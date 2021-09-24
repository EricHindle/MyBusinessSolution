' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

''' <summary>
''' Functions used in authorising users
''' i.e. deciding what access they have
''' </summary>
''' <remarks></remarks>
Public Class AuthorisationUtil
    Public Enum AccessRole
        Administrator
        Manager
        Executive
        Operatr
        Guest
        Profile
        Suspended
    End Enum
    Public Shared Function GetRoleName(ByVal roleValue As AccessRole) As String
        Return [Enum].GetName(GetType(AccessRole), roleValue)
    End Function

    Public Shared Function GetCurrentUserid()
        Dim myIdentity As NetwyrksIIdentity
        myIdentity = My.User.CurrentPrincipal.Identity
        Return myIdentity.UserId
    End Function

End Class
