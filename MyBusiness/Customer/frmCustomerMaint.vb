﻿' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class FrmCustomerMaint
#Region "variables"
    Private ReadOnly oCustTa As New netwyrksDataSetTableAdapters.customerTableAdapter
    Private ReadOnly oCustListTable As New netwyrksDataSet.customerDataTable
    Private ReadOnly oCustTable As New netwyrksDataSet.customerDataTable
    Private _currentCustomer As Customer = Nothing
    Private _newCustomer As Customer = Nothing
    Private isLoading As Boolean = False
#End Region
#Region "properties"
    Private _customerId As Integer
    Public Property CustomerId() As Integer
        Get
            Return _customerId
        End Get
        Set(ByVal value As Integer)
            _customerId = value
        End Set
    End Property
#End Region
#Region "form handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub FrmCustomerMaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        logutil.info("Started", Me.Name)
        isLoading = True
        pnlCustomer.Enabled = False
        SplitContainer1.Panel2Collapsed = True
        Me.KeyPreview = True
        If _customerId = 0 Then
            NewCustomer()
        Else
            pnlCustomer.Enabled = True
            _currentCustomer = CustomerBuilder.ACustomer.StartingWith(_customerId).Build
            FillCustomerDetails()
        End If
        SpellCheckUtil.EnableSpellChecking({rtbCustNotes})
        isLoading = False
    End Sub
    Private Sub FrmCustomerMaint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        logutil.info("Closing", Me.Name)
        oCustListTable.Dispose()
        oCustTa.Dispose()
        oCustTable.Dispose()
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            ShowDiary()
        End If
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        logutil.info("Updating", Me.Name)
        Dim _custAdd As Address = AddressBuilder.AnAddress.WithAddress1(txtCustAddr1.Text.Trim).WithAddress2(txtCustAddr2.Text.Trim).WithAddress3(txtCustAddr3.Text.Trim).WithAddress4(txtCustAddr4.Text.Trim).WithPostcode(txtCustPostcode.Text.Trim.ToUpper).Build
        With _currentCustomer
            _newCustomer = CustomerBuilder.ACustomer.WithAddress(_custAdd) _
                .WithCustName(txtCustName.Text.Trim()) _
                .WithDateChanged(.DateChanged) _
                .WithDateCreated(.DateCreated) _
                .WithEmail(txtCustEmail.Text.Trim) _
                .WithNotes(rtbCustNotes.Text) _
                .WithPhone(txtCustPhone.Text.Trim) _
                .WithDiscount(nudCustDiscount.Value) _
                .WithTerms(nudDays.Value).Build
        End With
        If _customerId > 0 Then
            AmendCustomer()
        Else
            CreateCustomer()
        End If
    End Sub
    Private Sub DgvJobs_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DgvJobs.CellDoubleClick
        If DgvJobs.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = DgvJobs.SelectedRows(0)
            Dim _JobId As Integer = oRow.Cells(Me.jobId.Name).Value
            LogUtil.Info("Updating job " & CStr(_JobId), Me.Name)
            Using _jobForm As New FrmJobMaint
                _jobForm.TheJob = GetJobById(_JobId)
                _jobForm.CustomerId = _customerId
                _jobForm.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub BtnAddJob_Click(sender As Object, e As EventArgs) Handles BtnAddJob.Click
        LogUtil.Info("Adding job", Me.Name)
        Using _jobForm As New FrmJobMaint
            _jobForm.TheJob = Nothing
            _jobForm.CustomerId = _customerId
            _jobForm.ShowDialog()
            FillJobsList(_customerId)
        End Using
    End Sub
    Private Sub ChkCompleted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCompleted.CheckedChanged
        isLoading = True
        FillJobsList(_customerId)
        isLoading = False
    End Sub
