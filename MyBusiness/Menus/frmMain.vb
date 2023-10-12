' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Imports HindlewareLib.Domain.Objects
Imports HindlewareLib.Logging
Imports HindlewareLib.NetwyrksErrorCodes
Imports HindlewareLib.Popup
Imports i00SpellCheck
Public Class FrmMain
#Region "constants"
    Private Const CALLBACK_MESSAGE As String = vbCrLf & "Callback requested for "
#End Region
#Region "variables"
    Private isLoading As Boolean = False
    Private ReadOnly dayOfWeek As Integer = Today.DayOfWeek
    Private dateSectionHeads As String() = New String() {"Overdue", "Today", "Tomorrow", "This Week", "Next Week", "Future"}
    Private dateSectionEnds As Date() = New DateTime() {Today, DateAdd(DateInterval.Day, 1, Today), DateAdd(DateInterval.Day, 2, Today), DateAdd(DateInterval.Day, 8 - dayOfWeek, Today), DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Day, 14 - dayOfWeek, Today)), Date.MaxValue}
    Private dateSection As Integer = 0
    Private ReadOnly isShowAll As Boolean = False
#End Region
#Region "form handlers"
    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        MenuStrip1.CanOverflow = True
        Text = GlobalSettings.GetStringSetting(GlobalSettings.COMPANY_NAME)
        If GetFormPos(Me, My.Settings.MainFormPos) Then
            SplitContainer1.SplitterDistance = My.Settings.MainSplitterDist1
            SplitContainer2.SplitterDistance = My.Settings.MainSplitterDist2
            SplitContainer3.SplitterDistance = My.Settings.MainSplitterDist3
            spCustomer.SplitterDistance = My.Settings.MainSplitterDist4
            spSupplier.SplitterDistance = My.Settings.MainSplitterDist5
        End If
        isLoading = True
        InitialiseData()
        FillCustomerTable(-1)
        FillSupplierTable(-1)
        FillJobTable(-1, mnuShowAllJobs.Checked)
        FillDiaryTable()
        If My.Settings.checkCallBack Then
            StartReminderCheck()
            TimerCallBackReminders.Interval = My.Settings.alertNotice * 60000
            TimerCallBackReminders.Enabled = True
        End If
        EnableControlExtensions()
        isLoading = False
    End Sub
    Private Sub DgvCust_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DgvCust.SelectionChanged
        spCustomer.Panel2Collapsed = True
        If Not isLoading Then
            If DgvCust.SelectedRows.Count = 1 Then
                Dim cRow As DataGridViewRow = DgvCust.SelectedRows(0)
                Dim _selCustId As Integer = cRow.Cells(custId.Name).Value
                If _selCustId > 0 Then
                    Dim _selectedCust As Customer = CustomerBuilder.ACustomer.StartingWith(_selCustId).Build
                    FillJobTable(_selectedCust.CustomerId, MnuShowAllJobs.Checked)
                    txtCustAddress.Text = _selectedCust.CustName & vbCrLf & MultilineAddressString(_selectedCust.Address)
                    If My.Settings.ShowCustomer Then spCustomer.Panel2Collapsed = False
                    FillJobTable(_selCustId, MnuShowAllJobs.Checked)
                Else
                    FillJobTable(-1, MnuShowAllJobs.Checked)
                End If
            Else
                FillJobTable(-1, MnuShowAllJobs.Checked)
            End If
        End If
    End Sub
    Private Sub DgvDiary_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgvDiary.SelectionChanged
        If Not isLoading Then
            If dgvDiary.SelectedRows.Count = 1 Then
                Dim dRow As DataGridViewRow = dgvDiary.SelectedRows(0)
                Dim _diaryId As Integer = dRow.Cells(dremId.Name).Value
                Dim _reminder As Reminder = GetReminderById(_diaryId)
                rtbDiaryBody.Text = _reminder.Body
            End If
        End If
    End Sub
    Private Sub DgvDiary_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvDiary.CellDoubleClick
        If dgvDiary.SelectedRows.Count = 1 Then
            Dim dRow As DataGridViewRow = dgvDiary.SelectedRows(0)
            Dim _diaryId As Integer = dRow.Cells(dremId.Name).Value
            Dim _reminder As Reminder = GetReminderById(_diaryId)
            Using _diary As New FrmReminder
                _diary.CurrentReminder = _reminder
                _diary.ShowDialog()
            End Using
            isLoading = True
            FillDiaryTable()
            isLoading = False
        End If
    End Sub
    Private Sub DgvCust_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DgvCust.CellDoubleClick
        If DgvCust.SelectedRows.Count = 1 Then
            Dim dRow As DataGridViewRow = DgvCust.SelectedRows(0)
            Dim _custId As Integer = dRow.Cells(custId.Name).Value
            Using _custForm As New FrmCustomerMaint
                _custForm.CustomerId = _custId
                _custForm.ShowDialog()
            End Using
            FillCustomerTable(_custId)
            FillDiaryTable()
        End If
    End Sub
    Private Sub DgvSupp_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DgvSupp.CellDoubleClick
        If DgvSupp.SelectedRows.Count = 1 Then
            Dim dRow As DataGridViewRow = DgvSupp.SelectedRows(0)
            Dim _suppId As Integer = dRow.Cells(suppId.Name).Value
            Using _suppForm As New FrmSupplier
                _suppForm.SupplierId = _suppId
                _suppForm.ShowDialog()
            End Using
            isLoading = True
            FillSupplierTable(_suppId)
            isLoading = False
        End If
    End Sub
    Private Sub DgvJobs_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvJobs.CellDoubleClick
        If dgvJobs.SelectedRows.Count = 1 Then
            Dim dRow As DataGridViewRow = dgvJobs.SelectedRows(0)
            Dim _jobId As Integer = dRow.Cells(jobId.Name).Value
            Using _jobForm As New FrmJobMaint
                _jobForm.TheJob = GetJobById(_jobId)
                _jobForm.CustomerId = _jobForm.TheJob.JobCustomerId
                _jobForm.ShowDialog()
            End Using
            isLoading = True
            DgvCust.ClearSelection()
            FillJobTable(-1, MnuShowAllJobs.Checked)
            FillDiaryTable()
            isLoading = False
        End If
    End Sub
    Private Sub DgvSupp_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DgvSupp.SelectionChanged
        spSupplier.Panel2Collapsed = True
        If Not isLoading Then
            If DgvSupp.SelectedRows.Count = 1 Then
                Dim sRow As DataGridViewRow = DgvSupp.SelectedRows(0)
                Dim _selSuppId As Integer = sRow.Cells(suppId.Name).Value
                If _selSuppId > 0 Then
                    Dim _selectedSupp As Supplier = SupplierBuilder.ASupplier.StartingWith(_selSuppId).Build
                    txtSuppAddress.Text = _selectedSupp.SupplierName & vbCrLf & MultilineAddressString(_selectedSupp.SupplierAddress)
                    If My.Settings.ShowSupplier Then spSupplier.Panel2Collapsed = False
                End If
            End If
        End If
    End Sub
    Private Sub NewCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAddCustomer.Click
        Using _custForm As New FrmCustomerMaint
            _custForm.ShowDialog()
            isLoading = True
            FillCustomerTable(_custForm.CustomerId)
            isLoading = False
        End Using
    End Sub
    Private Sub NewSupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAddSupplier.Click
        Using _suppForm As New FrmSupplier
            _suppForm.ShowDialog()
            isLoading = True
            FillSupplierTable(_suppForm.SupplierId)
            isLoading = False
        End Using

    End Sub
    Private Sub NewDiaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAddDiary.Click
        Using _diary As New FrmReminder
            _diary.CurrentReminder = Nothing
            _diary.ShowDialog()
        End Using
        isLoading = True
        FillDiaryTable()
        isLoading = False
    End Sub
    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuClose.Click
        Close()
    End Sub
    Private Sub PreferencesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuPreferences.Click
        Using _settings As New frmOptions
            _settings.ShowDialog()
        End Using
        If My.Settings.ShowDiaryBody Then
            spDiary.Panel2Collapsed = False
        Else
            spDiary.Panel2Collapsed = True
        End If
    End Sub
    Private Sub GlobalSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuGlobalSettings.Click
        Using _global As New FrmGlobalSettings
            _global.ShowDialog()
        End Using
    End Sub
    Private Sub UserControlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserControlToolStripMenuItem.Click
        Using _userControl As New FrmUserControl
            _userControl.ShowDialog()
        End Using
    End Sub
    Private Sub MnuLogView_Click(sender As Object, e As EventArgs) Handles MnuLogView.Click
        Using _log As New FrmLogViewer
            _log.ShowDialog()
        End Using
    End Sub
    Private Sub MnuBackup_Click(sender As Object, e As EventArgs) Handles MnuBackup.Click
        Using _backup As New FrmBackup
            _backup.ShowDialog()
        End Using
    End Sub
    Private Sub MnuRestore_Click(sender As Object, e As EventArgs) Handles MnuRestore.Click
        Using _restore As New FrmRestore
            _restore.ShowDialog()
        End Using
    End Sub
    Private Sub MnuChangePassword_Click(sender As Object, e As EventArgs) Handles MnuChangePassword.Click
        Using _pwdChange As New FrmChangePassword
            _pwdChange.ForceChange = False
            _pwdChange.ShowDialog()
        End Using
    End Sub
    Private Sub ChkCallBackReminders_Click(sender As Object, e As EventArgs) Handles MnuCheckCallBackReminders.Click
        StartReminderCheck()
    End Sub
    Private Sub TimerCallBackReminders_Tick(sender As Object, e As EventArgs) Handles TimerCallBackReminders.Tick
        LogUtil.Info("Reminder Timer tick", MyBase.Name)
        StartReminderCheck()
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Using _about As New FrmAbout
            _about.ShowDialog()
        End Using
    End Sub
    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.MainFormPos = SetFormPos(Me)
        My.Settings.MainSplitterDist1 = SplitContainer1.SplitterDistance
        My.Settings.MainSplitterDist2 = SplitContainer2.SplitterDistance
        My.Settings.MainSplitterDist3 = SplitContainer3.SplitterDistance
        My.Settings.MainSplitterDist4 = spCustomer.SplitterDistance
        My.Settings.MainSplitterDist5 = spSupplier.SplitterDistance
        My.Settings.Save()
    End Sub
    Private Sub MnuShowAudit_Click(sender As Object, e As EventArgs) Handles MnuShowAudit.Click
        Using _audit As New FrmDisplayAudit
            _audit.ShowDialog()
        End Using
    End Sub
    Private Sub MnuTidyFiles_Click(sender As Object, e As EventArgs) Handles MnuTidyFiles.Click
        Dim logFolder As String = sLogFolder
        Dim retentionPeriod As Integer = My.Settings.RetentionPeriod
        TidyFiles(logFolder, "*.*", retentionPeriod)
        MsgBox("Tidy complete", MsgBoxStyle.Information, "Housekeeping")
    End Sub
    Private Sub MnuTemplateFromJob_Click(sender As Object, e As EventArgs) Handles MnuTemplateFromJob.Click
        If dgvJobs.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = dgvJobs.SelectedRows(0)
            Dim _job As Job = GetJobById(oRow.Cells(jobId.Name).Value)
            Dim _jobproducts As List(Of JobProduct) = GetJobProductByJob(_job)
            Dim _jobtasks As List(Of JobTask) = GetJobTasksByJob(_job.JobId)
            Dim _template As Template = TemplateBuilder.ATemplate.StartingWithNothing _
                                                        .WithTemplateName(_job.JobName) _
                                                        .WithTemplateDescription(_job.JobDescription) _
                                                        .Build
            Dim _templateId As Integer = InsertTemplate(_template)
            If _templateId > 0 Then
                For Each _jobproduct As JobProduct In _jobproducts
                    Dim _templateproduct As TemplateProduct = TemplateProductBuilder.ATemplateProduct.StartingWith(_jobproduct) _
                                                                                                        .WithTemplateId(_templateId) _
                                                                                                        .Build
                    Dim _tmplProdId As Integer = InsertTemplateProduct(_templateproduct)
                Next
                For Each _task As JobTask In _jobtasks
                    Dim _templatetask As TemplateTask = TemplateTaskBuilder.ATemplateTask.StartingWith(_task) _
                                                                                            .WithTemplateId(_templateId) _
                                                                                            .Build
                    Dim _tmplTaskId As Integer = InsertTemplatetask(_templatetask)
                Next
            End If
            Using _templates As New FrmJobTemplates
                _templates.TemplateId = _templateId
                _templates.ShowDialog()
            End Using
        Else
            '   ShowStatus(lblstatus, "No job selected")
        End If
    End Sub
    Private Sub MnuMaintainTemplates_Click(sender As Object, e As EventArgs) Handles MnuMaintainTemplates.Click
        Using _templates As New FrmJobTemplates
            _templates.ShowDialog()
        End Using
    End Sub
    Private Sub MnuAddJob_Click(sender As Object, e As EventArgs) Handles MnuAddJob.Click
        Using _jobForm As New FrmJobMaint
            _jobForm.TheJob = Nothing
            _jobForm.CustomerId = -1
            _jobForm.ShowDialog()
        End Using
        isLoading = True
        FillJobTable(-1, MnuShowAllJobs.Checked)
        isLoading = False
    End Sub
    Private Sub MnuShowAllJobs_Click(sender As Object, e As EventArgs) Handles MnuShowAllJobs.Click
        Dim _selCustId As Integer = -1
        If DgvCust.SelectedRows.Count = 1 Then
            _selCustId = DgvCust.SelectedRows(0).Cells(custId.Name).Value
        End If
        FillJobTable(_selCustId, MnuShowAllJobs.Checked)
    End Sub
    Private Sub MnuJobFromTemplate_Click(sender As Object, e As EventArgs) Handles MnuJobFromTemplate.Click
        LogUtil.Info("Job from template", MyBase.Name)
        Dim _selectedTemplate As Template = SelectATemplate()

        If _selectedTemplate IsNot Nothing Then
            LogUtil.Info("Selected template : " & _selectedTemplate.ToString, MyBase.Name)
            CreateJobFromTemplate(_selectedTemplate)
            isLoading = True
            FillJobTable(-1, MnuShowAllJobs.Checked)
            isLoading = False
        End If
    End Sub
    Private Sub DgvCust_MouseDown(sender As Object, e As MouseEventArgs) Handles DgvCust.MouseDown
        If e.Button = MouseButtons.Right Then
            DgvCust.ClearSelection()
        End If
    End Sub
    Private Sub DgvSupp_MouseDown(sender As Object, e As MouseEventArgs) Handles DgvSupp.MouseDown
        If e.Button = MouseButtons.Right Then
            DgvSupp.ClearSelection()
        End If
    End Sub

