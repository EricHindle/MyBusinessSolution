' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class User
    Private _userId As Integer
    Private _user_login As String
    Private _user_code As String
    Private _password As String
    Private _tempPassword As String
    Private _forcePasswordChange As Boolean?
    Private _salt As String
    Private _email As String
    Private _contactNumber As String
    Private _mobile As String
    Private _jobtitle As String
    Private _note As String
    Private _userName As String
    Private _role As String

    Public Sub New(ByVal pUserId As Integer,
                   ByVal pUserLogin As String,
                   ByVal pUserCode As String,
                   ByVal pPassword As String,
                   ByVal pTempPassword As String,
                   ByVal pForcePasswordChange As Boolean?,
                   ByVal pSalt As String,
                   ByVal pUserName As String,
                   ByVal pContactNumber As String,
                   ByVal pMobile As String,
                   ByVal pEmail As String,
                   ByVal pJobTitle As String,
                   ByVal pNote As String,
                   ByVal pRole As String)
        _userId = pUserId
        _user_login = pUserLogin
        _user_code = pUserCode
        _password = pPassword
        _tempPassword = pTempPassword
        _forcePasswordChange = pForcePasswordChange
        _salt = pSalt
        _userName = pUserName
        _email = pEmail
        _contactNumber = pContactNumber
        _mobile = pMobile
        _jobtitle = pJobTitle
        _note = pNote
        _role = pRole
    End Sub
    Public Property User_login() As String
        Get
            Return _user_login
        End Get
        Set(ByVal value As String)
            _user_login = value
        End Set
    End Property
    Public Property User_code() As String
        Get
            Return _user_code
        End Get
        Set(ByVal value As String)
            _user_code = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property
    Public Property TempPassword() As String
        Get
            Return _tempPassword
        End Get
        Set(ByVal value As String)
            _tempPassword = value
        End Set
    End Property
    Public Property ForcePasswordChange() As Boolean?
        Get
            Return _forcePasswordChange
        End Get
        Set(ByVal value As Boolean?)
            _forcePasswordChange = value
        End Set
    End Property
    Public Property Salt() As String
        Get
            Return _salt
        End Get
        Set(ByVal value As String)
            _salt = value
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return _userName
        End Get
        Set(ByVal value As String)
            _userName = value
        End Set
    End Property
    Public Property Note() As String
        Get
            Return If(_note, "")
        End Get
        Set(ByVal value As String)
            _note = value
        End Set
    End Property
    Public Property JobTitle() As String
        Get
            Return If(_jobtitle, "")
        End Get
        Set(ByVal value As String)
            _jobtitle = value
        End Set
    End Property
    Public Property ContactNumber() As String
        Get
            Return If(_contactNumber, "")
        End Get
        Set(ByVal value As String)
            _contactNumber = value
        End Set
    End Property
    Public Property Mobile() As String
        Get
            Return If(_mobile, "")
        End Get
        Set(ByVal value As String)
            _mobile = value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return If(_email, "")
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property
    Public Property UserId() As Integer
        Get
            Return _userId
        End Get
        Set(ByVal value As Integer)
            _userId = value
        End Set
    End Property
    Public Property UserRole() As String
        Get
            Return _role
        End Get
        Set(ByVal value As String)
            _role = value
        End Set
    End Property
End Class
