<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.spCustomer = New System.Windows.Forms.SplitContainer()
        Me.dgvCust = New System.Windows.Forms.DataGridView()
        Me.custId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.custName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.custPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.custemail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtCustAddress = New System.Windows.Forms.TextBox()
        Me.spSupplier = New System.Windows.Forms.SplitContainer()
        Me.dgvSupp = New System.Windows.Forms.DataGridView()
        Me.txtSuppAddress = New System.Windows.Forms.TextBox()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.dgvJobs = New System.Windows.Forms.DataGridView()
        Me.jobId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jobName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jobDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jobAssigned = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jobCompleted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jobUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.spDiary = New System.Windows.Forms.SplitContainer()
        Me.dgvDiary = New System.Windows.Forms.DataGridView()
        Me.dremId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremCustId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremSeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremIncId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremUserCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremSubject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremRem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremCallback = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremClosed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremHeader = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rtbDiaryBody = New System.Windows.Forms.RichTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuLogView = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewCustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JobToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAddANewJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuShowAllJobs = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewSupplierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewDiaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TidyFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GlobalSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.suppId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suppName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suppPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suppEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suppAmazon = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.spCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spCustomer.Panel1.SuspendLayout()
        Me.spCustomer.Panel2.SuspendLayout()
        Me.spCustomer.SuspendLayout()
        CType(Me.dgvCust, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spSupplier.Panel1.SuspendLayout()
        Me.spSupplier.Panel2.SuspendLayout()
        Me.spSupplier.SuspendLayout()
        CType(Me.dgvSupp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.dgvJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spDiary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spDiary.Panel1.SuspendLayout()
        Me.spDiary.Panel2.SuspendLayout()
        Me.spDiary.SuspendLayout()
        CType(Me.dgvDiary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1154, 849)
        Me.SplitContainer1.SplitterDistance = 362
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 1
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.SplitContainer2.Panel1.Controls.Add(Me.spCustomer)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.spSupplier)
        Me.SplitContainer2.Size = New System.Drawing.Size(362, 849)
        Me.SplitContainer2.SplitterDistance = 460
        Me.SplitContainer2.TabIndex = 0
        '
        'spCustomer
        '
        Me.spCustomer.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.spCustomer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spCustomer.Location = New System.Drawing.Point(0, 0)
        Me.spCustomer.Name = "spCustomer"
        Me.spCustomer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spCustomer.Panel1
        '
        Me.spCustomer.Panel1.Controls.Add(Me.dgvCust)
        '
        'spCustomer.Panel2
        '
        Me.spCustomer.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.spCustomer.Panel2.Controls.Add(Me.txtCustAddress)
        Me.spCustomer.Size = New System.Drawing.Size(358, 456)
        Me.spCustomer.SplitterDistance = 335
        Me.spCustomer.TabIndex = 1
        '
        'dgvCust
        '
        Me.dgvCust.AllowUserToAddRows = False
        Me.dgvCust.AllowUserToDeleteRows = False
        Me.dgvCust.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.dgvCust.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCust.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCust.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.custId, Me.custName, Me.custPhone, Me.custemail})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCust.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCust.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCust.Location = New System.Drawing.Point(0, 0)
        Me.dgvCust.Name = "dgvCust"
        Me.dgvCust.ReadOnly = True
        Me.dgvCust.RowHeadersVisible = False
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.dgvCust.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCust.Size = New System.Drawing.Size(358, 335)
        Me.dgvCust.TabIndex = 1
        '
        'custId
        '
        Me.custId.HeaderText = "Id"
        Me.custId.Name = "custId"
        Me.custId.ReadOnly = True
        Me.custId.Visible = False
        '
        'custName
        '
        Me.custName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.custName.HeaderText = "Customer"
        Me.custName.Name = "custName"
        Me.custName.ReadOnly = True
        '
        'custPhone
        '
        Me.custPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.custPhone.HeaderText = "Phone"
        Me.custPhone.Name = "custPhone"
        Me.custPhone.ReadOnly = True
        '
        'custemail
        '
        Me.custemail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.custemail.HeaderText = "Email"
        Me.custemail.Name = "custemail"
        Me.custemail.ReadOnly = True
        '
        'txtCustAddress
        '
        Me.txtCustAddress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustAddress.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCustAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCustAddress.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustAddress.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtCustAddress.Location = New System.Drawing.Point(10, 10)
        Me.txtCustAddress.Margin = New System.Windows.Forms.Padding(0)
        Me.txtCustAddress.Multiline = True
        Me.txtCustAddress.Name = "txtCustAddress"
        Me.txtCustAddress.Size = New System.Drawing.Size(336, 98)
        Me.txtCustAddress.TabIndex = 0
        '
        'spSupplier
        '
        Me.spSupplier.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.spSupplier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spSupplier.Location = New System.Drawing.Point(0, 0)
        Me.spSupplier.Name = "spSupplier"
        Me.spSupplier.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spSupplier.Panel1
        '
        Me.spSupplier.Panel1.Controls.Add(Me.dgvSupp)
        '
        'spSupplier.Panel2
        '
        Me.spSupplier.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.spSupplier.Panel2.Controls.Add(Me.txtSuppAddress)
        Me.spSupplier.Size = New System.Drawing.Size(358, 381)
        Me.spSupplier.SplitterDistance = 276
        Me.spSupplier.TabIndex = 1
        '
        'dgvSupp
        '
        Me.dgvSupp.AllowUserToAddRows = False
        Me.dgvSupp.AllowUserToDeleteRows = False
        Me.dgvSupp.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.dgvSupp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSupp.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvSupp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSupp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.suppId, Me.suppName, Me.suppPhone, Me.suppEmail, Me.suppAmazon})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSupp.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvSupp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSupp.Location = New System.Drawing.Point(0, 0)
        Me.dgvSupp.Name = "dgvSupp"
        Me.dgvSupp.ReadOnly = True
        Me.dgvSupp.RowHeadersVisible = False
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.dgvSupp.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvSupp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSupp.Size = New System.Drawing.Size(358, 276)
        Me.dgvSupp.TabIndex = 0
        '
        'txtSuppAddress
        '
        Me.txtSuppAddress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSuppAddress.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSuppAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSuppAddress.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuppAddress.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtSuppAddress.Location = New System.Drawing.Point(10, 10)
        Me.txtSuppAddress.Multiline = True
        Me.txtSuppAddress.Name = "txtSuppAddress"
        Me.txtSuppAddress.Size = New System.Drawing.Size(336, 88)
        Me.txtSuppAddress.TabIndex = 1
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.SplitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.SplitContainer3.Panel1.Controls.Add(Me.dgvJobs)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SplitContainer3.Panel2.Controls.Add(Me.spDiary)
        Me.SplitContainer3.Size = New System.Drawing.Size(787, 849)
        Me.SplitContainer3.SplitterDistance = 459
        Me.SplitContainer3.TabIndex = 0
        '
        'dgvJobs
        '
        Me.dgvJobs.AllowUserToAddRows = False
        Me.dgvJobs.AllowUserToDeleteRows = False
        Me.dgvJobs.AllowUserToResizeRows = False
        Me.dgvJobs.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvJobs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJobs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.jobId, Me.jobName, Me.jobDesc, Me.jobAssigned, Me.jobCompleted, Me.jobUser})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJobs.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvJobs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvJobs.Location = New System.Drawing.Point(0, 0)
        Me.dgvJobs.Name = "dgvJobs"
        Me.dgvJobs.ReadOnly = True
        Me.dgvJobs.RowHeadersVisible = False
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.dgvJobs.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJobs.Size = New System.Drawing.Size(783, 455)
        Me.dgvJobs.TabIndex = 0
        '
        'jobId
        '
        Me.jobId.HeaderText = "Id"
        Me.jobId.Name = "jobId"
        Me.jobId.ReadOnly = True
        Me.jobId.Visible = False
        '
        'jobName
        '
        Me.jobName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.jobName.HeaderText = "Job"
        Me.jobName.Name = "jobName"
        Me.jobName.ReadOnly = True
        Me.jobName.Width = 200
        '
        'jobDesc
        '
        Me.jobDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.jobDesc.HeaderText = "Description"
        Me.jobDesc.Name = "jobDesc"
        Me.jobDesc.ReadOnly = True
        '
        'jobAssigned
        '
        Me.jobAssigned.HeaderText = "Assigned to"
        Me.jobAssigned.Name = "jobAssigned"
        Me.jobAssigned.ReadOnly = True
        '
        'jobCompleted
        '
        Me.jobCompleted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.jobCompleted.HeaderText = "Done"
        Me.jobCompleted.Name = "jobCompleted"
        Me.jobCompleted.ReadOnly = True
        Me.jobCompleted.Width = 50
        '
        'jobUser
        '
        Me.jobUser.HeaderText = "User"
        Me.jobUser.Name = "jobUser"
        Me.jobUser.ReadOnly = True
        Me.jobUser.Visible = False
        '
        'spDiary
        '
        Me.spDiary.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.spDiary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spDiary.Location = New System.Drawing.Point(0, 0)
        Me.spDiary.Name = "spDiary"
        Me.spDiary.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spDiary.Panel1
        '
        Me.spDiary.Panel1.Controls.Add(Me.dgvDiary)
        '
        'spDiary.Panel2
        '
        Me.spDiary.Panel2.Controls.Add(Me.rtbDiaryBody)
        Me.spDiary.Size = New System.Drawing.Size(783, 382)
        Me.spDiary.SplitterDistance = 322
        Me.spDiary.TabIndex = 25
        '
        'dgvDiary
        '
        Me.dgvDiary.AllowUserToAddRows = False
        Me.dgvDiary.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        Me.dgvDiary.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvDiary.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvDiary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDiary.ColumnHeadersVisible = False
        Me.dgvDiary.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dremId, Me.dremCustId, Me.dremSeId, Me.dremIncId, Me.dremUserCode, Me.dremDate, Me.dremSubject, Me.dremRem, Me.dremCallback, Me.dremClosed, Me.dremHeader})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDiary.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvDiary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDiary.Location = New System.Drawing.Point(0, 0)
        Me.dgvDiary.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvDiary.MultiSelect = False
        Me.dgvDiary.Name = "dgvDiary"
        Me.dgvDiary.ReadOnly = True
        Me.dgvDiary.RowHeadersVisible = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White
        Me.dgvDiary.RowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDiary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDiary.Size = New System.Drawing.Size(783, 322)
        Me.dgvDiary.TabIndex = 24
        '
        'dremId
        '
        Me.dremId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dremId.HeaderText = "Id"
        Me.dremId.Name = "dremId"
        Me.dremId.ReadOnly = True
        Me.dremId.Visible = False
        '
        'dremCustId
        '
        Me.dremCustId.HeaderText = "CustId"
        Me.dremCustId.Name = "dremCustId"
        Me.dremCustId.ReadOnly = True
        Me.dremCustId.Visible = False
        '
        'dremSeId
        '
        Me.dremSeId.HeaderText = "SeId"
        Me.dremSeId.Name = "dremSeId"
        Me.dremSeId.ReadOnly = True
        Me.dremSeId.Visible = False
        '
        'dremIncId
        '
        Me.dremIncId.HeaderText = "incId"
        Me.dremIncId.Name = "dremIncId"
        Me.dremIncId.ReadOnly = True
        Me.dremIncId.Visible = False
        '
        'dremUserCode
        '
        Me.dremUserCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dremUserCode.HeaderText = "User"
        Me.dremUserCode.Name = "dremUserCode"
        Me.dremUserCode.ReadOnly = True
        Me.dremUserCode.Visible = False
        Me.dremUserCode.Width = 50
        '
        'dremDate
        '
        Me.dremDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dremDate.HeaderText = "Date"
        Me.dremDate.Name = "dremDate"
        Me.dremDate.ReadOnly = True
        '
        'dremSubject
        '
        Me.dremSubject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dremSubject.HeaderText = "Subject"
        Me.dremSubject.Name = "dremSubject"
        Me.dremSubject.ReadOnly = True
        '
        'dremRem
        '
        Me.dremRem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dremRem.HeaderText = ""
        Me.dremRem.Name = "dremRem"
        Me.dremRem.ReadOnly = True
        Me.dremRem.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dremRem.Width = 30
        '
        'dremCallback
        '
        Me.dremCallback.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dremCallback.HeaderText = ""
        Me.dremCallback.Name = "dremCallback"
        Me.dremCallback.ReadOnly = True
        Me.dremCallback.Width = 30
        '
        'dremClosed
        '
        Me.dremClosed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dremClosed.HeaderText = ""
        Me.dremClosed.Name = "dremClosed"
        Me.dremClosed.ReadOnly = True
        Me.dremClosed.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dremClosed.Width = 30
        '
        'dremHeader
        '
        Me.dremHeader.HeaderText = "Header"
        Me.dremHeader.Name = "dremHeader"
        Me.dremHeader.ReadOnly = True
        Me.dremHeader.Visible = False
        '
        'rtbDiaryBody
        '
        Me.rtbDiaryBody.BackColor = System.Drawing.Color.WhiteSmoke
        Me.rtbDiaryBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbDiaryBody.Location = New System.Drawing.Point(0, 0)
        Me.rtbDiaryBody.Name = "rtbDiaryBody"
        Me.rtbDiaryBody.Size = New System.Drawing.Size(783, 56)
        Me.rtbDiaryBody.TabIndex = 0
        Me.rtbDiaryBody.Text = ""
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Right
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdminToolStripMenuItem, Me.NewCustomerToolStripMenuItem, Me.JobToolStripMenuItem, Me.NewSupplierToolStripMenuItem, Me.NewDiaryToolStripMenuItem, Me.ToolStripMenuItem1, Me.TidyFilesToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ToolStripMenuItem2, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(1154, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(6, 5, 5, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(101, 849)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AdminToolStripMenuItem
        '
        Me.AdminToolStripMenuItem.AutoSize = False
        Me.AdminToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.AdminToolStripMenuItem.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.AdminToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AdminToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserControlToolStripMenuItem, Me.ToolStripSeparator2, Me.MnuBackup, Me.MnuRestore, Me.ToolStripSeparator3, Me.MnuLogView})
        Me.AdminToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        Me.AdminToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.AdminToolStripMenuItem.Size = New System.Drawing.Size(90, 90)
        Me.AdminToolStripMenuItem.Text = "Admin"
        '
        'UserControlToolStripMenuItem
        '
        Me.UserControlToolStripMenuItem.Name = "UserControlToolStripMenuItem"
        Me.UserControlToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.UserControlToolStripMenuItem.Text = "User Control"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(137, 6)
        '
        'MnuBackup
        '
        Me.MnuBackup.Name = "MnuBackup"
        Me.MnuBackup.Size = New System.Drawing.Size(140, 22)
        Me.MnuBackup.Text = "Backup"
        '
        'MnuRestore
        '
        Me.MnuRestore.Name = "MnuRestore"
        Me.MnuRestore.Size = New System.Drawing.Size(140, 22)
        Me.MnuRestore.Text = "Restore"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(137, 6)
        '
        'MnuLogView
        '
        Me.MnuLogView.Name = "MnuLogView"
        Me.MnuLogView.Size = New System.Drawing.Size(140, 22)
        Me.MnuLogView.Text = "Log Viewer"
        '
        'NewCustomerToolStripMenuItem
        '
        Me.NewCustomerToolStripMenuItem.AutoSize = False
        Me.NewCustomerToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.NewCustomerToolStripMenuItem.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.NewCustomerToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NewCustomerToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.NewCustomerToolStripMenuItem.Name = "NewCustomerToolStripMenuItem"
        Me.NewCustomerToolStripMenuItem.Size = New System.Drawing.Size(90, 90)
        Me.NewCustomerToolStripMenuItem.Text = "+Customer"
        '
        'JobToolStripMenuItem
        '
        Me.JobToolStripMenuItem.AutoSize = False
        Me.JobToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.JobToolStripMenuItem.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.JobToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.JobToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAddANewJob, Me.mnuShowAllJobs})
        Me.JobToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.JobToolStripMenuItem.Name = "JobToolStripMenuItem"
        Me.JobToolStripMenuItem.Size = New System.Drawing.Size(90, 90)
        Me.JobToolStripMenuItem.Text = "Jobs"
        '
        'mnuAddANewJob
        '
        Me.mnuAddANewJob.Name = "mnuAddANewJob"
        Me.mnuAddANewJob.Size = New System.Drawing.Size(150, 22)
        Me.mnuAddANewJob.Text = "Add a new job"
        '
        'mnuShowAllJobs
        '
        Me.mnuShowAllJobs.CheckOnClick = True
        Me.mnuShowAllJobs.Name = "mnuShowAllJobs"
        Me.mnuShowAllJobs.Size = New System.Drawing.Size(150, 22)
        Me.mnuShowAllJobs.Text = "Show all jobs"
        '
        'NewSupplierToolStripMenuItem
        '
        Me.NewSupplierToolStripMenuItem.AutoSize = False
        Me.NewSupplierToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.NewSupplierToolStripMenuItem.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.NewSupplierToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NewSupplierToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.NewSupplierToolStripMenuItem.Name = "NewSupplierToolStripMenuItem"
        Me.NewSupplierToolStripMenuItem.Size = New System.Drawing.Size(90, 90)
        Me.NewSupplierToolStripMenuItem.Text = "+Supplier"
        '
        'NewDiaryToolStripMenuItem
        '
        Me.NewDiaryToolStripMenuItem.AutoSize = False
        Me.NewDiaryToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.NewDiaryToolStripMenuItem.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.NewDiaryToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NewDiaryToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.NewDiaryToolStripMenuItem.Name = "NewDiaryToolStripMenuItem"
        Me.NewDiaryToolStripMenuItem.Size = New System.Drawing.Size(90, 90)
        Me.NewDiaryToolStripMenuItem.Text = "+Diary"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(78, 19)
        Me.ToolStripMenuItem1.Text = " "
        '
        'TidyFilesToolStripMenuItem
        '
        Me.TidyFilesToolStripMenuItem.AutoSize = False
        Me.TidyFilesToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.TidyFilesToolStripMenuItem.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.TidyFilesToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TidyFilesToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.TidyFilesToolStripMenuItem.Name = "TidyFilesToolStripMenuItem"
        Me.TidyFilesToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.TidyFilesToolStripMenuItem.Size = New System.Drawing.Size(90, 90)
        Me.TidyFilesToolStripMenuItem.Text = "Tidy Files"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.AutoSize = False
        Me.SettingsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.SettingsToolStripMenuItem.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.SettingsToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GlobalSettingsToolStripMenuItem, Me.ToolStripSeparator1, Me.PreferencesToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(90, 90)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'GlobalSettingsToolStripMenuItem
        '
        Me.GlobalSettingsToolStripMenuItem.Name = "GlobalSettingsToolStripMenuItem"
        Me.GlobalSettingsToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.GlobalSettingsToolStripMenuItem.Text = "Global Settings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(150, 6)
        '
        'PreferencesToolStripMenuItem
        '
        Me.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem"
        Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.PreferencesToolStripMenuItem.Text = "Preferences"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(78, 19)
        Me.ToolStripMenuItem2.Text = " "
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.AutoSize = False
        Me.CloseToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.CloseToolStripMenuItem.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.CloseToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CloseToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(90, 90)
        Me.CloseToolStripMenuItem.Text = "Close"
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
        Me.suppName.HeaderText = "Supplier"
        Me.suppName.Name = "suppName"
        Me.suppName.ReadOnly = True
        '
        'suppPhone
        '
        Me.suppPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.suppPhone.HeaderText = "Phone"
        Me.suppPhone.Name = "suppPhone"
        Me.suppPhone.ReadOnly = True
        '
        'suppEmail
        '
        Me.suppEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.suppEmail.HeaderText = "Email"
        Me.suppEmail.Name = "suppEmail"
        Me.suppEmail.ReadOnly = True
        '
        'supplierAmazon
        '
        Me.suppAmazon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.suppAmazon.HeaderText = "Amzn"
        Me.suppAmazon.Name = "supplierAmazon"
        Me.suppAmazon.ReadOnly = True
        Me.suppAmazon.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.suppAmazon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.suppAmazon.Width = 60
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1255, 849)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.spCustomer.Panel1.ResumeLayout(False)
        Me.spCustomer.Panel2.ResumeLayout(False)
        Me.spCustomer.Panel2.PerformLayout()
        CType(Me.spCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spCustomer.ResumeLayout(False)
        CType(Me.dgvCust, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spSupplier.Panel1.ResumeLayout(False)
        Me.spSupplier.Panel2.ResumeLayout(False)
        Me.spSupplier.Panel2.PerformLayout()
        CType(Me.spSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spSupplier.ResumeLayout(False)
        CType(Me.dgvSupp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.dgvJobs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spDiary.Panel1.ResumeLayout(False)
        Me.spDiary.Panel2.ResumeLayout(False)
        CType(Me.spDiary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spDiary.ResumeLayout(False)
        CType(Me.dgvDiary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents dgvSupp As DataGridView
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents dgvJobs As DataGridView
    Friend WithEvents dgvDiary As DataGridView
    Friend WithEvents dremId As DataGridViewTextBoxColumn
    Friend WithEvents dremCustId As DataGridViewTextBoxColumn
    Friend WithEvents dremSeId As DataGridViewTextBoxColumn
    Friend WithEvents dremIncId As DataGridViewTextBoxColumn
    Friend WithEvents dremUserCode As DataGridViewTextBoxColumn
    Friend WithEvents dremDate As DataGridViewTextBoxColumn
    Friend WithEvents dremSubject As DataGridViewTextBoxColumn
    Friend WithEvents dremRem As DataGridViewTextBoxColumn
    Friend WithEvents dremCallback As DataGridViewTextBoxColumn
    Friend WithEvents dremClosed As DataGridViewTextBoxColumn
    Friend WithEvents dremHeader As DataGridViewTextBoxColumn
    Friend WithEvents spDiary As SplitContainer
    Friend WithEvents rtbDiaryBody As RichTextBox
    Friend WithEvents spCustomer As SplitContainer
    Friend WithEvents spSupplier As SplitContainer
    Friend WithEvents dgvCust As DataGridView
    Friend WithEvents custId As DataGridViewTextBoxColumn
    Friend WithEvents custName As DataGridViewTextBoxColumn
    Friend WithEvents custPhone As DataGridViewTextBoxColumn
    Friend WithEvents custemail As DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AdminToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewCustomerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewSupplierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JobToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewDiaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TidyFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GlobalSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserControlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCustAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtSuppAddress As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAddANewJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuShowAllJobs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents jobId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jobName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jobDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jobAssigned As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jobCompleted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jobUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MnuLogView As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents MnuBackup As ToolStripMenuItem
    Friend WithEvents MnuRestore As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents suppId As DataGridViewTextBoxColumn
    Friend WithEvents suppName As DataGridViewTextBoxColumn
    Friend WithEvents suppPhone As DataGridViewTextBoxColumn
    Friend WithEvents suppEmail As DataGridViewTextBoxColumn
    Friend WithEvents suppAmazon As DataGridViewCheckBoxColumn
End Class
