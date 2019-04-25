'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.Windows.Forms

Public Class frmDateRange

    Private _dateFrom As Date
    Private _dateTo As Date

    Public Property DateTo() As Date
        Get
            Return _dateTo
        End Get
        Set(ByVal value As Date)
            _dateTo = value
        End Set
    End Property

    Public Property DateFrom() As Date
        Get
            Return _dateFrom
        End Get
        Set(ByVal value As Date)
            _dateFrom = value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        _dateFrom = dtpFrom.Value
        _dateTo = dtpTo.Value

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmDateRange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboDateRange.DataSource = PeriodDescriptions
        If _dateFrom = Date.MinValue Then
            _dateFrom = Today.Date
        End If
        If _dateTo = Date.MinValue Then
            _dateTo = Today.Date
        End If
        dtpFrom.Value = _dateFrom
        dtpTo.Value = _dateTo
    End Sub

    Private Sub cboDateRange_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDateRange.SelectedIndexChanged
        Dim oRange As DateRange = setDateRange(cboDateRange.SelectedIndex)
        dtpFrom.Value = oRange.fromDate
        dtpTo.Value = oRange.toDate
    End Sub

End Class
