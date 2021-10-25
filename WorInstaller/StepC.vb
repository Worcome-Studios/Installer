Public Class StepC 'Componentes / Comp / THREE
    Public UserClose As Boolean = True

    Private Sub StepC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddToInstallerLog("StepC", "Step C Iniciado! " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), False)
        If AppLanguage = 1 Then
            Idioma.Forms.Tres.OnLoad.ESP()
        Else
            Idioma.Forms.Tres.OnLoad.ENG()
        End If
        Idioma.Forms.Tres.OnLoad.AfterLoad()
        If AppImageLocation IsNot Nothing Then
            PIC_IMG_Icon.ImageLocation = AppImageLocation
        End If
        LoadData()
    End Sub
    Private Sub StepC_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If UserClose Then
            UserClose = False
            AbortInstallProcess(Me, "El usuario cerro la ventana de Informacion de Ensamblado")
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
        SecureFormClose(StepD, Me)
    End Sub

    Sub Salir()
        Try
            UserClose = False
            AbortInstallProcess(Me, "El usuario salio de la ventana de Informacion de Ensamblado")
        Catch ex As Exception
            AddToInstallerLog("Salir@StepC", "Error: " & ex.Message, False)
        End Try
    End Sub

    Sub LoadData()
        Try
            lblAssemblyInfo.Text = "La version a instalar es la " & AppStatus.Assembly_Version & " encontrada en el servidor."
            AddToInstallerLog("StepC", "Se cargo la informacion del ensamblado desde: " & ServerSwitch.DIR_AppHelper & "/AboutApps/" & AssemblyName & ".html", False)
            WebBrowser1.Navigate(ServerSwitch.DIR_AppHelper & "/AboutApps/" & AssemblyName & ".html")
            cbAllUserCanUse.Checked = AllUsersInstall
        Catch ex As Exception
            AddToInstallerLog("LoadData@StepC", "Error: " & ex.Message, False)
        End Try
    End Sub

    Private Sub cbAllUserCanUse_CheckedChanged(sender As Object, e As EventArgs) Handles cbAllUserCanUse.CheckedChanged
        AllUsersInstall = cbAllUserCanUse.Checked
    End Sub
End Class