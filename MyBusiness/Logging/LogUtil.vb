' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Threading

Public Class LogUtil
#Region "properties"
    Private Shared _LogFolder As String
    Private Shared isConfigured As Boolean = False
    Private Shared _isDebugOn As Boolean
    Public Shared Property IsDebugOn() As Boolean
        Get
            Return _isDebugOn
        End Get
        Set(ByVal value As Boolean)
            _isDebugOn = value
        End Set
    End Property
    Public Shared Property LogFolder() As String
        Get
            Return _LogFolder
        End Get
        Set(ByVal value As String)
            _LogFolder = value
        End Set
    End Property
#End Region
#Region "Start / stop"
    Public Shared Sub InitialiseLogging()
        If isConfigured = False Then

            My.Application.Log.DefaultFileLogWriter.LogFileCreationSchedule = Logging.LogFileCreationScheduleOption.Daily
            If _LogFolder IsNot Nothing Then
                My.Application.Log.DefaultFileLogWriter.CustomLocation = _LogFolder
            End If
            My.Application.Log.DefaultFileLogWriter.Append = True
            My.Application.Log.DefaultFileLogWriter.AutoFlush = True
            My.Application.Log.DefaultFileLogWriter.ReserveDiskSpace = 50000000
            isConfigured = True
        End If
    End Sub
    Public Shared Sub StartLogging()
        IsDebugOn = My.Settings.DebugOn
        Info("=".PadRight(40, "="))
        Info(My.Application.Info.Title & " version " & My.Application.Info.Version.ToString)
        Info(My.Application.Info.Copyright)
        Info("Logging started at " & Format(Now, "dd/MM/yyyy HH:mm:ss"))
        If IsDebugOn Then
            Info("Debug : ON")
        End If
        Info("Computer name    : " & My.Computer.Name)
        Info("Application path : " & My.Application.Info.DirectoryPath)
        LogDbDetails()
        Info("-".PadRight(40, "-"))
    End Sub
    Public Shared Sub LogDbDetails()
        Dim sConnection As String() = Split(My.Settings.netwyrksConnectionString, ";")
        Dim serverName As String = ""
        Dim dbName As String = ""
        For Each oConn As String In sConnection
            Dim nvp As String() = Split(oConn, "=")
            If nvp.GetUpperBound(0) = 1 Then
                Select Case nvp(0)
                    Case "server"
                        serverName = nvp(1)
                    Case "database"
                        dbName = nvp(1)
                End Select
            End If
        Next
        Info("Data connection  :")
        Info("   server   = " & serverName)
        Info("   database = " & dbName)
    End Sub
    Public Shared Sub StopLogging()
        If isConfigured Then
            My.Application.Log.DefaultFileLogWriter.Flush()
            My.Application.Log.DefaultFileLogWriter.Close()
            isConfigured = False
        End If
    End Sub
