' Hindleware
' Copyright (c) 2022-24 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

''' <summary>
''' Allows user to set personal preferences
''' </summary>
''' <remarks></remarks>
Public Class FrmOptions
    Private ReadOnly encryptedPwd As String = ""
    Private ReadOnly fieldmarkers(,) As String
    Private isLoading As Boolean = True
    Private Const FORM_NAME As String = "preferences"
    Private zoomValue As Decimal
#Region "Form event handlers"
    ''' <summary>
    ''' Close form without saving changes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub
    ''' <summary>
    ''' Load current settings into the forms
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CeOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isLoading = True
        lblFormName.Text = FORM_NAME
        LoadGeneralOptions()
        LoadInvoiceOptions()
        LoadFolderOptions()
        SpellCheckUtil.EnableSpellChecking(New System.Windows.Forms.Control() {txtSpellTest})
        LoadSpellcheckOptions()
        LoadLoggingOptions()
        SetTooltips()
        isLoading = False
    End Sub
    ''' <summary>
    ''' Validate and save settings
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim bValid As Boolean = True
        bValid = ValidateFolders(bValid)
        bValid = ValidateGeneralOptions(bValid)
        If bValid Then
            SaveGeneralOptions()
            SaveInvoiceOptions()
            SaveFolderOptions()
            SaveSpellcheckOptions()
            SaveLoggingOptions
            My.Settings.Save()
            Close()
        Else
            MsgBox("Some values are invalid", MsgBoxStyle.Exclamation, "Option errors")
        End If
    End Sub
    Private Sub TrackBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        zoomValue = TrackBar1.Value / 10
        TxtZoomValue.Text = CStr(zoomValue)
    End Sub
    ''' <summary>
    ''' Add tooltips to folder path fields
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetTooltips()
        ToolTip1.SetToolTip(txtTempFolder, txtTempFolder.Text.Replace("<application path>", sApplicationPath))
        ToolTip1.SetToolTip(txtLogPath, txtLogPath.Text.Replace("<application path>", sApplicationPath))
    End Sub
    ''' <summary>
    ''' Display standard colour dialog to select colours for various colour settings
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                Handles lblCaseErrorColor.Click, lblMistakeColor.Click,
        lblIgnoreColor.Click
        Dim lbl As Label = CType(sender, Label)
        Using _colorDialog As New ColorDialog
            _colorDialog.AllowFullOpen = True
            _colorDialog.CustomColors = New Integer() {RGB(lbl.BackColor.R, lbl.BackColor.G, lbl.BackColor.B)}
            _colorDialog.Color = lbl.BackColor
            If _colorDialog.ShowDialog() = DialogResult.OK Then
                lbl.BackColor = _colorDialog.Color
            End If
        End Using
    End Sub
    ''' <summary>
    ''' Insert text when popup menu is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MInsert_Click(ByVal sender As System.Object, ByVal e As ToolStripItemClickedEventArgs) Handles mFieldSelect.ItemClicked
        If e.ClickedItem.Name.Length > 0 Then
            Try
                Dim oSender As ContextMenuStrip = CType(sender, ContextMenuStrip)
                Dim oControl As TextBox = CType(oSender.SourceControl, TextBox)
                With oControl
                    Dim start As Integer = .SelectionStart
                    Dim sText As String = .Text()
                    .Text = sText.Substring(0, start) & "{" & e.ClickedItem.Name & "}" & sText.Substring(start)
                    .SelectionStart = start + e.ClickedItem.Name.Length + 2
                End With
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnTest.Click
        Using _test As New FrmInstallationTest
            _test.ShowDialog()
        End Using
    End Sub
#End Region
#Region "General"

    ''' <summary>
    ''' Load values into General tab form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadGeneralOptions()
        chkShowDiaryBody.Checked = My.Settings.ShowDiaryBody
        chkShowCustomer.Checked = My.Settings.ShowCustomer
        chkShowSupplier.Checked = My.Settings.ShowSupplier
        chkShowJob.Checked = My.Settings.ShowJob
        cbDebug.Checked = My.Settings.DebugOn
        nudRetention.Value = My.Settings.RetentionPeriod
        chkAutoTidy.Checked = My.Settings.AutoTidy
        ChkCheckCallbacks.Checked = My.Settings.checkCallBack
        ChkShowDiary.Checked = My.Settings.ShowRemindersAtLogin
        chkShowAllReminders.Checked = My.Settings.ShowAllReminders
        ChkShowProduct.Checked = My.Settings.ShowProduct
        ChkShowTask.Checked = My.Settings.ShowTask
        NudAlertDuration.Value = My.Settings.alertDuration
        NudAlertNotice.Value = My.Settings.alertNotice
        ChkShowClosed.Checked = My.Settings.ShowCompletedDiaryEntries
    End Sub

    ''' <summary>
    ''' Save values from General tab form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveGeneralOptions()
        My.Settings.ShowDiaryBody = chkShowDiaryBody.Checked
        My.Settings.ShowCustomer = chkShowCustomer.Checked
        My.Settings.ShowSupplier = chkShowSupplier.Checked
        My.Settings.ShowJob = chkShowJob.Checked
        My.Settings.RetentionPeriod = nudRetention.Value
        My.Settings.AutoTidy = chkAutoTidy.Checked
        My.Settings.DebugOn = cbDebug.Checked
        My.Settings.checkCallBack = ChkCheckCallbacks.Checked
        My.Settings.alertNotice = NudAlertNotice.Value
        My.Settings.alertDuration = NudAlertDuration.Value
        My.Settings.ShowRemindersAtLogin = ChkShowDiary.Checked
        My.Settings.ShowAllReminders = chkShowAllReminders.Checked
        My.Settings.ShowTask = ChkShowTask.Checked
        My.Settings.ShowProduct = ChkShowProduct.Checked
        My.Settings.ShowCompletedDiaryEntries = ChkShowClosed.Checked
    End Sub

    ''' <summary>
    ''' Validate values on General tab form
    ''' </summary>
    ''' <param name="bValid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ValidateGeneralOptions(ByVal bValid As Boolean) As Boolean
        Return bValid
    End Function

    ''' <summary>
    ''' Display standard font dialog to select font for Notes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnNotesFont_Click(ByVal sender As Object, ByVal e As EventArgs)
        Using _fontDialog As New FontDialog
            With _fontDialog
                .ShowApply = False
                .ShowEffects = True
                .FontMustExist = True
            End With
        End Using
    End Sub
