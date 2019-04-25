'
' Copyright (c) 2017, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.Text

Public Class job
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
    Private _jobUser As Integer

    Public Property jobUser() As Integer
        Get
            Return _jobUser
        End Get
        Set(ByVal value As Integer)
            _jobUser = value
        End Set
    End Property


    Public Property jobPaymentDue() As DateTime?
        Get
            Return _jobPaymentDue
        End Get
        Set(ByVal value As DateTime?)
            _jobPaymentDue = value
        End Set
    End Property

    Public Property jobInvoiceDate() As DateTime?
        Get
            Return _jobInvoiceDate
        End Get
        Set(ByVal value As DateTime?)
            _jobInvoiceDate = value
        End Set
    End Property


    Public Property jobReference() As String
        Get
            Return If(_jobReference Is Nothing, "", _jobReference)
        End Get
        Set(ByVal value As String)
            _jobReference = value
        End Set
    End Property

    Public Property jobPoNumber() As String
        Get
            Return If(_jobPoNumber Is Nothing, "", _jobPoNumber)
        End Get
        Set(ByVal value As String)
            _jobPoNumber = value
        End Set
    End Property
    Public Property jobInvoiceNumber() As String
        Get
            Return If(_jobInvoiceNumber Is Nothing, "", _jobInvoiceNumber)
        End Get
        Set(ByVal value As String)
            _jobInvoiceNumber = value
        End Set
    End Property
    Public Property jobCustomerId() As Integer
        Get
            Return _jobCustomerId
        End Get
        Set(ByVal value As Integer)
            _jobCustomerId = value
        End Set
    End Property
    Public Property jobChanged() As DateTime?
        Get
            Return _jobChanged
        End Get
        Set(ByVal value As DateTime?)
            _jobChanged = value
        End Set
    End Property
    Public Property jobCreated() As DateTime
        Get
            Return _jobCreated
        End Get
        Set(ByVal value As DateTime)
            _jobCreated = value
        End Set
    End Property
    Public Property isJobCompleted() As Boolean
        Get
            Return _jobCompleted
        End Get
        Set(ByVal value As Boolean)
            _jobCompleted = value
        End Set
    End Property
    Public Property jobDescription() As String
        Get
            Return _jobDescription
        End Get
        Set(ByVal value As String)
            _jobDescription = value
        End Set
    End Property
    Public Property jobName() As String
        Get
            Return _jobName
        End Get
        Set(ByVal value As String)
            _jobName = value
        End Set
    End Property
    Public Property jobId() As Integer
        Get
            Return _jobId
        End Get
        Set(ByVal value As Integer)
            _jobId = value
        End Set
    End Property

    Public Sub New(ByVal pJobId As Integer, _
                    ByVal pJobCustomer As Integer, _
                    ByVal pJobName As String, _
                    ByVal pJobDescription As String, _
                    ByVal pJobCompleted As Boolean, _
                    ByVal pJobCreated As DateTime, _
                    ByVal pJobChanged As DateTime?, _
                    ByVal pJobInvoiceNumber As String, _
                    ByVal pJobPoNumber As String, _
                    ByVal pJobReference As String, _
                    ByVal pJobInvoiceDate As DateTime?, _
                    ByVal pJobPaymentDue As DateTime?, _
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
        _jobUser = pJobUser
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
        .Append(UserBuilder.aUserBuilder.startingWith(_jobUser).build.user_code) _
        .Append("]")
        Return sb.ToString
    End Function

End Class
