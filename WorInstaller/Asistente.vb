Imports Microsoft.Win32
Public Class Asistente
    Public UserClose As Boolean = True

    Private Sub Asistente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'APLICA EL IDIOMA A LA VARIABLE AppLanguague PARA PODER USARLA
            Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
            If myCurrentLanguage.Culture.EnglishName.Contains("Spanish") Then
                AppLanguage = 1
            ElseIf myCurrentLanguage.Culture.EnglishName.Contains("English") Then
                AppLanguage = 0
            Else
                AppLanguage = 0
            End If
        Catch
        End Try
        If AppLanguage = 1 Then
            Idioma.Forms.Assistant.OnLoad.ESP()
        Else
            Idioma.Forms.Assistant.OnLoad.ENG()
        End If
        Idioma.Forms.Assistant.OnLoad.AfterLoad()
        If isSilenced Then
            Me.Hide()
        End If
        If AppLanguage = 1 Then
            Me.Text = AssemblyName & " - Asistente"
        Else
            Me.Text = AssemblyName & " - Assistant"
        End If
        Dim StartBlinkForFocus = WindowsApi.FlashWindow(Process.GetCurrentProcess().MainWindowHandle, True, True, 5)
        'SACAR LOS DATOS DEL REGISTRO, QUEDA CASI PROHIBIDO CONECTARSE A AppService
        Try
            Dim Icono As Icon = Icon.ExtractAssociatedIcon(AssemblyRegistry.GetValue("Assembly Path"))
            picAppIcon.Image = Icono.ToBitmap
            picAppIcon.Visible = True
            Me.Icon = Icono
        Catch
            picAppIcon.Visible = False
        End Try
        GetRegistry()
        rtbLog.SelectionColor = Color.Gray
        rtbLog.AppendText("WorInstaller " & My.Application.Info.Version.ToString & " (" & Application.ProductVersion & ")")
        rtbLog.SelectionColor = Color.Black
        rtbLog.ScrollToCaret()
        If UninstallMode = True Then
            Uninstall()
        End If
    End Sub
    Private Sub Asistente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        For i = 1.1 To 0.0 Step -0.1
            Me.Opacity = i
            Me.Refresh()
        Next
        If UserClose Then
            SecureCloseAll()
        End If
    End Sub
    Private Sub Asistente_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Me.HelpRequested
        MsgBox("WorInstaller " & My.Application.Info.Version.ToString & " (" & Application.ProductVersion & ")", MsgBoxStyle.Information, "Worcome Security")
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If UserClose Then
            SecureCloseAll()
        End If
    End Sub

    Sub AddToAssistantLog(ByVal message As String, Optional ByVal flag As Boolean = False)
        Try
            AddToInstallerLog("Asistente", message, flag)
            If flag Then
                rtbLog.SelectionColor = Color.Red
            End If
            rtbLog.AppendText(vbCrLf & message)
            rtbLog.SelectionColor = DefaultForeColor
            rtbLog.ScrollToCaret()
        Catch ex As Exception
            AddToInstallerLog("AddToAssistantLog@Asistente", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub GetRegistry()
        Try
            Me.Text = AssemblyRegistry.GetValue("Assembly") & " (" & AssemblyRegistry.GetValue("Version") & ") - Assistant"
            lblAssemblyInfo.Text = "Assembly: " & AssemblyRegistry.GetValue("Assembly") &
            vbCrLf & "Version: " & AssemblyRegistry.GetValue("Version") &
            vbCrLf & "Installed Date: " & AssemblyRegistry.GetValue("Installed Date") &
            vbCrLf & "Last start: " & AssemblyRegistry.GetValue("Last Start")
        Catch ex As Exception
            AddToInstallerLog("GetRegistry@Asistente", "Error: " & ex.Message, True)
        End Try
    End Sub

    Private Sub llblAbout_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblAbout.LinkClicked
        Process.Start(ServerSwitch.DIR_AppHelper & "/AboutApps/" & AssemblyName & ".html")
    End Sub
    Private Sub llblUseGuide_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblUseGuide.LinkClicked
        Process.Start(ServerSwitch.DIR_AppHelper & "/" & AssemblyName & ".html")
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateIt()
    End Sub
    Private Sub btnReinstall_Click(sender As Object, e As EventArgs) Handles btnReinstall.Click
        Reinstall()
    End Sub
    Private Sub btnUninstall_Click(sender As Object, e As EventArgs) Handles btnUninstall.Click
        Uninstall()
    End Sub
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Reset()
    End Sub
    Private Sub btnSearchUpdates_Click(sender As Object, e As EventArgs) Handles btnSearchUpdates.Click
        SearchUpdates()
    End Sub

    Sub Reinstall()
        Try
            'Verificar que el software no se este ejecutando
            If IsProccessRunning(IO.Path.GetFileNameWithoutExtension(ExecutableFile)) Then
                AbortInstallProcess(Me, "No se puede realizar la reinstalacion con el programa ejecutandose.")
            Else
                If MessageBox.Show("¿Want to reinstall '" & AssemblyRegistry.GetValue("Assembly") & "'?", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    AddToAssistantLog("Starting reinstall process...")
                    UserClose = False
                    ReinstallMode = True
                    InstallMode = False
                    UpdateMode = False
                    UninstallMode = False
                    AddToInstallerLog("Asistente", "Iniciando AppService...", False)
                    AppService.StartAppService(False, False, False, True, AssemblyName, AssemblyRegistry.GetValue("Version"))
                    SecureFormClose(StepB, Me)
                End If
            End If
        Catch ex As Exception
            AddToInstallerLog("Reinstall@Asistente", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub Uninstall()
        Try
            'Verificar que el software no se este ejecutando
            If IsProccessRunning(IO.Path.GetFileNameWithoutExtension(ExecutableFile)) Then
                AbortInstallProcess(Me, "No se puede realizar la desinstalacion con el programa ejecutandose.")
            Else
                If isSilenced Then
                    GoTo uninstallthething
                Else
                    If MessageBox.Show("¿Want to uninstall '" & AssemblyRegistry.GetValue("Assembly") & "' de su equipo?", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        GoTo uninstallthething
                    Else
                        Exit Sub
                    End If
                End If
uninstallthething:
                AddToAssistantLog("Starting uninstall process...")
                Try
                    'ELIMINAR CARPETA DE INSTALACION Y DIRCommons
                    AddToAssistantLog("Deleting installation folder...")
                    If My.Computer.FileSystem.DirectoryExists(AssemblyRegistry.GetValue("Directory")) = True Then
                        My.Computer.FileSystem.DeleteDirectory(AssemblyRegistry.GetValue("Directory"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                    If My.Computer.FileSystem.DirectoryExists(DIRCommons) = True Then
                        My.Computer.FileSystem.DeleteDirectory(DIRCommons, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                Catch ex As Exception
                    AddToInstallerLog("Uninstall(0)@Asistente", "Error: " & ex.Message, True)
                End Try
                Try
                    'ELIMINA LOS ARCHIVOS DEL PROGRAMA
                    AddToAssistantLog("Deleting programa configuration directory...")
                    If My.Computer.FileSystem.DirectoryExists("C:\Users\" & Environment.UserName & "\AppData\Local\Worcome_Studios\Commons\Apps\" & AssemblyName) = True Then
                        My.Computer.FileSystem.DeleteDirectory("C:\Users\" & Environment.UserName & "\AppData\Local\Worcome_Studios\Commons\Apps\" & AssemblyName, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                    If My.Computer.FileSystem.DirectoryExists("C:\Users\" & Environment.UserName & "\AppData\Local\Worcome_Studios\Commons\" & AssemblyName) = True Then
                        My.Computer.FileSystem.DeleteDirectory("C:\Users\" & Environment.UserName & "\AppData\Local\Worcome_Studios\Commons\" & AssemblyName, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                Catch ex As Exception
                    AddToInstallerLog("Uninstall(1)@Asistente", "Error: " & ex.Message, True)
                End Try
                Try
                    'ELIMINA EL REGISTRO StartUp CurrentUser
                    Dim RegistryRemover As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", True)
                    If RegistryRemover.GetValue(AssemblyName) IsNot Nothing Then
                        RegistryRemover.DeleteValue(AssemblyName)
                    End If
                Catch ex As Exception
                    AddToInstallerLog("Uninstall(2)@Asistente", "Error: " & ex.Message, True)
                End Try
                Try
                    'ELIMINA EL REGISTRO StartUp LocalMachine
                    Dim RegistryRemover As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", True)
                    If RegistryRemover.GetValue(AssemblyName) IsNot Nothing Then
                        RegistryRemover.DeleteValue(AssemblyName)
                    End If
                Catch ex As Exception
                    AddToInstallerLog("Uninstall(3)@Asistente", "Error: " & ex.Message, True)
                End Try
                Try
                    'ELIMINA EL REGISTRO RunAsAdmin CurrentUser
                    Dim RegistryRemover As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", True)
                    If RegistryRemover.GetValue(AssemblyRegistry.GetValue("Assembly Path")) IsNot Nothing Then
                        RegistryRemover.DeleteValue(AssemblyRegistry.GetValue("Assembly Path"))
                    End If
                Catch ex As Exception
                    AddToInstallerLog("Uninstall(4)@Asistente", "Error: " & ex.Message, True)
                End Try
                Try
                    'ELIMINA EL REGISTRO RunAsAdmin LocalMachine
                    Dim RegistryRemover As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", True)
                    If RegistryRemover.GetValue(AssemblyRegistry.GetValue("Assembly Path")) IsNot Nothing Then
                        RegistryRemover.DeleteValue(AssemblyRegistry.GetValue("Assembly Path"))
                    End If
                Catch ex As Exception
                    AddToInstallerLog("Uninstall(5)@Asistente", "Error: " & ex.Message, True)
                End Try
                Try
                    'ELIMINA EL REGISTRO DE INSTALACION
                    AddToAssistantLog("Deleting installation registry...")
                    Dim RegistryRemover As RegistryKey = Registry.LocalMachine.OpenSubKey(AssemblyRegistry.GetValue("Install Registry"), True)
                    If RegistryRemover IsNot Nothing Then
                        Registry.LocalMachine.DeleteSubKeyTree(AssemblyRegistry.GetValue("Install Registry"))
                    End If
                Catch ex As Exception
                    AddToInstallerLog("Uninstall(6)@Asistente", "Error: " & ex.Message, True)
                End Try
                Try
                    'ELIMINAR ACCESO DIRECTO DE Program
                    AddToAssistantLog("Deleting direct access files...")
                    Dim AppFolder_Inicio As String
                    AppFolder_Inicio = Environment.GetFolderPath(Environment.SpecialFolder.Programs) & "\Worcome Studios\Worcome Apps\" & AssemblyPackageName
                    My.Computer.FileSystem.DeleteDirectory(AppFolder_Inicio, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    'Y DEL ESCRITORIO
                    Dim LNK_Escritorio As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & AssemblyPackageName & ".lnk"
                    If My.Computer.FileSystem.FileExists(LNK_Escritorio) Then
                        My.Computer.FileSystem.DeleteFile(LNK_Escritorio)
                    End If
                Catch ex As Exception
                    AddToInstallerLog("Uninstall(7)@Asistente", "Error: " & ex.Message, True)
                End Try
                Try
                    'ELIMINAR REGISTRO CurrentUser de SignRegistry
                    AddToAssistantLog("Deleting SignRegistry (CurrentUser)...")
                    Dim RegistryRemover As RegistryKey
                    RegistryRemover = Registry.CurrentUser.OpenSubKey("Software\\Worcome_Studios\\" & AssemblyName, True)
                    If RegistryRemover IsNot Nothing Then
                        RegistryRemover.DeleteValue("AllUsersCanUse", False)
                        RegistryRemover.DeleteValue("Assembly", False)
                        RegistryRemover.DeleteValue("Assembly Path", False)
                        RegistryRemover.DeleteValue("Compilated", False)
                        RegistryRemover.DeleteValue("Description", False)
                        RegistryRemover.DeleteValue("Directory", False)
                        RegistryRemover.DeleteValue("Installed Date", False)
                        RegistryRemover.DeleteValue("Last Start", False)
                        RegistryRemover.DeleteValue("Version", False)
                        'ELIMINA LA LLAVE COMPLETA
                        Registry.CurrentUser.DeleteSubKeyTree("Software\\Worcome_Studios\\" & AssemblyName)
                    End If
                Catch ex As Exception
                    AddToInstallerLog("Uninstall(8)@Asistente", "Error: " & ex.Message, True)
                End Try
                Try
                    'ELIMINAR REGISTRO LocalMachine de SignRegistry
                    AddToAssistantLog("Deleting SignRegistry (LocalMachine)...")
                    Dim RegistryRemover As RegistryKey
                    RegistryRemover = Registry.LocalMachine.OpenSubKey("Software\\Worcome_Studios\\" & AssemblyName, True)
                    If RegistryRemover IsNot Nothing Then
                        RegistryRemover.DeleteValue("AllUsersCanUse", False)
                        RegistryRemover.DeleteValue("Assembly", False)
                        RegistryRemover.DeleteValue("Assembly Path", False)
                        RegistryRemover.DeleteValue("Directory", False)
                        RegistryRemover.DeleteValue("Installed Date", False)
                        RegistryRemover.DeleteValue("Last Start", False)
                        RegistryRemover.DeleteValue("Version", False)
                        Registry.LocalMachine.DeleteSubKeyTree("Software\\Worcome_Studios\\" & AssemblyName)
                    End If
                Catch ex As Exception
                    AddToInstallerLog("Uninstall(9)@Asistente", "Error: " & ex.Message, True)
                End Try
                AddToAssistantLog("Uninstall complete...")
                If Not isSilenced Then
                    If AppLanguage = 1 Then
                        MsgBox("Desinstalación completa", MsgBoxStyle.Information, "Worcome Security")
                        If MessageBox.Show("¿Quiere completar una pequeña encuesta?" & vbCrLf & "Nos ayudaría mucho saber su opinión", "Worcome Community", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Process.Start("https://docs.google.com/forms/d/e/1FAIpQLSevAg6CpdzgHV1cK1QvNp41DzXb-Rf379vn9znIOFp1FO-cug/viewform?usp=pp_url&entry.2061732064=" & AssemblyPackageName)
                        End If
                    Else
                        MsgBox("Uninstall Completed", MsgBoxStyle.Information, "Worcome Security")
                        If MessageBox.Show("Do you want to complete a short survey?" & vbCrLf & "It would help us a lot to know your opinion!", "Worcome Community", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Process.Start("https://docs.google.com/forms/d/e/1FAIpQLSevAg6CpdzgHV1cK1QvNp41DzXb-Rf379vn9znIOFp1FO-cug/viewform?usp=pp_url&entry.2061732064=" & AssemblyPackageName)
                        End If
                    End If
                End If
                AddToAssistantLog("Closing...")
                SecureCloseAll()
            End If
        Catch ex As Exception
            AddToInstallerLog("Uninstall(10)@Asistente", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub Reset()
        Try
            AddToAssistantLog("Starting reset process...")
            Process.Start(AssemblyRegistry.GetValue("Assembly Path"), "/FactoryReset")
        Catch ex As Exception
            AddToInstallerLog("Reset@Asistente", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub SearchUpdates()
        Try
            AddToInstallerLog("Asistente", "Iniciando AppService...", False)
            UpdateMode = True
            AppService.StartAppService(False, False, False, True, AssemblyName, AssemblyRegistry.GetValue("Version"))
            AddToAssistantLog("Searching for updates...")
        Catch ex As Exception
            AddToInstallerLog("SearchUpdates@Asistente", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub CheckIfUpdate()
        UpdateMode = False
        'ANALIZAR LA VERSION
        Dim versionLocal = New Version(AssemblyRegistry.GetValue("Version"))
        Dim versionServidor = New Version(Assembly_Version)
        Dim result = versionLocal.CompareTo(versionServidor)
        AddToAssistantLog("Server: " & Assembly_Version & "    Local: " & versionLocal.ToString)
        If (result < 0) Then
            If AppLanguage = 1 Then
                If MessageBox.Show("Hay una actualización disponible." & vbCrLf & "La descarga será desde el servidor." & vbCrLf & "¿Quiere actualizar?", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    UpdateIt()
                End If
            Else
                If MessageBox.Show("An update is available." & vbCrLf & "The download will be from the server." & vbCrLf & "Do you want to update?", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    UpdateIt()
                End If
            End If
            Console.WriteLine("[Asistente]Una nueva version esta disponible.")
        Else
            If AppLanguage = 1 Then
                MsgBox("No hay actualizaciones disponibles.", MsgBoxStyle.Information, "Worcome Security")
            Else
                MsgBox("There are no updates available.", MsgBoxStyle.Information, "Worcome Security")
            End If
            Console.WriteLine("[Asistente]Sin actualizaciones.")
        End If
    End Sub
    Sub UpdateIt()
        Try
            AddToAssistantLog("Starting update process...")
            UserClose = False
            ReinstallMode = False
            InstallMode = False
            UpdateMode = True
            UninstallMode = False
            SecureFormClose(StepD, Me)
        Catch ex As Exception
            AddToInstallerLog("UpdateIt@Asistente", "Error: " & ex.Message, True)
        End Try
    End Sub

    Private Sub picAppIcon_Click(sender As Object, e As EventArgs) Handles picAppIcon.Click
        If AppLanguage = 1 Then
            If MessageBox.Show("¿Desea iniciar '" & AssemblyPackageName & "'?", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Process.Start(AssemblyRegistry.GetValue("Assembly Path"))
            End If
        Else
            If MessageBox.Show("Do you want to start '" & AssemblyPackageName & "'?", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Process.Start(AssemblyRegistry.GetValue("Assembly Path"))
            End If
        End If
    End Sub
End Class