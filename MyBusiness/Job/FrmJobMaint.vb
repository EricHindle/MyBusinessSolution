﻿' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

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
    Private _currentJobProduct As JobProduct
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
        LogUtil.Debug("Closing", Name)
        My.Settings.JobMaintFormPos = SetFormPos(Me)
        My.Settings.Save()
        oCustTa.Dispose()
        oCustListTable.Dispose()
        oUserTa.Dispose()
        oUserTable.Dispose()
    End Sub
    Private Sub FrmJob_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Started", Name)
        GetFormPos(Me, My.Settings.JobMaintFormPos)
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

        If _currentCust.Terms = 0 Then
            LblTerms.Text = "Immediate"
        Else
            LblTerms.Text = _currentCust.Terms & " days"
        End If

        SpellCheckUtil.EnableSpellChecking({rtbJobNotes})
        isLoading = False
    End Sub
    Private Sub BtnViewCust_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnViewCust.Click
        LogUtil.Debug("View customer " & CStr(cbCust.SelectedValue), Name)
        Using _custForm As New FrmViewCust
            _custForm.TheCustomer = _currentCust
            _custForm.ShowDialog()
        End Using
    End Sub
    Private Sub BtnAddTask_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddTask.Click
        LogUtil.Debug("Add task to job", Name)
        Using _taskForm As New FrmTask
            _taskForm.TheJob = _job
            _taskForm.ShowDialog()
        End Using
        FillTaskList(_currentJobId)
    End Sub
    Private Sub BtnMaintProduct_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMaintProducts.Click
        LogUtil.Debug("Maintain products on job", Name)
        Using _jobProductForm As New FrmJobProducts
            _jobProductForm.TheJob = _job
            _jobProductForm.SelectedJobProduct = Nothing
            _jobProductForm.ShowDialog()
        End Using
        FillProductList(_currentJobId)
    End Sub
    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Close()
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
        Close()
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
            LogUtil.Debug("Deleting task", Name)
            Dim oRow As DataGridViewRow = dgvTasks.SelectedRows(0)
            Dim taskName As String = oRow.Cells(Me.taskName.Name).Value
            Dim _taskId As Integer = oRow.Cells(taskId.Name).Value
            If Global.Microsoft.VisualBasic.Interaction.MsgBox("Do you want to remove this task?" & Global.Microsoft.VisualBasic.Constants.vbCrLf & Global.MyBusiness.netwyrksConstants.QUOTES & taskName & Global.MyBusiness.netwyrksConstants.QUOTES, Global.Microsoft.VisualBasic.MsgBoxStyle.Question Or Global.Microsoft.VisualBasic.MsgBoxStyle.YesNo, "Confirm") = Global.Microsoft.VisualBasic.MsgBoxResult.Yes Then
                If DeleteTask(_taskId) = 1 Then
                    ShowStatus(LblStatus, "Task removed OK", Name, True)
                Else
                    ShowStatus(LblStatus, "Task NOT removed", Name, True)
                End If
                FillTaskList(_currentJobId)
            End If
        End If
    End Sub
    Private Sub DgvTasks_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTasks.CellDoubleClick
        If dgvTasks.SelectedRows.Count = 1 Then
            LogUtil.Debug("Updating task", Name)
            Dim oRow As DataGridViewRow = dgvTasks.SelectedRows(0)
            Dim _taskId As Integer = oRow.Cells(taskId.Name).Value
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
        LogUtil.Debug("Maintain products on job", Name)
        Dim _jpId As Integer = dgvProducts.Rows(e.RowIndex).Cells(jpId.Name).Value
        _currentJobProduct = JobProductBuilder.AJobProduct.StartingWith(_jpId).Build
        Using _jobProductForm As New FrmJobProducts
            _jobProductForm.TheJob = _job
            _jobProductForm.SelectedJobProduct = _currentJobProduct
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
        LogUtil.Debug("Existing job " & _currentJobId, Name)
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
        LogUtil.Debug("Finding customers", Name)
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
        LogUtil.Debug("Finding tasks", Name)
        oTaskTa.FillByJob(oTaskTable, pJobId)
        For Each oRow As netwyrksDataSet.taskRow In oTaskTable.Rows
            Dim tRow As DataGridViewRow = dgvTasks.Rows(dgvTasks.Rows.Add)
            tRow.Cells(taskId.Name).Value = oRow.task_id
            tRow.Cells(taskName.Name).Value = oRow.task_name
            Dim _startDue As String = If(oRow.Istask_start_dueNull, "", Format(oRow.task_start_due, "dd/MM/yyyy"))
            tRow.Cells(taskStartDue.Name).Value = _startDue
            tRow.Cells(taskHours.Name).Value = oRow.task_time
            tRow.Cells(taskStarted.Name).Value = CStr(oRow.task_started)
            tRow.Cells(taskCompleted.Name).Value = CStr(oRow.task_completed)
            tRow.Cells(taskPrice.Name).Value = oRow.task_cost
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
        LogUtil.Debug("Finding products", Name)
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
            tRow.Cells(prodSupp.Name).Value = _supplierName
            tRow.Cells(prodName.Name).Value = _productName
            tRow.Cells(prodId.Name).Value = _productId
            tRow.Cells(jpId.Name).Value = _jpId
            tRow.Cells(prodQty.Name).Value = _qty
            tRow.Cells(prodCost.Name).Value = _cost
            tRow.Cells(prodPrice.Name).Value = _price
            tRow.Cells(jobPrice.Name).Value = oRow.jp_price
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
        LogUtil.Debug("New job", Name())
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
        LogUtil.Debug("Updating job " & _currentJobId, Name)
        Dim _ct As Integer = UpdateJob(_newJob)
        If _ct > 0 Then
            isAmendOk = True
            ShowStatus(LblStatus, "Job updated OK", Name, True)
        Else
            isAmendOk = False
            ShowStatus(LblStatus, "Job NOT updated", Name, True)
        End If
        Return isAmendOk
    End Function
    Private Function CreateJob() As Boolean
        Dim isInsertOk As Boolean
        LogUtil.Debug("Inserting job", Name)
        _currentJobId = InsertJob(_newJob)
        If _currentJobId > 0 Then
            isInsertOk = True
            ShowStatus(LblStatus, "Job " & _currentJobId & " Created OK", Name, True)
        Else
            isInsertOk = False
            ShowStatus(LblStatus, "Job NOT created", Name, True)
        End If
        Return isInsertOk
    End Function

    Private Sub PicDiary_Click(sender As Object, e As EventArgs) Handles picDiary.Click
        ShowDiary()
    End Sub
    Private Sub ShowDiary()
        Using _diary As New FrmDiary
            _diary.ForJobId = _currentJobId
            _diary.ShowDialog()
        End Using
    End Sub

    Private Sub dgvProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProducts.SelectionChanged
        If dgvProducts.SelectedRows.Count > 0 Then
            Dim _row As DataGridViewRow = dgvProducts.SelectedRows(0)
            Dim _id As Integer = _row.Cells(jpId.Name).Value
            _currentJobProduct = JobProductBuilder.AJobProduct.StartingWith(_id).Build
        Else
            _currentJobProduct = JobProductBuilder.AJobProduct.StartingWithNothing.Build
        End If
    End Sub

#End Region
End Class