' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class frmAuditItem
#Region "Contants"
    Private Const FORM_NAME As String = "audit item"
#End Region
#Region "Private variable instances"
    Private RECORD_TYPE As AuditUtil.RecordType = AuditUtil.RecordType.Customer
    Private oAuditTa As New netwyrksDataSetTableAdapters.auditTableAdapter
    Private oAuditTable As New netwyrksDataSet.auditDataTable
#End Region
#Region "Properties"
    Private _auditItemId As Integer
    Public Property auditItemId() As Integer
        Get
            Return _auditItemId
        End Get
        Set(ByVal value As Integer)
            _auditItemId = value
        End Set
    End Property

#End Region
#Region "Form Event Handlers"
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oAuditTa.Dispose()
        oAuditTable.Dispose()
        LogUtil.Debug("Closed", FORM_NAME)
    End Sub

    Private Sub form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Starting", FORM_NAME)
        lblFormName.Text = FORM_NAME

        If oAuditTa.FillById(oAuditTable, _auditItemId) = 1 Then
            fillAuditItem()
        Else
            clearForm()
            logStatus("Audit item not found", True)
        End If
    End Sub
#End Region

#Region "Subroutines"
    Private Sub logStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information, Optional ByVal errorCode As String = Nothing)
        lblStatus.Text = sText
        If islogged Then LogUtil.addLog(sText, level, FORM_NAME, errorCode)
    End Sub
    Private Sub fillAuditItem()
        Dim oRow As netwyrksDataSet.auditRow = oAuditTable.Rows(0)
        lblAction.Text = oRow.audit_action.ToUpper
        lblComputerName.Text = oRow.audit_computer_name
        lblDateChanged.Text = Format(oRow.audit_date, "dd MMM yyyy  HH:mm:ss")
        lblNewValue.Text = oRow.audit_after
        lblRecordType.Text = oRow.audit_record_type
        lblUserCode.Text = oRow.audit_user_id
    End Sub
    Private Sub clearForm()
        lblAction.Text = ""
        lblComputerName.Text = ""
        lblDateChanged.Text = ""
        lblNewValue.Text = ""
        lblRecordType.Text = ""
        lblUserCode.Text = ""
    End Sub
#End Region
End Class