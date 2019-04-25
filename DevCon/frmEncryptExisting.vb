Imports DevCon.EncryptionUtil
Public Class frmEncryptExisting
#Region "Contants"
    Private Const FORM_NAME As String = "encrypt database values"
#End Region
#Region "Private variable instances"

#End Region

#Region "Form"
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Starting", FORM_NAME)
        lblFormName.Text = FORM_NAME
    End Sub
#End Region

#Region "Subroutines"
    Private Sub logStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information, Optional ByVal errorCode As String = Nothing)
        lblStatus.Text = sText
        If islogged Then LogUtil.addLog(sText, level, FORM_NAME, errorCode)
    End Sub
#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked Then
            encryptDiary()
        End If
        If CheckBox2.Checked Then
            encryptJobs()
        End If
        If CheckBox3.Checked Then
            encryptCustomer()
        End If
        If CheckBox11.Checked Then
            encryptAudit()
        End If
        If CheckBox12.Checked Then
            encryptUserDetails()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CheckBox1.Checked Then
            decryptDiary()
        End If
        If CheckBox2.Checked Then
            decryptJobs()
        End If
        If CheckBox3.Checked Then
            decryptCustomer()
        End If
        If CheckBox11.Checked Then
            decryptAudit()
        End If
        If CheckBox12.Checked Then
            decryptUserDetails()
        End If
    End Sub

    Private Sub encryptDiary()
        LogUtil.Info("Encrypting Diary", FORM_NAME)
        Dim oTa As New netwyrksDataSetTableAdapters.diaryTableAdapter
        Dim oTable As New netwyrksDataSet.diaryDataTable
        oTa.Fill(oTable)
        For Each oRow As netwyrksDataSet.diaryRow In oTable.Rows
            Dim id As Integer = oRow.diary_id
            Dim newBody As String = If(oRow.Isdiary_bodyNull, "", encryptText(oRow.diary_body))
            Dim newSubject As String = If(oRow.Isdiary_subjectNull, "", encryptText(oRow.diary_subject))
            '          oTa.UpdateEnc(newSubject, newBody, id)
        Next
        oTa.Dispose()
        oTable.Dispose()
        logStatus("Completed Diary encryption", True)
    End Sub

    Private Sub encryptJobs()
        LogUtil.Info("Encrypting Incidents", FORM_NAME)
        Dim oTa As New netwyrksDataSetTableAdapters.jobTableAdapter
        Dim oTable As New netwyrksDataSet.jobDataTable
        oTa.Fill(oTable)
        For Each oRow As netwyrksDataSet.jobRow In oTable.Rows
            Dim id As Integer = oRow.job_id

            '        oTa.UpdateEnc(newNote, newRecomm, id)
        Next
        oTa.Dispose()
        oTable.Dispose()

        logStatus("Completed Incidents encryption", True)
    End Sub

    Private Sub encryptCustomer()
        LogUtil.Info("Encrypting Customers", FORM_NAME)
        Dim oTa As New netwyrksDataSetTableAdapters.customerTableAdapter
        Dim oTable As New netwyrksDataSet.customerDataTable
        oTa.Fill(oTable)
        For Each oRow As netwyrksDataSet.customerRow In oTable.Rows
            Dim id As Integer = oRow.customer_id
            Dim newName As String = encryptText(oRow.customer_name)
            Dim newEmail As String = If(oRow.Iscustomer_emailNull, "", encryptText(oRow.customer_email))
            Dim newPhone As String = If(oRow.Iscustomer_telephoneNull, "", encryptText(oRow.customer_telephone))
            Dim newNotes As String = If(oRow.Iscustomer_notesNull, "", encryptText(oRow.customer_notes))
            '     oTa.UpdateEnc(newTitle, newGivenName, newFamilyName, newEmail, newPhone, newNotes, newMobile, newMatchKey, id)
        Next
        oTa.Dispose()
        oTable.Dispose()
        logStatus("Completed Customers encryption", True)

    End Sub

    Private Sub encryptAudit()
        LogUtil.Info("Encrypting Audit", FORM_NAME)
        Dim oTa As New netwyrksDataSetTableAdapters.auditTableAdapter
        Dim oTable As New netwyrksDataSet.auditDataTable
        oTa.Fill(oTable)
        For Each oRow As netwyrksDataSet.auditRow In oTable.Rows
            Dim id As Integer = oRow.audit_id
            Dim newValue As String = If(oRow.Isaudit_afterNull, "", encryptText(oRow.audit_after))
            '     oTa.UpdateEnc(newValue, id)
        Next
        oTa.Dispose()
        oTable.Dispose()
        logStatus("Completed Audit encryption", True)

    End Sub

    Private Sub encryptUserDetails()
        LogUtil.Info("Encrypting User Details", FORM_NAME)
        Dim oTa As New netwyrksDataSetTableAdapters.userTableAdapter
        Dim oTable As New netwyrksDataSet.userDataTable
        oTa.Fill(oTable)
        For Each oRow As netwyrksDataSet.userRow In oTable.Rows
            Dim id As Integer = oRow.user_id

            Dim newEmail As String = If(oRow.Isuser_emailNull, "", encryptText(oRow.user_email))
            Dim newJobTitle As String = If(oRow.Isuser_jobtitleNull, "", encryptText(oRow.user_jobtitle))
            Dim newNote As String = If(oRow.Isuser_noteNull, "", encryptText(oRow.user_note))
            Dim newContactNumber As String = If(oRow.Isuser_contact_numberNull, "", encryptText(oRow.user_contact_number))
            Dim newForename As String = encryptText(oRow.user_name)
            '            oTa.UpdateEnc(newEmail, newJobTitle, newNote, newContactNumber, newTitle, newForename, newSurname, id)
        Next
        oTa.Dispose()
        oTable.Dispose()
        logStatus("Completed User Detail encryption", True)

    End Sub



    Private Sub decryptDiary()
        LogUtil.Info("Decrypting Diary", FORM_NAME)
        Dim oTa As New netwyrksDataSetTableAdapters.diaryTableAdapter
        Dim oTable As New netwyrksDataSet.diaryDataTable
        oTa.Fill(oTable)
        For Each oRow As netwyrksDataSet.diaryRow In oTable.Rows
            Dim id As Integer = oRow.diary_id
            Dim newBody As String = If(oRow.Isdiary_bodyNull, "", decryptText(oRow.diary_body))
            Dim newSubject As String = If(oRow.Isdiary_subjectNull, "", decryptText(oRow.diary_subject))
            '      oTa.UpdateEnc(newSubject, newBody, id)
        Next
        oTa.Dispose()
        oTable.Dispose()
        logStatus("Completed Diary decryption", True)
    End Sub

    Private Sub decryptJobs()
        LogUtil.Info("Decrypting Incidents", FORM_NAME)
        Dim oTa As New netwyrksDataSetTableAdapters.jobTableAdapter
        Dim oTable As New netwyrksDataSet.jobDataTable
        oTa.Fill(oTable)
        For Each oRow As netwyrksDataSet.jobRow In oTable.Rows
            Dim id As Integer = oRow.job_id

            '        oTa.UpdateEnc(newNote, newRecomm, id)
        Next
        oTa.Dispose()
        oTable.Dispose()
        logStatus("Completed Incidents decryption", True)
    End Sub

    Private Sub decryptCustomer()
        LogUtil.Info("Decrypting Customers", FORM_NAME)
        Dim oTa As New netwyrksDataSetTableAdapters.customerTableAdapter
        Dim oTable As New netwyrksDataSet.customerDataTable
        oTa.Fill(oTable)
        For Each oRow As netwyrksDataSet.customerRow In oTable.Rows
            Dim id As Integer = oRow.customer_id

            Dim newName As String = oRow.customer_name

            Dim newEmail As String = If(oRow.Iscustomer_emailNull, "", decryptText(oRow.customer_email))
            Dim newPhone As String = If(oRow.Iscustomer_telephoneNull, "", decryptText(oRow.customer_telephone))
            Dim newNotes As String = If(oRow.Iscustomer_notesNull, "", decryptText(oRow.customer_notes))

            '         oTa.UpdateEnc(newTitle, newGivenName, newFamilyName, newEmail, newPhone, newNotes, newMobile, newMatchKey, id)
        Next
        oTa.Dispose()
        oTable.Dispose()
        logStatus("Completed Customer decryption", True)

    End Sub



    Private Sub decryptAudit()
        LogUtil.Info("Decrypting Audit", FORM_NAME)
        Dim oTa As New netwyrksDataSetTableAdapters.auditTableAdapter
        Dim oTable As New netwyrksDataSet.auditDataTable
        oTa.Fill(oTable)
        For Each oRow As netwyrksDataSet.auditRow In oTable.Rows
            Dim id As Integer = oRow.audit_id
            Dim newValue As String = If(oRow.Isaudit_afterNull, "", decryptText(oRow.audit_after))
            '    oTa.UpdateEnc(newValue, id)
        Next
        oTa.Dispose()
        oTable.Dispose()
        logStatus("Completed Audit decryption", True)

    End Sub

    Private Sub decryptUserDetails()
        LogUtil.Info("Decrypting User Details", FORM_NAME)
        Dim oTa As New netwyrksDataSetTableAdapters.userTableAdapter
        Dim oTable As New netwyrksDataSet.userDataTable
        oTa.Fill(oTable)
        For Each oRow As netwyrksDataSet.userRow In oTable.Rows
            Dim id As Integer = oRow.user_id

            Dim newEmail As String = If(oRow.Isuser_emailNull, "", decryptText(oRow.user_email))
            Dim newJobTitle As String = If(oRow.Isuser_jobtitleNull, "", decryptText(oRow.user_jobtitle))
            Dim newNote As String = If(oRow.Isuser_noteNull, "", decryptText(oRow.user_note))
            Dim newContactNumber As String = If(oRow.Isuser_contact_numberNull, "", decryptText(oRow.user_contact_number))
            Dim newSName As String = decryptText(oRow.user_name)

            '    oTa.UpdateEnc(newEmail, newJobTitle, newNote, newContactNumber, newTitle, newForename, newSurname, id)
        Next
        oTa.Dispose()
        oTable.Dispose()
        logStatus("Completed User Detail decryption", True)

    End Sub
End Class