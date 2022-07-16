' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class FrmSupplier
#Region "variables"

    Private ReadOnly oSuppTa As New netwyrksDataSetTableAdapters.supplierTableAdapter
    Private ReadOnly oSuppTable As New netwyrksDataSet.supplierDataTable
    Private _currentSupplier As SupplierBuilder = Nothing
    Private _newSupplier As SupplierBuilder = Nothing
    Private isLoadingProducts As Boolean = False
    Private _supplierId As Integer
    Private INSERT_WIDTH As Integer
    Private UPDATE_WIDTH As Integer
#End Region
#Region "properties"

    Public Property SupplierId() As Integer
        Get
            Return _supplierId
        End Get
        Set(ByVal value As Integer)
            _supplierId = value
        End Set
    End Property
#End Region
#Region "form handlers"
    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub FrmSupplier_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        spProducts.Panel2Collapsed = True
        INSERT_WIDTH = Me.Width - pnlProducts.Width
        UPDATE_WIDTH = Me.Width
        pnlSupplier.Enabled = False
        pnlProducts.Visible = False
        If _supplierId <= 0 Then
            NewSupplier()
        Else
            pnlSupplier.Enabled = True
            _currentSupplier = SupplierBuilder.ASupplierBuilder.StartingWith(_supplierId)
            FillSupplierDetails()
        End If
        SpellCheckUtil.EnableSpellChecking({rtbSuppNotes})
    End Sub
    Private Sub FrmSupplier_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        oSuppTa.Dispose()
        oSuppTable.Dispose()
    End Sub
    Private Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        Dim _suppAdd As Address = AddressBuilder.AnAddress.WithAddress1(txtSuppAddr1.Text.Trim).WithAddress2(txtSuppAddr2.Text.Trim).WithAddress3(txtSuppAddr3.Text.Trim).WithAddress4(txtSuppAddr4.Text.Trim).WithPostcode(txtSuppPostcode.Text.Trim).Build
        With _currentSupplier.Build
            _newSupplier = SupplierBuilder.ASupplierBuilder _
                                .WithSupplierAddress(_suppAdd) _
                                .WithSupplierName(txtSuppName.Text.Trim()) _
                                .WithSupplierChanged(.SupplierChanged) _
                                .WithSupplierCreated(.SupplierCreated) _
                                .WithSupplierEmail(txtSuppEmail.Text.Trim) _
                                .WithSupplierNotes(rtbSuppNotes.Text) _
                                .WithSupplierPhone(txtSuppPhone.Text.Trim) _
                                .WithSupplierDiscount(nudSuppDiscount.Value) _
                                .WithIsAmazon(ChkAmazon.Checked) _
                                .WithSupplierUrl(TxtWeb.Text)
        End With

        If _supplierId > 0 Then
            If AmendSupplier() Then
                Me.Close()
            End If
        Else
            If InsertSupplier() Then
                pnlProducts.Visible = False
                LblStatus.Text = "Inserted New Supplier"
                LblStatus.BackColor = Color.SeaGreen
                Me.Close()
            End If
        End If

    End Sub
    Private Sub DgvProducts_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvProducts.CellDoubleClick
        If dgvProducts.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = dgvProducts.SelectedRows(0)
            Dim oProductId As Integer = oRow.Cells(Me.prodId.Name).Value
            Using _ProductForm As New frmProduct
                _ProductForm.TheSupplier = _currentSupplier.Build
                _ProductForm.ProductId = oProductId
                _ProductForm.ShowDialog()
            End Using
            FillProductsList(_supplierId)
        End If
    End Sub
    Private Sub BtnAddProduct_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddProduct.Click
        Using _productForm As New frmProduct
            _productForm.TheSupplier = _currentSupplier.Build
            _productForm.ShowDialog()
            FillProductsList(_supplierId)
        End Using
    End Sub
    Private Sub DgvProducts_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvProducts.SelectionChanged
        spProducts.Panel2Collapsed = True
        If Not isLoadingProducts Then
            If dgvProducts.SelectedRows.Count = 1 Then
                Dim cRow As DataGridViewRow = dgvProducts.SelectedRows(0)
                Dim _selProdId As Integer = cRow.Cells(Me.prodId.Name).Value
                If _selProdId > 0 Then
                    Dim _selectedProduct As Product = ProductBuilder.AProductBuilder.StartingWith(_selProdId).Build
                    txtProductDesc.Text = _selectedProduct.ProductDescription
                    txtCost.Text = "£" & CStr(_selectedProduct.ProductCost)
                    txtPrice.Text = "£" & CStr(_selectedProduct.ProductPrice)
                    If My.Settings.showProduct Then spProducts.Panel2Collapsed = False
                End If
            End If
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub FillSupplierDetails()
        Me.Width = UPDATE_WIDTH
        LblStatus.Text = "Updating Supplier"
        LblStatus.BackColor = Color.SlateGray
        btnUpdate.Text = "Update"
        With _currentSupplier.Build
            txtSuppName.Text = .SupplierName
            txtSuppAddr1.Text = .SupplierAddress.Address1
            txtSuppAddr2.Text = .SupplierAddress.Address2
            txtSuppAddr3.Text = .SupplierAddress.Address3
            txtSuppAddr4.Text = .SupplierAddress.Address4
            txtSuppPostcode.Text = .SupplierAddress.Postcode
            txtSuppPhone.Text = .SupplierPhone
            txtSuppEmail.Text = .SupplierEmail
            nudSuppDiscount.Value = .SupplierDiscount
            rtbSuppNotes.Text = .SupplierNotes
            ChkAmazon.Checked = .IsSupplierAmazon
            TxtWeb.Text = .SupplierUrl
        End With
        pnlProducts.Visible = True
        FillProductsList(_supplierId)
    End Sub
    Private Function InsertSupplier() As Boolean
        Dim isInsertOK As Boolean = False
        With _newSupplier.Build
            _supplierId = oSuppTa.InsertSupplier(.SupplierName, .SupplierAddress.Address1, .SupplierAddress.Address2, .SupplierAddress.Address3, .SupplierAddress.Address4, .SupplierAddress.Postcode, .SupplierPhone, .SupplierEmail, .SupplierDiscount, .SupplierNotes, Now, .SupplierAmazon, .SupplierUrl)
            If _supplierId > 0 Then
                isInsertOK = True
                AuditUtil.AddAudit(currentUser.UserId, AuditUtil.RecordType.Supplier, _supplierId, AuditUtil.AuditableAction.create, "", .ToString)
            Else
                MsgBox("Supplier not saved", MsgBoxStyle.Exclamation, "Error")
                LogUtil.Problem("Supplier " & .SupplierName & " not saved")
                isInsertOK = False
            End If
        End With
        Return isInsertOK
    End Function
    Private Function AmendSupplier() As Boolean
        Dim isAmendOK As Boolean = False
        With _newSupplier.Build
            If oSuppTa.UpdateSupplier(.SupplierName, .SupplierAddress.Address1, .SupplierAddress.Address2, .SupplierAddress.Address3, .SupplierAddress.Address4, .SupplierAddress.Postcode, .SupplierPhone, .SupplierEmail, .SupplierDiscount, .SupplierNotes, Now, .SupplierAmazon, .SupplierUrl, _supplierId) = 1 Then
                isAmendOK = True
                AuditUtil.AddAudit(currentUser.UserId, AuditUtil.RecordType.Supplier, _supplierId, AuditUtil.AuditableAction.update, _currentSupplier.Build.ToString, .ToString)
            Else
                isAmendOK = False
                MsgBox("Supplier not updated", MsgBoxStyle.Exclamation, "Error")
                LogUtil.Problem("Supplier " & .SupplierName & " not updated")
            End If
        End With
        Return isAmendOK
    End Function
    Private Sub NewSupplier()
        LblStatus.Text = "Adding New Supplier"
        btnUpdate.Text = "Create"
        LblStatus.BackColor = Color.SteelBlue
        _currentSupplier = SupplierBuilder.ASupplierBuilder.StartingWithNothing
        ClearSupplierDetails()
        pnlSupplier.Enabled = True
        pnlProducts.Visible = False
        dgvProducts.Rows.Clear()
    End Sub
    Private Sub ClearSupplierDetails()
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
        ChkAmazon.Checked = False
        TxtWeb.Text = ""
    End Sub
    Private Sub FillProductsList(ByVal suppId As Integer)
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

    Private Sub ChkAmazon_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAmazon.CheckedChanged
        With ChkAmazon
            If .Checked Then
                .BackColor = Color.DarkRed
                .ForeColor = Color.White
            Else
                .BackColor = Color.WhiteSmoke
                .ForeColor = Color.Black
            End If
        End With
    End Sub


#End Region
End Class