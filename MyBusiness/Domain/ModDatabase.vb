Module ModDatabase
#Region "adapters"
    Private ReadOnly oUserTa As New netwyrksDataSetTableAdapters.userTableAdapter
    Private ReadOnly oUserTable As New netwyrksDataSet.userDataTable
#End Region
#Region "users"
    Public Function GetUserById(_id As Integer) As netwyrksDataSet.userRow
        oUserTa.FillById(oUserTable, _id)
        Dim oRow As netwyrksDataSet.userRow = Nothing
        If oUserTable.Rows.Count > 0 Then
            oRow = oUserTable.Rows(0)
        End If
        Return oRow
    End Function
    Public Function GetUserByLogin(_login As String) As netwyrksDataSet.userRow
        oUserTa.FillByLogin(oUserTable, _login)
        Dim oRow As netwyrksDataSet.userRow = Nothing
        If oUserTable.Rows.Count > 0 Then
            oRow = oUserTable.Rows(0)
        End If
        Return oRow
    End Function
    Public Function InsertUser(_user As User, _password As String) As Integer
        Dim newUserId As Integer = oUserTa.InsertUser(_user.User_login, _user.User_code,
                                                   AuthenticationUtil.GetHashed(_user.Salt & _password), _user.TempPassword, True,
                                                   _user.Salt,
                                                   _user.UserName, _user.ContactNumber, _user.Mobile, _user.Email, _user.JobTitle, _user.Note, Now, _user.UserRole)
        Return newUserId
    End Function
    Public Function UpdateUser(_user As User) As Integer
        Dim _forceChange As Integer = If(_user.ForcePasswordChange, 1, 0)
        Return oUserTa.UpdateUser(_user.User_code, _user.Password, _user.TempPassword,
                           _forceChange, _user.Salt, _user.UserName,
                           _user.ContactNumber, _user.Mobile, _user.Email,
                           _user.JobTitle, _user.Note, Now, _user.UserRole, _user.UserId)
    End Function
    Public Function GetAllUsers() As netwyrksDataSet.userDataTable
        oUserTa.Fill(oUserTable)
        Return oUserTable
    End Function
#End Region
End Module
