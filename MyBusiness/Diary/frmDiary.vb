' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports MyBusiness.NetwyrksErrorCodes
''' <summary>
''' Form to display and maintain the user diary
''' </summary>
''' <remarks></remarks>
Public Class FrmDiary
#Region "Constants"
    Private Const FORM_NAME As String = "diary"
#End Region
#Region "Private variable instances"
    Private ReadOnly RECORD_TYPE As AuditUtil.RecordType = AuditUtil.RecordType.Reminder
    Private ReadOnly userId As Integer = currentUser.UserId
    Private ReadOnly userName As String = currentUser.UserName
    Private ReadOnly currentRemId As Integer = 0
    Private currentCustId As Integer = 0
    Private currentJobId As Integer = 0
    Private ReadOnly dayOfWeek As Integer = Today.DayOfWeek
    Private dateSectionHeads As String() = {"Overdue", "Today", "Tomorrow", "This Week", "Next Week", "Future"}
    Private dateSectionEnds As Date() = {Today, DateAdd(DateInterval.Day, 1, Today), DateAdd(DateInterval.Day, 2, Today), DateAdd(DateInterval.Day, 8 - dayOfWeek, Today), DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Day, 14 - dayOfWeek, Today)), Date.MaxValue}
    Private dateSection As Integer = 0
    Private isLoading As Boolean = True
    Private isShowAll As Boolean = False
    Private currentDiary As Reminder
#End Region
#Region "properties"
    Private _forCustomerId As Integer
    Private _forJobId As Integer
    Public Property ForJobId() As Integer
        Get
            Return _forJobId
        End Get
        Set(ByVal value As Integer)
            _forJobId = value
        End Set
    End Property
    Public Property ForCustomerId() As Integer
        Get
            Return _forCustomerId
        End Get
        Set(ByVal value As Integer)
            _forCustomerId = value
        End Set
    End Property
