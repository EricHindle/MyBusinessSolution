'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.Text
Imports System.Windows.Media.Imaging

''' <summary>
''' Utilities for creating an MapQuest Map
''' </summary>
''' <remarks></remarks>
Public Class MapQuestMapUtil
    Inherits MappingUtil
    Protected mColour() As String = New String() {"orange", "blue", "red", "yellow", "green", "purple", "pink"}
    ''' <summary>
    ''' Base URL for the map request held in the Global Settings table
    ''' </summary>
    ''' <remarks></remarks>
    Private MapQuestStaticMapURL As String = GlobalSettings.getSetting("MapQuestStaticMapURL")
    ''' <summary>
    ''' MapQuest account key held in the Global Settings table
    ''' </summary>
    ''' <remarks></remarks>
    Private mapQuestKey As String = GlobalSettings.getSetting("MapQuestKey")
    Private Const MAP_SIZE As String = "&size="
    Private Const MIN_HEIGHT As Integer = 400
    Private Const MIN_WIDTH As Integer = 400
    Private Const MAX_HEIGHT As Integer = 1600
    Private Const MAX_WIDTH As Integer = 1600
    Private iWidth As Integer = MIN_WIDTH
    Private iHeight As Integer = MIN_HEIGHT
    ''' <summary>
    ''' Enum of permitted map types
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' map = map
    ''' sat = satellite
    ''' hyb = hybrid
    ''' </remarks>
    Public Overrides Function getMapTypes() As String()
        Return New String() {"map", "sat", "hyb"}
    End Function

    ''' <summary>
    ''' Ensures that maximum marker number (150) is not exceeded
    ''' </summary>
    ''' <param name="charNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function getMarker(charNo As Integer) As String
        If charNo > 150 Then
            charNo = 0
        End If
        Return CStr(charNo)
    End Function

    ''' <summary>
    ''' Build the HTTP request for a static map, make the rquest and return the map image
    ''' </summary>
    ''' <param name="sMapType">Map type can be map or satellite or hybrid</param>
    ''' <param name="lboNodes">Tree of nodes containing shop locations</param>
    ''' <param name="returnUri">Used to return the URI of the map</param>
    ''' <param name="pWidth">map width</param>
    ''' <param name="pHeight">map height</param>
    ''' <returns>Static map image</returns>
    ''' <remarks></remarks>
    Public Overrides Function createLboMap(ByVal sMapType As String, ByRef lboNodes As Dictionary(Of Integer, TreeNode), ByRef returnUri As String, Optional ByVal pWidth As Integer = 400, Optional ByVal pHeight As Integer = 400, Optional ByVal isShowAll As Boolean = False) As System.Windows.Controls.Image
        Dim allMarkers As New ArrayList
        ehImage = New System.Windows.Controls.Image()
        Dim pCenter As String = ""
        For Each oNode In lboNodes
            Select Case oNode.Key
                Case 0
                    pCenter = buildCentreMarker(oNode.Value, isShowAll)
                Case Is < mColour.Length
                    allMarkers = buildMarkers(oNode.Key, lboNodes, allMarkers, mColour(oNode.Key), isShowAll)
                Case Else
                    allMarkers = buildMarkers(9999, lboNodes, allMarkers, "white", isShowAll)
            End Select
        Next
        Dim sDeclutter As String = If(My.Settings.MapQuestDeclutter, "true", "false")
        If pWidth > MIN_WIDTH And pWidth < MAX_WIDTH Then
            iWidth = pWidth
        End If
        If pHeight > MIN_HEIGHT And pHeight < MAX_HEIGHT Then
            iHeight = pHeight
        End If
        Dim mapSize As String = MAP_SIZE & CStr(iWidth) & "," & CStr(iHeight)
        Dim theUrl As New StringBuilder(MapQuestStaticMapURL & mapQuestKey & mapSize & pCenter & "&declutter=" & sDeclutter & "&type=" & sMapType & "&imagetype=jpeg&pois=")
        For Each marker As String In allMarkers
            theUrl.Append(marker).Append("|")
        Next
        Dim mpMap As New BitmapImage()
        mpMap.BeginInit()
        mpMap.CacheOption = BitmapCacheOption.OnDemand
        mpMap.UriSource = New Uri(theUrl.ToString.Trim("|"))
        returnUri = mpMap.UriSource.ToString
        LogUtil.Info(returnUri, "createLboMap")
        AddHandler mpMap.DownloadCompleted, AddressOf mpMap_DownloadCompleted
        mpMap.EndInit()
        ehImage.Source = mpMap
        Return ehImage
    End Function


    ''' <summary>
    ''' Build a string list of map markers from the selected nodes in the shop tree for a single bookmaker
    ''' </summary>
    ''' <param name="nodeNumber">indicates which bookmaker</param>
    ''' <param name="lboNodes"></param>
    ''' <param name="allMarkers">existing list of markers. new markers are appended.</param>
    ''' <param name="markerColor">Fill colour of the marker (different for each bookmaker)</param>
    ''' <returns>New marker string</returns>
    ''' <remarks></remarks>
    Private Function buildMarkers(ByVal nodeNumber As Integer, ByVal lboNodes As Dictionary(Of Integer, TreeNode), ByVal allMarkers As ArrayList, ByVal markerColor As String, ByVal isShowAll As Boolean) As ArrayList
        Dim shopNodes As TreeNode = lboNodes.Item(nodeNumber)
        If shopNodes.Nodes.Count > 0 Then
            For Each shopNode As TreeNode In shopNodes.Nodes
                If shopNode.Checked Or isShowAll Then
                    Dim fmqLocation1 As GeoPos = setGeolocation(shopNode.Nodes(1).Text, shopNode.Nodes(2).Text)
                    If fmqLocation1 IsNot Nothing Then
                        Dim markerString As String = markerColor & "_1-" & shopNode.Nodes(3).Text & ","
                        Dim markerNo As Integer = allMarkers.Add(markerString)
                        Dim dLat As Decimal = If(fmqLocation1.Latitude Is Nothing, 0, fmqLocation1.Latitude)
                        Dim dLng As Decimal = If(fmqLocation1.Longitude Is Nothing, 0, fmqLocation1.Longitude)
                        allMarkers(markerNo) += Convert.ToString(Math.Round(dLat, 6)) & "," & Convert.ToString(Math.Round(dLng, 6))
                    Else
                        LogUtil.Problem("Unable to locate " & shopNode.Nodes(0).Text, "buildMarkers")
                    End If
                End If
            Next
        End If
        Return allMarkers
    End Function

    ''' <summary>
    ''' If the origin is to be displayed on the map, return the parameters to display a special marker
    ''' </summary>
    ''' <param name="shopNodes"></param>
    ''' <returns>the parameter string to display a special marker</returns>
    ''' <remarks></remarks>
    Private Function buildCentreMarker(ByVal shopNodes As TreeNode, ByVal isShowAll As Boolean)
        Dim markerString As String = ""
        If shopNodes IsNot Nothing Then
            Dim shopNode As TreeNode = shopNodes.Nodes(0)
            If shopNode.Checked Or isShowAll Then
                Dim fmqLocation1 As GeoPos = setGeolocation(shopNode.Nodes(1).Text, shopNode.Nodes(2).Text)
                If fmqLocation1 IsNot Nothing Then
                    Dim dLat As Decimal = If(fmqLocation1.Latitude Is Nothing, 0, fmqLocation1.Latitude)
                    Dim dLng As Decimal = If(fmqLocation1.Longitude Is Nothing, 0, fmqLocation1.Longitude)
                    markerString = "&pcenter=" & Convert.ToString(Math.Round(dLat, 6)) & "," & Convert.ToString(Math.Round(dLng, 6))
                End If
            End If
        End If
        Return markerString
    End Function
End Class
