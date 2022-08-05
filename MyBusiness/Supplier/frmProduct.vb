' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

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
    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub FrmProduct_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", Me.Name)
        My.Settings.ProductFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub FrmProduct_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LogUtil.Info("Starting", Me.Name)
        GetFormPos(Me, My.Settings.ProductFormPos)
        isLoading = True
        If _supplier IsNot Nothing Then
            _supplierId = _supplier.SupplierId
            lblSuppName.Text = _supplier.SupplierName
        Else
            MsgBox("Error: no supplier selected", MsgBoxStyle.Exclamation, "Error")
            LogUtil.Problem("Error: no supplier selected", MyBase.Name)
            Me.Close()
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
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not String.IsNullOrWhiteSpace(txtProductName.Text) Then
            _newproduct = ProductBuilder.AProduct.StartingWith(_product) _
                                .WithProductName(txtProductName.Text.Trim) _
                                .WithProductDescription(rtbDescription.Text.Trim) _
                                .WithProductCost(nudCost.Value) _
                                .WithProductPrice(nudPrice.Value) _
                                .WithProductSupplierId(_supplierId) _
                                .WithProductTaxable(chkTaxable.Checked) _
                                .WithProductTaxRate(nudTaxRate.Value) _
                                .Build
            If _productId > 0 Then
                AmendProduct()
            Else
                CreateProduct()
            End If
            Me.Close()
        Else
            ShowStatus(lblStatus, "Product name missing", MyBase.Name, True)
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub FillProductDetails()
        LblAction.Text = "Updating Product"
        btnSave.Text = "Update"
        With _product
            LogUtil.Info("Amending product " & CStr(_productId) & " : " & .ProductName, MyBase.Name)
            txtProductName.Text = .ProductName
            rtbDescription.Text = .ProductDescription
            nudCost.Value = .ProductCost
            nudPrice.Value = .ProductPrice
            chkTaxable.Checked = .IsProductTaxable
            nudTaxRate.Value = .ProductTaxRate
        End With
    End Sub
    Private Sub ClearProductDetails()
        txtProductName.Text = ""
        rtbDescription.Text = ""
        nudCost.Value = 0
        nudPrice.Value = 0
        chkTaxable.Checked = False
        nudTaxRate.Value = 0.0
    End Sub
    Private Sub Newproduct()
        LogUtil.Info("New product", MyBase.Name())
        ClearProductDetails()
        LblAction.Text = "Adding New Product"
        btnSave.Text = "Create"
        _product = ProductBuilder.AProduct.StartingWithNothing.Build
    End Sub
    Private Function AmendProduct() As Boolean
        Dim isAmendOk As Boolean
        LogUtil.Info("Updating", Me.Name)
        _newproduct.ProductChanged = Now
        If UpdateProduct(_newproduct) = 1 Then
            AuditUtil.AddAudit(currentUser.UserId, AuditUtil.RecordType.Product, _newproduct.ProductId, AuditUtil.AuditableAction.create, _product.ToString, _newproduct.ToString)
            isAmendOk = True
            ShowStatus(lblStatus, "Product updated OK", MyBase.Name, True)
        Else
            isAmendOk = False
            ShowStatus(lblStatus, "Product NOT updated", MyBase.Name, True)
        End If
        Return isAmendOk
    End Function
    Private Function CreateProduct() As Boolean
        Dim isInsertOk As Boolean
        LogUtil.Info("Inserting", Me.Name)
        _newproduct.ProductCreated = Now
        _productId = InsertProduct(_newproduct)
        If _productId > 0 Then
            AuditUtil.AddAudit(currentUser.UserId, AuditUtil.RecordType.Product, _productId, AuditUtil.AuditableAction.create, "", _newproduct.ToString)
            isInsertOk = True
            ShowStatus(lblStatus, "Product " & CStr(_productId) & " Created OK", MyBase.Name, True)
        Else
            isInsertOk = False
            ShowStatus(lblStatus, "Product NOT created", MyBase.Name, True)
        End If
        Return isInsertOk
    End Function
#End Region
End Class