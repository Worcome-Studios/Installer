Public Class StepA 'Introduccion / Main / MainONE
    Public UserClose As Boolean = True

    Private Sub StepA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddToInstallerLog("StepA", "Step A Iniciado! " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), False)
        If AppLanguage = 1 Then
            Idioma.Forms.Main.OnLoad.ESP()
        Else
            Idioma.Forms.Main.OnLoad.ENG()
        End If
        Idioma.Forms.Main.OnLoad.AfterLoad()
        Me.BringToFront()
        Dim StartBlinkForFocus = WindowsApi.FlashWindow(Process.GetCurrentProcess().MainWindowHandle, True, True, 5)
    End Sub
    Private Sub StepA_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If UserClose Then
            UserClose = False
            AbortInstallProcess(Me, "El usuario cerro la ventana de Introduccion.")
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
        Try
            UserClose = False
            SecureFormClose(StepB, Me)
        Catch ex As Exception
            AddToInstallerLog("Continuar@StepA", "Error: " & ex.Message, False)
        End Try
    End Sub

    Sub Salir()
        Try
            UserClose = False
            AbortInstallProcess(Me, "El usuario salio de la ventana de Introduccion.")
        Catch ex As Exception
            AddToInstallerLog("Salir@StepA", "Error: " & ex.Message, False)
        End Try
    End Sub
End Class