' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports HindlewareLib.Logging

Public Class FrmTask
#Region "variables"
    Private _jobId As Integer
    Private _job As Job
    Private _taskId As Integer
    Private _task As Task
    Private _tmplId As Integer
    Private _template As Template
    Private _jobtaskId As Integer
    Private _jobtask As JobTask
    Private _newJobTask As JobTask
    Private _templateTask As TemplateTask
    Private _newTemplateTask As TemplateTask
    Private IsLoading As Boolean = False
    Private IsTemplateTask As Boolean
    Private IsTasksLoaded As Boolean = False
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
    Public Property JobTaskId() As Integer
        Get
            Return _jobtaskId
        End Get
        Set(ByVal value As Integer)
            _jobtaskId = value
        End Set
    End Property
#End Region
#Region "form handlers"
    Private Sub FrmTask_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LogUtil.Info("Starting", Name)
        GetFormPos(Me, My.Settings.TaskFormPos)
        LoadTaskList()
        IsTasksLoaded = True
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
        _jobtask = JobTaskBuilder.AJobTask.StartingWithNothing.Build
        ClearTaskDetails()
        If _jobtaskId > 0 Then
            CbTask.Enabled = False
            rtbDescription.Enabled = False
            txtTaskName.Visible = False
            BtnAdd.Visible = False
            PicUpdate.Visible = True
            PicAdd.Visible = False
            If IsTemplateTask Then
                _templateTask = GetTemplateTaskById(_jobtaskId)
                FillTaskDetails(_templateTask)
            Else
                _jobtask = GetJobTaskById(_jobtaskId)
                FillTaskDetails(_jobtask)
            End If
        Else
            _jobtaskId = -1
            CbTask.Enabled = True
            rtbDescription.Enabled = False
            txtTaskName.Visible = False
            BtnAdd.Visible = True
            PicUpdate.Visible = False
            PicAdd.Visible = True
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
            CreateNewJobTaskFromForm()
            _newTemplateTask = TemplateTaskBuilder.ATemplateTask.StartingWith(_newJobTask).WithTemplateId(_tmplId).Build
            Amendtask()
            Close()
        Else
            ShowStatus(lblStatus, "Missing values. No action")
        End If
    End Sub

    Private Sub CreateNewJobTaskFromForm()
        _newJobTask = JobTaskBuilder.AJobTask.WithTask(_task) _
                                    .WithTaskCost(nudCost.Value) _
                                    .WithTaskTime(nudTime.Value) _
                                    .WithTaskCompleted(chkCompleted.Checked) _
                                    .WithTaskStartDue(dtpStartDate.Value.Date) _
                                    .WithTaskStarted(chkStarted.Checked) _
                                    .WithTaskCreated(_jobtask.TaskCreated) _
                                    .WithTaskChanged(_jobtask.TaskChanged) _
                                    .WithTaskJobId(_jobId) _
                                    .WithTaskTaxable(chkTaxable.Checked) _
                                    .WithTaskTaxRate(nudTaxRate.Value) _
                                    .WithJobTaskId(_jobtaskId) _
                                    .Build()
    End Sub
    Private Sub CreateTaskFromForm()
        _task = TaskBuilder.ATask.StartingWithNothing _
                            .WithTaskName(txtTaskName.Text) _
                            .WithTaskDescription(rtbDescription.Text) _
                            .Build
    End Sub