#End Region
#Region "subroutines"
    Private Sub FillCustomerTable(ByVal pCustId As Integer)
        isLoading = True
        DgvCust.Rows.Clear()
        For Each oCust As Customer In GetCustomers()
            Dim tRow As DataGridViewRow = DgvCust.Rows(DgvCust.Rows.Add)
            tRow.Cells(custId.Name).Value = oCust.CustomerId
            tRow.Cells(custName.Name).Value = oCust.CustName
            tRow.Cells(custPhone.Name).Value = oCust.Phone
            tRow.Cells(custemail.Name).Value = oCust.Email
        Next
        spCustomer.Panel2Collapsed = True
        DgvCust.ClearSelection()
        isLoading = False
        If pCustId > 0 Then
            FindCustomerInTable(pCustId)
        End If
    End Sub
    Private Sub FindCustomerInTable(ByVal pCustId As Integer)
        For Each oRow As DataGridViewRow In DgvCust.Rows
            If oRow.Cells(custId.Name).Value = pCustId Then
                oRow.Selected = True
                Exit For
            End If
        Next
    End Sub
    Private Sub FillSupplierTable(ByVal pSuppId As Integer)
        isLoading = True
        DgvSupp.Rows.Clear()
        For Each oSupp As Supplier In GetSuppliers()
            Dim tRow As DataGridViewRow = DgvSupp.Rows(DgvSupp.Rows.Add)
            tRow.Cells(suppId.Name).Value = oSupp.SupplierId
            tRow.Cells(suppName.Name).Value = oSupp.SupplierName
            tRow.Cells(suppPhone.Name).Value = oSupp.SupplierPhone
            tRow.Cells(suppEmail.Name).Value = oSupp.SupplierEmail
            tRow.Cells(suppAmazon.Name).Value = oSupp.IsSupplierAmazon
        Next
        spSupplier.Panel2Collapsed = True
        DgvSupp.ClearSelection()
        isLoading = False
        If pSuppId > 0 Then
            FindSupplierInTable(pSuppId)
        End If
    End Sub
    Private Sub FindSupplierInTable(ByVal pSuppId As Integer)
        For Each oRow As DataGridViewRow In DgvSupp.Rows
            If oRow.Cells(suppId.Name).Value = pSuppId Then
                oRow.Selected = True
                Exit For
            End If
        Next
    End Sub
    Private Sub FillJobTable(ByVal custId As Integer, ByVal showAllJobs As Boolean)
        dgvJobs.Rows.Clear()
        Dim ojobstable As List(Of Job)
        If custId > 0 Then
            ojobstable = GetJobsForCustomer(custId)
        Else
            ojobstable = GetAllJobs()
        End If
        For Each ojob As Job In ojobstable
            Dim tRow As DataGridViewRow = dgvJobs.Rows(dgvJobs.Rows.Add)
            tRow.Visible = showAllJobs Or (ojob.JobUserId = currentUser.UserId)
            tRow.Cells(jobId.Name).Value = ojob.JobId
            tRow.Cells(jobName.Name).Value = ojob.JobName
            tRow.Cells(jobDesc.Name).Value = ojob.JobDescription.Replace(Chr(10), " ")
            tRow.Cells(jobUser.Name).Value = ojob.JobUserId
            tRow.Cells(jobAssigned.Name).Value = UserBuilder.AUser.StartingWith(ojob.JobUserId).Build.User_code
            If ojob.IsJobCompleted Then
                tRow.Cells(jobCompleted.Name).Value = "Yes"
            End If
        Next
        dgvJobs.ClearSelection()
    End Sub
    Private Sub FillDiaryTable()
        Dim oReminderList As New List(Of Reminder)
        If dayOfWeek = 6 Then
            dateSectionHeads = New String() {"Overdue", "Today", "Tomorrow", "Next Week", "Future"}
            dateSectionEnds = New DateTime() {Today, DateAdd(DateInterval.Day, 1, Today), DateAdd(DateInterval.Day, 2, Today), DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Day, 8, Today)), Date.MaxValue}
        End If
        If My.Settings.ShowDiaryBody Then
            spDiary.Panel2Collapsed = False
        Else
            spDiary.Panel2Collapsed = True
        End If
        dgvDiary.Rows.Clear()
        Try
            If isShowAll Then
                oReminderList = GetAllReminders()
            Else
                oReminderList = GetRemindersForUser(currentUser.UserId)
            End If
            If oReminderList.Count > 0 Then
                Dim isFirstRow As Boolean = True
                For Each oReminder As Reminder In oReminderList
                    Dim r As Integer = 0
                    Dim rRow As DataGridViewRow = Nothing
                    If isFirstRow Then
                        Dim oFirstRow As Reminder = oReminderList(0)
                        Dim firstRowdate As Date = oFirstRow.ReminderDate.Date
                        r = dgvDiary.Rows.Add()
                        rRow = dgvDiary.Rows(r)
                        dateSection = GetNextSection(firstRowdate, rRow)
                        isFirstRow = False
                    End If
                    Dim remId As Integer = oReminder.Diary_id
                    r = dgvDiary.Rows.Add()
                    rRow = dgvDiary.Rows(r)
                    If oReminder.ReminderDate.Date >= dateSectionEnds(dateSection).Date Then
                        dateSection = GetNextSection(oReminder.ReminderDate.Date, rRow)
                        dgvDiary.Rows.Add()
                        rRow = dgvDiary.Rows(r + 1)
                    End If
                    Dim isReminder As Boolean = oReminder.IsReminder
                    Dim isComplete As Boolean = oReminder.IsClosed
                    Dim isCallBack As Boolean = oReminder.CallBack
                    '   rRow.Cells(Me.dremUserCode.Name).Value = If(oUserList.ContainsKey(oRow.diary_user_id), oUserList(oRow.diary_user_id), "")
                    rRow.Cells(dremHeader.Name).Value = False
                    rRow.Cells(dremId.Name).Value = oReminder.Diary_id
                    rRow.Cells(dremSubject.Name).Value = oReminder.Subject
                    rRow.Cells(dremDate.Name).Value = Format(oReminder.ReminderDate, "dd/MM/yyyy")
                    rRow.Cells(dremDate.Name).Style.ForeColor = Color.Gray
                    rRow.Cells(dremCustId.Name).Value = oReminder.CustomerId
                    Dim oRemCell As DataGridViewCell = rRow.Cells(dremRem.Name)
                    oRemCell.Style.Font = New Font("Wingdings", 11)
                    oRemCell.Value = If(isReminder, Chr(185), "")
                    Dim oCompCell As DataGridViewCell = rRow.Cells(dremClosed.Name)
                    oCompCell.Style.Font = New Font("Wingdings", 11)
                    oCompCell.Value = If(isComplete, Chr(254), "")
                    Dim oCallCell As DataGridViewCell = rRow.Cells(dremCallback.Name)
                    oCallCell.Style.Font = New Font("Wingdings", 11)
                    oCallCell.Value = If(isCallBack, Chr(40), "")
                Next
            End If
        Catch ex As Exception
            LogUtil.Exception("Error loading reminders", ex, "loadReminders", GetErrorCode(SystemModule.DIARY, ErrorType.TABLE, FailedAction.ERROR_LOADING_RECORDS))
        End Try
        dgvDiary.ClearSelection()
    End Sub
