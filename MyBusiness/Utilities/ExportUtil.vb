' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.Text
Imports System.IO

Imports MyBusiness.NetwyrksErrorCodes

Public Class ExportUtil
    Private Const NEWLINE As String = Chr(27) & " :"
    Private fbd As OpenFileDialog
    Private aColFormat As String() = New String() {}
    Private mySep As String
    Private myOutfile As String
    Private myOutFolder As String
    Private myDocumentText As StringBuilder
    Private myExportFileType As FileUtil.FileType
    Private myPassword As String = Nothing

    Public Property usePassword() As String
        Get
            Return myPassword
        End Get
        Set(ByVal value As String)
            myPassword = value
        End Set
    End Property

    Public Property exportFileType() As FileUtil.FileType
        Get
            Return myExportFileType
        End Get
        Set(ByVal value As FileUtil.FileType)
            myExportFileType = value
        End Set
    End Property

    Public Property Separator() As String
        Get
            Return mySep
        End Get
        Set(ByVal value As String)
            mySep = value
        End Set
    End Property

    Public Property OutFolder() As String
        Get
            Return myOutFolder
        End Get
        Set(ByVal value As String)
            myOutFolder = value
        End Set
    End Property

    Public Property OutFile() As String
        Get
            Return myOutfile
        End Get
        Set(ByVal value As String)
            myOutfile = value
        End Set
    End Property

    Public Sub New()
        myDocumentText = New StringBuilder
        mySep = ","
        myOutfile = "ExportData.csv"
        myOutFolder = sReportFolder
        myExportFileType = FileUtil.FileType.CSV
        myPassword = Nothing
    End Sub

    Public Sub New(ByVal exportFileType As FileUtil.FileType)
        myDocumentText = New StringBuilder
        mySep = ","
        myOutfile = "ExportData.csv"
        myOutFolder = sReportFolder
        myExportFileType = exportFileType
        myPassword = Nothing
    End Sub

    Public Function myOutFullFilePath() As String
        Return Path.Combine(myOutFolder, myOutfile)
    End Function

    Public Sub exportString(ByVal sText As String)
        Dim lines As String() = sText.Split("\n")
        exportStrings(lines)
    End Sub

    Public Sub exportStrings(ByVal sText As String())
        LogUtil.Debug("Writing lines to file " & myOutFullFilePath())
        Using sw As New StreamWriter(myOutFullFilePath)
            For Each sLine As String In sText
                sw.WriteLine(sLine)
            Next
        End Using
    End Sub

    Public Sub exportGrid(ByRef dg As DataGridView, Optional ByVal bHeads As Boolean = True, Optional ByVal pColQuotes As String = "", Optional ByVal includeInvisible As Boolean = True, Optional ByVal heading As String = Nothing)
        Dim convertToXls As Boolean = False
        Dim pformat As FileUtil.FileType = myExportFileType
        If myExportFileType = FileUtil.FileType.XLS Then
            convertToXls = True
            pformat = FileUtil.FileType.SLK
            myOutfile = Path.GetFileNameWithoutExtension(myOutfile) & FileUtil.fileSuffix(pformat)
        End If
        Dim sFullFilename As String = Path.Combine(myOutFolder, myOutfile)
        LogUtil.Debug("Writing grid to file " & sFullFilename)
        If pformat = FileUtil.FileType.SLK Then
            aColFormat = Split(pColQuotes, ",")
        End If
        Using sw As New StreamWriter(sFullFilename)
            If pformat = FileUtil.FileType.SLK Then
                sw.WriteLine("ID;PSERS;N;E")
            End If
            Dim rowCt As Integer = 1
            If heading IsNot Nothing Then
                Select Case pformat
                    Case FileUtil.FileType.CSV
                        sw.WriteLine("""" & heading & """")
                    Case FileUtil.FileType.SLK
                        sw.WriteLine(ConvertTextToSylk(heading, rowCt))
                End Select
                rowCt += 1
            End If
            If bHeads Then
                Select Case pformat
                    Case FileUtil.FileType.CSV
                        sw.WriteLine(ConvertHeadsToCsv(dg.Columns, , includeInvisible), mySep)
                    Case FileUtil.FileType.SLK
                        sw.WriteLine(ConvertHeadsToSylk(dg.Columns, includeInvisible, rowCt))
                End Select
                rowCt += 1
            End If

            For Each oRow As DataGridViewRow In dg.Rows
                Select Case pformat
                    Case FileUtil.FileType.CSV
                        sw.WriteLine(ConvertRowToCsv(oRow, , includeInvisible), mySep)
                    Case FileUtil.FileType.SLK
                        sw.WriteLine(ConvertRowToSylk(oRow, rowCt, includeInvisible))
                End Select
                rowCt += 1
            Next
            If pformat = FileUtil.FileType.SLK Then
                sw.WriteLine("E")
            End If
        End Using
    End Sub
    Private Function ConvertHeadsToCsv(ByVal oCols As DataGridViewColumnCollection, Optional ByVal sSep As String = ",", Optional ByVal includeInvisible As Boolean = True) As String
        Dim sb As New StringBuilder
        For Each ocol As DataGridViewColumn In oCols
            If includeInvisible Or ocol.Visible Then
                sb.Append(ocol.HeaderText).Append(sSep)
            End If
        Next
        Return sb.ToString
    End Function
    Private Function ConvertHeadsToSylk(ByVal oCols As DataGridViewColumnCollection, Optional ByVal includeInvisible As Boolean = True, Optional ByVal rCt As Integer = 1) As String
        Dim sb As New StringBuilder
        Dim cCt As Integer = 1
        For Each ocol As DataGridViewColumn In oCols
            If includeInvisible Or ocol.Visible Then
                sb.Append("F;W ").Append(CStr(cCt)).Append(" ").Append(CStr(cCt)).Append(" ").Append(CStr(CInt(ocol.Width / 6))).Append(vbCrLf)
                sb.Append("C;Y").Append(CStr(rCt)).Append(";X").Append(CStr(cCt)).Append(";K""")
                Dim sCellValue As String = ""
                If ocol.HeaderText IsNot Nothing AndAlso IsDBNull(ocol.HeaderText) = False Then
                    sCellValue = ocol.HeaderText
                End If
                sCellValue = sCellValue.Replace(vbCrLf, NEWLINE)
                sb.Append(sCellValue)
                sb.Append("""").Append(vbCrLf)
                cCt += 1
            End If
        Next
        Return sb.ToString
    End Function

    Private Function ConvertTextToSylk(ByVal oText As String, ByVal rCt As Integer) As String
        Dim sb As New StringBuilder
        Return "C;Y" & CStr(rCt) & ";X1;K""" & oText.Replace(vbCrLf, NEWLINE) & """" & vbCrLf
    End Function

    Private Function ConvertRowToSylk(ByVal oRow As DataGridViewRow, ByVal rCt As Integer, Optional ByVal includeInvisible As Boolean = True) As String
        Dim sb As New StringBuilder
        Dim cCt As Integer = 1
        For Each oCell As DataGridViewCell In oRow.Cells
            If includeInvisible Or oCell.Visible Then
                If oCell.Value IsNot DBNull.Value AndAlso CStr(oCell.Value) <> "" Then
                    Dim sQuotes As String = """"
                    If aColFormat.GetUpperBound(0) >= oCell.ColumnIndex Then
                        If aColFormat(oCell.ColumnIndex) = "n" Then
                            sQuotes = ""
                        End If
                    End If
                    sb.Append("C;Y").Append(CStr(rCt)).Append(";X").Append(CStr(cCt)).Append(";K").Append(sQuotes)
                    If oCell.ValueType Is GetType(Date) Then
                        sb.Append(Format(oCell.Value, "dd/MM/yyyy"))
                    Else
                        Dim sCellValue As String = ""
                        If oCell.Value IsNot Nothing AndAlso IsDBNull(oCell.Value) = False Then
                            sCellValue = oCell.Value
                        End If
                        sCellValue = sCellValue.Replace(vbCrLf, NEWLINE)
                        sb.Append(sCellValue)
                    End If
                    sb.Append(sQuotes).Append(vbCrLf)
                End If
                cCt += 1
            End If
        Next
        Return sb.ToString
    End Function
    Private Function ConvertRowToCsv(ByVal oRow As DataGridViewRow, Optional ByVal sSep As String = ",", Optional ByVal includeInvisible As Boolean = True) As String
        Dim sb As New StringBuilder
        myDocumentText = New StringBuilder
        For Each oCell As DataGridViewCell In oRow.Cells
            If includeInvisible Or oCell.Visible Then
                If oCell.ValueType Is GetType(Date) Then
                    sb.Append(Format(oCell.Value, "dd/MM/yyyy"))
                Else
                    Dim sCellValue As String = ""
                    If oCell.Value IsNot Nothing AndAlso IsDBNull(oCell.Value) = False Then
                        sCellValue = oCell.Value
                    End If
                    sCellValue = sCellValue.Replace(vbCrLf, NEWLINE)
                    sb.Append("""").Append(sCellValue).Append("""")
                End If

                If oCell.ColumnIndex < oRow.Cells.Count Then
                    sb.Append(mySep)
                End If
            End If
        Next
        Return sb.ToString
    End Function

    Public Function ChooseFolder() As String
        Dim sFilename As String = FileUtil.GetFileName(FileUtil.OpenOrSave.Save, myExportFileType, myOutFolder)
        If sFilename.Length > 0 Then
            myOutFolder = Path.GetDirectoryName(sFilename)
            myOutfile = Path.GetFileName(sFilename)
        Else
            myOutFolder = ""
            myOutfile = ""
        End If
        Return sFilename
    End Function

    Public Function saveAndRename(ByVal pExt As FileUtil.FileType, ByVal sFilename As String) As String
        myExportFileType = pExt
        ChooseFolder()
        Dim newFilename As String = myOutFullFilePath()
        If newFilename.Length > 0 Then
            If newFilename <> sFilename Then
                If My.Computer.FileSystem.FileExists(newFilename) Then
                    My.Computer.FileSystem.DeleteFile(newFilename)
                End If
                My.Computer.FileSystem.CopyFile(sFilename, newFilename)
                My.Computer.FileSystem.DeleteFile(sFilename)
            End If
        End If
        Return newFilename
    End Function

    Public Function ExportGridToRtfFile(ByVal oReportDef As ReportDefinition, ByRef dgvReportTable As DataGridView) As String
        Dim response As New StringBuilder
        response.Append(RtfManager.RtfTop(True))
        Dim paragraphtext As New StringBuilder
        'Dim tempFolder As String = My.Settings.TempFolder.Replace("<application path>", sApplicationPath)
        'Dim sFilename As String = Path.Combine(tempFolder, "LQReport.rtf")

        response.Append(RtfManager.RtfParagraph(oReportDef.ReportHead, RtfManager.RtfFont(RtfManager.RtfFontType.Cambria, 24, RtfManager.RtfColour.Hdr1Blue, , True)))
        response.Append(RtfManager.RtfNewPar)

        response.Append(RtfManager.GridToRtf(dgvReportTable, RtfManager.RtfFontType.Calibri, txtSize:=oReportDef.Font.Size * 2, maxColWidth:=30, singleLine:=False))
        response.Append(RtfManager.RtfNewPar)

        Dim irowct As Integer = 0
        For Each row As DataGridViewRow In dgvReportTable.Rows
            If row.Cells(0).Value IsNot Nothing Then
                irowct += 1
            End If
        Next

        If oReportDef.ShowCount Then
            response.Append(RtfManager.RtfParagraph(CStr(irowct) & " records selected", RtfManager.RtfFont(RtfManager.RtfFontType.Cambria, 24, RtfManager.RtfColour.Hdr1Blue, , True)))
            response.Append(RtfManager.RtfNewPar)
        End If
        Dim sFilename As String = Path.Combine(myOutFolder, myOutfile)
        response.Append(RtfManager.RtfBottom)
        LogUtil.Debug("Writing " & sFilename, Me.GetType.Name)
        Using rtfFile As New StreamWriter(sFilename)
            rtfFile.Write(response.ToString)
        End Using

        Return sFilename

    End Function

    Public Function ExportTextToRtfFile(ByVal oReportDef As ReportDefinition, ByVal _text As String, ByVal Optional isLandscape As Boolean = False) As String
        Dim sFilename As String = Path.Combine(myOutFolder, myOutfile)
        Dim _contents As New StringBuilder
        _contents.Append(RtfManager.RtfTop(isLandscape))
        _contents.Append(_text)
        _contents.Append(RtfManager.RtfBottom)
        LogUtil.Debug("Writing " & sFilename, Me.GetType.Name)
        Using rtfFile As New StreamWriter(sFilename)
            rtfFile.Write(_contents.ToString)
        End Using
        Return sFilename

    End Function

    Public Sub saveTableSelection(ByVal dgv As DataGridView)
        If dgv.SelectedCells.Count > 0 Then
            Clipboard.SetDataObject(dgv.GetClipboardContent())
            myExportFileType = FileUtil.FileType.TXT
            ChooseFolder()
            exportString(Clipboard.GetText)
        Else
            MsgBox("Nothing selected", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub

    Public Sub saveTreeList(ByVal sTitle As String, ByRef lboTree As TreeView)
        '   Dim sFilename As String = FileUtil.getFileName(FileUtil.OpenOrSave.Save, FileUtil.FileType.TXT, sReportFolder)
        Dim sFileName As String = Path.Combine(sReportFolder, sTitle & "_LBOList_" & Format(Now, "yyyyMMddHHmmss") & ".txt")
        Dim bOK As Boolean = False
        Dim sb As New StringBuilder()
        If My.Computer.FileSystem.FileExists(sFileName) Then
            If MsgBox("File already exists. OK to replace?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "File exists") = MsgBoxResult.Yes Then
                bOK = True
            End If
        Else
            bOK = True
        End If
        If bOK Then
            For Each companyNode As TreeNode In lboTree.Nodes
                If companyNode.Nodes.Count > 0 Then
                    sb.AppendLine(companyNode.Text)
                    For Each lboNode As TreeNode In companyNode.Nodes
                        sb.AppendLine(" - " & lboNode.Text)
                        For Each valueNode As TreeNode In lboNode.Nodes
                            sb.AppendLine("    - " & valueNode.Text)
                        Next
                    Next
                End If
            Next
            Using outfile As New StreamWriter(sFileName)
                outfile.Write(sb.ToString())
            End Using
        End If
    End Sub
End Class
