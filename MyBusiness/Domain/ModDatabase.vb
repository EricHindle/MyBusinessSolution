' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.Common
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
    Private ReadOnly oJobProductViewTa As New netwyrksDataSetTableAdapters.v_jobproductTableAdapter
    Private ReadOnly oJobProductViewTable As New netwyrksDataSet.v_jobproductDataTable
    Private ReadOnly oJobImageTa As New netwyrksDataSetTableAdapters.job_imageTableAdapter
    Private ReadOnly oJobImageTable As New netwyrksDataSet.job_imageDataTable
    Private ReadOnly oTemplateTa As New netwyrksDataSetTableAdapters.templateTableAdapter
    Private ReadOnly oTemplateTable As New netwyrksDataSet.templateDataTable
    Private ReadOnly oTemplateTaskTa As New netwyrksDataSetTableAdapters.template_taskTableAdapter
    Private ReadOnly oTemplateTaskTable As New netwyrksDataSet.template_taskDataTable
    Private ReadOnly oTemplateProductTa As New netwyrksDataSetTableAdapters.template_productTableAdapter
    Private ReadOnly oTemplateProductTable As New netwyrksDataSet.template_productDataTable
#End Region
#Region "variables"
    Public tableList As New List(Of String)
#End Region
#Region "audit"
    Public Function InsertAudit(pAudit As AuditEntry) As Integer
        Dim _auditId As Integer = -1
        Try
            With pAudit
                _auditId = oAuditTa.InsertAudit(.AuditUsercode, .RecordType, .RecordId, .AuditDate, .Action, .Before, .After, .ComputerName)
            End With
        Catch ex As Exception
            DisplayException(ex, "Exception inserting audit", MODULE_NAME)
            MsgBox("Error:Audit not added.", MsgBoxStyle.Exclamation, "Error")
        End Try
        Return _auditId

    End Function
    Public Function GetByUserDateType(pUsercode As String, pRecordType As String, pFromDate As Date, pToDate As Date) As List(Of AuditEntry)
        Dim _auditList As New List(Of AuditEntry)
        Try
            oAuditTa.FillByUserDateType(oAuditTable, pUsercode, pRecordType, pFromDate, pToDate)
            For Each oRow As netwyrksDataSet.auditRow In oAuditTable.Rows
                Dim _audit As AuditEntry = AuditEntryBuilder.AnAuditEntry.StartingWith(oRow).Build
                _auditList.Add(_audit)
            Next
        Catch ex As Exception
            DisplayException(ex, "Exception getting audit", MODULE_NAME)
        End Try

        Return _auditList
    End Function
