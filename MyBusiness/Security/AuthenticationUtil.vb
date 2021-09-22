' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports MyBusiness.NetwyrksErrorCodes
Imports System.Security.Cryptography
Imports i00SpellCheck
''' <summary>
''' Functions used in authenticating users
''' i.e. deciding whether they are who they say they are
''' </summary>
''' <remarks></remarks>
Public Class AuthenticationUtil
#Region "Constants"
    Public Const APPLICATION_CODE As String = "AnUbIs"
    Public Const TRANSFORM_INITIALISER As String = "3gUcfgF1WnKdadf"
    Private Const PASSWORD_CHARS_LCASE As String = "abcdefghjkmnpqrstwxyz"
    Private Const PASSWORD_CHARS_UCASE As String = "ABCDEFGHJKLMNPQRSTWXYZ"
    Private Const PASSWORD_CHARS_NUMERIC As String = "23456789"
    Private Const PASSWORD_CHARS_SPECIAL As String = "*$-+?&=!%{}"

#End Region
#Region "Variables"
    Private Shared ReadOnly sha1 As New System.Security.Cryptography.SHA1CryptoServiceProvider
    Private Shared ReadOnly minPwdLen As Integer = GlobalSettings.getIntegerSetting("minPwdLen")
    Private Shared oDict As FlatFileDictionary = Nothing
#End Region
#Region "Salt"
    ''' <summary>
    ''' Find the user's encryption salt from the user id
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getUserSalt(ByVal userId As Integer) As String
        Dim oTa As New netwyrksDataSetTableAdapters.userTableAdapter
        Dim oTable As New netwyrksDataSet.userDataTable
        Dim i As Integer = oTa.FillById(oTable, userId)
        Dim oSalt As String = ""
        If i = 1 Then
            Dim oRow As netwyrksDataSet.userRow = oTable.Rows(0)
            oSalt = oRow.salt
        End If
        oTa.Dispose()
        oTable.Dispose()
        Return oSalt
    End Function

    ''' <summary>
    ''' Create a new salt 
    ''' </summary>
    ''' <param name="username"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getNewSalt(ByVal username As String)
        Dim salt As String = CStr(Now.Millisecond) + username + Format(Now, "MMmmyyyyHHssdd") + "gadget"
        Return GetHashed(salt)
    End Function
#End Region
#Region "Hashing"

    ''' <summary>
    ''' Get the hashed value of a string
    ''' </summary>
    ''' <param name="unHashed"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetHashed(ByVal unHashed As String) As String
        Dim unHashedBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(unHashed)
        Dim hashedBytes() As Byte = sha1.ComputeHash(unHashedBytes)
        Return Convert.ToBase64String(hashedBytes)
    End Function

    ''' <summary>
    ''' Get the hashed value of a username
    ''' </summary>
    ''' <param name="username"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function hashedUsername(ByVal username As String) As String
        Return AuthenticationUtil.GetHashed(APPLICATION_CODE & username.Trim().ToLower())
    End Function
#End Region
#Region "authenticate"

    ''' <summary>
    ''' Test if a password is correct for the user identity passed in
    ''' </summary>
    ''' <param name="string1"></param>
    ''' <param name="myIdentity"></param>
    ''' <returns></returns>
    ''' <remarks>The user has a single current password and may have a temporary password if a password reset has been requested.
    ''' Either password will grant access</remarks>
    Public Shared Function isPasswordOK(ByVal string1 As String, ByVal myIdentity As netwyrksIIdentity) As Boolean
        Dim rtnval As Boolean = False
        Dim oTa As New netwyrksDataSetTableAdapters.userTableAdapter
        Dim oTable As New netwyrksDataSet.userDataTable
        Dim userId As Integer = myIdentity.userId
        Dim salt As String = ""
        If oTa.FillById(oTable, userId) = 1 Then
            Dim oRow As netwyrksDataSet.userRow = oTable.Rows(0)
            salt = oRow.salt
            Dim hashedCurrentPW As String = AuthenticationUtil.GetHashed(salt & string1)
            Dim hashedExistingPw As String = oRow.user_password
            Dim hashedTempPW As String = If(oRow.Istemp_passwordNull, Nothing, oRow.temp_password)
            If hashedCurrentPW = hashedExistingPw Or hashedCurrentPW = hashedTempPW Then
                rtnval = True
            End If
        End If
        oTa.Dispose()
        oTable.Dispose()
        Return rtnval
    End Function

    ''' <summary>
    ''' Test if a password is correct for the current user's user identity
    ''' </summary>
    ''' <param name="string1"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function isPasswordOK(ByVal string1 As String) As Boolean
        Dim myIdentity As netwyrksIIdentity = My.User.CurrentPrincipal.Identity
        Return isPasswordOK(string1, myIdentity)
    End Function

    ''' <summary>
    ''' Check if the current user must chnage their password and if yes ask the current user for a new password
    ''' </summary>
    ''' <returns>true if the user has changed their password or doesn't need to</returns>
    ''' <remarks></remarks>
    Public Shared Function isPasswordChangeOK() As Boolean
        Dim rtnval As Boolean = False
        Dim myIdentity As netwyrksIIdentity = My.User.CurrentPrincipal.Identity
        Dim userId As Integer = myIdentity.userId
        Dim oTa As New netwyrksDataSetTableAdapters.userTableAdapter
        Dim oTable As New netwyrksDataSet.userDataTable
        If oTa.FillById(oTable, userId) = 1 Then
            Dim oRow As netwyrksDataSet.userRow = oTable.Rows(0)
            If Not oRow.Isforce_password_changeNull AndAlso oRow.force_password_change Then
                Using _pwdChange As New frmChangePassword
                    _pwdChange.forceChange = True
                    If _pwdChange.ShowDialog = DialogResult.OK Then
                        rtnval = True
                    End If
                End Using
            Else
                rtnval = True
            End If
        End If
        oTa.Dispose()
        oTable.Dispose()
        Return rtnval
    End Function
