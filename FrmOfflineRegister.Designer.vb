<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOfflineRegister
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOfflineRegister))
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.txtConfirmCode = New System.Windows.Forms.TextBox()
        Me.BtnActivate = New System.Windows.Forms.Button()
        Me.TxtSerial = New System.Windows.Forms.TextBox()
        Me.textPUID = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImage = Global.ExpTree_Demo.My.Resources.Resources.close_o
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox5.Location = New System.Drawing.Point(426, 3)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox5.TabIndex = 22
        Me.PictureBox5.TabStop = False
        '
        'txtConfirmCode
        '
        Me.txtConfirmCode.BackColor = System.Drawing.Color.White
        Me.txtConfirmCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtConfirmCode.Font = New System.Drawing.Font("IRANSans", 10.0!)
        Me.txtConfirmCode.ForeColor = System.Drawing.Color.DimGray
        Me.txtConfirmCode.Location = New System.Drawing.Point(91, 350)
        Me.txtConfirmCode.Multiline = True
        Me.txtConfirmCode.Name = "txtConfirmCode"
        Me.txtConfirmCode.Size = New System.Drawing.Size(266, 20)
        Me.txtConfirmCode.TabIndex = 1
        Me.txtConfirmCode.Text = "کد دریافتی"
        Me.txtConfirmCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnActivate
        '
        Me.BtnActivate.BackColor = System.Drawing.Color.Transparent
        Me.BtnActivate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnActivate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.BtnActivate.FlatAppearance.BorderSize = 0
        Me.BtnActivate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnActivate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnActivate.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.BtnActivate.ForeColor = System.Drawing.Color.White
        Me.BtnActivate.Location = New System.Drawing.Point(37, 426)
        Me.BtnActivate.Name = "BtnActivate"
        Me.BtnActivate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnActivate.Size = New System.Drawing.Size(375, 37)
        Me.BtnActivate.TabIndex = 0
        Me.BtnActivate.UseVisualStyleBackColor = False
        '
        'TxtSerial
        '
        Me.TxtSerial.BackColor = System.Drawing.Color.White
        Me.TxtSerial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSerial.Font = New System.Drawing.Font("IRANSans", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerial.ForeColor = System.Drawing.Color.DimGray
        Me.TxtSerial.Location = New System.Drawing.Point(92, 389)
        Me.TxtSerial.Multiline = True
        Me.TxtSerial.Name = "TxtSerial"
        Me.TxtSerial.Size = New System.Drawing.Size(266, 20)
        Me.TxtSerial.TabIndex = 2
        Me.TxtSerial.Text = "سریال فعال سازی"
        Me.TxtSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'textPUID
        '
        Me.textPUID.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.textPUID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textPUID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textPUID.ForeColor = System.Drawing.Color.Yellow
        Me.textPUID.Location = New System.Drawing.Point(27, 275)
        Me.textPUID.Name = "textPUID"
        Me.textPUID.ReadOnly = True
        Me.textPUID.Size = New System.Drawing.Size(396, 22)
        Me.textPUID.TabIndex = 43
        Me.textPUID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmOfflineRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ExpTree_Demo.My.Resources.Resources.offline1
        Me.ClientSize = New System.Drawing.Size(450, 480)
        Me.Controls.Add(Me.textPUID)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.TxtSerial)
        Me.Controls.Add(Me.BtnActivate)
        Me.Controls.Add(Me.txtConfirmCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOfflineRegister"
        Me.Opacity = 0R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DlgOfflineRegister"
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents txtConfirmCode As TextBox
    Friend WithEvents BtnActivate As Button
    Friend WithEvents TxtSerial As TextBox
    Friend WithEvents textPUID As TextBox
End Class
