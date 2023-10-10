<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUserControl))
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.txtUserLogin = New System.Windows.Forms.TextBox()
        Me.txtPasswd1 = New System.Windows.Forms.TextBox()
        Me.txtPasswd2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbGuest = New System.Windows.Forms.RadioButton()
        Me.rbAdministrator = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbSuspend = New System.Windows.Forms.RadioButton()
        Me.rbOperator = New System.Windows.Forms.RadioButton()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.lblExists = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtMobile = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtJobTitle = New System.Windows.Forms.TextBox()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.chkForceChange = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtUsercode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtContactNumber = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFormName = New System.Windows.Forms.Label()
        Me.cbSelect = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.txtStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.OK_Button.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.OK_Button.Location = New System.Drawing.Point(474, 592)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(72, 42)
        Me.OK_Button.TabIndex = 6
        Me.OK_Button.Text = "Close"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnUpdate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.Black
        Me.btnUpdate.Location = New System.Drawing.Point(262, 592)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(72, 42)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnRemove.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.Black
        Me.btnRemove.Location = New System.Drawing.Point(52, 592)
        Me.btnRemove.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(72, 42)
        Me.btnRemove.TabIndex = 4
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'txtUserLogin
        '
        Me.txtUserLogin.Location = New System.Drawing.Point(204, 94)
        Me.txtUserLogin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtUserLogin.Name = "txtUserLogin"
        Me.txtUserLogin.Size = New System.Drawing.Size(209, 23)
        Me.txtUserLogin.TabIndex = 1
        '
        'txtPasswd1
        '
        Me.txtPasswd1.Location = New System.Drawing.Point(144, 175)
        Me.txtPasswd1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPasswd1.Name = "txtPasswd1"
        Me.txtPasswd1.Size = New System.Drawing.Size(189, 23)
        Me.txtPasswd1.TabIndex = 8
        '
        'txtPasswd2
        '
        Me.txtPasswd2.Location = New System.Drawing.Point(144, 206)
        Me.txtPasswd2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPasswd2.Name = "txtPasswd2"
        Me.txtPasswd2.Size = New System.Drawing.Size(189, 23)
        Me.txtPasswd2.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(82, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "or enter Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(13, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "New Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(13, 209)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 16)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Confirm Password"
        '
        'rbGuest
        '
        Me.rbGuest.AutoSize = True
        Me.rbGuest.Location = New System.Drawing.Point(6, 51)
        Me.rbGuest.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbGuest.Name = "rbGuest"
        Me.rbGuest.Size = New System.Drawing.Size(57, 20)
        Me.rbGuest.TabIndex = 4
        Me.rbGuest.Text = "Guest"
        Me.rbGuest.UseVisualStyleBackColor = True
        '
        'rbAdministrator
        '
        Me.rbAdministrator.AutoSize = True
        Me.rbAdministrator.Location = New System.Drawing.Point(6, 24)
        Me.rbAdministrator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbAdministrator.Name = "rbAdministrator"
        Me.rbAdministrator.Size = New System.Drawing.Size(102, 20)
        Me.rbAdministrator.TabIndex = 0
        Me.rbAdministrator.Text = "Administrator"
        Me.rbAdministrator.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSuspend)
        Me.GroupBox1.Controls.Add(Me.rbOperator)
        Me.GroupBox1.Controls.Add(Me.rbGuest)
        Me.GroupBox1.Controls.Add(Me.rbAdministrator)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(29, 243)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(233, 91)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Access Level"
        '
        'rbSuspend
        '
        Me.rbSuspend.AutoSize = True
        Me.rbSuspend.Location = New System.Drawing.Point(134, 51)
        Me.rbSuspend.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbSuspend.Name = "rbSuspend"
        Me.rbSuspend.Size = New System.Drawing.Size(88, 20)
        Me.rbSuspend.TabIndex = 5
        Me.rbSuspend.Text = "Suspended"
        Me.rbSuspend.UseVisualStyleBackColor = True
        '
        'rbOperator
        '
        Me.rbOperator.AutoSize = True
        Me.rbOperator.Location = New System.Drawing.Point(134, 24)
        Me.rbOperator.Name = "rbOperator"
        Me.rbOperator.Size = New System.Drawing.Size(76, 20)
        Me.rbOperator.TabIndex = 3
        Me.rbOperator.TabStop = True
        Me.rbOperator.Text = "Operator"
        Me.rbOperator.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnFind.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnFind.Location = New System.Drawing.Point(419, 92)
        Me.btnFind.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(72, 27)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "Check"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'lblExists
        '
        Me.lblExists.BackColor = System.Drawing.Color.Gray
        Me.lblExists.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblExists.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExists.ForeColor = System.Drawing.Color.White
        Me.lblExists.Location = New System.Drawing.Point(87, 127)
        Me.lblExists.Name = "lblExists"
        Me.lblExists.Size = New System.Drawing.Size(404, 28)
        Me.lblExists.TabIndex = 7
        Me.lblExists.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtMobile)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtJobTitle)
        Me.Panel1.Controls.Add(Me.txtNote)
        Me.Panel1.Controls.Add(Me.chkForceChange)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtEmail)
        Me.Panel1.Controls.Add(Me.txtUserName)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtUsercode)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtContactNumber)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtPasswd2)
        Me.Panel1.Controls.Add(Me.txtPasswd1)
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(23, 166)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(564, 409)
        Me.Panel1.TabIndex = 3
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(361, 45)
        Me.txtMobile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(167, 23)
        Me.txtMobile.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(310, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 16)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Mobile"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(288, 290)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 16)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Note"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(288, 243)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 16)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Job Title"
        '
        'txtJobTitle
        '
        Me.txtJobTitle.Location = New System.Drawing.Point(291, 260)
        Me.txtJobTitle.Name = "txtJobTitle"
        Me.txtJobTitle.Size = New System.Drawing.Size(265, 23)
        Me.txtJobTitle.TabIndex = 11
        '
        'txtNote
        '
        Me.txtNote.BackColor = System.Drawing.Color.White
        Me.txtNote.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(291, 309)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(265, 81)
        Me.txtNote.TabIndex = 12
        '
        'chkForceChange
        '
        Me.chkForceChange.AutoSize = True
        Me.chkForceChange.Location = New System.Drawing.Point(357, 178)
        Me.chkForceChange.Name = "chkForceChange"
        Me.chkForceChange.Size = New System.Drawing.Size(117, 36)
        Me.chkForceChange.TabIndex = 23
        Me.chkForceChange.Text = "Force Password" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Change"
        Me.chkForceChange.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 16)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(122, 85)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(289, 23)
        Me.txtEmail.TabIndex = 4
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(123, 14)
        Me.txtUserName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(288, 23)
        Me.txtUserName.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(203, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 16)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "max. 3 chars."
        '
        'txtUsercode
        '
        Me.txtUsercode.Location = New System.Drawing.Point(122, 115)
        Me.txtUsercode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtUsercode.Name = "txtUsercode"
        Me.txtUsercode.Size = New System.Drawing.Size(75, 23)
        Me.txtUsercode.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 16)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Unique usercode"
        '
        'txtContactNumber
        '
        Me.txtContactNumber.Location = New System.Drawing.Point(122, 45)
        Me.txtContactNumber.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtContactNumber.Name = "txtContactNumber"
        Me.txtContactNumber.Size = New System.Drawing.Size(167, 23)
        Me.txtContactNumber.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Contact number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Name"
        '
        'lblFormName
        '
        Me.lblFormName.AutoSize = True
        Me.lblFormName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormName.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblFormName.Location = New System.Drawing.Point(60, 12)
        Me.lblFormName.Name = "lblFormName"
        Me.lblFormName.Size = New System.Drawing.Size(147, 25)
        Me.lblFormName.TabIndex = 9
        Me.lblFormName.Text = "Form Name"
        '
        'cbSelect
        '
        Me.cbSelect.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelect.DisplayMember = "name"
        Me.cbSelect.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSelect.FormattingEnabled = True
        Me.cbSelect.Location = New System.Drawing.Point(156, 60)
        Me.cbSelect.Name = "cbSelect"
        Me.cbSelect.Size = New System.Drawing.Size(257, 22)
        Me.cbSelect.TabIndex = 0
        Me.cbSelect.ValueMember = "user_id"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(85, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 16)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Select"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(42, 42)
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.StatusStrip1.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 647)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(593, 24)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtStatus.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.txtStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.txtStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(20, 19)
        Me.txtStatus.Text = "   "
        '
        'FrmUserControl
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(593, 671)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cbSelect)
        Me.Controls.Add(Me.lblFormName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblExists)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUserLogin)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnRemove)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUserControl"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents rbAdministrator As System.Windows.Forms.RadioButton
    Friend WithEvents rbGuest As System.Windows.Forms.RadioButton
    Friend WithEvents txtUserLogin As System.Windows.Forms.TextBox
    Friend WithEvents txtPasswd1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPasswd2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents txtStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents lblExists As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtContactNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFormName As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtUsercode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rbSuspend As System.Windows.Forms.RadioButton
    Friend WithEvents rbOperator As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtJobTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents chkForceChange As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents cbSelect As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMobile As TextBox
    Friend WithEvents Label8 As Label
End Class
