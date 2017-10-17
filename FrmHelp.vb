﻿Imports System.Threading
Public Class FrmHelp
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click, MyBase.DoubleClick
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim webAddress As String = "http://civil808.com/shop"
        Process.Start(webAddress)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim webAddress As String = "http://civil808.com"
        Process.Start(webAddress)
    End Sub

    Private Sub LoadOpacity()
        For i As Integer = 1 To 10
            Me.Invoke(New Action(Of Integer)(AddressOf LoadOpacityChild), i)
            System.Threading.Thread.Sleep(20)
        Next
    End Sub

    Private Sub LoadOpacityChild(ByVal input As Integer)
        Me.Opacity = input / 10
    End Sub

    Private Sub Help_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim t As Thread = New Thread(AddressOf LoadOpacity)
        t.SetApartmentState(ApartmentState.STA)
        t.Start()
    End Sub
    Private Sub btn_about_Click(sender As Object, e As EventArgs) Handles btn_about.Click
        Dim webAddress As String = "http://civil808.com/page/about"
        Process.Start(webAddress)
    End Sub

    Private Sub btn_site_Click(sender As Object, e As EventArgs) Handles btn_site.Click
        Dim webAddress As String = "http://civil808.com/"
        Process.Start(webAddress)
    End Sub

    Private Sub dotnet_Click(sender As Object, e As EventArgs) Handles dotnet.Click
        Dim webAddress As String = "http://lock.civil808.com/repo/dotnet.exe"
        Process.Start(webAddress)
    End Sub

    Private Sub codec_Click(sender As Object, e As EventArgs) Handles codec.Click
        Dim webAddress As String = "http://lock.civil808.com/repo/Codec.exe"
        Process.Start(webAddress)
    End Sub

    Private Sub iran_Click(sender As Object, e As EventArgs) Handles iran.Click
        Dim webAddress As String = "http://lock.civil808.com/repo/IRANSans.ttf"
        Process.Start(webAddress)
    End Sub
End Class