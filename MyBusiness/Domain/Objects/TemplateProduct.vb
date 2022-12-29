' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class TemplateProduct
    Private _templateProductId As Integer
    Private _product As Product
    Private _quantity As Integer
    Private _template As Template
    Public Property TemplateProductId() As Integer
        Get
            Return _templateProductId
        End Get
        Set(ByVal value As Integer)
            _templateProductId = value
        End Set
    End Property
    Public ReadOnly Property ProductId() As Integer
        Get
            Return _product.ProductId
        End Get
    End Property
    Public Property Product() As Product
        Get
            Return _product
        End Get
        Set(ByVal value As Product)
            _product = value
        End Set
    End Property
    Public Property Quantity() As Integer
        Get
            Return _quantity
        End Get
        Set(ByVal value As Integer)
            _quantity = value
        End Set
    End Property
    Public Property Template() As Template
        Get
            Return _template
        End Get
        Set(ByVal value As Template)
            _template = value
        End Set
    End Property
    Public Sub New(ByVal pId As Integer,
                   ByVal pTemplate As Template,
                   ByVal pProduct As Product,
                   ByVal pQuantity As Decimal)
        _templateProductId = pId
        _product = pProduct
        _quantity = pQuantity
        _template = pTemplate
    End Sub

End Class
