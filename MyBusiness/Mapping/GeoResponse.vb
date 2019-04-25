'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Public Class GeoResponse
    Private _results As GeoResult()
    Private _status As responseStatus
    Private _bestResult As GeoResult

    Public Enum responseStatus
        UNKNOWN
        OK
        INVALIDREQUEST
        ZERORESULTS
        OVERQUERYTLIMIT
        REQUESTDENIED
    End Enum

    Public Sub New(ByVal pResults As GeoResult(), ByVal pStatus As responseStatus, ByVal pBestResult As GeoResult)
        _results = pResults
        _status = pStatus
        _bestResult = pBestResult
    End Sub

    Public Property status() As Integer
        Get
            Return _status
        End Get
        Set(ByVal value As Integer)
            _status = value
        End Set
    End Property

    Public Property results() As GeoResult()
        Get
            Return _results
        End Get
        Set(ByVal value As GeoResult())
            _results = value
        End Set
    End Property

    Public Property bestResult() As GeoResult
        Get
            Return _bestResult
        End Get
        Set(ByVal value As GeoResult)
            _bestResult = value
        End Set
    End Property

End Class
