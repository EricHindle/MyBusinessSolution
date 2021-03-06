﻿
'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.Drawing.Imaging

''' <summary>
''' This form is displayed when the about menu option is selected
''' </summary>
''' <remarks>This form provides some useful version and run environment information</remarks>
Public NotInheritable Class frmAbout

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        ' Initialize all of the text displayed on the About Box.
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
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
        Me.TextBoxDescription.Text = _
                vbCrLf & "Multi-operator Self Exclusion" & vbCrLf & _
                vbCrLf & "Computer name : " & My.Computer.Name & _
                vbCrLf & "Data connection: " & _
                vbCrLf & "   server=" & serverName & _
                vbCrLf & "   database=" & dbName & _
                vbCrLf & "Application path is " & My.Application.Info.DirectoryPath & _
                vbCrLf & "Cache path is " & sCacheFolder

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

End Class