#End Region
#Region "functions"
    Private Function GetNextSection(ByVal rowDate As Date, ByRef rRow As DataGridViewRow) As Integer
        Dim sectionNo As Integer = dateSectionHeads.GetUpperBound(0)
        For x = 0 To dateSectionHeads.GetUpperBound(0)
            If rowDate < dateSectionEnds(x).Date Then
                sectionNo = x
                Exit For
            End If
        Next
        rRow.Cells(dremDate.Name).Value = dateSectionHeads(sectionNo)
        rRow.Cells(dremDate.Name).Style.ForeColor = Color.Black
        rRow.Cells(dremHeader.Name).Value = True
        For Each oCell As DataGridViewCell In rRow.Cells
            oCell.Style.BackColor = Color.Silver
        Next
        Return sectionNo
    End Function
    Private Function MultilineAddressString(ByVal anAddress As Address) As String
        Dim sb As New StringBuilder
        With anAddress
            If .Address1 IsNot Nothing AndAlso .Address1.Trim.Length > 0 Then
                sb.Append(.Address1.Trim).Append(vbCrLf)
            End If
            If .Address2 IsNot Nothing AndAlso .Address2.Trim.Length > 0 Then
                sb.Append(.Address2.Trim).Append(vbCrLf)
            End If
            If .Address3 IsNot Nothing AndAlso .Address3.Trim.Length > 0 Then
                sb.Append(.Address3.Trim).Append(vbCrLf)
            End If
            If .Address4 IsNot Nothing AndAlso .Address4.Trim.Length > 0 Then
                sb.Append(.Address4.Trim).Append(vbCrLf)
            End If
            If .Postcode IsNot Nothing AndAlso .Postcode.Trim.Length > 0 Then
                sb.Append(.Postcode.Trim).Append(vbCrLf)
            End If
        End With
        Return sb.ToString
    End Function
