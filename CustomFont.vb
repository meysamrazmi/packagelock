'Imports System.Drawing.Text
'Imports System.Runtime.InteropServices

'Module CustomFont
'    <DllImport("gdi32")>
'    Public Function AddFontResource(ByVal lpFileName As String) As Integer
'    End Function
'    <DllImport("user32.dll")>
'    Public Function SendMessage(ByVal hWnd As Integer, ByVal Msg As UInteger, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
'    End Function
'    <DllImport("kernel32.dll", SetLastError:=True)>
'    Public Function WriteProfileString(ByVal lpszSection As String, ByVal lpszKeyName As String, ByVal lpszString As String) As Integer
'    End Function
'    'PRIVATE FONT COLLECTION TO HOLD THE DYNAMIC FONT
'    Private _pfc As PrivateFontCollection = Nothing
'    Public ReadOnly Property GetInstance(ByVal Size As Single, ByVal style As FontStyle) As Font
'        Get
'            'IF THIS IS THE FIRST TIME GETTING AN INSTANCE
'            'LOAD THE FONT FROM RESOURCES
'            If _pfc Is Nothing Then LoadFont()

'            'RETURN A NEW FONT OBJECT BASED ON THE SIZE AND STYLE PASSED IN
'            Return New Font(_pfc.Families(0), Size, style) ',Style
'        End Get
'    End Property
'    Private Sub LoadFont()
'        Try
'            'INIT THE FONT COLLECTION
'            _pfc = New PrivateFontCollection
'            'LOAD MEMORY POINTER FOR FONT RESOURCE
'            Dim fontMemPointer As IntPtr = Marshal.AllocCoTaskMem(My.Resources.IRANSans.Length)
'            'COPY THE DATA TO THE MEMORY LOCATION
'            Marshal.Copy(My.Resources.IRANSans, 0, fontMemPointer, My.Resources.IRANSans.Length)
'            'LOAD THE MEMORY FONT INTO THE PRIVATE FONT COLLECTION
'            _pfc.AddMemoryFont(fontMemPointer, My.Resources.IRANSans.Length)
'            'FREE UNSAFE MEMORY
'            Marshal.FreeCoTaskMem(fontMemPointer)
'        Catch ex As Exception
'            'ERROR LOADING FONT. HANDLE EXCEPTION HERE
'        End Try
'    End Sub
'    Public Function IsFontInstalled(ByVal font As String) As Boolean
'        Dim FontCollection As FontCollection = New InstalledFontCollection
'        Dim Result As Boolean = False
'        Dim a As FontFamily
'        For Each a In FontCollection.Families
'            If a.Name = font Then
'                Result = True
'            End If
'        Next
'        Return Result
'    End Function
'End Module

'MATTHEW KLEINWAKS
'ZerosAndTheOne.com
'2009
'CUSTOM FONT LOADED DYNAMICALLY FROM A RESOURCE

Imports System.Drawing.Text
Imports System.Runtime.InteropServices

Module CustomFont

    'PRIVATE FONT COLLECTION TO HOLD THE DYNAMIC FONT
    Private _pfc As PrivateFontCollection = Nothing


    Public ReadOnly Property GetInstance(ByVal Size As Single, ByVal style As FontStyle) As Font
        Get
            'IF THIS IS THE FIRST TIME GETTING AN INSTANCE
            'LOAD THE FONT FROM RESOURCES
            If _pfc Is Nothing Then LoadFont()

            'RETURN A NEW FONT OBJECT BASED ON THE SIZE AND STYLE PASSED IN
            Return New Font(_pfc.Families(0), Size, style)

        End Get
    End Property

    Private Sub LoadFont()
        Try
            'INIT THE FONT COLLECTION
            _pfc = New PrivateFontCollection

            'LOAD MEMORY POINTER FOR FONT RESOURCE
            Dim fontMemPointer As IntPtr = Marshal.AllocCoTaskMem(My.Resources.iran.Length)

            'COPY THE DATA TO THE MEMORY LOCATION
            Marshal.Copy(My.Resources.iran, 0, fontMemPointer, My.Resources.iran.Length)

            'LOAD THE MEMORY FONT INTO THE PRIVATE FONT COLLECTION
            _pfc.AddMemoryFont(fontMemPointer, My.Resources.iran.Length)

            'FREE UNSAFE MEMORY
            Marshal.FreeCoTaskMem(fontMemPointer)
        Catch ee As Exception
            MsgBox("خطای نامعلوم" & vbNewLine & ee.Message, MsgBoxStyle.Critical, "")
        End Try

    End Sub

End Module
