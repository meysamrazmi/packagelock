Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.ComponentModel
Imports System.Drawing.Text

Public Class FrmLock
    'for moving the form lock windows form
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub Frm_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Frm_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Frm_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub

    Private Sub FrmLock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtName.Font = CustomFont.GetInstance(8.25, FontStyle.Regular)
        lblStatus.Font = CustomFont.GetInstance(10, FontStyle.Regular)

        FrmsOpenCount += 1

        'debug
        ParseCommandLineArgs()
        'If Path.GetFileName(Application.ExecutablePath) <> "Commander32.exe" And Path.GetFileName(Application.ExecutablePath) <> "Commander32.EXE" Then
        '    MsgBox("خطایی در رابطه با مکان قرارگیری فایل ها وجود دارد." & vbNewLine & "لطفا فایل ها را به حالت اولیه برگردانید و سپس autorun.exe را اجرا کنید", MsgBoxStyle.Exclamation, "خطا")
        '    Application.Exit()
        'End If

        LocalKey = ToMD5(LocalKey + Environment.MachineName + Environment.UserName)
        LocalIV = ToMD5(LocalIV + Environment.MachineName + Environment.UserName)
        Dim tempBytes As Byte() = CryptBytes(Encoding.UTF32.GetString(password), File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory & "data\Loader32.dll"), False)
        Dim SettingsStr As String = AES_decrypt(Encoding.UTF8.GetString(tempBytes))
        Dim SettingItems() As String = SettingsStr.Split("@@")
        serverURI = SettingItems(0)
        PackageCode = SettingItems(2).ToLower.Trim
        CheckumBin = SettingItems(4).ToLower.Trim
        If SettingItems.Length > 6 Then
            PackageName = SettingItems(6).Trim
        End If
        PackageTitle.Text = PackageName & " - (" & PackageCode & ")"
        Me.Text = PackageName & " - 808 Package Lock"

        If SettingItems.Length > 8 Then
            DataVersion = SettingItems(8).ToLower.Trim
        End If
        If SettingItems.Length > 10 Then
            'JustFile = SettingItems(10).ToLower.Trim
        End If
        AppVersion = lblversion.Text

        Dim tempRegVal As String = get_setting("version", "").ToString

        If tempRegVal <> "" Then
            Dim tthreadRunLogo As Thread = New Thread(AddressOf threadRunLogo)
            tthreadRunLogo.SetApartmentState(ApartmentState.STA)
            tthreadRunLogo.Start()
        End If

        binDir = AppDomain.CurrentDomain.BaseDirectory & "data\bin\"
        viewMainDir = AppDomain.CurrentDomain.BaseDirectory & "data\view\main\"
        videoDir = AppDomain.CurrentDomain.BaseDirectory & "data\view\video\"
        videoDetailsDir = AppDomain.CurrentDomain.BaseDirectory & "data\view\video_details\"
        helpDir = AppDomain.CurrentDomain.BaseDirectory & "data\help\"

        Dim cx As String = folderCheksum(binDir)
        If cx <> CheckumBin Then
            MsgBox("خطایی در رابطه با مکان قرارگیری فایل ها در پوشه bin وجود دارد." & vbNewLine & "لطفا فایل ها را به حالت اولیه برگردانید.", MsgBoxStyle.Exclamation, "خطا")
            Application.Exit()
        End If

        Dim temppath2 As String = IO.Path.GetTempPath()
        If Strings.Right(temppath2, 1) <> "\" Then temppath2 &= "\"

        tempDir = get_setting("tempdir", "")
        If tempDir <> "" And FileIO.FileSystem.DirectoryExists(tempDir) Then
            FileIO.FileSystem.DeleteDirectory(tempDir, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        tempDir = temppath2 & CStr(GetRandom(1, 10000000)) & CStr(GetRandom(1, 10000000)) & CStr(GetRandom(1, 10000000))
        If Directory.Exists(tempDir) = False Then
            FileSystem.MkDir(tempDir)
        End If
        File.SetAttributes(tempDir, File.GetAttributes(tempDir) Or FileAttributes.Hidden Or FileAttributes.System)
        set_setting("tempdir", tempDir)

        If (FileIO.FileSystem.FileExists(AppDomain.CurrentDomain.BaseDirectory & "reset.reset")) = True Then
            File.Delete(AppDomain.CurrentDomain.BaseDirectory & "reset.reset")
            set_setting("version", "")
            Application.Restart()
        End If

        Dim videos As String() = Directory.GetFiles(videoDetailsDir)
        If videos.Length = 0 Then 'there is no video file in data
            JustFile = "1"
        End If

        If tempRegVal <> "" Then
            If JustFile = "1" Then 'there is no video in this package
                FrmExplorerObj.Show()
                Me.Hide()
            Else
                FrmVideoObj.Show()
                Me.Hide()
            End If

            Dim threadCheckPUID As Thread = New Thread(AddressOf checkPUID)
            threadCheckPUID.SetApartmentState(ApartmentState.MTA)
            threadCheckPUID.Priority = ThreadPriority.BelowNormal
            threadCheckPUID.Start()

            While threadCheckPUID.IsAlive = True
                Thread.Sleep(5000)
            End While
            If My.Computer.Network.IsAvailable Then
                Dim syncUser As Thread = New Thread(AddressOf syncOfflineUser)
                syncUser.SetApartmentState(ApartmentState.MTA)
                syncUser.Start()
            End If
        Else
            Me.Activate()
            isLogoWorkComplete = True
            Dim t As Thread = New Thread(AddressOf LoadOpacity)
            t.SetApartmentState(ApartmentState.STA)
            t.Start()

        End If

        'loading textfield to prevent data lost at every starting
        If get_setting("user_name", "") <> "" Then
            txtName.Text = get_setting("user_name", "")
            txtName.ForeColor = Color.Black
        End If
        If get_setting("user_phone", "") <> "" Then
            txtPhone.Text = get_setting("user_phone", "")
            txtPhone.ForeColor = Color.Black
        End If
        If get_setting("user_email", "") <> "" Then
            txtEmail.Text = get_setting("user_email", "")
            txtEmail.ForeColor = Color.Black
        End If

    End Sub

    Private Sub threadRunLogo()
        FrmLogoObj = New FrmLogo
        FrmLogoObj.Show()
        FrmLogoObj.Opacity = 1
        FrmLogoObj.Refresh()

        Do While (isLogoWorkComplete = False)
            Threading.Thread.Sleep(200)
        Loop
        Threading.Thread.Sleep(3000)
        FrmLogoObj.Close()
    End Sub

    Private Sub ParseCommandLineArgs()
        Dim inputArgument As String = "/input="
        Dim inputName As String = ""

        For Each s As String In My.Application.CommandLineArgs
            If s.ToLower.StartsWith(inputArgument) Then
                inputName = s.Remove(0, inputArgument.Length)
            End If
        Next

        inputName = "9xx7(y)aso9E4236lX5wf8"
        PHPConKey = Strings.Right(inputName, 6) & PHPConKey
        PHPConIV = PHPConIV & Strings.Left(inputName, 7)
        'If inputName <> "9xx7(y)aso9E4236lX5wf8" Then
        '    MsgBox("خطایی در رابطه با تنظیمات برنامه رخ داده است." & vbNewLine & "لطفا با پشتیبانی تماس حاصل فرمایید.", MsgBoxStyle.Exclamation, "خطا")
        '    Application.Exit()
        'Else
        'End If

    End Sub
    Private Sub LoadOpacity()
        For i As Integer = 1 To 10
            Me.Invoke(New Action(Of Integer)(AddressOf LoadOpacityChild), i)
            System.Threading.Thread.Sleep(30)
        Next


        Dim ThreadGetPUID As Thread = New Thread(AddressOf GETPUID)
        ThreadGetPUID.SetApartmentState(ApartmentState.MTA)
        ThreadGetPUID.Start()
    End Sub

    Private Sub LoadOpacityChild(ByVal input As Integer)
        Me.Opacity = input / 10
    End Sub

    Private Sub TxtPass_TextChanged(sender As Object, e As EventArgs) Handles TxtPass.TextChanged
        lblStatus.Visible = False
        lblStatus.Text = ""
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If txtPhone.Text <> "09120000000" Then
            set_setting("user_phone", txtPhone.Text)
        End If
        If txtName.Text <> "میثم رزمی" Then
            set_setting("user_name", txtName.Text)
        End If
        If txtEmail.Text <> "sample@gmail.com" Then
            set_setting("user_email", txtEmail.Text)
        End If

        lblStatus.Visible = True
        lblStatus.Text = ""
        If TxtPass.Text.Length < 2 Or txtPhone.Text = "" Or txtPhone.Text = "09120000000" Or txtName.Text = "" Or txtName.Text = "میثم رزمی" Or txtEmail.Text = "" Or txtEmail.Text = "sample@gmail.com" Then
            lblStatus.Text = "فیلدها را به درستی پر کنید"
            lblStatus.ForeColor = Color.Red
            Exit Sub
        End If
        If IsEmail(txtEmail.Text) = False Then
            lblStatus.Text = "ایمیل نادرست"
            lblStatus.ForeColor = Color.Red
            Exit Sub
        End If
        If txtPhone.Text.Length <> 11 Then
            MsgBox("شماره تلفن اشتباه است. شماره باید 11 رقم باشد مانند:" & vbNewLine & "09123456789", MsgBoxStyle.Exclamation, "خطا")
            Exit Sub
        End If

        Try
            If My.Computer.Network.IsAvailable Then
                If Strings.Left(TxtPass.Text.Trim.ToLower, PackageCode.Length) <> PackageCode Then
                    lblStatus.Text = "سریال برای پکیج دیگری می باشد و بر روی این پکیج فعال نیست."
                    lblStatus.ForeColor = Color.Red
                Else

                    Dim ranber As Long = GetRandom(10000, 100000)
                    Dim jsondata As String = jsonSerilizer(1, PUID, TxtPass.Text.Trim.ToLower, PackageCode, ranber, txtName.Text.Replace(vbCrLf, ""), txtEmail.Text, txtPhone.Text, PackageName, DataVersion, AppVersion)
                    Dim hash As String = Web.HttpUtility.UrlEncodeUnicode(AES_encrypt(jsondata))
                    Dim response As String = HttpPostRequest(serverURI, "hash=" & hash.Trim)

                    Dim result As New jsonStructure
                    If response.Length > 20 Then
                        result = importJson(response)
                    Else
                        lblStatus.Text = "خطای نامعلوم"
                        lblStatus.ForeColor = Color.Black
                        MsgBox("لطفا با پشتیبانی تماس بگیرید و تصویر این خطا را برای آنها بفرستید." & vbNewLine & jsondata & vbNewLine & response, MsgBoxStyle.Critical, "خطای نامعلوم")
                        Return
                    End If

                    If result.ranber = (ranber * 73) - 320 Then
                        lblStatus.Text = "..."
                        Select Case CInt(result.response)
                            Case 1
                                lblStatus.Text = "فعال سازی انجام شد!"
                                lblStatus.ForeColor = Color.Green

                                set_setting("version", PUID)
                                set_setting("serial", TxtPass.Text.Trim.ToLower)
                                set_setting("package", PackageCode)
                                set_setting("user_name", txtName.Text)
                                set_setting("user_phone", txtPhone.Text)
                                set_setting("user_email", txtEmail.Text)

                                If JustFile = "1" Then 'there is no video in this package
                                    FrmExplorerObj.Show()
                                    Me.Hide()
                                Else
                                    FrmVideoObj.Show()
                                    Me.Hide()
                                End If
                            Case 2
                                lblStatus.Text = "تعداد دفعات استفاده از سریال مجاز نیست."
                                lblStatus.ForeColor = Color.Red
                            Case 3
                                lblStatus.Text = "خطای سرور, مجددا سعی کنید"
                                lblStatus.ForeColor = Color.Red
                            Case 4
                                lblStatus.Text = "سریال نامعتبر!"
                                lblStatus.ForeColor = Color.Red
                            Case 5
                                lblStatus.Text = "..."
                                lblStatus.ForeColor = Color.Green
                            Case Else

                        End Select
                    End If
                End If
            Else
                lblStatus.Text = "عدم دسترسی به اینترنت"
                lblStatus.ForeColor = Color.Black
                Exit Sub
            End If

        Catch ee As Exception
            lblStatus.Text = "خطای نامعلوم"
            MsgBox("خطای نامعلوم" & vbNewLine & ee.Message, MsgBoxStyle.Critical, "خطا")
            lblStatus.ForeColor = Color.Black
        End Try
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim webAddress As String = "http://civil808.com/page/about"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim webAddress As String = "http://civil808.com/"
        Process.Start(webAddress)
    End Sub

    Private Sub BtnHelp_Click(sender As Object, e As EventArgs) Handles BtnHelp.Click
        Dim tfrm As New FrmHelp
        tfrm.ShowDialog()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Close()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If txtPhone.Text <> "09120000000" Or txtPhone.Text <> "" Then
            set_setting("user_phone", txtPhone.Text)
        End If
        If txtName.Text <> "میثم رزمی" Or txtName.Text <> "" Then
            set_setting("user_name", txtName.Text)
        End If
        If txtEmail.Text <> "sample@gmail.com" Or txtEmail.Text <> "" Then
            set_setting("user_email", txtEmail.Text)
        End If

        If My.Computer.Network.IsAvailable Then
            MsgBox("برای جلوگیری از بروز خطا در استفاده های بعدی در صورت اتصال به اینترنت لطفا از فعال سازی آنلاین استفاده کنید.", MsgBoxStyle.Information, "راهنما")
        End If
        If txtPhone.Text = "" Or txtPhone.Text = "09120000000" Or txtName.Text = "" Or txtName.Text = "میثم رزمی" Or txtEmail.Text = "" Or txtEmail.Text = "sample@gmail.com" Then
            MsgBox("لطفا فیلدهای (نام - ایمیل - شماره تلفن) را پر کنید. حداقل 3 حرف باید وارد شود.", MsgBoxStyle.Exclamation, "خطا")
            Exit Sub
        End If
        If IsEmail(txtEmail.Text) = False Then
            MsgBox("ایمیل نادرست", MsgBoxStyle.Exclamation, "خطا")
            Exit Sub
        End If
        If txtPhone.Text.Length <> 11 Then
            MsgBox("شماره تلفن اشتباه است. شماره باید 11 رقم باشد مانند:" & vbNewLine & "09120001111", MsgBoxStyle.Exclamation, "خطا")
            Exit Sub
        End If

        Dim frmOffline As New FrmOfflineRegister
        frmOffline.ShowDialog()

        set_setting("user_name", txtName.Text)
        set_setting("user_phone", txtPhone.Text)
        set_setting("user_email", txtEmail.Text)
        set_setting("package", PackageCode)

        If get_setting("version", "") = PUID Then
            lblStatus.Text = "فعال سازی آفلاین انجام شد!"
            lblStatus.ForeColor = Color.Green
            If JustFile = "1" Then 'there is no video in this package
                FrmExplorerObj.Show()
                Me.Hide()
            Else
                FrmVideoObj.Show()
                Me.Hide()
            End If
        End If

    End Sub

    Private Sub txtPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub txtEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmail.KeyPress
        Dim ac As String = "@"
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Asc(e.KeyChar) < 97 Or Asc(e.KeyChar) > 122 Then
                If Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 95 Then
                    If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                        If ac.IndexOf(e.KeyChar) = -1 Then
                            e.Handled = True
                        Else
                            If txtEmail.Text.Contains("@") And e.KeyChar = "@" Then
                                e.Handled = True
                            End If
                        End If
                    End If
                End If
            End If

        End If

    End Sub

    'handling textboxes placeholders
    Private Sub txtName_GotFocus(sender As Object, e As EventArgs) Handles txtName.GotFocus
        If txtName.Text = "میثم رزمی" Then
            txtName.Text = ""
            txtName.ForeColor = Color.Black
            Dim iran As Font = CustomFont.GetInstance(10, FontStyle.Regular)
            txtName.Font = iran
        End If
    End Sub

    Private Sub txtName_LostFocus(sender As Object, e As EventArgs) Handles txtName.LostFocus
        If txtName.Text = "" Then
            txtName.Text = "میثم رزمی"
            txtName.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub txtPhone_GotFocus(sender As Object, e As EventArgs) Handles txtPhone.GotFocus
        If txtPhone.Text = "09120000000" Then
            txtPhone.Text = ""
            txtPhone.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtPhone_LostFocus(sender As Object, e As EventArgs) Handles txtPhone.LostFocus
        If txtPhone.Text = "" Then
            txtPhone.Text = "09120000000"
            txtPhone.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub txtEmail_GotFocus(sender As Object, e As EventArgs) Handles txtEmail.GotFocus
        If txtEmail.Text = "sample@gmail.com" Then
            txtEmail.Text = ""
            txtEmail.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtEmail_LostFocus(sender As Object, e As EventArgs) Handles txtEmail.LostFocus
        If txtEmail.Text = "" Then
            txtEmail.Text = "sample@gmail.com"
            txtEmail.ForeColor = Color.Silver
        End If
    End Sub

End Class