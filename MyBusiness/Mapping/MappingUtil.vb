'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.Windows.Media.Imaging
Imports System.IO
Imports System.Text
Imports System.Net

Public MustInherit Class MappingUtil

    Public Const EARTH_RADIUS As Decimal = 3960.0
    Public Const DEGREES_TO_RADIANS As Decimal = Math.PI / 180.0
    Public Const RADIANS_TO_DEGREES As Decimal = 180.0 / Math.PI

    Protected ehImage As System.Windows.Controls.Image = New System.Windows.Controls.Image()

    Public Shared Function convertMilesToLatitude(miles As Decimal) As Decimal
        Return (miles / EARTH_RADIUS) * RADIANS_TO_DEGREES
    End Function

    Public Shared Function convertMilesToLongitude(miles As Decimal, latitude As Decimal) As Decimal
        Dim radius As Decimal = EARTH_RADIUS * Math.Cos(latitude * DEGREES_TO_RADIANS)
        Return (miles / radius) * RADIANS_TO_DEGREES
    End Function

    Public Shared Function calculateDistance(latitude1 As Decimal, longitude1 As Decimal, latitude2 As Decimal, longitude2 As Decimal) As Decimal
        Dim milesNorth As Decimal = (EARTH_RADIUS * DEGREES_TO_RADIANS) * (latitude2 - latitude1)
        Dim milesWest As Decimal = (EARTH_RADIUS * DEGREES_TO_RADIANS) * (longitude2 - longitude1) * Math.Cos(latitude1 / RADIANS_TO_DEGREES)
        Return Math.Sqrt((milesNorth ^ 2) + (milesWest ^ 2))

    End Function

    Public Shared Function calculateDistanceBetweenTwoLocations(ByVal geoLocation1 As GeoPos, ByVal geoLocation2 As GeoPos) As Decimal
        Dim milesNorth As Decimal = (EARTH_RADIUS * DEGREES_TO_RADIANS) * (geoLocation2.Latitude - geoLocation1.Latitude)
        Dim milesWest As Decimal = (EARTH_RADIUS * DEGREES_TO_RADIANS) * (geoLocation2.Longitude - geoLocation1.Longitude) * Math.Cos(geoLocation1.Latitude / RADIANS_TO_DEGREES)
        Return Math.Sqrt((milesNorth ^ 2) + (milesWest ^ 2))
    End Function

    Public Shared Function setGeolocation(ByVal lat As String, ByVal lng As String) As GeoPos
        Dim gp As GeoPos = Nothing
        If lat IsNot Nothing _
            AndAlso lat.Length > 0 _
            AndAlso lng IsNot Nothing _
            AndAlso lng.Length > 0 _
            AndAlso IsNumeric(lat) _
            AndAlso IsNumeric(lng) Then
            Dim dLat As Decimal = CDec(lat)
            Dim dLng As Decimal = CDec(lng)
            gp = New GeoPos(dLat, dLng)
        End If
        Return gp
    End Function

    Public Shared Sub mpMap_DownloadCompleted(sender As Object, e As EventArgs)
        Dim encoder As New JpegBitmapEncoder()
        encoder.Frames.Add(BitmapFrame.Create(CType(sender, BitmapImage)))
        Using filestream As New FileStream(ImageUtil.tempMapImageFile, FileMode.Create)
            encoder.Save(filestream)
        End Using
    End Sub

    Public MustOverride Function createLboMap(ByVal smaptype As String, ByRef lboNodes As Dictionary(Of Integer, TreeNode), ByRef returnUri As String, Optional ByVal pWidth As Integer = 400, Optional ByVal pHeight As Integer = 400, Optional ByVal isShowAll As Boolean = False) As System.Windows.Controls.Image
    Public MustOverride Function getMarker(ByVal charNo As Integer) As String
    Public MustOverride Function getMapTypes() As String()

End Class
