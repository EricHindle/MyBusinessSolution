'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports Google.Api.Maps.Service.Geocoding
Imports System.Text
Imports System.Web
Imports System.Xml
Imports MyBusiness.netwyrksErrorCodes

''' <summary>
''' Utilities to obtain Geographical Info from MapQuest
''' </summary>
''' <remarks></remarks>
Public Class MapQuestGeoInfo
    Inherits GeoInfo

    Private Const SINGLE_LINE_COUNTRY_CODE As String = ",GB"
    Private Const PARSED_COUNTRY_CODE As String = "&adminArea1=GB"
    Private Const LOCATION As String = "&location="
    Private Const POST_CODE As String = "&postalCode="
    Private Const IN_FORMAT As String = "&inFormat=xml"
    Private Const OUT_FORMAT As String = "&outFormat=xml"
    ''' <summary>
    ''' MapQuest base URL held in the Global Settings table
    ''' </summary>
    ''' <remarks></remarks>
    Private MapQuestGeocodingURL As String = GlobalSettings.getSetting("MapQuestGeocodingURL")
    ''' <summary>
    ''' MapQuest account key held in the Global Settings table
    ''' </summary>
    ''' <remarks></remarks>
    Private mapQuestKey As String = GlobalSettings.getSetting("MapQuestKey")

    ''' <summary>
    ''' Requests GeoInfo for an address in a single line
    ''' </summary>
    ''' <param name="singleLineAddress"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function getGeographicalInfo(singleLineAddress As String) As GeoResponse
        Dim response As GeoResponseBuilder = GeoResponseBuilder.aGeoResponse.withNoResults().withStatus(GeoResponse.responseStatus.ZERORESULTS)
        If Not String.IsNullOrEmpty(mapQuestKey) And Not String.IsNullOrEmpty(singleLineAddress) Then
            Dim theURL As String = MapQuestGeocodingURL & mapQuestKey & OUT_FORMAT & LOCATION & singleLineAddress & SINGLE_LINE_COUNTRY_CODE
            LogUtil.Info("Getting Geo info for " & singleLineAddress, "getGeographicalInfo")
            response = requestGeocodingInfo(theURL)
        End If
        Return response.build
    End Function

    ''' <summary>
    ''' Requests GeoInfo for an address in separate fields
    ''' </summary>
    ''' <param name="Street"></param>
    ''' <param name="City"></param>
    ''' <param name="State"></param>
    ''' <param name="postcode"></param>
    ''' <returns></returns>
    ''' <remarks>Note. currently only uses the postcode</remarks>
    Public Overrides Function getGeographicalInfo(Street As String, City As String, State As String, postcode As String) As GeoResponse
        Dim response As GeoResponseBuilder = GeoResponseBuilder.aGeoResponse.withNoResults().withstatus(GeoResponse.responseStatus.ZERORESULTS)
        If Not String.IsNullOrEmpty(mapQuestKey) And Not String.IsNullOrEmpty(postcode) Then
            ' Dim theURL As String = "http://www.mapquestapi.com/geocoding/v1/address?key=" & API_KEY & OUT_FORMAT & "&street=" & HttpUtility.UrlEncode(Street) & "&city=" & HttpUtility.UrlEncode(City) & "&state=" & HttpUtility.UrlEncode(State)
            ' Dim theURL As String = "http://www.mapquestapi.com/geocoding/v1/address?key=" & API_KEY & IN_FORMAT & OUT_FORMAT & "xml=<locations><location><adminArea1 type=""Country"">UK</adminArea1><street>" & Street & "</street><city>" & City & "</city><state>" & State & "</state><postalCode>" & postcode & "</postalCode></location></locations>"
            ' Dim theURL As String = "http://www.mapquestapi.com/geocoding/v1/address?key=" & API_KEY & IN_FORMAT & OUT_FORMAT & "&xml=<locations><location><adminArea1 type=""Country"">UK</adminArea1><postalCode>" & postcode & "</postalCode></location></locations>"
            ' Dim theURL As String = "http://www.mapquestapi.com/geocoding/v1/address?key=" & API_KEY &  OUT_FORMAT & LOCATION & fulline & COUNTRY_CODE
            Dim theURL As String = MapQuestGeocodingURL & mapQuestKey & IN_FORMAT & OUT_FORMAT & POST_CODE & postcode & PARSED_COUNTRY_CODE
            response = requestGeocodingInfo(theURL)
        End If
        Return response.build
    End Function

    ''' <summary>
    ''' Builds a GeoResponse from the XML received from the HTTP call to MapQuest
    ''' </summary>
    ''' <param name="theURL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function requestGeocodingInfo(ByVal theURL As String) As GeoResponseBuilder
        Dim oResponse As GeoResponseBuilder = GeoResponseBuilder.aGeoResponse.withNoResults.withStatus(GeoResponse.responseStatus.ZERORESULTS)

        Try

            ' ===== Using this code because Citrix won't handle the simpler version

            Dim responseXml As String
            Using oWebClient As New System.Net.WebClient()
                LogUtil.Info("Using WebClient to get geocoding info", "requestGeocodingInfo")
                responseXml = oWebClient.DownloadString(theURL)
            End Using

            Dim strAsBytes() As Byte = New System.Text.UTF8Encoding().GetBytes(responseXml)

            LogUtil.Info("Converting geocoding info xml string to memory stream in xml text reader", "requestGeocodingInfo")
            Dim oMemoryString As New System.IO.MemoryStream(strAsBytes)
            Dim reader As XmlTextReader = New XmlTextReader(oMemoryString)

            '         Dim reader As XmlTextReader = New XmlTextReader(theURL)
            ' =====================================================================

            reader.WhitespaceHandling = WhitespaceHandling.Significant
            Dim mqResponse As New MapQuestResponse.response
            Dim serializer As New Xml.Serialization.XmlSerializer(mqResponse.GetType)
            LogUtil.Info("De-serializing XML", "requestGeocodingInfo")
            If serializer.CanDeserialize(reader) Then
                mqResponse = serializer.Deserialize(reader)
                LogUtil.Info("Transforming MapQuest Response to GeoResponse", "requestGeocodingInfo")
                oResponse = GeoResponseTransformer.transformMapQuestResponseToGeoResponse(mqResponse)
            Else
                LogUtil.Problem("Cannot de-serialise the MapQuest Response", "requestGeocodingInfo")
                oResponse = oResponse.withStatus(GeoResponse.responseStatus.INVALIDREQUEST)
            End If
            oMemoryString.Dispose()
        Catch ex As Exception
            LogUtil.Exception("Invalid GeocodingRequest operation", ex, "requestGeocodingInfo", getErrorCode(SystemModule.MAPPING, ErrorType.APPLICATION, FailedAction.GEO_CODING_ERROR))
            oResponse = oResponse.withStatus(GeoResponse.responseStatus.INVALIDREQUEST)
        End Try
        Return oResponse
    End Function


End Class
