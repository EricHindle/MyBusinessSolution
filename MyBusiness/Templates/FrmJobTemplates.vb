' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmJobTemplates
#Region "constants"

#End Region
#Region "variables"
    Private IsLoading As Boolean
    Private SelectedTemplate As Template
    Private SelectedProducts As New List(Of FullTemplateProduct)
    Private SelectedTasks As New List(Of TemplateTask)
#End Region
#Region "properties"
    Private _selectedTemplateId As Integer
    Public Property TemplateId() As Integer
        Get
            Return _selectedTemplateId
        End Get
        Set(ByVal value As Integer)
            _selectedTemplateId = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        Close()
    End Sub
    Private Sub FrmJobTemplates_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", Name)
        My.Settings.TmplFormPos = SetFormPos(Me)
        My.Settings.TmplSplitterDist1 = SplitContainer1.SplitterDistance
        My.Settings.TmplSplitterDist2 = SplitContainer2.SplitterDistance
        My.Settings.Save()
    End Sub
    Private Sub FrmJobTemplates_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Started", Name)
        If GetFormPos(Me, My.Settings.TmplFormPos) Then
            SplitContainer1.SplitterDistance = CInt("0" & My.Settings.TmplSplitterDist1)
            SplitContainer2.SplitterDistance = CInt("0" & My.Settings.TmplSplitterDist2)
        End If
        LoadTemplateTable()
        ClearForm()
        For Each oRow As DataGridViewRow In DgvTemplates.Rows
            If oRow.Cells(tmplId.Name).Value = _selectedTemplateId Then
                oRow.Selected = True
                Exit For
            End If
        Next
    End Sub
    Private Sub BtnMaintProducts_Click(sender As Object, e As EventArgs) Handles btnMaintProducts.Click
        'LogUtil.Debug("Maintain products on job", Name)
        'Using _jobProductForm As New FrmJobProducts
        '    _jobProductForm.TheJob = _job
        '    _jobProductForm.SelectedJobProduct = Nothing
        '    _jobProductForm.ShowDialog()
        'End Using
        'FillProductList(_currentJobId)
    End Sub
    Private Sub DgvTemplates_SelectionChanged(sender As Object, e As EventArgs) Handles DgvTemplates.SelectionChanged
        If Not IsLoading Then
            If DgvTemplates.SelectedRows.Count = 1 Then
                Dim oRow As DataGridViewRow = DgvTemplates.SelectedRows(0)
                Dim _tmplId As Integer = oRow.Cells(tmplId.Name).Value
                SelectedTemplate = GetTemplateById(_tmplId)
                LoadFormFromSelectedTemplate()
            Else
                clearForm
            End If
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub LoadTemplateTable()

        IsLoading = True
        DgvTemplates.Rows.Clear()
        Dim _templates As List(Of Template) = GetAllTemplates()
        For Each _template As Template In _templates
            Dim oRow As DataGridViewRow = DgvTemplates.Rows(DgvTemplates.Rows.Add())
            oRow.Cells(tmplId.Name).Value = _template.TemplateId
            oRow.Cells(tmplName.Name).Value = _template.TemplateName
        Next

        DgvTemplates.ClearSelection()
        IsLoading = False

    End Sub
    Private Sub LoadFormFromSelectedTemplate()
        With SelectedTemplate
            LblId.Text = .TemplateId
            TxtTmplName.Text = .TemplateName
            TxtTmplDesc.Text = .TemplateDescription
            LoadProductTable()
            LoadTaskTable()
            SplitContainer1.Panel2Collapsed = False
            PicAddTemplate.Visible = False
            PicUpdate.Visible = True
            PicDeleteTemplate.Visible = True
        End With

    End Sub

    Private Sub LoadProductTable()
        dgvProducts.Rows.Clear()
        SelectedProducts = GetTemplateProductViewbyTemplateId(SelectedTemplate.TemplateId)
        For Each _tmplproduct As FullTemplateProduct In SelectedProducts
            Dim _Product As Product = _tmplproduct.Product
            Dim _supplier As Supplier = _tmplproduct.Supplier
            Dim oRow As DataGridViewRow = dgvProducts.Rows(dgvProducts.Rows.Add())
            oRow.Cells(tpId.Name).Value = _tmplproduct.TemplateProductId
            oRow.Cells(tpProdId.Name).Value = _Product.ProductId
            oRow.Cells(tpSupp.Name).Value = _supplier.SupplierName
            oRow.Cells(tpProdName.Name).Value = _Product.ProductName
            oRow.Cells(tpQty.Name).Value = _tmplproduct.Quantity
            oRow.Cells(tpCost.Name).Value = _Product.ProductCost
        Next

    End Sub
    Private Sub LoadTaskTable()
        DgvTasks.Rows.Clear()
        SelectedTasks = GetTemplateTasksForTemplate(SelectedTemplate.TemplateId)
        For Each _task As TemplateTask In SelectedTasks
            Dim oRow As DataGridViewRow = DgvTasks.Rows(DgvTasks.Rows.Add())
            oRow.Cells(taskId.Name).Value = _task.TaskId
            oRow.Cells(taskName.Name).Value = _task.Name
            oRow.Cells(taskHours.Name).Value = _task.Hours
            oRow.Cells(taskPrice.Name).Value = _task.Cost
        Next
    End Sub

    Private Sub PicDeleteTemplate_Click(sender As Object, e As EventArgs) Handles PicDeleteTemplate.Click
        If DgvTemplates.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = DgvTemplates.SelectedRows(0)
            Dim _tmplId As Integer = oRow.Cells(tmplId.Name).Value
            DeleteAllTemplate(_tmplId)
            LoadTemplateTable()
            ClearForm()
            ShowStatus(LblStatus, "Templated deleted", MyBase.Name, True)
        End If
    End Sub

    Private Sub PicUpdate_Click(sender As Object, e As EventArgs) Handles PicUpdate.Click
        If DgvTemplates.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = DgvTemplates.SelectedRows(0)
            Dim _tmplId As Integer = oRow.Cells(tmplId.Name).Value
            Dim _tmpl As Template = TemplateBuilder.ATemplate.StartingWithNothing _
                .WithTemplateId(_tmplId) _
            .WithTemplateName(TxtTmplName.Text) _
            .WithTemplateDescription(TxtTmplDesc.Text) _
            .Build
            UpdateTemplate(_tmpl)
            ShowStatus(LblStatus, "Templated updated", MyBase.Name, True)
        End If
    End Sub

    Private Sub PicAddTemplate_Click(sender As Object, e As EventArgs) Handles PicAddTemplate.Click
        If Not String.IsNullOrWhiteSpace(TxtTmplName.Text) Then


            Dim _template As Template = TemplateBuilder.ATemplate.StartingWithNothing _
                                            .WithTemplateName(TxtTmplName.Text) _
                                            .WithTemplateDescription(TxtTmplDesc.Text) _
                                            .Build
            Dim _templateId As Integer = InsertTemplate(_template)
            If _templateId > 0 Then
                For Each _fullTemplateProduct As FullTemplateProduct In SelectedProducts

                    Dim _templateproduct As TemplateProduct = TemplateProductBuilder.ATemplateProduct.StartingWith(_fullTemplateProduct) _
                                                                                                    .WithTemplateId(_templateId) _
                                                                                                    .Build
                    InsertTemplateProduct(_templateproduct)
                Next
                For Each _task As TemplateTask In SelectedTasks
                    Dim _templatetask As TemplateTask = TemplateTaskBuilder.ATemplateTask.StartingWith(_task) _
                                                                                        .WithTemplateId(_templateId) _
                                                                                        .Build
                    InsertTemplatetask(_templatetask)
                Next
            End If
            Using _templates As New FrmJobTemplates
                _templates.TemplateId = _templateId
                _templates.ShowDialog()
            End Using
            ShowStatus(LblStatus, "Templated added", MyBase.Name, True)
        Else
            ShowStatus(LblStatus, "Missing values. No action.", MyBase.Name, True)
        End If
    End Sub

    Private Sub BtnClearForm_Click(sender As Object, e As EventArgs) Handles BtnClearForm.Click
        DgvTemplates.ClearSelection()
    End Sub

    Private Sub ClearForm()
        LblId.Text = ""
        dgvProducts.Rows.Clear()
        DgvTasks.Rows.Clear()
        SelectedTasks.Clear()
        SelectedProducts.Clear()
        SelectedTemplate = Nothing
        TxtTmplDesc.Text = ""
        TxtTmplName.Text = ""
        PicAddTemplate.Visible = True
        PicUpdate.Visible = False
        PicDeleteTemplate.Visible = False
        SplitContainer1.Panel2Collapsed = True
    End Sub

    Private Sub BtnRemoveTask_Click(sender As Object, e As EventArgs) Handles btnRemoveTask.Click
        If DgvTasks.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = DgvTasks.SelectedRows(0)
            Dim _taskId As Integer = oRow.Cells(taskId.Name).Value
            DeleteTemplateTask(_taskId)
            LoadTaskTable()
        End If
    End Sub

    Private Sub BtnAddTask_Click(sender As Object, e As EventArgs) Handles btnAddTask.Click
        If SelectedTemplate IsNot Nothing AndAlso SelectedTemplate.TemplateId > 0 Then
            LogUtil.Debug("Add task to template", Name)
            Using _taskForm As New FrmTask
                _taskForm.CustomerJob = Nothing
                _taskForm.Template = SelectedTemplate
                _taskForm.ShowDialog()
            End Using
            LoadTaskTable()
        Else
            ShowStatus(LblStatus, "Add Template before adding tasks", MyBase.Name, False)
        End If
    End Sub

    Private Sub DgvTasks_CellDoubleClick(sender As Object, e As EventArgs) Handles DgvTasks.CellDoubleClick
        If DgvTasks.SelectedRows.Count = 1 Then
            LogUtil.Debug("Updating task", Name)
            Dim oRow As DataGridViewRow = DgvTasks.SelectedRows(0)
            Dim _taskId As Integer = oRow.Cells(taskId.Name).Value
            Using _taskForm As New FrmTask
                _taskForm.CustomerJob = Nothing
                _taskForm.Template = SelectedTemplate
                _taskForm.TaskId = _taskId
                _taskForm.ShowDialog()
            End Using
            LoadTaskTable()
        End If
    End Sub

#End Region
End Class