' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmTasks
#Region "variables"
    Private _task As Task
    Private _newTask As Task
    Private IsLoading As Boolean = False
    Private IsTasksLoaded As Boolean = False
#End Region
#Region "properties"
    Private _taskId As Integer
    Public ReadOnly Property TaskId() As Integer
        Get
            Return TaskId
        End Get
    End Property
#End Region
#Region "form handlers"
    Private Sub FrmTask_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LogUtil.Info("Starting", Name)
        GetFormPos(Me, My.Settings.TaskFormPos)
        LoadTaskList()
        IsTasksLoaded = True
        IsLoading = True
        ClearTaskDetails()
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
        If _taskId > 0 Then
            If Not String.IsNullOrEmpty(txtTaskName.Text) Then
                _newTask = CreateNewTaskFromForm()
                AmendTask(_newTask)
                Close()
            Else
                ShowStatus(lblStatus, "Missing values. No action")
            End If
        Else
            ShowStatus(lblStatus, "No task selected. No action")
        End If
    End Sub
    Private Sub CbTask_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbTask.SelectedIndexChanged
        If IsTasksLoaded AndAlso CbTask.SelectedIndex > -1 Then
            _taskId = CbTask.SelectedValue
            _task = GetTaskById(_taskId)
            txtTaskName.Text = _task.TaskName
            rtbDescription.Text = _task.TaskDescription
            PicUpdate.Visible = True
        Else
            txtTaskName.Text = String.Empty
            rtbDescription.Text = String.Empty
            _taskId = -1
            _task = TaskBuilder.ATask.StartingWithNothing.Build
            PicUpdate.Visible = False
        End If
    End Sub
    Private Sub PicAdd_Click(sender As Object, e As EventArgs) Handles PicAdd.Click
        If Not String.IsNullOrEmpty(txtTaskName.Text) Then
            _newTask = CreateNewTaskFromForm()
            CreateTask(_newTask)
            Close()
        Else
            ShowStatus(lblStatus, "Missing values. No action")
        End If
    End Sub
    Private Sub PicClear_Click(sender As Object, e As EventArgs) Handles PicClear.Click
        ClearTaskDetails()
    End Sub
#End Region
#Region "subroutines"
    Private Function CreateNewTaskFromForm() As Task
        Return TaskBuilder.ATask.StartingWithNothing _
                                    .WithTaskId(_taskId) _
                                    .WithTaskName(txtTaskName.Text) _
                                    .WithTaskDescription(rtbDescription.Text) _
                                    .Build()
    End Function
    Private Sub LoadTaskList()
        Dim oTaskTa As New MyBusinessDataSetTableAdapters.taskTableAdapter
        Dim oTaskTable As MyBusinessDataSet.taskDataTable = oTaskTa.GetData()
        CbTask.DataSource = oTaskTable
        CbTask.ValueMember = "taskid"
        CbTask.DisplayMember = "task_name"
    End Sub
    Private Sub FillTaskDetails(pTask As Task)
        With pTask
            _task = pTask
            _taskId = pTask.TaskId
            CbTask.SelectedValue = pTask.TaskId
            txtTaskName.Text = .TaskName
            rtbDescription.Text = .TaskDescription
        End With
    End Sub
    Private Sub ClearTaskDetails()
        CbTask.SelectedIndex = -1
    End Sub
    Private Function AmendTask(pTask As Task) As Boolean
        Dim isAmendOk As Boolean = False
        LogUtil.Info("Updating task", Name)
        With pTask
            Dim _ct As Integer
            _ct = UpdateTask(pTask)
            AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Task, .TaskId, AuditUtil.AuditableAction.create, _task.ToString, .ToString)
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
    Private Function CreateTask(pTask As Task) As Boolean
        Dim isInsertOk As Boolean
        LogUtil.Info("Inserting task", Name)
        With pTask
            _taskId = InsertTask(pTask)
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