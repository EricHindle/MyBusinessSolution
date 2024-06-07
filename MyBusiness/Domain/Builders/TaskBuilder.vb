' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class TaskBuilder
    Private _taskId As Integer
    Private _taskName As String
    Private _taskDescription As String
    Public Shared Function ATask() As TaskBuilder
        Return New TaskBuilder
    End Function
    Public Function StartingWith(ByVal oTask As Task) As TaskBuilder
        With oTask
            _taskId = .TaskId
            _taskName = .TaskName
            _taskDescription = .TaskDescription
        End With
        Return Me
    End Function
    Public Function StartingWith(ByVal oTask As MyBusinessDataSet.taskRow) As TaskBuilder

        With oTask
            _taskId = .taskid
            _taskName = .task_name
            _taskDescription = .task_desc
        End With
        Return Me
    End Function
    Public Function StartingWithNothing() As TaskBuilder
        _taskId = -1
        _taskName = ""
        _taskDescription = ""
        Return Me
    End Function
    Public Function WithTaskId(ByVal pTaskId As Integer) As TaskBuilder
        _taskId = pTaskId
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
    Public Function Build() As Task
        Return New Task(_taskId,
                        _taskName,
                        _taskDescription)
    End Function
End Class
