' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class JobBuilder
    Private _jobId As Integer
    Private _jobName As String
    Private _jobDescription As String
    'Private _jobCost As Decimal
    'Private _jobPrice As Decimal
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

    Public Shared Function AJobBuilder() As JobBuilder
        Return New JobBuilder
    End Function
    Public Function StartingWith(ByVal jobId As Integer) As JobBuilder
        Dim oJobTa As New netwyrksDataSetTableAdapters.jobTableAdapter
        Dim oJobTable As New netwyrksDataSet.jobDataTable
        If oJobTa.FillById(oJobTable, jobId) > 0 Then
            startingWith(oJobTable.Rows(0))
        Else
            startingWithNothing()
        End If
        oJobTa.Dispose()
        oJobTable.Dispose()
        Return Me
    End Function
    Public Function StartingWith(ByVal oJob As Job) As JobBuilder
        With oJob
            _jobId = .JobId
            _jobName = .JobName
            _jobDescription = .JobDescription
            '_jobCost = .jobCost
            '_jobPrice = .jobPrice
            _jobCompleted = .IsJobCompleted
            _jobCreated = .JobCreated
            _jobChanged = .JobChanged
            _jobCustomerId = .JobCustomerId
            _jobInvoiceNumber = .JobInvoiceNumber
            _jobPoNumber = .JobPoNumber
            _jobReference = .JobReference
            _jobInvoiceDate = .JobInvoiceDate
            _jobPaymentDue = .JobPaymentDue
            _jobUser = .JobUser
        End With
        Return Me
    End Function
    Public Function StartingWith(ByVal oJob As netwyrksDataSet.jobRow) As JobBuilder

        With oJob
            .Isjob_changedNull()
            _jobId = .job_id
            _jobName = .job_name
            _jobDescription = .job_description
            '_jobCost = .job_cost
            '_jobPrice = .job_price
            _jobCompleted = .job_completed
            _jobCreated = .job_created
            If .Isjob_changedNull() Then
                _jobChanged = Nothing
            Else
                _jobChanged = .job_changed
            End If
            _jobCustomerId = .job_customer_id
            _jobInvoiceNumber = If(.Isjob_invoice_numberNull, "", .job_invoice_number)
            _jobPoNumber = If(.Isjob_po_numberNull, "", .job_po_number)
            _jobReference = If(.Isjob_referenceNull, "", .job_reference)
            If .Isjob_invoice_dateNull() Then
                _jobInvoiceDate = Nothing
            Else
                _jobInvoiceDate = .job_invoice_date
            End If
            If .Isjob_payment_dueNull() Then
                _jobPaymentDue = Nothing
            Else
                _jobPaymentDue = .job_payment_due
            End If
            _jobUser = .job_user_id
        End With
        Return Me
    End Function
    Public Function StartingWithNothing() As JobBuilder
        _jobId = -1
        _jobName = ""
        _jobDescription = ""
        '_jobCost = 0
        '_jobPrice = 0
        _jobCompleted = False
        _jobCreated = Today.Date
        _jobChanged = Nothing
        _jobCustomerId = -1
        _jobInvoiceNumber = ""
        _jobPoNumber = ""
        _jobReference = ""
        _jobInvoiceDate = Today.Date
        _jobPaymentDue = Today.Date
        _jobUser = -1
        Return Me
    End Function
    Public Function WithJobId(ByVal pJobId As Integer) As JobBuilder
        _jobId = pJobId
        Return Me
    End Function
    Public Function WithJobCustomerId(ByVal pJobCustomerId As Integer) As JobBuilder
        _jobCustomerId = pJobCustomerId
        Return Me
    End Function
    Public Function WithJobName(ByVal pJobName As String) As JobBuilder
        _jobName = pJobName
        Return Me
    End Function
    Public Function WithJobDescription(ByVal pJobDescription As String) As JobBuilder
        _jobDescription = pJobDescription
        Return Me
    End Function
    'Public Function withJobCost(ByVal pJobCost As Decimal) As jobBuilder
    '    _jobCost = pJobCost
    '    Return Me
    'End Function
    'Public Function withJobPrice(ByVal pJobPrice As Decimal) As jobBuilder
    '    _jobPrice = pJobPrice
    '    Return Me
    'End Function
    Public Function WithJobCompleted(ByVal pJobCompleted As Boolean) As JobBuilder
        _jobCompleted = pJobCompleted
        Return Me
    End Function
    Public Function WithJobCreated(ByVal pJobCreated As DateTime) As JobBuilder
        _jobCreated = pJobCreated
        Return Me
    End Function
    Public Function WithJobChanged(ByVal pJobChanged As DateTime?) As JobBuilder
        _jobChanged = pJobChanged
        Return Me
    End Function
    Public Function WithJobInvoiceNumber(ByVal pJobInvoiceNumber As String) As JobBuilder
        _jobInvoiceNumber = pJobInvoiceNumber
        Return Me
    End Function
    Public Function WithJobPoNumber(ByVal pJobPoNumber As String) As JobBuilder
        _jobPoNumber = pJobPoNumber
        Return Me
    End Function
    Public Function WithJobReference(ByVal pJobReference As String) As JobBuilder
        _jobReference = pJobReference
        Return Me
    End Function
    Public Function WithJobInvoiceDate(ByVal pJobInvoiceDate As DateTime?) As JobBuilder
        _jobInvoiceDate = pJobInvoiceDate
        Return Me
    End Function
    Public Function WithJobPaymentDue(ByVal pJobPaymentDue As DateTime?) As JobBuilder
        _jobPaymentDue = pJobPaymentDue
        Return Me
    End Function
    Public Function WithJobUser(ByVal pJobUser As Integer) As JobBuilder
        _jobUser = pJobUser
        Return Me
    End Function
    Public Function Build() As Job
        Return New Job(_jobId,
                       _jobCustomerId,
                       _jobName,
                       _jobDescription,
                       _jobCompleted,
                       _jobCreated,
                       _jobChanged,
                       _jobInvoiceNumber,
                       _jobPoNumber,
                       _jobReference,
                       _jobInvoiceDate,
                       _jobPaymentDue,
                       _jobUser)
        '_jobCost, _
        '_jobPrice, _
    End Function
End Class
