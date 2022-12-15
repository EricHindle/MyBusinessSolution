' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class ReportColumnBuilder
    Private _columnName As String
    Private _columnType As String
    Private _columnFormat As String
    Private _columnEncrypted As Boolean
    Private _columnHeading As String
    Private _parentTable As String
    Private _accessLevel As Integer
    Private _reportDefault As Boolean
    Public Shared Function AReportColumn() As ReportColumnBuilder
        Return New ReportColumnBuilder
    End Function
    Public Function StartingWith(pReportColumn As ReportColumn) As ReportColumnBuilder
        _columnName = pReportColumn.ColumnName
        _columnType = pReportColumn.ColumnType
        _columnFormat = pReportColumn.ColumnFormat
        _columnEncrypted = pReportColumn.ColumnEncrypted
        _columnHeading = pReportColumn.ColumnHeading
        _parentTable = pReportColumn.ParentTable
        _accessLevel = pReportColumn.AccessLevel
        _reportDefault = pReportColumn.ReportDefault
        Return Me
    End Function
    Public Function StartingWithNothing() As ReportColumnBuilder
        _columnName = ""
        _columnType = "System.String"
        _columnFormat = ""
        _columnEncrypted = False
        _columnHeading = ""
        _parentTable = ""
        _accessLevel = 0
        _reportDefault = False
        Return Me
    End Function
    Public Function WithName(pColName As String) As ReportColumnBuilder
        _columnName = pColName
        Return Me
    End Function
    Public Function WithType(pColType As String) As ReportColumnBuilder
        _columnType = pColType
        Return Me
    End Function
    Public Function WithFormat(pColFormat As String) As ReportColumnBuilder
        _columnFormat = pColFormat
        Return Me
    End Function
    Public Function WithEncrypted(pColEncrypted As Boolean) As ReportColumnBuilder
        _columnEncrypted = pColEncrypted
        Return Me
    End Function
    Public Function WithHeading(pColHeading As String) As ReportColumnBuilder
        _columnHeading = pColHeading
        Return Me
    End Function
    Public Function WithTable(pTable As String) As ReportColumnBuilder
        _parentTable = pTable
        Return Me
    End Function
    Public Function WithAccessLevel(pAccessLevel As Integer) As ReportColumnBuilder
        _accessLevel = pAccessLevel
        Return Me
    End Function
    Public Function WithDefault(pDefault As Boolean) As ReportColumnBuilder
        _reportDefault = pDefault
        Return Me
    End Function
    Public Function Build() As ReportColumn
        Return New ReportColumn(_columnName, _columnType, _columnFormat, _columnEncrypted, _columnHeading, _parentTable, _accessLevel, _reportDefault)
    End Function
End Class
