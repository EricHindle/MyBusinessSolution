'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.Text
Imports System.Web

Public Class GoogleStaticMap

    Public baseUriString As String = GlobalSettings.getSetting("GoogleStaticMapURL")


    Private _centre As String
    Public Property centre() As String
        Get
            Return _centre
        End Get
        Set(ByVal value As String)
            _centre = value
        End Set
    End Property

    Private _zoom As String
    Public Property zoom() As String
        Get
            Return _zoom
        End Get
        Set(ByVal value As String)
            _zoom = value
        End Set
    End Property

    Private _size As String
    Public Property size() As String
        Get
            Return _size
        End Get
        Set(ByVal value As String)
            _size = value
        End Set
    End Property

    Private _format As String
    Public Property format() As String
        Get
            Return _format
        End Get
        Set(ByVal value As String)
            _format = value
        End Set
    End Property

    Private _mapType As String
    Public Property mapType() As String
        Get
            Return _mapType
        End Get
        Set(ByVal value As String)
            _mapType = value
        End Set
    End Property


    Private _mobile As String
    Public Property mobile() As String
        Get
            Return _mobile
        End Get
        Set(ByVal value As String)
            _mobile = value
        End Set
    End Property


    Private _language As String
    Public Property language() As String
        Get
            Return _language
        End Get
        Set(ByVal value As String)
            _language = value
        End Set
    End Property


    Private _markers As ArrayList
    Public Property markers() As ArrayList
        Get
            Return _markers
        End Get
        Set(ByVal value As ArrayList)
            _markers = value
        End Set
    End Property


    Private _path As String
    Public Property path() As String
        Get
            Return _path
        End Get
        Set(ByVal value As String)
            _path = value
        End Set
    End Property


    Private _visible As String
    Public Property visible() As String
        Get
            Return _visible
        End Get
        Set(ByVal value As String)
            _visible = value
        End Set
    End Property


    Private _sensor As String
    Public Property sensor() As String
        Get
            Return _sensor
        End Get
        Set(ByVal value As String)
            _sensor = value
        End Set
    End Property


    Public Function ToUri() As Uri

        Dim url As New StringBuilder(baseUriString)
        url.Append("size=").Append(size)
        url.Append("&").Append("maptype=").Append(mapType)
        For Each marker As String In _markers
            url = url.Append("&").Append("markers=").Append(marker)
        Next

        Return New Uri(url.ToString)
    End Function
End Class
