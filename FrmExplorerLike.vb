Imports ExpTreeLib
Imports ExpTreeLib.CShItem
Imports ExpTreeLib.SystemImageListManager
Imports System.IO
Imports System.Threading
Imports System.Collections.Generic
Imports System.Text

#Const Ver = 2005
Public Class frmExplorerLike
    Inherits System.Windows.Forms.Form
    'avoid Globalization problem-- an empty timevalue
    Dim testTime As New DateTime(1, 1, 1, 0, 0, 0)

    Private LastSelectedCSI As CShItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents BtnOpenVideos As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ExpTree1 As ExpTree
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents Panel1 As Panel
    Public WithEvents lv1 As ListView
    Friend WithEvents ColumnHeaderName As ColumnHeader
    Friend WithEvents ColumnHeaderSize As ColumnHeader
    Friend WithEvents ColumnHeaderType As ColumnHeader
    Friend WithEvents cmdCTest As Button
    Friend WithEvents BtnBackFolder As Button
    Private Shared Event1 As New ManualResetEvent(True)

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SystemImageListManager.SetListViewImageList(lv1, True, False)
        SystemImageListManager.SetListViewImageList(lv1, False, False)
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuViewLargeIcons As System.Windows.Forms.MenuItem
    Friend WithEvents mnuViewSmallIcons As System.Windows.Forms.MenuItem
    Friend WithEvents mnuViewList As System.Windows.Forms.MenuItem
    Friend WithEvents mnuViewDetails As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExplorerLike))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnuViewLargeIcons = New System.Windows.Forms.MenuItem()
        Me.mnuViewSmallIcons = New System.Windows.Forms.MenuItem()
        Me.mnuViewList = New System.Windows.Forms.MenuItem()
        Me.mnuViewDetails = New System.Windows.Forms.MenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ExpTree1 = New ExpTreeLib.ExpTree()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lv1 = New System.Windows.Forms.ListView()
        Me.ColumnHeaderName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdCTest = New System.Windows.Forms.Button()
        Me.BtnOpenVideos = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.BtnBackFolder = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2})
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuViewLargeIcons, Me.mnuViewSmallIcons, Me.mnuViewList, Me.mnuViewDetails})
        Me.MenuItem2.Text = "&View"
        '
        'mnuViewLargeIcons
        '
        Me.mnuViewLargeIcons.Index = 0
        Me.mnuViewLargeIcons.Text = "Large Icon"
        '
        'mnuViewSmallIcons
        '
        Me.mnuViewSmallIcons.Index = 1
        Me.mnuViewSmallIcons.Text = "Small Icon"
        '
        'mnuViewList
        '
        Me.mnuViewList.Index = 2
        Me.mnuViewList.Text = "List"
        '
        'mnuViewDetails
        '
        Me.mnuViewDetails.Index = 3
        Me.mnuViewDetails.Text = "Details"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.BtnOpenVideos, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdExit, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 379)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(8)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(905, 43)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'ExpTree1
        '
        Me.ExpTree1.AllowFolderRename = False
        Me.ExpTree1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ExpTree1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExpTree1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ExpTree1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ExpTree1.Location = New System.Drawing.Point(0, 0)
        Me.ExpTree1.Name = "ExpTree1"
        Me.ExpTree1.ShowRootLines = False
        Me.ExpTree1.Size = New System.Drawing.Size(187, 379)
        Me.ExpTree1.StartUpDirectory = ExpTreeLib.ExpTree.StartDir.Desktop
        Me.ExpTree1.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(187, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(7, 379)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lv1)
        Me.Panel1.Controls.Add(Me.cmdCTest)
        Me.Panel1.Controls.Add(Me.BtnBackFolder)
        Me.Panel1.Controls.Add(Me.Splitter1)
        Me.Panel1.Controls.Add(Me.ExpTree1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(905, 379)
        Me.Panel1.TabIndex = 1
        '
        'lv1
        '
        Me.lv1.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lv1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lv1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderName, Me.ColumnHeaderSize, Me.ColumnHeaderType})
        Me.lv1.Location = New System.Drawing.Point(193, 28)
        Me.lv1.MultiSelect = False
        Me.lv1.Name = "lv1"
        Me.lv1.Size = New System.Drawing.Size(712, 348)
        Me.lv1.TabIndex = 0
        Me.lv1.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeaderName
        '
        Me.ColumnHeaderName.Text = "Name"
        Me.ColumnHeaderName.Width = 180
        '
        'ColumnHeaderSize
        '
        Me.ColumnHeaderSize.Text = "Size"
        Me.ColumnHeaderSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeaderSize.Width = 80
        '
        'ColumnHeaderType
        '
        Me.ColumnHeaderType.Text = "Type"
        Me.ColumnHeaderType.Width = 100
        '
        'cmdCTest
        '
        Me.cmdCTest.Font = New System.Drawing.Font("IRANSans", 9.0!)
        Me.cmdCTest.Location = New System.Drawing.Point(193, 0)
        Me.cmdCTest.Name = "cmdCTest"
        Me.cmdCTest.Size = New System.Drawing.Size(103, 27)
        Me.cmdCTest.TabIndex = 7
        Me.cmdCTest.Text = "پوشه اصلی"
        Me.cmdCTest.UseCompatibleTextRendering = True
        '
        'BtnOpenVideos
        '
        Me.BtnOpenVideos.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BtnOpenVideos.BackColor = System.Drawing.Color.White
        Me.BtnOpenVideos.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.BtnOpenVideos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOpenVideos.Font = New System.Drawing.Font("IRANSans", 9.75!)
        Me.BtnOpenVideos.Image = Global.ExpTree_Demo.My.Resources.Resources.arrow_left
        Me.BtnOpenVideos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOpenVideos.Location = New System.Drawing.Point(3, 4)
        Me.BtnOpenVideos.Name = "BtnOpenVideos"
        Me.BtnOpenVideos.Padding = New System.Windows.Forms.Padding(0, 0, 15, 0)
        Me.BtnOpenVideos.Size = New System.Drawing.Size(115, 34)
        Me.BtnOpenVideos.TabIndex = 4
        Me.BtnOpenVideos.Text = "ویدیوها"
        Me.BtnOpenVideos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnOpenVideos.UseVisualStyleBackColor = False
        Me.BtnOpenVideos.UseCompatibleTextRendering = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.cmdExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExit.Font = New System.Drawing.Font("IRANSans", 9.75!)
        Me.cmdExit.ForeColor = System.Drawing.Color.White
        Me.cmdExit.Image = Global.ExpTree_Demo.My.Resources.Resources.logout
        Me.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdExit.Location = New System.Drawing.Point(801, 3)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.cmdExit.Size = New System.Drawing.Size(101, 37)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "خروج"
        Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExit.UseVisualStyleBackColor = False
        Me.cmdExit.UseCompatibleTextRendering = True
        '
        'BtnBackFolder
        '
        Me.BtnBackFolder.Font = New System.Drawing.Font("IRANSans", 9.0!)
        Me.BtnBackFolder.Location = New System.Drawing.Point(297, 0)
        Me.BtnBackFolder.Name = "BtnBackFolder"
        Me.BtnBackFolder.Size = New System.Drawing.Size(89, 27)
        Me.BtnBackFolder.TabIndex = 8
        Me.BtnBackFolder.Text = "بازگشت"
        Me.BtnBackFolder.UseVisualStyleBackColor = True
        Me.BtnBackFolder.UseCompatibleTextRendering = True
        '
        'frmExplorerLike
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(905, 422)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MainMenu1
        Me.Name = "frmExplorerLike"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "808 File Viewer"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Form Exit Methods"
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        FrmLock.Close()
        Me.Close()
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        FrmLock.Close()
        Me.Close()
    End Sub