#End Region
#Region "users"
    Public Function GetUserById(_id As Integer) As User
        Dim _user As User = UserBuilder.AUser.StartingWithNothing.Build
        Try
            oUserTa.FillById(oUserTable, _id)
            If oUserTable.Rows.Count > 0 Then
                _user = UserBuilder.AUser.StartingWith(oUserTable.Rows(0)).Build
            End If
        Catch ex As DbException
            DisplayException(ex, "Exception getting user", MODULE_NAME)
        End Try
        Return _user
    End Function
    Public Function GetUserByUsercode(_usercode As String) As User
        Dim _user As User = UserBuilder.AUser.StartingWithNothing.Build
        Try
            oUserTa.FillByUsercode(oUserTable, _usercode)
            If oUserTable.Rows.Count > 0 Then
                _user = UserBuilder.AUser.StartingWith(oUserTable.Rows(0)).Build
            End If
        Catch ex As DbException
            DisplayException(ex, "Exception getting user", MODULE_NAME)
        End Try
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
    Public Function GetAllUsers() As List(Of User)
        Dim _userList As New List(Of User)
        oUserTa.Fill(oUserTable)
        For Each oRow As netwyrksDataSet.userRow In oUserTable.Rows
            _userList.Add(UserBuilder.AUser.StartingWith(oRow).Build)
        Next
        Return _userList
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
    Public Function UpdatePassword(_userId As Integer, ByVal string1 As String, ByVal force As Boolean, ByVal salt As String) As Integer
        Dim _ct As Integer
        Try
            Dim hashedPW As String = AuthenticationUtil.GetHashed(salt & string1)
            Dim forceChange As Integer = If(force, 1, 0)
            _ct = oUserTa.UpdatePassword(hashedPW, Now, force, _userId)
        Catch ex As Exception
            DisplayException(ex, "Exception updating password", MODULE_NAME)
            LogUtil.Exception("Exception saving password : " & ex.Message, ex, MODULE_NAME)
            Throw New ApplicationException("Exception saving password : " & ex.Message)
        End Try
        Return _ct
    End Function
    Public Function UpdateTempPassword(_userId As Integer, ByVal string1 As String, ByVal force As Boolean, ByVal salt As String) As Integer
        Dim _ct As Integer
        Try
            Dim hashedPW As String = AuthenticationUtil.GetHashed(salt & string1)
            Dim forceChange As Integer = If(force, 1, 0)
            _ct = oUserTa.UpdateTempPassword(hashedPW, Now, force, _userId)
        Catch ex As Exception
            DisplayException(ex, "Exception ", MODULE_NAME)
            LogUtil.Exception("Exception saving password : " & ex.Message, ex, MODULE_NAME)
            Throw New ApplicationException("Exception saving password : " & ex.Message)
        End Try
        Return _ct
    End Function
    Public Function RemoveTempPassword(pUserId As Integer) As Integer
        Dim _ct As Integer
        Try
            _ct = oUserTa.UpdateTempPassword(Nothing, Now, False, pUserId)
        Catch ex As Exception
            DisplayException(ex, "Exception updating temp password", MODULE_NAME)
            LogUtil.Exception("Exception saving password : " & ex.Message, ex, MODULE_NAME)
            Throw New ApplicationException("Exception saving password : " & ex.Message)
        End Try
        Return _ct
    End Function
    Public Function DeleteUser(pUserId As Integer) As Integer
        Dim _ct As Integer = 0
        Try
            _ct = oUserTa.DeleteUser(pUserId)
        Catch ex As Exception
            DisplayException(ex, "Exception deleting user", MODULE_NAME)
        End Try
        Return _ct
    End Function
#End Region
#Region "job"
    Public Function GetJobById(ByVal pId As Integer) As Job
        Dim _job As Job = JobBuilder.AJob.StartingWithNothing.Build
        Try
            oJobTa.FillById(oJobTable, pId)
            If oJobTable.Rows.Count > 0 Then
                Dim _row As netwyrksDataSet.jobRow = oJobTable.Rows(0)
                _job = JobBuilder.AJob.StartingWith(_row).Build
            End If
        Catch ex As DbException

        End Try

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
    Public Function InsertJob(pJob As Job) As Integer
        Dim _jobId As Integer = -1
        With pJob
            _jobId = oJobTa.InsertJob(.JobName, .JobDescription, .IsJobCompleted, Now, .JobCustomerId, .JobInvoiceNumber, .JobPoNumber, .JobReference, .JobInvoiceDate, .JobPaymentDue, .JobUserId)
            If _jobId > 0 Then
                AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Job, _jobId, AuditUtil.AuditableAction.create, "", .ToString)
            End If
        End With
        Return _jobId
    End Function
    Public Function UpdateJob(pJob As Job) As Integer
        Dim _ct As Integer = 0
        With pJob
            _ct = oJobTa.UpdateJob(.JobName, .JobDescription, .IsJobCompleted, Now, .JobCustomerId, .JobInvoiceNumber, .JobPoNumber, .JobReference, .JobInvoiceDate, .JobPaymentDue, .JobUserId, .JobId)
            If _ct > 0 Then
                AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.Job, .JobId, AuditUtil.AuditableAction.create, pJob.ToString, .ToString)
            End If
        End With
        Return _ct
    End Function
