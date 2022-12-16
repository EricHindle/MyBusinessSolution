' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.ComponentModel

Public Class FrmJobProducts
#Region "variables"
    Private isLoading As Boolean = False
    Private _currentSupplierId As Integer = -1
#End Region
#Region "properties"
    Private _job As Job
    Private _selectedJobProduct As JobProduct
    Public Property SelectedJobProduct() As JobProduct
        Get
            Return _selectedJobProduct
        End Get
        Set(ByVal value As JobProduct)
            _selectedJobProduct = value
        End Set
    End Property
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
        If _selectedJobProduct IsNot Nothing Then
            SelectSupplier(_selectedJobProduct.ThisProduct.ProductSupplierId)
            SelectProduct(_selectedJobProduct.ThisProduct.ProductId)
            SelectJobProduct(_selectedJobProduct.JobProductId)
            FillProductDetails()
        End If
        isLoading = False
    End Sub
    Private Sub FrmJobProducts_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.JobProductsFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub DgvProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProducts.SelectionChanged
        If Not isLoading Then
            ClearProductDetails()
            If dgvProducts.SelectedRows.Count = 1 Then
                isLoading = True
                Dim pRow As DataGridViewRow = dgvProducts.SelectedRows(0)
                Dim _ProductId As Integer = pRow.Cells(prodId.Name).Value
                Dim _jpId As Integer = SelectJobProductByProduct(_ProductId)
                If _jpId > 0 Then
                    _selectedJobProduct = JobProductBuilder.AJobProduct.StartingWith(_jpId).Build
                Else
                    Dim _product As Product = GetProductById(_ProductId)
                    _selectedJobProduct = JobProductBuilder.AJobProduct.StartingWithNothing.WithJob(_job).WithProduct(_product).Build
                End If
                SelectSupplier(_selectedJobProduct.ThisProduct.ProductSupplierId)
                isLoading = False
                FillProductDetails()
            Else
                dgvJobProducts.ClearSelection()
                SelectedJobProduct = JobProductBuilder.AJobProduct.StartingWithNothing.Build
            End If
        End If
    End Sub
    Private Sub DgvSupplier_SelectionChanged(sender As Object, e As EventArgs) Handles DgvSupplier.SelectionChanged
        If Not isLoading Then
            isLoading = True
            dgvJobProducts.ClearSelection()
            dgvProducts.ClearSelection()
            ClearProductDetails()
            _selectedJobProduct = Nothing
            If DgvSupplier.SelectedRows.Count = 1 Then
                Dim sRow As DataGridViewRow = DgvSupplier.SelectedRows(0)
                _currentSupplierId = sRow.Cells(suppId.Name).Value
                FillProductList()
            End If
            isLoading = False
        End If
    End Sub
    Private Sub DgvJobProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvJobProducts.SelectionChanged
        If Not isLoading Then
            If dgvJobProducts.SelectedRows.Count = 1 Then
                Dim tRow As DataGridViewRow = dgvJobProducts.SelectedRows(0)
                _selectedJobProduct = JobProductBuilder.AJobProduct.StartingWith(tRow.Cells(jpId.Name).Value).Build
                isLoading = True
                SelectSupplier(_selectedJobProduct.ThisProduct.ProductSupplierId)
                SelectProduct(_selectedJobProduct.ThisProduct.ProductId)
                isLoading = False
                FillProductDetails()
            Else
                ClearProductDetails()
            End If
        End If
    End Sub

    Private Sub FillProductDetails()
        nudQuantity.Value = _selectedJobProduct.Quantity
        lblProductName.Text = _selectedJobProduct.ThisProduct.ProductName
        chkTaxable.Checked = _selectedJobProduct.Taxable
        nudTaxRate.Value = _selectedJobProduct.Tax_Rate
        nudPrice.Value = _selectedJobProduct.Price
        NudUnitPrice.Value = _selectedJobProduct.ThisProduct.ProductPrice
    End Sub

    Private Sub ClearProductDetails()
        lblProductName.Text = "Select a product"
        nudQuantity.Value = 1
        nudPrice.Value = 0.00
        NudUnitPrice.Value = 0.00
        nudTaxRate.Value = 0.00
        chkTaxable.Checked = False
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If dgvJobProducts.SelectedRows.Count = 1 Then
            MsgBox("Use Adjust", MsgBoxStyle.Exclamation, "Error")
        Else
            If dgvProducts.SelectedRows.Count = 1 And nudQuantity.Value > 0 Then
                Dim _newJobProduct As JobProduct = JobProductBuilder.AJobProduct.StartingWith(_selectedJobProduct) _
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
        End If
    End Sub
    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dgvJobProducts.SelectedRows.Count > 0 Then
            Dim _selJpId As Integer = _selectedJobProduct.JobProductId
            If DeleteJobProduct(_selJpId) = 1 Then
                AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.JobProduct, _selJpId, AuditUtil.AuditableAction.delete, "", "")
            End If
            ClearProductDetails()
            isLoading = True
            FillJobProductList(dgvJobProducts)
            dgvProducts.ClearSelection()
            DgvSupplier.ClearSelection()
            isLoading = False
        End If
    End Sub
    Private Sub BtnAdjust_Click(sender As Object, e As EventArgs) Handles btnAdjust.Click
        If dgvJobProducts.SelectedRows.Count > 0 Then
            Dim _selJpId As Integer = _selectedJobProduct.JobProductId
            Dim _newJobProduct As JobProduct = JobProductBuilder.AJobProduct.StartingWithNothing _
            .WithJobProductId(_selectedJobProduct.JobProductId) _
            .WithProduct(_selectedJobProduct.ThisProduct) _
            .WithJob(_selectedJobProduct.ThisJob) _
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
        Else
            _productList = GetAllProducts()
        End If
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
        Dim _jobProductList As List(Of FullJobProduct) = GetJobProductViewByJob(_job.JobId)

        For Each _jobProduct As FullJobProduct In _jobProductList
            With _jobProduct
                Dim _jpId As Integer = .JobProductId
                Dim _productId As Integer = .ThisProduct.ProductId
                Dim _qty As Integer = .Quantity
                Dim _isTaxable As String = If(.Taxable = False, "No", "Yes")
                Dim _taxRate As Decimal = .Tax_Rate
                Dim _jobprice As Decimal = .Price
                Dim _productName As String = If(.ThisProduct IsNot Nothing, .ThisProduct.ProductName, "** Missing")
                Dim _supplierName As String = If(.ProductSupplier IsNot Nothing, .ProductSupplier.SupplierName, "** Missing")

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

    Private Sub nudQuantity_ValueChanged(sender As Object, e As EventArgs) Handles nudQuantity.ValueChanged
        nudPrice.Value = NudUnitPrice.Value * nudQuantity.Value
    End Sub
    Private Sub SelectJobProduct(pJobProductId As Integer)
        For Each oRow As DataGridViewRow In dgvJobProducts.Rows
            If oRow.Cells(jpId.Name).Value = pJobProductId Then
                oRow.Selected = True
                Exit For
            End If
        Next
    End Sub
    Private Function SelectJobProductByProduct(pProductId As Integer) As Boolean
        Dim isFound As Boolean = False
        For Each oRow As DataGridViewRow In dgvJobProducts.Rows
            If oRow.Cells(jpProdId.Name).Value = pProductId Then
                oRow.Selected = True
                dgvJobProducts.FirstDisplayedScrollingRowIndex = oRow.Index
                isFound = True
                Exit For
            End If
        Next
        Return isFound
    End Function
    Private Sub SelectProduct(pProductId As Integer)
        For Each oRow As DataGridViewRow In dgvProducts.Rows
            If oRow.Cells(prodId.Name).Value = pProductId Then
                oRow.Selected = True
                dgvProducts.FirstDisplayedScrollingRowIndex = oRow.Index
                Exit For
            End If
        Next
    End Sub
    Private Sub SelectSupplier(pSupplierId As Integer)
        For Each oRow As DataGridViewRow In DgvSupplier.Rows
            If oRow.Cells(suppId.Name).Value = pSupplierId Then
                oRow.Selected = True
                DgvSupplier.FirstDisplayedScrollingRowIndex = oRow.Index
                Exit For
            End If
        Next
    End Sub
#End Region
End Class