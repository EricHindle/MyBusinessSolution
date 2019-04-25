'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.IO
Imports MyBusiness.netwyrksErrorCodes
Public Class FileTransformer
    Private Shared fsInput As System.IO.Stream
    Private Shared lngFileLength As Long = 0

    Public Shared Function transformFileToBytes(ByVal fromFile As String) As Byte()
        Dim toBytes As Byte() = Nothing
        If Not File.Exists(fromFile) Then Return Nothing
        Try
            fsInput = New System.IO.FileStream(fromFile, FileMode.Open, FileAccess.Read)
            lngFileLength = fsInput.Length
            If EncryptionUtil.isValidHeaderinStream(fsInput) Then
                fsInput.Seek(0, SeekOrigin.Begin)
                toBytes = New Byte(lngFileLength - 1) {}
                fsInput.Read(toBytes, 0, lngFileLength)
            Else
                LogUtil.Problem("Invalid file header in " & fromFile)
            End If
        Catch ex As Exception
            LogUtil.Exception("Error transforming file", ex, "transformFileToBytes", getErrorCode(SystemModule.IMAGES, ErrorType.CONVERSION, FailedAction.ENCRYPTION_ERROR))
        Finally
            closeStreams()
        End Try
        Return toBytes
    End Function

    Private Shared Sub closeStreams()
        If fsInput IsNot Nothing Then
            fsInput.Close()
        End If
    End Sub
End Class
