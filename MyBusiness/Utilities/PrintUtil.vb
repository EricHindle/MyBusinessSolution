' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.Drawing.Printing
Imports System.Text
Imports System.IO

''' <summary>
''' Useful functions for printing
''' </summary>
''' <remarks></remarks>
Public Class PrintUtil : Implements IDisposable

#Region "Private variables"
    Private myPrintDoc As PrintDocument
    Private myPageSetUp As PageSetupDialog
    Private myDocumentText As StringBuilder
    Private myStringToPrint As String
    Private myStringFormat As StringFormat
    Private myFont As Font
    ' variable to trace text to print for pagination
    Private m_nFirstCharOnPage As Integer
    Private myRichTextBoxEx As New RichTextBoxEx

    Private imagePrintDocument As PrintDocument
    Private iPrintOption As Integer
    Private sImageFile As String = ""
    Private oImage As Image = Nothing
    Private myMaxColumnWidth As Integer
#End Region

#Region "properties"
    Public Property MaxColumnWidth() As Integer
        Get
            Return myMaxColumnWidth
        End Get
        Set(ByVal value As Integer)
            myMaxColumnWidth = value
        End Set
    End Property

    Public Property PrintDoc() As PrintDocument
        Get
            Return myPrintDoc
        End Get
        Set(ByVal value As PrintDocument)
            myPrintDoc = value
        End Set
    End Property

    Public Property PrintFont() As Font
        Get
            Return myFont
        End Get
        Set(ByVal value As Font)
            myFont = value
        End Set
    End Property

    Public Property StringToPrint() As String
        Get
            Return myStringToPrint
        End Get
        Set(ByVal value As String)
            myStringToPrint = value
        End Set
    End Property

    Public ReadOnly Property PageSetup() As PageSetupDialog
        Get
            Return myPageSetUp
        End Get
    End Property
#End Region

#Region "new"
    ''' <summary>
    ''' Initializes a new instance of the Print Utility
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        myFont = New Font("Arial", 10, FontStyle.Regular)
        myPrintDoc = New PrintDocument
        myPageSetUp = New PageSetupDialog
        myStringFormat = New StringFormat(StringFormat.GenericTypographic)
        myMaxColumnWidth = 0
        AddHandler myPrintDoc.PrintPage, AddressOf txt_PrintPage
        myPrintDoc.DefaultPageSettings.Landscape = False
        myPrintDoc.DefaultPageSettings.PaperSize.RawKind = System.Drawing.Printing.PaperKind.A4
        myPrintDoc.DefaultPageSettings.Margins.Left = 60
        myPrintDoc.DefaultPageSettings.Margins.Right = 60
        myPrintDoc.DefaultPageSettings.Margins.Top = 60
        myPrintDoc.DefaultPageSettings.Margins.Bottom = 60
        myPageSetUp.Document = myPrintDoc
        myPageSetUp.EnableMetric = True
    End Sub
#End Region