#End Region
#Region "Add log"
    Public Shared Sub AddLog(ByVal sText As String, Optional ByVal severity As TraceEventType = TraceEventType.Information, Optional ByVal sSub As String = "", Optional ByVal errorCode As String = Nothing, Optional ByRef padCt As Integer = 0)
        InitialiseLogging()
        Dim thisThread As String = "{" & Thread.CurrentThread.ManagedThreadId & "} "
        padCt += 6 - thisThread.Length
        Dim sPad As String = "".PadRight(padCt)
        Dim sIdentity As NetwyrksIIdentity = TryCast(My.User.CurrentPrincipal.Identity, NetwyrksIIdentity)
        Dim sIdentityName As String() = Split(My.User.CurrentPrincipal.Identity.Name, "\")

        Dim usercode As String = If(sIdentity Is Nothing, sIdentityName(sIdentityName.GetUpperBound(0)), sIdentity.Usercode)
        Dim sPrefix As String = sPad & thisThread & My.Computer.Clock.LocalTime.ToString() & " - "
        If Not String.IsNullOrEmpty(usercode) Then
            sPrefix += "[user " & usercode & "] "
        End If
        Dim sOrigin As String = " "
        If Not String.IsNullOrEmpty(sSub) Then
            sOrigin = "(" & sSub & ") "
        End If
        sPrefix += sOrigin.PadRight(My.Resources.ORIGIN_WIDTH)
        If Not String.IsNullOrEmpty(errorCode) Then
            sPrefix += "Error code: " & errorCode & " "
        End If
        My.Application.Log.WriteEntry(sPrefix & sText, severity)
    End Sub
    Public Shared Sub AddExceptionLog(ByVal ex As Exception, ByVal sText As String, Optional ByVal eventType As TraceEventType = TraceEventType.Error, Optional ByVal sSub As String = "", Optional ByVal errorCode As String = Nothing, Optional ByRef padCt As Integer = 0)
        InitialiseLogging()
        Dim exMessage As String = If(ex Is Nothing, "no excepion message", ex.Message)
        Dim sErrorText = sText & " : Exception - " & exMessage
        AddLog(sErrorText, eventType, sSub, errorCode, padCt)
    End Sub
    Public Shared Sub Info(ByVal pStr As String, Optional ByVal psub As String = "")
        addLog(pStr, TraceEventType.Information, psub)
    End Sub
    Public Shared Sub Warn(ByVal pStr As String, Optional ByVal psub As String = "")
        addLog(pStr, TraceEventType.Warning, psub, , 4)
    End Sub
    Public Shared Sub Problem(ByVal pStr As String, Optional ByVal psub As String = "", Optional ByVal errorCode As String = Nothing)
        addLog(pStr, TraceEventType.Error, psub, errorCode, 6)
    End Sub
    Public Shared Sub Debug(ByVal pStr As String, Optional ByVal psub As String = "")
        Dim pad As Integer = 4
        Dim level As TraceEventType = TraceEventType.Verbose
        If isDebugOn Then
            level = TraceEventType.Information
            pad = 0
        End If
        addLog(pStr, level, psub, , pad)
    End Sub
    Public Shared Sub Fatal(ByVal pStr As String, Optional ByVal psub As String = "", Optional ByVal errorCode As String = Nothing)
        addLog(pStr, TraceEventType.Critical, psub, errorCode, 3)
    End Sub
    Public Shared Sub Exception(ByVal pStr As String, ByVal pEx As Exception, Optional ByVal psub As String = "", Optional ByVal errorCode As String = Nothing)
        addExceptionLog(pEx, pStr, TraceEventType.Error, psub, errorCode, 6)
    End Sub
#End Region
#Region "Log file"
    Public Shared Function GetLogfileName() As String
        Return My.Application.Log.DefaultFileLogWriter.FullLogFileName
    End Function
    Public Shared Function GetLogfileName(newDate As Date) As String
        Return Path.Combine(LogUtil.LogFolder, My.Application.Log.DefaultFileLogWriter.BaseFileName & "-" & Format(newDate, "yyyy-MM-dd") & ".log")
    End Function
    Public Shared Sub ClearLogFile()
        Dim sLogFile As String = getLogfileName()
        My.Application.Log.DefaultFileLogWriter.Close()
        Using sr As New StreamWriter(sLogFile, False)
            sr.Write("")
        End Using
        My.Application.Log.DefaultFileLogWriter.WriteLine("Log file cleared by " & My.User.Name & " on " & Format(Now, "dd/MM/yyyy HH:mm:ss"))
    End Sub
    Public Shared Function GetLogContents() As String
        Dim sLogFile As String = getLogfileName()
        My.Application.Log.DefaultFileLogWriter.Close()
        GetLogContents = My.Computer.FileSystem.ReadAllText(sLogFile)
        My.Application.Log.DefaultFileLogWriter.Write("")
    End Function
    'Public Shared Function SendLogFileToSupport() As Boolean
    '    Dim isSent As Boolean = False
    '    Dim oSupportAddress As String = GlobalSettings.getSetting("SupportEmail")
    '    Dim oSupportAddresses As String() = EmailUtil.MakeEmailAddressList(oSupportAddress)

    '    Dim userId As Integer = currentUser.userId
    '    Dim fromAddress As String = ""
    '    Dim tempLogFile As String = Path.Combine(sTempFolder, Path.GetFileName(LogUtil.getLogfileName))

    '    Dim aSenders As String() = EmailUtil.getEmailsenders
    '        Dim _sender As String = ""
    '        If aSenders.Length > 0 Then
    '            _sender = aSenders(0)
    '        End If
    '        fromAddress = If(My.Settings.SMTPUsername = "", _sender, My.Settings.SMTPUsername)

    '    If oSupportAddresses.Length > 0 Then
    '        Try
    '            If My.Computer.FileSystem.FileExists(tempLogFile) Then My.Computer.FileSystem.DeleteFile(tempLogFile)
    '            My.Computer.FileSystem.CopyFile(LogUtil.getLogfileName, tempLogFile)
    '            If EmailUtil.SendMail(oSupportAddresses, New String() {}, "Logfile contents", "See attached", tempLogFile, False, fromAddress, True) Then
    '                isSent = True
    '                LogUtil.Info("Log file sent to support at " & oSupportAddress, "SendLogFileToSupport")
    '            End If
    '            '   My.Computer.FileSystem.DeleteFile(tempLogFile)
    '        Catch ex As Exception
    '            isSent = False
    '            LogUtil.Exception("Failed to send log", ex, "SendLogFileToSupport")
    '        End Try
    '    Else
    '        MsgBox("No support address found", MsgBoxStyle.Exclamation, "Error")
    '    End If
    '    Return isSent
    'End Function
#End Region
End Class
