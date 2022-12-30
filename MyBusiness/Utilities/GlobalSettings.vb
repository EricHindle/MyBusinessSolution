' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports MyBusiness.NetwyrksErrorCodes

''' <summary>
''' Options and settings to be used by all users
''' </summary>
''' <remarks></remarks>
Public Class GlobalSettings
    Public Const COMPANY_NAME As String = "companyname"
    Public Const PERSONAL_FOLDERS As String = "personalfolders"
    Public Const COMPANY_ADDRESS As String = "companyaddress"
    Public Const COMPANY_EMAIL As String = "companyemail"
    Public Const COMPANY_WEBSITE As String = "companyurl"
    Public Const COMPANY_LOGOFILE As String = "companylogofile"

    Public Const INVOICE_NUMBER As String = "invoicenumber"

    Private Shared RECORD_TYPE As AuditUtil.RecordType

    Private Shared ReadOnly oTa As New netwyrksDataSetTableAdapters.configurationTableAdapter
    Private Shared ReadOnly oTable As New netwyrksDataSet.configurationDataTable
    Private Shared ReadOnly className As String = "GlobalSettings"
    ''' <summary>
    ''' Get a setting
    ''' </summary>
    ''' <param name="settingName">Name of setting to be returned</param>
    ''' <returns>Value of setting</returns>
    ''' <remarks></remarks>
    Public Shared Function GetSetting(ByVal settingName As String) As Object
        Dim rtnValue As Object = Nothing
        Try
            Dim i As Integer = oTa.FillById(oTable, settingName)

            If i = 1 Then
                Dim oRow As netwyrksDataSet.configurationRow = oTable.Rows(0)
                Dim value As String = oRow.configuration_value
                Try
                    Select Case oRow.configuration_type.ToLower
                        Case "string"
                            rtnValue = value
                        Case "integer"
                            rtnValue = CInt(value)
                        Case "date"
                            rtnValue = CDate(value)
                        Case "boolean"
                            rtnValue = CBool(value)
                        Case "decimal"
                            rtnValue = CDec(value)
                        Case "char"
                            rtnValue = CChar(value)
                    End Select
                Catch ex As Exception
                    LogUtil.Exception("Cannot return setting value", ex, "GlobalSettings.getSetting", GetErrorCode(SystemModule.UTILITIES, ErrorType.CONVERSION, FailedAction.GLOBAL_SETTING_ERROR))
                End Try
            Else
                oTa.InsertSetting(settingName, "string", "")
                rtnValue = ""
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            LogUtil.Exception("Database exception", ex, className, GetErrorCode(SystemModule.SETTINGS, ErrorType.DATABASE, FailedAction.GLOBAL_SETTINGS_EXCEPTION))
            Throw
        End Try
        Return rtnValue
    End Function

    Public Shared Function GetStringSetting(ByVal settingName As String) As String
        Return CStr(GetSetting(settingName))
    End Function
    Public Shared Function GetBooleanSetting(ByVal settingName As String) As Boolean
        Dim stringValue As String = GetSetting(settingName)
        Dim booleanValue As Boolean = False
        Try
            If stringValue IsNot Nothing Then
                booleanValue = CBool(stringValue)
            End If
        Catch ex As Exception
            booleanValue = False
        End Try
        Return booleanValue
    End Function
    Public Shared Function GetIntegerSetting(ByVal settingName As String) As Integer
        Dim stringValue As String = GetSetting(settingName)
        Dim intValue As Integer = 0
        Try
            If stringValue IsNot Nothing AndAlso IsNumeric(stringValue) Then
                intValue = CInt(stringValue)
            End If
        Catch ex As Exception
            intValue = 0
        End Try

        Return intValue
    End Function

    Public Shared Function SetSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String) As Boolean
        RECORD_TYPE = AuditUtil.RecordType.Setting
        Dim rtnVal As Boolean = True
        Dim ct As Integer
        Try
            ct = oTa.UpdateSetting(settingType, settingValue, settingName)
        Catch ex As Exception
            LogUtil.Exception("Update exception", ex, className, GetErrorCode(SystemModule.UTILITIES, ErrorType.DATABASE, FailedAction.UPDATE_EXCEPTION))
            ct = 0
            rtnVal = False
        End Try
        If ct = 1 Then
            AuditUtil.AddAudit(RECORD_TYPE, -1, AuditUtil.AuditableAction.update,, settingValue)
            LogUtil.Info(RECORD_TYPE.ToString() & " " & settingName & " updated", True)
        Else
            LogUtil.Problem(RECORD_TYPE.ToString() & " " & settingName & " NOT updated", GetErrorCode(SystemModule.UTILITIES, ErrorType.DATABASE, FailedAction.UPDATE_EXCEPTION))
            rtnVal = False
        End If
        Return rtnVal
    End Function

    Public Shared Sub LoadGlobalSettings()

    End Sub

End Class
