' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports System.Data.SqlClient
Imports HindlewareLib.Logging

Public Class LoginForm

    ' The custom principal is attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

#Region "variables"
    Private ReadOnly wiName As String() = Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\"c)
#End Region
#Region "Form"
    Private Sub LoginForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _companyName = GlobalSettings.GetStringSetting(GlobalSettings.COMPANY_NAME)
        InitialiseLoginForm()
        Show()
        Refresh()
        If InitialiseApplication() Then
            LogUtil.Info("Settings:")
            LogUtil.Info(" Auto Tidy           : " & My.Settings.AutoTidy)
            LogUtil.Info(" Retention period    : " & My.Settings.RetentionPeriod)
            LogUtil.Info(" Spell Check enabled : " & My.Settings.splchkEnabled)
        Else
            Close()
        End If
        lblInitMessage.Visible = False
        Panel1.Visible = True
        PasswordTextBox.Select()
    End Sub
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        ' Creating a new sersIPrincipal checks the username and password and sets the user's role
        Try
            Dim customPrincipal As New NetwyrksIPrincipal(UsernameTextBox.Text, PasswordTextBox.Text)
            If Not customPrincipal.Identity.IsAuthenticated Then
                ' The user is still not validated.
                LogUtil.Warn(NOT_AUTHENTICATED)
                MsgBox("The username and password pair is incorrect", MsgBoxStyle.Exclamation, "Authentication Error")
                InitialiseLoginForm()
                lblInitMessage.Visible = False
                Panel1.Visible = True
                PasswordTextBox.Select()
            Else
                ' Successful login
                My.User.CurrentPrincipal = customPrincipal
                If My.User.IsAuthenticated And IsActiveUser() Then
                    TopMost = False
                    If AuthenticationUtil.IsPasswordChangeOK Then
                        EnterApplication()
                    Else
                        MsgBox("Required password change not complete", MsgBoxStyle.Exclamation, "Access Error")
                    End If
                Else
                    LogUtil.Warn(NOT_AUTHORISED)
                    Throw New ApplicationException(AUTHORISATION_ERROR)
                End If
            End If
        Catch ex As ApplicationException
            MsgBox("Not authorised to use the application", MsgBoxStyle.Exclamation, "Access Error")
            OK.Enabled = False
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        LogUtil.Info("Login cancelled")
        LogUtil.Info("=".PadRight(40, "="))
        Close()
    End Sub
    Private Function IsActiveUser() As Boolean
        Return My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) _
                    Or My.User.IsInRole(ApplicationServices.BuiltInRole.User) _
                    Or My.User.IsInRole(ApplicationServices.BuiltInRole.PowerUser) _
                    Or My.User.IsInRole(ApplicationServices.BuiltInRole.AccountOperator) _
                    Or My.User.IsInRole(ApplicationServices.BuiltInRole.Guest)
    End Function
    Private Sub LblForgottenPassword_DoubleClick(sender As Object, e As EventArgs) Handles lblForgottenPassword.DoubleClick, lblForgottenPassword.Click
        TopMost = False
        Using _forgot As New FrmPasswordRequest
            _forgot.ShowDialog()
            LogUtil.Info("Login abandoned - forgotten password")
            LogUtil.Info("=".PadRight(40, "="))
            Close()
        End Using
    End Sub
#End Region
#Region "Subroutines"
    Private Sub InitialiseLoginForm()
        currentUser = Nothing
        lblInitMessage.Location = Panel1.Location
        lblInitMessage.Visible = True
        Panel1.Visible = False
        'Application title
        If _companyName <> "" Then
            ApplicationTitle.Text = _companyName
        Else
            'If the application title is missing, use the application name, without the extension
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        'Copyright info
        Copyright.Text = My.Application.Info.Copyright
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)
        TopMost = True
        ' put the current Windows login name in the username box
        '
        UsernameTextBox.Text = wiName(wiName.GetUpperBound(0))
        PasswordTextBox.Text = ""
        PasswordTextBox.Select()
    End Sub
    Public Function InitialiseApplication() As Boolean
        Dim rtnVal As Boolean = True
        Dim isVersionChange As Boolean = False
        Dim oldVersion As String = My.Settings.Version

        ' Preserve previous version user application settings
        If oldVersion <> Version.Text Then
            isVersionChange = True
            My.Settings.Upgrade()
        End If
        My.Settings.Version = Version.Text
        My.Settings.Save()

        Try
            GlobalSettings.LoadGlobalSettings()
            Try
                SetFolderNames()
                CreateMissingFolders()
                LogUtil.LogFolder = sLogFolder
                LogUtil.StartLogging(My.Settings.netwyrksConnectionString)
                If isVersionChange Then
                    LogUtil.Info("Version change " & oldVersion & " >> " & My.Settings.Version)
                    LogUtil.Info("Upgrading settings")
                End If

                'Dim fontFile As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "fonts\FELIXTI.TTF")
                'If Not My.Computer.FileSystem.FileExists(fontFile) Then
                '    MsgBox("Titling font missing. Please install FELIXTI.TTF", MsgBoxStyle.Information, "Missing File")
                'End If
            Catch ex As Exception
                MsgBox("Error initialising the application:" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Initialisation Error")
                rtnVal = False
            End Try
        Catch ex1 As SqlException
            MsgBox(ex1.Message & vbCrLf & vbCrLf & "Contact support to:-" & vbCrLf & "  Check that the application has been activated" & vbCrLf & "  Check that the database is available" & vbCrLf & vbCrLf & "*** SERS will now close ***", MsgBoxStyle.Critical, "SERS Database Error")
            rtnVal = False
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & "Cannot start the application. Contact support." & vbCrLf & "*** SERS will now close ***", MsgBoxStyle.Critical, "SERS Initialisation Error")
            rtnVal = False
        End Try
        Return rtnVal
    End Function

    Private Sub EnterApplication()
        LogUtil.Info("Entering the application", MyBase.Name)
        currentUser = UserBuilder.AUser.startingWith(AuthorisationUtil.getCurrentUserid).build
        AuditUtil.AddAudit("", AuditUtil.RecordType.User, currentUser.UserId, AuditUtil.AuditableAction.login, My.Application.Info.Version.ToString, "")
        'For Citrix: allocate individual temporary folders
        If GlobalSettings.getBooleanSetting(GlobalSettings.PERSONAL_FOLDERS) Then
            SetPersonalisedFolderNames(Nothing, MyBase.Name)
        End If
        ' housekeeping
        If My.Settings.AutoTidy Then
            ClearCache(My.Settings.RetentionPeriod, CacheType.All)
        End If
        Hide()
        If My.Settings.ShowRemindersAtLogin Then
            Using _remind As New FrmReminderList
                Dim i As Integer = _remind.loadReminders
                If i > 0 Then
                    _remind.ShowDialog()
                End If
            End Using
        End If
        Using _menu As New frmMain
            _menu.ShowDialog()
        End Using
        '
        '=========== Logout ===========
        '
        ' Remove all Temporary files on logout
        ClearCache(0, CacheType.Temp)
        AuditUtil.addAudit(AuditUtil.RecordType.User, currentUser.userId, AuditUtil.AuditableAction.logout)
        ' On return from the menu, close the application
        LogUtil.Info(My.Application.Info.Title & " closed at " & Format(Now, "dd/MM/yyyy HH:mm:ss"))
        LogUtil.Info("=".PadRight(40, "="))
        LogUtil.StopLogging()
        Close()
    End Sub

#End Region

End Class
