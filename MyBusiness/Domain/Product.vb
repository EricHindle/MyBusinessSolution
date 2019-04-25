'
' Copyright (c) 2017, Eric Hindle
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
    Public Property productTaxRate() As Decimal?
        Get
            Return _productTaxrate
        End Get
        Set(ByVal value As Decimal?)
            _productTaxrate = value
        End Set
    End Property
    Public Property isProductTaxable() As Boolean
        Get
            Return _productTaxable
        End Get
        Set(ByVal value As Boolean)
            _productTaxable = value
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
    Public Property productName() As String
        Get
            Return _productName
        End Get
        Set(ByVal value As String)
            _productName = value
        End Set
    End Property
    Public Property productDescription() As String
        Get
            Return If(_productDescription Is Nothing, "", _productDescription)
        End Get
        Set(ByVal value As String)
            _productDescription = value
        End Set
    End Property
    Public Property productSupplierId() As Integer
        Get
            Return _productSupplierId
        End Get
        Set(ByVal value As Integer)
            _productSupplierId = value
        End Set
    End Property
    Public Property productCost() As Decimal
        Get
            Return _productCost
        End Get
        Set(ByVal value As Decimal)
            _productCost = value
        End Set
    End Property

    Public Property productPrice() As Decimal
        Get
            Return _productPrice
        End Get
        Set(ByVal value As Decimal)
            _productPrice = value
        End Set
    End Property

    Public Property productCreated() As DateTime
        Get
            Return _productCreated
        End Get
        Set(ByVal value As DateTime)
            _productCreated = value
        End Set
    End Property
    Public Property productChanged() As DateTime?
        Get
            Return _productChanged
        End Get
        Set(ByVal value As DateTime?)
            _productChanged = value
        End Set
    End Property

    Public Sub New(ByVal pProductId As Integer, _
                    ByVal pProductName As String, _
                    ByVal pProductDescription As String, _
                    ByVal pProductSupplierId As Integer, _
                    ByVal pProductCost As Decimal, _
                    ByVal pProductPrice As Decimal, _
                    ByVal pProductCreated As DateTime, _
                    ByVal pProductChanged As DateTime?, _
                    ByVal pProductTaxable As Boolean, _
                    ByVal pProductRate As Decimal? _
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
        _productTaxrate = pProductRate
    End Sub
End Class
