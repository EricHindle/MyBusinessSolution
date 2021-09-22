' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Imports System.IO

Public Class frmInstallationTest
#Region "Contants"
    Private Const FORM_NAME As String = "installation Test"
#End Region
#Region "Private variable instances"
    Private RECORD_TYPE As AuditUtil.RecordType = AuditUtil.RecordType.Customer
    Private oGeoInfo As GeoInfo
    Private oMappingUtil As MappingUtil
    Private myReportDef As ReportDefinition = Nothing
    Private oExporter As ExportUtil = Nothing
    Dim originLocation As MyBusiness.GeoPos = Nothing
#End Region
#Region "Form"
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Starting", FORM_NAME)
        lblFormName.Text = FORM_NAME
        myReportDef = New ReportDefinition()
        initialiseDgv()
        rtbLog.Text = ""
    End Sub

    Private Sub btnSMTP_Click(sender As Object, e As EventArgs) Handles btnSMTP.Click
        lblSMTPResult.Text = "Sending SMTP email..."
        Me.Refresh()
        Dim mailResultOK As Boolean = EmailUtil.SendMail(txtFrom.Text, txtTo.Text, New String() {}, "SERS SMTP email test", "Test")
        lblSMTPResult.Text = If(mailResultOK, "OK", "Failed")
    End Sub



    Private Sub btnGeoReq_Click(sender As Object, e As EventArgs) Handles btnGeoReq.Click
        lblGeoResult.Text = "Finding Geo information..."
        oGeoInfo = If(rbMapQuest.Checked, New MapQuestGeoInfo, CType(New GoogleGeoInfo, GeoInfo))
        Me.Refresh()
        Dim geoResponse As GeoResponse = oGeoInfo.getGeographicalInfo(txtLocation.Text)
        If geoResponse IsNot Nothing AndAlso geoResponse.bestResult IsNot Nothing AndAlso geoResponse.bestResult.location IsNot Nothing Then
            lblGeoResult.Text = getGeoResponseBestLocation(geoResponse)
        ElseIf geoResponse IsNot Nothing AndAlso geoResponse.results.Count > 0 AndAlso geoResponse.results(0).location IsNot Nothing Then
            lblGeoResult.Text = getGeoResponseFirstLocation(geoResponse)
        Else
            lblGeoResult.Text = getGeoResponseError(geoResponse)
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        lblPrintResult.Text = "Printing..."
        Dim dgv As DataGridView = DataGridView1
        myReportDef.TabStops = prtUtil.SetTabStopsFromColumns(dgv)
        myReportDef.ReportHead = "Installation Test"
        Me.Refresh()
        prtUtil.printGrid(dgv, myReportDef)
        lblPrintResult.Text = "Done"
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        lblExcelResult.Text = "Exporting..."
        Dim fileTitle As String = txtFilename.Text
        Dim exporter As New ExportUtil(FileUtil.FileType.XLS)
        exporter.OutFolder = sTempFolder
        Dim dgv As DataGridView = DataGridView1
        exporter.OutFile = fileTitle & Format(Now, "yyyyMMddHHmmss") & FileUtil.fileSuffix(FileUtil.FileType.XLS)
        exporter.exportGrid(dgv, True, , False, "Installation Test")
        lblExcelResult.Text = "Exported to " & Path.Combine(exporter.OutFolder, exporter.OutFile)
        exporter = Nothing
    End Sub

    Private Sub btnShowLog_Click(sender As Object, e As EventArgs) Handles btnShowLog.Click
        Using _logViewer As New frmLogViewer
            _logViewer.ShowDialog()
        End Using
    End Sub

    Private Sub lblPrintResult_TextChanged(sender As Object, e As EventArgs) Handles lblPrintResult.TextChanged
        addTrace(lblPrintResult.Text)
    End Sub

    Private Sub lblPdfResult_TextChanged(sender As Object, e As EventArgs) Handles lblPdfResult.TextChanged
        addTrace(lblPdfResult.Text)
    End Sub

    Private Sub lblExcelResult_TextChanged(sender As Object, e As EventArgs) Handles lblExcelResult.TextChanged
        addTrace(lblExcelResult.Text)
    End Sub

    Private Sub lblMapResult_TextChanged(sender As Object, e As EventArgs) Handles lblMapResult.TextChanged
        addTrace(lblMapResult.Text)
    End Sub

    Private Sub lblGeoResult_TextChanged(sender As Object, e As EventArgs) Handles lblGeoResult.TextChanged
        addTrace(lblGeoResult.Text)
    End Sub

    Private Sub lblOutlookResult_TextChanged(sender As Object, e As EventArgs) Handles lblOutlookResult.TextChanged
        addTrace(lblOutlookResult.Text)
    End Sub

    Private Sub lblSMTPResult_TextChanged(sender As Object, e As EventArgs) Handles lblSMTPResult.TextChanged
        addTrace(lblSMTPResult.Text)
    End Sub
