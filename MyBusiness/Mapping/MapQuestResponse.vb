'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

''' <summary>
''' Set of classes to allow an XML deserializer to convert GeoInfo XML from MapQuest
''' </summary>
''' <remarks></remarks>
Public Class MapQuestResponse
    Public Class response
        Private _info As mqInfo
        Private _results As result()
        Private _options As mqOptions
        Public Property options() As mqOptions
            Get
                Return _options
            End Get
            Set(ByVal value As mqOptions)
                _options = value
            End Set
        End Property
        Public Property results As result()
            Get
                Return _results
            End Get
            Set(ByVal value As result())
                _results = value
            End Set
        End Property
        Public Property info() As mqInfo
            Get
                Return _info
            End Get
            Set(ByVal value As mqInfo)
                _info = value
            End Set
        End Property
    End Class
    Public Class mqInfo
        Private _statusCode As String
        Private _messages As String()
        Private _copyright As mqCopyright
        Public Property copyright() As mqCopyright
            Get
                Return _copyright
            End Get
            Set(ByVal value As mqCopyright)
                _copyright = value
            End Set
        End Property
        Public Property messages() As String()
            Get
                Return _messages
            End Get
            Set(ByVal value As String())
                _messages = value
            End Set
        End Property
        Public Property statusCode() As String
            Get
                Return _statusCode
            End Get
            Set(ByVal value As String)
                _statusCode = value
            End Set
        End Property
    End Class
    ''' <summary>
    ''' The results of the request as a list of locations
    ''' </summary>
    ''' <remarks>
    ''' see http://www.mapquestapi.com/geocoding/#response
    ''' </remarks>
    Public Class result
        Private _providedLocation As mqSingleLineLocation
        Private _locations As location()
        Public Property locations() As location()
            Get
                Return _locations
            End Get
            Set(ByVal value As location())
                _locations = value
            End Set
        End Property
        Public Property providedLocation() As mqSingleLineLocation
            Get
                Return _providedLocation
            End Get
            Set(ByVal value As mqSingleLineLocation)
                _providedLocation = value
            End Set
        End Property
    End Class
    ''' <summary>
    ''' The location in detail
    ''' </summary>
    ''' <remarks></remarks>
    Public Class location
        Private _street As String
        Private _adminArea6 As String
        Private _adminArea5 As String
        Private _adminArea4 As String
        Private _adminArea3 As String
        Private _adminArea2 As String
        Private _adminArea1 As String
        Private _postalCode As String
        Private _geocodeQuality As String
        Private _latLng As mqLatLng
        Private _geocodeQualityCode As String
        Private _dragPoint As Boolean
        Private _sideOfStreet As String
        Private _displayLatLng As mqLatLng
        Private _linkId As String
        Private _unknownInput As String
        Private _type As String
        Private _mapUrl As String
        Public Property mapUrl() As String
            Get
                Return _mapUrl
            End Get
            Set(ByVal value As String)
                _mapUrl = value
            End Set
        End Property
        Public Property type() As String
            Get
                Return _type
            End Get
            Set(ByVal value As String)
                _type = value
            End Set
        End Property
        Public Property unknownInput() As String
            Get
                Return _unknownInput
            End Get
            Set(ByVal value As String)
                _unknownInput = value
            End Set
        End Property
        Public Property linkId() As String
            Get
                Return _linkId
            End Get
            Set(ByVal value As String)
                _linkId = value
            End Set
        End Property
        Public Property displayLatLng() As mqLatLng
            Get
                Return _displayLatLng
            End Get
            Set(ByVal value As mqLatLng)
                _displayLatLng = value
            End Set
        End Property
        Public Property sideOfStreet() As String
            Get
                Return _sideOfStreet
            End Get
            Set(ByVal value As String)
                _sideOfStreet = value
            End Set
        End Property
        Public Property dragPoint() As Boolean
            Get
                Return _dragPoint
            End Get
            Set(ByVal value As Boolean)
                _dragPoint = value
            End Set
        End Property
        Public Property geocodeQualityCode() As String
            Get
                Return _geocodeQualityCode
            End Get
            Set(ByVal value As String)
                _geocodeQualityCode = value
            End Set
        End Property
        Public Property latLng() As mqLatLng
            Get
                Return _latLng
            End Get
            Set(ByVal value As mqLatLng)
                _latLng = value
            End Set
        End Property
        Public Property geocodeQuality() As String
            Get
                Return _geocodeQuality
            End Get
            Set(ByVal value As String)
                _geocodeQuality = value
            End Set
        End Property
        Public Property postalCode() As String
            Get
                Return _postalCode
            End Get
            Set(ByVal value As String)
                _postalCode = value
            End Set
        End Property
        Public Property adminArea1() As String
            Get
                Return _adminArea1
            End Get
            Set(ByVal value As String)
                _adminArea1 = value
            End Set
        End Property
        Public Property adminArea2() As String
            Get
                Return _adminArea2
            End Get
            Set(ByVal value As String)
                _adminArea2 = value
            End Set
        End Property
        Public Property adminArea3() As String
            Get
                Return _adminArea3
            End Get
            Set(ByVal value As String)
                _adminArea3 = value
            End Set
        End Property
        Public Property adminArea4() As String
            Get
                Return _adminArea4
            End Get
            Set(ByVal value As String)
                _adminArea4 = value
            End Set
        End Property
        Public Property adminArea5() As String
            Get
                Return _adminArea5
            End Get
            Set(ByVal value As String)
                _adminArea5 = value
            End Set
        End Property
        Public Property adminArea6() As String
            Get
                Return _adminArea6
            End Get
            Set(ByVal value As String)
                _adminArea6 = value
            End Set
        End Property
        Public Property street() As String
            Get
                Return _street
            End Get
            Set(ByVal value As String)
                _street = value
            End Set
        End Property
    End Class
    ''' <summary>
    ''' The location as a single string
    ''' </summary>
    ''' <remarks></remarks>
    Public Class mqSingleLineLocation
        Private _location As String
        Public Property location() As String
            Get
                Return _location
            End Get
            Set(ByVal value As String)
                _location = value
            End Set
        End Property
    End Class
    ''' <summary>
    ''' Latitiude and Longitude
    ''' </summary>
    ''' <remarks></remarks>
    Public Class mqLatLng
        Private _lat As Double
        Private _lng As Double
        Public Property lng() As Double
            Get
                Return _lng
            End Get
            Set(ByVal value As Double)
                _lng = value
            End Set
        End Property
        Public Property lat() As Double
            Get
                Return _lat
            End Get
            Set(ByVal value As Double)
                _lat = value
            End Set
        End Property
    End Class
    ''' <summary>
    ''' MapQuest request options
    ''' </summary>
    ''' <remarks></remarks>
    Public Class mqOptions
        Private _maxResults As Integer
        Private _thumbMaps As Boolean
        Private _ignoreLatLngInput As Boolean
        Private _boundingBox As String
        Public Property boundingBox() As String
            Get
                Return _boundingBox
            End Get
            Set(ByVal value As String)
                _boundingBox = value
            End Set
        End Property
        Public Property ignoreLatLngInput() As Boolean
            Get
                Return _ignoreLatLngInput
            End Get
            Set(ByVal value As Boolean)
                _ignoreLatLngInput = value
            End Set
        End Property
        Public Property thumbMaps() As Boolean
            Get
                Return _thumbMaps
            End Get
            Set(ByVal value As Boolean)
                _thumbMaps = value
            End Set
        End Property
        Public Property maxResults() As Integer
            Get
                Return _maxResults
            End Get
            Set(ByVal value As Integer)
                _maxResults = value
            End Set
        End Property
    End Class
    ''' <summary>
    ''' MapQuest Copyright 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class mqCopyright
        Private _imageUrl As String
        Private _imageAltText As String
        Private _text As String
        Public Property text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property
        Public Property imageAltText() As String
            Get
                Return _imageAltText
            End Get
            Set(ByVal value As String)
                _imageAltText = value
            End Set
        End Property
        Public Property imageUrl() As String
            Get
                Return _imageUrl
            End Get
            Set(ByVal value As String)
                _imageUrl = value
            End Set
        End Property
    End Class
End Class