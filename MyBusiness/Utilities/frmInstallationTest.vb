' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.IO

Public Class FrmInstallationTest
#Region "Contants"
    Private Const FORM_NAME As String = "installation Test"
#End Region
#Region "Private variable instances"
    Private myReportDef As ReportDefinition = Nothing
#End Region
#Region "Form"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Starting", MyBase.Name)
        lblFormName.Text = FORM_NAME
        txtFrom.Text = GlobalSettings.getSetting(EmailUtil.SMTP_FROMNAME)
        myReportDef = New ReportDefinition()
        InitialiseDgv()
        rtbLog.Text = ""
    End Sub
    Private Sub BtnSMTP_Click(sender As Object, e As EventArgs) Handles btnSMTP.Click
        lblSMTPResult.Text = "Sending SMTP email..."
        Me.Refresh()
        Dim fromEmail As String = GlobalSettings.getSetting(EmailUtil.SMTP_USERNAME)
        Dim mailResultOK As Boolean = EmailUtil.SendMail(fromEmail, txtTo.Text, New String() {}, "SMTP email test", "Test", txtFrom.Text)
        lblSMTPResult.Text = If(mailResultOK, "OK", "Failed")

    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        lblPrintResult.Text = "Printing..."
        Dim dgv As DataGridView = DataGridView1
        myReportDef.TabStops = prtUtil.SetTabStopsFromColumns(dgv)
        myReportDef.ReportHead = "Installation Test"
        Me.Refresh()
        prtUtil.printGrid(dgv, myReportDef)
        lblPrintResult.Text = "Done"
    End Sub
    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        lblExcelResult.Text = "Exporting..."
        Dim fileTitle As String = txtFilename.Text
        Dim exporter As New ExportUtil(FileUtil.FileType.XLS) With {
            .OutFolder = sTempFolder
        }
        Dim dgv As DataGridView = DataGridView1
        exporter.OutFile = fileTitle & Format(Now, "yyyyMMddHHmmss") & FileUtil.fileSuffix(FileUtil.FileType.XLS)
        exporter.exportGrid(dgv, True, , False, "Installation Test")
        lblExcelResult.Text = "Exported to " & Path.Combine(exporter.OutFolder, exporter.OutFile)
    End Sub
    Private Sub BtnShowLog_Click(sender As Object, e As EventArgs) Handles btnShowLog.Click
        Using _logViewer As New FrmLogViewer
            _logViewer.ShowDialog()
        End Using
    End Sub
    Private Sub LblPrintResult_TextChanged(sender As Object, e As EventArgs) Handles lblPrintResult.TextChanged
        AddTrace(lblPrintResult.Text)
    End Sub
    Private Sub LblPdfResult_TextChanged(sender As Object, e As EventArgs) Handles lblPdfResult.TextChanged
        AddTrace(lblPdfResult.Text)
    End Sub
    Private Sub LblExcelResult_TextChanged(sender As Object, e As EventArgs) Handles lblExcelResult.TextChanged
        AddTrace(lblExcelResult.Text)
    End Sub
    Private Sub LblSMTPResult_TextChanged(sender As Object, e As EventArgs) Handles lblSMTPResult.TextChanged
        AddTrace(lblSMTPResult.Text)
    End Sub
    Private Sub FrmInstallationTest_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
    End Sub

#End Region
#Region "Subroutines"
    Private Sub InitialiseDgv()
        AddTrace("Initialising grid")
        DataGridView1.Rows.Add(2)
        DataGridView1.Rows(0).Cells(0).Value = 111
        DataGridView1.Rows(0).Cells(1).Value = "aaa"
        DataGridView1.Rows(0).Cells(2).Value = Today.Date
        DataGridView1.Rows(1).Cells(0).Value = 222
        DataGridView1.Rows(1).Cells(1).Value = "bbb"
        DataGridView1.Rows(1).Cells(2).Value = CDate("24/10/1955")
    End Sub
    Private Sub AddTrace(sText As String)
        LogUtil.Info(sText, MyBase.Name)
        rtbLog.Text = sText & vbCrLf & rtbLog.Text
    End Sub

#End Region
End Class