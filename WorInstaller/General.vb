Imports System.IO
Imports System.IO.Compression
Imports System.Management
Imports System.Net
Imports System.Text
Imports Microsoft.Win32
Module Telemetry
    Public InstallerLogContent As String = Nothing
    Public TelemetryID As String
    Sub CreateTelemetry()
        Try
            AddToInstallerLog("TELEMETRY", "Creando telemetria...", True)
            TelemetryID = CreateIdentification("Identification")
            Dim MotherboardSerial As String = GetMotherBoardID()
            Dim CPUSerial As String = GetCpuID()
            Dim IPAddr As String = GetIPAddress()
            If My.Computer.FileSystem.FileExists(DIRCommons & "\[" & TelemetryID & "]TLM_Installer" & AssemblyName & ".tlm") Then
                My.Computer.FileSystem.DeleteFile(DIRCommons & "\[" & TelemetryID & "]TLM_Installer" & AssemblyName & ".tlm")
            End If
            AddToInstallerLog("TELEMETRY", " --- FIN DEL SERVICIO DE TELEMETRIA --- ", True)
            Dim TLM_Content As String
            TLM_Content = "#WorInstaller " & My.Application.Info.Version.ToString & " (" & Application.ProductVersion & ")" & " | " & AssemblyName & " " & AssemblyVersion & " | " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") & " | Telemetry Installer" &
                                                vbCrLf & "[Installer]" &
                                                vbCrLf & "ID=" & TelemetryID &
                                                vbCrLf & "InstallerCompilation=" & My.Application.Info.Version.ToString & ", " & Application.ProductVersion &
                                                vbCrLf & "User=" & Environment.UserName &
                                                vbCrLf & "AppLanguage=" & AppLanguage &
                                                vbCrLf & "AssemblyName=" & AssemblyName &
                                                vbCrLf & "AssemblyVersion=" & AssemblyVersion &
                                                vbCrLf & "PackageName=" & AssemblyPackageName &
                                                vbCrLf & "PackageSize=" & PackageSize &
                                                vbCrLf & "StartParametros=" & ArgCommandLine &
                                                vbCrLf & "[Parameters]" &
                                                vbCrLf & "IsSilentMode=" & isSilenced &
                                                vbCrLf & "IsForceMode=" & isForced &
                                                vbCrLf & "CanDowngrade=" & CanDowngrade &
                                                vbCrLf & "InstallMode=" & InstallMode &
                                                vbCrLf & "UpdateMode=" & UpdateMode &
                                                vbCrLf & "UninstallMode=" & UninstallMode &
                                                vbCrLf & "ReinstallMode=" & ReinstallMode &
                                                vbCrLf & "AssistantMode=" & AssistantMode &
                                                vbCrLf & "DowngradeForce=" & AppStatus.Installer_CanDowngrade &
                                                vbCrLf & "isCMD=" & isCMD &
                                                vbCrLf & "isCMDAllowed=" & isCMDAllowed &
                                                vbCrLf & "AllUsersInstall=" & AllUsersInstall &
                                                vbCrLf & "DownloadPackageFile=" & AppStatus.Installer_BinDownload &
                                                vbCrLf & "[Online]" &
                                                vbCrLf & "ServerAssemblyName=" & AppStatus.Assembly_Name &
                                                vbCrLf & "ServerAssemblyVersion=" & AppStatus.Assembly_Version &
                                                vbCrLf & "ServerInstallerStatus=" & AppStatus.Installer_Status &
                                                vbCrLf & "AppImageLocation=" & AppImageLocation &
                                                vbCrLf & "[Paths]" &
                                                vbCrLf & "InstallFolder=" & InstallFolder &
                                                vbCrLf & "DIRCommons=" & DIRCommons &
                                                vbCrLf & "[Forms]" &
                                                vbCrLf & "LocationX,Y=" & LocationX & "," & LocationY &
                                                vbCrLf & "StartupPath=" & Application.ExecutablePath & vbCrLf &
                                                vbCrLf & "[Computer]" &
                                                vbCrLf & "Name=" & Environment.UserDomainName & " or " & Environment.MachineName &
                                                vbCrLf & "SO=" & My.Computer.Info.OSFullName & " " & My.Computer.Info.OSVersion &
                                                vbCrLf & "RAM=" & My.Computer.Info.TotalPhysicalMemory &
                                                vbCrLf & "BitsArch=" & ProcessorArch & " (" & Installer_BitArch & ")" &
                                                vbCrLf & "Screen=" & My.Computer.Screen.Bounds.ToString & " (Area en Uso: " & My.Computer.Screen.WorkingArea.ToString & ")" &
                                                vbCrLf & "Languaje=" & My.Computer.Info.InstalledUICulture.NativeName &
                                                vbCrLf & "TimeAndDate=" & Format(DateAndTime.TimeOfDay, "hh") & ":" & Format(DateAndTime.TimeOfDay, "mm") & ":" & Format(DateAndTime.TimeOfDay, "ss") & Format(DateAndTime.TimeOfDay, "tt") & "@" & (DateAndTime.Today) &
                                                vbCrLf & "MotherboardSerial=" & MotherboardSerial &
                                                vbCrLf & "CPUSerial=" & CPUSerial &
                                                vbCrLf & "IPAddr=" & IPAddr & vbCrLf &
                                                vbCrLf & "[Log]" &
                                                vbCrLf & "#Installer Log" & vbCrLf & InstallerLogContent
            AddToInstallerLog("TELEMETRY", TLM_Content, True, 3)
            SendTelemetry(TLM_Content, False)
        Catch ex As Exception
        End Try
    End Sub
    Friend Function GetMotherBoardID() As String
        Dim strMotherBoardID As String = Nothing
        Dim query As New SelectQuery("Win32_BaseBoard")
        Dim search As New ManagementObjectSearcher(query)
        Dim info As ManagementObject
        For Each info In search.Get()
            strMotherBoardID = info("SerialNumber").ToString()
        Next
        Return strMotherBoardID
    End Function
    Function GetCpuID()
        Dim cpuInfo As String = Nothing
        Dim mc As New ManagementClass("win32_processor")
        Dim moc As ManagementObjectCollection = mc.GetInstances
        For Each mo As ManagementObject In moc
            If cpuInfo = "" Then
                cpuInfo = mo.Properties("processorID").Value.ToString
                Exit For
            End If
        Next
        Return cpuInfo
    End Function
    Function GetIPAddress() As String
        Dim ip As New WebClient
        Return ip.DownloadString(SW_UsingServer & "/getIP.php")
    End Function
    Sub SendTelemetry(ByVal content As String, ByVal localCopy As Boolean)
        Try
            Dim request As WebRequest = WebRequest.Create(ServerSwitch.DIR_Telemetry & "/postTelemetry.php")
            request.Method = "POST"
            Dim postData As String = "ident=" & My.Application.Info.AssemblyName & "_" & CreateIdentification("Identification") & "&log=" & content
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = byteArray.Length
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As WebResponse = request.GetResponse()
            Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
            If CType(response, HttpWebResponse).StatusDescription = "OK" Then
            Else
            End If
            response.Close()
            InstallerLogContent = Nothing
        Catch
        End Try
        Try
            If localCopy = True Then
                SaveTelemetry(content)
            End If
        Catch
        End Try
    End Sub
    Sub SaveTelemetry(ByVal content As String)
        Dim IdentificacionFile As String = CreateIdentification("Identification")
        Dim tlmLogFile As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\[" & IdentificacionFile & "]WorInstallerLog.tlm"
        Try
            If My.Computer.FileSystem.FileExists(tlmLogFile) = True Then
                My.Computer.FileSystem.DeleteFile(tlmLogFile)
            End If
            My.Computer.FileSystem.WriteAllText(tlmLogFile, content, False)
        Catch
        End Try
    End Sub
    Sub AddToInstallerLog(ByVal from As String, ByVal content As String, Optional ByVal flag As Boolean = False, Optional ByVal flagType As SByte = 0)
        Dim finalContent As String = Nothing
        If flag Then
            finalContent = " [!!!]"
        End If
        InstallerCommand.AddToCommandLog(from, content, flagType)
        If content.Contains("&") Then
            content = content.Replace("&", "(ampersandSymb)")
        ElseIf content.Contains("+") Then
            content = content.Replace("+", "(addSymb)")
        ElseIf content.Contains("=") Then
            content = content.Replace("=", "(equalSymb)")
        ElseIf content.Contains("*") Then
            content = content.Replace("*", "(perSymb)")
        ElseIf content.Contains("#") Then
            content = content.Replace("#", "(hashtagSymb)")
        End If
        Try
            Dim Message As String = DateTime.Now.ToString("hh:mm:ss tt dd/MM/yyyy") & finalContent & " [" & from & "] " & content
            InstallerLogContent &= vbCrLf & Message
            Console.WriteLine("[" & from & "]" & finalContent & " " & content)
            If from = Nothing And content = Nothing Then
                Message = Nothing
            End If
            Try
                If SaveLocalLog Then
                    If My.Computer.FileSystem.FileExists(DIRCommons & "\Activity.log") Then
                        My.Computer.FileSystem.WriteAllText(DIRCommons & "\Activity.log", vbCrLf & Message, True)
                    Else
                        My.Computer.FileSystem.WriteAllText(DIRCommons & "\Activity.log", vbCrLf & vbCrLf & Message, False)
                    End If
                End If
            Catch
            End Try
        Catch ex As Exception
            Console.WriteLine("[AddToInstallerLog@Telemetry]Error: " & ex.Message)
        End Try
    End Sub
    Function CreateIdentification(ByVal CreatedString As String)
        Dim obj As New Random()
        Dim posibles As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim longitud As Integer = posibles.Length
        Dim letra As Char
        Dim longitudnuevacadena As Integer = 35
        Dim nuevacadena As String = Nothing
        For i As Integer = 0 To longitudnuevacadena - 1
            letra = posibles(obj.[Next](longitud))
            nuevacadena += letra.ToString()
        Next
        Return nuevacadena
    End Function
