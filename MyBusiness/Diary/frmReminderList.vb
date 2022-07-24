' Hindleware
' Copyright (c) 2022, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class frmReminderList
#Region "variables"
    Private Const FORM_NAME As String = "reminders"
    Private Const DUE_REMINDERS As String = "due reminders"
    Private isLoading As Boolean = False
    Private ReadOnly dayOfWeek As Integer = Today.DayOfWeek
    Private dateSectionHeads As String() = Split(My.Resources.SectionHeads, "/")
    Private dateSectionEnds As Date() = {Today, DateAdd(DateInterval.Day, 1, Today), DateAdd(DateInterval.Day, 2, Today), DateAdd(DateInterval.Day, 8 - dayOfWeek, Today), DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Day, 14 - dayOfWeek, Today)), Date.MaxValue}
    Private dateSection As Integer = 0
    Private currentRemId As Integer = 0
    Private currentCustId As Integer = 0
    Private currentJobId As Integer = 0
#End Region
#Region "form control handlers"
    Private Sub Reminders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If dayOfWeek = 6 Then
            dateSectionHeads = Split(My.Resources.Day6SectionHeads, "/")
            dateSectionEnds = {Today, DateAdd(DateInterval.Day, 1, Today), DateAdd(DateInterval.Day, 2, Today), DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Day, 8, Today)), Date.MaxValue}
        End If
        lblFormName.Text = FORM_NAME
        ChkShowAll.Checked = My.Settings.ShowAllReminders
        ChkShowAtLogin.Checked = My.Settings.ShowRemindersAtLogin
        LoadReminders()
    End Sub
    Private Sub Reminders_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closed", FORM_NAME)
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub ChkShowAtLogin_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowAtLogin.CheckedChanged
        My.Settings.ShowRemindersAtLogin = ChkShowAtLogin.Checked
        My.Settings.Save()
    End Sub
    Private Sub ChkShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowAll.CheckedChanged
        lblFormName.Text = If(ChkShowAll.Checked, FORM_NAME, DUE_REMINDERS)
        My.Settings.ShowAllReminders = ChkShowAll.Checked
        My.Settings.Save()
        LoadReminders()
    End Sub
    Private Sub DgvReminders_SelectionChanged(sender As Object, e As EventArgs) Handles DgvReminders.SelectionChanged
        If Not isLoading Then
            ClearForm()
            If DgvReminders.SelectedRows.Count = 1 Then
                If DgvReminders.SelectedRows(0).Cells(remHeader.Name).Value = False Then
                    FillForm(DgvReminders.SelectedRows(0))
                End If
            End If
        End If
    End Sub
    Private Sub BtnCloseRem_Click(sender As Object, e As EventArgs) Handles BtnCloseRem.Click
        UpdateReminderClosed(1, currentRemId)
        LogStatus("Closed reminder", True)
        LoadReminders()
    End Sub
    Private Sub BtnSetReminder_Click(sender As Object, e As EventArgs) Handles BtnSetReminder.Click
        UpdateIsReminder(Not lblReminder.Visible, currentRemId)
        LogStatus("Updated reminder flag", True)
        LoadReminders()
    End Sub
    Private Sub BtnCustomer_Click(sender As Object, e As EventArgs) Handles BtnCustomer.Click
        Using _dialog As New FrmCustomerMaint
            _dialog.CustomerId = currentCustId
            _dialog.ShowDialog()
        End Using
        LoadReminders()
    End Sub
    Private Sub BtnJob_Click(sender As Object, e As EventArgs) Handles BtnJob.Click
        Using _dialog As New FrmJobMaint
            _dialog.TheJob = GetJobById(currentJobId)
            _dialog.ShowDialog()
        End Using
        LoadReminders()
    End Sub
#End Region
#Region "subroutines"
    Public Sub ClearForm()
        lblReminder.Visible = False
        txtSubject.Text = ""
        rtbBody.Text = ""
        BtnCloseRem.Visible = False
        BtnCustomer.Visible = False
        BtnJob.Visible = False
        currentRemId = 0
        LblCustName.Text = ""
        LblJobName.Text = ""
    End Sub
    Private Sub FillForm(ByVal oRow As DataGridViewRow)
        currentRemId = oRow.Cells(Me.remId.Name).Value
        Dim _reminder As Reminder = GetReminderById(currentRemId)
        With _reminder
            currentCustId = .CustomerId
            currentJobId = .JobId
            txtSubject.Text = .Subject
            rtbBody.Text = .Body
            BtnSetReminder.Text = If(.IsReminder, "Cancel Reminder", "Set Reminder")
            lblReminder.Visible = .IsReminder
            BtnCustomer.Visible = .HasCustomer
            BtnJob.Visible = .HasJob
            BtnCloseRem.Visible = .IsReminder
            LblCustName.Text = If(currentCustId > 0, _reminder.LinkedCustomer.CustName, "")
            LblJobName.Text = If(currentJobId > 0, _reminder.LinkedJob.JobName, "")
        End With
    End Sub
    Public Function LoadReminders() As Integer
        ClearForm()
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
            If oRow.Cells(Me.remHeader.Name).Value = False AndAlso oRow.Cells(remId.Name).Value = iSelectedId Then
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
                    If oRem.IsClosed Then
                        Continue For
                    End If
                    If ChkShowAll.Checked Or oRem.ReminderDate.Date <= Today.Date Then
                        Dim rRow As DataGridViewRow = Nothing
                        If isFirstRow Then
                            Dim oFirstRow As Reminder = _remList(0)
                            Dim firstRowdate As Date = oFirstRow.ReminderDate.Date
                            rRow = DgvReminders.Rows(DgvReminders.Rows.Add())
                            dateSection = GetNextSection(firstRowdate, rRow)
                            isFirstRow = False
                        End If
                        rRow = DgvReminders.Rows(DgvReminders.Rows.Add())
                        If oRem.ReminderDate.Date >= dateSectionEnds(dateSection).Date Then
                            dateSection = GetNextSection(oRem.ReminderDate.Date, rRow)
                            rRow = DgvReminders.Rows(DgvReminders.Rows.Add())
                        End If
                        rRow.Cells(remHeader.Name).Value = False
                        rRow.Cells(remId.Name).Value = oRem.Diary_id
                        rRow.Cells(remSubject.Name).Value = oRem.Subject
                        rRow.Cells(remDate.Name).Value = Format(oRem.ReminderDate, "dd/MM/yyyy")
                        rRow.Cells(remDate.Name).Style.ForeColor = Color.Gray
                        If oRem.CustomerId > 0 Then
                            rRow.Cells(remCustId.Name).Value = oRem.CustomerId
                        End If
                        If oRem.JobId > 0 Then
                            rRow.Cells(remJobId.Name).Value = oRem.JobId
                        End If
                        remCt += 1
                    End If
                Next
            End If
        Catch ex As Exception
            LogUtil.Exception("Error loading reminders", ex, "loadReminders")
        Finally
            isLoading = False
        End Try
        Return remCt
    End Function
    Private Sub LogStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information)
        LblStatus.Text = sText
        If islogged Then LogUtil.AddLog(sText, level, FORM_NAME)
    End Sub
    Private Sub ClearStatus()
        LogStatus("")
    End Sub
#End Region
End Class