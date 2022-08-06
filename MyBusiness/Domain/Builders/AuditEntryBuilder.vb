' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class AuditEntryBuilder
    Private _auditId As Integer
    Private _auditUsercode As String
    Private _recordType As String
    Private _recordId As Integer
    Private _auditDate As DateTime
    Private _action As String
    Private _before As String
    Private _after As String
    Private _computerName As String

    Public Shared Function AnAuditEntry() As AuditEntryBuilder
        Return New AuditEntryBuilder
    End Function
    Public Function StartingWithNothing() As AuditEntryBuilder
        _auditId = -1
        _auditUsercode = ''
        _recordType = ""
        _recordId = -1
        _auditDate = DateTime.MinValue
        _action = ""
        _before = ""
        _after = ""
        _computerName = ""
        Return Me
    End Function
    Public Function StartingWith(_auditEntry As AuditEntry) As AuditEntryBuilder
        With _auditEntry
            _auditId = .AuditId
            _auditUsercode = .AuditUsercode
            _recordType = .RecordType
            _recordId = .RecordId
            _auditDate = .AuditDate
            _action = .Action
            _before = .Before
            _after = .After
            _computerName = .ComputerName
        End With
        Return Me
    End Function
    Public Function StartingWith(_auditRow As netwyrksDataSet.auditRow) As AuditEntryBuilder
        With _auditRow
            _auditId = .audit_id
            _auditUsercode = If(.Isaudit_user_idNull, "", .audit_user_id)
            _recordType = If(.Isaudit_record_typeNull, "", .audit_record_type)
            _recordId = If(.Isaudit_record_idNull, "", .audit_record_id)
            _auditDate = If(.Isaudit_dateNull, New Date(1, 1, 1), .audit_date)
            _action = If(.Isaudit_actionNull, "", .audit_action)
            _before = If(.Isaudit_beforeNull, "", .audit_before)
            _after = If(.Isaudit_afterNull, "", .audit_after)
            _computerName = If(.Isaudit_computer_nameNull, "", .audit_computer_name)
        End With
        Return Me
    End Function
    Public Function WithAuditId(ByVal pAuditId As Integer) As AuditEntryBuilder
        _auditId = pAuditId
        Return Me
    End Function
    Public Function WithUsercode(ByVal pUsercode As String) As AuditEntryBuilder
        _auditUsercode = pUsercode
        Return Me
    End Function

    Public Function WithRecordType(ByVal pRecordType As String) As AuditEntryBuilder
        _recordType = pRecordType
        Return Me
    End Function
    Public Function WithRecordId(ByVal pRecordId As Integer) As AuditEntryBuilder
        _recordId = pRecordId
        Return Me
    End Function
    Public Function WithAuditDate(ByVal pAuditDate As DateTime) As AuditEntryBuilder
        _auditDate = pAuditDate
        Return Me
    End Function
    Public Function WithAction(ByVal pAction As String) As AuditEntryBuilder
        _action = pAction
        Return Me
    End Function
    Public Function WithBefore(ByVal pBefore As String) As AuditEntryBuilder
        _before = pBefore
        Return Me
    End Function
    Public Function WithAfter(ByVal pAfter As String) As AuditEntryBuilder
        _after = pAfter
        Return Me
    End Function
    Public Function WithComputerName(ByVal pComputerName As String) As AuditEntryBuilder
        _computerName = pComputerName
        Return Me
    End Function
    Public Function Build() As AuditEntry
        Return New AuditEntry(
                                _auditId,
                                _auditUsercode,
                                _recordType,
                                _recordId,
                                _auditDate,
                                _action,
                                _before,
                                _after,
                                _computerName)
    End Function
End Class
