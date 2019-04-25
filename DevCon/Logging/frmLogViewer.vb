'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author E Hindle
' Created June 2015

Imports System.Windows.Forms
Imports System.IO

Public Class frmLogViewer
    Const FORM_NAME As String = "log viewer"

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub LogViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblFormName.Text = FORM_NAME
        Me.Text = "Log: " & LogUtil.getLogfileName
        rtbLog.Text = LogUtil.GetLogContents()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        LogUtil.ClearLogFile()
        rtbLog.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoZoom.Click
        TrackBar1.Value = 10
    End Sub

    Private Sub TrackBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        rtbLog.ZoomFactor = TrackBar1.Value / 10
        btnNoZoom.Text = rtbLog.ZoomFactor
    End Sub

    Private Sub WrapTextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WrapTextToolStripMenuItem.Click
        rtbLog.WordWrap = WrapTextToolStripMenuItem.Checked
    End Sub

    Private Sub ZoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomToolStripMenuItem.Click
        TrackBar1.Visible = ZoomToolStripMenuItem.Checked
        btnNoZoom.Visible = ZoomToolStripMenuItem.Checked
        If ZoomToolStripMenuItem.Checked = False Then
            TrackBar1.Value = 10
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        rtbLog.Copy()
    End Sub

    Private Sub CopyAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyAllToolStripMenuItem.Click
        rtbLog.SelectAll()
        rtbLog.Copy()
        rtbLog.Select(0, 0)
    End Sub

End Class
