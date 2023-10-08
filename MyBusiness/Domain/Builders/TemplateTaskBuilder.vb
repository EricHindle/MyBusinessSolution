' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class TemplateTaskBuilder
    Private _templatetaskId As Integer
    Private _taskId As Integer
    Private _task As Task
    Private _name As String
    Private _description As String
    Private _cost As Decimal
    Private _templateId As Integer
    Private _hours As Decimal
    Private _taxable As Boolean
    Private _taxRate As Decimal
    Public Shared Function ATemplateTask() As TemplateTaskBuilder
        Return New TemplateTaskBuilder
    End Function
    Public Function StartingWith(ByVal oTemplateTask As TemplateTask) As TemplateTaskBuilder
        With oTemplateTask
            _templatetaskId = .TemplateTaskId
            _task = .Task
            _taskId = .Task.TaskId
            _templateId = .TemplateId
            _cost = .Cost
            _hours = .Hours
            _taxable = .IsTaskTaxable
            _taxRate = .TaxRate
        End With
        Return Me
    End Function
    Public Function StartingWith(ByVal oTask As JobTask) As TemplateTaskBuilder
        With oTask
            _templatetaskId = .JobTaskId
            _task = .Task
            _taskId = .Task.TaskId
            _cost = .TaskCost
            _hours = .TaskHours
            _taxable = .IsTaskTaxable
            _taxRate = .TaskTaxRate
        End With
        Return Me
    End Function
    Public Function StartingWith(ByVal oTemplateTask As netwyrksDataSet.template_taskRow) As TemplateTaskBuilder
        With oTemplateTask
            _templatetaskId = .templatetask_id
            _templateId = .template_id
            _task = GetTaskById(.templatetask_task_id)
            _cost = .templatetask_cost
            _hours = .templatetask_time
            _taxable = .templatetask_taxable = 1
            _taxRate = .templatetask_tax_rate
        End With
        Return Me
    End Function
    Public Function StartingWithNothing() As TemplateTaskBuilder
        _templatetaskId = -1
        _task = TaskBuilder.ATask.StartingWithNothing.Build
        _taskId = -1
        _cost = 0.00
        _hours = 0
        _taxable = False
        _taxRate = 0.00
        _templateId = -1
        Return Me
    End Function

    Public Function WithTaskId(ByVal pTemplateTaskId As Integer) As TemplateTaskBuilder
        _templatetaskId = pTemplateTaskId
        Return Me
    End Function
    Public Function WithTask(ByVal pTaskId As Integer) As TemplateTaskBuilder
        _taskId = pTaskId
        _task = GetTaskById(pTaskId)
        Return Me
    End Function
    Public Function WithTask(ByVal pTask As Task) As TemplateTaskBuilder
        _taskId = pTask.TaskId
        _task = pTask
        Return Me
    End Function
    Public Function WithTemplateId(ByVal pTemplateId As Integer) As TemplateTaskBuilder
        _templateId = pTemplateId
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
        Return New TemplateTask(_templatetaskId,
                        _task,
                        _templateId,
                        _name,
                        _description,
                        _cost,
                        _hours,
                        _taxable,
                        _taxRate)
    End Function

End Class
