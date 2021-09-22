' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class frmProduct
    Private _productBuilder As ProductBuilder
    Private _productId As Integer
    Private _product As Product
    Private _supplierId As Integer
    Private _supplier As Supplier
    Private _newproduct As Product
    Private isLoading As Boolean = False
    Private oproductTa As New netwyrksDataSetTableAdapters.productTableAdapter
    Private oproductTable As New netwyrksDataSet.productDataTable


    Public Property theSupplier() As Supplier
        Get
            Return _supplier
        End Get
        Set(ByVal value As Supplier)
            _supplier = value
        End Set
    End Property

    Public Property theProduct() As ProductBuilder
        Get
            Return _productBuilder
        End Get
        Set(ByVal value As ProductBuilder)
            _productBuilder = value
        End Set
    End Property

    Public Property productId() As Integer
        Get
            Return _productId
        End Get
        Set(ByVal value As Integer)
            _productId = value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmProduct_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closing", Me.Name)
        oproductTa.Dispose()
        oproductTable.Dispose()
    End Sub

    Private Sub frmProduct_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LogUtil.Debug("Starting", Me.Name)
        isLoading = True
        If _supplier IsNot Nothing Then
            _supplierId = _supplier.supplierId
            lblSuppName.Text = _supplier.supplierName
        Else
            MsgBox("Error: no supplier selected", MsgBoxStyle.Exclamation, "Error")
            showStatus(lblStatus, "No supplier selected", Me.Name, True)
        End If
        If _productId > 0 Then
            _productBuilder = ProductBuilder.aProductBuilder.startingWith(_productId)
            _product = _productBuilder.build
            fillproductDetails()
        Else
            newproduct()
            _productId = -1
        End If
        isLoading = False
    End Sub

    Private Sub fillproductDetails()
        With _product
            txtProductName.Text = .productName
            rtbDescription.Text = .productDescription
            nudCost.Value = .productCost
            nudPrice.Value = .productPrice
            chkTaxable.Checked = .isProductTaxable
            nudTaxRate.Value = .productTaxRate
        End With
        LogUtil.Debug("Existing product " & CStr(_productId), Me.Name)

    End Sub

    Private Sub clearproductDetails()
        txtProductName.Text = ""
        rtbDescription.Text = ""
        nudCost.Value = 0
        nudPrice.Value = 0
        chkTaxable.Checked = False
        nudTaxRate.Value = 0.0
    End Sub

    Private Sub newproduct()
        LogUtil.Debug("New product", Me.Name())
        clearproductDetails()
        _productBuilder = ProductBuilder.aProductBuilder.startingWithNothing
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        With _productBuilder.build
            _newproduct = ProductBuilder.aProductBuilder.withProductName(txtProductName.Text.Trim) _
            .withProductDescription(rtbDescription.Text.Trim) _
            .withProductCost(nudCost.Value) _
            .withProductPrice(nudPrice.Value) _
            .withProductCreated(.productCreated) _
            .withProductChanged(.productChanged) _
            .withProductSupplierId(_supplierId) _
            .withProductTaxable(chkTaxable.Checked) _
            .withProductTaxRate(nudTaxRate.Value) _
            .build
        End With
        Dim newproductId As Integer = -1
        If _productId > 0 Then
            amendProduct()
        Else
            insertProduct()
        End If
    End Sub

    Private Function amendProduct() As Boolean
        Dim isAmendOk As Boolean = False
        LogUtil.Debug("Updating product " & CStr(_productId), Me.Name)
        With _newproduct
            If oproductTa.UpdateProduct(.productName, .productDescription, .productCost, .productPrice, Now, .productSupplierId, .isProductTaxable, .productTaxRate, _productId) = 1 Then
                AuditUtil.addAudit(currentUser.userId, AuditUtil.RecordType.Product, _productId, AuditUtil.AuditableAction.create, _productBuilder.ToString, .ToString)
                isAmendOk = True
                showStatus(lblStatus, "Product updated OK", Me.Name, True)
            Else
                isAmendOk = False
                showStatus(lblStatus, "Product NOT updated", Me.Name, True)

            End If
        End With
        Return isAmendOk
    End Function

    Private Function insertProduct() As Boolean
        Dim isInsertOk As Boolean
        LogUtil.Debug("Inserting product", Me.Name)
        With _newproduct
            _productId = oproductTa.InsertProduct(.productName, .productDescription, .productCost, .productPrice, Now, .productSupplierId, .isProductTaxable, .productTaxRate)
            If _productId > 0 Then
                AuditUtil.addAudit(currentUser.userId, AuditUtil.RecordType.Product, _productId, AuditUtil.AuditableAction.create, "", .ToString)
                isInsertOk = True
                showStatus(lblStatus, "Product " & CStr(_productId) & " Created OK", Me.Name, True)
            Else
                isInsertOk = False
                showStatus(lblStatus, "Product NOT created", Me.Name, True)
            End If
        End With
        Return isInsertOk
    End Function


End Class