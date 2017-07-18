Imports ExpTree_Demo
Imports Manina.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmVideoList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVideoList))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblShowExplorer = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ImageListView1 = New Manina.Windows.Forms.ImageListView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblOtherProducts = New System.Windows.Forms.Label()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblShowExplorer, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 579)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1281, 93)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblShowExplorer
        '
        Me.lblShowExplorer.AutoSize = True
        Me.lblShowExplorer.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblShowExplorer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblShowExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblShowExplorer.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.lblShowExplorer.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.lblShowExplorer.Location = New System.Drawing.Point(0, 0)
        Me.lblShowExplorer.Margin = New System.Windows.Forms.Padding(0)
        Me.lblShowExplorer.Name = "lblShowExplorer"
        Me.lblShowExplorer.Size = New System.Drawing.Size(1281, 58)
        Me.lblShowExplorer.TabIndex = 0
        Me.lblShowExplorer.Text = "سایر محتویات پکیج"
        Me.lblShowExplorer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox5, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(1186, 12)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(79, 36)
        Me.TableLayoutPanel2.TabIndex = 26
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.ExpTree_Demo.My.Resources.Resources.minimize_white2
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(10, 10)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 16)
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImage = Global.ExpTree_Demo.My.Resources.Resources._exit
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox5.Location = New System.Drawing.Point(49, 10)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(10)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(20, 16)
        Me.PictureBox5.TabIndex = 22
        Me.PictureBox5.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblTitle.Location = New System.Drawing.Point(469, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(229, 19)
        Me.lblTitle.TabIndex = 24
        Me.lblTitle.Text = "موسسه مهندسی آموزشی ۸۰۸"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox2.Image = Global.ExpTree_Demo.My.Resources.Resources.Logo_02
        Me.PictureBox2.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(102, 46)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        '
        'ImageListView1
        '
        Me.ImageListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.ImageListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImageListView1.CacheLimit = "40MB"
        Me.ImageListView1.DefaultImage = CType(resources.GetObject("ImageListView1.DefaultImage"), System.Drawing.Image)
        Me.ImageListView1.ErrorImage = CType(resources.GetObject("ImageListView1.ErrorImage"), System.Drawing.Image)
        Me.ImageListView1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.ImageListView1.Location = New System.Drawing.Point(0, 57)
        Me.ImageListView1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.ImageListView1.Name = "ImageListView1"
        Me.ImageListView1.Size = New System.Drawing.Size(1281, 529)
        Me.ImageListView1.TabIndex = 28
        Me.ImageListView1.Text = ""
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.lblHelp, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblOtherProducts, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 58)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1281, 35)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'lblOtherProducts
        '
        Me.lblOtherProducts.AutoSize = True
        Me.lblOtherProducts.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblOtherProducts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblOtherProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOtherProducts.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.lblOtherProducts.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.lblOtherProducts.Location = New System.Drawing.Point(0, 0)
        Me.lblOtherProducts.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOtherProducts.Name = "lblOtherProducts"
        Me.lblOtherProducts.Size = New System.Drawing.Size(640, 35)
        Me.lblOtherProducts.TabIndex = 1
        Me.lblOtherProducts.Text = "سایر محصولات"
        Me.lblOtherProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHelp.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.lblHelp.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.lblHelp.Location = New System.Drawing.Point(640, 0)
        Me.lblHelp.Margin = New System.Windows.Forms.Padding(0)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(641, 35)
        Me.lblHelp.TabIndex = 2
        Me.lblHelp.Text = "راهنمای پکیج"
        Me.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmVideoList
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1281, 672)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.ImageListView1)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmVideoList"
        Me.Opacity = 0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents lblTitle As Label
    Private WithEvents ImageListView1 As ImageListView
    Friend WithEvents lblShowExplorer As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents lblHelp As Label
    Friend WithEvents lblOtherProducts As Label
End Class
