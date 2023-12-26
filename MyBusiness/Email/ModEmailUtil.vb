' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Domain.Builders
Imports HindlewareLib.Domain.Objects

Public Module ModEmailUtil
#Region "constants"
    Public Const SMTP_USERNAME As String = "SMTPUsername"
    Public Const SMTP_FROMNAME As String = "SendEmailName"
    Public Const SMTP_PASSWORD As String = "SMTPPassword"
    Public Const SMTP_HOST As String = "SMTPHost"
    Public Const SMTP_REQ_CRED As String = "SMTPRequiresCredentials"
    Public Const SMTP_PORT As String = "SMTPPort"
    Public Const SMTP_SSL As String = "SMTPEnableSSL"
#End Region
#Region "functions"
    Public Function MakeSmtpFromGlobalValues() As SmtpAccount
        Return SmtpAccountBuilder.AnSmtpAccount.StartingWithNothing _
                        .WithHost(GlobalSettings.GetSettingValue(SMTP_HOST)) _
                        .WithUsername(GlobalSettings.GetSettingValue(SMTP_USERNAME)) _
                        .WithPassword(GlobalSettings.GetSettingValue(SMTP_PASSWORD)) _
                        .WithPort(GlobalSettings.GetIntegerSetting(SMTP_PORT)) _
                        .WithEnableSsl(GlobalSettings.GetBooleanSetting(SMTP_SSL)) _
                        .WithRequireCredentials(GlobalSettings.GetBooleanSetting(SMTP_REQ_CRED)) _
                        .Build
    End Function
#End Region
End Module
