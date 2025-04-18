﻿' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Domain.Objects
Imports HindlewareLib.Logging

Public Class FrmCustomerMaint
#Region "variables"
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
    Private _isView As Boolean
    Public Property IsView() As Boolean
        Get
            Return _isView
        End Get
        Set(ByVal value As Boolean)
            _isView = value
        End Set
    End Property
#End Region
#Region "form handlers"
    Private Sub FrmCustomerMaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.LogInfo("Started", Name)
        If GetFormPos(Me, My.Settings.CustFormPos) Then
            ScCustomer.SplitterDistance = CInt("0" & My.Settings.CustSplitterDist1)
        End If
        isLoading = True
        ScCustomer.Panel2Collapsed = True
        KeyPreview = True
        If _customerId <= 0 Then
            NewCustomer()
        Else
            _currentCustomer = GetCustomer(_customerId)
            FillCustomerDetails()
            ScCustomer.Enabled = Not IsView
            LblAction.Visible = Not IsView
        End If
        SpellCheckUtil.EnableSpellChecking({rtbCustNotes})
        isLoading = False
    End Sub
    Private Sub FrmCustomerMaint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", Name)
        My.Settings.CustFormPos = SetFormPos(Me)
        My.Settings.CustSplitterDist1 = ScCustomer.SplitterDistance
        My.Settings.Save()
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            ShowDiary()
        End If
    End Sub
    Private Sub DgvJobs_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DgvJobs.CellDoubleClick
        If DgvJobs.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = DgvJobs.SelectedRows(0)
            Dim _JobId As Integer = oRow.Cells(jobId.Name).Value
            LogUtil.LogInfo("Updating job " & _JobId, Name)
            Using _jobForm As New FrmJobMaint
                _jobForm.TheJob = GetJobById(_JobId)
                _jobForm.CustomerId = _customerId
                _jobForm.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub ChkCompleted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCompleted.CheckedChanged
        isLoading = True
        FillJobsList(_customerId)
        isLoading = False
    End Sub
    Private Sub PicDiary_Click(sender As Object, e As EventArgs) Handles picDiary.Click
        ShowDiary()
    End Sub
    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        Close()
    End Sub
    Private Sub PicUpdate_Click(sender As Object, e As EventArgs) Handles PicUpdate.Click
        LogUtil.LogInfo("Updating", Name)
        Dim _custAdd As Address = AddressBuilder.AnAddress.WithAddress1(txtCustAddr1.Text.Trim) _
                                                .WithAddress2(txtCustAddr2.Text.Trim) _
                                                .WithAddress3(txtCustAddr3.Text.Trim) _
                                                .WithAddress4(txtCustAddr4.Text.Trim) _
                                                .WithPostcode(txtCustPostcode.Text.Trim.ToUpper).Build
        With _currentCustomer
            _newCustomer = CustomerBuilder.ACustomer.WithCustId(.CustomerId) _
                .WithAddress(_custAdd) _
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
            If CreateCustomer() Then
                LblAction.Text = "Added the new customer"
            End If
        End If
    End Sub
    Private Sub PicAddJob_Click(sender As Object, e As EventArgs) Handles PicAddJob.Click
        LogUtil.LogInfo("Adding job", Name)
        Using _jobForm As New FrmJobMaint
            _jobForm.TheJob = Nothing
            _jobForm.CustomerId = _customerId
            _jobForm.ShowDialog()
            FillJobsList(_customerId)
        End Using
    End Sub
#End Region
#Region "functions"
    Private Sub FillCustomerDetails()
        LblAction.Text = "Updating a customer"
        Dim _custId As Integer = 0
        With _currentCustomer
            LblCustNo.Text = CStr(_currentCustomer.CustomerId)
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
        ScCustomer.Panel2Collapsed = False
        LogUtil.LogInfo("Existing customer " & _custId, Name)
        FillJobsList(_custId)
    End Sub
    Private Function CreateCustomer() As Boolean
        Dim isInsertOK As Boolean
        _customerId = InsertCustomer(_newCustomer)
        If _customerId > 0 Then
            AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Customer, _customerId, AuditUtil.AuditableAction.create, "", _newCustomer.ToString)
            isInsertOK = True
            LogUtil.ShowStatus("Customer " & _customerId & " created OK", lblStatus, True, Name,  False)
        Else
            isInsertOK = False
            LogUtil.ShowStatus("Customer NOT created", lblStatus, True, Name, False)
        End If
        Return isInsertOK
    End Function
    Private Function AmendCustomer() As Boolean
        Dim isAmendOK As Boolean = False
        PicUpdate.Image = My.Resources.update_database
        ToolTip1.SetToolTip(PicUpdate, "Update the customer")
        With _newCustomer
            If UpdateCustomer(_newCustomer) = 1 Then
                AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Customer, _customerId, AuditUtil.AuditableAction.update, _currentCustomer.ToString, .ToString)
                isAmendOK = True
                LogUtil.ShowStatus("Customer " & _customerId & " updated OK", lblStatus, True, Name, False)
            Else
                isAmendOK = False
                LogUtil.ShowStatus("Customer NOT updated", lblStatus, True, Name, False)
            End If
        End With
        Return isAmendOK
    End Function
    Private Sub NewCustomer()
        LogUtil.LogInfo("New customer", Name)
        LblAction.Text = "Adding a new customer"
        PicUpdate.Image = My.Resources.add_database
        ToolTip1.SetToolTip(PicUpdate, "Add a new customer")
        _currentCustomer = CustomerBuilder.ACustomer.StartingWithNothing.Build
        ClearCustomerDetails()
        ScCustomer.Panel2Collapsed = True
        DgvJobs.Rows.Clear()
    End Sub
    Private Sub ClearCustomerDetails()
        LblCustNo.Text = -1
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
        LogUtil.LogInfo("Finding jobs", MyBase.Name)
        Dim oJobList As List(Of Job) = GetJobsForCustomer(custId)
        For Each oJob As Job In oJobList
            Dim tRow As DataGridViewRow = DgvJobs.Rows(DgvJobs.Rows.Add)
            If oJob.IsJobCompleted Then
                tRow.Visible = ChkCompleted.Checked
            End If
            tRow.Cells(jobId.Name).Value = oJob.JobId
            tRow.Cells(jobName.Name).Value = oJob.JobName
            tRow.Cells(jobCompleted.Name).Value = If(oJob.IsJobCompleted, "Yes", "")
        Next
        DgvJobs.ClearSelection()
    End Sub
    Private Sub ShowDiary()
        Using _diary As New FrmDiary
            _diary.ForCustomerId = _customerId
            If DgvJobs.SelectedRows.Count = 1 Then
                _diary.ForJobId = DgvJobs.SelectedRows(0).Cells(jobId.Name).Value
            End If
            _diary.ShowDialog()
        End Using
    End Sub

#End Region
End Class