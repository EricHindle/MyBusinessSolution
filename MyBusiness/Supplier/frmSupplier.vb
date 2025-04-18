﻿' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports HindlewareLib.Domain.Objects
Imports HindlewareLib.Logging

Public Class FrmSupplier
#Region "variables"
    Private _currentSupplier As Supplier = Nothing
    Private _newSupplier As Supplier = SupplierBuilder.ASupplier.StartingWithNothing.Build
    Private isLoadingProducts As Boolean = False
    Private _supplierId As Integer
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
    Private Sub FrmSupplier_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Starting", MyBase.Name)
        If GetFormPos(Me, My.Settings.SupplierFormPos) Then
            SplitContainer1.SplitterDistance = My.Settings.SuppSplitterDist1
            spProducts.SplitterDistance = My.Settings.SuppSplitterDist2
        End If
        spProducts.Panel2Collapsed = True
        pnlProducts.Enabled = False
        If _supplierId <= 0 Then
            NewSupplier()
        Else
            _currentSupplier = SupplierBuilder.ASupplier.StartingWith(_supplierId).Build
            FillSupplierDetails()
        End If
        SpellCheckUtil.EnableSpellChecking({rtbSuppNotes})
    End Sub
    Private Sub FrmSupplier_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.SupplierFormPos = SetFormPos(Me)
        My.Settings.SuppSplitterDist1 = SplitContainer1.SplitterDistance
        My.Settings.SuppSplitterDist2 = spProducts.SplitterDistance
        My.Settings.Save()
    End Sub
    Private Sub DgvProducts_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvProducts.CellDoubleClick
        ShowProductForm()
    End Sub
    Private Sub BtnAddProduct_Click(ByVal sender As Object, ByVal e As EventArgs)
        ShowProductForm(-1)
    End Sub
    Private Sub DgvProducts_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvProducts.SelectionChanged
        spProducts.Panel2Collapsed = True
        If Not isLoadingProducts Then
            If dgvProducts.SelectedRows.Count = 1 Then
                Dim cRow As DataGridViewRow = dgvProducts.SelectedRows(0)
                Dim _selProdId As Integer = cRow.Cells(prodId.Name).Value
                If _selProdId > 0 Then
                    Dim _selectedProduct As Product = GetProductById(_selProdId)
                    txtProductDesc.Text = _selectedProduct.ProductDescription
                    txtCost.Text = "£" & _selectedProduct.ProductCost
                    txtPrice.Text = "£" & _selectedProduct.ProductPrice
                    If My.Settings.ShowProduct Then spProducts.Panel2Collapsed = False
                End If
            End If
        End If
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
    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        Close()
    End Sub
    Private Sub PicUpdate_Click(sender As Object, e As EventArgs) Handles PicUpdate.Click
        If IsValidSupplier() Then
            Dim _suppAdd As Address = HindlewareLib.Domain.Builders.AddressBuilder.AnAddress _
                                                    .WithAddress1(txtSuppAddr1.Text.Trim) _
                                                    .WithAddress2(txtSuppAddr2.Text.Trim) _
                                                    .WithAddress3(txtSuppAddr3.Text.Trim) _
                                                    .WithAddress4(txtSuppAddr4.Text.Trim) _
                                                    .WithPostcode(txtSuppPostcode.Text.ToUpper.Trim) _
                                                    .Build
            _newSupplier = SupplierBuilder.ASupplier.StartingWith(_currentSupplier) _
                            .WithSupplierId(_supplierId) _
                            .WithSupplierAddress(_suppAdd) _
                            .WithSupplierName(txtSuppName.Text.Trim()) _
                            .WithSupplierEmail(txtSuppEmail.Text.Trim) _
                            .WithSupplierNotes(rtbSuppNotes.Text) _
                            .WithSupplierPhone(txtSuppPhone.Text.Trim) _
                            .WithSupplierDiscount(nudSuppDiscount.Value) _
                            .WithIsAmazon(ChkAmazon.Checked) _
                            .WithSupplierUrl(TxtWeb.Text).Build
            If _supplierId > 0 Then
                If AmendSupplier() Then
                    Close()
                End If
            Else
                If CreateSupplier() Then
                    LblAction.Text = "Added the new supplier"
                    Close()
                End If
            End If
        Else
            LblAction.Text = "Invalid supplier details"
        End If

    End Sub
    Private Sub PicOpenWeb_Click(sender As Object, e As EventArgs) Handles PicOpenWeb.Click
        If Not String.IsNullOrWhiteSpace(TxtWeb.Text) Then
            Try
                Process.Start(TxtWeb.Text)
            Catch ex As Exception
                LogUtil.ShowException(ex, "Exception opening web site", LblStatus, Name)
            End Try
        End If
    End Sub
    Private Sub BtnAddJobProduct_Click(sender As Object, e As EventArgs) Handles BtnAddJobProduct.Click
        ShowProductForm(-1)
    End Sub
    Private Sub BtnUpdateJobTask_Click(sender As Object, e As EventArgs) Handles BtnUpdateJobProduct.Click
        ShowProductForm()
    End Sub
