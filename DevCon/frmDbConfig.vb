
' Copyright (c) 2015, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
' Created Oct 2015

Imports MySql.Data.MySqlClient

''' <summary>
''' Utility to help set-up SERS for release
''' </summary>
''' <remarks></remarks>
Public Class frmDbConfig
#Region "Contants"
    Private Const FORM_NAME As String = "SERS DB Config"
#End Region

#Region "Private variable instances"
    Private className As String = Me.GetType.Name
#End Region

#Region "Form"
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.StopLogging()
    End Sub

    Private Sub form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Starting", FORM_NAME)
        lblFormName.Text = FORM_NAME
    End Sub
#End Region

#Region "Subroutines"
    Private Sub logStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information, Optional ByVal errorCode As String = Nothing)
        lblStatus.Text = sText
        If islogged Then LogUtil.addLog(sText, level, FORM_NAME, errorCode)
    End Sub

    ''' <summary>
    ''' Encrypt the password.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' Uses a key that is only used for this purpose.
    ''' The same key is coded into the SERS Activation utility</remarks>
    Private Sub btnEncrypt_Click(sender As Object, e As EventArgs) Handles btnEncrypt.Click
        lblEncrypted.Text = EncryptionUtil.encryptText(txtPassword.Text.Trim, EncryptionUtil.DB_PASSWORD_ENCRYPTION_KEY)
    End Sub

    ''' <summary>
    ''' Test the database connection using the details supplied
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        LogUtil.Info("Testing DB connection", classname)
        Dim _ConnectionString As String = ""
        Dim isSuccess As Boolean = False
        Try
            _ConnectionString = "server=" & txtServer.Text & ";user id=" & txtUser.Text & ";password=" & txtPassword.Text & ";persistsecurityinfo=True;database=" & txtDatabase.Text
            Using sqlConn As New MySql.Data.MySqlClient.MySqlConnection(_ConnectionString)
                sqlConn.Open()
                isSuccess = (sqlConn.State = ConnectionState.Open)
            End Using
        Catch e1 As MySqlException
            isSuccess = False
            LogUtil.Exception("DB connection SQL exception", e1, "btnTest")
        Catch e2 As Exception
            isSuccess = False
            LogUtil.Exception("DB connection exception", e2, "btnTest")
        End Try
        lblSuccess.Text = If(isSuccess, "Success", "Failed")
        LogUtil.Info(lblSuccess.Text, className)
    End Sub

    ''' <summary>
    ''' Copy the encrypted password to the clipboard
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        My.Computer.Clipboard.SetText(lblEncrypted.Text)
    End Sub
#End Region

    Private Sub btnDecrypt_Click(sender As Object, e As EventArgs) Handles btnDecrypt.Click
        lblDecrypt.Text = EncryptionUtil.decryptText(lblEncrypted.Text, EncryptionUtil.DB_PASSWORD_ENCRYPTION_KEY)
    End Sub
End Class
