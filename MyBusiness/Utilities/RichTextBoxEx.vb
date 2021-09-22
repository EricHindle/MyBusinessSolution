' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.Runtime.InteropServices
Imports System.Drawing.Printing

''' <summary>
''' Rich Text Box extension
''' </summary>
''' <remarks></remarks>
Public Class RichTextBoxEx
    Inherits RichTextBox
    <StructLayout(LayoutKind.Sequential)> _
Private Structure STRUCT_RECT
        Public left As Int32
        Public top As Int32
        Public right As Int32
        Public bottom As Int32
    End Structure
    <StructLayout(LayoutKind.Sequential)> _
Private Structure STRUCT_CHARRANGE
        Public cpMin As Int32
        Public cpMax As Int32
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure STRUCT_FORMATRANGE
        Public hdc As IntPtr
        Public hdcTarget As IntPtr
        Public rc As STRUCT_RECT
        Public rcPage As STRUCT_RECT
        Public chrg As STRUCT_CHARRANGE
    End Structure
    Private Class NativeMethods
        <DllImport("user32.dll")> _
        Shared Function SendMessage(ByVal hWnd As IntPtr, _
                                    ByVal msg As Int32, _
                                    ByVal wParam As IntPtr, _
                                    ByVal lParam As IntPtr) As IntPtr
        End Function
    End Class
    Private Const WM_USER As Int32 = &H400&
    Private Const EM_FORMATRANGE As Int32 = WM_USER + 57

    ''' <summary>
    ''' Calculate or render the contents of the RichTextBox for printing
    ''' </summary>
    ''' <param name="measureOnly">If true, only the calculation is performed, otherwise the text is rendered as well</param>
    ''' <param name="e">The PrintPageEventArgs object from the PrintPage event</param>
    ''' <param name="charFrom">Index of first character to be printed</param>
    ''' <param name="charTo">Index of last character to be printed</param>
    ''' <returns>(Index of last character that fitted on the page) + 1</returns>
    ''' <remarks></remarks>
    Public Function FormatRange(ByVal measureOnly As Boolean, _
                                ByVal e As PrintPageEventArgs, _
                                ByVal charFrom As Integer, _
                                ByVal charTo As Integer) As Integer
        ' Specify which characters to print
        Dim cr As STRUCT_CHARRANGE
        cr.cpMin = charFrom
        cr.cpMax = charTo

        ' Specify the area inside page margins
        Dim rc As STRUCT_RECT
        rc.top = HundredthInchToTwips(e.MarginBounds.Top)
        rc.bottom = HundredthInchToTwips(e.MarginBounds.Bottom)
        rc.left = HundredthInchToTwips(e.MarginBounds.Left)
        rc.right = HundredthInchToTwips(e.MarginBounds.Right)

        ' Specify the page area
        Dim rcPage As STRUCT_RECT
        rcPage.top = HundredthInchToTwips(e.PageBounds.Top)
        rcPage.bottom = HundredthInchToTwips(e.PageBounds.Bottom)
        rcPage.left = HundredthInchToTwips(e.PageBounds.Left)
        rcPage.right = HundredthInchToTwips(e.PageBounds.Right)

        ' Get device context of output device
        Dim hdc As IntPtr
        hdc = e.Graphics.GetHdc()

        ' Fill in the FORMATRANGE structure
        Dim fr As STRUCT_FORMATRANGE
        fr.chrg = cr
        fr.hdc = hdc
        fr.hdcTarget = hdc
        fr.rc = rc
        fr.rcPage = rcPage

        ' Non-Zero wParam means render, Zero means measure
        Dim wParam As Int32
        If measureOnly Then
            wParam = 0
        Else
            wParam = 1
        End If

        ' Allocate memory for the FORMATRANGE struct and
        ' copy the contents of our struct to this memory
        Dim lParam As IntPtr
        lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fr))
        Marshal.StructureToPtr(fr, lParam, False)

        ' Send the actual Win32 message
        Dim res As Integer
        res = NativeMethods.SendMessage(Handle, EM_FORMATRANGE, wParam, lParam)

        ' Free allocated memory
        Marshal.FreeCoTaskMem(lParam)

        ' and release the device context
        e.Graphics.ReleaseHdc(hdc)

        Return res
    End Function

    ''' <summary>
    ''' Convert between 1/100 inch (unit used by the .NET framework)
    ''' and twips (1/1440 inch, used by Win32 API calls)
    ''' </summary>
    ''' <param name="n">Value in 1/100 inch</param>
    ''' <returns>Value in twips</returns>
    ''' <remarks></remarks>
    Private Function HundredthInchToTwips(ByVal n As Integer) As Int32
        Return Convert.ToInt32(n * 14.4)
    End Function

    ''' <summary>
    ''' Free cached data from rich edit control after printing
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FormatRangeDone()
        Dim lParam As New IntPtr(0)
        NativeMethods.SendMessage(Handle, EM_FORMATRANGE, 0, lParam)
    End Sub

End Class
