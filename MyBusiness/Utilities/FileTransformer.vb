' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports MyBusiness.NetwyrksErrorCodes
Public Class FileTransformer
#Region "variables"
    Private Shared fsInput As System.IO.Stream
    Private Shared lngFileLength As Long = 0
#End Region
#Region "functions"
    Public Shared Function TransformFileToBytes(ByVal fromFile As String) As Byte()
        Dim toBytes As Byte() = Nothing
        If Not File.Exists(fromFile) Then Return Nothing
        Try
            fsInput = New System.IO.FileStream(fromFile, FileMode.Open, FileAccess.Read)
            lngFileLength = fsInput.Length
            If EncryptionUtil.IsValidHeaderinStream(fsInput) Then
                fsInput.Seek(0, SeekOrigin.Begin)
                toBytes = New Byte(lngFileLength - 1) {}
                fsInput.Read(toBytes, 0, lngFileLength)
            Else
                LogUtil.Problem("Invalid file header in " & fromFile)
            End If
        Catch ex As Exception
            LogUtil.Exception("Error transforming file", ex, "transformFileToBytes", getErrorCode(SystemModule.IMAGES, ErrorType.CONVERSION, FailedAction.ENCRYPTION_ERROR))
        Finally
            CloseStreams()
        End Try
        Return toBytes
    End Function
    Private Shared Sub CloseStreams()
        If fsInput IsNot Nothing Then
            fsInput.Close()
        End If
    End Sub
#End Region
End Class
