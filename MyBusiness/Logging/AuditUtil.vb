' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

''' <summary>
''' Utility to assist in the recording of audit information
''' </summary>
''' <remarks></remarks>
Public Class AuditUtil
#Region "enum"
    Public Enum RecordType
        Customer
        Job
        Task
        Supplier
        Product
        Logging
        User
        Setting
        Reminder
        JobProduct
    End Enum
    Public Enum AuditableAction
        create
        read
        update
        delete
        login
        logout
    End Enum
#End Region
#Region "subroutines"
    ''' <summary>
    ''' Add a record to the audit table.
    ''' </summary>
    ''' <remarks>Audit record is assigned to the current user.
    ''' </remarks>
    Public Shared Sub AddAudit(ByVal record_type As RecordType, ByVal record_id As String, ByVal auditAction As AuditableAction, Optional ByVal beforeValue As String = Nothing, Optional ByVal afterValue As String = Nothing)
        Dim userCode As String = ""
        If TypeOf My.User.CurrentPrincipal.Identity Is NetwyrksIIdentity Then
            Dim myIdentity As NetwyrksIIdentity = My.User.CurrentPrincipal.Identity
            userCode = myIdentity.Usercode
        End If
        Dim dateChanged As Date = Now
        Dim _audit As AuditEntry = AuditEntryBuilder.AnAuditEntry.StartingWithNothing _
            .WithUsercode(userCode) _
            .WithRecordType(record_type.ToString) _
            .WithRecordId(record_id) _
            .WithAuditDate(dateChanged) _
            .WithAction(auditAction.ToString) _
            .WithBefore(beforeValue) _
            .WithAfter(afterValue) _
            .WithComputerName(My.Computer.Name).Build

        InsertAudit(_audit)
    End Sub
    ''' <summary>
    ''' Add a record to the audit table.
    ''' </summary>
    ''' <remarks>Used for changes made by (e.g.) DB event scripts</remarks>
    Public Shared Sub AddAudit(ByVal usercode As String, ByVal record_type As RecordType, ByVal record_id As String, ByVal auditAction As AuditableAction, Optional ByVal beforeValue As String = Nothing, Optional ByVal afterValue As String = Nothing)
        Dim dateChanged As Date = Now
        Dim _audit As AuditEntry = AuditEntryBuilder.AnAuditEntry.StartingWithNothing _
                .WithUsercode(usercode) _
                .WithRecordType(record_type.ToString) _
                .WithRecordId(record_id) _
                .WithAuditDate(dateChanged) _
                .WithAction(auditAction.ToString) _
                .WithBefore(beforeValue) _
                .WithAfter(afterValue) _
                .WithComputerName(My.Computer.Name).Build

        InsertAudit(_audit)
    End Sub
#End Region

End Class
