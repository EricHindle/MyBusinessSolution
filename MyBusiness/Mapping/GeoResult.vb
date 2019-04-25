'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Public Class GeoResult
    Private _location As GeoPos
    Private _formattedAddress As String

    Public Sub New(ByVal plocation As GeoPos, ByVal pformattedAddress As String)
        _location = plocation
        _formattedAddress = pformattedAddress
    End Sub
    Public Property formattedAddress() As String
        Get
            Return _formattedAddress
        End Get
        Set(ByVal value As String)
            _formattedAddress = value
        End Set
    End Property

    Public Property location() As GeoPos
        Get
            Return _location
        End Get
        Set(ByVal value As GeoPos)
            _location = value
        End Set
    End Property

End Class
