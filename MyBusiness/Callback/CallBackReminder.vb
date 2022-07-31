Imports System.ComponentModel

Public Class CallBackReminder
    Private _principal As NetwyrksIPrincipal
    Public Property Principal() As NetwyrksIPrincipal
        Get
            Return _principal
        End Get
        Set(ByVal value As NetwyrksIPrincipal)
            _principal = value
        End Set
    End Property
    Private Const CALLBACK_MESSAGE As String = vbCrLf & "Callback requested for "
    Public Class CurrentProgress
        Public progressStatus As Integer
    End Class
    Public Sub CheckCallBackReminders(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs)
        My.User.CurrentPrincipal = Principal
        Dim state As New CurrentProgress
        Const Psub As String = "checkCallBackReminders"
        LogUtil.Debug("Checking call back reminders", Psub)
        Dim userId As Integer = currentUser.UserId
        LogUtil.Debug("Finding call back reminders", Psub)
        Dim _alertList As List(Of Reminder) = GetCallBackAlerts(userId)
        LogUtil.Info(CStr(_alertList.Count) & " reminders", Psub)
        FrmAlert.openForms.Clear()
        For Each _alert As Reminder In _alertList
            Dim callBackTime As String = Format(_alert.ReminderDate, "HH:mm")
            Dim subject As String = _alert.Subject
            Dim slice As New FrmAlert(My.Settings.alertDuration * 1000, subject & CALLBACK_MESSAGE & callBackTime) With {
                .Height = 80,
                .Guid = Guid.NewGuid
            }
            LogUtil.Info("About to show " & slice.Guid.ToString, Psub)
            slice.Show()
        Next
        state.progressStatus = 0
        worker.ReportProgress(100, state)
        LogUtil.Debug("Call back reminders complete", Psub)
    End Sub

End Class
