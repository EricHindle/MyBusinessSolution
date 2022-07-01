' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class SupplierBuilder
    Private _supplierId As Integer
    Private _supplierName As String
    Private _supplierAddress As Address
    Private _supplierEmail As String
    Private _supplierPhone As String
    Private _supplierNotes As String
    Private _supplierDiscount As Decimal
    Private _supplierCreated As DateTime
    Private _supplierChanged As DateTime?
    Public Shared Function ASupplierBuilder() As SupplierBuilder
        Return New SupplierBuilder
    End Function
    Public Function StartingWith(ByVal SupplierId As Integer) As SupplierBuilder
        Dim oSupplierTa As New netwyrksDataSetTableAdapters.supplierTableAdapter
        Dim oSupplierTable As New netwyrksDataSet.supplierDataTable
        If oSupplierTa.FillById(oSupplierTable, SupplierId) > 0 Then
            StartingWith(oSupplierTable.Rows(0))
        Else
            StartingWithNothing()
        End If
        oSupplierTa.Dispose()
        oSupplierTable.Dispose()
        Return Me
    End Function
    Public Function StartingWith(ByVal oSupplier As Supplier) As SupplierBuilder
        With oSupplier
            _supplierId = .SupplierId
            _supplierName = .SupplierName
            _supplierAddress = .SupplierAddress
            _supplierEmail = .SupplierEmail
            _supplierPhone = .SupplierPhone
            _supplierNotes = .SupplierNotes
            _supplierDiscount = .SupplierDiscount
            _supplierCreated = .SupplierCreated
            _supplierChanged = .SupplierChanged
        End With
        Return Me
    End Function
    Public Function StartingWith(ByVal oSupplier As netwyrksDataSet.supplierRow) As SupplierBuilder

        With oSupplier
            _supplierId = .supplier_id
            _supplierName = .supplier_name
            _supplierAddress = AddressBuilder.AnAddress.StartingWith(oSupplier).Build
            _supplierEmail = If(.Issupplier_emailNull, "", .supplier_email)
            _supplierPhone = If(.Issupplier_telephoneNull, "", .supplier_telephone)
            _supplierNotes = If(.Issupplier_notesNull, "", .supplier_notes)
            _supplierDiscount = If(.Issupplier_discount_percentNull, 0, .supplier_discount_percent)
            _supplierCreated = .supplier_created
            If .Issupplier_changedNull Then
                _supplierChanged = Nothing
            Else
                _supplierChanged = .supplier_changed
            End If
        End With
        Return Me
    End Function
    Public Function StartingWithNothing() As SupplierBuilder
        _supplierId = -1
        _supplierName = ""
        _supplierAddress = AddressBuilder.AnAddress.StartingWithNothing.Build
        _supplierEmail = ""
        _supplierPhone = ""
        _supplierNotes = ""
        _supplierDiscount = 0
        _supplierCreated = Now
        _supplierChanged = Nothing
        Return Me
    End Function
    Public Function WithSupplierId(ByVal pSupplierId As Integer) As SupplierBuilder
        _supplierId = pSupplierId
        Return Me
    End Function
    Public Function WithSupplierName(ByVal pSupplierName As String) As SupplierBuilder
        _supplierName = pSupplierName
        Return Me
    End Function
    Public Function WithSupplierAddress(ByVal pSupplierAddress As Address) As SupplierBuilder
        _supplierAddress = pSupplierAddress
        Return Me
    End Function
    Public Function WithSupplierPhone(ByVal pSupplierPhone As String) As SupplierBuilder
        _supplierPhone = pSupplierPhone
        Return Me
    End Function
    Public Function WithSupplierEmail(ByVal pSupplierEmail As String) As SupplierBuilder
        _supplierEmail = pSupplierEmail
        Return Me
    End Function
    Public Function WithSupplierDiscount(ByVal pSupplierDiscount As Decimal) As SupplierBuilder
        _supplierDiscount = pSupplierDiscount
        Return Me
    End Function
    Public Function WithSupplierNotes(ByVal pSupplierNotes As String) As SupplierBuilder
        _supplierNotes = pSupplierNotes
        Return Me
    End Function
    Public Function WithSupplierCreated(ByVal pSupplierCreated As DateTime) As SupplierBuilder
        _supplierCreated = pSupplierCreated
        Return Me
    End Function
    Public Function WithSupplierChanged(ByVal pSupplierChanged As DateTime?) As SupplierBuilder
        _supplierChanged = pSupplierChanged
        Return Me
    End Function
    Public Function Build() As Supplier
        Return New Supplier(_supplierId,
                            _supplierName,
                            _supplierEmail,
                            _supplierPhone,
                            _supplierNotes,
                            _supplierCreated,
                            _supplierChanged,
                            _supplierAddress,
                            _supplierDiscount)
    End Function
End Class
