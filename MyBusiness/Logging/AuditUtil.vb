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
        Dim oTa As New netwyrksDataSetTableAdapters.auditTableAdapter
        Dim userId As Integer = -1
        If TypeOf My.User.CurrentPrincipal.Identity Is netwyrksIIdentity Then
            Dim myIdentity As netwyrksIIdentity = My.User.CurrentPrincipal.Identity
            userId = myIdentity.userId
        End If
        Dim dateChanged As Date = Now
        oTa.InsertAudit(userId, record_type, record_id, Now, auditAction, beforeValue, afterValue, My.Computer.Name)
        oTa.Dispose()
    End Sub
    ''' <summary>
    ''' Add a record to the audit table.
    ''' </summary>
    ''' <remarks>Used for changes made by (e.g.) DB event scripts</remarks>
    Public Shared Sub AddAudit(ByVal userid As Integer, ByVal record_type As RecordType, ByVal record_id As String, ByVal auditAction As AuditableAction, Optional ByVal beforeValue As String = Nothing, Optional ByVal afterValue As String = Nothing)
        Dim oTa As New netwyrksDataSetTableAdapters.auditTableAdapter
        Dim dateChanged As Date = Now
        oTa.InsertAudit(userid, record_type, record_id, Now, auditAction, beforeValue, afterValue, My.Computer.Name)
        oTa.Dispose()
    End Sub
#End Region

End Class
