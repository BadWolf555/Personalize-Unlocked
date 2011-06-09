Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Public Class Form1
    <DllImport("user32")> _
    Public Shared Function SystemParametersInfo(ByVal uAction As Integer, _
     ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni _
     As Integer) As Integer
    End Function
    Dim key As RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Control Panel\Desktop", True)
    Const SPI_SETDESKWALLPAPER As Integer = 20
    Const SPIF_UPDATEINIFILE As Integer = &H1&
    Const SPIF_SENDWININICHANGE As Integer = &H2&
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Load(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ComboBox1.SelectedItem = "Stretch" Then
            key.SetValue("WallpaperStyle", "2")
            key.SetValue("TileWallpaper", "0")
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, OpenFileDialog1.FileName, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)
        ElseIf ComboBox1.SelectedItem = "Centre" Then
            key.SetValue("WallpaperStyle", "1")
            key.SetValue("TileWallpaper", "0")
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, OpenFileDialog1.FileName, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)
        ElseIf ComboBox1.SelectedItem = "Tile" Then
            key.SetValue("WallpaperStyle", "1")
            key.SetValue("TileWallpaper", "1")
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, OpenFileDialog1.FileName, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)
        ElseIf ComboBox1.SelectedItem = "Fill" Then
            key.SetValue("WallpaperStyle", "10")
            key.SetValue("TileWallpaper", "0")
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, OpenFileDialog1.FileName, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)
        ElseIf ComboBox1.SelectedItem = "Fit" Then
            key.SetValue("WallpaperStyle", "6")
            key.SetValue("TileWallpaper", "0")
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, OpenFileDialog1.FileName, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ComboBox1.SelectedItem = "Stretch"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        key.SetValue("WallpaperStyle", "2")
        key.SetValue("TileWallpaper", "0")
        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, "C:\Windows\Web\Wallpaper\Windows\img0.jpg", SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)
        PictureBox1.Load("C:\Windows\Web\Wallpaper\Windows\img0.jpg")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        AboutBox1.ShowDialog()
    End Sub
End Class
