' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.IO
Imports System.Windows.Forms

Public Class dlgViewInvoice
#Region "variables"

#End Region
#Region "properties"
    Private _fileName As String
    Public WriteOnly Property Filename() As String
        Set(ByVal value As String)
            _fileName = value
        End Set
    End Property
#End Region
#Region "form handlers"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub DlgViewInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(_fileName) Then
            WebBrowser1.Navigate(_fileName)
        End If
    End Sub
#End Region
End Class
