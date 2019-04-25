'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports MyBusiness.netwyrksErrorCodes
''' <summary>
''' Form to create and amend user diary entries
''' </summary>
''' <remarks></remarks>
Public Class frmReminder

#Region "Constants"
    Private Const REMINDER_TEXT As String = "Reminder"
    Private Const DIARY_TEXT As String = "Diary entry"
#End Region
#Region "Private variable instances"
    Private RECORD_TYPE As AuditUtil.RecordType = AuditUtil.RecordType.Reminder
    Private FORM_NAME As String = REMINDER_TEXT
    Private oDiaryTa As New netwyrksDataSetTableAdapters.diaryTableAdapter
    Private oDiaryTable As New netwyrksDataSet.diaryDataTable
    Private oUserTa As New netwyrksDataSetTableAdapters.userTableAdapter
    Private user As netwyrksIIdentity = My.User.CurrentPrincipal.Identity
    Private userId As Integer = user.userId
    Private reminderId As Integer = 0
#End Region
#Region "properties"
    Private _customer As Customer
    Private _reminder As Reminder
    Private _job As job
    Private _isReminder As Boolean
    Public Property isReminder() As Boolean
        Get
            Return _isReminder
        End Get
        Set(ByVal value As Boolean)
            _isReminder = value
        End Set
    End Property
    Public Property theReminder() As Reminder
        Get
            Return _reminder
        End Get
        Set(ByVal value As Reminder)
            _reminder = value
        End Set
    End Property

#End Region
#Region "Form"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oDiaryTa.Dispose()
        oDiaryTable.Dispose()
        oUserTa.Dispose()
        LogUtil.Debug("Closed", FORM_NAME)
    End Sub

    Private Sub form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Starting", FORM_NAME)
        dtpSelectDate.Value = Today
        lblFormName.Text = FORM_NAME
        'lblName.Text = AuthenticationUtil.getUserName(userId)
        lblName.Text = currentUser.userName
        clearForm()
        If _reminder IsNot Nothing Then
            BuildReferences()
        End If
        If _reminder IsNot Nothing AndAlso _reminder.diary_id > 0 Then
            fillForm()
            btnAdd.Visible = False
            btnUpdate.Visible = True
        Else
            If _customer IsNot Nothing Then
                txtSubject.Text = "Customer " & CStr(_customer.customerId) & " : " & _customer.custName
            End If
            btnAdd.Visible = True
            btnUpdate.Visible = False
        End If
        If _customer IsNot Nothing Then lblCust.ForeColor = Color.Black
        If _job IsNot Nothing Then lblJob.ForeColor = Color.Black
        chkReminder.Checked = isReminder
    End Sub

    Private Sub BuildReferences()

        If _reminder.customerId > 0 Then
            _customer = CustomerBuilder.aCustomer.startingWith(_reminder.customerId).build
        End If
        If _reminder.jobId > 0 Then
            _job = jobBuilder.aJobBuilder.startingWith(_reminder.jobId).build
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSetComplete_Click(sender As Object, e As EventArgs) Handles btnSetComplete.Click
        Dim isComplete As Boolean = _reminder.isClosed
        Dim newValue As Integer = If(isComplete, 0, 1)
        oDiaryTa.UpdateClosed(newValue, _reminder.diary_id)
        getReminder(_reminder.diary_id)

        fillForm()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearForm()
        lblCust.ForeColor = Color.Silver
        lblJob.ForeColor = Color.Silver
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
    Private Sub fillForm()
        Dim isComplete As Boolean = _reminder.isClosed
        Dim isAreminder As Boolean = _reminder.isReminder
        txtSubject.Text = _reminder.subject
        rtbBody.Text = _reminder.body
        dtpSelectDate.Value = _reminder.reminderDate
        lblReminder.Visible = isAreminder
        lblComplete.Visible = isComplete
        lblOverdue.Visible = isComplete = False And _reminder.reminderDate < Today.Date
        btnSetComplete.Enabled = True
        btnSetComplete.Text = If(isComplete, "Unset", "Set") & " Complete"
        btnAdd.Visible = False
        btnUpdate.Visible = True
        chkReminder.Checked = _reminder.isReminder
        chkCallBack.Checked = _reminder.callBack
    End Sub

