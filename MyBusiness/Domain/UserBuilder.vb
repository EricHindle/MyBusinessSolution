' Copyright (c) 2016, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
' The moral right of the author has been asserted
' Created Mar 2016

''' <summary>
''' User object builder (see https://en.wikipedia.org/wiki/Builder_pattern)
''' </summary>
''' <remarks></remarks>
Public Class UserBuilder
    Private _userId As Integer
    Private _userLogin As String
    Private _userCode As String
    Private _password As String
    Private _tempPassword As String
    Private _forcePasswordChange As Boolean
    Private _salt As String
    Private _userName As String
    Private _email As String
    Private _contactNumber As String
    Private _mobile As String
    Private _jobTitle As String
    Private _note As String

    Public Shared Function aUserBuilder() As UserBuilder
        Return New UserBuilder
    End Function

    Public Function startingWith(ByVal pUserId As Integer) As UserBuilder
        Dim oUserTable As New netwyrksDataSet.userDataTable
        Dim oUserTa As New netwyrksDataSetTableAdapters.userTableAdapter
        If oUserTa.FillById(oUserTable, pUserId) > 0 Then
            startingWith(oUserTable.Rows(0))
        Else
            startingWithNothing()
        End If
        oUserTable.Dispose()
        oUserTa.Dispose()
        Return Me
    End Function

    Public Function startingWith(ByRef pUserRow As netwyrksDataSet.userRow) As UserBuilder
        If pUserRow IsNot Nothing Then
            With pUserRow
                _userId = .user_id
                _userLogin = .user_login
                _userCode = .user_code
                _password = .user_password
                _tempPassword = .temp_password
                _forcePasswordChange = .force_password_change
                _salt = .salt
                _userName = .user_name
                _contactNumber = .user_contact_number
                _mobile = .user_mobile
                _email = .user_email
                _jobTitle = .user_jobtitle
                _note = .user_note
            End With
        Else
            startingWithNothing()
        End If
        Return Me
    End Function

    Public Function startingWithNothing() As UserBuilder
        _userId = 0
        _userLogin = ""
        _userCode = ""
        _password = ""
        _tempPassword = ""
        _forcePasswordChange = False
        _salt = ""
        _userName = ""
        _contactNumber = ""
        _mobile = ""
        _email = ""
        _jobTitle = ""
        _note = ""
        Return Me
    End Function
    Public Function withUserId(ByVal puserId As Integer) As UserBuilder
        _userId = puserId
        Return Me
    End Function
    Public Function withUserLogin(ByVal pUserLogin As String) As UserBuilder
        _userLogin = pUserLogin
        Return Me
    End Function
    Public Function withUserCode(ByVal pUserCode As String) As UserBuilder
        _userCode = pUserCode
        Return Me
    End Function
    Public Function withPassword(ByVal pPassword As String) As UserBuilder
        _password = pPassword
        Return Me
    End Function
    Public Function withTempPassword(ByVal pTempPassword As String) As UserBuilder
        _tempPassword = pTempPassword
        Return Me
    End Function
    Public Function withForcePasswordChange(ByVal pForcePasswordChange As String) As UserBuilder
        _forcePasswordChange = pForcePasswordChange
        Return Me
    End Function
    Public Function withSalt(ByVal pSalt As String) As UserBuilder
        _salt = pSalt
        Return Me
    End Function
    Public Function withUserName(ByVal pUserName As String) As UserBuilder
        _userName = pUserName
        Return Me
    End Function
    Public Function withEmail(ByVal pEmail As String) As UserBuilder
        _email = pEmail
        Return Me
    End Function
    Public Function withContactNumber(ByVal pContactNumber As String) As UserBuilder
        _contactNumber = pContactNumber
        Return Me
    End Function
    Public Function withMobile(ByVal pMobile As String) As UserBuilder
        _mobile = pMobile
        Return Me
    End Function
    Public Function withJobTitle(ByVal pJobTitle As String) As UserBuilder
        _jobTitle = pJobTitle
        Return Me
    End Function
    Public Function withNote(ByVal pNote As String) As UserBuilder
        _note = pNote
        Return Me
    End Function

    Public Function build() As User
        Return New User(_userId, _
                        _userLogin, _
                        _userCode, _
                        _password, _
                        _tempPassword, _
                        _forcePasswordChange, _
                        _salt, _
                        _userName, _
                        _contactNumber, _
                        _mobile, _email, _
                        _jobTitle, _
                        _note)
    End Function

End Class
