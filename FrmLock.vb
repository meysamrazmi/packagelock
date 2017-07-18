Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.ComponentModel

Public Class FrmLock


    Private Sub FrmLock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FrmsOpenCount += 1



        'debug
        ParseCommandLineArgs()
        If Path.GetFileName(Application.ExecutablePath) <> "Commander32.exe" Then
            'Debug
            Application.Exit()

        End If


        LocalKey = ToMD5(LocalKey + Environment.MachineName + Environment.UserName)
        LocalIV = ToMD5(LocalIV + Environment.MachineName + Environment.UserName)
        Dim tempBytes As Byte() = CryptBytes(Encoding.UTF32.GetString(password), File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory & "data\Loader32.dll"), False)
        Dim SettingsStr As String = AES_decrypt(Encoding.UTF8.GetString(tempBytes))
        Dim SettingItems() As String = SettingsStr.Split("@@")
        serverURI = SettingItems(0)
        PackageCode = SettingItems(2).ToLower.Trim
        CheckumBin = SettingItems(4).ToLower.Trim


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


        If tempRegVal <> "" Then
            Dim x As New FrmVideoList
            x.Show()
            Me.Hide()

            Dim threadCheckPUID As Thread = New Thread(AddressOf checkPUID)
            threadCheckPUID.SetApartmentState(ApartmentState.MTA)
            threadCheckPUID.Priority = ThreadPriority.BelowNormal
            threadCheckPUID.Start()

            While threadCheckPUID.IsAlive = True
                Thread.Sleep(500)
            End While

        Else
            Me.Activate()
            isLogoWorkComplete = True
            Dim t As Thread = New Thread(AddressOf LoadOpacity)
            t.SetApartmentState(ApartmentState.STA)
            t.Start()

        End If



        If My.Computer.Network.IsAvailable And tempRegVal <> "" Then
            Dim syncUser As Thread = New Thread(AddressOf syncOfflineUser)
            syncUser.SetApartmentState(ApartmentState.MTA)
            syncUser.Start()
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
        Threading.Thread.Sleep(4000)
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

        If inputName <> "9xx7(y)aso9E4236lX5wf8" Then
            Application.Exit()
        Else
            PHPConKey = Strings.Right(inputName, 6) & PHPConKey
            PHPConIV = PHPConIV & Strings.Left(inputName, 7)
        End If

    End Sub
    Private Sub LoadOpacity()
        For i As Integer = 1 To 100
            Me.Invoke(New Action(Of Integer)(AddressOf LoadOpacityChild), i)
            System.Threading.Thread.Sleep(10)
        Next


        Dim ThreadGetPUID As Thread = New Thread(AddressOf GETPUID)
        ThreadGetPUID.SetApartmentState(ApartmentState.MTA)
        ThreadGetPUID.Start()
    End Sub

    Private Sub LoadOpacityChild(ByVal input As Integer)
        Me.Opacity = input / 100
    End Sub

    Private Sub TxtPass_TextChanged(sender As Object, e As EventArgs) Handles TxtPass.TextChanged
        lblStatus.Visible = False
        lblStatus.Text = ""
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        lblStatus.Visible = True
        lblStatus.Text = ""
        If TxtPass.Text.Length < 4 Or txtPhone.Text = "" Or txtName.Text = "" Or txtEmail.Text = "" Then
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
            MsgBox("شماره تماس اشتباه است" & vbNewLine & "(نمونه صحیح) 9120001111", MsgBoxStyle.Exclamation, "خطا")
            Exit Sub
        End If


        Try

            If My.Computer.Network.IsAvailable Then
                If Strings.Left(TxtPass.Text.Trim.ToLower, PackageCode.Length) <> PackageCode Then
                    lblStatus.Text = "سریال نامعتبر!"
                    lblStatus.ForeColor = Color.Red
                Else

                    Dim ranber As Long = GetRandom(10000, 100000)
                    Dim hash As String = Web.HttpUtility.UrlEncodeUnicode(jsonSerilizer(1, PUID, TxtPass.Text.Trim.ToLower, PackageCode, ranber, txtName.Text, txtEmail.Text, txtPhone.Text))
                    Dim response As String = HttpPostRequest(serverURI, "hash=" & hash.Trim)

                    Dim result As New jsonStructure
                    If response.Length > 20 Then
                        result = importJson(response)
                    Else
                        lblStatus.Text = "خطای نامعلوم"
                        lblStatus.ForeColor = Color.Black
                        Return
                    End If

                    If result.ranber = (ranber * 73) - 320 Then
                        lblStatus.Text = "..."
                        Select Case CInt(result.response)
                            Case 1
                                lblStatus.Text = "ورود موفق!"
                                lblStatus.ForeColor = Color.Green

                                set_setting("version", PUID)
                                set_setting("serial", TxtPass.Text.Trim.ToLower)
                                set_setting("user_name", txtName.Text)
                                set_setting("user_phone", txtPhone.Text)
                                set_setting("user_email", txtEmail.Text)

                                Dim x As New FrmVideoList
                                x.Show()
                                Me.Hide()
                            Case 2
                                lblStatus.Text = "سریال باطل شده"
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

        Catch
            lblStatus.Text = "خطای نامعلوم"
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

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Close()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        'debug
        If My.Computer.Network.IsAvailable Then
            MsgBox("لطفا از فعالساز آنلاین استفاده کنید", MsgBoxStyle.Information, "راهنما")
            Exit Sub
        End If
        If txtEmail.Text.Length < 3 Or txtName.Text.Length < 3 Or txtPhone.Text.Length < 3 Then
            MsgBox("لطفا فیلدهای (نام - ایمیل - شماره تماس) را پر کنید", MsgBoxStyle.Exclamation, "خطا")
            Exit Sub
        End If
        If IsEmail(txtEmail.Text) = False Then
            MsgBox("ایمیل نادرست", MsgBoxStyle.Exclamation, "خطا")
            Exit Sub
        End If
        If txtPhone.Text.Length <> 11 Then
            MsgBox("شماره تماس اشتباه. نمونه صحیح:" & vbNewLine & "9120001111", MsgBoxStyle.Exclamation, "خطا")
            Exit Sub
        End If

        Dim frmOffline As New FrmOfflineRegister
        frmOffline.ShowDialog()

        set_setting("user_name", txtName.Text)
        set_setting("user_phone", txtPhone.Text)
        set_setting("user_email", txtEmail.Text)

        If get_setting("version", "") = PUID Then
            Dim x As New FrmVideoList
            x.Show()
            Me.Hide()
        Else
            lblStatus.Text = "خطا!"
            lblStatus.ForeColor = Color.Red
            lblStatus.Visible = True
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


End Class