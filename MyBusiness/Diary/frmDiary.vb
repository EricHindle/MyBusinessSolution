﻿' Hindleware
' Copyright (c) 2022-24 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging
Imports HindlewareLib.NetwyrksErrorCodes

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
        LogUtil.LogInfo("Closed", FORM_NAME)
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
        LogUtil.LogInfo("Starting", FORM_NAME)
        GetFormPos(Me, My.Settings.DiaryFormPos)
        lblDate.Text = Format(Today, "dd MMMM yyyy")
        lblStatus.Text = ""
        KeyPreview = True
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
    ''' Refill the diary grid and position the selected row as before
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RebuildDiaryList()
        Dim iSelectedRow As Integer = 0
        Dim iSelectedId As Integer = -1
        If dgvDiary.SelectedRows.Count > 0 Then
            iSelectedRow = dgvDiary.SelectedRows(0).Index
            iSelectedId = dgvDiary.SelectedRows(0).Cells(dremId.Name).Value
        End If
        Dim iTopRow As Integer = dgvDiary.FirstDisplayedScrollingRowIndex
        Dim iTopRowDiff As Integer = Math.Max(iSelectedRow - iTopRow, 0)
        FillDiaryTable()
        iSelectedRow = Math.Min(iSelectedRow, dgvDiary.Rows.Count - 1)
        For Each oRow As DataGridViewRow In dgvDiary.Rows
            If oRow.Cells(dremHeader.Name).Value = False AndAlso oRow.Cells(dremId.Name).Value = iSelectedId Then
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
        PicAdd.Visible = True
        PicUpdate.Visible = False
        PicToggleComplete.Visible = False
        PicSetReminder.Visible = False
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
        PicSetReminder.Visible = currentDiary.Diary_id > 0
        PicToggleComplete.Visible = currentDiary.Diary_id > 0
        PicSetReminder.Image = If(isReminder, My.Resources.cancelreminder, My.Resources.setreminder)
        PicToggleComplete.Image = If(isComplete, My.Resources.reopendiary, My.Resources.closediary)
        PicUpdate.Visible = currentDiary.Diary_id > 0
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
            If dgvDiary.SelectedRows(0).Cells(dremHeader.Name).Value = False Then
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
            _dialog.IsView = True
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
                _job.IsView = True
                _job.ShowDialog()

            End Using

        End If
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
    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        Close()
    End Sub
#End Region
#Region "Create Update Delete"
    Private Sub PicAdd_Click(sender As Object, e As EventArgs) Handles PicAdd.Click
        Using _reminder As New FrmReminder
            If _forJobId > 0 Then
                _reminder.CurrentJob = GetJobById(_forJobId)
            End If
            If _forCustomerId > 0 Then
                _reminder.CurrentCustomer = GetCustomer(_forCustomerId)
            End If
            _reminder.CurrentReminder = Nothing
            _reminder.ShowDialog()
        End Using
        RebuildDiaryList()
    End Sub
    Private Sub PicUpdate_Click(sender As Object, e As EventArgs) Handles PicUpdate.Click
        If dgvDiary.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = dgvDiary.SelectedRows(0)
            Using _reminder As New FrmReminder
                _reminder.CurrentReminder = GetReminderById(oRow.Cells(dremId.Name).Value)
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
                _RemList = GetAllReminders(chkComplete.Checked)
            Else
                _RemList = GetRemindersForUser(userId, chkComplete.Checked)
            End If
            If _RemList.Count > 0 Then
                Dim isFirstRow As Boolean = True
                For Each _reminder As Reminder In _RemList
                    If Not IsRequiredCustomer(_reminder) OrElse Not IsRequiredJob(_reminder) Then
                        Continue For
                    End If
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

                        rRow.Cells(dremUserCode.Name).Value = _reminder.DiaryUser.User_code
                        rRow.Cells(dremHeader.Name).Value = False
                        rRow.Cells(dremId.Name).Value = _reminder.Diary_id
                        rRow.Cells(dremSubject.Name).Value = _reminder.Subject
                        rRow.Cells(dremDate.Name).Value = Format(_reminder.ReminderDate, "dd/MM/yyyy")
                        rRow.Cells(dremDate.Name).Style.ForeColor = Color.Gray
                        rRow.Cells(dremCustId.Name).Value = _reminder.CustomerId
                        rRow.Cells(dremJobId.Name).Value = _reminder.JobId
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
                Next
            End If
        Catch ex As Exception
            LogUtil.LogException(ex, "Error loading reminders", "loadReminders", TraceEventType.Error, GetErrorCode(SystemModule.DIARY, ErrorType.TABLE, FailedAction.ERROR_LOADING_RECORDS), 0)
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
        rRow.Cells(dremDate.Name).Value = dateSectionHeads(sectionNo)
        rRow.Cells(dremDate.Name).Style.ForeColor = Color.Black
        rRow.Cells(dremHeader.Name).Value = True
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
            dgvDiary.Columns(dremUserCode.Name).Visible = True
        Else
            lblF4.Text = "F4=Show All Users"
            lblName.Text = userName
            dgvDiary.Columns(dremUserCode.Name).Visible = False
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
    Private Sub PicSetReminder_Click(sender As Object, e As EventArgs) Handles PicSetReminder.Click
        If dgvDiary.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = dgvDiary.SelectedRows(0)
            Dim remId As Integer = oRow.Cells(dremId.Name).Value
            Dim _rem As Reminder = GetReminderById(remId)
            Dim newValue As Integer = If(_rem.IsReminder, 0, 1)
            PicSetReminder.Image = If(_rem.IsReminder, My.Resources.setreminder, My.Resources.cancelreminder)
            UpdateIsReminder(newValue, remId)
            RebuildDiaryList()
        End If
    End Sub
    Private Sub PicToggleComplete_Click(sender As Object, e As EventArgs) Handles PicToggleComplete.Click
        If dgvDiary.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = dgvDiary.SelectedRows(0)
            Dim _reminder As Reminder = GetReminderById(oRow.Cells(dremId.Name).Value)
            _reminder.IsClosed = Not _reminder.IsClosed
            UpdateReminderClosed(_reminder.IsClosed, _reminder.Diary_id)
            RebuildDiaryList()
        End If
    End Sub
    Private Sub PicCancelCustLink_Click(sender As Object, e As EventArgs) Handles PicCancelCustLink.Click
        _forCustomerId = -1
        LblCustName.Text = String.Empty
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        _forJobId = -1
        LblJobName.Text = String.Empty
    End Sub
#End Region
End Class