' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Threading.Tasks
Imports System.Windows.Markup.Localizer
Imports MyBusiness.netwyrksDataSetTableAdapters

Public Class FrmJobTemplates
#Region "constants"

#End Region
#Region "variables"
    Private IsLoading As Boolean
    Private SelectedTemplate As Template
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
            End If
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub LoadTemplateTable()

        IsLoading = True
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
        End With

    End Sub

    Private Sub LoadProductTable()
        Dim _productList As List(Of FullTemplateProduct) = GetTemplateProductViewbyTemplateId(SelectedTemplate.TemplateId)
        For Each _tmplproduct As FullTemplateProduct In _productList
            Dim _Product As Product = _tmplproduct.Product
            Dim _supplier As Supplier = _tmplproduct.Supplier
            Dim oRow As DataGridViewRow = dgvProducts.Rows(dgvProducts.Rows.Add())
            oRow.Cells(tpSupp.Name).Value = _supplier.SupplierName
            oRow.Cells(tpProdName.Name).Value = _Product.ProductName
            oRow.Cells(tpQty.Name).Value = _tmplproduct.Quantity
            oRow.Cells(tpCost.Name).Value = _Product.ProductCost
        Next

    End Sub
    Private Sub LoadTaskTable()
        Dim _taskList As List(Of TemplateTask) = GetTemplateTasksForTemplate(SelectedTemplate.TemplateId)
        For Each _task As TemplateTask In _taskList
            Dim oRow As DataGridViewRow = dgvTasks.Rows(dgvTasks.Rows.Add())
            oRow.Cells(taskName.Name).Value = _task.Name
            oRow.Cells(taskHours.Name).Value = _task.Hours
            oRow.Cells(taskPrice.Name).Value = _task.Cost
        Next
    End Sub


#End Region
End Class