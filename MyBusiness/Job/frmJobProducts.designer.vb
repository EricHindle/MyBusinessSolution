<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJobProducts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmJobProducts))
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblJobName = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblF5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvJobProducts = New System.Windows.Forms.DataGridView()
        Me.jpId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jpProdId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jpSupp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jpProduct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jpQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jpTaxable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jpRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jpprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvSupplier = New System.Windows.Forms.DataGridView()
        Me.suppId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suppName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.prodId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodTaxable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodTaxRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.NudQuantity = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkTaxable = New System.Windows.Forms.CheckBox()
        Me.nudTaxRate = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.nudPrice = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NudUnitPrice = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PicUpdate = New System.Windows.Forms.PictureBox()
        Me.PicAdd = New System.Windows.Forms.PictureBox()
        Me.PicRemove = New System.Windows.Forms.PictureBox()
        Me.PicClose = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgvJobProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTaxRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.nudPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudUnitPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblScreenName
        '
        Me.lblScreenName.AutoSize = True
        Me.lblScreenName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenName.ForeColor = System.Drawing.Color.Black
        Me.lblScreenName.Location = New System.Drawing.Point(70, 15)
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(179, 25)
        Me.lblScreenName.TabIndex = 68
        Me.lblScreenName.Text = "Job Products"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(16, 15)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 69
        Me.PictureBox1.TabStop = False
        '
        'lblJobName
        '
        Me.lblJobName.AutoSize = True
        Me.lblJobName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobName.Location = New System.Drawing.Point(71, 65)
        Me.lblJobName.Name = "lblJobName"
        Me.lblJobName.Size = New System.Drawing.Size(78, 19)
        Me.lblJobName.TabIndex = 70
        Me.lblJobName.Text = "Job name"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblF5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 631)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(764, 30)
        Me.StatusStrip1.TabIndex = 72
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblF5
        '
        Me.LblF5.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.LblF5.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.LblF5.Margin = New System.Windows.Forms.Padding(3, 3, 5, 2)
        Me.LblF5.Name = "LblF5"
        Me.LblF5.Padding = New System.Windows.Forms.Padding(3)
        Me.LblF5.Size = New System.Drawing.Size(105, 25)
        Me.LblF5.Text = "F5=Add Supplier"
        '
        'dgvJobProducts
        '
        Me.dgvJobProducts.AllowUserToAddRows = False
        Me.dgvJobProducts.AllowUserToDeleteRows = False
        Me.dgvJobProducts.AllowUserToResizeRows = False
        Me.dgvJobProducts.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvJobProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJobProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.jpId, Me.jpProdId, Me.jpSupp, Me.jpProduct, Me.jpQty, Me.jpTaxable, Me.jpRate, Me.jpprice})
        Me.dgvJobProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvJobProducts.Location = New System.Drawing.Point(0, 0)
        Me.dgvJobProducts.MultiSelect = False
        Me.dgvJobProducts.Name = "dgvJobProducts"
        Me.dgvJobProducts.ReadOnly = True
        Me.dgvJobProducts.RowHeadersVisible = False
        Me.dgvJobProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJobProducts.Size = New System.Drawing.Size(732, 201)
        Me.dgvJobProducts.TabIndex = 75
        '
        'jpId
        '
        Me.jpId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.jpId.HeaderText = "Id"
        Me.jpId.Name = "jpId"
        Me.jpId.ReadOnly = True
        Me.jpId.Visible = False
        Me.jpId.Width = 60
        '
        'jpProdId
        '
        Me.jpProdId.HeaderText = "ProdId"
        Me.jpProdId.Name = "jpProdId"
        Me.jpProdId.ReadOnly = True
        Me.jpProdId.Visible = False
        '
        'jpSupp
        '
        Me.jpSupp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.jpSupp.HeaderText = "Supplier"
        Me.jpSupp.Name = "jpSupp"
        Me.jpSupp.ReadOnly = True
        Me.jpSupp.Width = 200
        '
        'jpProduct
        '
        Me.jpProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.jpProduct.HeaderText = "Product"
        Me.jpProduct.Name = "jpProduct"
        Me.jpProduct.ReadOnly = True
        '
        'jpQty
        '
        Me.jpQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.jpQty.HeaderText = "Quantity"
        Me.jpQty.Name = "jpQty"
        Me.jpQty.ReadOnly = True
        '
        'jpTaxable
        '
        Me.jpTaxable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.jpTaxable.HeaderText = "Taxable"
        Me.jpTaxable.Name = "jpTaxable"
        Me.jpTaxable.ReadOnly = True
        Me.jpTaxable.Width = 65
        '
        'jpRate
        '
        Me.jpRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.jpRate.HeaderText = "Rate (%)"
        Me.jpRate.Name = "jpRate"
        Me.jpRate.ReadOnly = True
        Me.jpRate.Width = 90
        '
        'jpprice
        '
        Me.jpprice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.jpprice.HeaderText = "Price"
        Me.jpprice.Name = "jpprice"
        Me.jpprice.ReadOnly = True
        Me.jpprice.Width = 80
        '
        'DgvSupplier
        '
        Me.DgvSupplier.AllowUserToAddRows = False
        Me.DgvSupplier.AllowUserToDeleteRows = False
        Me.DgvSupplier.AllowUserToResizeRows = False
        Me.DgvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSupplier.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.suppId, Me.suppName})
        Me.DgvSupplier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvSupplier.Location = New System.Drawing.Point(0, 0)
        Me.DgvSupplier.MultiSelect = False
        Me.DgvSupplier.Name = "DgvSupplier"
        Me.DgvSupplier.ReadOnly = True
        Me.DgvSupplier.RowHeadersVisible = False
        Me.DgvSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSupplier.Size = New System.Drawing.Size(240, 198)
        Me.DgvSupplier.TabIndex = 76
        '
        'suppId
        '
        Me.suppId.HeaderText = "Id"
        Me.suppId.Name = "suppId"
        Me.suppId.ReadOnly = True
        Me.suppId.Visible = False
        '
        'suppName
        '
        Me.suppName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.suppName.HeaderText = "Supplier name"
        Me.suppName.Name = "suppName"
        Me.suppName.ReadOnly = True
        '
        'dgvProducts
        '
        Me.dgvProducts.AllowUserToAddRows = False
        Me.dgvProducts.AllowUserToDeleteRows = False
        Me.dgvProducts.AllowUserToResizeRows = False
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.prodId, Me.prodName, Me.prodTaxable, Me.prodTaxRate, Me.prodPrice})
        Me.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProducts.Location = New System.Drawing.Point(0, 0)
        Me.dgvProducts.MultiSelect = False
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.ReadOnly = True
        Me.dgvProducts.RowHeadersVisible = False
        Me.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProducts.Size = New System.Drawing.Size(484, 198)
        Me.dgvProducts.TabIndex = 77
        '
        'prodId
        '
        Me.prodId.HeaderText = "Id"
        Me.prodId.Name = "prodId"
        Me.prodId.ReadOnly = True
        Me.prodId.Visible = False
        '
        'prodName
        '
        Me.prodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.prodName.HeaderText = "Product name"
        Me.prodName.Name = "prodName"
        Me.prodName.ReadOnly = True
        '
        'prodTaxable
        '
        Me.prodTaxable.HeaderText = "Taxable"
        Me.prodTaxable.Name = "prodTaxable"
        Me.prodTaxable.ReadOnly = True
        Me.prodTaxable.Visible = False
        '
        'prodTaxRate
        '
        Me.prodTaxRate.HeaderText = "Rate"
        Me.prodTaxRate.Name = "prodTaxRate"
        Me.prodTaxRate.ReadOnly = True
        Me.prodTaxRate.Visible = False
        '
        'prodPrice
        '
        Me.prodPrice.HeaderText = "Price"
        Me.prodPrice.Name = "prodPrice"
        Me.prodPrice.ReadOnly = True
        Me.prodPrice.Visible = False
        '
        'lblProductName
        '
        Me.lblProductName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Location = New System.Drawing.Point(27, 516)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(108, 17)
        Me.lblProductName.TabIndex = 78
        Me.lblProductName.Text = "Select a product"
        '
        'NudQuantity
        '
        Me.NudQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NudQuantity.Location = New System.Drawing.Point(266, 516)
        Me.NudQuantity.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NudQuantity.Name = "NudQuantity"
        Me.NudQuantity.Size = New System.Drawing.Size(120, 24)
        Me.NudQuantity.TabIndex = 79
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(229, 516)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 17)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Qty"
        '
        'chkTaxable
        '
        Me.chkTaxable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkTaxable.AutoSize = True
        Me.chkTaxable.Location = New System.Drawing.Point(503, 545)
        Me.chkTaxable.Name = "chkTaxable"
        Me.chkTaxable.Size = New System.Drawing.Size(86, 21)
        Me.chkTaxable.TabIndex = 83
        Me.chkTaxable.Text = "is Taxable"
        Me.ToolTip1.SetToolTip(Me.chkTaxable, "Add tax to the price?")
        Me.chkTaxable.UseVisualStyleBackColor = True
        '
        'nudTaxRate
        '
        Me.nudTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudTaxRate.DecimalPlaces = 2
        Me.nudTaxRate.Location = New System.Drawing.Point(669, 544)
        Me.nudTaxRate.Name = "nudTaxRate"
        Me.nudTaxRate.Size = New System.Drawing.Size(80, 24)
        Me.nudTaxRate.TabIndex = 84
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(609, 546)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 17)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Rate %"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgvSupplier)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvProducts)
        Me.SplitContainer1.Size = New System.Drawing.Size(736, 202)
        Me.SplitContainer1.SplitterDistance = 244
        Me.SplitContainer1.TabIndex = 86
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Location = New System.Drawing.Point(16, 97)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgvJobProducts)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(736, 411)
        Me.SplitContainer2.SplitterDistance = 205
        Me.SplitContainer2.TabIndex = 87
        '
        'nudPrice
        '
        Me.nudPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudPrice.DecimalPlaces = 2
        Me.nudPrice.Location = New System.Drawing.Point(629, 514)
        Me.nudPrice.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudPrice.Name = "nudPrice"
        Me.nudPrice.Size = New System.Drawing.Size(120, 24)
        Me.nudPrice.TabIndex = 88
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(586, 516)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 17)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "Price"
        '
        'NudUnitPrice
        '
        Me.NudUnitPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NudUnitPrice.DecimalPlaces = 2
        Me.NudUnitPrice.Enabled = False
        Me.NudUnitPrice.Location = New System.Drawing.Point(488, 516)
        Me.NudUnitPrice.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NudUnitPrice.Name = "NudUnitPrice"
        Me.NudUnitPrice.Size = New System.Drawing.Size(82, 24)
        Me.NudUnitPrice.TabIndex = 90
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(417, 518)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Unit Price"
        '
        'PicUpdate
        '
        Me.PicUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicUpdate.Image = Global.MyBusiness.My.Resources.Resources.update
        Me.PicUpdate.InitialImage = Nothing
        Me.PicUpdate.Location = New System.Drawing.Point(82, 580)
        Me.PicUpdate.Name = "PicUpdate"
        Me.PicUpdate.Size = New System.Drawing.Size(42, 42)
        Me.PicUpdate.TabIndex = 102
        Me.PicUpdate.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicUpdate, "Update the product on the job")
        '
        'PicAdd
        '
        Me.PicAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicAdd.Image = Global.MyBusiness.My.Resources.Resources.add
        Me.PicAdd.InitialImage = Nothing
        Me.PicAdd.Location = New System.Drawing.Point(18, 579)
        Me.PicAdd.Name = "PicAdd"
        Me.PicAdd.Size = New System.Drawing.Size(42, 42)
        Me.PicAdd.TabIndex = 101
        Me.PicAdd.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicAdd, "Add a product to the job")
        '
        'PicRemove
        '
        Me.PicRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicRemove.Image = Global.MyBusiness.My.Resources.Resources.remove
        Me.PicRemove.InitialImage = Nothing
        Me.PicRemove.Location = New System.Drawing.Point(149, 580)
        Me.PicRemove.Name = "PicRemove"
        Me.PicRemove.Size = New System.Drawing.Size(42, 42)
        Me.PicRemove.TabIndex = 100
        Me.PicRemove.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicRemove, "Remove the product from the job")
        '
        'PicClose
        '
        Me.PicClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicClose.Image = Global.MyBusiness.My.Resources.Resources.exitbutton
        Me.PicClose.InitialImage = Nothing
        Me.PicClose.Location = New System.Drawing.Point(710, 579)
        Me.PicClose.Name = "PicClose"
        Me.PicClose.Size = New System.Drawing.Size(42, 42)
        Me.PicClose.TabIndex = 99
        Me.PicClose.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicClose, "Close the form")
        '
        'FrmJobProducts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(764, 661)
        Me.Controls.Add(Me.PicUpdate)
        Me.Controls.Add(Me.PicAdd)
        Me.Controls.Add(Me.PicRemove)
        Me.Controls.Add(Me.PicClose)
        Me.Controls.Add(Me.NudUnitPrice)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nudPrice)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nudTaxRate)
        Me.Controls.Add(Me.chkTaxable)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NudQuantity)
        Me.Controls.Add(Me.lblProductName)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lblJobName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblScreenName)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(780, 700)
        Me.Name = "FrmJobProducts"
        Me.ShowIcon = False
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgvJobProducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTaxRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.nudPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudUnitPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblScreenName As Label
    Friend WithEvents lblJobName As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents dgvJobProducts As DataGridView
    Friend WithEvents DgvSupplier As DataGridView
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents lblProductName As Label
    Friend WithEvents NudQuantity As NumericUpDown
    Friend WithEvents suppId As DataGridViewTextBoxColumn
    Friend WithEvents suppName As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkTaxable As System.Windows.Forms.CheckBox
    Friend WithEvents nudTaxRate As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblF5 As ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents nudPrice As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents jpId As DataGridViewTextBoxColumn
    Friend WithEvents jpProdId As DataGridViewTextBoxColumn
    Friend WithEvents jpSupp As DataGridViewTextBoxColumn
    Friend WithEvents jpProduct As DataGridViewTextBoxColumn
    Friend WithEvents jpQty As DataGridViewTextBoxColumn
    Friend WithEvents jpTaxable As DataGridViewTextBoxColumn
    Friend WithEvents jpRate As DataGridViewTextBoxColumn
    Friend WithEvents jpprice As DataGridViewTextBoxColumn
    Friend WithEvents prodId As DataGridViewTextBoxColumn
    Friend WithEvents prodName As DataGridViewTextBoxColumn
    Friend WithEvents prodTaxable As DataGridViewTextBoxColumn
    Friend WithEvents prodTaxRate As DataGridViewTextBoxColumn
    Friend WithEvents prodPrice As DataGridViewTextBoxColumn
    Friend WithEvents NudUnitPrice As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents PicUpdate As PictureBox
    Friend WithEvents PicAdd As PictureBox
    Friend WithEvents PicRemove As PictureBox
    Friend WithEvents PicClose As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
