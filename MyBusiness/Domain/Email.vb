'
' Copyright (c) 2017, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

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
    Private _attachment As String
    Private _format As String
    Private _readReceipt As Boolean
    Private _deliveryReport As Boolean
    Private _fromAddress As String
    Private _sendDate As Date
    Private _transport As String
    Private _importance As String

    Public Sub New(ByVal pToAddress As List(Of String), _
                   ByVal pCcAddress As List(Of String), _
                   ByVal pSubject As String, _
                   ByVal pBody As List(Of String), _
                   ByVal pAttachment As String, _
                   ByVal pFormat As String, _
                   ByVal pReadReceipt As Boolean, _
                   ByVal pDeliveryReport As Boolean, _
                   ByVal pFromaddress As String, _
                   ByVal pSendDate As Date, _
                   ByVal pTransport As String, _
                   ByVal pImportance As String)

        _toAddress = pToAddress
        _ccAddress = pCcAddress
        _subject = pSubject
        _body = pBody
        _attachment = pAttachment
        _format = pFormat
        _readReceipt = pReadReceipt
        _deliveryReport = pDeliveryReport
        _fromAddress = pFromaddress
        _sendDate = pSendDate
        _transport = pTransport
        _importance = pImportance
    End Sub

    Public Property Importance() As String
        Get
            Return _importance
        End Get
        Set(ByVal value As String)
            _importance = value
        End Set
    End Property

    Public Property Transport() As String
        Get
            Return _transport
        End Get
        Set(ByVal value As String)
            _transport = value
        End Set
    End Property

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

    Public Property DeliveryReport() As Boolean
        Get
            Return _deliveryReport
        End Get
        Set(ByVal value As Boolean)
            _deliveryReport = value
        End Set
    End Property

    Public Property ReadReceipt() As Boolean
        Get
            Return _readReceipt
        End Get
        Set(ByVal value As Boolean)
            _readReceipt = value
        End Set
    End Property

    Public Property BodyFormat() As String
        Get
            Return _format
        End Get
        Set(ByVal value As String)
            _format = value
        End Set
    End Property

    Public Property Attachment() As String
        Get
            Return _attachment
        End Get
        Set(ByVal value As String)
            _attachment = value
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
            .Append(_attachment) _
            .Append("], format=[") _
            .Append(_format) _
            .Append("], fromAddress=[") _
            .Append(_fromAddress) _
            .Append("], sendDate=[") _
            .Append(Format(_sendDate, "dd/MM/yyyy")) _
            .Append("], transport=[") _
            .Append(_transport) _
            .Append("], importance=[") _
            .Append(_importance) _
            .Append("]]")
        Return sb.ToString
    End Function


End Class
