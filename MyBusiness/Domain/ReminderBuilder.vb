' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Sep 2015

Public Class ReminderBuilder
    Private _diaryId As Integer
    Private _userId As Integer
    Private _reminderDate As DateTime
    Private _subject As String
    Private _body As String
    Private _isReminder As Boolean
    Private _isClosed As Boolean
    Private _customerId As Integer?
    Private _jobId As Integer?
    Private _callback As Boolean

    Public Shared Function aReminder() As ReminderBuilder
        Return New ReminderBuilder
    End Function

    Public Function startingWith(ByVal oReminder As Reminder) As ReminderBuilder
        If oReminder IsNot Nothing Then
            With oReminder
                _diaryId = .diary_id
                _userId = .userId
                _reminderDate = .reminderDate
                _subject = .subject
                _body = .body
                _isReminder = .isReminder
                _isClosed = .isClosed
                _customerId = .customerId
                _jobId = .jobId
                _callback = .callBack
            End With
        Else
            startingWithNothing()
        End If
        Return Me
    End Function

    Public Function startingWithNothing() As ReminderBuilder
        _diaryId = 0
        _userId = 0
        _reminderDate = Today.Date
        _subject = ""
        _body = ""
        _isReminder = False
        _isClosed = False
        _customerId = Nothing
        _jobId = Nothing
        _callback = False
        Return Me
    End Function

    Public Function startingWith(ByVal iReminderId As Integer) As ReminderBuilder
        Dim oDiaryTa As New netwyrksDataSetTableAdapters.diaryTableAdapter
        Dim oDiaryTable As New netwyrksDataSet.diaryDataTable
        If oDiaryTa.FillById(oDiaryTable, iReminderId) = 1 Then
            startingWith(oDiaryTable.Rows(0))
        Else
            startingWithNothing()
        End If
        oDiaryTa.Dispose()
        oDiaryTable.Dispose()
        Return Me
    End Function

    Public Function startingWith(ByVal oReminder As netwyrksDataSet.diaryRow) As ReminderBuilder
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
                    _jobId = Nothing
                Else
                    _jobId = .diary_job
                End If
                If .Isdiary_cust_idNull Then
                    _customerId = Nothing
                Else
                    _customerId = .diary_cust_id
                End If

                _callback = .diary_callback
            End With
        Else
            startingWithNothing()
        End If
        Return Me
    End Function

    Public Function withDiaryId(ByVal pDiaryId As Integer) As ReminderBuilder
        _diaryId = pDiaryId
        Return Me
    End Function

    Public Function withUserId(ByVal userId As Integer) As ReminderBuilder
        _userId = userId
        Return Me
    End Function

    Public Function withReminderDate(ByVal reminderDate As DateTime) As ReminderBuilder
        _reminderDate = reminderDate
        Return Me
    End Function

    Public Function withSubject(ByVal subject As String) As ReminderBuilder
        _subject = subject
        Return Me
    End Function

    Public Function withBody(ByVal body As String) As ReminderBuilder
        _body = body
        Return Me
    End Function
    Public Function withReminder(ByVal pReminder As String) As ReminderBuilder
        _isReminder = pReminder
        Return Me
    End Function

    Public Function withClosed(ByVal pClosed As Boolean) As ReminderBuilder
        _isClosed = pClosed
        Return Me
    End Function

    Public Function withCustomerId(ByVal pCustomerId As Integer?) As ReminderBuilder
        _customerId = pCustomerId
        Return Me
    End Function

    Public Function withJobId(ByVal pIncidentId As Integer?) As ReminderBuilder
        _jobId = pIncidentId
        Return Me
    End Function

    Public Function withCallBack(ByVal pCallBack As Boolean) As ReminderBuilder
        _callback = pCallBack
        Return Me
    End Function
    Public Function build() As Reminder
        Return New Reminder(_diaryId, _
                            _userId, _
                            _reminderDate, _
                            _subject, _
                            _body, _
                            _isReminder, _
                            _isClosed, _
                            _customerId, _
                            _jobId, _
                            _callback)
    End Function

End Class
