﻿' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class Supplier
    Private _supplierId As Integer
    Private _supplierName As String
    Private _supplierAddress As Address
    Private _supplierEmail As String
    Private _supplierPhone As String
    Private _supplierNotes As String
    Private _supplierDiscount As Decimal?
    Private _supplierCreated As DateTime
    Private _supplierChanged As DateTime?
    Public Sub New(ByVal pSupplierId As Integer,
                   ByVal pSupplierName As String,
                   ByVal pSupplierEmail As String,
                   ByVal pSupplierPhone As String,
                   ByVal pSupplierNotes As String,
                   ByVal pSupplierCreated As DateTime,
                   ByVal pSupplierChanged As DateTime?,
                   ByVal pSupplierAddress As Address,
                   ByVal pSupplierDiscount As Decimal?)

        _supplierId = pSupplierId
        _supplierName = pSupplierName
        _supplierAddress = pSupplierAddress
        _supplierEmail = pSupplierEmail
        _supplierPhone = pSupplierPhone
        _supplierNotes = pSupplierNotes
        _supplierDiscount = pSupplierDiscount
        _supplierCreated = pSupplierCreated
        _supplierChanged = pSupplierChanged

    End Sub
    Public Property SupplierDiscount() As Decimal?
        Get
            Return If(_supplierDiscount Is Nothing, 0, _supplierDiscount)
        End Get
        Set(ByVal value As Decimal?)
            _supplierDiscount = value
        End Set
    End Property
    Public Property SupplierChanged() As DateTime?
        Get
            Return _supplierChanged
        End Get
        Set(ByVal value As DateTime?)
            _supplierChanged = value
        End Set
    End Property
    Public Property SupplierCreated() As DateTime
        Get
            Return _supplierCreated
        End Get
        Set(ByVal value As DateTime)
            _supplierCreated = value
        End Set
    End Property
    Public Property SupplierNotes() As String
        Get
            Return If(_supplierNotes, "")
        End Get
        Set(ByVal value As String)
            _supplierNotes = value
        End Set
    End Property
    Public Property SupplierPhone() As String
        Get
            Return If(_supplierPhone, "")
        End Get
        Set(ByVal value As String)
            _supplierPhone = value
        End Set
    End Property
    Public Property SupplierEmail() As String
        Get
            Return If(_supplierEmail, "")
        End Get
        Set(ByVal value As String)
            _supplierEmail = value
        End Set
    End Property
    Public Property SupplierName() As String
        Get
            Return _supplierName
        End Get
        Set(ByVal value As String)
            _supplierName = value
        End Set
    End Property
    Public Property SupplierId() As Integer
        Get
            Return _supplierId
        End Get
        Set(ByVal value As Integer)
            _supplierId = value
        End Set
    End Property
    Public Property SupplierAddress() As Address
        Get
            Return If(_supplierAddress, AddressBuilder.AnAddress.StartingWithNothing.Build)
        End Get
        Set(ByVal value As Address)
            _supplierAddress = value
        End Set
    End Property
End Class
