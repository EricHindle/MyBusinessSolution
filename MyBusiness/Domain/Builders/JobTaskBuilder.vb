' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class JobTaskBuilder
    Private _taskId As Integer
    Private _task As Task
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
    Public Shared Function AJobTask() As JobTaskBuilder
        Return New JobTaskBuilder
    End Function
    Public Function StartingWith(ByVal oTask As JobTask) As JobTaskBuilder
        With oTask
            _taskId = .TaskId
            _taskJobId = .TaskJobId
            _task = .Task
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
    Public Function StartingWith(ByVal oTask As TemplateTask) As JobTaskBuilder
        StartingWithNothing()
        With oTask
            _taskId = .TaskId
            _task = GetTaskById(.TaskId)
            _taskCost = .Cost
            _taskHours = .Hours
            _taskTaxable = .IsTaskTaxable
            _taskTaxRate = .TaxRate
        End With
        Return Me
    End Function
    Public Function StartingWith(ByVal oTask As netwyrksDataSet.job_taskRow) As JobTaskBuilder
        With oTask
            _taskId = .task_id
            _taskJobId = .task_job_id
            _task = GetTaskById(.task_id)
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
    Public Function StartingWithNothing() As JobTaskBuilder
        _taskId = -1
        _taskJobId = -1
        _task = TaskBuilder.ATask.StartingWithNothing.Build
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
    Public Function WithTaskId(ByVal pTaskId As Integer) As JobTaskBuilder
        _taskId = pTaskId
        Return Me
    End Function
    Public Function WithTaskJobId(ByVal pTaskJobId As Integer) As JobTaskBuilder
        _taskJobId = pTaskJobId
        Return Me
    End Function
    Public Function WithTask(ByVal pTaskId As Integer) As JobTaskBuilder
        _task = GetTaskById(pTaskId)
        Return Me
    End Function
    Public Function WithTask(ByVal pTask As Task) As JobTaskBuilder
        _task = pTask
        Return Me
    End Function
    Public Function WithTaskCost(ByVal pTaskCost As Decimal) As JobTaskBuilder
        _taskCost = pTaskCost
        Return Me
    End Function
    Public Function WithTaskTime(ByVal pTaskHours As Decimal) As JobTaskBuilder
        _taskHours = pTaskHours
        Return Me
    End Function
    Public Function WithTaskStartDue(ByVal pTaskStartDue As DateTime?) As JobTaskBuilder
        _taskStartDue = pTaskStartDue
        Return Me
    End Function
    Public Function WithTaskStarted(ByVal pTaskStarted As Boolean) As JobTaskBuilder
        _taskStarted = pTaskStarted
        Return Me
    End Function
    Public Function WithTaskCompleted(ByVal pTaskCompleted As Boolean) As JobTaskBuilder
        _taskCompleted = pTaskCompleted
        Return Me
    End Function
    Public Function WithTaskCreated(ByVal pTaskCreated As DateTime) As JobTaskBuilder
        _taskCreated = pTaskCreated
        Return Me
    End Function
    Public Function WithTaskChanged(ByVal pTaskChanged As DateTime?) As JobTaskBuilder
        _taskChanged = pTaskChanged
        Return Me
    End Function
    Public Function WithTaskTaxable(ByVal pTaskTaxable As Boolean) As JobTaskBuilder
        _taskTaxable = pTaskTaxable
        Return Me
    End Function
    Public Function WithTaskTaxRate(ByVal pTaskTaxRate As Decimal?) As JobTaskBuilder
        _taskTaxRate = pTaskTaxRate
        Return Me
    End Function
    Public Function Build() As JobTask
        Return New JobTask(_taskId,
                        _task,
                        _taskJobId,
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
