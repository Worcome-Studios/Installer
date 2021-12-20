Public Class StepB 'Acuerdo con el Usuario / User Agreement / TWO
    Public UserClose As Boolean = True

    Private Sub StepB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddToInstallerLog("StepB", "Step B Iniciado! " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), False)
        If AppLanguage = 1 Then
            Idioma.Forms.Dos.OnLoad.ESP()
        Else
            Idioma.Forms.Dos.OnLoad.ENG()
        End If
        Idioma.Forms.Dos.OnLoad.AfterLoad()
        If AppImageLocation IsNot Nothing Then
            PIC_IMG_Icon.ImageLocation = AppImageLocation
        End If
        Dim errString As String = My.Resources.UserAgreement
        Dim correctString As String = errString.Replace("AppName", AssemblyName)
        rtbEULA.AppendText(correctString)
    End Sub

    Private Sub StepB_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If UserClose Then
            UserClose = False
            AbortInstallProcess(Me, "El usuario cerro la ventana de Acuerdo con el Usuario")
            'SecureCloseAll()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Continuar()
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Salir()
    End Sub

    Sub Continuar()
        If rbAccept.Checked = True Then
            UserClose = False
            If ReinstallMode = False Then
                SecureFormClose(StepC, Me)
            Else
                SecureFormClose(StepD, Me)
            End If
        Else
            UserClose = False
            AbortInstallProcess(Me, "El usuario no acepto el Acuerdo con el Usuario.")
        End If
    End Sub

    Sub Salir()
        Try
            UserClose = False
            AbortInstallProcess(Me, "El usuario salio de la ventana de Acuerdo con el Usuario")
        Catch ex As Exception
            AddToInstallerLog("Salir@StepB", "Error: " & ex.Message, False)
        End Try
    End Sub

    Private Sub rbAccept_CheckedChanged(sender As Object, e As EventArgs) Handles rbAccept.CheckedChanged
        If rbAccept.Checked = True Then
            btnNext.Enabled = True
        Else
            btnNext.Enabled = False
        End If
    End Sub
End Class