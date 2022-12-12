' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.ComponentModel

Public Class FrmJobProducts
#Region "variables"
    Private isLoading As Boolean = False
    Private _currentSupplierId As Integer = -1
    Private _job As Job
    Private _selJpId As Integer = -1
    Private _selProductId As String = -1
    Private _selIsTaxable As Boolean = False
    Private _selTaxRate As Decimal = 0.0
    Private _selPrice As Decimal = 0.0
#End Region
#Region "properties"
    Public Property TheJob() As Job
        Get
            Return _job
        End Get
        Set(ByVal value As Job)
            _job = value
        End Set
    End Property
#End Region
#Region "form handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub FrmJobProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.JobProductsFormPos)
        isLoading = True
        _currentSupplierId = -1
        FillSupplierList()
        FillProductList()
        FillJobProductList(dgvJobProducts)
        lblJobName.Text = _job.JobName
        lblProductName.Text = ""
        KeyPreview = True
        isLoading = False
    End Sub
    Private Sub FrmJobProducts_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.JobProductsFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub DgvProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProducts.SelectionChanged
        If Not isLoading Then
            If dgvProducts.SelectedRows.Count = 1 Then
                isLoading = True
                nudQuantity.Value = 1
                Dim pRow As DataGridViewRow = dgvProducts.SelectedRows(0)
                lblProductName.Text = pRow.Cells(prodName.Name).Value
                _selJpId = -1
                _selProductId = pRow.Cells(prodId.Name).Value
                _selIsTaxable = pRow.Cells(prodTaxable.Name).Value
                _selTaxRate = pRow.Cells(prodTaxRate.Name).Value
                chkTaxable.Checked = _selIsTaxable
                nudTaxRate.Value = _selTaxRate
                nudPrice.Value = pRow.Cells(prodPrice.Name).Value
            End If
        End If
    End Sub
    Private Sub DgvSupplier_SelectionChanged(sender As Object, e As EventArgs) Handles DgvSupplier.SelectionChanged
        If Not isLoading Then
            If DgvSupplier.SelectedRows.Count = 1 Then
                isLoading = True
                nudQuantity.Value = 0
                lblProductName.Text = "No product selected"
                _selJpId = -1
                _selProductId = -1
                _selIsTaxable = False
                _selTaxRate = 0.0
                Dim sRow As DataGridViewRow = DgvSupplier.SelectedRows(0)
                _currentSupplierId = sRow.Cells(suppId.Name).Value
                FillProductList()
                isLoading = False
            End If
        End If
    End Sub
    Private Sub DgvJobProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvJobProducts.SelectionChanged
        If Not isLoading Then
            If dgvJobProducts.SelectedRows.Count = 1 Then
                isLoading = True
                DgvSupplier.ClearSelection()
                dgvProducts.ClearSelection()
                isLoading = False
                Dim tRow As DataGridViewRow = dgvJobProducts.SelectedRows(0)
                _selJpId = tRow.Cells(jpId.Name).Value
                _selProductId = tRow.Cells(jpProdId.Name).Value
                _selIsTaxable = tRow.Cells(jpTaxable.Name).Value = "Yes"
                _selTaxRate = tRow.Cells(jpRate.Name).Value
                _selPrice = tRow.Cells(jpprice.Name).Value
                Dim _jpProduct As String = tRow.Cells(jpProduct.Name).Value
                nudQuantity.Value = tRow.Cells(jpQty.Name).Value
                lblProductName.Text = _jpProduct
                chkTaxable.Checked = _selIsTaxable
                nudTaxRate.Value = _selTaxRate
                nudPrice.Value = _selPrice
            Else
                nudQuantity.Value = 1
                nudPrice.Value = 0.00
                nudTaxRate.Value = 0.00
                chkTaxable.Checked = False
            End If
        End If
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If _selProductId > 0 And nudQuantity.Value > 0 Then
            Dim _newJobProduct As JobProduct = JobProductBuilder.AJobProduct.StartingWithNothing _
            .WithProduct(_selProductId) _
            .WithJob(_job.JobId) _
            .WithTaxable(chkTaxable.Checked) _
            .WithQuantity(nudQuantity.Value) _
            .WithTaxRate(nudTaxRate.Value) _
            .WithPrice(nudPrice.Value) _
            .WithCreated(Now) _
            .Build
            Dim _newJpId As Integer = InsertJobProduct(_newJobProduct)

            If _newJpId > 0 Then
                AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.JobProduct, _newJpId, AuditUtil.AuditableAction.create, "", _newJobProduct.ToString)
            End If
            isLoading = True
            FillJobProductList(dgvJobProducts)
            isLoading = False
        End If
    End Sub
    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If _selJpId > 0 Then
            If DeleteJobProduct(_selJpId) = 1 Then
                AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.JobProduct, _selJpId, AuditUtil.AuditableAction.delete, "", "")
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
            Dim _newJobProduct As JobProduct = JobProductBuilder.AJobProduct.StartingWithNothing _
            .WithJobProductId(_selJpId) _
            .WithProduct(_selProductId) _
            .WithJob(_job.JobId) _
            .WithTaxable(chkTaxable.Checked) _
            .WithQuantity(nudQuantity.Value) _
            .WithTaxRate(nudTaxRate.Value) _
            .WithPrice(nudPrice.Value) _
            .WithCreated(Now) _
            .Build


            If UpdateJobProduct(_newJobProduct) = 1 Then
                AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.JobProduct, _selJpId, AuditUtil.AuditableAction.update, "", _newJobProduct.ToString)
            End If
            isLoading = True
            FillJobProductList(dgvJobProducts)
            isLoading = False
        End If
    End Sub
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            AddSupplier()
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub AddSupplier()
        Using _suppform As New FrmSupplier
            _suppform.SupplierId = -1
            _suppform.ShowDialog()
        End Using
        FillSupplierList()
    End Sub
    Private Sub FillSupplierList()
        DgvSupplier.Rows.Clear()
        Try
            Dim i As Integer = DgvSupplier.Rows.Add()
            Dim firstRow As DataGridViewRow = DgvSupplier.Rows(i)
            firstRow.Cells(suppName.Name).Value = "ALL"
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

        Dim _supplierList As List(Of Supplier) = GetSuppliers()
        For Each _supplier As Supplier In _supplierList
            Dim tRow As DataGridViewRow = DgvSupplier.Rows(DgvSupplier.Rows.Add())
            tRow.Cells(suppId.Name).Value = _supplier.SupplierId
            tRow.Cells(suppName.Name).Value = _supplier.SupplierName
        Next
        DgvSupplier.ClearSelection()
    End Sub
    Private Sub FillProductList()
        Dim _productList As List(Of Product)

        dgvProducts.Rows.Clear()
        If _currentSupplierId > 0 Then

            _productList = GetProductsBySupplier(_currentSupplierId)
            ' oProdTa.FillBySupplier(oProdTable, _currentSupplierId)
        Else
            _productList = GetAllProducts()
            '   oProdTa.Fill(oProdTable)
        End If
        '    For Each sRow As netwyrksDataSet.productRow In oProdTable.Rows
        For Each _product As Product In _productList
            Dim tRow As DataGridViewRow = dgvProducts.Rows(dgvProducts.Rows.Add())
            With _product
                tRow.Cells(prodId.Name).Value = .ProductId
                tRow.Cells(prodName.Name).Value = .ProductName
                tRow.Cells(prodTaxable.Name).Value = .IsProductTaxable
                tRow.Cells(prodTaxRate.Name).Value = .ProductTaxRate
                tRow.Cells(prodPrice.Name).Value = .ProductPrice
            End With
        Next
        dgvProducts.ClearSelection()
    End Sub
    Private Sub FillJobProductList(ByRef dgv As DataGridView)
        dgv.Rows.Clear()
        Dim _jobProductList As List(Of JobProduct) = GetJobProductByJob(_job)

        For Each _jobProduct As JobProduct In _jobProductList
            With _jobProduct
                Dim _jpId As Integer = .JobProductId
                Dim _productId As Integer = .ThisProduct.ProductId
                Dim _qty As Integer = .Quantity
                Dim _isTaxable As String = If(.Taxable = False, "No", "Yes")
                Dim _taxRate As Decimal = .Tax_Rate
                Dim _jobprice As Decimal = .Price
                Dim _productName As String = "** Missing"
                Dim _supplierName As String = "** Missing"
                Dim _supplierId As Integer = -1

                Dim _product As Product = GetProductById(_productId)
                _productName = _product.ProductName
                _supplierId = _product.ProductSupplierId

                If _supplierId > 0 Then
                    Dim _supplier As Supplier = GetSupplierById(_supplierId)
                    _supplierName = _supplier.SupplierName
                End If

                Dim tRow As DataGridViewRow = dgv.Rows(dgv.Rows.Add())
                tRow.Cells(jpSupp.Name).Value = _supplierName
                tRow.Cells(jpProduct.Name).Value = _productName
                tRow.Cells(jpProdId.Name).Value = _productId
                tRow.Cells(jpId.Name).Value = _jpId
                tRow.Cells(jpQty.Name).Value = _qty
                tRow.Cells(jpTaxable.Name).Value = _isTaxable
                tRow.Cells(jpRate.Name).Value = _taxRate
                tRow.Cells(jpprice.Name).Value = _jobprice
            End With
        Next
        dgvJobProducts.ClearSelection()
    End Sub

    Private Sub LblF5_Click(sender As Object, e As EventArgs) Handles LblF5.Click
        AddSupplier()
    End Sub

    Private Sub DgvSupplier_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSupplier.CellDoubleClick
        If DgvSupplier.SelectedRows.Count = 1 Then
            Dim dRow As DataGridViewRow = DgvSupplier.SelectedRows(0)
            Dim _suppId As Integer = dRow.Cells(suppId.Name).Value
            Using _suppForm As New FrmSupplier
                _suppForm.SupplierId = _suppId
                _suppForm.ShowDialog()
            End Using
            isLoading = True
            FillSupplierList()
            isLoading = False
        End If
    End Sub

    Private Sub FrmJobProducts_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.JobProductsFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

#End Region
End Class