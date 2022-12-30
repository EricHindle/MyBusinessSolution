' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Drawing.Drawing2D
Imports System.IO

Public Class ImageUtil
#Region "enum"
    Public Enum ImageType
        JPEG
        GIF
        BMP
        TIFF
        PNG
        ANJ
        ALL
    End Enum
    Public Enum OpenOrSave
        Open
        Save
    End Enum
#End Region
#Region "variables"
    Public Shared imageFilter As String() = {"jpeg files (*.jpg;*.jpeg)|*.jpg;*.jpeg",
                                             "gif files (*.gif)|*.gif",
                                             "bmp files (*.bmp)|*.bmp",
                                             "tiff files (*.tif*.tiff)|*.tif;*.tiff",
                                             "png files (*.png)|*.png",
                                             "Encrypted files (*.anj)| *.anj",
                                             "image files|*.jpg;*.jpeg;*.gif;*.bmp;*.tif;*.tiff;*.png"}
    Public Shared tempMapImageFile As String = Path.Combine(sTempFolder, "mapimage_" & currentUser.User_code & Format(Now, "ddMMyyHHmmss") & ".jpg")
    Public Shared imageExtensions As String() = {".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".png", ".anj", ""}
#End Region
#Region "functions"
    Public Shared Sub PrintImage(ByVal imageFile As String)
        Dim oPrintUtil As New PrintUtil
        oPrintUtil.PreparePrintDocument()
        oPrintUtil.printSelectedImage(imageFile, 2)
    End Sub
    Public Shared Sub SaveTempImage(ByVal imageFile As String, ByVal imageName As String)
        Dim sFileName As String = Path.Combine(sCacheFolder, imageName & "_" & Format(Now, "yyyyMMddHHmmss") & ".jpg")
        Dim bOK As Boolean = False
        If My.Computer.FileSystem.FileExists(sFileName) Then
            If MsgBox("File already exists. OK to replace?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "File exists") = MsgBoxResult.Yes Then
                bOK = True
            End If
        Else
            bOK = True
        End If
        If bOK Then
            My.Computer.FileSystem.CopyFile(imageFile, sFileName)
        End If
    End Sub
    Public Shared Function SaveImage(ByVal img As Image, Optional ByVal imgType As ImageType = ImageType.JPEG) As String
        Dim sFilename As String = GetImageFileName(OpenOrSave.Save, imgType)
        If Not String.IsNullOrEmpty(sFilename) Then
            img.Save(sFilename, ConvertImageTypeToFormat(imgType))
        End If
        Return sFilename
    End Function
    Public Shared Function ConvertImageTypeToFormat(ByVal imgType As ImageType) As Imaging.ImageFormat
        Dim iFormat As Imaging.ImageFormat = Imaging.ImageFormat.Jpeg
        Select Case imgType
            Case ImageType.JPEG
                iFormat = Imaging.ImageFormat.Jpeg
            Case ImageType.GIF
                iFormat = Imaging.ImageFormat.Gif
            Case ImageType.BMP
                iFormat = Imaging.ImageFormat.Bmp
            Case ImageType.PNG
                iFormat = Imaging.ImageFormat.Png
            Case ImageType.TIFF
                iFormat = Imaging.ImageFormat.Tiff
        End Select
        Return iFormat
    End Function
    Public Shared Function GetImageFileName(ByVal dialogType As OpenOrSave, Optional ByVal imgType As Integer = 0) As String
        Dim sFilename As String = ""
        If dialogType = OpenOrSave.Open Then
            Using fbd As New OpenFileDialog
                sFilename = ShowFileDialog(fbd, imgType, sCacheFolder)
            End Using
        Else
            Using fbd As New SaveFileDialog
                sFilename = ShowFileDialog(fbd, imgType, sCacheFolder)
            End Using
        End If
        Return sFilename
    End Function
    Public Shared Function ShowFileDialog(ByVal fbd As FileDialog, Optional ByVal imgType As Integer = 0, Optional ByVal initialDirectory As String = Nothing) As String
        Dim sFilename As String = ""
        fbd.Filter = imageFilter(imgType)
        fbd.FilterIndex = 0
        fbd.RestoreDirectory = False
        fbd.CheckFileExists = False
        If String.IsNullOrEmpty(initialDirectory) Then
            fbd.InitialDirectory = sTempFolder
        Else
            fbd.InitialDirectory = initialDirectory
        End If

        If fbd.ShowDialog() = DialogResult.OK Then
            sFilename = fbd.FileName
        End If
        Return sFilename
    End Function
    Public Shared Function ResizeImage(pImage As Bitmap, pWidth As Integer, pHeight As Integer) As Bitmap
        If pImage IsNot Nothing Then
            Return New Bitmap(pImage, pWidth, pHeight)
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function ResizeImage(pImage As Byte(), pWidth As Integer, pHeight As Integer) As Bitmap
        Dim _image As Image = ConvertBytesToImage(pImage)
        If _image IsNot Nothing Then
            Return ResizeImage(_image, pWidth, pHeight)
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function ConvertBytesToImage(pImageBytes As Byte()) As Image
        Dim _image As System.Drawing.Image = Nothing
        Try
            Dim imageConverter As New ImageConverter()
            _image = imageConverter.ConvertFrom(pImageBytes)
        Catch ex As ArgumentException
            DisplayException(ex, "Exception converting bytes", "ImageUtil")
        Catch ex As NotSupportedException
            DisplayException(ex, "Exception converting bytes", "ImageUtil")
        End Try
        Return _image
    End Function
    Public Shared Function ResizeImageToBitmap(ByVal sourceImage As System.Drawing.Image, ByVal targetWidth As Integer, targetHeight As Integer, Optional ByVal sourceOriginX As Integer = 0, Optional ByVal sourceOriginY As Integer = 0) As Bitmap
        Using targetBitmap As New System.Drawing.Bitmap(targetWidth, targetHeight)
            Dim targetRectangle As New Rectangle(sourceOriginX, sourceOriginY, targetWidth, targetHeight)
            Using oBitMap As New Bitmap(sourceImage, sourceImage.Width, sourceImage.Height)
                Dim oGraphics As Graphics = InitialiseGraphics(targetBitmap)
                oGraphics.DrawImage(oBitMap, targetRectangle, 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel)
            End Using
            Return targetBitmap
        End Using
    End Function
    Public Shared Function ExtractCroppedAreaFromImage(ByVal sourceImage As System.Drawing.Image, ByVal targetWidth As Integer, targetHeight As Integer, Optional ByVal sourceOriginX As Integer = 0, Optional ByVal sourceOriginY As Integer = 0) As Bitmap
        Using targetBitmap As New Bitmap(targetWidth, targetHeight)
            Dim targetRectangle As New Rectangle(sourceOriginX, sourceOriginY, targetWidth, targetHeight)
            Using oBitMap As New Bitmap(sourceImage, sourceImage.Width, sourceImage.Height)
                Dim oGraphics As Graphics = InitialiseGraphics(targetBitmap)
                oGraphics.DrawImage(oBitMap, 0, 0, targetRectangle, GraphicsUnit.Pixel)
            End Using
            Return targetBitmap
        End Using
    End Function
    Public Shared Function InitialiseGraphics(ByVal oImage As Image) As Graphics
        Dim oGraphics As Graphics = Graphics.FromImage(oImage)
        oGraphics.SmoothingMode = SmoothingMode.HighQuality
        oGraphics.CompositingQuality = CompositingQuality.HighQuality
        oGraphics.InterpolationMode = InterpolationMode.High
        oGraphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
        Return oGraphics
    End Function
    Private Shared Function GetCodecInfo(ByVal imgType As ImageType) As System.Drawing.Imaging.ImageCodecInfo
        Dim arrayICI() As System.Drawing.Imaging.ImageCodecInfo = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
        Dim thisICI As System.Drawing.Imaging.ImageCodecInfo = Nothing
        For x As Integer = 0 To arrayICI.Length - 1
            If arrayICI(x).FormatDescription.Equals(imgType.ToString) Then
                thisICI = arrayICI(x)
                Exit For
            End If
        Next
        Return thisICI
    End Function
    Private Shared Function GetEncoderParameters() As System.Drawing.Imaging.EncoderParameters
        Dim oEncoder As System.Drawing.Imaging.Encoder
        Dim oEncoderParameter As System.Drawing.Imaging.EncoderParameter
        Dim oEncoderParameters As System.Drawing.Imaging.EncoderParameters
        oEncoder = System.Drawing.Imaging.Encoder.Quality
        oEncoderParameters = New System.Drawing.Imaging.EncoderParameters(1)
        oEncoderParameter = New System.Drawing.Imaging.EncoderParameter(oEncoder, 60L)
        oEncoderParameters.Param(0) = oEncoderParameter
        Return oEncoderParameters
    End Function
    Public Shared Function GetImageFileName(ByVal pDialogType As OpenOrSave, Optional ByVal pImgType As Integer = 0, Optional ByVal pFolder As String = Nothing, Optional ByVal pFilename As String = Nothing) As String
        Dim sFilename As String = ""

        If pDialogType = OpenOrSave.Open Then
            Using fbd As New OpenFileDialog
                If Not String.IsNullOrEmpty(pFolder) Then
                    fbd.InitialDirectory = pFolder
                End If
                If Not String.IsNullOrEmpty(pFilename) Then
                    fbd.FileName = pFilename
                End If
                sFilename = ShowFileDialog(fbd, pImgType, sImageFolder)
            End Using
        Else
            Using fbd As New SaveFileDialog
                If Not String.IsNullOrEmpty(pFolder) Then
                    fbd.InitialDirectory = pFolder
                End If
                If Not String.IsNullOrEmpty(pFilename) Then
                    fbd.FileName = pFilename
                End If
                sFilename = ShowFileDialog(fbd, pImgType, sImageFolder)
            End Using
        End If
        Return sFilename
    End Function

#End Region
End Class
