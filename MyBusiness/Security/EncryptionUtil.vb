' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports MyBusiness.NetwyrksErrorCodes

''' <summary>
''' Useful encryption/decryption functions
''' </summary>
''' <remarks></remarks>
Public Class EncryptionUtil
#Region "constants"
    Public Const ENCRYPTION_KEY As String = "D7xoTK1T987eXa2z"
    Private Const BUFFER_SIZE As Integer = 4096
    Private Const KEY_SIZE_BYTES As Integer = 32
    Private Const IV_SIZE_BYTES As Integer = 16
    Private Const HEADER_SIZE_BYTES As Integer = 7
    Private Const BLOCK_SIZE As Integer = 128
#End Region
#Region "variables"
    Private Shared fsInput As System.IO.Stream
    Private Shared fsOutput As System.IO.FileStream
    Private Shared msOutput As System.IO.MemoryStream
    Private Shared msInput As System.IO.MemoryStream
    Private Shared bKey() As Byte
    Private Shared bIV() As Byte
    Private Shared ReadOnly headerString As String = "ANUBIS "
    Private Shared headerBytes(HEADER_SIZE_BYTES) As Byte
    Private Shared ReadOnly bytBuffer(BUFFER_SIZE) As Byte
    Private Shared lngBytesProcessed As Long = 0
    Private Shared lngFileLength As Long = 0
    Private Shared intBytesInCurrentBlock As Integer
    Private Shared ReadOnly cspRijndael As New System.Security.Cryptography.RijndaelManaged
    Private Shared csCryptoStream As CryptoStream = Nothing
    Private Shared _password As String
    Private Shared _passwordBytes As Byte()
