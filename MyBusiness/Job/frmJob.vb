Public Class frmJob
    Private isLoading As Boolean = False
    Private oCustTa As New netwyrksDataSetTableAdapters.customerTableAdapter
    Private oCustListTable As New netwyrksDataSet.customerDataTable
    Private oJobTa As New netwyrksDataSetTableAdapters.jobTableAdapter
    Private oJobListTable As New netwyrksDataSet.jobDataTable
    Private oTaskTa As New netwyrksDataSetTableAdapters.taskTableAdapter
    Private _jobBuilder As jobBuilder
    Private _job As job
    Private _currentJobId As Integer = -1
    Private _customerId As Integer
    Private _newJob As job
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
    Public Property theJob() As jobBuilder
        Get
            Return _jobBuilder
        End Get
        Set(ByVal value As jobBuilder)
            _jobBuilder = value
        End Set
    End Property

    Private Sub frmJob_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closing", Me.Name)
        oCustTa.Dispose()
        oCustListTable.Dispose()
        oJobTa.Dispose()
        oJobListTable.Dispose()
    End Sub

    Private Sub frmJob_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.UserTableAdapter.Fill(Me.NetwyrksDataSet.user)
        LogUtil.Debug("Started", Me.Name)
        INSERT_WIDTH = Me.Width - pnlTask.Width
        UPDATE_WIDTH = Me.Width
        isLoading = True
        pnlJob.Enabled = False
        pnlTask.Visible = False
        loadCustomerList()

        If _jobBuilder IsNot Nothing Then
            _job = _jobBuilder.build
            _currentJobId = _job.jobId
            pnlJob.Enabled = True
            fillJobDetails()
        Else
            newJob()
            _currentJobId = -1
        End If
        isLoading = False
    End Sub

    Private Sub fillJobDetails()
        Me.Width = UPDATE_WIDTH
        With _job
            cbCust.SelectedValue = .jobCustomerId
            txtJobName.Text = .jobName
            chkCompleted.Checked = .isJobCompleted
            rtbJobNotes.Text = .jobDescription
            cbUser.SelectedValue = .jobUser
        End With
        LogUtil.Debug("Existing job " & CStr(_currentJobId), Me.Name)
        pnlTask.Visible = True
        fillTaskList(_currentJobId)
        fillProductList(_currentJobId)
    End Sub
    Private Sub clearJobdetails()
        cbCust.SelectedIndex = -1
        txtJobName.Text = ""
        chkCompleted.Checked = False
        rtbJobNotes.Text = ""
    End Sub
    Private Sub loadCustomerList()
        LogUtil.Debug("Finding customers", Me.Name)
        oCustTa.Fill(oCustListTable)
        cbCust.DataSource = oCustListTable
        cbCust.ValueMember = oCustListTable.customer_idColumn.ColumnName
        cbCust.DisplayMember = oCustListTable.customer_nameColumn.ColumnName
        cbCust.SelectedIndex = -1
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub fillTaskList(ByVal pJobId As Integer)
        dgvTasks.Rows.Clear()
        Dim oTaskTa As New netwyrksDataSetTableAdapters.taskTableAdapter
        Dim oTaskTable As New netwyrksDataSet.taskDataTable
        LogUtil.Debug("Finding tasks", Me.Name)
        oTaskTa.FillByJob(oTaskTable, pJobId)
        For Each oRow As netwyrksDataSet.taskRow In oTaskTable.Rows
            Dim tRow As DataGridViewRow = dgvTasks.Rows(dgvTasks.Rows.Add)
            tRow.Cells(Me.taskId.Name).Value = oRow.task_id
            tRow.Cells(Me.taskName.Name).Value = oRow.task_name
            Dim _startDue As String = If(oRow.Istask_start_dueNull, "", Format(CDate(oRow.task_start_due), "dd/MM/yyyy"))
            tRow.Cells(Me.taskStartDue.Name).Value = _startDue
            tRow.Cells(Me.taskHours.Name).Value = oRow.task_time
            tRow.Cells(Me.taskStarted.Name).Value = CStr(CBool(oRow.task_started))
            tRow.Cells(Me.taskCompleted.Name).Value = CStr(CBool(oRow.task_completed))
        Next
        oTaskTa.Dispose()
        oTaskTable.Dispose()
    End Sub
    Private Sub fillProductList(ByVal pJobId As Integer)
        dgvProducts.Rows.Clear()
        Dim oJobProductTa As New netwyrksDataSetTableAdapters.job_productTableAdapter
        Dim oJobProductTable As New netwyrksDataSet.job_productDataTable
        Dim oProdTa As New netwyrksDataSetTableAdapters.productTableAdapter
        Dim oProdTable As New netwyrksDataSet.productDataTable
        Dim oSuppTa As New netwyrksDataSetTableAdapters.supplierTableAdapter
        Dim oSuppTable As New netwyrksDataSet.supplierDataTable
        LogUtil.Debug("Finding products", Me.Name)
        oJobProductTa.FillByJob(oJobProductTable, pJobId)
        For Each oRow As netwyrksDataSet.job_productRow In oJobProductTable.Rows
            Dim _jpId As Integer = oRow.job_product_id
            Dim _productId As Integer = oRow.jp_product_id
            Dim _qty As Integer = oRow.jp_quantity
            Dim _productName As String = "** Missing"
            Dim _supplierName As String = "** Missing"
            Dim _supplierId As Integer = -1
            Dim _cost As Decimal = 0
            Dim _price As Decimal = 0
            If oProdTa.FillById(oProdTable, _productId) = 1 Then
                Dim pRow As netwyrksDataSet.productRow = oProdTable.Rows(0)
                _productName = pRow.product_name
                _supplierId = pRow.product_supplier_id
                _cost = pRow.product_cost
                _price = pRow.product_price
            End If
            If _supplierId > 0 Then
                If oSuppTa.FillById(oSuppTable, _supplierId) = 1 Then
                    Dim sRow As netwyrksDataSet.supplierRow = oSuppTable.Rows(0)
                    _supplierName = sRow.supplier_name
                End If
            End If
            Dim tRow As DataGridViewRow = dgvProducts.Rows(dgvProducts.Rows.Add)
            tRow.Cells(Me.prodSupp.Name).Value = _supplierName
            tRow.Cells(Me.prodName.Name).Value = _productName
            tRow.Cells(Me.prodId.Name).Value = _productId
            tRow.Cells(Me.jpId.Name).Value = _jpId
            tRow.Cells(Me.prodQty.Name).Value = _qty
            tRow.Cells(Me.prodCost.Name).Value = _cost
            tRow.Cells(Me.prodPrice.Name).Value = _price
        Next
        dgvProducts.ClearSelection()
        oJobProductTa.Dispose()
        oJobProductTable.Dispose()
        oProdTable.Dispose()
        oProdTa.Dispose()
        oSuppTable.Dispose()
        oSuppTa.Dispose()

    End Sub

    Private Sub btnViewCust_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnViewCust.Click
        LogUtil.Debug("View customer " & CStr(cbCust.SelectedValue), Me.Name)
        Using _custForm As New frmViewCust
            Dim oCustRow As netwyrksDataSet.customerRow = DirectCast(cbCust.SelectedItem, DataRowView).Row
            _custForm.theCustomer = CustomerBuilder.aCustomer.startingWith(oCustRow).build
            _custForm.ShowDialog()
        End Using
    End Sub

    Private Sub btnAddTask_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddTask.Click
        LogUtil.Debug("Add task to job", Me.Name)
        Using _taskForm As New frmTask
            _taskForm.theJob = _jobBuilder.build
            _taskForm.ShowDialog()
        End Using
        fillTaskList(_currentJobId)
    End Sub

    Private Sub btnAddProduct_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMaintProducts.Click
        LogUtil.Debug("Maintain products on job", Me.Name)
        Using _jobProductForm As New frmJobProducts
            _jobProductForm.theJob = _jobBuilder
            _jobProductForm.ShowDialog()
        End Using
        fillProductList(_currentJobId)
    End Sub

    Private Sub newJob()
        LogUtil.Debug("New job", Me.Name())
        Me.Width = INSERT_WIDTH
        clearJobdetails()
        If _customerId > 0 Then
            cbCust.SelectedValue = _customerId
        End If
        pnlJob.Enabled = True
        pnlTask.Visible = False
        _jobBuilder = jobBuilder.aJobBuilder.startingWithNothing
        cbUser.SelectedValue = currentUser.userId
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        With _jobBuilder.build
            _newJob = jobBuilder.aJobBuilder.withJobName(txtJobName.Text.Trim).withJobDescription(rtbJobNotes.Text.Trim).withJobCustomerId(cbCust.SelectedValue).withJobCompleted(chkCompleted.Checked).withJobCreated(.jobCreated).withJobChanged(.jobChanged).withjobUser(cbUser.SelectedValue).build
        End With
        Dim newJobId As Integer = -1
        If _currentJobId > 0 Then
            amendjob()
        Else
            insertJob()
        End If
        Me.Close()
    End Sub
    Private Function amendjob() As Boolean
        Dim isAmendOk As Boolean = False
        LogUtil.Debug("Updating job " & CStr(_currentJobId), Me.Name)
        With _newJob
            If oJobTa.UpdateJob(.jobName, .jobDescription, .isJobCompleted, Now, .jobCustomerId, "", "", "", Nothing, Nothing, .jobUser, _currentJobId) = 1 Then
                AuditUtil.addAudit(currentUser.userId, AuditUtil.RecordType.Job, _currentJobId, AuditUtil.AuditableAction.create, _jobBuilder.ToString, .ToString)
                isAmendOk = True
                showStatus(lblStatus, "Job updated OK", Me.Name, True)
            Else
                isAmendOk = False
                showStatus(lblStatus, "Job NOT updated", Me.Name, True)

            End If
        End With
        Return isAmendOk
    End Function

    Private Function insertJob() As Boolean
        Dim isInsertOk As Boolean
        LogUtil.Debug("Inserting job", Me.Name)
        With _newJob
            _currentJobId = oJobTa.InsertJob(.jobName, .jobDescription, .isJobCompleted, Now, .jobCustomerId, "", "", "", Nothing, Nothing, .jobUser)
            If _currentJobId > 0 Then
                AuditUtil.addAudit(currentUser.userId, AuditUtil.RecordType.Job, _currentJobId, AuditUtil.AuditableAction.create, "", .ToString)
                isInsertOk = True
                showStatus(lblStatus, "Job " & CStr(_currentJobId) & " Created OK", Me.Name, True)
            Else
                isInsertOk = False
                showStatus(lblStatus, "Job NOT created", Me.Name, True)
            End If
        End With
        Return isInsertOk
    End Function


    Private Sub cbCust_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbCust.SelectedIndexChanged
        btnViewCust.Enabled = cbCust.SelectedIndex > 0
    End Sub

    Private Sub btnRemoveTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveTask.Click
        If dgvTasks.SelectedRows.Count = 1 Then
            LogUtil.Debug("Deleting task", Me.Name)
            Dim oRow As DataGridViewRow = dgvTasks.SelectedRows(0)
            Dim taskName As String = oRow.Cells(Me.taskName.Name).Value
            Dim _taskId As Integer = CInt(oRow.Cells(Me.taskId.Name).Value)
            If MsgBox("Do you want to remove this task?" & vbCrLf & QUOTES & taskName & QUOTES, MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If oTaskTa.DeleteTask(_taskId) = 1 Then
                    showStatus(lblStatus, "Task removed OK", Me.Name, True)
                Else
                    showStatus(lblStatus, "Task NOT removed", Me.Name, True)
                End If
                fillTaskList(_currentJobId)
            End If
        End If
    End Sub

    Private Sub dgvTasks_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTasks.CellDoubleClick
        If dgvTasks.SelectedRows.Count = 1 Then
            LogUtil.Debug("Updating task", Me.Name)
            Dim oRow As DataGridViewRow = dgvTasks.SelectedRows(0)
            Dim _taskId As Integer = CInt(oRow.Cells(Me.taskId.Name).Value)
            Using _taskForm As New frmTask

                _taskForm.theJob = _jobBuilder.build
                _taskForm.taskId = _taskId
                _taskForm.ShowDialog()
            End Using
            clearJobdetails()
            fillJobDetails()
        End If
    End Sub

    Private Sub dgvProducts_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProducts.CellDoubleClick
        LogUtil.Debug("Maintain products on job", Me.Name)
        Using _jobProductForm As New frmJobProducts
            _jobProductForm.theJob = _jobBuilder
            _jobProductForm.ShowDialog()
        End Using
        fillProductList(_currentJobId)
    End Sub

    Private Sub btnInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoice.Click
        If _job IsNot Nothing Then
            Dim _invoicePrinter As New InvoicePrinter
            _invoicePrinter.CreateInvoice(_job)
        End If
    End Sub

End Class