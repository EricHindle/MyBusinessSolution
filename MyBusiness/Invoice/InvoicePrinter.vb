' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports HindlewareLib.Logging
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports HindlewareLib.Utilities
Public Class InvoicePrinter
#Region "variables"
    Private _job As Job
    Private ReadOnly _iTextManager As New ITextManager
    Private ReadOnly myReportDef As ReportDefinition
    Private ReadOnly myPrintUtil As PrintUtil
    'Private _HdrFont As iTextSharp.text.Font
    'Private _BodyFont As iTextSharp.text.Font
    'Private _CmpyNameFont As iTextSharp.text.Font
    'Private _CmpyAddrFont As iTextSharp.text.Font
    'Private _BodyLargeFont As iTextSharp.text.Font
    Private ReadOnly _FtrFont As iTextSharp.text.Font
    Private _nextInvoiceNumber As Integer
    Private ReadOnly _companyName As String = GlobalSettings.GetStringSetting(GlobalSettings.COMPANY_NAME)
    Private ReadOnly _companyAddress As String() = GlobalSettings.GetStringSetting(GlobalSettings.COMPANY_ADDRESS).Split("/")
    Private ReadOnly _companyEmail As String = GlobalSettings.GetStringSetting(GlobalSettings.COMPANY_EMAIL)
    Private ReadOnly _companyUrl As String = GlobalSettings.GetStringSetting(GlobalSettings.COMPANY_WEBSITE)
    Private ReadOnly oTaskTa As New netwyrksDataSetTableAdapters.job_taskTableAdapter
    Private ReadOnly oTaskTable As New netwyrksDataSet.job_taskDataTable
    Private ReadOnly oJobProductTa As New netwyrksDataSetTableAdapters.job_productTableAdapter
    Private ReadOnly oJobProductTable As New netwyrksDataSet.job_productDataTable
    Private Const LEFT_MARGIN As Integer = 32
    Private Const RIGHT_MARGIN As Integer = 32
    Private Const TOP_MARGIN As Integer = 32
    Private Const BOTTOM_MARGIN As Integer = 32
    Private Const AMOUNT_FORMAT As String = "#####0.00"
    Private Const RATE_FORMAT As String = "##0.00"
    Private Const QTY_FORMAT As String = "#####0"
