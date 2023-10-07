' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class JobTask
    Private _jobtaskId As Integer
    Private _taskId As Integer
    Private _jobId As Integer
    Private _task As Task
    Private _taskCost As Decimal
    Private _taskCompleted As Boolean
    Private _taskCreated As DateTime
    Private _taskChanged As DateTime?
    Private _taskHours As Decimal
    Private _taskStarted As Boolean
    Private _taskStartDue As DateTime?
    Private _taskTaxable As Boolean
    Private _taskTaxRate As Decimal?
    Public Property JobTaskId() As Integer
        Get
            Return _jobtaskId
        End Get
        Set(ByVal value As Integer)
            _jobtaskId = value
        End Set
    End Property
    Public Property Task() As Task
        Get
            Return _task
        End Get
        Set(ByVal value As Task)
            _task = value
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
    Public Property JobId() As Integer
        Get
            Return _jobId
        End Get
        Set(ByVal value As Integer)
            _jobId = value
        End Set
    End Property
    Public Property TaskTaxRate() As Decimal?
        Get
            Return _taskTaxRate
        End Get
        Set(ByVal value As Decimal?)
            _taskTaxRate = value
        End Set
    End Property
    Public Property IsTaskTaxable() As Boolean
        Get
            Return _taskTaxable
        End Get
        Set(ByVal value As Boolean)
            _taskTaxable = value
        End Set
    End Property
    Public Property TaskStartDue() As DateTime?
        Get
            Return _taskStartDue
        End Get
        Set(ByVal value As DateTime?)
            _taskStartDue = value
        End Set
    End Property
    Public Property IsTaskStarted() As Boolean
        Get
            Return _taskStarted
        End Get
        Set(ByVal value As Boolean)
            _taskStarted = value
        End Set
    End Property
    Public Property TaskHours() As Decimal
        Get
            Return _taskHours
        End Get
        Set(ByVal value As Decimal)
            _taskHours = value
        End Set
    End Property
    Public Property TaskChanged() As DateTime?
        Get
            Return _taskChanged
        End Get
        Set(ByVal value As DateTime?)
            _taskChanged = value
        End Set
    End Property
    Public Property TaskCreated() As DateTime
        Get
            Return _taskCreated
        End Get
        Set(ByVal value As DateTime)
            _taskCreated = value
        End Set
    End Property
    Public Property IstaskCompleted() As Boolean
        Get
            Return _taskCompleted
        End Get
        Set(ByVal value As Boolean)
            _taskCompleted = value
        End Set
    End Property
    Public Property TaskCost() As Decimal
        Get
            Return _taskCost
        End Get
        Set(ByVal value As Decimal)
            _taskCost = value
        End Set
    End Property
    Public Sub New(ByVal pTaskId As Integer,
                   ByVal pTask As Task,
                    ByVal pTaskJob As Integer,
                    ByVal pTaskCost As Decimal,
                    ByVal pTaskHours As Decimal,
                    ByVal pTaskStartDue As DateTime?,
                    ByVal pTaskStarted As Boolean,
                    ByVal pTaskCompleted As Boolean,
                    ByVal pTaskCreated As DateTime,
                    ByVal pTaskChanged As DateTime?,
                    ByVal pTaskTaxable As Boolean,
                    ByVal pTaskTaxRate As Decimal?)
        _task = pTask
        _jobtaskId = pTaskId
        _jobId = pTaskJob
        _taskId = pTask.TaskId
        _taskCost = pTaskCost
        _taskHours = pTaskHours
        _taskStartDue = pTaskStartDue
        _taskStarted = pTaskStarted
        _taskCompleted = pTaskCompleted
        _taskCreated = pTaskCreated
        _taskChanged = pTaskChanged
        _taskTaxable = pTaskTaxable
        _taskTaxRate = pTaskTaxRate
    End Sub
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
        .Append("jobtaskId=[") _
        .Append(_jobtaskId) _
        .Append("], taskid=[") _
        .Append(_taskId) _
        .Append("], name=[") _
        .Append(_task.TaskName) _
        .Append("], description=[") _
        .Append(_task.TaskDescription) _
        .Append("], jobId=[") _
        .Append(_jobId) _
        .Append("], cost=[") _
        .Append(_taskCost) _
        .Append("], hours=[") _
        .Append(_taskHours) _
        .Append("], startdue=[") _
        .Append(If(_taskStartDue Is Nothing, "", Format(_taskStartDue, "dd/MM/yyyy"))) _
        .Append("], started=[") _
        .Append(_taskStarted) _
        .Append("], completed=[") _
        .Append(_taskCompleted) _
        .Append("], created=[") _
        .Append(_taskCreated) _
        .Append("], changed=[") _
        .Append(If(_taskChanged Is Nothing, "", Format(_taskChanged, "dd/MM/yyyy"))) _
        .Append("], taskTaxable=[") _
        .Append(_taskTaxable) _
        .Append("], taskTaxRate=[") _
        .Append(_taskTaxRate) _
        .Append("]")
        Return sb.ToString
    End Function
    Public Function AuditString() As String
        Return ToString()
    End Function
End Class

