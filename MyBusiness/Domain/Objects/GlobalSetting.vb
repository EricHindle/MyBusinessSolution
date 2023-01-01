' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class GlobalSetting
    Private _settingId As String
    Private _settingType As SettingType
    Private _settingValue As String
    Public Enum SettingType
        STR
        INT
        DAT
        BOO
        DEC
        CHA
    End Enum
    Public Property SettingValue() As String
        Get
            Return _settingValue
        End Get
        Set(ByVal value As String)
            _settingValue = value
        End Set
    End Property
    Public Property ValueType() As SettingType
        Get
            Return _settingType
        End Get
        Set(ByVal value As SettingType)
            _settingType = value
        End Set
    End Property
    Public Property SettingId() As String
        Get
            Return _settingId
        End Get
        Set(ByVal value As String)
            _settingId = value
        End Set
    End Property
    Public Sub New(ByVal pId As String,
                   ByVal pType As SettingType,
                   ByVal pValue As String)
        _settingId = pId
        _settingType = pType
        _settingValue = pValue
    End Sub

End Class
