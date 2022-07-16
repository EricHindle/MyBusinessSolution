' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class Product
    Private _productId As Integer
    Private _productName As String
    Private _productDescription As String
    Private _productSupplierId As Integer
    Private _productCost As Decimal
    Private _productPrice As Decimal
    Private _productCreated As DateTime
    Private _productChanged As DateTime?
    Private _productTaxable As Boolean
    Private _productTaxRate As Decimal?
    Public Property ProductTaxRate() As Decimal?
        Get
            Return _productTaxRate
        End Get
        Set(ByVal value As Decimal?)
            _productTaxRate = value
        End Set
    End Property
    Public Property IsProductTaxable() As Boolean
        Get
            Return _productTaxable
        End Get
        Set(ByVal value As Boolean)
            _productTaxable = value
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
    Public Property ProductName() As String
        Get
            Return _productName
        End Get
        Set(ByVal value As String)
            _productName = value
        End Set
    End Property
    Public Property ProductDescription() As String
        Get
            Return If(_productDescription, "")
        End Get
        Set(ByVal value As String)
            _productDescription = value
        End Set
    End Property
    Public Property ProductSupplierId() As Integer
        Get
            Return _productSupplierId
        End Get
        Set(ByVal value As Integer)
            _productSupplierId = value
        End Set
    End Property
    Public Property ProductCost() As Decimal
        Get
            Return _productCost
        End Get
        Set(ByVal value As Decimal)
            _productCost = value
        End Set
    End Property
    Public Property ProductPrice() As Decimal
        Get
            Return _productPrice
        End Get
        Set(ByVal value As Decimal)
            _productPrice = value
        End Set
    End Property
    Public Property ProductCreated() As DateTime
        Get
            Return _productCreated
        End Get
        Set(ByVal value As DateTime)
            _productCreated = value
        End Set
    End Property
    Public Property ProductChanged() As DateTime?
        Get
            Return _productChanged
        End Get
        Set(ByVal value As DateTime?)
            _productChanged = value
        End Set
    End Property
    Public Sub New(ByVal pProductId As Integer,
                    ByVal pProductName As String,
                    ByVal pProductDescription As String,
                    ByVal pProductSupplierId As Integer,
                    ByVal pProductCost As Decimal,
                    ByVal pProductPrice As Decimal,
                    ByVal pProductCreated As DateTime,
                    ByVal pProductChanged As DateTime?,
                    ByVal pProductTaxable As Boolean,
                    ByVal pProductRate As Decimal?
                  )
        _productId = pProductId
        _productName = pProductName
        _productDescription = pProductDescription
        _productSupplierId = pProductSupplierId
        _productCost = pProductCost
        _productPrice = pProductPrice
        _productCreated = pProductCreated
        _productChanged = pProductChanged
        _productTaxable = pProductTaxable
        _productTaxRate = pProductRate
    End Sub
End Class
