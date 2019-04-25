' Copyright (c) 2015, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
' Created Nov 2015

<Serializable()> Public Class AuthenticationException
    Inherits System.ApplicationException
    Public Sub New()
    End Sub
    ' Creates a Sub New for the exception that allows you to set the
    ' message property when thrown.
    Public Sub New(Message As String)
        MyBase.New(Message)
    End Sub
    ' Creates a Sub New that can be used when you also want to include
    ' the inner exception.
    Public Sub New(Message As String, Inner As Exception)
        MyBase.New(Message)
    End Sub
End Class
