' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class FrmCustomerMaint
#Region "variables"
    Private ReadOnly oCustTa As New netwyrksDataSetTableAdapters.customerTableAdapter
    Private ReadOnly oCustListTable As New netwyrksDataSet.customerDataTable
    Private ReadOnly oCustTable As New netwyrksDataSet.customerDataTable
    Private _currentCustomer As CustomerBuilder = Nothing
    Private _newCustomer As CustomerBuilder = Nothing
    Private isLoading As Boolean = False
    Private INSERT_WIDTH As Integer
    Private UPDATE_WIDTH As Integer
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
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub FrmCustomerMaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Started", Me.Name)
        INSERT_WIDTH = Me.Width - pnlJobs.Width
        UPDATE_WIDTH = Me.Width
        isLoading = True
        pnlCustomer.Enabled = False
        pnlJobs.Visible = False
        If _customerId = 0 Then
            NewCustomer()
        Else
            pnlCustomer.Enabled = True
            _currentCustomer = CustomerBuilder.ACustomer.StartingWith(_customerId)
            FillCustomerDetails()
        End If
        SpellCheckUtil.EnableSpellChecking({rtbCustNotes})
        isLoading = False
    End Sub
    Private Sub FrmCustomerMaint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closing", Me.Name)
        oCustListTable.Dispose()
        oCustTa.Dispose()
        oCustTable.Dispose()
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        LogUtil.Debug("Updating", Me.Name)
        Dim _custAdd As Address = AddressBuilder.AnAddress.WithAddress1(txtCustAddr1.Text.Trim).WithAddress2(txtCustAddr2.Text.Trim).WithAddress3(txtCustAddr3.Text.Trim).WithAddress4(txtCustAddr4.Text.Trim).WithPostcode(txtCustPostcode.Text.Trim).Build
        With _currentCustomer.Build
            _newCustomer = CustomerBuilder.ACustomer.WithAddress(_custAdd).WithCustName(txtCustName.Text.Trim()).WithDateChanged(.DateChanged).WithDateCreated(.DateCreated).WithEmail(txtCustEmail.Text.Trim).WithNotes(rtbCustNotes.Text).WithPhone(txtCustPhone.Text.Trim).WithDiscount(nudCustDiscount.Value).WithTerms(nudDays.Value)
        End With
        If _customerId > 0 Then
            AmendCustomer()
        Else
            InsertCustomer()
        End If
    End Sub
    Private Sub DgvJobs_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DgvJobs.CellDoubleClick
        If DgvJobs.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = DgvJobs.SelectedRows(0)
            Dim _JobId As Integer = oRow.Cells(Me.jobId.Name).Value
            LogUtil.Debug("Updating job " & CStr(_JobId), Me.Name)
            Using _jobForm As New frmJob
                _jobForm.theJob = JobBuilder.AJobBuilder.StartingWith(_JobId)
                _jobForm.customerId = _customerId
                _jobForm.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub BtnAddJob_Click(sender As Object, e As EventArgs) Handles BtnAddJob.Click
        LogUtil.Debug("Adding job", Me.Name)
        Using _jobForm As New frmJob
            _jobForm.theJob = Nothing
            _jobForm.customerId = _customerId
            _jobForm.ShowDialog()
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
        Me.Width = UPDATE_WIDTH
        Dim _custId As Integer = 0
        With _currentCustomer.Build
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
        LogUtil.Debug("Existing customer " & CStr(_custId), Me.Name)
        pnlJobs.Visible = True
        FillJobsList(_custId)
    End Sub
    Private Function InsertCustomer() As Boolean
        Dim isInsertOK As Boolean = False
        With _newCustomer.Build
            _customerId = oCustTa.InsertCustomer(.CustName, .Address.Address1, .Address.Address2, .Address.Address3, .Address.Address4, .Address.Postcode, .Phone, .Email, .Discount, .Notes, Now, Nothing, .Terms)
            If _customerId > 0 Then
                AuditUtil.addAudit(currentUser.UserId, AuditUtil.RecordType.Customer, _customerId, AuditUtil.AuditableAction.create, "", .ToString)
                isInsertOK = True
                showStatus(lblStatus, "Customer " & CStr(_customerId) & " created OK", Me.Name, True)
            Else
                isInsertOK = False
                showStatus(lblStatus, "Customer NOT created", Me.Name, True)
            End If
            Return isInsertOK
        End With

    End Function
    Private Function AmendCustomer() As Boolean
        Dim isAmendOK As Boolean = False
        With _newCustomer.Build
            If oCustTa.UpdateCustomer(.CustName, .Address.Address1, .Address.Address2, .Address.Address3, .Address.Address4, .Address.Postcode, .Phone, .Email, .Discount, .Notes, Now, .Terms, _customerId) = 1 Then
                AuditUtil.addAudit(currentUser.UserId, AuditUtil.RecordType.Customer, _customerId, AuditUtil.AuditableAction.update, _currentCustomer.Build.ToString, .ToString)
                isAmendOK = True
                showStatus(lblStatus, "Customer updated OK", Me.Name, True)
            Else
                isAmendOK = False
                showStatus(lblStatus, "Customer NOT updated", Me.Name, True)
            End If
        End With
        Return isAmendOK
    End Function
    Private Sub NewCustomer()
        LogUtil.Debug("New customer", Me.Name)
        _currentCustomer = CustomerBuilder.ACustomer.StartingWithNothing
        ClearCustomerDetails()
        pnlCustomer.Enabled = True
        pnlJobs.Visible = False
        DgvJobs.Rows.Clear()
        Me.Width = INSERT_WIDTH
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
        LogUtil.Debug("Finding jobs", Me.Name)
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
#End Region
End Class