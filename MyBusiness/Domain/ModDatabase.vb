Imports System.IO

Module ModDatabase
#Region "constants"
    Private Const MODULE_NAME As String = "DataFunctions"
#End Region
#Region "adapters"
    Private ReadOnly oUserTa As New netwyrksDataSetTableAdapters.userTableAdapter
    Private ReadOnly oUserTable As New netwyrksDataSet.userDataTable
    Private ReadOnly oAuditTa As New netwyrksDataSetTableAdapters.auditTableAdapter
    Private ReadOnly oAuditTable As New netwyrksDataSet.auditDataTable
    Private ReadOnly oConfigurationTa As New netwyrksDataSetTableAdapters.configurationTableAdapter
    Private ReadOnly oConfigurationTable As New netwyrksDataSet.configurationDataTable
    Private ReadOnly oCustomerTa As New netwyrksDataSetTableAdapters.customerTableAdapter
    Private ReadOnly oCustomerTable As New netwyrksDataSet.customerDataTable
    Private ReadOnly oJobTa As New netwyrksDataSetTableAdapters.jobTableAdapter
    Private ReadOnly oJobTable As New netwyrksDataSet.jobDataTable
    Private ReadOnly oJobProductTa As New netwyrksDataSetTableAdapters.job_productTableAdapter
    Private ReadOnly oJobProductTable As New netwyrksDataSet.job_productDataTable
    Private ReadOnly oProductTa As New netwyrksDataSetTableAdapters.productTableAdapter
    Private ReadOnly oProductTable As New netwyrksDataSet.productDataTable
    Private ReadOnly oTaskTa As New netwyrksDataSetTableAdapters.taskTableAdapter
    Private ReadOnly oTaskTable As New netwyrksDataSet.taskDataTable
    Private ReadOnly oDiaryTa As New netwyrksDataSetTableAdapters.diaryTableAdapter
    Private ReadOnly oDiaryTable As New netwyrksDataSet.diaryDataTable
    Private ReadOnly oSupplierTa As New netwyrksDataSetTableAdapters.supplierTableAdapter
    Private ReadOnly oSupplierTable As New netwyrksDataSet.supplierDataTable
#End Region
#Region "variables"
    Public tableList As New List(Of String)
#End Region
#Region "users"
    Public Function GetUserById(_id As Integer) As User
        Dim _user As User = UserBuilder.AUser.StartingWithNothing.Build
        oUserTa.FillById(oUserTable, _id)
        If oUserTable.Rows.Count > 0 Then
            _user = UserBuilder.AUser.StartingWith(oUserTable.Rows(0)).Build
        End If
        Return _user
    End Function
    Public Function GetUserByLogin(_login As String) As User
        Dim _user As User = UserBuilder.AUser.StartingWithNothing.Build
        oUserTa.FillByLogin(oUserTable, _login)
        If oUserTable.Rows.Count > 0 Then
            _user = UserBuilder.AUser.StartingWith(oUserTable.Rows(0)).Build
        End If
        Return _user
    End Function
    Public Function InsertUser(_user As User, _password As String) As Integer
        Dim newUserId As Integer = oUserTa.InsertUser(_user.User_login, _user.User_code,
                                                   AuthenticationUtil.GetHashed(_user.Salt & _password), _user.TempPassword, True,
                                                   _user.Salt,
                                                   _user.UserName, _user.ContactNumber, _user.Mobile, _user.Email, _user.JobTitle, _user.Note, Now, _user.UserRole)
        Return newUserId
    End Function
    Public Function UpdateUser(_user As User) As Integer
        Dim _forceChange As Integer = If(_user.ForcePasswordChange, 1, 0)
        Return oUserTa.UpdateUser(_user.User_code, _user.Password, _user.TempPassword,
                           _forceChange, _user.Salt, _user.UserName,
                           _user.ContactNumber, _user.Mobile, _user.Email,
                           _user.JobTitle, _user.Note, Now, _user.UserRole, _user.UserId)
    End Function
    Public Function GetAllUsers() As List(Of User)
        Dim _userList As New List(Of User)
        oUserTa.Fill(oUserTable)
        For Each oRow As netwyrksDataSet.userRow In oUserTable.Rows
            _userList.Add(UserBuilder.AUser.StartingWith(oRow).Build)
        Next
        Return _userList
    End Function


