' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

''' <summary>
''' Diary entry or Reminder
''' </summary>
''' <remarks></remarks>
Public Class Reminder
#Region "properties"
    Private _reminderDate As DateTime
    Private _subject As String
    Private _body As String
    Private _isReminder As Boolean
    Private _isClosed As Boolean
    Private _diaryId As Integer
    Private _callBack As Boolean
    Private _customer As Customer
    Private _user As User
    Private _job As Job
    Public ReadOnly Property HasCustomer() As Boolean
        Get
            Return _customer IsNot Nothing AndAlso _customer.CustomerId > 0
        End Get
    End Property
    Public ReadOnly Property HasJob() As Boolean
        Get
            Return _job IsNot Nothing AndAlso _job.JobId > 0
        End Get
    End Property
    Public ReadOnly Property HasUser() As Boolean
        Get
            Return _user IsNot Nothing AndAlso _user.UserId > 0
        End Get
    End Property
    Public Property DiaryUser() As User
        Get
            Return _user
        End Get
        Set(ByVal value As User)
            _user = value
        End Set
    End Property
    Public Property LinkedJob() As Job
        Get
            Return _job
        End Get
        Set(ByVal value As Job)
            _job = value
        End Set
    End Property
    Public Property LinkedCustomer() As Customer
        Get
            Return _customer
        End Get
        Set(ByVal value As Customer)
            _customer = value
        End Set
    End Property
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
    Public ReadOnly Property JobId() As Integer
        Get
            Return If(HasJob, _job.JobId, -1)
        End Get
    End Property
    Public ReadOnly Property CustomerId() As Integer
        Get
            Return If(HasCustomer, _customer.CustomerId, -1)
        End Get
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
    Public ReadOnly Property UserId() As Integer
        Get
            Return If(HasUser, _user.UserId, -1)
        End Get
    End Property
#End Region
#Region "constructors"
    Public Sub New(ByVal pDiaryId As Integer,
                    ByVal pUser As User,
                    ByVal pReminderDate As DateTime,
                    ByVal pSubject As String,
                    ByVal pBody As String,
                    ByVal pReminder As Boolean,
                    ByVal pClosed As Boolean,
                    ByVal pCustomer As Customer,
                    ByVal pJob As Job,
                    ByVal pCallBack As Boolean)
        _diaryId = pDiaryId
        _reminderDate = pReminderDate
        _subject = pSubject
        _body = pBody
        _isReminder = pReminder
        _isClosed = pClosed
        _callBack = pCallBack
        _user = pUser
        _customer = pCustomer
        _job = pJob
    End Sub
#End Region
#Region "methods"
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
            .Append("Reminder=[") _
            .Append("Diary Id=[") _
            .Append(_diaryId) _
            .Append("], User Id=[") _
            .Append(CStr(UserId)) _
            .Append("], Reminder Date=[") _
            .Append(Format(_reminderDate, "dd/MM/yyyy HH:mm")) _
            .Append("], Subject=[") _
            .Append(_subject) _
            .Append("], Body=[") _
            .Append(_body) _
            .Append("], isReminder=[") _
            .Append(CStr(_isReminder)) _
            .Append("], isClosed=[") _
            .Append(CStr(_isClosed)) _
            .Append("], customer=[") _
            .Append(CStr(CustomerId)) _
            .Append("], job=[") _
            .Append(CStr(JobId)) _
            .Append("]]")
        Return sb.ToString
    End Function
#End Region
End Class
