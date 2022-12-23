' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmImages
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImages))
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DgvImages = New System.Windows.Forms.DataGridView()
        Me.col1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col3 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col4 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PicClose = New System.Windows.Forms.PictureBox()
        Me.TxtImagePath = New System.Windows.Forms.TextBox()
        Me.TxtImageDesc = New System.Windows.Forms.TextBox()
        Me.PicRemove = New System.Windows.Forms.PictureBox()
        Me.PicAdd = New System.Windows.Forms.PictureBox()
        Me.PicUpdate = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnFindFile = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DgvImages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblScreenName
        '
        Me.lblScreenName.AutoSize = True
        Me.lblScreenName.Font = New System.Drawing.Font("Felix Titling", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenName.ForeColor = System.Drawing.Color.Black
        Me.lblScreenName.Location = New System.Drawing.Point(59, 9)
        Me.lblScreenName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(92, 25)
        Me.lblScreenName.TabIndex = 70
        Me.lblScreenName.Text = "Images"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(9, 9)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 84
        Me.PictureBox1.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 478)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(530, 22)
        Me.StatusStrip1.TabIndex = 85
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(10, 17)
        '
        'DgvImages
        '
        Me.DgvImages.AllowUserToAddRows = False
        Me.DgvImages.AllowUserToDeleteRows = False
        Me.DgvImages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvImages.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvImages.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvImages.ColumnHeadersVisible = False
        Me.DgvImages.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col1, Me.col2, Me.col3, Me.col4})
        Me.DgvImages.Location = New System.Drawing.Point(9, 72)
        Me.DgvImages.Name = "DgvImages"
        Me.DgvImages.ReadOnly = True
        Me.DgvImages.RowHeadersVisible = False
        Me.DgvImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgvImages.Size = New System.Drawing.Size(505, 258)
        Me.DgvImages.TabIndex = 86
        '
        'col1
        '
        Me.col1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col1.HeaderText = "Column1"
        Me.col1.Name = "col1"
        Me.col1.ReadOnly = True
        Me.col1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2
        '
        Me.col2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col2.HeaderText = "Column2"
        Me.col2.Name = "col2"
        Me.col2.ReadOnly = True
        Me.col2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col3
        '
        Me.col3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col3.HeaderText = "Column3"
        Me.col3.Name = "col3"
        Me.col3.ReadOnly = True
        '
        'col4
        '
        Me.col4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col4.HeaderText = "Column4"
        Me.col4.Name = "col4"
        Me.col4.ReadOnly = True
        '
        'PicClose
        '
        Me.PicClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicClose.Image = Global.MyBusiness.My.Resources.Resources.exitbutton
        Me.PicClose.InitialImage = Nothing
        Me.PicClose.Location = New System.Drawing.Point(476, 432)
        Me.PicClose.Name = "PicClose"
        Me.PicClose.Size = New System.Drawing.Size(42, 42)
        Me.PicClose.TabIndex = 93
        Me.PicClose.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicClose, "Close")
        '
        'TxtImagePath
        '
        Me.TxtImagePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtImagePath.Location = New System.Drawing.Point(91, 353)
        Me.TxtImagePath.Name = "TxtImagePath"
        Me.TxtImagePath.Size = New System.Drawing.Size(397, 24)
        Me.TxtImagePath.TabIndex = 94
        '
        'TxtImageDesc
        '
        Me.TxtImageDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtImageDesc.Location = New System.Drawing.Point(91, 383)
        Me.TxtImageDesc.Name = "TxtImageDesc"
        Me.TxtImageDesc.Size = New System.Drawing.Size(406, 24)
        Me.TxtImageDesc.TabIndex = 95
        '
        'PicRemove
        '
        Me.PicRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicRemove.Image = Global.MyBusiness.My.Resources.Resources.remove
        Me.PicRemove.InitialImage = Nothing
        Me.PicRemove.Location = New System.Drawing.Point(143, 433)
        Me.PicRemove.Name = "PicRemove"
        Me.PicRemove.Size = New System.Drawing.Size(42, 42)
        Me.PicRemove.TabIndex = 96
        Me.PicRemove.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicRemove, "Remove Image")
        '
        'PicAdd
        '
        Me.PicAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicAdd.Image = Global.MyBusiness.My.Resources.Resources.add
        Me.PicAdd.InitialImage = Nothing
        Me.PicAdd.Location = New System.Drawing.Point(12, 432)
        Me.PicAdd.Name = "PicAdd"
        Me.PicAdd.Size = New System.Drawing.Size(42, 42)
        Me.PicAdd.TabIndex = 97
        Me.PicAdd.TabStop = False
        '
        'PicUpdate
        '
        Me.PicUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicUpdate.Image = Global.MyBusiness.My.Resources.Resources.update
        Me.PicUpdate.InitialImage = Nothing
        Me.PicUpdate.Location = New System.Drawing.Point(76, 433)
        Me.PicUpdate.Name = "PicUpdate"
        Me.PicUpdate.Size = New System.Drawing.Size(42, 42)
        Me.PicUpdate.TabIndex = 98
        Me.PicUpdate.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicUpdate, "Update Image")
        '
        'BtnFindFile
        '
        Me.BtnFindFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFindFile.BackgroundImage = Global.MyBusiness.My.Resources.Resources.left24
        Me.BtnFindFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnFindFile.Location = New System.Drawing.Point(494, 353)
        Me.BtnFindFile.Name = "BtnFindFile"
        Me.BtnFindFile.Size = New System.Drawing.Size(24, 24)
        Me.BtnFindFile.TabIndex = 99
        Me.ToolTip1.SetToolTip(Me.BtnFindFile, "Select file")
        Me.BtnFindFile.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 357)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 17)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Path"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 386)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "Description"
        '
        'FrmImages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(530, 500)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnFindFile)
        Me.Controls.Add(Me.PicUpdate)
        Me.Controls.Add(Me.PicAdd)
        Me.Controls.Add(Me.PicRemove)
        Me.Controls.Add(Me.TxtImageDesc)
        Me.Controls.Add(Me.TxtImagePath)
        Me.Controls.Add(Me.PicClose)
        Me.Controls.Add(Me.DgvImages)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblScreenName)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(415, 438)
        Me.Name = "FrmImages"
        Me.ShowIcon = False
        Me.ToolTip1.SetToolTip(Me, "Add Image")
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DgvImages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblScreenName As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents DgvImages As DataGridView
    Friend WithEvents PicClose As PictureBox
    Friend WithEvents col1 As DataGridViewImageColumn
    Friend WithEvents col2 As DataGridViewImageColumn
    Friend WithEvents col3 As DataGridViewImageColumn
    Friend WithEvents col4 As DataGridViewImageColumn
    Friend WithEvents TxtImagePath As TextBox
    Friend WithEvents TxtImageDesc As TextBox
    Friend WithEvents PicRemove As PictureBox
    Friend WithEvents PicAdd As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PicUpdate As PictureBox
    Friend WithEvents BtnFindFile As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblStatus As ToolStripStatusLabel
End Class