#End Region
#Region "subroutines"
    Private Sub FillSupplierDetails()
        LblAction.Text = "Updating a supplier"
        PicUpdate.Image = My.Resources.update_database
        ToolTip1.SetToolTip(PicUpdate, "Update the supplier")
        With _currentSupplier
            LogUtil.Info("Amending supplier " & _supplierId & " : " & .SupplierName, MyBase.Name)
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
        pnlProducts.Enabled = True
        FillProductsList(_supplierId)
    End Sub
    Private Function CreateSupplier() As Boolean
        Dim isInsertOK As Boolean
        _supplierId = InsertSupplier(_newSupplier)
        If _supplierId > 0 Then
            isInsertOK = True
            AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Supplier, _supplierId, AuditUtil.AuditableAction.create, "", _newSupplier.ToString)
            LogUtil.Info("Supplier created OK", MyBase.Name)
        Else
            MsgBox("Supplier not saved", MsgBoxStyle.Exclamation, "Error")
            LogUtil.Problem("Supplier " & _newSupplier.SupplierName & " not saved")
            isInsertOK = False
        End If
        Return isInsertOK
    End Function
    Private Function AmendSupplier() As Boolean
        Dim isAmendOK As Boolean
        LogUtil.Info("Updating", Name)
        If UpdateSupplier(_newSupplier) = 1 Then
            isAmendOK = True
            AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Supplier, _supplierId, AuditUtil.AuditableAction.update, _currentSupplier.ToString, _newSupplier.ToString)
            LogUtil.Info("Supplier updated OK", MyBase.Name)
        Else
            isAmendOK = False
            MsgBox("Supplier not updated", MsgBoxStyle.Exclamation, "Error")
            LogUtil.Problem("Supplier " & _newSupplier.SupplierName & " not updated")
        End If
        Return isAmendOK
    End Function
    Private Sub NewSupplier()
        LogUtil.Info("New supplier", MyBase.Name())
        LblAction.Text = "Adding a new supplier"
        PicUpdate.Image = My.Resources.add_database
        ToolTip1.SetToolTip(PicUpdate, "Add a new supplier")
        _currentSupplier = SupplierBuilder.ASupplier.StartingWithNothing.Build
        ClearSupplierDetails()
        pnlProducts.Enabled = False
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
        'pRow.Cells(prodId.Name).Value = -1
        Dim _productList As List(Of Product) = GetProductsBySupplier(suppId)
        For Each oProduct As Product In _productList
            Dim tRow As DataGridViewRow = dgvProducts.Rows(dgvProducts.Rows.Add)
            tRow.Cells(prodId.Name).Value = oProduct.ProductId
            tRow.Cells(prodName.Name).Value = oProduct.ProductName
        Next
        dgvProducts.ClearSelection()
        isLoadingProducts = False
    End Sub
    Private Sub ShowProductForm(pProductId As Integer)
        Using _productForm As New FrmProduct
            _productForm.SelectSupplier = _currentSupplier
            _productForm.ProductId = pProductId
            _productForm.ShowDialog()
        End Using
        FillProductsList(_supplierId)
    End Sub
    Private Sub ShowProductForm()
        If dgvProducts.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = dgvProducts.SelectedRows(0)
            Dim oProductId As Integer = oRow.Cells(prodId.Name).Value
            ShowProductForm(oProductId)
        End If
    End Sub
    Private Function IsValidSupplier() As Boolean
        Dim isOk As Boolean = True
        If String.IsNullOrWhiteSpace(txtSuppName.Text) Then
            isOk = False
        End If
        Return isOK
    End Function
#End Region
End Class