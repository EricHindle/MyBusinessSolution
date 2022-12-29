' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmJobTemplates
    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        Me.Close()
    End Sub

    Private Sub FrmJobTemplates_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", Name)
        My.Settings.TmplFormPos = SetFormPos(Me)
        My.Settings.TmplSplitterDist1 = SplitContainer1.SplitterDistance
        My.Settings.TmplSplitterDist2 = SplitContainer2.SplitterDistance
        My.Settings.Save()
    End Sub

    Private Sub FrmJobTemplates_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Started", Name)
        If GetFormPos(Me, My.Settings.TmplFormPos) Then
            SplitContainer1.SplitterDistance = CInt("0" & My.Settings.TmplSplitterDist1)
            SplitContainer2.SplitterDistance = CInt("0" & My.Settings.TmplSplitterDist2)
        End If
    End Sub

    Private Sub BtnMaintProducts_Click(sender As Object, e As EventArgs) Handles btnMaintProducts.Click
        'LogUtil.Debug("Maintain products on job", Name)
        'Using _jobProductForm As New FrmJobProducts
        '    _jobProductForm.TheJob = _job
        '    _jobProductForm.SelectedJobProduct = Nothing
        '    _jobProductForm.ShowDialog()
        'End Using
        'FillProductList(_currentJobId)
    End Sub
End Class