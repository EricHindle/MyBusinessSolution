' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class JobImageBuilder
    Private _jobId As Integer
    Private _imageId As Integer
    Private _imagePath As String
    Private _imageDesc As String
    Public Shared Function aJobImage() As JobImageBuilder
        Return New JobImageBuilder
    End Function

    Private Sub Initialise()
        _jobId = -1
        _imageDesc = ""
        _imageId = -1
        _imageDesc = ""
    End Sub
    Public Function StartingWith(pJobImage As JobImage) As JobImageBuilder
        With pJobImage
            _imageId = .ImageId
            _jobId = .JobId
            _imagePath = .ImagePath
            _imageDesc = .ImageDesc
        End With
        Return Me
    End Function

    Public Function StartingWithNothing() As JobImageBuilder
        Initialise
        Return Me
    End Function

    Public Function StartingWith(pRow As MyBusinessDataSet.job_imageRow) As JobImageBuilder
        With pRow
            _imageId = .imageid
            _jobId = .jobid
            _imagePath = .imagepath
            _imageDesc = .imagedesc
        End With
        Return Me
    End Function
    Public Function WithJobId(pJobId As Integer) As JobImageBuilder
        _jobId = pJobId
        Return Me
    End Function
    Public Function WithImageId(pImageId As Integer) As JobImageBuilder
        _imageId = pImageId
        Return Me
    End Function
    Public Function WithImagePath(pImagepath As String) As JobImageBuilder
        _imagePath = pImagepath
        Return Me
    End Function
    Public Function WithImageDesc(pImageDesc As String) As JobImageBuilder
        _imageDesc = pImageDesc
        Return Me
    End Function
    Public Function Build() As JobImage
        Return New JobImage(_imageId, _jobId, _imagePath, _imageDesc)
    End Function
End Class
