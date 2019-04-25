'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.Windows.Media.Imaging

Public Class GoogleMapUtil
    Inherits MappingUtil

    Protected mColour() As String = New String() {"orange", "blue", "red", "yellow", "purple", "green", "gray"}
    Public Overrides Function getMapTypes() As String()
        Return New String() {"roadmap", "terrain", "satellite", "hybrid"}
    End Function
    Public Overrides Function getMarker(charNo As Integer) As String
        charNo = Asc("A") - 1 + charNo
        If charNo > Asc("W") Then
            charNo = Asc("X")
        End If
        Return Chr(charNo)
    End Function
    Public Overrides Function createLboMap(ByVal smaptype As String, ByRef lboNodes As Dictionary(Of Integer, TreeNode), ByRef returnUri As String, Optional ByVal pWidth As Integer = 400, Optional ByVal pHeight As Integer = 400, Optional ByVal isShowAll As Boolean = False) As System.Windows.Controls.Image
        Dim allMarkers As New ArrayList
        '       ehImage = New System.Windows.Controls.Image()
        For company As Integer = 0 To 5
            If lboNodes.Count > company Then
                Dim shopNodes As TreeNode = lboNodes.Item(company)
                If shopNodes.Nodes.Count > 0 Then
                    For Each shopNode As TreeNode In shopNodes.Nodes
                        If shopNode.Checked Or isShowAll Then
                            Dim fmqLocation1 As GeoPos = setGeolocation(shopNode.Nodes(1).Text, shopNode.Nodes(2).Text)
                            If fmqLocation1 IsNot Nothing Then
                                Dim markerNo As Integer = allMarkers.Add("color:" & mColour(company) & "|" + "label:" & shopNode.Nodes(3).Text)
                                Dim dLat As Decimal = If(fmqLocation1.Latitude Is Nothing, 0, fmqLocation1.Latitude)
                                Dim dLng As Decimal = If(fmqLocation1.Longitude Is Nothing, 0, fmqLocation1.Longitude)
                                allMarkers(markerNo) += "|" & Convert.ToString(Math.Round(dLat, 6)) & "," & Convert.ToString(Math.Round(dLng, 6))
                            Else
                                LogUtil.Problem("Unable to locate " & shopNode.Nodes(0).Text)
                            End If
                        End If
                    Next
                End If
            End If
        Next

        Dim fmqMap = New GoogleStaticMap()
        fmqMap.size = "640x640"
        fmqMap.markers = allMarkers
        fmqMap.mapType = smaptype ' can be roadmap, satellite, terrain, hybrid
        fmqMap.sensor = "false"
        Dim mpMap As New BitmapImage()
        mpMap.BeginInit()
        mpMap.CacheOption = BitmapCacheOption.OnDemand
        mpMap.UriSource = fmqMap.ToUri()
        returnUri = mpMap.UriSource.ToString
        '     LogUtil.Info(returnUri)
        AddHandler mpMap.DownloadCompleted, AddressOf mpMap_DownloadCompleted
        mpMap.EndInit()
        ehImage.Source = mpMap

        Return ehImage
    End Function
End Class
