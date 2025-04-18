﻿' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports HindlewareLib.Logging

Public Class FrmReminderList
    '
    ' Shows list of reminders (if any) for the current user at login
    '
#Region "variables"
    Private Const FORM_NAME As String = "reminders"
    Private Const DUE_REMINDERS As String = "due reminders"
    Private isLoading As Boolean = False
    Private ReadOnly dayOfWeek As Integer = Today.DayOfWeek
    Private dateSectionHeads As String() = Split(My.Resources.SectionHeads, "/")
    Private dateSectionEnds As Date() = {Today, DateAdd(DateInterval.Day, 1, Today), DateAdd(DateInterval.Day, 2, Today), DateAdd(DateInterval.Day, 8 - dayOfWeek, Today), DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Day, 14 - dayOfWeek, Today)), Date.MaxValue}
    Private dateSection As Integer = 0
    Private currentReminder As Reminder
#End Region
#Region "form control handlers"
    Private Sub Reminders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.ReminderListPos)
        If dayOfWeek = 6 Then
            dateSectionHeads = Split(My.Resources.Day6SectionHeads, "/")
            dateSectionEnds = {Today, DateAdd(DateInterval.Day, 1, Today), DateAdd(DateInterval.Day, 2, Today), DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Day, 8, Today)), Date.MaxValue}
        End If
        lblFormName.Text = FORM_NAME
        ChkShowAll.Checked = My.Settings.ShowAllReminders
        ChkShowAtLogin.Checked = My.Settings.ShowRemindersAtLogin
        currentReminder = ReminderBuilder.AReminder.StartingWithNothing.Build
    End Sub
    Private Sub Reminders_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closed", FORM_NAME)
        My.Settings.ReminderListPos = SetFormPos(Me)
        My.Settings.Save()
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

    Private Sub BtnCustomer_Click(sender As Object, e As EventArgs) Handles BtnCustomer.Click
        Using _dialog As New FrmCustomerMaint
            _dialog.CustomerId = currentReminder.LinkedCustomer.CustomerId
            _dialog.IsView = True
            _dialog.ShowDialog()
        End Using
        LoadReminders()
    End Sub
    Private Sub BtnJob_Click(sender As Object, e As EventArgs) Handles BtnJob.Click
        Using _dialog As New FrmJobMaint
            _dialog.TheJob = currentReminder.LinkedJob
            _dialog.IsView = True
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
        PicSetComplete.Visible = False
        PicToggleReminder.Visible = False
        BtnCustomer.Visible = False
        BtnJob.Visible = False
        'currentRemId = -1
        'currentCustId = -1
        'currentJobId = -1
        currentReminder = ReminderBuilder.AReminder.StartingWithNothing.Build
        LblCustName.Text = ""
        LblJobName.Text = ""
    End Sub
    Private Sub FillForm(ByVal oRow As DataGridViewRow)
        Dim _remid As String = oRow.Cells(remId.Name).Value
        If IsNumeric(_remid) Then
            Dim currentRemId As Integer = oRow.Cells(remId.Name).Value
            currentReminder = GetReminderById(currentRemId)
            With currentReminder
                'currentCustId = .CustomerId
                'currentJobId = .JobId
                txtSubject.Text = .Subject
                rtbBody.Text = .Body
                lblReminder.Visible = .IsReminder
                BtnCustomer.Visible = .HasCustomer
                BtnJob.Visible = .HasJob
                PicSetComplete.Visible = .Diary_id > 0
                PicToggleReminder.Visible = .Diary_id > 0
                PicSetComplete.Image = If(.IsClosed, My.Resources.reopendiary, My.Resources.closediary)
                PicToggleReminder.Image = If(.IsReminder, My.Resources.cancelreminder, My.Resources.setreminder)
                ToolTip1.SetToolTip(PicToggleReminder, If(.IsReminder, "Cancel reminder", "Set a reminder"))
                ToolTip1.SetToolTip(PicSetComplete, If(.IsClosed, "Reopen diary entry", "Mark as complete"))
                LblCustName.Text = currentReminder.LinkedCustomer.CustName
                LblJobName.Text = currentReminder.LinkedJob.JobName
            End With
        End If
    End Sub
    Public Function LoadReminders() As Integer
        '
        ' Called from login form
        '
        ClearForm()
        Dim iSelectedRow As Integer = 0
        Dim iSelectedId As Integer = -1
        If DgvReminders.SelectedRows.Count > 0 Then
            iSelectedRow = DgvReminders.SelectedRows(0).Index
            iSelectedId = DgvReminders.SelectedRows(0).Cells(remId.Name).Value
        End If
        Dim iTopRow As Integer = DgvReminders.FirstDisplayedScrollingRowIndex
        Dim iTopRowDiff As Integer = Math.Max(iSelectedRow - iTopRow, 0)
        Dim remCt As Integer = FillReminderTable()
        iSelectedRow = Math.Min(iSelectedRow, DgvReminders.Rows.Count - 1)
        For Each oRow As DataGridViewRow In DgvReminders.Rows
            If oRow.Cells(remHeader.Name).Value = False AndAlso oRow.Cells(remId.Name).Value = iSelectedId Then
                iSelectedRow = oRow.Index
            End If
        Next
        iTopRow = Math.Max(iSelectedRow - iTopRowDiff, 0)
        If DgvReminders.Rows.Count > 0 Then
            DgvReminders.Rows(iSelectedRow).Selected = True
            DgvReminders.FirstDisplayedScrollingRowIndex = iTopRow
            If DgvReminders.SelectedRows(0).Cells(remHeader.Name).Value = False Then
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
        rRow.Cells(remDate.Name).Value = dateSectionHeads(sectionNo)
        rRow.Cells(remDate.Name).Style.ForeColor = Color.Black
        rRow.Cells(remHeader.Name).Value = True
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
            _remList = GetRemindersForUser(currentUser.UserId, My.Settings.ShowCompletedDiaryEntries)
            If _remList.Count > 0 Then
                Dim isFirstRow As Boolean = True
                For Each oRem As Reminder In _remList
                    If oRem.IsClosed Then
                        Continue For
                    End If
                    If My.Settings.ShowAllReminders Or oRem.ReminderDate.Date <= Today.Date Then
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
    Private Sub ClearStatus()
        LogUtil.ClearStatus(LblStatus)
    End Sub
    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        Close()
    End Sub
    Private Sub PicAdd_Click(sender As Object, e As EventArgs) Handles PicToggleReminder.Click
        currentReminder.IsReminder = Not currentReminder.IsReminder
        UpdateIsReminder(currentReminder.IsReminder, currentReminder.Diary_id)
        LogUtil.ShowStatus("Updated reminder flag", LblStatus, Name)
        LoadReminders()
    End Sub
    Private Sub PicRemove_Click(sender As Object, e As EventArgs) Handles PicSetComplete.Click
        UpdateReminderClosed(True, currentReminder.Diary_id)
        LogUtil.ShowStatus("Closed reminder", LblStatus, Name)
        LoadReminders()
    End Sub
#End Region
End Class