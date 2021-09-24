' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.InteropServices

''' <summary>
''' Report definition
''' </summary>
''' <remarks></remarks>
Public Class ReportDefinition : Implements IDisposable
    Private myReportHead As String
    Private myColumns As ArrayList
    Private myCommandText As String
    Private myTable As String
    Private myParameters As ArrayList
    Private myParameterValues As ArrayList
    Private myTabStops As Single()
    Private myFont As Font
    Private myDetailProcess As System.Windows.Forms.Form
    Private myTimeOut As Integer
    Private myShowCount As Boolean

    Private disposed As Boolean = False
    Private ReadOnly handle As SafeHandle = New SafeFileHandle(IntPtr.Zero, True)

    ''' <summary>
    ''' Initializes a new instance of the ReportDefinition class
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        myColumns = New ArrayList
        myParameters = New ArrayList
        myParameterValues = New ArrayList
        myTable = ""
        myCommandText = ""
        myReportHead = ""
        ' set default font and tabstops
        myTabStops = New Single() {100.0F, 100.0F, 100.0F, 100.0F, 100.0F}
        myFont = New Font("Arial", 10, FontStyle.Regular)
        myShowCount = False
    End Sub

    ''' <summary>
    ''' Should record count be included in the report
    ''' </summary>
    ''' <value></value>
    ''' <returns>True if record count should be included in the report</returns>
    ''' <remarks></remarks>
    Public Property ShowCount() As Boolean
        Get
            Return myShowCount
        End Get
        Set(ByVal value As Boolean)
            myShowCount = value
        End Set
    End Property

    ''' <summary>
    ''' Timeout value to be applied when running the SQL commnad
    ''' </summary>
    ''' <value>Timeout time in seconds</value>
    ''' <returns>Timeout time in seconds</returns>
    ''' <remarks></remarks>
    Public Property TimeOut() As Integer
        Get
            Return myTimeOut
        End Get
        Set(ByVal value As Integer)
            myTimeOut = value
        End Set
    End Property

    ''' <summary>
    ''' Not currently used
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DetailProcess() As System.Windows.Forms.Form
        Get
            Return myDetailProcess
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            myDetailProcess = value
        End Set
    End Property

    ''' <summary>
    ''' Report heading
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReportHead() As String
        Get
            Return myReportHead
        End Get
        Set(ByVal value As String)
            myReportHead = value
        End Set
    End Property

    ''' <summary>
    ''' Array list of the columns in the report
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Columns() As ArrayList
        Get
            Return myColumns
        End Get
        Set(ByVal value As ArrayList)
            myColumns = value
        End Set
    End Property

    ''' <summary>
    ''' Return the name of a column in the report
    ''' </summary>
    ''' <param name="index">Index of the required column</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetColumnName(ByVal index As Int16) As String
        Dim rtnval As String = ""
        If index < myColumns.Count Then
            Dim s As ReportColumn = myColumns(index)
            If s IsNot Nothing Then
                rtnval = s.ColumnName
            End If
        End If
        Return rtnval
    End Function

    ''' <summary>
    ''' Return the heading of a column in the report
    ''' </summary>
    ''' <param name="index">Index of the required column</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetColumnHeading(ByVal index As Int16) As String
        Dim rtnval As String = ""
        If index < myColumns.Count Then
            Dim s As ReportColumn = myColumns(index)
            If s IsNot Nothing Then
                rtnval = s.ColumnHeading
            End If
        End If
        Return rtnval

    End Function

    ''' <summary>
    ''' Return the format of a column in the report
    ''' </summary>
    ''' <param name="index">Index of the required column</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetColumnFormat(ByVal index As Int16) As String
        Dim rtnval As String = Nothing
        If index < myColumns.Count Then
            Dim s As ReportColumn = myColumns(index)
            If s IsNot Nothing Then
                rtnval = s.ColumnFormat
            End If
        End If
        Return rtnval

    End Function

    ''' <summary>
    ''' Return the format of a column in the report
    ''' </summary>
    ''' <param name="index">Index of the required column</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IdColumnEncrypted(ByVal index As Int16) As Boolean
        Dim rtnval As Boolean = False
        If index < myColumns.Count Then
            Dim s As ReportColumn = myColumns(index)
            If s IsNot Nothing Then
                rtnval = s.ColumnEncrypted
            End If
        End If
        Return rtnval
    End Function

    ''' <summary>
    ''' Return the type of contents in a column in the report
    ''' </summary>
    ''' <param name="index">Index of the required column</param>
    ''' <returns>System.Type of the column contents</returns>
    ''' <remarks></remarks>
    Public Function GetColumnType(ByVal index As Int16) As System.Type
        Dim rtnval As System.Type = GetType(String)
        If index < myColumns.Count Then
            Dim s As ReportColumn = myColumns(index)
            rtnval = Type.GetType(s.ColumnType)
        End If
        Return rtnval
    End Function

    ''' <summary>
    ''' SQL command to produce the report
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CommandText() As String
        Get
            Return myCommandText
        End Get
        Set(ByVal value As String)
            myCommandText = value
        End Set
    End Property

    ''' <summary>
    ''' Table name for the results table
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TableName() As String
        Get
            Return myTable
        End Get
        Set(ByVal value As String)
            myTable = value
        End Set
    End Property

    ''' <summary>
    ''' List of Parameter names to be substituted in the SQL
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Parameters() As ArrayList
        Get
            Return myParameters
        End Get
        Set(ByVal value As ArrayList)
            myParameters = value
        End Set
    End Property

    ''' <summary>
    ''' Parameters as an array
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParameterArray() As Object()
        Get
            Return myParameters.ToArray()
        End Get
        Set(ByVal value As Object())
            myParameters.Clear()
            For Each oVal In value
                myParameters.Add(oVal)
            Next
        End Set
    End Property

    ''' <summary>
    ''' List of Parameter values to be substituted into the SQL
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParameterValues() As ArrayList
        Get
            Return myParameterValues
        End Get
        Set(ByVal value As ArrayList)
            myParameterValues = value
        End Set
    End Property

    ''' <summary>
    ''' Parameter values as an array
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParameterValuesArray() As Object()
        Get
            Return myParameterValues.ToArray()
        End Get
        Set(ByVal value As Object())
            myParameterValues.Clear()
            For Each oVal In value
                myParameterValues.Add(oVal)
            Next
        End Set
    End Property

    ''' <summary>
    ''' Return parameter value as a string
    ''' </summary>
    ''' <param name="index">Index of required parameter</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StringParameter(ByVal index) As String
        Dim stringVal As String
        stringVal = TryCast(myParameterValues(index), String)
        Return stringVal
    End Function

    ''' <summary>
    ''' Return parameter value as a date
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns>Index of required parameter</returns>
    ''' <remarks></remarks>
    Public Function DateParameter(ByVal index) As Date
        Dim oDatetime As Date = Nothing
        If IsDate(myParameters(index)) Then
            oDatetime = CDate(myParameterValues(index))
        End If
        Return oDatetime
    End Function

    ''' <summary>
    ''' Return parameter value as an integer
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns>Index of required parameter</returns>
    ''' <remarks></remarks>
    Public Function IntParameter(ByVal index) As Integer
        Dim oInt As Integer = Nothing
        If IsNumeric(myParameters(index)) Then
            oInt = CInt(myParameterValues(index))
        End If
        Return oInt
    End Function

    ''' <summary>
    ''' List of tab stop postions
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TabStops() As Single()
        Get
            Return myTabStops
        End Get
        Set(ByVal value As Single())
            myTabStops = value
        End Set
    End Property

    ''' <summary>
    ''' Font to be used in the report
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Font() As Font
        Get
            Return myFont
        End Get
        Set(ByVal value As Font)
            myFont = value
        End Set
    End Property
    Public Sub Dispose() _
         Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Protected Overridable Sub Dispose(disposing As Boolean)
        If disposed Then Return
        If disposing Then
            handle.Dispose()
            myFont.Dispose()
        End If
        disposed = True
    End Sub
End Class

