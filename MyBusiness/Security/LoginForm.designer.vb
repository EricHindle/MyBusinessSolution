<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class LoginForm
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.ApplicationTitle = New System.Windows.Forms.Label()
        Me.Version = New System.Windows.Forms.Label()
        Me.Copyright = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblForgottenPassword = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblInitMessage = New System.Windows.Forms.Label()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsernameLabel
        '
        Me.UsernameLabel.AutoSize = True
        Me.UsernameLabel.BackColor = System.Drawing.Color.White
        Me.UsernameLabel.Location = New System.Drawing.Point(3, 18)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(73, 17)
        Me.UsernameLabel.TabIndex = 5
        Me.UsernameLabel.Text = "&User name"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.AutoSize = True
        Me.PasswordLabel.BackColor = System.Drawing.Color.White
        Me.PasswordLabel.Location = New System.Drawing.Point(3, 50)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(66, 17)
        Me.PasswordLabel.TabIndex = 0
        Me.PasswordLabel.Text = "&Password"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.BackColor = System.Drawing.Color.Maroon
        Me.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsernameTextBox.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameTextBox.ForeColor = System.Drawing.Color.White
        Me.UsernameTextBox.Location = New System.Drawing.Point(83, 15)
        Me.UsernameTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(242, 24)
        Me.UsernameTextBox.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.UsernameTextBox, "Enter your username")
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.Color.Maroon
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordTextBox.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordTextBox.ForeColor = System.Drawing.Color.White
        Me.PasswordTextBox.Location = New System.Drawing.Point(83, 47)
        Me.PasswordTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9632)
        Me.PasswordTextBox.Size = New System.Drawing.Size(242, 24)
        Me.PasswordTextBox.TabIndex = 1
        Me.PasswordTextBox.Text = "g49URAmX"
        Me.ToolTip1.SetToolTip(Me.PasswordTextBox, "Enter your password")
        '
        'OK
        '
        Me.OK.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.OK.Location = New System.Drawing.Point(270, 120)
        Me.OK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(69, 31)
        Me.OK.TabIndex = 2
        Me.OK.Text = "&OK"
        Me.ToolTip1.SetToolTip(Me.OK, "Enter the application")
        Me.OK.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(83, 120)
        Me.Cancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(69, 31)
        Me.Cancel.TabIndex = 3
        Me.Cancel.Text = "&Cancel"
        Me.ToolTip1.SetToolTip(Me.Cancel, "Close the application")
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'ApplicationTitle
        '
        Me.ApplicationTitle.BackColor = System.Drawing.Color.White
        Me.ApplicationTitle.Font = New System.Drawing.Font("Felix Titling", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplicationTitle.ForeColor = System.Drawing.Color.Black
        Me.ApplicationTitle.Location = New System.Drawing.Point(178, 13)
        Me.ApplicationTitle.Name = "ApplicationTitle"
        Me.ApplicationTitle.Size = New System.Drawing.Size(357, 64)
        Me.ApplicationTitle.TabIndex = 3
        Me.ApplicationTitle.Text = "Title"
        Me.ApplicationTitle.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Version
        '
        Me.Version.BackColor = System.Drawing.Color.White
        Me.Version.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.ForeColor = System.Drawing.Color.DimGray
        Me.Version.Location = New System.Drawing.Point(345, 77)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(190, 21)
        Me.Version.TabIndex = 4
        Me.Version.Text = "Version {0}.{1}.{2}"
        Me.Version.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Copyright
        '
        Me.Copyright.BackColor = System.Drawing.Color.White
        Me.Copyright.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.ForeColor = System.Drawing.Color.Gray
        Me.Copyright.Location = New System.Drawing.Point(12, 236)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(167, 41)
        Me.Copyright.TabIndex = 5
        Me.Copyright.Text = "Copyright"
        Me.Copyright.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Cancel)
        Me.Panel1.Controls.Add(Me.lblForgottenPassword)
        Me.Panel1.Controls.Add(Me.PasswordLabel)
        Me.Panel1.Controls.Add(Me.PasswordTextBox)
        Me.Panel1.Controls.Add(Me.UsernameLabel)
        Me.Panel1.Controls.Add(Me.UsernameTextBox)
        Me.Panel1.Controls.Add(Me.OK)
        Me.Panel1.Location = New System.Drawing.Point(184, 115)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(342, 165)
        Me.Panel1.TabIndex = 0
        '
        'lblForgottenPassword
        '
        Me.lblForgottenPassword.AutoSize = True
        Me.lblForgottenPassword.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForgottenPassword.ForeColor = System.Drawing.Color.DimGray
        Me.lblForgottenPassword.Location = New System.Drawing.Point(227, 86)
        Me.lblForgottenPassword.Name = "lblForgottenPassword"
        Me.lblForgottenPassword.Size = New System.Drawing.Size(112, 13)
        Me.lblForgottenPassword.TabIndex = 4
        Me.lblForgottenPassword.Text = "Forgotten Password ?"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "green18.png")
        Me.ImageList1.Images.SetKeyName(1, "red18.png")
        '
        'lblInitMessage
        '
        Me.lblInitMessage.AutoSize = True
        Me.lblInitMessage.BackColor = System.Drawing.Color.White
        Me.lblInitMessage.Font = New System.Drawing.Font("Papyrus", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInitMessage.ForeColor = System.Drawing.Color.Black
        Me.lblInitMessage.Location = New System.Drawing.Point(185, 81)
        Me.lblInitMessage.Name = "lblInitMessage"
        Me.lblInitMessage.Size = New System.Drawing.Size(117, 30)
        Me.lblInitMessage.TabIndex = 6
        Me.lblInitMessage.Text = "Initialising..."
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.LogoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LogoPictureBox.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.LogoPictureBox.Location = New System.Drawing.Point(12, 54)
        Me.LogoPictureBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(150, 150)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'LoginForm
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(550, 286)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Copyright)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.ApplicationTitle)
        Me.Controls.Add(Me.lblInitMessage)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ApplicationTitle As System.Windows.Forms.Label
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents Copyright As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblForgottenPassword As System.Windows.Forms.Label
    Friend WithEvents lblInitMessage As System.Windows.Forms.Label

End Class
