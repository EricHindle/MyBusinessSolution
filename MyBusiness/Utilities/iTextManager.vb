' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class ITextManager
    Public Shared headerFont As iTextSharp.text.Font
    Public Shared bodyFont As iTextSharp.text.Font
    Public Shared companyNameFont As iTextSharp.text.Font
    Public Shared companyAddressFont As iTextSharp.text.Font
    Public Shared bodyLargeFont As iTextSharp.text.Font
    Public Sub New()
        Dim _fontFolder As String = Path.Combine(Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System)).FullName, "Fonts")
        FontFactory.RegisterDirectory(_fontFolder)
        headerFont = iTextSharp.text.FontFactory.GetFont(My.Settings.InvHdrFont.Name, My.Settings.InvHdrFont.Size)
        bodyFont = iTextSharp.text.FontFactory.GetFont(My.Settings.InvBodyLargeFont.Name, My.Settings.InvBodyLargeFont.Size)
        companyNameFont = iTextSharp.text.FontFactory.GetFont(My.Settings.InvCmpyNameFont.Name, My.Settings.InvCmpyNameFont.Size)
        companyAddressFont = iTextSharp.text.FontFactory.GetFont(My.Settings.InvCmpyAddrFont.Name, My.Settings.InvCmpyAddrFont.Size)
        bodyLargeFont = iTextSharp.text.FontFactory.GetFont(My.Settings.InvBodyLargeFont.Name, My.Settings.InvBodyLargeFont.Size)
    End Sub
    Public Function CreateImageCell(ByVal path As String) As PdfPCell
        Dim img As iTextSharp.text.Image = Nothing
        If String.IsNullOrEmpty(path) = False Then
            Try
                img = iTextSharp.text.Image.GetInstance(path)
            Catch ex As Exception
                LogUtil.Exception("Error finding logo", ex, "createImageCell")
            End Try
        Else
            LogUtil.Info("No logo file defined", "createImageCell")
        End If

        Dim cell As New PdfPCell(img, True)
        Return cell
    End Function
    Public Function BuildTableHeaderCell(ByVal pCellValue As String) As PdfPCell
        Dim _hdrCellValue As New Paragraph(pCellValue, bodyFont)
        Dim _tableHdrCell As New iTextSharp.text.pdf.PdfPCell(_hdrCellValue) With {
            .BackgroundColor = New BaseColor(194, 217, 255),
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Border = iTextSharp.text.Rectangle.NO_BORDER
        }
        Return _tableHdrCell
    End Function
    Public Function BuildTableCell(ByVal pCellValue As String, Optional ByVal pAlignment As Integer = Element.ALIGN_RIGHT) As PdfPCell
        Dim _cellValue As New Paragraph(pCellValue, bodyFont)
        Dim _tableCell As New iTextSharp.text.pdf.PdfPCell(_cellValue) With {
            .HorizontalAlignment = pAlignment,
            .Border = iTextSharp.text.Rectangle.NO_BORDER
        }
        Return _tableCell
    End Function
    Public Function BuildTable(ByVal columnWidths As Single()) As PdfPTable
        Dim _table As New iTextSharp.text.pdf.PdfPTable(columnWidths.Length) With {
            .WidthPercentage = 100.0F
        }
        _table.SetWidths(columnWidths)
        _table.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
        _table.SpacingAfter = 10.0F
        Return _table
    End Function
    Public Function EmptyCell() As PdfPCell
        Dim _emptyCell As New iTextSharp.text.pdf.PdfPCell(New Paragraph(" ")) With {
            .Border = iTextSharp.text.Rectangle.NO_BORDER
        }
        Return _emptyCell
    End Function
End Class
