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

    Private Shared ReadOnly className As String = "GlobalSettings"
    ''' <summary>
    ''' Get a setting
    ''' </summary>
    ''' <param name="settingName">Name of setting to be returned</param>
    ''' <returns>Value of setting</returns>
    ''' <remarks></remarks>
    Public Shared Function GetSettingValue(ByVal settingName As String) As Object
        LogUtil.Info("Getting global setting " & settingName, className)
        Dim rtnValue As Object = Nothing
        Try
            Dim _setting As GlobalSetting = GetSetting(settingName)
            'Dim i As Integer = oTa.FillById(oTable, settingName)

            If _setting IsNot Nothing Then
                'Dim oRow As netwyrksDataSet.configurationRow = oTable.Rows(0)
                'Dim value As String = oRow.configuration_value
                Try
                    Select Case _setting.ValueType
                        Case GlobalSetting.SettingType.STR
                            rtnValue = _setting.SettingValue
                        Case GlobalSetting.SettingType.INT
                            rtnValue = CInt(_setting.SettingValue)
                        Case GlobalSetting.SettingType.DAT
                            rtnValue = CDate(_setting.SettingValue)
                        Case GlobalSetting.SettingType.BOO
                            rtnValue = CBool(_setting.SettingValue)
                        Case GlobalSetting.SettingType.DEC
                            rtnValue = CDec(_setting.SettingValue)
                        Case GlobalSetting.SettingType.CHA
                            rtnValue = CChar(_setting.SettingValue)
                    End Select
                Catch ex As Exception
                    LogUtil.Exception("Cannot return setting value", ex, "GlobalSettings.getSetting", GetErrorCode(SystemModule.UTILITIES, ErrorType.CONVERSION, FailedAction.GLOBAL_SETTING_ERROR))
                End Try
            Else
                _setting = GlobalSettingBuilder.AGlobalSetting.StartingWithNothing _
                    .WithId(settingName) _
                    .WithType(GlobalSetting.SettingType.STR) _
                    .WithValue("") _
                    .Build
                InsertSetting(_setting)
                rtnValue = ""
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            LogUtil.Exception("Database exception", ex, className, GetErrorCode(SystemModule.SETTINGS, ErrorType.DATABASE, FailedAction.GLOBAL_SETTINGS_EXCEPTION))
            Throw
        End Try
        Return rtnValue
    End Function

    Public Shared Function GetStringSetting(ByVal settingName As String) As String
        Return CStr(GetSettingValue(settingName))
    End Function
    Public Shared Function GetBooleanSetting(ByVal settingName As String) As Boolean
        Dim stringValue As String = GetSettingValue(settingName)
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
        Dim stringValue As String = GetSettingValue(settingName)
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

    Public Shared Function SetSetting(ByVal settingName As String, ByVal valueType As String, ByVal settingValue As String) As Boolean
        RECORD_TYPE = AuditUtil.RecordType.Setting
        Dim rtnVal As Boolean = True
        Dim _setting As GlobalSetting = GlobalSettingBuilder.AGlobalSetting.StartingWithNothing _
                    .WithId(settingName) _
                    .WithType(valueType) _
                    .WithValue(settingValue) _
                    .Build
        If UpdateSetting(_setting) = 1 Then

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
