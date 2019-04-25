'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Text

''' <summary>
''' Input validation functions
''' </summary>
''' <remarks></remarks>
Public Class ValidationUtil
    Dim invalid As Boolean = False
    Const STRICT_POSTCODE_REGEX As String = "^([A-PR-UWYZ0-9][A-HK-Y0-9][AEHMNPRTVXY0-9]?[ABEHMNPRVWXY0-9]? {1,2}[0-9][ABD-HJLNP-UW-Z]{2})$"
    Const GENERAL_POSTCODE_REGEX As String = "^([A-Z]{1,2}[0-9][0-9A-Z]?\s?[0-9][A-Z]{2})$"
    Const EMAIL_REGEX As String = "^(([A-Z0-9._%+-]+)@(([A-Z0-9.-]+)\.([A-Z]{2,4})))$"
    Const STRICT_PHONE_REGEX As String = "^(((\+44\s?|0044\s?)?|(\(?0))((2[03489]\)?\s?\d{4}\s?\d{4})|(1[23456789]1\)?\s?\d{3}\s?\d{4})|(1[23456789][234578][0234679]\)?\s?\d{6})|(1[2579][0245][0467]\)?\s?\d{5})|(11[345678]\)?\s?\d{3}\s?\d{4})|(1[35679][234689]\s?[46789][234567]\)?\s?\d{4,5})|([389]\d{2}\s?\d{3}\s?\d{4})|([57][0-9]\s?\d{4}\s?\d{4})|(500\s?\d{6})|(7[456789]\d{2}\s?\d{6})))$"
    Const GENERAL_PHONE_REGEX As String = "^\(?0\d{4}\)?\s*(\d{5,6}\s*)|\(?0\d{3}\)?\s*(\d{3}\s*\d{4})|\(?02\d\)?\s*(\d{4}\s*\d{4})|\(?01\d{2}\s*\d{2}\)?\s*(\d{4,5})$"

    Public Function IsValidEmail(ByVal strIn As String) As Boolean
        If String.IsNullOrEmpty(strIn) Then Return True
        ' Return true if strIn is in valid e-mail format.
        Return Regex.IsMatch(strIn, EMAIL_REGEX, RegexOptions.IgnoreCase)
    End Function

    Public Function isValidPostcode(ByVal strIn As String) As Boolean
        If String.IsNullOrEmpty(strIn) Then Return True

        Return Regex.IsMatch(strIn.ToUpper, GENERAL_POSTCODE_REGEX)

    End Function

    Public Function isValidPhoneNumber(ByVal strIn As String) As Boolean
        If String.IsNullOrEmpty(strIn) Then Return True

        Return Regex.IsMatch(strIn.ToUpper, GENERAL_PHONE_REGEX)

    End Function

    Public Function isValidCard(ByVal strIn As String) As Boolean
        If String.IsNullOrEmpty(strIn) Then Return True
        ' TODO other card validation
        Return IsNumeric(strIn)
    End Function

    Public Function isLengthOK(ByVal strIn As String, ByVal maxLen As Integer, Optional ByVal minLen As Integer = 0) As Boolean
        Return strIn.Length >= minLen And strIn.Length <= maxLen
    End Function

    Public Function isValidCustomer(ByVal oCust As Customer, ByRef sInvalid As String) As Boolean
        Dim isValid As Boolean = True
        Dim sb As New StringBuilder

        If isValidMandatoryText(oCust.custName, 2, 45) = False Then
            sb.Append("Customer name|")
            isValid = False
        End If
        If IsValidEmail(oCust.email) = False Then
            sb.Append("Email|")
            isValid = False
        End If

        If isValidPhoneNumber(oCust.phone) = False Then
            sb.Append("Phone number|")
            isValid = False
        End If
        sInvalid = sb.ToString
        Return isValid
    End Function

    Private Function setError(ByVal errorText As String, ByRef errmsg As StringBuilder) As Boolean
        errmsg.Append(errorText).Append(vbCrLf)
        Return False
    End Function

    Public Function isValidLoyaltySchemeMembership(ByVal schemeId As Integer?, ByVal sEmail As String, ByVal sMemberNo As String, ByVal sCardNo As String, ByVal sPhone As String, ByRef sInvalid As String) As Boolean
        Dim sb As New StringBuilder
        Dim rtnval As Boolean = True
        If schemeId Is Nothing OrElse schemeId <= 0 Then rtnval = setError("No scheme selected", sb)
        If Not IsValidEmail(sEmail) Then rtnval = setError("Email address invalid", sb)
        If Not isValidCard(sCardNo) Then rtnval = setError("Card Number invalid", sb)
        If sMemberNo.Length > 0 AndAlso Not IsNumeric(sMemberNo) Then rtnval = setError("Membership Number not numeric", sb)
        If Not isLengthOK(sMemberNo, 9) Then rtnval = setError("Membership Number too long", sb)
        If Not isLengthOK(sCardNo, 21) Then rtnval = setError("Card Number too long", sb)
        If Not isLengthOK(sEmail, 100) Then rtnval = setError("Email address too long", sb)
        If Not isLengthOK(sPhone, 20) Then rtnval = setError("Phone Number too long", sb)
        If Not isValidPhoneNumber(sPhone) Then rtnval = setError("Phone Number invalid", sb)
        sInvalid = sb.ToString
        Return rtnval
    End Function


    Public Function isValidCustomerAccount(ByVal opId As Integer?, ByVal accTypeId As Integer?, ByVal sAccEmail As String, ByVal sAccRef As String, ByVal sAccUserName As String, ByRef sInvalid As String) As Boolean
        Dim sb As New StringBuilder
        Dim rtnval As Boolean = True
        If opId Is Nothing OrElse opId <= 0 Then rtnval = setError("No bookmaker selected", sb)
        If accTypeId Is Nothing OrElse accTypeId <= 0 Then rtnval = setError("No account type selected", sb)
        If Not IsValidEmail(sAccEmail) Then rtnval = setError("Email address invalid", sb)
        If Not isLengthOK(sAccRef, 45) Then rtnval = setError("Account reference too long", sb)
        If Not isLengthOK(sAccEmail, 100) Then rtnval = setError("Email address too long", sb)
        If Not isLengthOK(sAccUserName, 45) Then rtnval = setError("Username too long", sb)
        sInvalid = sb.ToString
        Return rtnval
    End Function

    Public Function isValidDateOfBirth(ByVal sDate As String) As Boolean
        If String.IsNullOrEmpty(sDate) Then Return True
        Dim isValid As Boolean = True
        Try
            Dim odate As Date = CDate(sDate)
            If odate < New Date(1900, 1, 1) Or odate > DateAdd(DateInterval.Year, -18, Today.Date) Then
                isValid = False
            End If
        Catch ex As Exception
            isValid = False
        End Try
        Return isValid
    End Function

    Public Function isValidMandatoryText(ByVal sText As String, Optional ByVal minLength As Integer = 1, Optional ByVal maxLength As Integer = 0) As Boolean
        If String.IsNullOrEmpty(sText) Then Return False
        Dim isValid As Boolean = True
        If sText.Length < minLength Then
            isValid = False
        End If
        If maxLength > 0 AndAlso sText.Length > maxLength Then
            isValid = False
        End If

        Return isValid
    End Function

    Public Function isValidGender(ByVal iGender As Integer) As Boolean
        Dim isValid As Boolean = True
        If iGender < 1 Then
            isValid = False
        End If
        Return isValid
    End Function

    Public Function isValidPathName(ByVal sPath As String) As Boolean
        Dim isValid As Boolean = True
        If sPath Is Nothing Then
            isValid = False
        Else
            For Each badChar As Char In System.IO.Path.GetInvalidPathChars
                If InStr(sPath, badChar) > 0 Then
                    Return False
                End If
            Next
        End If
        Return isValid
    End Function

    Public Function isValidFileName(ByVal sPath As String) As Boolean
        Dim isValid As Boolean = True
        If sPath Is Nothing Then
            isValid = False
        Else
            For Each badChar As Char In System.IO.Path.GetInvalidFileNameChars
                If InStr(sPath, badChar) > 0 Then
                    Return False
                End If
            Next
        End If
        Return isValid
    End Function

    Public Function isValidFullFileName(ByVal sPath As String) As Boolean
        Dim isValid As Boolean = True
        If Not isValidFileName(System.IO.Path.GetFileName(sPath)) Or Not isValidPathName(System.IO.Path.GetFullPath(sPath)) Then
            isValid = False
        End If
        Return isValid
    End Function

End Class