#End Region
#Region "subroutines"
    Private Sub LoadTaskList()
        Dim oTaskTa As New netwyrksDataSetTableAdapters.taskTableAdapter
        Dim oTaskTable As netwyrksDataSet.taskDataTable = oTaskTa.GetData()
        CbTask.DataSource = oTaskTable
        CbTask.ValueMember = "taskid"
        CbTask.DisplayMember = "task_name"
    End Sub
    Private Sub FillTaskDetails(pTask As JobTask)
        With pTask
            _task = pTask.Task
            _taskId = _task.TaskId
            CbTask.SelectedValue = pTask.TaskId
            txtTaskName.Text = .Task.TaskName
            rtbDescription.Text = .Task.TaskDescription
            nudCost.Value = .TaskCost
            nudTime.Value = .TaskHours
            dtpStartDate.Value = If(.TaskStartDue Is Nothing, Now.Date, CDate(.TaskStartDue).Date)
            chkStarted.Checked = .IsTaskStarted
            chkCompleted.Checked = .IstaskCompleted
            chkTaxable.Checked = .IsTaskTaxable
            nudTaxRate.Value = .TaskTaxRate
        End With
        LogUtil.Info("Existing task " & _jobtaskId, Name)
    End Sub
    Private Sub FillTaskDetails(pTemplateTask As TemplateTask)
        FillTaskDetails(JobTaskBuilder.AJobTask.StartingWith(pTemplateTask).Build)
    End Sub
    Private Sub ClearTaskDetails()
        txtTaskName.Text = ""
        rtbDescription.Text = ""
        nudCost.Value = 0
        nudTime.Value = 0
        dtpStartDate.Value = Today.Date
        chkStarted.Checked = False
        chkCompleted.Checked = False
        txtTaskName.Visible = False
        CbTask.SelectedIndex = -1
        _task = TaskBuilder.ATask.StartingWithNothing.Build
        _taskId = -1
    End Sub
    Private Sub NewTask()
        LogUtil.Info("New task", Name)
        ClearTaskDetails()
    End Sub
    Private Function Amendtask() As Boolean
        Dim isAmendOk As Boolean = False
        LogUtil.Info("Updating task", Name)
        With _newJobTask
            Dim _ct As Integer
            If IsTemplateTask Then
                _ct = UpdateTemplateTask(_newTemplateTask)
            Else
                _ct = UpdateJobTask(_newJobTask)
                AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Task, .JobTaskId, AuditUtil.AuditableAction.create, _jobtask.ToString, .ToString)
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
        With _newJobTask
            If IsTemplateTask Then
                _jobtaskId = InsertTemplatetask(_newTemplateTask)
            Else
                _jobtaskId = InsertJobTask(_newJobTask)
            End If
            If _jobtaskId > 0 Then
                AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Task, _jobtaskId, AuditUtil.AuditableAction.create, "", .ToString)
                isInsertOk = True
                ShowStatus(lblStatus, "Task " & _jobtaskId & " Created OK", Name, True)
            Else
                isInsertOk = False
                ShowStatus(lblStatus, "Task NOT created", Name, True)
            End If
        End With
        Return isInsertOk
    End Function

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        txtTaskName.Visible = True
        CbTask.SelectedIndex = -1
        CbTask.Visible = False
        rtbDescription.Enabled = True
        BtnAdd.Visible = False
    End Sub

    Private Sub CbTask_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbTask.SelectedIndexChanged
        If IsTasksLoaded AndAlso CbTask.SelectedIndex > -1 Then
            _taskId = CbTask.SelectedValue
            _task = GetTaskById(_taskId)
            txtTaskName.Text = _task.TaskName
            rtbDescription.Text = _task.TaskDescription
        Else
            txtTaskName.Text = String.Empty
            rtbDescription.Text = String.Empty
            _taskId = -1
            _task = TaskBuilder.ATask.StartingWithNothing.Build
        End If
    End Sub

    Private Sub PicAdd_Click(sender As Object, e As EventArgs) Handles PicAdd.Click
        If Not String.IsNullOrEmpty(txtTaskName.Text) Then
            CreateTaskFromForm()
            If _taskId < 0 Then
                _taskId = InsertTask(_task)
                _task.TaskId = _taskId
            End If
            CreateNewJobTaskFromForm()
            _newTemplateTask = TemplateTaskBuilder.ATemplateTask.StartingWith(_newJobTask).WithTemplateId(_tmplId).Build

            CreateTask()
            Close()
        Else
            ShowStatus(lblStatus, "Missing values. No action")
        End If
    End Sub
#End Region
End Class