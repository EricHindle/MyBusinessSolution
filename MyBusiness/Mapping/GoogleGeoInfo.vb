'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports Google.Api.Maps.Service.Geocoding
Imports System.Text
Imports MyBusiness.NetwyrksErrorCodes
Public Class GoogleGeoInfo
    Inherits GeoInfo

    Public Overrides Function getGeographicalInfo(fullLBOAddress As String) As GeoResponse
        Dim fmqResponse As New Google.Api.Maps.Service.Geocoding.GeocodingResponse
        Dim oResponse As GeoResponseBuilder = GeoResponseBuilder.aGeoResponse.withNoResults.withstatus(GeoResponse.responseStatus.ZERORESULTS)

        Try
            Dim fmqRequest = New Google.Api.Maps.Service.Geocoding.GeocodingRequest() 'Request geographical info
            fmqRequest.Address = fullLBOAddress
            fmqRequest.Sensor = "false"
            fmqResponse = Google.Api.Maps.Service.Geocoding.GeocodingService.GetResponse(fmqRequest)
            oResponse = GeoResponseTransformer.transformGoogleResponseToGeoResponse(fmqResponse)
        Catch ex As System.InvalidOperationException
            LogUtil.Exception("Invalid GeocodingRequest operation", ex, "getGeographicalInfo", getErrorCode(SystemModule.MAPPING, ErrorType.APPLICATION, FailedAction.GEO_CODING_ERROR))
            oResponse.withstatus(GeoResponse.responseStatus.INVALIDREQUEST)
        Finally
        End Try
        Return oResponse.build
    End Function

    Public Overrides Function getGeographicalInfo(Street As String, City As String, State As String, postcode As String) As GeoResponse
        Return Nothing
    End Function
End Class
