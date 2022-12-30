' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

''' <summary>
''' Form to maintain Global Settings values
''' </summary>
''' <remarks>Global Settings are settings which must be the same for all system users.
''' The Keys for the settings are hardcoded so the records must not be deleted from the table.
''' New setting records are not needed unless the code changes, so they cannot be created here.</remarks>
Public Class FrmGlobalSettings
#Region "Constants"
    Private Const FORM_NAME As String = "Global Settings"
#End Region
#Region "Private variable instances"
    Private ReadOnly RECORD_TYPE As AuditUtil.RecordType = AuditUtil.RecordType.Setting
    Private ReadOnly oTa As New netwyrksDataSetTableAdapters.configurationTableAdapter
    Private ReadOnly oTable As New netwyrksDataSet.configurationDataTable
#End Region
#Region "Form"
    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        logutil.info("Closed", FORM_NAME)
    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        logutil.info("Starting", FORM_NAME)
        oTa.Fill(oTable)
        cbSelect.DataSource = oTable
        cbSelect.DisplayMember = "configuration_id"
        cbSelect.ValueMember = "configuration_id"
        lblFormName.Text = FORM_NAME
        ClearForm()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub ClearForm()
        cbSelect.SelectedIndex = -1
        cbType.SelectedValue = 0
        txtValue.Text = ""
    End Sub
    Private Sub FillForm(ByVal _name As String)
        Dim _table As New netwyrksDataSet.configurationDataTable
        Dim i As Integer = oTa.FillById(_table, _name)
        If i = 1 Then
            Dim oRow As netwyrksDataSet.configurationRow = _table.Rows(0)
            txtValue.Text = oRow.configuration_value
            cbType.SelectedIndex = cbType.FindString(oRow.configuration_type)
        Else
            lblStatus.Text = "Cannot identify a single record"
        End If
        _table.Dispose()
    End Sub
    Private Sub CbSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSelect.SelectedIndexChanged
        If cbSelect.SelectedIndex > -1 Then
            If TypeOf cbSelect.SelectedValue Is String Then
                FillForm(cbSelect.SelectedValue)
            End If
        Else
            ClearForm()
        End If
    End Sub
#End Region
#Region "Update"
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If cbSelect.SelectedIndex > -1 Then
            Dim recordId As String = cbSelect.SelectedValue

            If GlobalSettings.SetSetting(recordId, cbType.SelectedItem, txtValue.Text) Then
                LogStatus(RECORD_TYPE.ToString() & " " & recordId & " updated", True)
            Else
                LogStatus(RECORD_TYPE.ToString() & " " & recordId & " NOT updated", True, TraceEventType.Warning)
            End If
        Else
            MsgBox("Pick an item from the list", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Selection error")
        End If
        oTa.Fill(oTable)
        ClearForm()
    End Sub
#End Region
#Region "Subroutines"
    Private Sub LogStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information)
        lblStatus.Text = sText
        If islogged Then LogUtil.AddLog(sText, level, FORM_NAME)
    End Sub
#End Region
End Class