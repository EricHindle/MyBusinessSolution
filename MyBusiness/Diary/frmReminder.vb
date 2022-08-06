' Hindleware
' Copyright (c) 2021,2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports MyBusiness.NetwyrksErrorCodes
Imports i00SpellCheck
''' <summary>
''' Form to create and amend user diary entries
''' </summary>
''' <remarks></remarks>
Public Class FrmReminder
#Region "Constants"
    Private Const REMINDER_TEXT As String = "Reminder"
    Private Const DIARY_TEXT As String = "Diary entry"
#End Region
#Region "Private variable instances"
    Private ReadOnly RECORD_TYPE As AuditUtil.RecordType = AuditUtil.RecordType.Reminder
    Private FORM_NAME As String = REMINDER_TEXT
#End Region
#Region "properties"
    Private _reminder As Reminder
    Private _customer As Customer
    Private _job As Job
    Public Property CurrentJob() As Job
        Get
            Return _job
        End Get
        Set(ByVal value As Job)
            _job = value
        End Set
    End Property
    Public Property CurrentCustomer() As Customer
        Get
            Return _customer
        End Get
        Set(ByVal value As Customer)
            _customer = value
        End Set
    End Property
    Public Property CurrentReminder() As Reminder
        Get
            Return _reminder
        End Get
        Set(ByVal value As Reminder)
            _reminder = value
        End Set
    End Property
#End Region
#Region "Form Handlers"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closed", FORM_NAME)
        My.Settings.ReminderFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        logutil.info("Starting", FORM_NAME)
        GetFormPos(Me, My.Settings.ReminderFormPos)
        dtpSelectDate.Value = Today
        lblFormName.Text = FORM_NAME
        lblName.Text = currentUser.UserName
        ClearForm()
        SpellCheckUtil.EnableSpellChecking({txtSubject, rtbBody})
        btnAdd.Visible = True
        If _reminder IsNot Nothing Then
            If _reminder.Diary_id > 0 Then
                FillForm()
                _customer = _reminder.LinkedCustomer
                _job = _reminder.LinkedJob
            End If
        End If

        If _customer IsNot Nothing Then
            lblCust.ForeColor = Color.Black
            LblCustName.Text = _customer.CustName
        End If
        If _job IsNot Nothing Then
            lblJob.ForeColor = Color.Black
            LblJobName.Text = _job.JobName
        End If
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
    Private Sub BtnSetComplete_Click(sender As Object, e As EventArgs) Handles btnSetComplete.Click
        Dim newValue As SByte = If(_reminder.IsClosed, 0, 1)
        UpdateReminderClosed(newValue, _reminder.Diary_id)
        _reminder.IsClosed = newValue
        FillForm()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkReminder_CheckedChanged(sender As Object, e As EventArgs) Handles chkReminder.CheckedChanged
        FORM_NAME = If(chkReminder.Checked, REMINDER_TEXT, DIARY_TEXT)
        lblFormName.Text = FORM_NAME
        lblRemDate.Text = FORM_NAME & " for"
    End Sub
    Private Sub ChkCallBack_CheckedChanged(sender As Object, e As EventArgs) Handles chkCallBack.CheckedChanged
        If chkCallBack.Checked Then
            dtpSelectDate.Format = DateTimePickerFormat.Custom
            dtpSelectDate.CustomFormat = "dd MMMM yyyy  HH:mm"
        Else
            dtpSelectDate.CustomFormat = vbLongDate
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim _diaryId As Integer
        Dim remFlag As Integer = If(chkReminder.Checked, 1, 0)
        Try
            _reminder = MakeReminderFromForm()
            _diaryId = CreateDiary(_reminder)

        Catch ex As Exception
            LogUtil.Exception(RECORD_TYPE & " creation exception", ex, FORM_NAME, getErrorCode(SystemModule.DIARY, ErrorType.DATABASE, FailedAction.CREATION_EXCEPTION))
            _diaryId = 0
        End Try
        If _diaryId > 0 Then
            AuditUtil.AddAudit(currentUser.User_code, RECORD_TYPE, _diaryId, AuditUtil.AuditableAction.create,, _reminder.ToString)
            LogStatus(RECORD_TYPE.ToString() & " " & txtSubject.Text & " added", True)
        Else
            logStatus(RECORD_TYPE.ToString() & " " & txtSubject.Text & " NOT added", True, TraceEventType.Warning)
        End If
        Me.Close()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim ct As Integer
        Dim recordId As Integer = _reminder.Diary_id
        Try
            ct = UpdateDiary(MakeReminderFromForm)
        Catch ex As Exception
            LogUtil.Exception(RECORD_TYPE & " update exception", ex, FORM_NAME, getErrorCode(SystemModule.DIARY, ErrorType.DATABASE, FailedAction.UPDATE_EXCEPTION))
            ct = 0
        End Try
        Dim _oldReminder As Reminder = _reminder
        _reminder = GetReminderById(recordId)
        If ct = 1 Then
            AuditUtil.AddAudit(currentUser.User_code, RECORD_TYPE, recordId, AuditUtil.AuditableAction.update, _oldReminder.ToString, _reminder.ToString)
            LogStatus(RECORD_TYPE.ToString() & " " & txtSubject.Text & " updated", True)
        Else
            logStatus(RECORD_TYPE.ToString() & " " & txtSubject.Text & " NOT updated", True, TraceEventType.Warning)
        End If
        Me.Close()
    End Sub

    Private Function MakeReminderFromForm() As Reminder
        Dim _rem As ReminderBuilder = ReminderBuilder.AReminder.StartingWith(_reminder)
        _rem.WithReminderDate(dtpSelectDate.Value) _
        .WithSubject(txtSubject.Text) _
        .WithBody(rtbBody.Text) _
        .WithIsReminder(chkReminder.Checked) _
        .WithClosed(False) _
        .WithCallBack(chkCallBack.Checked) _
        .WithCustomerId(If(_customer Is Nothing, -1, _customer.CustomerId)) _
        .WithJobId(If(_job Is Nothing, -1, _job.JobId))
        Return _rem.Build
    End Function
