' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class TemplateTask
    Private _taskId As Integer
    Private _name As String
    Private _description As String
    Private _cost As Decimal
    Private _templateId As Integer
    Private _hours As Decimal
    Private _taxable As Boolean
    Private _taxRate As Decimal
    Public Property TaxRate() As Decimal
        Get
            Return _taxRate
        End Get
        Set(ByVal value As Decimal)
            _taxRate = value
        End Set
    End Property
    Public Property IsTaskTaxable() As Boolean
        Get
            Return _taxable
        End Get
        Set(ByVal value As Boolean)
            _taxable = value
        End Set
    End Property
    Public Property Hours() As Decimal
        Get
            Return _hours
        End Get
        Set(ByVal value As Decimal)
            _hours = value
        End Set
    End Property
    Public Property Cost() As Decimal
        Get
            Return _cost
        End Get
        Set(ByVal value As Decimal)
            _cost = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
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
    Public Property TemplateId() As Integer
        Get
            Return _templateId
        End Get
        Set(ByVal value As Integer)
            _templateId = value
        End Set
    End Property
    Public Sub New(ByVal pTaskId As Integer,
                    ByVal pTemplateId As Integer,
                    ByVal pTaskName As String,
                    ByVal pTaskDescription As String,
                    ByVal pTaskCost As Decimal,
                    ByVal pTaskHours As Decimal,
                    ByVal pTaskTaxable As Boolean,
                    ByVal pTaskTaxRate As Decimal)
        _taskId = pTaskId
        _templateId = pTemplateId
        _name = pTaskName
        _description = pTaskDescription
        _cost = pTaskCost
        _hours = pTaskHours
        _taxable = pTaskTaxable
        _taxRate = pTaskTaxRate
    End Sub
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
        .Append("taskId=[") _
        .Append(_taskId) _
        .Append("], name=[") _
        .Append(_name) _
        .Append("], description=[") _
        .Append(_description) _
        .Append("], templateId=[") _
        .Append(_templateId) _
        .Append("], cost=[") _
        .Append(_cost) _
        .Append("], hours=[") _
        .Append(_hours) _
        .Append("], taskTaxable=[") _
        .Append(_taxable) _
        .Append("], taskTaxRate=[") _
        .Append(_taxRate) _
        .Append("]")
        Return sb.ToString
    End Function
    Public Function AuditString() As String
        Return ToString()
    End Function

End Class
