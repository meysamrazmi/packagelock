﻿Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Module functions

    Public Function GetRandom(ByVal Min As Long, ByVal Max As Long) As Long

        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)

        Return Nothing
    End Function

    Public Function HttpPostRequest(ByVal url As String, ByVal data As String, Optional ByVal HideErrors As Boolean = False) As String
        Dim responseFromServer As String = Nothing
        Try
            url = Replace(url, "https", "http")

            Dim request As System.Net.WebRequest = System.Net.WebRequest.Create(url)
            request.Method = "POST"
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(data)

            request.ContentType = "application/x-www-form-urlencoded"
            CType(request, HttpWebRequest).UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows CE)"
            'CType(request, HttpWebRequest).Accept = "*/*"
            'request.Headers.Add("Accept-Language", "en-us\r\n")
            'request.Headers.Add("UA-CPU", "x86 \r\n")
            'request.Headers.Add("Cache-Control", "no-cache\r\n")
            CType(request, HttpWebRequest).Referer = url
            request.ContentLength = byteArray.Length

            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As WebResponse = request.GetResponse()
            dataStream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            responseFromServer = reader.ReadToEnd()
            reader.Close()
            dataStream.Close()
            response.Close()
            Return responseFromServer

        Catch ex As Exception
            Dim error1 As String = ErrorToString()
            If HideErrors = False Then
                If error1 = "Invalid URI: The format of the URI could not be determined." Then
                    MsgBox("ERROR! Must have HTTP:// before the URL.", "Webservice/httpRequest")
                Else
                    MsgBox(error1.ToString, System.Reflection.MethodBase.GetCurrentMethod.Name.ToString)
                End If
                Return ""
            Else
                Return error1
            End If
        End Try
    End Function

    Public Sub checkPUID()
        Dim tempRegVal As String = get_setting("version", "").ToString
        GETPUID()
        If tempRegVal <> PUID Then
            set_setting("version", "")
            MsgBox("تغییراتی در سیستم شما بوجود آمده است و پکیج غیر فعال شده است." & vbNewLine & "اگر خطایی رخ داده است می توانید دوباره فعال سازی را انجام دهید و یا اینکه یا پشتیبانی تماس بگیرید.", MsgBoxStyle.Exclamation, "خطا")
            Application.Restart()
        End If
    End Sub

    Public Function IsEmail(ByVal input As String) As Boolean
        Dim email As New Regex("([\w-+]+(?:\.[\w-+]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7})")
        If email.IsMatch(input) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IsProcessRunning(sProcessName As String) As Boolean
        Dim listProc() As System.Diagnostics.Process
        listProc = System.Diagnostics.Process.GetProcessesByName(sProcessName)
        If listProc.Length > 0 Then
            Return True
        Else
            Return False
        End If

        Return False
    End Function

    Public Sub killProcess(ByVal name As String)
        For Each Process1 As Process In Process.GetProcessesByName(name)
            Process1.Kill()
            Process1.WaitForExit()
        Next
    End Sub
    Public Sub syncOfflineUser()
        On Error Resume Next
        Dim ranber As Long = GetRandom(10000, 100000)
        Dim jsondata As String = jsonSerilizer(1, get_setting("version", PUID), get_setting("serial", ""), PackageCode, ranber, get_setting("user_name", ""), get_setting("user_email", ""), get_setting("user_phone", ""), PackageName, DataVersion, AppVersion)
        Dim hash As String = Web.HttpUtility.UrlEncodeUnicode(AES_encrypt(jsondata))
        Dim response As String = HttpPostRequest(serverURI, "hash=" & hash.Trim)

        Dim result As New jsonStructure
        If response.Length > 20 Then
            result = importJson(response)
        Else
            Exit Sub
        End If

        If result.ranber = (ranber * 73) - 320 And (CInt(result.response) = 4 Or CInt(result.response) = 2) And get_setting("version", "") <> "" Then
            set_setting("version", "")
            MsgBox("اطلاعات شما در دیتابیس وجود ندارد." & vbNewLine & "اگر خطایی رخ داده است می توانید دوباره فعال سازی را انجام دهید و یا اینکه یا پشتیبانی تماس بگیرید.", MsgBoxStyle.Exclamation, "خطا")
            Application.Restart()
        End If

        'everyone should see videos with their default video player 
        If result.extra = "pdf" Then
            result.extra = "film/pdf"
        Else result.extra = ""
            result.extra = "film"
        End If

        If get_setting("default_player", "") <> result.extra And (result.extra = "pdf" Or result.extra = "film" Or result.extra = "film/pdf") Then 'pdf or film or film/pdf or 0
            set_setting("default_player", result.extra)
            MsgBox("Player " & result.extra & "پیش فرض شما تغییر کرد و شما می توانید برای اجرای فایل ها از player های سیستم خودتان استفاده کنید.", MsgBoxStyle.OkOnly, "اطلاعیه")
        ElseIf result.extra = "0" Then
            set_setting("default_player", "")
        End If
    End Sub


    Public Function get_setting(ByVal Key As String, ByVal DefaultV As Object) As Object
        Dim temp As String = Nothing
        Dim Subject As String = "Saze808Lock"

        temp = AES_decrypt(GetSetting(AES_encrypt(Application.ProductName & PackageCode, LocalKey, LocalIV), AES_encrypt(Subject & PackageCode, LocalKey, LocalIV), AES_encrypt(Key & PackageCode, LocalKey, LocalIV), AES_encrypt(DefaultV, LocalKey, LocalIV)), LocalKey, LocalIV)

        If temp = Nothing Then
            Return DefaultV
        End If

        Return temp
    End Function

    Public Sub set_setting(ByVal Key As String, ByVal Value As Object)
        Dim Subject As String = "Saze808Lock"
        SaveSetting(AES_encrypt(Application.ProductName & PackageCode, LocalKey, LocalIV), AES_encrypt(Subject & PackageCode, LocalKey, LocalIV), AES_encrypt(Key & PackageCode, LocalKey, LocalIV), AES_encrypt(Value, LocalKey, LocalIV))
    End Sub

    Public Function AES_encrypt(Input As String, Optional key As String = "", Optional iv As String = "") As String
        Dim aes As RijndaelManaged = New RijndaelManaged()
        aes.KeySize = 256
        aes.BlockSize = 256
        aes.Padding = PaddingMode.PKCS7
        If key = "" Or iv = "" Then
            aes.Key = Encoding.UTF8.GetBytes(PHPConKey)
            aes.IV = Encoding.UTF8.GetBytes(PHPConIV)
        Else
            aes.Key = Encoding.UTF8.GetBytes(key)
            aes.IV = Encoding.UTF8.GetBytes(iv)
        End If

        Dim encrypt As ICryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV)
        Dim xBuff As Byte() = Nothing
        Using ms As MemoryStream = New MemoryStream()
            Using cs As CryptoStream = New CryptoStream(ms, encrypt, CryptoStreamMode.Write)
                Dim xXml As Byte() = Encoding.UTF8.GetBytes(Input)
                cs.Write(xXml, 0, xXml.Length)
            End Using

            xBuff = ms.ToArray()
        End Using

        Dim Output As String = Convert.ToBase64String(xBuff)
        Return Output
    End Function

    Public Function AES_decrypt(Input As String, Optional key As String = "", Optional iv As String = "") As String
        Dim aes As New RijndaelManaged()
        aes.KeySize = 256
        aes.BlockSize = 256
        aes.Mode = CipherMode.CBC
        aes.Padding = PaddingMode.PKCS7
        If key = "" Or iv = "" Then
            aes.Key = Encoding.UTF8.GetBytes(PHPConKey)
            aes.IV = Encoding.UTF8.GetBytes(PHPConIV)
        Else
            aes.Key = Encoding.UTF8.GetBytes(key)
            aes.IV = Encoding.UTF8.GetBytes(iv)
        End If

        Dim decrypt As ICryptoTransform = aes.CreateDecryptor()
        Dim xBuff As Byte() = Nothing
        Try
            Using ms As MemoryStream = New MemoryStream()
                Using cs As CryptoStream = New CryptoStream(ms, decrypt, CryptoStreamMode.Write)
                    Dim xXml As Byte() = Convert.FromBase64String(Input)
                    cs.Write(xXml, 0, xXml.Length)
                End Using

                xBuff = ms.ToArray()
            End Using
        Catch

        End Try
        Dim Output As String = Encoding.UTF8.GetString(xBuff)
        Return Output
    End Function


    Public Function ServerHash(ByVal SourceText As String) As String
        Dim data1ToHash As Byte() = Encoding.UTF8.GetBytes(SourceText)
        Dim hashvalue1 As Byte() = CType(CryptoConfig.CreateFromName("MD5"), HashAlgorithm).ComputeHash(data1ToHash)
        Return Convert.ToBase64String(hashvalue1)
    End Function

    Public Function ToMD5(ByVal input As String) As String
        Using md5Hash As MD5 = MD5.Create()
            Return GetMd5Hash(md5Hash, input)
        End Using
    End Function

    Private Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))
        Dim sBuilder As New StringBuilder()
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i
        Return sBuilder.ToString()
    End Function

    Public Sub open808FileThread(ByVal viewFilePath As FileInfo, Optional ByVal player As String = "")
        Try
            Dim extension As String = viewFilePath.Extension.ToLower
            If player = "film" And extension = ".pdf" Then
                extension = ".msc"
            ElseIf player = "pdf" Or player = "" Then
                Select Case extension
                    Case ".pdf"
                        If player = "" Then
                            extension = ".msc"
                        End If
                    Case ".mp4"
                        extension = ".chm"
                    Case ".mov"
                        extension = ".chm"
                    Case ".avi"
                        extension = ".chm"
                    Case ".mpg"
                        extension = ".chm"
                    Case ".wmv"
                        extension = ".chm"
                    Case ".mp3"
                        extension = ".chm"
                    Case ".flv"
                        extension = ".chm"
                    Case ".mkv"
                        extension = ".chm"
                    Case ".bdmv"
                        extension = ".chm"
                    Case ".evo"
                        extension = ".chm"
                    Case ".hdmov"
                        extension = ".chm"
                    Case ".ogm"
                        extension = ".chm"
                    Case ".webm"
                        extension = ".chm"
                    Case Else
                End Select
            End If

            'read view file
            Dim viewFile As Byte() = CryptBytes(Encoding.UTF32.GetString(password), File.ReadAllBytes(viewFilePath.FullName), False)

            'copy bin file
            Dim filePath As String = tempDir & "\WinUpdate-KB-" & GetRandom(1, 9999999) & extension
            FileSystem.FileCopy(binDir & ToMD5(viewFilePath.Name & "^g3cV98&3sZl)$A") & ".bin", filePath)

            'replace 1218 bytes
            Using fs As New FileStream(filePath, FileMode.Open, FileAccess.ReadWrite)
                fs.Seek(0, SeekOrigin.Begin)
                fs.Write(viewFile, 0, 1218)
            End Using

            Dim proc As ProcessStartInfo = New ProcessStartInfo
            Select Case extension
                Case ".msc"
                    proc.UseShellExecute = True
                    proc.FileName = "player\book\play808.exe"
                    proc.Arguments = AES_encrypt(filePath, "JH8d*42(sF964Zc=820Di2!sF353EG#^", "@4gD348dsghFgjr$92Dk4036ksga28fH")
                Case ".chm"
                    proc.UseShellExecute = True
                    proc.FileName = "player\video\play808.exe"
                    proc.Arguments = AES_encrypt(filePath, "JH8d*42(sF964Zc=820Di2!sF353EG#^", "@4gD348dsghFgjr$92Dk4036ksga28fH")
                Case Else
                    proc.FileName = filePath
            End Select

            FrmLoadingObj.workCompleted = True
            Using exeProcess As Process = Process.Start(proc)
                exeProcess.WaitForExit()
            End Using
            File.Delete(filePath)
        Catch ee As Exception
            If ee.Message <> "Object reference not set to an instance of an object." Then
                MsgBox("خطا حین باز کردن فایل" & vbNewLine & ee.Message, MsgBoxStyle.Critical, "خطا")
            End If
        End Try

    End Sub

    'Public Function jsonSerilizer(ByVal action As Short, ByVal puid As String, ByVal serial As String, ByVal package As String, ByVal ranber As Long, Optional name As String = "", Optional email As String = "", Optional phone As String = "", Optional PackageName As String = "", Optional DataVersion As String = "", Optional version As String = "") As String
    '    Return AES_encrypt("{""action"":" & action & ",""puid"":""" & puid & """,""serial"":""" & serial & """,""name"":""" & name & """,""email"":""" & email & """,""phone"":""" & phone & """,""package"":""" & package & """,""ranber"":" & ranber & ",""packagename"":""" & PackageName & """,""dataversion"":""" & DataVersion & """,""version"":""" & version & """}")
    'End Function

    Public Function jsonSerilizer(ByVal action As Short, ByVal puid As String, ByVal serial As String, ByVal package As String, ByVal ranber As Long, Optional name As String = "", Optional email As String = "", Optional phone As String = "", Optional PackageName As String = "", Optional DataVersion As String = "", Optional version As String = "") As String
        Return "{""action"":" & action & ",""puid"":""" & puid & """,""serial"":""" & serial & """,""name"":""" & name & """,""email"":""" & email & """,""phone"":""" & phone & """,""package"":""" & package & """,""ranber"":" & ranber & ",""packagename"":""" & PackageName & """,""dataversion"":""" & DataVersion & """,""version"":""" & version & """}"
    End Function

    Public Function importJson(ByVal input As String) As jsonStructure
        Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return jss.Deserialize(Of jsonStructure)(AES_decrypt(input))
    End Function

    Public Sub initilizeClose()
        Threading.Thread.Sleep(10)
        If FrmsOpenCount <= 1 Then
            On Error Resume Next
            If IsProcessRunning("play808") Then
                killProcess("play808")
            End If
            FileIO.FileSystem.DeleteDirectory(tempDir, FileIO.DeleteDirectoryOption.DeleteAllContents)
            set_setting("tempdir", "")
            Application.Exit()
        End If
    End Sub

    Public Function folderCheksum(path As String) As String
        Dim finalStr As String = ""
        Dim files() As String = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
        Array.Sort(files)

        For Each filename As String In files
            finalStr &= System.IO.Path.GetFileNameWithoutExtension(filename.ToLower())
        Next

        Return ToMD5(AES_encrypt(finalStr))
    End Function

End Module
