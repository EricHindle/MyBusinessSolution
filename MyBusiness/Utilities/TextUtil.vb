' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Sep 2015

Imports System.Text
Imports System.Globalization
Imports System.IO

''' <summary>
''' Useful text functions
''' </summary>
''' <remarks></remarks>
Public Class TextUtil

    Private Const MATCHKEY_CHARS As String = "bcdfghjklmnpqrstvwxz"

    Private Shared tInfo As TextInfo = CultureInfo.CurrentCulture.TextInfo



    Public Shared Function getMatchkey(ByVal sText As String) As String
        Dim matchkey As String = ""
        For Each sChar In sText.ToLower
            If MATCHKEY_CHARS.IndexOf(sChar) >= 0 Then
                matchkey += sChar
            End If
        Next
        Return matchkey
    End Function

End Class
