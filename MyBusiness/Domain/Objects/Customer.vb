' Hindleware
' Copyright (c) 2021, Eric Hindle
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
    Public Sub New(ByVal pCustId As Integer,
                   ByVal pCustName As String,
                   ByVal pEmail As String,
                   ByVal pPhone As String,
                   ByVal pNotes As String,
                   ByVal pDateCreated As DateTime,
                   ByVal pDateChanged As DateTime?,
                   ByVal pAddress As Address,
                   ByVal pDiscount As Decimal?,
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
    Public Property Terms() As Integer?
        Get
            Return If(_terms Is Nothing, 0, _terms)
        End Get
        Set(ByVal value As Integer?)
            _terms = value
        End Set
    End Property
    Public Property Discount() As Decimal?
        Get
            Return If(_discount Is Nothing, 0, _discount)
        End Get
        Set(ByVal value As Decimal?)
            _discount = value
        End Set
    End Property
    Public Property DateChanged() As DateTime?
        Get
            Return _dateChanged
        End Get
        Set(ByVal value As DateTime?)
            _dateChanged = value
        End Set
    End Property
    Public Property DateCreated() As DateTime
        Get
            Return _dateCreated
        End Get
        Set(ByVal value As DateTime)
            _dateCreated = value
        End Set
    End Property
    Public Property Notes() As String
        Get
            Return If(_notes, "")
        End Get
        Set(ByVal value As String)
            _notes = value
        End Set
    End Property
    Public Property Phone() As String
        Get
            Return If(_phone, "")
        End Get
        Set(ByVal value As String)
            _phone = value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return If(_email, "")
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property
    Public Property CustName() As String
        Get
            Return If(_custName, "")
        End Get
        Set(ByVal value As String)
            _custName = value
        End Set
    End Property
    Public Property CustomerId() As Integer
        Get
            Return _custId
        End Get
        Set(ByVal value As Integer)
            _custId = value
        End Set
    End Property
    Public Property Address() As Address
        Get
            Return If(_custAddress, AddressBuilder.AnAddress.StartingWithNothing.Build)
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
        .Append(CustomerId) _
        .Append("], Name=[") _
        .Append(CustName) _
        .Append("], email=[") _
        .Append(Email) _
        .Append("], phone=[") _
        .Append(Phone) _
        .Append("], notes=[") _
        .Append(Notes) _
        .Append("], dateCreated=[") _
        .Append(Format(DateCreated, "dd/MM/yyyy")) _
        .Append("], dateChanged=[") _
        .Append(If(DateChanged Is Nothing, "", Format(DateChanged, "dd/MM/yyyy"))) _
        .Append("], ") _
        .Append(Address.ToString) _
        .Append(", discount=[") _
        .Append(CStr(Discount)) _
        .Append("], terms=[") _
        .Append(CStr(Terms)) _
        .Append("]]")
        Return sb.ToString
    End Function
End Class
