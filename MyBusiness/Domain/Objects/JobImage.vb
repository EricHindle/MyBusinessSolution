' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class JobImage
    Private _jobId As Integer
    Private _imageId As Integer
    Private _imagePath As String
    Private _imageDesc As String
    Public Property ImageDesc() As String
        Get
            Return _imageDesc
        End Get
        Set(ByVal value As String)
            _imageDesc = value
        End Set
    End Property
    Public Property ImagePath() As String
        Get
            Return _imagePath
        End Get
        Set(ByVal value As String)
            _imagePath = value
        End Set
    End Property
    Public Property ImageId() As Integer
        Get
            Return _imageId
        End Get
        Set(ByVal value As Integer)
            _imageId = value
        End Set
    End Property
    Public Property JobId() As Integer
        Get
            Return _jobId
        End Get
        Set(ByVal value As Integer)
            _jobId = value
        End Set
    End Property
    Public Sub New(ByVal pImageId As Integer,
                  ByVal pJobId As Integer,
                   ByVal pImagePath As String,
                   ByVal pImageDesc As String)
        _imageId = pImageId
        _jobId = pJobId
        _imagePath = pImagePath
        _imageDesc = pImageDesc
    End Sub

    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
        .Append("imageId=[") _
        .Append(_imageId) _
        .Append("], jobId=[") _
        .Append(_jobId) _
        .Append("], path=[") _
        .Append(_imagePath) _
        .Append("], desc=[") _
        .Append(_imageDesc) _
        .Append("]")
        Return sb.ToString
    End Function
End Class