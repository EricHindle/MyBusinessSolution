' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class NetwyrksIPrincipal
    Implements System.Security.Principal.IPrincipal
    Private ReadOnly identityValue As NetwyrksIIdentity

    Public Sub New(ByVal name As String, ByVal password As String)
        '
        ' Validate the username and password and create a new identity
        '
        identityValue = New NetwyrksIIdentity(name, password)
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
