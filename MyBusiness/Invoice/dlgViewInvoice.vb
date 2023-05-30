' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports HindlewareLib.Logging

Public Class DlgViewInvoice
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
        DialogResult = System.Windows.Forms.DialogResult.OK
        Close()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        DialogResult = System.Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
    Private Sub DlgViewInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Viewing Invoice", MyBase.Name)
        GetFormPos(Me, My.Settings.ViewInvoiceFormPos)
        If File.Exists(_fileName) Then
            WebBrowser1.Navigate(_fileName)
        End If
    End Sub

    Private Sub DlgViewInvoice_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.ViewInvoiceFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
#End Region
End Class
