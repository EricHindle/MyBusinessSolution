
' Copyright (c) 2015, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
' Created Oct 2015

Imports System.ComponentModel
Imports System.Reflection
Imports System.Security.Principal

''' <summary>
''' Utility to assist in the recording of audit information
''' </summary>
''' <remarks></remarks>
Public Class AuditUtil

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

    ''' <summary>
    ''' Add a record to the audit table.
    ''' </summary>
    ''' <remarks>Audit record is assigned to the current user.
    ''' </remarks>
    Public Shared Sub addAudit(ByVal record_type As RecordType, ByVal record_id As String, ByVal auditAction As AuditableAction, Optional ByVal beforeValue As String = Nothing, Optional ByVal afterValue As String = Nothing)
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
    Public Shared Sub addAudit(ByVal userid As Integer, ByVal record_type As RecordType, ByVal record_id As String, ByVal auditAction As AuditableAction, Optional ByVal beforeValue As String = Nothing, Optional ByVal afterValue As String = Nothing)
        Dim oTa As New netwyrksDataSetTableAdapters.auditTableAdapter
        Dim dateChanged As Date = Now
        oTa.InsertAudit(userid, record_type, record_id, Now, auditAction, beforeValue, afterValue, My.Computer.Name)
        oTa.Dispose()
    End Sub
End Class
