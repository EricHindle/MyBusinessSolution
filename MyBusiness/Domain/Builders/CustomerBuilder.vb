' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

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
    Public Shared Function ACustomer() As CustomerBuilder
        Return New CustomerBuilder
    End Function
    Public Function Refresh() As CustomerBuilder
        StartingWith(_custId)
        Return Me
    End Function
    Public Function StartingWith(ByVal custId As Integer) As CustomerBuilder
        Dim oCustTa As New netwyrksDataSetTableAdapters.customerTableAdapter
        Dim oCustTable As New netwyrksDataSet.customerDataTable
        If oCustTa.FillById(oCustTable, custId) > 0 Then
            StartingWith(oCustTable.Rows(0))
        Else
            StartingWithNothing()
        End If
        oCustTa.Dispose()
        oCustTable.Dispose()
        Return Me
    End Function
    Public Function StartingWith(ByVal oCustomer As Customer) As CustomerBuilder
        With oCustomer
            _custId = .CustomerId
            _custAddress = .Address
            _custName = .CustName
            _phone = .Phone
            _email = .Email
            _notes = .Notes
            _discount = .Discount
            _dateChanged = .DateChanged
            _dateCreated = .DateCreated
            _terms = .Terms
        End With

        Return Me
    End Function
    Public Function StartingWith(ByVal oRow As netwyrksDataSet.customerRow) As CustomerBuilder
        If oRow Is Nothing Then
            StartingWithNothing()
        Else
            With oRow
                _custId = .customer_id
                _custName = .customer_name
                _custAddress = AddressBuilder.AnAddress.StartingWith(oRow).Build
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
    Public Function StartingWithNothing() As CustomerBuilder
        _custId = 0
        _custName = ""
        _custAddress = AddressBuilder.AnAddress.StartingWithNothing().Build
        _phone = ""
        _email = ""
        _discount = 0.0
        _notes = ""
        _dateCreated = Today.Date
        _dateChanged = Nothing
        _terms = 0
        Return Me
    End Function
    Public Function WithCustId(ByVal pCustId As Integer) As CustomerBuilder
        _custId = pCustId
        Return Me
    End Function
    Public Function WithCustName(ByVal pCustName As String) As CustomerBuilder
        _custName = pCustName
        Return Me
    End Function
    Public Function WithPhone(ByVal pPhone As String) As CustomerBuilder
        _phone = pPhone
        Return Me
    End Function
    Public Function WithEmail(ByVal pEmail As String) As CustomerBuilder
        _email = pEmail
        Return Me
    End Function
    Public Function WithDiscount(ByVal pDiscount As Decimal?) As CustomerBuilder
        _discount = pDiscount
        Return Me
    End Function
    Public Function WithNotes(ByVal pNotes As String) As CustomerBuilder
        _notes = pNotes
        Return Me
    End Function
    Public Function WithAddress(ByVal pAddress As Address) As CustomerBuilder
        _custAddress = pAddress
        Return Me
    End Function
    Public Function WithDateCreated(ByVal pDateCreated As DateTime) As CustomerBuilder
        _dateCreated = pDateCreated
        Return Me
    End Function
    Public Function WithDateChanged(ByVal pDateChanged As DateTime?) As CustomerBuilder
        _dateChanged = pDateChanged
        Return Me
    End Function
    Public Function WithTerms(ByVal pTerms As Integer?) As CustomerBuilder
        _terms = pTerms
        Return Me
    End Function
    Public Function Build() As Customer
        Return New Customer(_custId,
                            _custName,
                            _email,
                            _phone,
                            _notes,
                            _dateCreated,
                            _dateChanged,
                            _custAddress,
                            _discount,
                            _terms)
    End Function
End Class
