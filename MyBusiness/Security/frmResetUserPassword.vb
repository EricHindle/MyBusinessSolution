' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle 

Public Class frmResetUserPassword
#Region "Contants"
    Private Const FORM_NAME As String = "reset user password"
#End Region
#Region "Private variable instances"
    Private RECORD_TYPE As AuditUtil.RecordType = AuditUtil.RecordType.Customer
    Private oUserTa As New netwyrksDataSetTableAdapters.userTableAdapter
    Private oUserTable As New netwyrksDataSet.userDataTable

    Private userItem As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)()
#End Region

#Region "Form"
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oUserTa.Dispose()
        oUserTable.Dispose()
        LogUtil.Debug("Closed", FORM_NAME)
    End Sub

    Private Sub form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Starting", FORM_NAME)
        lblFormName.Text = FORM_NAME
        oUserTa.Fill(oUserTable)
        For Each oUserRow As netwyrksDataSet.userRow In oUserTable.Rows
            Dim sUsername As String = oUserRow.user_name
            Dim userId As Integer = oUserRow.user_id
            userItem.Add(userId, sUsername)
        Next
        cbSelect.DataSource = New BindingSource(userItem, Nothing)
        cbSelect.DisplayMember = "Value"
        cbSelect.ValueMember = "Key"
    End Sub
#End Region

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        If cbSelect.SelectedIndex > -1 Then
            If oUserTa.FillById(oUserTable, cbSelect.SelectedValue) = 1 Then
                Dim userRow As netwyrksDataSet.userRow = oUserTable.Rows(0)


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
    Private Sub logStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information, Optional ByVal errorCode As String = Nothing)
        lblStatus.Text = sText
        If islogged Then LogUtil.addLog(sText, level, FORM_NAME, errorCode)
    End Sub

End Class