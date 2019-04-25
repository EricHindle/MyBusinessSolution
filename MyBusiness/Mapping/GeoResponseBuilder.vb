'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Public Class GeoResponseBuilder
    Private _results As GeoResult()
    Private _status As Integer
    Private _bestResult As GeoResult

    Public Shared Function aGeoResponse() As GeoResponseBuilder
        Return New GeoResponseBuilder
    End Function

    Public Function startingWith(ByVal pGeoResponse As GeoResponse) As GeoResponseBuilder
        _results = pGeoResponse.results
        _status = pGeoResponse.status
        _bestResult = pGeoResponse.bestResult
        Return Me
    End Function
    Public Function withNoResults() As GeoResponseBuilder
        _results = New GeoResult() {}
        Return Me
    End Function
    Public Function withResults(ByVal pResults As GeoResult()) As GeoResponseBuilder
        _results = pResults
        Return Me
    End Function

    Public Function withStatus(ByVal pStatus As Integer) As GeoResponseBuilder
        _status = pStatus
        Return Me
    End Function
    Public Function withBestResult(ByVal pResult As GeoResult) As GeoResponseBuilder
        _bestResult = pResult
        Return Me
    End Function
    Public Function build() As GeoResponse
        Return New GeoResponse(_results, _status, _bestResult)
    End Function

    Public Function addResult(ByVal pResult As GeoResult) As GeoResponseBuilder
        Dim act As Integer = 0
        If _results Is Nothing Then
            _results = New GeoResult() {GeoResultBuilder.aGeoResult.build}
        Else
            act = _results.Count
            ReDim Preserve _results(act)
        End If
        _results(act) = pResult
        Return Me
    End Function
End Class
