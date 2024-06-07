' Hindleware
' Copyright (c) 2022-24 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text
Imports System.Text.RegularExpressions

''' <summary>
''' Input validation functions
''' </summary>
''' <remarks></remarks>
Public Class ValidationUtil
    Const GENERAL_POSTCODE_REGEX As String = "^([A-Z]{1,2}[0-9][0-9A-Z]?\s?[0-9][A-Z]{2})$"
    Const EMAIL_REGEX As String = "^(([A-Z0-9._%+-]+)@(([A-Z0-9.-]+)\.([A-Z]{2,4})))$"
    Const GENERAL_PHONE_REGEX As String = "^\(?0\d{4}\)?\s*(\d{5,6}\s*)|\(?0\d{3}\)?\s*(\d{3}\s*\d{4})|\(?02\d\)?\s*(\d{4}\s*\d{4})|\(?01\d{2}\s*\d{2}\)?\s*(\d{4,5})$"
    Public Function IsValidEmail(ByVal strIn As String) As Boolean
        If String.IsNullOrEmpty(strIn) Then Return True
        ' Return true if strIn is in valid e-mail format.
        Return Regex.IsMatch(strIn, EMAIL_REGEX, RegexOptions.IgnoreCase)
    End Function
    Public Function IsValidPostcode(ByVal strIn As String) As Boolean
        If String.IsNullOrEmpty(strIn) Then Return True
        Return Regex.IsMatch(strIn.ToUpper, GENERAL_POSTCODE_REGEX)
    End Function
    Public Function IsValidPhoneNumber(ByVal strIn As String) As Boolean
        If String.IsNullOrEmpty(strIn) Then Return True
        Return Regex.IsMatch(strIn.ToUpper, GENERAL_PHONE_REGEX)
    End Function
    Public Function IsValidCard(ByVal strIn As String) As Boolean
        If String.IsNullOrEmpty(strIn) Then Return True
        ' TODO other card validation
        Return IsNumeric(strIn)
    End Function
    Public Function IsLengthOK(ByVal strIn As String, ByVal maxLen As Integer, Optional ByVal minLen As Integer = 0) As Boolean
        Return strIn.Length >= minLen And strIn.Length <= maxLen
    End Function
    Public Function IsValidCustomer(ByVal oCust As Customer, ByRef sInvalid As String) As Boolean
        Dim isValid As Boolean = True
        Dim sb As New StringBuilder
        If IsValidMandatoryText(oCust.custName, 2, 45) = False Then
            sb.Append("Customer name|")
            isValid = False
        End If
        If IsValidEmail(oCust.email) = False Then
            sb.Append("Email|")
            isValid = False
        End If
        If IsValidPhoneNumber(oCust.Phone) = False Then
            sb.Append("Phone number|")
            isValid = False
        End If
        sInvalid = sb.ToString
        Return isValid
    End Function
    Private Function SetError(ByVal errorText As String, ByRef errmsg As StringBuilder) As Boolean
        errmsg.Append(errorText).Append(vbCrLf)
        Return False
    End Function
    Public Function IsValidLoyaltySchemeMembership(ByVal schemeId As Integer?,
                                                   ByVal sEmail As String,
                                                   ByVal sMemberNo As String,
                                                   ByVal sCardNo As String,
                                                   ByVal sPhone As String,
                                                   ByRef sInvalid As String) As Boolean
        Dim sb As New StringBuilder
        Dim rtnval As Boolean = True
        If schemeId Is Nothing OrElse schemeId <= 0 Then rtnval = SetError("No scheme selected", sb)
        If Not IsValidEmail(sEmail) Then rtnval = SetError("Email address invalid", sb)
        If Not IsValidCard(sCardNo) Then rtnval = SetError("Card Number invalid", sb)
        If sMemberNo.Length > 0 AndAlso Not IsNumeric(sMemberNo) Then rtnval = SetError("Membership Number not numeric", sb)
        If Not IsLengthOK(sMemberNo, 9) Then rtnval = SetError("Membership Number too long", sb)
        If Not IsLengthOK(sCardNo, 21) Then rtnval = SetError("Card Number too long", sb)
        If Not IsLengthOK(sEmail, 100) Then rtnval = SetError("Email address too long", sb)
        If Not IsLengthOK(sPhone, 20) Then rtnval = SetError("Phone Number too long", sb)
        If Not IsValidPhoneNumber(sPhone) Then rtnval = SetError("Phone Number invalid", sb)
        sInvalid = sb.ToString
        Return rtnval
    End Function
    Public Function IsValidCustomerAccount(ByVal opId As Integer?,
                                           ByVal accTypeId As Integer?,
                                           ByVal sAccEmail As String,
                                           ByVal sAccRef As String,
                                           ByVal sAccUserName As String,
                                           ByRef sInvalid As String) As Boolean
        Dim sb As New StringBuilder
        Dim rtnval As Boolean = True
        If opId Is Nothing OrElse opId <= 0 Then rtnval = SetError("No bookmaker selected", sb)
        If accTypeId Is Nothing OrElse accTypeId <= 0 Then rtnval = SetError("No account type selected", sb)
        If Not IsValidEmail(sAccEmail) Then rtnval = SetError("Email address invalid", sb)
        If Not IsLengthOK(sAccRef, 45) Then rtnval = SetError("Account reference too long", sb)
        If Not IsLengthOK(sAccEmail, 100) Then rtnval = SetError("Email address too long", sb)
        If Not IsLengthOK(sAccUserName, 45) Then rtnval = SetError("Username too long", sb)
        sInvalid = sb.ToString
        Return rtnval
    End Function
    Public Function IsValidDateOfBirth(ByVal sDate As String) As Boolean
        If String.IsNullOrEmpty(sDate) Then Return True
        Dim isValid As Boolean = True
        Try
            Dim odate As Date = sDate
            If odate < New Date(1900, 1, 1) Or odate > DateAdd(DateInterval.Year, -18, Today.Date) Then
                isValid = False
            End If
        Catch ex As Exception
            isValid = False
        End Try
        Return isValid
    End Function
    Public Function IsValidMandatoryText(ByVal sText As String,
                                         Optional ByVal minLength As Integer = 1,
                                         Optional ByVal maxLength As Integer = 0) As Boolean
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
    Public Function IsValidGender(ByVal iGender As Integer) As Boolean
        Dim isValid As Boolean = True
        If iGender < 1 Then
            isValid = False
        End If
        Return isValid
    End Function
    Public Function IsValidPathName(ByVal sPath As String) As Boolean
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
    Public Function IsValidFileName(ByVal sPath As String) As Boolean
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
    Public Function IsValidFullFileName(ByVal sPath As String) As Boolean
        Dim isValid As Boolean = True
        If Not IsValidFileName(System.IO.Path.GetFileName(sPath)) Or Not IsValidPathName(System.IO.Path.GetFullPath(sPath)) Then
            isValid = False
        End If
        Return isValid
    End Function
End Class
