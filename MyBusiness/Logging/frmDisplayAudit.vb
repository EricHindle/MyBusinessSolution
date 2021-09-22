' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

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
        LogUtil.Debug("Closed", FORM_NAME)
    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Starting", FORM_NAME)
        lblFormName.Text = FORM_NAME
        cbRecordType.DataSource = [Enum].GetValues(GetType(AuditUtil.RecordType))
        ClearForm()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim usercode As String = If(chkUser.Checked, txtUsercode.Text.Trim, "")
        Dim selectedRecordType As AuditUtil.RecordType = CType(cbRecordType.SelectedValue, AuditUtil.RecordType)
        Dim recordtype As String = If(chkRecordType.Checked, selectedRecordType.ToString, "")
        Dim fromDate As Date = If(chkDate.Checked, dtpDate.Value.Date, Date.MinValue)
        Dim todate As Date = If(chkDate.Checked, DateAdd(DateInterval.Day, 1, fromDate), Date.MaxValue)
        LogUtil.Debug("Searching for " & usercode & "/" & recordtype & "/" & Format(fromDate, "dd/MM/yyyy"), FORM_NAME)
        Try
            Dim i As Integer = oTa.FillByUserDateType(oTable, usercode, recordtype, fromDate, todate)
            LogUtil.Debug("Found " & CInt(i) & " records", FORM_NAME)
            dgvAudit.Rows.Clear()
            For Each oRow As netwyrksDataSet.auditRow In oTable.Rows
                AddTableRow(oRow)
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
    Private Sub AddTableRow(ByVal oRow As netwyrksDataSet.auditRow)
        Dim r As Integer = dgvAudit.Rows.Add
        With dgvAudit.Rows(r)
            .Cells(Me.audId.Name).Value = oRow.audit_id
            .Cells(Me.audDate.Name).Value = Format(oRow.audit_date, "dd/MM/yyyy HH:mm:ss")
            .Cells(Me.audUser.Name).Value = oRow.audit_user_id
            .Cells(Me.audComputer.Name).Value = If(oRow.Isaudit_computer_nameNull, "unknown", oRow.audit_computer_name)
            .Cells(Me.audRecType.Name).Value = oRow.audit_record_type
            .Cells(Me.audRecId.Name).Value = oRow.audit_record_id
            .Cells(Me.audAction.Name).Value = oRow.audit_action
            .Cells(Me.audNewValue.Name).Value = If(oRow.Isaudit_afterNull(), "", oRow.audit_after)
        End With
    End Sub
    Private Sub OpenAuditItem()
        If dgvAudit.SelectedRows.Count = 1 Then
            Dim eRow As DataGridViewRow = dgvAudit.SelectedRows(0)
            Dim auditId As Integer = eRow.Cells(Me.audId.Name).Value
            'oExclusion = ExclusionBuilder.anExclusion.startingWith(seId)
            Using _auditItem As New frmAuditItem
                _auditItem.AuditItemId = auditId
                _auditItem.ShowDialog()
            End Using
        End If
    End Sub
#End Region
End Class