﻿' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class myb_NetwyrksErrorCodes
#Region "Error Codes"
    Public Enum SystemModule
        UNKNOWN = 0
        CUSTOMER = 1
        ADMIN = 2
        SECURITY = 3
        IMAGES = 4
        DIARY = 5
        EMAIL = 6
        LOGGING = 7
        UTILITIES = 8
        TEMPLATES = 9
        SETTINGS = 10
        REPORTING = 11
    End Enum
    Public Enum ErrorType
        UNKNOWN = 0
        DATABASE = 1
        MISSING_DATA = 2
        COMMS = 3
        ENCRYPTION = 4
        TABLE = 5
        APPLICATION = 6
        CONVERSION = 7
        FILESYSTEM = 8
    End Enum
    Public Enum FailedAction
        UNKNOWN = 0
        DELETION_EXCEPTION = 1
        CREATION_EXCEPTION = 2
        UPDATE_EXCEPTION = 3
        ERROR_STARTING_EXTERNAL_APP = 4
        ERROR_CLOSING_EXTERNAL_APP = 5
        ERROR_IN_EXTERNAL_APP = 6
        EXTERNAL_APP_MUST_BE_RUNNING = 7
        EMAIL_FAILED = 8
        DELETION_FAILED = 9
        ERROR_SAVING_FILE = 10
        ERROR_CONVERTING_TO_PDF = 11
        ENCRYPTION_ERROR = 12
        DECRYPTION_ERROR = 13
        EXCEPTION_WHEN_ADDING_ROW_TO_TABLE = 14
        ERROR_LOADING_RECORDS = 15
        DROPDOWN_ERROR = 16
        SINGLE_RECORD_LOAD_EXCEPTION = 17
        UPDATE_FAILED = 18
        MOUSE_ERROR = 19
        IMAGE_PROCESSING_ERROR = 20
        ERROR_FINDING_FILE = 21
        GEO_CODING_ERROR = 22
        HTML_ERROR = 23
        GLOBAL_SETTING_ERROR = 24
        ERROR_DELETING_FILE = 25
        BUG = 26
        MERGE_EXCEPTION = 27
        GLOBAL_SETTINGS_EXCEPTION = 28
        DATA_ERROR = 29
        ARCHIVING_EXCEPTION = 30
        CREATION_FAILED = 31
    End Enum
    Public Shared Function GetErrorCode(ByVal errModule As SystemModule, ByVal errType As ErrorType, ByVal errCode As FailedAction) As String
        Return CInt(errModule).ToString("D2") & CInt(errType).ToString("D2") & CInt(errCode).ToString("D3")
    End Function
    Public Shared Function GetErrorString(ByVal errorcode As String) As String
        Dim rtnval As String
        Try
            Dim iModule As Integer = errorcode.Substring(0, 2)
            Dim iType As Integer = errorcode.Substring(2, 2)
            Dim sCode As String = errorcode.Substring(4, 3)

            Dim sModule As String = [Enum].GetName(GetType(SystemModule), iModule)
            Dim sType As String = [Enum].GetName(GetType(ErrorType), iType)
            rtnval = sModule & " module " & sType & " error " & sCode
        Catch ex As Exception
            rtnval = "Invalid Error Code"
        End Try
        Return rtnval
    End Function
#End Region
End Class

