' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class Template
    Private _templateId As Integer
    Private _templateName As String
    Private _templateDescription As String

    Public Property TemplateDescription() As String
        Get
            Return _templateDescription
        End Get
        Set(ByVal value As String)
            _templateDescription = value
        End Set
    End Property
    Public Property TemplateName() As String
        Get
            Return _templateName
        End Get
        Set(ByVal value As String)
            _templateName = value
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
    Public Sub New(ByVal pTemplateId As Integer,
                    ByVal pTemplateName As String,
                    ByVal pTemplateDescription As String)
        _templateId = pTemplateId
        _templateName = pTemplateName
        _templateDescription = pTemplateDescription
    End Sub
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
        .Append("templateId=[") _
        .Append(_templateId) _
        .Append("], name=[") _
        .Append(_templateName) _
        .Append("], description=[") _
        .Append(_templateDescription) _
        .Append("]")
        Return sb.ToString
    End Function

End Class
