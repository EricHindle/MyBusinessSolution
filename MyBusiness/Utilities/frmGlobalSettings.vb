'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports myBusiness.netwyrksErrorCodes

''' <summary>
''' Form to maintain Global Settings values
''' </summary>
''' <remarks>Global Settings are settings which must be the same for all system users.
''' The Keys for the settings are hardcoded so the records must not be deleted from the table.
''' New setting records are not needed unless the code changes, so they cannot be created here.</remarks>
Public Class frmGlobalSettings
#Region "Constants"
    Private Const FORM_NAME As String = "Global Settings"
#End Region
#Region "Private variable instances"
    Private RECORD_TYPE As AuditUtil.RecordType = AuditUtil.RecordType.Setting
    Private oTa As New netwyrksDataSetTableAdapters.configurationTableAdapter
    Private oTable As New netwyrksDataSet.configurationDataTable
#End Region
#Region "Form"
    Private Sub form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closed", FORM_NAME)
    End Sub

    Private Sub form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Starting", FORM_NAME)
        oTa.Fill(oTable)
        cbSelect.DataSource = oTable
        cbSelect.DisplayMember = "configuration_id"
        cbSelect.ValueMember = "configuration_id"
        lblFormName.Text = FORM_NAME
        clearForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub clearForm()
        cbSelect.SelectedIndex = -1
        cbType.SelectedValue = 0
        txtValue.Text = ""
    End Sub

    Private Sub fillForm(ByVal _name As String)
        Dim _table As New netwyrksDataSet.configurationDataTable
        Dim i As Integer = oTa.Fillbyid(_table, _name)
        If i = 1 Then
            Dim oRow As netwyrksDataSet.configurationRow = _table.Rows(0)
            txtValue.Text = oRow.configuration_value
            cbType.SelectedIndex = cbType.FindString(oRow.configuration_type)
        Else
            lblStatus.Text = "Cannot identify a single record"
        End If
        _table.Dispose()
    End Sub

    Private Sub cbSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSelect.SelectedIndexChanged
        If cbSelect.SelectedIndex > -1 Then
            If TypeOf cbSelect.SelectedValue Is String Then
                fillForm(cbSelect.SelectedValue)
            End If
        Else
            clearForm()
        End If
    End Sub
#End Region
#Region "Update"

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If cbSelect.SelectedIndex > -1 Then
            Dim recordId As String = cbSelect.SelectedValue

            If GlobalSettings.setSetting(recordId, cbType.SelectedItem, txtValue.Text) Then
                logStatus(RECORD_TYPE.ToString() & " " & recordId & " updated", True)
            Else
                logStatus(RECORD_TYPE.ToString() & " " & recordId & " NOT updated", True, TraceEventType.Warning)
            End If
        Else
            MsgBox("Pick an item from the list", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Selection error")
        End If
            oTa.Fill(oTable)
            clearForm()
    End Sub
#End Region
#Region "Subroutines"
    Private Sub logStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information)
        lblStatus.Text = sText
        If islogged Then LogUtil.addLog(sText, level, FORM_NAME)
    End Sub
#End Region
End Class