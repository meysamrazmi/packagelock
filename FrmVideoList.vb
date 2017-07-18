Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
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

    Private Sub FrmVideoList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width - 100
        Me.Height = Screen.PrimaryScreen.Bounds.Height - 100
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2

        ImageListView1.SetRenderer(New ImageListViewRenderers.TilesRenderer)

        Dim iniArray As New List(Of String())

        Dim files As String() = Directory.GetFiles(videoDetailsDir)
        ImageListView1.Items.AddRange(files)


        Me.WindowState = 0
        isLogoWorkComplete = True
        Me.Activate()
        Dim t As Thread = New Thread(AddressOf LoadOpacity)
        t.SetApartmentState(ApartmentState.STA)
        t.Start()
    End Sub

    Private Sub LoadOpacity()
        Try
            For i As Integer = 1 To 100
                Me.Invoke(New Action(Of Integer)(AddressOf LoadOpacityChild), i)
                System.Threading.Thread.Sleep(10)
            Next
        Catch
        End Try

    End Sub

    Private Sub LoadOpacityChild(ByVal input As Integer)
        Me.Opacity = input / 100
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

    Private Sub lblShowExplorer_Click(sender As Object, e As EventArgs) Handles lblShowExplorer.Click
        FrmsOpenCount -= 1
        FrmExplorerObj.Show()
        Me.Hide()
    End Sub

    Private Sub lblShowExplorer_MouseEnter(sender As Object, e As EventArgs) Handles lblShowExplorer.MouseEnter
        lblShowExplorer.BackColor = Color.FromArgb(60, 60, 70)
    End Sub

    Private Sub lblShowExplorer_MouseLeave(sender As Object, e As EventArgs) Handles lblShowExplorer.MouseLeave
        lblShowExplorer.BackColor = Color.FromArgb(70, 70, 80)
    End Sub

    Private Sub lblHelp_MouseEnter(sender As Object, e As EventArgs) Handles lblHelp.MouseEnter
        lblHelp.BackColor = Color.FromArgb(60, 70, 60)
    End Sub

    Private Sub lblHElp_MouseLeave(sender As Object, e As EventArgs) Handles lblHelp.MouseLeave
        lblHelp.BackColor = Color.FromArgb(70, 80, 70)
    End Sub

    Private Sub lblOtherProducts_MouseEnter(sender As Object, e As EventArgs) Handles lblOtherProducts.MouseEnter
        lblOtherProducts.BackColor = Color.FromArgb(70, 60, 70)
    End Sub
    Private Sub lblOtherProducts_MouseLeave(sender As Object, e As EventArgs) Handles lblOtherProducts.MouseLeave
        lblOtherProducts.BackColor = Color.FromArgb(80, 70, 80)
    End Sub

    Private Sub FrmVideoList_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged

        ImageListView1.Width = Me.Width
        ImageListView1.Left = 0
        ImageListView1.Height = Me.Height - 150
        TableLayoutPanel2.Left = Me.Width - 90
        lblTitle.Left = (Me.Width / 2) - (lblTitle.Width / 2)
        If minimized = False Then
            Dim itemW As Double = Me.Width / 4.28
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
        Dim FileInfo As New FileInfo(Path.Combine(videoDir, ImageListView1.SelectedItems(0).VideoPath))
        Dim fileOpenerThread As Thread = New Thread(Sub() open808FileThread(FileInfo))
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

    Private Sub lblHelp_Click(sender As Object, e As EventArgs) Handles lblHelp.Click
        Dim proc As ProcessStartInfo = New ProcessStartInfo
        proc.UseShellExecute = True
        proc.FileName = "player\book\play808.exe"
        proc.Arguments = AES_encrypt(helpDir & "HP.msc", "JH8d*42(sF964Zc=820Di2!sF353EG#^", "@4gD348dsghFgjr$92Dk4036ksga28fH")
        Using exeProcess As Process = Process.Start(proc)
            exeProcess.WaitForExit()
        End Using
    End Sub

    Private Sub lblOtherProducts_Click(sender As Object, e As EventArgs) Handles lblOtherProducts.Click
        Dim proc As ProcessStartInfo = New ProcessStartInfo
        proc.UseShellExecute = True
        proc.FileName = "player\book\play808.exe"
        proc.Arguments = AES_encrypt(helpDir & "OP.msc", "JH8d*42(sF964Zc=820Di2!sF353EG#^", "@4gD348dsghFgjr$92Dk4036ksga28fH")
        Using exeProcess As Process = Process.Start(proc)
            exeProcess.WaitForExit()
        End Using
    End Sub
End Class