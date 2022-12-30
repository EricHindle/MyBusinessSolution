' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class ReportColumn
    Private _columnName As String
    Private _columnType As String
    Private _columnFormat As String
    Private _columnEncrypted As Boolean
    Private _columnHeading As String
    Private _parentTable As String
    Private _accessLevel As Integer
    Private _reportDefault As Boolean
    Public Sub New(pName As String, pType As String, pFormat As String, pEncrypted As Boolean, pHeading As String, pTable As String, pAccessLevel As Integer, pDefault As Boolean)
        _columnName = pName
        _columnType = pType
        _columnFormat = pFormat
        _columnEncrypted = pEncrypted
        _columnHeading = pHeading
        _parentTable = pTable
        _accessLevel = pAccessLevel
        _reportDefault = pDefault
    End Sub
    Public Property ReportDefault() As Boolean
        Get
            Return _reportDefault
        End Get
        Set(ByVal value As Boolean)
            _reportDefault = value
        End Set
    End Property
    Public Property AccessLevel() As Integer
        Get
            Return _accessLevel
        End Get
        Set(ByVal value As Integer)
            _accessLevel = value
        End Set
    End Property
    Public Property ParentTable() As String
        Get
            Return _parentTable
        End Get
        Set(ByVal value As String)
            _parentTable = value
        End Set
    End Property
    Public Property ColumnHeading() As String
        Get
            Return _columnHeading
        End Get
        Set(ByVal value As String)
            _columnHeading = value
        End Set
    End Property
    Public Property ColumnEncrypted() As Boolean
        Get
            Return _columnEncrypted
        End Get
        Set(ByVal value As Boolean)
            _columnEncrypted = value
        End Set
    End Property
    Public Property ColumnFormat() As String
        Get
            Return _columnFormat
        End Get
        Set(ByVal value As String)
            _columnFormat = value
        End Set
    End Property
    Public Property ColumnType() As String
        Get
            Return _columnType
        End Get
        Set(ByVal value As String)
            _columnType = value
        End Set
    End Property
    Public Property ColumnName() As String
        Get
            Return _columnName
        End Get
        Set(ByVal value As String)
            _columnName = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb.Append(_columnName).Append("~") _
            .Append(_columnType).Append("~") _
            .Append(_columnFormat).Append("~") _
            .Append(CStr(_columnEncrypted)).Append("~") _
            .Append(_columnHeading).Append("~") _
            .Append(_parentTable).Append("~") _
            .Append(CStr(_accessLevel)).Append("~") _
            .Append(CStr(_reportDefault))
        Return sb.ToString
    End Function
End Class
