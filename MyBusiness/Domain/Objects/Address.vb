' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
''' <summary>
''' Customer or shop (lbo) address
''' </summary>
''' <remarks></remarks>
Public Class Address
    Private _address1 As String
    Private _address2 As String
    Private _address3 As String
    Private _address4 As String
    Private _postcode As String
    Public Sub New(ByVal pAddress1 As String,
                   ByVal pAddress2 As String,
                   ByVal pAddress3 As String,
                   ByVal pAddress4 As String,
                   ByVal pPostcode As String)
        _address1 = pAddress1
        _address2 = pAddress2
        _address3 = pAddress3
        _address4 = pAddress4
        _postcode = pPostcode

    End Sub
    Public Property Postcode() As String
        Get
            Return If(_postcode, "")
        End Get
        Set(ByVal value As String)
            _postcode = value
        End Set
    End Property
    Public Property Address1() As String
        Get
            Return If(_address1, "")
        End Get
        Set(ByVal value As String)
            _address1 = value
        End Set
    End Property
    Public Property Address2() As String
        Get
            Return If(_address2, "")
        End Get
        Set(ByVal value As String)
            _address2 = value
        End Set
    End Property
    Public Property Address3() As String
        Get
            Return If(_address3, "")
        End Get
        Set(ByVal value As String)
            _address3 = value
        End Set
    End Property
    Public Property Address4() As String
        Get
            Return If(_address4, "")
        End Get
        Set(ByVal value As String)
            _address4 = value
        End Set
    End Property
    Public Function GetFullAddress() As String
        Dim sb As New StringBuilder
        If Not String.IsNullOrEmpty(_address1) Then
            sb.Append(_address1.Trim()).Append(", ")
        End If
        If Not String.IsNullOrEmpty(_address2) Then
            sb.Append(_address2.Trim()).Append(", ")
        End If
        If Not String.IsNullOrEmpty(_address3) Then
            sb.Append(_address3.Trim()).Append(", ")
        End If
        If Not String.IsNullOrEmpty(_address4) Then
            sb.Append(_address4.Trim()).Append(", ")
        End If
        If Not String.IsNullOrEmpty(_postcode) Then
            sb.Append(_postcode.Trim())
        End If
        Return sb.ToString.Trim(" ").Trim(",")
    End Function
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
        .Append("address=[") _
        .Append("address1=[") _
        .Append(address1) _
        .Append("], address2=[") _
        .Append(address2) _
        .Append("], address3=[") _
        .Append(address3) _
        .Append("], address4=[") _
        .Append(address4) _
        .Append("], postcode=[") _
        .Append(postcode) _
        .Append("]]")
        Return sb.ToString
    End Function
End Class
