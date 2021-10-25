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
        AddToInstallerLog("StepD", "Step D Iniciado! " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), False)
        If AppLanguage = 1 Then
            Idioma.Forms.Cuatro.OnLoad.ESP()
        Else
            Idioma.Forms.Cuatro.OnLoad.ENG()
        End If
        Idioma.Forms.Cuatro.OnLoad.AfterLoad()
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
        UserClose = False
        If ReinstallMode = False Then
            If UpdateMode = False Then
                StepE.SetStatus("Instalación finalizada correctamente.", 1)
            Else
                StepE.SetStatus("Actualización finalizada correctamente.", 1)
            End If
        Else
            StepE.SetStatus("Reinstalación finalizada correctamente.", 1)
        End If
        SecureFormClose(StepE, Me)
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
        AddToInstallerLog("StepD", "Comenzo la descarga del paquete de instalacion...", False)
        Try
            Timer_StartDownload.Stop()
            Timer_StartDownload.Enabled = False
            btnNext.Enabled = False
            DownloaderURI = New Uri(AppStatus.Installer_BinDownload)
            DownloaderArray.DownloadFileAsync(DownloaderURI, zippedFilePath)
        Catch ex As Exception
            AddToInstallerLog("StartDownloadPacket@StepD", "Error: " & ex.Message, True)
            CriticalError(Me, ex.Message)
        End Try
    End Sub

    Private Sub DownloaderArray_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles DownloaderArray.DownloadFileCompleted
        FinishedDownload()
    End Sub

    Sub FinishedDownload()
        AddToInstallerLog("StepD", "Finalizo la descarga del paquete de instalacion.", False)
        Try
            btnNext.Enabled = False
            btnExit.Enabled = False
            ProgressBar1.Value = 100
            btnNext.Text = "Instalando..."
            'DEFINE DONDE SE INSTALARA
            WhereDoIInstall()
            'EXTRAER LOS DATOS PARA LA INSTALACION
            UnZipPacket()
            'COPIAR LO DESCOMPRIMIDO A LA CARPETA DE INSTALACION
            CopyToInstallFolder()
            'CREACION DEL POST-INSTALACION
            CreatePostInstallFiles()
            'CREACION DEL REGISTRO
            CreateInstallRegistry()
            'APLICAR OPCIONES DEL INSTRUCTIVO
            ApplyInstructiveOptions()
            'TERMINANDO....
            btnNext.Text = "Siguiente >"
            btnNext.Enabled = True
        Catch ex As Exception
            AddToInstallerLog("FinishedDownload@StepD", "Error: " & ex.Message, True)
            CriticalError(Me, ex.Message)
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

    Sub WhereDoIInstall()
        AddToInstallerLog("StepD", "Indicando las rutas y registros para la instalacion...", False)
        Try
            Dim x32bits As String = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" & AssemblyName
            Dim x64x32bits As String = "SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" & AssemblyName
            Dim x64bits As String = x32bits
            Dim UbicacionFinal As String = Nothing
            Dim EsProgramFiles As Boolean = True
            Dim RegistroFinal As String = Nothing
            Dim RegistradorInstalacion As RegistryKey = Nothing

            'PARA DISCRIMINAR DONDE SE INSTALARA (%username% O %programfiles%)
            If Installer_InstallFolder.Contains("%username%") Then
                EsProgramFiles = False
                Installer_InstallFolder = Installer_InstallFolder.Replace("%username%", Environment.UserName)
            ElseIf Installer_InstallFolder.Contains("%programfiles%") Then
                EsProgramFiles = True
                Installer_InstallFolder = Installer_InstallFolder.Replace("%programfiles%", Nothing)
            End If

            'SE VE LA ARQUITECTURA DEL PC Y LA DEL PROGRAMA
            If ProcessorArch = 32 And Installer_BitArch = 32 Then 'PC = 32, PROGRAMA = 32
                UbicacionFinal = "C:\Program Files" & Installer_InstallFolder
                RegistroFinal = x32bits
            ElseIf ProcessorArch = 64 And Installer_BitArch = 32 Then 'PC = 64, PROGRAMA = 32
                UbicacionFinal = "C:\Program Files (x86)" & Installer_InstallFolder
                RegistroFinal = x64x32bits
            ElseIf ProcessorArch = 32 And Installer_BitArch = 64 Then 'PC = 32, PROGRAMA = 64
                'UPA. NO SE PUEDE INSTALAR.
                If isSilenced = False Then
                    MsgBox("El programa por instalar requiere de un Sistema Operativo y un Procesador de 64bits y no de 32bits", MsgBoxStyle.Critical, "No se puede instalar")
                    End 'END_PROGRAM
                End If
            ElseIf ProcessorArch = 64 And Installer_BitArch = 64 Then 'PC = 64, PROGRAMA = 64
                UbicacionFinal = "C:\Program Files" & Installer_InstallFolder
                RegistroFinal = x64bits
            End If

            'VE SI EL PROGRAMA ESTARA INSTALADO A NIVEL MAQUINA O A NIVEL USUARIO.
            If EsProgramFiles = True Then
                'SoftwareInstalledMode = 0
                InstallFolder = UbicacionFinal
            Else
                'SoftwareInstalledMode = 1
                InstallFolder = Installer_InstallFolder
            End If
            InstallerRegistry = RegistroFinal
            AddToInstallerLog("StepD", "Instalacion en: " & InstallFolder & " Registrar en: " & InstallerRegistry, False)
        Catch ex As Exception
            AddToInstallerLog("WhereDoIInstall@StepD", "Error: " & ex.Message, True)
            CriticalError(Me, ex.Message)
        End Try
    End Sub
    Sub UnZipPacket()
        AddToInstallerLog("StepD", "Extrayendo datos del paquete de instalacion a carpeta temporal...", False)
        Try
            'SI EXISTE extractFolderPath, ENTONCES SE ELIMINA Y SE CREA, SI NO EXISTE, SE CREA.
            If My.Computer.FileSystem.DirectoryExists(extractFolderPath) = True Then
                My.Computer.FileSystem.DeleteDirectory(extractFolderPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
                AddToInstallerLog("StepD", "Se ha eliminado el directorio de instalacion final.", False)
            End If
            My.Computer.FileSystem.CreateDirectory(extractFolderPath)
            AddToInstallerLog("StepD", "Se ha creado el directorio de instalacion final.", False)

            'DESCOMPRIME
            ZipFile.ExtractToDirectory(zippedFilePath, extractFolderPath)
            AddToInstallerLog("StepD", "Se han extraido los datos del paquete de instalacion a la carpeta temporal.", False)
        Catch ex As Exception
            AddToInstallerLog("UnZipPacket@StepD", "Error: " & ex.Message, True)
            CriticalError(Me, ex.Message)
        End Try
    End Sub
    Sub CopyToInstallFolder()
        AddToInstallerLog("StepD", "Copiando datos de la carpeta temporal a ubicacion final de instalacion...", False)
        Try
            'SI EXISTE InstallFolder, ENTONCES SE ELIMINA Y SE CREA, SI NO EXISTE, SE CREA.
            If My.Computer.FileSystem.DirectoryExists(InstallFolder) = True Then
                My.Computer.FileSystem.DeleteDirectory(InstallFolder, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
            My.Computer.FileSystem.CreateDirectory(InstallFolder)
            'COPIA LOS DATOS A LA CARPETA InstallFolder
            My.Computer.FileSystem.CopyDirectory(extractFolderPath, InstallFolder, True)
        Catch ex As Exception
            AddToInstallerLog("CopyToInstallFolder@StepD", "Error: " & ex.Message, True)
            CriticalError(Me, ex.Message)
        End Try
    End Sub
    Sub CreatePostInstallFiles()
        AddToInstallerLog("StepD", "Creando archivos Post-Instalacion...", False)
        Try
            'CREACION DE LA CARPETA Program EN EL MENU DE WINDOWS SI NO EXISTE.
            If My.Computer.FileSystem.DirectoryExists(Environment.GetFolderPath(Environment.SpecialFolder.Programs) & "\Worcome Studios\Worcome Apps\" & AssemblyPackageName) = False Then
                My.Computer.FileSystem.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Programs) & "\Worcome Studios\Worcome Apps\" & AssemblyPackageName)
                AddToInstallerLog("StepD", "Se ha creado el directorio comun para aplicaciones.", False)
            End If
            'ELIMINACION DEL ACCESO DIRECTO DE Program SI EXISTE.
            If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.Programs) & "\Worcome Studios\Worcome Apps\" & AssemblyPackageName & "\" & AssemblyName & ".lnk") = True Then
                My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Programs) & "\Worcome Studios\Worcome Apps\" & AssemblyPackageName & "\" & AssemblyName & ".lnk")
                AddToInstallerLog("StepD", "Se ha eliminado el acceso directo del directorio comun para aplicaciones.", False)
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
            AddToInstallerLog("StepD", "Se ha creado el acceso directo del directorio comun para aplicaciones.", False)
            'CREACION DEL ASISTENTE POST-INSTALACION
            If My.Computer.FileSystem.FileExists(InstallFolder & "\uninstall.exe") = True Then
                My.Computer.FileSystem.DeleteFile(InstallFolder & "\uninstall.exe")
                AddToInstallerLog("StepD", "Se ha eliminado el asistente Post-Instalacion.", False)
            End If
            My.Computer.FileSystem.CopyFile(Application.ExecutablePath, InstallFolder & "\uninstall.exe")
            AddToInstallerLog("StepD", "Se ha creado el asistente Post-Instalacion.", False)
        Catch ex As Exception
            AddToInstallerLog("CreatePresence@StepD", "Error: " & ex.Message, True)
            CriticalError(Me, ex.Message)
        End Try
    End Sub
    Sub CreateInstallRegistry()
        AddToInstallerLog("StepD", "Registrando la instalacion...", False)
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
                AddToInstallerLog("StepD", "Se ha escrito en el registro: " & AppServiceRegWriter.ToString, False)
            Catch ex As Exception
                AddToInstallerLog("CreateInstallRegistry(1)@StepD", "Error: " & ex.Message, True)
                CriticalError(Me, ex.Message)
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
                InstallDataRegWriter.SetValue("AllUsersCanUse", AllUsersInstall & ";" & Environment.UserName, RegistryValueKind.String)
                InstallDataRegWriter.SetValue("Assembly Path", InstallFolder & "\" & AssemblyName & ".exe", RegistryValueKind.String)
                InstallDataRegWriter.SetValue("Install Registry", InstallerRegistry, RegistryValueKind.String)
                AddToInstallerLog("StepD", "Se ha escrito en el registro: " & InstallDataRegWriter.ToString, False)
            Catch ex As Exception
                AddToInstallerLog("CreateInstallRegistry(2)@StepD", "Error: " & ex.Message, True)
                CriticalError(Me, ex.Message)
            End Try
            Try
                'CREACION DEL REGISTRO DE INSTALACION.
                Dim InstallRegWriter As RegistryKey = Nothing
                If SoftwareInstalledMode = 0 Then
                    InstallRegWriter = Registry.LocalMachine.OpenSubKey(InstallerRegistry, True)
                ElseIf SoftwareInstalledMode = 1 Then
                    InstallRegWriter = Registry.CurrentUser.OpenSubKey(InstallerRegistry, True)
                End If
                'CREA EL REGISTRO DE NO EXISTIR. ADEMAS INDICA DONDE SE ESCRIBIRA EL REGISTRO DE INSTALACION (Maquina o Usuario)
                If InstallRegWriter Is Nothing Then
                    If SoftwareInstalledMode = 0 Then
                        Registry.LocalMachine.CreateSubKey(InstallerRegistry)
                        InstallRegWriter = Registry.LocalMachine.OpenSubKey(InstallerRegistry, True)
                    ElseIf SoftwareInstalledMode = 1 Then
                        Registry.CurrentUser.CreateSubKey(InstallerRegistry)
                        InstallRegWriter = Registry.CurrentUser.OpenSubKey(InstallerRegistry, True)
                    End If
                End If
                InstallRegWriter.SetValue("InstallDate", DateTime.Now.ToString("dd/MM/yyyy"), RegistryValueKind.String)
                InstallRegWriter.SetValue("InstallLocation", InstallFolder, RegistryValueKind.ExpandString)
                InstallRegWriter.SetValue("Size", FormatBytes(PackageSize, True), RegistryValueKind.String)
                InstallRegWriter.SetValue("Comments", AssemblyName & " Official Software", RegistryValueKind.String)
                InstallRegWriter.SetValue("DisplayIcon", InstallFolder & "\" & AssemblyName & ".exe", RegistryValueKind.String)
                InstallRegWriter.SetValue("DisplayName", AssemblyName, RegistryValueKind.String)
                InstallRegWriter.SetValue("DisplayVersion", AppStatus.Assembly_Version, RegistryValueKind.String)
                InstallRegWriter.SetValue("HelpLink", ServerSwitch.DIR_AppHelper & "/" & AssemblyName & ".html", RegistryValueKind.String)
                InstallRegWriter.SetValue("Publisher", "Worcome Studios", RegistryValueKind.String)
                InstallRegWriter.SetValue("Contact", ServerSwitch.SW_UsingServer & "/Contacto.html", RegistryValueKind.String)
                InstallRegWriter.SetValue("Readme", ServerSwitch.SW_UsingServer & "/readme.html", RegistryValueKind.String)
                InstallRegWriter.SetValue("URLInfoAbout", ServerSwitch.DIR_AppHelper & "/AboutApps/" & AssemblyName & ".html", RegistryValueKind.String)
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
                AddToInstallerLog("StepD", "Se ha escrito en el registro: " & InstallRegWriter.ToString, False)
            Catch ex As Exception
                AddToInstallerLog("CreateInstallRegistry(3)@StepD", "Error: " & ex.Message, True)
                CriticalError(Me, ex.Message)
            End Try
        Catch ex As Exception
            AddToInstallerLog("CreateInstallRegistry(4)@StepD", "Error: " & ex.Message, True)
            CriticalError(Me, ex.Message)
        End Try
    End Sub
    Sub ApplyInstructiveOptions()
        AddToInstallerLog("StepD", "Aplicando las opciones del instructivo...", False)
        Try
            If AppStatus.Installer_NeedElevateAccess Then
                Dim REGISTRADOR As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", True)
                REGISTRADOR.SetValue(InstallFolder & "\" & AssemblyName & ".exe", "RUNASADMIN", RegistryValueKind.String)
                AddToInstallerLog("StepD", "Creado el registro para iniciar con permisos de administrador.", False)
            End If
            If Installer_NeedStartUp.StartsWith("True") Then
                Dim REGISTRADOR As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", True)
                If Installer_NeedStartUp.Contains(";") Then
                    If REGISTRADOR Is Nothing Then
                        Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run")
                    End If
                    Dim Args() As String = Installer_NeedStartUp.Split(";")
                    If Args(1) = "NULL" Then
                        REGISTRADOR.SetValue(AssemblyName, """" & InstallFolder & "\" & AssemblyName & ".exe" & """", RegistryValueKind.ExpandString)
                    Else
                        REGISTRADOR.SetValue(AssemblyName, """" & InstallFolder & "\" & AssemblyName & ".exe" & """" & " " & Args(1), RegistryValueKind.ExpandString)
                    End If
                Else
                    REGISTRADOR.SetValue(AssemblyName, InstallFolder & "\" & AssemblyName & ".exe", RegistryValueKind.ExpandString)
                End If
                AddToInstallerLog("StepD", "Creado el registro para iniciar con Windows.", False)
            End If
        Catch ex As Exception
            AddToInstallerLog("ApplyInstructiveOptions@StepD", "Error: " & ex.Message, True)
            CriticalError(Me, ex.Message)
        End Try
    End Sub
End Class