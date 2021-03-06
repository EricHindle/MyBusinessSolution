﻿'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015
Imports System.Drawing.Imaging
Public Class FileUtil
    ''' <summary>
    ''' File attachment type
    ''' </summary>
    ''' <remarks>
    ''' Text Doc - any text document (.txt) file
    ''' Email - Outlook Email file (.msg)
    ''' VoiceMail - Sound file (.wav)
    ''' WordDoc - MS Word document (.docx)</remarks>
    Public Enum AttachmentType
        Unknown = 0
        Email = 1
        VoiceMail = 2
        TextDoc = 3
        WordDoc = 4
    End Enum

    ''' <summary>
    ''' File type
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum FileType
        ENC
        PDF
        XLS
        CSV
        SLK
        TXT
        RTF
        DOC
        ALL
    End Enum

    ''' <summary>
    ''' Open or Save for file dialog
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum OpenOrSave
        Open
        Save
    End Enum
    Public Shared fileFilter As String() = {"Encrypted files (*.an*)| *.an*", _
                                            "PDF files (*.pdf)| *.pdf", _
                                            "Excel files (*.xls)| *.xls", _
                                            "Comma Separated Value files (*.csv)| *.csv", _
                                            "SYLK files (*.slk)| *.slk", _
                                            "Text files (*.txt)| *.txt", _
                                            "Rich Test files (*.rtf)| *.rtf", _
                                            "Word files (*.docx)| *.docx", _
                                            "All files|*.*"}
    Public Shared fileSuffix As String() = {".anj", ".pdf", ".xls", ".csv", ".slk", ".txt", ".rtf", ".docx", ""}
    Public Shared imageFileSuffix As String() = {".jpg", ".gif", ".bmp", ".tif", ".png", ".anj", ""}

    Public Shared Function showFileDialog(ByVal fbd As FileDialog, Optional ByVal fileType As FileType = FileUtil.FileType.ENC, Optional ByVal initialFolder As String = "") As String
        Dim sFilename As String = ""
        fbd.Filter = fileFilter(fileType)
        fbd.FilterIndex = 0
        fbd.RestoreDirectory = False
        fbd.CheckFileExists = False
        fbd.InitialDirectory = initialFolder
        If fbd.ShowDialog() = DialogResult.OK Then
            sFilename = fbd.FileName
        End If
        Return sFilename
    End Function
    Public Shared Function getFileName(ByVal dialogType As OpenOrSave, Optional ByVal fileType As FileType = FileUtil.FileType.ENC, Optional ByVal initialFolder As String = "") As String
        Dim sFilename As String = ""
        If dialogType = OpenOrSave.Open Then
            Using fbd As New OpenFileDialog
                sFilename = showFileDialog(fbd, fileType, initialFolder)
            End Using
        Else
            Using fbd As New SaveFileDialog
                sFilename = showFileDialog(fbd, fileType, initialFolder)
            End Using
        End If
        Return sFilename
    End Function

    Public Shared Function getTempFileName(Optional ByVal sType As FileType = FileType.ALL) As String
        Dim suffix As String = fileSuffix(sType)
        Dim sFilename As String = AuthenticationUtil.generateWordyPassword(False) & "_" & Format(Now, "yyyyMMddHHmmss") & suffix
        Return sFilename
    End Function
    Public Shared Function getTempFileName(ByVal sType As Integer) As String
        Dim suffix As String = imageFileSuffix(sType)
        Dim sFilename As String = AuthenticationUtil.generateWordyPassword(False) & "_" & Format(Now, "yyyyMMddHHmmss") & suffix
        Return sFilename
    End Function
End Class
