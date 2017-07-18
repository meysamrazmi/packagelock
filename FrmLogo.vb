Public Class FrmLogo
    Private Sub FrmLogo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As String = get_setting("user_name", "")
        If x <> "" Then
            LblName.Text = x
        Else
            set_setting("version", "")
        End If
    End Sub
End Class