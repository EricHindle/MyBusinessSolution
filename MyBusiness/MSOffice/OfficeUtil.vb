Imports Microsoft.Office.Interop
Imports MyBusiness.netwyrksErrorCodes
Imports System.IO
Public Module OfficeUtil

#Region "Office Applications"
    '  Public bExcelOk As Boolean = False
    Public objExcel As Excel.Application = Nothing
    Public objWord As Word.Application = Nothing

    ''' <summary>
    ''' Starts MS Excel
    ''' </summary>
    ''' <param name="IsVisible">True if Excel should be visible to the user (useful for debugging)</param>
    ''' <returns>True if Excel starts OK</returns>
    ''' <remarks></remarks>
    Public Function StartExcel(Optional ByVal IsVisible As Boolean = True) As Boolean
        '
        '   Starts the Excel application
        '
        Dim bOk As Boolean = True
        Try
            objExcel = New Excel.Application
            objExcel.Visible = IsVisible
            objExcel.DisplayAlerts = False

        Catch ex As Exception
            MsgBox("Unable to start Excel" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Excel Error")
            LogUtil.Exception("Unable to start Excel", ex, "StartExcel", getErrorCode(SystemModule.UTILITIES, ErrorType.APPLICATION, FailedAction.ERROR_STARTING_EXTERNAL_APP))
            bOk = False
        End Try
        If Not bOk Then
            objExcel = Nothing
        End If
        Return bOk
    End Function

    ''' <summary>
    ''' Closes Excel down
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ForceExcelToQuit()
        Try
            If objExcel IsNot Nothing Then
                objExcel.Quit()
                objExcel = Nothing
            End If
        Catch ex As Exception
            LogUtil.Exception("Unable to quit Excel", ex, "ForceExcelToQuit", getErrorCode(SystemModule.UTILITIES, ErrorType.APPLICATION, FailedAction.ERROR_CLOSING_EXTERNAL_APP))
        End Try
    End Sub

    ''' <summary>
    ''' Starts MS Word
    ''' </summary>
    ''' <param name="IsVisible">True if Word should be visible to the user (useful for debugging)</param>
    ''' <returns>True if Word starts OK</returns>
    ''' <remarks></remarks>
    Public Function StartWord(Optional ByVal IsVisible As Boolean = True) As Boolean
        '
        '   Starts the Word application
        '
        Dim bOk As Boolean = True
        Try
            objWord = New Word.Application
            objWord.Visible = IsVisible
            objWord.DisplayAlerts = False

        Catch ex As Exception
            MsgBox("Unable to start Word" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Word Error")
            LogUtil.Exception("Unable to start Word", ex, "StartWord", getErrorCode(SystemModule.UTILITIES, ErrorType.APPLICATION, FailedAction.ERROR_STARTING_EXTERNAL_APP))
            bOk = False
        End Try
        If Not bOk Then
            objWord = Nothing
        End If
        Return bOk
    End Function

    ''' <summary>
    ''' Closes Word down
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ForceWordToQuit()
        If objWord IsNot Nothing Then
            objWord.Quit()
            objWord = Nothing
        End If
    End Sub

#End Region
#Region "Word document"
    Public Function AddHeading1ParagraphToWordDocument(ByVal sText As String, ByRef oDoc As Word.Document) As Word.Paragraph
        Dim oPara1 As Word.Paragraph = oDoc.Content.Paragraphs.Add()
        oPara1.Format.Style = Word.WdBuiltinStyle.wdStyleHeading1
        oPara1.Range.Text = sText
        oPara1.Range.InsertParagraphAfter()
        Return oPara1
    End Function
    Public Function AddHeading2ParagraphToWordDocument(ByVal sText As String, ByRef oDoc As Word.Document) As Word.Paragraph
        Dim oPara1 As Word.Paragraph = oDoc.Content.Paragraphs.Add()
        oPara1.Format.Style = Word.WdBuiltinStyle.wdStyleHeading2
        oPara1.Range.Text = sText
        oPara1.Range.InsertParagraphAfter()
        Return oPara1
    End Function
    Public Function AddHeading3ParagraphToWordDocument(ByVal sText As String, ByRef oDoc As Word.Document) As Word.Paragraph
        Dim oPara1 As Word.Paragraph = oDoc.Content.Paragraphs.Add()
        oPara1.Format.Style = Word.WdBuiltinStyle.wdStyleHeading3
        oPara1.Range.Text = sText
        oPara1.Range.InsertParagraphAfter()
        Return oPara1
    End Function
    Public Function AddTextParagraphToWordDocument(ByVal sText As String, ByRef oDoc As Word.Document) As Word.Paragraph
        Dim oPara1 As Word.Paragraph = oDoc.Content.Paragraphs.Add()
        oPara1.Range.Text = sText
        oPara1.Range.InsertParagraphAfter()
        Return oPara1
    End Function

    Public Sub AddTextAfterWordParagraph(ByVal sText As String, ByRef oPara As Word.Paragraph)
        oPara.Range.InsertAfter(sText)
        oPara.Range.InsertParagraphAfter()
    End Sub

    Public Function AddTableToWordDocument(ByRef oDoc As Word.Document, ByVal sContents()() As String, ByVal hasHeading As Boolean, Optional ByVal oStyle As Word.WdBuiltinStyle = Word.WdBuiltinStyle.wdStyleNormal) As Word.Table
        Dim oTable As Word.Table
        If sContents IsNot Nothing Then
            Dim rowCt As Integer = sContents.GetUpperBound(0)
            Dim colCt As Integer = sContents(0).GetUpperBound(0)
            oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, rowCt + 1, colCt + 1)
            If oStyle <> Word.WdBuiltinStyle.wdStyleNormal Then
                oTable.Style = oStyle
            End If
            'oTable.Range.FormattedText.Style = Word.WdBuiltinStyle.wdStylePlainText
            'oTable.Range.ParagraphFormat.SpaceAfter = 6
            Try
                For row = 0 To rowCt
                    If sContents(row) IsNot Nothing Then
                        For col = 0 To colCt
                            oTable.Cell(row + 1, col + 1).Range.Text = sContents(row)(col)
                        Next
                    End If
                    oTable.Rows(row + 1).Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalBottom
                Next
            Catch ex As Exception
                LogUtil.Exception("Table error", ex)
            End Try
            If hasHeading Then
                oTable.Rows.Item(1).Range.Font.Bold = True
                oTable.Rows.Item(1).Range.Borders(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleSingle
            End If
        Else
            oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 1, 1)
        End If
        Return oTable
    End Function

    Public Function AddGridToWordDocument(ByRef oDoc As Word.Document, ByRef oDgv As DataGridView, ByVal hasHeading As Boolean, Optional ByVal oStyle As Word.WdBuiltinStyle = Word.WdBuiltinStyle.wdStyleNormal, Optional ByVal isShowHiddenColumns As Boolean = False) As Word.Table
        Dim oTable As Word.Table
        If oDgv IsNot Nothing AndAlso oDgv.RowCount > 0 And oDgv.ColumnCount > 0 Then
            Dim rowCt As Integer = oDgv.RowCount
            Dim rowOffset As Integer = 1
            Dim colCt As Integer = oDgv.ColumnCount
            If hasHeading Then
                rowCt += 1
                rowOffset += 1
            End If

            oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, rowCt, colCt, Word.WdDefaultTableBehavior.wdWord9TableBehavior, Word.WdAutoFitBehavior.wdAutoFitContent)

            If oStyle <> Word.WdBuiltinStyle.wdStyleNormal Then
                oTable.Style = oStyle
            End If
            If hasHeading Then
                For col = 0 To oDgv.ColumnCount - 1
                    If oDgv.Columns(col).Visible Or isShowHiddenColumns Then
                        oTable.Cell(1, col + 1).Range.Text = oDgv.Columns(col).HeaderCell.Value
                    End If
                Next
            End If
            Try
                For row = 0 To oDgv.RowCount - 1

                    For col = 0 To oDgv.ColumnCount - 1
                        If oDgv.Columns(col).Visible Or isShowHiddenColumns Then
                            oTable.Cell(row + rowOffset, col + 1).Range.Text = oDgv.Rows(row).Cells(col).Value
                        End If
                    Next

                    oTable.Rows(row + 1).Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalBottom
                Next
            Catch ex As Exception
                LogUtil.Exception("Table error", ex)
            End Try
            'If hasHeading Then
            '    oTable.Rows.Item(1).Range.Font.Bold = True
            '    oTable.Rows.Item(1).Range.Borders(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleSingle
            'End If
        Else
            oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 1, 1)
        End If
        Return oTable
    End Function
