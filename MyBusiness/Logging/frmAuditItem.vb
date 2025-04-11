' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports HindlewareLib.Logging

Public Class FrmAuditItem
#Region "Contants"
    Private Const FORM_NAME As String = "audit item"

#End Region
#Region "Private variable instances"
    Private ReadOnly oAuditTa As New MyBusinessDataSetTableAdapters.auditTableAdapter
    Private ReadOnly oAuditTable As New MyBusinessDataSet.auditDataTable
#End Region
#Region "Properties"
    Private _auditItemId As Integer
    Public Property AuditItemId() As Integer
        Get
            Return _auditItemId
        End Get
        Set(ByVal value As Integer)
            _auditItemId = value
        End Set
    End Property

#End Region
#Region "Form Event Handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oAuditTa.Dispose()
        oAuditTable.Dispose()
        logutil.info("Closed", FORM_NAME)
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        logutil.info("Starting", FORM_NAME)
        lblFormName.Text = FORM_NAME

        If oAuditTa.FillById(oAuditTable, _auditItemId) = 1 Then
            FillAuditItem()
        Else
            ClearForm()
            LogStatus("Audit item not found", True)
        End If
    End Sub
#End Region

#Region "Subroutines"
    Private Sub LogStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information, Optional ByVal errorCode As String = Nothing)
        lblStatus.Text = sText
        If islogged Then LogUtil.AddLog(sText, level, FORM_NAME, errorCode, 0)
    End Sub
    Private Sub FillAuditItem()
        Dim oRow As MyBusinessDataSet.auditRow = oAuditTable.Rows(0)
        lblAction.Text = oRow.audit_action.ToUpper
        lblComputerName.Text = oRow.audit_computer_name
        lblDateChanged.Text = Format(oRow.audit_date, "dd MMM yyyy  HH:mm:ss")
        lblNewValue.Text = oRow.audit_after
        lblRecordType.Text = oRow.audit_record_type
        lblUserCode.Text = oRow.audit_user_id
    End Sub
    Private Sub ClearForm()
        lblAction.Text = ""
        lblComputerName.Text = ""
        lblDateChanged.Text = ""
        lblNewValue.Text = ""
        lblRecordType.Text = ""
        lblUserCode.Text = ""
    End Sub
#End Region
End Class