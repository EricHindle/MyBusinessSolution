' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.Globalization

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
