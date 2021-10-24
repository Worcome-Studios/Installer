Imports System.IO
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
            Dim serialBoard As String = Nothing
            If My.Computer.FileSystem.FileExists(DIRCommons & "\[" & TelemetryID & "]TLM_Installer" & AssemblyName & ".tlm") Then
                My.Computer.FileSystem.DeleteFile(DIRCommons & "\[" & TelemetryID & "]TLM_Installer" & AssemblyName & ".tlm")
            End If
            Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
            Dim serial As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_BaseBoard")
            For Each serialB As ManagementObject In serial.Get()
                serialBoard = (serialB.GetPropertyValue("SerialNumber").ToString)
            Next
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
                                                vbCrLf & "InstallMode=" & InstallMode &
                                                vbCrLf & "UpdateMode=" & UpdateMode &
                                                vbCrLf & "DowngradeForce=" & AppStatus.Installer_CanDowngrade &
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
                                                vbCrLf & "SO=" & My.Computer.Info.OSFullName & My.Computer.Info.OSVersion &
                                                vbCrLf & "RAM=" & My.Computer.Info.TotalPhysicalMemory &
                                                vbCrLf & "BitsArch=" & ProcessorArch & " (" & Installer_BitArch & ")" &
                                                vbCrLf & "Screen=" & My.Computer.Screen.Bounds.ToString & " (Area en Uso: " & My.Computer.Screen.WorkingArea.ToString & ")" &
                                                vbCrLf & "Languaje=" & My.Computer.Info.InstalledUICulture.NativeName &
                                                vbCrLf & "TimeAndDate=" & Format(DateAndTime.TimeOfDay, "hh") & ":" & Format(DateAndTime.TimeOfDay, "mm") & ":" & Format(DateAndTime.TimeOfDay, "ss") & Format(DateAndTime.TimeOfDay, "tt") & "@" & (DateAndTime.Today) &
                                                vbCrLf & "MemoryDiskSerialNumber=" & serialDD.Properties("SerialNumber").Value.ToString &
                                                vbCrLf & "SerialNumber=" & serialBoard & vbCrLf &
                                                vbCrLf & "[Log]" &
                                                vbCrLf & "#Installer Log" & vbCrLf & InstallerLogContent
            SendTelemetry(TLM_Content, False)
        Catch ex As Exception
        End Try
    End Sub
    Sub SendTelemetry(ByVal content As String, ByVal localCopy As Boolean)
        Try
            Dim request As WebRequest = WebRequest.Create(AppService.DIR_Telemetry & "/postTelemetry.php")
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
    Sub AddToInstallerLog(ByVal from As String, ByVal content As String, Optional ByVal flag As Boolean = False)
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
            Dim finalContent As String = Nothing
            If flag = True Then
                finalContent = " [!!!]"
            End If
            Dim Message As String = DateTime.Now.ToString("hh:mm:ss tt dd/MM/yyyy") & finalContent & " [" & from & "] " & content
            InstallerLogContent &= vbCrLf & Message
            Console.WriteLine("[" & from & "]" & finalContent & " " & content)
            'Try
            '    My.Computer.FileSystem.WriteAllText(DIRCommons & "\Activity.log", vbCrLf & Message, True)
            'Catch
            'End Try
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
    Public AssemblyName As String = "*" 'Nombre del ensamblado a Instalar (AutoRellenado)
    Public AssemblyVersion As String = "*.*.*.*"  'Version del ensamblado a Instalar (AutoRellenado)
    Public AssemblyPackageName As String = Nothing 'Nombre del producto (AutoRellenado)
    Public AssemblyRegistry As RegistryKey = Nothing
    Public AppImageLocation As String = Nothing 'ICONO DEL ENSAMBLADO (AutoRellenado)

    'Installer configurations
    Public InstallMode As Boolean = True 'Por defecto se intentara Instalar
    Public UpdateMode As Boolean = False
    Public UninstallMode As Boolean = False
    Public isSilenced As Boolean
    Public isForced As Boolean
    Public CanDowngrade As Boolean = False
    Public zippedFilePath As String 'El paquete de instalacion .ZIP (AutoRellenado)
    Public extractFolderPath As String 'Donde se descomprimira el paquete de instalacion .ZIP (AutoRellenado)
    Public InstallFolder As String 'Donde se instalara el paquete de instalacion (AutoRellenado)
    Public AllUsersInstall As Boolean = True
    Public SoftwareInstalledMode As SByte = 0 'Indica si el programa esta instalado a nivel maquina (0) o solo a nivel usuario (1)
    Public PackageSize As ULong
    Public InstallerRegistry As String

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
        'SET DE VARIABLES PARA SUS USOS POSTERIORES
        SetSubVariables()
        'ACCIONES COMUNES
        CommonActions()
        'LLAMADA A AppService PARA CARGAR LOS DATOS DEL ENSAMBLADO
        AddToInstallerLog("StartUp", "Iniciando AppService...", False)
        AppService.StartAppService(False, False, False, True, AssemblyName, AssemblyVersion)
        'COMENZAMOS EL PROCESO DE INSTALACION
        StartPreInstallProcess()
    End Sub

    Sub SetSubVariables()
        AddToInstallerLog("StartUp", "Indicando variables", False)
        Try
            AssemblyPackageName = AssemblyName.Replace("Wor", Nothing) 'Indica el nombre del producto a instalar
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
                    StarInstallProcess()
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
                        StarInstallProcess()
                    Else
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

    Sub StarInstallProcess()
        AddToInstallerLog("PreInstall", "Comenzando el proceso de instalacion...", False)
        Try
            'COMIENZA EL PROCESO DE INSTALACION.
            InstallMode = True
            StepA.Show()
            StepA.Focus()
            StepA.BringToFront()
        Catch ex As Exception
            AddToInstallerLog("StarInstallProcess@PreInstall", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub StartAssistant()
        AddToInstallerLog("PreInstall", "Iniciando el asistente...", False)
        Try
            Asistente.Show()
            Asistente.Focus()
            Asistente.BringToFront()
        Catch ex As Exception
            AddToInstallerLog("StartAssistant@PreInstall", "Error: " & ex.Message, True)
        End Try
    End Sub

End Module
Module GeneralUses
    Public ActualShowForm As Form

    Sub SecureFormClose(ByVal ShowForm As Form, ByVal CloseForm As Form)
        Try
            AddToInstallerLog("SecureFormClose", "El formulario '" & CloseForm.Text & "' llamo a '" & ShowForm.Text & "'", False)
            LocationX = CloseForm.Location.X
            LocationY = CloseForm.Location.Y
            ActualShowForm = ShowForm
            If isSilenced = False Then
                ShowForm.Show()
                ShowForm.Location = New Point(LocationX, LocationY)
                ShowForm.Focus()
            Else
                ShowForm.WindowState = FormWindowState.Minimized
                ShowForm.Show()
                ShowForm.Hide()
            End If
            CloseForm.Dispose()
            CloseForm.Close()
        Catch ex As Exception
            AddToInstallerLog("SecureFormClose@GeneralUses", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub AbortInstallProcess(ByVal FromForm As Form, ByVal reason As String)
        Try
            AddToInstallerLog("AbortInstallProcess", "Proceso interrumpido. (" & FromForm.Text & ", " & reason & ")", False)
            SecureFormClose(StepE, FromForm)
            StepE.SetStatus(reason, 0)
        Catch ex As Exception
            AddToInstallerLog("AbortInstallProcess@GeneralUses", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub AppServiceHasFinished()
        Try
            AddToInstallerLog("AppServiceHasFinished", "En general, AppService ha terminado.", False)
            'EN GENERAL, TERMINO.
            AssemblyVersion = AppStatus.Assembly_Version
            AppImageLocation = ServerSwitch.SW_UsingServer & "/images/AppsImage/Icons/" & AssemblyPackageName & ".png"
            StepB.rbAccept.Enabled = True
        Catch ex As Exception
            AddToInstallerLog("AppServiceHasFinished@GeneralUses", "Error: " & ex.Message, True)
        End Try
    End Sub
End Module