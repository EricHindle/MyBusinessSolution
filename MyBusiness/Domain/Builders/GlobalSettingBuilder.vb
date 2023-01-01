' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class GlobalSettingBuilder
    Private _settingId As String
    Private _settingType As GlobalSetting.SettingType
    Private _settingValue As String

    Public Shared Function AGlobalSetting() As GlobalSettingBuilder
        Return New GlobalSettingBuilder
    End Function
    Public Function StartingWithNothing() As GlobalSettingBuilder
        _settingValue = ""
        _settingType = GlobalSetting.SettingType.STR
        _settingId = ""
        Return Me
    End Function
    Public Function StartingWith(oRow As netwyrksDataSet.configurationRow) As GlobalSettingBuilder
        _settingId = oRow.configuration_id
        _settingType = oRow.configuration_type
        _settingValue = oRow.configuration_value
        Return Me
    End Function
    Public Function StartingWith(pId As String, pType As GlobalSetting.SettingType, pValue As String) As GlobalSettingBuilder
        _settingId = pId
        _settingType = pType
        _settingValue = pValue
        Return Me
    End Function
    Public Function WithId(pId As String) As GlobalSettingBuilder
        _settingId = pId
        Return Me
    End Function
    Public Function WithType(pType As GlobalSetting.SettingType) As GlobalSettingBuilder
        _settingType = pType
        Return Me
    End Function
    Public Function WithValue(pValue As String) As GlobalSettingBuilder
        _settingValue = pValue
        Return Me
    End Function
    Public Function Build() As GlobalSetting
        Return New GlobalSetting(_settingId,
                            _settingType,
                            _settingValue)
    End Function
End Class
