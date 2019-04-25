''' <summary>
''' Functions used in authorising users
''' i.e. deciding what access they have
''' </summary>
''' <remarks></remarks>
Public Class AuthorisationUtil
    Public Enum sersRole
        Administrator
        Manager
        Executive
        Operatr
        Guest
        Profile
        Suspended
    End Enum
    Public Shared Function getRoleName(ByVal roleValue As sersRole) As String
        Return [Enum].GetName(GetType(sersRole), roleValue)
    End Function

    Public Shared Function getCurrentUserid()
        Dim myIdentity As netwyrksIIdentity
        myIdentity = My.User.CurrentPrincipal.Identity
        Return myIdentity.userId
    End Function

End Class
