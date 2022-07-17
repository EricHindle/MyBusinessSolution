' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.Text

Public Class Job
    Private _jobId As Integer
    Private _jobName As String
    Private _jobDescription As String
    Private _jobCompleted As Boolean
    Private _jobCreated As DateTime
    Private _jobChanged As DateTime?
    Private _jobCustomerId As Integer
    Private _jobInvoiceNumber As String
    Private _jobPoNumber As String
    Private _jobReference As String
    Private _jobInvoiceDate As DateTime?
    Private _jobPaymentDue As DateTime?
    Private _jobUserId As Integer

    Public Property JobUserId() As Integer
        Get
            Return _jobUserId
        End Get
        Set(ByVal value As Integer)
            _jobUserId = value
        End Set
    End Property
    Public Property JobPaymentDue() As DateTime?
        Get
            Return _jobPaymentDue
        End Get
        Set(ByVal value As DateTime?)
            _jobPaymentDue = value
        End Set
    End Property
    Public Property JobInvoiceDate() As DateTime?
        Get
            Return _jobInvoiceDate
        End Get
        Set(ByVal value As DateTime?)
            _jobInvoiceDate = value
        End Set
    End Property
    Public Property JobReference() As String
        Get
            Return If(_jobReference, "")
        End Get
        Set(ByVal value As String)
            _jobReference = value
        End Set
    End Property
    Public Property JobPoNumber() As String
        Get
            Return If(_jobPoNumber, "")
        End Get
        Set(ByVal value As String)
            _jobPoNumber = value
        End Set
    End Property
    Public Property JobInvoiceNumber() As String
        Get
            Return If(_jobInvoiceNumber, "")
        End Get
        Set(ByVal value As String)
            _jobInvoiceNumber = value
        End Set
    End Property
    Public Property JobCustomerId() As Integer
        Get
            Return _jobCustomerId
        End Get
        Set(ByVal value As Integer)
            _jobCustomerId = value
        End Set
    End Property
    Public Property JobChanged() As DateTime?
        Get
            Return _jobChanged
        End Get
        Set(ByVal value As DateTime?)
            _jobChanged = value
        End Set
    End Property
    Public Property JobCreated() As DateTime
        Get
            Return _jobCreated
        End Get
        Set(ByVal value As DateTime)
            _jobCreated = value
        End Set
    End Property
    Public Property IsJobCompleted() As Boolean
        Get
            Return _jobCompleted
        End Get
        Set(ByVal value As Boolean)
            _jobCompleted = value
        End Set
    End Property
    Public Property JobDescription() As String
        Get
            Return _jobDescription
        End Get
        Set(ByVal value As String)
            _jobDescription = value
        End Set
    End Property
    Public Property JobName() As String
        Get
            Return _jobName
        End Get
        Set(ByVal value As String)
            _jobName = value
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
    Public Sub New(ByVal pJobId As Integer,
                    ByVal pJobCustomer As Integer,
                    ByVal pJobName As String,
                    ByVal pJobDescription As String,
                    ByVal pJobCompleted As Boolean,
                    ByVal pJobCreated As DateTime,
                    ByVal pJobChanged As DateTime?,
                    ByVal pJobInvoiceNumber As String,
                    ByVal pJobPoNumber As String,
                    ByVal pJobReference As String,
                    ByVal pJobInvoiceDate As DateTime?,
                    ByVal pJobPaymentDue As DateTime?,
                    ByVal pJobUser As Integer)
        _jobId = pJobId
        _jobCustomerId = pJobCustomer
        _jobName = pJobName
        _jobDescription = pJobDescription
        _jobCompleted = pJobCompleted
        _jobCreated = pJobCreated
        _jobChanged = pJobChanged
        _jobInvoiceNumber = pJobInvoiceNumber
        _jobPoNumber = pJobPoNumber
        _jobReference = pJobReference
        _jobInvoiceDate = pJobInvoiceDate
        _jobPaymentDue = pJobPaymentDue
        _jobUserId = pJobUser
    End Sub
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
        .Append("jobId=[") _
        .Append(_jobId) _
        .Append("], name=[") _
        .Append(_jobName) _
        .Append("], description=[") _
        .Append(_jobDescription) _
        .Append("], customerId=[") _
        .Append(_jobCustomerId) _
        .Append("], idCompleted=[") _
        .Append(_jobCompleted) _
        .Append("], created=[") _
        .Append(Format(_jobCreated, "dd/MM/yyyy")) _
        .Append("], changed=[") _
        .Append(If(_jobChanged Is Nothing, "", Format(_jobChanged, "dd/MM/yyyy"))) _
        .Append("], invoiceNumber=[") _
        .Append(_jobInvoiceNumber) _
        .Append("], poNumber=[") _
        .Append(_jobPoNumber) _
        .Append("], reference=[") _
        .Append(_jobReference) _
        .Append("], InvoiceDate=[") _
        .Append(If(_jobInvoiceDate Is Nothing, "", Format(_jobInvoiceDate, "dd/MM/yyyy"))) _
        .Append("], paymentDue=[") _
        .Append(If(_jobPaymentDue Is Nothing, "", Format(_jobPaymentDue, "dd/MM/yyyy"))) _
        .Append("], user=[") _
        .Append(UserBuilder.AUser.StartingWith(_jobUserId).Build.User_code) _
        .Append("]")
        Return sb.ToString
    End Function
End Class
