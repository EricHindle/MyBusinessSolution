﻿'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports MyBusiness.netwyrksErrorCodes
Imports Microsoft.Office.Interop

''' <summary>
''' Globally available functions
''' </summary>
''' <remarks></remarks>
Public Module netwyrksCommon
#Region "Constants"
    Public Const SELECT_TEXT As String = "Select..."
    Public PeriodDescriptions As String() = New String() _
            {SELECT_TEXT, _
                 "All", _
                 "Yesterday", _
                 "Current Week", _
                 "Last Week", _
                 "Last 7 days", _
                 "Last 30 days", _
                 "Current Month", _
                 "Last Month", _
                 "Current Quarter", _
                 "Last Quarter", _
                 "Current Year", _
                 "Next 12 Months", _
                 "Last 5 Years"}
    Public RECORD_TYPE As String = ""
#End Region
#Region "Structures"
    ''' <summary>
    ''' Defines a start and end date
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure DateRange
        Public fromDate As Date
        Public toDate As Date
    End Structure
#End Region
#Region "current user"
    Public _companyName As String = ""
    Public currentUser As User = UserBuilder.aUserBuilder.startingWithNothing().build
    Public isAdmin As Boolean = False
    Public isManager As Boolean = False
    Public isExecutive As Boolean = False
    Public isOperator As Boolean = False
    Public isGuest As Boolean = False
    ''' <summary>
    ''' Set global flags to show current user's role(s)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub setUserRoles()
        isAdmin = My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator)
        isManager = My.User.IsInRole(ApplicationServices.BuiltInRole.PowerUser) Or isAdmin
        isExecutive = My.User.IsInRole(ApplicationServices.BuiltInRole.User) Or isManager
        isOperator = My.User.IsInRole(ApplicationServices.BuiltInRole.PrintOperator) Or isExecutive
        isGuest = My.User.IsInRole(ApplicationServices.BuiltInRole.Guest) Or isOperator

        If isAdmin Then LogUtil.Debug("Is Admin")
        If isManager Then LogUtil.Debug("Is Manager")
        If isExecutive Then LogUtil.Debug("Is Executive")
        If isOperator Then LogUtil.Debug("Is Operator")
        If isGuest Then LogUtil.Debug("Is Guest")

    End Sub
#End Region
#Region "Folders"
    Public sApplicationPath As String
    Public sTempFolder As String
    Public sReportFolder As String
    Public sLogFolder As String
    Public sCacheFolder As String

    ''' <summary>
    ''' Set standard folder names from personal settings
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub setFolderNames()
        sApplicationPath = My.Application.Info.DirectoryPath

        If String.IsNullOrEmpty(My.Settings.CacheFolder) Then
            My.Settings.CacheFolder = "<application path>" & Path.DirectorySeparatorChar & "Cache"
        End If
        sCacheFolder = My.Settings.CacheFolder.Replace("<application path>", sApplicationPath)

        If String.IsNullOrEmpty(My.Settings.TempFolder) Then
            My.Settings.TempFolder = "<application path>" & Path.DirectorySeparatorChar & "Temp"
        End If
        sTempFolder = My.Settings.TempFolder.Replace("<application path>", sApplicationPath)

        If String.IsNullOrEmpty(My.Settings.ReportFolder) Then
            My.Settings.ReportFolder = "<application path>" & Path.DirectorySeparatorChar & "Report"
        End If
        sReportFolder = My.Settings.ReportFolder.Replace("<application path>", sApplicationPath)

        If String.IsNullOrEmpty(My.Settings.LogFolder) Then
            My.Settings.LogFolder = "<application path>" & Path.DirectorySeparatorChar & "Log"
        End If
        sLogFolder = My.Settings.LogFolder.Replace("<application path>", sApplicationPath)

    End Sub


    ''' <summary>
    ''' Set file paths for the current user to avoid conflicts under Citrix
    ''' </summary>
    ''' <remarks>
    ''' Note. If different SERS users log in to Windows with the same credentials (very bad practice)
    '''       a new user code will be added to the paths each time and the folder structure could get bigger and bigger.
    '''       A warning message will be displayed when this happens.
    '''       The paths can be corrected in preferences. </remarks>
    Public Sub SetPersonalisedFolderNames()
        Dim userId As String = CStr(currentUser.user_code)
        Dim isPathChanged As Boolean = False
        If userId.Length > 0 Then
            If Not My.Settings.TempFolder.ToLower.EndsWith(userId) Then
                My.Settings.TempFolder = My.Settings.TempFolder & Path.DirectorySeparatorChar & userId
                isPathChanged = True
            End If

            If Not My.Settings.LogFolder.ToLower.EndsWith(userId) Then
                My.Settings.LogFolder = My.Settings.LogFolder & Path.DirectorySeparatorChar & userId
                isPathChanged = True
            End If

            If Not String.IsNullOrEmpty(My.Settings.CacheFolder) AndAlso Not My.Settings.CacheFolder.ToLower.EndsWith(userId) Then
                My.Settings.CacheFolder = My.Settings.CacheFolder & Path.DirectorySeparatorChar & userId
                isPathChanged = True
            End If

            My.Settings.Save()
        End If

        setFolderNames()
        createMissingFolders()
        If isPathChanged Then
            ' This warning message will be displayed the first time that a user logs in. This is normal.
            MsgBox("New personal folders have been created" & vbCrLf & "Check your folder preferences", MsgBoxStyle.Information, "For information")
        End If
    End Sub

    ''' <summary>
    ''' Create any missing standard folders
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub createMissingFolders()
        My.Computer.FileSystem.CreateDirectory(sLogFolder)
        My.Computer.FileSystem.CreateDirectory(sTempFolder)
        My.Computer.FileSystem.CreateDirectory(sReportFolder)
        My.Computer.FileSystem.CreateDirectory(sCacheFolder)
    End Sub
