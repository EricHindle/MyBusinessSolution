' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Security.Principal
''' <summary>
''' Identity used to validate username and password and give the user a role
''' </summary>
''' <remarks></remarks>
Public Class NetwyrksIIdentity
    Implements IIdentity

    Private ReadOnly _nameValue As String
    Private ReadOnly authenticatedValue As Boolean
    Private roleValue As ApplicationServices.BuiltInRole
    Private _userId As Integer
    Private _usercode As String

    ''' <summary>
    ''' Creating an identity, checking username and password
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="password"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal name As String,
                   ByVal password As String)

        ' Name and password must both be present
        ' The name is not case sensitive, but the password is.

        _nameValue = name
        If name IsNot Nothing AndAlso password IsNot Nothing AndAlso IsValidNameAndPassword(name, password) Then
            authenticatedValue = True
        Else
            _nameValue = ""
            _usercode = ""
            authenticatedValue = False
            roleValue = Nothing
        End If
    End Sub

    Private Function IsValidNameAndPassword(ByVal username As String,
                ByVal password As String) _
                As Boolean
        Dim rtnVal As Boolean = False
        ' Find user record

        Dim hashedUser As String = ""
        Dim storedHashedPW As String = ""
        Dim storedHashedTempPW As String = ""
        Dim salt As String = ""
        Dim role As String = "Guest"
        Dim oTa As New MyBusinessDataSetTableAdapters.usersTableAdapter
        Dim oTable As New MyBusinessDataSet.usersDataTable
        Try
            hashedUser = AuthenticationUtil.hashedUsername(username)
        Catch ex As Exception
            Debug.Print(ex.Message)
            Debug.Print(ex.InnerException.Message)
        End Try
        Try
            If oTa.Fill(oTable) = 0 Then
                Throw New AuthenticationException("No registered users")
            End If
            If oTa.FillByLogin(oTable, hashedUser) = 1 Then
                Dim oRow As MyBusinessDataSet.usersRow = oTable.Rows(0)
                storedHashedPW = oRow.user_password
                storedHashedTempPW = If(oRow.Istemp_passwordNull, Nothing, oRow.temp_password)
                salt = oRow.salt
                role = oRow.user_role
                _userId = oRow.user_id
                _usercode = oRow.user_code
            End If

            Dim hpw As String = AuthenticationUtil.GetHashed(salt & Trim(password))
            If AuthenticationUtil.GetHashed(salt & Trim(password)) = storedHashedPW Or (storedHashedTempPW IsNot Nothing AndAlso AuthenticationUtil.GetHashed(salt & Trim(password)) = storedHashedTempPW) Then
                '
                ' set the user's role
                '
                Select Case role
                    Case AuthenticationUtil.GetHashed(salt & AuthorisationUtil.GetRoleName(AuthorisationUtil.AccessRole.Administrator))
                        roleValue = ApplicationServices.BuiltInRole.Administrator
                    Case AuthenticationUtil.GetHashed(salt & AuthorisationUtil.GetRoleName(AuthorisationUtil.AccessRole.Manager))
                        roleValue = ApplicationServices.BuiltInRole.PowerUser
                    Case AuthenticationUtil.GetHashed(salt & AuthorisationUtil.GetRoleName(AuthorisationUtil.AccessRole.Executive))
                        roleValue = ApplicationServices.BuiltInRole.User
                    Case AuthenticationUtil.GetHashed(salt & AuthorisationUtil.GetRoleName(AuthorisationUtil.AccessRole.Operatr))
                        roleValue = ApplicationServices.BuiltInRole.AccountOperator
                    Case AuthenticationUtil.GetHashed(salt & AuthorisationUtil.GetRoleName(AuthorisationUtil.AccessRole.Guest))
                        roleValue = ApplicationServices.BuiltInRole.Guest
                    Case Else
                        roleValue = Nothing
                End Select

                '_userId = 1
                '_usercode = "EH"

                '    roleValue = ApplicationServices.BuiltInRole.Administrator
                rtnVal = True
            End If
            'roleValue = ApplicationServices.BuiltInRole.Administrator
            'rtnVal = True
        Catch ex As Exception
            MsgBox("Exception occurred during authentication:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Access Error")
        End Try

        oTable.Dispose()
        oTa.Dispose()
        '    roleValue = ApplicationServices.BuiltInRole.Administrator

        Return rtnVal

    End Function

    Public ReadOnly Property AuthenticationType() As String Implements System.Security.Principal.IIdentity.AuthenticationType
        Get
            Return "Custom Authentication"
        End Get
    End Property

    Public ReadOnly Property IsAuthenticated() As Boolean Implements System.Security.Principal.IIdentity.IsAuthenticated
        Get
            Return authenticatedValue
        End Get
    End Property

    Public ReadOnly Property Name() As String Implements System.Security.Principal.IIdentity.Name
        Get
            Return _nameValue
        End Get
    End Property

    Public ReadOnly Property Role() As ApplicationServices.BuiltInRole
        Get
            Return roleValue
        End Get
    End Property

    Public ReadOnly Property RoleName() As String
        Get
            Return [Enum].GetName(GetType(ApplicationServices.BuiltInRole), roleValue)
        End Get
    End Property

    Public ReadOnly Property UserId() As Integer
        Get
            Return _userId
        End Get
    End Property

    Public ReadOnly Property Usercode() As String
        Get
            Return _usercode
        End Get
    End Property

End Class
