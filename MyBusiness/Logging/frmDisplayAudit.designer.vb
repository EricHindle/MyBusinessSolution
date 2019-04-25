<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDisplayAudit
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDisplayAudit))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblFormName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dgvAudit = New System.Windows.Forms.DataGridView()
        Me.audId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.audDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.audUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.audComputer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.audRecType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.audRecId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.audAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.audNewValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtUsercode = New System.Windows.Forms.TextBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.chkUser = New System.Windows.Forms.CheckBox()
        Me.chkDate = New System.Windows.Forms.CheckBox()
        Me.chkRecordType = New System.Windows.Forms.CheckBox()
        Me.cbRecordType = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(727, 414)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 34)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblFormName
        '
        Me.lblFormName.AutoSize = True
        Me.lblFormName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormName.ForeColor = System.Drawing.Color.Black
        Me.lblFormName.Location = New System.Drawing.Point(60, 12)
        Me.lblFormName.Name = "lblFormName"
        Me.lblFormName.Size = New System.Drawing.Size(147, 25)
        Me.lblFormName.TabIndex = 20
        Me.lblFormName.Text = "Form Name"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(42, 42)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'dgvAudit
        '
        Me.dgvAudit.AllowUserToAddRows = False
        Me.dgvAudit.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvAudit.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAudit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAudit.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAudit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.audId, Me.audDate, Me.audUser, Me.audComputer, Me.audRecType, Me.audRecId, Me.audAction, Me.audNewValue})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(26, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAudit.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAudit.Location = New System.Drawing.Point(12, 109)
        Me.dgvAudit.MultiSelect = False
        Me.dgvAudit.Name = "dgvAudit"
        Me.dgvAudit.ReadOnly = True
        Me.dgvAudit.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(74, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.dgvAudit.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAudit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAudit.Size = New System.Drawing.Size(790, 288)
        Me.dgvAudit.TabIndex = 21
        '
        'audId
        '
        Me.audId.HeaderText = "Id"
        Me.audId.Name = "audId"
        Me.audId.ReadOnly = True
        Me.audId.Visible = False
        '
        'audDate
        '
        Me.audDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.audDate.HeaderText = "Date"
        Me.audDate.Name = "audDate"
        Me.audDate.ReadOnly = True
        Me.audDate.Width = 150
        '
        'audUser
        '
        Me.audUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.audUser.HeaderText = "User"
        Me.audUser.Name = "audUser"
        Me.audUser.ReadOnly = True
        Me.audUser.Width = 50
        '
        'audComputer
        '
        Me.audComputer.HeaderText = "Computer"
        Me.audComputer.Name = "audComputer"
        Me.audComputer.ReadOnly = True
        '
        'audRecType
        '
        Me.audRecType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.audRecType.HeaderText = "Record Type"
        Me.audRecType.Name = "audRecType"
        Me.audRecType.ReadOnly = True
        '
        'audRecId
        '
        Me.audRecId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.audRecId.HeaderText = "Record Id"
        Me.audRecId.Name = "audRecId"
        Me.audRecId.ReadOnly = True
        Me.audRecId.Width = 70
        '
        'audAction
        '
        Me.audAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.audAction.HeaderText = "Action"
        Me.audAction.Name = "audAction"
        Me.audAction.ReadOnly = True
        Me.audAction.Width = 70
        '
        'audNewValue
        '
        Me.audNewValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.audNewValue.HeaderText = "New Value"
        Me.audNewValue.Name = "audNewValue"
        Me.audNewValue.ReadOnly = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(727, 56)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 34)
        Me.btnSearch.TabIndex = 22
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtUsercode
        '
        Me.txtUsercode.Location = New System.Drawing.Point(83, 62)
        Me.txtUsercode.Name = "txtUsercode"
        Me.txtUsercode.Size = New System.Drawing.Size(100, 23)
        Me.txtUsercode.TabIndex = 23
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(283, 62)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(145, 23)
        Me.dtpDate.TabIndex = 25
        '
        'chkUser
        '
        Me.chkUser.AutoSize = True
        Me.chkUser.ForeColor = System.Drawing.Color.Black
        Me.chkUser.Location = New System.Drawing.Point(24, 64)
        Me.chkUser.Name = "chkUser"
        Me.chkUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkUser.Size = New System.Drawing.Size(53, 20)
        Me.chkUser.TabIndex = 26
        Me.chkUser.Text = "User"
        Me.chkUser.UseVisualStyleBackColor = True
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.ForeColor = System.Drawing.Color.Black
        Me.chkDate.Location = New System.Drawing.Point(215, 64)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkDate.Size = New System.Drawing.Size(53, 20)
        Me.chkDate.TabIndex = 27
        Me.chkDate.Text = "Date"
        Me.chkDate.UseVisualStyleBackColor = True
        '
        'chkRecordType
        '
        Me.chkRecordType.AutoSize = True
        Me.chkRecordType.ForeColor = System.Drawing.Color.Black
        Me.chkRecordType.Location = New System.Drawing.Point(459, 64)
        Me.chkRecordType.Name = "chkRecordType"
        Me.chkRecordType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkRecordType.Size = New System.Drawing.Size(99, 20)
        Me.chkRecordType.TabIndex = 28
        Me.chkRecordType.Text = "Record Type"
        Me.chkRecordType.UseVisualStyleBackColor = True
        '
        'cbRecordType
        '
        Me.cbRecordType.FormattingEnabled = True
        Me.cbRecordType.Location = New System.Drawing.Point(564, 62)
        Me.cbRecordType.Name = "cbRecordType"
        Me.cbRecordType.Size = New System.Drawing.Size(131, 24)
        Me.cbRecordType.TabIndex = 30
        '
        'frmDisplayAudit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(814, 460)
        Me.Controls.Add(Me.cbRecordType)
        Me.Controls.Add(Me.chkRecordType)
        Me.Controls.Add(Me.chkDate)
        Me.Controls.Add(Me.chkUser)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.txtUsercode)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.dgvAudit)
        Me.Controls.Add(Me.lblFormName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(830, 430)
        Me.Name = "frmDisplayAudit"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAudit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblFormName As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dgvAudit As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtUsercode As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkUser As System.Windows.Forms.CheckBox
    Friend WithEvents chkDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecordType As System.Windows.Forms.CheckBox
    Friend WithEvents audId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents audDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents audUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents audComputer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents audRecType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents audRecId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents audAction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents audNewValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbRecordType As System.Windows.Forms.ComboBox
End Class
