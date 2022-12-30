' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class frmInfoSplash
#Region "private variables"
    Private _message As String
    Private _lifeTime As Integer
#End Region
#Region "properties"
    Public WriteOnly Property LifeTime() As Integer
        Set(ByVal value As Integer)
            _lifeTime = value
        End Set
    End Property
    Public WriteOnly Property Message() As String
        Set(ByVal value As String)
            _message = value
            lblMessage.Text = _message
        End Set
    End Property
#End Region
#Region "form event handlers"
    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Text = _message
        PictureBox1.Top = lblMessage.Top + ((lblMessage.Height - PictureBox1.Height) / 2)
        PictureBox1.BringToFront()
        If _lifeTime > 0 Then
            Timer1.Interval = _lifeTime
            Timer1.Start()
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        Close()
    End Sub
#End Region
End Class