﻿' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle

''' <summary>
''' Module access codes
''' </summary>
''' <remarks></remarks>
Public Module ModuleCodes
#Region "security"
    Public Const ADMIN_MOD_CD As String = "ADMIN"
    Public Const RESET_PASSWORD_MOD_CD As String = "PWDRES"
    Public Const VIEW_AUDIT_MOD_CD As String = "AUDDSP"
    Public Const ARCHIVE_AUDIT_MOD_CD As String = "AUDARC"
    Public Const USERS_MOD_CD As String = "USR"
    Public Const USER_ACCESS_MOD_CD As String = "USRACC"
    Public Const SYSTEM_MODULES_MOD_CD As String = "SYSMOD"
    Public Const ACTIVE_USERS_MOD_CD As String = "ACTUSR"
    Public Const INSTALLATION_TEST_MOD_CD As String = "INSTST"
    Public Const DEVELOPER_MOD_CD As String = "DEVMNU"
#End Region
#Region "files"
    Public Const FILES_MOD_CD As String = "FILMNU"
    Public Const FILES_REPORT_FOLDER_MOD_CD As String = "FILREP"
    Public Const FILES_SHARED_FOLDER_MOD_CD As String = "FILSHA"
    Public Const FILES_IMAGE_FOLDER_MOD_CD As String = "FILIMG"
#End Region
#Region "reference tables"
    Public Const REFERENCE_MENU_MOD_CD As String = "REFMNU"
    Public Const OPERATOR_MENU_MOD_CD As String = "OPRMNU"
    Public Const OPERATOR_UPDATE_MOD_CD As String = "OPRUPD"
    Public Const OPERATOR_MERGE_MOD_CD As String = "OPRMRG"
    Public Const OPERATOR_CLOSE_MOD_CD As String = "OPRCLO"
    Public Const SHOP_MENU_MOD_CD As String = "SHPMNU"
    Public Const SHOP_UPDATE_MOD_CD As String = "SHPUPD"
    Public Const SHOP_IMPORT_MOD_CD As String = "SHPIMP"
    Public Const SHOP_SEARCH_MOD_CD As String = "SHPLST"
    Public Const SHOP_MERGE_MOD_CD As String = "SHPMRG"
    Public Const GENDER_TYPE_MOD_CD As String = "GENTYP"
    Public Const INCIDENT_TYPE_MOD_CD As String = "INCTYP"
    Public Const CUSTOMER_FACT_MOD_CD As String = "CUSFAC"
    Public Const LOYALTY_SCHEME_MOD_CD As String = "LOYSCH"
    Public Const ACCOUNT_TYPE_MOD_CD As String = "ACCTYP"
    Public Const POINT_OF_CONTACT_MOD_CD As String = "POCMNT"
    Public Const LBO_CREATE_MOD_CD As String = "LBOCRT"
#End Region
#Region "customers"
    Public Const CUSTOMERS_MOD_CD As String = "CUSMNU"
    Public Const CUSTOMER_CALL_MOD_CD As String = "CUSCAL"
    Public Const CUSTOMER_MAINT_MOD_CD As String = "CUSMNT"
    Public Const CUSTOMER_INSERT_MOD_CD As String = "CUSADD"
    Public Const CUSTOMER_UPDATE_MOD_CD As String = "CUSUPD"
    Public Const CUSTOMER_STATUS_MOD_CD As String = "CUSSTS"
    Public Const CUSTOMER_REOPEN_MOD_CD As String = "CUSOPN"
    Public Const CUSTOMER_VIEW_MOD_CD As String = "CUSVEW"

    Public Const CUSTOMER_ACCOUNTS_MOD_CD As String = "CUSACC"
    Public Const ACCOUNT_INSERT_MOD_CD As String = "ACCINS"
    Public Const ACCOUNT_UPDATE_MOD_CD As String = "ACCUPD"
    Public Const ACCOUNT_DELETE_MOD_CD As String = "ACCDEL"

    Public Const LOYALTY_SCHEME_MEMBERSHIP_MOD_CD As String = "LOYMEM"
    Public Const LOYALTY_INSERT_MOD_CD As String = "LOYINS"
    Public Const LOYALTY_UPDATE_MOD_CD As String = "LOYUPD"
    Public Const LOYALTY_DELETE_MOD_CD As String = "LOYDEL"
#End Region
#Region "exclusions"
    Public Const EXCLUSIONS_MOD_CD As String = "EXCLUS"
    Public Const EXCLUSION_INSERT_MOD_CD As String = "EXCADD"
    Public Const EXCLUSION_UPDATE_MOD_CD As String = "EXCUPD"
    Public Const EXCLUSION_REVIEW_MOD_CD As String = "EXCREV"
    Public Const EXCLUSION_DEACTIVATE_MOD_CD As String = "EXCDEA"
    Public Const EXCLUSION_NOTIFY_MOD_CD As String = "EXCNTF"
    Public Const EXCLUSION_MAINT_MOD_CD As String = "EXCMNT"
    Public Const EXCLUSION_VIEW_MOD_CD As String = "EXCVEW"
