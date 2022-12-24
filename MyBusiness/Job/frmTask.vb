' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmTask
#Region "variables"
    Private _taskbuilder As TaskBuilder
    Private _taskId As Integer
    Private _task As Task
    Private _jobId As Integer
    Private _job As Job
    Private _newTask As Task
    Private isLoading As Boolean = False
    Private ReadOnly oTaskTa As New netwyrksDataSetTableAdapters.taskTableAdapter
    Private ReadOnly oTaskTable As New netwyrksDataSet.taskDataTable
#End Region
#Region "properties"
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
    'Public Property Thetask() As TaskBuilder
    '    Get
    '        Return _taskbuilder
    '    End Get
    '    Set(ByVal value As TaskBuilder)
    '        _taskbuilder = value
    '    End Set
    'End Property
#End Region
#Region "form handlers"

    Private Sub FrmTask_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        logutil.info("Closing", Name)
        oTaskTa.Dispose()
        oTaskTable.Dispose()
    End Sub
    Private Sub FrmTask_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logutil.info("Starting", Name)
        isLoading = True
        If _job IsNot Nothing Then
            _jobId = _job.JobId
            lblJobName.Text = _job.JobName
        Else
            MsgBox("Error: no job selected", MsgBoxStyle.Exclamation, "Error")
            showStatus(lblStatus, "No job selected", Name, True)
        End If
        If _taskId > 0 Then
            _taskbuilder = TaskBuilder.ATask.StartingWith(_taskId)
            _task = _taskbuilder.Build
            FillTaskDetails()
        Else
            NewTask()
            _taskId = -1
        End If
        SpellCheckUtil.EnableSpellChecking({rtbDescription})
        isLoading = False
    End Sub
    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        Close()
    End Sub
    Private Sub PicUpdate_Click(sender As Object, e As EventArgs) Handles PicUpdate.Click
        With _taskbuilder.Build
            _newTask = TaskBuilder.ATask.WithTaskName(txtTaskName.Text.Trim) _
            .WithTaskDescription(rtbDescription.Text.Trim) _
            .WithTaskCost(nudCost.Value) _
            .WithTaskTime(nudTime.Value) _
            .WithTaskCompleted(chkCompleted.Checked) _
            .WithTaskStartDue(dtpStartDate.Value.Date) _
            .WithTaskStarted(chkStarted.Checked) _
            .WithTaskCreated(.TaskCreated) _
            .WithTaskChanged(.TaskChanged) _
            .WithTaskJobId(_jobId) _
            .WithTaskTaxable(chkTaxable.Checked) _
            .WithTaskTaxRate(nudTaxRate.Value) _
            .WithTaskId(_taskId) _
            .Build()
        End With
        Dim newtaskId As Integer = -1
        If _taskId > 0 Then
            Amendtask()
        Else
            CreateTask()
        End If
        Close()

    End Sub
#End Region
#Region "subroutines"
    Private Sub FillTaskDetails()
        With _task
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
        LogUtil.Info("New task", Name())
        ClearTaskDetails()
        _taskbuilder = TaskBuilder.ATask.StartingWithNothing
    End Sub
    Private Function Amendtask() As Boolean
        Dim isAmendOk As Boolean = False
        LogUtil.Info("Updating task " & _taskId, Name)
        With _newTask
            If UpdateTask(_newTask) = 1 Then
                AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Task, .TaskId, AuditUtil.AuditableAction.create, _taskbuilder.ToString, .ToString)
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
            _taskId = InsertTask(_newTask)
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