#End Region
#Region "Subroutines"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearForm()
        lblCust.ForeColor = Color.Silver
        lblJob.ForeColor = Color.Silver
        LblCustName.Text = ""
        LblJobName.Text = ""
        btnUpdate.Visible = False
        btnAdd.Visible = False
        btnSetComplete.Enabled = False
        lblOverdue.Visible = False
        lblReminder.Visible = False
        lblComplete.Visible = False
        txtSubject.Text = ""
        rtbBody.Text = ""
        chkReminder.Checked = True
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillForm()
        Dim isComplete As Boolean = _reminder.IsClosed
        txtSubject.Text = _reminder.Subject
        rtbBody.Text = _reminder.Body
        dtpSelectDate.Value = _reminder.ReminderDate
        lblReminder.Visible = _reminder.IsReminder
        lblComplete.Visible = isComplete
        lblOverdue.Visible = isComplete = False And _reminder.ReminderDate < Today.Date
        btnSetComplete.Enabled = True
        btnSetComplete.Text = If(isComplete, "Unset", "Mark as") & " Complete"
        btnAdd.Visible = False
        btnUpdate.Visible = True
        chkReminder.Checked = _reminder.IsReminder
        chkCallBack.Checked = _reminder.CallBack

    End Sub
    ''' <summary>
    ''' Display a message in the status bar and optionally log it
    ''' </summary>
    ''' <param name="sText"></param>
    ''' <param name="islogged"></param>
    ''' <param name="level"></param>
    ''' <remarks></remarks>
    Private Sub LogStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information)
        lblStatus.Text = sText
        If islogged Then LogUtil.addLog(sText, level, FORM_NAME)
    End Sub

#End Region
End Class