Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Text
Imports System.Threading
Imports Manina.Windows.Forms

Public Class FrmVideoList
    Private FrmExplorer As New frmExplorerLike
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer


    Dim minimized As Boolean

    Private Sub FrmVideoList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, lblTitle.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub FrmVideoList_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, lblTitle.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub FrmVideoList_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp, lblTitle.MouseUp
        drag = False
    End Sub

    'helper function to work with base64
    Public Function DecodeBase64(input As String) As String
        Return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(input))
    End Function

    Private Sub FrmVideoList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim iran As Font = CustomFont.GetInstance(10, FontStyle.Regular)
        lblTitle.Font = CustomFont.GetInstance(14, FontStyle.Regular)
        open_explorer.Font = iran
        help_btn.Font = iran
        help1_btn.Font = iran
        other_btn.Font = iran

        Me.Text = PackageName & " - Video List"

        ImageListView1.SetRenderer(New ImageListViewRenderers.XPRenderer) 'TilesRenderer 'XPRenderer
        Dim iniArray As New List(Of String)
        Dim videos As String() = Directory.GetFiles(videoDetailsDir)

        For Each video As String In videos
            iniArray.Add(video)
        Next
        iniArray = iniArray.OrderBy(Function(q) Int32.Parse(q.Split("\").Last().Split(".").First)).ToList()
        Dim sortedVideos As String() = iniArray.ToArray()

        If videos.Length = 0 Then 'there is no video file in data
            JustFile = "1"
            FrmsOpenCount -= 1
            FrmExplorerObj.Show()
            Me.Hide()
        Else
            Dim iniPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory & "data\view\", "details.ini")
            Dim readText As String = File.ReadAllText(iniPath)
            Dim SettingItems() As String = readText.Split(vbNewLine)
            Dim settings As New List(Of String())
            For Each rawDetails As String In SettingItems
                Dim details() As String = rawDetails.Split("@")
                settings.Add(details)
            Next

            Dim i As Integer = 0
            For Each fileName As String In sortedVideos
                Dim item As New ImageListViewItem
                item.FileName = fileName
                item.Text = DecodeBase64(settings.Item(i)(1))
                item.Text += If(item.Text.Equals("") Or settings.Item(i)(2).Equals(""), "", "    |    ") + DecodeBase64(settings.Item(i)(2))
                item.Text += If(item.Text.Equals("") Or settings.Item(i)(2).Equals(""), "", "    |    ") + DecodeBase64(settings.Item(i)(3))
                ImageListView1.Items.Add(item)
                i = i + 1
            Next

            Me.WindowState = 0
            Me.Activate()
            Dim t As Thread = New Thread(AddressOf LoadOpacity)
            t.SetApartmentState(ApartmentState.STA)
            t.Start()
        End If

        isLogoWorkComplete = True
    End Sub

    Private Sub LoadOpacity()
        Try
            For i As Integer = 1 To 10
                Me.Invoke(New Action(Of Integer)(AddressOf LoadOpacityChild), i)
                System.Threading.Thread.Sleep(30)
            Next
        Catch
        End Try

    End Sub

    Private Sub LoadOpacityChild(ByVal input As Integer)
        Me.Opacity = input / 10
    End Sub


    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        minimized = True
        Me.WindowState = 1

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Close()
    End Sub



    Private Sub ImageListView1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ImageListView1.ItemClick
        If ImageListView1.SelectedItems.Count > 1 Then
            Dim xtemp As ImageListViewItem = ImageListView1.SelectedItems.Item(0)
            ImageListView1.SelectedItems.ImageListView.ClearSelection()
            ImageListView1.Items.FocusedItem = xtemp
            Exit Sub
        End If
    End Sub

    Private Sub open_explorer_Click(sender As Object, e As EventArgs) Handles open_explorer.Click
        FrmsOpenCount -= 1
        FrmExplorerObj.Show()
        Me.Hide()
    End Sub

    Private Sub open_explorer_MouseEnter(sender As Object, e As EventArgs) Handles open_explorer.MouseEnter
        open_explorer.BackColor = Color.White
    End Sub

    Private Sub open_explorer_MouseLeave(sender As Object, e As EventArgs) Handles open_explorer.MouseLeave
        open_explorer.BackColor = Color.Transparent
    End Sub

    Private Sub help_btn_MouseEnter(sender As Object, e As EventArgs) Handles help_btn.MouseEnter
        help_btn.BackColor = Color.White
    End Sub

    Private Sub help_btn_MouseLeave(sender As Object, e As EventArgs) Handles help_btn.MouseLeave
        help_btn.BackColor = Color.Transparent
    End Sub

    Private Sub help1_btn_MouseEnter(sender As Object, e As EventArgs) Handles help1_btn.MouseEnter
        help1_btn.BackColor = Color.White
    End Sub

    Private Sub help1_btn_MouseLeave(sender As Object, e As EventArgs) Handles help1_btn.MouseLeave
        help1_btn.BackColor = Color.Transparent
    End Sub

    Private Sub other_btn_MouseEnter(sender As Object, e As EventArgs) Handles other_btn.MouseEnter
        other_btn.BackColor = Color.White
    End Sub
    Private Sub other_btn_MouseLeave(sender As Object, e As EventArgs) Handles other_btn.MouseLeave
        other_btn.BackColor = Color.Transparent
    End Sub

    Private Sub FrmVideoList_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If minimized = False Then
            Dim itemW As Double = Me.Width / 4.3
            ImageListView1.ThumbnailSize = New Size(itemW, itemW)
        End If
        ImageListView1.Refresh()

    End Sub


    Private Sub ImageListView1_MouseLeave(sender As Object, e As EventArgs) Handles ImageListView1.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub ImageListView1_ItemHover(sender As Object, e As ItemHoverEventArgs) Handles ImageListView1.ItemHover
        Cursor = Cursors.Hand
    End Sub

    Private Sub ImageListView1_ItemDoubleClick(sender As Object, e As ItemClickEventArgs) Handles ImageListView1.ItemDoubleClick
        FrmLoadingObj = New Loading
        FrmLoadingObj.Show()

        If IsProcessRunning("play808") Then
            killProcess("play808")
        End If
        Dim FileInfo As New FileInfo(Directory.GetFiles(videoDir)(ImageListView1.SelectedItems(0).Index))
        Dim fileOpenerThread As Thread = New Thread(Sub() open808FileThread(FileInfo, get_setting("default_player", "")))
        fileOpenerThread.SetApartmentState(ApartmentState.MTA)
        fileOpenerThread.Priority = ThreadPriorityLevel.Highest
        fileOpenerThread.Start()
    End Sub

    Private Sub FrmVideoList_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FrmsOpenCount += 1
    End Sub


    Private Sub lblTitle_DoubleClick(sender As Object, e As EventArgs) Handles lblTitle.DoubleClick
        Dim webAddress As String = "http://civil808.com/"
        Process.Start(webAddress)
    End Sub

    Private Sub FrmVideoList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        FrmsOpenCount -= 1
        initilizeClose()
    End Sub

    Private Sub help1_btn_Click(sender As Object, e As EventArgs) Handles help1_btn.Click
        Dim tfrm As New FrmHelp
        tfrm.ShowDialog()
    End Sub

    Private Sub help_btn_Click(sender As Object, e As EventArgs) Handles help_btn.Click
        Dim proc As ProcessStartInfo = New ProcessStartInfo
        proc.UseShellExecute = True
        proc.FileName = "player\book\play808.exe"
        proc.Arguments = AES_encrypt(helpDir & "HP.msc", "JH8d*42(sF964Zc=820Di2!sF353EG#^", "@4gD348dsghFgjr$92Dk4036ksga28fH")
        Using exeProcess As Process = Process.Start(proc)
            exeProcess.WaitForExit()
        End Using
    End Sub

    Private Sub other_btn_Click(sender As Object, e As EventArgs) Handles other_btn.Click
        Dim proc As ProcessStartInfo = New ProcessStartInfo
        proc.UseShellExecute = True
        proc.FileName = "player\book\play808.exe"
        proc.Arguments = AES_encrypt(helpDir & "OP.msc", "JH8d*42(sF964Zc=820Di2!sF353EG#^", "@4gD348dsghFgjr$92Dk4036ksga28fH")
        Using exeProcess As Process = Process.Start(proc)
            exeProcess.WaitForExit()
        End Using
    End Sub

End Class