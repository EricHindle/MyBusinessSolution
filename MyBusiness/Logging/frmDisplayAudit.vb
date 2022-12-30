' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmDisplayAudit
#Region "constants"
    Private Const FORM_NAME As String = "audit"
#End Region
#Region "variables"
    Private ReadOnly oTa As New netwyrksDataSetTableAdapters.auditTableAdapter
    Private ReadOnly oTable As New netwyrksDataSet.auditDataTable
#End Region
#Region "form handlers"
    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closed", FORM_NAME)
    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Starting", FORM_NAME)
        lblFormName.Text = FORM_NAME
        cbRecordType.DataSource = [Enum].GetValues(GetType(AuditUtil.RecordType))
        ClearForm()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim usercode As String = If(chkUser.Checked, txtUsercode.Text.Trim, "")

        Dim selectedRecordType As AuditUtil.RecordType
        Dim recordtype As String = ""
        If chkRecordType.Checked AndAlso cbRecordType.SelectedIndex > -1 Then
            selectedRecordType = CType(cbRecordType.SelectedValue, AuditUtil.RecordType)
            recordtype = selectedRecordType.ToString
        End If
        Dim fromDate As Date = If(chkDate.Checked, dtpDate.Value.Date, Date.MinValue)
        Dim todate As Date = If(chkDate.Checked, DateAdd(DateInterval.Day, 1, fromDate), Date.MaxValue)
        LogUtil.Info("Searching for " & usercode & "/" & recordtype & "/" & Format(fromDate, "dd/MM/yyyy"), FORM_NAME)
        Try
            Dim _auditList As List(Of AuditEntry) = GetByUserDateType(usercode, recordtype, fromDate, todate)
            LogUtil.Info("Found " & _auditList.Count & " records", FORM_NAME)
            dgvAudit.Rows.Clear()
            For Each _audit As AuditEntry In _auditList
                AddTableRow(_audit)
            Next
        Catch ex As Exception
            LogUtil.Exception("Error loading audit records", ex, "Audit Search")
        End Try

    End Sub
    Private Sub DgvAudit_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAudit.CellDoubleClick
        OpenAuditItem()
    End Sub
#End Region
#Region "subroutines"
    Private Sub ClearForm()
        txtUsercode.Text = ""
        cbRecordType.SelectedIndex = -1
        dtpDate.Value = Today
        dgvAudit.Rows.Clear()
    End Sub
    Private Sub AddTableRow(ByVal _audit As AuditEntry)
        Dim oRow As DataGridViewRow = dgvAudit.Rows(dgvAudit.Rows.Add)
        With oRow
            .Cells(audId.Name).Value = _audit.AuditId
            .Cells(audDate.Name).Value = Format(_audit.AuditDate, "dd/MM/yyyy HH:mm:ss")
            .Cells(audUser.Name).Value = _audit.AuditUsercode
            .Cells(audComputer.Name).Value = If(_audit.ComputerName Is Nothing, "unknown", _audit.ComputerName)
            .Cells(audRecType.Name).Value = _audit.RecordType
            .Cells(audRecId.Name).Value = _audit.RecordId
            .Cells(audAction.Name).Value = _audit.Action
            .Cells(audNewValue.Name).Value = If(_audit.After Is Nothing, "", _audit.After)
        End With
    End Sub
    Private Sub OpenAuditItem()
        If dgvAudit.SelectedRows.Count = 1 Then
            Dim eRow As DataGridViewRow = dgvAudit.SelectedRows(0)
            Dim auditId As Integer = eRow.Cells(audId.Name).Value
            'oExclusion = ExclusionBuilder.anExclusion.startingWith(seId)
            Using _auditItem As New frmAuditItem
                _auditItem.AuditItemId = auditId
                _auditItem.ShowDialog()
            End Using
        End If
    End Sub
#End Region
End Class