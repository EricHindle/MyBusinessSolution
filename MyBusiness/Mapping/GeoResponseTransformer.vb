'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports Google.Api.Maps.Service.Geocoding
Public Class GeoResponseTransformer
    Public Shared Function transformGoogleResponseToGeoResponse(ByVal oResponse As GeocodingResponse) As GeoResponseBuilder
        Dim oGeoResponse As GeoResponseBuilder = GeoResponseBuilder.aGeoResponse.withNoResults.withstatus(oResponse.Status)
        Dim bestResult As GeoResult = Nothing
        For Each oResult As GeocodingResult In oResponse.Results
            Dim oPos As GeoPos = GeoPosBuilder.aGeoPos.withLatitude(oResult.Geometry.Location.Latitude).withLongitude(oResult.Geometry.Location.Longitude).build
            Dim oGeoResult As GeoResultBuilder = GeoResultBuilder.aGeoResult.withFormattedAddress(oResult.FormattedAddress).withLocation(oPos)
            oGeoResponse.addResult(oGeoResult.build)
            If bestResult Is Nothing And oResponse.Status = Google.Api.Maps.Service.ServiceResponseStatus.Ok Then
                bestResult = oGeoResult.build
            End If
        Next
        oGeoResponse.withBestResult(bestResult)
        Return oGeoResponse
    End Function
    Public Shared Function transformMapQuestResponseToGeoResponse(ByVal mqResponse As MapQuestResponse.response) As GeoResponseBuilder
        Dim oGeoResponse As GeoResponseBuilder = GeoResponseBuilder.aGeoResponse
        Dim oStatus As GeoResponse.responseStatus = GeoResponse.responseStatus.UNKNOWN
        If mqResponse Is Nothing Then
            LogUtil.Problem("MapQuest response is nothing", "transformMapQuestResponseToGeoResponse")
            oGeoResponse.withStatus(GeoResponse.responseStatus.INVALIDREQUEST)
        Else
            Dim bestResult As GeoResult = GeoResultBuilder.aGeoResult.build
            Dim confidenceLevel As String = "XX"
            If mqResponse.results.Length = 0 OrElse mqResponse.results(0).locations.Length = 0 Then
                LogUtil.Problem("Zero results", "transformMapQuestResponseToGeoResponse")
                oStatus = GeoResponse.responseStatus.ZERORESULTS
            End If
            LogUtil.Info("Building results", "transformMapQuestResponseToGeoResponse")
            For Each mqResult As MapQuestResponse.result In mqResponse.results
                LogUtil.Info("Result with " & CStr(mqResult.locations.Count) & " locations", "transformMapQuestResponseToGeoResponse")
                For Each mqLocation As MapQuestResponse.location In mqResult.locations
                    Dim oResult As GeoResultBuilder = GeoResultBuilder.aGeoResult
                    Dim oGeoPos As GeoPos = GeoPosBuilder.aGeoPos.withLatitude(mqLocation.latLng.lat).withLongitude(mqLocation.latLng.lng).build
                    Dim oAddress As Address = AddressBuilder.anAddress.withAddress1(mqLocation.adminArea6).withAddress2(mqLocation.adminArea5).withAddress3(mqLocation.adminArea3).withAddress4(mqLocation.adminArea4).withPostcode(mqLocation.postalCode).build
                    LogUtil.Info("Building location " & oAddress.getFullAddress, "transformMapQuestResponseToGeoResponse")
                    oResult.withLocation(oGeoPos).withFormattedAddress(oAddress.getFullAddress)
                    LogUtil.Info("Location quality code = " & mqLocation.geocodeQualityCode, "transformMapQuestResponseToGeoResponse")
                    If mqLocation.geocodeQualityCode.StartsWith("Z1X") Then
                        Dim thisConfidenceLevel As String = mqLocation.geocodeQualityCode.Substring(3, 2)
                        If thisConfidenceLevel < confidenceLevel Then
                            LogUtil.Info("Location with confidence level " & thisConfidenceLevel & " is best result so far", "transformMapQuestResponseToGeoResponse")
                            bestResult = oResult.build
                            confidenceLevel = thisConfidenceLevel
                            oGeoResponse.withStatus(GeoResponse.responseStatus.OK)
                        End If
                    End If
                    oGeoResponse.addResult(oResult.build)
                Next
            Next
            oGeoResponse.withBestResult(bestResult)
        End If
        Return oGeoResponse
    End Function

End Class
