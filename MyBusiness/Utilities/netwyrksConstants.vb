' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

''' <summary>
''' Globally available constants
''' </summary>
''' <remarks></remarks>
Module netwyrksConstants
#Region "constants"
    Public Const QUOTES As String = """"
    Public Const NOT_AUTHENTICATED As String = "User not authenticated"
    Public Const NOT_AUTHORISED As String = "User not authorised"
    Public Const AUTHORISATION_ERROR As String = "Authorisation error"
    Public Const AUTHENTICATION_ERROR As String = "Authentication error"
    Public Const PASSWORD_CHANGE_ERROR As String = "User password change error"
    Public Const INVALID_PASSWORD As String = "Invalid Password"
    Public Const PERSONAL_DATA_PRIVACY As String = "This message contains personal data. It should be kept secure and must not be forwarded, printed out or shown to third parties without authority."
    Public Const REPORT_PRIVACY As String = "This report should be kept secure and must not be forwarded, printed out or shown to third parties without authority."

    Public Const PASSWORD_CHANGE_EMAIL As String =
        "A temporary password has been requested for you for MyBusiness." & vbCrLf &
        "Temporary password: {}" & vbCrLf &
        "You can still use your old password." & vbCrLf & vbCrLf &
        "You will be required to choose a new password when you login." & vbCrLf & vbCrLf &
        "System Adminstration" & vbCrLf
    Public Const SKIN_OPT1 As String = "imageButtons"
    Public Const SKIN_STD As String = "standard"
    Public FORM_BACKGROUND_COLOUR As Color = Color.FromArgb(255, 239, 190)
    Public FORM_FOREGROUND_COLOUR As Color = Color.FromArgb(55, 48, 26)
    Public FIELD_BACKGROUND_COLOUR As Color = Color.WhiteSmoke
    Public HARD_SPACE As String = ChrW(160)
    Public Const NO_OF_PREM As String = "No. of premises = "
    Public Const STATUS_MESSAGE_MAX_LENGTH As Integer = 90

#End Region
End Module