#End Region
#Region "Users"
    ''' <summary>
    ''' Permanently remove a user
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RemoveUser(ByVal userId As Integer) As String
        Dim returnValue As String = ""
        Dim oTa As New netwyrksDataSetTableAdapters.userTableAdapter
        If userId = 0 Then
            Throw New ApplicationException("No username entered")
        Else
            Try

                If oTa.DeleteUser(userId) = 1 Then
                    returnValue = "User removed"
                Else
                    returnValue = "User  not found"
                End If
            Catch ex As Exception
                LogUtil.Exception("Exception removing user : " & ex.Message, ex, getErrorCode(SystemModule.SECURITY, ErrorType.DATABASE, FailedAction.DELETION_EXCEPTION))
                Throw New ApplicationException("Exception removing user : " & ex.Message)
            End Try
        End If
        oTa.Dispose()
        Return returnValue
    End Function

    ''' <summary>
    ''' Update a user password
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <param name="string1"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SavePassword(ByVal userId As Integer, ByVal string1 As String) As Boolean
        Dim returnValue As Boolean = False
        Dim oTa As New netwyrksDataSetTableAdapters.userTableAdapter
        Dim oTable As New netwyrksDataSet.userDataTable
        If userId = 0 Then
            Throw New ApplicationException("No userid supplied")
        Else
            Try
                Dim salt As String = getUserSalt(userId)
                Dim hashedPW As String = AuthenticationUtil.GetHashed(salt & string1)
                If oTa.UpdatePassword(hashedPW, Now, userId) = 1 Then
                    returnValue = True
                End If
            Catch ex As Exception
                LogUtil.Exception("Exception saving password : " & ex.Message, ex, , getErrorCode(SystemModule.SECURITY, ErrorType.DATABASE, FailedAction.UPDATE_EXCEPTION))
                Throw New ApplicationException("Exception saving password : " & ex.Message)
            End Try
        End If
        oTa.Dispose()
        oTable.Dispose()
        Return returnValue
    End Function

    Public Shared Function getUserLogin(ByVal userid As Integer) As String
        Dim usrLogin As String = ""
        Dim oTa As New netwyrksDataSetTableAdapters.userTableAdapter
        Dim oTable As New netwyrksDataSet.userDataTable
        If oTa.FillById(oTable, userid) = 1 Then
            Dim oRow As netwyrksDataSet.userRow = oTable.Rows(0)
            usrLogin = oRow.user_login
        End If
        oTa.Dispose()
        oTable.Dispose()
        Return usrLogin
    End Function

    Public Shared Function getUserCode(ByVal userid As Integer) As String
        Dim userCode As String = ""
        Dim oTa As New netwyrksDataSetTableAdapters.userTableAdapter
        Dim oTable As New netwyrksDataSet.userDataTable
        If oTa.FillById(oTable, userid) = 1 Then
            Dim oRow As netwyrksDataSet.userRow = oTable.Rows(0)
            userCode = oRow.user_code
        End If
        oTa.Dispose()
        oTable.Dispose()
        Return userCode
    End Function

    Public Shared Function getUserEmail(ByVal userid As Integer) As String
        Dim userEmail As String = ""
        Dim oTa As New netwyrksDataSetTableAdapters.userTableAdapter
        Dim oTable As New netwyrksDataSet.userDataTable
        If oTa.FillById(oTable, userid) = 1 Then
            Dim oRow As netwyrksDataSet.userRow = oTable.Rows(0)
            userEmail = If(oRow.Isuser_emailNull, "", oRow.user_email)
        End If
        oTa.Dispose()
        oTable.Dispose()
        Return userEmail
    End Function
    Public Shared Function getUserName(ByVal userid As Integer) As String
        Dim userName As String = ""
        Dim oTa As New netwyrksDataSetTableAdapters.userTableAdapter
        Dim oTable As New netwyrksDataSet.userDataTable
        If oTa.FillById(oTable, userid) = 1 Then
            Dim oRow As netwyrksDataSet.userRow = oTable.Rows(0)
            userName = oRow.user_name
        End If
        oTa.Dispose()
        oTable.Dispose()
        Return userName
    End Function
