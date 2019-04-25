'
' Copyright (c) 2017, Eric Hindle
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
    Private _customerId As Integer?
    Private _jobId As Integer?
    Private _diaryId As Integer
    Private _callBack As Boolean

    Public Sub New(ByVal pDiaryId As Integer, _
                    ByVal pUserId As Integer, _
                    ByVal pReminderDate As Date?, _
                    ByVal pSubject As String, _
                    ByVal pBody As String, _
                    ByVal pReminder As Boolean, _
                    ByVal pClosed As Boolean, _
                    ByVal pCustomerId As Integer?, _
                    ByVal pJobId As Integer?, _
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
    End Sub

    Public Property callBack() As Boolean
        Get
            Return _callBack
        End Get
        Set(ByVal value As Boolean)
            _callBack = value
        End Set
    End Property

    Public Property diary_id() As Integer
        Get
            Return _diaryId
        End Get
        Set(ByVal value As Integer)
            _diaryId = value
        End Set
    End Property

    Public Property jobId() As Integer?
        Get
            Return _jobId
        End Get
        Set(ByVal value As Integer?)
            _jobId = value
        End Set
    End Property

    Public Property customerId() As Integer?
        Get
            Return _customerId
        End Get
        Set(ByVal value As Integer?)
            _customerId = value
        End Set
    End Property

    Public Property isClosed() As Boolean
        Get
            Return _isClosed
        End Get
        Set(ByVal value As Boolean)
            _isClosed = value
        End Set
    End Property

    Public Property isReminder() As Boolean
        Get
            Return _isReminder
        End Get
        Set(ByVal value As Boolean)
            _isReminder = value
        End Set
    End Property

    Public Property body() As String
        Get
            Return _body
        End Get
        Set(ByVal value As String)
            _body = value
        End Set
    End Property

    Public Property subject() As String
        Get
            Return _subject
        End Get
        Set(ByVal value As String)
            _subject = value
        End Set
    End Property

    Public Property reminderDate() As DateTime
        Get
            Return _reminderDate
        End Get
        Set(ByVal value As DateTime)
            _reminderDate = value
        End Set
    End Property

    Public Property userId() As Integer
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
            .Append("], customerId=[") _
            .Append(_customerId) _
            .Append("], jobId=[") _
            .Append(_jobId) _
            .Append("], diaryId=[") _
            .Append(_diaryId) _
            .Append("]]")
        Return sb.ToString
    End Function

End Class
