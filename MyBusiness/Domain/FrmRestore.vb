' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO

Public Class FrmRestore
#Region "variables"
    Private backupPath As String
    Private dataPath As String
#End Region
#Region "form control handlers"
    Private Sub FrmRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Restore", MyBase.Name)
        GetFormPos(Me, My.Settings.RestoreFormPos)
        TxtBackupPath.Text = My.Settings.BackupPath
        AddProgress("Filling Table Tree")
        FillTableTree(TvDatatables)
        TvDatatables.ExpandAll()
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
    Private Sub TvDatatables_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TvDatatables.AfterCheck
        Dim node As TreeNode = e.Node
        Dim ischecked As Boolean = node.Checked
        For Each subNode As TreeNode In node.Nodes
            subNode.Checked = ischecked
        Next
    End Sub
    Private Sub BtnRestore_Click(sender As Object, e As EventArgs) Handles BtnRestore.Click
        Dim isOKToBackup As Boolean = CheckPaths(True)
        If isOKToBackup Then
            AddProgress("Restore started -------------------------")
            DataTableRestore()
            AddProgress("Restore complete -------------------------")
        End If
    End Sub
    Private Sub BtnSelectPath_Click(sender As Object, e As EventArgs) Handles BtnSelectPath.Click
        Using fbd As New FolderBrowserDialog
            If Not String.IsNullOrEmpty(TxtBackupPath.Text) Then
                fbd.SelectedPath = TxtBackupPath.Text
            End If
            If fbd.ShowDialog() = DialogResult.OK Then
                TxtBackupPath.Text = fbd.SelectedPath
            End If
        End Using
    End Sub
    Private Sub FrmRestore_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.RestoreFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnSelectAll_Click(sender As Object, e As EventArgs) Handles BtnSelectAll.Click
        TvDatatables.Nodes(0).Checked = True
    End Sub
#End Region
#Region "subroutines"
    Private Sub AddProgress(pText As String)
        LogUtil.Info(pText, MyBase.Name)
        rtbProgress.Text &= vbCrLf & pText
        rtbProgress.SelectionStart = rtbProgress.Text.Length
        rtbProgress.ScrollToCaret()
        rtbProgress.Refresh()
    End Sub
    Private Sub DataTableRestore()
        AddProgress("Data restore ======")
        For Each oNode As TreeNode In TvDatatables.Nodes(0).Nodes
            If oNode.Checked Then
                AddProgress("Restoring " & oNode.Text)
                Dim rowCount As Integer = RestoreDataTable(oNode.Text, dataPath)
                If rowCount > 0 Then
                    AddProgress(oNode.Text & " Restore complete ")
                    AddProgress(rowCount & " records")
                Else
                    AddProgress("No rows restored")
                End If
                oNode.Checked = False
            End If
        Next
        TvDatatables.Nodes(0).Checked = False
    End Sub
    Private Function CheckPaths(isOKToBackup As Boolean) As Boolean
        If Not String.IsNullOrEmpty(TxtBackupPath.Text) Then
            backupPath = TxtBackupPath.Text.Trim
            dataPath = Path.Combine(backupPath, "data")
            If Not My.Computer.FileSystem.DirectoryExists(dataPath) Then
                AddProgress("No source folder. No restore.")
                isOKToBackup = False
            End If
        Else
            AddProgress("No source folder. No restore.")
            isOKToBackup = False
        End If
        Return isOKToBackup
    End Function
#End Region
End Class