End Module
Module PublicInformation
    Public ReadOnly DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp\" & My.Application.Info.AssemblyName

    'Ensamblado
    Public AssemblyName As String = Nothing 'Nombre del ensamblado a Instalar (AutoRellenado)
    Public AssemblyVersion As String = Nothing 'Version del ensamblado a Instalar (AutoRellenado)
    Public AssemblyPackageName As String = Nothing 'Nombre del producto (AutoRellenado)
    Public AssemblyRegistry As RegistryKey = Nothing
    Public AppImageLocation As String = Nothing 'ICONO DEL ENSAMBLADO (AutoRellenado)

    'Installer configurations
    Public InstallMode As Boolean = True 'Por defecto se intentara Instalar
    Public UpdateMode As Boolean = False
    Public UninstallMode As Boolean = False
    Public ReinstallMode As Boolean = False
    Public AssistantMode As Boolean = False
    Public IsSoftwareInstalled As Boolean = False
    Public isSilenced As Boolean
    Public isForced As Boolean
    Public CanDowngrade As Boolean = False
    Public isCMD As Boolean = False
    Public Const isCMDAllowed As Boolean = True
    Public zippedFilePath As String 'El paquete de instalacion .ZIP (AutoRellenado)
    Public extractFolderPath As String 'Donde se descomprimira el paquete de instalacion .ZIP (AutoRellenado)
    Public InstallFolder As String 'Donde se instalara el paquete de instalacion (AutoRellenado)
    Public AllUsersInstall As Boolean = True
    Public SoftwareInstalledMode As SByte = 0 'Indica si el programa esta instalado a nivel maquina (0) o solo a nivel usuario (1)
    Public ExecutableFile As String 'Nombre del ejecutable + su extencion. (AutoRellenado)
    Public PackageSize As ULong
    Public InstallerRegistry As String
    Public SaveLocalLog As Boolean = True 'True: Guarda el LOG del instalador en local. False: No lo guarda en local.
    Public CorrectProcess As Boolean = False 'True para un proceso correcto. False para alguna incidencia.
    'Local machine
    Public ProcessorArch As SByte

    'Form config
    Public LocationX As Integer
    Public LocationY As Integer
