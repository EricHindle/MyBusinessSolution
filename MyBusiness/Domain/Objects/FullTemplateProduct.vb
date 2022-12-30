' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FullTemplateProduct
    Private _template As Template
    Private _product As Product
    Private _supplier As Supplier
    Private _templateProductId As Integer
    Private _quantity As Decimal
    Public Property Quantity() As Decimal
        Get
            Return _quantity
        End Get
        Set(ByVal value As Decimal)
            _quantity = value
        End Set
    End Property
    Public Property TemplateProductId() As Integer
        Get
            Return _templateProductId
        End Get
        Set(ByVal value As Integer)
            _templateProductId = value
        End Set
    End Property
    Public Property Supplier() As Supplier
        Get
            Return _supplier
        End Get
        Set(ByVal value As Supplier)
            _supplier = value
        End Set
    End Property
    Public Property Product() As Product
        Get
            Return _product
        End Get
        Set(ByVal value As Product)
            _product = value
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
    Public Sub New(pId As Integer,
                   ByVal pTemplate As Template,
                   ByVal pProduct As Product,
                   ByVal pQuantity As Decimal,
                   ByVal pSupplier As Supplier)
        _templateProductId = pId
        _template = pTemplate
        _product = pProduct
        _supplier = pSupplier
        _quantity = pQuantity
    End Sub
End Class