#End Region

#Region "Save"
    Public Function saveWordDocumentAsPdf(ByRef oDoc As Word.Document, ByVal sFilename As String) As Boolean
        Dim isSavedOk As Boolean = False
        Try
            Dim sPdfFilename As String = Path.Combine(sReportFolder, sFilename & ".pdf")
            If My.Computer.FileSystem.FileExists(sPdfFilename) Then
                My.Computer.FileSystem.DeleteFile(sPdfFilename)
            End If
            LogUtil.Debug("Saving " & sPdfFilename, "saveWordDocumentAsPdf")
            oDoc.SaveAs(sPdfFilename, ExportUtil.getWordFormat(FileUtil.FileType.PDF))
            isSavedOk = True
        Catch ex As Exception
            LogUtil.Exception("Save failed", ex, "saveWordDocumentAsPdf")
        End Try
        Return isSavedOk
    End Function

    Public Function saveWordDocument(ByRef oDoc As Word.Document, ByVal sFilename As String) As Boolean
        Dim isSavedOk As Boolean = False
        Try
            Dim sWordFilename As String = Path.Combine(sReportFolder, sFilename & ".docx")
            If My.Computer.FileSystem.FileExists(sWordFilename) Then
                My.Computer.FileSystem.DeleteFile(sWordFilename)
            End If
            LogUtil.Debug("Saving " & sWordFilename, "saveWordDocument")
            oDoc.SaveAs(sWordFilename, ExportUtil.getWordFormat(FileUtil.FileType.DOC))
            isSavedOk = True
        Catch ex As Exception
            LogUtil.Exception("Save failed", ex, "saveWordDocument")
        End Try
        Return isSavedOk
    End Function
#End Region
End Module