End Module
Module StartUp
    Public ArgCommandLine As String

    Sub Inicializate()
        'LEER PARAMETROS O EL INJECTADO.
        Debugger.ReadParameters()
        If Not isCMD Then
            'COMENZAMOS EL PROCESO DE INSTALACION
            StartPreInstallProcess()
        End If
    End Sub

    Sub SetSubVariables()
        AddToInstallerLog("StartUp", "Indicando variables", False)
        Try
            AssemblyPackageName = AssemblyName.Replace("Wor", Nothing) 'Indica el nombre del producto a instalar
            ExecutableFile = AssemblyName & ".exe"
            zippedFilePath = DIRCommons & "\[" & AssemblyName & "]Package.zip"
            extractFolderPath = DIRCommons & "\" & AssemblyName 'Donde se descomprimira
            AssemblyRegistry = Registry.LocalMachine.OpenSubKey("Software\\Worcome_Studios\\" & AssemblyName, True) 'Indica el registro del ensamblado
            If AssemblyVersion = "*.*.*.*" Then AssemblyVersion = "0.0.0.0" 'Indica una version si se ha omitido
            Try
                Dim consultaSQLArquitectura As String = "SELECT * FROM Win32_Processor"
                Dim objArquitectura As New ManagementObjectSearcher(consultaSQLArquitectura)
                For Each info As ManagementObject In objArquitectura.Get()
                    ProcessorArch = info.Properties("AddressWidth").Value.ToString() 'Obtiene la arquitectura del procesador (32/64)
                Next info
            Catch ex As Exception
                AddToInstallerLog("SetSubVariables(0)@StartUp", "Error: " & ex.Message, True)
            End Try
        Catch ex As Exception
            AddToInstallerLog("SetSubVariables(1)@StartUp", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub CommonActions()
        'CREACION/ELIMINACION DE DIRECTORIOS Y ARCHIVOS.
        Try
            'CREACION DEL DIRECTORIO TEMPORAL DE WorInstaller
            If My.Computer.FileSystem.DirectoryExists(DIRCommons) = False Then
                My.Computer.FileSystem.CreateDirectory(DIRCommons)
            End If

        Catch ex As Exception
            AddToInstallerLog("CommonActions@StartUp", "Error: " & ex.Message, True)
        End Try
    End Sub
End Module
Module PreInstall

    Sub StartPreInstallProcess()
        'CHECKEAMOS SI EL ENSAMBLADO ESTA O NO INSTALADO
        AddToInstallerLog("PreInstall", "Iniciando instancia de instalacion...", False)
        CheckForInstalledSoftware()
    End Sub

    Sub CheckForInstalledSoftware()
        AddToInstallerLog("PreInstall", "Verificando la existencia de alguna instalacion anterior...", False)
        Try
            If UpdateMode = False Then
                If AssemblyRegistry Is Nothing Then
                    'NO ESTA INSTALADO
                    AddToInstallerLog("PreInstall", "No se encontro un registro de instalacion.", False)
                    'NO INSTALADO, COMPROBADO.
                    StartInstallProcess()
                Else
                    'EXISTE UN REGISTRO, SE DEBE COMPROBAR
                    AddToInstallerLog("PreInstall", "Existe el ensamblado. Comprobando...", False)
                    'SI LOS VALORES SON Nothing, ENTONCES EL SOFTWARE NO ESTA INSTALADO.
                    If AssemblyRegistry.GetValue("Version") = Nothing Or
                        AssemblyRegistry.GetValue("Assembly Path") = Nothing Or
                        AssemblyRegistry.GetValue("Installed Date") = Nothing Or
                        AssemblyRegistry.GetValue("Directory") = Nothing Then
                        AddToInstallerLog("PreInstall", "El registro del ensamblado no esta correctamente configurando.", False)
                        'NO INSTALADO, COMPROBADO.
                        StartInstallProcess()
                    Else
                        IsSoftwareInstalled = True
                        AddToInstallerLog("PreInstall", "El software esta instalado y registrado.", False)
                        'ASISENTE
                        StartAssistant()
                    End If
                End If
            End If
        Catch ex As Exception
            AddToInstallerLog("CheckForInstalledSoftware@PreInstall", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub StartInstallProcess()
        'LLAMADA A AppService PARA CARGAR LOS DATOS DEL ENSAMBLADO
        AddToInstallerLog("StartUp", "Iniciando AppService...", False)
        AppService.StartAppService(False, False, False, True, AssemblyName, AssemblyVersion)
        AddToInstallerLog("PreInstall", "Comenzando el proceso de instalacion...", False)
        Try
            'COMIENZA EL PROCESO DE INSTALACION.
            InstallMode = True
            UninstallMode = False
            UpdateMode = False
            StepA.Show()
            StepA.Focus()
            StepA.BringToFront()
        Catch ex As Exception
            AddToInstallerLog("StarInstallProcess@PreInstall", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub StartAssistant()
        AddToInstallerLog("PreInstall", "Iniciando el asistente...", False)
        Debugger.StartFromAnotherLocation()
        Try
            IsSoftwareInstalled = True
            AssistantMode = True
            InstallMode = False
            'UninstallMode = False
            UpdateMode = False
            Asistente.Show()
            Asistente.Focus()
            Asistente.BringToFront()
        Catch ex As Exception
            AddToInstallerLog("StartAssistant@PreInstall", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub InstallBackup(ByVal Restore As Boolean)
        Try
            Dim backupFolder As String = DIRCommons & "\" & AssemblyName & "\BackUp"
            If Restore Then
                'RESTAURA LA COPIA
                If My.Computer.FileSystem.DirectoryExists(backupFolder) Then
                    AddToInstallerLog("PreInstall", "Aplicando la copia de seguridad...", False)
                    My.Computer.FileSystem.CopyDirectory(backupFolder, InstallFolder)
                Else
                    'INTENTANDO CON EL .ZIP (si existe)
                    If My.Computer.FileSystem.FileExists(zippedFilePath) Then
                        AddToInstallerLog("PreInstall", "Aplicando desde paquete de instalación...", False)
                        ZipFile.ExtractToDirectory(zippedFilePath, InstallFolder)
                    Else
                        AddToInstallerLog("PreInstall", "No se encontró una copia de seguridad.", False)
                    End If
                End If
            Else
                'CREA LA COPIA
                AddToInstallerLog("PreInstall", "Creando la copia de seguridad...", False)
                If My.Computer.FileSystem.DirectoryExists(backupFolder) Then
                    My.Computer.FileSystem.DeleteDirectory(backupFolder, FileIO.DeleteDirectoryOption.DeleteAllContents)
                End If
                My.Computer.FileSystem.CreateDirectory(backupFolder)
                My.Computer.FileSystem.CopyDirectory(InstallFolder, backupFolder)
            End If
        Catch ex As Exception
            AddToInstallerLog("CreateInstallBackup@PreInstall", "Error: " & ex.Message, True)
        End Try
    End Sub

End Module
Module GeneralUses
    Public ActualShowForm As Form

    Sub SecureCloseAll(Optional ByVal reason As String = Nothing)
        Try
            If reason <> Nothing Then
                AddToInstallerLog("SecureCloseAll", "Closing reason: " & reason, True, 1)
            Else
                AddToInstallerLog("SecureCloseAll", "Closing...", True, 1)
            End If
            If CorrectProcess Then
                CreateTelemetry()
            End If
            If Not isCMD Then
                End 'END_PROGRAM
            End If
        Catch ex As Exception
            AddToInstallerLog("SecureCloseAll@GeneralUses", "Error: " & ex.Message, True)
        End Try
    End Sub

    Dim FirstMessageShowed_CheckIfRunning As Boolean = False
    Function IsProccessRunning(ByVal pName As String)
        AddToInstallerLog("IsProccessRunning", "Buscando instancias...", False, 0)
        For Each clsProcess As Process In Process.GetProcesses()
            If clsProcess.ProcessName = pName Then
                AddToInstallerLog("IsProccessRunning", "Instancia abierta!", True, 1)
                If Not FirstMessageShowed_CheckIfRunning Then
                    If MessageBox.Show(pName & " is running. The proccess has been paused." & vbCrLf & "¿Want to close '" & ExecutableFile & "' and continue?", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                        FirstMessageShowed_CheckIfRunning = True
                    Else
                        Return True
                    End If
                End If
                AddToInstallerLog("IsProccessRunning", "Cerrando instancia...", False, 0)
                clsProcess.Kill()
            End If
        Next
        Return False
    End Function

    Sub ControlControls(ByVal status As Boolean)
        Try
            StepA.Panel1.Enabled = status

            StepB.Panel1.Enabled = status

            StepC.Panel1.Enabled = status

            StepD.Panel1.Enabled = status

            StepE.Panel1.Enabled = status
        Catch ex As Exception
            AddToInstallerLog("ControlControls@GeneralUses", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub SecureFormClose(ByVal ShowForm As Form, Optional ByVal CloseForm As Form = Nothing)
        Try
            If CloseForm IsNot Nothing Then
                AddToInstallerLog("SecureFormClose", "El formulario '" & CloseForm.Text & "' llamo a '" & ShowForm.Text & "'", False)
                LocationX = CloseForm.Location.X
                LocationY = CloseForm.Location.Y
                ActualShowForm = ShowForm
                ShowForm.Show()
                ShowForm.Location = New Point(LocationX, LocationY)
                ShowForm.Focus()
                CloseForm.Dispose()
                CloseForm.Close()
            Else
                AddToInstallerLog("SecureFormClose", "Se llamo al formulario '" & ShowForm.Text & "'", False)
                ShowForm.WindowState = FormWindowState.Minimized
                ShowForm.Show()
                ShowForm.Hide()
            End If
        Catch ex As Exception
            AddToInstallerLog("SecureFormClose@GeneralUses", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub AbortInstallProcess(Optional ByVal FromForm As Form = Nothing, Optional ByVal reason As String = Nothing)
        Try
            If FromForm Is Nothing Then
                AddToInstallerLog("AbortInstallProcess", "Proceso interrumpido. (" & reason & ")", False)
                SecureFormClose(StepE)
            Else
                AddToInstallerLog("AbortInstallProcess", "Proceso interrumpido. (" & FromForm.Text & ", " & reason & ")", False)
                SecureFormClose(StepE, FromForm)
            End If
            StepE.SetStatus(reason, 0)
        Catch ex As Exception
            AddToInstallerLog("AbortInstallProcess@GeneralUses", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub CriticalError(ByVal fromForm As Form, ByVal theError As String)
        Try
            AddToInstallerLog("CriticalError", "Error critico. (" & fromForm.Text & ", " & theError & ")", True)
            Try
                'SI ESTA INSTALADO, ESTO NO DEBE GATILLAR.
                If Not IsSoftwareInstalled Then
                    'ELIMINA TODO
                    Try
                        If My.Computer.FileSystem.DirectoryExists(InstallFolder) Then
                            My.Computer.FileSystem.DeleteDirectory(InstallFolder, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        End If
                    Catch
                    End Try
                    Try
                        If My.Computer.FileSystem.DirectoryExists(DIRCommons) Then
                            My.Computer.FileSystem.DeleteDirectory(DIRCommons, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        End If
                    Catch
                    End Try
                    Asistente.Uninstall(False) 'DESINSTALA TODO.
                Else
                    'RESTAURA TODO
                    InstallBackup(True)
                End If
            Catch ex As Exception
                AddToInstallerLog("CriticalError(0)@GeneralUses", "Error: " & ex.Message, True)
            End Try
            SecureFormClose(StepE, fromForm)
            StepE.SetStatus(theError, 0)
        Catch ex As Exception
            AddToInstallerLog("CriticalError@GeneralUses", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub AppServiceHasFinished()
        Try
            AddToInstallerLog("AppServiceHasFinished", "En general, AppService ha terminado.", False)
            'EN GENERAL, TERMINO.
            AssemblyVersion = AppStatus.Assembly_Version
            AppImageLocation = ServerSwitch.SW_UsingServer & "/images/AppsImage/Icons/" & AssemblyPackageName & ".png"
            StepB.rbAccept.Enabled = True
            If isSilenced Then
                If InstallMode Then
                    SecureFormClose(StepD)
                End If
            End If
            If UpdateMode Then
                Asistente.CheckIfUpdate()
            End If
        Catch ex As Exception
            AddToInstallerLog("AppServiceHasFinished@GeneralUses", "Error: " & ex.Message, True)
        End Try
    End Sub
End Module