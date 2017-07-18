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
        Me.LblName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.LblName.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.ForeColor = System.Drawing.Color.Teal
        Me.LblName.Location = New System.Drawing.Point(178, 151)
        Me.LblName.Name = "LblName"
        Me.LblName.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.LblName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblName.Size = New System.Drawing.Size(223, 46)
        Me.LblName.TabIndex = 0
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmLogo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ExpTree_Demo.My.Resources.Resources.LogoFrm
        Me.ClientSize = New System.Drawing.Size(698, 213)
        Me.Controls.Add(Me.LblName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmLogo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmLogo"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LblName As Label
End Class
