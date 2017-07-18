<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLock))
        Me.TxtPass = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtPass
        '
        Me.TxtPass.BackColor = System.Drawing.Color.White
        Me.TxtPass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtPass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtPass.Location = New System.Drawing.Point(353, 388)
        Me.TxtPass.Name = "TxtPass"
        Me.TxtPass.Size = New System.Drawing.Size(166, 20)
        Me.TxtPass.TabIndex = 17
        Me.TxtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Location = New System.Drawing.Point(450, 441)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 62)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Location = New System.Drawing.Point(622, 326)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(144, 33)
        Me.PictureBox2.TabIndex = 12
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Location = New System.Drawing.Point(107, 326)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(136, 33)
        Me.PictureBox3.TabIndex = 13
        Me.PictureBox3.TabStop = False
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtName.Location = New System.Drawing.Point(326, 282)
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtName.Size = New System.Drawing.Size(139, 14)
        Me.txtName.TabIndex = 14
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEmail.Location = New System.Drawing.Point(326, 330)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(139, 13)
        Me.txtEmail.TabIndex = 16
        '
        'txtPhone
        '
        Me.txtPhone.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPhone.Location = New System.Drawing.Point(326, 306)
        Me.txtPhone.MaxLength = 11
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(139, 13)
        Me.txtPhone.TabIndex = 15
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(259, 422)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(351, 16)
        Me.lblStatus.TabIndex = 20
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox4.Location = New System.Drawing.Point(356, 441)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(64, 62)
        Me.PictureBox4.TabIndex = 21
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImage = Global.ExpTree_Demo.My.Resources.Resources._exit
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox5.Location = New System.Drawing.Point(42, 3)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(25, 19)
        Me.PictureBox5.TabIndex = 22
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.BackgroundImage = Global.ExpTree_Demo.My.Resources.Resources.minimize
        Me.PictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox6.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(25, 19)
        Me.PictureBox6.TabIndex = 23
        Me.PictureBox6.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox6, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox5, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(781, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(78, 36)
        Me.TableLayoutPanel1.TabIndex = 24
        '
        'FrmLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ExpTree_Demo.My.Resources.Resources.ghofl_copy
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(871, 563)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TxtPass)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLock"
        Me.Opacity = 0R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "قفل امنیتی سازه 808"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtPass As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
