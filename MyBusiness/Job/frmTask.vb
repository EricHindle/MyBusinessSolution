' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class frmTask
    Private _taskbuilder As TaskBuilder
    Private _taskId As Integer
    Private _task As Task
    Private _jobId As Integer
    Private _job As job
    Private _newTask As Task
    Private isLoading As Boolean = False
    Private oTaskTa As New netwyrksDataSetTableAdapters.taskTableAdapter
    Private oTaskTable As New netwyrksDataSet.taskDataTable
    Public Property theJob() As job
        Get
            Return _job
        End Get
        Set(ByVal value As job)
            _job = value
        End Set
    End Property

    Public Property taskId() As Integer
        Get
            Return _taskId
        End Get
        Set(ByVal value As Integer)
            _taskId = value
        End Set
    End Property

    Public Property thetask() As TaskBuilder
        Get
            Return _taskbuilder
        End Get
        Set(ByVal value As TaskBuilder)
            _taskbuilder = value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmTask_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closing", Me.Name)
        oTaskTa.Dispose()
        oTaskTable.Dispose()
    End Sub

    Private Sub frmTask_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LogUtil.Debug("Starting", Me.Name)
        isLoading = True
        If _job IsNot Nothing Then
            _jobId = _job.jobId
            lblJobName.Text = _job.jobName
        Else
            MsgBox("Error: no job selected", MsgBoxStyle.Exclamation, "Error")
            showStatus(lblStatus, "No job selected", Me.Name, True)
        End If
        If _taskId > 0 Then
            _taskbuilder = TaskBuilder.aTaskBuilder.startingWith(_taskId)
            _task = _taskbuilder.build
            fillTaskDetails()
        Else
            newTask()
            _taskId = -1
        End If
        isLoading = False
    End Sub

    Private Sub fillTaskDetails()
        With _task
            txtTaskName.Text = .taskName
            rtbDescription.Text = .taskDescription
            nudCost.Value = .taskCost
            nudTime.Value = .taskHours
            dtpStartDate.Value = If(.taskStartDue Is Nothing, Now.Date, CDate(.taskStartDue).Date)
            chkStarted.Checked = .isTaskStarted
            chkCompleted.Checked = .istaskCompleted
            chkTaxable.Checked = .isTaskTaxable
            nudTaxRate.Value = .taskTaxRate
        End With
        LogUtil.Debug("Existing task " & CStr(_taskId), Me.Name)

    End Sub

    Private Sub clearTaskDetails()
        txtTaskName.Text = ""
        rtbDescription.Text = ""
        nudCost.Value = 0
        nudTime.Value = 0
        dtpStartDate.Value = Today.Date
        chkStarted.Checked = False
        chkCompleted.Checked = False
    End Sub

    Private Sub newTask()
        LogUtil.Debug("New task", Me.Name())
        clearTaskDetails()
        _taskbuilder = TaskBuilder.aTaskBuilder.startingWithNothing
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        With _taskbuilder.build
            _newTask = TaskBuilder.aTaskBuilder.withTaskName(txtTaskName.Text.Trim) _
            .withTaskDescription(rtbDescription.Text.Trim) _
            .withTaskCost(nudCost.Value) _
            .withTaskTime(nudTime.Value) _
            .withTaskCompleted(chkCompleted.Checked) _
            .withTaskStartDue(dtpStartDate.Value.Date) _
            .withTaskStarted(chkStarted.Checked) _
            .withTaskCreated(.taskCreated) _
            .withTaskChanged(.taskChanged) _
            .withTaskJobId(_jobId) _
            .withTaskTaxable(chkTaxable.Checked) _
            .withTaskTaxRate(nudTaxRate.Value) _
            .build()
        End With
        Dim newtaskId As Integer = -1
        If _taskId > 0 Then
            amendtask()
        Else
            inserttask()
        End If
    End Sub

    Private Function amendtask() As Boolean
        Dim isAmendOk As Boolean = False
        LogUtil.Debug("Updating task " & CStr(_taskId), Me.Name)
        With _newTask
            If oTaskTa.UpdateTask(.taskName, .taskDescription, .taskCost, .taskHours, .taskStartDue, .isTaskStarted, .istaskCompleted, Now, .taskJobId, .isTaskTaxable, .taskTaxRate, _taskId) = 1 Then
                AuditUtil.addAudit(currentUser.userId, AuditUtil.RecordType.Task, _taskId, AuditUtil.AuditableAction.create, _taskbuilder.ToString, .ToString)
                isAmendOk = True
                showStatus(lblStatus, "Task updated OK", Me.Name, True)
            Else
                isAmendOk = False
                showStatus(lblStatus, "Task NOT updated", Me.Name, True)

            End If
        End With
        Return isAmendOk
    End Function

    Private Function inserttask() As Boolean
        Dim isInsertOk As Boolean
        LogUtil.Debug("Inserting task", Me.Name)
        With _newTask
            _taskId = oTaskTa.InsertTask(.taskName, .taskDescription, .taskCost, .taskHours, .taskStartDue, .isTaskStarted, .istaskCompleted, Now, .taskJobId, .isTaskTaxable, .taskTaxRate)
            If _taskId > 0 Then
                AuditUtil.addAudit(currentUser.userId, AuditUtil.RecordType.Task, _taskId, AuditUtil.AuditableAction.create, "", .ToString)
                isInsertOk = True
                showStatus(lblStatus, "Task " & CStr(_taskId) & " Created OK", Me.Name, True)
            Else
                isInsertOk = False
                showStatus(lblStatus, "Task NOT created", Me.Name, True)
            End If
        End With
        Return isInsertOk
    End Function

End Class