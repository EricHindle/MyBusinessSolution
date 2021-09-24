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
        Dim userCt As Integer = 0
        Dim hashedUser As String
        Dim storedHashedPW As String
        Dim salt As String
        If txtUserName.Text.Trim = "" Then
            MsgBox("Name is required", MsgBoxStyle.Exclamation, MSGBOX_TITLE)
            Exit Sub
        End If

        If currentUserId > 0 Then
            userCt = oTa.FillById(oTable, currentUserId)
        ElseIf txtUserLogin.TextLength > 0 Then
            userCt = oTa.FillByLogin(oTable, AuthenticationUtil.hashedUsername(txtUserLogin.Text))
        End If
        If userCt = 1 Then
            Dim oRow As netwyrksDataSet.userRow = oTable.Rows(0)
            Dim userId As Integer = oRow.user_id
            oUser = UserBuilder.AUserBuilder.StartingWith(oRow).Build
            salt = oRow.salt
            'update existing
            If txtPasswd1.Text.Trim.Length = 0 Then
                ' not changing password   
                storedHashedPW = oRow.user_password
                Dim changePassword As Integer = If(chkForceChange.Checked, 1, 0)
                ' update user
                Dim updCt As Integer = oTa.UpdateUser(txtUsercode.Text.Trim, storedHashedPW, "", chkForceChange.Checked, salt, txtUserName.Text.Trim, txtContactNumber.Text.Trim, txtMobile.Text.Trim, txtEmail.Text.Trim, txtJobTitle.Text.Trim, txtNote.Text.Trim, Now, userId)

                If updCt = 1 Then
                    AuditUtil.AddAudit(-1, AuditUtil.RecordType.User, -1, AuditUtil.AuditableAction.update, "", txtUserLogin.Text & " - no new password")
                    LogStatus("User " & txtUserLogin.Text & " details updated", True, TraceEventType.Information)
                Else
                    MsgBox("User not updated", MsgBoxStyle.Exclamation, "Error")
                End If
            Else
                ' changing password
                If txtPasswd1.Text = txtPasswd2.Text Then
                    If txtPasswd1.Text.Trim.Length >= GlobalSettings.getSetting("MinPwdLen") Then
                        ' update user
                        storedHashedPW = AuthenticationUtil.GetHashed(salt & txtPasswd1.Text.Trim)
                        oTa.UpdateUser(txtUsercode.Text.Trim, storedHashedPW, "", chkForceChange.Checked, salt, txtUserName.Text.Trim, txtContactNumber.Text.Trim, txtMobile.Text.Trim, txtEmail.Text.Trim, txtJobTitle.Text.Trim, txtNote.Text.Trim, Now, userId)
                        AuditUtil.AddAudit(-1, AuditUtil.RecordType.User, -1, AuditUtil.AuditableAction.update, "", txtUserLogin.Text & " - new password")
                        LogStatus("User " & txtUserLogin.Text & " details updated", True, TraceEventType.Information)
                    Else
                        MsgBox("Password must be at least " & GlobalSettings.getSetting("MinPwdLen") & " characters", MsgBoxStyle.Exclamation, MSGBOX_TITLE)
                    End If
                Else
                    MsgBox("Mis-matched passwords", MsgBoxStyle.Exclamation, MSGBOX_TITLE)
                End If
            End If
        Else
            'insert new user
            If txtUserLogin.TextLength > 0 Then
                If txtPasswd1.Text.Trim.Length > 0 Then
                    If txtPasswd1.Text = txtPasswd2.Text Then
                        If txtPasswd1.Text.Trim.Length >= GlobalSettings.getSetting("MinPwdLen") Then
                            ' insert user
                            hashedUser = AuthenticationUtil.hashedUsername(txtUserLogin.Text)
                            salt = AuthenticationUtil.getNewSalt(txtUserLogin.Text)
                            Dim newUserId As Integer = oTa.InsertUser(hashedUser, txtUsercode.Text.Trim,
                                                   AuthenticationUtil.GetHashed(salt & txtPasswd1.Text.Trim), "", True,
                                                   salt,
                                                   txtUserName.Text.Trim, txtContactNumber.Text.Trim, txtMobile.Text.Trim, txtEmail.Text.Trim, txtJobTitle.Text.Trim, txtNote.Text.Trim, Now)
                            LogStatus("User " & txtUserLogin.Text & " details inserted", True, TraceEventType.Information)
                            AuditUtil.AddAudit(-1, AuditUtil.RecordType.User, -1, AuditUtil.AuditableAction.create, "", txtUserLogin.Text)
                            txtStatus.Text = "User " & txtUserLogin.Text.Trim() & " added"

                        Else
                            MsgBox("Password must be at least " & GlobalSettings.getSetting("MinPwdLen") & " characters", MsgBoxStyle.Exclamation, MSGBOX_TITLE)
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
        LogUtil.Debug("Closed", FORM_NAME)
    End Sub

    Private Sub UserControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        oUserTa.Fill(oUserTable)
        cbSelect.DataSource = oUserTable
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
            Dim hashedUser As String = AuthenticationUtil.hashedUsername(txtUserLogin.Text)
            Try
                If oTa.FillByLogin(oTable, hashedUser) > 0 Then
                    '
                    ' User already exists
                    '
                    Dim oRow As netwyrksDataSet.userRow = oTable.Rows(0)
                    FillForm(oRow)
                    oUser = UserBuilder.AUserBuilder.StartingWith(oRow).Build
                Else
                    ClearValues()
                    Panel1.Enabled = True
                    btnUpdate.Enabled = True
                    lblExists.Text = "New User"
                    currentUserId = 0
                    oUser = UserBuilder.AUserBuilder.StartingWithNothing.Build
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

    Private Sub FillForm(ByVal oRow As netwyrksDataSet.userRow)

        Panel1.Enabled = True
        btnRemove.Enabled = True
        btnUpdate.Enabled = True

        ClearValues()
        Dim storedHashedPW As String
        Dim salt As String
        Dim role As String = ""

        storedHashedPW = oRow.user_password
        salt = oRow.salt

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

        txtUsercode.Text = oRow.user_code
        txtUsercode.Enabled = True
        currentUserId = oRow.user_id

        txtUserName.Text = oRow.user_name
        txtContactNumber.Text = If(oRow.Isuser_contact_numberNull, "", oRow.user_contact_number)
        txtJobTitle.Text = If(oRow.Isuser_jobtitleNull, "", oRow.user_jobtitle)
        txtNote.Text = If(oRow.Isuser_noteNull, "", oRow.user_note)
        txtEmail.Text = If(oRow.Isuser_emailNull, "", oRow.user_email)
        txtMobile.Text = If(oRow.Isuser_mobileNull, "", oRow.user_mobile)


    End Sub

    Private Sub TxtUserName_TextChanged(sender As Object, e As EventArgs) Handles txtUserLogin.TextChanged
        ClearValues()
    End Sub

    Private Sub CbSelect_Format(sender As Object, e As ListControlConvertEventArgs) Handles cbSelect.Format
        Dim oRowView As DataRowView = CType(e.ListItem, DataRowView)
        Dim oUserRow As netwyrksDataSet.userRow = TryCast(oRowView.Row, netwyrksDataSet.userRow)
        e.Value = oUserRow.user_name
    End Sub

    Private Sub CbSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSelect.SelectedIndexChanged
        If cbSelect.SelectedIndex > -1 Then
            Try
                If oTa.FillById(oTable, cbSelect.SelectedValue) = 1 Then
                    Dim orow As netwyrksDataSet.userRow = oTable.Rows(0)
                    FillForm(orow)
                    oUser = UserBuilder.AUserBuilder.StartingWith(orow).Build
                Else
                    ' Error
                    oUser = UserBuilder.AUserBuilder.StartingWithNothing.Build
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
