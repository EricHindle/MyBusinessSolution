'
' Copyright (c) 2017, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.Text
''' <summary>
''' Customer builder  (see https://en.wikipedia.org/wiki/Builder_pattern)
''' </summary>
''' <remarks></remarks>
Public Class CustomerBuilder
    Private _custId As Integer
    Private _custName As String
    Private _custAddress As Address
    Private _email As String
    Private _phone As String
    Private _notes As String
    Private _discount As Decimal?
    Private _dateCreated As DateTime
    Private _dateChanged As DateTime?
    Private _terms As Integer?

    Public Shared Function aCustomer() As CustomerBuilder
        Return New CustomerBuilder
    End Function

    Public Function refresh() As CustomerBuilder
        startingWith(_custId)
        Return Me
    End Function

    Public Function startingWith(ByVal custId As Integer) As CustomerBuilder
        Dim oCustTa As New netwyrksDataSetTableAdapters.customerTableAdapter
        Dim oCustTable As New netwyrksDataSet.customerDataTable
        If oCustTa.FillById(oCustTable, custId) > 0 Then
            startingWith(oCustTable.Rows(0))
        Else
            startingWithNothing()
        End If
        oCustTa.Dispose()
        oCustTable.Dispose()
        Return Me
    End Function

    Public Function startingWith(ByVal oCustomer As Customer) As CustomerBuilder
        With oCustomer
            _custId = .customerId
            _custAddress = .address
            _custName = .custName
            _phone = .Phone
            _email = .email
            _notes = .notes
            _discount = .discount
            _dateChanged = .dateChanged
            _dateCreated = .dateCreated
            _terms = .terms
        End With

        Return Me
    End Function

    Public Function startingWith(ByVal oRow As netwyrksDataSet.customerRow) As CustomerBuilder
        If oRow Is Nothing Then
            startingWithNothing()
        Else
            With oRow
                _custId = .customer_id
                _custName = .customer_name
                _custAddress = AddressBuilder.anAddress.startingWith(oRow).build
                _phone = If(.Iscustomer_telephoneNull, "", .customer_telephone)
                _email = If(.Iscustomer_emailNull, "", .customer_email)
                _discount = If(.Iscustomer_discount_percentNull, 0.0, .customer_discount_percent)
                _notes = If(.Iscustomer_notesNull, "", .customer_notes)
                _dateCreated = .customer_created
                If .Iscustomer_changedNull Then
                    _dateChanged = Nothing
                Else
                    _dateChanged = .customer_changed
                End If
                _terms = If(.Iscustomer_termsNull, 0, .customer_terms)
            End With
        End If
        Return Me
    End Function

    Public Function startingWithNothing() As CustomerBuilder
        _custId = 0
        _custName = ""
        _custAddress = AddressBuilder.anAddress.startingWithNothing().build
        _phone = ""
        _email = ""
        _discount = 0.0
        _notes = ""
        _dateCreated = Today.Date
        _dateChanged = Nothing
        _terms = 0
        Return Me
    End Function


    Public Function withCustId(ByVal pCustId As Integer) As CustomerBuilder
        _custId = pCustId
        Return Me
    End Function
    Public Function withCustName(ByVal pCustName As String) As CustomerBuilder
        _custName = pCustName
        Return Me
    End Function
    Public Function withPhone(ByVal pPhone As String) As CustomerBuilder
        _phone = pPhone
        Return Me
    End Function
    Public Function withEmail(ByVal pEmail As String) As CustomerBuilder
        _email = pEmail
        Return Me
    End Function
    Public Function withDiscount(ByVal pDiscount As Decimal?) As CustomerBuilder
        _discount = pDiscount
        Return Me
    End Function
    Public Function withNotes(ByVal pNotes As String) As CustomerBuilder
        _notes = pNotes
        Return Me
    End Function
    Public Function withAddress(ByVal pAddress As Address) As CustomerBuilder
        _custAddress = pAddress
        Return Me
    End Function

    Public Function withDateCreated(ByVal pDateCreated As DateTime) As CustomerBuilder
        _dateCreated = pDateCreated
        Return Me
    End Function

    Public Function withDateChanged(ByVal pDateChanged As DateTime?) As CustomerBuilder
        _dateChanged = pDateChanged
        Return Me
    End Function
    Public Function withTerms(ByVal pTerms As Integer?) As CustomerBuilder
        _terms = pTerms
        Return Me
    End Function

    Public Function build() As Customer
        Return New Customer(_custId, _
                            _custName, _
                            _email, _
                            _phone, _
                            _notes, _
                            _dateCreated, _
                            _dateChanged, _
                            _custAddress, _
                            _discount, _
                            _terms)
    End Function

End Class
