<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogo))
        Me.LblName = New System.Windows.Forms.Label()
        Me.LblSerial = New System.Windows.Forms.Label()
        Me.LblPackage = New System.Windows.Forms.Label()
        Me.lblversion = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.ForeColor = System.Drawing.Color.Indigo
        Me.LblName.Location = New System.Drawing.Point(29, 185)
        Me.LblName.Name = "LblName"
        Me.LblName.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.LblName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblName.Size = New System.Drawing.Size(211, 32)
        Me.LblName.TabIndex = 0
        Me.LblName.UseCompatibleTextRendering = True
        '
        'LblSerial
        '
        Me.LblSerial.BackColor = System.Drawing.Color.Transparent
        Me.LblSerial.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSerial.ForeColor = System.Drawing.Color.Indigo
        Me.LblSerial.Location = New System.Drawing.Point(29, 227)
        Me.LblSerial.Name = "LblSerial"
        Me.LblSerial.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.LblSerial.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblSerial.Size = New System.Drawing.Size(211, 34)
        Me.LblSerial.TabIndex = 2
        Me.LblSerial.UseCompatibleTextRendering = True
        '
        'LblPackage
        '
        Me.LblPackage.BackColor = System.Drawing.Color.Transparent
        Me.LblPackage.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPackage.ForeColor = System.Drawing.Color.Indigo
        Me.LblPackage.Location = New System.Drawing.Point(29, 263)
        Me.LblPackage.Name = "LblPackage"
        Me.LblPackage.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.LblPackage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblPackage.Size = New System.Drawing.Size(212, 34)
        Me.LblPackage.TabIndex = 3
        '
        'lblversion
        '
        Me.lblversion.AutoSize = True
        Me.lblversion.BackColor = System.Drawing.Color.Transparent
        Me.lblversion.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblversion.Location = New System.Drawing.Point(47, 304)
        Me.lblversion.Name = "lblversion"
        Me.lblversion.Size = New System.Drawing.Size(23, 13)
        Me.lblversion.TabIndex = 37
        Me.lblversion.Text = "2.3"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label11.Location = New System.Drawing.Point(4, 304)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "version"
        '
        'FrmLogo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ExpTree_Demo.My.Resources.Resources.LogoFrm
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(504, 323)
        Me.Controls.Add(Me.lblversion)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LblPackage)
        Me.Controls.Add(Me.LblSerial)
        Me.Controls.Add(Me.LblName)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLogo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmLogo"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblName As Label
    Friend WithEvents LblSerial As Label
    Friend WithEvents LblPackage As Label
    Friend WithEvents lblversion As Label
    Friend WithEvents Label11 As Label
End Class
