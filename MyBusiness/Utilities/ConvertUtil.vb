'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports Microsoft.Office.Interop
Imports MyBusiness.netwyrksErrorCodes
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.Word

''' <summary>
''' The ConvertUtil module contains the procedures used to perform various conversion operations.
''' </summary>
''' <remarks></remarks>
Public Class ConvertUtil

    ''' <summary>
    ''' Convert a DataGridView table to HTML
    ''' Generates HTML that represents the structure and contents of the data grid
    ''' </summary>
    ''' <param name="dgv">The data grid table to convert</param>
    ''' <returns>HTML representation of the table</returns>
    ''' <remarks></remarks>
    Public Shared Function DataGridViewToHtmlTable(ByRef dgv As DataGridView) As String
        LogUtil.Debug("Converting data grid to html", "DataGridViewToHtmlTable")
        Dim sText As New StringBuilder("<table>")
        If dgv.ColumnHeadersVisible Then
            sText.Append("<tr>")
            For Each oCol As DataGridViewColumn In dgv.Columns

                sText.Append("<td>")
                sText.Append(oCol.HeaderText)
                sText.Append("</td>")
            Next
            sText.Append("</tr>")
        End If

        For Each oRow As DataGridViewRow In dgv.Rows
            sText.Append("<tr>")
            For Each oCell As DataGridViewCell In oRow.Cells
                sText.Append("<td>")
                If oCell.Value IsNot DBNull.Value Then
                    sText.Append(CStr(oCell.Value))
                Else
                    sText.Append("")
                End If
                sText.Append("</td>")
            Next
            sText.Append("</tr>")
        Next
        sText.Append("</table>")
        Return sText.ToString
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dgv">The data grid table to convert</param>
    ''' <param name="sFmt">The format to user for date values</param>
    ''' <param name="sSep">The separator to use between columns</param>
    ''' <returns>String representation of the table</returns>
    ''' <remarks></remarks>
    Public Shared Function DataGridViewToTextTable(ByRef dgv As DataGridView, Optional ByVal sFmt As String = Nothing, Optional ByVal sSep As String = vbTab) As String
        LogUtil.Debug("Converting data grid to text", "DataGridViewToTextTable")
        Dim sText As New StringBuilder()
        Dim isFirst As Boolean = True
        If dgv.ColumnHeadersVisible Then
            For Each oCol As DataGridViewColumn In dgv.Columns
                If oCol.Visible Then
                    If isFirst Then
                        isFirst = False
                    Else
                        sText.Append(sSep)
                    End If
                    sText.Append(oCol.HeaderText)

                End If
            Next
            sText.Append(vbCrLf)
        End If

        For Each oRow As DataGridViewRow In dgv.Rows
            isFirst = True
            For Each oCell As DataGridViewCell In oRow.Cells
                If oCell.Visible Then
                    If isFirst Then
                        isFirst = False
                    Else
                        sText.Append(sSep)
                    End If

                    If oCell.Value IsNot Nothing AndAlso oCell.Value IsNot DBNull.Value Then
                        Dim sVal As String = CStr(oCell.Value)

                        If sFmt IsNot Nothing Then
                            If oCell.Value.GetType Is GetType(System.DateTime) Then
                                sVal = Format(oCell.Value, sFmt)
                            End If
                        End If
                        '    If sVal.IndexOf(",") >= 0 Or sVal.IndexOf(sSep) >= 0 Then
                        If sVal.IndexOf(sSep) >= 0 Then
                            sText.Append("""").Append(sVal).Append("""")
                        Else
                            sText.Append(sVal)
                        End If
                    Else
                        sText.Append("")
                    End If

                End If
            Next
            sText.Append(vbCrLf)
        Next
        Return sText.ToString
    End Function

    ''' <summary>
    ''' Generates a new DataGridView from an existing one but without the columns marked as not visible
    ''' </summary>
    ''' <param name="oDgv">The data grid table to convert</param>
    ''' <returns>The data grid table without the columns marked as not visible</returns>
    ''' <remarks></remarks>
    Public Shared Function RemoveInvisibleColumns(ByRef oDgv As DataGridView) As DataGridView
        Dim oNewDgv As New DataGridView()
        Dim visibleCols As New List(Of Integer)
        For Each oCol As DataGridViewColumn In oDgv.Columns
            If oCol.Visible Then
                oNewDgv.Columns.Add(oCol.Clone)
                visibleCols.Add(oCol.Index)
            End If
        Next
        For Each orow As DataGridViewRow In oDgv.Rows
            Dim r As Integer = oNewDgv.Rows.Add()
            For v = 0 To visibleCols.Count - 1
                oNewDgv.Rows(r).Cells(v).Value = orow.Cells(visibleCols(v)).Value
            Next
        Next
        Return oNewDgv
    End Function

    ''' <summary>
    ''' Uses MS Word to create a .pdf document containing the supplied image
    ''' </summary>
    ''' <param name="imageFile">Filename of the image file</param>
    ''' <returns>Filename of the generated .pdf file</returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertImageToPdf(ByVal imageFile As String) As String
        LogUtil.Debug("Converting image to pdf")
        Dim sPdfFilename As String = Nothing
        If imageFile.Length > 0 AndAlso My.Computer.FileSystem.FileExists(imageFile) Then
            Dim sImagePath As String = Path.GetDirectoryName(imageFile)
            sPdfFilename = Path.Combine(sImagePath, Path.GetFileNameWithoutExtension(imageFile) & ".pdf")
            Dim oWordApp As Word.Application = Nothing
            Dim oWordDoc As Word.Document = Nothing
            Try
                LogUtil.Debug("Starting Word", "ConvertToPdf")
                Try
                    oWordApp = New Word.Application
                Catch ex1 As Exception
                    LogUtil.Exception("Error loading Word", ex1, "ConvertToPdf", getErrorCode(SystemModule.UTILITIES, ErrorType.APPLICATION, FailedAction.ERROR_STARTING_EXTERNAL_APP))
                    Throw New Exception("Error loading Word", ex1)
                End Try
                oWordDoc = New Word.Document
                oWordDoc = oWordApp.Documents.Add
                oWordDoc.PageSetup.PageHeight = oWordApp.CentimetersToPoints(15)
                oWordDoc.PageSetup.PageWidth = oWordApp.CentimetersToPoints(20)
                oWordDoc.PageSetup.TopMargin = oWordApp.CentimetersToPoints(1.5)
                oWordDoc.PageSetup.BottomMargin = oWordApp.CentimetersToPoints(1.5)
                oWordDoc.PageSetup.LeftMargin = oWordApp.CentimetersToPoints(1.5)
                oWordDoc.PageSetup.RightMargin = oWordApp.CentimetersToPoints(1.5)

                Dim wPara As Word.Paragraph = oWordDoc.Content.Paragraphs.Add()
                Dim embedPic As Word.InlineShape = wPara.Range.InlineShapes.AddPicture(FileName:=imageFile, LinkToFile:=False, SaveWithDocument:=True)
                If My.Computer.FileSystem.FileExists(sPdfFilename) Then
                    LogUtil.Debug("Deleting previous " & sPdfFilename, "ConvertToPdf")
                    My.Computer.FileSystem.DeleteFile(sPdfFilename)
                End If
                Try
                    LogUtil.Debug("Saving new " & sPdfFilename, "ConvertToPdf")
                    oWordDoc.SaveAs(sPdfFilename, Word.WdSaveFormat.wdFormatPDF)
                Catch ex2 As Exception
                    LogUtil.Exception("Error saving Word document", ex2, "ConvertToPdf", getErrorCode(SystemModule.UTILITIES, ErrorType.APPLICATION, FailedAction.ERROR_SAVING_FILE))
                    Throw New Exception("Error saving Word document", ex2)
                End Try
            Catch ex As Exception
                sPdfFilename = Nothing
                MsgBox("Failure to convert image to .pdf" & vbCrLf & ex.Message & vbCrLf & ex.InnerException.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.AbortRetryIgnore, "Word failure")
                LogUtil.Exception("Error using Word to convert to pdf", ex, "ConvertToPdf", getErrorCode(SystemModule.UTILITIES, ErrorType.APPLICATION, FailedAction.ERROR_CONVERTING_TO_PDF))
            Finally
                If oWordDoc IsNot Nothing Then
                    LogUtil.Debug("Closing document", "ConvertToPdf")
                    oWordDoc.Close(Word.WdSaveOptions.wdDoNotSaveChanges)
                    oWordDoc = Nothing
                End If
                If oWordApp IsNot Nothing Then
                    LogUtil.Debug("Quitting Word", "ConvertToPdf")
                    oWordApp.Quit(Word.WdSaveOptions.wdDoNotSaveChanges)
                    oWordApp = Nothing
                End If
            End Try
        End If
        Return sPdfFilename
    End Function

    'Public Shared Function ConvertDocumentToPdf(ByVal docFile As String) As String
    '    LogUtil.Debug("Converting docuemnt to pdf")
    '    Dim sPdfFilename As String = Nothing
    '    If docFile.Length > 0 AndAlso My.Computer.FileSystem.FileExists(docFile) Then
    '        Dim sImagePath As String = Path.GetDirectoryName(docFile)
    '        sPdfFilename = Path.Combine(sImagePath, Path.GetFileNameWithoutExtension(docFile) & ".pdf")
    '        Dim oWordApp As Word.Application = Nothing
    '        Dim oWordDoc As Word.Document = Nothing
    '        Try
    '            LogUtil.Debug("Starting Word", "ConvertToPdf")
    '            Try
    '                oWordApp = New Word.Application
    '            Catch ex1 As Exception
    '                LogUtil.Exception("Error loading Word", ex1, "ConvertDocumentToPdf", getErrorCode(SystemModule.UTILITIES, ErrorType.APPLICATION, 4))
    '                Throw New Exception("Error loading Word", ex1)
    '            End Try
    '            oWordDoc = New Word.Document
    '            oWordDoc = oWordApp.Documents.Add
    '            oWordDoc.PageSetup.PageHeight = oWordApp.CentimetersToPoints(15)
    '            oWordDoc.PageSetup.PageWidth = oWordApp.CentimetersToPoints(20)
    '            oWordDoc.PageSetup.TopMargin = oWordApp.CentimetersToPoints(1.5)
    '            oWordDoc.PageSetup.BottomMargin = oWordApp.CentimetersToPoints(1.5)
    '            oWordDoc.PageSetup.LeftMargin = oWordApp.CentimetersToPoints(1.5)
    '            oWordDoc.PageSetup.RightMargin = oWordApp.CentimetersToPoints(1.5)

    '            Dim wPara As Word.Paragraph = oWordDoc.Content.Paragraphs.Add()
    '            Dim embedPic As Word.InlineShape = wPara.Range.InlineShapes.AddPicture(FileName:=imageFile, LinkToFile:=False, SaveWithDocument:=True)
    '            If My.Computer.FileSystem.FileExists(sPdfFilename) Then
    '                LogUtil.Debug("Deleting previous " & sPdfFilename, "ConvertToPdf")
    '                My.Computer.FileSystem.DeleteFile(sPdfFilename)
    '            End If
    '            Try
    '                LogUtil.Debug("Saving new " & sPdfFilename, "ConvertToPdf")
    '                oWordDoc.SaveAs(sPdfFilename, Word.WdSaveFormat.wdFormatPDF)
    '            Catch ex2 As Exception
    '                LogUtil.Exception("Error saving Word document", ex2, "ConvertToPdf", getErrorCode(SystemModule.UTILITIES, ErrorType.APPLICATION, 10))
    '                Throw New Exception("Error saving Word document", ex2)
    '            End Try
    '            Try
    '                LogUtil.Debug("Closing document", "ConvertToPdf")
    '                oWordDoc.Close(Word.WdSaveOptions.wdDoNotSaveChanges)
    '            Catch ex3 As Exception
    '                LogUtil.Exception("Error closing Word document", ex3, "ConvertToPdf", getErrorCode(SystemModule.UTILITIES, ErrorType.APPLICATION, 5))
    '                Throw New Exception("Error closing Word document", ex3)
    '            End Try
    '            Try
    '                LogUtil.Debug("Quitting Word", "ConvertToPdf")
    '                oWordApp.Quit(Word.WdSaveOptions.wdDoNotSaveChanges)
    '            Catch ex4 As Exception
    '                LogUtil.Exception("Error closing Word", ex4, "ConvertToPdf", getErrorCode(SystemModule.UTILITIES, ErrorType.APPLICATION, 5))
    '                Throw New Exception("Error closing Word", ex4)
    '            End Try
    '        Catch ex As Exception
    '            sPdfFilename = Nothing
    '            MsgBox("Failure to convert image to .pdf" & vbCrLf & ex.Message & vbCrLf & ex.InnerException.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.AbortRetryIgnore, "Word failure")
    '            LogUtil.Exception("Error using Word to convert to pdf", ex, "ConvertToPdf", getErrorCode(SystemModule.UTILITIES, ErrorType.APPLICATION, 11))
    '        Finally
    '            If oWordDoc IsNot Nothing Then
    '                oWordDoc = Nothing
    '            End If
    '            If oWordApp IsNot Nothing Then
    '                oWordApp = Nothing
    '            End If
    '        End Try
    '    End If
    '    Return sPdfFilename
    'End Function

    ''' <summary>
    ''' Uses MS Excel to convert a Sylk file into an Excel 97-2003 (.xls) file
    ''' Output file will have the same name as the input file but with .xls suffix
    ''' </summary>
    ''' <param name="sFilename">Filename of Sylk file to convert</param>
    ''' <returns>True if the file converted OK</returns>
    ''' <remarks></remarks>
    Public Shared Function convertSylkFileToExcel(ByVal sFilename As String, Optional ByVal sPassword As String = Nothing) As Boolean
        Dim IsSuccess As Boolean = False
        Try
            If StartExcel(False) Then
                Dim oWkBk As Workbook = objExcel.Workbooks.Add(sFilename)
                Dim sNewFilename As String = Path.Combine(Path.GetDirectoryName(sFilename), Path.GetFileNameWithoutExtension(sFilename) & ".xls")
                If sPassword IsNot Nothing Then
                    oWkBk.SaveAs(sNewFilename, XlFileFormat.xlExcel8, sPassword)
                Else
                    oWkBk.SaveAs(sNewFilename, XlFileFormat.xlExcel8)
                End If
                IsSuccess = True
            End If
        Catch ex As Exception
            MsgBox("Conversion to Excel failed.", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Excel Error")
            LogUtil.Exception("Unexpected exception", ex, "convertSylkFileToExcel")
            IsSuccess = False
        Finally
            ForceExcelToQuit()
        End Try
        Return IsSuccess
    End Function

    ''' <summary>
    ''' Uses MS Word to convert a Word document file to a .pdf file
    ''' Output file will have the same name as the input file but with .pds suffix
    ''' </summary>
    ''' <param name="sFilename">Filename of file to convert</param>
    ''' <returns>True if the file is converted OK</returns>
    ''' <remarks></remarks>
    Public Shared Function convertDocFileToPdf(ByVal sFilename As String) As Boolean
        Dim IsSuccess As Boolean = False
        If StartWord(False) Then
            Dim oDoc As Word.Document = objWord.Documents.Add(sFilename)
            Dim sNewFilename As String = Path.Combine(Path.GetDirectoryName(sFilename), Path.GetFileNameWithoutExtension(sFilename) & ".pdf")
            oDoc.SaveAs(sNewFilename, WdSaveFormat.wdFormatPDF)
            ForceWordToQuit()
            IsSuccess = True
        End If
        Return IsSuccess
    End Function

    ''' <summary>
    ''' Converts and array list of strings into a MS Word document object with each string as a paragraph
    ''' </summary>
    ''' <param name="sParas">Array of strings</param>
    ''' <returns>MS Word document object</returns>
    ''' <remarks></remarks>
    Public Shared Function convertStringsToWordDocument(ByVal sParas As ArrayList, Optional ByVal fontName As String = Nothing, Optional ByVal fontSize As Single = 0) As Word.Document
        Dim oDoc As new Word.Document 
        ' Test to see if selection is an insertion point. 
            For Each sPara As String In sParas
                Dim oPara1 As Word.Paragraph
                oPara1 = oDoc.Content.Paragraphs.Add
                oPara1.Range.Text = sPara
                If fontName IsNot Nothing Then oPara1.Range.Font.Name = fontName
                If fontSize <> 0 Then oPara1.Range.Font.Size = fontSize
                oPara1.Range.InsertParagraphAfter()
            Next
        Return oDoc
    End Function

    Public Shared Function DataGridViewClone(ByRef oDgv As DataGridView, Optional ByVal includeInvisibleRows As Boolean = True, Optional ByVal includeInvisibleColumns As Boolean = True) As DataGridView
        Dim oNewDgv As New DataGridView
        For Each oCol As DataGridViewColumn In oDgv.Columns
            If includeInvisibleColumns Or oCol.Visible Then
                Dim colNo As Integer = oNewDgv.Columns.Add(oCol.Clone)
                oNewDgv.Columns(colNo).Visible = oCol.Visible
            End If
        Next
        For Each orow As DataGridViewRow In oDgv.Rows
            If orow.Visible Or includeInvisibleRows Then
                Dim r As Integer = oNewDgv.Rows.Add()
                Dim c2 As Integer = 0
                oNewDgv.Rows(r).Visible = orow.Visible
                For c = 0 To oDgv.Columns.Count - 1
                    If includeInvisibleColumns Or oDgv.Columns(c).Visible Then
                        oNewDgv.Rows(r).Cells(c2).Value = orow.Cells(c).Value
                        c2 += 1
                    End If
                Next
            End If
        Next
        Return oNewDgv
    End Function

End Class
