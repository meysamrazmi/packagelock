Public Class FrmLogo
    Private Sub FrmLogo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblName.Font = CustomFont.GetInstance(14, FontStyle.Regular)
        Dim name As String = get_setting("user_name", "")
        Dim serial As String = get_setting("serial", "")
        Dim package As String = get_setting("package", "")
        If Name <> "" Then
            LblName.Text = Name
        Else
            set_setting("version", "")
        End If
        If serial <> "" Then
            LblSerial.Text = serial
        End If
        If package <> "" Then
            LblPackage.Text = package
        End If
    End Sub
End Class