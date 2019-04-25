'
' Copyright (c) 2017, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.Text

Public Class Task
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

    Public Property taskTaxRate() As Decimal?
        Get
            Return _taskTaxRate
        End Get
        Set(ByVal value As Decimal?)
            _taskTaxRate = value
        End Set
    End Property

    Public Property isTaskTaxable() As Boolean
        Get
            Return _taskTaxable
        End Get
        Set(ByVal value As Boolean)
            _taskTaxable = value
        End Set
    End Property

    Public Property taskStartDue() As DateTime?
        Get
            Return _taskStartDue
        End Get
        Set(ByVal value As DateTime?)
            _taskStartDue = value
        End Set
    End Property
    Public Property isTaskStarted() As Boolean
        Get
            Return _taskStarted
        End Get
        Set(ByVal value As Boolean)
            _taskStarted = value
        End Set
    End Property
    Public Property taskHours() As Decimal
        Get
            Return _taskHours
        End Get
        Set(ByVal value As Decimal)
            _taskHours = value
        End Set
    End Property

    Public Property taskJobId() As Integer
        Get
            Return _taskJobId
        End Get
        Set(ByVal value As Integer)
            _taskJobId = value
        End Set
    End Property
    Public Property taskChanged() As DateTime?
        Get
            Return _taskChanged
        End Get
        Set(ByVal value As DateTime?)
            _taskChanged = value
        End Set
    End Property
    Public Property taskCreated() As DateTime
        Get
            Return _taskCreated
        End Get
        Set(ByVal value As DateTime)
            _taskCreated = value
        End Set
    End Property
    Public Property istaskCompleted() As Boolean
        Get
            Return _taskCompleted
        End Get
        Set(ByVal value As Boolean)
            _taskCompleted = value
        End Set
    End Property

    Public Property taskCost() As Decimal
        Get
            Return _taskCost
        End Get
        Set(ByVal value As Decimal)
            _taskCost = value
        End Set
    End Property
    Public Property taskDescription() As String
        Get
            Return _taskDescription
        End Get
        Set(ByVal value As String)
            _taskDescription = value
        End Set
    End Property
    Public Property taskName() As String
        Get
            Return _taskName
        End Get
        Set(ByVal value As String)
            _taskName = value
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

    Public Sub New(ByVal pTaskId As Integer, _
                    ByVal pTaskJob As Integer, _
                    ByVal pTaskName As String, _
                    ByVal pTaskDescription As String, _
                    ByVal pTaskCost As Decimal, _
                    ByVal pTaskHours As Decimal, _
                    ByVal pTaskStartDue As DateTime?, _
                    ByVal pTaskStarted As Boolean, _
                    ByVal pTaskCompleted As Boolean, _
                    ByVal pTaskCreated As DateTime, _
                    ByVal pTaskChanged As DateTime?, _
                    ByVal pTaskTaxable As Boolean, _
                    ByVal pTaskTaxRate As Decimal?)
        _taskId = pTaskId
        _taskJobId = pTaskJob
        _taskName = pTaskName
        _taskDescription = pTaskDescription
        _taskCost = pTaskCost
        _taskHours = pTaskHours
        _taskStartDue = pTaskStartDue
        _taskStarted = pTaskStarted
        _taskCompleted = pTaskCompleted
        _taskCreated = pTaskCreated
        _taskChanged = pTaskChanged
        _taskTaxable = pTasktaxable
        _taskTaxRate = pTaskTaxRate
    End Sub

    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
        .Append("taskId=[") _
        .Append(_taskId) _
        .Append("], name=[") _
        .Append(_taskName) _
        .Append("], description=[") _
        .Append(_taskDescription) _
        .Append("], jobId=[") _
        .Append(_taskJobId) _
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
        Return Me.ToString
    End Function

End Class


