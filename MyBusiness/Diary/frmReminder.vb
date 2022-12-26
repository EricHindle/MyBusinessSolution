' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports MyBusiness.NetwyrksErrorCodes
Imports Org.BouncyCastle.Security.Certificates
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
        LogUtil.Info("Starting", FORM_NAME)
        GetFormPos(Me, My.Settings.ReminderFormPos)
        dtpSelectDate.Value = Today
        lblFormName.Text = FORM_NAME
        lblName.Text = currentUser.UserName
        ClearForm()
        SpellCheckUtil.EnableSpellChecking({txtSubject, rtbBody})
        PicAdd.Visible = True
        If _reminder Is Nothing Then
            _reminder = ReminderBuilder.AReminder.StartingWithNothing.Build
        End If
        If _reminder.Diary_id > 0 Then
            FillForm()
            _customer = _reminder.LinkedCustomer
            _job = _reminder.LinkedJob
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
    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        Close()
    End Sub
    Private Sub PicUpdate_Click(sender As Object, e As EventArgs) Handles PicUpdate.Click
        Dim ct As Integer
        Dim recordId As Integer = _reminder.Diary_id
        Try
            ct = UpdateDiary(MakeReminderFromForm)
        Catch ex As Exception
            LogUtil.Exception(RECORD_TYPE & " update exception", ex, FORM_NAME, GetErrorCode(SystemModule.DIARY, ErrorType.DATABASE, FailedAction.UPDATE_EXCEPTION))
            ct = 0
        End Try
        Dim _oldReminder As Reminder = _reminder
        _reminder = GetReminderById(recordId)
        If ct = 1 Then
            AuditUtil.AddAudit(currentUser.User_code, RECORD_TYPE, recordId, AuditUtil.AuditableAction.update, _oldReminder.ToString, _reminder.ToString)
            LogStatus(RECORD_TYPE.ToString() & " " & txtSubject.Text & " updated", True)
        Else
            LogStatus(RECORD_TYPE.ToString() & " " & txtSubject.Text & " NOT updated", True, TraceEventType.Warning)
        End If
        Close()

    End Sub
    Private Sub PicAdd_Click(sender As Object, e As EventArgs) Handles PicAdd.Click
        Dim _diaryId As Integer
        Dim remFlag As Integer = If(chkReminder.Checked, 1, 0)
        Try
            _reminder = MakeReminderFromForm()
            _diaryId = CreateDiary(_reminder)

        Catch ex As Exception
            LogUtil.Exception(RECORD_TYPE & " creation exception", ex, FORM_NAME, GetErrorCode(SystemModule.DIARY, ErrorType.DATABASE, FailedAction.CREATION_EXCEPTION))
            _diaryId = 0
        End Try
        If _diaryId > 0 Then
            AuditUtil.AddAudit(currentUser.User_code, RECORD_TYPE, _diaryId, AuditUtil.AuditableAction.create,, _reminder.ToString)
            LogStatus(RECORD_TYPE.ToString() & " " & txtSubject.Text & " added", True)
        Else
            LogStatus(RECORD_TYPE.ToString() & " " & txtSubject.Text & " NOT added", True, TraceEventType.Warning)
        End If
        Close()

    End Sub
    Private Sub PicToggleComplete_Click(sender As Object, e As EventArgs) Handles PicToggleComplete.Click
        _reminder.IsClosed = Not _reminder.IsClosed
        SetCompletePic()
        UpdateReminderClosed(_reminder.IsClosed, _reminder.Diary_id)
        FillForm()
    End Sub

    Private Sub SetCompletePic()
        If _reminder.IsClosed Then
            PicToggleComplete.Image = My.Resources.reopendiary
            ToolTip1.SetToolTip(PicToggleComplete, "Reopen diary entry")
        Else
            PicToggleComplete.Image = My.Resources.closediary
            ToolTip1.SetToolTip(PicToggleComplete, "Mark as complete")
        End If
    End Sub
#End Region
#Region "Subroutines"
    Private Sub ClearForm()
        lblCust.ForeColor = Color.Silver
        lblJob.ForeColor = Color.Silver
        LblCustName.Text = ""
        LblJobName.Text = ""
        PicUpdate.Visible = False
        PicAdd.Visible = False
        PicToggleComplete.Visible = False
        lblOverdue.Visible = False
        lblReminder.Visible = False
        lblComplete.Visible = False
        txtSubject.Text = ""
        rtbBody.Text = ""
        PicSetReminder.Image = My.Resources.setreminder
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
    Private Sub FillForm()
        Dim isComplete As Boolean = _reminder.IsClosed
        txtSubject.Text = _reminder.Subject
        rtbBody.Text = _reminder.Body
        dtpSelectDate.Value = _reminder.ReminderDate
        lblReminder.Visible = _reminder.IsReminder
        SetCompletePic()
        lblComplete.Visible = isComplete
        lblOverdue.Visible = _reminder.IsReminder And isComplete = False And _reminder.ReminderDate < Today.Date
        PicToggleComplete.Visible = True
        PicAdd.Visible = False
        PicUpdate.Visible = True
        chkReminder.Checked = _reminder.IsReminder
        chkCallBack.Checked = _reminder.CallBack
        SetReminderPic()
        SetCallbackPic()
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

    Private Sub PicSetReminder_Click(sender As Object, e As EventArgs) Handles PicSetReminder.Click
        _reminder.IsReminder = Not _reminder.IsReminder
        If _reminder.Diary_id > 0 Then
            UpdateIsReminder(_reminder.IsReminder, _reminder.Diary_id)
        End If
        SetReminderPic()
    End Sub

    Private Sub SetReminderPic()
        If _reminder.IsReminder Then
            FORM_NAME = REMINDER_TEXT
            PicSetReminder.Image = My.Resources.cancelreminder
            ToolTip1.SetToolTip(PicSetReminder, "Cancel reminder")
        Else
            FORM_NAME = DIARY_TEXT
            PicSetReminder.Image = My.Resources.setreminder
            ToolTip1.SetToolTip(PicSetReminder, "Set a reminder")
        End If
        lblFormName.Text = FORM_NAME
        lblRemDate.Text = FORM_NAME & " for"
        chkReminder.Checked = _reminder.IsReminder
        lblReminder.Visible = _reminder.IsReminder
    End Sub

    Private Sub PicSetCallback_Click(sender As Object, e As EventArgs) Handles PicSetCallback.Click
        _reminder.CallBack = Not _reminder.CallBack
        If _reminder.Diary_id > 0 Then
            UpdateCallback(_reminder.CallBack, _reminder.Diary_id)
        End If

        SetCallbackPic()
    End Sub

    Private Sub SetCallbackPic()
        chkCallBack.Checked = _reminder.CallBack
        If _reminder.CallBack Then
            dtpSelectDate.Format = DateTimePickerFormat.Custom
            dtpSelectDate.CustomFormat = "dd MMMM yyyy  HH:mm"
            ToolTip1.SetToolTip(PicSetCallback, "Cancel caLLback")
        Else
            dtpSelectDate.Format = DateTimePickerFormat.Long
            ToolTip1.SetToolTip(PicSetCallback, "Set callback required")
        End If
        PicSetCallback.Image = If(_reminder.CallBack, My.Resources.RmvCallback, My.Resources.PhoneCall)
        ToolTip1.SetToolTip(PicSetCallback, "")
    End Sub
#End Region
End Class