#End Region
#Region "Form"
    ''' <summary>
    ''' Dispose of resources when form closes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closed", FORM_NAME)
        My.Settings.DiaryFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    ''' <summary>
    ''' Initialse the loading form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Starting", FORM_NAME)
        GetFormPos(Me, My.Settings.DiaryFormPos)
        lblDate.Text = Format(Today, "dd MMMM yyyy")
        lblStatus.Text = ""
        Me.KeyPreview = True
        If dayOfWeek = 6 Then
            dateSectionHeads = New String() {"Overdue", "Today", "Tomorrow", "Next Week", "Future"}
            dateSectionEnds = New DateTime() {Today, DateAdd(DateInterval.Day, 1, Today), DateAdd(DateInterval.Day, 2, Today), DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Day, 8, Today)), Date.MaxValue}
        End If
        isLoading = True
        lblFormName.Text = FORM_NAME
        lblName.Text = userName
        ClearForm()
        isLoading = False
        If _forCustomerId > 0 Then
            LblCustName.Text = GetCustomer(_forCustomerId).CustName
        End If
        If _forJobId > 0 Then
            LblJobName.Text = GetJobById(_forJobId).JobName
        End If
        FillDiaryTable()
        SpellCheckUtil.EnableSpellChecking({rtbBody, txtSubject})
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSetReminder_Click(sender As Object, e As EventArgs) Handles btnSetReminder.Click
        If dgvDiary.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = dgvDiary.SelectedRows(0)
            Dim remId As Integer = oRow.Cells(dremId.Name).Value
            Dim newValue As Integer = If(oRow.Cells(Me.dremRem.Name).Value = "", 1, 0)
            UpdateIsReminder(newValue, remId)
            RebuildDiaryList()
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSetComplete_Click(sender As Object, e As EventArgs) Handles btnSetComplete.Click
        If dgvDiary.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = dgvDiary.SelectedRows(0)
            Dim remId As Integer = oRow.Cells(dremId.Name).Value
            Dim newValue As Integer = If(oRow.Cells(Me.dremClosed.Name).Value = "", 1, 0)
            UpdateReminderClosed(newValue, remId)
            RebuildDiaryList()
        End If
    End Sub
    ''' <summary>
    ''' Refill the diary grid and position the selected row as before
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RebuildDiaryList()
        Dim iSelectedRow As Integer = 0
        Dim iSelectedId As Integer = -1
        If dgvDiary.SelectedRows.Count > 0 Then
            iSelectedRow = dgvDiary.SelectedRows(0).Index
            iSelectedId = dgvDiary.SelectedRows(0).Cells(Me.dremId.Name).Value
        End If
        Dim iTopRow As Integer = dgvDiary.FirstDisplayedScrollingRowIndex
        Dim iTopRowDiff As Integer = Math.Max(iSelectedRow - iTopRow, 0)
        FillDiaryTable()
        iSelectedRow = Math.Min(iSelectedRow, dgvDiary.Rows.Count - 1)
        For Each oRow As DataGridViewRow In dgvDiary.Rows
            If oRow.Cells(Me.dremHeader.Name).Value = False AndAlso oRow.Cells(Me.dremId.Name).Value = iSelectedId Then
                iSelectedRow = oRow.Index
            End If
        Next
        iTopRow = Math.Max(iSelectedRow - iTopRowDiff, 0)
        If dgvDiary.Rows.Count > 0 Then
            dgvDiary.Rows(iSelectedRow).Selected = True
            dgvDiary.FirstDisplayedScrollingRowIndex = iTopRow
            FillForm(dgvDiary.Rows(iSelectedRow).Cells(dremId.Name).Value)
        Else
            dgvDiary.ClearSelection()
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DtpSelectDate_ValueChanged(sender As Object, e As EventArgs)
        FillDiaryTable()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkOptions_CheckedChanged(sender As Object, e As EventArgs) Handles chkReminders.CheckedChanged, chkComplete.CheckedChanged
        RebuildDiaryList()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearForm()
        currentDiary = Nothing
        btnNew.Visible = True
        btnUpdate.Visible = False
        btnSetComplete.Enabled = False
        btnSetReminder.Enabled = False
        lblOverdue.Visible = False
        lblReminder.Visible = False
        lblComplete.Visible = False
        txtSubject.Text = ""
        rtbBody.Text = ""
        ClearLinks()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearLinks()
        btnCustLink.Enabled = False
        btnJobLink.Enabled = False
        currentCustId = 0
        currentJobId = 0
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_id"></param>
    ''' <remarks></remarks>
    Private Sub FillForm(ByVal _id As Integer)
        currentDiary = GetReminderById(_id)
        ClearLinks()

        txtSubject.Text = currentDiary.Subject
        rtbBody.Text = currentDiary.Body
        If currentDiary.CustomerId > 0 Then
            btnCustLink.Enabled = True
            currentCustId = currentDiary.CustomerId
        End If
        If currentDiary.JobId > 0 Then
            btnJobLink.Enabled = True
            currentJobId = currentDiary.JobId
        End If
        Dim isReminder As Boolean = currentDiary.IsReminder
        Dim isComplete As Boolean = currentDiary.IsClosed
        lblReminder.Visible = isReminder
        lblComplete.Visible = isComplete
        lblOverdue.Visible = currentDiary.IsReminder And currentDiary.ReminderDate < Today.Date And Not isComplete
        btnSetReminder.Enabled = True
        btnSetComplete.Enabled = True
        btnSetReminder.Text = If(isReminder, "Cancel", "Set") & " Reminder"
        btnSetComplete.Text = If(isComplete, "Re-open", "Close") & " Reminder"
        btnUpdate.Visible = True
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DgvDiary_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDiary.SelectionChanged
        ClearForm()
        If dgvDiary.SelectedRows.Count = 1 Then
            If dgvDiary.SelectedRows(0).Cells(Me.dremHeader.Name).Value = False Then
                Dim orow As DataGridViewRow = dgvDiary.SelectedRows(0)
                FillForm(orow.Cells(dremId.Name).Value)
            End If
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCustLink_Click(sender As Object, e As EventArgs) Handles btnCustLink.Click

        Using _dialog As New FrmCustomerMaint
            _dialog.CustomerId = currentCustId
            _dialog.ShowDialog()
        End Using

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnjobLink_Click(sender As Object, e As EventArgs) Handles btnJobLink.Click


        If currentDiary IsNot Nothing Then

            Dim ojob As Job = currentDiary.LinkedJob

            Using _job As New FrmJobMaint
                _job.TheJob = ojob
                _job.ShowDialog()

            End Using

        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Using _reminder As New FrmReminder
            _reminder.CurrentReminder = Nothing
            _reminder.ShowDialog()
        End Using
        RebuildDiaryList()
    End Sub
    ''' <summary>
    ''' Capture function keypress and take action
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>F3 refreshes the list
    ''' F4 toggles show all users</remarks>
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            RefreshList()
        End If
        If e.KeyCode = Keys.F4 Then
            ShowAllUsers()
        End If
    End Sub
    Private Sub LblF3_Click(sender As Object, e As EventArgs) Handles lblF3.Click
        RefreshList()
    End Sub
    Private Sub LblF4_Click(sender As Object, e As EventArgs) Handles lblF4.Click
        ShowAllUsers()
    End Sub
