Public Class Debugger

    Private Sub Debugger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                        AssemblyName = Pars(0).Trim()
                        AssemblyVersion = Pars(1).Trim()
                    ElseIf parametro Like "*/S*" Then
                        isSilenced = True
                    ElseIf parametro Like "*/F*" Then
                        isForced = True
                    ElseIf parametro Like "*/ForceDowngrade*" Then
                        CanDowngrade = True
                    ElseIf parametro Like "*/Uninstall*" Then
                        UninstallMode = True
                        InstallMode = False
                    End If
                Next
            End If
        Catch ex As Exception
            AddToInstallerLog("ReadParameters@Debugger", "Error: " & ex.Message, True)
        End Try
        'SI NO SE LEEN PARAMETROS, ESTAS DOS VARIABLES QUEDAN VACIAS. SI ES ASI, SE DEBE LEER EL STUB COMO ULTIMO RECURSO.
        If AssemblyName = Nothing And AssemblyVersion = Nothing Then
            AddToInstallerLog("Debugger", "Leyendo injectado", False)
            GetInjectedData()
        End If
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
        Catch
            AddToInstallerLog("GetInjectedData@Debugger", "No se han encontrado datos cargados en el injectado.", True)
            MsgBox("Este instalador no esta correctamente configurado." & vbCrLf & "Faltan parametros.", MsgBoxStyle.Critical)
            End 'END_PROGRAM
        End Try
    End Sub
    Sub SetAssemblyInfo(ByVal AppAssemblyName As String, ByVal AppAssemblyVersion As String)
        Try
            AssemblyName = AppAssemblyName
            AssemblyVersion = AppAssemblyVersion
        Catch ex As Exception
            AddToInstallerLog("SetAssemblyInfo@Debugger", "Error: " & ex.Message, True)
        End Try
    End Sub
End Class