' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class ReminderBuilder
    Private _diaryId As Integer
    Private _userId As Integer
    Private _reminderDate As DateTime
    Private _subject As String
    Private _body As String
    Private _isReminder As Boolean
    Private _isClosed As Boolean
    Private _customerId As Integer
    Private _jobId As Integer
    Private _callback As Boolean
    Public Shared Function AReminder() As ReminderBuilder
        Return New ReminderBuilder
    End Function
    Public Function StartingWith(ByVal oReminder As Reminder) As ReminderBuilder
        If oReminder IsNot Nothing Then
            With oReminder
                _diaryId = .Diary_id
                _userId = .UserId
                _reminderDate = .ReminderDate
                _subject = .Subject
                _body = .Body
                _isReminder = .IsReminder
                _isClosed = .IsClosed
                _customerId = .CustomerId
                _jobId = .JobId
                _callback = .CallBack
            End With
        Else
            StartingWithNothing()
        End If
        Return Me
    End Function
    Public Function StartingWithNothing() As ReminderBuilder
        _diaryId = 0
        _userId = -1
        _reminderDate = Today.Date
        _subject = ""
        _body = ""
        _isReminder = False
        _isClosed = False
        _customerId = -1
        _jobId = -1
        _callback = False
        Return Me
    End Function
    Public Function StartingWith(ByVal iReminderId As Integer) As ReminderBuilder
        Dim oDiaryTa As New netwyrksDataSetTableAdapters.diaryTableAdapter
        Dim oDiaryTable As New netwyrksDataSet.diaryDataTable
        If oDiaryTa.FillById(oDiaryTable, iReminderId) = 1 Then
            StartingWith(oDiaryTable.Rows(0))
        Else
            StartingWithNothing()
        End If
        oDiaryTa.Dispose()
        oDiaryTable.Dispose()
        Return Me
    End Function
    Public Function StartingWith(ByVal oReminder As netwyrksDataSet.diaryRow) As ReminderBuilder
        If oReminder IsNot Nothing Then
            With oReminder
                _diaryId = .diary_id
                _userId = .diary_user_id
                _reminderDate = .diary_date
                _subject = .diary_subject
                _body = .diary_body
                _isReminder = .diary_reminder
                _isClosed = .diary_closed
                If .Isdiary_jobNull Then
                    _jobId = -1
                Else
                    _jobId = .diary_job
                End If
                If .Isdiary_cust_idNull Then
                    _customerId = -1
                Else
                    _customerId = .diary_cust_id
                End If

                _callback = .diary_callback
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
        _userId = userId
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
        _customerId = pCustomerId
        Return Me
    End Function
    Public Function WithJobId(ByVal pJobId As Integer?) As ReminderBuilder
        _jobId = pJobId
        Return Me
    End Function
    Public Function WithCallBack(ByVal pCallBack As Boolean) As ReminderBuilder
        _callback = pCallBack
        Return Me
    End Function

    Public Function Build() As Reminder
        Return New Reminder(_diaryId,
                            _userId,
                            _reminderDate,
                            _subject,
                            _body,
                            _isReminder,
                            _isClosed,
                            _customerId,
                            _jobId,
                            _callback)
    End Function
End Class