#End Region
#Region "Create Update Delete"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim _diaryId As Integer = 0
        Dim custId As Integer? = Nothing
        Dim jobId As Integer? = Nothing

        If _customer IsNot Nothing Then
            custId = _customer.customerId
        End If

        If _job IsNot Nothing Then
            jobId = _job.jobId
        End If

        Dim remFlag As Integer = If(chkReminder.Checked, 1, 0)
        Try
            reminderId = oDiaryTa.InsertDiary(dtpSelectDate.Value, txtSubject.Text, rtbBody.Text, remFlag, 0, chkCallBack.Checked, userId, jobId, custId)
            _diaryId = getReminder(reminderId)
        Catch ex As Exception
            LogUtil.Exception(RECORD_TYPE & " creation exception", ex, FORM_NAME, getErrorCode(SystemModule.DIARY, ErrorType.DATABASE, FailedAction.CREATION_EXCEPTION))
            _diaryId = 0
        End Try
        If _diaryId > 0 Then
            AuditUtil.addAudit(currentUser.userId, RECORD_TYPE, _diaryId, AuditUtil.AuditableAction.create,, _reminder.ToString)
            logStatus(RECORD_TYPE.ToString() & " " & txtSubject.Text & " added", True)
        Else
            logStatus(RECORD_TYPE.ToString() & " " & txtSubject.Text & " NOT added", True, TraceEventType.Warning)
        End If

        fillForm()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim ct As Integer = 0
        Dim recordId As Integer = _reminder.diary_id
        Dim custId As Integer? = Nothing
        Dim jobId As Integer? = Nothing

        If _customer IsNot Nothing Then
            custId = _customer.customerId
        End If
        If _job IsNot Nothing Then
            jobId = _job.jobId
        End If
        Dim remFlag As Integer = If(chkReminder.Checked, 1, 0)
        Try
            ct = oDiaryTa.UpdateDiary(dtpSelectDate.Value, txtSubject.Text, rtbBody.Text, remFlag, _reminder.isClosed, chkCallBack.Checked, userId, jobId, custId, recordId)
        Catch ex As Exception
            LogUtil.Exception(RECORD_TYPE & " update exception", ex, FORM_NAME, getErrorCode(SystemModule.DIARY, ErrorType.DATABASE, FailedAction.UPDATE_EXCEPTION))
            ct = 0
        End Try
        Dim _oldReminder As Reminder = _reminder
        getReminder(recordId)
        If ct = 1 Then
            AuditUtil.addAudit(currentUser.userId, RECORD_TYPE, recordId, AuditUtil.AuditableAction.update, _oldReminder.ToString, _reminder.ToString)
            logStatus(RECORD_TYPE.ToString() & " " & txtSubject.Text & " updated", True)
        Else
            logStatus(RECORD_TYPE.ToString() & " " & txtSubject.Text & " NOT updated", True, TraceEventType.Warning)
        End If

        fillForm()
    End Sub
#End Region
#Region "Subroutines"
    ''' <summary>
    ''' Display a message in the status bar and optionally log it
    ''' </summary>
    ''' <param name="sText"></param>
    ''' <param name="islogged"></param>
    ''' <param name="level"></param>
    ''' <remarks></remarks>
    Private Sub logStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information)
        lblStatus.Text = sText
        If islogged Then LogUtil.addLog(sText, level, FORM_NAME)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="reminderId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getReminder(ByVal reminderId As Integer)
        _reminder = ReminderBuilder.aReminder.startingWith(reminderId).build
        Return _reminder.diary_id
    End Function
#End Region
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkReminder_CheckedChanged(sender As Object, e As EventArgs) Handles chkReminder.CheckedChanged
        FORM_NAME = If(chkReminder.Checked, REMINDER_TEXT, DIARY_TEXT)
        lblFormName.Text = FORM_NAME
        lblRemDate.Text = FORM_NAME & " for"
    End Sub

    Private Sub chkCallBack_CheckedChanged(sender As Object, e As EventArgs) Handles chkCallBack.CheckedChanged
        If chkCallBack.Checked Then
            dtpSelectDate.Format = DateTimePickerFormat.Custom
            dtpSelectDate.CustomFormat = "dd MMMM yyyy  HH:mm"
        End If
    End Sub
End Class