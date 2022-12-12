' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class ProductBuilder
    Private _productChanged As DateTime?
    Private _productCreated As DateTime
    Private _productPrice As Decimal
    Private _productCost As Decimal
    Private _productSupplierId As Integer
    Private _productDescription As String
    Private _productName As String
    Private _productId As Integer
    Private _productTaxable As Boolean
    Private _productTaxRate As Decimal?
    Private _productPurchaseUnits As Integer
    Public Shared Function AProduct() As ProductBuilder
        Return New ProductBuilder
    End Function
    Public Function StartingWith(ByVal oProduct As Product) As ProductBuilder
        With oProduct
            _productId = .ProductId
            _productName = .ProductName
            _productDescription = .ProductDescription
            _productSupplierId = .ProductSupplierId
            _productCost = .ProductCost
            _productPrice = .ProductPrice
            _productCreated = .ProductCreated
            _productChanged = .ProductChanged
            _productTaxable = .IsProductTaxable
            _productTaxRate = .ProductTaxRate
            _productPurchaseUnits = .PurchaseUnits
        End With
        Return Me
    End Function
    Public Function StartingWith(ByVal oProduct As netwyrksDataSet.productRow) As ProductBuilder
        With oProduct
            _productId = .product_id
            _productName = .product_name
            _productDescription = If(.Isproduct_descriptionNull, "", .product_description)
            _productSupplierId = .product_supplier_id
            _productCost = .product_cost
            _productPrice = .product_price
            _productCreated = .product_created
            If .Isproduct_changedNull Then
                _productChanged = Nothing
            Else
                _productChanged = .product_changed
            End If
            _productTaxable = .product_taxable
            _productTaxRate = If(.Isproduct_tax_rateNull, 0.0, .product_tax_rate)
            _productPurchaseUnits = If(.Isproduct_purchase_unitsNull, 0, .product_purchase_units)
        End With
        Return Me
    End Function
    Public Function StartingWithNothing() As ProductBuilder
        _productId = -1
        _productName = ""
        _productDescription = ""
        _productSupplierId = -1
        _productCost = 0
        _productPrice = 0
        _productCreated = Today.Date
        _productChanged = Nothing
        _productTaxable = False
        _productTaxRate = 0.0
        _productPurchaseUnits = 0
        Return Me
    End Function
    Public Function WithProductId(ByVal pProductId As Integer) As ProductBuilder
        _productId = pProductId
        Return Me
    End Function
    Public Function WithProductName(ByVal pProductName As String) As ProductBuilder
        _productName = pProductName
        Return Me
    End Function
    Public Function WithProductDescription(ByVal pProductDescription As String) As ProductBuilder
        _productDescription = pProductDescription
        Return Me
    End Function
    Public Function WithProductSupplierId(ByVal pProductSupplierId As Integer) As ProductBuilder
        _productSupplierId = pProductSupplierId
        Return Me
    End Function
    Public Function WithProductCost(ByVal pProductCost As Decimal) As ProductBuilder
        _productCost = pProductCost
        Return Me
    End Function
    Public Function WithProductPrice(ByVal pProductPrice As Decimal) As ProductBuilder
        _productPrice = pProductPrice
        Return Me
    End Function
    Public Function WithProductCreated(ByVal pProductCreated As DateTime) As ProductBuilder
        _productCreated = pProductCreated
        Return Me
    End Function
    Public Function WithProductChanged(ByVal pProductChanged As DateTime?) As ProductBuilder
        _productChanged = pProductChanged
        Return Me
    End Function
    Public Function WithProductTaxable(ByVal pProductTaxable As Boolean) As ProductBuilder
        _productTaxable = pProductTaxable
        Return Me
    End Function
    Public Function WithProductTaxRate(ByVal pProductTaxRate As Decimal?) As ProductBuilder
        _productTaxRate = pProductTaxRate
        Return Me
    End Function
    Public Function WithPurchaseUnits(ByVal pPurchaseUnits As Integer) As ProductBuilder
        _productPurchaseUnits = pPurchaseUnits
        Return Me
    End Function
    Public Function Build() As Product
        Return New Product(_productId,
                           _productName,
                           _productDescription,
                           _productSupplierId,
                           _productCost,
                           _productPrice,
                           _productCreated,
                           _productChanged,
                           _productTaxable,
                           _productTaxRate,
                           _productPurchaseUnits)
    End Function
End Class
