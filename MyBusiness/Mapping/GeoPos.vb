Imports System.Text

'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Public Class GeoPos
    Private Lng As Decimal?
    Private Lat As Decimal?
    Public Sub New(ByVal pLat As Decimal?, ByVal pLng As Decimal?)
        Lat = pLat
        Lng = pLng
    End Sub
    Public Property Latitude() As Decimal?
        Get
            Return Lat
        End Get
        Set(ByVal value As Decimal?)
            Lat = value
        End Set
    End Property

    Public Property Longitude() As Decimal?
        Get
            Return Lng
        End Get
        Set(ByVal value As Decimal?)
            Lng = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
            .Append("GeoPos=[") _
            .Append("Latitude=[") _
            .Append(Latitude) _
            .Append("], ") _
            .Append("Longitude=[") _
            .Append(Longitude) _
            .Append("]]")
        Return sb.ToString
    End Function


End Class
