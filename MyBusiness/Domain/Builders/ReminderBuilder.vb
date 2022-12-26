' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class ReminderBuilder
    Private _diaryId As Integer
    Private _user As User
    Private _reminderDate As DateTime
    Private _subject As String
    Private _body As String
    Private _isReminder As Boolean
    Private _isClosed As Boolean
    Private _customer As Customer
    Private _job As Job
    Private _callback As Boolean
    Public Shared Function AReminder() As ReminderBuilder
        Return New ReminderBuilder
    End Function
    Public Function StartingWith(ByVal oReminder As Reminder) As ReminderBuilder
        If oReminder IsNot Nothing Then
            With oReminder
                _diaryId = .Diary_id
                _user = .DiaryUser
                _reminderDate = .ReminderDate
                _subject = .Subject
                _body = .Body
                _isReminder = .IsReminder
                _isClosed = .IsClosed
                _customer = .LinkedCustomer
                _job = .LinkedJob
                _callback = .CallBack
            End With
        Else
            StartingWithNothing()
        End If
        Return Me
    End Function
    Public Function StartingWithNothing() As ReminderBuilder
        _diaryId = 0
        _user = UserBuilder.AUser.StartingWithNothing.Build
        _reminderDate = Today.Date
        _subject = ""
        _body = ""
        _isReminder = False
        _isClosed = False
        _customer = CustomerBuilder.ACustomer.StartingWithNothing.Build
        _job = JobBuilder.AJob.StartingWithNothing.Build
        _callback = False
        Return Me
    End Function
    Public Function StartingWith(ByVal oReminder As netwyrksDataSet.diaryRow) As ReminderBuilder
        If oReminder IsNot Nothing Then
            With oReminder
                _diaryId = .diary_id
                _user = If(.Isdiary_user_idNull, UserBuilder.AUser.StartingWithNothing.Build, GetUserById(.diary_user_id))
                _reminderDate = If(.Isdiary_dateNull, Date.MinValue, .diary_date)
                _subject = If(.Isdiary_subjectNull, "", .diary_subject)
                _body = If(.Isdiary_bodyNull, "", .diary_body)
                _isReminder = Not .Isdiary_reminderNull AndAlso .diary_reminder <> 0
                _isClosed = Not .Isdiary_closedNull AndAlso .diary_closed <> 0
                _job = If(.Isdiary_jobNull, JobBuilder.AJob.StartingWithNothing.Build, GetJobById(.diary_job))
                _customer = If(.Isdiary_cust_idNull, CustomerBuilder.ACustomer.StartingWithNothing.Build, GetCustomer(.diary_cust_id))
                _callback = Not .Isdiary_callbackNull AndAlso .diary_callback <> 0
            End With
        Else
            StartingWithNothing()
        End If
        Return Me
    End Function
    Public Function WithDiaryId(ByVal pDiaryId As Integer) As ReminderBuilder
        _diaryId = pDiaryId
        Return Me
    End Function
    Public Function WithUserId(ByVal userId As Integer) As ReminderBuilder
        _user = GetUserById(userId)
        Return Me
    End Function
    Public Function WithReminderDate(ByVal reminderDate As DateTime) As ReminderBuilder
        _reminderDate = reminderDate
        Return Me
    End Function
    Public Function WithSubject(ByVal subject As String) As ReminderBuilder
        _subject = subject
        Return Me
    End Function
    Public Function WithBody(ByVal body As String) As ReminderBuilder
        _body = body
        Return Me
    End Function
    Public Function WithIsReminder(ByVal pReminder As Boolean) As ReminderBuilder
        _isReminder = pReminder
        Return Me
    End Function
    Public Function WithClosed(ByVal pClosed As Boolean) As ReminderBuilder
        _isClosed = pClosed
        Return Me
    End Function
    Public Function WithCustomerId(ByVal pCustomerId As Integer?) As ReminderBuilder
        _customer = GetCustomer(pCustomerId)
        Return Me
    End Function
    Public Function WithJobId(ByVal pJobId As Integer?) As ReminderBuilder
        _job = GetJobById(pJobId)
        Return Me
    End Function
    Public Function WithCallBack(ByVal pCallBack As Boolean) As ReminderBuilder
        _callback = pCallBack
        Return Me
    End Function

    Public Function Build() As Reminder
        Return New Reminder(_diaryId,
                            _user,
                            _reminderDate,
                            _subject,
                            _body,
                            _isReminder,
                            _isClosed,
                            _customer,
                            _job,
                            _callback)
    End Function
End Class
