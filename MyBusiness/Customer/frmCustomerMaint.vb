Public Class frmCustomerMaint
    Private oCustTa As New netwyrksDataSetTableAdapters.customerTableAdapter
    Private oCustListTable As New netwyrksDataSet.customerDataTable
    Private oCustTable As New netwyrksDataSet.customerDataTable
    Private _currentCustomer As CustomerBuilder = Nothing
    Private _newCustomer As CustomerBuilder = Nothing
    Private isLoading As Boolean = False
    Private _customerId As Integer
    Private INSERT_WIDTH As Integer
    Private UPDATE_WIDTH As Integer
    Public Property customerId() As Integer
        Get
            Return _customerId
        End Get
        Set(ByVal value As Integer)
            _customerId = value
        End Set
    End Property

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmCustomerMaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Started", Me.Name)
        INSERT_WIDTH = Me.Width - pnlJobs.Width
        UPDATE_WIDTH = Me.Width
        isLoading = True
        pnlCustomer.Enabled = False
        pnlJobs.Visible = False
        If _customerId = 0 Then
            newCustomer()
        Else
            pnlCustomer.Enabled = True
            _currentCustomer = CustomerBuilder.aCustomer.startingWith(_customerId)
            fillCustomerDetails()
        End If
        isLoading = False
    End Sub

    Private Sub frmCustomerMaint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closing", Me.Name)
        oCustListTable.Dispose()
        oCustTa.Dispose()
        oCustTable.Dispose()
    End Sub

    Private Sub fillCustomerDetails()
        Me.Width = UPDATE_WIDTH
        Dim _custId As Integer = 0
        With _currentCustomer.build
            txtCustName.Text = .custName
            txtCustAddr1.Text = .address.address1
            txtCustAddr2.Text = .address.address2
            txtCustAddr3.Text = .address.address3
            txtCustAddr4.Text = .address.address4
            txtCustPostcode.Text = .address.postcode
            txtCustPhone.Text = .Phone
            txtCustEmail.Text = .email
            nudCustDiscount.Value = .discount
            nudDays.Value = .terms
            rtbCustNotes.Text = .notes
            _custId = .customerId
        End With
        LogUtil.Debug("Existing customer " & CStr(_custId), Me.Name)
        pnlJobs.Visible = True
        fillJobsList(_custId)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        LogUtil.Debug("Updating", Me.Name)
        Dim _custAdd As Address = AddressBuilder.anAddress.withAddress1(txtCustAddr1.Text.Trim).withAddress2(txtCustAddr2.Text.Trim).withAddress3(txtCustAddr3.Text.Trim).withAddress4(txtCustAddr4.Text.Trim).withPostcode(txtCustPostcode.Text.Trim).build
        With _currentCustomer.build
            _newCustomer = CustomerBuilder.aCustomer.withAddress(_custAdd).withCustName(txtCustName.Text.Trim()).withDateChanged(.dateChanged).withDateCreated(.dateCreated).withEmail(txtCustEmail.Text.Trim).withNotes(rtbCustNotes.Text).withPhone(txtCustPhone.Text.Trim).withDiscount(nudCustDiscount.Value).withTerms(nudDays.Value)
        End With
        If _customerId > 0 Then
            amendCustomer()
        Else
            insertCustomer()
        End If
    End Sub

    Private Function insertCustomer() As Boolean
        Dim isInsertOK As Boolean = False
        With _newCustomer.build
            _customerId = oCustTa.InsertCustomer(.custName, .address.address1, .address.address2, .address.address3, .address.address4, .address.postcode, .Phone, .email, .discount, .notes, Now, Nothing, .terms)
            If _customerId > 0 Then
                AuditUtil.addAudit(currentUser.userId, AuditUtil.RecordType.Customer, _customerId, AuditUtil.AuditableAction.create, "", .ToString)
                isInsertOK = True
                showStatus(lblStatus, "Customer " & CStr(_customerId) & " created OK", Me.Name, True)
            Else
                isInsertOK = False
                showStatus(lblStatus, "Customer NOT created", Me.Name, True)
            End If
            Return isInsertOK
        End With

    End Function
    Private Function amendCustomer() As Boolean
        Dim isAmendOK As Boolean = False
        With _newCustomer.build
            If oCustTa.UpdateCustomer(.custName, .address.address1, .address.address2, .address.address3, .address.address4, .address.postcode, .Phone, .email, .discount, .notes, Now, .terms, _customerId) = 1 Then
                AuditUtil.addAudit(currentUser.userId, AuditUtil.RecordType.Customer, _customerId, AuditUtil.AuditableAction.update, _currentCustomer.build.ToString, .ToString)
                isAmendOK = True
                showStatus(lblStatus, "Customer updated OK", Me.Name, True)
            Else
                isAmendOK = False
                showStatus(lblStatus, "Customer NOT updated", Me.Name, True)
            End If
        End With
        Return isAmendOK
    End Function

    Private Sub newCustomer()
        LogUtil.Debug("New customer", Me.Name)
        _currentCustomer = CustomerBuilder.aCustomer.startingWithNothing
        clearCustomerDetails()
        pnlCustomer.Enabled = True
        pnlJobs.Visible = False
        dgvJobs.Rows.Clear()
        Me.Width = INSERT_WIDTH
    End Sub

    Private Sub clearCustomerDetails()
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

    Private Sub fillJobsList(ByVal custId As Integer)
        dgvJobs.Rows.Clear()
        Dim oJobsTa As New netwyrksDataSetTableAdapters.jobTableAdapter
        Dim oJobsTable As New netwyrksDataSet.jobDataTable
        LogUtil.Debug("Finding jobs", Me.Name)
        oJobsTa.FillByCust(oJobsTable, custId)
        For Each oRow As netwyrksDataSet.jobRow In oJobsTable.Rows
            Dim tRow As DataGridViewRow = dgvJobs.Rows(dgvJobs.Rows.Add)
            If oRow.job_completed Then
                tRow.Visible = chkCompleted.Checked
            End If
            tRow.Cells(Me.jobId.Name).Value = oRow.job_id
            tRow.Cells(Me.jobName.Name).Value = oRow.job_name
            tRow.Cells(Me.jobCompleted.Name).Value = If(oRow.job_completed, "Yes", "")
        Next
        oJobsTa.Dispose()
        oJobsTable.Dispose()
    End Sub

    Private Sub dgvJobs_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvJobs.CellDoubleClick
        If dgvJobs.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = dgvJobs.SelectedRows(0)
            Dim _JobId As Integer = oRow.Cells(Me.jobId.Name).Value
            LogUtil.Debug("Updating job " & CStr(_JobId), Me.Name)
            Using _jobForm As New frmJob
                _jobForm.theJob = jobBuilder.aJobBuilder.startingWith(_JobId)
                _jobForm.customerId = _customerId
                _jobForm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub btnAddJob_Click(sender As Object, e As EventArgs) Handles btnAddJob.Click
        LogUtil.Debug("Adding job", Me.Name)
        Using _jobForm As New frmJob
            _jobForm.theJob = Nothing
            _jobForm.customerId = _customerId
            _jobForm.ShowDialog()
        End Using
    End Sub

    Private Sub chkCompleted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCompleted.CheckedChanged
        isLoading = True
        fillJobsList(_customerId)
        isLoading = False
    End Sub

End Class