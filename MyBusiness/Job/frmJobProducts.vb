' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.ComponentModel

Public Class FrmJobProducts

    Private isLoading As Boolean = False
    Private _currentSupplierId As Integer = -1
    Private ReadOnly oJobProdTa As New netwyrksDataSetTableAdapters.job_productTableAdapter
    Private ReadOnly oJobProdTable As New netwyrksDataSet.job_productDataTable
    Private ReadOnly oProdTa As New netwyrksDataSetTableAdapters.productTableAdapter
    Private ReadOnly oProdTable As New netwyrksDataSet.productDataTable
    Private ReadOnly oSuppTa As New netwyrksDataSetTableAdapters.supplierTableAdapter
    Private ReadOnly oSuppTable As New netwyrksDataSet.supplierDataTable
    Private _job As JobBuilder
    Private _selJpId As Integer = -1
    Private _selProductId As String = -1
    Private _selIsTaxable As Boolean = False
    Private _selTaxRate As Decimal = 0.0

    Public Property TheJob() As JobBuilder
        Get
            Return _job
        End Get
        Set(ByVal value As JobBuilder)
            _job = value
        End Set
    End Property
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub FrmJobProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isLoading = True
        _currentSupplierId = -1
        fillSupplierList()
        fillProductList()
        fillJobProductList(dgvJobProducts)
        lblJobName.Text = _job.Build.JobName
        lblProductName.Text = ""
        isLoading = False
    End Sub

    Private Sub FillSupplierList()
        dgvSupplier.Rows.Clear()

        Try
            Dim i As Integer = dgvSupplier.Rows.Add()
            Dim firstRow As DataGridViewRow = dgvSupplier.Rows(i)
            firstRow.Cells(Me.suppName.Name).Value = "ALL"
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try


        oSuppTa.Fill(oSuppTable)
        For Each sRow As netwyrksDataSet.supplierRow In oSuppTable.Rows
            Dim tRow As DataGridViewRow = dgvSupplier.Rows(dgvSupplier.Rows.Add())
            tRow.Cells(Me.suppId.Name).Value = sRow.supplier_id
            tRow.Cells(Me.suppName.Name).Value = sRow.supplier_name
        Next

        dgvSupplier.ClearSelection()
    End Sub

    Private Sub FillProductList()
        dgvProducts.Rows.Clear()

        If _currentSupplierId > 0 Then
            oProdTa.FillBySupplier(oProdTable, _currentSupplierId)
        Else
            oProdTa.Fill(oProdTable)
        End If

        For Each sRow As netwyrksDataSet.productRow In oProdTable.Rows
            Dim tRow As DataGridViewRow = dgvProducts.Rows(dgvProducts.Rows.Add())
            tRow.Cells(Me.prodId.Name).Value = sRow.product_id
            tRow.Cells(Me.prodName.Name).Value = sRow.product_name
            tRow.Cells(Me.prodTaxable.Name).Value = sRow.product_taxable
            tRow.Cells(Me.prodTaxRate.Name).Value = sRow.product_tax_rate
        Next

        dgvProducts.ClearSelection()
    End Sub

    Private Sub FillJobProductList(ByRef dgv As DataGridView)

        dgv.Rows.Clear()
        oJobProdTa.FillByJob(oJobProdTable, _job.Build.JobId)
        For Each oRow As netwyrksDataSet.job_productRow In oJobProdTable.Rows
            Dim _jpId As Integer = oRow.job_product_id
            Dim _productId As Integer = oRow.jp_product_id
            Dim _qty As Integer = oRow.jp_quantity
            Dim _isTaxable As String = If(oRow.Isjp_taxableNull OrElse oRow.jp_taxable = False, "No", "Yes")
            Dim _taxRate As Decimal = If(oRow.Isjp_tax_rateNull, 0.0, oRow.jp_tax_rate)
            Dim _productName As String = "** Missing"
            Dim _supplierName As String = "** Missing"
            Dim _supplierId As Integer = -1
            If oProdTa.FillById(oProdTable, _productId) = 1 Then
                Dim pRow As netwyrksDataSet.productRow = oProdTable.Rows(0)
                _productName = pRow.product_name
                _supplierId = pRow.product_supplier_id
            End If
            If _supplierId > 0 Then
                If oSuppTa.FillById(oSuppTable, _supplierId) = 1 Then
                    Dim sRow As netwyrksDataSet.supplierRow = oSuppTable.Rows(0)
                    _supplierName = sRow.supplier_name
                End If
            End If
            Dim tRow As DataGridViewRow = dgv.Rows(dgv.Rows.Add())
            tRow.Cells(Me.jpSupp.Name).Value = _supplierName
            tRow.Cells(Me.jpProduct.Name).Value = _productName
            tRow.Cells(Me.jpProdId.Name).Value = _productId
            tRow.Cells(Me.jpId.Name).Value = _jpId
            tRow.Cells(Me.jpQty.Name).Value = _qty
            tRow.Cells(Me.jpTaxable.Name).Value = _isTaxable
            tRow.Cells(Me.jpRate.Name).Value = _taxRate
        Next
        dgvJobProducts.ClearSelection()
    End Sub

    Private Sub FrmJobProducts_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        oJobProdTa.Dispose()
        oJobProdTable.Dispose()
        oProdTable.Dispose()
        oProdTa.Dispose()
        oSuppTable.Dispose()
        oSuppTa.Dispose()
    End Sub

    Private Sub DgvProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProducts.SelectionChanged
        If Not isLoading Then
            If dgvProducts.SelectedRows.Count = 1 Then
                isLoading = True
                nudQuantity.Value = 0
                Dim pRow As DataGridViewRow = dgvProducts.SelectedRows(0)
                lblProductName.Text = pRow.Cells(Me.prodName.Name).Value

                _selJpId = -1
                _selProductId = pRow.Cells(Me.prodId.Name).Value
                _selIsTaxable = pRow.Cells(Me.prodTaxable.Name).Value
                _selTaxRate = pRow.Cells(Me.prodTaxRate.Name).Value

                chkTaxable.Checked = _selIsTaxable
                nudTaxRate.Value = _selTaxRate
                isLoading = False
            End If
        End If
    End Sub

    Private Sub DgvSupplier_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSupplier.SelectionChanged
        If Not isLoading Then
            If dgvSupplier.SelectedRows.Count = 1 Then
                isLoading = True
                nudQuantity.Value = 0
                lblProductName.Text = "No product selected"
                _selJpId = -1
                _selProductId = -1
                _selIsTaxable = False
                _selTaxRate = 0.0
                Dim sRow As DataGridViewRow = dgvSupplier.SelectedRows(0)
                _currentSupplierId = sRow.Cells(Me.suppId.Name).Value
                FillProductList()
                isLoading = False
            End If
        End If
    End Sub

    Private Sub DgvJobProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvJobProducts.SelectionChanged
        If Not isLoading Then
            If dgvJobProducts.SelectedRows.Count = 1 Then
                isLoading = True
                dgvSupplier.ClearSelection()
                dgvProducts.ClearSelection()
                isLoading = False
                Dim tRow As DataGridViewRow = dgvJobProducts.SelectedRows(0)

                _selJpId = tRow.Cells(Me.jpId.Name).Value
                _selProductId = tRow.Cells(Me.jpProdId.Name).Value
                _selIsTaxable = (tRow.Cells(Me.jpTaxable.Name).Value = "Yes")
                _selTaxRate = tRow.Cells(Me.jpRate.Name).Value
                Dim _jpProduct As String = tRow.Cells(Me.jpProduct.Name).Value
                nudQuantity.Value = tRow.Cells(Me.jpQty.Name).Value
                lblProductName.Text = _jpProduct
                chkTaxable.Checked = _selIsTaxable
                nudTaxRate.Value = _selTaxRate
            End If

        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If _selProductId > 0 And nudQuantity.Value > 0 Then
            Dim _newJpId As Integer = oJobProdTa.InsertJobProduct(nudQuantity.Value, Now, _selProductId, _job.Build.JobId, chkTaxable.Checked, nudTaxRate.Value)
            If _newJpId > 0 Then
                AuditUtil.addAudit(currentUser.UserId, AuditUtil.RecordType.JobProduct, _newJpId, AuditUtil.AuditableAction.create, "", _selProductId)
            End If
            isLoading = True
            FillJobProductList(dgvJobProducts)
            isLoading = False
        End If
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If _selJpId > 0 Then
            If oJobProdTa.DeleteJobProduct(_selJpId) = 1 Then
                AuditUtil.addAudit(currentUser.UserId, AuditUtil.RecordType.JobProduct, _selJpId, AuditUtil.AuditableAction.delete, "", "")
            End If
            isLoading = True
            nudQuantity.Value = 0
            lblProductName.Text = ""
            _selProductId = -1
            _selJpId = -1
            FillJobProductList(dgvJobProducts)
            isLoading = False
        End If
    End Sub

    Private Sub BtnAdjust_Click(sender As Object, e As EventArgs) Handles btnAdjust.Click
        If _selJpId > 0 Then
            If oJobProdTa.UpdateJobProduct(nudQuantity.Value, Now, _selProductId, _job.Build.JobId, chkTaxable.Checked, nudTaxRate.Value, _selJpId) = 1 Then
                AuditUtil.addAudit(currentUser.UserId, AuditUtil.RecordType.JobProduct, _selJpId, AuditUtil.AuditableAction.delete, "", "")
            End If
            isLoading = True
            FillJobProductList(dgvJobProducts)
            isLoading = False
        End If
    End Sub
End Class