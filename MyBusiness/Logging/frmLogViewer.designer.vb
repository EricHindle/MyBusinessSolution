﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogViewer))
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.rtbLog = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.WrapTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ZoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SendToSupportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblFormName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnToday = New System.Windows.Forms.Button()
        Me.BtnNextFile = New System.Windows.Forms.Button()
        Me.BtnPrevFile = New System.Windows.Forms.Button()
        Me.BtnClearLog = New System.Windows.Forms.Button()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.btnNoZoom = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.OK_Button.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.ForeColor = System.Drawing.Color.Black
        Me.OK_Button.Location = New System.Drawing.Point(685, 378)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(2)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(78, 38)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'rtbLog
        '
        Me.rtbLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbLog.BackColor = System.Drawing.Color.Gainsboro
        Me.rtbLog.ContextMenuStrip = Me.ContextMenuStrip1
        Me.rtbLog.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbLog.ForeColor = System.Drawing.Color.Black
        Me.rtbLog.Location = New System.Drawing.Point(14, 66)
        Me.rtbLog.Margin = New System.Windows.Forms.Padding(2)
        Me.rtbLog.Name = "rtbLog"
        Me.rtbLog.Size = New System.Drawing.Size(748, 307)
        Me.rtbLog.TabIndex = 5
        Me.rtbLog.Text = ""
        Me.rtbLog.WordWrap = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WrapTextToolStripMenuItem, Me.ToolStripSeparator2, Me.ZoomToolStripMenuItem, Me.ToolStripSeparator1, Me.CopyToolStripMenuItem, Me.CopyAllToolStripMenuItem, Me.ToolStripSeparator3, Me.SendToSupportToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(160, 132)
        '
        'WrapTextToolStripMenuItem
        '
        Me.WrapTextToolStripMenuItem.CheckOnClick = True
        Me.WrapTextToolStripMenuItem.Name = "WrapTextToolStripMenuItem"
        Me.WrapTextToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.WrapTextToolStripMenuItem.Text = "Wrap Text"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(156, 6)
        '
        'ZoomToolStripMenuItem
        '
        Me.ZoomToolStripMenuItem.CheckOnClick = True
        Me.ZoomToolStripMenuItem.Name = "ZoomToolStripMenuItem"
        Me.ZoomToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ZoomToolStripMenuItem.Text = "Zoom On"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(156, 6)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.CopyToolStripMenuItem.Text = "Copy Selected"
        '
        'CopyAllToolStripMenuItem
        '
        Me.CopyAllToolStripMenuItem.Name = "CopyAllToolStripMenuItem"
        Me.CopyAllToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.CopyAllToolStripMenuItem.Text = "Copy All"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(156, 6)
        '
        'SendToSupportToolStripMenuItem
        '
        Me.SendToSupportToolStripMenuItem.Name = "SendToSupportToolStripMenuItem"
        Me.SendToSupportToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SendToSupportToolStripMenuItem.Text = "Send to Support"
        '
        'lblFormName
        '
        Me.lblFormName.AutoSize = True
        Me.lblFormName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormName.ForeColor = System.Drawing.Color.Black
        Me.lblFormName.Location = New System.Drawing.Point(58, 11)
        Me.lblFormName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFormName.Name = "lblFormName"
        Me.lblFormName.Size = New System.Drawing.Size(150, 25)
        Me.lblFormName.TabIndex = 4
        Me.lblFormName.Text = "Log Viewer"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.Location = New System.Drawing.Point(11, 11)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(42, 42)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 110
        Me.PictureBox1.TabStop = False
        '
        'BtnToday
        '
        Me.BtnToday.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnToday.AutoSize = True
        Me.BtnToday.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnToday.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnToday.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnToday.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnToday.Location = New System.Drawing.Point(535, 387)
        Me.BtnToday.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnToday.Name = "BtnToday"
        Me.BtnToday.Size = New System.Drawing.Size(60, 28)
        Me.BtnToday.TabIndex = 116
        Me.BtnToday.Text = "Today"
        Me.BtnToday.UseVisualStyleBackColor = True
        '
        'BtnNextFile
        '
        Me.BtnNextFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnNextFile.AutoSize = True
        Me.BtnNextFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnNextFile.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnNextFile.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNextFile.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnNextFile.Location = New System.Drawing.Point(610, 387)
        Me.BtnNextFile.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnNextFile.Name = "BtnNextFile"
        Me.BtnNextFile.Size = New System.Drawing.Size(40, 28)
        Me.BtnNextFile.TabIndex = 115
        Me.BtnNextFile.Text = ">>"
        Me.BtnNextFile.UseVisualStyleBackColor = True
        '
        'BtnPrevFile
        '
        Me.BtnPrevFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPrevFile.AutoSize = True
        Me.BtnPrevFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnPrevFile.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnPrevFile.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrevFile.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnPrevFile.Location = New System.Drawing.Point(480, 386)
        Me.BtnPrevFile.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnPrevFile.Name = "BtnPrevFile"
        Me.BtnPrevFile.Size = New System.Drawing.Size(40, 28)
        Me.BtnPrevFile.TabIndex = 114
        Me.BtnPrevFile.Text = "<<"
        Me.BtnPrevFile.UseVisualStyleBackColor = True
        '
        'BtnClearLog
        '
        Me.BtnClearLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClearLog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnClearLog.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnClearLog.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClearLog.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClearLog.Location = New System.Drawing.Point(14, 377)
        Me.BtnClearLog.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnClearLog.Name = "BtnClearLog"
        Me.BtnClearLog.Size = New System.Drawing.Size(93, 38)
        Me.BtnClearLog.TabIndex = 113
        Me.BtnClearLog.Text = "Clear Log"
        Me.BtnClearLog.UseVisualStyleBackColor = True
        '
        'TrackBar1
        '
        Me.TrackBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TrackBar1.AutoSize = False
        Me.TrackBar1.Location = New System.Drawing.Point(191, 385)
        Me.TrackBar1.Margin = New System.Windows.Forms.Padding(2)
        Me.TrackBar1.Maximum = 30
        Me.TrackBar1.Minimum = 5
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(189, 23)
        Me.TrackBar1.TabIndex = 111
        Me.TrackBar1.TickFrequency = 5
        Me.TrackBar1.Value = 10
        Me.TrackBar1.Visible = False
        '
        'btnNoZoom
        '
        Me.btnNoZoom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNoZoom.AutoSize = True
        Me.btnNoZoom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnNoZoom.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnNoZoom.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNoZoom.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnNoZoom.Location = New System.Drawing.Point(393, 386)
        Me.btnNoZoom.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNoZoom.Name = "btnNoZoom"
        Me.btnNoZoom.Size = New System.Drawing.Size(26, 28)
        Me.btnNoZoom.TabIndex = 112
        Me.btnNoZoom.Text = "1"
        Me.btnNoZoom.UseVisualStyleBackColor = True
        Me.btnNoZoom.Visible = False
        '
        'FrmLogViewer
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(782, 426)
        Me.Controls.Add(Me.BtnToday)
        Me.Controls.Add(Me.BtnNextFile)
        Me.Controls.Add(Me.BtnPrevFile)
        Me.Controls.Add(Me.BtnClearLog)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.btnNoZoom)
        Me.Controls.Add(Me.lblFormName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.rtbLog)
        Me.Controls.Add(Me.OK_Button)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLogViewer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents rtbLog As System.Windows.Forms.RichTextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents WrapTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ZoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblFormName As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SendToSupportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnToday As Button
    Friend WithEvents BtnNextFile As Button
    Friend WithEvents BtnPrevFile As Button
    Friend WithEvents BtnClearLog As Button
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents btnNoZoom As Button
End Class
