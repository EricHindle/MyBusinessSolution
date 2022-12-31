' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmTask
#Region "variables"
    Private _jobId As Integer
    Private _job As Job
    Private _tmplId As Integer
    Private _template As Template
    Private _taskId As Integer
    Private _task As Task
    Private _newTask As Task
    Private _templateTask As TemplateTask
    Private _newTemplateTask As TemplateTask
    Private IsLoading As Boolean = False
    Private IsTemplateTask As Boolean

#End Region
#Region "properties"
    Public Property Template() As Template
        Get
            Return _template
        End Get
        Set(ByVal value As Template)
            _template = value
        End Set
    End Property
    Public Property CustomerJob() As Job
        Get
            Return _job
        End Get
        Set(ByVal value As Job)
            _job = value
        End Set
    End Property
    Public Property TaskId() As Integer
        Get
            Return _taskId
        End Get
        Set(ByVal value As Integer)
            _taskId = value
        End Set
    End Property
#End Region
#Region "form handlers"
    Private Sub FrmTask_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LogUtil.Info("Starting", Name)
        GetFormPos(Me, My.Settings.TaskFormPos)
        IsLoading = True
        IsTemplateTask = False
        If _job IsNot Nothing Then
            _jobId = _job.JobId
            lblJobName.Text = _job.JobName
            LogUtil.Info("Job Task", Name)
        ElseIf _template IsNot Nothing Then
            _tmplId = _template.TemplateId
            lblJobName.Text = "Template: " & _template.TemplateName
            IsTemplateTask = True
            LogUtil.Info("Template Task", Name)
        Else
            ShowStatus(lblStatus, "No job selected", Name, True)
            MsgBox("Error: no job selected", MsgBoxStyle.Exclamation, "Error")
            Close()
        End If
        _task = TaskBuilder.ATask.StartingWithNothing.Build
        If _taskId > 0 Then
            If IsTemplateTask Then
                _templateTask = GetTemplateTaskById(_taskId)
                FillTaskDetails(_templateTask)
            Else
                _task = GetTaskById(_taskId)
                FillTaskDetails(_task)
            End If
        Else
            NewTask()
            _taskId = -1
        End If
        SpellCheckUtil.EnableSpellChecking({rtbDescription})
        IsLoading = False
    End Sub
    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        Close()
    End Sub
    Private Sub FrmTask_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", Name)
        My.Settings.TaskFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub PicUpdate_Click(sender As Object, e As EventArgs) Handles PicUpdate.Click
        If Not String.IsNullOrEmpty(txtTaskName.Text) Then
            _newTask = TaskBuilder.ATask.WithTaskName(txtTaskName.Text.Trim) _
                                        .WithTaskDescription(rtbDescription.Text.Trim) _
                                        .WithTaskCost(nudCost.Value) _
                                        .WithTaskTime(nudTime.Value) _
                                        .WithTaskCompleted(chkCompleted.Checked) _
                                        .WithTaskStartDue(dtpStartDate.Value.Date) _
                                        .WithTaskStarted(chkStarted.Checked) _
                                        .WithTaskCreated(_task.TaskCreated) _
                                        .WithTaskChanged(_task.TaskChanged) _
                                        .WithTaskJobId(_jobId) _
                                        .WithTaskTaxable(chkTaxable.Checked) _
                                        .WithTaskTaxRate(nudTaxRate.Value) _
                                        .WithTaskId(_taskId) _
                                        .Build()
            _newTemplateTask = TemplateTaskBuilder.ATemplateTask.StartingWith(_newTask).WithTemplateId(_tmplId).Build
            If _taskId > 0 Then
                Amendtask()
            Else
                CreateTask()
            End If

            Close()
        Else
            ShowStatus(lblStatus, "Missing values. No action")
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub FillTaskDetails(pTask As Task)
        With pTask
            txtTaskName.Text = .TaskName
            rtbDescription.Text = .TaskDescription
            nudCost.Value = .TaskCost
            nudTime.Value = .TaskHours
            dtpStartDate.Value = If(.TaskStartDue Is Nothing, Now.Date, CDate(.TaskStartDue).Date)
            chkStarted.Checked = .IsTaskStarted
            chkCompleted.Checked = .IstaskCompleted
            chkTaxable.Checked = .IsTaskTaxable
            nudTaxRate.Value = .TaskTaxRate
        End With
        LogUtil.Info("Existing task " & _taskId, Name)
    End Sub
    Private Sub FillTaskDetails(pTemplateTask As TemplateTask)
        FillTaskDetails(TaskBuilder.ATask.StartingWith(pTemplateTask).Build)
    End Sub
    Private Sub ClearTaskDetails()
        txtTaskName.Text = ""
        rtbDescription.Text = ""
        nudCost.Value = 0
        nudTime.Value = 0
        dtpStartDate.Value = Today.Date
        chkStarted.Checked = False
        chkCompleted.Checked = False
    End Sub
    Private Sub NewTask()
        LogUtil.Info("New task", Name)
        ClearTaskDetails()
    End Sub
    Private Function Amendtask() As Boolean
        Dim isAmendOk As Boolean = False
        LogUtil.Info("Updating task", Name)
        With _newTask
            Dim _ct As Integer
            If IsTemplateTask Then
                _ct = UpdateTemplateTask(_newTemplateTask)
            Else
                _ct = UpdateTask(_newTask)
                AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Task, .TaskId, AuditUtil.AuditableAction.create, _task.ToString, .ToString)
            End If
            If _ct = 1 Then
                isAmendOk = True
                ShowStatus(lblStatus, "Task updated OK", Name, True)
            Else
                isAmendOk = False
                ShowStatus(lblStatus, "Task NOT updated", Name, True)
            End If
        End With
        Return isAmendOk
    End Function
    Private Function CreateTask() As Boolean
        Dim isInsertOk As Boolean
        LogUtil.Info("Inserting task", Name)
        With _newTask
            If IsTemplateTask Then
                _taskId = InsertTemplatetask(_newTemplateTask)
            Else
                _taskId = InsertTask(_newTask)
            End If
            If _taskId > 0 Then
                AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Task, _taskId, AuditUtil.AuditableAction.create, "", .ToString)
                isInsertOk = True
                ShowStatus(lblStatus, "Task " & _taskId & " Created OK", Name, True)
            Else
                isInsertOk = False
                ShowStatus(lblStatus, "Task NOT created", Name, True)
            End If
        End With
        Return isInsertOk
    End Function
#End Region
End Class