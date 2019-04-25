'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Public Class GeoResultBuilder
    Private _location As GeoPos
    Private _formattedAddress As String

    Public Shared Function aGeoResult() As GeoResultBuilder
        Return New GeoResultBuilder
    End Function

    Public Function startingWith(ByVal pGeoResult As GeoResult) As GeoResultBuilder
        _location = pGeoResult.location
        _formattedAddress = pGeoResult.formattedAddress
        Return Me
    End Function
    Public Function withLocation(ByVal plocation As GeoPos) As GeoResultBuilder
        _location = plocation
        Return Me
    End Function
    Public Function withFormattedAddress(ByVal pformattedAddress As String) As GeoResultBuilder
        _formattedAddress = pformattedAddress
        Return Me
    End Function
    Public Function build() As GeoResult
        Return New GeoResult(_location, _formattedAddress)
    End Function



End Class
