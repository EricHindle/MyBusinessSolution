'
' Copyright (c) 2017, Eric Hindle
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
    Public Shared Function aSupplierBuilder() As SupplierBuilder
        Return New SupplierBuilder
    End Function
    Public Function startingWith(ByVal SupplierId As Integer) As SupplierBuilder
        Dim oSupplierTa As New netwyrksDataSetTableAdapters.supplierTableAdapter
        Dim oSupplierTable As New netwyrksDataSet.supplierDataTable
        Dim oSupplierRow As netwyrksDataSet.supplierRow = Nothing
        If oSupplierTa.FillById(oSupplierTable, SupplierId) > 0 Then
            startingWith(oSupplierTable.Rows(0))
        Else
            startingWithNothing()
        End If
        oSupplierTa.Dispose()
        oSupplierTable.Dispose()
        Return Me
    End Function

    Public Function startingWith(ByVal oSupplier As Supplier) As SupplierBuilder
        With oSupplier
            _supplierId = .supplierId
            _supplierName = .supplierName
            _supplierAddress = .supplierAddress
            _supplierEmail = .supplierEmail
            _supplierPhone = .supplierPhone
            _supplierNotes = .supplierNotes
            _supplierDiscount = .supplierDiscount
            _supplierCreated = .supplierCreated
            _supplierChanged = .supplierChanged

        End With
        Return Me
    End Function
    Public Function startingWith(ByVal oSupplier As netwyrksDataSet.supplierRow) As SupplierBuilder

        With oSupplier
            _supplierId = .supplier_id
            _supplierName = .supplier_name
            _supplierAddress = AddressBuilder.anAddress.startingWith(oSupplier).build
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
    Public Function startingWithNothing() As SupplierBuilder
        _supplierId = -1
        _supplierName = ""
        _supplierAddress = AddressBuilder.anAddress.startingWithNothing.build
        _supplierEmail = ""
        _supplierPhone = ""
        _supplierNotes = ""
        _supplierDiscount = 0
        _supplierCreated = Now
        _supplierChanged = Nothing
        Return Me
    End Function
    Public Function withSupplierId(ByVal pSupplierId As Integer) As SupplierBuilder
        _supplierId = pSupplierId
        Return Me
    End Function
    Public Function withSupplierName(ByVal pSupplierName As String) As SupplierBuilder
        _supplierName = pSupplierName
        Return Me
    End Function
    Public Function withSupplierAddress(ByVal pSupplierAddress As Address) As SupplierBuilder
        _supplierAddress = pSupplierAddress
        Return Me
    End Function
    Public Function withSupplierPhone(ByVal pSupplierPhone As String) As SupplierBuilder
        _supplierPhone = pSupplierPhone
        Return Me
    End Function
    Public Function withSupplierEmail(ByVal pSupplierEmail As String) As SupplierBuilder
        _supplierEmail = pSupplierEmail
        Return Me
    End Function
    Public Function withSupplierDiscount(ByVal pSupplierDiscount As Decimal) As SupplierBuilder
        _supplierDiscount = pSupplierDiscount
        Return Me
    End Function
    Public Function withSupplierNotes(ByVal pSupplierNotes As String) As SupplierBuilder
        _supplierNotes = pSupplierNotes
        Return Me
    End Function
    Public Function withSupplierCreated(ByVal pSupplierCreated As DateTime) As SupplierBuilder
        _supplierCreated = pSupplierCreated
        Return Me
    End Function
    Public Function withSupplierChanged(ByVal pSupplierChanged As DateTime?) As SupplierBuilder
        _supplierChanged = pSupplierChanged
        Return Me
    End Function
    Public Function build() As Supplier
        Return New Supplier(_supplierId, _
                            _supplierName, _
                            _supplierEmail, _
                            _supplierPhone, _
                            _supplierNotes, _
                            _supplierCreated, _
                            _supplierChanged, _
                            _supplierAddress, _
                            _supplierDiscount)
    End Function
End Class
