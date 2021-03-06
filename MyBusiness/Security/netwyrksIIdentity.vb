﻿

Imports System.IO
Imports System.Security.Principal
''' <summary>
''' Identity used to validate username and password and give the user a role
''' </summary>
''' <remarks></remarks>
Public Class netwyrksIIdentity
    Implements IIdentity

    Private _nameValue As String
    Private authenticatedValue As Boolean
    Private roleValue As ApplicationServices.BuiltInRole
    Private _userId As Integer
    Private _usercode As String
    Private userName As String

    ''' <summary>
    ''' Creating an identity, checking username and password
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="password"></param>
    ''' <param name="appcode"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal name As String, _
                   ByVal password As String, _
                   ByVal appcode As String)

        ' Name and password must both be present
        ' The name is not case sensitive, but the password is.

        _nameValue = name
        If name IsNot Nothing AndAlso password IsNot Nothing AndAlso IsValidNameAndPassword(name, password, appcode) Then
            authenticatedValue = True
        Else
            _nameValue = ""
            _usercode = ""
            authenticatedValue = False
            roleValue = Nothing
        End If
    End Sub

    Private Function IsValidNameAndPassword(ByVal username As String, _
                ByVal password As String, _
                ByVal appcode As String) _
                As Boolean
        Dim rtnVal As Boolean = False
        ' Find user record


        Dim hashedUser As String = ""
        Dim storedHashedPW As String = ""
        Dim storedHashedTempPW As String = ""
        Dim salt As String = ""
        Dim role As String = "Administrator"

        Dim oTa As New netwyrksDataSetTableAdapters.userTableAdapter
        Dim oTable As New netwyrksDataSet.userDataTable
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
                Dim oRow As netwyrksDataSet.userRow = oTable.Rows(0)
                storedHashedPW = oRow.user_password
                storedHashedTempPW = If(oRow.Istemp_passwordNull, Nothing, oRow.temp_password)
                salt = oRow.salt
                _userId = oRow.user_id
                _usercode = oRow.user_code
            End If

            Dim hpw As String = AuthenticationUtil.GetHashed(salt & Trim(password))
            Debug.Print(AuthenticationUtil.GetHashed(salt & Trim(password)))
            If AuthenticationUtil.GetHashed(salt & Trim(password)) = storedHashedPW Or (storedHashedTempPW IsNot Nothing AndAlso AuthenticationUtil.GetHashed(salt & Trim(password)) = storedHashedTempPW) Then
                '
                ' set the user's role
                '
                roleValue = ApplicationServices.BuiltInRole.Administrator
                rtnVal = True
            End If
        Catch ex As Exception
            MsgBox("Exception occurred during authentication:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Access Error")
        End Try

        oTable.Dispose()
        oTa.Dispose()

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

    Public ReadOnly Property userId() As Integer
        Get
            Return _userId
        End Get
    End Property

    Public ReadOnly Property usercode() As String
        Get
            Return _usercode
        End Get
    End Property

End Class
