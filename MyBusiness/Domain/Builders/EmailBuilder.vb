' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

''' <summary>
''' Email object builder
''' </summary>
''' <remarks></remarks>
Public Class EmailBuilder
    Private _toAddress As List(Of String)
    Private _ccAddress As List(Of String)
    Private _subject As String
    Private _body As List(Of String)
    Private _attachment As String
    Private _format As String
    Private _deliveryReport As Boolean
    Private _readReceipt As Boolean
    Private _fromAddress As String
    Private _sendDate As Date
    Private _transport As String
    Private _importance As String

    Public Shared Function AnEmail() As EmailBuilder
        Return New EmailBuilder
    End Function

    ''' <summary>
    ''' Create a builder starting from an email
    ''' </summary>
    ''' <param name="pEmail"></param>
    ''' <returns>Email builder</returns>
    ''' <remarks></remarks>
    Public Function StartingWith(ByVal pEmail As Email) As EmailBuilder
        _toAddress = pEmail.ToAddress
        _ccAddress = pEmail.CcAddress
        _subject = pEmail.Subject
        _body = pEmail.Body
        _attachment = pEmail.Attachment
        _format = pEmail.BodyFormat
        _deliveryReport = pEmail.DeliveryReport
        _readReceipt = pEmail.ReadReceipt
        _fromAddress = pEmail.Fromaddress
        _sendDate = pEmail.SendDate
        _transport = pEmail.Transport
        _importance = pEmail.Importance
        Return Me
    End Function

    ''' <summary>
    ''' Create a builder starting from nothing
    ''' </summary>
    ''' <returns>Empty email builder</returns>
    ''' <remarks></remarks>
    Public Function StartingWithNothing() As EmailBuilder
        _toAddress = New List(Of String)
        _ccAddress = New List(Of String)
        _subject = ""
        _body = New List(Of String)
        _attachment = Nothing
        _format = "H"
        _deliveryReport = False
        _readReceipt = False
        _fromAddress = ""
        _sendDate = Today.Date
        _transport = ""
        _importance = ""
        Return Me
    End Function

    Public Function WithFromAddress(ByVal pFromAddress As String) As EmailBuilder
        _fromAddress = pFromAddress
        Return Me
    End Function
    Public Function WithTransport(ByVal pTransport As String) As EmailBuilder
        _transport = pTransport
        Return Me
    End Function
    Public Function WithImportance(ByVal pImportance As String) As EmailBuilder
        _importance = pImportance
        Return Me
    End Function
    Public Function WithSendDate(ByVal pSendDate As Date) As EmailBuilder
        _sendDate = pSendDate
        Return Me
    End Function
    Public Function WithReadReceipt(ByVal pReadReceipt As Boolean) As EmailBuilder
        _readReceipt = pReadReceipt
        Return Me
    End Function
    Public Function WithDeliveryReport(ByVal pDeliveryReport As Boolean)
        _deliveryReport = pDeliveryReport
        Return Me
    End Function
    Public Function WithToAddress(ByVal pToAddress As List(Of String)) As EmailBuilder
        _toAddress = pToAddress
        Return Me
    End Function
    Public Function WithCcAddress(ByVal pCcAddress As List(Of String)) As EmailBuilder
        _ccAddress = pCcAddress
        Return Me
    End Function
    Public Function WithSubject(ByVal pSubject As String) As EmailBuilder
        _subject = pSubject
        Return Me
    End Function
    Public Function WithBody(ByVal pBody As List(Of String)) As EmailBuilder
        _body = pBody
        Return Me
    End Function
    Public Function WithAttachment(ByVal pAttachment As String) As EmailBuilder
        _attachment = pAttachment
        Return Me
    End Function
    Public Function WithFormat(ByVal pFormat As String) As EmailBuilder
        _format = pFormat
        Return Me
    End Function
    Public Function AppendToBody(ByVal oText As String) As EmailBuilder
        If _body Is Nothing Then
            _body = New List(Of String)
        End If
        _body.Add(oText)
        Return Me
    End Function
    Public Function AppendToRecipients(ByVal oText As String) As EmailBuilder
        If _toAddress Is Nothing Then
            _toAddress = New List(Of String)
        End If
        _toAddress.Add(oText)
        Return Me
    End Function
    Public Function AppendToCopies(ByVal oText As String) As EmailBuilder
        If _ccAddress Is Nothing Then
            _ccAddress = New List(Of String)
        End If
        _ccAddress.Add(oText)
        Return Me
    End Function
    Public Function Build() As Email
        Return New Email(_toAddress,
                         _ccAddress,
                         _subject,
                         _body,
                         _attachment,
                         _format,
                         _readReceipt,
                         _deliveryReport,
                         _fromAddress,
                         _sendDate,
                         _transport,
                         _importance)
    End Function
End Class
