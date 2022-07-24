<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReminderList
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReminderList))
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.DgvReminders = New System.Windows.Forms.DataGridView()
        Me.remId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remCustId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remJobId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remSubject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remHeader = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ChkShowAtLogin = New System.Windows.Forms.CheckBox()
        Me.ChkShowAll = New System.Windows.Forms.CheckBox()
        Me.lblFormName = New System.Windows.Forms.Label()
        Me.BtnCustomer = New System.Windows.Forms.Button()
        Me.BtnJob = New System.Windows.Forms.Button()
        Me.lblReminder = New System.Windows.Forms.Label()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.BtnSetReminder = New System.Windows.Forms.Button()
        Me.BtnCloseRem = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rtbBody = New System.Windows.Forms.RichTextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblJobName = New System.Windows.Forms.Label()
        Me.LblCustName = New System.Windows.Forms.Label()
        Me.lblJob = New System.Windows.Forms.Label()
        Me.lblCust = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.DgvReminders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.SystemColors.Control
        Me.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtnClose.Location = New System.Drawing.Point(328, 291)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(74, 36)
        Me.BtnClose.TabIndex = 8
        Me.BtnClose.Text = "Exit"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'DgvReminders
        '
        Me.DgvReminders.AllowUserToAddRows = False
        Me.DgvReminders.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.DgvReminders.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvReminders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvReminders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.DgvReminders.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvReminders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DgvReminders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvReminders.ColumnHeadersVisible = False
        Me.DgvReminders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.remId, Me.remCustId, Me.remJobId, Me.remDate, Me.remSubject, Me.remHeader})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvReminders.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvReminders.Location = New System.Drawing.Point(420, 63)
        Me.DgvReminders.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DgvReminders.MultiSelect = False
        Me.DgvReminders.Name = "DgvReminders"
        Me.DgvReminders.ReadOnly = True
        Me.DgvReminders.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.DgvReminders.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvReminders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvReminders.Size = New System.Drawing.Size(367, 360)
        Me.DgvReminders.TabIndex = 0
        '
        'remId
        '
        Me.remId.HeaderText = "Id"
        Me.remId.Name = "remId"
        Me.remId.ReadOnly = True
        Me.remId.Visible = False
        '
        'remCustId
        '
        Me.remCustId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.remCustId.HeaderText = "Cust Id"
        Me.remCustId.Name = "remCustId"
        Me.remCustId.ReadOnly = True
        Me.remCustId.Visible = False
        '
        'remJobId
        '
        Me.remJobId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.remJobId.HeaderText = "Job Id"
        Me.remJobId.Name = "remJobId"
        Me.remJobId.ReadOnly = True
        Me.remJobId.Visible = False
        '
        'remDate
        '
        Me.remDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.remDate.HeaderText = "Date"
        Me.remDate.Name = "remDate"
        Me.remDate.ReadOnly = True
        '
        'remSubject
        '
        Me.remSubject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.remSubject.DefaultCellStyle = DataGridViewCellStyle2
        Me.remSubject.HeaderText = "Subject"
        Me.remSubject.Name = "remSubject"
        Me.remSubject.ReadOnly = True
        '
        'remHeader
        '
        Me.remHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.remHeader.HeaderText = "is Header"
        Me.remHeader.Name = "remHeader"
        Me.remHeader.ReadOnly = True
        Me.remHeader.Text = ""
        Me.remHeader.Visible = False
        Me.remHeader.Width = 20
        '
        'ChkShowAtLogin
        '
        Me.ChkShowAtLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkShowAtLogin.AutoSize = True
        Me.ChkShowAtLogin.BackColor = System.Drawing.SystemColors.Control
        Me.ChkShowAtLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ChkShowAtLogin.Location = New System.Drawing.Point(674, 11)
        Me.ChkShowAtLogin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ChkShowAtLogin.Name = "ChkShowAtLogin"
        Me.ChkShowAtLogin.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkShowAtLogin.Size = New System.Drawing.Size(101, 18)
        Me.ChkShowAtLogin.TabIndex = 4
        Me.ChkShowAtLogin.Text = "Show at login"
        Me.ChkShowAtLogin.UseVisualStyleBackColor = False
        '
        'ChkShowAll
        '
        Me.ChkShowAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkShowAll.AutoSize = True
        Me.ChkShowAll.BackColor = System.Drawing.SystemColors.Control
        Me.ChkShowAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ChkShowAll.Location = New System.Drawing.Point(599, 11)
        Me.ChkShowAll.Name = "ChkShowAll"
        Me.ChkShowAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkShowAll.Size = New System.Drawing.Size(69, 18)
        Me.ChkShowAll.TabIndex = 3
        Me.ChkShowAll.Text = "ShowAll"
        Me.ChkShowAll.UseVisualStyleBackColor = False
        '
        'lblFormName
        '
        Me.lblFormName.AutoSize = True
        Me.lblFormName.BackColor = System.Drawing.SystemColors.Control
        Me.lblFormName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblFormName.Location = New System.Drawing.Point(60, 11)
        Me.lblFormName.Name = "lblFormName"
        Me.lblFormName.Size = New System.Drawing.Size(147, 25)
        Me.lblFormName.TabIndex = 9
        Me.lblFormName.Text = "Form Name"
        '
        'BtnCustomer
        '
        Me.BtnCustomer.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCustomer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtnCustomer.Location = New System.Drawing.Point(6, 21)
        Me.BtnCustomer.Name = "BtnCustomer"
        Me.BtnCustomer.Size = New System.Drawing.Size(74, 23)
        Me.BtnCustomer.TabIndex = 0
        Me.BtnCustomer.Text = "Customer"
        Me.BtnCustomer.UseVisualStyleBackColor = False
        '
        'BtnJob
        '
        Me.BtnJob.BackColor = System.Drawing.SystemColors.Control
        Me.BtnJob.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnJob.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtnJob.Location = New System.Drawing.Point(6, 50)
        Me.BtnJob.Name = "BtnJob"
        Me.BtnJob.Size = New System.Drawing.Size(74, 23)
        Me.BtnJob.TabIndex = 1
        Me.BtnJob.Text = "Job"
        Me.BtnJob.UseVisualStyleBackColor = False
        '
        'lblReminder
        '
        Me.lblReminder.AutoSize = True
        Me.lblReminder.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.lblReminder.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReminder.ForeColor = System.Drawing.Color.White
        Me.lblReminder.Location = New System.Drawing.Point(12, 72)
        Me.lblReminder.Name = "lblReminder"
        Me.lblReminder.Size = New System.Drawing.Size(77, 19)
        Me.lblReminder.TabIndex = 10
        Me.lblReminder.Text = "Reminder"
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(15, 158)
        Me.txtSubject.Multiline = True
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(301, 48)
        Me.txtSubject.TabIndex = 1
        '
        'BtnSetReminder
        '
        Me.BtnSetReminder.BackColor = System.Drawing.SystemColors.Control
        Me.BtnSetReminder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSetReminder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtnSetReminder.Location = New System.Drawing.Point(328, 63)
        Me.BtnSetReminder.Name = "BtnSetReminder"
        Me.BtnSetReminder.Size = New System.Drawing.Size(74, 41)
        Me.BtnSetReminder.TabIndex = 5
        Me.BtnSetReminder.Text = "Set Reminder"
        Me.BtnSetReminder.UseVisualStyleBackColor = False
        '
        'BtnCloseRem
        '
        Me.BtnCloseRem.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCloseRem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCloseRem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtnCloseRem.Location = New System.Drawing.Point(328, 111)
        Me.BtnCloseRem.Name = "BtnCloseRem"
        Me.BtnCloseRem.Size = New System.Drawing.Size(74, 41)
        Me.BtnCloseRem.TabIndex = 6
        Me.BtnCloseRem.Text = "Close Reminder"
        Me.BtnCloseRem.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(790, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.BtnCustomer)
        Me.GroupBox1.Controls.Add(Me.BtnJob)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(322, 158)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(92, 86)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Links"
        '
        'rtbBody
        '
        Me.rtbBody.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rtbBody.Location = New System.Drawing.Point(16, 212)
        Me.rtbBody.Name = "rtbBody"
        Me.rtbBody.Size = New System.Drawing.Size(301, 211)
        Me.rtbBody.TabIndex = 36
        Me.rtbBody.Text = ""
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 11)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 45)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 75
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblJobName)
        Me.GroupBox2.Controls.Add(Me.LblCustName)
        Me.GroupBox2.Controls.Add(Me.lblJob)
        Me.GroupBox2.Controls.Add(Me.lblCust)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(16, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 58)
        Me.GroupBox2.TabIndex = 76
        Me.GroupBox2.TabStop = False
        '
        'LblJobName
        '
        Me.LblJobName.AutoSize = True
        Me.LblJobName.Location = New System.Drawing.Point(65, 35)
        Me.LblJobName.Name = "LblJobName"
        Me.LblJobName.Size = New System.Drawing.Size(32, 13)
        Me.LblJobName.TabIndex = 4
        Me.LblJobName.Text = "None"
        '
        'LblCustName
        '
        Me.LblCustName.AutoSize = True
        Me.LblCustName.Location = New System.Drawing.Point(65, 13)
        Me.LblCustName.Name = "LblCustName"
        Me.LblCustName.Size = New System.Drawing.Size(32, 13)
        Me.LblCustName.TabIndex = 3
        Me.LblCustName.Text = "None"
        '
        'lblJob
        '
        Me.lblJob.AutoSize = True
        Me.lblJob.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblJob.Location = New System.Drawing.Point(6, 35)
        Me.lblJob.Name = "lblJob"
        Me.lblJob.Size = New System.Drawing.Size(24, 13)
        Me.lblJob.TabIndex = 2
        Me.lblJob.Text = "Job"
        '
        'lblCust
        '
        Me.lblCust.AutoSize = True
        Me.lblCust.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCust.Location = New System.Drawing.Point(6, 13)
        Me.lblCust.Name = "lblCust"
        Me.lblCust.Size = New System.Drawing.Size(53, 13)
        Me.lblCust.TabIndex = 0
        Me.lblCust.Text = "Customer"
        '
        'LblStatus
        '
        Me.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(5, 0, 2, 0)
        Me.LblStatus.Size = New System.Drawing.Size(11, 22)
        '
        'frmReminderList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(790, 453)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.rtbBody)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnCloseRem)
        Me.Controls.Add(Me.BtnSetReminder)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.lblReminder)
        Me.Controls.Add(Me.lblFormName)
        Me.Controls.Add(Me.ChkShowAll)
        Me.Controls.Add(Me.ChkShowAtLogin)
        Me.Controls.Add(Me.DgvReminders)
        Me.Controls.Add(Me.BtnClose)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmReminderList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DgvReminders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents DgvReminders As System.Windows.Forms.DataGridView
    Friend WithEvents ChkShowAtLogin As System.Windows.Forms.CheckBox
    Friend WithEvents ChkShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents lblFormName As System.Windows.Forms.Label
    Friend WithEvents BtnCustomer As System.Windows.Forms.Button
    Friend WithEvents BtnJob As System.Windows.Forms.Button
    Friend WithEvents lblReminder As System.Windows.Forms.Label
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents BtnSetReminder As System.Windows.Forms.Button
    Friend WithEvents BtnCloseRem As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rtbBody As System.Windows.Forms.RichTextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents remId As DataGridViewTextBoxColumn
    Friend WithEvents remCustId As DataGridViewTextBoxColumn
    Friend WithEvents remJobId As DataGridViewTextBoxColumn
    Friend WithEvents remDate As DataGridViewTextBoxColumn
    Friend WithEvents remSubject As DataGridViewTextBoxColumn
    Friend WithEvents remHeader As DataGridViewButtonColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LblJobName As Label
    Friend WithEvents LblCustName As Label
    Friend WithEvents lblJob As Label
    Friend WithEvents lblCust As Label
    Friend WithEvents LblStatus As ToolStripStatusLabel
End Class
