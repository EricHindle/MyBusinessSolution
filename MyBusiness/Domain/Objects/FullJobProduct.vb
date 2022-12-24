' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FullJobProduct
    Private _job As Job
    Private _product As Product
    Private _quantity As Integer
    Private _jobProductCreated As DateTime?
    Private _jobProductChanged As DateTime?
    Private _taxable As Boolean
    Private _tax_rate As Decimal
    Private _price As Decimal
    Private _jobProductId As Integer
    Private _supplier As Supplier
    Private _customer As Customer
    Public Property JobCustomer() As Customer
        Get
            Return _customer
        End Get
        Set(ByVal value As Customer)
            _customer = value
        End Set
    End Property
    Public Property ProductSupplier() As Supplier
        Get
            Return _supplier
        End Get
        Set(ByVal value As Supplier)
            _supplier = value
        End Set
    End Property
    Public Property JobProductId() As Integer
        Get
            Return _jobProductId
        End Get
        Set(ByVal value As Integer)
            _jobProductId = value
        End Set
    End Property
    Public Property Price() As Decimal
        Get
            Return _price
        End Get
        Set(ByVal value As Decimal)
            _price = value
        End Set
    End Property
    Public Property Tax_Rate() As Decimal
        Get
            Return _tax_rate
        End Get
        Set(ByVal value As Decimal)
            _tax_rate = value
        End Set
    End Property
    Public Property Taxable() As Boolean
        Get
            Return _taxable
        End Get
        Set(ByVal value As Boolean)
            _taxable = value
        End Set
    End Property
    Public Property JobProductChanged() As DateTime?
        Get
            Return _jobProductChanged
        End Get
        Set(ByVal value As DateTime?)
            _jobProductChanged = value
        End Set
    End Property
    Public Property JobProductCreated() As DateTime?
        Get
            Return _jobProductCreated
        End Get
        Set(ByVal value As DateTime?)
            _jobProductCreated = value
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
    Public Property ThisProduct() As Product
        Get
            Return _product
        End Get
        Set(ByVal value As Product)
            _product = value
        End Set
    End Property
    Public Property CustomerJob() As Job
        Get
            Return _job
        End Get
        Set(ByVal value As Job)
            _job = value
        End Set
    End Property
    Public Sub New(ByVal pId As Integer,
                   ByVal pJob As Job,
                   ByVal pProduct As Product,
                   ByVal pQuantity As Decimal,
                   ByVal pCreated As DateTime?,
                   ByVal pChanged As DateTime?,
                   ByVal pTaxable As Boolean,
                   ByVal pTax_Rate As Decimal,
                   ByVal pPrice As Decimal,
                   ByVal pCustomer As Customer,
                   ByVal pSupplier As Supplier)
        _jobProductId = pId
        _job = pJob
        _product = pProduct
        _customer = pCustomer
        _supplier = pSupplier
        _quantity = pQuantity
        _jobProductCreated = pCreated
        _jobProductChanged = pChanged
        _taxable = pTaxable
        _tax_rate = pTax_Rate
        _price = pPrice
    End Sub
End Class
