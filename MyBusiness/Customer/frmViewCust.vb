' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Public Class FrmViewCust
#Region "variables"
    Private _customer As Customer
#End Region
#Region "properties"
    Public Property TheCustomer() As Customer
        Get
            Return _customer
        End Get
        Set(ByVal value As Customer)
            _customer = value
        End Set
    End Property
#End Region
#Region "form handlers"
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub FrmViewCust_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closing", Me.Name)
    End Sub
    Private Sub FrmViewCust_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCustAddr1.Text = _customer.Address.Address1
        txtCustAddr2.Text = _customer.Address.Address2
        txtCustAddr3.Text = _customer.Address.Address3
        txtCustAddr4.Text = _customer.Address.Address4
        txtCustEmail.Text = _customer.Email
        txtCustName.Text = _customer.CustName
        txtCustPhone.Text = _customer.Phone
        txtCustPostcode.Text = _customer.Address.Postcode
        rtbCustNotes.Text = _customer.Notes
    End Sub
#End Region
End Class