<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJobProducts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJobProducts))
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblJobName = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.dgvJobProducts = New System.Windows.Forms.DataGridView()
        Me.jpId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jpProdId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jpSupp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jpProduct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jpQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jpTaxable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jpRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSupplier = New System.Windows.Forms.DataGridView()
        Me.suppId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suppName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.prodId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodTaxable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodTaxRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.nudQuantity = New System.Windows.Forms.NumericUpDown()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdjust = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkTaxable = New System.Windows.Forms.CheckBox()
        Me.nudTaxRate = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvJobProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTaxRate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.Location = New System.Drawing.Point(14, 15)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 51)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 69
        Me.PictureBox1.TabStop = False
        '
        'lblJobName
        '
        Me.lblJobName.AutoSize = True
        Me.lblJobName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobName.Location = New System.Drawing.Point(71, 75)
        Me.lblJobName.Name = "lblJobName"
        Me.lblJobName.Size = New System.Drawing.Size(78, 19)
        Me.lblJobName.TabIndex = 70
        Me.lblJobName.Text = "Job name"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(651, 632)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 41)
        Me.btnClose.TabIndex = 74
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(12, 632)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(98, 41)
        Me.btnAdd.TabIndex = 73
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 676)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(761, 22)
        Me.StatusStrip1.TabIndex = 72
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'dgvJobProducts
        '
        Me.dgvJobProducts.AllowUserToAddRows = False
        Me.dgvJobProducts.AllowUserToDeleteRows = False
        Me.dgvJobProducts.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvJobProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJobProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.jpId, Me.jpProdId, Me.jpSupp, Me.jpProduct, Me.jpQty, Me.jpTaxable, Me.jpRate})
        Me.dgvJobProducts.Location = New System.Drawing.Point(14, 106)
        Me.dgvJobProducts.MultiSelect = False
        Me.dgvJobProducts.Name = "dgvJobProducts"
        Me.dgvJobProducts.ReadOnly = True
        Me.dgvJobProducts.RowHeadersVisible = False
        Me.dgvJobProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJobProducts.Size = New System.Drawing.Size(735, 279)
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
        'dgvSupplier
        '
        Me.dgvSupplier.AllowUserToAddRows = False
        Me.dgvSupplier.AllowUserToDeleteRows = False
        Me.dgvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSupplier.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.suppId, Me.suppName})
        Me.dgvSupplier.Location = New System.Drawing.Point(14, 402)
        Me.dgvSupplier.MultiSelect = False
        Me.dgvSupplier.Name = "dgvSupplier"
        Me.dgvSupplier.ReadOnly = True
        Me.dgvSupplier.RowHeadersVisible = False
        Me.dgvSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSupplier.Size = New System.Drawing.Size(240, 150)
        Me.dgvSupplier.TabIndex = 76
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
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.prodId, Me.prodName, Me.prodTaxable, Me.prodTaxRate})
        Me.dgvProducts.Location = New System.Drawing.Point(273, 402)
        Me.dgvProducts.MultiSelect = False
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.ReadOnly = True
        Me.dgvProducts.RowHeadersVisible = False
        Me.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProducts.Size = New System.Drawing.Size(476, 150)
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
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Location = New System.Drawing.Point(21, 588)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(108, 17)
        Me.lblProductName.TabIndex = 78
        Me.lblProductName.Text = "Select a product"
        '
        'nudQuantity
        '
        Me.nudQuantity.Location = New System.Drawing.Point(273, 586)
        Me.nudQuantity.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudQuantity.Name = "nudQuantity"
        Me.nudQuantity.Size = New System.Drawing.Size(120, 24)
        Me.nudQuantity.TabIndex = 79
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(290, 632)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(98, 41)
        Me.btnRemove.TabIndex = 80
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdjust
        '
        Me.btnAdjust.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdjust.Location = New System.Drawing.Point(151, 632)
        Me.btnAdjust.Name = "btnAdjust"
        Me.btnAdjust.Size = New System.Drawing.Size(98, 41)
        Me.btnAdjust.TabIndex = 81
        Me.btnAdjust.Text = "Adjust"
        Me.btnAdjust.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(270, 566)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 17)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Qty"
        '
        'chkTaxable
        '
        Me.chkTaxable.AutoSize = True
        Me.chkTaxable.Location = New System.Drawing.Point(420, 587)
        Me.chkTaxable.Name = "chkTaxable"
        Me.chkTaxable.Size = New System.Drawing.Size(86, 21)
        Me.chkTaxable.TabIndex = 83
        Me.chkTaxable.Text = "is Taxable"
        Me.chkTaxable.UseVisualStyleBackColor = True
        '
        'nudTaxRate
        '
        Me.nudTaxRate.DecimalPlaces = 2
        Me.nudTaxRate.Location = New System.Drawing.Point(586, 586)
        Me.nudTaxRate.Name = "nudTaxRate"
        Me.nudTaxRate.Size = New System.Drawing.Size(80, 24)
        Me.nudTaxRate.TabIndex = 84
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(526, 588)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 17)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Rate %"
        '
        'frmJobProducts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(761, 698)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nudTaxRate)
        Me.Controls.Add(Me.chkTaxable)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAdjust)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.nudQuantity)
        Me.Controls.Add(Me.lblProductName)
        Me.Controls.Add(Me.dgvProducts)
        Me.Controls.Add(Me.dgvSupplier)
        Me.Controls.Add(Me.dgvJobProducts)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lblJobName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblScreenName)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmJobProducts"
        Me.ShowIcon = False
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvJobProducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTaxRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblScreenName As Label
    Friend WithEvents lblJobName As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents dgvJobProducts As DataGridView
    Friend WithEvents dgvSupplier As DataGridView
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents lblProductName As Label
    Friend WithEvents nudQuantity As NumericUpDown
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnAdjust As Button
    Friend WithEvents suppId As DataGridViewTextBoxColumn
    Friend WithEvents suppName As DataGridViewTextBoxColumn
    Friend WithEvents jpId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jpProdId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jpSupp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jpProduct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jpQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jpTaxable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jpRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkTaxable As System.Windows.Forms.CheckBox
    Friend WithEvents nudTaxRate As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents prodId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prodName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prodTaxable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prodTaxRate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
