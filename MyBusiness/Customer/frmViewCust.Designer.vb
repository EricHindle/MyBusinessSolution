﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmViewCust
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmViewCust))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.rtbCustNotes = New System.Windows.Forms.Label()
        Me.txtCustEmail = New System.Windows.Forms.Label()
        Me.txtCustPhone = New System.Windows.Forms.Label()
        Me.txtCustPostcode = New System.Windows.Forms.Label()
        Me.txtCustAddr4 = New System.Windows.Forms.Label()
        Me.txtCustAddr3 = New System.Windows.Forms.Label()
        Me.txtCustAddr2 = New System.Windows.Forms.Label()
        Me.txtCustAddr1 = New System.Windows.Forms.Label()
        Me.txtCustName = New System.Windows.Forms.Label()
        Me.PicClose = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCustNo = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.MyBusiness.My.Resources.Resources.MyBusinessLogo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 69
        Me.PictureBox1.TabStop = False
        '
        'lblScreenName
        '
        Me.lblScreenName.AutoSize = True
        Me.lblScreenName.Font = New System.Drawing.Font("Felix Titling", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenName.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblScreenName.Location = New System.Drawing.Point(50, 12)
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(100, 19)
        Me.lblScreenName.TabIndex = 10
        Me.lblScreenName.Text = "Customer"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtbCustNotes
        '
        Me.rtbCustNotes.BackColor = System.Drawing.Color.LightGray
        Me.rtbCustNotes.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbCustNotes.Location = New System.Drawing.Point(11, 303)
        Me.rtbCustNotes.Name = "rtbCustNotes"
        Me.rtbCustNotes.Size = New System.Drawing.Size(206, 86)
        Me.rtbCustNotes.TabIndex = 8
        '
        'txtCustEmail
        '
        Me.txtCustEmail.AutoEllipsis = True
        Me.txtCustEmail.BackColor = System.Drawing.Color.LightGray
        Me.txtCustEmail.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustEmail.Location = New System.Drawing.Point(11, 277)
        Me.txtCustEmail.Name = "txtCustEmail"
        Me.txtCustEmail.Padding = New System.Windows.Forms.Padding(2)
        Me.txtCustEmail.Size = New System.Drawing.Size(206, 17)
        Me.txtCustEmail.TabIndex = 7
        '
        'txtCustPhone
        '
        Me.txtCustPhone.AutoEllipsis = True
        Me.txtCustPhone.BackColor = System.Drawing.Color.LightGray
        Me.txtCustPhone.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustPhone.Location = New System.Drawing.Point(11, 251)
        Me.txtCustPhone.Name = "txtCustPhone"
        Me.txtCustPhone.Padding = New System.Windows.Forms.Padding(2)
        Me.txtCustPhone.Size = New System.Drawing.Size(206, 17)
        Me.txtCustPhone.TabIndex = 6
        '
        'txtCustPostcode
        '
        Me.txtCustPostcode.AutoEllipsis = True
        Me.txtCustPostcode.BackColor = System.Drawing.Color.LightGray
        Me.txtCustPostcode.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustPostcode.Location = New System.Drawing.Point(11, 214)
        Me.txtCustPostcode.Name = "txtCustPostcode"
        Me.txtCustPostcode.Padding = New System.Windows.Forms.Padding(2)
        Me.txtCustPostcode.Size = New System.Drawing.Size(116, 18)
        Me.txtCustPostcode.TabIndex = 5
        '
        'txtCustAddr4
        '
        Me.txtCustAddr4.AutoEllipsis = True
        Me.txtCustAddr4.BackColor = System.Drawing.Color.LightGray
        Me.txtCustAddr4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustAddr4.Location = New System.Drawing.Point(11, 188)
        Me.txtCustAddr4.Name = "txtCustAddr4"
        Me.txtCustAddr4.Padding = New System.Windows.Forms.Padding(2)
        Me.txtCustAddr4.Size = New System.Drawing.Size(206, 17)
        Me.txtCustAddr4.TabIndex = 4
        '
        'txtCustAddr3
        '
        Me.txtCustAddr3.AutoEllipsis = True
        Me.txtCustAddr3.BackColor = System.Drawing.Color.LightGray
        Me.txtCustAddr3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustAddr3.Location = New System.Drawing.Point(11, 162)
        Me.txtCustAddr3.Name = "txtCustAddr3"
        Me.txtCustAddr3.Padding = New System.Windows.Forms.Padding(2)
        Me.txtCustAddr3.Size = New System.Drawing.Size(206, 17)
        Me.txtCustAddr3.TabIndex = 3
        '
        'txtCustAddr2
        '
        Me.txtCustAddr2.AutoEllipsis = True
        Me.txtCustAddr2.BackColor = System.Drawing.Color.LightGray
        Me.txtCustAddr2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustAddr2.Location = New System.Drawing.Point(11, 136)
        Me.txtCustAddr2.Name = "txtCustAddr2"
        Me.txtCustAddr2.Padding = New System.Windows.Forms.Padding(2)
        Me.txtCustAddr2.Size = New System.Drawing.Size(206, 17)
        Me.txtCustAddr2.TabIndex = 2
        '
        'txtCustAddr1
        '
        Me.txtCustAddr1.AutoEllipsis = True
        Me.txtCustAddr1.BackColor = System.Drawing.Color.LightGray
        Me.txtCustAddr1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustAddr1.Location = New System.Drawing.Point(11, 110)
        Me.txtCustAddr1.Name = "txtCustAddr1"
        Me.txtCustAddr1.Padding = New System.Windows.Forms.Padding(2)
        Me.txtCustAddr1.Size = New System.Drawing.Size(206, 17)
        Me.txtCustAddr1.TabIndex = 1
        '
        'txtCustName
        '
        Me.txtCustName.BackColor = System.Drawing.Color.LightGray
        Me.txtCustName.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustName.Location = New System.Drawing.Point(11, 80)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Padding = New System.Windows.Forms.Padding(2)
        Me.txtCustName.Size = New System.Drawing.Size(206, 22)
        Me.txtCustName.TabIndex = 0
        '
        'PicClose
        '
        Me.PicClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicClose.Image = Global.MyBusiness.My.Resources.Resources.exitbutton
        Me.PicClose.InitialImage = Nothing
        Me.PicClose.Location = New System.Drawing.Point(181, 402)
        Me.PicClose.Name = "PicClose"
        Me.PicClose.Size = New System.Drawing.Size(36, 33)
        Me.PicClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicClose.TabIndex = 96
        Me.PicClose.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicClose, "Close")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Customer no.:"
        '
        'txtCustNo
        '
        Me.txtCustNo.AutoEllipsis = True
        Me.txtCustNo.BackColor = System.Drawing.Color.LightGray
        Me.txtCustNo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustNo.Location = New System.Drawing.Point(94, 58)
        Me.txtCustNo.Name = "txtCustNo"
        Me.txtCustNo.Padding = New System.Windows.Forms.Padding(2)
        Me.txtCustNo.Size = New System.Drawing.Size(40, 18)
        Me.txtCustNo.TabIndex = 98
        '
        'FrmViewCust
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(229, 440)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtCustNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PicClose)
        Me.Controls.Add(Me.rtbCustNotes)
        Me.Controls.Add(Me.txtCustEmail)
        Me.Controls.Add(Me.txtCustPhone)
        Me.Controls.Add(Me.txtCustPostcode)
        Me.Controls.Add(Me.txtCustAddr4)
        Me.Controls.Add(Me.txtCustAddr3)
        Me.Controls.Add(Me.txtCustAddr2)
        Me.Controls.Add(Me.txtCustAddr1)
        Me.Controls.Add(Me.txtCustName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblScreenName)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmViewCust"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblScreenName As System.Windows.Forms.Label
    Friend WithEvents rtbCustNotes As System.Windows.Forms.Label
    Friend WithEvents txtCustEmail As System.Windows.Forms.Label
    Friend WithEvents txtCustPhone As System.Windows.Forms.Label
    Friend WithEvents txtCustPostcode As System.Windows.Forms.Label
    Friend WithEvents txtCustAddr4 As System.Windows.Forms.Label
    Friend WithEvents txtCustAddr3 As System.Windows.Forms.Label
    Friend WithEvents txtCustAddr2 As System.Windows.Forms.Label
    Friend WithEvents txtCustAddr1 As System.Windows.Forms.Label
    Friend WithEvents txtCustName As System.Windows.Forms.Label
    Friend WithEvents PicClose As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCustNo As Label
End Class
