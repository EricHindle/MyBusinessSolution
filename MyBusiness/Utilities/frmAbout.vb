' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

''' <summary>
''' This form is displayed when the about menu option is selected
''' </summary>
''' <remarks>This form provides some useful version and run environment information</remarks>
Public NotInheritable Class FrmAbout
    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        ' Initialize all of the text displayed on the About Box.
        LabelProductName.Text = My.Application.Info.ProductName
        LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        LabelCopyright.Text = My.Application.Info.Copyright
        LabelCompanyName.Text = My.Application.Info.CompanyName
        Dim sConnection As String() = Split(My.Settings.netwyrksConnectionString, ";")
        Dim serverName As String = ""
        Dim dbName As String = ""
        For Each oConn As String In sConnection
            Dim nvp As String() = Split(oConn, "=")
            If nvp.GetUpperBound(0) = 1 Then
                Select Case nvp(0)
                    Case "server"
                        serverName = nvp(1)
                    Case "database"
                        dbName = nvp(1)
                End Select
            End If
        Next
        TextBoxDescription.Text =
                vbCrLf & "MyBusiness Work Management" & vbCrLf &
                vbCrLf & "Computer name : " & My.Computer.Name &
                vbCrLf & "Data connection: " &
                vbCrLf & "   server=" & serverName &
                vbCrLf & "   database=" & dbName &
                vbCrLf & "Application path is " & My.Application.Info.DirectoryPath &
                vbCrLf & "Cache path is " & sCacheFolder
    End Sub
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class
