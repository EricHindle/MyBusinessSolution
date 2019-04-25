'
' Copyright (c) 2017, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class jobBuilder
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

    Public Shared Function aJobBuilder() As jobBuilder
        Return New jobBuilder
    End Function
    Public Function startingWith(ByVal jobId As Integer) As jobBuilder
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

    Public Function startingWith(ByVal oJob As job) As jobBuilder
        With oJob
            _jobId = .jobId
            _jobName = .jobName
            _jobDescription = .jobDescription
            '_jobCost = .jobCost
            '_jobPrice = .jobPrice
            _jobCompleted = .isJobCompleted
            _jobCreated = .jobCreated
            _jobChanged = .jobChanged
            _jobCustomerId = .jobCustomerId
            _jobInvoiceNumber = .jobInvoiceNumber
            _jobPoNumber = .jobPoNumber
            _jobReference = .jobReference
            _jobInvoiceDate = .jobInvoiceDate
            _jobPaymentDue = .jobPaymentDue
            _jobUser = .jobUser
        End With
        Return Me
    End Function
    Public Function startingWith(ByVal oJob As netwyrksDataSet.jobRow) As jobBuilder

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
    Public Function startingWithNothing() As jobBuilder
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
    Public Function withJobId(ByVal pJobId As Integer) As jobBuilder
        _jobId = pJobId
        Return Me
    End Function
    Public Function withJobCustomerId(ByVal pJobCustomerId As Integer) As jobBuilder
        _jobCustomerId = pJobCustomerId
        Return Me
    End Function
    Public Function withJobName(ByVal pJobName As String) As jobBuilder
        _jobName = pJobName
        Return Me
    End Function
    Public Function withJobDescription(ByVal pJobDescription As String) As jobBuilder
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
    Public Function withJobCompleted(ByVal pJobCompleted As Boolean) As jobBuilder
        _jobCompleted = pJobCompleted
        Return Me
    End Function
    Public Function withJobCreated(ByVal pJobCreated As DateTime) As jobBuilder
        _jobCreated = pJobCreated
        Return Me
    End Function
    Public Function withJobChanged(ByVal pJobChanged As DateTime?) As jobBuilder
        _jobChanged = pJobChanged
        Return Me
    End Function
    Public Function withJobInvoiceNumber(ByVal pJobInvoiceNumber As String) As jobBuilder
        _jobInvoiceNumber = pJobInvoiceNumber
        Return Me
    End Function
    Public Function withJobPoNumber(ByVal pJobPoNumber As String) As jobBuilder
        _jobPoNumber = pJobPoNumber
        Return Me
    End Function
    Public Function withJobReference(ByVal pJobReference As String) As jobBuilder
        _jobReference = pJobReference
        Return Me
    End Function
    Public Function withJobInvoiceDate(ByVal pJobInvoiceDate As DateTime?) As jobBuilder
        _jobInvoiceDate = pJobInvoiceDate
        Return Me
    End Function
    Public Function withJobPaymentDue(ByVal pJobPaymentDue As DateTime?) As jobBuilder
        _jobPaymentDue = pJobPaymentDue
        Return Me
    End Function
    Public Function withjobUser(ByVal pJobUser As Integer) As jobBuilder
        _jobUser = pJobUser
        Return Me
    End Function
    Public Function build() As job
        Return New job(_jobId, _
                       _jobCustomerId, _
                       _jobName, _
                       _jobDescription, _
                       _jobCompleted, _
                       _jobCreated, _
                       _jobChanged, _
                       _jobInvoiceNumber, _
                       _jobPoNumber, _
                       _jobReference, _
                       _jobInvoiceDate, _
                       _jobPaymentDue, _
                       _jobUser)
        '_jobCost, _
        '_jobPrice, _
    End Function
End Class
