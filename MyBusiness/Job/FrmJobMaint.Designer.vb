<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJobMaint
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnInvoice = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.btnRemoveTask = New System.Windows.Forms.Button()
        Me.btnAddJobTask = New System.Windows.Forms.Button()
        Me.dgvTasks = New System.Windows.Forms.DataGridView()
        Me.taskId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskStartDue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskStarted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskCompleted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnMaintProducts = New System.Windows.Forms.Button()
        Me.DgvProducts = New System.Windows.Forms.DataGridView()
        Me.jpId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodSupp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jobPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlJob = New System.Windows.Forms.Panel()
        Me.GrpInvoice = New System.Windows.Forms.GroupBox()
        Me.LblTerms = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DtpPaymentDue = New System.Windows.Forms.DateTimePicker()
        Me.DtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.TxtInvoiceNumber = New System.Windows.Forms.TextBox()
        Me.cbUser = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnViewCust = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rtbJobNotes = New System.Windows.Forms.RichTextBox()
        Me.TxtJobReference = New System.Windows.Forms.TextBox()
        Me.TxtPurchaseOrder = New System.Windows.Forms.TextBox()
        Me.chkCompleted = New System.Windows.Forms.CheckBox()
        Me.txtJobName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCust = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ScJobItems = New System.Windows.Forms.SplitContainer()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ScJob = New System.Windows.Forms.SplitContainer()
        Me.PicDiary = New System.Windows.Forms.PictureBox()
        Me.PicImages = New System.Windows.Forms.PictureBox()
        Me.PicClose = New System.Windows.Forms.PictureBox()
        Me.PicUpdate = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PicDeleteJob = New System.Windows.Forms.PictureBox()
        Me.LblAction = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlJob.SuspendLayout()
        Me.GrpInvoice.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ScJobItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ScJobItems.Panel1.SuspendLayout()
        Me.ScJobItems.Panel2.SuspendLayout()
        Me.ScJobItems.SuspendLayout()
        CType(Me.ScJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ScJob.Panel1.SuspendLayout()
        Me.ScJob.Panel2.SuspendLayout()
        Me.ScJob.SuspendLayout()
        CType(Me.PicDiary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicImages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicDeleteJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnInvoice
        '
        Me.btnInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnInvoice.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInvoice.Location = New System.Drawing.Point(10, 67)
        Me.btnInvoice.Margin = New System.Windows.Forms.Padding(4)
        Me.btnInvoice.Name = "btnInvoice"
        Me.btnInvoice.Size = New System.Drawing.Size(136, 30)
        Me.btnInvoice.TabIndex = 75
        Me.btnInvoice.Text = "Produce Invoice"
        Me.ToolTip1.SetToolTip(Me.btnInvoice, "Prepare pdf Invoice")
        Me.btnInvoice.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.Location = New System.Drawing.Point(14, 13)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 45)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 74
        Me.PictureBox1.TabStop = False
        '
        'lblScreenName
        '
        Me.lblScreenName.AutoSize = True
        Me.lblScreenName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenName.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblScreenName.Location = New System.Drawing.Point(70, 13)
        Me.lblScreenName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(49, 25)
        Me.lblScreenName.TabIndex = 73
        Me.lblScreenName.Text = "Job"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRemoveTask
        '
        Me.btnRemoveTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveTask.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveTask.Location = New System.Drawing.Point(450, 4)
        Me.btnRemoveTask.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemoveTask.Name = "btnRemoveTask"
        Me.btnRemoveTask.Size = New System.Drawing.Size(86, 28)
        Me.btnRemoveTask.TabIndex = 70
        Me.btnRemoveTask.Text = "Remove"
        Me.ToolTip1.SetToolTip(Me.btnRemoveTask, "Remove the selected task")
        Me.btnRemoveTask.UseVisualStyleBackColor = True
        '
        'btnAddJobTask
        '
        Me.btnAddJobTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddJobTask.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddJobTask.Location = New System.Drawing.Point(357, 4)
        Me.btnAddJobTask.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddJobTask.Name = "btnAddJobTask"
        Me.btnAddJobTask.Size = New System.Drawing.Size(86, 28)
        Me.btnAddJobTask.TabIndex = 69
        Me.btnAddJobTask.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.btnAddJobTask, "Add a task")
        Me.btnAddJobTask.UseVisualStyleBackColor = True
        '
        'dgvTasks
        '
        Me.dgvTasks.AllowUserToAddRows = False
        Me.dgvTasks.AllowUserToDeleteRows = False
        Me.dgvTasks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTasks.BackgroundColor = System.Drawing.Color.LavenderBlush
        Me.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTasks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.taskId, Me.taskName, Me.taskStartDue, Me.taskStarted, Me.taskCompleted, Me.taskHours, Me.taskPrice})
        Me.dgvTasks.Location = New System.Drawing.Point(4, 40)
        Me.dgvTasks.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dgvTasks.Name = "dgvTasks"
        Me.dgvTasks.ReadOnly = True
        Me.dgvTasks.RowHeadersVisible = False
        Me.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTasks.Size = New System.Drawing.Size(541, 150)
        Me.dgvTasks.TabIndex = 0
        '
        'taskId
        '
        Me.taskId.HeaderText = "Id"
        Me.taskId.Name = "taskId"
        Me.taskId.ReadOnly = True
        Me.taskId.Visible = False
        '
        'taskName
        '
        Me.taskName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.taskName.HeaderText = "Name"
        Me.taskName.Name = "taskName"
        Me.taskName.ReadOnly = True
        '
        'taskStartDue
        '
        Me.taskStartDue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.taskStartDue.HeaderText = "Start"
        Me.taskStartDue.Name = "taskStartDue"
        Me.taskStartDue.ReadOnly = True
        Me.taskStartDue.Width = 80
        '
        'taskStarted
        '
        Me.taskStarted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.taskStarted.HeaderText = "Begun"
        Me.taskStarted.Name = "taskStarted"
        Me.taskStarted.ReadOnly = True
        Me.taskStarted.Width = 70
        '
        'taskCompleted
        '
        Me.taskCompleted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.taskCompleted.HeaderText = "Ended"
        Me.taskCompleted.Name = "taskCompleted"
        Me.taskCompleted.ReadOnly = True
        Me.taskCompleted.Width = 70
        '
        'taskHours
        '
        Me.taskHours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.taskHours.HeaderText = "Hours"
        Me.taskHours.Name = "taskHours"
        Me.taskHours.ReadOnly = True
        Me.taskHours.Width = 60
        '
        'taskPrice
        '
        Me.taskPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.taskPrice.HeaderText = "Price"
        Me.taskPrice.Name = "taskPrice"
        Me.taskPrice.ReadOnly = True
        Me.taskPrice.Width = 60
        '
        'btnMaintProducts
        '
        Me.btnMaintProducts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaintProducts.Location = New System.Drawing.Point(450, 5)
        Me.btnMaintProducts.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMaintProducts.Name = "btnMaintProducts"
        Me.btnMaintProducts.Size = New System.Drawing.Size(86, 28)
        Me.btnMaintProducts.TabIndex = 70
        Me.btnMaintProducts.Text = "Update"
        Me.btnMaintProducts.UseVisualStyleBackColor = True
        '
        'DgvProducts
        '
        Me.DgvProducts.AllowUserToAddRows = False
        Me.DgvProducts.AllowUserToDeleteRows = False
        Me.DgvProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvProducts.BackgroundColor = System.Drawing.Color.SeaShell
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Snow
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvProducts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.jpId, Me.prodSupp, Me.prodId, Me.prodName, Me.prodQty, Me.prodCost, Me.prodPrice, Me.jobPrice})
        Me.DgvProducts.Location = New System.Drawing.Point(7, 40)
        Me.DgvProducts.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DgvProducts.Name = "DgvProducts"
        Me.DgvProducts.ReadOnly = True
        Me.DgvProducts.RowHeadersVisible = False
        Me.DgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProducts.Size = New System.Drawing.Size(538, 213)
        Me.DgvProducts.TabIndex = 0
        '
        'jpId
        '
        Me.jpId.HeaderText = "Id"
        Me.jpId.Name = "jpId"
        Me.jpId.ReadOnly = True
        Me.jpId.Visible = False
        '
        'prodSupp
        '
        Me.prodSupp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.prodSupp.HeaderText = "Supplier"
        Me.prodSupp.Name = "prodSupp"
        Me.prodSupp.ReadOnly = True
        Me.prodSupp.Width = 120
        '
        'prodId
        '
        Me.prodId.HeaderText = "prodId"
        Me.prodId.Name = "prodId"
        Me.prodId.ReadOnly = True
        Me.prodId.Visible = False
        '
        'prodName
        '
        Me.prodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.prodName.HeaderText = "ProductName"
        Me.prodName.Name = "prodName"
        Me.prodName.ReadOnly = True
        '
        'prodQty
        '
        Me.prodQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.prodQty.HeaderText = "Qty"
        Me.prodQty.Name = "prodQty"
        Me.prodQty.ReadOnly = True
        Me.prodQty.Width = 60
        '
        'prodCost
        '
        Me.prodCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.prodCost.HeaderText = "Unit Cost"
        Me.prodCost.Name = "prodCost"
        Me.prodCost.ReadOnly = True
        Me.prodCost.Width = 70
        '
        'prodPrice
        '
        Me.prodPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.prodPrice.HeaderText = "Std Price"
        Me.prodPrice.Name = "prodPrice"
        Me.prodPrice.ReadOnly = True
        Me.prodPrice.Width = 70
        '
        'jobPrice
        '
        Me.jobPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.jobPrice.HeaderText = "Job Price"
        Me.jobPrice.Name = "jobPrice"
        Me.jobPrice.ReadOnly = True
        Me.jobPrice.Width = 70
        '
        'pnlJob
        '
        Me.pnlJob.BackColor = System.Drawing.Color.GhostWhite
        Me.pnlJob.Controls.Add(Me.GrpInvoice)
        Me.pnlJob.Controls.Add(Me.cbUser)
        Me.pnlJob.Controls.Add(Me.Label10)
        Me.pnlJob.Controls.Add(Me.Label6)
        Me.pnlJob.Controls.Add(Me.btnViewCust)
        Me.pnlJob.Controls.Add(Me.Label5)
        Me.pnlJob.Controls.Add(Me.Label7)
        Me.pnlJob.Controls.Add(Me.Label2)
        Me.pnlJob.Controls.Add(Me.rtbJobNotes)
        Me.pnlJob.Controls.Add(Me.TxtJobReference)
        Me.pnlJob.Controls.Add(Me.TxtPurchaseOrder)
        Me.pnlJob.Controls.Add(Me.chkCompleted)
        Me.pnlJob.Controls.Add(Me.txtJobName)
        Me.pnlJob.Controls.Add(Me.Label1)
        Me.pnlJob.Controls.Add(Me.cbCust)
        Me.pnlJob.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlJob.Location = New System.Drawing.Point(0, 0)
        Me.pnlJob.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pnlJob.Name = "pnlJob"
        Me.pnlJob.Size = New System.Drawing.Size(494, 457)
        Me.pnlJob.TabIndex = 69
        '
        'GrpInvoice
        '
        Me.GrpInvoice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpInvoice.Controls.Add(Me.LblTerms)
        Me.GrpInvoice.Controls.Add(Me.Label8)
        Me.GrpInvoice.Controls.Add(Me.Label12)
        Me.GrpInvoice.Controls.Add(Me.Label11)
        Me.GrpInvoice.Controls.Add(Me.btnInvoice)
        Me.GrpInvoice.Controls.Add(Me.Label9)
        Me.GrpInvoice.Controls.Add(Me.DtpPaymentDue)
        Me.GrpInvoice.Controls.Add(Me.DtpInvoiceDate)
        Me.GrpInvoice.Controls.Add(Me.TxtInvoiceNumber)
        Me.GrpInvoice.Location = New System.Drawing.Point(24, 349)
        Me.GrpInvoice.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GrpInvoice.Name = "GrpInvoice"
        Me.GrpInvoice.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GrpInvoice.Size = New System.Drawing.Size(450, 102)
        Me.GrpInvoice.TabIndex = 14
        Me.GrpInvoice.TabStop = False
        '
        'LblTerms
        '
        Me.LblTerms.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTerms.AutoSize = True
        Me.LblTerms.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTerms.Location = New System.Drawing.Point(371, 57)
        Me.LblTerms.Name = "LblTerms"
        Me.LblTerms.Size = New System.Drawing.Size(72, 14)
        Me.LblTerms.TabIndex = 77
        Me.LblTerms.Text = "Immediate"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(380, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 14)
        Me.Label8.TabIndex = 76
        Me.Label8.Text = "Terms"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(199, 17)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 14)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Invoice Date"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(7, 17)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 14)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Invoice Number"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(199, 58)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 14)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Payment Due"
        '
        'DtpPaymentDue
        '
        Me.DtpPaymentDue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpPaymentDue.Location = New System.Drawing.Point(199, 75)
        Me.DtpPaymentDue.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DtpPaymentDue.Name = "DtpPaymentDue"
        Me.DtpPaymentDue.Size = New System.Drawing.Size(165, 22)
        Me.DtpPaymentDue.TabIndex = 5
        Me.DtpPaymentDue.Value = New Date(2022, 7, 19, 0, 0, 0, 0)
        '
        'DtpInvoiceDate
        '
        Me.DtpInvoiceDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpInvoiceDate.Location = New System.Drawing.Point(199, 34)
        Me.DtpInvoiceDate.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DtpInvoiceDate.Name = "DtpInvoiceDate"
        Me.DtpInvoiceDate.Size = New System.Drawing.Size(165, 22)
        Me.DtpInvoiceDate.TabIndex = 4
        '
        'TxtInvoiceNumber
        '
        Me.TxtInvoiceNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtInvoiceNumber.Location = New System.Drawing.Point(10, 39)
        Me.TxtInvoiceNumber.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtInvoiceNumber.Name = "TxtInvoiceNumber"
        Me.TxtInvoiceNumber.Size = New System.Drawing.Size(164, 22)
        Me.TxtInvoiceNumber.TabIndex = 1
        '
        'cbUser
        '
        Me.cbUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbUser.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUser.FormattingEnabled = True
        Me.cbUser.Location = New System.Drawing.Point(407, 89)
        Me.cbUser.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbUser.Name = "cbUser"
        Me.cbUser.Size = New System.Drawing.Size(66, 22)
        Me.cbUser.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(21, 130)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 14)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Purchase Order"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(328, 92)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 14)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Assigned to"
        '
        'btnViewCust
        '
        Me.btnViewCust.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewCust.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewCust.Location = New System.Drawing.Point(407, 16)
        Me.btnViewCust.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnViewCust.Name = "btnViewCust"
        Me.btnViewCust.Size = New System.Drawing.Size(68, 26)
        Me.btnViewCust.TabIndex = 11
        Me.btnViewCust.Text = "View"
        Me.ToolTip1.SetToolTip(Me.btnViewCust, "View customer details")
        Me.btnViewCust.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 160)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 14)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Description"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 93)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 14)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Job Reference"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 57)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Name"
        '
        'rtbJobNotes
        '
        Me.rtbJobNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbJobNotes.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbJobNotes.Location = New System.Drawing.Point(24, 179)
        Me.rtbJobNotes.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rtbJobNotes.Name = "rtbJobNotes"
        Me.rtbJobNotes.Size = New System.Drawing.Size(449, 164)
        Me.rtbJobNotes.TabIndex = 6
        Me.rtbJobNotes.Text = ""
        '
        'TxtJobReference
        '
        Me.TxtJobReference.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtJobReference.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtJobReference.Location = New System.Drawing.Point(134, 89)
        Me.TxtJobReference.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtJobReference.Name = "TxtJobReference"
        Me.TxtJobReference.Size = New System.Drawing.Size(175, 22)
        Me.TxtJobReference.TabIndex = 2
        '
        'TxtPurchaseOrder
        '
        Me.TxtPurchaseOrder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPurchaseOrder.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPurchaseOrder.Location = New System.Drawing.Point(134, 128)
        Me.TxtPurchaseOrder.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtPurchaseOrder.Name = "TxtPurchaseOrder"
        Me.TxtPurchaseOrder.Size = New System.Drawing.Size(175, 22)
        Me.TxtPurchaseOrder.TabIndex = 0
        '
        'chkCompleted
        '
        Me.chkCompleted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkCompleted.AutoSize = True
        Me.chkCompleted.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCompleted.Location = New System.Drawing.Point(361, 132)
        Me.chkCompleted.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkCompleted.Name = "chkCompleted"
        Me.chkCompleted.Size = New System.Drawing.Size(85, 18)
        Me.chkCompleted.TabIndex = 5
        Me.chkCompleted.Text = "Completed"
        Me.chkCompleted.UseVisualStyleBackColor = True
        '
        'txtJobName
        '
        Me.txtJobName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJobName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobName.Location = New System.Drawing.Point(107, 51)
        Me.txtJobName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtJobName.Name = "txtJobName"
        Me.txtJobName.Size = New System.Drawing.Size(366, 27)
        Me.txtJobName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer"
        '
        'cbCust
        '
        Me.cbCust.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbCust.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCust.FormattingEnabled = True
        Me.cbCust.Location = New System.Drawing.Point(107, 16)
        Me.cbCust.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbCust.Name = "cbCust"
        Me.cbCust.Size = New System.Drawing.Size(281, 22)
        Me.cbCust.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 589)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1076, 22)
        Me.StatusStrip1.TabIndex = 76
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.LblStatus.Size = New System.Drawing.Size(9, 17)
        '
        'ScJobItems
        '
        Me.ScJobItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ScJobItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ScJobItems.Location = New System.Drawing.Point(0, 0)
        Me.ScJobItems.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ScJobItems.Name = "ScJobItems"
        Me.ScJobItems.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'ScJobItems.Panel1
        '
        Me.ScJobItems.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ScJobItems.Panel1.Controls.Add(Me.Label3)
        Me.ScJobItems.Panel1.Controls.Add(Me.btnAddJobTask)
        Me.ScJobItems.Panel1.Controls.Add(Me.dgvTasks)
        Me.ScJobItems.Panel1.Controls.Add(Me.btnRemoveTask)
        '
        'ScJobItems.Panel2
        '
        Me.ScJobItems.Panel2.BackColor = System.Drawing.Color.Snow
        Me.ScJobItems.Panel2.Controls.Add(Me.btnMaintProducts)
        Me.ScJobItems.Panel2.Controls.Add(Me.Label4)
        Me.ScJobItems.Panel2.Controls.Add(Me.DgvProducts)
        Me.ScJobItems.Size = New System.Drawing.Size(548, 461)
        Me.ScJobItems.SplitterDistance = 197
        Me.ScJobItems.TabIndex = 77
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 19)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Tasks"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 10)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 19)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Products"
        '
        'ScJob
        '
        Me.ScJob.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScJob.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ScJob.Location = New System.Drawing.Point(14, 64)
        Me.ScJob.Name = "ScJob"
        '
        'ScJob.Panel1
        '
        Me.ScJob.Panel1.Controls.Add(Me.pnlJob)
        '
        'ScJob.Panel2
        '
        Me.ScJob.Panel2.Controls.Add(Me.ScJobItems)
        Me.ScJob.Size = New System.Drawing.Size(1050, 461)
        Me.ScJob.SplitterDistance = 498
        Me.ScJob.TabIndex = 78
        '
        'PicDiary
        '
        Me.PicDiary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicDiary.Image = Global.MyBusiness.My.Resources.Resources.diary
        Me.PicDiary.InitialImage = Nothing
        Me.PicDiary.Location = New System.Drawing.Point(946, 536)
        Me.PicDiary.Name = "PicDiary"
        Me.PicDiary.Size = New System.Drawing.Size(42, 42)
        Me.PicDiary.TabIndex = 90
        Me.PicDiary.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicDiary, "Reminders")
        '
        'PicImages
        '
        Me.PicImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicImages.Image = Global.MyBusiness.My.Resources.Resources.image
        Me.PicImages.InitialImage = Nothing
        Me.PicImages.Location = New System.Drawing.Point(898, 536)
        Me.PicImages.Name = "PicImages"
        Me.PicImages.Size = New System.Drawing.Size(42, 42)
        Me.PicImages.TabIndex = 91
        Me.PicImages.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicImages, "Images")
        '
        'PicClose
        '
        Me.PicClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicClose.Image = Global.MyBusiness.My.Resources.Resources.exitbutton
        Me.PicClose.InitialImage = Nothing
        Me.PicClose.Location = New System.Drawing.Point(1022, 536)
        Me.PicClose.Name = "PicClose"
        Me.PicClose.Size = New System.Drawing.Size(42, 42)
        Me.PicClose.TabIndex = 92
        Me.PicClose.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicClose, "Close the form")
        '
        'PicUpdate
        '
        Me.PicUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicUpdate.Image = Global.MyBusiness.My.Resources.Resources.update
        Me.PicUpdate.InitialImage = Nothing
        Me.PicUpdate.Location = New System.Drawing.Point(14, 536)
        Me.PicUpdate.Name = "PicUpdate"
        Me.PicUpdate.Size = New System.Drawing.Size(42, 42)
        Me.PicUpdate.TabIndex = 93
        Me.PicUpdate.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicUpdate, "Update Job")
        '
        'PicDeleteJob
        '
        Me.PicDeleteJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicDeleteJob.Image = Global.MyBusiness.My.Resources.Resources.remove
        Me.PicDeleteJob.InitialImage = Nothing
        Me.PicDeleteJob.Location = New System.Drawing.Point(86, 536)
        Me.PicDeleteJob.Name = "PicDeleteJob"
        Me.PicDeleteJob.Size = New System.Drawing.Size(42, 42)
        Me.PicDeleteJob.TabIndex = 94
        Me.PicDeleteJob.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicDeleteJob, "Remove Job")
        '
        'LblAction
        '
        Me.LblAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblAction.AutoSize = True
        Me.LblAction.BackColor = System.Drawing.Color.LightSteelBlue
        Me.LblAction.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAction.ForeColor = System.Drawing.Color.White
        Me.LblAction.Location = New System.Drawing.Point(851, 29)
        Me.LblAction.Name = "LblAction"
        Me.LblAction.Padding = New System.Windows.Forms.Padding(3)
        Me.LblAction.Size = New System.Drawing.Size(148, 29)
        Me.LblAction.TabIndex = 95
        Me.LblAction.Text = "Adding new job"
        '
        'FrmJobMaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 611)
        Me.Controls.Add(Me.LblAction)
        Me.Controls.Add(Me.PicDeleteJob)
        Me.Controls.Add(Me.PicUpdate)
        Me.Controls.Add(Me.PicClose)
        Me.Controls.Add(Me.PicImages)
        Me.Controls.Add(Me.PicDiary)
        Me.Controls.Add(Me.ScJob)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblScreenName)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FrmJobMaint"
        Me.ShowIcon = False
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTasks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlJob.ResumeLayout(False)
        Me.pnlJob.PerformLayout()
        Me.GrpInvoice.ResumeLayout(False)
        Me.GrpInvoice.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ScJobItems.Panel1.ResumeLayout(False)
        Me.ScJobItems.Panel1.PerformLayout()
        Me.ScJobItems.Panel2.ResumeLayout(False)
        Me.ScJobItems.Panel2.PerformLayout()
        CType(Me.ScJobItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ScJobItems.ResumeLayout(False)
        Me.ScJob.Panel1.ResumeLayout(False)
        Me.ScJob.Panel2.ResumeLayout(False)
        CType(Me.ScJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ScJob.ResumeLayout(False)
        CType(Me.PicDiary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicImages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicDeleteJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnInvoice As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblScreenName As Label
    Friend WithEvents btnRemoveTask As Button
    Friend WithEvents btnAddJobTask As Button
    Friend WithEvents dgvTasks As DataGridView
    Friend WithEvents btnMaintProducts As Button
    Friend WithEvents DgvProducts As DataGridView
    Friend WithEvents pnlJob As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents btnViewCust As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents rtbJobNotes As RichTextBox
    Friend WithEvents chkCompleted As CheckBox
    Friend WithEvents txtJobName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbCust As ComboBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents cbUser As ComboBox
    Friend WithEvents ScJobItems As SplitContainer
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GrpInvoice As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents DtpPaymentDue As DateTimePicker
    Friend WithEvents DtpInvoiceDate As DateTimePicker
    Friend WithEvents TxtInvoiceNumber As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtJobReference As TextBox
    Friend WithEvents TxtPurchaseOrder As TextBox
    Friend WithEvents ScJob As SplitContainer
    Friend WithEvents LblTerms As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents PicDiary As PictureBox
    Friend WithEvents taskId As DataGridViewTextBoxColumn
    Friend WithEvents taskName As DataGridViewTextBoxColumn
    Friend WithEvents taskStartDue As DataGridViewTextBoxColumn
    Friend WithEvents taskStarted As DataGridViewTextBoxColumn
    Friend WithEvents taskCompleted As DataGridViewTextBoxColumn
    Friend WithEvents taskHours As DataGridViewTextBoxColumn
    Friend WithEvents taskPrice As DataGridViewTextBoxColumn
    Friend WithEvents jpId As DataGridViewTextBoxColumn
    Friend WithEvents prodSupp As DataGridViewTextBoxColumn
    Friend WithEvents prodId As DataGridViewTextBoxColumn
    Friend WithEvents prodName As DataGridViewTextBoxColumn
    Friend WithEvents prodQty As DataGridViewTextBoxColumn
    Friend WithEvents prodCost As DataGridViewTextBoxColumn
    Friend WithEvents prodPrice As DataGridViewTextBoxColumn
    Friend WithEvents jobPrice As DataGridViewTextBoxColumn
    Friend WithEvents PicImages As PictureBox
    Friend WithEvents PicClose As PictureBox
    Friend WithEvents PicUpdate As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PicDeleteJob As PictureBox
    Friend WithEvents LblAction As Label
End Class
