<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomerMaint
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCustomerMaint))
        Me.pnlCustomer = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nudDays = New System.Windows.Forms.NumericUpDown()
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
        Me.pnlJobs = New System.Windows.Forms.Panel()
        Me.PicAddJob = New System.Windows.Forms.PictureBox()
        Me.ChkCompleted = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DgvJobs = New System.Windows.Forms.DataGridView()
        Me.jobId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jobName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jobCompleted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ScCustomer = New System.Windows.Forms.SplitContainer()
        Me.picDiary = New System.Windows.Forms.PictureBox()
        Me.PicUpdate = New System.Windows.Forms.PictureBox()
        Me.PicClose = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LblAction = New System.Windows.Forms.Label()
        Me.pnlCustomer.SuspendLayout()
        CType(Me.nudDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCustDiscount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlJobs.SuspendLayout()
        CType(Me.PicAddJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ScCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ScCustomer.Panel1.SuspendLayout()
        Me.ScCustomer.Panel2.SuspendLayout()
        Me.ScCustomer.SuspendLayout()
        CType(Me.picDiary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCustomer
        '
        Me.pnlCustomer.BackColor = System.Drawing.Color.FloralWhite
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
        Me.pnlCustomer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCustomer.Location = New System.Drawing.Point(0, 0)
        Me.pnlCustomer.Name = "pnlCustomer"
        Me.pnlCustomer.Size = New System.Drawing.Size(501, 416)
        Me.pnlCustomer.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(391, 302)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 17)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "days"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(265, 302)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 17)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Terms"
        '
        'nudDays
        '
        Me.nudDays.Location = New System.Drawing.Point(318, 298)
        Me.nudDays.Name = "nudDays"
        Me.nudDays.Size = New System.Drawing.Size(67, 24)
        Me.nudDays.TabIndex = 9
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
        Me.rtbCustNotes.Size = New System.Drawing.Size(386, 71)
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
        Me.nudCustDiscount.Location = New System.Drawing.Point(112, 298)
        Me.nudCustDiscount.Name = "nudCustDiscount"
        Me.nudCustDiscount.Size = New System.Drawing.Size(120, 24)
        Me.nudCustDiscount.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.nudCustDiscount, "Percentage discount applied the job price")
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
        Me.txtCustEmail.Size = New System.Drawing.Size(285, 24)
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
        Me.txtCustPhone.Size = New System.Drawing.Size(285, 24)
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
        Me.txtCustAddr4.Size = New System.Drawing.Size(285, 24)
        Me.txtCustAddr4.TabIndex = 4
        '
        'txtCustAddr3
        '
        Me.txtCustAddr3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustAddr3.Location = New System.Drawing.Point(112, 115)
        Me.txtCustAddr3.Name = "txtCustAddr3"
        Me.txtCustAddr3.Size = New System.Drawing.Size(285, 24)
        Me.txtCustAddr3.TabIndex = 3
        '
        'txtCustAddr2
        '
        Me.txtCustAddr2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustAddr2.Location = New System.Drawing.Point(112, 86)
        Me.txtCustAddr2.Name = "txtCustAddr2"
        Me.txtCustAddr2.Size = New System.Drawing.Size(285, 24)
        Me.txtCustAddr2.TabIndex = 2
        '
        'txtCustAddr1
        '
        Me.txtCustAddr1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustAddr1.Location = New System.Drawing.Point(112, 57)
        Me.txtCustAddr1.Name = "txtCustAddr1"
        Me.txtCustAddr1.Size = New System.Drawing.Size(285, 24)
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
        Me.txtCustName.Size = New System.Drawing.Size(386, 27)
        Me.txtCustName.TabIndex = 0
        '
        'pnlJobs
        '
        Me.pnlJobs.BackColor = System.Drawing.Color.FloralWhite
        Me.pnlJobs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlJobs.Controls.Add(Me.PicAddJob)
        Me.pnlJobs.Controls.Add(Me.ChkCompleted)
        Me.pnlJobs.Controls.Add(Me.Label8)
        Me.pnlJobs.Controls.Add(Me.DgvJobs)
        Me.pnlJobs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlJobs.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlJobs.Location = New System.Drawing.Point(0, 0)
        Me.pnlJobs.Name = "pnlJobs"
        Me.pnlJobs.Size = New System.Drawing.Size(404, 416)
        Me.pnlJobs.TabIndex = 1
        '
        'PicAddJob
        '
        Me.PicAddJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicAddJob.Image = Global.MyBusiness.My.Resources.Resources.addany
        Me.PicAddJob.InitialImage = Nothing
        Me.PicAddJob.Location = New System.Drawing.Point(3, 387)
        Me.PicAddJob.Name = "PicAddJob"
        Me.PicAddJob.Size = New System.Drawing.Size(24, 24)
        Me.PicAddJob.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicAddJob.TabIndex = 96
        Me.PicAddJob.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicAddJob, "Add a new job")
        '
        'ChkCompleted
        '
        Me.ChkCompleted.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkCompleted.AutoSize = True
        Me.ChkCompleted.Checked = True
        Me.ChkCompleted.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCompleted.Location = New System.Drawing.Point(254, 389)
        Me.ChkCompleted.Name = "ChkCompleted"
        Me.ChkCompleted.Size = New System.Drawing.Size(145, 18)
        Me.ChkCompleted.TabIndex = 3
        Me.ChkCompleted.Text = "Show completed jobs"
        Me.ChkCompleted.UseVisualStyleBackColor = True
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
        'DgvJobs
        '
        Me.DgvJobs.AllowUserToAddRows = False
        Me.DgvJobs.AllowUserToDeleteRows = False
        Me.DgvJobs.AllowUserToResizeRows = False
        Me.DgvJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvJobs.BackgroundColor = System.Drawing.Color.OldLace
        Me.DgvJobs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvJobs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.jobId, Me.jobName, Me.jobCompleted})
        Me.DgvJobs.Location = New System.Drawing.Point(3, 25)
        Me.DgvJobs.Name = "DgvJobs"
        Me.DgvJobs.ReadOnly = True
        Me.DgvJobs.RowHeadersVisible = False
        Me.DgvJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvJobs.Size = New System.Drawing.Size(396, 357)
        Me.DgvJobs.TabIndex = 2
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
        Me.lblScreenName.ForeColor = System.Drawing.Color.DarkSlateGray
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 531)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(941, 22)
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
        'ScCustomer
        '
        Me.ScCustomer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ScCustomer.Location = New System.Drawing.Point(12, 60)
        Me.ScCustomer.Name = "ScCustomer"
        '
        'ScCustomer.Panel1
        '
        Me.ScCustomer.Panel1.Controls.Add(Me.pnlCustomer)
        '
        'ScCustomer.Panel2
        '
        Me.ScCustomer.Panel2.Controls.Add(Me.pnlJobs)
        Me.ScCustomer.Size = New System.Drawing.Size(917, 420)
        Me.ScCustomer.SplitterDistance = 505
        Me.ScCustomer.TabIndex = 68
        '
        'picDiary
        '
        Me.picDiary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picDiary.Image = Global.MyBusiness.My.Resources.Resources.diary
        Me.picDiary.InitialImage = Nothing
        Me.picDiary.Location = New System.Drawing.Point(819, 486)
        Me.picDiary.Name = "picDiary"
        Me.picDiary.Size = New System.Drawing.Size(42, 42)
        Me.picDiary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picDiary.TabIndex = 89
        Me.picDiary.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picDiary, "Reminders linked to the custromer")
        '
        'PicUpdate
        '
        Me.PicUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicUpdate.Image = Global.MyBusiness.My.Resources.Resources.update
        Me.PicUpdate.InitialImage = Nothing
        Me.PicUpdate.Location = New System.Drawing.Point(12, 486)
        Me.PicUpdate.Name = "PicUpdate"
        Me.PicUpdate.Size = New System.Drawing.Size(42, 42)
        Me.PicUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicUpdate.TabIndex = 94
        Me.PicUpdate.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicUpdate, "Update the customer")
        '
        'PicClose
        '
        Me.PicClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicClose.Image = Global.MyBusiness.My.Resources.Resources.exitbutton
        Me.PicClose.InitialImage = Nothing
        Me.PicClose.Location = New System.Drawing.Point(885, 486)
        Me.PicClose.Name = "PicClose"
        Me.PicClose.Size = New System.Drawing.Size(42, 42)
        Me.PicClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicClose.TabIndex = 95
        Me.PicClose.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicClose, "Close the form")
        '
        'LblAction
        '
        Me.LblAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblAction.AutoSize = True
        Me.LblAction.BackColor = System.Drawing.Color.Tan
        Me.LblAction.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAction.ForeColor = System.Drawing.Color.White
        Me.LblAction.Location = New System.Drawing.Point(690, 25)
        Me.LblAction.Name = "LblAction"
        Me.LblAction.Padding = New System.Windows.Forms.Padding(3)
        Me.LblAction.Size = New System.Drawing.Size(199, 29)
        Me.LblAction.TabIndex = 96
        Me.LblAction.Text = "Adding new customer"
        '
        'FrmCustomerMaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(941, 553)
        Me.Controls.Add(Me.LblAction)
        Me.Controls.Add(Me.PicClose)
        Me.Controls.Add(Me.PicUpdate)
        Me.Controls.Add(Me.picDiary)
        Me.Controls.Add(Me.ScCustomer)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblScreenName)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmCustomerMaint"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlCustomer.ResumeLayout(False)
        Me.pnlCustomer.PerformLayout()
        CType(Me.nudDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCustDiscount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlJobs.ResumeLayout(False)
        Me.pnlJobs.PerformLayout()
        CType(Me.PicAddJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvJobs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ScCustomer.Panel1.ResumeLayout(False)
        Me.ScCustomer.Panel2.ResumeLayout(False)
        CType(Me.ScCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ScCustomer.ResumeLayout(False)
        CType(Me.picDiary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents pnlJobs As Panel
    Friend WithEvents DgvJobs As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblScreenName As Label
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ChkCompleted As System.Windows.Forms.CheckBox
    Friend WithEvents jobId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jobName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jobCompleted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents nudDays As NumericUpDown
    Friend WithEvents ScCustomer As SplitContainer
    Friend WithEvents picDiary As PictureBox
    Friend WithEvents PicUpdate As PictureBox
    Friend WithEvents PicClose As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PicAddJob As PictureBox
    Friend WithEvents LblAction As Label
End Class
