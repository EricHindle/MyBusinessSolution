' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO

Public Class FrmBackup
#Region "variables"
    Private backupPath As String
    Private dataPath As String
    Private docPath As String
    Private imagePath As String
#End Region
#Region "form control handlers"
    Private Sub FrmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Backup", MyBase.Name)
        GetFormPos(Me, My.Settings.BackupFormPos)
        TxtBackupPath.Text = My.Settings.BackupFolder
        AddProgress("Filling Table Tree")
        FillTableTree(TvDatatables)
        TvDatatables.ExpandAll()
        AddProgress("Filling Document Tree")
        FillDocumentTree()
        TvDocuments.ExpandAll()
        AddProgress("Filling Image Tree")
        FillImageTree()
        TvImages.ExpandAll()
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Private Sub TvDatatables_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TvDatatables.AfterCheck, TvDocuments.AfterCheck, TvImages.AfterCheck
        Dim node As TreeNode = e.Node
        Dim ischecked As Boolean = node.Checked
        For Each subNode As TreeNode In node.Nodes
            subNode.Checked = ischecked
        Next
    End Sub
    Private Sub BtnBackup_Click(sender As Object, e As EventArgs) Handles BtnBackup.Click
        Dim isOKToBackup As Boolean = CheckPaths(True)
        If isOKToBackup Then
            AddProgress("Backup started -------------------------")
            DataTableBackup()
            DocumentsBackup()
            ImageBackup()
            AddProgress("Backup complete -------------------------")
        End If
    End Sub

    Private Sub DocumentsBackup()
        ReportsBackup()
        InvoicesBackup()
        TvDocuments.Nodes(0).Checked = False
    End Sub

    Private Sub BtnSavePath_Click(sender As Object, e As EventArgs) Handles BtnSavePath.Click
        My.Settings.BackupFolder = TxtBackupPath.Text
        My.Settings.Save()
    End Sub
    Private Sub BtnSelectPath_Click(sender As Object, e As EventArgs) Handles BtnSelectPath.Click
        Using fbd As New FolderBrowserDialog
            fbd.RootFolder = Environment.SpecialFolder.MyComputer
            If Not String.IsNullOrEmpty(TxtBackupPath.Text) Then
                fbd.SelectedPath = TxtBackupPath.Text
            End If
            If fbd.ShowDialog() = DialogResult.OK Then
                TxtBackupPath.Text = fbd.SelectedPath
            End If
        End Using
    End Sub
    Private Sub FrmBackup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.BackupFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnSelectAll_Click(sender As Object, e As EventArgs) Handles BtnSelectAll.Click
        TvDatatables.Nodes(0).Checked = True
        TvDocuments.Nodes(0).Checked = True
        TvImages.Nodes(0).Checked = True
    End Sub
