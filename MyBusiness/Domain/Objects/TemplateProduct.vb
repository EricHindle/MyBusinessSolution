' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class TemplateProduct
    Private _templateProductId As Integer
    Private _product As Product
    Private _quantity As Integer
    Private _templateId As Integer
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
    Public Property TemplateId() As Integer
        Get
            Return _templateId
        End Get
        Set(ByVal value As Integer)
            _templateId = value
        End Set
    End Property
    Public Sub New(ByVal pId As Integer,
                   ByVal pTemplateId As Integer,
                   ByVal pProduct As Product,
                   ByVal pQuantity As Decimal)
        _templateProductId = pId
        _product = pProduct
        _quantity = pQuantity
        _templateId = pTemplateId
    End Sub

End Class