#End Region
#Region "password"

    ''' <summary>
    ''' Create a temporary password for a user and inform them via email to the registered email address
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <param name="salt"></param>
    ''' <param name="sEmail"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function createUserTemporaryPassword(ByVal userId As Integer, ByVal salt As String, ByVal sEmail As String) As Boolean
        Dim isCreatedOK As Boolean = False
        Dim oUserTa As New netwyrksDataSetTableAdapters.userTableAdapter

        Dim newTempPassword As String = AuthenticationUtil.generatePassword()
        Try
            Dim emailAddress As String = sEmail
            Dim validate As New ValidationUtil
            Dim sentOnBehalfOf As String = "noreply@self-exclusion.co.uk"
            If validate.IsValidEmail(emailAddress) Then
                If oUserTa.UpdateTempPassword(AuthenticationUtil.GetHashed(salt & newTempPassword), Now, userId, True) = 1 Then
                    AuditUtil.addAudit(currentUser.userId, AuditUtil.RecordType.User, userId, AuditUtil.AuditableAction.update, "Temporary password created", newTempPassword)

                    Dim userEmailAddress As String = emailAddress
                    If EmailUtil.SendMail(sentOnBehalfOf,
                            userEmailAddress,
                            {},
                            "Temporary SERS Password",
                            PASSWORD_CHANGE_EMAIL.Replace("{}",
                            newTempPassword)) Then
                        isCreatedOK = True
                        MsgBox("An email has been sent to your registered address.", , "Password Reset")
                    Else
                        MsgBox("We are unable to reset your password. Contact the system administrator.", , "Password Reset")
                    End If
                Else
                    isCreatedOK = False
                End If
            Else
                isCreatedOK = False
            End If
        Catch ex As Exception
            isCreatedOK = False
        Finally
            oUserTa.Dispose()
        End Try
        Return isCreatedOK
    End Function

    Public Shared Function generateWordyPassword(Optional ByVal includeSpecialChar As Boolean = True) As String
        Dim AllWords As List(Of String)
        Dim rng As Random = GetRandomNumberGenerator()
        Dim charIndex As Integer = rng.Next(0, PASSWORD_CHARS_SPECIAL.Length - 1)
        Dim specChar As String = If(includeSpecialChar, PASSWORD_CHARS_SPECIAL(charIndex), "")
        If oDict Is Nothing Then
            'dict not loaded yet
            FlatFileDictionary.LoadDefaultDictionary()
            oDict = DirectCast(Dictionary.DefaultDictionary, FlatFileDictionary)
        End If
        Randomize()
        AllWords = oDict.IndexedDictionary.GetFullList
        Dim word1 As String = (From xItem In AllWords Where xItem.Length <= 6 And xItem.Length > 2 Order By Rnd()).FirstOrDefault
        Dim word2 As String = (From xItem In AllWords Where xItem.Length <= 6 And xItem.Length > 2 Order By Rnd()).FirstOrDefault
        Dim word3 As String = word1.Replace("e", "3").Replace("a", "4")
        Dim word4 As String = word2.Replace("i", "1").Replace("o", "0")
        Return word3 & specChar & word4
    End Function

    ''' <summary>
    ''' Generate a random strong password
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function generatePassword() As String
        Dim charGroups As Char()() = New Char()() _
           { _
               PASSWORD_CHARS_LCASE.ToCharArray(), _
               PASSWORD_CHARS_UCASE.ToCharArray(), _
               PASSWORD_CHARS_NUMERIC.ToCharArray(), _
               PASSWORD_CHARS_SPECIAL.ToCharArray() _
           }

        ' Use this array to track the number of unused characters in each
        ' character group.
        Dim charsLeftInGroup As Integer() = New Integer(charGroups.Length - 1) {}

        ' Initially, all characters in each group are not used.
        Dim I As Integer
        For I = 0 To charsLeftInGroup.Length - 1
            charsLeftInGroup(I) = charGroups(I).Length
        Next

        ' Use this array to track (iterate through) unused character groups.
        Dim leftGroupsOrder As Integer() = New Integer(charGroups.Length - 1) {}

        ' Initially, all character groups are not used.
        For I = 0 To leftGroupsOrder.Length - 1
            leftGroupsOrder(I) = I
        Next

        Dim random As Random = GetRandomNumberGenerator()

        ' This array will hold password characters.
        Dim password As Char() = Nothing

        ' Allocate appropriate memory for the password.
        password = New Char(minPwdLen - 1) {}

        ' Index of the next character to be added to password.
        Dim nextCharIdx As Integer

        ' Index of the next character group to be processed.
        Dim nextGroupIdx As Integer

        ' Index which will be used to track not processed character groups.
        Dim nextLeftGroupsOrderIdx As Integer

        ' Index of the last non-processed character in a group.
        Dim lastCharIdx As Integer

        ' Index of the last non-processed group.
        Dim lastLeftGroupsOrderIdx As Integer = leftGroupsOrder.Length - 1

        ' Generate password characters one at a time.
        For I = 0 To password.Length - 1

            ' If only one character group remained unprocessed, process it;
            ' otherwise, pick a random character group from the unprocessed
            ' group list. To allow a special character to appear in the
            ' first position, increment the second parameter of the Next
            ' function call by one, i.e. lastLeftGroupsOrderIdx + 1.
            If (lastLeftGroupsOrderIdx = 0) Then
                nextLeftGroupsOrderIdx = 0
            Else
                nextLeftGroupsOrderIdx = random.Next(0, lastLeftGroupsOrderIdx)
            End If

            ' Get the actual index of the character group, from which we will
            ' pick the next character.
            nextGroupIdx = leftGroupsOrder(nextLeftGroupsOrderIdx)

            ' Get the index of the last unprocessed characters in this group.
            lastCharIdx = charsLeftInGroup(nextGroupIdx) - 1

            ' If only one unprocessed character is left, pick it; otherwise,
            ' get a random character from the unused character list.
            If (lastCharIdx = 0) Then
                nextCharIdx = 0
            Else
                nextCharIdx = random.Next(0, lastCharIdx + 1)
            End If

            ' Add this character to the password.
            password(I) = charGroups(nextGroupIdx)(nextCharIdx)

            ' If we processed the last character in this group, start over.
            If (lastCharIdx = 0) Then
                charsLeftInGroup(nextGroupIdx) = _
                                charGroups(nextGroupIdx).Length
                ' There are more unprocessed characters left.
            Else
                ' Swap processed character with the last unprocessed character
                ' so that we don't pick it until we process all characters in
                ' this group.
                If (lastCharIdx <> nextCharIdx) Then
                    Dim temp As Char = charGroups(nextGroupIdx)(lastCharIdx)
                    charGroups(nextGroupIdx)(lastCharIdx) = _
                                charGroups(nextGroupIdx)(nextCharIdx)
                    charGroups(nextGroupIdx)(nextCharIdx) = temp
                End If

                ' Decrement the number of unprocessed characters in
                ' this group.
                charsLeftInGroup(nextGroupIdx) = _
                           charsLeftInGroup(nextGroupIdx) - 1
            End If

            ' If we processed the last group, start all over.
            If (lastLeftGroupsOrderIdx = 0) Then
                lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1
                ' There are more unprocessed groups left.
            Else
                ' Swap processed group with the last unprocessed group
                ' so that we don't pick it until we process all groups.
                If (lastLeftGroupsOrderIdx <> nextLeftGroupsOrderIdx) Then
                    Dim temp As Integer = _
                                leftGroupsOrder(lastLeftGroupsOrderIdx)
                    leftGroupsOrder(lastLeftGroupsOrderIdx) = _
                                leftGroupsOrder(nextLeftGroupsOrderIdx)
                    leftGroupsOrder(nextLeftGroupsOrderIdx) = temp
                End If

                ' Decrement the number of unprocessed groups.
                lastLeftGroupsOrderIdx = lastLeftGroupsOrderIdx - 1
            End If
        Next

        ' Convert password characters into a string and return the result.
        Return New String(password)
    End Function

    Private Shared Function GetRandomNumberGenerator() As Random
        ' Use a 4-byte array to fill it with random bytes and convert it then
        ' to an integer value.
        Dim randomBytes As Byte() = New Byte(3) {}
        ' Generate 4 random bytes.
        Dim rng As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
        rng.GetBytes(randomBytes)
        ' Convert 4 bytes into a 32-bit integer value.
        Dim seed As Integer = BitConverter.ToInt32(randomBytes, 0)
        ' Now, this is real randomization.
        Return New Random(seed)
    End Function
#End Region
End Class