#End Region
#Region "task"
    Public Function GetTasksByJob(_jobId As Integer) As List(Of Task)
        Dim _taskList As New List(Of Task)
        Try
            oTaskTa.FillByJob(oTaskTable, _jobId)
            For Each oRow As netwyrksDataSet.taskRow In oTaskTable.Rows
                _taskList.Add(TaskBuilder.ATask.StartingWith(oRow).Build)
            Next
        Catch ex As Exception
            DisplayException(ex, "Exception getting tasks", MODULE_NAME)
        End Try
        Return _taskList
    End Function
    Public Function InsertTask(_task As Task) As Integer
        Dim _taskId As Integer = -1
        Try
            With _task
                _taskId = oTaskTa.InsertTask(.TaskName, .TaskDescription, .TaskCost, .TaskHours, .TaskStartDue, .IsTaskStarted, .IstaskCompleted, Now, .TaskJobId, .IsTaskTaxable, .TaskTaxRate)
            End With
        Catch ex As DbException
            DisplayException(ex, "Exception inserting task", MODULE_NAME)
        End Try
        Return _taskId
    End Function
    Public Function UpdateTask(_task As Task) As Integer
        Dim _rtn As Integer = 0
        Try
            With _task
                _rtn = oTaskTa.UpdateTask(.TaskName, .TaskDescription, .TaskCost, .TaskHours, .TaskStartDue, .IsTaskStarted, .IstaskCompleted, Now, .TaskJobId, .IsTaskTaxable, .TaskTaxRate, .TaskId)
            End With
        Catch ex As DbException
            DisplayException(ex, "Exception updating task", MODULE_NAME)
        End Try
        Return _rtn
    End Function
    Public Function DeleteTask(pTaskId As Integer) As Integer
        Dim _ct As Integer
        Try
            _ct = oTaskTa.DeleteTask(pTaskId)
        Catch ex As Exception
            DisplayException(ex, "Exception deleting task", MODULE_NAME)
        End Try
        Return _ct
    End Function
#End Region
#Region "jobproduct"
    Public Function GetJobProductById(_id As Integer) As JobProduct
        Dim _jobProduct As JobProduct
        oJobProductTa.FillById(oJobProductTable, _id)
        If oJobProductTable.Rows.Count > 0 Then
            _jobProduct = JobProductBuilder.AJobProduct.StartingWith(oJobProductTable.Rows(0)).Build
        Else
            _jobProduct = JobProductBuilder.AJobProduct.StartingWithNothing.Build
        End If
        Return _jobProduct
    End Function
    Public Function GetJobProductByJob(_job As Job) As List(Of JobProduct)
        Dim _jobProductList As New List(Of JobProduct)
        oJobProductTa.FillByJob(oJobProductTable, _job.JobId)
        For Each oRow As netwyrksDataSet.job_productRow In oJobProductTable.Rows
            _jobProductList.Add(JobProductBuilder.AJobProduct.StartingWith(oRow).Build)
        Next
        Return _jobProductList
    End Function
    Public Function InsertJobProduct(pJobProduct As JobProduct) As Integer
        Dim _jobproductId As Integer
        Try
            With pJobProduct
                _jobproductId = oJobProductTa.InsertJobProduct(.Quantity, Now, .ThisProduct.ProductId, .ThisJob.JobId, .Taxable, .Tax_Rate, .Price)
                If _jobproductId > 0 Then
                    AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.JobProduct, _jobproductId, AuditUtil.AuditableAction.create, "", .ToString)
                End If
            End With
        Catch ex As Exception
            DisplayException(ex, "Exception inserting job product", MODULE_NAME)
        End Try
        Return _jobproductId
    End Function
    Public Function DeleteJobProduct(pJobProductId As Integer) As Integer
        Dim _ct As Integer = 0
        Try
            _ct = oJobProductTa.DeleteJobProduct(pJobProductId)
        Catch ex As Exception
            DisplayException(ex, "Exception deleting job product", MODULE_NAME)
        End Try
        Return _ct
    End Function
    Public Function UpdateJobProduct(pJobProduct As JobProduct) As Integer
        Dim _ct As Integer
        Try
            With pJobProduct
                _ct = oJobProductTa.UpdateJobProduct(.Quantity, Now, .JobProductId, .ThisJob.JobId, .Taxable, .Tax_Rate, .Price, .JobProductId)
            End With
        Catch ex As Exception
            DisplayException(ex, "Exception updating job product", MODULE_NAME)
        End Try
        Return _ct
    End Function
    Public Function GetJobProductViewById(_id As Integer) As FullJobProduct
        Dim _jobProduct As FullJobProduct = FullJobProductBuilder.AJobProduct.StartingWithNothing.Build
        Try
            oJobProductViewTa.FillById(oJobProductViewTable, _id)
            If oJobProductViewTable.Rows.Count > 0 Then
                _jobProduct = FullJobProductBuilder.AJobProduct.StartingWith(oJobProductTable.Rows(0)).Build
            End If
        Catch ex As Exception
            DisplayException(ex, "Exception getting job product", MODULE_NAME)
        End Try
        Return _jobProduct
    End Function
    Public Function GetJobProductViewByJob(_id As Integer) As List(Of FullJobProduct)
        Dim _jobProductList As New List(Of FullJobProduct)

        Try
            oJobProductViewTa.FillByJobId(oJobProductViewTable, _id)
            For Each oRow As netwyrksDataSet.v_jobproductRow In oJobProductViewTable.Rows
                _jobProductList.Add(FullJobProductBuilder.AJobProduct.StartingWith(oRow).Build)
            Next
        Catch ex As Exception
            DisplayException(ex, "Exception getting job product", MODULE_NAME)
        End Try
        Return _jobProductList
    End Function
    Public Function GetJobProductViewByCustomer(_id As Integer) As List(Of FullJobProduct)
        Dim _jobProductList As New List(Of FullJobProduct)

        Try
            oJobProductViewTa.FillByCustomerId(oJobProductViewTable, _id)
            For Each oRow As netwyrksDataSet.v_jobproductRow In oJobProductViewTable.Rows
                _jobProductList.Add(FullJobProductBuilder.AJobProduct.StartingWith(oRow).Build)
            Next
        Catch ex As Exception
            DisplayException(ex, "Exception getting job products", MODULE_NAME)
        End Try
        Return _jobProductList
    End Function
