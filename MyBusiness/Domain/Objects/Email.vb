' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Net.Mail
Imports System.Text

''' <summary>
''' Email 
''' </summary>
''' <remarks></remarks>
Public Class Email
    Private _toAddress As List(Of String)
    Private _ccAddress As List(Of String)
    Private _subject As String
    Private _body As List(Of String)
    Private _attachments As List(Of Attachment)
    Private _format As Boolean
    Private _readReceipt As Boolean
    Private _deliveryReport As DeliveryNotificationOptions
    Private _fromAddress As String
    Private _sendDate As Date
    Private _transport As String
    Private _priority As String
    Public Sub New(ByVal pToAddress As List(Of String),
                   ByVal pCcAddress As List(Of String),
                   ByVal pSubject As String,
                   ByVal pBody As List(Of String),
                   ByVal pAttachments As List(Of Attachment),
                   ByVal pFormat As String,
                   ByVal pReadReceipt As Boolean,
                   ByVal pDeliveryReport As Boolean,
                   ByVal pFromaddress As String,
                   ByVal pSendDate As Date,
                   ByVal pTransport As String,
                   ByVal pImportance As String)

        _toAddress = pToAddress
        _ccAddress = pCcAddress
        _subject = pSubject
        _body = pBody
        _attachments = pAttachments
        _format = pFormat
        _readReceipt = pReadReceipt
        _deliveryReport = pDeliveryReport
        _fromAddress = pFromaddress
        _sendDate = pSendDate
        _transport = pTransport
        _priority = pImportance
    End Sub
    Public Property Priority() As String
        Get
            Return _priority
        End Get
        Set(ByVal value As String)
            _priority = value
        End Set
    End Property
    'Public Property Transport() As String
    '    Get
    '        Return _transport
    '    End Get
    '    Set(ByVal value As String)
    '        _transport = value
    '    End Set
    'End Property
    Public Property SendDate() As Date
        Get
            Return _sendDate
        End Get
        Set(ByVal value As Date)
            _sendDate = value
        End Set
    End Property
    Public Property Fromaddress() As String
        Get
            Return _fromAddress
        End Get
        Set(ByVal value As String)
            _fromAddress = value
        End Set
    End Property
    Public Property DeliveryReport() As DeliveryNotificationOptions
        Get
            Return _deliveryReport
        End Get
        Set(ByVal value As DeliveryNotificationOptions)
            _deliveryReport = value
        End Set
    End Property
    'Public Property ReadReceipt() As Boolean
    '    Get
    '        Return _readReceipt
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _readReceipt = value
    '    End Set
    'End Property
    Public Property IsHtml() As Boolean
        Get
            Return _format
        End Get
        Set(ByVal value As Boolean)
            _format = value
        End Set
    End Property
    Public Property Attachments() As List(Of Attachment)
        Get
            Return _attachments
        End Get
        Set(ByVal value As List(Of Attachment))
            _attachments = value
        End Set
    End Property
    Public Property ToAddress() As List(Of String)
        Get
            Return _toAddress
        End Get
        Set(ByVal value As List(Of String))
            _toAddress = value
        End Set
    End Property
    Public Property CcAddress() As List(Of String)
        Get
            Return _ccAddress
        End Get
        Set(ByVal value As List(Of String))
            _ccAddress = value
        End Set
    End Property
    Public Property Subject() As String
        Get
            Return _subject
        End Get
        Set(ByVal value As String)
            _subject = value
        End Set
    End Property
    Public Property Body() As List(Of String)
        Get
            Return _body
        End Get
        Set(ByVal value As List(Of String))
            _body = value
        End Set
    End Property
    Public Function BodyString() As String
        Return Join(_body.ToArray, vbCrLf)
    End Function
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder

        sb _
            .Append("Email=[") _
            .Append("toAddress=[") _
            .Append(String.Join(";", _toAddress.ToArray)) _
            .Append("], ccAddress=[") _
            .Append(String.Join(";", _ccAddress.ToArray)) _
            .Append("], subject=[") _
            .Append(_subject) _
            .Append("], body=[") _
            .Append(String.Join("\", _body.ToArray)) _
            .Append("], attachment=[") _
            .Append(_attachments) _
            .Append("], format=[") _
            .Append(_format) _
            .Append("], fromAddress=[") _
            .Append(_fromAddress) _
            .Append("], sendDate=[") _
            .Append(Format(_sendDate, "dd/MM/yyyy")) _
            .Append("], transport=[") _
            .Append(_transport) _
            .Append("], importance=[") _
            .Append(_priority) _
            .Append("]]")
        Return sb.ToString
    End Function
End Class
