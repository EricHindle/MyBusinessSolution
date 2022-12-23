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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImages))
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.DgvImages = New System.Windows.Forms.DataGridView()
        Me.col1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col3 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col4 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PicClose = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvImages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(131, 514)
        Me.btnRemove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(93, 38)
        Me.btnRemove.TabIndex = 83
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(13, 514)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(93, 38)
        Me.btnAdd.TabIndex = 81
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
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
        Me.StatusStrip1.BackgroundImage = Global.MyBusiness.My.Resources.Resources.statusstrip
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 556)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(887, 22)
        Me.StatusStrip1.TabIndex = 85
        Me.StatusStrip1.Text = "StatusStrip1"
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
        Me.DgvImages.Location = New System.Drawing.Point(12, 60)
        Me.DgvImages.Name = "DgvImages"
        Me.DgvImages.ReadOnly = True
        Me.DgvImages.RowHeadersVisible = False
        Me.DgvImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgvImages.Size = New System.Drawing.Size(862, 361)
        Me.DgvImages.TabIndex = 86
        '
        'col1
        '
        Me.col1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.col1.HeaderText = "Column1"
        Me.col1.Name = "col1"
        Me.col1.ReadOnly = True
        Me.col1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2
        '
        Me.col2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.col2.HeaderText = "Column2"
        Me.col2.Name = "col2"
        Me.col2.ReadOnly = True
        Me.col2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col3
        '
        Me.col3.HeaderText = "Column3"
        Me.col3.Name = "col3"
        Me.col3.ReadOnly = True
        '
        'col4
        '
        Me.col4.HeaderText = "Column4"
        Me.col4.Name = "col4"
        Me.col4.ReadOnly = True
        '
        'PicClose
        '
        Me.PicClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicClose.Image = Global.MyBusiness.My.Resources.Resources.exitbutton
        Me.PicClose.InitialImage = Nothing
        Me.PicClose.Location = New System.Drawing.Point(833, 510)
        Me.PicClose.Name = "PicClose"
        Me.PicClose.Size = New System.Drawing.Size(42, 42)
        Me.PicClose.TabIndex = 93
        Me.PicClose.TabStop = False
        '
        'FrmImages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(887, 578)
        Me.Controls.Add(Me.PicClose)
        Me.Controls.Add(Me.DgvImages)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblScreenName)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmImages"
        Me.ShowIcon = False
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvImages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblScreenName As Label
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents DgvImages As DataGridView
    Friend WithEvents col1 As DataGridViewImageColumn
    Friend WithEvents col2 As DataGridViewImageColumn
    Friend WithEvents col3 As DataGridViewImageColumn
    Friend WithEvents col4 As DataGridViewImageColumn
    Friend WithEvents PicClose As PictureBox
End Class
