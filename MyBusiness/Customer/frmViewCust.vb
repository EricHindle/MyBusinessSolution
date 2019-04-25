Public Class frmViewCust

    Private _customer As Customer
    Public Property theCustomer() As Customer
        Get
            Return _customer
        End Get
        Set(ByVal value As Customer)
            _customer = value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmViewCust_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closing", Me.Name)
    End Sub

    Private Sub frmViewCust_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCustAddr1.Text = _customer.address.address1
        txtCustAddr2.Text = _customer.address.address2
        txtCustAddr3.Text = _customer.address.address3
        txtCustAddr4.Text = _customer.address.address4
        txtCustEmail.Text = _customer.email
        txtCustName.Text = _customer.custName
        txtCustPhone.Text = _customer.Phone
        txtCustPostcode.Text = _customer.address.postcode
        rtbCustNotes.Text = _customer.notes

    End Sub
End Class