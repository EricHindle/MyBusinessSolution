'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports Microsoft.Office.Interop.Outlook
Imports System.IO
Imports MyBusiness.netwyrksErrorCodes
Imports System.Net
Imports System.Text
Imports System.Net.Mime
Imports Microsoft.Office.Interop

''' <summary>
''' Utility for sending emails
''' </summary>
''' <remarks></remarks>
Public Class EmailUtil
    'Private Shared oRecipientTa As netwyrksDataSetTableAdapters.recipientTableAdapter
    'Private Shared oMemberTa As netwyrksDataSetTableAdapters.distribution_group_membersTableAdapter
    Private Shared className As String = "EmailUtil"
    'Private Shared oEmailTa As New netwyrksDataSetTableAdapters.sers_sent_emailTableAdapter
    'Private Shared oEmailTable As New netwyrksDataSet.sers_sent_emailDataTable
    Public Shared sOutlookSender As String = ""
    Public Shared EmailTypeDescription As String() = New String() { _
        "Unknown", _
        "Exclusion Notification", _
        "Incident Notification", _
        "Customer Account Details", _
        "Customer History", _
        "Report", _
        "Data Table Report", _
        "Customer Communication"}

    Public Shared Sub setSMTPSetting(ByVal useSmtp As Boolean)
        My.Settings.useSMTP = useSmtp
    End Sub

    ''' <summary>
    ''' Check to see if Outlook is available and obtain currently logged on account email address
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckOutlookSender() As String
        If Not My.Settings.useSMTP Then
            LogUtil.Debug("Checking Outlook", "CheckOutlookSender")
            Try
                Dim outlookAccounts As Outlook.Accounts = getOutlookAccounts()
                If outlookAccounts IsNot Nothing Then
                    sOutlookSender = outlookAccounts(1).DisplayName
                    LogUtil.Debug("Outlook OK", "CheckOutlookSender")
                Else
                    LogUtil.Problem("Error finding Outlook account", "CheckOutlookSender")
                End If
            Catch ex As System.Exception
                LogUtil.Exception("Exception getting Outlook account", ex, "CheckOutlookSender", getErrorCode(SystemModule.EMAIL, ErrorType.APPLICATION, FailedAction.ERROR_STARTING_EXTERNAL_APP))
            End Try
        End If
        Return sOutlookSender
    End Function

    Public Shared Function getOutlookAccounts() As Outlook.Accounts
        Dim outlookAccounts As Outlook.Accounts = Nothing
        LogUtil.Debug("Getting Outlook Accounts", "getOutlookAccounts")
        Try
            Dim objOutlook As Application = Nothing
            Try
                If objOutlook Is Nothing Then
                    objOutlook = CreateObject("Outlook.Application")
                    objOutlook.Session.Logon()
                End If
                outlookAccounts = objOutlook.Session.Accounts
                LogUtil.Debug("Outlook OK", "CheckOutlookSender")
            Catch ex As System.Exception
                LogUtil.Exception("Cannot start Outlook", ex, className & ":CheckOutlookSender", getErrorCode(SystemModule.EMAIL, ErrorType.APPLICATION, FailedAction.ERROR_STARTING_EXTERNAL_APP))
            End Try
            objOutlook = Nothing
        Catch ex As System.Exception
            LogUtil.Exception("Error getting Outlook Accounts", ex, "getOutlookAccounts")
        End Try
        Return outlookAccounts
    End Function


    'Public Shared Function EmailTypeToTemplateType(ByVal pEmailType As Email.EmailType) As Template.TemplateType
    '    Dim TemplType As Template.TemplateType = Template.TemplateType.Unknown
    '    Select Case pEmailType
    '        Case Email.EmailType.ExclusionNotification
    '            TemplType = Template.TemplateType.ExclusionNotificationEmail
    '        Case Email.EmailType.IncidentNotification
    '            TemplType = Template.TemplateType.IncidentNotificationEmail
    '        Case Email.EmailType.CustomerAccountDetails
    '            TemplType = Template.TemplateType.CustomerAccounts
    '        Case Email.EmailType.DataTableReport
    '            TemplType = Template.TemplateType.DataTableEmail
    '    End Select
    '    Return TemplType
    'End Function

    'Public Shared Function EmailTypeHasImages(ByVal pEmailType As Email.EmailType) As Boolean
    '    Dim rtnval As Boolean = False
    '    Select Case pEmailType
    '        Case Email.EmailType.ExclusionNotification
    '            rtnval = False
    '    End Select
    '    Return rtnval
    'End Function

    ''' <summary>
    ''' Send an email
    ''' </summary>
    ''' <param name="strToName">List of To email addresses</param>
    ''' <param name="strCC">List of cc email addresses</param>
    ''' <param name="strSubject">Email subject text</param>
    ''' <param name="strBody">Email body text</param>
    ''' <param name="strFilenames">List of files to be attached</param>
    ''' <param name="bodyType">Indicator to show HTML or plain text body</param>
    ''' <param name="oFont">Font for HTML body</param>
    ''' <param name="strOnBehalfOf">Email address to be sent from</param>
    ''' <param name="oImportance">Indicator to show if to be sent with high importance</param>
    ''' <param name="deleteAfterSubmit">Indicator to show if email should be retained in the outbox (and sent mail table)</param>
    ''' <returns>True if email sent OK</returns>
    ''' <remarks></remarks>
    Public Shared Function SendMail(ByVal strToName As String(), _
                          ByVal strCC As String(), _
                          ByVal strSubject As String, _
                          ByVal strBody As String, _
                          Optional ByVal strFilenames As String() = Nothing, _
                          Optional ByVal bodyType As Integer = 1, _
                          Optional ByVal oFont As System.Drawing.Font = Nothing, _
                          Optional ByVal strOnBehalfOf As String = "", _
                          Optional ByVal oImportance As OlImportance = OlImportance.olImportanceNormal, _
                          Optional ByVal deleteAfterSubmit As Boolean = False, _
                          Optional ByVal readReceiptRequired As Boolean = False, _
                          Optional ByVal deliveryReportRequired As Boolean = False) As Boolean
        Dim isSentOk As Boolean = False
        Dim sTransport As String
        If My.Settings.useSMTP Then
            sTransport = "S"
            isSentOk = SendMailViaSMTP(strToName, strCC, strSubject, strBody, strFilenames, bodyType, _
                                        oFont, strOnBehalfOf, oImportance, deleteAfterSubmit, readReceiptRequired, deliveryReportRequired)
        Else
            sTransport = "O"
            isSentOk = SendMailViaOutlook(strToName, strCC, strSubject, strBody, strFilenames, bodyType, _
                            oFont, strOnBehalfOf, oImportance, deleteAfterSubmit, readReceiptRequired, deliveryReportRequired)
        End If

        'Save the email details unless deleteAfterSubmit (e.g. Password emails)
        'If isSentOk And Not deleteAfterSubmit Then
        '    InsertEmailRecord(strToName, strCC, strSubject, strBody, strFilenames, bodyType, _
        '                    oFont, strOnBehalfOf, oImportance, sTransport)
        'End If
        Return isSentOk
    End Function

    Public Shared Function SendMail(ByVal strToName As String(), _
                      ByVal strCC As String(), _
                      ByVal strSubject As String, _
                      ByVal strBody As String, _
                      ByVal strFilename As String, _
                      Optional ByVal bodyFormat As OlBodyFormat = OlBodyFormat.olFormatPlain, _
                      Optional ByVal strOnBehalfOf As String = "", _
                      Optional ByVal oImportance As OlImportance = OlImportance.olImportanceNormal, _
                      Optional ByVal deleteAfterSubmit As Boolean = False, _
                      Optional ByVal readReceiptRequired As Boolean = False, _
                      Optional ByVal deliveryReportRequired As Boolean = False) As Boolean
        Dim strFilenames As String() = Nothing
        If strFilename IsNot Nothing AndAlso strFilename.Length > 0 Then
            strFilenames = New String() {strFilename}
        Else
            strFilenames = New String() {}
        End If

        Return SendMail(strToName, strCC, strSubject, strBody, strFilenames, bodyFormat, , strOnBehalfOf, oImportance, deleteAfterSubmit, readReceiptRequired, deliveryReportRequired)
    End Function

    Public Shared Function SendMailViaOutlook(ByVal strToName As String(), _
                          ByVal strCC As String(), _
                          ByVal strSubject As String, _
                          ByVal strBody As String, _
                          Optional ByVal strFilenames As String() = Nothing, _
                          Optional ByVal bodyType As Integer = 1, _
                          Optional ByVal oFont As System.Drawing.Font = Nothing, _
                          Optional ByVal strOnBehalfOf As String = "", _
                          Optional ByVal oImportance As OlImportance = OlImportance.olImportanceNormal, _
                          Optional ByVal deleteAfterSubmit As Boolean = False, _
                          Optional ByVal readReceiptRequired As Boolean = False, _
                          Optional ByVal deliveryReportRequired As Boolean = False) As Boolean
        LogUtil.Debug("Sending mail via Outlook", className)
        Dim objOutlookMsg As MailItem
        Dim objOutlookRecip As Recipient
        Dim blnSendOK As Boolean = True
        Dim objOutlook As Application = Nothing
        Dim bodyformat As OlBodyFormat = bodyType

        Try
            If strToName Is Nothing OrElse strToName.Count = 0 Then
                MsgBox("There are no recipients for the email", MsgBoxStyle.Exclamation, "Email error")
                Throw New ApplicationException("No email recipient")
            End If
            If strSubject.Length = 0 Then
                If MsgBox("No email subject. OK to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm email send") = MsgBoxResult.No Then
                    Throw New ApplicationException("Email abandoned - no subject")
                End If
            End If
            If strBody.Length = 0 Then
                If MsgBox("No email text. OK to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm email send") = MsgBoxResult.No Then
                    Throw New ApplicationException("Email abandoned - no body")
                End If
            End If

            '
            ' Get Outlook object
            '
            Try
                If objOutlook Is Nothing Then
                    objOutlook = CreateObject("Outlook.Application")
                    objOutlook.Session.Logon()
                    '==============================================================================
                    'Dim accounts As Outlook.Accounts = objOutlook.Session.Accounts
                    '' Concatenate a message with information about all accounts. 
                    'Dim builder As StringBuilder = New StringBuilder()

                    '' Loop over all accounts and print detail account information. 
                    '' All properties of the Account object are read-only. 
                    'Dim account As Outlook.Account
                    'For Each account In accounts
                    '    ' The DisplayName property represents the friendly name of the account. 
                    '    builder.AppendFormat("DisplayName: {0}" & vbNewLine, account.DisplayName)
                    '    ' The UserName property provides an account-based context to determine identity. 
                    '    builder.AppendFormat("UserName: {0}" & vbNewLine, account.UserName)
                    '    ' The SmtpAddress property provides the SMTP address for the account. 
                    '    builder.AppendFormat("SmtpAddress: {0}" & vbNewLine, account.SmtpAddress)
                    '    ' The AccountType property indicates the type of the account. 
                    '    builder.Append("AccountType: ")
                    '    Select Case (account.AccountType)
                    '        Case Outlook.OlAccountType.olExchange
                    '            builder.AppendLine("Exchange")
                    '        Case Outlook.OlAccountType.olHttp
                    '            builder.AppendLine("Http")
                    '        Case Outlook.OlAccountType.olImap
                    '            builder.AppendLine("Imap")
                    '        Case Outlook.OlAccountType.olOtherAccount
                    '            builder.AppendLine("Other")
                    '        Case Outlook.OlAccountType.olPop3
                    '            builder.AppendLine("Pop3")
                    '    End Select
                    '    builder.AppendLine()
                    'Next
                    'LogUtil.Info(builder.ToString)
                    '==============================================================================
                End If
            Catch ex As System.Exception
                MsgBox("Outlook must be running to send emails." & vbCrLf & _
                       "Start Outlook and try again.", MsgBoxStyle.Critical)
                LogUtil.Exception("Outlook must be running to send emails.", ex, className & ":SendMailViaOutlook", getErrorCode(SystemModule.EMAIL, ErrorType.APPLICATION, FailedAction.EXTERNAL_APP_MUST_BE_RUNNING))
                Return False
            End Try
            ' Create the message.
            objOutlookMsg = objOutlook.CreateItem(OlItemType.olMailItem)
            Dim oFile As Attachment
            With objOutlookMsg
                .Subject = strSubject
                .BodyFormat = bodyformat
                .Importance = oImportance

                .OriginatorDeliveryReportRequested = deliveryReportRequired
                .ReadReceiptRequested = readReceiptRequired

                If bodyformat = OlBodyFormat.olFormatHTML Then
                    convertBodyToHtml(strBody, oFont, objOutlookMsg)
                Else
                    .Body = strBody
                End If

                For Each sToName As String In strToName
                    ' Add the name to the recipients and try to resolve
                    If sToName.Trim.Length > 0 Then
                        objOutlookRecip = .Recipients.Add(sToName.Trim)

                        If Not objOutlookRecip.Resolve() Then
                            blnSendOK = False
                            MsgBox("Cannot recognise the mail recipient " & sToName)
                        End If
                    End If
                Next
                If strCC IsNot Nothing Then
                    For Each sCcName As String In strCC
                        If sCcName.Trim.Length > 0 Then
                            ' Add the name to the recipients and try to resolve
                            objOutlookRecip = .Recipients.Add(sCcName.Trim)
                            objOutlookRecip.Type = OlMailRecipientType.olCC
                            If Not objOutlookRecip.Resolve() Then
                                blnSendOK = False
                                MsgBox("Cannot recognise the mail recipient " & sCcName)
                            End If
                        End If
                    Next
                End If
                '
                ' If there is no file name continue with no attachment
                ' If the file does not exist, throw an exception
                '
                If strFilenames IsNot Nothing Then
                    For Each sFilename As String In strFilenames
                        If sFilename IsNot Nothing Then
                            If My.Computer.FileSystem.FileExists(sFilename) Then
                                oFile = .Attachments.Add(sFilename, OlAttachmentType.olByValue, strBody.Length + 1)
                            Else
                                If MsgBox("Email attachment file " & sFilename & " does not exist." & _
                                          vbCrLf & "OK to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm email send") = MsgBoxResult.No Then
                                    Throw New ApplicationException("Warning: Email attachment file does not exist")
                                End If
                            End If
                        End If
                    Next
                End If

                '===================================
                '               SEND
                '===================================

                .DeleteAfterSubmit = deleteAfterSubmit

                If blnSendOK Then
                    If My.Settings.OutlookAccount.Length > 0 Then
                        Dim accounts As Outlook.Accounts = objOutlook.Session.Accounts
                        For Each account As Outlook.Account In accounts
                            If account.SmtpAddress.ToLower = My.Settings.OutlookAccount.ToLower Then
                                .SendUsingAccount() = account
                                Exit For
                            End If
                        Next
                    End If
                    If String.IsNullOrEmpty(strOnBehalfOf) = False Then
                        .SentOnBehalfOfName = strOnBehalfOf

                    End If
                    .Send()
                End If

            End With
        Catch ex As System.Exception
            blnSendOK = False
            LogUtil.Exception("Email failed", ex, className & ":SendMailViaOutlook", getErrorCode(SystemModule.EMAIL, ErrorType.APPLICATION, FailedAction.EMAIL_FAILED))

        End Try
        objOutlook = Nothing
        Return blnSendOK
    End Function

    '
    ' Sends an email via SMTP
    '    
    Public Shared Function SendMailViaSMTP(ByVal strToName As String(), _
                          ByVal strCC As String(), _
                          ByVal strSubject As String, _
                          ByVal strBody As String, _
                          Optional ByVal strFilenames As String() = Nothing, _
                          Optional ByVal bodyType As Integer = 1, _
                          Optional ByVal oFont As System.Drawing.Font = Nothing, _
                          Optional ByVal strOnBehalfOf As String = "", _
                          Optional ByVal oImportance As OlImportance = OlImportance.olImportanceNormal, _
                          Optional ByVal deleteAfterSubmit As Boolean = False, _
                          Optional ByVal readReceiptRequired As Boolean = False, _
                          Optional ByVal deliveryReportRequired As Boolean = False) As Boolean
        LogUtil.Info("Sending email by SMTP", "SendMailViaSMTP")
        Try
            Dim objMessage As Mail.MailMessage
            Dim objEmailClient As New Mail.SmtpClient
            Dim strToAddress As String = If(strToName.Length > 0, Join(strToName, ","), Nothing)

            objMessage = New Mail.MailMessage(strOnBehalfOf, strToAddress, strSubject, strBody)
            Dim smtpUserName As String = My.Settings.SMTPUsername
            Dim smtpPassword As String = My.Settings.SMTPPassword
            Dim bodyformat As OlBodyFormat = bodyType
            If bodyformat = OlBodyFormat.olFormatHTML Then
                convertBodyToHtml(strBody, oFont, objMessage)
                objMessage.IsBodyHtml = True
            End If

            If oImportance = OlImportance.olImportanceHigh Then
                objMessage.Priority = Mail.MailPriority.High
            End If
            '
            ' Validate the parameters
            '
            Dim strSmtpHost As String = My.Settings.SMTPHost
            If strSmtpHost Is Nothing Or Len(strSmtpHost) = 0 Then
                LogUtil.Info("No smtp host specified")
                Throw New ApplicationException("Error: No Mail Host")
            End If
            If strToAddress Is Nothing Or Len(strToAddress) = 0 Then
                LogUtil.Info("No 'To' email address specified")
                Throw New ApplicationException("Error: No To address")
            End If
            For Each ccAddress As String In strCC
                If String.IsNullOrEmpty(ccAddress) = False Then
                    objMessage.CC.Add(New Mail.MailAddress(ccAddress))
                End If
            Next

            '
            ' If there is no file name or file cannot be found continue with no attachment
            '
            If strFilenames IsNot Nothing AndAlso strFilenames.Length > 0 Then
                For Each strFilename As String In strFilenames
                    If My.Computer.FileSystem.FileExists(strFilename) Then
                        LogUtil.Info("Adding attachment " & strFilename)
                        objMessage.Attachments.Add(New Mail.Attachment(strFilename))
                    Else
                        LogUtil.Info("Cannot find attachment " & strFilename)
                    End If
                Next
            End If

            objMessage.DeliveryNotificationOptions = Mail.DeliveryNotificationOptions.OnFailure
            objMessage.Headers.Add("Return-Receipt-To", strOnBehalfOf)
            ' Asks sending email system to return a delivery receipt
            If deliveryReportRequired Then
                objMessage.DeliveryNotificationOptions = Mail.DeliveryNotificationOptions.OnFailure Or Mail.DeliveryNotificationOptions.Delay Or Mail.DeliveryNotificationOptions.OnSuccess
            End If

            ' Asks recipient to send an acknowledgement
            If readReceiptRequired Then
                objMessage.Headers.Add("Read-Receipt-To", strOnBehalfOf)
                objMessage.Headers.Add("Disposition-Notification-To", strOnBehalfOf)
            End If
            'objMessage.ReplyToList.Add(strOnBehalfOf)
            'Dim replyto As String = GlobalSettings.getSetting("EmailReturnAddress")
            'If replyto.Trim.Length > 0 Then
            '    objMessage.ReplyToList.Add(replyto)
            'End If
            '
            ' Connect to the host
            '
            objEmailClient.Host = strSmtpHost
            If My.Settings.SMTPRequiresCredentials Then
                objEmailClient.Credentials = New NetworkCredential(smtpUserName, smtpPassword)
            End If

            Dim strSmtpPort As Integer = My.Settings.SMTPPort
            If strSmtpPort > 0 Then
                objEmailClient.Port = strSmtpPort
            End If

            If My.Settings.SMTPEnableSSL Then
                objEmailClient.EnableSsl = True
            End If
            '
            ' Send the email
            '
            objEmailClient.Send(objMessage)

            objMessage.Dispose()
            objMessage = Nothing
            objEmailClient = Nothing

            Return True

        Catch mailex As Mail.SmtpFailedRecipientsException
            LogUtil.Info("SmtpFailedRecipientsException occurred sending email : " & mailex.Message, "SendMailViaSMTP")
            Return False
        Catch ex As ApplicationException
            LogUtil.Info("ApplicationException occurred sending email : " & ex.Message, "SendMailViaSMTP")
            Return False
        Catch ex1 As System.Exception
            LogUtil.Info("Exception occurred sending email : " & ex1.Message, "SendMailViaSMTP")
            Return False
        End Try
        Return False
    End Function

    Private Shared Sub convertBodyToHtml(ByVal strBody As String, ByVal oFont As Font, ByRef objOutlookMsg As Microsoft.Office.Interop.Outlook.MailItem)
        Dim attachlist As ArrayList = convertToHtml(strBody, oFont)
        With objOutlookMsg
            .HTMLBody = strBody
            '========= add image in the body ===========
            ' add image as an attachment
            For Each strImageFile As String In attachlist
                .Attachments.Add(strImageFile)
            Next
        End With
    End Sub

    Private Shared Sub convertBodyToHtml(ByVal strBody As String, ByVal oFont As Font, ByRef objMessage As Mail.MailMessage)
        Dim attachlist As ArrayList = convertToHtml(strBody, oFont)
        With objMessage
            .Body = strBody
            For Each strImageFile As String In attachlist
                ' Create  the file attachment for this e-mail message.
                Dim data As New Mail.Attachment(strImageFile, MediaTypeNames.Application.Octet)
                .Attachments.Add(data)
            Next
        End With
    End Sub

    Private Shared Function convertToHtml(ByRef strBody As String, ByVal oFont As Font) As ArrayList
        Dim attachList As New ArrayList
        If oFont IsNot Nothing Then
            strBody = "<span style='font-size:" & oFont.SizeInPoints & "pt;font-family:""" & oFont.Name & """;color:black'>" & _
            strBody & "</span>"
        End If
        strBody = strBody.Replace(vbCrLf, "<br />")
        '========= add image in the body ===========
        ' add image as an attachment
        ' include a tag inside the body HTML to pick up the image
        Do While True
            Dim iImgSt As Integer = strBody.IndexOf("{img:")
            If iImgSt > -1 Then
                Dim iImgEnd = strBody.IndexOf("}", iImgSt + 5)
                Dim strImageFile As String = strBody.Substring(iImgSt + 5, iImgEnd - iImgSt - 5)
                Dim sImage As String = Path.GetFileName(strImageFile)
                If My.Computer.FileSystem.FileExists(strImageFile) Then
                    attachList.Add(strImageFile)

                    strBody = strBody.Substring(0, iImgSt) & _
                           "<IMG alt='' hspace=0 src='cid:" & sImage & "' align=baseline border=0>&nbsp;" & _
                    strBody.Substring(iImgEnd + 1)
                Else
                    If MsgBox("Image " & sImage & " not found. OK to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm email send") = MsgBoxResult.No Then
                        Throw New ApplicationException("Email abandoned - missing image")
                    End If

                    strBody = strBody.Substring(0, iImgSt) & _
                    strBody.Substring(iImgEnd + 1)
                End If
            Else
                Exit Do
            End If
        Loop
        '=========

        Return attachList
    End Function

    'Public Shared Function buildEmailAddressListFromDistributionGroup(ByVal distGrpId As Integer, ByVal TorC As String) As ArrayList
    '    Dim emailList As New ArrayList
    '    oRecipientTa = New netwyrksDataSetTableAdapters.recipientTableAdapter
    '    oMemberTa = New netwyrksDataSetTableAdapters.distribution_group_membersTableAdapter
    '    emailList.AddRange(addDistributionGroupMembers(distGrpId, TorC))
    '    oMemberTa.Dispose()
    '    oRecipientTa.Dispose()
    '    Return emailList
    'End Function

    'Private Shared Function addDistributionGroupMembers(ByVal distGrpId As Integer, ByVal TorC As String) As ArrayList
    '    Dim emailList As New ArrayList
    '    Dim oRecipientTable As New netwyrksDataSet.recipientDataTable
    '    Dim oMemberTable As New netwyrksDataSet.distribution_group_membersDataTable
    '    '       oMemberTa = New netwyrksDataSetTableAdapters.distribution_group_membersTableAdapter
    '    oRecipientTable = New netwyrksDataSet.recipientDataTable
    '    If oMemberTa.FillByGroupId(oMemberTable, distGrpId) > 0 Then
    '        For Each oRow As netwyrksDataSet.distribution_group_membersRow In oMemberTable.Rows
    '            If oRow.member_type = "R" Then
    '                If oRow.distribution_type = TorC Or TorC = "*" Then
    '                    If oRecipientTa.FillById(oRecipientTable, oRow.member_id) = 1 Then
    '                        Dim rRow As netwyrksDataSet.recipientRow = oRecipientTable.Rows(0)
    '                        If rRow.recipient_firstname = "" And rRow.recipient_lastname = "" Then
    '                            emailList.Add(rRow.recipient_email_address)
    '                        Else
    '                            Dim sname As String = Trim(rRow.recipient_firstname & " " & rRow.recipient_lastname)
    '                            emailList.Add(sname & " <" & rRow.recipient_email_address & ">")
    '                        End If
    '                    End If
    '                End If
    '            Else
    '                emailList.AddRange(addDistributionGroupMembers(oRow.member_id, TorC))
    '            End If
    '        Next
    '    End If
    '    oMemberTable.Dispose()
    '    oRecipientTable.Dispose()
    '    Return emailList
    'End Function
    'Private Shared Sub InsertEmailRecord(ByVal strToName As String(), _
    '                                        ByVal strCC As String(), _
    '                                        ByVal strSubject As String, _
    '                                        ByVal strBody As String, _
    '                                        ByVal strFilenames As String(), _
    '                                        ByVal bodyType As Integer, _
    '                                        ByVal oFont As System.Drawing.Font, _
    '                                        ByVal strOnBehalfOf As String, _
    '                                        ByVal oImportance As OlImportance, _
    '                                        ByVal transport As String)
    '    LogUtil.Info("Saving email record", "InsertEmailRecord")
    '    Dim myIdentity As netwyrksIIdentity = My.User.CurrentPrincipal.Identity
    '    Dim userCode As String = myIdentity.usercode
    '    Dim aFormat As String() = {"U", "T", "H"}
    '    Dim aImportance As String() = {"L", "N", "H"}
    '    Dim sAttachments As String = Join(strFilenames, " ; ")
    '    Dim sTo As String = Join(strToName, " ; ")
    '    Dim sCc As String = Join(strCC, " ; ")
    '    If String.IsNullOrEmpty(strOnBehalfOf) Then
    '        strOnBehalfOf = sOutlookSender
    '    End If
    '    oEmailTa.InsertEmail(strOnBehalfOf, EncryptionUtil.encryptText(sTo), EncryptionUtil.encryptText(sCc), EncryptionUtil.encryptText(strSubject), EncryptionUtil.encryptText(strBody), Now, sAttachments, transport, aFormat(bodyType), aImportance(oImportance), userCode)
    'End Sub

    Public Shared Function MakeEmailAddressList(ByVal sAddresses As String) As String()
        Return Split(sAddresses.Replace(" ", "").Replace(",", ";"), ";")
    End Function

    Public Shared Function getEmailsenders() As String()
        Dim aSenders As String()
        Try
            Dim _outlookSender As String = CheckOutlookSender()
            Dim globalSenders As String = GlobalSettings.getSetting("EmailSenders")
            If String.IsNullOrEmpty(_outlookSender) Then
                My.Settings.useSMTP = True
                aSenders = Split(globalSenders, ";")
            Else
                If globalSenders = "" Then
                    aSenders = New String() {_outlookSender}
                Else
                    aSenders = Split(GlobalSettings.getSetting("EmailSenders") & ";" & _outlookSender, ";")
                End If
            End If
        Catch ex As System.Exception
            LogUtil.Exception("Exception while getting email senders", ex, "getEmailsenders")
            aSenders = New String() {""}
        End Try
        Return aSenders
    End Function

End Class
