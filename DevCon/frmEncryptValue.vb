Public Class frmEncryptValue
#Region "Contants"
    Private Const FORM_NAME As String = "encrypt"
#End Region
#Region "Private variable instances"

#End Region

#Region "Form"
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Starting", FORM_NAME)
        lblFormName.Text = FORM_NAME
    End Sub
    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        My.Computer.Clipboard.SetText(lblEncrypted.Text)
    End Sub

    Private Sub btnEncrypt_Click(sender As Object, e As EventArgs) Handles btnEncrypt.Click
        lblEncrypted.Text = EncryptionUtil.encryptText(lblDecrypted.Text.Trim)
    End Sub

    Private Sub btnDecrypt_Click(sender As Object, e As EventArgs) Handles btnDecrypt.Click
        lblDecrypted.Text = EncryptionUtil.decryptText(lblEncrypted.Text)
    End Sub

#End Region

#Region "Subroutines"
    Private Sub logStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information, Optional ByVal errorCode As String = Nothing)
        lblStatus.Text = sText
        If islogged Then LogUtil.addLog(sText, level, FORM_NAME, errorCode)
    End Sub
#End Region


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lblEncrypted.Text = ""
        lblDecrypted.Text = ""
    End Sub
End Class