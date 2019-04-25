Imports System.ComponentModel

'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Public Class frmMenu

#Region "Private variables"
    Private Const GAP As Integer = 12
    Private Const BORDERS As Integer = 18
    Private Const IMAGE_WIDTH As Integer = 42


#End Region
#Region "Form"

    Private Sub SERSMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closing", "MainMenu")
    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Loading", "MainMenu")
        lblCompanyName.Text = _companyName
        setUserRoles()
        Me.KeyPreview = True

        LogUtil.Debug("Loaded", "MainMenu")
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F3 Then
            ShowDiary()
        End If

        If (e.KeyCode = Keys.X AndAlso e.Modifiers = Keys.Control) Then
            LogUtil.Debug("Ctrl+X - Exit", "MainMenu")
            Me.Close()
        End If

    End Sub


#End Region
#Region "settings"
    Private Sub mnuOptions_Click(sender As Object, e As EventArgs) Handles mnuOptions.Click
        LogUtil.Debug("Options", "SERSMenu")
        Using _options As New frmOptions
            _options.ShowDialog()
        End Using
    End Sub

    Private Sub mnuChangePassword_Click(sender As Object, e As EventArgs) Handles mnuChangePassword.Click
        LogUtil.Debug("Change password", "SERSMenu")
        Dim result As DialogResult = DialogResult.Cancel
        Using _password As New frmChangePassword
            result = _password.ShowDialog()
        End Using
        If result = DialogResult.OK Then
            MsgBox("Password changed OK", MsgBoxStyle.Information, "Password")
        End If
    End Sub

    Private Sub mnuResetUserPassword_Click(sender As Object, e As EventArgs) Handles mnuResetUserPassword.Click
        LogUtil.Debug("Reset User Password", "SERSMenu")
        Using _reset As New frmResetUserPassword
            _reset.ShowDialog()
        End Using
    End Sub

    Private Sub mnuGlobalSettings_Click(sender As Object, e As EventArgs) Handles mnuGlobalSettings.Click
        LogUtil.Debug("Global settings", "SERSMenu")
        Using _settings As New frmGlobalSettings
            _settings.ShowDialog()
        End Using
    End Sub
#End Region
#Region "Menu strip"


    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        LogUtil.Debug("About", "SERSMenu")
        Using _about As New frmAbout
            _about.ShowDialog()
        End Using

    End Sub

    Private Sub mnuViewLog_Click(sender As Object, e As EventArgs) Handles mnuViewLog.Click
        LogUtil.Debug("View Log", "SERSMenu")
        Using _logViewer As New frmLogViewer
            _logViewer.ShowDialog()
        End Using

    End Sub

    Private Sub mnuUsers_Click(sender As Object, e As EventArgs) Handles mnuUsers.Click
        LogUtil.Debug("User control", "SERSMenu")
        Using _userControl As New frmUserControl
            _userControl.ShowDialog()
        End Using
    End Sub


    Private Sub mnuViewAudit_Click_1(sender As Object, e As EventArgs) Handles mnuViewAudit.Click
        LogUtil.Debug("View audit", "SERSMenu")
        Using _audit As New frmDisplayAudit
            _audit.ShowDialog()
        End Using

    End Sub

#End Region
#Region "Main menu options"




#End Region
#Region "Email Submenu options"

#End Region
#Region "Operators Submenu options"



#End Region
#Region "Shops Submenu options"

#End Region
#Region "Ref Submenu options"


#End Region
#Region "Customer Submenu options"

#End Region
#Region "Subroutines"
    Private Sub showdiary()

    End Sub

#End Region
#Region "Images submenu options"


#End Region
#Region "Housekeeping"

    Private Sub mnuAutoTidy_Click(sender As Object, e As EventArgs) Handles mnuAutoTidy.Click
        LogUtil.Debug("Auto tidy", "SERSMenu")
        My.Settings.AutoTidy = mnuAutoTidy.Checked
        My.Settings.Save()
    End Sub