#End Region

#Region "VisibleChanged Event"

    Dim lastClickTime As DateTime = Now
    Private Sub lv1_MouseClick(sender As Object, e As MouseEventArgs) Handles lv1.MouseClick

        Dim TimeSpent As System.TimeSpan
        TimeSpent = Now.Subtract(lastClickTime)
        If TimeSpent.TotalSeconds < 6 Then
            Exit Sub
        End If
        lastClickTime = Now

        Dim NewProcess As New ProcessStartInfo
        Dim selectedFileFullPath As String
        selectedFileFullPath = ExpTree1.SelectedItem.Path & "\" & Me.lv1.SelectedItems.Item(0).Text.ToString
        If Directory.Exists(selectedFileFullPath) Then

        ElseIf File.Exists(selectedFileFullPath) Then

            FrmLoadingObj = New Loading
            FrmLoadingObj.Show()

            If IsProcessRunning("play808") Then
                killProcess("play808")
            End If
            Dim FileInfo As New FileInfo(selectedFileFullPath)
            Dim fileOpenerThread As Thread = New Thread(Sub() open808FileThread(FileInfo))
            fileOpenerThread.SetApartmentState(ApartmentState.MTA)
            fileOpenerThread.Priority = ThreadPriorityLevel.Highest
            fileOpenerThread.Start()

        End If

    End Sub




    Private Sub dlgStart()
        FrmLoadingObj = New Loading
        FrmLoadingObj.ShowDialog()
    End Sub
    Private Sub lv1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lv1.VisibleChanged
        If lv1.Visible Then
            SystemImageListManager.SetListViewImageList(lv1, True, False)
            SystemImageListManager.SetListViewImageList(lv1, False, False)
        End If
    End Sub
