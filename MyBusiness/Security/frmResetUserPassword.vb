' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports HindlewareLib.Logging

Public Class FrmResetUserPassword
#Region "Constants"
    Private Const FORM_NAME As String = "reset user password"
#End Region
#Region "Private variable instances"
    Private ReadOnly oUserTa As New MyBusinessDataSetTableAdapters.usersTableAdapter
    Private ReadOnly oUserTable As New MyBusinessDataSet.usersDataTable
    Private ReadOnly userItem As New Dictionary(Of Integer, String)()
#End Region
#Region "Form"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oUserTa.Dispose()
        oUserTable.Dispose()
        logutil.info("Closed", FORM_NAME)
    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        logutil.info("Starting", FORM_NAME)
        lblFormName.Text = FORM_NAME
        oUserTa.Fill(oUserTable)
        For Each oUserRow As MyBusinessDataSet.usersRow In oUserTable.Rows
            Dim sUsername As String = oUserRow.user_name
            Dim userId As Integer = oUserRow.user_id
            userItem.Add(userId, sUsername)
        Next
        cbSelect.DataSource = New BindingSource(userItem, Nothing)
        cbSelect.DisplayMember = "Value"
        cbSelect.ValueMember = "Key"
    End Sub
    Private Sub BtnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        If cbSelect.SelectedIndex > -1 Then
            If oUserTa.FillById(oUserTable, cbSelect.SelectedValue) = 1 Then
                Dim userRow As MyBusinessDataSet.usersRow = oUserTable.Rows(0)

                If Not userRow.Isuser_emailNull Then
                    If AuthenticationUtil.createUserTemporaryPassword(userRow.user_id, userRow.salt, userRow.user_email) Then
                        logStatus("User allocated temporary password", True)
                    End If
                Else
                    logStatus("No email address for that user", True, TraceEventType.Error)
                End If

            Else
                logStatus("User record missing for that user", True, TraceEventType.Error)
            End If
        Else
            logStatus("No user selected", False)
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub LogStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information, Optional ByVal errorCode As String = Nothing)
        lblStatus.Text = sText
        If islogged Then LogUtil.AddLog(sText, level, FORM_NAME, errorCode)
    End Sub
#End Region
End Class