#End Region
#Region "functions"
    Public Sub New()
        myReportDef = New ReportDefinition With {
            .ReportHead = "Invoice"
        }
        myPrintUtil = New PrintUtil
        InitialisePrint()
        _FtrFont = iTextSharp.text.FontFactory.GetFont(My.Settings.InvFtrFont.Name, My.Settings.InvFtrFont.Size)
    End Sub
    Public Sub CreateInvoicePdf(ByVal sFilename As String)
        Dim totalPrice As Decimal = 0.0
        Dim totalTax As Decimal = 0.0
        Dim grandTotal As Decimal
        Dim _document As New Document(PageSize.A4, LEFT_MARGIN, RIGHT_MARGIN, TOP_MARGIN, BOTTOM_MARGIN)
        Dim _writer As PdfWriter = PdfWriter.GetInstance(_document, New FileStream(sFilename, FileMode.Create, FileAccess.Write))
        _document.Open()
        Dim _companyNameTable As iTextSharp.text.pdf.PdfPTable = _iTextManager.BuildTable(New Single() {100})
        Dim _companyNameCell As New iTextSharp.text.pdf.PdfPCell(New Paragraph(_companyName, ITextManager.companyNameFont)) With {
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                .Border = iTextSharp.text.Rectangle.NO_BORDER
            }
        _companyNameTable.AddCell(_companyNameCell)
        _document.Add(_companyNameTable)
        Dim _companyTable As iTextSharp.text.pdf.PdfPTable = _iTextManager.BuildTable(New Single() {15, 85})
        Dim _logoCell As New iTextSharp.text.pdf.PdfPCell(_iTextManager.CreateImageCell(GlobalSettings.GetStringSetting(GlobalSettings.COMPANY_LOGOFILE))) With {
            .Rowspan = 6,
            .HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
            .VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
            .Border = iTextSharp.text.Rectangle.NO_BORDER
        }
        _companyTable.AddCell(_logoCell)
        For Each sAddress As String In _companyAddress
            Dim _addrCell As New iTextSharp.text.pdf.PdfPCell(New Paragraph(sAddress, ITextManager.companyAddressFont)) With {
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT,
                .Border = iTextSharp.text.Rectangle.NO_BORDER
            }
            _companyTable.AddCell(_addrCell)
        Next
        _companyTable.AddCell(_iTextManager.EmptyCell)
        If Not String.IsNullOrEmpty(_companyEmail) Then
            Dim _cell As New iTextSharp.text.pdf.PdfPCell(New Paragraph(_companyEmail, ITextManager.companyAddressFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            }
            _companyTable.AddCell(_iTextManager.EmptyCell)
            _companyTable.AddCell(_cell)
        End If
        If Not String.IsNullOrEmpty(_companyUrl) Then
            Dim _cell As New iTextSharp.text.pdf.PdfPCell(New Paragraph(_companyUrl, ITextManager.companyAddressFont)) With {
                .Border = iTextSharp.text.Rectangle.NO_BORDER,
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            }
            _companyTable.AddCell(_iTextManager.EmptyCell)
            _companyTable.AddCell(_cell)
        End If
        _document.Add(_companyTable)
        _document.Add(New Paragraph("Invoice", ITextManager.headerFont))
        _document.Add(Chunk.NEWLINE)
        _document.Add(New Paragraph(_job.JobName, ITextManager.bodyLargeFont))
        Dim _jobDescription As String() = _job.JobDescription.Replace(vbCrLf, "~").Replace(vbLf, "~").Split("~")
        For Each sLine As String In _jobDescription
            _document.Add(New Paragraph(sLine, ITextManager.bodyFont))
        Next
        _document.Add(Chunk.NEWLINE)
        Dim _taskTable As iTextSharp.text.pdf.PdfPTable = _iTextManager.BuildTable(New Single() {40, 15, 15, 12, 18})
        _taskTable.AddCell(_iTextManager.BuildTableHeaderCell(" "))
        _taskTable.AddCell(_iTextManager.BuildTableHeaderCell("Price (£)"))
        _taskTable.AddCell(_iTextManager.BuildTableHeaderCell("Tax rate"))
        _taskTable.AddCell(_iTextManager.BuildTableHeaderCell("Tax (£)"))
        _taskTable.AddCell(_iTextManager.BuildTableHeaderCell("Total (£)"))
        For Each oTaskRow As netwyrksDataSet.job_taskRow In oTaskTable.Rows
            Dim oJobTask As JobTask = JobTaskBuilder.AJobTask.StartingWith(oTaskRow).Build
            Dim taxAmount As Decimal = CalcTax(oJobTask.TaskCost, oJobTask.TaskTaxRate)
            _taskTable.AddCell(_iTextManager.BuildTableCell(oJobTask.Task.TaskDescription, Element.ALIGN_LEFT))
            _taskTable.AddCell(_iTextManager.BuildTableCell(Format(oJobTask.TaskCost, AMOUNT_FORMAT)))
            totalPrice += oJobTask.TaskCost
            _taskTable.AddCell(_iTextManager.BuildTableCell(Format(oJobTask.TaskTaxRate, RATE_FORMAT)))
            _taskTable.AddCell(_iTextManager.BuildTableCell(Format(taxAmount, AMOUNT_FORMAT)))
            totalTax += taxAmount
            _taskTable.AddCell(_iTextManager.BuildTableCell(Format(oJobTask.TaskCost + taxAmount, AMOUNT_FORMAT)))
        Next
        _document.Add(_taskTable)
        Dim _productTable As iTextSharp.text.pdf.PdfPTable = _iTextManager.BuildTable(New Single() {30, 10, 15, 15, 12, 18})
        _productTable.AddCell(_iTextManager.BuildTableHeaderCell(" "))
        _productTable.AddCell(_iTextManager.BuildTableHeaderCell("Qty"))
        _productTable.AddCell(_iTextManager.BuildTableHeaderCell("Unit price (£)"))
        _productTable.AddCell(_iTextManager.BuildTableHeaderCell("Tax rate"))
        _productTable.AddCell(_iTextManager.BuildTableHeaderCell("Tax (£)"))
        _productTable.AddCell(_iTextManager.BuildTableHeaderCell("Total (£)"))
        For Each oJobProduct As netwyrksDataSet.job_productRow In oJobProductTable.Rows
            Dim oProduct As Product = GetProductById(oJobProduct.jp_product_id)
            Dim taxAmount As Decimal = CalcTax(oProduct.ProductPrice, oJobProduct.jp_tax_rate)
            _productTable.AddCell(_iTextManager.BuildTableCell(oProduct.ProductName))
            _productTable.AddCell(_iTextManager.BuildTableCell(oJobProduct.jp_quantity))
            _productTable.AddCell(_iTextManager.BuildTableCell(Format(oProduct.ProductPrice, AMOUNT_FORMAT)))
            totalPrice += oProduct.ProductPrice * oJobProduct.jp_quantity
            _productTable.AddCell(_iTextManager.BuildTableCell(Format(oJobProduct.jp_tax_rate, RATE_FORMAT)))
            _productTable.AddCell(_iTextManager.BuildTableCell(Format(taxAmount * oJobProduct.jp_quantity, AMOUNT_FORMAT)))
            totalTax += taxAmount * oJobProduct.jp_quantity
            _productTable.AddCell(_iTextManager.BuildTableCell(Format((oProduct.ProductPrice + taxAmount) * oJobProduct.jp_quantity, AMOUNT_FORMAT)))
        Next
        _document.Add(_productTable)
        grandTotal = totalPrice + totalTax
        Dim _totalTable As iTextSharp.text.pdf.PdfPTable = _iTextManager.BuildTable(New Single() {50, 50})
        _totalTable.AddCell(_iTextManager.BuildTableCell("Total Price"))
        _totalTable.AddCell(_iTextManager.BuildTableCell(Format(totalPrice, AMOUNT_FORMAT)))
        _totalTable.AddCell(_iTextManager.BuildTableCell("Total Tax"))
        _totalTable.AddCell(_iTextManager.BuildTableCell(Format(totalTax, AMOUNT_FORMAT)))
        _totalTable.AddCell(_iTextManager.BuildTableCell("Grand Total"))
        _totalTable.AddCell(_iTextManager.BuildTableCell(Format(grandTotal, AMOUNT_FORMAT)))
        _document.Add(_totalTable)
        _document.Close()
    End Sub
    Private Function CalcTax(ByVal _amount As Decimal, ByVal _rate As Decimal) As Decimal
        Return _amount * _rate / 100
    End Function
    Public Sub CreateInvoice(ByRef pJob As Job)
        LogUtil.Info("Printing Invoice", [GetType].Name)
        _job = pJob
        oTaskTa.FillByJob(oTaskTable, _job.JobId)
        oJobProductTa.FillByJob(oJobProductTable, _job.JobId)
        If String.IsNullOrWhiteSpace(_job.JobInvoiceNumber) OrElse Not IsNumeric(_job.JobInvoiceNumber) OrElse _job.JobInvoiceNumber <= 0 Then
            _nextInvoiceNumber = CInt(GlobalSettings.GetSettingValue(GlobalSettings.INVOICE_NUMBER)) + 1
            GlobalSettings.SetSetting(GlobalSettings.INVOICE_NUMBER, "integer", _nextInvoiceNumber)
            _job.JobInvoiceNumber = _nextInvoiceNumber
        End If
        _job.JobInvoiceDate = Now
        UpdateJob(_job)
        Dim _customer As Customer = CustomerBuilder.ACustomer.StartingWith(_job.JobCustomerId).Build
        Dim _customerFolder As String = Path.Combine(sInvoiceFolder, _customer.CustomerId & "_" & _customer.CustName)
        My.Computer.FileSystem.CreateDirectory(_customerFolder)
        Dim sFilename As String = Path.Combine(_customerFolder, "Invoice_" & _job.JobInvoiceNumber & ".pdf")
        CreateInvoicePdf(sFilename)
        Using _viewInvoice As New dlgViewInvoice
            _viewInvoice.Filename = sFilename
            _viewInvoice.ShowDialog()
        End Using
        'End If
    End Sub
    Public Sub InitialisePrint()
        ' Initialise print document
        prtUtil.PrintDoc.DefaultPageSettings.Landscape = False
        prtUtil.PrintDoc.DefaultPageSettings.Margins = New Drawing.Printing.Margins(25, 25, 25, 60)
        prtUtil.MaxColumnWidth = 150
        ShowPrinterSettings()
    End Sub
    Private Sub PrinterSetup()
        Using _pageSetup As PageSetupDialog = prtUtil.PageSetup
            _pageSetup.ShowDialog()
            ShowPrinterSettings()
        End Using
    End Sub
    Private Sub ShowPrinterSettings()
        Dim lblOrientation As String = If(prtUtil.PrintDoc.DefaultPageSettings.Landscape, "Landscape", "Portrait")
        Dim lblPaperSize As String = [Enum].GetName(GetType(System.Drawing.Printing.PaperKind), prtUtil.PrintDoc.DefaultPageSettings.PaperSize.RawKind)
        Dim lblPrinter As String = prtUtil.PrintDoc.DefaultPageSettings.PrinterSettings.PrinterName
    End Sub
#End Region
End Class
