' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports MyBusiness.NetwyrksErrorCodes
Public Class FrmPasswordRequest

#Region "Constants"
    Private Const FORM_NAME As String = "forgotten password"
    Private Const USERNAME_TEXT As String = "User name"
    Private Const EMAIL_TEXT As String = "Registered email address"
#End Region
#Region "Private variable instances"
    Private ReadOnly RECORD_TYPE As AuditUtil.RecordType = AuditUtil.RecordType.User
#End Region
#Region "Form"
    Private Sub BtnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click

        Dim hashedUser As String = AuthenticationUtil.HashedUsername(txtUsername.Text.Trim)
        Dim _user As User = GetUserByLogin(hashedUser)
        If _user.UserId > 0 Then

            Dim userId As Integer = _user.UserId
            Dim salt As String = _user.Salt
            Dim usercode As String = _user.User_code

            If Not String.IsNullOrEmpty(_user.Email) Then
                Dim sEmail As String = _user.Email
                If sEmail.Trim.ToLower = txtEmail.Text.Trim.ToLower Then
                    If AuthenticationUtil.CreateUserTemporaryPassword(userId, salt, _user.Email) Then
                        LogStatus("Password reset OK", True)
                        AuditUtil.AddAudit(AuditUtil.RecordType.User, userId, AuditUtil.AuditableAction.update, , "Temporary password created")
                    Else
                        MsgBox("Temporary password could not be created", MsgBoxStyle.Critical, "Error")
                        LogStatus("Temporary password could not be created", True, TraceEventType.Error, GetErrorCode(SystemModule.SECURITY, ErrorType.DATABASE, FailedAction.UPDATE_FAILED))
                    End If
                Else
                    LogStatus("Username/email not recognised", True, TraceEventType.Information)
                    AuditUtil.AddAudit(AuditUtil.RecordType.User, userId, AuditUtil.AuditableAction.update,, "Unsuccessful attempt to reset password (email address)")
                End If
            Else
                MsgBox("User record incomplete", MsgBoxStyle.Critical, "Error")
                LogStatus("User record incomplete - no email address", True, TraceEventType.Error, GetErrorCode(SystemModule.SECURITY, ErrorType.MISSING_DATA, FailedAction.SINGLE_RECORD_LOAD_EXCEPTION))
            End If

            Close()
        Else
            LogStatus("Username/email not recognised", True, TraceEventType.Information)
            AuditUtil.AddAudit(AuditUtil.RecordType.User, -1, AuditUtil.AuditableAction.update,, "Unsuccessful attempt to reset password (userId)")
        End If
    End Sub
    Private Sub TextBox_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtUsername.Enter, txtEmail.Enter
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
    Private Sub TxtCurrent_Leave(sender As Object, e As EventArgs) Handles txtUsername.Leave, txtEmail.Leave
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
    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closed", FORM_NAME)
    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        logutil.info("Starting", FORM_NAME)
        lblFormName.Text = FORM_NAME
        SetTextboxToDefault(txtUsername, USERNAME_TEXT)
        SetTextboxToDefault(txtEmail, EMAIL_TEXT)
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
#End Region
#Region "subroutines"
    Private Sub SetTextboxToDefault(ByRef oTextBox As TextBox, ByVal stdText As String)
        With oTextBox
            .PasswordChar = Nothing
            .ForeColor = Color.Gray
            .BackColor = Color.White
            .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Italic)
            .Text = stdText
        End With
    End Sub
    Private Sub LogStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information, Optional ByVal errorCode As String = Nothing)
        lblStatus.Text = sText
        If islogged Then LogUtil.AddLog(sText, level, FORM_NAME, errorCode)
    End Sub
#End Region

End Class