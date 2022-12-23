' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmImages
    Private _job As Job
    Public Property ForJob() As Job
        Get
            Return _job
        End Get
        Set(ByVal value As Job)
            _job = value
        End Set
    End Property
    Private oImageList As List(Of JobImage)

    Private Sub FrmImages_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closing", Name)
        My.Settings.ImagesFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub FrmImages_Load(sender As Object, e As EventArgs) Handles Me.Load
        LogUtil.Debug("Started", Name)
        GetFormPos(Me, My.Settings.ImagesFormPos)
        oImageList = New List(Of JobImage)
        If _job IsNot Nothing Then
            oImageList = GetJobImageByJob(_job)
        End If
        LoadImagesIntoTable()
    End Sub
    Private Sub LoadImagesIntoTable()

        DgvImages.Rows.Clear()

        For Each oCol As DataGridViewColumn In DgvImages.Columns
            oCol.Width = DgvImages.Size.Width / 4
        Next
        Dim _col As Integer = 0
        Dim oRow As DataGridViewRow = DgvImages.Rows(DgvImages.Rows.Add())

        For Each _image As JobImage In oImageList
            Dim _cell As DataGridViewImageCell = oRow.Cells(_col)
            Dim _bitmap As Bitmap = ImageUtil.ResizeImage(New Bitmap(Image.FromFile(_image.ImagePath)), _cell.Size.Width, _cell.Size.Width)
            oRow.Height = _cell.Size.Width
            _cell.Value = _bitmap
            _col += 1
            If _col >= oRow.Cells.Count Then
                oRow = DgvImages.Rows(DgvImages.Rows.Add())
                _col = 0
            End If
        Next
    End Sub

    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        Close()
    End Sub

End Class