' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports i00SpellCheck
Imports MyBusiness.NetwyrksErrorCodes
Imports System.ComponentModel
Imports System.Text

Public Class FrmMain
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
        Me.Text = GlobalSettings.GetStringSetting(GlobalSettings.COMPANY_NAME)
        isLoading = True
        InitialiseData()
        FillCustomerTable()
        FillSupplierTable()
        FillJobTable(-1, mnuShowAllJobs.Checked)
        FillDiaryTable()
        If My.Settings.checkCallBack Then
            timerCallBackReminders.Interval = My.Settings.alertNotice * 60000
            chkCallBackReminders.Checked = True
            timerCallBackReminders.Enabled = True
            StartReminderThread()
        End If
        Me.EnableControlExtensions()
        isLoading = False
    End Sub
    Private Sub DgvCust_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgvCust.SelectionChanged
        spCustomer.Panel2Collapsed = True
        If Not isLoading Then
            If dgvCust.SelectedRows.Count = 1 Then
                Dim cRow As DataGridViewRow = dgvCust.SelectedRows(0)
                Dim _selCustId As Integer = cRow.Cells(Me.custId.Name).Value
                If _selCustId > 0 Then
                    Dim _selectedCust As Customer = CustomerBuilder.ACustomer.StartingWith(_selCustId).Build
                    FillJobTable(_selectedCust.CustomerId, mnuShowAllJobs.Checked)
                    txtCustAddress.Text = _selectedCust.CustName & vbCrLf & MultilineAddressString(_selectedCust.Address)
                    If My.Settings.ShowCustomer Then spCustomer.Panel2Collapsed = False
                    FillJobTable(_selCustId, mnuShowAllJobs.Checked)
                Else
                    FillJobTable(-1, mnuShowAllJobs.Checked)
                End If
            End If
        End If
    End Sub
    Private Sub DgvDiary_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgvDiary.SelectionChanged
        If Not isLoading Then
            If dgvDiary.SelectedRows.Count = 1 Then
                Dim dRow As DataGridViewRow = dgvDiary.SelectedRows(0)
                Dim _diaryId As Integer = dRow.Cells(Me.dremId.Name).Value
                Dim _reminder As Reminder = ReminderBuilder.AReminder.StartingWith(_diaryId).Build
                rtbDiaryBody.Text = _reminder.Body
            End If
        End If
    End Sub
    Private Sub DgvDiary_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvDiary.CellDoubleClick
        If dgvDiary.SelectedRows.Count = 1 Then
            Dim dRow As DataGridViewRow = dgvDiary.SelectedRows(0)
            Dim _diaryId As Integer = dRow.Cells(Me.dremId.Name).Value
            Dim _reminder As Reminder = ReminderBuilder.AReminder.StartingWith(_diaryId).Build
            Using _diary As New FrmReminder
                _diary.CurrentReminder = _reminder
                _diary.ShowDialog()
            End Using
            isLoading = True
            FillDiaryTable()
            isLoading = False
        End If
    End Sub
    Private Sub DgvCust_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvCust.CellDoubleClick
        If dgvCust.SelectedRows.Count = 1 Then
            Dim dRow As DataGridViewRow = dgvCust.SelectedRows(0)
            Dim _custId As Integer = dRow.Cells(Me.custId.Name).Value
            Using _custForm As New FrmCustomerMaint
                _custForm.CustomerId = _custId
                _custForm.ShowDialog()
            End Using
            isLoading = True
            FillCustomerTable()
            isLoading = False
        End If
    End Sub
    Private Sub DgvSupp_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvSupp.CellDoubleClick
        If dgvSupp.SelectedRows.Count = 1 Then
            Dim dRow As DataGridViewRow = dgvSupp.SelectedRows(0)
            Dim _suppId As Integer = dRow.Cells(Me.suppId.Name).Value
            Using _suppForm As New FrmSupplier
                _suppForm.SupplierId = _suppId
                _suppForm.ShowDialog()
            End Using
            isLoading = True
            FillSupplierTable()
            isLoading = False
        End If
    End Sub
    Private Sub DgvJobs_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvJobs.CellDoubleClick
        If dgvJobs.SelectedRows.Count = 1 Then
            Dim dRow As DataGridViewRow = dgvJobs.SelectedRows(0)
            Dim _jobId As Integer = dRow.Cells(Me.jobId.Name).Value
            Using _jobForm As New FrmJobMaint
                _jobForm.TheJob = GetJobById(_jobId)
                _jobForm.CustomerId = _jobForm.TheJob.JobCustomerId
                _jobForm.ShowDialog()
            End Using
            isLoading = True
            dgvCust.ClearSelection()
            FillJobTable(-1, mnuShowAllJobs.Checked)
            isLoading = False
        End If
    End Sub
    Private Sub DgvSupp_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgvSupp.SelectionChanged
        spSupplier.Panel2Collapsed = True
        If Not isLoading Then
            If dgvSupp.SelectedRows.Count = 1 Then
                Dim sRow As DataGridViewRow = dgvSupp.SelectedRows(0)
                Dim _selSuppId As Integer = sRow.Cells(Me.suppId.Name).Value
                If _selSuppId > 0 Then
                    Dim _selectedSupp As Supplier = SupplierBuilder.ASupplier.StartingWith(_selSuppId).Build
                    txtSuppAddress.Text = _selectedSupp.SupplierName & vbCrLf & MultilineAddressString(_selectedSupp.SupplierAddress)
                    If My.Settings.ShowSupplier Then spSupplier.Panel2Collapsed = False
                End If
            End If
        End If
    End Sub
    Private Sub NewCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewCustomerToolStripMenuItem.Click
        Using _custForm As New FrmCustomerMaint
            _custForm.ShowDialog()
        End Using
        isLoading = True
        FillCustomerTable()
        isLoading = False
    End Sub
    Private Sub NewSupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewSupplierToolStripMenuItem.Click
        Using _suppForm As New FrmSupplier
            _suppForm.ShowDialog()
        End Using
        isLoading = True
        FillSupplierTable()
        isLoading = False
    End Sub
    Private Sub NewDiaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewDiaryToolStripMenuItem.Click
        Using _diary As New FrmReminder
            _diary.ShowDialog()
        End Using
        isLoading = True
        FillDiaryTable()
        isLoading = False
    End Sub
    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub PreferencesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreferencesToolStripMenuItem.Click
        Using _settings As New frmOptions
            _settings.ShowDialog()
        End Using
        If My.Settings.ShowDiaryBody Then
            spDiary.Panel2Collapsed = False
        Else
            spDiary.Panel2Collapsed = True
        End If
    End Sub
    Private Sub GlobalSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlobalSettingsToolStripMenuItem.Click
        Using _global As New FrmGlobalSettings
            _global.ShowDialog()
        End Using
    End Sub
    Private Sub UserControlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserControlToolStripMenuItem.Click
        Using _userControl As New FrmUserControl
            _userControl.ShowDialog()
        End Using
    End Sub
    Private Sub TidyFilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TidyFilesToolStripMenuItem.Click
        Dim logFolder As String = sLogFolder
        Dim retentionPeriod As Integer = My.Settings.RetentionPeriod
        TidyFiles(logFolder, "*.*", retentionPeriod)
        MsgBox("Tidy complete", MsgBoxStyle.Information, "Housekeeping")
    End Sub
    Private Sub MnuAddANewJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddANewJob.Click
        Using _jobForm As New FrmJobMaint
            _jobForm.CustomerId = -1
            _jobForm.ShowDialog()
        End Using
        isLoading = True
        FillJobTable(-1, mnuShowAllJobs.Checked)
        isLoading = False
    End Sub
    Private Sub MnuShowAllJobs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAllJobs.Click
        Dim _selCustId As Integer = -1
        If dgvCust.SelectedRows.Count = 1 Then
            _selCustId = dgvCust.SelectedRows(0).Cells(Me.custId.Name).Value
        End If
        FillJobTable(_selCustId, mnuShowAllJobs.Checked)
    End Sub
    Private Sub MnuLogView_Click(sender As Object, e As EventArgs) Handles MnuLogView.Click
        Using _log As New FrmLogViewer
            _log.ShowDialog()
        End Using
    End Sub