#Region "Image Print"
    ''' <summary>
    ''' Prepare print document - size, margins, etc.
    ''' </summary>
    ''' <param name="isLandscape">True if landscape print</param>
    ''' <param name="pPaperKind">Paper size (defaults to A4(</param>
    ''' <remarks></remarks>
    Public Sub PreparePrintDocument(Optional ByVal isLandscape As Boolean = False, Optional ByVal pPaperKind As System.Drawing.Printing.PaperKind = PaperKind.A4)
        ' prepare print document
        ' set default paper size (A4) and margins (0.5 inch)
        imagePrintDocument = New PrintDocument
        For Each ps As PaperSize In imagePrintDocument.PrinterSettings.PaperSizes
            If ps.RawKind = pPaperKind Then
                imagePrintDocument.DefaultPageSettings.PaperSize = ps
                Exit For
            End If
        Next
        AddHandler imagePrintDocument.PrintPage, AddressOf OnPrintImage
        imagePrintDocument.DefaultPageSettings.Landscape = isLandscape
        imagePrintDocument.DefaultPageSettings.Margins.Left = 50
        imagePrintDocument.DefaultPageSettings.Margins.Right = 50
        imagePrintDocument.DefaultPageSettings.Margins.Top = 50
        imagePrintDocument.DefaultPageSettings.Margins.Bottom = 50
    End Sub

    ''' <summary>
    ''' Returns image print docuemnt to aid testing
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetImagePrintDocument() As PrintDocument
        Return imagePrintDocument
    End Function

    ''' <summary>
    ''' Print an image from a file
    ''' </summary>
    ''' <param name="pImageFile">Filename of image file</param>
    ''' <param name="printOption">Print option</param>
    ''' <remarks> Print options
    ''' 0 = print to fill available space
    ''' 1 =
    ''' 2 = print maximum size retaining aspect ratio
    ''' 3 = print into half the available space
    ''' 4 = print actual size
    ''' </remarks>
    Public Sub PrintSelectedImage(pImageFile As String, printOption As Integer)
        sImageFile = pImageFile
        oImage = Nothing
        iPrintOption = printOption
        imagePrintDocument.Print()

    End Sub

    ''' <summary>
    ''' Print an image from an image object
    ''' </summary>
    ''' <param name="printOption">Print option</param>
    ''' <remarks> Print options
    ''' 0 = print to fill available space
    ''' 1 =
    ''' 2 = print maximum size retaining aspect ratio
    ''' 3 = print into half the available space
    ''' 4 = print actual size
    ''' </remarks>
    ''' 
    Public Sub PrintSelectedImage(pImage As Image, printOption As Integer)
        sImageFile = Nothing
        oImage = pImage
        iPrintOption = printOption
        imagePrintDocument.Print()

    End Sub

    Private Sub OnPrintImage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        'print options
        ' 0 = print to fill available space
        ' 1 =
        ' 2 = print maximum size retaining aspect ratio
        ' 3 = print into half the available space
        ' 4 = print actual size


        '
        ' Print the image if the file exists
        '
        ' calculate the printable page size
        ' by subtracting the margins from the actual page size

        Dim leftMargin As Single = e.MarginBounds.Left
        Dim topMargin As Single = e.MarginBounds.Top

        Dim iPrintWidth As Integer = e.MarginBounds.Width
        Dim iPrintHeight As Integer = e.MarginBounds.Height
        Dim iOutWidth As Integer = iPrintWidth
        Dim iOutHeight As Integer = iPrintHeight
        Dim iTextTop As Integer = 0
        Dim imageFrm As Bitmap = Nothing
        ' create an image

        If oImage Is Nothing Then
            If My.Computer.FileSystem.FileExists(sImageFile) Then
                imageFrm = Image.FromFile(sImageFile)
            End If
        Else
            imageFrm = oImage
        End If

        Select Case iPrintOption
            Case 2
                If iOutHeight > iOutWidth Then
                    iOutHeight = iOutWidth * (imageFrm.Height / imageFrm.Width)
                Else
                    iOutWidth = iOutHeight * (imageFrm.Width / imageFrm.Height)
                End If
            Case 3
                iOutWidth = iPrintWidth / 2
                iOutHeight = iPrintHeight / 2
            Case 4
                iOutWidth = imageFrm.Width
                iOutHeight = imageFrm.Height
        End Select

        ' DRAW THE IMAGE scaled to the print area
        e.Graphics.DrawImage(imageFrm, leftMargin, topMargin, iOutWidth, iOutHeight)
    End Sub
#End Region

