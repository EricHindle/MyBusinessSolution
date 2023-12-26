' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports HindlewareLib.Logging

Public Class FrmSelectTemplate
#Region "properties"
    Public ReadOnly Property SelectedTemplate() As Template
        Get
            Return _selectedTemplate
        End Get
    End Property

#End Region
#Region "variables"
    Private IsLoading As Boolean
    Private _selectedTemplate As Template
#End Region
#Region "form control handlers"
    Private Sub FrmSelectTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTemplateTable()
    End Sub
    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
    Private Sub FrmJobTemplates_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", Name)
    End Sub
    Private Sub PicSelectTemplate_Click(sender As Object, e As EventArgs) Handles PicSelectTemplate.Click
        If DgvTemplates.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = DgvTemplates.SelectedRows(0)
            Dim _tmplId As Integer = oRow.Cells(tmplId.Name).Value
            _selectedTemplate = GetTemplateById(_tmplId)
            DialogResult = DialogResult.OK
            Close()
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
#End Region
End Class