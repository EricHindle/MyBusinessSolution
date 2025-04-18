﻿' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports System.ComponentModel
Imports System.IO
Imports HindlewareLib.Logging

Public Class FrmProduct
#Region "variables"
    Private _productId As Integer
    Private _product As Product
    Private _supplierId As Integer
    Private _supplier As Supplier
    Private _newproduct As Product
    Private isLoading As Boolean = False
#End Region
#Region "properties"
    Public Property SelectSupplier() As Supplier
        Get
            Return _supplier
        End Get
        Set(ByVal value As Supplier)
            _supplier = value
        End Set
    End Property
    Public Property SelectProduct() As Product
        Get
            Return _product
        End Get
        Set(ByVal value As Product)
            _product = value
        End Set
    End Property
    Public Property ProductId() As Integer
        Get
            Return _productId
        End Get
        Set(ByVal value As Integer)
            _productId = value
        End Set
    End Property
#End Region
#Region "form handlers"

    Private Sub FrmProduct_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", Name)
        My.Settings.ProductFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub FrmProduct_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LogUtil.Info("Starting", Name)
        GetFormPos(Me, My.Settings.ProductFormPos)
        isLoading = True
        If _supplier IsNot Nothing Then
            _supplierId = _supplier.SupplierId
            lblSuppName.Text = _supplier.SupplierName
        Else
            MsgBox("Error: no supplier selected", MsgBoxStyle.Exclamation, "Error")
            LogUtil.Problem("Error: no supplier selected", MyBase.Name)
            Close()
        End If
        If _productId > 0 Then
            _product = GetProductById(_productId)
            FillProductDetails()
        Else
            Newproduct()
            _productId = -1
        End If
        SpellCheckUtil.EnableSpellChecking({rtbDescription})
        isLoading = False
    End Sub
    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        Close()
    End Sub
    Private Sub PicUpdate_Click(sender As Object, e As EventArgs) Handles PicUpdate.Click
        If IsValidProduct() Then
            _newproduct = ProductBuilder.AProduct.StartingWith(_product) _
                                .WithProductName(txtProductName.Text.Trim) _
                                .WithProductDescription(rtbDescription.Text.Trim) _
                                .WithProductCost(NudCost.Value) _
                                .WithProductPrice(NudUnitCost.Value) _
                                .WithProductSupplierId(_supplierId) _
                                .WithProductTaxable(chkTaxable.Checked) _
                                .WithProductTaxRate(nudTaxRate.Value) _
                                .WithPurchaseUnits(NudPurchaseUnits.Value) _
                                .Build
            If _productId > 0 Then
                AmendProduct()
            Else
                CreateProduct()
            End If
            Close()
        Else
            LogUtil.ShowStatus("Invalid Product details", lblStatus, Name)
        End If

    End Sub
    Private Sub PicOpenWeb_Click(sender As Object, e As EventArgs) Handles PicOpenWeb.Click
        If Not String.IsNullOrWhiteSpace(_supplier.SupplierUrl) Then
            Try
                Process.Start(_supplier.SupplierUrl.ToString)
            Catch ex As Win32Exception
                LogUtil.ShowException(ex, "Exception opening image", lblStatus, Name)
            Catch ex As FileNotFoundException
                LogUtil.ShowException(ex, "Exception opening image", lblStatus, Name)
            End Try
        End If
    End Sub
    Private Sub NudCost_ValueChanged(sender As Object, e As EventArgs) Handles NudCost.ValueChanged, NudPurchaseUnits.ValueChanged
        If NudCost.Value > 0 AndAlso NudPurchaseUnits.Value > 0 Then
            NudUnitCost.Value = NudCost.Value / NudPurchaseUnits.Value
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub FillProductDetails()
        LblAction.Text = "Updating Product"
        PicUpdate.Image = My.Resources.update_database
        ToolTip1.SetToolTip(PicUpdate, "Update the product")
        With _product
            LogUtil.Info("Amending product " & _productId & " : " & .ProductName, MyBase.Name)
            txtProductName.Text = .ProductName
            rtbDescription.Text = .ProductDescription
            NudCost.Value = .ProductCost
            NudUnitCost.Value = .ProductPrice
            chkTaxable.Checked = .IsProductTaxable
            nudTaxRate.Value = .ProductTaxRate
            NudPurchaseUnits.Value = .PurchaseUnits
        End With
    End Sub
    Private Sub ClearProductDetails()
        txtProductName.Text = ""
        rtbDescription.Text = ""
        NudCost.Value = 0
        NudUnitCost.Value = 0
        chkTaxable.Checked = False
        nudTaxRate.Value = 0.0
        NudPurchaseUnits.Value = 1
    End Sub
    Private Sub Newproduct()
        LogUtil.Info("New product", MyBase.Name())
        ClearProductDetails()
        LblAction.Text = "Adding New Product"
        PicUpdate.Image = My.Resources.add_database
        ToolTip1.SetToolTip(PicUpdate, "Add a new product")
        _product = ProductBuilder.AProduct.StartingWithNothing.Build
    End Sub
    Private Function AmendProduct() As Boolean
        Dim isAmendOk As Boolean
        LogUtil.Info("Updating", Name)
        _newproduct.ProductChanged = Now
        If UpdateProduct(_newproduct) = 1 Then
            AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Product, _newproduct.ProductId, AuditUtil.AuditableAction.create, _product.ToString, _newproduct.ToString)
            isAmendOk = True
            LogUtil.ShowStatus("Product updated OK", lblStatus, MyBase.Name)
        Else
            isAmendOk = False
            LogUtil.ShowStatus("Product NOT updated", lblStatus, MyBase.Name)
        End If
        Return isAmendOk
    End Function
    Private Function CreateProduct() As Boolean
        Dim isInsertOk As Boolean
        LogUtil.LogInfo("Inserting", Name)
        _newproduct.ProductCreated = Now
        _productId = InsertProduct(_newproduct)
        If _productId > 0 Then
            AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Product, _productId, AuditUtil.AuditableAction.create, "", _newproduct.ToString)
            isInsertOk = True
            LogUtil.ShowStatus("Product " & _productId & " Created OK", lblStatus, Name)
        Else
            isInsertOk = False
            LogUtil.ShowStatus("Product NOT created", lblStatus, Name)
        End If
        Return isInsertOk
    End Function
    Private Function IsValidProduct() As Boolean
        Dim isOk As Boolean = True
        If String.IsNullOrWhiteSpace(txtProductName.Text) Then
            isOk = False
        End If
        Return isOk
    End Function
#End Region
End Class