#End Region

#Region "Form Load"


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ExpTree1.Visible = False
        Dim iran As Font = CustomFont.GetInstance(10, FontStyle.Regular)
        cmdCTest.Font = CustomFont.GetInstance(9, FontStyle.Regular)
        BtnBackFolder.Font = CustomFont.GetInstance(9, FontStyle.Regular)
        cmdExit.Font = iran
        BtnOpenVideos.Font = iran

        Me.Activate()

        Dim cDir As CShItem = GetCShItem(viewMainDir)
        If cDir.IsFolder Then
            ExpTree1.RootItem = cDir
        End If
        FrmLoadingObj.Close()
    End Sub
#End Region

#Region "   ExplorerTree Event Handling"
    Private Sub AfterNodeSelect(ByVal pathName As String, ByVal CSI As CShItem) Handles ExpTree1.ExpTreeNodeSelected
        Dim dirList As New ArrayList()
        Dim fileList As New ArrayList()
        Dim TotalItems As Integer
        LastSelectedCSI = CSI
        If CSI.DisplayName.Equals(CShItem.strMyComputer) Then
            dirList = CSI.GetDirectories 'avoid re-query since only has dirs
        Else
            dirList = CSI.GetDirectories
            fileList = CSI.GetFiles
        End If
        TotalItems = dirList.Count + fileList.Count
        Event1.WaitOne()
        If TotalItems > 0 Then
            Dim item As CShItem
            dirList.Sort()
            fileList.Sort()
            Dim combList As New ArrayList(TotalItems)
            combList.AddRange(dirList)
            combList.AddRange(fileList)

            'Build the ListViewItems & add to lv1
            lv1.BeginUpdate()
            lv1.Items.Clear()
            For Each item In combList
                Dim lvi As New ListViewItem(item.GetFileName)
                With lvi
                    If Not item.IsDisk And item.IsFileSystem And Not item.IsFolder Then
                        If item.Length > 1024 Then
                            .SubItems.Add(Format(item.Length / 1024, "#,### KB"))
                        Else
                            .SubItems.Add(Format(item.Length, "##0 Bytes"))
                        End If
                    Else
                        .SubItems.Add("")
                    End If
                    .SubItems.Add(item.TypeName)
                    If item.IsDisk Then
                        .SubItems.Add("")
                    Else
                        If item.LastWriteTime = testTime Then '"#1/1/0001 12:00:00 AM#" is empty
                            .SubItems.Add("")
                        Else
                            .SubItems.Add(item.LastWriteTime)
                        End If
                    End If
                    '.ImageIndex = SystemImageListManager.GetIconIndex(item, False)
                    .Tag = item
                End With
                lv1.Items.Add(lvi)
            Next
            lv1.EndUpdate()
            LoadLV1Images()
        Else
            lv1.Items.Clear()
        End If
    End Sub

#End Region

#Region "   ListView and ComboBox Event Handling"
    Private BackList As ArrayList

    Private Sub lv1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lv1.MouseUp
        Dim lvi As ListViewItem = lv1.GetItemAt(e.X, e.Y)
        If IsNothing(lvi) Then Exit Sub
        If IsNothing(lv1.SelectedItems) OrElse lv1.SelectedItems.Count < 1 Then Exit Sub
        Dim item As CShItem = lv1.SelectedItems(0).Tag
        If item.IsFolder Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Event1.WaitOne()

                ExpTree1.RootItem = item
            ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
                Event1.WaitOne()
                ExpTree1.ExpandANode(item)
            End If
        End If
    End Sub





#End Region







#Region "   View Menu Event Handling"
    Private Sub mnuViewLargeIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewLargeIcons.Click
        lv1.View = View.LargeIcon
    End Sub

    Private Sub mnuViewSmallIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewSmallIcons.Click
        lv1.View = View.Tile
    End Sub

    Private Sub mnuViewList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewList.Click
        lv1.View = View.List
    End Sub

    Private Sub mnuViewDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewDetails.Click
        lv1.View = View.Details
    End Sub