#End Region
#Region "subroutines"
    Private Sub FillImageTree()
        TvImages.Nodes.Clear()
        TvImages.Nodes.Add("Images")
        Dim topNode As TreeNode = TvImages.Nodes(0)
        If My.Computer.FileSystem.DirectoryExists(My.Settings.ImageFolder.Replace("<application path>", sApplicationPath)) Then
            Dim fileList As IReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(sImageFolder, FileIO.SearchOption.SearchAllSubDirectories)
            For Each _filename As String In fileList
                Dim _fname As String = Path.GetFileName(_filename)
                Dim _fpath As String = _filename
                Dim newNode As TreeNode = topNode.Nodes.Add(_fpath, _fname)
            Next
        End If
    End Sub
    Private Sub FillDocumentTree()
        TvDocuments.Nodes.Clear()
        TvDocuments.Nodes.Add("Documents")

        Dim reportFileList As IReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(sReportFolder, FileIO.SearchOption.SearchAllSubDirectories)
        Dim invoiceFileList As IReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(sInvoiceFolder, FileIO.SearchOption.SearchAllSubDirectories)

        TvDocuments.Nodes(0).Nodes.Add("Report files")
        Dim topNode As TreeNode = TvDocuments.Nodes(0).Nodes(0)
        For Each _filename As String In reportFileList
            Dim _fname As String = Path.GetFileName(_filename)
            Dim _fpath As String = _filename
            Dim newNode As TreeNode = topNode.Nodes.Add(_fpath, _fname)
        Next

        TvDocuments.Nodes(0).Nodes.Add("Invoice files")
        topNode = TvDocuments.Nodes(0).Nodes(1)
        For Each _filename As String In invoiceFileList
            Dim _fname As String = Path.GetFileName(_filename)
            Dim _fpath As String = _filename
            Dim newNode As TreeNode = topNode.Nodes.Add(_fpath, _fname)
            AddProgress(newNode.Name)
        Next
    End Sub
    Private Function CheckPaths(isOKToBackup As Boolean) As Boolean
        If Not String.IsNullOrEmpty(TxtBackupPath.Text) Then
            backupPath = If(chkAddDate.Checked, Path.Combine(TxtBackupPath.Text.Trim, Format(Today, "yyyyMMdd")), TxtBackupPath.Text.Trim)
            dataPath = Path.Combine(backupPath, "data")
            docPath = Path.Combine(backupPath, "documents")
            imagePath = Path.Combine(backupPath, "images")
            Try
                If Not My.Computer.FileSystem.DirectoryExists(backupPath) Then
                    AddProgress("Creating backup folder")
                    My.Computer.FileSystem.CreateDirectory(backupPath)
                End If
                If Not My.Computer.FileSystem.DirectoryExists(dataPath) Then
                    AddProgress("Creating data folder")
                    My.Computer.FileSystem.CreateDirectory(dataPath)
                End If
                If Not My.Computer.FileSystem.DirectoryExists(docPath) Then
                    AddProgress("Creating document folder")
                    My.Computer.FileSystem.CreateDirectory(docPath)
                End If
                If Not My.Computer.FileSystem.DirectoryExists(imagePath) Then
                    AddProgress("Creating image folder")
                    My.Computer.FileSystem.CreateDirectory(imagePath)
                End If
            Catch ex As ArgumentException
                LogUtil.Exception("File creation", ex, False, MyBase.Name)
                AddProgress("Failed : " & ex.Message)
                isOKToBackup = False
            Catch ex As PathTooLongException
                LogUtil.Exception("File creation", ex, False, MyBase.Name)
                AddProgress("Failed : " & ex.Message)
                isOKToBackup = False
            Catch ex As NotSupportedException
                LogUtil.Exception("File creation", ex, False, MyBase.Name)
                AddProgress("Failed : " & ex.Message)
                isOKToBackup = False
            Catch ex As IOException
                LogUtil.Exception("File creation", ex, False, MyBase.Name)
                AddProgress("Failed : " & ex.Message)
                isOKToBackup = False
            Catch ex As UnauthorizedAccessException
                LogUtil.Exception("File creation", ex, False, MyBase.Name)
                AddProgress("Failed : " & ex.Message)
                isOKToBackup = False
            End Try
        Else
            AddProgress("No destination. No backup.")
            isOKToBackup = False
        End If
        Return isOKToBackup
    End Function
    Private Sub ImageBackup()
        AddProgress("Image backup ======")
        For Each oNode As TreeNode In TvImages.Nodes(0).Nodes
            CopyFileToBackup(oNode, imagePath, sImageFolder)
        Next
        TvImages.Nodes(0).Checked = False
    End Sub

    Private Function CopyFileToBackup(pNode As TreeNode, pBackupPath As String, pSourceFolder As String) As TreeNode
        If pNode.Checked Then
            AddProgress(pNode.Text)
            Dim _filename As String = pNode.Text
            Dim _fullname As String = pNode.Name
            My.Computer.FileSystem.CopyFile(_fullname, Path.Combine(pBackupPath, _fullname.Replace(pSourceFolder, "")), True)
            AddProgress(_filename & " copied")
            pNode.Checked = False
        End If

        Return pNode
    End Function

    Private Sub ReportsBackup()
        AddProgress("Report backup ======")
        Dim oTypeNode As TreeNode = TvDocuments.Nodes(0).Nodes(0)
        For Each oNode As TreeNode In oTypeNode.Nodes
            CopyFileToBackup(oNode, Path.Combine(docPath, "Reports\"), sReportFolder)
        Next
        oTypeNode.Checked = False
    End Sub
    Private Sub InvoicesBackup()
        AddProgress("Invoice backup ======")
        Dim oTypeNode As TreeNode = TvDocuments.Nodes(0).Nodes(1)
        For Each oNode As TreeNode In oTypeNode.Nodes
            CopyFileToBackup(oNode, Path.Combine(docPath, "Invoices\"), sInvoiceFolder)
        Next
        oTypeNode.Checked = False
    End Sub
    Private Sub DataTableBackup()
        AddProgress("Data backup ======")
        For Each oNode As TreeNode In TvDatatables.Nodes(0).Nodes
            If oNode.Checked Then
                AddProgress(oNode.Text)
                Select Case oNode.Text
                    Case "Audit"
                        BackupTable(GetAuditTable)
                    Case "Configuration"
                        BackupTable(GetConfigurationTable)
                    Case "Customer"
                        BackupTable(GetCustomerTable)
                    Case "Diary"
                        BackupTable(GetDiaryTable)
                    Case "Job"
                        BackupTable(GetJobTable)
                    Case "Job_Product"
                        BackupTable(GetJob_ProductTable)
                    Case "Job_Image"
                        BackupTable(GetJob_ImageTable)
                    Case "Product"
                        BackupTable(GetProductTable)
                    Case "Supplier"
                        BackupTable(GetSupplierTable)
                    Case "Task"
                        BackupTable(GetTaskTable)
                    Case "User"
                        BackupTable(GetUserTable)

                End Select
                oNode.Checked = False
            End If
        Next
        TvDatatables.Nodes(0).Checked = False
    End Sub
    Private Sub AddProgress(pText As String)
        LogUtil.Info(pText, MyBase.Name)
        rtbProgress.Text &= vbCrLf & pText
        rtbProgress.SelectionStart = rtbProgress.Text.Length
        rtbProgress.ScrollToCaret()
        rtbProgress.Refresh()
    End Sub
    Private Sub BackupTable(backupDataTable As DataTable)
        Dim sTableName As String = backupDataTable.TableName
        Dim sDbFullPath As String = dataPath
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".xml")
        AddProgress("Writing " & sBackupFile)
        backupDataTable.WriteXml(sBackupFile, XmlWriteMode.WriteSchema)
        AddProgress("Writing " & sBackupFile & " complete")
    End Sub

#End Region
End Class