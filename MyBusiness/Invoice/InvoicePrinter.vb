Imports System.Text
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Public Class InvoicePrinter
    Private _job As job
    Private _iTextManager As New iTextManager
    Private myReportDef As ReportDefinition
    Private myPrintUtil As PrintUtil
    'Private _HdrFont As iTextSharp.text.Font
    'Private _BodyFont As iTextSharp.text.Font
    'Private _CmpyNameFont As iTextSharp.text.Font
    'Private _CmpyAddrFont As iTextSharp.text.Font
    'Private _BodyLargeFont As iTextSharp.text.Font
    Private _FtrFont As iTextSharp.text.Font
    Private _nextInvoiceNumber As Integer
    Private _companyName As String = GlobalSettings.getStringSetting(GlobalSettings.COMPANY_NAME)
    Private _companyAddress As String() = GlobalSettings.getStringSetting(GlobalSettings.COMPANY_ADDRESS).Split("/")
    Private _companyEmail As String = GlobalSettings.getStringSetting(GlobalSettings.COMPANY_EMAIL)
    Private _companyUrl As String = GlobalSettings.getStringSetting(GlobalSettings.COMPANY_WEBSITE)

    Private oTaskTa As New netwyrksDataSetTableAdapters.taskTableAdapter
    Private oTaskTable As New netwyrksDataSet.taskDataTable

    Private oJobProductTa As New netwyrksDataSetTableAdapters.job_productTableAdapter
    Private oJobProductTable As New netwyrksDataSet.job_productDataTable

    Private Const LEFT_MARGIN As Integer = 32
    Private Const RIGHT_MARGIN As Integer = 32
    Private Const TOP_MARGIN As Integer = 32
    Private Const BOTTOM_MARGIN As Integer = 32
    Private Const AMOUNT_FORMAT As String = "#####0.00"
    Private Const RATE_FORMAT As String = "##0.00"
    Private Const QTY_FORMAT As String = "#####0"


    Public Sub New()
        myReportDef = New ReportDefinition()
        myReportDef.ReportHead = "Invoice"
        myPrintUtil = New PrintUtil
        initialisePrint()

        _FtrFont = iTextSharp.text.FontFactory.GetFont(My.Settings.InvFtrFont.Name, My.Settings.InvFtrFont.Size)


    End Sub

    Public Sub createInvoicePdf(ByVal sFilename As String)
        Dim totalPrice As Decimal = 0.0
        Dim totalTax As Decimal = 0.0
        Dim grandTotal As Decimal = 0.0
        Dim _document As New Document(PageSize.A4, LEFT_MARGIN, RIGHT_MARGIN, TOP_MARGIN, BOTTOM_MARGIN)
        Dim _writer As PdfWriter = PdfWriter.GetInstance(_document, New FileStream(sFilename, FileMode.Create, FileAccess.Write))
        _document.Open()
        Dim _companyNamePara As New Paragraph(_companyName, iTextManager.companyNameFont)
        _document.Add(_companyNamePara)
        Dim _companyTable As iTextSharp.text.pdf.PdfPTable = _iTextManager.buildTable(New Single() {15, 85})

        Dim _logoCell As New iTextSharp.text.pdf.PdfPCell(_iTextManager.createImageCell(GlobalSettings.getStringSetting(GlobalSettings.COMPANY_LOGOFILE)))
        _logoCell.Rowspan = 6
        _logoCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
        _logoCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
        _logoCell.Border = iTextSharp.text.Rectangle.NO_BORDER
        _companyTable.AddCell(_logoCell)

        For Each sAddress As String In _companyAddress
            Dim _addrCell As New iTextSharp.text.pdf.PdfPCell(New Paragraph(sAddress, iTextManager.companyAddressFont))
            _addrCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            _addrCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            _companyTable.AddCell(_addrCell)
        Next

        _companyTable.AddCell(_iTextManager.emptyCell)

        If Not String.IsNullOrEmpty(_companyEmail) Then
            Dim _cell As New iTextSharp.text.pdf.PdfPCell(New Paragraph(_companyEmail, iTextManager.companyAddressFont))
            _cell.Border = iTextSharp.text.Rectangle.NO_BORDER
            _cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            _companyTable.AddCell(_iTextManager.emptyCell)
            _companyTable.AddCell(_cell)
        End If
        If Not String.IsNullOrEmpty(_companyUrl) Then
            Dim _cell As New iTextSharp.text.pdf.PdfPCell(New Paragraph(_companyUrl, iTextManager.companyAddressFont))
            _cell.Border = iTextSharp.text.Rectangle.NO_BORDER
            _cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            _companyTable.AddCell(_iTextManager.emptyCell)
            _companyTable.AddCell(_cell)
        End If
        _document.Add(_companyTable)

        _document.Add(New Paragraph("Invoice", iTextManager.headerFont))
        _document.Add(Chunk.NEWLINE)
        _document.Add(New Paragraph(_job.jobName, iTextManager.bodyLargeFont))
        Dim _jobDescription As String() = _job.jobDescription.Replace(vbCrLf, "~").Replace(vbLf, "~").Split("~")
        For Each sLine As String In _jobDescription
            _document.Add(New Paragraph(sLine, iTextManager.bodyFont))
        Next
        _document.Add(Chunk.NEWLINE)

        Dim _taskTable As iTextSharp.text.pdf.PdfPTable = _iTextManager.buildTable(New Single() {40, 15, 15, 12, 18})
        _taskTable.AddCell(_iTextManager.buildTableHeaderCell(" "))
        _taskTable.AddCell(_iTextManager.buildTableHeaderCell("Price (£)"))
        _taskTable.AddCell(_iTextManager.buildTableHeaderCell("Tax rate"))
        _taskTable.AddCell(_iTextManager.buildTableHeaderCell("Tax (£)"))
        _taskTable.AddCell(_iTextManager.buildTableHeaderCell("Total (£)"))

        For Each oTaskRow As netwyrksDataSet.taskRow In oTaskTable.Rows
            Dim oTask As Task = TaskBuilder.aTaskBuilder.startingWith(oTaskRow).build
            Dim taxAmount As Decimal = calcTax(oTask.taskCost, oTask.taskTaxRate)
            _taskTable.AddCell(_iTextManager.buildTableCell(oTask.taskDescription, Element.ALIGN_LEFT))
            _taskTable.AddCell(_iTextManager.buildTableCell(Format(oTask.taskCost, AMOUNT_FORMAT)))
            totalPrice += oTask.taskCost
            _taskTable.AddCell(_iTextManager.buildTableCell(Format(oTask.taskTaxRate, RATE_FORMAT)))
            _taskTable.AddCell(_iTextManager.buildTableCell(Format(taxAmount, AMOUNT_FORMAT)))
            totalTax += taxAmount
            _taskTable.AddCell(_iTextManager.buildTableCell(Format(oTask.taskCost + taxAmount, AMOUNT_FORMAT)))
        Next
        _document.Add(_taskTable)

        Dim _productTable As iTextSharp.text.pdf.PdfPTable = _iTextManager.buildTable(New Single() {30, 10, 15, 15, 12, 18})
        _productTable.AddCell(_iTextManager.buildTableHeaderCell(" "))
        _productTable.AddCell(_iTextManager.buildTableHeaderCell("Qty"))
        _productTable.AddCell(_iTextManager.buildTableHeaderCell("Unit price (£)"))
        _productTable.AddCell(_iTextManager.buildTableHeaderCell("Tax rate"))
        _productTable.AddCell(_iTextManager.buildTableHeaderCell("Tax (£)"))
        _productTable.AddCell(_iTextManager.buildTableHeaderCell("Total (£)"))

        For Each oJobProduct As netwyrksDataSet.job_productRow In oJobProductTable.Rows
            Dim oProduct As Product = ProductBuilder.aProductBuilder.startingWith(oJobProduct.jp_product_id).build
            Dim taxAmount As Decimal = calcTax(oProduct.productPrice, oJobProduct.jp_tax_rate)
            _productTable.AddCell(_iTextManager.buildTableCell(oProduct.productName))
            _productTable.AddCell(_iTextManager.buildTableCell(CStr(oJobProduct.jp_quantity)))
            _productTable.AddCell(_iTextManager.buildTableCell(Format(oProduct.productPrice, AMOUNT_FORMAT)))
            totalPrice += oProduct.productPrice * oJobProduct.jp_quantity
            _productTable.AddCell(_iTextManager.buildTableCell(Format(oJobProduct.jp_tax_rate, RATE_FORMAT)))
            _productTable.AddCell(_iTextManager.buildTableCell(Format(taxAmount * oJobProduct.jp_quantity, AMOUNT_FORMAT)))
            totalTax += taxAmount * oJobProduct.jp_quantity
            _productTable.AddCell(_iTextManager.buildTableCell(Format((oProduct.productPrice + taxAmount) * oJobProduct.jp_quantity, AMOUNT_FORMAT)))
        Next
        _document.Add(_productTable)

        grandTotal = totalPrice + totalTax
        Dim _totalTable As iTextSharp.text.pdf.PdfPTable = _iTextManager.buildTable(New Single() {50, 50})
        _totalTable.AddCell(_iTextManager.buildTableCell("Total Price"))
        _totalTable.AddCell(_iTextManager.buildTableCell(Format(totalPrice, AMOUNT_FORMAT)))
        _totalTable.AddCell(_iTextManager.buildTableCell("Total Tax"))
        _totalTable.AddCell(_iTextManager.buildTableCell(Format(totalTax, AMOUNT_FORMAT)))
        _totalTable.AddCell(_iTextManager.buildTableCell("Grand Total"))
        _totalTable.AddCell(_iTextManager.buildTableCell(Format(grandTotal, AMOUNT_FORMAT)))
        _document.Add(_totalTable)





        _document.Close()
    End Sub

    Private Function calcTax(ByVal _amount As Decimal, ByVal _rate As Decimal) As Decimal
        Return _amount * _rate / 100
    End Function



    Public Sub CreateInvoice(ByRef pJob As job)
        LogUtil.Info("Printing Invoice", Me.GetType.Name)
        _job = pJob
        oTaskTa.FillByJob(oTaskTable, _job.jobId)
        oJobProductTa.FillByJob(oJobProductTable, _job.jobId)

        _nextInvoiceNumber = CInt(GlobalSettings.getSetting(GlobalSettings.INVOICE_NUMBER)) + 1
        GlobalSettings.setSetting(GlobalSettings.INVOICE_NUMBER, "integer", CStr(_nextInvoiceNumber))

        Dim sFilename As String = Path.Combine(sReportFolder, "Invoice_" & CStr(_nextInvoiceNumber) & ".pdf")
        createInvoicePdf(sFilename)

        Using _viewInvoice As New dlgViewInvoice
            _viewInvoice.Filename = sFilename
            _viewInvoice.ShowDialog()
        End Using
        'End If
    End Sub


    Public Sub initialisePrint()
        ' Initialise print document
        prtUtil.PrintDoc.DefaultPageSettings.Landscape = False
        prtUtil.PrintDoc.DefaultPageSettings.Margins = New Drawing.Printing.Margins(25, 25, 25, 60)
        prtUtil.MaxColumnWidth = 150
        showPrinterSettings()
    End Sub


    Private Sub printerSetup()
        Using _pageSetup As PageSetupDialog = prtUtil.PageSetup
            _pageSetup.ShowDialog()
            showPrinterSettings()
        End Using
    End Sub

    Private Sub showPrinterSettings()
        Dim lblOrientation As String = If(prtUtil.PrintDoc.DefaultPageSettings.Landscape, "Landscape", "Portrait")
        Dim lblPaperSize As String = [Enum].GetName(GetType(System.Drawing.Printing.PaperKind), prtUtil.PrintDoc.DefaultPageSettings.PaperSize.RawKind)
        Dim lblPrinter As String = prtUtil.PrintDoc.DefaultPageSettings.PrinterSettings.PrinterName
    End Sub

End Class
