' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class frmProduct
#Region "variables"
    Private _productBuilder As ProductBuilder
    Private _productId As Integer
    Private _product As Product
    Private _supplierId As Integer
    Private _supplier As Supplier
    Private _newproduct As Product
    Private isLoading As Boolean = False
    Private ReadOnly oproductTa As New netwyrksDataSetTableAdapters.productTableAdapter
    Private ReadOnly oproductTable As New netwyrksDataSet.productDataTable
#End Region
#Region "properties"
    Public Property TheSupplier() As Supplier
        Get
            Return _supplier
        End Get
        Set(ByVal value As Supplier)
            _supplier = value
        End Set
    End Property
    Public Property TheProduct() As ProductBuilder
        Get
            Return _productBuilder
        End Get
        Set(ByVal value As ProductBuilder)
            _productBuilder = value
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
    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub FrmProduct_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closing", Me.Name)
        oproductTa.Dispose()
        oproductTable.Dispose()
    End Sub
    Private Sub FrmProduct_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LogUtil.Debug("Starting", Me.Name)
        isLoading = True
        If _supplier IsNot Nothing Then
            _supplierId = _supplier.SupplierId
            lblSuppName.Text = _supplier.SupplierName
        Else
            MsgBox("Error: no supplier selected", MsgBoxStyle.Exclamation, "Error")
            showStatus(lblStatus, "No supplier selected", Me.Name, True)
        End If
        If _productId > 0 Then
            _productBuilder = ProductBuilder.AProductBuilder.StartingWith(_productId)
            _product = _productBuilder.Build
            FillproductDetails()
        Else
            Newproduct()
            _productId = -1
        End If
        isLoading = False
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        With _productBuilder.Build
            _newproduct = ProductBuilder.AProductBuilder.WithProductName(txtProductName.Text.Trim) _
            .WithProductDescription(rtbDescription.Text.Trim) _
            .WithProductCost(nudCost.Value) _
            .WithProductPrice(nudPrice.Value) _
            .WithProductCreated(.ProductCreated) _
            .WithProductChanged(.ProductChanged) _
            .WithProductSupplierId(_supplierId) _
            .WithProductTaxable(chkTaxable.Checked) _
            .WithProductTaxRate(nudTaxRate.Value) _
            .Build
        End With
        Dim newproductId As Integer = -1
        If _productId > 0 Then
            AmendProduct()
        Else
            InsertProduct()
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub FillproductDetails()
        With _product
            txtProductName.Text = .ProductName
            rtbDescription.Text = .ProductDescription
            nudCost.Value = .ProductCost
            nudPrice.Value = .ProductPrice
            chkTaxable.Checked = .IsProductTaxable
            nudTaxRate.Value = .ProductTaxRate
        End With
        LogUtil.Debug("Existing product " & CStr(_productId), Me.Name)

    End Sub
    Private Sub ClearproductDetails()
        txtProductName.Text = ""
        rtbDescription.Text = ""
        nudCost.Value = 0
        nudPrice.Value = 0
        chkTaxable.Checked = False
        nudTaxRate.Value = 0.0
    End Sub
    Private Sub Newproduct()
        LogUtil.Debug("New product", Me.Name())
        ClearproductDetails()
        _productBuilder = ProductBuilder.AProductBuilder.StartingWithNothing
    End Sub
    Private Function AmendProduct() As Boolean
        Dim isAmendOk As Boolean = False
        LogUtil.Debug("Updating product " & CStr(_productId), Me.Name)
        With _newproduct
            If oproductTa.UpdateProduct(.ProductName, .ProductDescription, .ProductCost, .ProductPrice, Now, .ProductSupplierId, .IsProductTaxable, .ProductTaxRate, _productId) = 1 Then
                AuditUtil.AddAudit(currentUser.UserId, AuditUtil.RecordType.Product, _productId, AuditUtil.AuditableAction.create, _productBuilder.ToString, .ToString)
                isAmendOk = True
                showStatus(lblStatus, "Product updated OK", Me.Name, True)
            Else
                isAmendOk = False
                showStatus(lblStatus, "Product NOT updated", Me.Name, True)

            End If
        End With
        Return isAmendOk
    End Function
    Private Function InsertProduct() As Boolean
        Dim isInsertOk As Boolean
        LogUtil.Debug("Inserting product", Me.Name)
        With _newproduct
            _productId = oproductTa.InsertProduct(.ProductName, .ProductDescription, .ProductCost, .ProductPrice, Now, .ProductSupplierId, .IsProductTaxable, .ProductTaxRate)
            If _productId > 0 Then
                AuditUtil.AddAudit(currentUser.UserId, AuditUtil.RecordType.Product, _productId, AuditUtil.AuditableAction.create, "", .ToString)
                isInsertOk = True
                showStatus(lblStatus, "Product " & CStr(_productId) & " Created OK", Me.Name, True)
            Else
                isInsertOk = False
                showStatus(lblStatus, "Product NOT created", Me.Name, True)
            End If
        End With
        Return isInsertOk
    End Function
#End Region
End Class