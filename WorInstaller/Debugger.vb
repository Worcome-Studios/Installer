Public Class Debugger

    Private Sub Debugger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InstallerCommand.StartUp()
        AddToInstallerLog("", "", True)
        AddToInstallerLog("Debugger", "Instancia de WorInstaller iniciada!. " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), True)
        ArgCommandLine = Command()
        Inicializate()
    End Sub

    Sub ReadParameters()
        Try
            If My.Application.CommandLineArgs.Count > 0 Then
                AddToInstallerLog("Debugger", "Leyendo parametros", False)
                For i As Integer = 0 To My.Application.CommandLineArgs.Count - 1
                    Dim parametro As String = My.Application.CommandLineArgs(i)
                    If parametro Like "*/Installer.Package.Set=*" Then
                        Dim Args As String = parametro.Remove(0, parametro.LastIndexOf("=") + 1)
                        Dim Pars As String() = Args.Split(",")
                        SetAssemblyInfo(Pars(0).Trim(), Pars(1).Trim())
                    ElseIf parametro.ToUpper Like "*-S*" Then
                        isSilenced = True
                    ElseIf parametro.ToUpper Like "*-F*" Then
                        isForced = True
                    ElseIf parametro.ToUpper Like "*-FORCEDOWNGRADE*" Then
                        CanDowngrade = True
                    ElseIf parametro.ToUpper Like "*-COMMANDPROMPT*" Then
                        If isCMDAllowed Then
                            AddToInstallerLog("ReadParameters@Debugger", "Se ha iniciado Command Prompt", True)
                            isCMD = True
                            InstallerCommand.Show()
                            InstallerCommand.Focus()
                        Else
                            AddToInstallerLog("ReadParameters@Debugger", "Funcion Command Prompt no habilitada.", True)
                        End If
                    ElseIf parametro.ToUpper Like "*/UNINSTALL*" Then
                        InstallMode = False
                        UninstallMode = True
                        UpdateMode = False
                        AssistantMode = True
                    End If
                Next
            End If
        Catch ex As Exception
            AddToInstallerLog("ReadParameters@Debugger", "Error: " & ex.Message, True)
        End Try
        If Not isCMD Then
            'Si el instalador lo permite, se pueden pedir parametros
            If AssemblyName = "*" Or AssemblyVersion = "*.*.*.*" Then
                AskForParemeters()
            End If
            'Si no se tienen los parametros, entonces se debe leer el STUB
            If AssemblyName = Nothing Or AssemblyVersion = Nothing Then
                AddToInstallerLog("Debugger", "Leyendo injectado", False)
                GetInjectedData()
            End If
        End If
    End Sub

    Sub AskForParemeters()
        Try
            Dim assemblyNameIn = InputBox("Set a Assembly", "Worcome Security")
            Dim assemblyVersionIn = InputBox("Set the Assembly Version", "Worcome Security", "*.*.*.*")
            If assemblyNameIn <> Nothing Then
                If assemblyVersionIn <> Nothing Then
                    AddToInstallerLog("Debugger", "Se han insertado manualmente el Ensamblado y Version", False)
                    SetAssemblyInfo(assemblyNameIn, assemblyVersionIn)
                Else
                    SecureCloseAll()
                End If
            Else
                SecureCloseAll()
            End If
        Catch ex As Exception
            AddToInstallerLog("AskForParemeters@Debugger", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub GetInjectedData()
        Try
            FileOpen(1, Application.ExecutablePath, OpenMode.Binary, OpenAccess.Read)
            Dim stubb As String = Space(LOF(1))
            Dim FileSplit = "|WOR|"
            FileGet(1, stubb)
            FileClose(1)
            Dim opt() As String = Split(stubb, FileSplit)
            If opt(1) IsNot "None" Then
                AddToInstallerLog("GetInjectedData@Debugger", "Se han cargado datos del injectado.", False)
                SetAssemblyInfo(opt(1), opt(2))
            End If
        Catch ex As Exception
            AddToInstallerLog("GetInjectedData@Debugger", "Error: " & ex.Message, True)
            'If MessageBox.Show("Este instalador no esta correctamente configurado." & vbCrLf & vbCrLf & "Faltan 'AssemblyName' y 'AssemblyVersion'." & vbCrLf & "¿Quiere ingresar esos valores?", "Worcome Security", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '    AskForParemeters()
            'Else
            SecureCloseAll("Assembly name and version cant be nothing.")
            'End If
        End Try
    End Sub
    Sub SetAssemblyInfo(ByVal AppAssemblyName As String, ByVal AppAssemblyVersion As String)
        Try
            AddToInstallerLog("SetAssemblyInfo@Debugger", "Se han insertado valores.", True)
            AssemblyName = AppAssemblyName
            AssemblyVersion = AppAssemblyVersion
            StartUp.SetSubVariables()
            StartUp.CommonActions()
        Catch ex As Exception
            AddToInstallerLog("SetAssemblyInfo@Debugger", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub StartFromAnotherLocation(Optional ByVal CloseInstance As Boolean = True)
        Try
            If Not isCMD Then
                Dim TempFolder As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp"
                If Application.ExecutablePath.Contains("uninstall.exe") Then
                    If My.Computer.FileSystem.FileExists(TempFolder & "\" & AssemblyName & "_Assistant.exe") Then
                        My.Computer.FileSystem.DeleteFile(TempFolder & "\" & AssemblyName & "_Assistant.exe")
                    End If
                    My.Computer.FileSystem.CopyFile(Application.ExecutablePath, TempFolder & "\" & AssemblyName & "_Assistant.exe")
                    Process.Start(TempFolder & "\" & AssemblyName & "_Assistant.exe", ArgCommandLine)
                    If CloseInstance Then
                        SecureCloseAll("Restarting from another location.")
                    End If
                End If
            End If
        Catch ex As Exception
            AddToInstallerLog("StartFromAnotherLocation@Debugger", "Error: " & ex.Message, True)
        End Try
    End Sub
End Class