#End Region
#Region "Invoice"
    Private Sub LoadInvoiceOptions()
        txtInvHdrSample.Font = My.Settings.InvHdrFont
        txtInvBodySample.Font = My.Settings.InvBodyLargeFont
        txtInvFtrSample.Font = My.Settings.InvFtrFont
        txtInvBodyLargeSample.Font = My.Settings.InvBodyLargeFont
        txtInvCompNameSample.Font = My.Settings.InvCmpyNameFont
        txtInvCompAddrSample.Font = My.Settings.InvCmpyAddrFont
    End Sub
    Private Sub BtnFont1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFont1.Click, btnFont2.Click, btnFont3.Click, btnFont4.Click, btnFont5.Click, btnFont6.Click
        Dim _btn As Button = CType(sender, Button)
        Dim _sample As New TextBox
        Select Case _btn.Name
            Case "btnFont1"
                _sample = txtInvCompNameSample
            Case "btnFont2"
                _sample = txtInvCompAddrSample
            Case "btnFont3"
                _sample = txtInvHdrSample
            Case "btnFont4"
                _sample = txtInvBodyLargeSample
            Case "btnFont5"
                _sample = txtInvBodySample
            Case "btnFont6"
                _sample = txtInvFtrSample
        End Select
        FontDialog1.Font = _sample.Font
        FontDialog1.ShowDialog()
        _sample.Font = FontDialog1.Font
    End Sub
    Private Sub SaveInvoiceOptions()
        My.Settings.InvHdrFont = txtInvHdrSample.Font
        My.Settings.InvBodyLargeFont = txtInvBodySample.Font
        My.Settings.InvFtrFont = txtInvFtrSample.Font
        My.Settings.InvBodyLargeFont = txtInvBodyLargeSample.Font
        My.Settings.InvCmpyNameFont = txtInvCompNameSample.Font
        My.Settings.InvCmpyAddrFont = txtInvCompAddrSample.Font
    End Sub
#End Region
#Region "Folders"

    ''' <summary>
    ''' Load values into Folders tab form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadFolderOptions()
        txtTempFolder.Text = My.Settings.TempFolder
        txtLogPath.Text = My.Settings.LogFolder
        txtReportFolder.Text = My.Settings.ReportFolder
        txtCacheFolder.Text = My.Settings.CacheFolder
        TxtImageFolder.Text = My.Settings.ImageFolder
        TxtInvoiceFolder.Text = My.Settings.InvoiceFolder
        TxtBackupFolder.Text = My.Settings.BackupFolder
    End Sub

    ''' <summary>
    ''' Save values from Folder tab form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveFolderOptions()
        My.Settings.TempFolder = txtTempFolder.Text
        My.Settings.LogFolder = txtLogPath.Text
        My.Settings.ReportFolder = txtReportFolder.Text
        My.Settings.CacheFolder = txtCacheFolder.Text
        My.Settings.ImageFolder = TxtImageFolder.Text
        My.Settings.InvoiceFolder = TxtInvoiceFolder.Text
        My.Settings.BackupFolder = TxtBackupFolder.Text

        SetFolderNames()
    End Sub

    ''' <summary>
    ''' Validate values on Folders tab form
    ''' </summary>
    ''' <param name="bValid"></param>
    ''' <returns></returns>
    ''' <remarks>Paths must exist on the computer</remarks>
    Private Function ValidateFolders(ByVal bValid As Boolean) As Boolean
        lblTempFolder.ForeColor = Color.Black
        lblLogFolder.ForeColor = Color.Black
        lblReports.ForeColor = Color.Black
        If Not IsValidPathName(txtReportFolder.Text) Then
            lblReports.ForeColor = Color.Red
            bValid = False
        End If
        If Not IsValidPathName(txtTempFolder.Text) Then
            lblTempFolder.ForeColor = Color.Red
            bValid = False
        End If
        If Not IsValidPathName(txtLogPath.Text) Then
            lblLogFolder.ForeColor = Color.Red
            bValid = False
        End If
        Return bValid
    End Function

    ''' <summary>
    ''' Check that the path exists. Give option to create a missing path.
    ''' </summary>
    ''' <param name="sPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidPathName(ByVal sPath As String) As Boolean
        Dim rtnval As Boolean = True
        Dim fullPath As String = sPath.Replace("<application path>", sApplicationPath)
        If String.IsNullOrEmpty(sPath) Then
            rtnval = False
        Else
            If My.Computer.FileSystem.DirectoryExists(fullPath) = False Then
                If MsgBox(fullPath & " does not exist." & vbCrLf & "OK to create?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Path missing") = MsgBoxResult.Yes Then
                    My.Computer.FileSystem.CreateDirectory(fullPath)
                Else
                    rtnval = False
                End If
            End If
        End If
        Return rtnval
    End Function

    ''' <summary>
    ''' Check that the file exists
    ''' </summary>
    ''' <param name="sPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidFileName(ByVal sPath As String) As Boolean
        Return My.Computer.FileSystem.FileExists(sPath.Replace("<application path>", sApplicationPath))
    End Function

    ''' <summary>
    ''' Save the path values and create any missing folders
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCreateFolders_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCreateFolders.Click
        LogUtil.Info("Creating any missing folders", MyBase.Name)
        SaveFolderOptions()
        CreateMissingFolders()
        txtStatus.Text = "Missing folders created"
    End Sub