#End Region
#Region "Subroutines"
    Private Sub initialiseDgv()
        addTrace("Initialising grid")
        DataGridView1.Rows.Add(2)
        DataGridView1.Rows(0).Cells(0).Value = 111
        DataGridView1.Rows(0).Cells(1).Value = "aaa"
        DataGridView1.Rows(0).Cells(2).Value = Today.Date
        DataGridView1.Rows(1).Cells(0).Value = 222
        DataGridView1.Rows(1).Cells(1).Value = "bbb"
        DataGridView1.Rows(1).Cells(2).Value = CDate("24/10/1955")
    End Sub

    Private Function addOriginNode() As Dictionary(Of Integer, TreeNode)
        Dim lboNodeCollection As New Dictionary(Of Integer, TreeNode)
        Dim newOriginNode As TreeNode = TreeView1.Nodes.Add(0, "Origin")
        lboNodeCollection.Add(0, newOriginNode)
        Dim oNode As TreeNode = lboNodeCollection.Item(0)
        Dim newNode As TreeNode = oNode.Nodes.Add(0, txtLocation.Text)
        newNode.Checked = True
        newNode.Nodes.Add(lblGeoResult.Text)
        newNode.Nodes.Add(txtLat.Text)
        newNode.Nodes.Add(txtLng.Text)
        newNode.Nodes.Add("0")
        newNode.Nodes.Add("0 miles")
        Return lboNodeCollection
    End Function

    Private Function getGeoResponseError(ByRef geoResponse As GeoResponse) As String
        addTrace("Mapping search response error")
        Dim geoResponseError As String
        If geoResponse Is Nothing Then
            geoResponseError = "Geo Response is Nothing"
        Else
            addTrace("Geo Response results count = " & CStr(geoResponse.results.Count))
            If geoResponse.bestResult Is Nothing Then
                geoResponseError = "Geo Response bestResult is Nothing"
            Else
                If geoResponse.bestResult.location Is Nothing Then
                    geoResponseError = "Geo Response bestResult location is Nothing"
                Else
                    geoResponseError = "Geo Response bestResult location = " & geoResponse.bestResult.formattedAddress
                End If
            End If

            If geoResponse.results.Count > 0 Then
                If geoResponse.results(0).location Is Nothing Then
                    geoResponseError = "Geo Response (0) is Nothing"
                Else
                    geoResponseError = "Geo Response Result (0) location = " & geoResponse.results(0).formattedAddress
                End If
            End If
        End If
        addTrace(geoResponseError)
        Return geoResponseError
    End Function

    Private Function getGeoResponseBestLocation(ByRef geoResponse As GeoResponse) As String
        txtLat.Text = CStr(geoResponse.bestResult.location.Latitude)
        txtLng.Text = CStr(geoResponse.bestResult.location.Longitude)
        originLocation = geoResponse.bestResult.location
        addTrace("Geo Response bestResult location = " & geoResponse.bestResult.formattedAddress)
        Return geoResponse.bestResult.formattedAddress
    End Function

    Private Function getGeoResponseFirstLocation(ByRef geoResponse As GeoResponse) As String
        txtLat.Text = CStr(geoResponse.results(0).location.Latitude)
        txtLng.Text = CStr(geoResponse.results(0).location.Longitude)
        originLocation = geoResponse.results(0).location
        addTrace("Geo Response Result (0) location = " & geoResponse.results(0).formattedAddress)
        Return geoResponse.results(0).formattedAddress & " *"
    End Function


    Private Sub addTrace(sText As String)
        LogUtil.Debug(sText, "InstallationTest")
        rtbLog.Text = sText & vbCrLf & rtbLog.Text
    End Sub
#End Region
End Class