' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Module ModTemplate
    Public Function SelectATemplate() As Template
        Dim _selectedTemplate As Template = Nothing
        Using _selTmpl As New FrmSelectTemplate
            If _selTmpl.ShowDialog() = DialogResult.OK Then
                _selectedTemplate = _selTmpl.SelectedTemplate
            End If
        End Using
        Return _selectedTemplate
    End Function

    Public Sub CreateJobFromTemplate(pTemplate As Template)
        Dim _newJob As Job = JobBuilder.AJob.StartingWithNothing.WithJobName(pTemplate.TemplateName).WithJobUser(currentUser.UserId).Build
        Dim _jobId = CreateJob(_newJob)
        If _jobId > 0 Then

            Dim _templateProducts As List(Of FullTemplateProduct) = GetTemplateProductViewbyTemplateId(pTemplate.TemplateId)
            Dim _templateTasks As List(Of TemplateTask) = GetTemplateTasksForTemplate(pTemplate.TemplateId)
            Dim _products As New List(Of JobProduct)
            Dim _tasks As New List(Of Task)
            For Each _templateTask As TemplateTask In _templateTasks
                _tasks.Add(TaskBuilder.ATask.StartingWith(_templateTask) _
                                            .WithTaskJobId(_jobId) _
                                            .Build)
            Next
            For Each _templateProduct As FullTemplateProduct In _templateProducts
                _products.Add(JobProductBuilder.AJobProduct.StartingWith(_templateProduct) _
                                            .WithJob(_newJob) _
                                            .Build)
            Next
            AddJobProductsToJob(_products)
            AddTasksToJob(_tasks)

        End If
    End Sub
    Private Sub AddTasksToJob(pTaskList As List(Of Task))
        For Each oTask As Task In pTaskList
            InsertTask(oTask)
        Next
    End Sub
    Private Sub AddJobProductsToJob(_jobProductList As List(Of JobProduct))
        For Each _jobProduct As JobProduct In _jobProductList
            InsertJobProduct(_jobProduct)
        Next
    End Sub
    Private Function CreateJob(ByRef pNewJob As Job) As Integer
        Dim _jobId As Integer
        LogUtil.Debug("Inserting job", "Create Job")
        _jobId = InsertJob(pNewJob)
        If _jobId > 0 Then
            pNewJob.JobId = _jobId
        End If
        Return _jobId
    End Function
End Module
