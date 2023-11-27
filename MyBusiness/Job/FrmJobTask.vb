' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports HindlewareLib.Logging

Public Class FrmJobTask
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
        GetFormPos(Me, My.Settings.JobTaskFormPos)
        LoadTaskList()
        IsTasksLoaded = True
        IsTemplateTask = False
        IsLoading = True
        If _job IsNot Nothing Then
            _jobId = _job.JobId
            lblJobName.Text = _job.JobName
            LogUtil.Info("Job Task", Name)
        ElseIf _template IsNot Nothing Then
            _tmplId = _template.TemplateId
            lblJobName.Text = "Template: " & _template.TemplateName
            IsTemplateTask = True
            lblScreenName.Text = "Template Task"
            LogUtil.Info("Template Task", Name)
        Else
            ShowStatus(lblStatus, "No job/template selected", Name, True)
            MsgBox("Error: no job selected", MsgBoxStyle.Exclamation, "Error")
            Close()
        End If
        _jobtask = JobTaskBuilder.AJobTask.StartingWithNothing.Build
        ClearTaskDetails()
        rtbDescription.Enabled = False
        If _jobtaskId > 0 Then
            BtnAdd.Visible = False
            SetButtonVisibility(False)
            If IsTemplateTask Then
                _templateTask = GetTemplateTaskById(_jobtaskId)
                FillTaskDetails(JobTaskBuilder.AJobTask.StartingWith(_templateTask).Build)
                FillTemplateTaskDetails(_templateTask)
            Else
                _jobtask = GetJobTaskById(_jobtaskId)
                FillTaskDetails(_jobtask)
                FillJobTaskDetails(_jobtask)
            End If
        Else
            _jobtaskId = -1
            BtnAdd.Visible = True
            SetButtonVisibility(True)
        End If
        SpellCheckUtil.EnableSpellChecking({rtbDescription})
        IsLoading = False
    End Sub
    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        Close()
    End Sub
    Private Sub FrmTask_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", Name)
        My.Settings.JobTaskFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub PicUpdate_Click(sender As Object, e As EventArgs) Handles PicUpdate.Click
        _newJobTask = CreateNewJobTaskFromForm()
        If IsTemplateTask Then
            _newTemplateTask = TemplateTaskBuilder.ATemplateTask.StartingWith(_newJobTask).WithTemplateId(_tmplId).Build
            AmendTemplateTask()
        Else
            AmendJobTask()
        End If
        Close()
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Using _taskForm As New FrmTasks
            _taskForm.ShowDialog()
            _taskId = _taskForm.TaskId
        End Using
        LoadTaskList()
    End Sub
    Private Sub CbTask_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbTask.SelectedIndexChanged
        If Not IsLoading Then
            If IsTasksLoaded AndAlso CbTask.SelectedIndex > -1 Then
                _taskId = CbTask.SelectedValue
                _task = GetTaskById(_taskId)
                rtbDescription.Text = _task.TaskDescription
                Dim _existingId As Integer
                If IsTemplateTask Then
                    Dim _existingTemplateTask As TemplateTask = GetTemplateTaskByTemplateAndTask(_template.TemplateId, _taskId)
                    FillTemplateTaskDetails(_existingTemplateTask)
                    _existingId = _existingTemplateTask.TemplateTaskId
                Else
                    Dim _existingJobTask As JobTask = GetJobTaskByJobAndTask(_jobId, _taskId)
                    FillJobTaskDetails(_existingJobTask)
                    _existingId = _existingJobTask.JobTaskId
                End If
                _jobtaskId = _existingId
                SetButtonVisibility(_existingId < 0)
            Else
                rtbDescription.Text = String.Empty
                _taskId = -1
                _task = TaskBuilder.ATask.StartingWithNothing.Build
            End If
        End If
    End Sub
    Private Sub PicAdd_Click(sender As Object, e As EventArgs) Handles PicAdd.Click
        If CbTask.SelectedIndex > -1 Then
            _newJobTask = CreateNewJobTaskFromForm()
            If IsTemplateTask Then
                _newTemplateTask = TemplateTaskBuilder.ATemplateTask.StartingWith(_newJobTask).WithTemplateId(_tmplId).Build
                CreateTemplateTask()
            Else
                CreateJobTask()
            End If
            Close()
        Else
            ShowStatus(lblStatus, "Missing values. No action")
        End If
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
    Private Sub FillTaskDetails(pJobTask As JobTask)
        With pJobTask
            _task = .Task
            _taskId = _task.TaskId
            CbTask.SelectedValue = _taskId
            rtbDescription.Text = .Task.TaskDescription
        End With
    End Sub
    Private Sub FillJobTaskDetails(pJobTask As JobTask)
        With pJobTask
            nudCost.Value = .TaskCost
            nudTime.Value = .TaskHours
            dtpStartDate.Value = If(.TaskStartDue Is Nothing, Now.Date, CDate(.TaskStartDue).Date)
            chkStarted.Checked = .IsTaskStarted
            chkCompleted.Checked = .IstaskCompleted
            chkTaxable.Checked = .IsTaskTaxable
            nudTaxRate.Value = .TaskTaxRate
        End With
    End Sub
    Private Sub FillTemplateTaskDetails(pTemplateTask As TemplateTask)
        With pTemplateTask
            nudCost.Value = .Cost
            nudTime.Value = .Hours
            chkTaxable.Checked = .IsTaskTaxable
            nudTaxRate.Value = .TaxRate
        End With
    End Sub
    Private Sub ClearTaskDetails()
        rtbDescription.Text = ""
        nudCost.Value = 0
        nudTime.Value = 0
        dtpStartDate.Value = Today.Date
        chkStarted.Checked = False
        chkCompleted.Checked = False
        CbTask.SelectedIndex = -1
        _task = TaskBuilder.ATask.StartingWithNothing.Build
        _taskId = -1
    End Sub
    Private Function AmendJobTask() As Boolean
        LogUtil.Info("Updating job task", Name)
        Dim _ct As Integer
        _ct = UpdateJobTask(_newJobTask)
        AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.JobTask, _newJobTask.JobTaskId, AuditUtil.AuditableAction.create, _jobtask.ToString, _newJobTask.ToString)
        Dim isAmendOk As Boolean
        If _ct = 1 Then
            isAmendOk = True
            ShowStatus(lblStatus, "Job Task updated OK", Name, True)
        Else
            isAmendOk = False
            ShowStatus(lblStatus, "Job Task NOT updated", Name, True)
        End If
        Return isAmendOk
    End Function
    Private Function AmendTemplateTask() As Boolean
        LogUtil.Info("Updating template task", Name)
        Dim _ct As Integer
        _ct = UpdateTemplateTask(_newTemplateTask)
        AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.TemplateTask, _newTemplateTask.TemplateTaskId, AuditUtil.AuditableAction.create, _templateTask.ToString, _newTemplateTask.ToString)
        Dim isAmendOk As Boolean
        If _ct = 1 Then
            isAmendOk = True
            ShowStatus(lblStatus, "Template Task updated OK", Name, True)
        Else
            isAmendOk = False
            ShowStatus(lblStatus, "Template Task NOT updated", Name, True)
        End If
        Return isAmendOk
    End Function
    Private Function CreateJobTask() As Boolean
        Dim isInsertOk As Boolean
        LogUtil.Info("Inserting job task", Name)
        _jobtaskId = InsertJobTask(_newJobTask)
        AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.JobTask, _jobtaskId, AuditUtil.AuditableAction.create, "", _newJobTask.ToString)
        If _jobtaskId > 0 Then
            isInsertOk = True
            ShowStatus(lblStatus, "Job Task " & _jobtaskId & " Created OK", Name, True)
        Else
            isInsertOk = False
            ShowStatus(lblStatus, "Job Task NOT created", Name, True)
        End If
        Return isInsertOk
    End Function
    Private Function CreateTemplateTask() As Boolean
        Dim isInsertOk As Boolean
        LogUtil.Info("Inserting template task", Name)
        _jobtaskId = InsertTemplatetask(_newTemplateTask)
        AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.TemplateTask, _jobtaskId, AuditUtil.AuditableAction.create, "", _newTemplateTask.ToString)
        If _jobtaskId > 0 Then
            isInsertOk = True
            ShowStatus(lblStatus, "Template Task " & _jobtaskId & " Created OK", Name, True)
        Else
            isInsertOk = False
            ShowStatus(lblStatus, "Template Task NOT created", Name, True)
        End If
        Return isInsertOk
    End Function
    Private Function CreateNewJobTaskFromForm() As JobTask
        Return JobTaskBuilder.AJobTask.WithTask(_task) _
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
    End Function
    Private Sub SetButtonVisibility(IsAddVisible As Boolean)
        PicAdd.Visible = IsAddVisible
        PicUpdate.Visible = Not IsAddVisible
    End Sub
#End Region
End Class