#End Region
#Region "Callback reminders"
    Sub StartReminderCheck()
        LogUtil.Info("Callback Reminder check ========== Start", MyBase.Name)
        If FrmPopup.openForms.Count = 0 Then
            Dim userId As Integer = currentUser.UserId
            LogUtil.Info("Finding call back reminders", MyBase.Name)
            Dim _alertList As List(Of Reminder) = GetCallBackAlerts(userId)
            LogUtil.Info(_alertList.Count & " reminders", MyBase.Name)
            FrmPopup.openForms.Clear()
            For Each _alert As Reminder In _alertList
                ShowAlertMessage(_alert)
            Next
            LogUtil.Info("Callback reminder check complete", MyBase.Name)
        Else
            LogUtil.Info("Reminder check is aleady progress", MyBase.Name)
        End If
        LogUtil.Info("Callback Reminder check ========== End", MyBase.Name)
    End Sub
    Private Sub ShowAlertMessage(_alert As Reminder)
        Dim callBackTime As String = Format(_alert.ReminderDate, "HH:mm")
        Dim subject As String = _alert.Subject
        Dim slice As New FrmPopup(My.Settings.alertDuration * 1000, subject & CALLBACK_MESSAGE & callBackTime) With {
        .Height = 80,
        .Guid = Guid.NewGuid
    }
        LogUtil.Info("About to show " & slice.Guid.ToString, MyBase.Name)
        slice.Show()
    End Sub

    Private Sub MnuTasks_Click(sender As Object, e As EventArgs) Handles MnuTasks.Click
        Using _taskForm As New FrmTasks
            _taskForm.ShowDialog()
        End Using
    End Sub

#End Region
End Class