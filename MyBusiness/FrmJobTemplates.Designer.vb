' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJobTemplates
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmJobTemplates))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAddTask = New System.Windows.Forms.Button()
        Me.btnRemoveTask = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DgvTemplates = New System.Windows.Forms.DataGridView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvTasks = New System.Windows.Forms.DataGridView()
        Me.taskId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskStartDue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskStarted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskCompleted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taskPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnMaintProducts = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.jpId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodSupp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jobPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PicClose = New System.Windows.Forms.PictureBox()
        Me.PicUpdate = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgvTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'SplitContainer1
        '
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
        Me.DgvTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTemplates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTemplates.Location = New System.Drawing.Point(0, 0)
        Me.DgvTemplates.Name = "DgvTemplates"
        Me.DgvTemplates.Size = New System.Drawing.Size(297, 333)
        Me.DgvTemplates.TabIndex = 0
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgvTasks)
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
        'dgvTasks
        '
        Me.dgvTasks.AllowUserToAddRows = False
        Me.dgvTasks.AllowUserToDeleteRows = False
        Me.dgvTasks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTasks.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTasks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.taskId, Me.taskName, Me.taskStartDue, Me.taskStarted, Me.taskCompleted, Me.taskHours, Me.taskPrice})
        Me.dgvTasks.Location = New System.Drawing.Point(8, 39)
        Me.dgvTasks.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dgvTasks.Name = "dgvTasks"
        Me.dgvTasks.ReadOnly = True
        Me.dgvTasks.RowHeadersVisible = False
        Me.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTasks.Size = New System.Drawing.Size(582, 119)
        Me.dgvTasks.TabIndex = 72
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
        Me.dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.jpId, Me.prodSupp, Me.prodId, Me.prodName, Me.prodQty, Me.prodCost, Me.prodPrice, Me.jobPrice})
        Me.dgvProducts.Location = New System.Drawing.Point(8, 35)
        Me.dgvProducts.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.ReadOnly = True
        Me.dgvProducts.RowHeadersVisible = False
        Me.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProducts.Size = New System.Drawing.Size(582, 124)
        Me.dgvProducts.TabIndex = 73
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
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.MyBusiness.My.Resources.Resources.add
        Me.PictureBox2.InitialImage = Nothing
        Me.PictureBox2.Location = New System.Drawing.Point(12, 520)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(42, 42)
        Me.PictureBox2.TabIndex = 102
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.MyBusiness.My.Resources.Resources.remove
        Me.PictureBox3.InitialImage = Nothing
        Me.PictureBox3.Location = New System.Drawing.Point(108, 520)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(42, 42)
        Me.PictureBox3.TabIndex = 103
        Me.PictureBox3.TabStop = False
        '
        'FrmJobTemplates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 587)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
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
        CType(Me.dgvTasks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvTasks As DataGridView
    Friend WithEvents taskId As DataGridViewTextBoxColumn
    Friend WithEvents taskName As DataGridViewTextBoxColumn
    Friend WithEvents taskStartDue As DataGridViewTextBoxColumn
    Friend WithEvents taskStarted As DataGridViewTextBoxColumn
    Friend WithEvents taskCompleted As DataGridViewTextBoxColumn
    Friend WithEvents taskHours As DataGridViewTextBoxColumn
    Friend WithEvents taskPrice As DataGridViewTextBoxColumn
    Friend WithEvents btnRemoveTask As Button
    Friend WithEvents DgvTemplates As DataGridView
    Friend WithEvents btnMaintProducts As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents jpId As DataGridViewTextBoxColumn
    Friend WithEvents prodSupp As DataGridViewTextBoxColumn
    Friend WithEvents prodId As DataGridViewTextBoxColumn
    Friend WithEvents prodName As DataGridViewTextBoxColumn
    Friend WithEvents prodQty As DataGridViewTextBoxColumn
    Friend WithEvents prodCost As DataGridViewTextBoxColumn
    Friend WithEvents prodPrice As DataGridViewTextBoxColumn
    Friend WithEvents jobPrice As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
End Class