#End Region
#Region "job"
    Public Function GetJobById(ByVal pId As Integer) As Job
        Dim _job As Job = JobBuilder.AJob.StartingWithNothing.Build
        oJobTa.FillById(oJobTable, pId)
        If oJobTable.Rows.Count > 0 Then
            _job = JobBuilder.AJob.StartingWith(oJobTable.Rows(0)).Build
        End If
        Return _job
    End Function
    Public Function GetAllJobs() As List(Of Job)
        Dim _jobList As New List(Of Job)
        oJobTa.Fill(oJobTable)
        For Each oRow As netwyrksDataSet.jobRow In oJobTable.Rows
            _jobList.Add(JobBuilder.AJob.StartingWith(oRow).Build)
        Next
        Return _jobList
    End Function
    Public Function GetJobsForCustomer(ByVal pCustomerId As Integer) As List(Of Job)
        Dim _jobList As New List(Of Job)
        oJobTa.FillByCust(oJobTable, pCustomerId)
        For Each oRow As netwyrksDataSet.jobRow In oJobTable.Rows
            _jobList.Add(JobBuilder.AJob.StartingWith(oRow).Build)
        Next
        Return _jobList
    End Function
#End Region
#Region "product"
    Public Function GetProductById(ByVal pId As Integer) As Product
        Dim _product As Product = ProductBuilder.AProduct.StartingWithNothing.Build
        oProductTa.FillById(oProductTable, pId)
        If oProductTable.Rows.Count > 0 Then
            _product = ProductBuilder.AProduct.StartingWith(oProductTable.Rows(0)).Build
        End If
        Return _product
    End Function
#End Region
#Region "customer"
    Public Function GetCustomers() As List(Of Customer)
        Dim _customerList As New List(Of Customer)
        oCustomerTa.Fill(oCustomerTable)
        For Each oRow As netwyrksDataSet.customerRow In oCustomerTable.Rows
            _customerList.Add(CustomerBuilder.ACustomer.StartingWith(oRow).Build)
        Next
        Return _customerList
    End Function
#End Region
#Region "supplier"
    Public Function GetSuppliers() As List(Of Supplier)
        Dim _supplierList As New List(Of Supplier)
        oSupplierTa.Fill(oSupplierTable)
        For Each oRow As netwyrksDataSet.supplierRow In oSupplierTable.Rows
            _supplierList.Add(SupplierBuilder.ASupplier.StartingWith(oRow).Build)
        Next
        Return _supplierList
    End Function
#End Region
#Region "diary"
    Public Function GetAllReminders() As List(Of Reminder)
        Dim _remList As New List(Of Reminder)
        oDiaryTa.Fill(oDiaryTable)
        For Each oRow As netwyrksDataSet.diaryRow In oDiaryTable.Rows
            _remList.Add(ReminderBuilder.AReminder.StartingWith(oRow).Build)
        Next
        Return _remList
    End Function
    Public Function GetRemindersForUser(ByVal pUserId As Integer) As List(Of Reminder)
        Dim _remList As New List(Of Reminder)
        oDiaryTa.FillByUserId(oDiaryTable, pUserId)
        For Each oRow As netwyrksDataSet.diaryRow In oDiaryTable.Rows
            _remList.Add(ReminderBuilder.AReminder.StartingWith(oRow).Build)
        Next
        Return _remList
    End Function
