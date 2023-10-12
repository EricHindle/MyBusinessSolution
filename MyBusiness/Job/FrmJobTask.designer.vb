<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJobTask
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmJobTask))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkStarted = New System.Windows.Forms.CheckBox()
        Me.chkCompleted = New System.Windows.Forms.CheckBox()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.nudCost = New System.Windows.Forms.NumericUpDown()
        Me.nudTime = New System.Windows.Forms.NumericUpDown()
        Me.rtbDescription = New System.Windows.Forms.RichTextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblJobName = New System.Windows.Forms.Label()
        Me.nudTaxRate = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkTaxable = New System.Windows.Forms.CheckBox()
        Me.PicUpdate = New System.Windows.Forms.PictureBox()
        Me.PicClose = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.PicAdd = New System.Windows.Forms.PictureBox()
        Me.CbTask = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.nudTaxRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.Location = New System.Drawing.Point(11, 12)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 51)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 69
        Me.PictureBox1.TabStop = False
        '
        'lblScreenName
        '
        Me.lblScreenName.AutoSize = True
        Me.lblScreenName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenName.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblScreenName.Location = New System.Drawing.Point(63, 12)
        Me.lblScreenName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(112, 25)
        Me.lblScreenName.TabIndex = 7
        Me.lblScreenName.Text = "Job Task"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 75)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Job"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Task name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Description"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 285)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Cost"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(295, 285)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Time (hours)"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 372)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Start date"
        '
        'chkStarted
        '
        Me.chkStarted.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkStarted.AutoSize = True
        Me.chkStarted.Location = New System.Drawing.Point(368, 346)
        Me.chkStarted.Name = "chkStarted"
        Me.chkStarted.Size = New System.Drawing.Size(84, 21)
        Me.chkStarted.TabIndex = 5
        Me.chkStarted.Text = "is Started"
        Me.ToolTip1.SetToolTip(Me.chkStarted, "Has the task been started")
        Me.chkStarted.UseVisualStyleBackColor = True
        '
        'chkCompleted
        '
        Me.chkCompleted.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkCompleted.AutoSize = True
        Me.chkCompleted.Location = New System.Drawing.Point(368, 374)
        Me.chkCompleted.Name = "chkCompleted"
        Me.chkCompleted.Size = New System.Drawing.Size(105, 21)
        Me.chkCompleted.TabIndex = 6
        Me.chkCompleted.Text = "is Completed"
        Me.ToolTip1.SetToolTip(Me.chkCompleted, "Is the task complete?")
        Me.chkCompleted.UseVisualStyleBackColor = True
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpStartDate.Location = New System.Drawing.Point(109, 368)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(200, 24)
        Me.dtpStartDate.TabIndex = 4
        '
        'nudCost
        '
        Me.nudCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudCost.DecimalPlaces = 2
        Me.nudCost.Location = New System.Drawing.Point(99, 283)
        Me.nudCost.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudCost.Name = "nudCost"
        Me.nudCost.Size = New System.Drawing.Size(120, 24)
        Me.nudCost.TabIndex = 2
        '
        'nudTime
        '
        Me.nudTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudTime.DecimalPlaces = 2
        Me.nudTime.Location = New System.Drawing.Point(387, 283)
        Me.nudTime.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudTime.Name = "nudTime"
        Me.nudTime.Size = New System.Drawing.Size(120, 24)
        Me.nudTime.TabIndex = 3
        '
        'rtbDescription
        '
        Me.rtbDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbDescription.Location = New System.Drawing.Point(34, 197)
        Me.rtbDescription.Name = "rtbDescription"
        Me.rtbDescription.Size = New System.Drawing.Size(474, 80)
        Me.rtbDescription.TabIndex = 1
        Me.rtbDescription.Text = ""
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 464)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(537, 22)
        Me.StatusStrip1.TabIndex = 15
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.lblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblStatus.Size = New System.Drawing.Size(7, 17)
        '
        'lblJobName
        '
        Me.lblJobName.AutoSize = True
        Me.lblJobName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobName.Location = New System.Drawing.Point(107, 75)
        Me.lblJobName.Name = "lblJobName"
        Me.lblJobName.Size = New System.Drawing.Size(78, 19)
        Me.lblJobName.TabIndex = 9
        Me.lblJobName.Text = "Job name"
        '
        'nudTaxRate
        '
        Me.nudTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudTaxRate.DecimalPlaces = 2
        Me.nudTaxRate.Location = New System.Drawing.Point(195, 325)
        Me.nudTaxRate.Name = "nudTaxRate"
        Me.nudTaxRate.Size = New System.Drawing.Size(60, 24)
        Me.nudTaxRate.TabIndex = 72
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(136, 329)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 17)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "Rate %"
        '
        'chkTaxable
        '
        Me.chkTaxable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkTaxable.AutoSize = True
        Me.chkTaxable.Location = New System.Drawing.Point(43, 327)
        Me.chkTaxable.Name = "chkTaxable"
        Me.chkTaxable.Size = New System.Drawing.Size(74, 21)
        Me.chkTaxable.TabIndex = 74
        Me.chkTaxable.Text = "Taxable"
        Me.ToolTip1.SetToolTip(Me.chkTaxable, "Add tax to the price?")
        Me.chkTaxable.UseVisualStyleBackColor = True
        '
        'PicUpdate
        '
        Me.PicUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicUpdate.Image = Global.MyBusiness.My.Resources.Resources.update
        Me.PicUpdate.InitialImage = Nothing
        Me.PicUpdate.Location = New System.Drawing.Point(32, 409)
        Me.PicUpdate.Name = "PicUpdate"
        Me.PicUpdate.Size = New System.Drawing.Size(42, 42)
        Me.PicUpdate.TabIndex = 103
        Me.PicUpdate.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicUpdate, "Update the job task")
        '
        'PicClose
        '
        Me.PicClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicClose.Image = Global.MyBusiness.My.Resources.Resources.exitbutton
        Me.PicClose.InitialImage = Nothing
        Me.PicClose.Location = New System.Drawing.Point(467, 409)
        Me.PicClose.Name = "PicClose"
        Me.PicClose.Size = New System.Drawing.Size(42, 42)
        Me.PicClose.TabIndex = 104
        Me.PicClose.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicClose, "Close the form")
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.BackgroundImage = Global.MyBusiness.My.Resources.Resources.addany
        Me.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAdd.Location = New System.Drawing.Point(480, 112)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(29, 29)
        Me.BtnAdd.TabIndex = 106
        Me.ToolTip1.SetToolTip(Me.BtnAdd, "Create a new task")
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'PicAdd
        '
        Me.PicAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicAdd.Image = Global.MyBusiness.My.Resources.Resources.add
        Me.PicAdd.InitialImage = Nothing
        Me.PicAdd.Location = New System.Drawing.Point(32, 409)
        Me.PicAdd.Name = "PicAdd"
        Me.PicAdd.Size = New System.Drawing.Size(42, 42)
        Me.PicAdd.TabIndex = 107
        Me.PicAdd.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicAdd, "Add the new job task")
        '
        'CbTask
        '
        Me.CbTask.FormattingEnabled = True
        Me.CbTask.Location = New System.Drawing.Point(111, 115)
        Me.CbTask.Name = "CbTask"
        Me.CbTask.Size = New System.Drawing.Size(341, 24)
        Me.CbTask.TabIndex = 105
        '
        'FrmJobTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 486)
        Me.Controls.Add(Me.PicAdd)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.CbTask)
        Me.Controls.Add(Me.PicClose)
        Me.Controls.Add(Me.PicUpdate)
        Me.Controls.Add(Me.chkTaxable)
        Me.Controls.Add(Me.nudTaxRate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblJobName)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.rtbDescription)
        Me.Controls.Add(Me.nudTime)
        Me.Controls.Add(Me.nudCost)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.chkCompleted)
        Me.Controls.Add(Me.chkStarted)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblScreenName)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "FrmJobTask"
        Me.ShowIcon = False
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.nudTaxRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblScreenName As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents chkStarted As CheckBox
    Friend WithEvents chkCompleted As CheckBox
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents nudCost As NumericUpDown
    Friend WithEvents nudTime As NumericUpDown
    Friend WithEvents rtbDescription As RichTextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblJobName As Label
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents nudTaxRate As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkTaxable As System.Windows.Forms.CheckBox
    Friend WithEvents PicUpdate As PictureBox
    Friend WithEvents PicClose As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents CbTask As ComboBox
    Friend WithEvents BtnAdd As Button
    Friend WithEvents PicAdd As PictureBox
End Class
