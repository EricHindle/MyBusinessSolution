' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectTemplate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelectTemplate))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.DgvTemplates = New System.Windows.Forms.DataGridView()
        Me.tmplId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmplName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PicClose = New System.Windows.Forms.PictureBox()
        Me.PicSelectTemplate = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicSelectTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.Location = New System.Drawing.Point(14, 13)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 71
        Me.PictureBox1.TabStop = False
        '
        'lblScreenName
        '
        Me.lblScreenName.AutoSize = True
        Me.lblScreenName.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenName.ForeColor = System.Drawing.Color.Black
        Me.lblScreenName.Location = New System.Drawing.Point(59, 13)
        Me.lblScreenName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(97, 19)
        Me.lblScreenName.TabIndex = 70
        Me.lblScreenName.Text = "TEMPLATES"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DgvTemplates
        '
        Me.DgvTemplates.AllowUserToAddRows = False
        Me.DgvTemplates.AllowUserToDeleteRows = False
        Me.DgvTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTemplates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tmplId, Me.tmplName})
        Me.DgvTemplates.Location = New System.Drawing.Point(14, 53)
        Me.DgvTemplates.MultiSelect = False
        Me.DgvTemplates.Name = "DgvTemplates"
        Me.DgvTemplates.ReadOnly = True
        Me.DgvTemplates.RowHeadersVisible = False
        Me.DgvTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvTemplates.Size = New System.Drawing.Size(220, 384)
        Me.DgvTemplates.TabIndex = 72
        '
        'tmplId
        '
        Me.tmplId.HeaderText = "Id"
        Me.tmplId.Name = "tmplId"
        Me.tmplId.ReadOnly = True
        Me.tmplId.Visible = False
        '
        'tmplName
        '
        Me.tmplName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tmplName.HeaderText = "Name"
        Me.tmplName.Name = "tmplName"
        Me.tmplName.ReadOnly = True
        '
        'PicClose
        '
        Me.PicClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicClose.Image = Global.MyBusiness.My.Resources.Resources.exitbutton
        Me.PicClose.InitialImage = Nothing
        Me.PicClose.Location = New System.Drawing.Point(191, 443)
        Me.PicClose.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PicClose.Name = "PicClose"
        Me.PicClose.Size = New System.Drawing.Size(42, 36)
        Me.PicClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicClose.TabIndex = 97
        Me.PicClose.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicClose, "Cancel")
        '
        'PicSelectTemplate
        '
        Me.PicSelectTemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicSelectTemplate.Image = Global.MyBusiness.My.Resources.Resources._select
        Me.PicSelectTemplate.InitialImage = Nothing
        Me.PicSelectTemplate.Location = New System.Drawing.Point(14, 443)
        Me.PicSelectTemplate.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PicSelectTemplate.Name = "PicSelectTemplate"
        Me.PicSelectTemplate.Size = New System.Drawing.Size(42, 36)
        Me.PicSelectTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicSelectTemplate.TabIndex = 98
        Me.PicSelectTemplate.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicSelectTemplate, "Select Template")
        '
        'FrmSelectTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(246, 485)
        Me.ControlBox = False
        Me.Controls.Add(Me.PicSelectTemplate)
        Me.Controls.Add(Me.PicClose)
        Me.Controls.Add(Me.DgvTemplates)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblScreenName)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FrmSelectTemplate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicSelectTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblScreenName As Label
    Friend WithEvents DgvTemplates As DataGridView
    Friend WithEvents tmplId As DataGridViewTextBoxColumn
    Friend WithEvents tmplName As DataGridViewTextBoxColumn
    Friend WithEvents PicClose As PictureBox
    Friend WithEvents PicSelectTemplate As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
