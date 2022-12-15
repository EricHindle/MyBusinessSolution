' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FileUtil
#Region "enum"
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
#End Region
#Region "variables"
    Public Shared fileFilter As String() = {"Encrypted files (*.an*)| *.an*",
                                            "PDF files (*.pdf)| *.pdf",
                                            "Excel files (*.xls)| *.xls",
                                            "Comma Separated Value files (*.csv)| *.csv",
                                            "SYLK files (*.slk)| *.slk",
                                            "Text files (*.txt)| *.txt",
                                            "Rich Test files (*.rtf)| *.rtf",
                                            "Word files (*.docx)| *.docx",
                                            "All files|*.*"}
    Public Shared fileSuffix As String() = {".anj", ".pdf", ".xls", ".csv", ".slk", ".txt", ".rtf", ".docx", ""}
    Public Shared imageFileSuffix As String() = {".jpg", ".gif", ".bmp", ".tif", ".png", ".anj", ""}
#End Region
#Region "functions"
    Public Shared Function ShowFileDialog(ByVal fbd As FileDialog, Optional ByVal fileType As FileType = FileUtil.FileType.ENC, Optional ByVal initialFolder As String = "") As String
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
    Public Shared Function GetFileName(ByVal dialogType As OpenOrSave, Optional ByVal fileType As FileType = FileUtil.FileType.ENC, Optional ByVal initialFolder As String = "") As String
        Dim sFilename As String = ""
        If dialogType = OpenOrSave.Open Then
            Using fbd As New OpenFileDialog
                sFilename = ShowFileDialog(fbd, fileType, initialFolder)
            End Using
        Else
            Using fbd As New SaveFileDialog
                sFilename = ShowFileDialog(fbd, fileType, initialFolder)
            End Using
        End If
        Return sFilename
    End Function
    Public Shared Function GetTempFileName(Optional ByVal sType As FileType = FileType.ALL) As String
        Dim suffix As String = fileSuffix(sType)
        Dim sFilename As String = AuthenticationUtil.generateWordyPassword(False) & "_" & Format(Now, "yyyyMMddHHmmss") & suffix
        Return sFilename
    End Function
    Public Shared Function GetTempFileName(ByVal sType As Integer) As String
        Dim suffix As String = imageFileSuffix(sType)
        Dim sFilename As String = AuthenticationUtil.generateWordyPassword(False) & "_" & Format(Now, "yyyyMMddHHmmss") & suffix
        Return sFilename
    End Function
#End Region
End Class
