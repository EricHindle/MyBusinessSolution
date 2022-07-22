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
        Me.btnInvoice = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnRemoveTask = New System.Windows.Forms.Button()
        Me.btnAddTask = New System.Windows.Forms.Button()
        Me.dgvTasks = New System.Windows.Forms.DataGridView()
        Me.taskId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskStartDue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskStarted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskCompleted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnMaintProducts = New System.Windows.Forms.Button()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.jpId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodSupp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.PicDiary = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlJob.SuspendLayout()
        Me.GrpInvoice.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.PicDiary, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblScreenName.ForeColor = System.Drawing.Color.Black
        Me.lblScreenName.Location = New System.Drawing.Point(70, 13)
        Me.lblScreenName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(49, 25)
        Me.lblScreenName.TabIndex = 73
        Me.lblScreenName.Text = "Job"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(384, 532)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(136, 46)
        Me.btnClose.TabIndex = 72
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(38, 532)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(136, 46)
        Me.btnUpdate.TabIndex = 71
        Me.btnUpdate.Text = "Save"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnRemoveTask
        '
        Me.btnRemoveTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveTask.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveTask.Location = New System.Drawing.Point(368, 4)
        Me.btnRemoveTask.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemoveTask.Name = "btnRemoveTask"
        Me.btnRemoveTask.Size = New System.Drawing.Size(86, 28)
        Me.btnRemoveTask.TabIndex = 70
        Me.btnRemoveTask.Text = "Remove"
        Me.btnRemoveTask.UseVisualStyleBackColor = True
        '
        'btnAddTask
        '
        Me.btnAddTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddTask.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddTask.Location = New System.Drawing.Point(275, 4)
        Me.btnAddTask.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddTask.Name = "btnAddTask"
        Me.btnAddTask.Size = New System.Drawing.Size(86, 28)
        Me.btnAddTask.TabIndex = 69
        Me.btnAddTask.Text = "Add"
        Me.btnAddTask.UseVisualStyleBackColor = True
        '
        'dgvTasks
        '
        Me.dgvTasks.AllowUserToAddRows = False
        Me.dgvTasks.AllowUserToDeleteRows = False
        Me.dgvTasks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTasks.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTasks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.taskId, Me.taskName, Me.taskStartDue, Me.taskStarted, Me.taskCompleted, Me.taskHours})
        Me.dgvTasks.Location = New System.Drawing.Point(4, 40)
        Me.dgvTasks.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dgvTasks.Name = "dgvTasks"
        Me.dgvTasks.ReadOnly = True
        Me.dgvTasks.RowHeadersVisible = False
        Me.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTasks.Size = New System.Drawing.Size(459, 150)
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
        '
        'taskStarted
        '
        Me.taskStarted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.taskStarted.HeaderText = "Begun"
        Me.taskStarted.Name = "taskStarted"
        Me.taskStarted.ReadOnly = True
        Me.taskStarted.Width = 50
        '
        'taskCompleted
        '
        Me.taskCompleted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.taskCompleted.HeaderText = "Ended"
        Me.taskCompleted.Name = "taskCompleted"
        Me.taskCompleted.ReadOnly = True
        Me.taskCompleted.Width = 50
        '
        'taskHours
        '
        Me.taskHours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.taskHours.HeaderText = "Hours"
        Me.taskHours.Name = "taskHours"
        Me.taskHours.ReadOnly = True
        Me.taskHours.Width = 80
        '
        'btnMaintProducts
        '
        Me.btnMaintProducts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaintProducts.Location = New System.Drawing.Point(368, 5)
        Me.btnMaintProducts.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMaintProducts.Name = "btnMaintProducts"
        Me.btnMaintProducts.Size = New System.Drawing.Size(86, 28)
        Me.btnMaintProducts.TabIndex = 70
        Me.btnMaintProducts.Text = "Update"
        Me.btnMaintProducts.UseVisualStyleBackColor = True
        '
        'dgvProducts
        '
        Me.dgvProducts.AllowUserToAddRows = False
        Me.dgvProducts.AllowUserToDeleteRows = False
        Me.dgvProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProducts.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.jpId, Me.prodSupp, Me.prodId, Me.prodName, Me.prodQty, Me.prodCost, Me.prodPrice})
        Me.dgvProducts.Location = New System.Drawing.Point(7, 40)
        Me.dgvProducts.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.ReadOnly = True
        Me.dgvProducts.RowHeadersVisible = False
        Me.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProducts.Size = New System.Drawing.Size(456, 213)
        Me.dgvProducts.TabIndex = 0
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
        Me.prodCost.HeaderText = "Cost"
        Me.prodCost.Name = "prodCost"
        Me.prodCost.ReadOnly = True
        '
        'prodPrice
        '
        Me.prodPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.prodPrice.HeaderText = "Price"
        Me.prodPrice.Name = "prodPrice"
        Me.prodPrice.ReadOnly = True
        '
        'pnlJob
        '
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
        Me.pnlJob.Size = New System.Drawing.Size(575, 457)
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
        Me.GrpInvoice.Size = New System.Drawing.Size(531, 102)
        Me.GrpInvoice.TabIndex = 14
        Me.GrpInvoice.TabStop = False
        '
        'LblTerms
        '
        Me.LblTerms.AutoSize = True
        Me.LblTerms.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTerms.Location = New System.Drawing.Point(172, 67)
        Me.LblTerms.Name = "LblTerms"
        Me.LblTerms.Size = New System.Drawing.Size(72, 14)
        Me.LblTerms.TabIndex = 77
        Me.LblTerms.Text = "Immediate"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(181, 47)
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
        Me.Label12.Location = New System.Drawing.Point(255, 39)
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
        Me.Label9.Location = New System.Drawing.Point(255, 73)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 14)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Payment Due"
        '
        'DtpPaymentDue
        '
        Me.DtpPaymentDue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpPaymentDue.Location = New System.Drawing.Point(344, 67)
        Me.DtpPaymentDue.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DtpPaymentDue.Name = "DtpPaymentDue"
        Me.DtpPaymentDue.Size = New System.Drawing.Size(165, 22)
        Me.DtpPaymentDue.TabIndex = 5
        Me.DtpPaymentDue.Value = New Date(2022, 7, 19, 0, 0, 0, 0)
        '
        'DtpInvoiceDate
        '
        Me.DtpInvoiceDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpInvoiceDate.Location = New System.Drawing.Point(344, 33)
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
        Me.TxtInvoiceNumber.Size = New System.Drawing.Size(142, 22)
        Me.TxtInvoiceNumber.TabIndex = 1
        '
        'cbUser
        '
        Me.cbUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbUser.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUser.FormattingEnabled = True
        Me.cbUser.Location = New System.Drawing.Point(488, 89)
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
        Me.Label6.Location = New System.Drawing.Point(409, 92)
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
        Me.btnViewCust.Location = New System.Drawing.Point(488, 16)
        Me.btnViewCust.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnViewCust.Name = "btnViewCust"
        Me.btnViewCust.Size = New System.Drawing.Size(68, 26)
        Me.btnViewCust.TabIndex = 11
        Me.btnViewCust.Text = "View"
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
        Me.rtbJobNotes.Size = New System.Drawing.Size(530, 164)
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
        Me.TxtJobReference.Size = New System.Drawing.Size(256, 22)
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
        Me.TxtPurchaseOrder.Size = New System.Drawing.Size(256, 22)
        Me.TxtPurchaseOrder.TabIndex = 0
        '
        'chkCompleted
        '
        Me.chkCompleted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkCompleted.AutoSize = True
        Me.chkCompleted.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCompleted.Location = New System.Drawing.Point(442, 132)
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
        Me.txtJobName.Size = New System.Drawing.Size(447, 27)
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
        Me.cbCust.Size = New System.Drawing.Size(362, 22)
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
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnAddTask)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvTasks)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnRemoveTask)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnMaintProducts)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvProducts)
        Me.SplitContainer1.Size = New System.Drawing.Size(467, 461)
        Me.SplitContainer1.SplitterDistance = 197
        Me.SplitContainer1.TabIndex = 77
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
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Location = New System.Drawing.Point(14, 64)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.pnlJob)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1050, 461)
        Me.SplitContainer2.SplitterDistance = 579
        Me.SplitContainer2.TabIndex = 78
        '
        'PicDiary
        '
        Me.PicDiary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicDiary.Image = Global.MyBusiness.My.Resources.Resources.diary
        Me.PicDiary.InitialImage = Nothing
        Me.PicDiary.Location = New System.Drawing.Point(1020, 536)
        Me.PicDiary.Name = "PicDiary"
        Me.PicDiary.Size = New System.Drawing.Size(42, 42)
        Me.PicDiary.TabIndex = 90
        Me.PicDiary.TabStop = False
        '
        'FrmJobMaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 611)
        Me.Controls.Add(Me.PicDiary)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblScreenName)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnUpdate)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FrmJobMaint"
        Me.ShowIcon = False
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTasks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlJob.ResumeLayout(False)
        Me.pnlJob.PerformLayout()
        Me.GrpInvoice.ResumeLayout(False)
        Me.GrpInvoice.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.PicDiary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnInvoice As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblScreenName As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnRemoveTask As Button
    Friend WithEvents btnAddTask As Button
    Friend WithEvents dgvTasks As DataGridView
    Friend WithEvents taskId As DataGridViewTextBoxColumn
    Friend WithEvents taskName As DataGridViewTextBoxColumn
    Friend WithEvents taskStartDue As DataGridViewTextBoxColumn
    Friend WithEvents taskStarted As DataGridViewTextBoxColumn
    Friend WithEvents taskCompleted As DataGridViewTextBoxColumn
    Friend WithEvents taskHours As DataGridViewTextBoxColumn
    Friend WithEvents btnMaintProducts As Button
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents jpId As DataGridViewTextBoxColumn
    Friend WithEvents prodSupp As DataGridViewTextBoxColumn
    Friend WithEvents prodId As DataGridViewTextBoxColumn
    Friend WithEvents prodName As DataGridViewTextBoxColumn
    Friend WithEvents prodQty As DataGridViewTextBoxColumn
    Friend WithEvents prodCost As DataGridViewTextBoxColumn
    Friend WithEvents prodPrice As DataGridViewTextBoxColumn
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
    Friend WithEvents SplitContainer1 As SplitContainer
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
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents LblTerms As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents PicDiary As PictureBox
End Class
