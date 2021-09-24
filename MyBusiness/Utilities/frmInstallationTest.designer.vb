<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInstallationTest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInstallationTest))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblFormName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnSMTP = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFrom = New System.Windows.Forms.TextBox()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSMTPResult = New System.Windows.Forms.Label()
        Me.rtbLog = New System.Windows.Forms.RichTextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ehImageHost = New System.Windows.Forms.Integration.ElementHost()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnPdf = New System.Windows.Forms.Button()
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblExcelResult = New System.Windows.Forms.Label()
        Me.lblPdfResult = New System.Windows.Forms.Label()
        Me.lblPrintResult = New System.Windows.Forms.Label()
        Me.btnShowLog = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(896, 736)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 34)
        Me.btnClose.TabIndex = 14
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
        Me.lblFormName.TabIndex = 22
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
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'btnSMTP
        '
        Me.btnSMTP.ForeColor = System.Drawing.Color.Black
        Me.btnSMTP.Location = New System.Drawing.Point(43, 71)
        Me.btnSMTP.Name = "btnSMTP"
        Me.btnSMTP.Size = New System.Drawing.Size(164, 23)
        Me.btnSMTP.TabIndex = 8
        Me.btnSMTP.Text = "Send SMTP Email"
        Me.btnSMTP.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(242, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "From"
        '
        'txtFrom
        '
        Me.txtFrom.ForeColor = System.Drawing.Color.Black
        Me.txtFrom.Location = New System.Drawing.Point(286, 71)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(276, 23)
        Me.txtFrom.TabIndex = 0
        '
        'txtTo
        '
        Me.txtTo.ForeColor = System.Drawing.Color.Black
        Me.txtTo.Location = New System.Drawing.Point(286, 106)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(276, 23)
        Me.txtTo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(257, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "To"
        '
        'lblSMTPResult
        '
        Me.lblSMTPResult.BackColor = System.Drawing.Color.Gainsboro
        Me.lblSMTPResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSMTPResult.ForeColor = System.Drawing.Color.Black
        Me.lblSMTPResult.Location = New System.Drawing.Point(580, 71)
        Me.lblSMTPResult.Name = "lblSMTPResult"
        Me.lblSMTPResult.Size = New System.Drawing.Size(222, 23)
        Me.lblSMTPResult.TabIndex = 15
        Me.lblSMTPResult.Text = "SMTP Mail result"
        Me.lblSMTPResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rtbLog
        '
        Me.rtbLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rtbLog.BackColor = System.Drawing.Color.Black
        Me.rtbLog.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbLog.ForeColor = System.Drawing.Color.White
        Me.rtbLog.Location = New System.Drawing.Point(33, 550)
        Me.rtbLog.Margin = New System.Windows.Forms.Padding(2)
        Me.rtbLog.Name = "rtbLog"
        Me.rtbLog.Size = New System.Drawing.Size(381, 169)
        Me.rtbLog.TabIndex = 25
        Me.rtbLog.Text = ""
        Me.rtbLog.WordWrap = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.ForeColor = System.Drawing.Color.Black
        Me.SplitContainer1.Location = New System.Drawing.Point(419, 302)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ehImageHost)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.WebBrowser1)
        Me.SplitContainer1.Size = New System.Drawing.Size(542, 417)
        Me.SplitContainer1.SplitterDistance = 249
        Me.SplitContainer1.TabIndex = 22
        '
        'ehImageHost
        '
        Me.ehImageHost.BackColor = System.Drawing.Color.Gainsboro
        Me.ehImageHost.Location = New System.Drawing.Point(3, 3)
        Me.ehImageHost.Name = "ehImageHost"
        Me.ehImageHost.Size = New System.Drawing.Size(239, 407)
        Me.ehImageHost.TabIndex = 0
        Me.ehImageHost.Text = "ElementHost1"
        Me.ehImageHost.Child = Nothing
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(285, 413)
        Me.WebBrowser1.TabIndex = 0
        '
        'TreeView1
        '
        Me.TreeView1.ForeColor = System.Drawing.Color.Black
        Me.TreeView1.Location = New System.Drawing.Point(194, 302)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(219, 243)
        Me.TreeView1.TabIndex = 23
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.DataGridView1.Location = New System.Drawing.Point(258, 153)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(304, 101)
        Me.DataGridView1.TabIndex = 5
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 80
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 80
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column3.HeaderText = "Column3"
        Me.Column3.Name = "Column3"
        '
        'btnExcel
        '
        Me.btnExcel.ForeColor = System.Drawing.Color.Black
        Me.btnExcel.Location = New System.Drawing.Point(43, 153)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(164, 23)
        Me.btnExcel.TabIndex = 11
        Me.btnExcel.Text = "Export Data To Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.ForeColor = System.Drawing.Color.Black
        Me.btnPrint.Location = New System.Drawing.Point(43, 241)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(164, 23)
        Me.btnPrint.TabIndex = 13
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnPdf
        '
        Me.btnPdf.ForeColor = System.Drawing.Color.Black
        Me.btnPdf.Location = New System.Drawing.Point(43, 197)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(164, 23)
        Me.btnPdf.TabIndex = 12
        Me.btnPdf.Text = "Export To pdf"
        Me.btnPdf.UseVisualStyleBackColor = True
        '
        'txtFilename
        '
        Me.txtFilename.ForeColor = System.Drawing.Color.Black
        Me.txtFilename.Location = New System.Drawing.Point(286, 260)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(276, 23)
        Me.txtFilename.TabIndex = 6
        Me.txtFilename.Text = "InstallationTest"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(220, 263)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 16)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Filename"
        '
        'lblExcelResult
        '
        Me.lblExcelResult.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExcelResult.AutoEllipsis = True
        Me.lblExcelResult.BackColor = System.Drawing.Color.Gainsboro
        Me.lblExcelResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblExcelResult.ForeColor = System.Drawing.Color.Black
        Me.lblExcelResult.Location = New System.Drawing.Point(580, 153)
        Me.lblExcelResult.Name = "lblExcelResult"
        Me.lblExcelResult.Size = New System.Drawing.Size(370, 23)
        Me.lblExcelResult.TabIndex = 19
        Me.lblExcelResult.Text = "Excel result"
        Me.lblExcelResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPdfResult
        '
        Me.lblPdfResult.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPdfResult.AutoEllipsis = True
        Me.lblPdfResult.BackColor = System.Drawing.Color.Gainsboro
        Me.lblPdfResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPdfResult.ForeColor = System.Drawing.Color.Black
        Me.lblPdfResult.Location = New System.Drawing.Point(580, 197)
        Me.lblPdfResult.Name = "lblPdfResult"
        Me.lblPdfResult.Size = New System.Drawing.Size(370, 23)
        Me.lblPdfResult.TabIndex = 20
        Me.lblPdfResult.Text = "pdf result"
        Me.lblPdfResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPrintResult
        '
        Me.lblPrintResult.BackColor = System.Drawing.Color.Gainsboro
        Me.lblPrintResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrintResult.ForeColor = System.Drawing.Color.Black
        Me.lblPrintResult.Location = New System.Drawing.Point(580, 241)
        Me.lblPrintResult.Name = "lblPrintResult"
        Me.lblPrintResult.Size = New System.Drawing.Size(222, 23)
        Me.lblPrintResult.TabIndex = 21
        Me.lblPrintResult.Text = "Print result"
        Me.lblPrintResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnShowLog
        '
        Me.btnShowLog.ForeColor = System.Drawing.Color.Black
        Me.btnShowLog.Location = New System.Drawing.Point(43, 307)
        Me.btnShowLog.Name = "btnShowLog"
        Me.btnShowLog.Size = New System.Drawing.Size(109, 23)
        Me.btnShowLog.TabIndex = 24
        Me.btnShowLog.Text = "Show Log"
        Me.btnShowLog.UseVisualStyleBackColor = True
        '
        'FrmInstallationTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(983, 782)
        Me.Controls.Add(Me.btnShowLog)
        Me.Controls.Add(Me.lblPrintResult)
        Me.Controls.Add(Me.lblPdfResult)
        Me.Controls.Add(Me.lblExcelResult)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.btnPdf)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.rtbLog)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.lblSMTPResult)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFrom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSMTP)
        Me.Controls.Add(Me.lblFormName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmInstallationTest"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblFormName As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSMTP As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSMTPResult As System.Windows.Forms.Label
    Friend WithEvents rtbLog As System.Windows.Forms.RichTextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    '    Friend WithEvents ehImageHost As System.Windows.Forms.Integration.ElementHost
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnPdf As System.Windows.Forms.Button
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblExcelResult As System.Windows.Forms.Label
    Friend WithEvents lblPdfResult As System.Windows.Forms.Label
    Friend WithEvents lblPrintResult As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnShowLog As System.Windows.Forms.Button
    Friend WithEvents ehImageHost As Integration.ElementHost
End Class
