'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.IO
Imports System.Drawing.Drawing2D

Public Class ImageUtil
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
    Public Shared imageFilter As String() = {"jpeg files (*.jpg;*.jpeg)|*.jpg;*.jpeg", _
                                             "gif files (*.gif)|*.gif", _
                                             "bmp files (*.bmp)|*.bmp", _
                                             "tiff files (*.tif*.tiff)|*.tif;*.tiff", _
                                             "png files (*.png)|*.png", _
                                             "Encrypted files (*.anj)| *.anj", _
                                             "image files|*.jpg;*.jpeg;*.gif;*.bmp;*.tif;*.tiff;*.png"}
    Public Shared tempMapImageFile As String = Path.Combine(sTempFolder, "mapimage_" & currentUser.user_code & Format(Now, "ddMMyyHHmmss") & ".jpg")
    Public Shared imageExtensions As String() = {".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".png", ".anj", ""}
    Public Shared Sub printImage(ByVal imageFile As String)
        Dim oPrintUtil As New PrintUtil
        oPrintUtil.PreparePrintDocument()
        oPrintUtil.printSelectedImage(imageFile, 2)
        oPrintUtil = Nothing
    End Sub
    Public Shared Sub saveTempImage(ByVal imageFile As String, ByVal imageName As String)
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
    Public Shared Function saveImage(ByVal img As Image, Optional ByVal imgType As ImageType = ImageType.JPEG) As String
        Dim sFilename As String = getImageFileName(OpenOrSave.Save, imgType)
        If Not String.IsNullOrEmpty(sFilename) Then
            img.Save(sFilename, convertImageTypeToFormat(imgType))
        End If
        Return sFilename
    End Function
    Public Shared Function convertImageTypeToFormat(ByVal imgType As ImageType) As Imaging.ImageFormat
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
    Public Shared Function saveImageFromPictureBox(ByVal oPicture As PictureBox, ByVal sourceWidth As Integer, ByVal sourceHeight As Integer, Optional ByVal imgType As ImageType = ImageType.JPEG) As String
        LogUtil.Debug("Saving image from PictureBox")
        Dim targetBitmap As System.Drawing.Bitmap = resizeImageToBitmap(oPicture.Image, oPicture.Width, oPicture.Height)
        Dim targetFile As String = getImageFileName(OpenOrSave.Save, imgType)
        If Not String.IsNullOrEmpty(targetFile) Then
            targetBitmap.Save(targetFile, getCodecInfo(imgType), getEncoderParameters)
        End If
        targetBitmap.Dispose()
        Return targetFile
    End Function
    Public Shared Function getImageFileName(ByVal dialogType As OpenOrSave, Optional ByVal imgType As Integer = 0) As String
        Dim sFilename As String = ""

        If dialogType = OpenOrSave.Open Then
            Using fbd As New OpenFileDialog
                sFilename = showFileDialog(fbd, imgType, sCacheFolder)
            End Using
        Else
            Using fbd As New SaveFileDialog
                sFilename = showFileDialog(fbd, imgType, sCacheFolder)
            End Using
        End If
        Return sFilename
    End Function

    Public Shared Function showFileDialog(ByVal fbd As FileDialog, Optional ByVal imgType As Integer = 0, Optional ByVal initialDirectory As String = Nothing) As String
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

    Public Shared Function resizeImageToBitmap(ByVal sourceImage As System.Drawing.Image, ByVal targetWidth As Integer, targetHeight As Integer, Optional ByVal sourceOriginX As Integer = 0, Optional ByVal sourceOriginY As Integer = 0) As Bitmap
        Dim targetBitmap As System.Drawing.Bitmap = New System.Drawing.Bitmap(targetWidth, targetHeight)
        Dim targetRectangle As New Rectangle(sourceOriginX, sourceOriginY, targetWidth, targetHeight)
        Dim oBitMap As Bitmap = New Bitmap(sourceImage, sourceImage.Width, sourceImage.Height)
        Dim oGraphics As Graphics = initialiseGraphics(targetBitmap)
        oGraphics.DrawImage(oBitMap, targetRectangle, 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel)
        Return targetBitmap
    End Function
    Public Shared Function extractCroppedAreaFromImage(ByVal sourceImage As System.Drawing.Image, ByVal targetWidth As Integer, targetHeight As Integer, Optional ByVal sourceOriginX As Integer = 0, Optional ByVal sourceOriginY As Integer = 0) As Bitmap
        Dim targetBitmap As System.Drawing.Bitmap = New Bitmap(targetWidth, targetHeight)
        Dim targetRectangle As New Rectangle(sourceOriginX, sourceOriginY, targetWidth, targetHeight)
        Dim oBitMap As Bitmap = New Bitmap(sourceImage, sourceImage.Width, sourceImage.Height)
        Dim oGraphics As Graphics = initialiseGraphics(targetBitmap)
        oGraphics.DrawImage(oBitMap, 0, 0, targetRectangle, GraphicsUnit.Pixel)
        Return targetBitmap
    End Function
    Public Shared Function initialiseGraphics(ByVal oImage As Image) As Graphics
        Dim oGraphics As Graphics = Graphics.FromImage(oImage)
        oGraphics.SmoothingMode = SmoothingMode.HighQuality
        oGraphics.CompositingQuality = CompositingQuality.HighQuality
        oGraphics.InterpolationMode = InterpolationMode.High
        oGraphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
        Return oGraphics
    End Function
    Private Shared Function getCodecInfo(ByVal imgType As ImageType) As System.Drawing.Imaging.ImageCodecInfo
        Dim arrayICI() As System.Drawing.Imaging.ImageCodecInfo = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
        Dim thisICI As System.Drawing.Imaging.ImageCodecInfo = Nothing
        Dim x As Integer = 0
        For x = 0 To arrayICI.Length - 1
            If (arrayICI(x).FormatDescription.Equals(imgType.ToString)) Then
                thisICI = arrayICI(x)
                Exit For
            End If
        Next
        Return thisICI
    End Function
    Private Shared Function getEncoderParameters() As System.Drawing.Imaging.EncoderParameters
        Dim oEncoder As System.Drawing.Imaging.Encoder
        Dim oEncoderParameter As System.Drawing.Imaging.EncoderParameter
        Dim oEncoderParameters As System.Drawing.Imaging.EncoderParameters
        oEncoder = System.Drawing.Imaging.Encoder.Quality
        oEncoderParameters = New System.Drawing.Imaging.EncoderParameters(1)
        oEncoderParameter = New System.Drawing.Imaging.EncoderParameter(oEncoder, 60L)
        oEncoderParameters.Param(0) = oEncoderParameter
        Return oEncoderParameters
    End Function


End Class