#End Region
#Region "Create Update Delete"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvDiary.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = dgvDiary.SelectedRows(0)
            Using _reminder As New FrmReminder
                _reminder.CurrentReminder = ReminderBuilder.AReminder.StartingWith(oRow.Cells(Me.dremId.Name).Value).build()
                _reminder.ShowDialog()
            End Using
        Else
            MsgBox("Pick an item from the list", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Selection error")
        End If
        RebuildDiaryList()
    End Sub
#End Region
#Region "Subroutines"
    ''' <summary>
    ''' Display mesasage on the status bar and log it
    ''' </summary>
    ''' <param name="sText"></param>
    ''' <param name="islogged"></param>
    ''' <param name="level"></param>
    ''' <remarks></remarks>
    Private Sub LogStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information)
        lblStatus.Text = sText
        If islogged Then LogUtil.AddLog(sText, level, FORM_NAME)
    End Sub
    ''' <summary>
    ''' Fill the diary grid with diary entries
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillDiaryTable()
        Dim _RemList As List(Of Reminder)
        If isLoading Then Exit Sub
        dgvDiary.Rows.Clear()
        Try
            Dim remCt As Integer = 0
            If isShowAll Then
                _RemList = GetAllReminders()
            Else
                _RemList = GetRemindersForUser(userId)
            End If
            If _RemList.Count > 0 Then
                Dim isFirstRow As Boolean = True
                For Each _reminder As Reminder In _RemList
                    If Not IsRequiredCustomer(_reminder) OrElse Not IsRequiredJob(_reminder) Then
                        Continue For
                    End If
                    If chkComplete.Checked Or Not _reminder.IsClosed Then
                        If _reminder.IsReminder Or Not chkReminders.Checked Then
                            Dim rRow As DataGridViewRow = Nothing
                            If isFirstRow Then
                                Dim oFirstRow As Reminder = _RemList(0)
                                Dim firstRowdate As Date = oFirstRow.ReminderDate.Date
                                rRow = dgvDiary.Rows(dgvDiary.Rows.Add())
                                dateSection = GetNextSection(firstRowdate, rRow)
                                isFirstRow = False
                            End If
                            Dim remId As Integer = _reminder.Diary_id
                            rRow = dgvDiary.Rows(dgvDiary.Rows.Add())
                            If _reminder.ReminderDate.Date >= dateSectionEnds(dateSection).Date Then
                                dateSection = GetNextSection(_reminder.ReminderDate.Date, rRow)
                                rRow = dgvDiary.Rows(dgvDiary.Rows.Add() + 1)
                            End If
                            Dim isReminder As Boolean = _reminder.IsReminder
                            Dim isComplete As Boolean = _reminder.IsClosed
                            Dim isCallBack As Boolean = _reminder.CallBack

                            rRow.Cells(Me.dremUserCode.Name).Value = _reminder.DiaryUser.User_code
                            rRow.Cells(Me.dremHeader.Name).Value = False
                            rRow.Cells(Me.dremId.Name).Value = _reminder.Diary_id
                            rRow.Cells(Me.dremSubject.Name).Value = _reminder.Subject
                            rRow.Cells(Me.dremDate.Name).Value = Format(_reminder.ReminderDate, "dd/MM/yyyy")
                            rRow.Cells(Me.dremDate.Name).Style.ForeColor = Color.Gray
                            rRow.Cells(Me.dremCustId.Name).Value = _reminder.CustomerId
                            rRow.Cells(Me.dremJobId.Name).Value = _reminder.JobId
                            Dim oRemCell As DataGridViewCell = rRow.Cells(dremRem.Name)
                            oRemCell.Style.Font = New Font("Wingdings", 11)
                            oRemCell.Value = If(isReminder, Chr(185), "")
                            Dim oCompCell As DataGridViewCell = rRow.Cells(dremClosed.Name)
                            oCompCell.Style.Font = New Font("Wingdings", 11)
                            oCompCell.Value = If(isComplete, Chr(254), "")
                            Dim oCallCell As DataGridViewCell = rRow.Cells(dremCallback.Name)
                            oCallCell.Style.Font = New Font("Wingdings", 11)
                            oCallCell.Value = If(isCallBack, Chr(40), "")
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            LogUtil.Exception("Error loading reminders", ex, "loadReminders", GetErrorCode(SystemModule.DIARY, ErrorType.TABLE, FailedAction.ERROR_LOADING_RECORDS))
        End Try
        dgvDiary.ClearSelection()
    End Sub
    Private Function IsRequiredCustomer(ByRef _reminder As Reminder) As Boolean
        Dim isRequired As Boolean
        isRequired = _forCustomerId <= 0 Or _reminder.LinkedCustomer.CustomerId = _forCustomerId
        Return isRequired
    End Function
    Private Function IsRequiredJob(ByRef _reminder As Reminder) As Boolean
        Dim isRequired As Boolean
        isRequired = _forJobId <= 0 Or _reminder.LinkedJob.JobId = _forJobId
        Return isRequired
    End Function
    ''' <summary>
    ''' Find the next date section 
    ''' </summary>
    ''' <param name="rowDate"></param>
    ''' <param name="rRow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
    ''' <summary>
    ''' Reload the list to show all users or the current user's diary
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowAllUsers()
        isShowAll = Not isShowAll
        isLoading = True
        ClearForm()
        If isShowAll Then
            lblF4.Text = "F4=Show " & userName
            lblName.Text = "All Users"
            dgvDiary.Columns(Me.dremUserCode.Name).Visible = True
        Else
            lblF4.Text = "F4=Show All Users"
            lblName.Text = userName
            dgvDiary.Columns(Me.dremUserCode.Name).Visible = False
        End If
        isLoading = False
        RebuildDiaryList()

    End Sub
    ''' <summary>
    ''' Refreshes the diary list
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshList()
        isLoading = True
        ClearForm()
        isLoading = False
        RebuildDiaryList()
    End Sub
#End Region
End Class