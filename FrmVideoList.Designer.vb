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
        Me.open_explorer = New System.Windows.Forms.Button()
        Me.help_btn = New System.Windows.Forms.Button()
        Me.help1_btn = New System.Windows.Forms.Button()
        Me.other_btn = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.ImageListView1 = New Manina.Windows.Forms.ImageListView()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.open_explorer, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.help1_btn, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.help_btn, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.other_btn, 3, 0)
        Me.TableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(1, 519)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1022, 56)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'open_explorer
        '
        Me.open_explorer.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.open_explorer.BackColor = System.Drawing.Color.Transparent
        Me.open_explorer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.open_explorer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.open_explorer.FlatAppearance.BorderSize = 0
        Me.open_explorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.open_explorer.Font = New System.Drawing.Font("IRANSans", 10.0!)
        Me.open_explorer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.open_explorer.Image = Global.ExpTree_Demo.My.Resources.Resources.folder_open
        Me.open_explorer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.open_explorer.Location = New System.Drawing.Point(17, 10)
        Me.open_explorer.Margin = New System.Windows.Forms.Padding(17, 3, 3, 3)
        Me.open_explorer.Name = "open_explorer"
        Me.open_explorer.Size = New System.Drawing.Size(160, 35)
        Me.open_explorer.TabIndex = 33
        Me.open_explorer.Text = "سایر محتویات پکیج"
        Me.open_explorer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.open_explorer.UseMnemonic = False
        Me.open_explorer.UseVisualStyleBackColor = False
        Me.open_explorer.UseCompatibleTextRendering = True
        '
        'help_btn
        '
        Me.help_btn.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.help_btn.BackColor = System.Drawing.Color.Transparent
        Me.help_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.help_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.help_btn.FlatAppearance.BorderSize = 0
        Me.help_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.help_btn.Font = New System.Drawing.Font("IRANSans", 10.0!)
        Me.help_btn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.help_btn.Image = Global.ExpTree_Demo.My.Resources.Resources.help_circle_outline
        Me.help_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.help_btn.Location = New System.Drawing.Point(747, 10)
        Me.help_btn.Margin = New System.Windows.Forms.Padding(3, 3, 14, 3)
        Me.help_btn.Name = "help_btn"
        Me.help_btn.Size = New System.Drawing.Size(115, 35)
        Me.help_btn.TabIndex = 34
        Me.help_btn.Text = "راهنمای پکیج"
        Me.help_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.help_btn.UseMnemonic = False
        Me.help_btn.UseVisualStyleBackColor = False
        Me.help_btn.UseCompatibleTextRendering = True
        '
        'help1_btn
        '
        Me.help1_btn.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.help1_btn.BackColor = System.Drawing.Color.Transparent
        Me.help1_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.help1_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.help1_btn.FlatAppearance.BorderSize = 0
        Me.help1_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.help1_btn.Font = New System.Drawing.Font("IRANSans", 10.0!)
        Me.help1_btn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.help1_btn.Image = Global.ExpTree_Demo.My.Resources.Resources.help_circle_outline
        Me.help1_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.help1_btn.Location = New System.Drawing.Point(615, 10)
        Me.help1_btn.Margin = New System.Windows.Forms.Padding(3, 3, 14, 3)
        Me.help1_btn.Name = "help1_btn"
        Me.help1_btn.Size = New System.Drawing.Size(115, 35)
        Me.help1_btn.TabIndex = 34
        Me.help1_btn.Text = "راهنمای برنامه"
        Me.help1_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.help1_btn.UseMnemonic = False
        Me.help1_btn.UseVisualStyleBackColor = False
        Me.help1_btn.UseCompatibleTextRendering = True
        '
        'other_btn
        '
        Me.other_btn.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.other_btn.BackColor = System.Drawing.Color.Transparent
        Me.other_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.other_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.other_btn.FlatAppearance.BorderSize = 0
        Me.other_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.other_btn.Font = New System.Drawing.Font("IRANSans", 10.0!)
        Me.other_btn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.other_btn.Image = Global.ExpTree_Demo.My.Resources.Resources.webpack
        Me.other_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.other_btn.Location = New System.Drawing.Point(879, 10)
        Me.other_btn.Margin = New System.Windows.Forms.Padding(3, 3, 17, 3)
        Me.other_btn.Name = "other_btn"
        Me.other_btn.Size = New System.Drawing.Size(126, 35)
        Me.other_btn.TabIndex = 35
        Me.other_btn.Text = "سایر محصولات"
        Me.other_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.other_btn.UseMnemonic = False
        Me.other_btn.UseVisualStyleBackColor = False
        Me.other_btn.UseCompatibleTextRendering = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTitle.Font = New System.Drawing.Font("IRANSans Medium", 14.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(120, 17)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(233, 33)
        Me.lblTitle.TabIndex = 24
        Me.lblTitle.Text = "موسسه مهندسی آموزشی ۸۰۸"
        Me.lblTitle.UseCompatibleTextRendering = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.ExpTree_Demo.My.Resources.Resources.negative
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Location = New System.Drawing.Point(955, 21)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 22)
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox2.Image = Global.ExpTree_Demo.My.Resources.Resources.logo_w
        Me.PictureBox2.Location = New System.Drawing.Point(17, 17)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(85, 30)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImage = Global.ExpTree_Demo.My.Resources.Resources.close
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox5.Location = New System.Drawing.Point(985, 21)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(10)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(22, 22)
        Me.PictureBox5.TabIndex = 22
        Me.PictureBox5.TabStop = False
        '
        'ImageListView1
        '
        Me.ImageListView1.BackColor = System.Drawing.Color.White
        Me.ImageListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImageListView1.CacheLimit = "40MB"
        Me.ImageListView1.DefaultImage = Global.ExpTree_Demo.My.Resources.Resources.def
        Me.ImageListView1.ErrorImage = CType(resources.GetObject("ImageListView1.ErrorImage"), System.Drawing.Image)
        Me.ImageListView1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ImageListView1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.ImageListView1.Location = New System.Drawing.Point(0, 64)
        Me.ImageListView1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.ImageListView1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 56)
        Me.ImageListView1.Name = "ImageListView1"
        Me.ImageListView1.Size = New System.Drawing.Size(1024, 512)
        Me.ImageListView1.TabIndex = 0
        Me.ImageListView1.Text = ""
        Me.ImageListView1.ThumbnailSize = New System.Drawing.Size(250, 250)
        '
        'FrmVideoList
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1024, 576)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.ImageListView1)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmVideoList"
        Me.Opacity = 0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents lblTitle As Label
    Private WithEvents ImageListView1 As ImageListView
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents open_explorer As Button
    Friend WithEvents help_btn As Button
    Friend WithEvents help1_btn As Button
    Friend WithEvents other_btn As Button
End Class
