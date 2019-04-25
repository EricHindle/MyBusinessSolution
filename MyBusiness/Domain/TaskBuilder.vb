Public Class TaskBuilder
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

    Public Shared Function aTaskBuilder() As TaskBuilder
        Return New TaskBuilder
    End Function
    Public Function startingWith(ByVal TaskId As Integer) As TaskBuilder
        Dim oTaskTa As New netwyrksDataSetTableAdapters.taskTableAdapter
        Dim oTaskTable As New netwyrksDataSet.taskDataTable
        Dim oTaskRow As netwyrksDataSet.taskRow = Nothing
        If oTaskTa.FillById(oTaskTable, TaskId) > 0 Then
            startingWith(oTaskTable.Rows(0))
        Else
            startingWithNothing()
        End If
        oTaskTa.Dispose()
        oTaskTable.Dispose()
        Return Me
    End Function

    Public Function startingWith(ByVal oTask As Task) As TaskBuilder
        With oTask
            _taskId = .taskId
            _taskJobId = .taskJobId
            _taskName = .taskName
            _taskDescription = .taskDescription
            _taskCost = .taskCost
            _taskHours = .taskHours
            _taskStartDue = .taskStartDue
            _taskStarted = .isTaskStarted
            _taskCompleted = .istaskCompleted
            _taskCreated = .taskCreated
            _taskChanged = .taskChanged
            _taskTaxable = .isTaskTaxable
            _taskTaxRate = .taskTaxRate
        End With
        Return Me
    End Function
    Public Function startingWith(ByVal oTask As netwyrksDataSet.taskRow) As TaskBuilder

        With oTask
            _taskId = .task_id
            _taskJobId = .task_job_id
            _taskName = .task_name
            _taskDescription = If(.Istask_descriptionNull, "", .task_description)
            _taskCost = If(.Istask_costNull, 0, .task_cost)
            _taskHours = If(.Istask_timeNull, 0, .task_time)
            If .Istask_start_dueNull Then
                _taskStartDue = Nothing
            Else
                _taskStartDue = .task_start_due
            End If
            _taskStarted = .task_started
            _taskCompleted = .task_completed
            _taskCreated = .task_created
            If .Istask_changedNull Then
                _taskChanged = Nothing
            Else
                _taskChanged = .task_changed
            End If
            _taskTaxable = .task_taxable
            _taskTaxRate = If(.Istask_tax_rateNull, 0, .task_tax_rate)
        End With
        Return Me
    End Function
    Public Function startingWithNothing() As TaskBuilder
        _taskId = -1
        _taskJobId = -1
        _taskName = ""
        _taskDescription = ""
        _taskCost = 0
        _taskHours = 0
        _taskStartDue = Today.Date
        _taskStarted = False
        _taskCompleted = False
        _taskCreated = Now
        _taskChanged = Nothing
        _taskTaxable = False
        _taskTaxRate = Nothing
        Return Me
    End Function
    Public Function withTaskId(ByVal pTaskId As Integer) As TaskBuilder
        _taskId = pTaskId
        Return Me
    End Function
    Public Function withTaskJobId(ByVal pTaskJobId As Integer) As TaskBuilder
        _taskJobId = pTaskJobId
        Return Me
    End Function
    Public Function withTaskName(ByVal pTaskName As String) As TaskBuilder
        _taskName = pTaskName
        Return Me
    End Function
    Public Function withTaskDescription(ByVal pTaskDescription As String) As TaskBuilder
        _taskDescription = pTaskDescription
        Return Me
    End Function
    Public Function withTaskCost(ByVal pTaskCost As Decimal) As TaskBuilder
        _taskCost = pTaskCost
        Return Me
    End Function
    Public Function withTaskTime(ByVal pTaskHours As Decimal) As TaskBuilder
        _taskHours = pTaskHours
        Return Me
    End Function
    Public Function withTaskStartDue(ByVal pTaskStartDue As DateTime?) As TaskBuilder
        _taskStartDue = pTaskStartDue
        Return Me
    End Function
    Public Function withTaskStarted(ByVal pTaskStarted As Boolean) As TaskBuilder
        _taskStarted = pTaskStarted
        Return Me
    End Function
    Public Function withTaskCompleted(ByVal pTaskCompleted As Boolean) As TaskBuilder
        _taskCompleted = pTaskCompleted
        Return Me
    End Function
    Public Function withTaskCreated(ByVal pTaskCreated As DateTime) As TaskBuilder
        _taskCreated = pTaskCreated
        Return Me
    End Function
    Public Function withTaskChanged(ByVal pTaskChanged As DateTime?) As TaskBuilder
        _taskChanged = pTaskChanged
        Return Me
    End Function
    Public Function withTaskTaxable(ByVal pTaskTaxable As Boolean) As TaskBuilder
        _taskTaxable = pTaskTaxable
        Return Me
    End Function
    Public Function withTaskTaxRate(ByVal pTaskTaxRate As Decimal?) As TaskBuilder
        _taskTaxRate = pTaskTaxRate
        Return Me
    End Function

    Public Function build() As Task
        Return New Task(_taskId, _
                        _taskJobId, _
                        _taskName, _
                        _taskDescription, _
                        _taskCost, _
                        _taskHours, _
                        _taskStartDue, _
                        _taskStarted, _
                        _taskCompleted, _
                        _taskCreated, _
                        _taskChanged, _
                        _taskTaxable, _
                        _taskTaxRate)
    End Function
End Class
