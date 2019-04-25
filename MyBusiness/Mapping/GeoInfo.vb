'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports Google.Api.Maps.Service.Geocoding
Imports System.Text

Public MustInherit Class GeoInfo

    Public MustOverride Function getGeographicalInfo(fullLBOAddress As String) As GeoResponse
    Public MustOverride Function getGeographicalInfo(Street As String, City As String, State As String, postcode As String) As GeoResponse

End Class
