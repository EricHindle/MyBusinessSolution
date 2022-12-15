' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class TaskBuilder
    Private _taskId As Integer
    Private _taskName As String
    Private _taskDescription As String
    Private _taskCost As Decimal
    Private _taskCompleted As Boolean
    Private _taskCreated As DateTime
    Private _taskChanged As DateTime?
    Private _taskJobId As Integer
    Private _taskHours As Decimal
    Private _taskStarted As Boolean
    Private _taskStartDue As DateTime?
    Private _taskTaxable As Boolean
    Private _taskTaxRate As Decimal?
    Public Shared Function ATask() As TaskBuilder
        Return New TaskBuilder
    End Function
    Public Function StartingWith(ByVal TaskId As Integer) As TaskBuilder
        Dim oTaskTa As New netwyrksDataSetTableAdapters.taskTableAdapter
        Dim oTaskTable As New netwyrksDataSet.taskDataTable
        If oTaskTa.FillById(oTaskTable, TaskId) > 0 Then
            StartingWith(oTaskTable.Rows(0))
        Else
            StartingWithNothing()
        End If
        oTaskTa.Dispose()
        oTaskTable.Dispose()
        Return Me
    End Function
    Public Function StartingWith(ByVal oTask As Task) As TaskBuilder
        With oTask
            _taskId = .TaskId
            _taskJobId = .TaskJobId
            _taskName = .TaskName
            _taskDescription = .TaskDescription
            _taskCost = .TaskCost
            _taskHours = .TaskHours
            _taskStartDue = .TaskStartDue
            _taskStarted = .IsTaskStarted
            _taskCompleted = .IstaskCompleted
            _taskCreated = .TaskCreated
            _taskChanged = .TaskChanged
            _taskTaxable = .IsTaskTaxable
            _taskTaxRate = .TaskTaxRate
        End With
        Return Me
    End Function
    Public Function StartingWith(ByVal oTask As netwyrksDataSet.taskRow) As TaskBuilder

        With oTask
            _taskId = .task_id
            _taskJobId = .task_job_id
            _taskName = .task_name
            _taskDescription = If(.Istask_descriptionNull, "", .task_description)
            _taskCost = If(.Istask_costNull, 0, .task_cost)
            _taskHours = If(.Istask_timeNull, 0, .task_time)
            If .Istask_start_dueNull Then
                _taskStartDue = Nothing
            Else
                _taskStartDue = .task_start_due
            End If
            _taskStarted = .task_started
            _taskCompleted = .task_completed
            _taskCreated = .task_created
            If .Istask_changedNull Then
                _taskChanged = Nothing
            Else
                _taskChanged = .task_changed
            End If
            _taskTaxable = .task_taxable
            _taskTaxRate = If(.Istask_tax_rateNull, 0, .task_tax_rate)
        End With
        Return Me
    End Function
    Public Function StartingWithNothing() As TaskBuilder
        _taskId = -1
        _taskJobId = -1
        _taskName = ""
        _taskDescription = ""
        _taskCost = 0
        _taskHours = 0
        _taskStartDue = Today.Date
        _taskStarted = False
        _taskCompleted = False
        _taskCreated = Now
        _taskChanged = Nothing
        _taskTaxable = False
        _taskTaxRate = Nothing
        Return Me
    End Function
    Public Function WithTaskId(ByVal pTaskId As Integer) As TaskBuilder
        _taskId = pTaskId
        Return Me
    End Function
    Public Function WithTaskJobId(ByVal pTaskJobId As Integer) As TaskBuilder
        _taskJobId = pTaskJobId
        Return Me
    End Function
    Public Function WithTaskName(ByVal pTaskName As String) As TaskBuilder
        _taskName = pTaskName
        Return Me
    End Function
    Public Function WithTaskDescription(ByVal pTaskDescription As String) As TaskBuilder
        _taskDescription = pTaskDescription
        Return Me
    End Function
    Public Function WithTaskCost(ByVal pTaskCost As Decimal) As TaskBuilder
        _taskCost = pTaskCost
        Return Me
    End Function
    Public Function WithTaskTime(ByVal pTaskHours As Decimal) As TaskBuilder
        _taskHours = pTaskHours
        Return Me
    End Function
    Public Function WithTaskStartDue(ByVal pTaskStartDue As DateTime?) As TaskBuilder
        _taskStartDue = pTaskStartDue
        Return Me
    End Function
    Public Function WithTaskStarted(ByVal pTaskStarted As Boolean) As TaskBuilder
        _taskStarted = pTaskStarted
        Return Me
    End Function
    Public Function WithTaskCompleted(ByVal pTaskCompleted As Boolean) As TaskBuilder
        _taskCompleted = pTaskCompleted
        Return Me
    End Function
    Public Function WithTaskCreated(ByVal pTaskCreated As DateTime) As TaskBuilder
        _taskCreated = pTaskCreated
        Return Me
    End Function
    Public Function WithTaskChanged(ByVal pTaskChanged As DateTime?) As TaskBuilder
        _taskChanged = pTaskChanged
        Return Me
    End Function
    Public Function WithTaskTaxable(ByVal pTaskTaxable As Boolean) As TaskBuilder
        _taskTaxable = pTaskTaxable
        Return Me
    End Function
    Public Function WithTaskTaxRate(ByVal pTaskTaxRate As Decimal?) As TaskBuilder
        _taskTaxRate = pTaskTaxRate
        Return Me
    End Function
    Public Function Build() As Task
        Return New Task(_taskId,
                        _taskJobId,
                        _taskName,
                        _taskDescription,
                        _taskCost,
                        _taskHours,
                        _taskStartDue,
                        _taskStarted,
                        _taskCompleted,
                        _taskCreated,
                        _taskChanged,
                        _taskTaxable,
                        _taskTaxRate)
    End Function
End Class
