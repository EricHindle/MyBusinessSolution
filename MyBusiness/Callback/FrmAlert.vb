' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Runtime.InteropServices
''' <summary>
''' Alert Form 
''' </summary>
''' <remarks>Form pops up toaster style in the bottom corner of the screen</remarks>
Public Class FrmAlert
    Private Class NativeMethods
        ''' <summary>
        ''' Gets the handle of the window that currently has focus.
        ''' </summary>
        ''' <returns>
        ''' The handle of the window that currently has focus.
        ''' </returns>
        <DllImport("user32")>
        Public Shared Function GetForegroundWindow() As IntPtr
        End Function

        ''' <summary>
        ''' Activates the specified window.
        ''' </summary>
        ''' <param name="hWnd">
        ''' The handle of the window to be focused.
        ''' </param>
        ''' <returns>
        ''' True if the window was focused; False otherwise.
        ''' </returns>
        <DllImport("user32")>
        Public Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
        End Function
    End Class
#Region "properties"
    Private _guid As Guid
    Public Property Guid() As Guid
        Get
            Return _guid
        End Get
        Set(ByVal value As Guid)
            _guid = value
        End Set
    End Property
#End Region
#Region "Variables"
    ''' <summary>
    ''' The list of currently open Alert Forms.
    ''' </summary>
    Friend Shared ReadOnly openForms As New List(Of FrmAlert)
    ''' <summary>
    ''' Indicates whether the form can receive focus or not.
    ''' </summary>
    Private allowFocus As Boolean = False
    ''' <summary>
    ''' The object that creates the sliding animation.
    ''' </summary>
    Private ReadOnly animator As FormAnimator
    ''' <summary>
    ''' The handle of the window that currently has focus.
    ''' </summary>
    Private currentForegroundWindow As IntPtr

#End Region
#Region "Constructors"
    ''' <summary>
    ''' Creates a new Alert Form object that is displayed for the specified length of time.
    ''' </summary>
    ''' <param name="lifeTime">
    ''' The length of time, in milliseconds, that the form will be displayed.
    ''' </param>
    Public Sub New(ByVal lifeTime As Integer, ByVal message As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        'Set the time for which the form should be displayed and the message to display.
        With Timer1
            .Interval = lifeTime
        End With
        messageLabel.Text = message
        'Display the form by sliding up.
        animator = New FormAnimator(Me,
                                       FormAnimator.AnimationMethod.Slide,
                                       FormAnimator.AnimationDirection.Up,
                                       500)
    End Sub
#End Region
#Region "Methods"
    ''' <summary>
    ''' Displays the form.
    ''' </summary>
    ''' <remarks>
    ''' Required to allow the form to determine the current foreground window     before being displayed.
    ''' </remarks>
    ''' 
    Public Shadows Sub Show()
        'Determine the current foreground window so it can be reactivated each time this form tries to get the focus.
        currentForegroundWindow = NativeMethods.GetForegroundWindow()
        'Display the form.
        MyBase.Show()
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub AlertForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Display the form just above the system tray.
        LogUtil.Info("Loading Alert " & _guid.ToString, MyBase.Name)

        Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 5,
                                Screen.PrimaryScreen.WorkingArea.Height - Height - 5)
        'Move each open form upwards to make room for this one.
        For Each openForm As FrmAlert In FrmAlert.openForms
            openForm.Location = New Point(openForm.Location.X, openForm.Location.Y - Size.Height)
        Next
        'Add this form from the open form list.
        FrmAlert.openForms.Add(Me)

        'Start counting down the form's liftime.
        LogUtil.Info("Starting " & Guid.ToString & ": Interval " & Timer1.Interval, MyBase.Name)
        Timer1.Start()
    End Sub
    Private Sub AlertForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Prevent the form taking focus when it is initially shown.
        If Not allowFocus Then
            'Activate the window that previously had the focus.
            NativeMethods.SetForegroundWindow(currentForegroundWindow)
        End If
    End Sub
    Private Sub AlertForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'Once the animation has completed the form can receive focus.
        allowFocus = True
        'Close the form by sliding down.
        animator.Direction = FormAnimator.AnimationDirection.Down
    End Sub
    Private Sub AlertForm_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
        'Move down any open forms above this one.
        For Each openForm As FrmAlert In FrmAlert.openForms
            If openForm IsNot Me Then
                If openForm.Location.Y < Location.Y Then
                    openForm.Location = New Point(openForm.Location.X, openForm.Location.Y + Size.Height)
                End If
            End If
        Next
        'Remove this form from the open form list.
        FrmAlert.openForms.Remove(Me)
        LogUtil.Info("Alert form closed " & _guid.ToString, MyBase.Name)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'The form's lifetime has expired.
        LogUtil.Info(Guid.ToString & " ticked ", "TimerTick")
        Timer1.Stop()
        Close()
    End Sub
#End Region

End Class