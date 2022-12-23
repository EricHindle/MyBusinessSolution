' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmImages
#Region "properties"
    Private _job As Job
    Public Property ForJob() As Job
        Get
            Return _job
        End Get
        Set(ByVal value As Job)
            _job = value
        End Set
    End Property
#End Region
#Region "variables"
    Private oImageList As List(Of JobImage)
    Private _selectedImage As JobImage
#End Region
#Region "form control handlers"
    Private Sub FrmImages_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closing", Name)
        My.Settings.ImagesFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub FrmImages_Load(sender As Object, e As EventArgs) Handles Me.Load
        LogUtil.Debug("Started", Name)
        GetFormPos(Me, My.Settings.ImagesFormPos)
        RefreshImageTable()
    End Sub
    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        Close()
    End Sub
    Private Sub DgvImages_SizeChanged(sender As Object, e As EventArgs) Handles DgvImages.SizeChanged
        If oImageList IsNot Nothing Then
            LoadImagesIntoTable()
        End If
    End Sub
    Private Sub DgvImages_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvImages.CellDoubleClick
        Dim _imageNo As Integer = (e.RowIndex * DgvImages.ColumnCount) + e.ColumnIndex
        If _imageNo < oImageList.Count Then
            ShowStatus(LblStatus, "Opening Image", MyBase.Name, True)
            Dim _filepath As String = oImageList(_imageNo).ImagePath
            Try
                If My.Computer.FileSystem.FileExists(_filepath) Then
                    Process.Start(_filepath)
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub DgvImages_SelectionChanged(sender As Object, e As EventArgs) Handles DgvImages.SelectionChanged
        ShowStatus(LblStatus, "")
        If oImageList.Count > 0 AndAlso DgvImages.SelectedCells.Count > 0 Then
            Dim _selectedCell As DataGridViewCell = DgvImages.SelectedCells(0)
            Dim _imageNo As Integer = (_selectedCell.RowIndex * DgvImages.ColumnCount) + _selectedCell.ColumnIndex
            _selectedImage = oImageList(_imageNo)
            TxtImageDesc.Text = _selectedImage.ImageDesc
            TxtImagePath.Text = _selectedImage.ImagePath
        Else
            _selectedImage = Nothing
            TxtImageDesc.Text = ""
            TxtImagePath.Text = ""
        End If
    End Sub
    Private Sub PicAdd_Click(sender As Object, e As EventArgs) Handles PicAdd.Click
        If My.Computer.FileSystem.FileExists(TxtImagePath.Text) Then
            ShowStatus(LblStatus, "Inserting Image", MyBase.Name, True)
            Dim _jobimg As JobImage = JobImageBuilder.aJobImage _
                                                    .StartingWithNothing() _
                                                    .WithJobId(_job.JobId) _
                                                    .WithImagePath(TxtImagePath.Text) _
                                                    .WithImageDesc(TxtImageDesc.Text).Build
            If InsertJobImage(_jobimg) = 1 Then
                RefreshImageTable()
                ShowStatus(LblStatus, "Inserted Image", MyBase.Name, True)
            Else
                ShowStatus(LblStatus, "Insert failed", MyBase.Name, True)
            End If
        Else
            ShowStatus(LblStatus, "File not found", MyBase.Name, False)
        End If
    End Sub

    Private Sub PicRemove_Click(sender As Object, e As EventArgs) Handles PicRemove.Click
        If _selectedImage IsNot Nothing Then
            ShowStatus(LblStatus, "Removing Image", MyBase.Name, True)
            If MsgBox("Delete " & _selectedImage.ImageDesc _
                    & " (" & IO.Path.GetFileName(_selectedImage.ImagePath) & ")?",
                          MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeleteJobImage(_selectedImage.ImageId) = 1 Then
                    RefreshImageTable()
                    ShowStatus(LblStatus, "Removed Image", MyBase.Name, True)
                Else
                    ShowStatus(LblStatus, "Delete failed", MyBase.Name, True)
                End If
            End If
        Else
            ShowStatus(LblStatus, "No Image Selected", MyBase.Name, True)
        End If
    End Sub

    Private Sub PicUpdate_Click(sender As Object, e As EventArgs) Handles PicUpdate.Click
        If _selectedImage IsNot Nothing AndAlso My.Computer.FileSystem.FileExists(TxtImagePath.Text) Then
            ShowStatus(LblStatus, "Updating Image", MyBase.Name, True)
            Dim _jobimg As JobImage = JobImageBuilder.aJobImage _
                                                    .StartingWithNothing() _
                                                    .WithImageId(_selectedImage.ImageId) _
                                                    .WithJobId(_job.JobId) _
                                                    .WithImagePath(TxtImagePath.Text) _
                                                    .WithImageDesc(TxtImageDesc.Text).Build
            If UpdateJobImage(_jobimg) = 1 Then
                RefreshImageTable()
                ShowStatus(LblStatus, "Updated Image", MyBase.Name, True)
            Else
                ShowStatus(LblStatus, "Update failed", MyBase.Name, True)
            End If
        Else
            ShowStatus(LblStatus, "File not found", MyBase.Name, False)
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub RefreshImageTable()
        oImageList = New List(Of JobImage)
        If _job IsNot Nothing Then
            oImageList = GetJobImageByJob(_job)
        End If
        LoadImagesIntoTable()
    End Sub
    Private Sub LoadImagesIntoTable()
        DgvImages.Rows.Clear()
        Dim _col As Integer = 0
        Dim oRow As DataGridViewRow = DgvImages.Rows(DgvImages.Rows.Add())
        Dim oCell As DataGridViewImageCell = oRow.Cells(_col)
        oRow.Height = oCell.Size.Width
        For Each _image As JobImage In oImageList
            If _col >= oRow.Cells.Count Then
                oRow = DgvImages.Rows(DgvImages.Rows.Add())
                oRow.Height = oCell.Size.Width
                _col = 0
            End If
            Dim _pic As Image = Image.FromFile(_image.ImagePath)
            Dim _wmultiplier As Decimal = 1
            Dim _hmultiplier As Decimal = 1
            Dim _newWidth As Integer = oCell.Size.Width
            Dim _newHeight As Integer = oRow.Height
            If _pic.Size.Width > _pic.Size.Height Then
                _hmultiplier = _pic.Size.Height / _pic.Size.Width
                _newHeight = oRow.Height * _hmultiplier
            Else
                _wmultiplier = _pic.Size.Width / _pic.Size.Height
                _newWidth = oCell.Size.Width * _wmultiplier
            End If
            Dim _cell As DataGridViewImageCell = oRow.Cells(_col)
            Dim _bitmap As Bitmap = ImageUtil.ResizeImage(New Bitmap(_pic), _newWidth, _newHeight)
            _cell.Value = _bitmap
            _col += 1
        Next
        DgvImages.ClearSelection()
    End Sub

    Private Sub BtnFindFile_Click(sender As Object, e As EventArgs) Handles BtnFindFile.Click
        TxtImagePath.Text = ImageUtil.GetImageFileName(ImageUtil.OpenOrSave.Open, ImageUtil.ImageType.ALL, sImageFolder)
    End Sub

#End Region
End Class