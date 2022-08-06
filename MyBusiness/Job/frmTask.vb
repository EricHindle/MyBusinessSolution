' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

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
    Public Property TheJob() As Job
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
    Public Property Thetask() As TaskBuilder
        Get
            Return _taskbuilder
        End Get
        Set(ByVal value As TaskBuilder)
            _taskbuilder = value
        End Set
    End Property
#End Region
#Region "form handlers"
    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub FrmTask_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        logutil.info("Closing", Me.Name)
        oTaskTa.Dispose()
        oTaskTable.Dispose()
    End Sub
    Private Sub FrmTask_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logutil.info("Starting", Me.Name)
        isLoading = True
        If _job IsNot Nothing Then
            _jobId = _job.JobId
            lblJobName.Text = _job.JobName
        Else
            MsgBox("Error: no job selected", MsgBoxStyle.Exclamation, "Error")
            showStatus(lblStatus, "No job selected", Me.Name, True)
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
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
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
            .Build()
        End With
        Dim newtaskId As Integer = -1
        If _taskId > 0 Then
            Amendtask()
        Else
            Inserttask()
        End If
        Me.Close()
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
        logutil.info("Existing task " & CStr(_taskId), Me.Name)

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
        logutil.info("New task", Me.Name())
        ClearTaskDetails()
        _taskbuilder = TaskBuilder.ATask.StartingWithNothing
    End Sub
    Private Function Amendtask() As Boolean
        Dim isAmendOk As Boolean = False
        logutil.info("Updating task " & CStr(_taskId), Me.Name)
        With _newTask
            If oTaskTa.UpdateTask(.TaskName, .TaskDescription, .TaskCost, .TaskHours, .TaskStartDue, .IsTaskStarted, .IstaskCompleted, Now, .TaskJobId, .IsTaskTaxable, .TaskTaxRate, _taskId) = 1 Then
                AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Task, _taskId, AuditUtil.AuditableAction.create, _taskbuilder.ToString, .ToString)
                isAmendOk = True
                showStatus(lblStatus, "Task updated OK", Me.Name, True)
            Else
                isAmendOk = False
                showStatus(lblStatus, "Task NOT updated", Me.Name, True)

            End If
        End With
        Return isAmendOk
    End Function
    Private Function Inserttask() As Boolean
        Dim isInsertOk As Boolean
        logutil.info("Inserting task", Me.Name)
        With _newTask
            _taskId = oTaskTa.InsertTask(.TaskName, .TaskDescription, .TaskCost, .TaskHours, .TaskStartDue, .IsTaskStarted, .IstaskCompleted, Now, .TaskJobId, .IsTaskTaxable, .TaskTaxRate)
            If _taskId > 0 Then
                AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Task, _taskId, AuditUtil.AuditableAction.create, "", .ToString)
                isInsertOk = True
                showStatus(lblStatus, "Task " & CStr(_taskId) & " Created OK", Me.Name, True)
            Else
                isInsertOk = False
                showStatus(lblStatus, "Task NOT created", Me.Name, True)
            End If
        End With
        Return isInsertOk
    End Function
#End Region
End Class