<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerMaint
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomerMaint))
        Me.pnlCustomer = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rtbCustNotes = New System.Windows.Forms.RichTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudCustDiscount = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCustEmail = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCustPhone = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCustPostcode = New System.Windows.Forms.TextBox()
        Me.txtCustAddr4 = New System.Windows.Forms.TextBox()
        Me.txtCustAddr3 = New System.Windows.Forms.TextBox()
        Me.txtCustAddr2 = New System.Windows.Forms.TextBox()
        Me.txtCustAddr1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCustName = New System.Windows.Forms.TextBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlJobs = New System.Windows.Forms.Panel()
        Me.chkCompleted = New System.Windows.Forms.CheckBox()
        Me.btnAddJob = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgvJobs = New System.Windows.Forms.DataGridView()
        Me.jobId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jobName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jobCompleted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.nudDays = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlCustomer.SuspendLayout()
        CType(Me.nudCustDiscount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlJobs.SuspendLayout()
        CType(Me.dgvJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.nudDays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCustomer
        '
        Me.pnlCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlCustomer.Controls.Add(Me.Label10)
        Me.pnlCustomer.Controls.Add(Me.Label9)
        Me.pnlCustomer.Controls.Add(Me.nudDays)
        Me.pnlCustomer.Controls.Add(Me.Label7)
        Me.pnlCustomer.Controls.Add(Me.rtbCustNotes)
        Me.pnlCustomer.Controls.Add(Me.Label6)
        Me.pnlCustomer.Controls.Add(Me.nudCustDiscount)
        Me.pnlCustomer.Controls.Add(Me.Label5)
        Me.pnlCustomer.Controls.Add(Me.txtCustEmail)
        Me.pnlCustomer.Controls.Add(Me.Label4)
        Me.pnlCustomer.Controls.Add(Me.txtCustPhone)
        Me.pnlCustomer.Controls.Add(Me.Label3)
        Me.pnlCustomer.Controls.Add(Me.Label2)
        Me.pnlCustomer.Controls.Add(Me.txtCustPostcode)
        Me.pnlCustomer.Controls.Add(Me.txtCustAddr4)
        Me.pnlCustomer.Controls.Add(Me.txtCustAddr3)
        Me.pnlCustomer.Controls.Add(Me.txtCustAddr2)
        Me.pnlCustomer.Controls.Add(Me.txtCustAddr1)
        Me.pnlCustomer.Controls.Add(Me.Label1)
        Me.pnlCustomer.Controls.Add(Me.txtCustName)
        Me.pnlCustomer.Location = New System.Drawing.Point(12, 60)
        Me.pnlCustomer.Name = "pnlCustomer"
        Me.pnlCustomer.Size = New System.Drawing.Size(516, 505)
        Me.pnlCustomer.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 339)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Notes"
        '
        'rtbCustNotes
        '
        Me.rtbCustNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbCustNotes.Location = New System.Drawing.Point(112, 336)
        Me.rtbCustNotes.Name = "rtbCustNotes"
        Me.rtbCustNotes.Size = New System.Drawing.Size(401, 160)
        Me.rtbCustNotes.TabIndex = 10
        Me.rtbCustNotes.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 302)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 17)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Discount %"
        '
        'nudCustDiscount
        '
        Me.nudCustDiscount.DecimalPlaces = 2
        Me.nudCustDiscount.Location = New System.Drawing.Point(112, 300)
        Me.nudCustDiscount.Name = "nudCustDiscount"
        Me.nudCustDiscount.Size = New System.Drawing.Size(120, 24)
        Me.nudCustDiscount.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "eMail"
        '
        'txtCustEmail
        '
        Me.txtCustEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustEmail.Location = New System.Drawing.Point(112, 248)
        Me.txtCustEmail.Name = "txtCustEmail"
        Me.txtCustEmail.Size = New System.Drawing.Size(300, 24)
        Me.txtCustEmail.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Phone"
        '
        'txtCustPhone
        '
        Me.txtCustPhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustPhone.Location = New System.Drawing.Point(112, 219)
        Me.txtCustPhone.Name = "txtCustPhone"
        Me.txtCustPhone.Size = New System.Drawing.Size(300, 24)
        Me.txtCustPhone.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Postcode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Address"
        '
        'txtCustPostcode
        '
        Me.txtCustPostcode.Location = New System.Drawing.Point(112, 175)
        Me.txtCustPostcode.Name = "txtCustPostcode"
        Me.txtCustPostcode.Size = New System.Drawing.Size(158, 24)
        Me.txtCustPostcode.TabIndex = 5
        '
        'txtCustAddr4
        '
        Me.txtCustAddr4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustAddr4.Location = New System.Drawing.Point(112, 145)
        Me.txtCustAddr4.Name = "txtCustAddr4"
        Me.txtCustAddr4.Size = New System.Drawing.Size(300, 24)
        Me.txtCustAddr4.TabIndex = 4
        '
        'txtCustAddr3
        '
        Me.txtCustAddr3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustAddr3.Location = New System.Drawing.Point(112, 115)
        Me.txtCustAddr3.Name = "txtCustAddr3"
        Me.txtCustAddr3.Size = New System.Drawing.Size(300, 24)
        Me.txtCustAddr3.TabIndex = 3
        '
        'txtCustAddr2
        '
        Me.txtCustAddr2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustAddr2.Location = New System.Drawing.Point(112, 86)
        Me.txtCustAddr2.Name = "txtCustAddr2"
        Me.txtCustAddr2.Size = New System.Drawing.Size(300, 24)
        Me.txtCustAddr2.TabIndex = 2
        '
        'txtCustAddr1
        '
        Me.txtCustAddr1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustAddr1.Location = New System.Drawing.Point(112, 57)
        Me.txtCustAddr1.Name = "txtCustAddr1"
        Me.txtCustAddr1.Size = New System.Drawing.Size(300, 24)
        Me.txtCustAddr1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Name"
        '
        'txtCustName
        '
        Me.txtCustName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustName.Location = New System.Drawing.Point(112, 16)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Size = New System.Drawing.Size(401, 27)
        Me.txtCustName.TabIndex = 0
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Location = New System.Drawing.Point(13, 572)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(117, 43)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(408, 572)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(117, 43)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'pnlJobs
        '
        Me.pnlJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlJobs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlJobs.Controls.Add(Me.chkCompleted)
        Me.pnlJobs.Controls.Add(Me.btnAddJob)
        Me.pnlJobs.Controls.Add(Me.Label8)
        Me.pnlJobs.Controls.Add(Me.dgvJobs)
        Me.pnlJobs.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlJobs.Location = New System.Drawing.Point(534, 49)
        Me.pnlJobs.Name = "pnlJobs"
        Me.pnlJobs.Size = New System.Drawing.Size(405, 516)
        Me.pnlJobs.TabIndex = 1
        '
        'chkCompleted
        '
        Me.chkCompleted.AutoSize = True
        Me.chkCompleted.Location = New System.Drawing.Point(6, 483)
        Me.chkCompleted.Name = "chkCompleted"
        Me.chkCompleted.Size = New System.Drawing.Size(145, 18)
        Me.chkCompleted.TabIndex = 3
        Me.chkCompleted.Text = "Show completed jobs"
        Me.chkCompleted.UseVisualStyleBackColor = True
        '
        'btnAddJob
        '
        Me.btnAddJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddJob.Location = New System.Drawing.Point(296, 476)
        Me.btnAddJob.Name = "btnAddJob"
        Me.btnAddJob.Size = New System.Drawing.Size(95, 31)
        Me.btnAddJob.TabIndex = 0
        Me.btnAddJob.Text = "Add Job"
        Me.btnAddJob.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 14)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Jobs"
        '
        'dgvJobs
        '
        Me.dgvJobs.AllowUserToAddRows = False
        Me.dgvJobs.AllowUserToDeleteRows = False
        Me.dgvJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvJobs.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvJobs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJobs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.jobId, Me.jobName, Me.jobCompleted})
        Me.dgvJobs.Location = New System.Drawing.Point(6, 27)
        Me.dgvJobs.Name = "dgvJobs"
        Me.dgvJobs.ReadOnly = True
        Me.dgvJobs.RowHeadersVisible = False
        Me.dgvJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJobs.Size = New System.Drawing.Size(394, 436)
        Me.dgvJobs.TabIndex = 2
        '
        'jobId
        '
        Me.jobId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.jobId.HeaderText = "Id"
        Me.jobId.Name = "jobId"
        Me.jobId.ReadOnly = True
        Me.jobId.Visible = False
        Me.jobId.Width = 50
        '
        'jobName
        '
        Me.jobName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.jobName.HeaderText = "Name"
        Me.jobName.Name = "jobName"
        Me.jobName.ReadOnly = True
        '
        'jobCompleted
        '
        Me.jobCompleted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.jobCompleted.HeaderText = "Completed"
        Me.jobCompleted.Name = "jobCompleted"
        Me.jobCompleted.ReadOnly = True
        Me.jobCompleted.Width = 80
        '
        'lblScreenName
        '
        Me.lblScreenName.AutoSize = True
        Me.lblScreenName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenName.ForeColor = System.Drawing.Color.Black
        Me.lblScreenName.Location = New System.Drawing.Point(60, 12)
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(136, 25)
        Me.lblScreenName.TabIndex = 5
        Me.lblScreenName.Text = "Customer"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(42, 42)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 67
        Me.PictureBox1.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 627)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(951, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.lblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblStatus.Size = New System.Drawing.Size(7, 17)
        '
        'nudDays
        '
        Me.nudDays.Location = New System.Drawing.Point(345, 300)
        Me.nudDays.Name = "nudDays"
        Me.nudDays.Size = New System.Drawing.Size(67, 24)
        Me.nudDays.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(292, 302)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 17)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Terms"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(418, 302)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 17)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "days"
        '
        'frmCustomerMaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(951, 649)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblScreenName)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.pnlJobs)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.pnlCustomer)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmCustomerMaint"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.pnlCustomer.ResumeLayout(False)
        Me.pnlCustomer.PerformLayout()
        CType(Me.nudCustDiscount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlJobs.ResumeLayout(False)
        Me.pnlJobs.PerformLayout()
        CType(Me.dgvJobs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.nudDays, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlCustomer As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents rtbCustNotes As RichTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents nudCustDiscount As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCustEmail As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCustPhone As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCustPostcode As TextBox
    Friend WithEvents txtCustAddr4 As TextBox
    Friend WithEvents txtCustAddr3 As TextBox
    Friend WithEvents txtCustAddr2 As TextBox
    Friend WithEvents txtCustAddr1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCustName As TextBox
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents pnlJobs As Panel
    Friend WithEvents dgvJobs As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblScreenName As Label
    Friend WithEvents btnAddJob As Button
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chkCompleted As System.Windows.Forms.CheckBox
    Friend WithEvents jobId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jobName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jobCompleted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents nudDays As NumericUpDown
End Class
