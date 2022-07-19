' Hindleware
' Copyright (c) 2022, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

Public Class FrmJobMaint

#Region "variables"

    Private isLoading As Boolean = False
    Private ReadOnly oCustTa As New netwyrksDataSetTableAdapters.customerTableAdapter
    Private ReadOnly oCustListTable As New netwyrksDataSet.customerDataTable
    Private ReadOnly oUserTa As New netwyrksDataSetTableAdapters.userTableAdapter
    Private ReadOnly oUserTable As New netwyrksDataSet.userDataTable
    Private _job As Job
    Private _currentJobId As Integer = -1
    Private _customerId As Integer
    Private _currentCust As Customer = CustomerBuilder.ACustomer.StartingWithNothing.Build
    Private _newJob As Job
    Private INSERT_WIDTH As Integer
    Private UPDATE_WIDTH As Integer
#End Region
#Region "properties"
    Public Property CustomerId() As Integer
        Get
            Return _customerId
        End Get
        Set(ByVal value As Integer)
            _customerId = value
        End Set
    End Property
    Public Property TheJob() As Job
        Get
            Return _job
        End Get
        Set(ByVal value As Job)
            _job = value
        End Set
    End Property
#End Region
#Region "form handlers"
    Private Sub FrmJob_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closing", Me.Name)
        oCustTa.Dispose()
        oCustListTable.Dispose()
        oUserTa.Dispose()
        oUserTable.Dispose()
    End Sub
    Private Sub FrmJob_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Started", Me.Name)
        isLoading = True
        Try
            oUserTa.Fill(oUserTable)
            cbUser.DataSource = oUserTable
            cbUser.DisplayMember = "user_code"
            cbUser.ValueMember = "user_id"
        Catch ex As Exception

        End Try
        LoadCustomerList()
        If _job IsNot Nothing Then
            _currentJobId = _job.JobId
            FillJobDetails()
        Else
            NewJob()
            _currentJobId = -1
        End If
        SpellCheckUtil.EnableSpellChecking({rtbJobNotes})
        isLoading = False
    End Sub
    Private Sub BtnViewCust_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnViewCust.Click
        LogUtil.Debug("View customer " & CStr(cbCust.SelectedValue), Me.Name)
        Using _custForm As New FrmViewCust
            _custForm.TheCustomer = _currentCust
            _custForm.ShowDialog()
        End Using
    End Sub
    Private Sub BtnAddTask_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddTask.Click
        LogUtil.Debug("Add task to job", Me.Name)
        Using _taskForm As New FrmTask
            _taskForm.TheJob = _job
            _taskForm.ShowDialog()
        End Using
        FillTaskList(_currentJobId)
    End Sub
    Private Sub BtnAddProduct_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMaintProducts.Click
        LogUtil.Debug("Maintain products on job", Me.Name)
        Using _jobProductForm As New FrmJobProducts
            _jobProductForm.TheJob = _job
            _jobProductForm.ShowDialog()
        End Using
        FillProductList(_currentJobId)
    End Sub
    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        With _job
            _newJob = JobBuilder.AJob.WithJobName(txtJobName.Text.Trim) _
            .WithJobDescription(rtbJobNotes.Text.Trim) _
            .WithJobCustomerId(cbCust.SelectedValue) _
            .WithJobCompleted(chkCompleted.Checked) _
            .WithJobReference(TxtJobReference.Text) _
            .WithJobInvoiceNumber(TxtInvoiceNumber.Text) _
            .WithJobInvoiceDate(DtpInvoiceDate.Value) _
            .WithJobPoNumber(TxtPurchaseOrder.Text) _
            .WithJobCreated(.JobCreated) _
            .WithJobChanged(.JobChanged) _
            .WithJobUser(cbUser.SelectedValue) _
            .WithJobPaymentDue(DtpPaymentDue.Value) _
            .WithJobId(_currentJobId) _
            .Build
        End With
        Dim newJobId As Integer = -1
        If _currentJobId > 0 Then
            Amendjob()
        Else
            CreateJob()
            SplitContainer2.Panel2Collapsed = False
            GrpInvoice.Enabled = True
        End If
        Me.Close()
    End Sub
    Private Sub CbCust_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbCust.SelectedIndexChanged
        If Not isLoading Then
            GetCurrentCustomer()
        Else
            btnViewCust.Enabled = False
        End If
    End Sub
    Private Sub GetCurrentCustomer()
        If cbCust.SelectedIndex > -1 Then
            btnViewCust.Enabled = True
            _currentCust = GetCustomer(cbCust.SelectedValue)
        Else
            btnViewCust.Enabled = False
            _currentCust = CustomerBuilder.ACustomer.StartingWithNothing.Build
        End If
    End Sub
    Private Sub BtnRemoveTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveTask.Click
        If dgvTasks.SelectedRows.Count = 1 Then
            LogUtil.Debug("Deleting task", Me.Name)
            Dim oRow As DataGridViewRow = dgvTasks.SelectedRows(0)
            Dim taskName As String = oRow.Cells(Me.taskName.Name).Value
            Dim _taskId As Integer = CInt(oRow.Cells(Me.taskId.Name).Value)
            If MsgBox("Do you want to remove this task?" & vbCrLf & QUOTES & taskName & QUOTES, MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeleteTask(_taskId) = 1 Then
                    ShowStatus(LblStatus, "Task removed OK", Me.Name, True)
                Else
                    ShowStatus(LblStatus, "Task NOT removed", Me.Name, True)
                End If
                FillTaskList(_currentJobId)
            End If
        End If
    End Sub
    Private Sub DgvTasks_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTasks.CellDoubleClick
        If dgvTasks.SelectedRows.Count = 1 Then
            LogUtil.Debug("Updating task", Me.Name)
            Dim oRow As DataGridViewRow = dgvTasks.SelectedRows(0)
            Dim _taskId As Integer = CInt(oRow.Cells(Me.taskId.Name).Value)
            Using _taskForm As New FrmTask

                _taskForm.TheJob = _job
                _taskForm.TaskId = _taskId
                _taskForm.ShowDialog()
            End Using
            ClearJobdetails()
            FillJobDetails()
        End If
    End Sub
    Private Sub DgvProducts_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProducts.CellDoubleClick
        LogUtil.Debug("Maintain products on job", Me.Name)
        Using _jobProductForm As New FrmJobProducts
            _jobProductForm.TheJob = _job
            _jobProductForm.ShowDialog()
        End Using
        FillProductList(_currentJobId)
    End Sub
    Private Sub BtnInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoice.Click
        If _job IsNot Nothing Then
            Dim _invoicePrinter As New InvoicePrinter
            _invoicePrinter.CreateInvoice(_job)
        End If
    End Sub
#End Region
#Region "functions"
    Private Sub FillJobDetails()
        SplitContainer2.Panel2Collapsed = False
        GrpInvoice.Enabled = True
        With _job
            cbCust.SelectedValue = .JobCustomerId
            GetCurrentCustomer()
            txtJobName.Text = .JobName
            chkCompleted.Checked = .IsJobCompleted
            rtbJobNotes.Text = .JobDescription
            cbUser.SelectedValue = .JobUserId
            TxtInvoiceNumber.Text = .JobInvoiceNumber
            TxtJobReference.Text = .JobReference
            TxtPurchaseOrder.Text = .JobPoNumber
            DtpInvoiceDate.Value = If(.JobInvoiceDate, New Date(Now.Year, 1, 1))
            DtpPaymentDue.Value = If(.JobPaymentDue, New Date(Now.Year, 1, 1))
            cbUser.SelectedValue = .JobUserId
        End With
        LogUtil.Debug("Existing job " & CStr(_currentJobId), Me.Name)
        SplitContainer1.Visible = True
        FillTaskList(_currentJobId)
        FillProductList(_currentJobId)
    End Sub
    Private Sub ClearJobdetails()
        cbCust.SelectedIndex = -1
        txtJobName.Text = ""
        chkCompleted.Checked = False
        rtbJobNotes.Text = ""
    End Sub
    Private Sub LoadCustomerList()
        LogUtil.Debug("Finding customers", Me.Name)
        Try
            oCustTa.Fill(oCustListTable)
            cbCust.DataSource = oCustListTable
            cbCust.ValueMember = oCustListTable.customer_idColumn.ColumnName
            cbCust.DisplayMember = oCustListTable.customer_nameColumn.ColumnName
            cbCust.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillTaskList(ByVal pJobId As Integer)
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
    Private Sub FillProductList(ByVal pJobId As Integer)
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
    Private Sub NewJob()
        LogUtil.Debug("New job", Me.Name())
        SplitContainer2.Panel2Collapsed = True
        GrpInvoice.Enabled = False
        ClearJobdetails()
        If _customerId > 0 Then
            cbCust.SelectedValue = _customerId
        End If
        _job = JobBuilder.AJob.StartingWithNothing.Build
        cbUser.SelectedValue = currentUser.UserId
    End Sub
    Private Function Amendjob() As Boolean
        Dim isAmendOk As Boolean
        LogUtil.Debug("Updating job " & CStr(_currentJobId), Me.Name)
        dim _ct as integer = updatejob(_newJob)
        If _ct > 0 Then
            isAmendOk = True
            ShowStatus(LblStatus, "Job updated OK", Me.Name, True)
        Else
            isAmendOk = False
            ShowStatus(LblStatus, "Job NOT updated", Me.Name, True)
        End If
        Return isAmendOk
    End Function
    Private Function CreateJob() As Boolean
        Dim isInsertOk As Boolean
        LogUtil.Debug("Inserting job", Me.Name)
        _currentJobId = InsertJob(_newJob)
        If _currentJobId > 0 Then
            isInsertOk = True
            ShowStatus(LblStatus, "Job " & CStr(_currentJobId) & " Created OK", Me.Name, True)
        Else
            isInsertOk = False
            ShowStatus(LblStatus, "Job NOT created", Me.Name, True)
        End If
        Return isInsertOk
    End Function

#End Region
End Class