﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDiary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDiary))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblF3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblF4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSetReminder = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSetComplete = New System.Windows.Forms.Button()
        Me.lblFormName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dgvDiary = New System.Windows.Forms.DataGridView()
        Me.dremId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremCustId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremJobId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremUserCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremSubject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremRem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremCallback = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremClosed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dremHeader = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rtbBody = New System.Windows.Forms.RichTextBox()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnJobLink = New System.Windows.Forms.Button()
        Me.btnCustLink = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.chkReminders = New System.Windows.Forms.CheckBox()
        Me.chkComplete = New System.Windows.Forms.CheckBox()
        Me.lblReminder = New System.Windows.Forms.Label()
        Me.lblComplete = New System.Windows.Forms.Label()
        Me.lblOverdue = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDiary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblF3, Me.lblF4, Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 438)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(926, 26)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblF3
        '
        Me.lblF3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblF3.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.lblF3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblF3.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.lblF3.ForeColor = System.Drawing.Color.Black
        Me.lblF3.Name = "lblF3"
        Me.lblF3.Padding = New System.Windows.Forms.Padding(1)
        Me.lblF3.Size = New System.Drawing.Size(72, 21)
        Me.lblF3.Text = "F3=Refresh"
        '
        'lblF4
        '
        Me.lblF4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblF4.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.lblF4.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblF4.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.lblF4.ForeColor = System.Drawing.Color.Black
        Me.lblF4.Margin = New System.Windows.Forms.Padding(1, 3, 0, 2)
        Me.lblF4.Name = "lblF4"
        Me.lblF4.Padding = New System.Windows.Forms.Padding(1)
        Me.lblF4.Size = New System.Drawing.Size(110, 21)
        Me.lblF4.Text = "F4=Show All Users"
        '
        'lblStatus
        '
        Me.lblStatus.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(10, 3, 0, 2)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(20, 21)
        Me.lblStatus.Text = "   "
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(295, 401)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 34)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSetReminder
        '
        Me.btnSetReminder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSetReminder.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetReminder.ForeColor = System.Drawing.Color.Black
        Me.btnSetReminder.Location = New System.Drawing.Point(273, 200)
        Me.btnSetReminder.Name = "btnSetReminder"
        Me.btnSetReminder.Size = New System.Drawing.Size(119, 31)
        Me.btnSetReminder.TabIndex = 4
        Me.btnSetReminder.Text = "Set as reminder"
        Me.btnSetReminder.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUpdate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.Black
        Me.btnUpdate.Location = New System.Drawing.Point(273, 160)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(119, 31)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "Update Entry"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSetComplete
        '
        Me.btnSetComplete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSetComplete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetComplete.ForeColor = System.Drawing.Color.Black
        Me.btnSetComplete.Location = New System.Drawing.Point(273, 240)
        Me.btnSetComplete.Name = "btnSetComplete"
        Me.btnSetComplete.Size = New System.Drawing.Size(119, 31)
        Me.btnSetComplete.TabIndex = 7
        Me.btnSetComplete.Text = "Close Reminder"
        Me.btnSetComplete.UseVisualStyleBackColor = True
        '
        'lblFormName
        '
        Me.lblFormName.AutoSize = True
        Me.lblFormName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormName.ForeColor = System.Drawing.Color.Black
        Me.lblFormName.Location = New System.Drawing.Point(62, 12)
        Me.lblFormName.Name = "lblFormName"
        Me.lblFormName.Size = New System.Drawing.Size(147, 25)
        Me.lblFormName.TabIndex = 20
        Me.lblFormName.Text = "Form Name"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(44, 44)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'dgvDiary
        '
        Me.dgvDiary.AllowUserToAddRows = False
        Me.dgvDiary.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvDiary.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDiary.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDiary.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvDiary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDiary.ColumnHeadersVisible = False
        Me.dgvDiary.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dremId, Me.dremCustId, Me.dremJobId, Me.dremUserCode, Me.dremDate, Me.dremSubject, Me.dremRem, Me.dremCallback, Me.dremClosed, Me.dremHeader})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDiary.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDiary.Location = New System.Drawing.Point(406, 40)
        Me.dgvDiary.MultiSelect = False
        Me.dgvDiary.Name = "dgvDiary"
        Me.dgvDiary.ReadOnly = True
        Me.dgvDiary.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.dgvDiary.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDiary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDiary.Size = New System.Drawing.Size(508, 350)
        Me.dgvDiary.TabIndex = 23
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
        'dremJobId
        '
        Me.dremJobId.HeaderText = "jobId"
        Me.dremJobId.Name = "dremJobId"
        Me.dremJobId.ReadOnly = True
        Me.dremJobId.Visible = False
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
        'rtbBody
        '
        Me.rtbBody.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rtbBody.BackColor = System.Drawing.Color.Gainsboro
        Me.rtbBody.Location = New System.Drawing.Point(11, 200)
        Me.rtbBody.Name = "rtbBody"
        Me.rtbBody.Size = New System.Drawing.Size(247, 213)
        Me.rtbBody.TabIndex = 24
        Me.rtbBody.Text = ""
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(11, 168)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(246, 23)
        Me.txtSubject.TabIndex = 25
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnJobLink)
        Me.GroupBox1.Controls.Add(Me.btnCustLink)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(284, 277)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(92, 89)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Links"
        '
        'btnJobLink
        '
        Me.btnJobLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnJobLink.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJobLink.Location = New System.Drawing.Point(11, 51)
        Me.btnJobLink.Name = "btnJobLink"
        Me.btnJobLink.Size = New System.Drawing.Size(75, 23)
        Me.btnJobLink.TabIndex = 2
        Me.btnJobLink.Text = "Job"
        Me.btnJobLink.UseVisualStyleBackColor = True
        '
        'btnCustLink
        '
        Me.btnCustLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCustLink.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustLink.Location = New System.Drawing.Point(11, 22)
        Me.btnCustLink.Name = "btnCustLink"
        Me.btnCustLink.Size = New System.Drawing.Size(75, 23)
        Me.btnCustLink.TabIndex = 0
        Me.btnCustLink.Text = "Customer"
        Me.btnCustLink.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNew.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.ForeColor = System.Drawing.Color.Black
        Me.btnNew.Location = New System.Drawing.Point(273, 80)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(119, 31)
        Me.btnNew.TabIndex = 27
        Me.btnNew.Text = "New Entry"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'chkReminders
        '
        Me.chkReminders.AutoSize = True
        Me.chkReminders.ForeColor = System.Drawing.Color.Black
        Me.chkReminders.Location = New System.Drawing.Point(19, 106)
        Me.chkReminders.Name = "chkReminders"
        Me.chkReminders.Size = New System.Drawing.Size(115, 20)
        Me.chkReminders.TabIndex = 28
        Me.chkReminders.Text = "Reminders only"
        Me.chkReminders.UseVisualStyleBackColor = True
        '
        'chkComplete
        '
        Me.chkComplete.AutoSize = True
        Me.chkComplete.ForeColor = System.Drawing.Color.Black
        Me.chkComplete.Location = New System.Drawing.Point(19, 80)
        Me.chkComplete.Name = "chkComplete"
        Me.chkComplete.Size = New System.Drawing.Size(167, 20)
        Me.chkComplete.TabIndex = 29
        Me.chkComplete.Text = "Show Completed Entries"
        Me.chkComplete.UseVisualStyleBackColor = True
        '
        'lblReminder
        '
        Me.lblReminder.AutoSize = True
        Me.lblReminder.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblReminder.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReminder.ForeColor = System.Drawing.Color.White
        Me.lblReminder.Location = New System.Drawing.Point(12, 144)
        Me.lblReminder.Name = "lblReminder"
        Me.lblReminder.Size = New System.Drawing.Size(77, 19)
        Me.lblReminder.TabIndex = 30
        Me.lblReminder.Text = "Reminder"
        '
        'lblComplete
        '
        Me.lblComplete.AutoSize = True
        Me.lblComplete.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblComplete.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComplete.ForeColor = System.Drawing.Color.White
        Me.lblComplete.Location = New System.Drawing.Point(182, 144)
        Me.lblComplete.Name = "lblComplete"
        Me.lblComplete.Size = New System.Drawing.Size(76, 19)
        Me.lblComplete.TabIndex = 31
        Me.lblComplete.Text = "Complete"
        '
        'lblOverdue
        '
        Me.lblOverdue.AutoSize = True
        Me.lblOverdue.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblOverdue.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverdue.ForeColor = System.Drawing.Color.White
        Me.lblOverdue.Location = New System.Drawing.Point(95, 144)
        Me.lblOverdue.Name = "lblOverdue"
        Me.lblOverdue.Size = New System.Drawing.Size(69, 19)
        Me.lblOverdue.TabIndex = 32
        Me.lblOverdue.Text = "Overdue"
        '
        'lblName
        '
        Me.lblName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblName.Font = New System.Drawing.Font("Felix Titling", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(509, 12)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(405, 25)
        Me.lblName.TabIndex = 35
        Me.lblName.Text = "Name"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(62, 40)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(152, 25)
        Me.lblDate.TabIndex = 37
        Me.lblDate.Text = "dd MM yyyy"
        '
        'frmDiary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(926, 464)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblOverdue)
        Me.Controls.Add(Me.lblComplete)
        Me.Controls.Add(Me.lblReminder)
        Me.Controls.Add(Me.chkComplete)
        Me.Controls.Add(Me.chkReminders)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.rtbBody)
        Me.Controls.Add(Me.dgvDiary)
        Me.Controls.Add(Me.lblFormName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnSetComplete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnSetReminder)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(730, 500)
        Me.Name = "frmDiary"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDiary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnSetReminder As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnSetComplete As System.Windows.Forms.Button
    Friend WithEvents lblFormName As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dgvDiary As System.Windows.Forms.DataGridView
    Friend WithEvents rtbBody As System.Windows.Forms.RichTextBox
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnJobLink As System.Windows.Forms.Button
    Friend WithEvents btnCustLink As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents chkReminders As System.Windows.Forms.CheckBox
    Friend WithEvents chkComplete As System.Windows.Forms.CheckBox
    Friend WithEvents lblReminder As System.Windows.Forms.Label
    Friend WithEvents lblComplete As System.Windows.Forms.Label
    Friend WithEvents lblOverdue As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblF3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblF4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dremId As DataGridViewTextBoxColumn
    Friend WithEvents dremCustId As DataGridViewTextBoxColumn
    Friend WithEvents dremJobId As DataGridViewTextBoxColumn
    Friend WithEvents dremUserCode As DataGridViewTextBoxColumn
    Friend WithEvents dremDate As DataGridViewTextBoxColumn
    Friend WithEvents dremSubject As DataGridViewTextBoxColumn
    Friend WithEvents dremRem As DataGridViewTextBoxColumn
    Friend WithEvents dremCallback As DataGridViewTextBoxColumn
    Friend WithEvents dremClosed As DataGridViewTextBoxColumn
    Friend WithEvents dremHeader As DataGridViewTextBoxColumn
End Class
