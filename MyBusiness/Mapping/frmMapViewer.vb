'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.Windows.Forms
Imports System.IO

Public Class frmMapViewer

    Const FORM_NAME As String = "map"

    Private _Uri As String
    Private _lboNodes As TreeView
    Private sCentreLat As String
    Private sCentreLng As String
    Private sCentreTitle As String

    Public Property lboNodes() As TreeView
        Get
            Return _lboNodes
        End Get
        Set(ByVal value As TreeView)
            _lboNodes = value
        End Set
    End Property

    Public Property uri() As String
        Get
            Return _Uri
        End Get
        Set(ByVal value As String)
            _Uri = value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Hide()
    End Sub

    Private Sub frmMapViewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        e.Cancel = True
    End Sub


    Private Sub frmMapViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Starting", FORM_NAME)
        lblFormName.Text = FORM_NAME
        Me.KeyPreview = True
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            Using _diary As New frmDiary
                _diary.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub btnInteractive_Click(sender As Object, e As EventArgs) Handles btnInteractive.Click
        LogUtil.Debug("Requesting interactive map", FORM_NAME)
        If _lboNodes.Nodes Is Nothing OrElse _lboNodes.Nodes.Count = 0 Then
            MsgBox("No LBOs to be mapped", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If
        sCentreLat = _lboNodes.Nodes(0).Nodes(0).Nodes(1).Text
        sCentreLng = _lboNodes.Nodes(0).Nodes(0).Nodes(2).Text
        sCentreTitle = _lboNodes.Nodes(0).Nodes(0).Text

        Dim sTemplateFolder = My.Settings.DataFolder
        sTemplateFolder = sTemplateFolder.Replace("<application path>", My.Application.Info.DirectoryPath)
        Dim sTempMapFileName = My.Computer.FileSystem.CombinePath(sTempFolder, "tempMap.htm")
        Dim sMapTemplate1 = My.Computer.FileSystem.CombinePath(sTemplateFolder, "MapTop.tmpl")
        Dim sMapTemplate2 = My.Computer.FileSystem.CombinePath(sTemplateFolder, "MapBottom.tmpl")

        If Not My.Computer.FileSystem.FileExists(sMapTemplate1) Then
            Dim message As String = "Top template file " & sMapTemplate1 & " is missing"
            LogUtil.Problem(message, FORM_NAME)
            MsgBox(message, MsgBoxStyle.Exclamation, "File Error")
            Exit Sub
        End If

        If Not My.Computer.FileSystem.FileExists(sMapTemplate2) Then
            Dim message As String = "Bottom template file " & sMapTemplate2 & " is missing"
            LogUtil.Problem(message, FORM_NAME)
            MsgBox(message, MsgBoxStyle.Exclamation, "File Error")
            Exit Sub
        End If

        Using sw As StreamWriter = File.CreateText(sTempMapFileName)
            Using sr As StreamReader = File.OpenText(sMapTemplate1)
                Do While sr.Peek() >= 0
                    sw.WriteLine(replaceTopValues(sr.ReadLine()))
                Loop
            End Using

            For company = 0 To 5
                For Each node As TreeNode In _lboNodes.Nodes(company).Nodes
                    If node.Checked Then
                        Dim sTitle As String = node.Text.Replace("'", "")
                        Dim sLat As String = node.Nodes(1).Text
                        Dim sLng As String = node.Nodes(2).Text
                        sw.WriteLine(" lboLatLng = new google.maps.LatLng(" & sLat & ", " & sLng & ");")
                        sw.WriteLine("new google.maps.Marker({")
                        sw.WriteLine("position: lboLatLng,")
                        sw.WriteLine("map: map,")
                        sw.WriteLine("title: '" & sTitle & "'")
                        sw.WriteLine("});")
                    End If
                Next
            Next

            Using sr As StreamReader = File.OpenText(sMapTemplate2)
                Do While sr.Peek() >= 0
                    sw.WriteLine(sr.ReadLine())
                Loop
            End Using
        End Using
        Dim htmlSource As String = IO.File.ReadAllText(sTempMapFileName)
        WebBrowser1.DocumentText = htmlSource
    End Sub

    Private Function replaceTopValues(sLine As String) As String
        Return sLine.Replace("|centreLat|", sCentreLat).Replace("|centreLng|", sCentreLng).Replace("|centreTitle|", sCentreTitle)
    End Function

    Private Sub btnStatic_Click(sender As Object, e As EventArgs) Handles btnStatic.Click
        LogUtil.Debug("Browsing to static map at " & uri, FORM_NAME)
        WebBrowser1.Navigate(_Uri)
    End Sub

End Class
