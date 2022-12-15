' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class AuditEntry
    Private _auditId As Integer
    Private _auditUsercode As String
    Private _recordType As String
    Private _recordId As Integer
    Private _auditDate As DateTime
    Private _action As String
    Private _before As String
    Private _after As String
    Private _computerName As String
    Public Property ComputerName() As String
        Get
            Return _computerName
        End Get
        Set(ByVal value As String)
            _computerName = value
        End Set
    End Property
    Public Property After() As String
        Get
            Return _after
        End Get
        Set(ByVal value As String)
            _after = value
        End Set
    End Property
    Public Property Before() As String
        Get
            Return _before
        End Get
        Set(ByVal value As String)
            _before = value
        End Set
    End Property
    Public Property Action() As String
        Get
            Return _action
        End Get
        Set(ByVal value As String)
            _action = value
        End Set
    End Property
    Public Property AuditDate() As DateTime
        Get
            Return _auditDate
        End Get
        Set(ByVal value As DateTime)
            _auditDate = value
        End Set
    End Property
    Public Property RecordId() As Integer
        Get
            Return _recordId
        End Get
        Set(ByVal value As Integer)
            _recordId = value
        End Set
    End Property
    Public Property RecordType() As String
        Get
            Return _recordType
        End Get
        Set(ByVal value As String)
            _recordType = value
        End Set
    End Property
    Public Property AuditUsercode() As String
        Get
            Return _auditUsercode
        End Get
        Set(ByVal value As String)
            _auditUsercode = value
        End Set
    End Property
    Public Property AuditId() As Integer
        Get
            Return _auditId
        End Get
        Set(ByVal value As Integer)
            _auditId = value
        End Set
    End Property
    Public Sub New(pauditId As Integer,
                    pauditUser As String,
                    precordType As String,
                    precordId As Integer,
                    pauditDate As DateTime,
                    paction As String,
                    pbefore As String,
                    pafter As String,
                    pcomputerName As String)
        _auditId = pauditId
        _auditUsercode = pauditUser
        _recordType = precordType
        _recordId = precordId
        _auditDate = pauditDate
        _action = paction
        _before = pbefore
        _after = pafter
        _computerName = pcomputerName
    End Sub
End Class
