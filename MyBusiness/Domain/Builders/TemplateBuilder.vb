' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class TemplateBuilder
    Private _templateId As Integer
    Private _templateName As String
    Private _templateDescription As String

    Public Shared Function ATemplate() As TemplateBuilder
        Return New TemplateBuilder
    End Function
    Public Function StartingWithNothing() As TemplateBuilder
        _templateId = -1
        _templateName = ""
        _templateDescription = ""
        Return Me
    End Function
    Public Function StartingWith(ByVal oTemplate As Template) As TemplateBuilder
        With oTemplate
            _templateId = .TemplateId
            _templateName = .TemplateName
            _templateDescription = .TemplateDescription
        End With
        Return Me
    End Function
    Public Function StartingWith(ByVal oTemplate As MyBusinessDataSet.templateRow) As TemplateBuilder
        With oTemplate
            _templateId = .template_id
            _templateName = .template_name
            _templateDescription = .template_description
        End With
        Return Me
    End Function
    Public Function WithTemplateId(ByVal pTemplateId As Integer) As TemplateBuilder
        _templateId = pTemplateId
        Return Me
    End Function
    Public Function WithTemplateName(ByVal pTemplateName As String) As TemplateBuilder
        _templateName = pTemplateName
        Return Me
    End Function
    Public Function WithTemplateDescription(ByVal pTemplateDescription As String) As TemplateBuilder
        _templateDescription = pTemplateDescription
        Return Me
    End Function

    Public Function Build() As Template
        Return New Template(_templateId,
                       _templateName,
                       _templateDescription)
    End Function

End Class
