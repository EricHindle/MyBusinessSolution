' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class Task
    Private _taskId As Integer
    Private _taskName As String
    Private _taskDescription As String

    Public Property TaskDescription() As String
        Get
            Return _taskDescription
        End Get
        Set(ByVal value As String)
            _taskDescription = value
        End Set
    End Property
    Public Property TaskName() As String
        Get
            Return _taskName
        End Get
        Set(ByVal value As String)
            _taskName = value
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
    Public Sub New(ByVal pTaskId As Integer,
                    ByVal pTaskName As String,
                    ByVal pTaskDescription As String)
        _taskId = pTaskId
        _taskName = pTaskName
        _taskDescription = pTaskDescription
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
        .Append("]")
        Return sb.ToString
    End Function
    Public Function AuditString() As String
        Return ToString
    End Function
End Class

