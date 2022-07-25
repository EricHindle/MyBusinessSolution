<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSupplier
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSupplier))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.pnlSupplier = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtWeb = New System.Windows.Forms.TextBox()
        Me.ChkAmazon = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rtbSuppNotes = New System.Windows.Forms.RichTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudSuppDiscount = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSuppEmail = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSuppPhone = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSuppPostcode = New System.Windows.Forms.TextBox()
        Me.txtSuppAddr4 = New System.Windows.Forms.TextBox()
        Me.txtSuppAddr3 = New System.Windows.Forms.TextBox()
        Me.txtSuppAddr2 = New System.Windows.Forms.TextBox()
        Me.txtSuppAddr1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSuppName = New System.Windows.Forms.TextBox()
        Me.pnlProducts = New System.Windows.Forms.Panel()
        Me.spProducts = New System.Windows.Forms.SplitContainer()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.prodId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtCost = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtProductDesc = New System.Windows.Forms.TextBox()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSupplier.SuspendLayout()
        CType(Me.nudSuppDiscount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProducts.SuspendLayout()
        CType(Me.spProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spProducts.Panel1.SuspendLayout()
        Me.spProducts.Panel2.SuspendLayout()
        Me.spProducts.SuspendLayout()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.Location = New System.Drawing.Point(14, 15)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(42, 42)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 69
        Me.PictureBox1.TabStop = False
        '
        'lblScreenName
        '
        Me.lblScreenName.AutoSize = True
        Me.lblScreenName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenName.ForeColor = System.Drawing.Color.Black
        Me.lblScreenName.Location = New System.Drawing.Point(70, 15)
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(111, 25)
        Me.lblScreenName.TabIndex = 68
        Me.lblScreenName.Text = "Supplier"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(374, 555)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(114, 50)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Location = New System.Drawing.Point(16, 555)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(114, 50)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 609)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(852, 22)
        Me.StatusStrip1.TabIndex = 72
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'pnlSupplier
        '
        Me.pnlSupplier.Controls.Add(Me.Label8)
        Me.pnlSupplier.Controls.Add(Me.TxtWeb)
        Me.pnlSupplier.Controls.Add(Me.ChkAmazon)
        Me.pnlSupplier.Controls.Add(Me.Label7)
        Me.pnlSupplier.Controls.Add(Me.rtbSuppNotes)
        Me.pnlSupplier.Controls.Add(Me.Label6)
        Me.pnlSupplier.Controls.Add(Me.nudSuppDiscount)
        Me.pnlSupplier.Controls.Add(Me.Label5)
        Me.pnlSupplier.Controls.Add(Me.txtSuppEmail)
        Me.pnlSupplier.Controls.Add(Me.Label4)
        Me.pnlSupplier.Controls.Add(Me.txtSuppPhone)
        Me.pnlSupplier.Controls.Add(Me.Label3)
        Me.pnlSupplier.Controls.Add(Me.Label2)
        Me.pnlSupplier.Controls.Add(Me.txtSuppPostcode)
        Me.pnlSupplier.Controls.Add(Me.txtSuppAddr4)
        Me.pnlSupplier.Controls.Add(Me.txtSuppAddr3)
        Me.pnlSupplier.Controls.Add(Me.txtSuppAddr2)
        Me.pnlSupplier.Controls.Add(Me.txtSuppAddr1)
        Me.pnlSupplier.Controls.Add(Me.Label1)
        Me.pnlSupplier.Controls.Add(Me.txtSuppName)
        Me.pnlSupplier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSupplier.Location = New System.Drawing.Point(0, 0)
        Me.pnlSupplier.Name = "pnlSupplier"
        Me.pnlSupplier.Size = New System.Drawing.Size(440, 480)
        Me.pnlSupplier.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 281)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 17)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Web"
        '
        'TxtWeb
        '
        Me.TxtWeb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtWeb.Location = New System.Drawing.Point(112, 281)
        Me.TxtWeb.Name = "TxtWeb"
        Me.TxtWeb.Size = New System.Drawing.Size(306, 24)
        Me.TxtWeb.TabIndex = 8
        '
        'ChkAmazon
        '
        Me.ChkAmazon.AutoSize = True
        Me.ChkAmazon.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ChkAmazon.Location = New System.Drawing.Point(298, 337)
        Me.ChkAmazon.Name = "ChkAmazon"
        Me.ChkAmazon.Size = New System.Drawing.Size(76, 21)
        Me.ChkAmazon.TabIndex = 10
        Me.ChkAmazon.Text = "Amazon"
        Me.ChkAmazon.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 376)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 17)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Notes"
        '
        'rtbSuppNotes
        '
        Me.rtbSuppNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbSuppNotes.Location = New System.Drawing.Point(112, 376)
        Me.rtbSuppNotes.Name = "rtbSuppNotes"
        Me.rtbSuppNotes.Size = New System.Drawing.Size(325, 101)
        Me.rtbSuppNotes.TabIndex = 11
        Me.rtbSuppNotes.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 338)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Discount %"
        '
        'nudSuppDiscount
        '
        Me.nudSuppDiscount.DecimalPlaces = 2
        Me.nudSuppDiscount.Location = New System.Drawing.Point(112, 336)
        Me.nudSuppDiscount.Name = "nudSuppDiscount"
        Me.nudSuppDiscount.Size = New System.Drawing.Size(120, 24)
        Me.nudSuppDiscount.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 17)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "eMail"
        '
        'txtSuppEmail
        '
        Me.txtSuppEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSuppEmail.Location = New System.Drawing.Point(112, 250)
        Me.txtSuppEmail.Name = "txtSuppEmail"
        Me.txtSuppEmail.Size = New System.Drawing.Size(224, 24)
        Me.txtSuppEmail.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 17)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Phone"
        '
        'txtSuppPhone
        '
        Me.txtSuppPhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSuppPhone.Location = New System.Drawing.Point(112, 219)
        Me.txtSuppPhone.Name = "txtSuppPhone"
        Me.txtSuppPhone.Size = New System.Drawing.Size(224, 24)
        Me.txtSuppPhone.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Postcode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Address"
        '
        'txtSuppPostcode
        '
        Me.txtSuppPostcode.Location = New System.Drawing.Point(112, 175)
        Me.txtSuppPostcode.Name = "txtSuppPostcode"
        Me.txtSuppPostcode.Size = New System.Drawing.Size(158, 24)
        Me.txtSuppPostcode.TabIndex = 5
        '
        'txtSuppAddr4
        '
        Me.txtSuppAddr4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSuppAddr4.Location = New System.Drawing.Point(112, 145)
        Me.txtSuppAddr4.Name = "txtSuppAddr4"
        Me.txtSuppAddr4.Size = New System.Drawing.Size(224, 24)
        Me.txtSuppAddr4.TabIndex = 4
        '
        'txtSuppAddr3
        '
        Me.txtSuppAddr3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSuppAddr3.Location = New System.Drawing.Point(112, 115)
        Me.txtSuppAddr3.Name = "txtSuppAddr3"
        Me.txtSuppAddr3.Size = New System.Drawing.Size(224, 24)
        Me.txtSuppAddr3.TabIndex = 3
        '
        'txtSuppAddr2
        '
        Me.txtSuppAddr2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSuppAddr2.Location = New System.Drawing.Point(112, 86)
        Me.txtSuppAddr2.Name = "txtSuppAddr2"
        Me.txtSuppAddr2.Size = New System.Drawing.Size(224, 24)
        Me.txtSuppAddr2.TabIndex = 2
        '
        'txtSuppAddr1
        '
        Me.txtSuppAddr1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSuppAddr1.Location = New System.Drawing.Point(112, 57)
        Me.txtSuppAddr1.Name = "txtSuppAddr1"
        Me.txtSuppAddr1.Size = New System.Drawing.Size(224, 24)
        Me.txtSuppAddr1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Name"
        '
        'txtSuppName
        '
        Me.txtSuppName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSuppName.Location = New System.Drawing.Point(112, 16)
        Me.txtSuppName.Name = "txtSuppName"
        Me.txtSuppName.Size = New System.Drawing.Size(325, 24)
        Me.txtSuppName.TabIndex = 0
        '
        'pnlProducts
        '
        Me.pnlProducts.Controls.Add(Me.spProducts)
        Me.pnlProducts.Controls.Add(Me.btnAddProduct)
        Me.pnlProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProducts.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlProducts.Location = New System.Drawing.Point(0, 0)
        Me.pnlProducts.Name = "pnlProducts"
        Me.pnlProducts.Size = New System.Drawing.Size(374, 480)
        Me.pnlProducts.TabIndex = 1
        '
        'spProducts
        '
        Me.spProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spProducts.BackColor = System.Drawing.Color.Gainsboro
        Me.spProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spProducts.Location = New System.Drawing.Point(3, 3)
        Me.spProducts.Name = "spProducts"
        Me.spProducts.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spProducts.Panel1
        '
        Me.spProducts.Panel1.Controls.Add(Me.dgvProducts)
        '
        'spProducts.Panel2
        '
        Me.spProducts.Panel2.Controls.Add(Me.Panel1)
        Me.spProducts.Size = New System.Drawing.Size(368, 445)
        Me.spProducts.SplitterDistance = 373
        Me.spProducts.TabIndex = 3
        '
        'dgvProducts
        '
        Me.dgvProducts.AllowUserToAddRows = False
        Me.dgvProducts.AllowUserToDeleteRows = False
        Me.dgvProducts.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.dgvProducts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProducts.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.prodId, Me.prodName})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProducts.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProducts.Location = New System.Drawing.Point(0, 0)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.ReadOnly = True
        Me.dgvProducts.RowHeadersVisible = False
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.dgvProducts.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProducts.Size = New System.Drawing.Size(366, 371)
        Me.dgvProducts.TabIndex = 0
        '
        'prodId
        '
        Me.prodId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.prodId.HeaderText = "Id"
        Me.prodId.Name = "prodId"
        Me.prodId.ReadOnly = True
        Me.prodId.Visible = False
        Me.prodId.Width = 50
        '
        'prodName
        '
        Me.prodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.prodName.HeaderText = "Products"
        Me.prodName.Name = "prodName"
        Me.prodName.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.txtPrice)
        Me.Panel1.Controls.Add(Me.txtCost)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtProductDesc)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(366, 66)
        Me.Panel1.TabIndex = 0
        '
        'txtPrice
        '
        Me.txtPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPrice.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPrice.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtPrice.Location = New System.Drawing.Point(240, 83)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(92, 15)
        Me.txtPrice.TabIndex = 4
        '
        'txtCost
        '
        Me.txtCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCost.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCost.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCost.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtCost.Location = New System.Drawing.Point(50, 83)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(100, 15)
        Me.txtCost.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label10.ForeColor = System.Drawing.Color.DarkGray
        Me.Label10.Location = New System.Drawing.Point(201, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 14)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Price"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DarkGray
        Me.Label9.Location = New System.Drawing.Point(13, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 14)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Cost"
        '
        'txtProductDesc
        '
        Me.txtProductDesc.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtProductDesc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtProductDesc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProductDesc.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtProductDesc.Location = New System.Drawing.Point(0, 0)
        Me.txtProductDesc.Multiline = True
        Me.txtProductDesc.Name = "txtProductDesc"
        Me.txtProductDesc.Size = New System.Drawing.Size(366, 66)
        Me.txtProductDesc.TabIndex = 0
        '
        'btnAddProduct
        '
        Me.btnAddProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddProduct.Location = New System.Drawing.Point(297, 452)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(74, 25)
        Me.btnAddProduct.TabIndex = 0
        Me.btnAddProduct.Text = "+Product"
        Me.btnAddProduct.UseVisualStyleBackColor = True
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.BackColor = System.Drawing.Color.SeaGreen
        Me.LblStatus.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.ForeColor = System.Drawing.Color.White
        Me.LblStatus.Location = New System.Drawing.Point(562, 28)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.LblStatus.Size = New System.Drawing.Size(188, 29)
        Me.LblStatus.TabIndex = 73
        Me.LblStatus.Text = "Adding new supplier"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(14, 64)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlSupplier)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlProducts)
        Me.SplitContainer1.Size = New System.Drawing.Size(826, 484)
        Me.SplitContainer1.SplitterDistance = 444
        Me.SplitContainer1.TabIndex = 74
        '
        'FrmSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(852, 631)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblScreenName)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmSupplier"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSupplier.ResumeLayout(False)
        Me.pnlSupplier.PerformLayout()
        CType(Me.nudSuppDiscount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProducts.ResumeLayout(False)
        Me.spProducts.Panel1.ResumeLayout(False)
        Me.spProducts.Panel2.ResumeLayout(False)
        CType(Me.spProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spProducts.ResumeLayout(False)
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblScreenName As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents pnlSupplier As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents rtbSuppNotes As RichTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents nudSuppDiscount As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSuppEmail As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSuppPhone As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSuppPostcode As TextBox
    Friend WithEvents txtSuppAddr4 As TextBox
    Friend WithEvents txtSuppAddr3 As TextBox
    Friend WithEvents txtSuppAddr2 As TextBox
    Friend WithEvents txtSuppAddr1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSuppName As TextBox
    Friend WithEvents pnlProducts As Panel
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents btnAddProduct As Button
    Friend WithEvents spProducts As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtProductDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtCost As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents prodId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prodName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChkAmazon As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtWeb As TextBox
    Friend WithEvents LblStatus As Label
    Friend WithEvents SplitContainer1 As SplitContainer
End Class