#End Region
#Region "SpellCheck"

    ''' <summary>
    ''' Load values into the Spell Check tab form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadSpellcheckOptions()
        cbSplchkEnabled.Checked = My.Settings.splchkEnabled
        cbSplchkAdd.Checked = My.Settings.splchkAdd
        cbSplchkIgnore.Checked = My.Settings.splchkIgnore
        cbSplChkNumber.Checked = My.Settings.splchkNumber
        cbSplchkRemove.Checked = My.Settings.splchkRemove
        cbSplChkUpper.Checked = My.Settings.splchkUpper
        cbSplchkMistakes.Checked = My.Settings.splchkShowMistakes
        cbSplchkShowIgnore.Checked = My.Settings.splchkShowIgnore
        cbSplchkShowCase.Checked = My.Settings.splchkShowCaseError
        lblMistakeColor.BackColor = My.Settings.splchkMistakeColor
        lblIgnoreColor.BackColor = My.Settings.splchkIgnoreColor
        lblCaseErrorColor.BackColor = My.Settings.splchkCaseErrorColor
    End Sub

    ''' <summary>
    ''' Save values from the spell Check tab form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveSpellcheckOptions()
        My.Settings.splchkEnabled = cbSplchkEnabled.Checked
        My.Settings.splchkAdd = cbSplchkAdd.Checked
        My.Settings.splchkIgnore = cbSplchkIgnore.Checked
        My.Settings.splchkNumber = cbSplChkNumber.Checked
        My.Settings.splchkRemove = cbSplchkRemove.Checked
        My.Settings.splchkUpper = cbSplChkUpper.Checked
        My.Settings.splchkShowMistakes = cbSplchkMistakes.Checked
        My.Settings.splchkShowIgnore = cbSplchkShowIgnore.Checked
        My.Settings.splchkShowCaseError = cbSplchkShowCase.Checked
        My.Settings.splchkCaseErrorColor = lblCaseErrorColor.BackColor
        My.Settings.splchkMistakeColor = lblMistakeColor.BackColor
        My.Settings.splchkIgnoreColor = lblIgnoreColor.BackColor
    End Sub
    Private Sub SaveLoggingOptions()
        My.Settings.logZoomOn = ChkZoomOn.Checked
        My.Settings.logZoomValue = TrackBar1.Value / 10
    End Sub
    Private Sub LoadLoggingOptions()
        ChkZoomOn.Checked = My.Settings.logZoomOn
        TrackBar1.Value = My.Settings.logZoomValue * 10
    End Sub
    ''' <summary>
    ''' If the option to do Spell Checking is changed, save the setting and spellcheck the test field
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CbSplchkEnabled_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbSplchkEnabled.CheckedChanged
        My.Settings.splchkEnabled = cbSplchkEnabled.Checked
        SpellCheckUtil.EnableSpellChecking(New System.Windows.Forms.Control() {txtSpellTest})
    End Sub
#End Region
#Region "Email"
    Private Function SelectFont(ByVal currentFont As Font) As Font
        Dim newFont As Font = currentFont
        Using _fontDialog As New FontDialog
            With _fontDialog
                .Font = currentFont
                .ShowApply = False
                .ShowEffects = True
                .FontMustExist = True
                If .ShowDialog() = DialogResult.OK Then
                    newFont = .Font
                End If
            End With
        End Using
        Return newFont
    End Function

#End Region
End Class
