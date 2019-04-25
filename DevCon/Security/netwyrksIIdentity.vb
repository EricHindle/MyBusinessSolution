' IIdentity.vb
'
' Identity used to validate username and password and give the user a role
'
' Copyright (c) 2015, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
' Created Oct 2015

Imports System.IO

Public Class netwyrksIIdentity
    Implements System.Security.Principal.IIdentity
    Private _nameValue As String
    Private authenticatedValue As Boolean
    Private roleValue As ApplicationServices.BuiltInRole
    Private _userId As Integer
    Private _usercode As String
    Private _operatorId As Integer

    Public Sub New(ByVal name As String, _
                   ByVal password As String, _
                   ByVal appcode As String)

        _nameValue = name
        authenticatedValue = True
    End Sub

    Public Property operatorId() As Integer
        Get
            Return _operatorId
        End Get
        Set(ByVal value As Integer)
            _operatorId = value
        End Set
    End Property

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
