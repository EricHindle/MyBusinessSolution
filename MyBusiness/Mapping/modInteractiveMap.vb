Imports System.IO

Module modInteractiveMap
    Public _staticMapUri As String
    Public _mapLboNodes As TreeView
    Public _mapEveryNode As Boolean
    Private sCentreLat As String
    Private sCentreLng As String
    Private sCentreTitle As String
    Public Sub launchBrowser(Optional ByVal iZoom As Integer = 13)
        If _mapLboNodes.Nodes Is Nothing OrElse _mapLboNodes.Nodes.Count = 0 Then
            MsgBox("No LBOs to be mapped", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If
        sCentreLat = _mapLboNodes.Nodes(0).Nodes(0).Nodes(1).Text
        sCentreLng = _mapLboNodes.Nodes(0).Nodes(0).Nodes(2).Text
        sCentreTitle = _mapLboNodes.Nodes(0).Nodes(0).Text

        Dim sTemplateFolder = My.Settings.DataFolder
        sTemplateFolder = sTemplateFolder.Replace("<application path>", My.Application.Info.DirectoryPath)

        Dim sTempFilename As String = "tempMap" & AuthenticationUtil.generateWordyPassword(False) & "_" & Format(Now, "yyyyMMddHHmmss") & ".htm"


        Dim sTempMapFileName As String = My.Computer.FileSystem.CombinePath(sTempFolder, sTempFilename)
        Dim sMapTemplate1 As String = My.Computer.FileSystem.CombinePath(sTemplateFolder, "MapTop.tmpl")
        Dim sMapTemplate2 As String = My.Computer.FileSystem.CombinePath(sTemplateFolder, "MapBottom.tmpl")

        If Not My.Computer.FileSystem.FileExists(sMapTemplate1) Then
            MsgBox("Top template file " & sMapTemplate1 & " is missing", MsgBoxStyle.Exclamation, "File Error")
            Exit Sub
        End If

        If Not My.Computer.FileSystem.FileExists(sMapTemplate2) Then
            MsgBox("Bottom template file " & sMapTemplate2 & " is missing", MsgBoxStyle.Exclamation, "File Error")
            Exit Sub
        End If
        Dim googleAPIKey As String = GlobalSettings.getSetting("GoogleAPIKey")
        Using sw As StreamWriter = File.CreateText(sTempMapFileName)
            Using sr As StreamReader = File.OpenText(sMapTemplate1)
                Do While sr.Peek() >= 0
                    Dim sLine As String = sr.ReadLine()
                    Dim sNewLine As String = sLine.Replace("|centreLat|", sCentreLat).Replace("|centreLng|", sCentreLng).Replace("|centreTitle|", sCentreTitle) _
                                             .Replace("|zoom|", CStr(iZoom)).Replace("|googleKey|", googleAPIKey)
                    sw.WriteLine(sNewLine)
                Loop
            End Using

            For company = 0 To 6
                For Each node As TreeNode In _mapLboNodes.Nodes(company).Nodes
                    If node.Checked Or _mapEveryNode Then
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
        Process.Start(sTempMapFileName)
    End Sub
End Module