#End Region
#Region "functions"
    Private Sub FillCustomerDetails()
        Dim _custId As Integer = 0
        With _currentCustomer
            txtCustName.Text = .CustName
            txtCustAddr1.Text = .Address.Address1
            txtCustAddr2.Text = .Address.Address2
            txtCustAddr3.Text = .Address.Address3
            txtCustAddr4.Text = .Address.Address4
            txtCustPostcode.Text = .Address.Postcode
            txtCustPhone.Text = .Phone
            txtCustEmail.Text = .Email
            nudCustDiscount.Value = .Discount
            nudDays.Value = .Terms
            rtbCustNotes.Text = .Notes
            _custId = .CustomerId
        End With
        SplitContainer1.Panel2Collapsed = False
        LogUtil.Info("Existing customer " & CStr(_custId), Me.Name)
        FillJobsList(_custId)
    End Sub
    Private Function CreateCustomer() As Boolean
        Dim isInsertOK As Boolean
        _customerId = InsertCustomer(_newCustomer)
        If _customerId > 0 Then
            AuditUtil.AddAudit(currentUser.UserId, AuditUtil.RecordType.Customer, _customerId, AuditUtil.AuditableAction.create, "", _newCustomer.ToString)
            isInsertOK = True
            ShowStatus(lblStatus, "Customer " & CStr(_customerId) & " created OK", Me.Name, True)
        Else
            isInsertOK = False
            ShowStatus(lblStatus, "Customer NOT created", Me.Name, True)
        End If
        Return isInsertOK
    End Function
    Private Function AmendCustomer() As Boolean
        Dim isAmendOK As Boolean = False
        With _newCustomer
            If oCustTa.UpdateCustomer(.CustName, .Address.Address1, .Address.Address2, .Address.Address3, .Address.Address4, .Address.Postcode, .Phone, .Email, .Discount, .Notes, Now, .Terms, _customerId) = 1 Then
                AuditUtil.AddAudit(currentUser.UserId, AuditUtil.RecordType.Customer, _customerId, AuditUtil.AuditableAction.update, _currentCustomer.ToString, .ToString)
                isAmendOK = True
                ShowStatus(lblStatus, "Customer updated OK", Me.Name, True)
            Else
                isAmendOK = False
                ShowStatus(lblStatus, "Customer NOT updated", Me.Name, True)
            End If
        End With
        Return isAmendOK
    End Function
    Private Sub NewCustomer()
        logutil.info("New customer", Me.Name)
        _currentCustomer = CustomerBuilder.ACustomer.StartingWithNothing.Build
        ClearCustomerDetails()
        pnlCustomer.Enabled = True
        SplitContainer1.Panel2Collapsed = True
        DgvJobs.Rows.Clear()
    End Sub
    Private Sub ClearCustomerDetails()
        txtCustName.Text = ""
        txtCustAddr1.Text = ""
        txtCustAddr2.Text = ""
        txtCustAddr3.Text = ""
        txtCustAddr4.Text = ""
        txtCustPostcode.Text = ""
        txtCustPhone.Text = ""
        txtCustEmail.Text = ""
        nudCustDiscount.Value = 0
        nudDays.Value = 0
        rtbCustNotes.Text = ""
    End Sub
    Private Sub FillJobsList(ByVal custId As Integer)
        DgvJobs.Rows.Clear()
        Dim oJobsTa As New netwyrksDataSetTableAdapters.jobTableAdapter
        Dim oJobsTable As New netwyrksDataSet.jobDataTable
        logutil.info("Finding jobs", MyBase.Name)
        oJobsTa.FillByCust(oJobsTable, custId)
        For Each oRow As netwyrksDataSet.jobRow In oJobsTable.Rows
            Dim tRow As DataGridViewRow = DgvJobs.Rows(DgvJobs.Rows.Add)
            If oRow.job_completed Then
                tRow.Visible = ChkCompleted.Checked
            End If
            tRow.Cells(Me.jobId.Name).Value = oRow.job_id
            tRow.Cells(Me.jobName.Name).Value = oRow.job_name
            tRow.Cells(Me.jobCompleted.Name).Value = If(oRow.job_completed, "Yes", "")
        Next
        oJobsTa.Dispose()
        oJobsTable.Dispose()
    End Sub
    Private Sub ShowDiary()
        Using _diary As New FrmDiary
            _diary.ForCustomerId = _customerId
            _diary.ShowDialog()
        End Using
    End Sub

    Private Sub LblF3_Click(sender As Object, e As EventArgs)
        ShowDiary()
    End Sub

    Private Sub PicDiary_Click(sender As Object, e As EventArgs) Handles picDiary.Click
        ShowDiary()
    End Sub
#End Region
End Class