#End Region
#Region "subroutines"
    Private Sub FillCustomerTable()
        dgvCust.Rows.Clear()
        Dim row1 As DataGridViewRow = dgvCust.Rows(dgvCust.Rows.Add)
        row1.Cells(custId.Name).Value = -1
        For Each oCust As Customer In GetCustomers()
            Dim tRow As DataGridViewRow = dgvCust.Rows(dgvCust.Rows.Add)
            tRow.Cells(custId.Name).Value = oCust.CustomerId
            tRow.Cells(custName.Name).Value = oCust.CustName
            tRow.Cells(custPhone.Name).Value = oCust.Phone
            tRow.Cells(custemail.Name).Value = oCust.Email
        Next
        spCustomer.Panel2Collapsed = True
        dgvCust.ClearSelection()
    End Sub
    Private Sub FillSupplierTable()
        dgvSupp.Rows.Clear()
        Dim row1 As DataGridViewRow = dgvSupp.Rows(dgvSupp.Rows.Add)
        row1.Cells(suppId.Name).Value = -1
        For Each oSupp As Supplier In GetSuppliers()
            Dim tRow As DataGridViewRow = dgvSupp.Rows(dgvSupp.Rows.Add)
            tRow.Cells(suppId.Name).Value = oSupp.SupplierId
            tRow.Cells(suppName.Name).Value = oSupp.SupplierName
            tRow.Cells(suppPhone.Name).Value = oSupp.SupplierPhone
            tRow.Cells(suppEmail.Name).Value = oSupp.SupplierEmail
            tRow.Cells(suppAmazon.Name).Value = oSupp.IsSupplierAmazon
        Next
        spSupplier.Panel2Collapsed = True
        dgvSupp.ClearSelection()
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
            tRow.Cells(Me.jobId.Name).Value = ojob.JobId
            tRow.Cells(Me.jobName.Name).Value = ojob.JobName
            tRow.Cells(Me.jobDesc.Name).Value = ojob.JobDescription.Replace(Chr(10), " ")
            tRow.Cells(Me.jobUser.Name).Value = ojob.JobUserId
            tRow.Cells(Me.jobAssigned.Name).Value = UserBuilder.AUser.StartingWith(ojob.JobUserId).Build.User_code
            If ojob.IsJobCompleted Then
                tRow.Cells(Me.jobCompleted.Name).Value = "Yes"
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
                    rRow.Cells(Me.dremHeader.Name).Value = False
                    rRow.Cells(Me.dremId.Name).Value = oReminder.Diary_id
                    rRow.Cells(Me.dremSubject.Name).Value = oReminder.Subject
                    rRow.Cells(Me.dremDate.Name).Value = Format(oReminder.ReminderDate, "dd/MM/yyyy")
                    rRow.Cells(Me.dremDate.Name).Style.ForeColor = Color.Gray
                    rRow.Cells(Me.dremCustId.Name).Value = oReminder.CustomerId
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
        rRow.Cells(Me.dremDate.Name).Value = dateSectionHeads(sectionNo)
        rRow.Cells(Me.dremDate.Name).Style.ForeColor = Color.Black
        rRow.Cells(Me.dremHeader.Name).Value = True
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

