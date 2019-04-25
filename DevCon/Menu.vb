Public Class Menu

    Private Const FORM_NAME As String = "devcon menu"
    Public Const APPLICATION_CODE As String = "AnUbIs"
    Private sha1 As New System.Security.Cryptography.SHA1CryptoServiceProvider
    Private unlock1 As Char() = "qwertyuiopasd"
    Private unlock2 As Char() = "zxcvbnm"
    Private unlock3 As Char() = "smtwtfs"

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Menu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.StopLogging()
    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblFormName.Text = FORM_NAME
        LogUtil.StartLogging()
        If InputBox("Password?", "SERS DevCon", "", 200, 200) <> "st4g3+r3d" Then
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub btnCustomer_Click(sender As Object, e As EventArgs) Handles btnCustomer.Click
        Me.Hide()
        Using _customer As New frmDbConfig
            _customer.ShowDialog()
        End Using
        Me.Show()
    End Sub

    Private Sub btnSE_Click(sender As Object, e As EventArgs) Handles btnSE.Click
        Me.Hide()
        Using _se As New frmEncryptExisting
            _se.ShowDialog()
        End Using
        Me.Show()
    End Sub

    Private Sub ViewLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewLogToolStripMenuItem.Click
        Using _log As New frmLogViewer
            _log.ShowDialog()
        End Using
    End Sub

    Private Sub btnCreateAdminUser_Click(sender As Object, e As EventArgs) Handles btnCreateAdminUser.Click
        createAdminUser("Admin", "g49URAmX")
    End Sub

    Public Sub createAdminUser(ByVal _nameValue As String, ByVal _passwordValue As String)
        Dim _salt As String
        Dim oTa As New netwyrksDataSetTableAdapters.userTableAdapter
        Dim oTable As New netwyrksDataSet.userDataTable
        oTa.Fill(oTable)
        For Each oRow As netwyrksDataSet.userRow In oTable.Rows
            Debug.Print(oRow.user_name)
        Next
        Dim unlockCode As String
        Dim hashedUser As String = GetHashed(APPLICATION_CODE & _nameValue.Trim().ToLower())
        unlockCode = InputBox("Value", "Unlocking code:", "")
        Debug.Print(unlock1(Today.Month) & unlock2(Today.DayOfWeek) & unlock3(Today.DayOfWeek) & CStr(Today.Day) & "-")
        'If unlockCode.StartsWith(unlock1(Today.Month) & unlock2(Today.DayOfWeek) & unlock3(Today.DayOfWeek) & CStr(Today.Day) & "-") Then
        ' Dim ucode As String() = Split(unlockCode, "-")
        Dim ucode As String() = New String() {"", "XX"}
        If ucode.Length > 1 AndAlso (ucode(1).Length = 2 Or ucode(1).Length = 3) Then
            _salt = getNewSalt(_nameValue)
            If oTa.FillByLogin(oTable, hashedUser) = 0 Then
                Dim userId As Integer = oTa.InsertUser(hashedUser, "ADM", _
                                             GetHashed(_salt & Trim(_passwordValue)), _
                                                       "", False, _
                                            _salt, "Administrator", "", "", "", "", "Created by DevCon", Today, Today)
            End If
        End If
        'End If
        oTa.Dispose()
        oTable.Dispose()
    End Sub

    Private Function getNewSalt(ByVal username As String)
        Dim salt As String = CStr(Now.Millisecond) + username + Format(Now, "MMmmyyyyHHssdd") + "gadget"
        Return GetHashed(salt)
    End Function

    Private Function GetHashed(ByVal unHashed As String)
        Dim unHashedBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(unHashed)
        Dim hashedBytes() As Byte = sha1.ComputeHash(unHashedBytes)
        Return Convert.ToBase64String(hashedBytes)
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Using _se As New frmEncryptValue
            _se.ShowDialog()
        End Using
        Me.Show()
    End Sub
End Class