#End Region
#Region "common"
    Public Sub InitialiseData()
        LogUtil.Info("Initialising data", MODULE_NAME)
        tableList.Add("Audit")
        tableList.Add("Configuration")
        tableList.Add("Customer")
        tableList.Add("Diary")
        tableList.Add("Job")
        tableList.Add("Job_Product")
        tableList.Add("Product")
        tableList.Add("Supplier")
        tableList.Add("Task")
        tableList.Add("User")
    End Sub
    Public Sub FillTableTree(ByRef tvtables As TreeView)
        tvtables.Nodes.Clear()
        tvtables.Nodes.Add("Tables")
        For Each oTable As String In tableList
            tvtables.Nodes(0).Nodes.Add(oTable)
        Next
    End Sub
    Public Function RestoreDataTable(tableType As String, datapath As String) As Integer
        Dim rowCount As Integer = 0
        Try
            Select Case tableType
                Case "Audit"
                    If RecreateTable(oAuditTable, datapath) Then
                        oAuditTa.TruncateAudit()
                        oAuditTa.Update(oAuditTable)
                        rowCount = oAuditTa.GetData().Rows.Count
                    End If
                Case "Users"
                    If RecreateTable(oUserTable, datapath) Then
                        oUserTa.TruncateUsers()
                        oUserTa.Update(oUserTable)
                        rowCount = oUserTa.GetData.Rows.Count
                    End If
                Case "Configuration"
                    If RecreateTable(oConfigurationTable, datapath) Then
                        oConfigurationTa.TruncateConfiguration()
                        oConfigurationTa.Update(oConfigurationTable)
                        rowCount = oConfigurationTa.GetData.Rows.Count
                    End If
                Case "Customer"
                    If RecreateTable(oCustomerTable, datapath) Then
                        oCustomerTa.TruncateCustomers()
                        oCustomerTa.Update(oCustomerTable)
                        rowCount = oCustomerTa.GetData.Rows.Count
                    End If
                Case "Diary"
                    If RecreateTable(oDiaryTable, datapath) Then
                        oDiaryTa.TruncateDiary()
                        oDiaryTa.Update(oDiaryTable)
                        rowCount = oDiaryTa.GetData.Rows.Count
                    End If
                Case "Job"
                    If RecreateTable(oJobTable, datapath) Then
                        oJobTa.TruncateJobs()
                        oJobTa.Update(oJobTable)
                        rowCount = oJobTa.GetData.Rows.Count
                    End If
                Case "Job_Product"
                    If RecreateTable(oJobProductTable, datapath) Then
                        oJobProductTa.TruncateJobProduct()
                        oJobProductTa.Update(oJobProductTable)
                        rowCount = oJobProductTa.GetData.Rows.Count
                    End If
                Case "Product"
                    If RecreateTable(oProductTable, datapath) Then
                        oProductTa.TruncateProducts()
                        oProductTa.Update(oProductTable)
                        rowCount = oProductTa.GetData.Rows.Count
                    End If
                Case "Supplier"
                    If RecreateTable(oSupplierTable, datapath) Then
                        oSupplierTa.TruncateSuppliers()
                        oSupplierTa.Update(oSupplierTable)
                        rowCount = oSupplierTa.GetData.Rows.Count
                    End If
                Case "Task"
                    If RecreateTable(oTaskTable, datapath) Then
                        oTaskTa.TruncateTasks()
                        oTaskTa.Update(oTaskTable)
                        rowCount = oTaskTa.GetData.Rows.Count
                    End If
            End Select
        Catch ex As Exception
            MsgBox(GetMessage(ex), MsgBoxStyle.Exclamation, "Error")
        End Try
        Return rowCount
    End Function
    Private Function RecreateTable(ByRef restoredDataTable As DataTable, datapath As String) As Boolean
        Dim isTableOK As Boolean = False
        Dim sTableName As String = restoredDataTable.TableName
        Dim sBackupFile As String = Path.Combine(datapath, sTableName & ".xml")
        If My.Computer.FileSystem.FileExists(sBackupFile) Then
            Try
                restoredDataTable.Clear()
                restoredDataTable.ReadXml(sBackupFile)
                Dim rowCount As Integer = restoredDataTable.Rows.Count
                If MsgBox(CStr(rowCount) & " records recovered. OK to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Continue") = MsgBoxResult.Yes Then
                    isTableOK = True
                End If
            Catch ex As Exception
                MsgBox(GetMessage(ex), MsgBoxStyle.Exclamation, "Error")
            End Try
        End If
        Return isTableOK
    End Function

    Private Function GetMessage(ex As Exception) As String
        Return If(ex Is Nothing, "", "Exception:  " & ex.Message & vbCrLf & If(ex.InnerException Is Nothing, "", ex.InnerException.Message))
    End Function

#End Region
#Region "getdata"
    Public Function GetAuditTable() As netwyrksDataSet.auditDataTable
        LogUtil.Info("Getting Audit table", MODULE_NAME)
        Return oAuditTa.GetData()
    End Function
    Public Function GetConfigurationTable() As netwyrksDataSet.configurationDataTable
        LogUtil.Info("Getting Configuration table", MODULE_NAME)
        Return oConfigurationTa.GetData()
    End Function
    Public Function GetCustomerTable() As netwyrksDataSet.customerDataTable
        LogUtil.Info("Getting Customer table", MODULE_NAME)
        Return oCustomerTa.GetData()
    End Function
    Public Function GetJobTable() As netwyrksDataSet.jobDataTable
        LogUtil.Info("Getting Job table", MODULE_NAME)
        Return oJobTa.GetData()
    End Function
    Public Function GetJob_ProductTable() As netwyrksDataSet.job_productDataTable
        LogUtil.Info("Getting Job_Product table", MODULE_NAME)
        Return oJobProductTa.GetData()
    End Function
    Public Function GetProductTable() As netwyrksDataSet.productDataTable
        LogUtil.Info("Getting Product table", MODULE_NAME)
        Return oProductTa.GetData()
    End Function
    Public Function GetTaskTable() As netwyrksDataSet.taskDataTable
        LogUtil.Info("Getting Task table", MODULE_NAME)
        Return oTaskTa.GetData()
    End Function
    Public Function GetUserTable() As netwyrksDataSet.userDataTable
        LogUtil.Info("Getting User table", MODULE_NAME)
        Return oUserTa.GetData()
    End Function
    Public Function GetDiaryTable() As netwyrksDataSet.diaryDataTable
        LogUtil.Info("Getting Diary table", MODULE_NAME)
        Return oDiaryTa.GetData()
    End Function
    Public Function GetSupplierTable() As netwyrksDataSet.supplierDataTable
        LogUtil.Info("Getting Supplier table", MODULE_NAME)
        Return oSupplierTa.GetData()
    End Function
#End Region
End Module
