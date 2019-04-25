Public Class frmSupplier
    Private oSuppTa As New netwyrksDataSetTableAdapters.supplierTableAdapter
    Private oSuppTable As New netwyrksDataSet.supplierDataTable
    Private _currentSupplier As SupplierBuilder = Nothing
    Private _newSupplier As SupplierBuilder = Nothing
    Private isLoadingProducts As Boolean = False
    Private _supplierId As Integer
    Private INSERT_WIDTH As Integer
    Private UPDATE_WIDTH As Integer

    Public Property supplierId() As Integer
        Get
            Return _supplierId
        End Get
        Set(ByVal value As Integer)
            _supplierId = value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmSupplier_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        spProducts.Panel2Collapsed = True
        INSERT_WIDTH = Me.Width - pnlProducts.Width
        UPDATE_WIDTH = Me.Width
        pnlSupplier.Enabled = False
        pnlProducts.Visible = False
        If _supplierId = 0 Then
            newSupplier()
        Else
            pnlSupplier.Enabled = True
            _currentSupplier = SupplierBuilder.aSupplierBuilder.startingWith(_supplierId)
            fillSupplierDetails()
        End If
    End Sub


    Private Sub frmSupplier_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        oSuppTa.Dispose()
        oSuppTable.Dispose()
    End Sub

    Private Sub fillSupplierDetails()
        Me.Width = UPDATE_WIDTH
        With _currentSupplier.build
            txtSuppName.Text = .supplierName
            txtSuppAddr1.Text = .supplierAddress.address1
            txtSuppAddr2.Text = .supplierAddress.address2
            txtSuppAddr3.Text = .supplierAddress.address3
            txtSuppAddr4.Text = .supplierAddress.address4
            txtSuppPostcode.Text = .supplierAddress.postcode
            txtSuppPhone.Text = .supplierPhone
            txtSuppEmail.Text = .supplierEmail
            nudSuppDiscount.Value = .supplierDiscount
            rtbSuppNotes.Text = .supplierNotes
        End With
        pnlProducts.Visible = True
        fillProductsList(_supplierId)
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        Dim _suppAdd As Address = AddressBuilder.anAddress.withAddress1(txtSuppAddr1.Text.Trim).withAddress2(txtSuppAddr2.Text.Trim).withAddress3(txtSuppAddr3.Text.Trim).withAddress4(txtSuppAddr4.Text.Trim).withPostcode(txtSuppPostcode.Text.Trim).build
        With _currentSupplier.build
            _newSupplier = SupplierBuilder.aSupplierBuilder.withSupplierAddress(_suppAdd).withSupplierName(txtSuppName.Text.Trim()).withSupplierChanged(.supplierChanged).withSupplierCreated(.supplierCreated).withSupplierEmail(txtSuppEmail.Text.Trim).withSupplierNotes(rtbSuppNotes.Text).withSupplierPhone(txtSuppPhone.Text.Trim).withSupplierDiscount(nudSuppDiscount.Value)
        End With

        If _supplierId > 0 Then
            If amendSupplier() Then
                Me.Close()
            End If
        Else
            If insertSupplier() Then
                pnlProducts.Visible = False
            Else
                Me.Close()
            End If
        End If

    End Sub

    Private Function insertSupplier() As Boolean
        Dim isInsertOK As Boolean = False
        With _newSupplier.build
            _supplierId = oSuppTa.InsertSupplier(.supplierName, .supplierAddress.address1, .supplierAddress.address2, .supplierAddress.address3, .supplierAddress.address4, .supplierAddress.postcode, .supplierPhone, .supplierEmail, .supplierDiscount, .supplierNotes, Now)
            If _supplierId > 0 Then
                isInsertOK = True
                AuditUtil.addAudit(currentUser.userId, AuditUtil.RecordType.Supplier, _supplierId, AuditUtil.AuditableAction.create, "", .ToString)
            Else
                MsgBox("Supplier not saved", MsgBoxStyle.Exclamation, "Error")
                LogUtil.Problem("Supplier " & .supplierName & " not saved")
                isInsertOK = False
            End If
        End With
        Return isInsertOK
    End Function

    Private Function amendSupplier() As Boolean
        Dim isAmendOK As Boolean = False
        With _newSupplier.build
            If oSuppTa.UpdateSupplier(.supplierName, .supplierAddress.address1, .supplierAddress.address2, .supplierAddress.address3, .supplierAddress.address4, .supplierAddress.postcode, .supplierPhone, .supplierEmail, .supplierDiscount, .supplierNotes, Now, _supplierId) = 1 Then
                isAmendOK = True
                AuditUtil.addAudit(currentUser.userId, AuditUtil.RecordType.Supplier, _supplierId, AuditUtil.AuditableAction.update, _currentSupplier.build.ToString, .ToString)
            Else
                isAmendOK = False
                MsgBox("Supplier not updated", MsgBoxStyle.Exclamation, "Error")
                LogUtil.Problem("Supplier " & .supplierName & " not updated")
            End If
        End With
        Return isAmendOK
    End Function

    Private Sub newSupplier()
        _currentSupplier = SupplierBuilder.aSupplierBuilder.startingWithNothing
        clearSupplierDetails()
        pnlSupplier.Enabled = True
        pnlProducts.Visible = False
        dgvProducts.Rows.Clear()
    End Sub

    Private Sub clearSupplierDetails()
        txtSuppName.Text = ""
        txtSuppAddr1.Text = ""
        txtSuppAddr2.Text = ""
        txtSuppAddr3.Text = ""
        txtSuppAddr4.Text = ""
        txtSuppPostcode.Text = ""
        txtSuppPhone.Text = ""
        txtSuppEmail.Text = ""
        nudSuppDiscount.Value = 0
        rtbSuppNotes.Text = ""

    End Sub

    Private Sub fillProductsList(ByVal suppId As Integer)
        isLoadingProducts = True
        dgvProducts.Rows.Clear()
        'Dim pRow As DataGridViewRow = dgvProducts.Rows(dgvProducts.Rows.Add)
        'pRow.Cells(Me.prodId.Name).Value = -1
        Dim oProductTa As New netwyrksDataSetTableAdapters.productTableAdapter
        Dim oProductTable As New netwyrksDataSet.productDataTable
        oProductTa.FillBySupplier(oProductTable, suppId)
        For Each oRow As netwyrksDataSet.productRow In oProductTable.Rows
            Dim tRow As DataGridViewRow = dgvProducts.Rows(dgvProducts.Rows.Add)
            tRow.Cells(Me.prodId.Name).Value = oRow.product_id
            tRow.Cells(Me.prodName.Name).Value = oRow.product_name
        Next
        dgvProducts.ClearSelection()
        oProductTa.Dispose()
        oProductTable.Dispose()
        isLoadingProducts = False
    End Sub

    Private Sub dgvProducts_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvProducts.CellDoubleClick
        If dgvProducts.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = dgvProducts.SelectedRows(0)
            Dim oProductId As Integer = oRow.Cells(Me.prodId.Name).Value
            Using _ProductForm As New frmProduct
                _ProductForm.theSupplier = _currentSupplier.build
                _ProductForm.productId = oProductId
                _ProductForm.ShowDialog()
            End Using
            fillProductsList(_supplierId)
        End If
    End Sub

    Private Sub btnAddProduct_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddProduct.Click
        Using _productForm As New frmProduct
            _productForm.theSupplier = _currentSupplier.build
            _productForm.ShowDialog()
            fillProductsList(_supplierId)
        End Using
    End Sub

    Private Sub dgvProducts_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvProducts.SelectionChanged
        spProducts.Panel2Collapsed = True
        If Not isLoadingProducts Then
            If dgvProducts.SelectedRows.Count = 1 Then
                Dim cRow As DataGridViewRow = dgvProducts.SelectedRows(0)
                Dim _selProdId As Integer = cRow.Cells(Me.prodId.Name).Value
                If _selProdId > 0 Then
                    Dim _selectedProduct As Product = ProductBuilder.aProductBuilder.startingWith(_selProdId).build
                    txtProductDesc.Text = _selectedProduct.productDescription
                    txtCost.Text = "£" & CStr(_selectedProduct.productCost)
                    txtPrice.Text = "£" & CStr(_selectedProduct.productPrice)
                    If My.Settings.showProduct Then spProducts.Panel2Collapsed = False
                End If
            End If
        End If
    End Sub
End Class