#End Region
#Region "Callback reminder background worker"
    Sub StartReminderThread()
        LogUtil.Info("CallBack Reminder Check started", "StartReminderThread")
        ' Initialize the object that the background worker calls. 
        Dim oCallBackReminder As New CallBackReminder
        oCallBackReminder.Principal = My.User.CurrentPrincipal
        ' Start the asynchronous operation.   
        CallbackReminderBackgroundWorker.RunWorkerAsync(oCallBackReminder)
    End Sub

    Private Sub CallbackReminderBackgroundWorker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles CallbackReminderBackgroundWorker.DoWork
        LogUtil.Info("Callback Reminder thread ========== Start")
        Dim worker As BackgroundWorker
        worker = CType(sender, BackgroundWorker)
        Dim oCallBackreminder As CallBackReminder = CType(e.Argument, CallBackReminder)
        oCallBackreminder.CheckCallBackReminders(worker, e)
        LogUtil.Info("Callback Reminder thread ========== End")
    End Sub

    Private Sub CallbackReminderBackgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles CallbackReminderBackgroundWorker.RunWorkerCompleted
        ' This event handler is called when the background thread finishes. 
        ' This method runs on the main thread. 
        If e.Error IsNot Nothing Then
            LogUtil.Problem("Error: " & e.Error.Message)
        ElseIf e.Cancelled Then
            LogUtil.Info("Callback reminder check cancelled", "CallbackReminderBackgroundWorker")
        Else
            LogUtil.Info("Callback reminder check complete", "CallbackReminderBackgroundWorker")
        End If
    End Sub

    Private Sub CallbackReminderBackgroundWorker_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles CallbackReminderBackgroundWorker.ProgressChanged
        ' This method runs on the main thread. 
        Dim state As CallBackReminder.CurrentProgress = CType(e.UserState, CallBackReminder.CurrentProgress)
        Dim percentage As Integer = e.ProgressPercentage
        LogUtil.Info("Callback reminder status " & CStr(state.progressStatus), "CallbackReminderBackgroundWorker")
    End Sub

    Private Sub chkCallBackReminders_Click(sender As Object, e As EventArgs) Handles chkCallBackReminders.Click
        chkCallBackReminders.Checked = Not chkCallBackReminders.Checked
        If chkCallBackReminders.Checked Then
            StartReminderThread()
        End If
    End Sub

    Private Sub timerCallBackReminders_Tick(sender As Object, e As EventArgs) Handles timerCallBackReminders.Tick
        LogUtil.Debug("Timer tick", MyBase.Name)
        StartReminderThread()
    End Sub

#End Region
End Class