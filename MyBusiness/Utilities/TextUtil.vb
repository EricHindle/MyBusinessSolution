' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

''' <summary>
''' Useful text functions
''' </summary>
''' <remarks></remarks>
Public Class TextUtil

    Private Const MATCHKEY_CHARS As String = "bcdfghjklmnpqrstvwxz"
    Public Shared Function GetMatchkey(ByVal sText As String) As String
        Dim matchkey As String = ""
        For Each sChar In sText.ToLower
            If MATCHKEY_CHARS.IndexOf(sChar) >= 0 Then
                matchkey += sChar
            End If
        Next
        Return matchkey
    End Function
End Class
