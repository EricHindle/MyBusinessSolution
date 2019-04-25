Public Class ReportColumnBuilder
    Private _columnName As String
    Private _columnType As String
    Private _columnFormat As String
    Private _columnEncrypted As Boolean
    Private _columnHeading As String
    Private _parentTable As String
    Private _accessLevel As Integer
    Private _reportDefault As Boolean

    Public Shared Function aReportColumn() As ReportColumnBuilder
        Return New ReportColumnBuilder
    End Function

    Public Function startingWith(pReportColumn As ReportColumn) As ReportColumnBuilder
        _columnName = pReportColumn.columnName
        _columnType = pReportColumn.columnType
        _columnFormat = pReportColumn.columnFormat
        _columnEncrypted = pReportColumn.columnEncrypted
        _columnHeading = pReportColumn.columnHeading
        _parentTable = pReportColumn.parentTable
        _accessLevel = pReportColumn.accessLevel
        _reportDefault = pReportColumn.reportDefault
        Return Me
    End Function

    Public Function startingWithNothing() As ReportColumnBuilder
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

    Public Function withName(pColName As String) As ReportColumnBuilder
        _columnName = pColName
        Return Me
    End Function

    Public Function withType(pColType As String) As ReportColumnBuilder
        _columnType = pColType
        Return Me
    End Function

    Public Function withFormat(pColFormat As String) As ReportColumnBuilder
        _columnFormat = pColFormat
        Return Me
    End Function

    Public Function withEncrypted(pColEncrypted As Boolean) As ReportColumnBuilder
        _columnEncrypted = pColEncrypted
        Return Me
    End Function

    Public Function withHeading(pColHeading As String) As ReportColumnBuilder
        _columnHeading = pColHeading
        Return Me
    End Function

    Public Function withTable(pTable As String) As ReportColumnBuilder
        _parentTable = pTable
        Return Me
    End Function

    Public Function withAccessLevel(pAccessLevel As Integer) As ReportColumnBuilder
        _accessLevel = pAccessLevel
        Return Me
    End Function

    Public Function withDefault(pDefault As Boolean) As ReportColumnBuilder
        _reportDefault = pDefault
        Return Me
    End Function

    Public Function build() As ReportColumn
        Return New ReportColumn(_columnName, _columnType, _columnFormat, _columnEncrypted, _columnHeading, _parentTable, _accessLevel, _reportDefault)
    End Function
End Class
