﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReminder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReminder))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PicUpdate = New System.Windows.Forms.PictureBox()
        Me.PicAdd = New System.Windows.Forms.PictureBox()
        Me.PicToggleComplete = New System.Windows.Forms.PictureBox()
        Me.PicClose = New System.Windows.Forms.PictureBox()
        Me.PicSetReminder = New System.Windows.Forms.PictureBox()
        Me.PicSetCallback = New System.Windows.Forms.PictureBox()
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
        Me.LblJobName = New System.Windows.Forms.Label()
        Me.LblCustName = New System.Windows.Forms.Label()
        Me.lblJob = New System.Windows.Forms.Label()
        Me.lblCust = New System.Windows.Forms.Label()
        Me.chkCallBack = New System.Windows.Forms.CheckBox()
        Me.chkReminder = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicToggleComplete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicSetReminder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicSetCallback, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 461)
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
        'PicUpdate
        '
        Me.PicUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicUpdate.Image = Global.MyBusiness.My.Resources.Resources.updatediary
        Me.PicUpdate.InitialImage = Nothing
        Me.PicUpdate.Location = New System.Drawing.Point(76, 410)
        Me.PicUpdate.Name = "PicUpdate"
        Me.PicUpdate.Size = New System.Drawing.Size(42, 42)
        Me.PicUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicUpdate.TabIndex = 102
        Me.PicUpdate.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicUpdate, "Update reminder")
        '
        'PicAdd
        '
        Me.PicAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicAdd.Image = Global.MyBusiness.My.Resources.Resources.adddiary
        Me.PicAdd.InitialImage = Nothing
        Me.PicAdd.Location = New System.Drawing.Point(12, 410)
        Me.PicAdd.Name = "PicAdd"
        Me.PicAdd.Size = New System.Drawing.Size(42, 42)
        Me.PicAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicAdd.TabIndex = 101
        Me.PicAdd.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicAdd, "Add Reminder")
        '
        'PicToggleComplete
        '
        Me.PicToggleComplete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicToggleComplete.Image = Global.MyBusiness.My.Resources.Resources.closediary
        Me.PicToggleComplete.InitialImage = Nothing
        Me.PicToggleComplete.Location = New System.Drawing.Point(143, 410)
        Me.PicToggleComplete.Name = "PicToggleComplete"
        Me.PicToggleComplete.Size = New System.Drawing.Size(42, 42)
        Me.PicToggleComplete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicToggleComplete.TabIndex = 100
        Me.PicToggleComplete.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicToggleComplete, "Mark as completed")
        '
        'PicClose
        '
        Me.PicClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicClose.Image = Global.MyBusiness.My.Resources.Resources.exitbutton
        Me.PicClose.InitialImage = Nothing
        Me.PicClose.Location = New System.Drawing.Point(492, 410)
        Me.PicClose.Name = "PicClose"
        Me.PicClose.Size = New System.Drawing.Size(42, 42)
        Me.PicClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicClose.TabIndex = 99
        Me.PicClose.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicClose, "Close")
        '
        'PicSetReminder
        '
        Me.PicSetReminder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicSetReminder.Image = Global.MyBusiness.My.Resources.Resources.setreminder
        Me.PicSetReminder.InitialImage = Nothing
        Me.PicSetReminder.Location = New System.Drawing.Point(492, 109)
        Me.PicSetReminder.Name = "PicSetReminder"
        Me.PicSetReminder.Size = New System.Drawing.Size(42, 42)
        Me.PicSetReminder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicSetReminder.TabIndex = 103
        Me.PicSetReminder.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicSetReminder, "Set as reminder")
        '
        'PicSetCallback
        '
        Me.PicSetCallback.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicSetCallback.Image = Global.MyBusiness.My.Resources.Resources.PhoneCall
        Me.PicSetCallback.InitialImage = Nothing
        Me.PicSetCallback.Location = New System.Drawing.Point(492, 157)
        Me.PicSetCallback.Name = "PicSetCallback"
        Me.PicSetCallback.Size = New System.Drawing.Size(42, 42)
        Me.PicSetCallback.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicSetCallback.TabIndex = 104
        Me.PicSetCallback.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicSetCallback, "Set Callback required")
        '
        'lblFormName
        '
        Me.lblFormName.AutoSize = True
        Me.lblFormName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblFormName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormName.ForeColor = System.Drawing.Color.DarkSlateGray
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
        Me.rtbBody.Location = New System.Drawing.Point(11, 227)
        Me.rtbBody.Name = "rtbBody"
        Me.rtbBody.Size = New System.Drawing.Size(433, 173)
        Me.rtbBody.TabIndex = 2
        Me.rtbBody.Text = ""
        '
        'txtSubject
        '
        Me.txtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.Location = New System.Drawing.Point(11, 180)
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
        Me.lblReminder.Location = New System.Drawing.Point(458, 256)
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
        Me.lblComplete.Location = New System.Drawing.Point(458, 284)
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
        Me.lblOverdue.Location = New System.Drawing.Point(462, 227)
        Me.lblOverdue.Name = "lblOverdue"
        Me.lblOverdue.Size = New System.Drawing.Size(69, 19)
        Me.lblOverdue.TabIndex = 14
        Me.lblOverdue.Text = "Overdue"
        '
        'dtpSelectDate
        '
        Me.dtpSelectDate.CalendarFont = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSelectDate.CustomFormat = ""
        Me.dtpSelectDate.Location = New System.Drawing.Point(113, 127)
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
        Me.lblName.ForeColor = System.Drawing.Color.DarkSlateGray
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
        Me.lblRemDate.Location = New System.Drawing.Point(7, 131)
        Me.lblRemDate.Name = "lblRemDate"
        Me.lblRemDate.Size = New System.Drawing.Size(87, 17)
        Me.lblRemDate.TabIndex = 10
        Me.lblRemDate.Text = "Reminder for"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.LblJobName)
        Me.GroupBox1.Controls.Add(Me.LblCustName)
        Me.GroupBox1.Controls.Add(Me.lblJob)
        Me.GroupBox1.Controls.Add(Me.lblCust)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(10, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(433, 58)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
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
        'chkCallBack
        '
        Me.chkCallBack.AutoSize = True
        Me.chkCallBack.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCallBack.Location = New System.Drawing.Point(334, 154)
        Me.chkCallBack.Name = "chkCallBack"
        Me.chkCallBack.Size = New System.Drawing.Size(111, 17)
        Me.chkCallBack.TabIndex = 12
        Me.chkCallBack.Text = "Call back required"
        Me.chkCallBack.UseVisualStyleBackColor = True
        Me.chkCallBack.Visible = False
        '
        'chkReminder
        '
        Me.chkReminder.AutoSize = True
        Me.chkReminder.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkReminder.Location = New System.Drawing.Point(334, 127)
        Me.chkReminder.Name = "chkReminder"
        Me.chkReminder.Size = New System.Drawing.Size(74, 17)
        Me.chkReminder.TabIndex = 11
        Me.chkReminder.Text = " Reminder"
        Me.chkReminder.UseVisualStyleBackColor = True
        Me.chkReminder.Visible = False
        '
        'FrmReminder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(556, 485)
        Me.Controls.Add(Me.PicSetCallback)
        Me.Controls.Add(Me.PicSetReminder)
        Me.Controls.Add(Me.PicUpdate)
        Me.Controls.Add(Me.PicAdd)
        Me.Controls.Add(Me.PicToggleComplete)
        Me.Controls.Add(Me.PicClose)
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
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(470, 300)
        Me.Name = "FrmReminder"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicToggleComplete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicSetReminder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicSetCallback, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
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
    Friend WithEvents chkCallBack As System.Windows.Forms.CheckBox
    Friend WithEvents LblJobName As Label
    Friend WithEvents LblCustName As Label
    Friend WithEvents PicUpdate As PictureBox
    Friend WithEvents PicAdd As PictureBox
    Friend WithEvents PicToggleComplete As PictureBox
    Friend WithEvents PicClose As PictureBox
    Friend WithEvents PicSetReminder As PictureBox
    Friend WithEvents PicSetCallback As PictureBox
    Friend WithEvents chkReminder As CheckBox
End Class
