'
' Copyright (c) 2017, Eric Hindle
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

    Public Sub New(ByVal pSupplierId As Integer, _
                   ByVal pSupplierName As String, _
                   ByVal pSupplierEmail As String, _
                   ByVal pSupplierPhone As String, _
                   ByVal pSupplierNotes As String, _
                   ByVal pSupplierCreated As DateTime, _
                   ByVal pSupplierChanged As DateTime?, _
                   ByVal pSupplierAddress As Address, _
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
    Public Property supplierDiscount() As Decimal?
        Get
            Return If(_supplierDiscount Is Nothing, 0, _supplierDiscount)
        End Get
        Set(ByVal value As Decimal?)
            _supplierDiscount = value
        End Set
    End Property
    Public Property supplierChanged() As DateTime?
        Get
            Return _supplierChanged
        End Get
        Set(ByVal value As DateTime?)
            _supplierChanged = value
        End Set
    End Property
    Public Property supplierCreated() As DateTime
        Get
            Return _supplierCreated
        End Get
        Set(ByVal value As DateTime)
            _supplierCreated = value
        End Set
    End Property

    Public Property supplierNotes() As String
        Get
            Return If(_supplierNotes Is Nothing, "", _supplierNotes)
        End Get
        Set(ByVal value As String)
            _supplierNotes = value
        End Set
    End Property
    Public Property supplierPhone() As String
        Get
            Return If(_supplierPhone Is Nothing, "", _supplierPhone)
        End Get
        Set(ByVal value As String)
            _supplierPhone = value
        End Set
    End Property
    Public Property supplierEmail() As String
        Get
            Return If(_supplierEmail Is Nothing, "", _supplierEmail)
        End Get
        Set(ByVal value As String)
            _supplierEmail = value
        End Set
    End Property

    Public Property supplierName() As String
        Get
            Return _supplierName
        End Get
        Set(ByVal value As String)
            _supplierName = value
        End Set
    End Property

    Public Property supplierId() As Integer
        Get
            Return _supplierId
        End Get
        Set(ByVal value As Integer)
            _supplierId = value
        End Set
    End Property
    Public Property supplierAddress() As Address
        Get
            Return If(_supplierAddress Is Nothing, AddressBuilder.anAddress.startingWithNothing.build, _supplierAddress)
        End Get
        Set(ByVal value As Address)
            _supplierAddress = value
        End Set
    End Property
End Class