#End Region
#Region "incidents"
    Public Const INCIDENTS_MENU_MOD_CD As String = "INCMNU"
    Public Const INCIDENT_INSERT_MOD_CD As String = "INCADD"
    Public Const INCIDENT_UPDATE_MOD_CD As String = "INCUPD"
    Public Const INCIDENT_DELETE_MOD_CD As String = "INCDEL"
    Public Const INCIDENT_CONFIRM_MOD_CD As String = "INCCNF"
    Public Const INCIDENT_NOTIFY_MOD_CD As String = "INCNTF"
    Public Const INCIDENT_MAINT_MOD_CD As String = "INCMNT"
#End Region
#Region "email"
    Public Const EMAIL_MENU_MOD_CD As String = "EMLMNU"
    Public Const EMAIL_TEMPLATES_MOD_CD As String = "EMLTMP"
    Public Const EMAIL_DISTRIBUTION_MOD_CD As String = "EMLDST"
    Public Const DISTRIBUTION_GROUP_MOD_CD As String = "DSTGRP"
    Public Const DISTRIBUTION_RECIP_MOD_CD As String = "DSTREC"
    Public Const DISTRIBUTION_MEMB_MOD_CD As String = "DSTMEM"
    Public Const EMAIL_EDIT_MOD_CD As String = "EMLEDT"
    Public Const EMAIL_TEST_MOD_CD As String = "EMLTST"
    Public Const EMAIL_ARCHIVE_MOD_CD As String = "EMLARC"
    Public Const EMAIL_DELETE_MOD_CD As String = "EMLDEL"
    Public Const EMAIL_OUTBOX_MOD_CD As String = "EMLOUT"
#End Region
#Region "images"
    Public Const IMAGES_MENU_MOD_CD As String = "IMGMNU"
    Public Const IMAGE_CAPTURE_MOD_CD As String = "IMGCAP"
    Public Const IMAGE_VIEWER_MOD_CD As String = "IMGVWR"
#End Region
#Region "templates"
    Public Const NOTE_TEMPLATES_MOD_CD As String = "NTTMPL"
#End Region
#Region "reports"
    Public Const REPORTS_MENU_MOD_CD As String = "REPMNU"
    Public Const REPORT_SHOP_AUDIT_MOD_CD As String = "REPAUD"
    Public Const REPORT_BREACH_AUDIT_MOD_CD As String = "REPBAU"
    Public Const REPORT_BREACHES_MOD_CD As String = "REPBRE"
    Public Const REPORT_ALL_BREACHES_MOD_CD As String = "REPBR1"
    Public Const REPORT_BREACHES_ENTERED_MOD_CD As String = "REPBR2"
    Public Const REPORT_BREACHES_GAMBLED_MOD_CD As String = "REPBR3"
    Public Const REPORT_EXCLUSIONS_MOD_CD As String = "REPEXC"
    Public Const REPORT_ALL_EXCLUSIONS_MOD_CD As String = "REPEX1"
    Public Const REPORT_EXCLUSIONS_CREATED_MOD_CD As String = "REPEX2"
    Public Const REPORT_EXCLUSIONS_STARTED_MOD_CD As String = "REPEX3"
    Public Const REPORT_EXCLUSIONS_BY_STATUS_MOD_CD As String = "REPEX4"
    Public Const REPORT_STATISTICS_MOD_CD As String = "REPWK1"
    Public Const REPORT_CUSTOMER_LIST_MOD_CD As String = "REPCUS"
    Public Const REPORT_CLOSED_CUSTOMER_LIST_MOD_CD As String = "REPCU1"
    Public Const REPORT_CUSTOMER_LIST2_MOD_CD As String = "REPCU2"
    Public Const REPORT_CONTACT_CUSTOMER_LIST_MOD_CD As String = "REPCU3"
    Public Const REPORT_SERS_QUERY_MOD_CD As String = "REPQRY"
    Public Const ACCESS_LEVEL1_MOD_CD As String = "REPLV1"
    Public Const ACCESS_LEVEL2_MOD_CD As String = "REPLV2"
    Public Const ACCESS_LEVEL3_MOD_CD As String = "REPLV3"
    Public Const REPORT_EXCLUSIONS_PREMISES_MOD_CD As String = "REPEXP"
    Public Const REPORT_CALL_LOG_MOD_CD As String = "REPCLG"
    Public Const REPORT_VERSION_MENU_MOD_CD As String = "VERMNU"
    Public Const REPORT_VERSION_HISTORY_MOD_CD As String = "REPVHI"
    Public Const REPORT_VERSION_CUST_SUMMARY_MOD_CD As String = "REPVCS"
    Public Const REPORT_VERSION_CUST_DETAIL_MOD_CD As String = "REPVCD"
    Public Const REPORT_ADMIN_MENU_MOD_CD As String = "REPADM"
    Public Const REPORT_ADMIN_EXCEPTION_REPORT_MOD_CD As String = "REPAD1"
    Public Const REPORT_ADMIN_OPERATOR_LIST_MOD_CD As String = "REPAD2"

#End Region
#Region "functions"
    Public Const DIARY_MOD_CD As String = "DIARY"
    Public Const DIARY_ALL_MOD_CD As String = "DIAALL"
    Public Const MAPPING_MOD_CD As String = "MAPPNG"
    Public Const GLOBAL_SETTINGS_MOD_CD As String = "GLOSET"
    Public Const CALL_LOG_MOD_CD As String = "CALLOG"
    Public Const CALL_LOG_DELETE_MOD_CD As String = "CALDEL"
#End Region
End Module