#End Region
#Region "cache"
    Public Enum CacheType
        Image
        Attachment
        Temp
        All
    End Enum

    ''' <summary>
    ''' Clear files from the image/attachment/temporary cache folders
    ''' </summary>
    ''' <param name="retention">minimum number of days to retain files</param>
    ''' <param name="type">type of cache to be cleared</param>
    ''' <remarks></remarks>
    Public Sub ClearCache(ByVal retention As Integer, ByVal type As CacheType)
        Dim sFilePattern As String = "*.*"
        Dim sFolder As String
        If type = CacheType.Temp Or type = CacheType.All Then
            LogUtil.Info("Clearing temporary file cache", "ClearCache")
            sFolder = My.Settings.TempFolder.Replace("<application path>", My.Application.Info.DirectoryPath)
            TidyFiles(sFolder, sFilePattern, retention, True)
        End If

    End Sub

    ''' <summary>
    ''' Delete files from a folder (and optionally sub-folders) depending on a filename pattern and retention period
    ''' </summary>
    ''' <param name="sFolder">Folder name</param>
    ''' <param name="sPattern">Filename pattern</param>
    ''' <param name="iRetain">Retention period in days</param>
    ''' <param name="bSubfolders">True if sub-folders should be searched for matching files</param>
    ''' <remarks>Read-only, hidden and system files are not removed. Folders are not removed. </remarks>
    Public Sub TidyFiles(ByVal sFolder As String, ByVal sPattern As String, ByVal iRetain As Integer, Optional ByVal bSubfolders As Boolean = False)
        Dim oDirInfo As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(sFolder)
        LogUtil.Info("Tidying files in " & sFolder & " older than " & iRetain & " days", "TidyFiles")
        Try
            Dim oFileList As FileInfo() = oDirInfo.GetFiles(sPattern, If(bSubfolders, SearchOption.AllDirectories, SearchOption.TopDirectoryOnly))

            For Each oFileInfo As FileInfo In oFileList
                If (oFileInfo.Attributes And FileAttributes.ReadOnly) = 0 _
                       And (oFileInfo.Attributes And FileAttributes.Hidden) = 0 _
                       And (oFileInfo.Attributes And FileAttributes.System) = 0 _
                       And (oFileInfo.Attributes And FileAttributes.Directory) = 0 Then
                    Dim oDate As Date = oFileInfo.LastWriteTime
                    Dim iDaysOld As Integer = DateDiff("d", oDate, Now)
                    If iDaysOld >= iRetain Then
                        Try
                            My.Computer.FileSystem.DeleteFile(oFileInfo.FullName)
                            LogUtil.Info(oFileInfo.Name & " - " & CStr(iDaysOld) & " days old - deleted", "TidyFiles")
                        Catch ex As Exception
                            '      MsgBox("Unable to remove " & oFileInfo.FullName, MsgBoxStyle.Exclamation, "File Deletion Error")
                            LogUtil.Exception("Unable to remove " & oFileInfo.FullName, ex, "TidyFiles", getErrorCode(SystemModule.UTILITIES, ErrorType.FILESYSTEM, FailedAction.ERROR_DELETING_FILE))
                        End Try
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("Problem tidying files:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "File Error")
            LogUtil.Exception("Problem tidying files", ex, "TidyFiles", getErrorCode(SystemModule.UTILITIES, ErrorType.FILESYSTEM, FailedAction.ERROR_DELETING_FILE))
        End Try
    End Sub
#End Region
#Region "Utilities"

    Public prtUtil As New PrintUtil

    Public Sub SetRowColours(ByRef oRow As DataGridViewRow, ByVal forecolor As Color, ByVal backcolor As Color)
        oRow.DefaultCellStyle.ForeColor = forecolor
        oRow.DefaultCellStyle.BackColor = backcolor
    End Sub

    Public Function setDateRange(ByVal indx As Integer) As DateRange
        Dim oRange As DateRange
        Dim d As Int16 = Today.DayOfWeek
        Dim d1 As Int16 = Today.Day
        Dim dinm As Int16 = Date.DaysInMonth(Today.Year, Today.Month)
        Dim dinlm As Int16 = Date.DaysInMonth(Today.AddMonths(-1).Year, Today.AddMonths(-1).Month)
        Dim thisQuarterNum As Integer = (Today.Month - 1) \ 3 + 1
        Dim lastQuarterNum As Integer = (Today.Month - 1) \ 3

        oRange.fromDate = Today
        oRange.toDate = Today
        Select Case indx
            Case 0  '   Today
            Case 1  '   All
                oRange.fromDate = CDate("01-01-1900")
                oRange.toDate = Today
            Case 2  '   Yesterday
                oRange.fromDate = Today.AddDays(-1)
                oRange.toDate = Today.AddDays(-1)
            Case 3  '   Current Week
                oRange.fromDate = Today.AddDays(-d)
                oRange.toDate = Today.AddDays(6 - d)
            Case 4  '   Last Week
                oRange.fromDate = Today.AddDays(-d - 7)
                oRange.toDate = Today.AddDays(-d - 1)
            Case 5  '   Last 7 days
                oRange.fromDate = Today.AddDays(-6)
                oRange.toDate = Today
            Case 6  '   Last 15 days
                oRange.fromDate = Today.AddDays(-29)
                oRange.toDate = Today
            Case 7  '   Current Month
                oRange.fromDate = DateSerial(Today.Year, Today.Month, 1)
                oRange.toDate = DateSerial(Today.Year, Today.Month + 1, 0)
            Case 8  '   Last Month
                oRange.fromDate = DateSerial(Today.Year, Today.Month - 1, 1)
                oRange.toDate = DateSerial(Today.Year, Today.Month, 0)
            Case 9 '   Current Quarter
                oRange.fromDate = DateSerial(Today.Year, 3 * thisQuarterNum - 2, 1)
                oRange.toDate = DateSerial(Today.Year, 3 * thisQuarterNum + 1, 0)
            Case 10 '   Last Quarter
                oRange.fromDate = DateSerial(Today.Year, 3 * lastQuarterNum - 2, 1)
                oRange.toDate = DateSerial(Today.Year, 3 * lastQuarterNum + 1, 0)
            Case 11 '   Current Year
                oRange.fromDate = New Date(Today.Year, 1, 1)
                oRange.toDate = New Date(Today.Year, 12, 31)
            Case 12 '   Next 12 months
                oRange.fromDate = Today
                oRange.toDate = DateAdd(DateInterval.Month, 12, Today.Date)
            Case 13 '   Last 5 Years
                oRange.fromDate = New Date(Today.Year - 5, Today.Month, Today.Day)
                oRange.toDate = Today
            Case Else

        End Select

        Return oRange
    End Function

    Public Sub setDateControlRange(ByVal oRange As DateRange, ByRef dtpSelectFromDate As DateTimePicker, ByRef dtpSelectToDate As DateTimePicker)
        If oRange.fromDate >= dtpSelectFromDate.MinDate Then
            If oRange.fromDate <= dtpSelectFromDate.MaxDate Then
                dtpSelectFromDate.Value = oRange.fromDate
            Else
                dtpSelectFromDate.Value = dtpSelectFromDate.MaxDate
            End If
        Else
            dtpSelectFromDate.Value = dtpSelectFromDate.MinDate
        End If
        If oRange.toDate >= dtpSelectToDate.MinDate Then
            If oRange.toDate <= dtpSelectToDate.MaxDate Then
                dtpSelectToDate.Value = oRange.toDate
            Else
                dtpSelectToDate.Value = dtpSelectToDate.MaxDate
            End If
        Else
            dtpSelectToDate.Value = dtpSelectToDate.MinDate
        End If
    End Sub

    Public Sub splashMessage(ByVal message As String, Optional ByVal lifeTime As Integer = 2000)
        Using _splash As New frmInfoSplash
            With _splash
                .Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - .Width) / 2, _
                                        (Screen.PrimaryScreen.WorkingArea.Height - .Height) / 2)
                .LifeTime = lifeTime
                .Message = message
                .ShowDialog()
            End With
        End Using
    End Sub

    Private splash As frmInfoSplash

    Public Sub showSplash(ByVal sMessage As String, ByVal oParentSize As Size, ByVal oParentLocation As Point)
        splash = New frmInfoSplash
        With splash
            .Message = sMessage
            If oParentSize.IsEmpty Then
                .Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - .Width) / 2, _
                                            (Screen.PrimaryScreen.WorkingArea.Height - .Height) / 2)
            Else
                .Location = New Point(oParentLocation.X + ((oParentSize.Width - .Width) / 2), oParentLocation.Y + ((oParentSize.Height - .Height) / 2))
            End If
            .Show()
            .Refresh()
        End With
    End Sub

    Public Sub showSplash(ByVal sMessage As String)
        showSplash(sMessage, New Size(0, 0), New Point(0, 0))
    End Sub

    Public Sub closeSplash()
        splash.Close()
        splash.Dispose()
    End Sub

    Public Sub showStatus(ByRef oStatusLabel As Windows.Forms.ToolStripStatusLabel, ByVal sText As String, Optional ByRef oFormName As String = "", Optional ByVal isLogged As Boolean = False)
        oStatusLabel.Text = sText
        If isLogged Then LogUtil.Debug(sText, oFormName)
    End Sub

#End Region
End Module