#End Region
#Region "jobimage"
    Public Function GetJobImageById(_id As Integer) As JobImage
        Dim _jobImage As JobImage
        oJobImageTa.FillByImageId(oJobImageTable, _id)
        If oJobImageTable.Rows.Count > 0 Then
            _jobImage = JobImageBuilder.aJobImage.StartingWith(oJobImageTable.Rows(0)).Build
        Else
            _jobImage = JobImageBuilder.aJobImage.StartingWithNothing.Build
        End If
        Return _jobImage
    End Function
    Public Function GetJobImageByJob(_job As Job) As List(Of JobImage)
        Dim _jobImageList As New List(Of JobImage)
        oJobImageTa.FillByJobId(oJobImageTable, _job.JobId)
        For Each oRow As netwyrksDataSet.job_imageRow In oJobImageTable.Rows
            _jobImageList.Add(JobImageBuilder.aJobImage.StartingWith(oRow).Build)
        Next
        Return _jobImageList
    End Function
    Public Function InsertJobImage(pJobImage As JobImage) As Integer
        Dim _jobImageId As Integer
        Try
            With pJobImage
                _jobImageId = oJobImageTa.InsertJobImage(.JobId, .ImagePath, .ImageDesc)
                If _jobImageId > 0 Then
                    AuditUtil.AddAudit(currentUser.User_code, AuditUtil.RecordType.JobImage, _jobImageId, AuditUtil.AuditableAction.create, "", .ToString)
                End If
            End With
        Catch ex As DbException
            DisplayException(ex, "Exception inserting image", MODULE_NAME)
        End Try
        Return _jobImageId
    End Function
    Public Function DeleteJobImage(pJobImageId As Integer) As Integer
        Dim _ct As Integer = 0
        Try
            _ct = oJobImageTa.DeleteImage(pJobImageId)
        Catch ex As DbException
            DisplayException(ex, "Exception deleting image", MODULE_NAME)
        End Try
        Return _ct
    End Function
    Public Function UpdateJobImage(pJobImage As JobImage) As Integer
        Dim _ct As Integer
        Try
            With pJobImage
                _ct = oJobImageTa.UpdateJobImage(.JobId, .ImagePath, .ImageDesc, .ImageId)
            End With
        Catch ex As DbException
            DisplayException(ex, "Exception updating image", MODULE_NAME)
        End Try
        Return _ct
    End Function
