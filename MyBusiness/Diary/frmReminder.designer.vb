<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReminder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReminder))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSetComplete = New System.Windows.Forms.Button()
        Me.lblFormName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.rtbBody = New System.Windows.Forms.RichTextBox()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.lblReminder = New System.Windows.Forms.Label()
        Me.lblComplete = New System.Windows.Forms.Label()
        Me.lblOverdue = New System.Windows.Forms.Label()
        Me.dtpSelectDate = New System.Windows.Forms.DateTimePicker()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblRemDate = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblJob = New System.Windows.Forms.Label()
        Me.lblCust = New System.Windows.Forms.Label()
        Me.chkReminder = New System.Windows.Forms.CheckBox()
        Me.chkCallBack = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 363)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(556, 24)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(20, 19)
        Me.lblStatus.Text = "   "
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(356, 317)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(88, 34)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(12, 317)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 34)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUpdate.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(93, 317)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 34)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSetComplete
        '
        Me.btnSetComplete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetComplete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSetComplete.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetComplete.Location = New System.Drawing.Point(455, 227)
        Me.btnSetComplete.Name = "btnSetComplete"
        Me.btnSetComplete.Size = New System.Drawing.Size(89, 54)
        Me.btnSetComplete.TabIndex = 3
        Me.btnSetComplete.Text = "Set Complete"
        Me.btnSetComplete.UseVisualStyleBackColor = True
        '
        'lblFormName
        '
        Me.lblFormName.AutoSize = True
        Me.lblFormName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblFormName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormName.ForeColor = System.Drawing.Color.Black
        Me.lblFormName.Location = New System.Drawing.Point(60, 12)
        Me.lblFormName.Name = "lblFormName"
        Me.lblFormName.Size = New System.Drawing.Size(147, 25)
        Me.lblFormName.TabIndex = 8
        Me.lblFormName.Text = "Form Name"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(42, 42)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'rtbBody
        '
        Me.rtbBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbBody.BackColor = System.Drawing.Color.Gainsboro
        Me.rtbBody.Location = New System.Drawing.Point(11, 144)
        Me.rtbBody.Name = "rtbBody"
        Me.rtbBody.Size = New System.Drawing.Size(433, 167)
        Me.rtbBody.TabIndex = 2
        Me.rtbBody.Text = ""
        '
        'txtSubject
        '
        Me.txtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.Location = New System.Drawing.Point(12, 114)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(433, 24)
        Me.txtSubject.TabIndex = 1
        '
        'lblReminder
        '
        Me.lblReminder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReminder.AutoSize = True
        Me.lblReminder.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblReminder.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReminder.ForeColor = System.Drawing.Color.White
        Me.lblReminder.Location = New System.Drawing.Point(461, 168)
        Me.lblReminder.Name = "lblReminder"
        Me.lblReminder.Size = New System.Drawing.Size(77, 19)
        Me.lblReminder.TabIndex = 15
        Me.lblReminder.Text = "Reminder"
        '
        'lblComplete
        '
        Me.lblComplete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblComplete.AutoSize = True
        Me.lblComplete.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.lblComplete.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComplete.ForeColor = System.Drawing.Color.White
        Me.lblComplete.Location = New System.Drawing.Point(461, 196)
        Me.lblComplete.Name = "lblComplete"
        Me.lblComplete.Size = New System.Drawing.Size(76, 19)
        Me.lblComplete.TabIndex = 16
        Me.lblComplete.Text = "Complete"
        '
        'lblOverdue
        '
        Me.lblOverdue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOverdue.AutoSize = True
        Me.lblOverdue.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblOverdue.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverdue.ForeColor = System.Drawing.Color.White
        Me.lblOverdue.Location = New System.Drawing.Point(465, 139)
        Me.lblOverdue.Name = "lblOverdue"
        Me.lblOverdue.Size = New System.Drawing.Size(69, 19)
        Me.lblOverdue.TabIndex = 14
        Me.lblOverdue.Text = "Overdue"
        '
        'dtpSelectDate
        '
        Me.dtpSelectDate.CalendarFont = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSelectDate.CustomFormat = ""
        Me.dtpSelectDate.Location = New System.Drawing.Point(114, 61)
        Me.dtpSelectDate.Name = "dtpSelectDate"
        Me.dtpSelectDate.Size = New System.Drawing.Size(198, 24)
        Me.dtpSelectDate.TabIndex = 0
        '
        'lblName
        '
        Me.lblName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(247, 12)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(297, 25)
        Me.lblName.TabIndex = 9
        Me.lblName.Text = "Name"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblRemDate
        '
        Me.lblRemDate.AutoSize = True
        Me.lblRemDate.Location = New System.Drawing.Point(8, 65)
        Me.lblRemDate.Name = "lblRemDate"
        Me.lblRemDate.Size = New System.Drawing.Size(87, 17)
        Me.lblRemDate.TabIndex = 10
        Me.lblRemDate.Text = "Reminder for"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblJob)
        Me.GroupBox1.Controls.Add(Me.lblCust)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(469, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(65, 58)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
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
        'chkReminder
        '
        Me.chkReminder.AutoSize = True
        Me.chkReminder.Checked = True
        Me.chkReminder.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReminder.Location = New System.Drawing.Point(335, 61)
        Me.chkReminder.Name = "chkReminder"
        Me.chkReminder.Size = New System.Drawing.Size(109, 21)
        Me.chkReminder.TabIndex = 11
        Me.chkReminder.Text = "Set Reminder"
        Me.chkReminder.UseVisualStyleBackColor = True
        '
        'chkCallBack
        '
        Me.chkCallBack.AutoSize = True
        Me.chkCallBack.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCallBack.Location = New System.Drawing.Point(335, 88)
        Me.chkCallBack.Name = "chkCallBack"
        Me.chkCallBack.Size = New System.Drawing.Size(121, 18)
        Me.chkCallBack.TabIndex = 12
        Me.chkCallBack.Text = "Call back required"
        Me.chkCallBack.UseVisualStyleBackColor = True
        '
        'frmReminder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(556, 387)
        Me.Controls.Add(Me.chkCallBack)
        Me.Controls.Add(Me.chkReminder)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblRemDate)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.dtpSelectDate)
        Me.Controls.Add(Me.lblOverdue)
        Me.Controls.Add(Me.lblComplete)
        Me.Controls.Add(Me.lblReminder)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.rtbBody)
        Me.Controls.Add(Me.lblFormName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnSetComplete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(470, 300)
        Me.Name = "frmReminder"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnSetComplete As System.Windows.Forms.Button
    Friend WithEvents lblFormName As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents rtbBody As System.Windows.Forms.RichTextBox
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents lblReminder As System.Windows.Forms.Label
    Friend WithEvents lblComplete As System.Windows.Forms.Label
    Friend WithEvents lblOverdue As System.Windows.Forms.Label
    Friend WithEvents dtpSelectDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblRemDate As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblJob As System.Windows.Forms.Label
    Friend WithEvents lblCust As System.Windows.Forms.Label
    Friend WithEvents chkReminder As System.Windows.Forms.CheckBox
    Friend WithEvents chkCallBack As System.Windows.Forms.CheckBox
End Class
