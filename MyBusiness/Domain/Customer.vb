'
' Copyright (c) 2017, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.Text
''' <summary>
''' Object to describe a customer
''' </summary>
''' <remarks></remarks>
Public Class Customer
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


    Public Sub New(ByVal pCustId As Integer, _
                   ByVal pCustName As String, _
                   ByVal pEmail As String, _
                   ByVal pPhone As String, _
                   ByVal pNotes As String, _
                   ByVal pDateCreated As DateTime, _
                   ByVal pDateChanged As DateTime?, _
                   ByVal pAddress As Address, _
                   ByVal pDiscount As Decimal?, _
                   ByVal pTerms As Integer)

        _custId = pCustId
        _custName = pCustName
        _custAddress = pAddress
        _email = pEmail
        _phone = pPhone
        _notes = pNotes
        _discount = pDiscount
        _dateCreated = pDateCreated
        _dateChanged = pDateChanged
        _terms = pTerms
    End Sub
    Public Property terms() As Integer?
        Get
            Return If(_terms Is Nothing, 0, _terms)
        End Get
        Set(ByVal value As Integer?)
            _terms = value
        End Set
    End Property
    Public Property discount() As Decimal?
        Get
            Return If(_discount Is Nothing, 0, _discount)
        End Get
        Set(ByVal value As Decimal?)
            _discount = value
        End Set
    End Property
    Public Property dateChanged() As DateTime?
        Get
            Return _dateChanged
        End Get
        Set(ByVal value As DateTime?)
            _dateChanged = value
        End Set
    End Property
    Public Property dateCreated() As DateTime
        Get
            Return _dateCreated
        End Get
        Set(ByVal value As DateTime)
            _dateCreated = value
        End Set
    End Property

    Public Property notes() As String
        Get
            Return If(_notes Is Nothing, "", _notes)
        End Get
        Set(ByVal value As String)
            _notes = value
        End Set
    End Property
    Public Property Phone() As String
        Get
            Return If(_phone Is Nothing, "", _phone)
        End Get
        Set(ByVal value As String)
            _phone = value
        End Set
    End Property
    Public Property email() As String
        Get
            Return If(_email Is Nothing, "", _email)
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Public Property custName() As String
        Get
            Return If(_custName Is Nothing, "", _custName)
        End Get
        Set(ByVal value As String)
            _custName = value
        End Set
    End Property

    Public Property customerId() As Integer
        Get
            Return _custId
        End Get
        Set(ByVal value As Integer)
            _custId = value
        End Set
    End Property
    Public Property address() As Address
        Get
            Return If(_custAddress Is Nothing, AddressBuilder.anAddress.startingWithNothing.build, _custAddress)
        End Get
        Set(ByVal value As Address)
            _custAddress = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
        .Append("Customer=[") _
        .Append("customerId=[") _
        .Append(customerId) _
        .Append("], Name=[") _
        .Append(custName) _
        .Append("], email=[") _
        .Append(email) _
        .Append("], phone=[") _
        .Append(Phone) _
        .Append("], notes=[") _
        .Append(notes) _
        .Append("], dateCreated=[") _
        .Append(Format(dateCreated, "dd/MM/yyyy")) _
        .Append("], dateChanged=[") _
        .Append(If(dateChanged Is Nothing, "", Format(dateChanged, "dd/MM/yyyy"))) _
        .Append("], ") _
        .Append(address.ToString) _
        .Append(", discount=[") _
        .Append(CStr(discount)) _
        .Append("], terms=[") _
        .Append(CStr(terms)) _
        .Append("]]")
        Return sb.ToString
    End Function

End Class
