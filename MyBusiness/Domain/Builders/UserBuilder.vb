' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

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
    Private _role As String
    Public Shared Function AUser() As UserBuilder
        Return New UserBuilder
    End Function
    Public Function StartingWith(ByVal pUserId As Integer) As UserBuilder
        Dim oUserTable As New netwyrksDataSet.userDataTable
        Dim oUserTa As New netwyrksDataSetTableAdapters.userTableAdapter
        If oUserTa.FillById(oUserTable, pUserId) > 0 Then
            StartingWith(oUserTable.Rows(0))
        Else
            StartingWithNothing()
        End If
        oUserTable.Dispose()
        oUserTa.Dispose()
        Return Me
    End Function
    Public Function StartingWith(ByRef pUserRow As netwyrksDataSet.userRow) As UserBuilder
        If pUserRow IsNot Nothing Then
            With pUserRow
                _userId = .user_id
                _userLogin = .user_login
                _userCode = .user_code
                _password = .user_password
                _tempPassword = If(.Istemp_passwordNull, "", .temp_password)
                _forcePasswordChange = .force_password_change
                _salt = .salt
                _userName = .user_name
                _contactNumber = If(.Isuser_contact_numberNull, "", .user_contact_number)
                _mobile = If(.Isuser_mobileNull, "", .user_mobile)
                _email = If(.Isuser_emailNull, "", .user_email)
                _jobTitle = If(.Isuser_jobtitleNull, "", .user_jobtitle)
                _note = If(.Isuser_noteNull, "", .user_note)
                _role = .user_role
            End With
        Else
            StartingWithNothing()
        End If
        Return Me
    End Function
    Public Function StartingWithNothing() As UserBuilder
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
        _role = ""
        Return Me
    End Function
    Public Function WithUserId(ByVal puserId As Integer) As UserBuilder
        _userId = puserId
        Return Me
    End Function
    Public Function WithUserLogin(ByVal pUserLogin As String) As UserBuilder
        _userLogin = pUserLogin
        Return Me
    End Function
    Public Function WithUserCode(ByVal pUserCode As String) As UserBuilder
        _userCode = pUserCode
        Return Me
    End Function
    Public Function WithPassword(ByVal pPassword As String) As UserBuilder
        _password = pPassword
        Return Me
    End Function
    Public Function WithTempPassword(ByVal pTempPassword As String) As UserBuilder
        _tempPassword = pTempPassword
        Return Me
    End Function
    Public Function WithForcePasswordChange(ByVal pForcePasswordChange As String) As UserBuilder
        _forcePasswordChange = pForcePasswordChange
        Return Me
    End Function
    Public Function WithSalt(ByVal pSalt As String) As UserBuilder
        _salt = pSalt
        Return Me
    End Function
    Public Function WithUserName(ByVal pUserName As String) As UserBuilder
        _userName = pUserName
        Return Me
    End Function
    Public Function WithEmail(ByVal pEmail As String) As UserBuilder
        _email = pEmail
        Return Me
    End Function
    Public Function WithContactNumber(ByVal pContactNumber As String) As UserBuilder
        _contactNumber = pContactNumber
        Return Me
    End Function
    Public Function WithMobile(ByVal pMobile As String) As UserBuilder
        _mobile = pMobile
        Return Me
    End Function
    Public Function WithJobTitle(ByVal pJobTitle As String) As UserBuilder
        _jobTitle = pJobTitle
        Return Me
    End Function
    Public Function WithNote(ByVal pNote As String) As UserBuilder
        _note = pNote
        Return Me
    End Function
    Public Function WithRole(ByVal pRole As String) As UserBuilder
        _role = pRole
        Return Me
    End Function
    Public Function Build() As User
        Return New User(_userId,
                        _userLogin,
                        _userCode,
                        _password,
                        _tempPassword,
                        _forcePasswordChange,
                        _salt,
                        _userName,
                        _contactNumber,
                        _mobile, _email,
                        _jobTitle,
                        _note, _role)
    End Function
End Class
