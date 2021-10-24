Imports System.ComponentModel
Imports System.IO.Compression
Imports System.Net
Imports Microsoft.Win32

Public Class StepD 'Instalador / Installer / FOUR
    Public UserClose As Boolean = True

    Public shObj As Object = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"))
    Dim DownloaderURI As Uri
    Dim WithEvents DownloaderArray As New Net.WebClient

    Private Sub StepD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If AppImageLocation IsNot Nothing Then
            PIC_IMG_Icon.ImageLocation = AppImageLocation
        End If
        LoadData()
    End Sub
    Private Sub StepD_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If UserClose Then
            UserClose = False
            AbortInstallProcess(Me, "El usuario cerro la ventana de Instalacion")
            'End 'END_PROGRAM
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Continuar()
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Salir()
    End Sub

    Sub Continuar()

    End Sub

    Sub Salir()
        Try
            UserClose = False
            AbortInstallProcess(Me, "El usuario salio de la ventana de Instalacion")
        Catch ex As Exception
            AddToInstallerLog("Salir@StepD", "Error: " & ex.Message, False)
        End Try
    End Sub

    Private Sub btnRetry_Click(sender As Object, e As EventArgs) Handles btnRetry.Click

    End Sub

    Sub LoadData()
        Try
            WebBrowser1.Visible = True
            WebBrowser1.Navigate(New Uri(ServerSwitch.SW_UsingServer & "/WorInstallerCarousel.html"))
        Catch ex As Exception
            AddToInstallerLog("LoadData@StepD", "Error: " & ex.Message, False)
        End Try
    End Sub

    Private Sub Timer_StartDownload_Tick(sender As Object, e As EventArgs) Handles Timer_StartDownload.Tick
        StartDownloadPacket()
    End Sub

    Sub StartDownloadPacket()
        Try
            Timer_StartDownload.Stop()
            Timer_StartDownload.Enabled = False
            btnNext.Enabled = False
            btnNext.Text = "Downloading..."

            DownloaderURI = New Uri(AppStatus.Installer_BinDownload)
            DownloaderArray.DownloadFileAsync(DownloaderURI, zippedFilePath)
        Catch ex As Exception
            AddToInstallerLog("StartDownloadPacket@StepD", "Error: " & ex.Message, False)
        End Try
    End Sub

    Private Sub DownloaderArray_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles DownloaderArray.DownloadFileCompleted
        FinishedDownload()
    End Sub

    Sub FinishedDownload()
        Try
            btnNext.Enabled = False
            btnExit.Enabled = False
            ProgressBar1.Value = 100
            btnNext.Text = "Instalando..."
            'EXTRAER LOS DATOS PARA LA INSTALACION
            UnZipPacket()
            'COPIAR LO DESCOMPRIMIDO A LA CARPETA DE INSTALACION
            CopyToInstallFolder()
            'CREACION DEL POST-INSTALACION
            CreatePostInstallFiles()
            'CREACION DEL REGISTRO
            CreateInstallRegistry()
            'TERMINANDO....
            btnNext.Text = "Siguiente >"
            btnNext.Enabled = True
        Catch ex As Exception
            AddToInstallerLog("FinishedDownload@StepD", "Error: " & ex.Message, False)
        End Try
    End Sub
    Private Sub DownloaderArray_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles DownloaderArray.DownloadProgressChanged
        Try
            Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
            Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
            Dim percentage As Double = bytesIn / totalBytes * 100
            Label4.Text = CStr(e.ProgressPercentage & ("%")) & vbCrLf & FormatBytes(bytesIn, True) & "/" & FormatBytes(totalBytes, True)
            ProgressBar1.Value = e.ProgressPercentage
            PackageSize = e.TotalBytesToReceive
        Catch ex As Exception
            AddToInstallerLog("DownloaderArray_DownloadProgressChanged(1)@StepD", "Error: " & ex.Message, False)
        End Try
        Try
            TaskbarProgress.SetValue(Me.Handle, e.ProgressPercentage.ToString(), 100)
        Catch ex As Exception
            AddToInstallerLog("DownloaderArray_DownloadProgressChanged(2)@StepD", "Error: " & ex.Message, False)
        End Try
    End Sub

    Sub UnZipPacket()
        Try
            'SI EXISTE extractFolderPath, ENTONCES SE ELIMINA Y SE CREA, SI NO EXISTE, SE CREA.
            If My.Computer.FileSystem.DirectoryExists(extractFolderPath) = True Then
                My.Computer.FileSystem.DeleteDirectory(extractFolderPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
            My.Computer.FileSystem.CreateDirectory(extractFolderPath)

            'DESCOMPRIME
            ZipFile.ExtractToDirectory(zippedFilePath, extractFolderPath)
        Catch ex As Exception
            AddToInstallerLog("UnZipPacket@StepD", "Error: " & ex.Message, False)
        End Try
    End Sub
    Sub CopyToInstallFolder()
        Try
            'SI EXISTE InstallFolder, ENTONCES SE ELIMINA Y SE CREA, SI NO EXISTE, SE CREA.
            If My.Computer.FileSystem.DirectoryExists(InstallFolder) = True Then
                My.Computer.FileSystem.DeleteDirectory(InstallFolder, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
            My.Computer.FileSystem.CreateDirectory(InstallFolder)
            'COPIA LOS DATOS A LA CARPETA InstallFolder
            My.Computer.FileSystem.CopyDirectory(extractFolderPath, InstallFolder, True)
        Catch ex As Exception
            AddToInstallerLog("CopyToInstallFolder@StepD", "Error: " & ex.Message, False)
        End Try
    End Sub
    Sub CreatePostInstallFiles()
        Try
            'CREACION DE LA CARPETA Program EN EL MENU DE WINDOWS SI NO EXISTE.
            If My.Computer.FileSystem.DirectoryExists(Environment.GetFolderPath(Environment.SpecialFolder.Programs) & "\Worcome Studios\Worcome Apps\" & AssemblyPackageName) = False Then
                My.Computer.FileSystem.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Programs) & "\Worcome Studios\Worcome Apps\" & AssemblyPackageName)
            End If
            'ELIMINACION DEL ACCESO DIRECTO DE Program SI EXISTE.
            If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.Programs) & "\Worcome Studios\Worcome Apps\" & AssemblyPackageName & "\" & AssemblyName & ".lnk") = True Then
                My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Programs) & "\Worcome Studios\Worcome Apps\" & AssemblyPackageName & "\" & AssemblyName & ".lnk")
            End If
            'CREACION DEL ACCESO DIRECTO PARA Program.
            Dim WSHShell As Object = CreateObject("WScript.Shell")
            Dim Shortcut As Object
            Shortcut = WSHShell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Programs) & "\Worcome Studios\Worcome Apps\" & AssemblyPackageName & "\" & AssemblyName & ".lnk")
            Shortcut.IconLocation = InstallFolder & "\" & AssemblyName & ".exe" & ",0"
            Shortcut.TargetPath = InstallFolder & "\" & AssemblyName & ".exe"
            Shortcut.WindowStyle = 1
            Shortcut.Description = "Run " & AssemblyPackageName
            Shortcut.Save()
            'CREACION DEL ASISTENTE POST-INSTALACION
            If My.Computer.FileSystem.FileExists(InstallFolder & "\uninstall.exe") = True Then
                My.Computer.FileSystem.DeleteFile(InstallFolder & "\uninstall.exe")
            End If
            My.Computer.FileSystem.CopyFile(Application.ExecutablePath, InstallFolder & "\uninstall.exe")
        Catch ex As Exception
            AddToInstallerLog("CreatePresence@StepD", "Error: " & ex.Message, False)
        End Try
    End Sub
    Sub CreateInstallRegistry()
        Try
            Try
                'CREACION DEL REGISTRO PARA COMPATILIBILIDAD WorSupport>AppService>SignRegistry Y WorApps Y OTROS A NIVEL USUARIO.
                Dim AppServiceRegWriter As RegistryKey
                AppServiceRegWriter = Registry.CurrentUser.OpenSubKey("Software\\Worcome_Studios\\" & AssemblyName, True)
                If AppServiceRegWriter Is Nothing Then
                    Registry.CurrentUser.CreateSubKey("Software\\Worcome_Studios\\" & AssemblyName)
                    AppServiceRegWriter = Registry.CurrentUser.OpenSubKey("Software\\Worcome_Studios\\" & AssemblyName, True)
                End If
                AppServiceRegWriter.SetValue("Assembly", AssemblyName, RegistryValueKind.String)
                AppServiceRegWriter.SetValue("Version", AppStatus.Assembly_Version, RegistryValueKind.String)
                AppServiceRegWriter.SetValue("Installed Date", DateAndTime.Today & " @ " & Format(DateAndTime.TimeOfDay, "hh") & ":" & Format(DateAndTime.TimeOfDay, "mm") & ":" & Format(DateAndTime.TimeOfDay, "ss") & ":" & Format(DateAndTime.TimeOfDay, "tt"), RegistryValueKind.String)
                AppServiceRegWriter.SetValue("Last Start", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), RegistryValueKind.String)
                AppServiceRegWriter.SetValue("Directory", InstallFolder, RegistryValueKind.String)
                AppServiceRegWriter.SetValue("AllUsersCanUse", AllUsersInstall & ":" & Environment.UserName, RegistryValueKind.String)
                AppServiceRegWriter.SetValue("Assembly Path", InstallFolder & "\" & AssemblyName & ".exe", RegistryValueKind.String)
            Catch ex As Exception
                AddToInstallerLog("CreateInstallRegistry(1)@StepD", "Error: " & ex.Message, False)
            End Try
            Try
                'CREACION DEL REGISTRO PARA COMPATIBILIDAD  WorSupport>AppService>SignRegistry Y WorApps Y OTROS A NIVEL MAQUINA.
                Dim InstallDataRegWriter As RegistryKey
                InstallDataRegWriter = Registry.LocalMachine.OpenSubKey("Software\\Worcome_Studios\\" & AssemblyName, True)
                If InstallDataRegWriter Is Nothing Then
                    Registry.LocalMachine.CreateSubKey("Software\\Worcome_Studios\\" & AssemblyName)
                    InstallDataRegWriter = Registry.LocalMachine.OpenSubKey("Software\\Worcome_Studios\\" & AssemblyName, True)
                End If
                InstallDataRegWriter = Registry.LocalMachine.OpenSubKey("Software\\Worcome_Studios\\" & AssemblyName, True)
                InstallDataRegWriter.SetValue("Assembly", AssemblyName, RegistryValueKind.String)
                InstallDataRegWriter.SetValue("Version", AppStatus.Assembly_Version, RegistryValueKind.String)
                InstallDataRegWriter.SetValue("Installed Date", DateAndTime.Today & " @ " & Format(DateAndTime.TimeOfDay, "hh") & ":" & Format(DateAndTime.TimeOfDay, "mm") & ":" & Format(DateAndTime.TimeOfDay, "ss") & ":" & Format(DateAndTime.TimeOfDay, "tt"), RegistryValueKind.String)
                InstallDataRegWriter.SetValue("Last Start", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), RegistryValueKind.String)
                InstallDataRegWriter.SetValue("Directory", InstallFolder, RegistryValueKind.String)
                InstallDataRegWriter.SetValue("AllUserCanUse", AllUsersInstall & ";" & Environment.UserName, RegistryValueKind.String)
                InstallDataRegWriter.SetValue("Assembly Path", InstallFolder & "\" & AssemblyName & ".exe", RegistryValueKind.String)
            Catch ex As Exception
                AddToInstallerLog("CreateInstallRegistry(2)@StepD", "Error: " & ex.Message, False)
            End Try
            Try
                'CREACION DEL REGISTRO DE INSTALACION.
                Dim x32bits As String = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" & AssemblyName
                Dim x64x32bits As String = "SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" & AssemblyName
                Dim InstallRegWriter As RegistryKey = Registry.LocalMachine.OpenSubKey(x32bits, True)
                If ProcessorArch = "32" Then
                    If InstallRegWriter Is Nothing Then
                        Registry.LocalMachine.CreateSubKey(x32bits)
                    End If
                    InstallRegWriter = Registry.LocalMachine.OpenSubKey(x32bits, True)
                ElseIf ProcessorArch = "64" Then
                    If InstallRegWriter Is Nothing Then
                        Registry.LocalMachine.CreateSubKey(x64x32bits)
                    End If
                    InstallRegWriter = Registry.LocalMachine.OpenSubKey(x64x32bits, True)
                Else
                    If InstallRegWriter Is Nothing Then
                        Registry.LocalMachine.CreateSubKey(x32bits)
                    End If
                    InstallRegWriter = Registry.LocalMachine.OpenSubKey(x32bits, True)
                End If
                InstallRegWriter.SetValue("InstallDate", DateTime.Now.ToString("dd/MM/yyyy"), RegistryValueKind.String)
                InstallRegWriter.SetValue("InstallLocation", InstallFolder, RegistryValueKind.ExpandString)
                InstallRegWriter.SetValue("Size", FormatBytes(PackageSize, True), RegistryValueKind.String)
                InstallRegWriter.SetValue("Comments", AssemblyName & " Official Software", RegistryValueKind.String)
                InstallRegWriter.SetValue("DisplayIcon", InstallFolder & "\" & AssemblyName & ".exe", RegistryValueKind.String)
                InstallRegWriter.SetValue("DisplayName", AssemblyName, RegistryValueKind.String)
                InstallRegWriter.SetValue("DisplayVersion", AppStatus.Assembly_Version, RegistryValueKind.String)
                InstallRegWriter.SetValue("HelpLink", AppService.DIR_AppHelper & "/" & AssemblyName & ".html", RegistryValueKind.String)
                InstallRegWriter.SetValue("Publisher", "Worcome Studios", RegistryValueKind.String)
                InstallRegWriter.SetValue("Contact", ServerSwitch.SW_UsingServer & "/Contacto.html", RegistryValueKind.String)
                InstallRegWriter.SetValue("Readme", ServerSwitch.SW_UsingServer & "/readme.html", RegistryValueKind.String)
                InstallRegWriter.SetValue("URLInfoAbout", AppService.DIR_AppHelper & "/AboutApps/" & AssemblyName & ".html", RegistryValueKind.String)
                InstallRegWriter.SetValue("URLUpdateInfo", ServerSwitch.SW_UsingServer & "/AppsAssemblyInformation.html", RegistryValueKind.String)
                Try
                    Dim TotalSizeVal As String = Val(PackageSize)
                    InstallRegWriter.SetValue("EstimatedSize", TotalSizeVal.Remove(TotalSizeVal.Length - 3), RegistryValueKind.DWord)
                Catch
                End Try
                InstallRegWriter.SetValue("ModifyPath", InstallFolder & "\uninstall.exe /Installer.Package.Set=" & AssemblyName & "," & AssemblyVersion, RegistryValueKind.ExpandString)
                InstallRegWriter.SetValue("UninstallPath", InstallFolder & "\uninstall.exe" & " /Uninstall /Installer.Package.Set=" & AssemblyName & "," & AssemblyVersion, RegistryValueKind.ExpandString)
                InstallRegWriter.SetValue("UninstallString", """" & InstallFolder & "\uninstall.exe" & """" & " /Uninstall /Installer.Package.Set=" & AssemblyName & "," & AssemblyVersion, RegistryValueKind.ExpandString)
                InstallRegWriter.SetValue("QuietUninstallString", """" & InstallFolder & "\uninstall.exe" & """" & " /S /Uninstall /Installer.Package.Set=" & AssemblyName & "," & AssemblyVersion, RegistryValueKind.String)
            Catch ex As Exception
                AddToInstallerLog("CreateInstallRegistry(3)@StepD", "Error: " & ex.Message, False)
            End Try
        Catch ex As Exception
            AddToInstallerLog("CreateInstallRegistry(4)@StepD", "Error: " & ex.Message, False)
        End Try
    End Sub
End Class