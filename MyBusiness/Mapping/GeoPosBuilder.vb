'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Public Class GeoPosBuilder
    Private _lng As Decimal?
    Private _lat As Decimal?
    Public Shared Function aGeoPos() As GeoPosBuilder
        Return New GeoPosBuilder
    End Function
    Public Function startingWith(ByVal pGeoPos As GeoPos) As GeoPosBuilder
        _lng = pGeoPos.Longitude
        _lat = pGeoPos.Latitude
        Return Me
    End Function
    Public Function withLatitude(ByVal pLat As Decimal?) As GeoPosBuilder
        _lat = pLat
        Return Me
    End Function
    Public Function withLongitude(ByVal pLng As Decimal?) As GeoPosBuilder
        _lng = pLng
        Return Me
    End Function
    Public Function build() As GeoPos
        Return New GeoPos(_lat, _lng)
    End Function

End Class