#End Region
#Region "functions"
    ''' <summary>
    ''' Encrypt text with the built-in key
    ''' </summary>
    ''' <param name="sText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function EncryptText(ByVal sText As String) As String
        Return EncryptText(sText, ENCRYPTION_KEY)
    End Function
    ''' <summary>
    ''' Encrypt text with a given key
    ''' </summary>
    ''' <param name="sText"></param>
    ''' <param name="key"></param>
    ''' <returns></returns>
    ''' <remarks> Electronic Code Book mode
    ''' Triple Data Encryption Algorithm
    ''' </remarks>
    Public Shared Function EncryptText(ByVal sText As String, ByVal key As String) As String
        ' Encrypt text
        Dim rtnVal As String = ""
        Try
            If Not String.IsNullOrEmpty(sText) Then
                Dim toEncryptArray As Byte() = UTF8Encoding.UTF8.GetBytes(If(sText Is Nothing, "", sText))
                Dim keyArray As Byte() = UTF8Encoding.UTF8.GetBytes(key)
                Dim tdes As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
                tdes.Key = keyArray
                tdes.Mode = CipherMode.ECB
                tdes.Padding = PaddingMode.PKCS7
                Dim cTransform As ICryptoTransform = tdes.CreateEncryptor()
                'transform the specified region of bytes array to resultArray
                Dim resultArray As Byte() =
                  cTransform.TransformFinalBlock(toEncryptArray, 0,
                  toEncryptArray.Length)
                'Release resources held by TripleDes Encryptor
                tdes.Clear()
                'Return the Encrypted data into unreadable string format
                rtnVal = Convert.ToBase64String(resultArray, 0, resultArray.Length)
            End If
        Catch ex As Exception
        End Try
        Return rtnVal
    End Function
    ''' <summary>
    ''' Decrypt text with built-in key
    ''' </summary>
    ''' <param name="sText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DecryptText(ByVal sText As String) As String
        Return DecryptText(sText, ENCRYPTION_KEY)
    End Function
    ''' <summary>
    ''' Decrypt text with given key
    ''' </summary>
    ''' <param name="sText"></param>
    ''' <param name="key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DecryptText(ByVal sText As String, ByVal key As String) As String
        ' Decrypt text
        'get the byte code of the string
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
                Dim resultArray As Byte() = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length)
                'Release resources held by TripleDes Encryptor                
                tdes.Clear()
                'return the Clear decrypted TEXT
                rtnVal = UTF8Encoding.UTF8.GetString(resultArray)
            End If
        Catch ex As Exception
        End Try
        Return rtnVal
    End Function
    ''' <summary>
    ''' Encrypt a byte array and write the results to a file
    ''' </summary>
    ''' <param name="fromBytes"></param>
    ''' <param name="toFile"></param>
    ''' <returns>True if encrypted file is created OK</returns>
    ''' <remarks>A header is added to the bytes to be encrypted</remarks>
    Public Shared Function EncryptBytesToFile(ByRef fromBytes As Byte(), ByVal toFile As String) As Boolean
        Dim isTransformOK As Boolean = True
        If Not isInitialised() Then Return False
        If fromBytes Is Nothing Then Return False
        msInput = New MemoryStream(fromBytes)
        lngBytesProcessed = 0
        Try
            fsOutput = New System.IO.FileStream(toFile, FileMode.OpenOrCreate, FileAccess.Write)
            fsOutput.SetLength(0)
            lngFileLength = msInput.Length
            csCryptoStream = New CryptoStream(fsOutput, cspRijndael.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write)
            csCryptoStream.Write(headerBytes, 0, headerBytes.Length)
            While lngBytesProcessed < lngFileLength
                intBytesInCurrentBlock = msInput.Read(bytBuffer, 0, BUFFER_SIZE)
                csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                lngBytesProcessed += CLng(intBytesInCurrentBlock)
            End While
        Catch ex As Exception
            LogUtil.Exception("Error transforming bytes", ex, "EncryptBytesToFile", getErrorCode(SystemModule.SECURITY, ErrorType.ENCRYPTION, FailedAction.ENCRYPTION_ERROR))
            isTransformOK = False
        Finally
            If csCryptoStream IsNot Nothing Then
                csCryptoStream.Close()
            End If
            closeStreams()
        End Try
        If Not isTransformOK Then
            File.Delete(toFile)
        End If
        Return isTransformOK
    End Function
    ''' <summary>
    ''' Encrypt the contents of an unEncrypted file and create a new encrypted file
    ''' </summary>
    ''' <param name="fromFile"></param>
    ''' <param name="toFile"></param>
    ''' <returns>True if encrypted file is created OK</returns>
    ''' <remarks>A header is added to the bytes to be encrypted</remarks>
    Public Shared Function EncryptFileToFile(ByVal fromFile As String, ByVal toFile As String) As Boolean
        Dim isTransformOK As Boolean = True
        If Not isInitialised() Then Return False
        If Not File.Exists(fromFile) Then Return False
        Try
            fsInput = New System.IO.FileStream(fromFile, FileMode.Open, FileAccess.Read)
            fsOutput = New System.IO.FileStream(toFile, FileMode.OpenOrCreate, FileAccess.Write)
            fsOutput.SetLength(0)
            lngFileLength = fsInput.Length
            csCryptoStream = New CryptoStream(fsOutput, cspRijndael.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write)
            csCryptoStream.Write(headerBytes, 0, headerBytes.Length)
            While lngBytesProcessed < lngFileLength
                intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, BUFFER_SIZE)
                csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                lngBytesProcessed += CLng(intBytesInCurrentBlock)
            End While
        Catch ex As Exception
            LogUtil.Exception("Error transforming file", ex, "EncryptFileToFile", getErrorCode(SystemModule.SECURITY, ErrorType.ENCRYPTION, FailedAction.ENCRYPTION_ERROR))
            isTransformOK = False
        Finally
            If csCryptoStream IsNot Nothing Then
                csCryptoStream.Close()
            End If
            closeStreams()
        End Try
        If Not isTransformOK Then
            File.Delete(toFile)
        End If
        Return isTransformOK
    End Function
    ''' <summary>
    ''' Encrypt a the contents of a file to a byte array
    ''' </summary>
    ''' <param name="fromFile"></param>
    ''' <returns>An encrypted byte array</returns>
    ''' <remarks>A header is added to the bytes to be encrypted
    ''' Used for storing an attachment</remarks>
    Public Shared Function EncryptFileToBytes(ByVal fromFile As String) As Byte()
        Dim toBytes As Byte() = Nothing
        If Not isInitialised() Then Return Nothing
        If Not File.Exists(fromFile) Then Return Nothing
        Try
            fsInput = New System.IO.FileStream(fromFile, FileMode.Open, FileAccess.Read)
            msOutput = New System.IO.MemoryStream()
            lngFileLength = fsInput.Length
            csCryptoStream = New CryptoStream(msOutput, cspRijndael.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write)
            csCryptoStream.Write(headerBytes, 0, headerBytes.Length)
            lngBytesProcessed = 0
            While lngBytesProcessed < lngFileLength
                intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, BUFFER_SIZE)
                csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                lngBytesProcessed += CLng(intBytesInCurrentBlock)
            End While
            csCryptoStream.Close()
            toBytes = msOutput.ToArray()
        Catch ex As Exception
            LogUtil.Exception("Error transforming file", ex, "EncryptFileToBytes", getErrorCode(SystemModule.SECURITY, ErrorType.ENCRYPTION, FailedAction.ENCRYPTION_ERROR))
        Finally
            closeStreams()
        End Try
        Return toBytes
    End Function
    ''' <summary>
    ''' Decrypts an enecypted byte array and writes the resulting bytes to a file
    ''' </summary>
    ''' <param name="fromBytes"></param>
    ''' <param name="toFile"></param>
    ''' <returns>True if decrypted file is produced oK</returns>
    ''' <remarks>Byte array must contain the valid header string
    ''' Used for retrieving a stored attachment</remarks>
    Public Shared Function DecryptBytesToFile(ByVal fromBytes As Byte(), ByVal toFile As String) As Boolean
        Dim isTransformOK As Boolean = True
        If Not isInitialised() Then Return Nothing
        Try
            msInput = New MemoryStream(fromBytes)
            fsOutput = New System.IO.FileStream(toFile, FileMode.OpenOrCreate, FileAccess.Write)
            fsOutput.SetLength(0)
            lngFileLength = msInput.Length
            csCryptoStream = New CryptoStream(msInput, cspRijndael.CreateDecryptor(bKey, bIV), CryptoStreamMode.Read)
            If isValidHeader() Then
                Do
                    intBytesInCurrentBlock = csCryptoStream.Read(bytBuffer, 0, BUFFER_SIZE)
                    If intBytesInCurrentBlock = 0 Then Exit Do
                    fsOutput.Write(bytBuffer, 0, intBytesInCurrentBlock)
                    lngBytesProcessed += CLng(intBytesInCurrentBlock)
                Loop
            Else
                LogUtil.Problem("Invalid file header")
                isTransformOK = False
            End If
        Catch ex As Exception
            LogUtil.Exception("Error transforming bytes", ex, "DecryptBytesToFile", getErrorCode(SystemModule.SECURITY, ErrorType.ENCRYPTION, FailedAction.DECRYPTION_ERROR))
            isTransformOK = False
        Finally
            closeStreams()
        End Try
        Return isTransformOK
    End Function
    ''' <summary>
    ''' Decrypts an encrypted file
    ''' </summary>
    ''' <param name="fromFile"></param>
    ''' <param name="toFile"></param>
    ''' <returns>True if file is decrypted OK</returns>
    ''' <remarks>File must contain the valid header string</remarks>
    Public Shared Function DecryptFileToFile(ByVal fromFile As String, ByVal toFile As String) As Boolean
        Dim isTransformOK As Boolean = True
        If Not isInitialised() Then Return False
        If Not File.Exists(fromFile) Then Return False
        Dim ms As New MemoryStream
        Try
            fsInput = New System.IO.FileStream(fromFile, FileMode.Open, FileAccess.Read)
            fsOutput = New System.IO.FileStream(toFile, FileMode.OpenOrCreate, FileAccess.Write)
            fsOutput.SetLength(0)
            lngFileLength = fsInput.Length
            csCryptoStream = New CryptoStream(fsInput, cspRijndael.CreateDecryptor(bKey, bIV), CryptoStreamMode.Read)

            If isValidHeader() Then
                Do
                    intBytesInCurrentBlock = csCryptoStream.Read(bytBuffer, 0, BUFFER_SIZE)
                    If intBytesInCurrentBlock = 0 Then Exit Do
                    fsOutput.Write(bytBuffer, 0, intBytesInCurrentBlock)
                    lngBytesProcessed += CLng(intBytesInCurrentBlock)
                Loop
            Else
                LogUtil.Problem("Invalid file header in " & fromFile)
            End If
        Catch ex As Exception
            LogUtil.Exception("Error transforming file", ex, "DecryptFileToFile", getErrorCode(SystemModule.SECURITY, ErrorType.ENCRYPTION, FailedAction.DECRYPTION_ERROR))
            isTransformOK = False
        Finally
            If csCryptoStream IsNot Nothing Then
                csCryptoStream.Close()
            End If
            closeStreams()
        End Try
        If Not isTransformOK Then
            File.Delete(toFile)
        End If
        Return isTransformOK
    End Function
    Public Shared Function DecryptFileToBytes(ByVal fromFile As String) As MemoryStream
        '   Dim toBytes As Byte() = Nothing
        If Not isInitialised() Then Return Nothing
        If Not File.Exists(fromFile) Then Return Nothing
        Try
            fsInput = New System.IO.FileStream(fromFile, FileMode.Open, FileAccess.Read)
            msOutput = New System.IO.MemoryStream()
            lngFileLength = fsInput.Length
            csCryptoStream = New CryptoStream(fsInput, cspRijndael.CreateDecryptor(bKey, bIV), CryptoStreamMode.Read)
            If isValidHeader() Then
                Do
                    intBytesInCurrentBlock = csCryptoStream.Read(bytBuffer, 0, BUFFER_SIZE)
                    If intBytesInCurrentBlock = 0 Then Exit Do
                    msOutput.Write(bytBuffer, 0, intBytesInCurrentBlock)
                    lngBytesProcessed += CLng(intBytesInCurrentBlock)
                Loop
                '    toBytes = msOutput.ToArray
            Else
                LogUtil.Problem("Invalid file header in " & fromFile)
            End If
        Catch ex As Exception
            LogUtil.Exception("Error transforming file", ex, "DecryptFileToBytes", getErrorCode(SystemModule.SECURITY, ErrorType.ENCRYPTION, FailedAction.DECRYPTION_ERROR))
        Finally
            If csCryptoStream IsNot Nothing Then
                csCryptoStream.Close()
            End If
            closeStreams()
        End Try
        Return msOutput
    End Function
    Public Shared Function DecryptBytesToBytes(ByVal fromBytes As Byte()) As MemoryStream
        '  Dim toBytes As Byte() = Nothing
        If Not isInitialised() Then Return Nothing
        Try
            msInput = New MemoryStream(fromBytes)
            msOutput = New System.IO.MemoryStream()
            lngFileLength = msInput.Length
            csCryptoStream = New CryptoStream(msInput, cspRijndael.CreateDecryptor(bKey, bIV), CryptoStreamMode.Read)
            If isValidHeader() Then
                Do
                    intBytesInCurrentBlock = csCryptoStream.Read(bytBuffer, 0, BUFFER_SIZE)
                    If intBytesInCurrentBlock = 0 Then Exit Do
                    msOutput.Write(bytBuffer, 0, intBytesInCurrentBlock)
                    lngBytesProcessed += CLng(intBytesInCurrentBlock)
                Loop
                '     toBytes = msOutput.ToArray
            Else
                LogUtil.Problem("Invalid file header")

            End If
        Catch ex As Exception
            LogUtil.Exception("Error transforming file", ex, "DecryptBytesToBytes", getErrorCode(SystemModule.SECURITY, ErrorType.ENCRYPTION, FailedAction.DECRYPTION_ERROR))
        Finally
            If csCryptoStream IsNot Nothing Then
                csCryptoStream.Close()
            End If
            closeStreams()
        End Try
        Return msOutput
    End Function
    Private Shared Function isInitialised() As Boolean
        isInitialised = False
        _password = AuthenticationUtil.TRANSFORM_INITIALISER
        _passwordBytes = ConvertStringToBytes(_password)
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        Dim _hashedPassword As Byte() = SHA512.ComputeHash(_passwordBytes)
        Dim pdb As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(_password, _hashedPassword)
        'extract the key and IV
        bKey = pdb.GetBytes(KEY_SIZE_BYTES)
        bIV = pdb.GetBytes(IV_SIZE_BYTES)
        headerBytes = ConvertStringToBytes(headerString)
        With cspRijndael
            .Key = bKey
            .IV = bIV
            .BlockSize = BLOCK_SIZE
            .Padding = PaddingMode.PKCS7
        End With
        isInitialised = True
    End Function
    Public Shared Function ConvertStringToBytes(ByVal sString As String) As Byte()
        Return New UnicodeEncoding().GetBytes(sString)
    End Function
    Public Shared Function ConvertBytesToString(ByVal bytes() As Byte) As String
        Return New UnicodeEncoding().GetString(bytes)
    End Function
    Private Shared Sub closeStreams()
        If fsOutput IsNot Nothing Then
            fsOutput.Close()
        End If
        If fsInput IsNot Nothing Then
            fsInput.Close()
        End If
        If csCryptoStream IsNot Nothing Then
            csCryptoStream.Clear()
            csCryptoStream = Nothing
        End If
    End Sub
    ''' <summary>
    ''' Checks that first bytes match the header string
    ''' </summary>
    ''' <returns>True if header string is found</returns>
    ''' <remarks></remarks>
    Private Shared Function isValidHeader() As Boolean
        isValidHeader = True
        Dim test(headerBytes.Length - 1) As Byte
        csCryptoStream.Read(test, 0, headerBytes.Length)
        Dim testString As String = ConvertBytesToString(test)
        If testString <> headerString Then
            LogUtil.Problem("Mismatched image header: " & ConvertBytesToString(test) & " " & headerString, "isValidHeader")
            csCryptoStream.Clear()
            csCryptoStream = Nothing
            isValidHeader = False
        End If
        lngBytesProcessed = headerBytes.Length
    End Function
    ''' <summary>
    ''' Checks that first bytes match the header string
    ''' </summary>
    ''' <returns>True if header string is found</returns>
    ''' <remarks></remarks>
    Public Shared Function isValidHeaderinStream(ByVal streamInput As FileStream) As Boolean
        Dim isValid As Boolean = False
        Try
            If Not isInitialised() Then Return False
            csCryptoStream = New CryptoStream(streamInput, cspRijndael.CreateDecryptor(bKey, bIV), CryptoStreamMode.Read)
            isValid = isValidHeader()
        Catch ex As Exception
            LogUtil.Exception("Error when checking header", ex, "isValidHeaderinStream", getErrorCode(SystemModule.CUSTOMER, ErrorType.ENCRYPTION, FailedAction.DECRYPTION_ERROR))
        Finally

        End Try
        Return isValid
    End Function
#End Region
End Class