#End Region


    Private Sub cmdCTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCTest.Click
        Dim cDir As CShItem = GetCShItem(viewMainDir)
        If cDir.IsFolder Then
            ExpTree1.RootItem = cDir
        End If
    End Sub


#Region "   IconIndex Loading"
    Private Sub LoadLV1Images()
        Dim lvi As ListViewItem
        For Each lvi In lv1.Items
            lvi.ImageIndex = SystemImageListManager.GetIconIndex(lvi.Tag, False)
        Next
        Event1.Set()
    End Sub

#End Region

#Region "   Various testing routines. Depend on Files/Dirs on Developmental system"
    ' The Routines in this region handle buttons that have been removed from the form
    '  with the obvious names.  The routines depend on Files and Dirs found on
    '  my development system.  To see how they work, add the buttons and change 
    '  the literal references to Files & Dirs that exist on your system
    'Private Sub cmdFilterTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterTest.Click
    '    Dim filtAl As New ArrayList()
    '    Dim fList As New ArrayList()
    '    Dim baseItem As New CShItem("C:\Data\Checklists")
    '    fList = baseItem.GetFiles("*.doc")
    '    Dim Item As CShItem
    '    For Each Item In fList
    '        Dim xxx As New CShItem(Item.Path)
    '        Debug.WriteLine(xxx.Path)
    '        Debug.WriteLine(xxx.DisplayName)
    '        xxx.DebugDump()
    '        filtAl.Add(xxx)
    '    Next
    '    'Build the ListViewItems & add to lv1
    '    lv1.BeginUpdate()
    '    lv1.Items.Clear()
    '    For Each Item In fList
    '        Dim lvi As New ListViewItem(Item.DisplayName)
    '        With lvi
    '            If Not Item.IsDisk And Item.IsFileSystem And Not Item.IsFolder Then
    '                If Item.Length > 1024 Then
    '                    .SubItems.Add(Format(Item.Length / 1024, "#,### KB"))
    '                Else
    '                    .SubItems.Add(Format(Item.Length, "##0 Bytes"))
    '                End If
    '            Else
    '                .SubItems.Add("")
    '            End If
    '            .SubItems.Add(Item.TypeName)
    '            If Item.IsDisk Then
    '                .SubItems.Add("")
    '            Else
    '                If Item.LastWriteTime = testTime Then '"#1/1/0001 12:00:00 AM#" is empty
    '                    .SubItems.Add("")
    '                Else
    '                    .SubItems.Add(Item.LastWriteTime)
    '                End If
    '            End If
    '            .ImageIndex = SystemImageListManager.GetIconIndex(Item, False)
    '            .Tag = Item
    '        End With
    '        lv1.Items.Add(lvi)
    '    Next
    '    lv1.EndUpdate()
    'End Sub

    'Private Sub cmdExpandTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim testPath As String = "F:\Music\Clips\Brooks & Dunn\Borderline"
    '    ExpTree1.ExpandANode(testPath)
    'End Sub
#End Region


    Private Sub BtnBackFolder_Click(sender As Object, e As EventArgs) Handles BtnBackFolder.Click
        If Len(ExpTree1.SelectedItem.Path) - 1 > viewMainDir.Length Then
            Dim cDir As CShItem = GetCShItem(System.IO.Directory.GetParent(ExpTree1.SelectedItem.Path).FullName)
            If cDir.IsFolder Then
                ExpTree1.RootItem = cDir
            End If
        End If
    End Sub

    Private Sub BtnOpenVideos_Click(sender As Object, e As EventArgs) Handles BtnOpenVideos.Click
        FrmsOpenCount -= 1
        FrmVideoObj.Show()
        Me.Hide()
    End Sub

    Private Sub frmExplorerLike_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FrmsOpenCount += 1
    End Sub



    Private Sub frmExplorerLike_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Panel1.Top = 27
        Panel1.Width = Me.Width - 8
        Panel1.Height = Me.Height - 110
        lv1.Top = 27
        lv1.Left = 0
        lv1.Height = Panel1.Height - 8
        lv1.Width = Panel1.Width
        'BtnBackFolder.Left = Me.Width - BtnBackFolder.Width - 16
        TableLayoutPanel1.Top = Me.Height - 112
        TableLayoutPanel1.Width = Me.Width - 16
        cmdCTest.Left = 0
        BtnBackFolder.Left = 104
    End Sub

    Private Sub frmExplorerLike_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        FrmsOpenCount -= 1
        initilizeClose()
    End Sub
End Class