#Region "Private Subroutines"
    ''' <summary>
    ''' Set appropriate handlers depending on document type
    ''' </summary>
    ''' <param name="isRtf"></param>
    ''' <remarks></remarks>
    Private Sub SetRtf(ByVal isRtf As Boolean)
        If isRtf Then
            RemoveHandler myPrintDoc.PrintPage, AddressOf txt_PrintPage
            AddHandler PrintDoc.BeginPrint, AddressOf rtf_BeginPrint
            AddHandler PrintDoc.PrintPage, AddressOf rtf_PrintPage
            AddHandler PrintDoc.EndPrint, AddressOf rtf_EndPrint
        Else
            RemoveHandler PrintDoc.BeginPrint, AddressOf rtf_BeginPrint
            RemoveHandler PrintDoc.PrintPage, AddressOf rtf_PrintPage
            RemoveHandler PrintDoc.EndPrint, AddressOf rtf_EndPrint
            AddHandler myPrintDoc.PrintPage, AddressOf txt_PrintPage
        End If
    End Sub

    Private Function FormatGridForPrinting(ByRef dgv As DataGridView) As DataGridView
        Dim formattedDgv As New DataGridView
        For Each oCol As DataGridViewColumn In dgv.Columns
            formattedDgv.Columns.Add(oCol.Clone)
        Next
        formattedDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        For Each oRow As DataGridViewRow In dgv.Rows
            Dim r As Integer = formattedDgv.Rows.Add()
            Dim newRow As DataGridViewRow = formattedDgv.Rows(r)
            For Each oCell As DataGridViewCell In oRow.Cells
                Dim newCell As DataGridViewCell = newRow.Cells(oCell.ColumnIndex)
                Dim cellValue As String = ""
                If oCell.Value IsNot Nothing Then
                    If oCell.ValueType Is GetType(Date) Then
                        cellValue = (Format(oCell.Value, "dd/MM/yyyy"))
                    Else
                        cellValue = CStr(oCell.Value).Trim
                    End If
                End If
                If myMaxColumnWidth > 0 Then
                    Do While cellValue.Length > 0 AndAlso TextRenderer.MeasureText(cellValue, myFont).Width > myMaxColumnWidth
                        cellValue = cellValue.Substring(0, cellValue.Length - 1)
                    Loop
                End If
                newCell.Value = cellValue
            Next
        Next
        formattedDgv.AutoResizeColumns()

        Return formattedDgv
    End Function

    Private Sub Txt_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        '
        ' Print the image if the file exists
        '
        Dim charactersOnPage As Integer = 0
        Dim linesPerPage As Integer = 0
        Dim printFont As Font = myFont

        ' Sets the value of charactersOnPage to the number of characters 
        ' of stringToPrint that will fit within the bounds of the page.
        e.Graphics.MeasureString(myStringToPrint, printFont, e.MarginBounds.Size,
            myStringFormat, charactersOnPage, linesPerPage)

        Dim myStringOnThisPage As String = myStringToPrint.Substring(0, charactersOnPage)
        ' Draws the string within the bounds of the page
        e.Graphics.DrawString(myStringOnThisPage, printFont, Brushes.Black,
            e.MarginBounds, myStringFormat)

        ' Remove the portion of the string that has been printed.
        myStringToPrint = myStringToPrint.Substring(charactersOnPage)

        ' Check to see if more pages are to be printed.
        e.HasMorePages = myStringToPrint.Length > 0

    End Sub

    Private Sub Rtf_BeginPrint(ByVal sender As Object,
        ByVal e As System.Drawing.Printing.PrintEventArgs)
        ' Start at the beginning of the text
        m_nFirstCharOnPage = 0
    End Sub

    Private Sub Rtf_PrintPage(ByVal sender As Object,
        ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        ' make the RichTextBoxEx calculate and render as much text as will
        ' fit on the page and remember the last character printed for the
        ' beginning of the next page
        m_nFirstCharOnPage = myRichTextBoxEx.FormatRange(False,
                                                e,
                                                m_nFirstCharOnPage,
                                                myRichTextBoxEx.TextLength)

        ' check if there are more pages to print
        If (m_nFirstCharOnPage < myRichTextBoxEx.TextLength) Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

    Private Sub Rtf_EndPrint(ByVal sender As Object,
        ByVal e As System.Drawing.Printing.PrintEventArgs)
        ' Clean up cached information
        myRichTextBoxEx.FormatRangeDone()
    End Sub
#End Region

#Region "Public Subroutines"
    ''' <summary>
    ''' Split a line of text into an array list of strings with a maximum length
    ''' without splitting words
    ''' </summary>
    ''' <param name="StringToFormat">text to be split</param>
    ''' <param name="MaxLineLen">maximum line length</param>
    ''' <returns>array list of strings</returns>
    ''' <remarks></remarks>
    Public Shared Function WrapString(ByVal StringToFormat As String, ByVal MaxLineLen As Integer) As ArrayList
        Dim TempString As String
        Dim Pos As Long
        Dim stringArray As New ArrayList
        Pos = 1
        While StringToFormat <> ""
            If Len(StringToFormat) <= MaxLineLen Then
                TempString = Trim(StringToFormat)
            Else
                TempString = Mid(StringToFormat, Pos, MaxLineLen + 1)
                TempString = Trim(Left(TempString, InStrRev(TempString, " ")))
            End If
            stringArray.Add(TempString)
            StringToFormat = LTrim(Right(StringToFormat, Len(StringToFormat) - Len(TempString)))
        End While
        Return stringArray
    End Function

    ''' <summary>
    ''' Generate an array of numeric values to be used as tab stops from the contents of a data grid view table
    ''' </summary>
    ''' <param name="dgv">Table to use as source</param>
    ''' <returns>array of tab stop values</returns>
    ''' <remarks></remarks>
    Public Function SetTabStopsFromColumns(ByRef dgv As DataGridView) As Single()
        Dim tabStops(dgv.ColumnCount - 1) As Single
        For Each ocol As DataGridViewColumn In dgv.Columns
            Dim colWidth As Integer = ocol.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, True)
            tabStops(ocol.Index) = If(myMaxColumnWidth > 0, Math.Min(colWidth, myMaxColumnWidth), colWidth)
        Next
        Return tabStops
    End Function

    ''' <summary>
    ''' Print a datagrid view table
    ''' </summary>
    ''' <param name="dg">Table top be printed</param>
    ''' <param name="oReportDef">Report definition to be used to determine the print format</param>
    ''' <param name="asRtf">True if report should be put into an extended rich text box before printing to take advantage of tabs</param>
    ''' <remarks></remarks>
    Public Sub PrintGrid(ByRef dg As DataGridView, ByRef oReportDef As ReportDefinition, Optional ByVal asRtf As Boolean = True, Optional ByVal printInvisibleRows As Boolean = True)
        SetRtf(asRtf)
        myFont = oReportDef.Font
        If oReportDef.TabStops Is Nothing Then
            oReportDef.TabStops = SetTabStopsFromColumns(dg)
        End If
        myStringFormat.SetTabStops(0.0F, oReportDef.TabStops)
        myPrintDoc.DocumentName() = oReportDef.ReportHead
        myDocumentText = New StringBuilder(oReportDef.ReportHead.Replace("}", vbCrLf) & vbCrLf & vbCrLf)
        ' Print headings
        For Each oCol As DataGridViewColumn In dg.Columns
            myDocumentText.Append(CStr(oCol.HeaderText).Trim).Append(vbTab)
        Next
        myDocumentText.Append(vbCrLf)
        Dim iRowCt As Integer = 0
        For Each oRow As DataGridViewRow In dg.Rows
            If oRow.Visible Or printInvisibleRows Then
                Dim hasValue As Boolean = False
                For Each oCell As DataGridViewCell In oRow.Cells

                    Dim cellValue As String = ""
                    If oCell.Value IsNot Nothing AndAlso oCell.Value IsNot DBNull.Value Then
                        hasValue = True
                        If oCell.ValueType Is GetType(Date) Then
                            cellValue = (Format(oCell.Value, "dd/MM/yyyy"))
                        Else
                            cellValue = CStr(oCell.Value).Trim
                        End If

                        If myMaxColumnWidth > 0 Then
                            Do While cellValue.Length > 0 AndAlso TextRenderer.MeasureText(cellValue, myFont).Width > myMaxColumnWidth
                                cellValue = cellValue.Substring(0, cellValue.Length - 1)
                            Loop
                        End If
                    Else
                        cellValue = ""
                    End If
                    myDocumentText.Append(cellValue).Append(vbTab)
                Next
                myDocumentText.Append(vbCrLf)
                If hasValue Then
                    iRowCt += 1
                End If
            End If
        Next
        If oReportDef.ShowCount Then
            myDocumentText.Append(CStr(iRowCt)).Append(" records selected").Append(vbCrLf)
        End If
        If asRtf Then
            myRichTextBoxEx = New RichTextBoxEx

            myRichTextBoxEx.SelectAll()
            Dim tabstops(oReportDef.TabStops.Length - 1) As Int32
            For t = 0 To oReportDef.TabStops.Length - 1
                tabstops(t) = CInt(oReportDef.TabStops(t)) + If(t = 0, 0, tabstops(t - 1))
            Next
            myRichTextBoxEx.SelectionTabs = tabstops

            myRichTextBoxEx.Text = myDocumentText.ToString
            If myRichTextBoxEx IsNot Nothing Then
                myPrintDoc.Print()
            End If
        Else
            myStringToPrint = myDocumentText.ToString
            myPrintDoc.Print()
        End If

    End Sub

    ''' <summary>
    ''' Convert a data grid view table into text
    ''' </summary>
    ''' <param name="dg">Table to be converted</param>
    ''' <returns>String representation of the table</returns>
    ''' <remarks></remarks>
    Public Function GridToText(ByRef dg As DataGridView) As String
        Dim rtnText As New StringBuilder
        ' Print headings
        For Each oCol As DataGridViewColumn In dg.Columns
            rtnText.Append(oCol.HeaderText).Append(vbTab)
        Next
        rtnText.Append(vbCrLf)

        For Each oRow As DataGridViewRow In dg.Rows
            For Each oCell As DataGridViewCell In oRow.Cells

                If oCell.ValueType Is GetType(Date) Then
                    rtnText.Append(Format(oCell.Value, "dd/MM/yyyy")).Append(vbTab)
                Else
                    rtnText.Append(oCell.Value).Append(vbTab)
                End If
            Next
            rtnText.Append(vbCrLf)
        Next
        Return rtnText.ToString
    End Function

    ''' <summary>
    ''' Print a string using the report definition to determine the format
    ''' </summary>
    ''' <param name="sText">text to be printed</param>
    ''' <param name="oReportDef">Report definition to determine the format</param>
    ''' <remarks></remarks>
    Public Sub PrintText(ByRef sText As String, ByRef oReportDef As ReportDefinition)
        SetRtf(False)
        myFont = oReportDef.Font
        myStringFormat.SetTabStops(0.0F, oReportDef.TabStops)
        myPrintDoc.DocumentName() = oReportDef.ReportHead
        myStringToPrint = sText
        myPrintDoc.Print()

    End Sub

    ''' <summary>
    ''' Load rtf file into an extended rich text box then print it
    ''' </summary>
    ''' <param name="sFilename">Filename of file to be printed</param>
    ''' <remarks></remarks>
    Public Sub PrintRtfFile(ByVal sFilename As String)
        SetRtf(True)
        If File.Exists(sFilename) Then
            myRichTextBoxEx = New RichTextBoxEx
            myRichTextBoxEx.LoadFile(sFilename)
            myPrintDoc.Print()
        End If
    End Sub

    ''' <summary>
    ''' Print the contents of a rich text box by loading it into an extended rich text box
    ''' </summary>
    ''' <param name="rtb">Rich text box to be printed</param>
    ''' <remarks></remarks>
    Public Sub PrintRichTextBox(ByVal rtb As RichTextBoxEx)
        SetRtf(True)
        myRichTextBoxEx = rtb
        If myRichTextBoxEx IsNot Nothing Then
            myPrintDoc.Print()
        End If
    End Sub
#End Region

#Region "Dispose"
    Dim disposed As Boolean = False
    Public Sub Dispose() _
         Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposed Then
            If disposing Then
                If myFont IsNot Nothing Then
                    myFont.Dispose()
                End If
                If myRichTextBoxEx IsNot Nothing Then
                    myRichTextBoxEx.Dispose()
                End If
                If myStringFormat IsNot Nothing Then
                    myStringFormat.Dispose()
                End If
                If myPrintDoc IsNot Nothing Then
                    myPrintDoc.Dispose()
                End If
                If myPageSetUp IsNot Nothing Then
                    myPageSetUp.Dispose()
                End If
                If imagePrintDocument IsNot Nothing Then
                    imagePrintDocument.Dispose()
                End If
            End If
            myFont = Nothing
            myRichTextBoxEx = Nothing
            myStringFormat = Nothing
            myPrintDoc = Nothing
            myPageSetUp = Nothing
            imagePrintDocument = Nothing
            disposed = True
        End If
        disposed = True
    End Sub
#End Region

End Class
