'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

''' <summary>
''' Encryption/decryption utility
''' </summary>
''' <remarks></remarks>
Public Class EncryptionUtil
    Public Const ENCRYPTION_KEY As String = "D7xoTK1T987eXa2z"
    Public Const DB_PASSWORD_ENCRYPTION_KEY As String = "4*7v^46f1uE08OMK"
    ''' <summary>
    ''' Encrypt text using internal key
    ''' </summary>
    ''' <param name="sText">Text to be encrypted</param>
    ''' <returns>Encrypted text</returns>
    ''' <remarks></remarks>
    Public Shared Function encryptText(ByVal sText As String) As String
        Return encryptText(sText, ENCRYPTION_KEY)
    End Function

    ''' <summary>
    ''' Encrypt text using supplied key
    ''' </summary>
    ''' <param name="sText">Text to be encrypted</param>
    ''' <returns>Encrypted text</returns>
    ''' <remarks>
    ''' Uses Triple Data Encryption Algorithm (3DES)
    ''' </remarks>
    Public Shared Function encryptText(ByVal sText As String, ByVal key As String) As String
        ' Encrypt text
        Dim toEncryptArray As Byte() = UTF8Encoding.UTF8.GetBytes(sText)
        Dim keyArray As Byte() = UTF8Encoding.UTF8.GetBytes(key)
        Dim tdes As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
        tdes.Key = keyArray
        tdes.Mode = CipherMode.ECB
        tdes.Padding = PaddingMode.PKCS7
        Dim cTransform As ICryptoTransform = tdes.CreateEncryptor()
        ' Transform the specified region of bytes array to resultArray
        Dim resultArray As Byte() = _
          cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
        'Release resources held by TripleDes Encryptor
        tdes.Clear()
        'Return the encrypted data into unreadable string format
        Return Convert.ToBase64String(resultArray, 0, resultArray.Length)
    End Function

    ''' <summary>
    ''' Decrypt text using internal key
    ''' </summary>
    ''' <param name="sText">Text to be decrypted</param>
    ''' <returns>Plain text</returns>
    ''' <remarks></remarks>
    Public Shared Function decryptText(ByVal sText As String) As String
        Return decryptText(sText, ENCRYPTION_KEY)
    End Function

    ''' <summary>
    ''' Decrypt text using supplied key
    ''' </summary>
    ''' <param name="sText">Text to be decrypted</param>
    ''' <returns>Plain text</returns>
    ''' <remarks></remarks>
    Public Shared Function decryptText(ByVal sText As String, ByVal key As String) As String
        ' Decrypt text
        ' Get the byte code of the string
        Dim rtnVal As String = ""
        Try
            If Not String.IsNullOrEmpty(sText) Then
                Dim toEncryptArray As Byte() = Convert.FromBase64String(sText)
                Dim keyArray As Byte() = UTF8Encoding.UTF8.GetBytes(key)
                Dim tdes As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
                'set the secret key for the tripleDES algorithm
                tdes.Key = keyArray
                'mode of operation is ECB(Electronic code Book)
                tdes.Mode = CipherMode.ECB
                'padding mode(if any extra byte added)
                tdes.Padding = PaddingMode.PKCS7

                Dim cTransform As ICryptoTransform = tdes.CreateDecryptor()
                Dim resultArray As Byte() = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
                'Release resources held by TripleDes Encryptor                
                tdes.Clear()
                'return the Clear decrypted TEXT
                rtnVal = UTF8Encoding.UTF8.GetString(resultArray)
            End If
        Catch ex As Exception
        End Try
        Return rtnVal
    End Function

    Public Shared Function ConvertStringToBytes(ByVal sString As String) As Byte()
        Return New UnicodeEncoding().GetBytes(sString)
    End Function

    Public Shared Function ConvertBytesToString(ByVal bytes() As Byte) As String
        Return New UnicodeEncoding().GetString(bytes)
    End Function

End Class