#End Region
#Region "product"
    Public Function GetProductById(ByVal pId As Integer) As Product
        Dim _product As Product = ProductBuilder.AProduct.StartingWithNothing.Build
        oProductTa.FillById(oProductTable, pId)
        If oProductTable.Rows.Count > 0 Then
            Dim _row As netwyrksDataSet.productRow = oProductTable.Rows(0)
            _product = ProductBuilder.AProduct.StartingWith(_row).Build
        End If
        Return _product
    End Function
    Public Function GetAllProducts() As List(Of Product)
        Dim _productList As New List(Of Product)
        oProductTa.Fill(oProductTable)
        For Each oRow As netwyrksDataSet.productRow In oProductTable.Rows
            _productList.Add(ProductBuilder.AProduct.StartingWith(oRow).Build)
        Next
        Return _productList
    End Function
    Public Function GetProductsBySupplier(ByVal _suppId) As List(Of Product)
        Dim _productList As New List(Of Product)
        oProductTa.FillBySupplier(oProductTable, _suppId)
        For Each oRow As netwyrksDataSet.productRow In oProductTable.Rows
            _productList.Add(ProductBuilder.AProduct.StartingWith(oRow).Build)
        Next
        Return _productList
    End Function
    Public Function InsertProduct(pProduct As Product) As Integer
        Dim _productId As Integer
        With pProduct
            _productId = oProductTa.InsertProduct(.ProductName, .ProductDescription, .ProductCost, .ProductPrice, .ProductCreated, .ProductSupplierId, .IsProductTaxable, .ProductTaxRate, .PurchaseUnits)
        End With
        Return _productId
    End Function
    Public Function UpdateProduct(pProduct As Product) As Integer
        Dim _ct As Integer
        With pProduct
            _ct = oProductTa.UpdateProduct(.ProductName, .ProductDescription, .ProductCost, .ProductPrice, .ProductChanged, .ProductSupplierId, .IsProductTaxable, .ProductTaxRate, .PurchaseUnits, .ProductId)
        End With
        Return _ct
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
    Public Function GetCustomer(pCustId As Integer) As Customer
        Dim _cust As Customer = CustomerBuilder.ACustomer.StartingWithNothing.Build
        Try
            oCustomerTa.FillById(oCustomerTable, pCustId)
            If oCustomerTable.Rows.Count > 0 Then
                Dim _row As netwyrksDataSet.customerRow = oCustomerTable.Rows(0)
                _cust = CustomerBuilder.ACustomer.StartingWith(_row).Build
            End If
        Catch ex As DbException
            DisplayException(ex, "Exception getting customer", MODULE_NAME)
        End Try
        Return _cust
    End Function
    Public Function InsertCustomer(pCust As Customer) As Integer
        Dim _custId As Integer = -1
        Try
            With pCust
                _custId = oCustomerTa.InsertCustomer(.CustName,
                                           .Address.Address1,
                                           .Address.Address2,
                                           .Address.Address3,
                                           .Address.Address4,
                                           .Address.Postcode,
                                           .Phone,
                                           .Email,
                                           .Discount,
                                           .Notes,
                                           .DateCreated,
                                           .DateChanged,
                                           .Terms)

            End With
        Catch ex As DbException
            DisplayException(ex, "Exception inserting customer", MODULE_NAME)
            MsgBox("Error:Customer not added.", MsgBoxStyle.Exclamation, "Error")
        End Try
        Return _custId
    End Function
    Public Function UpdateCustomer(pCust As Customer) As Integer
        Dim _ct As Integer = -1
        Try
            With pCust
                _ct = oCustomerTa.UpdateCustomer(.CustName,
                                           .Address.Address1,
                                           .Address.Address2,
                                           .Address.Address3,
                                           .Address.Address4,
                                           .Address.Postcode,
                                           .Phone,
                                           .Email,
                                           .Discount,
                                           .Notes,
                                           Now,
                                           .Terms,
                                           .CustomerId)
            End With
        Catch ex As DbException
            DisplayException(ex, "Exception updating image", MODULE_NAME)
            MsgBox("Error:Customer not updated", MsgBoxStyle.Exclamation, "Error")
        End Try
        Return _ct
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
    Public Function GetSupplierById(pSuppId As Integer) As Supplier
        Dim _supp As Supplier = SupplierBuilder.ASupplier.StartingWithNothing.Build
        Try
            oSupplierTa.FillById(oSupplierTable, pSuppId)
            If oSupplierTable.Rows.Count > 0 Then
                Dim _row As netwyrksDataSet.supplierRow = oSupplierTable.Rows(0)
                _supp = SupplierBuilder.ASupplier.StartingWith(_row).Build
            End If
        Catch ex As DbException
            DisplayException(ex, "Exception getting supplier", MODULE_NAME)
        End Try
        Return _supp
    End Function
    Public Function InsertSupplier(ByRef pSupplier As Supplier) As Integer
        Dim newId As Integer = -1
        Try
            With pSupplier
                newId = oSupplierTa.InsertSupplier(.SupplierName,
                                           .SupplierAddress.Address1,
                                           .SupplierAddress.Address2,
                                           .SupplierAddress.Address3,
                                           .SupplierAddress.Address4,
                                           .SupplierAddress.Postcode,
                                           .SupplierPhone,
                                           .SupplierEmail,
                                           .SupplierDiscount,
                                           .SupplierNotes,
                                           .SupplierCreated,
                                           .IsSupplierAmazon,
                                           .SupplierUrl)
            End With
        Catch ex As Exception
            DisplayException(ex, "Exception inserting supplier", MODULE_NAME)
            MsgBox("Error:Supplier not added.", MsgBoxStyle.Exclamation, "Error")
        End Try
        Return newId
    End Function
    Public Function UpdateSupplier(ByRef pSupplier As Supplier) As Integer
        Dim _ct As Integer = -1
        Try
            With pSupplier
                _ct = oSupplierTa.UpdateSupplier(.SupplierName,
                                           .SupplierAddress.Address1,
                                           .SupplierAddress.Address2,
                                           .SupplierAddress.Address3,
                                           .SupplierAddress.Address4,
                                           .SupplierAddress.Postcode,
                                           .SupplierPhone,
                                           .SupplierEmail,
                                           .SupplierDiscount,
                                           .SupplierNotes,
                                           .SupplierCreated,
                                           .IsSupplierAmazon,
                                           .SupplierUrl,
                                           .SupplierId)
            End With
        Catch ex As Exception
            DisplayException(ex, "Exception updating supplier", MODULE_NAME)
            MsgBox("Error:Supplier not updated.", MsgBoxStyle.Exclamation, "Error")
        End Try
        Return _ct
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
    Public Function GetReminderById(ByVal pId As Integer) As Reminder
        Dim _rem As Reminder = ReminderBuilder.AReminder.StartingWithNothing.Build
        Try
            oDiaryTa.FillById(oDiaryTable, pId)
            If oDiaryTable.Rows.Count > 0 Then
                _rem = ReminderBuilder.AReminder.StartingWith(oDiaryTable.Rows(0)).Build
            End If
        Catch ex As DbException
            DisplayException(ex, "Exception getting reminder", MODULE_NAME)
        End Try
        Return _rem
    End Function
    Public Function UpdateReminderClosed(pValue As Boolean, pRemId As Integer) As Integer
        Dim _ct As Integer
        Try
            _ct = oDiaryTa.UpdateClosed(If(pValue, 1, 0), pRemId)
        Catch ex As Exception
            DisplayException(ex, "Exception updating reminder", MODULE_NAME)
            MsgBox("Error:Reminder not updated.", MsgBoxStyle.Exclamation, "Error")
        End Try
        Return _ct
    End Function
    Public Function UpdateIsReminder(pValue As Boolean, pRemId As Integer) As Integer
        Dim _ct As Integer
        Try
            _ct = oDiaryTa.UpdateReminder(If(pValue, 1, 0), pRemId)
        Catch ex As Exception
            DisplayException(ex, "Exception updating reminder", MODULE_NAME)
            MsgBox("Error:Reminder not updated.", MsgBoxStyle.Exclamation, "Error")
        End Try
        Return _ct
    End Function
    Public Function UpdateCallback(pValue As Boolean, pRemId As Integer) As Integer
        Dim _ct As Integer
        Try
            _ct = oDiaryTa.UpdateCallback(If(pValue, 1, 0), pRemId)
        Catch ex As Exception
            DisplayException(ex, "Exception updating reminder", MODULE_NAME)
            MsgBox("Error:Reminder not updated.", MsgBoxStyle.Exclamation, "Error")
        End Try
        Return _ct
    End Function
    Public Function UpdateDiary(pReminder As Reminder) As Integer
        Dim _ct As Integer
        Try
            With pReminder
                _ct = oDiaryTa.UpdateDiary(.ReminderDate,
                                           .UserId,
                                           .JobId,
                                           .CustomerId,
                                           .Body,
                                           .Subject,
                                           If(.IsReminder, 1, 0),
                                           If(.IsClosed, 1, 0),
                                           If(.CallBack, 1, 0),
                                           .Diary_id)
            End With
        Catch ex As DbException
            DisplayException(ex, "Exception updating diary", MODULE_NAME)
            MsgBox("Error:Diary not updated.", MsgBoxStyle.Exclamation, "Error")
        End Try
        Return _ct
    End Function
    Public Function CreateDiary(pReminder As Reminder) As Integer
        Dim _id As Integer
        Try
            With pReminder
                _id = oDiaryTa.InsertDiary(.ReminderDate,
                                           .UserId,
                                           .JobId,
                                           .CustomerId,
                                           .Body,
                                           .Subject,
                                           If(.IsReminder, 1, 0),
                                           If(.IsClosed, 1, 0),
                                           If(.CallBack, 1, 0))
            End With
        Catch ex As Exception
            DisplayException(ex, "Exception inserting diary", MODULE_NAME)
            MsgBox("Error:Diary not updated.", MsgBoxStyle.Exclamation, "Error")
        End Try
        Return _id
    End Function
    Public Function GetCallBackAlerts(ByVal userId As Integer) As List(Of Reminder)
        Dim _alertList As New List(Of Reminder)
        Try
            oDiaryTa.FillByCallbackAlert(oDiaryTable, Now, DateAdd(DateInterval.Minute, My.Settings.alertNotice * 1.5, Now), userId)
            For Each oRow As netwyrksDataSet.diaryRow In oDiaryTable.Rows
                Dim _alert As Reminder = ReminderBuilder.AReminder.StartingWith(oRow).Build
                _alertList.Add(_alert)
            Next
        Catch ex As Exception
            DisplayException(ex, "Exception getting call backs", MODULE_NAME)
        End Try
        Return _alertList
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
        tableList.Add("Job_Image")
        tableList.Add("Product")
        tableList.Add("Supplier")
        tableList.Add("Task")
        tableList.Add("User")
        tableList.Add("Template")
        tableList.Add("Template_Task")
        tableList.Add("Template_Product")
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
                Case "Job_Image"
                    If RecreateTable(oJobImageTable, datapath) Then
                        oJobImageTa.TruncateJobImage()
                        oJobImageTa.Update(oJobImageTable)
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
                Case "Template"
                    If RecreateTable(oTemplateTable, datapath) Then
                        oTemplateTa.TruncateTemplate()
                        oTemplateTa.Update(oTemplateTable)
                        rowCount = oTaskTa.GetData.Rows.Count
                    End If
                Case "Template_Task"
                    If RecreateTable(oTemplateTaskTable, datapath) Then
                        oTemplateTaskTa.TruncateTemplateTask()
                        oTemplateTaskTa.Update(oTemplateTaskTable)
                        rowCount = oTaskTa.GetData.Rows.Count
                    End If
                Case "Template_Product"
                    If RecreateTable(oTemplateProductTable, datapath) Then
                        oTemplateProductTa.TruncateTemplateProduct()
                        oTemplateProductTa.Update(oTemplateProductTable)
                        rowCount = oTaskTa.GetData.Rows.Count
                    End If
            End Select
        Catch ex As Exception
            DisplayException(ex, "Exception restoring table", MODULE_NAME)
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
                DisplayException(ex, "Exception recreating table", MODULE_NAME)
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
    Public Function GetJob_ImageTable() As netwyrksDataSet.job_imageDataTable
        LogUtil.Info("Getting Job_Image table", MODULE_NAME)
        Return oJobImageTa.GetData()
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
#Region "templates"
    Public Function GetTemplateTable() As netwyrksDataSet.templateDataTable
        LogUtil.Info("Getting Template table", MODULE_NAME)
        Return oTemplateTa.GetData
    End Function
    Public Function GetTemplate_TaskTable() As netwyrksDataSet.template_taskDataTable
        LogUtil.Info("Getting Template Task table", MODULE_NAME)
        Return oTemplateTaskTa.GetData
    End Function
    Public Function GetTemplate_ProductTable() As netwyrksDataSet.template_productDataTable
        LogUtil.Info("Getting Template Product table", MODULE_NAME)
        Return oTemplateProductTa.GetData
    End Function

    Public Function GetAllTemplates() As List(Of Template)
        Dim _templateList As New List(Of Template)
        Try
            oTemplateTa.Fill(oTemplateTable)
            For Each oRow As netwyrksDataSet.templateRow In oTemplateTable.Rows
                _templateList.Add(TemplateBuilder.ATemplate.StartingWith(oRow).Build)
            Next
        Catch ex As DbException

        End Try
        Return _templateList
    End Function
    Public Function GetTemplateById(pId As Integer) As Template
        Dim _template As Template = TemplateBuilder.ATemplate.StartingWithNothing.Build
        Try
            oTemplateTa.FillById(oTemplateTable, pId)
            If oTemplateTable.Rows.Count > 0 Then
                _template = TemplateBuilder.ATemplate.StartingWith(oTemplateTable.Rows(0)).Build
            End If
        Catch ex As DbException

        End Try
        Return _template
    End Function

    Public Function GetTemplateTasksForTemplate(pTemplateId) As List(Of TemplateTask)
        Dim _templateTaskList As New List(Of TemplateTask)
        Try
            oTemplateTaskTa.FillByTemplateId(oTemplateTaskTable, pTemplateId)
            For Each oRow As netwyrksDataSet.template_taskRow In oTemplateTaskTable.Rows
                _templateTaskList.Add(TemplateTaskBuilder.ATemplateTask.StartingWith(oRow).Build)
            Next
        Catch ex As DbException

        End Try
        Return _templateTaskList
    End Function
    Public Function GetTemplateTaskById(pId As Integer) As TemplateTask
        Dim _templateTask As TemplateTask = TemplateTaskBuilder.ATemplateTask.StartingWithNothing.Build
        Try
            oTemplateTaskTa.FillById(oTemplateTaskTable, pId)
            If oTemplateTaskTable.Rows.Count > 0 Then
                _templatetask = TemplateTaskBuilder.ATemplateTask.StartingWith(oTemplateTaskTable.Rows(0)).Build
            End If
        Catch ex As DbException

        End Try
        Return _templatetask
    End Function

    Public Function GetTemplateProductsForTemplate(pTemplateId) As List(Of TemplateProduct)
        Dim _templateProductList As New List(Of TemplateProduct)
        Try
            oTemplateProductTa.FillByTemplateId(oTemplateProductTable, pTemplateId)
            For Each oRow As netwyrksDataSet.template_productRow In oTemplateProductTable.Rows
                _templateProductList.Add(TemplateProductBuilder.ATemplateProduct.StartingWith(oRow).Build)
            Next
        Catch ex As DbException

        End Try
        Return _templateProductList
    End Function
    Public Function GetTemplateProductById(pId As Integer) As TemplateProduct
        Dim _templateProduct As TemplateProduct = TemplateProductBuilder.ATemplateProduct.StartingWithNothing.Build
        Try
            oTemplateProductTa.FillById(oTemplateProductTable, pId)
            If oTemplateProductTable.Rows.Count > 0 Then
                _templateProduct = TemplateProductBuilder.ATemplateProduct.StartingWith(oTemplateProductTable.Rows(0)).Build
            End If
        Catch ex As DbException

        End Try
        Return _templateProduct
    End Function

    Public Function InsertTemplate(ptemplate As Template) As Integer
        Dim _id As Integer
        Try
            With ptemplate
                _id = oTemplateTa.InsertTemplate(.TemplateName, .TemplateDescription)
            End With
        Catch ex As Exception
            DisplayException(ex, "Exception inserting template", MODULE_NAME)
        End Try
        Return _id
    End Function
    Public Function InsertTemplateProduct(ptemplateproduct As TemplateProduct) As Integer
        Dim _id As Integer
        Try
            With ptemplateproduct
                _id = oTemplateProductTa.InsertTemplateProduct(.Quantity, .ProductId, .Template.TemplateId)
            End With
        Catch ex As Exception
            DisplayException(ex, "Exception inserting template product", MODULE_NAME)
        End Try
        Return _id
    End Function
    Public Function InsertTemplatetask(ptemplatetask As TemplateTask) As Integer
        Dim _id As Integer
        Try
            With ptemplatetask
                _id = oTemplateTaskTa.InsertTemplateTask(.Name, .Description, .Cost, .Hours, .Template.TemplateId, .TaxRate, .IsTaskTaxable)
            End With
        Catch ex As Exception
            DisplayException(ex, "Exception inserting template task", MODULE_NAME)
        End Try
        Return _id
    End Function


#End Region
End Module
