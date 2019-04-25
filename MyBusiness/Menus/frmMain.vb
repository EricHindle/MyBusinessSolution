Imports MyBusiness.netwyrksErrorCodes
Imports System.Text

Public Class frmMain

    Private isLoading As Boolean = False
    Private dayOfWeek As Integer = Today.DayOfWeek
    Private dateSectionHeads As String() = New String() {"Overdue", "Today", "Tomorrow", "This Week", "Next Week", "Future"}
    Private dateSectionEnds As Date() = New DateTime() {Today, DateAdd(DateInterval.Day, 1, Today), DateAdd(DateInterval.Day, 2, Today), DateAdd(DateInterval.Day, 8 - dayOfWeek, Today), DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Day, 14 - dayOfWeek, Today)), Date.MaxValue}
    Private dateSection As Integer = 0
    Private oDiaryTa As New netwyrksDataSetTableAdapters.diaryTableAdapter
    Private oDiaryTable As New netwyrksDataSet.diaryDataTable
    Private isShowAll As Boolean = False


    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        MenuStrip1.CanOverflow = True

        Me.Text = GlobalSettings.getStringSetting(GlobalSettings.COMPANY_NAME)
        isLoading = True
        fillCustomerTable()
        fillSupplierTable()
        fillJobTable(-1, mnuShowAllJobs.Checked)
        fillDiaryTable()
        isLoading = False

    End Sub

    Private Sub fillCustomerTable()
        dgvCust.Rows.Clear()
        Dim row1 As DataGridViewRow = dgvCust.Rows(dgvCust.Rows.Add)
        row1.Cells(Me.custId.Name).Value = -1
        Dim oCustTa As New netwyrksDataSetTableAdapters.customerTableAdapter
        Dim oCustTable As New netwyrksDataSet.customerDataTable
        oCustTa.Fill(oCustTable)
        For Each oRow As netwyrksDataSet.customerRow In oCustTable.Rows
            Dim tRow As DataGridViewRow = dgvCust.Rows(dgvCust.Rows.Add)
            tRow.Cells(Me.custId.Name).Value = oRow.customer_id
            tRow.Cells(Me.custName.Name).Value = oRow.customer_name
            tRow.Cells(Me.custPhone.Name).Value = oRow.customer_telephone
            tRow.Cells(Me.custemail.Name).Value = oRow.customer_email
        Next
        oCustTa.Dispose()
        oCustTable.Dispose()
        spCustomer.Panel2Collapsed = True
        dgvCust.ClearSelection()
    End Sub
    Private Sub fillSupplierTable()
        dgvSupp.Rows.Clear()
        Dim row1 As DataGridViewRow = dgvSupp.Rows(dgvSupp.Rows.Add)
        row1.Cells(Me.suppId.Name).Value = -1
        Dim osuppTa As New netwyrksDataSetTableAdapters.supplierTableAdapter
        Dim osuppTable As New netwyrksDataSet.supplierDataTable
        osuppTa.Fill(osuppTable)
        For Each oRow As netwyrksDataSet.supplierRow In osuppTable.Rows
            Dim tRow As DataGridViewRow = dgvSupp.Rows(dgvSupp.Rows.Add)
            tRow.Cells(Me.suppId.Name).Value = oRow.supplier_id
            tRow.Cells(Me.suppName.Name).Value = oRow.supplier_name
            tRow.Cells(Me.suppPhone.Name).Value = oRow.supplier_telephone
            tRow.Cells(Me.suppEmail.Name).Value = oRow.supplier_email
        Next
        osuppTa.Dispose()
        osuppTable.Dispose()
        spSupplier.Panel2Collapsed = True
        dgvSupp.ClearSelection()
    End Sub
    Private Sub fillJobTable(ByVal custId As Integer, ByVal showAllJobs As Boolean)
        dgvJobs.Rows.Clear()
        Dim oJobsTa As New netwyrksDataSetTableAdapters.jobTableAdapter
        Dim oJobsTable As New netwyrksDataSet.jobDataTable
        If custId > 0 Then
            oJobsTa.FillByCust(oJobsTable, custId)
        Else
            oJobsTa.Fill(oJobsTable)
        End If
        For Each oRow As netwyrksDataSet.jobRow In oJobsTable.Rows
            Dim tRow As DataGridViewRow = dgvJobs.Rows(dgvJobs.Rows.Add)
            tRow.Visible = showAllJobs Or (oRow.job_user_id = currentUser.userId)
            tRow.Cells(Me.jobId.Name).Value = oRow.job_id
            tRow.Cells(Me.jobName.Name).Value = oRow.job_name
            tRow.Cells(Me.jobDesc.Name).Value = oRow.job_description.Replace(Chr(10), " ")
            tRow.Cells(Me.jobUser.Name).Value = oRow.job_user_id
            tRow.Cells(Me.jobAssigned.Name).Value = UserBuilder.aUserBuilder.startingWith(oRow.job_user_id).build.user_code
            If oRow.job_completed Then
                tRow.Cells(Me.jobCompleted.Name).Value = "Yes"
            End If
        Next
        oJobsTa.Dispose()
        oJobsTable.Dispose()
        dgvJobs.ClearSelection()
    End Sub
    Private Sub fillDiaryTable()
        If dayOfWeek = 6 Then
            dateSectionHeads = New String() {"Overdue", "Today", "Tomorrow", "Next Week", "Future"}
            dateSectionEnds = New DateTime() {Today, DateAdd(DateInterval.Day, 1, Today), DateAdd(DateInterval.Day, 2, Today), DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Day, 8, Today)), Date.MaxValue}
        End If
        If My.Settings.ShowDiaryBody Then
            spDiary.Panel2Collapsed = False
        Else
            spDiary.Panel2Collapsed = True
        End If
        dgvDiary.Rows.Clear()
        Try
            Dim remCt As Integer = 0
            If isShowAll Then
                remCt = oDiaryTa.Fill(oDiaryTable)
            Else
                remCt = oDiaryTa.FillByUserId(oDiaryTable, currentUser.userId)
            End If
            If remCt > 0 Then
                Dim isFirstRow As Boolean = True
                For Each oRow As netwyrksDataSet.diaryRow In oDiaryTable.Rows
                    Dim r As Integer = 0
                    Dim rRow As DataGridViewRow = Nothing
                    If isFirstRow Then
                        Dim oFirstRow As netwyrksDataSet.diaryRow = oDiaryTable.Rows(0)
                        Dim firstRowdate As Date = oFirstRow.diary_date.Date
                        r = dgvDiary.Rows.Add()
                        rRow = dgvDiary.Rows(r)
                        dateSection = getNextSection(firstRowdate, rRow)
                        isFirstRow = False
                    End If
                    Dim remId As Integer = oRow.diary_id
                    r = dgvDiary.Rows.Add()
                    rRow = dgvDiary.Rows(r)
                    If oRow.diary_date.Date >= dateSectionEnds(dateSection).Date Then
                        dateSection = getNextSection(oRow.diary_date.Date, rRow)
                        dgvDiary.Rows.Add()
                        rRow = dgvDiary.Rows(r + 1)
                    End If
                    Dim isReminder As Boolean = oRow.diary_reminder
                    Dim isComplete As Boolean = oRow.diary_closed
                    Dim isCallBack As Boolean = oRow.diary_callback

                    '   rRow.Cells(Me.dremUserCode.Name).Value = If(oUserList.ContainsKey(oRow.diary_user_id), oUserList(oRow.diary_user_id), "")
                    rRow.Cells(Me.dremHeader.Name).Value = False
                    rRow.Cells(Me.dremId.Name).Value = oRow.diary_id
                    rRow.Cells(Me.dremSubject.Name).Value = oRow.diary_subject
                    rRow.Cells(Me.dremDate.Name).Value = Format(oRow.diary_date, "dd/MM/yyyy")
                    rRow.Cells(Me.dremDate.Name).Style.ForeColor = Color.Gray

                    rRow.Cells(Me.dremCustId.Name).Value = If(oRow.Isdiary_cust_idNull, 0, oRow.diary_cust_id)


                    Dim oRemCell As DataGridViewCell = rRow.Cells(dremRem.Name)
                    oRemCell.Style.Font = New Font("Wingdings", 11)
                    oRemCell.Value = If(isReminder, Chr(185), "")
                    Dim oCompCell As DataGridViewCell = rRow.Cells(dremClosed.Name)
                    oCompCell.Style.Font = New Font("Wingdings", 11)
                    oCompCell.Value = If(isComplete, Chr(254), "")
                    Dim oCallCell As DataGridViewCell = rRow.Cells(dremCallback.Name)
                    oCallCell.Style.Font = New Font("Wingdings", 11)
                    oCallCell.Value = If(isCallBack, Chr(40), "")


                Next
            End If
        Catch ex As Exception
            LogUtil.Exception("Error loading reminders", ex, "loadReminders", getErrorCode(SystemModule.DIARY, ErrorType.TABLE, FailedAction.ERROR_LOADING_RECORDS))
        End Try
        dgvDiary.ClearSelection()

    End Sub

    Private Function getNextSection(ByVal rowDate As Date, ByRef rRow As DataGridViewRow) As Integer
        Dim sectionNo As Integer = dateSectionHeads.GetUpperBound(0)
        For x = 0 To dateSectionHeads.GetUpperBound(0)
            If rowDate < dateSectionEnds(x).Date Then
                sectionNo = x
                Exit For
            End If
        Next
        rRow.Cells(Me.dremDate.Name).Value = dateSectionHeads(sectionNo)
        rRow.Cells(Me.dremDate.Name).Style.ForeColor = Color.Black
        rRow.Cells(Me.dremHeader.Name).Value = True
        For Each oCell As DataGridViewCell In rRow.Cells
            oCell.Style.BackColor = Color.Silver
        Next
        Return sectionNo
    End Function

    Private Sub dgvCust_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgvCust.SelectionChanged
        spCustomer.Panel2Collapsed = True
        If Not isLoading Then
            If dgvCust.SelectedRows.Count = 1 Then
                Dim cRow As DataGridViewRow = dgvCust.SelectedRows(0)
                Dim _selCustId As Integer = cRow.Cells(Me.custId.Name).Value
                If _selCustId > 0 Then
                    Dim _selectedCust As Customer = CustomerBuilder.aCustomer.startingWith(_selCustId).build
                    fillJobTable(_selectedCust.customerId, mnuShowAllJobs.Checked)
                    txtCustAddress.Text = _selectedCust.custName & vbCrLf & multilineAddressString(_selectedCust.address)

                    If My.Settings.ShowCustomer Then spCustomer.Panel2Collapsed = False
                    fillJobTable(_selCustId, mnuShowAllJobs.Checked)
                Else
                    fillJobTable(-1, mnuShowAllJobs.Checked)
                End If

            End If
        End If
    End Sub

    Private Function multilineAddressString(ByVal anAddress As Address) As String
        Dim sb As New StringBuilder
        With anAddress

            If .address1 IsNot Nothing AndAlso .address1.Trim.Length > 0 Then
                sb.Append(.address1.Trim).Append(vbCrLf)
            End If
            If .address2 IsNot Nothing AndAlso .address2.Trim.Length > 0 Then
                sb.Append(.address2.Trim).Append(vbCrLf)
            End If
            If .address3 IsNot Nothing AndAlso .address3.Trim.Length > 0 Then
                sb.Append(.address3.Trim).Append(vbCrLf)
            End If
            If .address4 IsNot Nothing AndAlso .address4.Trim.Length > 0 Then
                sb.Append(.address4.Trim).Append(vbCrLf)
            End If
            If .postcode IsNot Nothing AndAlso .postcode.Trim.Length > 0 Then
                sb.Append(.postcode.Trim).Append(vbCrLf)
            End If

        End With
        Return sb.ToString
    End Function


    Private Sub dgvDiary_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgvDiary.SelectionChanged
        If Not isLoading Then
            If dgvDiary.SelectedRows.Count = 1 Then
                Dim dRow As DataGridViewRow = dgvDiary.SelectedRows(0)
                Dim _diaryId As Integer = dRow.Cells(Me.dremId.Name).Value
                Dim _reminder As Reminder = ReminderBuilder.aReminder.startingWith(_diaryId).build
                rtbDiaryBody.Text = _reminder.body

            End If
        End If
    End Sub

    Private Sub dgvDiary_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvDiary.CellDoubleClick
        If dgvDiary.SelectedRows.Count = 1 Then
            Dim dRow As DataGridViewRow = dgvDiary.SelectedRows(0)
            Dim _diaryId As Integer = dRow.Cells(Me.dremId.Name).Value
            Dim _reminder As Reminder = ReminderBuilder.aReminder.startingWith(_diaryId).build
            Using _diary As New frmReminder
                _diary.theReminder = _reminder
                _diary.isReminder = _reminder.isReminder
                _diary.ShowDialog()
            End Using
            isLoading = True
            fillDiaryTable()
            isLoading = False

        End If
    End Sub



    Private Sub dgvCust_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvCust.CellDoubleClick
        If dgvCust.SelectedRows.Count = 1 Then
            Dim dRow As DataGridViewRow = dgvCust.SelectedRows(0)
            Dim _custId As Integer = dRow.Cells(Me.custId.Name).Value
            Using _custForm As New frmCustomerMaint
                _custForm.customerId = _custId
                _custForm.ShowDialog()
            End Using
            isLoading = True
            fillCustomerTable()
            isLoading = False

        End If
    End Sub

    Private Sub dgvSupp_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvSupp.CellDoubleClick
        If dgvSupp.SelectedRows.Count = 1 Then
            Dim dRow As DataGridViewRow = dgvSupp.SelectedRows(0)
            Dim _suppId As Integer = dRow.Cells(Me.suppId.Name).Value
            Using _suppForm As New frmSupplier
                _suppForm.supplierId = _suppId
                _suppForm.ShowDialog()
            End Using
            isLoading = True
            fillSupplierTable()
            isLoading = False

        End If
    End Sub

    Private Sub dgvJobs_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvJobs.CellDoubleClick
        If dgvJobs.SelectedRows.Count = 1 Then
            Dim dRow As DataGridViewRow = dgvJobs.SelectedRows(0)
            Dim _jobId As Integer = dRow.Cells(Me.jobId.Name).Value
            Using _jobForm As New frmJob
                _jobForm.theJob = jobBuilder.aJobBuilder.startingWith(_jobId)
                _jobForm.customerId = _jobForm.theJob.build.jobCustomerId
                _jobForm.ShowDialog()
            End Using
            isLoading = True
            dgvCust.ClearSelection()
            fillJobTable(-1, mnuShowAllJobs.Checked)
            isLoading = False

        End If
    End Sub

    Private Sub dgvSupp_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgvSupp.SelectionChanged
        spSupplier.Panel2Collapsed = True
        If Not isLoading Then
            If dgvSupp.SelectedRows.Count = 1 Then
                Dim sRow As DataGridViewRow = dgvSupp.SelectedRows(0)
                Dim _selSuppId As Integer = sRow.Cells(Me.suppId.Name).Value
                If _selSuppId > 0 Then
                    Dim _selectedSupp As Supplier = SupplierBuilder.aSupplierBuilder.startingWith(_selSuppId).build
                    txtSuppAddress.Text = _selectedSupp.supplierName & vbCrLf & multilineAddressString(_selectedSupp.supplierAddress)
                    If My.Settings.ShowSupplier Then spSupplier.Panel2Collapsed = False
                End If
            End If
        End If
    End Sub

    Private Sub NewCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewCustomerToolStripMenuItem.Click
        Using _custForm As New frmCustomerMaint
            _custForm.ShowDialog()
        End Using
        isLoading = True
        fillCustomerTable()
        isLoading = False
    End Sub

    Private Sub NewSupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewSupplierToolStripMenuItem.Click
        Using _suppForm As New frmSupplier
            _suppForm.ShowDialog()
        End Using
        isLoading = True
        fillSupplierTable()
        isLoading = False
    End Sub

    Private Sub NewDiaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewDiaryToolStripMenuItem.Click
        Using _diary As New frmReminder
            _diary.ShowDialog()
            _diary.isReminder = False
        End Using
        isLoading = True
        fillDiaryTable()
        isLoading = False
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub PreferencesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreferencesToolStripMenuItem.Click
        Using _settings As New frmOptions
            _settings.ShowDialog()
        End Using
        If My.Settings.ShowDiaryBody Then
            spDiary.Panel2Collapsed = False
        Else
            spDiary.Panel2Collapsed = True
        End If
    End Sub

    Private Sub GlobalSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlobalSettingsToolStripMenuItem.Click
        Using _global As New frmGlobalSettings
            _global.ShowDialog()
        End Using
    End Sub

    Private Sub UserControlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserControlToolStripMenuItem.Click
        Using _userControl As New frmUserControl
            _userControl.ShowDialog()
        End Using
    End Sub

    Private Sub TidyFilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TidyFilesToolStripMenuItem.Click

    End Sub

    Private Sub mnuAddANewJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddANewJob.Click
        Using _jobForm As New frmJob
            _jobForm.customerId = -1
            _jobForm.ShowDialog()
        End Using
        isLoading = True
        fillJobTable(-1, mnuShowAllJobs.Checked)
        isLoading = False
    End Sub

    Private Sub mnuShowAllJobs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAllJobs.Click
        Dim _selCustId As Integer = -1
        If dgvCust.SelectedRows.Count = 1 Then
            _selCustId = dgvCust.SelectedRows(0).Cells(Me.custId.Name).Value
        End If
        fillJobTable(_selCustId, mnuShowAllJobs.Checked)

    End Sub
End Class