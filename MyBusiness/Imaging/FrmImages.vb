' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.ComponentModel
Imports System.IO
Imports HindlewareLib.Domain.Objects
Imports HindlewareLib.Imaging
Imports HindlewareLib.Logging
Public Class FrmImages
    Private Const OPACITY_VALUE As Single = 0.3
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
#Region "constants"
#End Region
#Region "variables"
    Private oImageList As List(Of JobImage)
    Private _selectedImage As JobImage
    Private oImageFolderName As String
    Private oJobImageFolder As String
    Private oNextImageRow As DataGridViewRow = Nothing
    Private oNextImageCol As Integer = 0
    Private isLoading As Boolean
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
        oImageFolderName = My.Settings.ImageFolder
        If _job IsNot Nothing Then
            oJobImageFolder = Path.Combine(oImageFolderName, "Job" & _job.JobId)
            Dim _resp As SuccessResponse = CreateFolder(oJobImageFolder)
            If Not String.IsNullOrEmpty(_resp.Message) Then
                ShowStatus(LblStatus, _resp, MyBase.Name, True)
            End If
        Else
            oJobImageFolder = oImageFolderName
        End If
        RefreshImageTable()
        PicAdd.Visible = False
        PicUpdate.Visible = False
        PicRemove.Visible = False
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
            Catch ex As Win32Exception
                ShowStatus(LblStatus, "Exception opening image", MyBase.Name, True, ex)
            End Try
        End If
    End Sub
    Private Sub DgvImages_SelectionChanged(sender As Object, e As EventArgs) Handles DgvImages.SelectionChanged
        ShowStatus(LblStatus, "")
        If Not isLoading Then
            If oImageList.Count > 0 AndAlso DgvImages.SelectedCells.Count > 0 Then
                Dim _selectedCell As DataGridViewCell = DgvImages.SelectedCells(0)
                Dim _imageNo As Integer = (_selectedCell.RowIndex * DgvImages.ColumnCount) + _selectedCell.ColumnIndex
                If _imageNo < oImageList.Count Then
                    _selectedImage = oImageList(_imageNo)
                    TxtImageDesc.Text = _selectedImage.ImageDesc
                    TxtImagePath.Text = _selectedImage.ImagePath
                Else
                    ClearSelection()
                End If
            Else
                ClearSelection()
            End If
        End If
    End Sub
    Private Sub PicAdd_Click(sender As Object, e As EventArgs) Handles PicAdd.Click
        If My.Computer.FileSystem.FileExists(TxtImagePath.Text) Then
            ShowStatus(LblStatus, "Adding Image to Job", MyBase.Name, True)
            Dim _jobimg As JobImage = JobImageBuilder.aJobImage _
                                                    .StartingWithNothing() _
                                                    .WithJobId(_job.JobId) _
                                                    .WithImagePath(TxtImagePath.Text) _
                                                    .WithImageDesc(TxtImageDesc.Text).Build
            If InsertJobImage(_jobimg) > 0 Then
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
            ShowStatus(LblStatus, "Removing Image from Job", MyBase.Name, True)
            If MsgBox("Remove " & _selectedImage.ImageDesc _
                    & " (" & IO.Path.GetFileName(_selectedImage.ImagePath) & ")?" _
                   & vbCrLf & "Image file will not be deleted.",
                          MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeleteJobImage(_selectedImage.ImageId) = 1 Then
                    RefreshImageTable()
                    ShowStatus(LblStatus, "Removed Image", MyBase.Name, True)
                Else
                    ShowStatus(LblStatus, "Removal failed", MyBase.Name, True)
                End If
            End If
        Else
            ShowStatus(LblStatus, "No Image Selected", MyBase.Name, True)
        End If
    End Sub
    Private Sub PicUpdate_Click(sender As Object, e As EventArgs) Handles PicUpdate.Click
        If _selectedImage IsNot Nothing AndAlso My.Computer.FileSystem.FileExists(TxtImagePath.Text) Then
            ShowStatus(LblStatus, "Updating Image in Job Folder", MyBase.Name, True)
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
    Private Sub BtnFindFile_Click(sender As Object, e As EventArgs) Handles BtnFindFile.Click
        TxtImagePath.Text = ImageUtil.GetImageFileName(ImageUtil.OpenOrSave.Open, ImageUtil.ImageType.ALL, oJobImageFolder)
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
        isLoading = True
        DgvImages.Rows.Clear()
        oNextImageCol = 0
        AddImageGridRow()
        For Each _image As JobImage In oImageList
            AddImageToGrid(_image)
            If Path.GetDirectoryName(_image.ImagePath) <> oJobImageFolder Then
                If MsgBox("Load image into job image folder?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Copy Image") = MsgBoxResult.Yes Then
                    _image = CopyFileToJobFolder(_image)
                End If
            End If
        Next
        DgvImages.ClearSelection()
        isLoading = False
    End Sub
    Private Function CopyFileToJobFolder(_image As JobImage) As JobImage
        Dim newPath As String = Path.Combine(oJobImageFolder, Path.GetFileName(_image.ImagePath))
        TxtImagePath.Text = newPath
        My.Computer.FileSystem.CopyFile(_image.ImagePath, newPath)
        _image.ImagePath = newPath
        UpdateJobImage(_image)
        Return _image
    End Function

    Private Function AddImageToGrid(_image As JobImage, Optional pIsPale As Boolean = False) As DataGridViewCell
        Dim oCell As DataGridViewCell
        If oNextImageCol >= oNextImageRow.Cells.Count Then
            oNextImageCol = 0
            AddImageGridRow()
        End If
        oCell = oNextImageRow.Cells(oNextImageCol)
        Dim _pic As Image = Image.FromFile(_image.ImagePath)
        Dim _wmultiplier As Decimal = 1
        Dim _hmultiplier As Decimal = 1
        Dim _newWidth As Integer = oCell.Size.Width
        Dim _newHeight As Integer = oNextImageRow.Height
        If _pic.Size.Width > _pic.Size.Height Then
            _hmultiplier = _pic.Size.Height / _pic.Size.Width
            _newHeight = oNextImageRow.Height * _hmultiplier
        Else
            _wmultiplier = _pic.Size.Width / _pic.Size.Height
            _newWidth = oCell.Size.Width * _wmultiplier
        End If
        Dim _cell As DataGridViewImageCell = oNextImageRow.Cells(oNextImageCol)
        Dim _bitmap As Bitmap = New Bitmap(_pic)
        If pIsPale Then
            _bitmap = ImageUtil.MakeImageOpaque(_bitmap, OPACITY_VALUE)
        End If
        Dim _resizedBitmap As Bitmap = ImageUtil.ResizeImage(_bitmap, _newWidth, _newHeight)
        _cell.Value = _resizedBitmap
        oNextImageCol += 1
        Return _cell
    End Function
    Private Sub AddImageGridRow()
        oNextImageRow = DgvImages.Rows(DgvImages.Rows.Add())
        Dim oCell As DataGridViewImageCell = oNextImageRow.Cells(oNextImageCol)
        Dim _cellWidth As Integer = oCell.Size.Width
        oNextImageRow.Height = _cellWidth
    End Sub

    Private Sub ClearSelection()
        _selectedImage = Nothing
        TxtImageDesc.Text = ""
        TxtImagePath.Text = ""
    End Sub
    Private Sub TxtImagePath_TextChanged(sender As Object, e As EventArgs) Handles TxtImagePath.TextChanged
        If TxtImagePath.TextLength > 0 Then
            If My.Computer.FileSystem.FileExists(TxtImagePath.Text) Then
                Dim _newImage As JobImage = JobImageBuilder.aJobImage.StartingWithNothing.WithJobId(ForJob.JobId).WithImagePath(TxtImagePath.Text).Build
                Dim isInJobFolder As Boolean = My.Computer.FileSystem.FileExists(Path.Combine(oJobImageFolder, Path.GetFileName(_newImage.ImagePath)))
                Dim _jobImages As List(Of JobImage) = GetJobImageByJobFile(ForJob, _newImage.ImagePath)
                Dim isAttached As Boolean = _jobImages.Count > 0
                BtnAddToJobFolder.Visible = Not isInJobFolder
                PicAdd.Visible = Not isAttached
                PicUpdate.Visible = isAttached
                PicRemove.Visible = isAttached
                If Not isAttached Then
                    Dim _cell As DataGridViewCell = AddImageToGrid(_newImage, True)
                    oImageList.Add(_newImage)
                    _cell.Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub BtnAddToJobFolder_Click(sender As Object, e As EventArgs) Handles BtnAddToJobFolder.Click
        CopyFileToJobFolder(_selectedImage)
    End Sub
#End Region
End Class