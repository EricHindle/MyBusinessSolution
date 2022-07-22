'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

''' <summary>
''' Reminder list displayed at login
''' </summary>
''' <remarks></remarks>
Public Class frmReminderList
    Private Const FORM_NAME As String = "reminders"
    Private Const DUE_REMINDERS As String = "due reminders"
    'Private oTa As New sersDataSetTableAdapters.diaryTableAdapter
    'Private oTable As New sersDataSet.diaryDataTable
    'Private oRemTable As New sersDataSet.diaryDataTable
    'Private oSeTa As New sersDataSetTableAdapters.exclusion_requestTableAdapter
    'Private osetable As New sersDataSet.exclusion_requestDataTable
    'Private oIncTa As New sersDataSetTableAdapters.incidentTableAdapter
    'Private oInctable As New sersDataSet.incidentDataTable
    Private isLoading As Boolean = False
    'Private user As sersIIdentity
    Private userId As Integer = 0
    Private dayOfWeek As Integer = Today.DayOfWeek
    Private dateSectionHeads As String() = {"Overdue", "Today", "Tomorrow", "This Week", "Next Week", "Future"}
    Private dateSectionEnds As Date() = {Today, DateAdd(DateInterval.Day, 1, Today), DateAdd(DateInterval.Day, 2, Today), DateAdd(DateInterval.Day, 8 - dayOfWeek, Today), DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Day, 14 - dayOfWeek, Today)), Date.MaxValue}
    Private dateSection As Integer = 0
    Private currentRemId As Integer = 0
    Private currentCustId As Integer = 0
    Private currentJobId As Integer = 0
    Private currentIncId As Integer = 0
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Reminders_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closed", FORM_NAME)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Reminders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearForm()
        DgvReminders.Rows.Clear()
        If dayOfWeek = 6 Then
            dateSectionHeads = {"Overdue", "Today", "Tomorrow", "Next Week", "Future"}
            dateSectionEnds = {Today, DateAdd(DateInterval.Day, 1, Today), DateAdd(DateInterval.Day, 2, Today), DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Day, 8, Today)), Date.MaxValue}
        End If
        userId = currentUser.UserId
        lblFormName.Text = FORM_NAME
        ChkShowAll.Checked = My.Settings.ShowAllReminders
        ChkShowAtLogin.Checked = My.Settings.ShowRemindersAtLogin
        loadReminders()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkShowAtLogin_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowAtLogin.CheckedChanged
        My.Settings.ShowRemindersAtLogin = ChkShowAtLogin.Checked
        My.Settings.Save()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearForm()
        lblReminder.Visible = False
        txtSubject.Text = ""
        rtbBody.Text = ""
        BtnCloseRem.Visible = False
        BtnSetReminder.Visible = False
        BtnCustomer.Visible = False
        BtnJob.Visible = False
        currentRemId = 0
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="oRow"></param>
    ''' <remarks></remarks>
    Private Sub FillForm(ByVal oRow As DataGridViewRow)
        currentRemId = oRow.Cells(Me.remId.Name).Value
        Dim _reminder As Reminder = GetReminderById(currentRemId)

        currentCustId = _reminder.CustomerId
        currentJobId = _reminder.JobId
        txtSubject.Text = _reminder.Subject
        rtbBody.Text = _reminder.Body
        Dim isReminder As Boolean = _reminder.IsReminder
        lblReminder.Visible = isReminder
        BtnCustomer.Visible = currentCustId > 0
        BtnJob.Visible = currentJobId > 0
        BtnCloseRem.Visible = True
        BtnSetReminder.Visible = True
        logStatus("")
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadReminders() As Integer
        Dim iSelectedRow As Integer = 0
        Dim iSelectedId As Integer = -1
        If DgvReminders.SelectedRows.Count > 0 Then
            iSelectedRow = DgvReminders.SelectedRows(0).Index
            iSelectedId = DgvReminders.SelectedRows(0).Cells(Me.remId.Name).Value
        End If
        Dim iTopRow As Integer = DgvReminders.FirstDisplayedScrollingRowIndex
        Dim iTopRowDiff As Integer = Math.Max(iSelectedRow - iTopRow, 0)

        Dim remCt As Integer = FillReminderTable()
        iSelectedRow = Math.Min(iSelectedRow, DgvReminders.Rows.Count - 1)
        For Each oRow As DataGridViewRow In DgvReminders.Rows
            If oRow.Cells(Me.remHeader.Name).Value = False AndAlso oRow.Cells(Me.remId.Name).Value = iSelectedId Then
                iSelectedRow = oRow.Index
            End If
        Next
        iTopRow = Math.Max(iSelectedRow - iTopRowDiff, 0)
        If DgvReminders.Rows.Count > 0 Then
            DgvReminders.Rows(iSelectedRow).Selected = True
            DgvReminders.FirstDisplayedScrollingRowIndex = iTopRow
            If DgvReminders.SelectedRows(0).Cells(Me.remHeader.Name).Value = False Then
                FillForm(DgvReminders.SelectedRows(0))
            End If
        Else
            DgvReminders.ClearSelection()
        End If

        Return remCt
    End Function

    Private Function FillReminderTable() As Integer
        isLoading = True
        Dim _remList As List(Of Reminder)
        DgvReminders.Rows.Clear()
        Dim remCt As Integer = 0
        Try
            _remList = GetRemindersForUser(currentUser.UserId)

            If _remList.Count > 0 Then
                Dim isFirstRow As Boolean = True

                For Each oRem As Reminder In _remList
                    If ChkShowAll.Checked Or oRem.ReminderDate.Date <= Today.Date Then
                        Dim rRow As DataGridViewRow = Nothing
                        If isFirstRow Then
                            Dim oFirstRow As Reminder = _remList(0)
                            Dim firstRowdate As Date = oFirstRow.ReminderDate.Date
                            rRow = DgvReminders.Rows(DgvReminders.Rows.Add())
                            dateSection = GetNextSection(firstRowdate, rRow)
                            remCt += 1
                            isFirstRow = False
                        End If
                        Dim remId As Integer = oRem.Diary_id
                        rRow = DgvReminders.Rows(DgvReminders.Rows.Add())
                        remCt += 1
                        If oRem.ReminderDate.Date >= dateSectionEnds(dateSection).Date Then
                            dateSection = getNextSection(oRem.ReminderDate.Date, rRow)
                            rRow = DgvReminders.Rows(DgvReminders.Rows.Add())
                        End If
                        rRow.Cells(Me.remHeader.Name).Value = False
                        rRow.Cells(Me.remId.Name).Value = oRem.Diary_id
                        rRow.Cells(Me.remSubject.Name).Value = oRem.Subject
                        rRow.Cells(Me.remDate.Name).Value = Format(oRem.ReminderDate, "dd/MM/yyyy")
                        rRow.Cells(Me.remDate.Name).Style.ForeColor = Color.Gray
                        If oRem.CustomerId > 0 Then
                            rRow.Cells(Me.remCustId.Name).Value = oRem.CustomerId
                        End If
                        If oRem.JobId > 0 Then
                            rRow.Cells(Me.remJobId.Name).Value = oRem.JobId
                        End If
                    End If
                Next
            End If

        Catch ex As Exception
            '           LogUtil.Exception("Error loading reminders", ex, "loadReminders", getErrorCode(SystemModule.DIARY, ErrorType.TABLE, FailedAction.ERROR_LOADING_RECORDS))
        Finally
            isLoading = False
        End Try
        Return remCt
    End Function

    ''' <summary>
    ''' 
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
        rRow.Cells(Me.remDate.Name).Value = dateSectionHeads(sectionNo)
        rRow.Cells(Me.remDate.Name).Style.ForeColor = Color.Black
        rRow.Cells(Me.remHeader.Name).Value = True
        For Each oCell As DataGridViewCell In rRow.Cells
            oCell.Style.BackColor = Color.Silver
        Next
        Return sectionNo
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowAll.CheckedChanged
        lblFormName.Text = If(ChkShowAll.Checked, FORM_NAME, DUE_REMINDERS)
        My.Settings.ShowAllReminders = ChkShowAll.Checked
        My.Settings.Save()
        ClearForm()
        loadReminders()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvReminders_SelectionChanged(sender As Object, e As EventArgs) Handles DgvReminders.SelectionChanged
        If Not isLoading Then
            ClearForm()
            If DgvReminders.SelectedRows.Count = 1 Then
                If DgvReminders.SelectedRows(0).Cells(Me.remHeader.Name).Value = False Then
                    FillForm(DgvReminders.SelectedRows(0))
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Display a message in the status bar and optionally log it
    ''' </summary>
    ''' <param name="sText"></param>
    ''' <param name="islogged"></param>
    ''' <param name="level"></param>
    ''' <remarks></remarks>
    Private Sub logStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information)
        lblStatus.Text = sText
        If islogged Then LogUtil.AddLog(sText, level, FORM_NAME)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCloseRem_Click(sender As Object, e As EventArgs) Handles BtnCloseRem.Click
        UpdateReminderClosed(1, currentRemId)
        logStatus("Closed reminder", True)
        ClearForm()
        loadReminders()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSetReminder_Click(sender As Object, e As EventArgs) Handles BtnSetReminder.Click
        UpdateIsReminder(0, currentRemId)
        logStatus("Cancelled reminder", True)
        ClearForm()
        LoadReminders()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCustomer_Click(sender As Object, e As EventArgs) Handles BtnCustomer.Click
        Using _dialog As New FrmCustomerMaint
            _dialog.CustomerId = currentCustId
            _dialog.ShowDialog()
        End Using
        ClearForm()
        LoadReminders()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnJob_Click(sender As Object, e As EventArgs) Handles BtnJob.Click
        Using _dialog As New FrmJobMaint
            _dialog.TheJob = GetJobById(currentJobId)
            _dialog.ShowDialog()
        End Using
        ClearForm()
        LoadReminders()
    End Sub


End Class