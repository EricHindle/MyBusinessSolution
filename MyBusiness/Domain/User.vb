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

    Public Sub New(ByVal pUserId As Integer, _
                   ByVal pUserLogin As String, _
                   ByVal pUserCode As String, _
                   ByVal pPassword As String, _
                   ByVal pTempPassword As String, _
                   ByVal pForcePasswordChange As Boolean?, _
                   ByVal pSalt As String, _
                   ByVal pUserName As String, _
                   ByVal pContactNumber As String, _
                   ByVal pMobile As String, _
                   ByVal pEmail As String, _
                   ByVal pJobTitle As String, _
                   ByVal pNote As String)
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
    End Sub

    Public Property user_login() As String
        Get
            Return _user_login
        End Get
        Set(ByVal value As String)
            _user_login = value
        End Set
    End Property
    Public Property user_code() As String
        Get
            Return _user_code
        End Get
        Set(ByVal value As String)
            _user_code = value
        End Set
    End Property
    Public Property password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property
    Public Property tempPassword() As String
        Get
            Return _tempPassword
        End Get
        Set(ByVal value As String)
            _tempPassword = value
        End Set
    End Property

    Public Property forcePasswordChange() As Boolean?
        Get
            Return _forcePasswordChange
        End Get
        Set(ByVal value As Boolean?)
            _forcePasswordChange = value
        End Set
    End Property
    Public Property salt() As String
        Get
            Return _salt
        End Get
        Set(ByVal value As String)
            _salt = value
        End Set
    End Property
    Public Property userName() As String
        Get
            Return _userName
        End Get
        Set(ByVal value As String)
            _userName = value
        End Set
    End Property
    Public Property note() As String
        Get
            Return If(_note Is Nothing, "", _note)
        End Get
        Set(ByVal value As String)
            _note = value
        End Set
    End Property

    Public Property jobTitle() As String
        Get
            Return If(_jobtitle Is Nothing, "", _jobtitle)
        End Get
        Set(ByVal value As String)
            _jobtitle = value
        End Set
    End Property

    Public Property contactNumber() As String
        Get
            Return If(_contactNumber Is Nothing, "", _contactNumber)
        End Get
        Set(ByVal value As String)
            _contactNumber = value
        End Set
    End Property
    Public Property mobile() As String
        Get
            Return If(_mobile Is Nothing, "", _mobile)
        End Get
        Set(ByVal value As String)
            _mobile = value
        End Set
    End Property
    Public Property email() As String
        Get
            Return If(_email Is Nothing, "", _email)
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Public Property userId() As Integer
        Get
            Return _userId
        End Get
        Set(ByVal value As Integer)
            _userId = value
        End Set
    End Property

End Class
