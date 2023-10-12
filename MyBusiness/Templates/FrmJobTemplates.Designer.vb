' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmJobTemplates
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmJobTemplates))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAddTask = New System.Windows.Forms.Button()
        Me.btnRemoveTask = New System.Windows.Forms.Button()
        Me.PicClear = New System.Windows.Forms.PictureBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DgvTemplates = New System.Windows.Forms.DataGridView()
        Me.tmplId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmplName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DgvTasks = New System.Windows.Forms.DataGridView()
        Me.taskId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnMaintProducts = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.tpId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpSupp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpProdId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpProdName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PicClose = New System.Windows.Forms.PictureBox()
        Me.PicUpdate = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.PicAddTemplate = New System.Windows.Forms.PictureBox()
        Me.PicDeleteTemplate = New System.Windows.Forms.PictureBox()
        Me.TxtTmplName = New System.Windows.Forms.TextBox()
        Me.TxtTmplDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblId = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PicClear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgvTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DgvTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicAddTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicDeleteTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 565)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(933, 22)
        Me.StatusStrip1.TabIndex = 96
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(2, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(9, 17)
        '
        'btnAddTask
        '
        Me.btnAddTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddTask.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddTask.Location = New System.Drawing.Point(410, 4)
        Me.btnAddTask.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddTask.Name = "btnAddTask"
        Me.btnAddTask.Size = New System.Drawing.Size(86, 28)
        Me.btnAddTask.TabIndex = 73
        Me.btnAddTask.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.btnAddTask, "Add a task")
        Me.btnAddTask.UseVisualStyleBackColor = True
        '
        'btnRemoveTask
        '
        Me.btnRemoveTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveTask.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveTask.Location = New System.Drawing.Point(504, 4)
        Me.btnRemoveTask.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemoveTask.Name = "btnRemoveTask"
        Me.btnRemoveTask.Size = New System.Drawing.Size(86, 28)
        Me.btnRemoveTask.TabIndex = 74
        Me.btnRemoveTask.Text = "Remove"
        Me.ToolTip1.SetToolTip(Me.btnRemoveTask, "Remove the selected task")
        Me.btnRemoveTask.UseVisualStyleBackColor = True
        '
        'PicClear
        '
        Me.PicClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicClear.Image = Global.MyBusiness.My.Resources.Resources.refresh
        Me.PicClear.InitialImage = Nothing
        Me.PicClear.Location = New System.Drawing.Point(891, 446)
        Me.PicClear.Margin = New System.Windows.Forms.Padding(4)
        Me.PicClear.Name = "PicClear"
        Me.PicClear.Size = New System.Drawing.Size(30, 30)
        Me.PicClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicClear.TabIndex = 134
        Me.PicClear.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicClear, "Clear the form")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(15, 78)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgvTemplates)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(904, 337)
        Me.SplitContainer1.SplitterDistance = 301
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 97
        '
        'DgvTemplates
        '
        Me.DgvTemplates.AllowUserToAddRows = False
        Me.DgvTemplates.AllowUserToDeleteRows = False
        Me.DgvTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTemplates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tmplId, Me.tmplName})
        Me.DgvTemplates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTemplates.Location = New System.Drawing.Point(0, 0)
        Me.DgvTemplates.MultiSelect = False
        Me.DgvTemplates.Name = "DgvTemplates"
        Me.DgvTemplates.ReadOnly = True
        Me.DgvTemplates.RowHeadersVisible = False
        Me.DgvTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvTemplates.Size = New System.Drawing.Size(297, 333)
        Me.DgvTemplates.TabIndex = 0
        '
        'tmplId
        '
        Me.tmplId.HeaderText = "Id"
        Me.tmplId.Name = "tmplId"
        Me.tmplId.ReadOnly = True
        Me.tmplId.Visible = False
        '
        'tmplName
        '
        Me.tmplName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tmplName.HeaderText = "Name"
        Me.tmplName.Name = "tmplName"
        Me.tmplName.ReadOnly = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnAddTask)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DgvTasks)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnRemoveTask)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnMaintProducts)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvProducts)
        Me.SplitContainer2.Size = New System.Drawing.Size(598, 337)
        Me.SplitContainer2.SplitterDistance = 165
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 7)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 19)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Tasks"
        '
        'DgvTasks
        '
        Me.DgvTasks.AllowUserToAddRows = False
        Me.DgvTasks.AllowUserToDeleteRows = False
        Me.DgvTasks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvTasks.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTasks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.taskId, Me.taskName, Me.taskHours, Me.taskPrice})
        Me.DgvTasks.Location = New System.Drawing.Point(8, 39)
        Me.DgvTasks.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DgvTasks.Name = "DgvTasks"
        Me.DgvTasks.ReadOnly = True
        Me.DgvTasks.RowHeadersVisible = False
        Me.DgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvTasks.Size = New System.Drawing.Size(582, 119)
        Me.DgvTasks.TabIndex = 72
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
        Me.btnMaintProducts.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaintProducts.Location = New System.Drawing.Point(504, 4)
        Me.btnMaintProducts.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMaintProducts.Name = "btnMaintProducts"
        Me.btnMaintProducts.Size = New System.Drawing.Size(86, 24)
        Me.btnMaintProducts.TabIndex = 74
        Me.btnMaintProducts.Text = "Update"
        Me.btnMaintProducts.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 5)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 19)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Products"
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
        Me.dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tpId, Me.tpSupp, Me.tpProdId, Me.tpProdName, Me.tpQty, Me.tpCost})
        Me.dgvProducts.Location = New System.Drawing.Point(8, 35)
        Me.dgvProducts.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.ReadOnly = True
        Me.dgvProducts.RowHeadersVisible = False
        Me.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProducts.Size = New System.Drawing.Size(582, 120)
        Me.dgvProducts.TabIndex = 73
        '
        'tpId
        '
        Me.tpId.HeaderText = "Id"
        Me.tpId.Name = "tpId"
        Me.tpId.ReadOnly = True
        Me.tpId.Visible = False
        '
        'tpSupp
        '
        Me.tpSupp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tpSupp.HeaderText = "Supplier"
        Me.tpSupp.Name = "tpSupp"
        Me.tpSupp.ReadOnly = True
        Me.tpSupp.Width = 120
        '
        'tpProdId
        '
        Me.tpProdId.HeaderText = "prodId"
        Me.tpProdId.Name = "tpProdId"
        Me.tpProdId.ReadOnly = True
        Me.tpProdId.Visible = False
        '
        'tpProdName
        '
        Me.tpProdName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tpProdName.HeaderText = "ProductName"
        Me.tpProdName.Name = "tpProdName"
        Me.tpProdName.ReadOnly = True
        '
        'tpQty
        '
        Me.tpQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tpQty.HeaderText = "Qty"
        Me.tpQty.Name = "tpQty"
        Me.tpQty.ReadOnly = True
        Me.tpQty.Width = 60
        '
        'tpCost
        '
        Me.tpCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tpCost.HeaderText = "Unit Cost"
        Me.tpCost.Name = "tpCost"
        Me.tpCost.ReadOnly = True
        Me.tpCost.Width = 90
        '
        'PicClose
        '
        Me.PicClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicClose.Image = Global.MyBusiness.My.Resources.Resources.exitbutton
        Me.PicClose.InitialImage = Nothing
        Me.PicClose.Location = New System.Drawing.Point(879, 520)
        Me.PicClose.Name = "PicClose"
        Me.PicClose.Size = New System.Drawing.Size(42, 42)
        Me.PicClose.TabIndex = 101
        Me.PicClose.TabStop = False
        '
        'PicUpdate
        '
        Me.PicUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicUpdate.Image = Global.MyBusiness.My.Resources.Resources.update
        Me.PicUpdate.InitialImage = Nothing
        Me.PicUpdate.Location = New System.Drawing.Point(60, 520)
        Me.PicUpdate.Name = "PicUpdate"
        Me.PicUpdate.Size = New System.Drawing.Size(42, 42)
        Me.PicUpdate.TabIndex = 100
        Me.PicUpdate.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.Location = New System.Drawing.Point(15, 12)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 45)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 99
        Me.PictureBox1.TabStop = False
        '
        'lblScreenName
        '
        Me.lblScreenName.AutoSize = True
        Me.lblScreenName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenName.ForeColor = System.Drawing.Color.Black
        Me.lblScreenName.Location = New System.Drawing.Point(71, 12)
        Me.lblScreenName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(174, 25)
        Me.lblScreenName.TabIndex = 98
        Me.lblScreenName.Text = "Job Templates"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PicAddTemplate
        '
        Me.PicAddTemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicAddTemplate.Image = Global.MyBusiness.My.Resources.Resources.add
        Me.PicAddTemplate.InitialImage = Nothing
        Me.PicAddTemplate.Location = New System.Drawing.Point(12, 520)
        Me.PicAddTemplate.Name = "PicAddTemplate"
        Me.PicAddTemplate.Size = New System.Drawing.Size(42, 42)
        Me.PicAddTemplate.TabIndex = 102
        Me.PicAddTemplate.TabStop = False
        '
        'PicDeleteTemplate
        '
        Me.PicDeleteTemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicDeleteTemplate.Image = Global.MyBusiness.My.Resources.Resources.remove
        Me.PicDeleteTemplate.InitialImage = Nothing
        Me.PicDeleteTemplate.Location = New System.Drawing.Point(108, 520)
        Me.PicDeleteTemplate.Name = "PicDeleteTemplate"
        Me.PicDeleteTemplate.Size = New System.Drawing.Size(42, 42)
        Me.PicDeleteTemplate.TabIndex = 103
        Me.PicDeleteTemplate.TabStop = False
        '
        'TxtTmplName
        '
        Me.TxtTmplName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtTmplName.Location = New System.Drawing.Point(69, 446)
        Me.TxtTmplName.Name = "TxtTmplName"
        Me.TxtTmplName.Size = New System.Drawing.Size(256, 24)
        Me.TxtTmplName.TabIndex = 104
        '
        'TxtTmplDesc
        '
        Me.TxtTmplDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTmplDesc.Location = New System.Drawing.Point(331, 446)
        Me.TxtTmplDesc.Multiline = True
        Me.TxtTmplDesc.Name = "TxtTmplDesc"
        Me.TxtTmplDesc.Size = New System.Drawing.Size(525, 56)
        Me.TxtTmplDesc.TabIndex = 105
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(66, 426)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(329, 426)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Description"
        '
        'LblId
        '
        Me.LblId.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblId.AutoSize = True
        Me.LblId.Location = New System.Drawing.Point(16, 449)
        Me.LblId.Name = "LblId"
        Me.LblId.Size = New System.Drawing.Size(21, 17)
        Me.LblId.TabIndex = 108
        Me.LblId.Text = "-1"
        '
        'FrmJobTemplates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 587)
        Me.Controls.Add(Me.PicClear)
        Me.Controls.Add(Me.LblId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtTmplDesc)
        Me.Controls.Add(Me.TxtTmplName)
        Me.Controls.Add(Me.PicDeleteTemplate)
        Me.Controls.Add(Me.PicAddTemplate)
        Me.Controls.Add(Me.PicClose)
        Me.Controls.Add(Me.PicUpdate)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblScreenName)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmJobTemplates"
        Me.ShowIcon = False
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PicClear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DgvTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DgvTasks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicAddTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicDeleteTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents PicClose As PictureBox
    Friend WithEvents PicUpdate As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblScreenName As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnAddTask As Button
    Friend WithEvents DgvTasks As DataGridView
    Friend WithEvents btnRemoveTask As Button
    Friend WithEvents DgvTemplates As DataGridView
    Friend WithEvents btnMaintProducts As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents PicAddTemplate As PictureBox
    Friend WithEvents PicDeleteTemplate As PictureBox
    Friend WithEvents tmplId As DataGridViewTextBoxColumn
    Friend WithEvents tmplName As DataGridViewTextBoxColumn
    Friend WithEvents TxtTmplName As TextBox
    Friend WithEvents TxtTmplDesc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblId As Label
    Friend WithEvents taskId As DataGridViewTextBoxColumn
    Friend WithEvents taskName As DataGridViewTextBoxColumn
    Friend WithEvents taskHours As DataGridViewTextBoxColumn
    Friend WithEvents taskPrice As DataGridViewTextBoxColumn
    Friend WithEvents tpId As DataGridViewTextBoxColumn
    Friend WithEvents tpSupp As DataGridViewTextBoxColumn
    Friend WithEvents tpProdId As DataGridViewTextBoxColumn
    Friend WithEvents tpProdName As DataGridViewTextBoxColumn
    Friend WithEvents tpQty As DataGridViewTextBoxColumn
    Friend WithEvents tpCost As DataGridViewTextBoxColumn
    Friend WithEvents PicClear As PictureBox
End Class