#End Region



    Private Sub picClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ImagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuImageTidy.Click
        ClearCache(My.Settings.RetentionPeriod, CacheType.Image)
    End Sub

    Private Sub AttachmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuAttachmentsTidy.Click
        ClearCache(My.Settings.RetentionPeriod, CacheType.Attachment)
    End Sub

    Private Sub TempFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuTempFilesTidy.Click
        ClearCache(My.Settings.RetentionPeriod, CacheType.Temp)
    End Sub

    Private Sub AllFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuAllFilesTidy.Click
        ClearCache(My.Settings.RetentionPeriod, CacheType.All)
    End Sub

    Private Sub ImagesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles mnuImagesClear.Click
        ClearCache(0, CacheType.Image)
    End Sub

    Private Sub AttachmentsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles mnuAttachmentsClear.Click
        ClearCache(0, CacheType.Attachment)
    End Sub

    Private Sub TempFilesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles mnuTempFilesClear.Click
        ClearCache(0, CacheType.Temp)
    End Sub

    Private Sub AllFilesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles mnuAllFilesClear.Click
        ClearCache(0, CacheType.All)
    End Sub

    Private Sub mnuClearAllFiles_Click(sender As Object, e As EventArgs) Handles mnuClearAllFiles.Click
        ClearCache(0, CacheType.All)
    End Sub

    Private Sub mnuShopListsTidy_Click(sender As Object, e As EventArgs) Handles mnuShopListsTidy.Click
        TidyFiles(sCacheFolder, SHOP_LIST_CACHE_FILE & "*2*.txt", My.Settings.RetentionPeriod, False)
    End Sub



    Private Sub mnuReportFolder_Click(sender As Object, e As EventArgs) Handles mnuReportFolder.Click
        LogUtil.Debug("Open report folder", "SERSmenu")
        Process.Start("explorer.exe", "/root, " & sReportFolder)
    End Sub


    Private Sub InstallationTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstallationTestToolStripMenuItem.Click
        LogUtil.Debug("Installation test", "SERSMenu")
        Using _tst As New frmInstallationTest
            _tst.ShowDialog()
        End Using
    End Sub


    Private Sub mnuSendLog_Click(sender As Object, e As EventArgs) Handles mnuSendLog.Click
        LogUtil.Debug("Send log", "SERSMenu")
        If LogUtil.SendLogFileToSupport() Then
            MsgBox("Log sent OK", , "Email")
        Else
            MsgBox("Log send FAILED", , "Email")
        End If
    End Sub

    Private Sub mnuPrinterSettings_Click(sender As Object, e As EventArgs) Handles mnuPrinterSettings.Click
        LogUtil.Debug("Printer setup", "SERSMenu")
        Try
            Using _pageSetup As PageSetupDialog = prtUtil.PageSetup
                _pageSetup.ShowDialog()
            End Using
        Catch ex As Exception
            LogUtil.Exception("Unexpected exception setting printer settings", ex, "mnuPrinterSettings_Click")
        End Try

    End Sub

#Region "Callback reminder background worker"

#End Region
    ''' <summary>
    ''' Developer test function
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picDev_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCustomers_Click(sender As Object, e As EventArgs) Handles btnCustomers.Click
        Using _customerForm As New frmCustomerMaint
            _customerForm.ShowDialog()
        End Using
    End Sub

    Private Sub btnExclusions_Click(sender As Object, e As EventArgs) Handles btnExclusions.Click
        Using _jobForm As New frmJob
            _jobForm.ShowDialog()
        End Using
    End Sub

    Private Sub mnuLogout_Click(sender As Object, e As EventArgs) Handles mnuLogout.Click
        Me.Close()
    End Sub

    Private Sub btnIncidents_Click(sender As Object, e As EventArgs) Handles btnIncidents.Click
        Using _suppForm As New frmSupplier
            _suppForm.ShowDialog()
        End Using
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        Using _prodForm As New frmProduct
            _prodForm.ShowDialog()
        End Using
    End Sub
End Class