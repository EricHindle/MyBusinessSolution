' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports MyBusiness.NetwyrksErrorCodes
Public Class frmPasswordRequest

#Region "Constants"
    Private Const FORM_NAME As String = "forgotten password"
    Private Const USERNAME_TEXT As String = "User name"
    Private Const EMAIL_TEXT As String = "Registered email address"
    Private oUserTa As new netwyrksDataSetTableAdapters.userTableAdapter
    Private oUserTable As New netwyrksDataSet.userDataTable
#End Region
#Region "Private variable instances"
    Private RECORD_TYPE As AuditUtil.RecordType = AuditUtil.RecordType.User
#End Region

#Region "Form"

    Private Sub form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oUserTa.Dispose()
        oUserTable.Dispose()
        LogUtil.Debug("Closed", FORM_NAME)
    End Sub

    Private Sub form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Starting", FORM_NAME)
        lblFormName.Text = FORM_NAME
        SetTextboxToDefault(txtUsername, USERNAME_TEXT)
        SetTextboxToDefault(txtEmail, EMAIL_TEXT)
    End Sub
#End Region

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click

        Dim hashedUser As String = AuthenticationUtil.hashedUsername(txtUsername.Text.Trim)
        Dim i As Integer = oUserTa.FillByLogin(oUserTable, hashedUser)
        If i = 1 Then
            Dim uRow As netwyrksDataSet.userRow = oUserTable.Rows(0)
            Dim userId As Integer = uRow.user_id
            Dim salt As String = uRow.salt
            Dim usercode As String = uRow.user_code

            If Not uRow.Isuser_emailNull Then
                Dim sEmail As String = uRow.user_email
                If sEmail.Trim.ToLower = txtEmail.Text.Trim.ToLower Then
                    If AuthenticationUtil.createUserTemporaryPassword(userId, salt, uRow.user_email) Then
                        logStatus("Password reset OK", True)
                        AuditUtil.addAudit(AuditUtil.RecordType.User, userId, AuditUtil.AuditableAction.update, , "Temporary password created")
                    Else
                        MsgBox("Temporary password could not be created", MsgBoxStyle.Critical, "Error")
                        logStatus("Temporary password could not be created", True, TraceEventType.Error, getErrorCode(SystemModule.SECURITY, ErrorType.DATABASE, FailedAction.UPDATE_FAILED))
                    End If
                Else
                    logStatus("Username/email not recognised", True, TraceEventType.Information)
                    AuditUtil.addAudit(AuditUtil.RecordType.User, userId, AuditUtil.AuditableAction.update,, "Unsuccessful attempt to reset password (email address)")
                End If
            Else
                MsgBox("User record incomplete", MsgBoxStyle.Critical, "Error")
                    logStatus("User record incomplete - no email address", True, TraceEventType.Error, getErrorCode(SystemModule.SECURITY, ErrorType.MISSING_DATA, FailedAction.SINGLE_RECORD_LOAD_EXCEPTION))
                End If

                Me.Close()
        Else
            logStatus("Username/email not recognised", True, TraceEventType.Information)
            AuditUtil.addAudit(AuditUtil.RecordType.User, -1, AuditUtil.AuditableAction.update,, "Unsuccessful attempt to reset password (userId)")
        End If
    End Sub

    Private Sub textBox_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtUsername.Enter, txtEmail.Enter
        Dim tb As TextBox = DirectCast(sender, TextBox)
        Dim stdText As String = ""
        Select Case tb.Name
            Case "txtUsername"
                stdText = USERNAME_TEXT
            Case "txtEmail"
                stdText = EMAIL_TEXT
        End Select
        With tb
            .ForeColor = Color.Black
            .BackColor = Color.White
            .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Regular)
            If .Text = stdText Then
                .Clear()
            End If
        End With
    End Sub

    Private Sub txtCurrent_Leave(sender As Object, e As EventArgs) Handles txtUsername.Leave, txtEmail.Leave
        Dim tb As TextBox = DirectCast(sender, TextBox)
        If tb.Text = "" Then
            Dim stdText As String = ""
            Select Case tb.Name
                Case "txtUsername"
                    stdText = USERNAME_TEXT
                Case "txtEmail"
                    stdText = EMAIL_TEXT
            End Select
            SetTextboxToDefault(tb, stdText)
        End If
    End Sub

    Private Sub SetTextboxToDefault(ByRef oTextBox As TextBox, ByVal stdText As String)
        With oTextBox
            .PasswordChar = Nothing
            .ForeColor = Color.Gray
            .BackColor = Color.White
            .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Italic)
            .Text = stdText
        End With
    End Sub

    Private Sub logStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information, Optional ByVal errorCode As String = Nothing)
        lblStatus.Text = sText
        If islogged Then LogUtil.addLog(sText, level, FORM_NAME, errorCode)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class