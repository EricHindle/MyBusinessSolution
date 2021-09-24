' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.Text

''' <summary>
''' Functions for the production of a rich text file
''' </summary>
''' <remarks></remarks>
Public Class RtfManager
    ''' <summary>
    ''' rtf representation of colours in the RtfColour enum
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared ReadOnly RtfColourTable As String = "{\colortbl ;" _
                        & "\red255\green0\blue0;" _
                        & "\red128\green0\blue0;" _
                        & "\red255\green255\blue0;" _
                        & "\red128\green128\blue0;" _
                        & "\red0\green128\blue0;" _
                        & "\red0\green0\blue128;" _
                        & "\red128\green0\blue128;" _
                        & "\red0\green128\blue128;" _
                        & "\red128\green128\blue128;" _
                        & "\red192\green192\blue192;" _
                        & "\red0\green255\blue0;" _
                        & "\red0\green0\blue255;" _
                        & "\red255\green0\blue255;" _
                        & "\red0\green255\blue255;" _
                        & "\red255\green255\blue255;" _
                        & "\red0\green0\blue0;" _
                        & "\red54\green95\blue145;" _
                        & "\red79\green129\blue189;" _
                        & "\red189\green214\blue238" _
                        & "}"
    ''' <summary>
    ''' rtf representation of fonts in the RtfFontType enum
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared ReadOnly RtfFontTable As String =
                            "{\fonttbl" _
                        & "{\f0\fnil\fcharset0 Arial;}" _
                        & "{\f1\fnil\fcharset0 Calibri;}" _
                        & "{\f2\fnil\fcharset0 Cambria;}" _
                        & "{\f3\fnil\fcharset0 Century;}" _
                        & "{\f4\fnil\fcharset0 Consolas;}" _
                        & "{\f5\fnil\fcharset0 Courier New;}" _
                        & "{\f6\fnil\fcharset0 Garamond;}" _
                        & "{\f7\fnil\fcharset0 Tahoma;}" _
                        & "{\f8\fnil\fcharset0 Times New Roman;}" _
                        & "{\f9\fnil\fcharset0 Verdana;}" _
                        & "}"
    Private Shared ReadOnly RtfAlignTable As String = "lrcj"
    Public Enum RtfColour
        DefaultColour
        Red
        Maroon
        Yellow
        Olive
        Green
        Navy
        Purple
        Teal
        Grey
        Silver
        Lime
        Blue
        Fuchsia
        Aqua
        White
        Black
        Hdr1Blue
        Hdr2Blue
        BkGrdBlue
    End Enum
    Public Enum RtfFontType
        Arial
        Calibri
        Cambria
        Century
        Consolas
        Courier_New
        Garamond
        Tahoma
        Times_New_Roman
        Verdana
    End Enum
    Public Enum RtfAlign
        left
        right
        centre
        justify
    End Enum
    Public Enum RtfUnits
        null = 0
        inches = 1440
        centimetres = 567
        twips = 1
        points = 20
    End Enum
    ''' <summary>
    ''' Generate rtf codes to set a font in the document
    ''' </summary>
    ''' <param name="fontNo">Font Type</param>
    ''' <param name="fontsize">Font size</param>
    ''' <param name="forecolor">Text colour</param>
    ''' <param name="backColor">Background colour</param>
    ''' <param name="isBold">True to make text bold</param>
    ''' <param name="isItalic">True to make text italic</param>
    ''' <param name="alignment">Text alignment</param>
    ''' <returns>String of rtf codes</returns>
    ''' <remarks></remarks>
    Public Shared Function RtfFont(ByVal fontNo As RtfFontType,
                                   ByVal fontsize As Integer,
                                   Optional ByVal forecolor As RtfColour = 0,
                                   Optional ByVal backColor As RtfColour = 0,
                                   Optional ByVal isBold As Boolean = False,
                                   Optional ByVal isItalic As Boolean = False,
                                   Optional ByVal alignment As RtfAlign = 0) As String

        Dim rtnString As New StringBuilder
        Dim al As String = RtfAlignTable.Substring(alignment, 1)
        rtnString.Append("\f") _
        .Append(fontNo) _
        .Append("\fs") _
        .Append(fontsize) _
        .Append("\cf") _
        .Append(forecolor) _
        .Append("\cb") _
        .Append(backColor)
        If isBold Then
            rtnString.Append("\b")
        Else
            rtnString.Append("\b0")
        End If
        If isItalic Then
            rtnString.Append("\i")
        Else
            rtnString.Append("\i0")
        End If
        rtnString.Append("\q").Append(al)
        Return rtnString.ToString
    End Function
    ''' <summary>
    ''' Generate rtf codes to set margins depending on selected unit of measurement
    ''' </summary>
    ''' <param name="marginLeft">Size of left margin</param>
    ''' <param name="marginRight">Size of right margin</param>
    ''' <param name="marginTop">Size of top margin</param>
    ''' <param name="marginBottom">Size of bottom margin</param>
    ''' <param name="units">Unit of measurement (defaults to inches)</param>
    ''' <returns>String of rtf codes</returns>
    ''' <remarks></remarks>
    Public Shared Function RtfMargins(Optional ByVal marginLeft As Double = 0.5, Optional ByVal marginRight As Double = 0.5, Optional ByVal marginTop As Double = 0.5, Optional ByVal marginBottom As Double = 0.5, Optional ByVal units As RtfUnits = RtfUnits.inches) As String
        Dim rtnString As New StringBuilder
        Dim l_marg As Integer = marginLeft * CInt(units)
        Dim r_marg As Integer = marginRight * CInt(units)
        Dim t_marg As Integer = marginTop * CInt(units)
        Dim b_marg As Integer = marginBottom * CInt(units)
        rtnString.Append("\margl").Append(CStr(l_marg))
        rtnString.Append("\margr").Append(CStr(r_marg))
        rtnString.Append("\margt").Append(CStr(t_marg))
        rtnString.Append("\margb").Append(CStr(b_marg))
        rtnString.Append(vbCrLf)
        Return rtnString.ToString
    End Function
    ''' <summary>
    ''' Standard rtf codes to be inserted at the top of a document
    ''' </summary>
    ''' <param name="isLandscape">True if document should be landscape</param>
    ''' <returns>String of rtf codes</returns>
    ''' <remarks>Inserts codepage, language, font table, colour table and paper size</remarks>
    Public Shared Function RtfTop(Optional ByVal isLandscape As Boolean = False) As String
        Dim rtnString As New StringBuilder
        rtnString.Append("{\rtf1\ansi\ansicpg1252\deff0\deflang2057")
        rtnString.Append(vbCrLf)
        rtnString.Append(RtfFontTable)
        rtnString.Append(vbCrLf)
        rtnString.Append(RtfColourTable)
        rtnString.Append(vbCrLf)
        rtnString.Append("\viewkind4\uc1")
        rtnString.Append(vbCrLf)
        If isLandscape Then
            rtnString.Append("\paperw16839\paperh11907")
            rtnString.Append(vbCrLf)
        End If
        Return rtnString.ToString
    End Function
    ''' <summary>
    ''' Generates rtf code for a new paragraph
    ''' </summary>
    ''' <returns>String of rtf codes</returns>
    ''' <remarks></remarks>
    Public Shared Function RtfNewPar() As String
        Dim rtnString As String = "\par" & vbCrLf
        Return rtnString

    End Function
    ''' <summary>
    ''' Standard rtf codes to be inserted at the bottom of a document
    ''' </summary>
    ''' <returns>"}"</returns>
    ''' <remarks></remarks>
    Public Shared Function RtfBottom() As String
        Dim rtnString As String = "}"
        Return rtnString

    End Function
    ''' <summary>
    ''' Adds rtf codes around a text string to create a paragraph
    ''' </summary>
    ''' <param name="text">Starting text</param>
    ''' <param name="rtfFont">Font</param>
    ''' <param name="resetDefault">True if reset to default settings (defaults to true)</param>
    ''' <param name="keepIntact">True if keep paragraph intact (defaults to true)</param>
    ''' <param name="keepWithNext">True if keep with next paragraph (defaults to false)</param>
    ''' <returns>Text with added rtf codes</returns>
    ''' <remarks></remarks>
    Public Shared Function RtfParagraph(ByVal text As String, Optional ByVal rtfFont As String = "", Optional ByVal resetDefault As Boolean = True, Optional ByVal keepIntact As Boolean = True, Optional ByVal keepWithNext As Boolean = False) As String
        Dim rtnString As New StringBuilder
        rtnString.Append(RtfStartLine("", resetDefault, keepIntact, keepWithNext))
        rtnString.Append(RtfText(text, rtfFont))
        rtnString.Append(RtfNewPar)
        Return rtnString.ToString
    End Function
    ''' <summary>
    ''' Adds rtf codes to start of a text string to set tabs
    ''' </summary>
    ''' <param name="rtfTabs">rtf tab settings string</param>
    ''' <param name="resetDefault">True if reset to default settings (defaults to true)</param>
    ''' <param name="keepIntact">True if keep paragraph intact (defaults to true)</param>
    ''' <param name="keepWithNext">True if keep with next paragraph (defaults to false)</param>
    ''' <returns>Text with added rtf codes</returns>
    ''' <remarks></remarks>
    Public Shared Function RtfStartLine(Optional ByVal rtfTabs As String = "", Optional ByVal resetDefault As Boolean = True, Optional ByVal keepIntact As Boolean = True, Optional ByVal keepWithNext As Boolean = False) As String
        Dim rtnString As New StringBuilder
        rtnString.Append("\par")
        If resetDefault Then
            rtnString.Append("d")
        End If
        If keepIntact Then
            rtnString.Append("\keep")
        End If
        If keepWithNext Then
            rtnString.Append("\keepn")
        End If
        rtnString.Append(rtfTabs)
        Return rtnString.ToString
    End Function
    ''' <summary>
    ''' Adds rtf codes to start of a text string to set font
    ''' </summary>
    ''' <param name="text"></param>
    ''' <param name="rtfFont"></param>
    ''' <returns>Text with added rtf font codes</returns>
    ''' <remarks></remarks>
    Public Shared Function RtfText(ByVal text As String, Optional ByVal rtfFont As String = "") As String
        Dim rtnString As New StringBuilder
        rtnString.Append(rtfFont)
        rtnString.Append(" ")
        rtnString.Append(text)
        Return rtnString.ToString
    End Function
    ''' <summary>
    ''' Convert a datagrid view table into an rtf string
    ''' </summary>
    ''' <param name="dg">Table to be converted</param>
    ''' <param name="fontType">Font (defaults to Calibri)</param>
    ''' <param name="txtSize">Text size (defaults to 20)</param>
    ''' <param name="isBold">True if text should be bold (defaults to true)</param>
    ''' <param name="autoSize">True if setting tab stops from contents of the table</param>
    ''' <param name="maxColWidth">Maximum column width</param>
    ''' <param name="singleLine">True if text should not be wrapped</param>
    ''' <returns>Text with added rtf codes</returns>
    ''' <remarks></remarks>
    Public Shared Function GridToRtf(ByRef dg As DataGridView, Optional ByVal fontType As RtfManager.RtfFontType = RtfManager.RtfFontType.Calibri, Optional ByVal txtSize As Integer = 20, Optional ByVal isBold As Boolean = True, Optional ByVal autoSize As Boolean = True, Optional ByVal maxColWidth As Integer = -1, Optional ByVal singleLine As Boolean = True) As String
        Dim rtnText As New StringBuilder
        Dim tabstops As String = SetGridTabs(dg, autoSize)
        ' Print headings
        rtnText.Append(RtfStartLine(tabstops))
        For Each oCol As DataGridViewColumn In dg.Columns
            If oCol.Visible Then
                rtnText.Append(RtfText(oCol.HeaderText.Trim, RtfManager.RtfFont(fontType, txtSize, , , isBold))).Append(vbTab)
            End If
        Next
        rtnText.Append(RtfNewPar)
        For Each oRow As DataGridViewRow In dg.Rows
            If oRow.Visible = True Then
                Dim aCells As New ArrayList
                Dim aMaxLines As Integer = 0
                For Each oCell As DataGridViewCell In oRow.Cells
                    If oCell.Visible Then
                        Dim cellColor As RtfColour = RtfColour.Black
                        If oCell.Style.ForeColor <> Color.Empty And oCell.Style.ForeColor <> Color.Black Then
                            If oCell.Style.ForeColor = Color.Green Then
                                cellColor = RtfColour.Green
                            ElseIf oCell.Style.ForeColor = Color.Maroon Then
                                cellColor = RtfColour.Maroon
                            ElseIf oCell.Style.ForeColor = Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(26, Byte), Integer)) Then
                                cellColor = RtfColour.Hdr2Blue
                            Else
                                cellColor = RtfColour.Hdr1Blue
                            End If
                        End If
                        Dim aCellValues As New ArrayList
                        If oCell.ValueType Is GetType(Date) Then
                            rtnText.Append(RtfText(Format(oCell.Value, "dd/MM/yyyy"), RtfManager.RtfFont(fontType, txtSize, cellColor, , isBold))).Append(vbTab)
                        Else
                            Dim cellVal As String = ""
                            If oCell.Value IsNot Nothing AndAlso oCell.Value IsNot DBNull.Value Then
                                If maxColWidth > 0 Then
                                    aCellValues = PrintUtil.wrapString(CStr(oCell.Value).Trim, maxColWidth)
                                    If aCellValues.Count > 0 Then
                                        cellVal = aCellValues(0)
                                    End If
                                Else
                                    cellVal = CStr(oCell.Value).Trim
                                End If
                                rtnText.Append(RtfText(cellVal, RtfManager.RtfFont(fontType, txtSize, cellColor, , isBold))).Append(vbTab)
                            Else
                                rtnText.Append("").Append(vbTab)
                            End If
                        End If
                        aCells.Add(aCellValues)
                        aMaxLines = Math.Max(aMaxLines, aCellValues.Count)
                    End If
                Next
                rtnText.Append(RtfNewPar)
                ' Now print rows for wrapped text
                If Not singleLine And maxColWidth > 0 And aMaxLines > 1 Then
                    For x = 1 To aMaxLines - 1
                        Dim cellVal As String
                        For Each a As ArrayList In aCells
                            If a.Count > x Then
                                cellVal = a(x)
                                rtnText.Append(RtfText(cellVal, RtfManager.RtfFont(fontType, txtSize, RtfColour.Black, , isBold))).Append(vbTab)
                            Else
                                rtnText.Append("").Append(vbTab)
                            End If
                        Next
                        rtnText.Append(RtfNewPar)
                    Next
                End If

            End If
        Next
        Return rtnText.ToString
    End Function
    ''' <summary>
    ''' Generate rtf tab stop codes for a data grid table 
    ''' </summary>
    ''' <param name="dg">Data grid </param>
    ''' <param name="autoSize">True if tab stop determined by table contents </param>
    ''' <param name="dpi">Pixel density - dots per inch (defaults to 96)</param>
    ''' <returns>String of rtf tab stop codes</returns>
    ''' <remarks></remarks>
    Private Shared Function SetGridTabs(ByRef dg As DataGridView, Optional ByRef autoSize As Boolean = True, Optional ByVal dpi As Integer = 96) As String
        Dim rtnText As New StringBuilder
        Dim lasttab As Integer = 0
        For Each oCol As DataGridViewColumn In dg.Columns
            If autoSize Then
                oCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End If
            If oCol.Visible Then
                Dim thisTab As Integer = lasttab + (PixelsToTwips(oCol.Width + 2, dpi))
                lasttab = thisTab
                rtnText.Append("\tx" & CStr(thisTab))
            End If
        Next
        Return rtnText.ToString
    End Function
    ''' <summary>
    ''' Converts pixels to twips (twentieth of a point)
    ''' </summary>
    ''' <param name="intPixels">Number of pixels </param>
    ''' <param name="dpi">Pixel density - dots per inch</param>
    ''' <returns>Number of twips</returns>
    ''' <remarks></remarks>
    Private Shared Function PixelsToTwips(ByVal intPixels As Integer, ByVal dpi As Integer) As Integer
        PixelsToTwips = intPixels * 1440 / dpi
    End Function
End Class
