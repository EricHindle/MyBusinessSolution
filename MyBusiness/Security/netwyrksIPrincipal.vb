' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class netwyrksIPrincipal
    Implements System.Security.Principal.IPrincipal
    Private identityValue As netwyrksIIdentity

    Dim disposed As Boolean = False

    Public Sub New(ByVal name As String, ByVal password As String, ByVal appCode As String)
        '
        ' Validate the username and password and create a new identity
        '
        identityValue = New netwyrksIIdentity(name, password, appCode)
    End Sub

    Public ReadOnly Property Identity() As System.Security.Principal.IIdentity Implements System.Security.Principal.IPrincipal.Identity
        Get
            Return identityValue
        End Get
    End Property

    Public Function IsInRole(ByVal role As String) As Boolean Implements System.Security.Principal.IPrincipal.IsInRole
        '
        ' checks if identity is in the role
        '
        Return role = identityValue.Role.ToString
    End Function

End Class
