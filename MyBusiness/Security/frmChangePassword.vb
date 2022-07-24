' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class FrmChangePassword
#Region "Contants"
    Private Const FORM_NAME As String = "change password"
    Private Const CURRENT_TEXT As String = "Current Password"
    Private Const NEW_TEXT As String = "New Password"
    Private Const RETYPE_TEXT As String = "Re-Type New Password"
#End Region
#Region "Private variable instances"
    Private ReadOnly RECORD_TYPE As AuditUtil.RecordType = AuditUtil.RecordType.User
    Private userId As Integer = 0
    Private ReadOnly salt As String = ""
    Private myIdentity As NetwyrksIIdentity = Nothing
    '  Private ReadOnly oTa As New netwyrksDataSetTableAdapters.userTableAdapter
    '  Private ReadOnly oTable As New netwyrksDataSet.userDataTable
#End Region
#Region "properties"
    Private _forceChange As Boolean
    Public Property ForceChange() As Boolean
        Get
            Return _forceChange
        End Get
        Set(ByVal value As Boolean)
            _forceChange = value
        End Set
    End Property
#End Region
#Region "Form"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closed", FORM_NAME)
    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        logutil.info("Starting", FORM_NAME)
        lblFormName.Text = FORM_NAME
        myIdentity = My.User.CurrentPrincipal.Identity
        userId = myIdentity.UserId
        lblForceChange.Visible = ForceChange
        SetTextboxToDefault(txtCurrent, CURRENT_TEXT)
        SetTextboxToDefault(txtNew, NEW_TEXT)
        SetTextboxToDefault(txtCopy, RETYPE_TEXT)
    End Sub
    Private Sub TextBox_Enter(sender As Object, e As EventArgs) Handles txtCurrent.Enter, txtNew.Enter, txtCopy.Enter
        Dim tb As TextBox = DirectCast(sender, TextBox)
        Dim stdText As String = ""
        Select Case tb.Name
            Case "txtCurrent"
                stdText = CURRENT_TEXT
            Case "txtNew"
                stdText = NEW_TEXT
            Case "txtCopy"
                stdText = RETYPE_TEXT
        End Select
        With tb
            .PasswordChar = "*"
            .ForeColor = Color.Black
            .BackColor = Color.White
            .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Regular)
            If .Text = stdText Then
                .Clear()
            End If
        End With
    End Sub
    Private Sub SetTextboxToDefault(ByRef oTextBox As TextBox, ByVal stdText As String)

        With oTextBox
            .PasswordChar = Nothing
            .ForeColor = Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(26, Byte), Integer))
            .BackColor = Color.PeachPuff
            .Font = New Font(.Font.FontFamily, .Font.Size, FontStyle.Italic)
            .Text = stdText
        End With
    End Sub
    Private Sub BtnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Me.DialogResult = DialogResult.Cancel
        Try
            Dim iMinLen As Integer = GlobalSettings.getSetting("MinPwdLen")
            If AuthenticationUtil.isPasswordOK(txtCurrent.Text.Trim) Then
                'Changing password
                If txtNew.Text.Trim.Length < iMinLen Then
                    LogUtil.Warn(PASSWORD_CHANGE_ERROR & " (length)")
                    MsgBox("Password must be at least " & CStr(iMinLen) & " characters", MsgBoxStyle.Exclamation, INVALID_PASSWORD)
                    Exit Sub
                End If
                If txtCopy.Text.Trim <> txtNew.Text.Trim Then
                    LogUtil.Warn(PASSWORD_CHANGE_ERROR & " (mis-match)")
                    MsgBox("Mis-matched passwords", MsgBoxStyle.Exclamation, INVALID_PASSWORD)
                    Exit Sub
                End If
                If txtCurrent.Text.Trim = txtNew.Text.Trim Then
                    LogUtil.Warn(PASSWORD_CHANGE_ERROR & " (same password)")
                    MsgBox("Password must be changed", MsgBoxStyle.Exclamation, INVALID_PASSWORD)
                    Exit Sub
                End If
                ' Store new password
                If StoreNewPassword() Then
                    ' Successful login with password change
                    LogStatus("User password changed OK", True, TraceEventType.Information)
                    RemoveTempPassword(userId)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    LogUtil.Warn(PASSWORD_CHANGE_ERROR & " (store)")
                    MsgBox("Unable to store new password", MsgBoxStyle.Exclamation, INVALID_PASSWORD)
                End If
            Else
                LogUtil.Warn(PASSWORD_CHANGE_ERROR & " (current password)")
                MsgBox("Current password is not correct", MsgBoxStyle.Exclamation, INVALID_PASSWORD)
            End If
        Catch ex As Exception
            LogUtil.Warn(PASSWORD_CHANGE_ERROR & " (store)")
            MsgBox("Unable to store new password", MsgBoxStyle.Exclamation, "Exception")
            SetTextboxToDefault(txtCurrent, CURRENT_TEXT)
            SetTextboxToDefault(txtNew, NEW_TEXT)
            SetTextboxToDefault(txtCopy, RETYPE_TEXT)
        End Try
    End Sub
    Private Sub TxtCurrent_Leave(sender As Object, e As EventArgs) Handles txtCurrent.Leave, txtNew.Leave, txtCopy.Leave
        Dim tb As TextBox = DirectCast(sender, TextBox)
        If tb.Text = "" Then
            Dim stdText As String = ""
            Select Case tb.Name
                Case "txtCurrent"
                    stdText = CURRENT_TEXT
                Case "txtNew"
                    stdText = NEW_TEXT
                Case "txtCopy"
                    stdText = RETYPE_TEXT
            End Select

            SetTextboxToDefault(tb, stdText)

        End If
    End Sub
    Private Sub BtnPwdGen_Click(sender As Object, e As EventArgs) Handles btnPwdGen.Click
        lblPwd.Text = AuthenticationUtil.generateWordyPassword
        My.Computer.Clipboard.SetText(lblPwd.Text)
    End Sub
#End Region
#Region "Subroutines"
    Private Sub LogStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information)
        lblStatus.Text = sText
        If islogged Then LogUtil.AddLog(sText, level, FORM_NAME)
    End Sub
    Private Function StoreNewPassword() As Boolean
        Dim rtnval As Boolean = False
        Try
            If AuthenticationUtil.SavePassword(userId, Trim(txtNew.Text), False) Then
                AuditUtil.AddAudit(AuditUtil.RecordType.User, userId, AuditUtil.AuditableAction.update,, "Password changed")
                rtnval = True
            End If
        Catch ex As Exception
            logStatus("Password not saved", True, TraceEventType.Error)
        End Try

        Return rtnval
    End Function
#End Region
End Class