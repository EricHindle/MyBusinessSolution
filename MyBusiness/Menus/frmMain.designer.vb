<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.spCustomer = New System.Windows.Forms.SplitContainer()
        Me.DgvCust = New System.Windows.Forms.DataGridView()
        Me.custId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.custName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.custPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.custemail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtCustAddress = New System.Windows.Forms.TextBox()
        Me.spSupplier = New System.Windows.Forms.SplitContainer()
        Me.DgvSupp = New System.Windows.Forms.DataGridView()
        Me.suppId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suppName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suppPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suppEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suppAmazon = New System.Windows.Forms.DataGridViewCheckBoxColumn()
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
        Me.MnuAddJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAddCustomer = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAddSupplier = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAddDiary = New System.Windows.Forms.ToolStripMenuItem()
        Me.Gap1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTemplates = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuJobFromTemplate = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTemplateFromJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuMaintainTemplates = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGlobalSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuPreferences = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuShowAllJobs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuCheckCallBackReminders = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAdmin = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuChangePassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuShowAudit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuTidyFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuLogView = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Gap2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerCallBackReminders = New System.Windows.Forms.Timer(Me.components)
        Me.CallbackReminderBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.MnuTasks = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
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
        CType(Me.DgvCust, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spSupplier.Panel1.SuspendLayout()
        Me.spSupplier.Panel2.SuspendLayout()
        Me.spSupplier.SuspendLayout()
        CType(Me.DgvSupp, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.spCustomer.Panel1.Controls.Add(Me.DgvCust)
        '
        'spCustomer.Panel2
        '
        Me.spCustomer.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.spCustomer.Panel2.Controls.Add(Me.txtCustAddress)
        Me.spCustomer.Size = New System.Drawing.Size(358, 456)
        Me.spCustomer.SplitterDistance = 335
        Me.spCustomer.TabIndex = 1
        '
        'DgvCust
        '
        Me.DgvCust.AllowUserToAddRows = False
        Me.DgvCust.AllowUserToDeleteRows = False
        Me.DgvCust.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.DgvCust.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvCust.BackgroundColor = System.Drawing.Color.OldLace
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FloralWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.OldLace
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.SaddleBrown
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvCust.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvCust.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.custId, Me.custName, Me.custPhone, Me.custemail})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvCust.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvCust.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCust.EnableHeadersVisualStyles = False
        Me.DgvCust.Location = New System.Drawing.Point(0, 0)
        Me.DgvCust.MultiSelect = False
        Me.DgvCust.Name = "DgvCust"
        Me.DgvCust.ReadOnly = True
        Me.DgvCust.RowHeadersVisible = False
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.DgvCust.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvCust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCust.Size = New System.Drawing.Size(358, 335)
        Me.DgvCust.TabIndex = 1
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
        Me.spSupplier.Panel1.Controls.Add(Me.DgvSupp)
        '
        'spSupplier.Panel2
        '
        Me.spSupplier.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.spSupplier.Panel2.Controls.Add(Me.txtSuppAddress)
        Me.spSupplier.Size = New System.Drawing.Size(358, 381)
        Me.spSupplier.SplitterDistance = 276
        Me.spSupplier.TabIndex = 1
        '
        'DgvSupp
        '
        Me.DgvSupp.AllowUserToAddRows = False
        Me.DgvSupp.AllowUserToDeleteRows = False
        Me.DgvSupp.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.DgvSupp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgvSupp.BackgroundColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.MintCream
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.DarkGreen
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSupp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgvSupp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.suppId, Me.suppName, Me.suppPhone, Me.suppEmail, Me.suppAmazon})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvSupp.DefaultCellStyle = DataGridViewCellStyle7
        Me.DgvSupp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvSupp.EnableHeadersVisualStyles = False
        Me.DgvSupp.Location = New System.Drawing.Point(0, 0)
        Me.DgvSupp.MultiSelect = False
        Me.DgvSupp.Name = "DgvSupp"
        Me.DgvSupp.ReadOnly = True
        Me.DgvSupp.RowHeadersVisible = False
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.DgvSupp.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DgvSupp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSupp.Size = New System.Drawing.Size(358, 276)
        Me.DgvSupp.TabIndex = 0
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
        'suppAmazon
        '
        Me.suppAmazon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.suppAmazon.HeaderText = "Amzn"
        Me.suppAmazon.Name = "suppAmazon"
        Me.suppAmazon.ReadOnly = True
        Me.suppAmazon.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.suppAmazon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.suppAmazon.Width = 60
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
        Me.dgvJobs.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgvJobs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.DarkBlue
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJobs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvJobs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.jobId, Me.jobName, Me.jobDesc, Me.jobAssigned, Me.jobCompleted, Me.jobUser})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvJobs.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvJobs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvJobs.EnableHeadersVisualStyles = False
        Me.dgvJobs.Location = New System.Drawing.Point(0, 0)
        Me.dgvJobs.MultiSelect = False
        Me.dgvJobs.Name = "dgvJobs"
        Me.dgvJobs.ReadOnly = True
        Me.dgvJobs.RowHeadersVisible = False
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.dgvJobs.RowsDefaultCellStyle = DataGridViewCellStyle11
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
        Me.jobName.HeaderText = "Job/Order"
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
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White
        Me.dgvDiary.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvDiary.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvDiary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDiary.ColumnHeadersVisible = False
        Me.dgvDiary.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dremId, Me.dremCustId, Me.dremSeId, Me.dremIncId, Me.dremUserCode, Me.dremDate, Me.dremSubject, Me.dremRem, Me.dremCallback, Me.dremClosed, Me.dremHeader})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDiary.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvDiary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDiary.Location = New System.Drawing.Point(0, 0)
        Me.dgvDiary.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvDiary.MultiSelect = False
        Me.dgvDiary.Name = "dgvDiary"
        Me.dgvDiary.ReadOnly = True
        Me.dgvDiary.RowHeadersVisible = False
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White
        Me.dgvDiary.RowsDefaultCellStyle = DataGridViewCellStyle14
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAddJob, Me.MnuAddCustomer, Me.MnuAddSupplier, Me.MnuAddDiary, Me.Gap1, Me.MnuTemplates, Me.MnuSettings, Me.MnuAdmin, Me.Gap2, Me.MnuClose})
        Me.MenuStrip1.Location = New System.Drawing.Point(1124, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(6, 5, 5, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(131, 849)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MnuAddJob
        '
        Me.MnuAddJob.AutoSize = False
        Me.MnuAddJob.BackColor = System.Drawing.SystemColors.Control
        Me.MnuAddJob.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.MnuAddJob.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MnuAddJob.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.MnuAddJob.Name = "MnuAddJob"
        Me.MnuAddJob.Size = New System.Drawing.Size(90, 90)
        Me.MnuAddJob.Text = "+Order/Job"
        '
        'MnuAddCustomer
        '
        Me.MnuAddCustomer.AutoSize = False
        Me.MnuAddCustomer.BackColor = System.Drawing.SystemColors.Control
        Me.MnuAddCustomer.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.MnuAddCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MnuAddCustomer.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.MnuAddCustomer.Name = "MnuAddCustomer"
        Me.MnuAddCustomer.Size = New System.Drawing.Size(90, 90)
        Me.MnuAddCustomer.Text = "+Customer"
        Me.MnuAddCustomer.ToolTipText = "Add a customer"
        '
        'MnuAddSupplier
        '
        Me.MnuAddSupplier.AutoSize = False
        Me.MnuAddSupplier.BackColor = System.Drawing.SystemColors.Control
        Me.MnuAddSupplier.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.MnuAddSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MnuAddSupplier.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.MnuAddSupplier.Name = "MnuAddSupplier"
        Me.MnuAddSupplier.Size = New System.Drawing.Size(90, 90)
        Me.MnuAddSupplier.Text = "+Supplier"
        Me.MnuAddSupplier.ToolTipText = "Add a supplier"
        '
        'MnuAddDiary
        '
        Me.MnuAddDiary.AutoSize = False
        Me.MnuAddDiary.BackColor = System.Drawing.SystemColors.Control
        Me.MnuAddDiary.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.MnuAddDiary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MnuAddDiary.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.MnuAddDiary.Name = "MnuAddDiary"
        Me.MnuAddDiary.Size = New System.Drawing.Size(90, 90)
        Me.MnuAddDiary.Text = "+Diary"
        '
        'Gap1
        '
        Me.Gap1.Name = "Gap1"
        Me.Gap1.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.Gap1.Size = New System.Drawing.Size(108, 19)
        Me.Gap1.Text = " "
        '
        'MnuTemplates
        '
        Me.MnuTemplates.AutoSize = False
        Me.MnuTemplates.BackColor = System.Drawing.SystemColors.Control
        Me.MnuTemplates.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.MnuTemplates.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MnuTemplates.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuJobFromTemplate, Me.MnuTemplateFromJob, Me.ToolStripSeparator7, Me.MnuMaintainTemplates})
        Me.MnuTemplates.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.MnuTemplates.Name = "MnuTemplates"
        Me.MnuTemplates.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.MnuTemplates.Size = New System.Drawing.Size(90, 90)
        Me.MnuTemplates.Text = "Templates"
        '
        'MnuJobFromTemplate
        '
        Me.MnuJobFromTemplate.Name = "MnuJobFromTemplate"
        Me.MnuJobFromTemplate.Size = New System.Drawing.Size(197, 22)
        Me.MnuJobFromTemplate.Text = "Add Job from Template"
        '
        'MnuTemplateFromJob
        '
        Me.MnuTemplateFromJob.Name = "MnuTemplateFromJob"
        Me.MnuTemplateFromJob.Size = New System.Drawing.Size(197, 22)
        Me.MnuTemplateFromJob.Text = "Add Template from Job"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(194, 6)
        '
        'MnuMaintainTemplates
        '
        Me.MnuMaintainTemplates.Name = "MnuMaintainTemplates"
        Me.MnuMaintainTemplates.Size = New System.Drawing.Size(197, 22)
        Me.MnuMaintainTemplates.Text = "Maintain Templates"
        '
        'MnuSettings
        '
        Me.MnuSettings.AutoSize = False
        Me.MnuSettings.BackColor = System.Drawing.SystemColors.Control
        Me.MnuSettings.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.MnuSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MnuSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuGlobalSettings, Me.ToolStripSeparator1, Me.MnuPreferences, Me.MnuShowAllJobs, Me.ToolStripSeparator4, Me.MnuCheckCallBackReminders})
        Me.MnuSettings.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.MnuSettings.Name = "MnuSettings"
        Me.MnuSettings.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.MnuSettings.Size = New System.Drawing.Size(90, 90)
        Me.MnuSettings.Text = "Settings"
        '
        'MnuGlobalSettings
        '
        Me.MnuGlobalSettings.Name = "MnuGlobalSettings"
        Me.MnuGlobalSettings.Size = New System.Drawing.Size(195, 22)
        Me.MnuGlobalSettings.Text = "Global Settings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(192, 6)
        '
        'MnuPreferences
        '
        Me.MnuPreferences.Name = "MnuPreferences"
        Me.MnuPreferences.Size = New System.Drawing.Size(195, 22)
        Me.MnuPreferences.Text = "Preferences"
        '
        'MnuShowAllJobs
        '
        Me.MnuShowAllJobs.CheckOnClick = True
        Me.MnuShowAllJobs.Name = "MnuShowAllJobs"
        Me.MnuShowAllJobs.Size = New System.Drawing.Size(195, 22)
        Me.MnuShowAllJobs.Text = "Show Jobs for All Users"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(192, 6)
        '
        'MnuCheckCallBackReminders
        '
        Me.MnuCheckCallBackReminders.Name = "MnuCheckCallBackReminders"
        Me.MnuCheckCallBackReminders.Size = New System.Drawing.Size(195, 22)
        Me.MnuCheckCallBackReminders.Text = "Callback Reminders"
        '
        'MnuAdmin
        '
        Me.MnuAdmin.AutoSize = False
        Me.MnuAdmin.BackColor = System.Drawing.SystemColors.Control
        Me.MnuAdmin.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.MnuAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MnuAdmin.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserControlToolStripMenuItem, Me.MnuChangePassword, Me.ToolStripSeparator6, Me.MnuTasks, Me.ToolStripSeparator8, Me.MnuShowAudit, Me.ToolStripSeparator2, Me.MnuTidyFiles, Me.MnuBackup, Me.MnuRestore, Me.ToolStripSeparator3, Me.MnuLogView, Me.ToolStripSeparator5, Me.AboutToolStripMenuItem})
        Me.MnuAdmin.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.MnuAdmin.Name = "MnuAdmin"
        Me.MnuAdmin.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.MnuAdmin.Size = New System.Drawing.Size(90, 90)
        Me.MnuAdmin.Text = "Admin"
        '
        'UserControlToolStripMenuItem
        '
        Me.UserControlToolStripMenuItem.Name = "UserControlToolStripMenuItem"
        Me.UserControlToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.UserControlToolStripMenuItem.Text = "User Control"
        '
        'MnuChangePassword
        '
        Me.MnuChangePassword.Name = "MnuChangePassword"
        Me.MnuChangePassword.Size = New System.Drawing.Size(180, 22)
        Me.MnuChangePassword.Text = "Change password"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(177, 6)
        '
        'MnuShowAudit
        '
        Me.MnuShowAudit.Name = "MnuShowAudit"
        Me.MnuShowAudit.Size = New System.Drawing.Size(180, 22)
        Me.MnuShowAudit.Text = "Show Audit"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(177, 6)
        '
        'MnuTidyFiles
        '
        Me.MnuTidyFiles.Name = "MnuTidyFiles"
        Me.MnuTidyFiles.Size = New System.Drawing.Size(180, 22)
        Me.MnuTidyFiles.Text = "Tidy Files"
        '
        'MnuBackup
        '
        Me.MnuBackup.Name = "MnuBackup"
        Me.MnuBackup.Size = New System.Drawing.Size(180, 22)
        Me.MnuBackup.Text = "Backup"
        '
        'MnuRestore
        '
        Me.MnuRestore.Name = "MnuRestore"
        Me.MnuRestore.Size = New System.Drawing.Size(180, 22)
        Me.MnuRestore.Text = "Restore"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(177, 6)
        '
        'MnuLogView
        '
        Me.MnuLogView.Name = "MnuLogView"
        Me.MnuLogView.Size = New System.Drawing.Size(180, 22)
        Me.MnuLogView.Text = "Log Viewer"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(177, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Gap2
        '
        Me.Gap2.Name = "Gap2"
        Me.Gap2.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.Gap2.Size = New System.Drawing.Size(108, 19)
        Me.Gap2.Text = " "
        '
        'MnuClose
        '
        Me.MnuClose.AutoSize = False
        Me.MnuClose.BackColor = System.Drawing.SystemColors.Control
        Me.MnuClose.BackgroundImage = Global.MyBusiness.My.Resources.Resources.glossy_button
        Me.MnuClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MnuClose.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.MnuClose.Name = "MnuClose"
        Me.MnuClose.Size = New System.Drawing.Size(90, 90)
        Me.MnuClose.Text = "Close"
        '
        'TimerCallBackReminders
        '
        '
        'CallbackReminderBackgroundWorker
        '
        Me.CallbackReminderBackgroundWorker.WorkerReportsProgress = True
        Me.CallbackReminderBackgroundWorker.WorkerSupportsCancellation = True
        '
        'MnuTasks
        '
        Me.MnuTasks.Name = "MnuTasks"
        Me.MnuTasks.Size = New System.Drawing.Size(180, 22)
        Me.MnuTasks.Text = "Maintain Tasks"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(177, 6)
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
        CType(Me.DgvCust, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spSupplier.Panel1.ResumeLayout(False)
        Me.spSupplier.Panel2.ResumeLayout(False)
        Me.spSupplier.Panel2.PerformLayout()
        CType(Me.spSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spSupplier.ResumeLayout(False)
        CType(Me.DgvSupp, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DgvSupp As DataGridView
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
    Friend WithEvents DgvCust As DataGridView
    Friend WithEvents custId As DataGridViewTextBoxColumn
    Friend WithEvents custName As DataGridViewTextBoxColumn
    Friend WithEvents custPhone As DataGridViewTextBoxColumn
    Friend WithEvents custemail As DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuAdmin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuAddCustomer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuAddSupplier As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuAddJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuAddDiary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Gap1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTemplates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Gap2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuGlobalSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuPreferences As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserControlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCustAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtSuppAddress As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuLogView As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents MnuBackup As ToolStripMenuItem
    Friend WithEvents MnuRestore As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents MnuChangePassword As ToolStripMenuItem
    Friend WithEvents TimerCallBackReminders As Timer
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents MnuCheckCallBackReminders As ToolStripMenuItem
    Friend WithEvents CallbackReminderBackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents suppId As DataGridViewTextBoxColumn
    Friend WithEvents suppName As DataGridViewTextBoxColumn
    Friend WithEvents suppPhone As DataGridViewTextBoxColumn
    Friend WithEvents suppEmail As DataGridViewTextBoxColumn
    Friend WithEvents suppAmazon As DataGridViewCheckBoxColumn
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents jobId As DataGridViewTextBoxColumn
    Friend WithEvents jobName As DataGridViewTextBoxColumn
    Friend WithEvents jobDesc As DataGridViewTextBoxColumn
    Friend WithEvents jobAssigned As DataGridViewTextBoxColumn
    Friend WithEvents jobCompleted As DataGridViewTextBoxColumn
    Friend WithEvents jobUser As DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents MnuShowAudit As ToolStripMenuItem
    Friend WithEvents MnuTidyFiles As ToolStripMenuItem
    Friend WithEvents MnuJobFromTemplate As ToolStripMenuItem
    Friend WithEvents MnuMaintainTemplates As ToolStripMenuItem
    Friend WithEvents MnuTemplateFromJob As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents MnuShowAllJobs As ToolStripMenuItem
    Friend WithEvents MnuTasks As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
End Class
