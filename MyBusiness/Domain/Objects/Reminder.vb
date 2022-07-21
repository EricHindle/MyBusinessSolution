' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.Text

''' <summary>
''' Diary entry
''' </summary>
''' <remarks></remarks>
Public Class Reminder

    Private _userId As Integer
    Private _reminderDate As DateTime
    Private _subject As String
    Private _body As String
    Private _isReminder As Boolean
    Private _isClosed As Boolean
    Private _customerId As Integer
    Private _jobId As Integer
    Private _diaryId As Integer
    Private _callBack As Boolean
    Private _customer As Customer
    Private _user As User
    Private _job As Job
    Public Property DiaryJob() As Job
        Get
            Return _job
        End Get
        Set(ByVal value As Job)
            _job = value
        End Set
    End Property
    Public Property DiaryUser() As User
        Get
            Return _user
        End Get
        Set(ByVal value As User)
            _user = value
        End Set
    End Property
    Public Property DiaryCustomer() As Customer
        Get
            Return _customer
        End Get
        Set(ByVal value As Customer)
            _customer = value
        End Set
    End Property
    Public Sub New(ByVal pDiaryId As Integer,
                    ByVal pUserId As Integer,
                    ByVal pReminderDate As Date?,
                    ByVal pSubject As String,
                    ByVal pBody As String,
                    ByVal pReminder As Boolean,
                    ByVal pClosed As Boolean,
                    ByVal pCustomerId As Integer,
                    ByVal pJobId As Integer,
                    ByVal pCallBack As Boolean)
        _diaryId = pDiaryId
        _userId = pUserId
        _reminderDate = pReminderDate
        _subject = pSubject
        _body = pBody
        _isReminder = pReminder
        _isClosed = pClosed
        _customerId = pCustomerId
        _jobId = pJobId
        _callBack = pCallBack
        _user = GetUserById(pUserId)
        _customer = GetCustomer(pCustomerId)
        _job = GetJobById(pJobId)
    End Sub
    Public Property CallBack() As Boolean
        Get
            Return _callBack
        End Get
        Set(ByVal value As Boolean)
            _callBack = value
        End Set
    End Property
    Public Property Diary_id() As Integer
        Get
            Return _diaryId
        End Get
        Set(ByVal value As Integer)
            _diaryId = value
        End Set
    End Property
    Public Property JobId() As Integer?
        Get
            Return _jobId
        End Get
        Set(ByVal value As Integer?)
            _jobId = value
        End Set
    End Property
    Public Property CustomerId() As Integer?
        Get
            Return _customerId
        End Get
        Set(ByVal value As Integer?)
            _customerId = value
        End Set
    End Property
    Public Property IsClosed() As Boolean
        Get
            Return _isClosed
        End Get
        Set(ByVal value As Boolean)
            _isClosed = value
        End Set
    End Property
    Public Property IsReminder() As Boolean
        Get
            Return _isReminder
        End Get
        Set(ByVal value As Boolean)
            _isReminder = value
        End Set
    End Property
    Public Property Body() As String
        Get
            Return _body
        End Get
        Set(ByVal value As String)
            _body = value
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
    Public Property ReminderDate() As DateTime
        Get
            Return _reminderDate
        End Get
        Set(ByVal value As DateTime)
            _reminderDate = value
        End Set
    End Property
    Public Property UserId() As Integer
        Get
            Return _userId
        End Get
        Set(ByVal value As Integer)
            _userId = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
            .Append("Reminder=[userId=[") _
            .Append(_userId) _
            .Append("], reminderDate=[") _
            .Append(Format(_reminderDate, "dd/MM/yyyy")) _
            .Append("], subject=[") _
            .Append(_subject) _
            .Append("], body=[") _
            .Append(_body) _
            .Append("], isReminder=[") _
            .Append(_isReminder) _
            .Append("], isClosed=[") _
            .Append(_isClosed) _
            .Append("], customer=[") _
            .Append(_customer.ToString) _
            .Append("], job=[") _
            .Append(_job.ToString) _
            .Append("], diaryId=[") _
            .Append(_diaryId) _
            .Append("]]")
        Return sb.ToString
    End Function
End Class
