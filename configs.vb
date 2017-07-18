Imports System.Drawing.Text

Module configs

    Public PHPConKey As String = "97+2dSfE^ks!14z5qq=498JHm5"  '32 chr shared ascii string (32 * 8 = 256 bit)
    Public PHPConIV As String = "7Oh952hhe%)y67#cs!9hjv48n"  '32 chr shared ascii string (32 * 8 = 256 bit)
    Public LocalKey As String = "t8H(3dV4w!52"
    Public LocalIV As String = "O%vJ6GJv85$3"
    Public PUID As String = ""
    Public serverURI As String = ""
    Public viewMainDir As String = ""
    Public binDir As String = ""
    Public videoDetailsDir As String = ""
    Public videoDir As String = ""
    Public helpDir As String = ""
    Public tempDir As String = ""
    Public FrmsOpenCount As Short = 0

    Public FrmLoadingObj As New Loading
    Public FrmVideoObj As New FrmVideoList
    Public FrmExplorerObj As New frmExplorerLike
    Public FrmLogoObj As FrmLogo

    Public isLogoWorkComplete As Boolean = False

    Public PackageCode As String = ""
    Public CheckumBin As String = ""

End Module
