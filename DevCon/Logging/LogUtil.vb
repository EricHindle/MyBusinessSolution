
' Copyright (c) 2015, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
' Created Oct 2015

Imports System.IO

''' <summary>
''' Utililty to write messages to a log
''' </summary>
''' <remarks></remarks>
Public Class LogUtil

    Private Shared sApplicationPath As String
    Private Shared _LogFolder As String
    Private Shared isConfigured As Boolean = False
    Private Shared isDebugOn As Boolean

    ''' <summary>
    ''' Set logging options
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub InitialiseLogging()
        If isConfigured = False Then
            sApplicationPath = My.Application.Info.DirectoryPath
            _LogFolder = My.Settings.LogFolder.Replace("<application path>", sApplicationPath)
            My.Computer.FileSystem.CreateDirectory(_LogFolder)
            My.Application.Log.DefaultFileLogWriter.LogFileCreationSchedule = Logging.LogFileCreationScheduleOption.Daily
            My.Application.Log.DefaultFileLogWriter.CustomLocation = _LogFolder
            My.Application.Log.DefaultFileLogWriter.Append = True
            My.Application.Log.DefaultFileLogWriter.AutoFlush = True
            My.Application.Log.DefaultFileLogWriter.ReserveDiskSpace = 50000000
            isConfigured = True
        End If
    End Sub

    ''' <summary>
    ''' Write start message to the log
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StartLogging()
        isDebugOn = My.Settings.TracingOn
        Info("=".PadRight(40, "="))
        Info(My.Application.Info.Title & " version " & My.Application.Info.Version.ToString)
        Info("Logging started at " & Format(Now, "dd/MM/yyyy HH:mm:ss"))
        If isDebugOn Then
            Info("Debug is ON")
        End If
        Dim sConnection As String() = Split(My.Settings.netwyrksConnectionString, ";")
        For Each sString As String In sConnection
            Info(sString)
        Next
    End Sub

    ''' <summary>
    ''' Flush and close the log file
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StopLogging()
        If isConfigured Then
            My.Application.Log.DefaultFileLogWriter.Flush()
            My.Application.Log.DefaultFileLogWriter.Close()
            isConfigured = False
        End If
    End Sub

    ''' <summary>
    ''' add a message to the log file
    ''' </summary>
    ''' <param name="sText">Log message text</param>
    ''' <param name="severity">Log level</param>
    ''' <param name="sSub">Location of error</param>
    ''' <param name="errorCode">SERS Error code</param>
    ''' <param name="padCt">Spaces to pad message depending on log level</param>
    ''' <remarks></remarks>
    Public Shared Sub addLog(ByVal sText As String, Optional ByVal severity As TraceEventType = TraceEventType.Information, Optional ByVal sSub As String = "", Optional ByVal errorCode As String = Nothing, Optional ByRef padCt As Integer = 0)
        InitialiseLogging()
        Dim sPad As String = "".PadRight(padCt)

        Dim usercode As String = "DEV"
        Dim sPrefix As String = sPad & My.Computer.Clock.LocalTime.ToString() & " - " & If(sSub.Length > 0, " (" & sSub & ") ", " ")
        If Not String.IsNullOrEmpty(usercode) Then
            sPrefix += "[user " & usercode & "] "
        End If
        If Not String.IsNullOrEmpty(errorCode) Then
            sPrefix += "Error code: " & errorCode & " "
        End If
        My.Application.Log.WriteEntry(sPrefix & sText, severity)
    End Sub

    ''' <summary>
    ''' Add an exception message to the log file
    ''' </summary>
    ''' <param name="ex">Exception to be logged</param>
    ''' <param name="sText"></param>
    ''' <param name="eventType"></param>
    ''' <param name="sSub"></param>
    ''' <param name="errorCode"></param>
    ''' <param name="padCt"></param>
    ''' <remarks></remarks>
    Public Shared Sub addExceptionLog(ByVal ex As Exception, ByVal sText As String, Optional ByVal eventType As TraceEventType = TraceEventType.Error, Optional ByVal sSub As String = "", Optional ByVal errorCode As String = Nothing, Optional ByRef padCt As Integer = 0)
        InitialiseLogging()
        Dim exMessage As String = If(ex Is Nothing, "no excepion message", ex.Message)
        Dim sErrorText = sText & " : Exception - " & exMessage
        addLog(sErrorText, eventType, sSub, errorCode, padCt)
    End Sub

    ''' <summary>
    ''' Add info message to the log 
    ''' </summary>
    ''' <param name="pStr"></param>
    ''' <param name="psub"></param>
    ''' <remarks></remarks>
    Public Shared Sub Info(ByVal pStr As String, Optional ByVal psub As String = "")
        addLog(pStr, TraceEventType.Information, psub)
    End Sub

    ''' <summary>
    ''' Add warning message to the log
    ''' </summary>
    ''' <param name="pStr"></param>
    ''' <param name="psub"></param>
    ''' <remarks></remarks>
    Public Shared Sub Warn(ByVal pStr As String, Optional ByVal psub As String = "")
        addLog(pStr, TraceEventType.Warning, psub, , 4)
    End Sub

    ''' <summary>
    ''' Add error message to the log
    ''' </summary>
    ''' <param name="pStr"></param>
    ''' <param name="psub"></param>
    ''' <param name="errorCode"></param>
    ''' <remarks></remarks>
    Public Shared Sub Problem(ByVal pStr As String, Optional ByVal psub As String = "", Optional ByVal errorCode As String = Nothing)
        addLog(pStr, TraceEventType.Error, psub, errorCode, 6)
    End Sub

    ''' <summary>
    ''' Add debug message to the log
    ''' </summary>
    ''' <param name="pStr"></param>
    ''' <param name="psub"></param>
    ''' <remarks></remarks>
    Public Shared Sub Debug(ByVal pStr As String, Optional ByVal psub As String = "")
        Dim pad As Integer = 4
        Dim level As TraceEventType = TraceEventType.Verbose
        If isDebugOn Then
            level = TraceEventType.Information
            pad = 0
        End If
        addLog(pStr, level, psub, , pad)
    End Sub

    ''' <summary>
    ''' Add critical message to the log
    ''' </summary>
    ''' <param name="pStr"></param>
    ''' <param name="psub"></param>
    ''' <param name="errorCode"></param>
    ''' <remarks></remarks>
    Public Shared Sub Fatal(ByVal pStr As String, Optional ByVal psub As String = "", Optional ByVal errorCode As String = Nothing)
        addLog(pStr, TraceEventType.Critical, psub, errorCode, 3)
    End Sub

    ''' <summary>
    ''' Add exception error message to the log
    ''' </summary>
    ''' <param name="pStr"></param>
    ''' <param name="pEx"></param>
    ''' <param name="psub"></param>
    ''' <param name="errorCode"></param>
    ''' <remarks></remarks>
    Public Shared Sub Exception(ByVal pStr As String, ByVal pEx As Exception, Optional ByVal psub As String = "", Optional ByVal errorCode As String = Nothing)
        addExceptionLog(pEx, pStr, TraceEventType.Error, psub, errorCode, 6)
    End Sub

    ''' <summary>
    ''' Get the name of the current log file
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getLogfileName() As String
        Return My.Application.Log.DefaultFileLogWriter.FullLogFileName
    End Function

    ''' <summary>
    ''' Empty the current log file
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub ClearLogFile()
        Dim sLogFile As String = getLogfileName()
        My.Application.Log.DefaultFileLogWriter.Close()
        Using sr As New StreamWriter(sLogFile, False)
            sr.Write("")
        End Using
        My.Application.Log.DefaultFileLogWriter.WriteLine("Log file cleared by " & My.User.Name & " on " & Format(Now, "dd/MM/yyyy HH:mm:ss"))
    End Sub

    ''' <summary>
    ''' Read all the text in the current log file
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLogContents() As String
        Dim sLogFile As String = getLogfileName()
        My.Application.Log.DefaultFileLogWriter.Close()
        GetLogContents = My.Computer.FileSystem.ReadAllText(sLogFile)
        My.Application.Log.DefaultFileLogWriter.Write("")
    End Function

End Class
