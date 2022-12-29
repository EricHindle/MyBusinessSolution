' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class TemplateTaskBuilder
    Private _taskId As Integer
    Private _name As String
    Private _description As String
    Private _cost As Decimal
    Private _template As Template
    Private _hours As Decimal
    Private _taxable As Boolean
    Private _taxRate As Decimal
    Public Shared Function ATemplateTask() As TemplateTaskBuilder
        Return New TemplateTaskBuilder
    End Function
    Public Function StartingWith(ByVal oTemplateTask As TemplateTask) As TemplateTaskBuilder
        With oTemplateTask
            _taskId = .TaskId
            _template = .Template
            _name = .Name
            _description = .Description
            _cost = .Cost
            _hours = .Hours
            _taxable = .IsTaskTaxable
            _taxRate = .TaxRate
        End With
        Return Me
    End Function
    Public Function StartingWith(ByVal oTemplateTask As netwyrksDataSet.template_taskRow) As TemplateTaskBuilder
        With oTemplateTask
            _taskId = .task_id
            _template = getTemplateById(.template_id)
            _name = .task_name
            _description = .task_description
            _cost = .task_cost
            _hours = .task_time
            _taxable = (.task_taxable = 1)
            _taxRate = .task_tax_rate
        End With
        Return Me
    End Function
    Public Function StartingWithNothing() As TemplateTaskBuilder
        _taskId = -1
        _name = ""
        _description = ""
        _cost = 0.00
        _hours = 0
        _taxable = False
        _taxRate = 0.00
        Return Me
    End Function
    Public Function WithTaskId(ByVal pTemplateTaskId As Integer) As TemplateTaskBuilder
        _taskId = pTemplateTaskId
        Return Me
    End Function
    Public Function WithTemplate(ByVal pTemplate As Template) As TemplateTaskBuilder
        _template = pTemplate
        Return Me
    End Function
    Public Function WithName(ByVal pTemplateTaskName As String) As TemplateTaskBuilder
        _name = pTemplateTaskName
        Return Me
    End Function
    Public Function WithDescription(ByVal pTemplateTaskDescription As String) As TemplateTaskBuilder
        _description = pTemplateTaskDescription
        Return Me
    End Function
    Public Function WithCost(ByVal pTemplateTaskCost As Decimal) As TemplateTaskBuilder
        _cost = pTemplateTaskCost
        Return Me
    End Function
    Public Function WithTaskHours(ByVal pTemplateTaskHours As Decimal) As TemplateTaskBuilder
        _hours = pTemplateTaskHours
        Return Me
    End Function
    Public Function WithIsTaxable(ByVal pTemplateTaskTaxable As Boolean) As TemplateTaskBuilder
        _taxable = pTemplateTaskTaxable
        Return Me
    End Function
    Public Function WithTaxRate(ByVal pTemplateTaskTaxRate As Decimal?) As TemplateTaskBuilder
        _taxRate = pTemplateTaskTaxRate
        Return Me
    End Function
    Public Function Build() As TemplateTask
        Return New TemplateTask(_taskId,
                        _template,
                        _name,
                        _description,
                        _cost,
                        _hours,
                        _taxable,
                        _taxRate)
    End Function

End Class
