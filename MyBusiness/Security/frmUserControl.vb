' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.Windows.Forms
Imports System.Security.Cryptography

Public Class FrmUserControl
    Const MSGBOX_TITLE As String = "Remove Error"
    Const FORM_NAME As String = "users"
    Const FORCE_PASSWORD_CHANGE As Integer = 1
    Const NO_PASSWORD_CHANGE As Integer = 0
    Private ReadOnly bChanges As Boolean = False
    Private ReadOnly sha1 As New SHA1CryptoServiceProvider
    Private currentUserId As Integer = 0
    Private ReadOnly oTa As New netwyrksDataSetTableAdapters.userTableAdapter
    Private ReadOnly oTable As New netwyrksDataSet.userDataTable
    Private ReadOnly oUserTa As New netwyrksDataSetTableAdapters.userTableAdapter
    Private ReadOnly oUserTable As New netwyrksDataSet.userDataTable
    Private oUser As User

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Const MSGBOX_TITLE As String = "Update Error"
        Dim hashedUser As String
        Dim storedHashedPW As String = ""
        Dim salt As String
        If txtUserName.Text.Trim = "" Then
            MsgBox("Name is required", MsgBoxStyle.Exclamation, MSGBOX_TITLE)
            Exit Sub
        End If

        '     Dim oRow As netwyrksDataSet.userRow = Nothing
        oUser = UserBuilder.AUser.StartingWithNothing.Build
        If currentUserId > 0 Then
            oUser = GetUserById(currentUserId)
        ElseIf txtUserLogin.TextLength > 0 Then
            oUser = GetUserByLogin(AuthenticationUtil.HashedUsername(txtUserLogin.Text))
        End If
        If oUser.UserId > 0 Then
            Dim userId As Integer = oUser.UserId
            salt = oUser.Salt
            If txtPasswd1.Text.Trim.Length = 0 Then
                storedHashedPW = oUser.Password
            Else
                ' changing password
                If txtPasswd1.Text = txtPasswd2.Text Then
                    If txtPasswd1.Text.Trim.Length >= GlobalSettings.GetSetting("MinPwdLen") Then
                        ' update user
                        storedHashedPW = AuthenticationUtil.GetHashed(salt & txtPasswd1.Text.Trim)
                    Else
                        MsgBox("Password must be at least " & GlobalSettings.GetSetting("MinPwdLen") & " characters", MsgBoxStyle.Exclamation, MSGBOX_TITLE)

                    End If
                Else
                    MsgBox("Mis-matched passwords", MsgBoxStyle.Exclamation, MSGBOX_TITLE)
                End If
            End If

            'update existing

            Dim _user As User = UserBuilder.AUser.StartingWithNothing.WithUserCode(txtUsercode.Text.Trim) _
                    .WithPassword(storedHashedPW) _
                    .WithForcePasswordChange(chkForceChange.Checked) _
                    .WithSalt(salt) _
                    .WithUserName(txtUserName.Text.Trim) _
                    .WithContactNumber(txtContactNumber.Text.Trim) _
                    .WithMobile(txtMobile.Text.Trim) _
                    .WithEmail(txtEmail.Text.Trim) _
                    .WithJobTitle(txtJobTitle.Text.Trim) _
                    .WithNote(txtNote.Text.Trim) _
                    .WithTempPassword("") _
                    .WithUserId(userId) _
                    .WithRole(GetAccessType(salt)) _
                    .Build
            Dim updCt As Integer = UpdateUser(_user)
            If updCt = 1 Then
                AuditUtil.AddAudit(-1, AuditUtil.RecordType.User, -1, AuditUtil.AuditableAction.update, "", txtUserLogin.Text & " - no new password")
                LogStatus("User " & txtUserLogin.Text & " details updated", True, TraceEventType.Information)
            Else
                MsgBox("User not updated", MsgBoxStyle.Exclamation, "Error")
            End If
        Else
            'insert new user
            If txtUserLogin.TextLength > 0 Then
                If txtPasswd1.Text.Trim.Length > 0 Then
                    If txtPasswd1.Text = txtPasswd2.Text Then
                        If txtPasswd1.Text.Trim.Length >= GlobalSettings.GetSetting("MinPwdLen") Then
                            ' insert user
                            hashedUser = AuthenticationUtil.HashedUsername(txtUserLogin.Text)
                            salt = AuthenticationUtil.GetNewSalt(txtUserLogin.Text)
                            Dim _user As User = UserBuilder.AUser.StartingWithNothing.WithUserCode(txtUsercode.Text.Trim) _
                                                        .WithUserLogin(hashedUser) _
                                                        .WithPassword(storedHashedPW) _
                                                        .WithForcePasswordChange(True) _
                                                        .WithSalt(salt) _
                                                        .WithUserName(txtUserName.Text.Trim) _
                                                        .WithContactNumber(txtContactNumber.Text.Trim) _
                                                        .WithMobile(txtMobile.Text.Trim) _
                                                        .WithEmail(txtEmail.Text.Trim) _
                                                        .WithJobTitle(txtJobTitle.Text.Trim) _
                                                        .WithNote(txtNote.Text.Trim) _
                                                        .WithRole(GetAccessType(salt)) _
                                                        .WithTempPassword("") _
                                                        .WithUserId(-1) _
                                                        .Build
                            Dim newUserId As Integer = InsertUser(_user, txtPasswd1.Text.Trim)

                            LogStatus("User " & txtUserLogin.Text & " details inserted", True, TraceEventType.Information)
                            AuditUtil.AddAudit(-1, AuditUtil.RecordType.User, -1, AuditUtil.AuditableAction.create, "", txtUserLogin.Text)
                            txtStatus.Text = "User " & txtUserLogin.Text.Trim() & " added"

                        Else
                            MsgBox("Password must be at least " & GlobalSettings.GetSetting("MinPwdLen") & " characters", MsgBoxStyle.Exclamation, MSGBOX_TITLE)
                        End If
                    Else
                        MsgBox("Mis-matched passwords", MsgBoxStyle.Exclamation, MSGBOX_TITLE)
                    End If
                Else
                    MsgBox("New user requires a password. Not updated.", MsgBoxStyle.Exclamation, MSGBOX_TITLE)
                End If
            Else
                MsgBox("No username entered", MsgBoxStyle.Exclamation, MSGBOX_TITLE)
            End If
        End If


    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        '
        ' Get hash of trimmed lower username
        '
        Try
            lblExists.Text = AuthenticationUtil.RemoveUser(currentUserId)
            AuditUtil.AddAudit(AuditUtil.RecordType.User, currentUserId, AuditUtil.AuditableAction.delete)
        Catch ex As ApplicationException
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Remove error")
        End Try
        ClearValues()
        txtUserLogin.Text = ""

    End Sub

    Private Sub ClearValues()

        lblExists.Text = ""
        txtUserName.Text = ""
        txtContactNumber.Text = ""
        txtEmail.Text = ""
        txtUsercode.Text = ""
        txtUsercode.Enabled = True
        txtPasswd1.Text = ""
        txtPasswd2.Text = ""
        txtJobTitle.Text = ""
        txtNote.Text = ""
        rbAdministrator.Checked = False
        rbGuest.Checked = False
        rbSuspend.Checked = True
        rbOperator.Checked = False
        currentUserId = 0

    End Sub

    Private Function GetAccessType(ByVal salt As String) As String
        Dim roleName As String = "Suspended"
        If rbAdministrator.Checked Then
            roleName = AuthorisationUtil.GetRoleName(AuthorisationUtil.AccessRole.Administrator)
        End If
        If rbOperator.Checked Then
            roleName = AuthorisationUtil.GetRoleName(AuthorisationUtil.AccessRole.Operatr)
        End If
        If rbGuest.Checked Then
            roleName = AuthorisationUtil.GetRoleName(AuthorisationUtil.AccessRole.Guest)
        End If
        If rbSuspend.Checked Then
            roleName = AuthorisationUtil.GetRoleName(AuthorisationUtil.AccessRole.Suspended)
        End If
        Return AuthenticationUtil.GetHashed(salt & roleName)
    End Function

    Private Sub FrmUserControl_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oTable.Dispose()
        oTa.Dispose()
        logutil.info("Closed", FORM_NAME)
    End Sub

    Private Sub UserControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbSelect.DataSource = GetAllUsers()
        cbSelect.DisplayMember = "user_name"
        cbSelect.ValueMember = "user_id"
        isAdmin = True
        btnRemove.Visible = isAdmin
        btnUpdate.Visible = isAdmin
        txtPasswd1.Enabled = isAdmin
        txtPasswd2.Enabled = isAdmin
        lblFormName.Text = FORM_NAME
        Panel1.Enabled = False
        btnRemove.Enabled = False
        btnUpdate.Enabled = False
        lblExists.Text = ""
        ClearValues()
        cbSelect.SelectedIndex = -1
        txtUserLogin.Text = ""
    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Const MSGBOX_TITLE As String = "Update Error"
        txtStatus.Text = ""
        If txtUserLogin.Text.Length > 0 Then
            '
            ' Get hash of trimmed lower username
            '
            Dim hashedUser As String = AuthenticationUtil.HashedUsername(txtUserLogin.Text)
            Try
                oUser = GetUserByLogin(hashedUser)
                If oUser.UserId > 0 Then
                    '
                    ' User already exists
                    '
                    FillForm(oUser)
                Else
                    ClearValues()
                    Panel1.Enabled = True
                    btnUpdate.Enabled = True
                    lblExists.Text = "New User"
                    currentUserId = 0
                    oUser = UserBuilder.AUser.StartingWithNothing.Build
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, MSGBOX_TITLE)
                Panel1.Enabled = False
                btnRemove.Enabled = False
                btnUpdate.Enabled = False
            End Try
        Else
            MsgBox("No username entered", MsgBoxStyle.Exclamation, MSGBOX_TITLE)
        End If

    End Sub

    Private Sub FillForm(ByVal pUser As User)

        Panel1.Enabled = True
        btnRemove.Enabled = True
        btnUpdate.Enabled = True

        ClearValues()
        Dim storedHashedPW As String = pUser.Password
        Dim salt As String = pUser.Salt
        Dim role As String = pUser.UserRole

        lblExists.Text = "User Exists"
        Select Case role
            Case AuthenticationUtil.GetHashed(salt & AuthorisationUtil.GetRoleName(AuthorisationUtil.AccessRole.Operatr))
                rbOperator.Checked = True
            Case AuthenticationUtil.GetHashed(salt & AuthorisationUtil.GetRoleName(AuthorisationUtil.AccessRole.Administrator))
                rbAdministrator.Checked = True
            Case AuthenticationUtil.GetHashed(salt & AuthorisationUtil.GetRoleName(AuthorisationUtil.AccessRole.Guest))
                rbGuest.Checked = True
            Case AuthenticationUtil.GetHashed(salt & AuthorisationUtil.GetRoleName(AuthorisationUtil.AccessRole.Suspended))
                rbSuspend.Checked = True
            Case Else
                rbSuspend.Checked = True
        End Select

        txtUsercode.Text = pUser.User_code
        txtUsercode.Enabled = True
        currentUserId = pUser.UserId

        txtUserName.Text = pUser.UserName
        txtContactNumber.Text = pUser.ContactNumber
        txtJobTitle.Text = pUser.JobTitle
        txtNote.Text = pUser.Note
        txtEmail.Text = pUser.Email
        txtMobile.Text = pUser.Mobile
    End Sub

    Private Sub TxtUserName_TextChanged(sender As Object, e As EventArgs) Handles txtUserLogin.TextChanged
        ClearValues()
    End Sub

    Private Sub CbSelect_Format(sender As Object, e As ListControlConvertEventArgs) Handles cbSelect.Format
        Dim oUser As User = CType(e.ListItem, User)
        e.Value = oUser.UserName
    End Sub

    Private Sub CbSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSelect.SelectedIndexChanged
        If cbSelect.SelectedIndex > -1 Then
            Try
                ' oUser = GetUserById(cbSelect.SelectedValue)
                oUser = cbSelect.SelectedValue
                If oUser.UserId > 0 Then
                    FillForm(oUser)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "error")
            End Try
        End If
    End Sub
    Private Sub LogStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information, Optional ByVal errorCode As String = Nothing)
        txtStatus.Text = sText
        If islogged Then LogUtil.AddLog(sText, level, FORM_NAME, errorCode)
    End Sub

End Class
