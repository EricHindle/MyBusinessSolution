'
' Copyright (c) 2017, Eric Hindle
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
    Public Shared Function aProductBuilder() As ProductBuilder
        Return New ProductBuilder
    End Function
    Public Function startingWith(ByVal ProductId As Integer) As ProductBuilder
        Dim oProductTa As New netwyrksDataSetTableAdapters.productTableAdapter
        Dim oProductTable As New netwyrksDataSet.productDataTable
        If oProductTa.FillById(oProductTable, ProductId) > 0 Then
            startingWith(oProductTable.Rows(0))
        Else
            startingWithNothing()
        End If
        oProductTa.Dispose()
        oProductTable.Dispose()
        Return Me
    End Function

    Public Function startingWith(ByVal oProduct As Product) As ProductBuilder
        With oProduct
            _productId = .productId
            _productName = .productName
            _productDescription = .productDescription
            _productSupplierId = .productSupplierId
            _productCost = .productCost
            _productPrice = .productPrice
            _productCreated = .productCreated
            _productChanged = .productChanged
            _productTaxable = .isProductTaxable
            _productTaxRate = .productTaxRate
        End With
        Return Me
    End Function
    Public Function startingWith(ByVal oProduct As netwyrksDataSet.productRow) As ProductBuilder

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
        End With
        Return Me
    End Function
    Public Function startingWithNothing() As ProductBuilder
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
        Return Me
    End Function
    Public Function withProductId(ByVal pProductId As Integer) As ProductBuilder
        _productId = pProductId
        Return Me
    End Function
    Public Function withProductName(ByVal pProductName As String) As ProductBuilder
        _productName = pProductName
        Return Me
    End Function
    Public Function withProductDescription(ByVal pProductDescription As String) As ProductBuilder
        _productDescription = pProductDescription
        Return Me
    End Function
    Public Function withProductSupplierId(ByVal pProductSupplierId As Integer) As ProductBuilder
        _productSupplierId = pProductSupplierId
        Return Me
    End Function
    Public Function withProductCost(ByVal pProductCost As Decimal) As ProductBuilder
        _productCost = pProductCost
        Return Me
    End Function
    Public Function withProductPrice(ByVal pProductPrice As Decimal) As ProductBuilder
        _productPrice = pProductPrice
        Return Me
    End Function
    Public Function withProductCreated(ByVal pProductCreated As DateTime) As ProductBuilder
        _productCreated = pProductCreated
        Return Me
    End Function
    Public Function withProductChanged(ByVal pProductChanged As DateTime?) As ProductBuilder
        _productChanged = pProductChanged
        Return Me
    End Function
    Public Function withProductTaxable(ByVal pProductTaxable As Boolean) As ProductBuilder
        _productTaxable = pProductTaxable
        Return Me
    End Function
    Public Function withProductTaxRate(ByVal pProductTaxRate As Decimal?) As ProductBuilder
        _productTaxRate = pProductTaxRate
        Return Me
    End Function
    Public Function build() As Product
        Return New Product(_productId, _
                           _productName, _
                           _productDescription, _
                           _productSupplierId, _
                           _productCost, _
                           _productPrice, _
                           _productCreated, _
                           _productChanged, _
                           _productTaxable, _
                           _productTaxRate)
    End Function
End Class
