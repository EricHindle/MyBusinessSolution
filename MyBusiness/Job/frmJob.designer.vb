﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJob
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJob))
        Me.pnlJob = New System.Windows.Forms.Panel()
        Me.cbUser = New System.Windows.Forms.ComboBox()
        Me.UserBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NetwyrksDataSet = New MyBusiness.netwyrksDataSet()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnViewCust = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rtbJobNotes = New System.Windows.Forms.RichTextBox()
        Me.chkCompleted = New System.Windows.Forms.CheckBox()
        Me.txtJobName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCust = New System.Windows.Forms.ComboBox()
        Me.pnlTask = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnRemoveTask = New System.Windows.Forms.Button()
        Me.btnAddTask = New System.Windows.Forms.Button()
        Me.dgvTasks = New System.Windows.Forms.DataGridView()
        Me.taskId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskStartDue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskStarted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskCompleted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnMaintProducts = New System.Windows.Forms.Button()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.jpId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodSupp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnInvoice = New System.Windows.Forms.Button()
        Me.UserTableAdapter = New MyBusiness.netwyrksDataSetTableAdapters.userTableAdapter()
        Me.pnlJob.SuspendLayout()
        CType(Me.UserBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NetwyrksDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTask.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlJob
        '
        Me.pnlJob.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlJob.Controls.Add(Me.cbUser)
        Me.pnlJob.Controls.Add(Me.Label6)
        Me.pnlJob.Controls.Add(Me.btnViewCust)
        Me.pnlJob.Controls.Add(Me.Label5)
        Me.pnlJob.Controls.Add(Me.Label2)
        Me.pnlJob.Controls.Add(Me.rtbJobNotes)
        Me.pnlJob.Controls.Add(Me.chkCompleted)
        Me.pnlJob.Controls.Add(Me.txtJobName)
        Me.pnlJob.Controls.Add(Me.Label1)
        Me.pnlJob.Controls.Add(Me.cbCust)
        Me.pnlJob.Location = New System.Drawing.Point(12, 52)
        Me.pnlJob.Name = "pnlJob"
        Me.pnlJob.Size = New System.Drawing.Size(541, 440)
        Me.pnlJob.TabIndex = 3
        '
        'cbUser
        '
        Me.cbUser.DataSource = Me.UserBindingSource
        Me.cbUser.DisplayMember = "user_code"
        Me.cbUser.FormattingEnabled = True
        Me.cbUser.Location = New System.Drawing.Point(466, 80)
        Me.cbUser.Name = "cbUser"
        Me.cbUser.Size = New System.Drawing.Size(58, 24)
        Me.cbUser.TabIndex = 13
        Me.cbUser.ValueMember = "user_id"
        '
        'UserBindingSource
        '
        Me.UserBindingSource.DataMember = "user"
        Me.UserBindingSource.DataSource = Me.NetwyrksDataSet
        '
        'NetwyrksDataSet
        '
        Me.NetwyrksDataSet.DataSetName = "netwyrksDataSet"
        Me.NetwyrksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(373, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Assigned to"
        '
        'btnViewCust
        '
        Me.btnViewCust.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewCust.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewCust.Location = New System.Drawing.Point(466, 16)
        Me.btnViewCust.Name = "btnViewCust"
        Me.btnViewCust.Size = New System.Drawing.Size(58, 23)
        Me.btnViewCust.TabIndex = 11
        Me.btnViewCust.Text = "View"
        Me.btnViewCust.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Name"
        '
        'rtbJobNotes
        '
        Me.rtbJobNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbJobNotes.Location = New System.Drawing.Point(21, 169)
        Me.rtbJobNotes.Name = "rtbJobNotes"
        Me.rtbJobNotes.Size = New System.Drawing.Size(503, 268)
        Me.rtbJobNotes.TabIndex = 6
        Me.rtbJobNotes.Text = ""
        '
        'chkCompleted
        '
        Me.chkCompleted.AutoSize = True
        Me.chkCompleted.Location = New System.Drawing.Point(376, 121)
        Me.chkCompleted.Name = "chkCompleted"
        Me.chkCompleted.Size = New System.Drawing.Size(93, 21)
        Me.chkCompleted.TabIndex = 5
        Me.chkCompleted.Text = "Completed"
        Me.chkCompleted.UseVisualStyleBackColor = True
        '
        'txtJobName
        '
        Me.txtJobName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJobName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobName.Location = New System.Drawing.Point(92, 47)
        Me.txtJobName.Name = "txtJobName"
        Me.txtJobName.Size = New System.Drawing.Size(432, 27)
        Me.txtJobName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer"
        '
        'cbCust
        '
        Me.cbCust.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbCust.FormattingEnabled = True
        Me.cbCust.Location = New System.Drawing.Point(92, 15)
        Me.cbCust.Name = "cbCust"
        Me.cbCust.Size = New System.Drawing.Size(359, 24)
        Me.cbCust.TabIndex = 0
        '
        'pnlTask
        '
        Me.pnlTask.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTask.Controls.Add(Me.TabControl1)
        Me.pnlTask.Location = New System.Drawing.Point(559, 52)
        Me.pnlTask.Name = "pnlTask"
        Me.pnlTask.Size = New System.Drawing.Size(490, 452)
        Me.pnlTask.TabIndex = 4
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(484, 446)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Gainsboro
        Me.TabPage1.Controls.Add(Me.btnRemoveTask)
        Me.TabPage1.Controls.Add(Me.btnAddTask)
        Me.TabPage1.Controls.Add(Me.dgvTasks)
        Me.TabPage1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(476, 417)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Tasks"
        '
        'btnRemoveTask
        '
        Me.btnRemoveTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveTask.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveTask.Location = New System.Drawing.Point(39, 384)
        Me.btnRemoveTask.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRemoveTask.Name = "btnRemoveTask"
        Me.btnRemoveTask.Size = New System.Drawing.Size(74, 26)
        Me.btnRemoveTask.TabIndex = 70
        Me.btnRemoveTask.Text = "-Task"
        Me.btnRemoveTask.UseVisualStyleBackColor = True
        '
        'btnAddTask
        '
        Me.btnAddTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddTask.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddTask.Location = New System.Drawing.Point(363, 384)
        Me.btnAddTask.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAddTask.Name = "btnAddTask"
        Me.btnAddTask.Size = New System.Drawing.Size(74, 26)
        Me.btnAddTask.TabIndex = 69
        Me.btnAddTask.Text = "+Task"
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
        Me.dgvTasks.Location = New System.Drawing.Point(3, 3)
        Me.dgvTasks.Name = "dgvTasks"
        Me.dgvTasks.ReadOnly = True
        Me.dgvTasks.RowHeadersVisible = False
        Me.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTasks.Size = New System.Drawing.Size(470, 374)
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
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Gainsboro
        Me.TabPage2.Controls.Add(Me.btnMaintProducts)
        Me.TabPage2.Controls.Add(Me.dgvProducts)
        Me.TabPage2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(476, 417)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Products"
        '
        'btnMaintProducts
        '
        Me.btnMaintProducts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMaintProducts.Location = New System.Drawing.Point(372, 383)
        Me.btnMaintProducts.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnMaintProducts.Name = "btnMaintProducts"
        Me.btnMaintProducts.Size = New System.Drawing.Size(89, 26)
        Me.btnMaintProducts.TabIndex = 70
        Me.btnMaintProducts.Text = "Products"
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
        Me.dgvProducts.Location = New System.Drawing.Point(3, 3)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.ReadOnly = True
        Me.dgvProducts.RowHeadersVisible = False
        Me.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProducts.Size = New System.Drawing.Size(467, 374)
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
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(419, 499)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(117, 43)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Location = New System.Drawing.Point(33, 499)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(117, 43)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "Save"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'lblScreenName
        '
        Me.lblScreenName.AutoSize = True
        Me.lblScreenName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenName.ForeColor = System.Drawing.Color.Black
        Me.lblScreenName.Location = New System.Drawing.Point(60, 4)
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(49, 25)
        Me.lblScreenName.TabIndex = 66
        Me.lblScreenName.Text = "Job"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 4)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 546)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1061, 22)
        Me.StatusStrip1.TabIndex = 7
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
        'btnInvoice
        '
        Me.btnInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnInvoice.Location = New System.Drawing.Point(220, 499)
        Me.btnInvoice.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnInvoice.Name = "btnInvoice"
        Me.btnInvoice.Size = New System.Drawing.Size(117, 43)
        Me.btnInvoice.TabIndex = 68
        Me.btnInvoice.Text = "Invoice"
        Me.btnInvoice.UseVisualStyleBackColor = True
        '
        'UserTableAdapter
        '
        Me.UserTableAdapter.ClearBeforeFill = True
        '
        'frmJob
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1061, 568)
        Me.Controls.Add(Me.btnInvoice)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblScreenName)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.pnlTask)
        Me.Controls.Add(Me.pnlJob)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmJob"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.pnlJob.ResumeLayout(False)
        Me.pnlJob.PerformLayout()
        CType(Me.UserBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NetwyrksDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTask.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvTasks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlJob As Panel
    Friend WithEvents pnlTask As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents cbCust As ComboBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnClose As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents dgvTasks As DataGridView
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents rtbJobNotes As RichTextBox
    Friend WithEvents chkCompleted As CheckBox
    Friend WithEvents txtJobName As TextBox
    Friend WithEvents btnViewCust As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblScreenName As Label
    Friend WithEvents btnAddTask As Button
    Friend WithEvents btnMaintProducts As Button
    Friend WithEvents jpId As DataGridViewTextBoxColumn
    Friend WithEvents prodSupp As DataGridViewTextBoxColumn
    Friend WithEvents prodId As DataGridViewTextBoxColumn
    Friend WithEvents prodName As DataGridViewTextBoxColumn
    Friend WithEvents prodQty As DataGridViewTextBoxColumn
    Friend WithEvents prodCost As DataGridViewTextBoxColumn
    Friend WithEvents prodPrice As DataGridViewTextBoxColumn
    Friend WithEvents taskId As DataGridViewTextBoxColumn
    Friend WithEvents taskName As DataGridViewTextBoxColumn
    Friend WithEvents taskStartDue As DataGridViewTextBoxColumn
    Friend WithEvents taskStarted As DataGridViewTextBoxColumn
    Friend WithEvents taskCompleted As DataGridViewTextBoxColumn
    Friend WithEvents taskHours As DataGridViewTextBoxColumn
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnRemoveTask As System.Windows.Forms.Button
    Friend WithEvents btnInvoice As System.Windows.Forms.Button
    Friend WithEvents cbUser As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents NetwyrksDataSet As MyBusiness.netwyrksDataSet
    Friend WithEvents UserBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UserTableAdapter As MyBusiness.netwyrksDataSetTableAdapters.userTableAdapter
End Class
