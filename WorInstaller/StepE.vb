Public Class StepE 'Conclusion / EndScreen / FIVE
    Public UserClose As Boolean = True

    Private Sub StepE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddToInstallerLog("StepE", "Step E Iniciado! " & DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), False)
        If AppLanguage = 1 Then
            Idioma.Forms.Cinco.OnLoad.ESP()
        Else
            Idioma.Forms.Cinco.OnLoad.ENG()
        End If
        Idioma.Forms.Cinco.OnLoad.AfterLoad()
        If AppImageLocation IsNot Nothing Then
            PIC_IMG_Icon.ImageLocation = AppImageLocation
        End If
        CreateTelemetry()
    End Sub
    Private Sub StepE_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If UserClose Then
            End 'END_PROGRAM
        End If
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        If Installer_NeedRestart Then
            AddToInstallerLog("StepE", "El equipo necesita un reinicio para completar la instalacion.", False)
            If isForced = False Then
                If MessageBox.Show("El programa requiere un reinicio del equipo." & vbCrLf & "¿Quiere reiniciar ahora?", "Reinicio pendiente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Process.Start("shutdown.exe", "/r")
                End If
            Else
                Process.Start("shutdown.exe", "/r /t 120")
                MsgBox("Se necesita reiniciar el equipo. El equipo se reiniciará en 2 minutos." & vbCrLf & "Para cancelar el reinicio, WINDOWS + R y escriba: shutdown.exe /a", MsgBoxStyle.Information)
            End If
        End If
        End 'END_PROGRAM
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End 'END_PROGRAM
    End Sub

    Sub SetStatus(ByVal message As String, ByVal type As SByte)
        Try
            If type = 0 Then '0 = Cancelado/Detenido/Interrumpido
                isFailedStatus()
            ElseIf type = 1 Then '1 = Exitoso
                isSucceedStatus()
            End If
            lblBody.Text = message
            AddToInstallerLog("StepE", "Estado de proceso de instalacion. " & type & ", " & message, False)
        Catch ex As Exception
            AddToInstallerLog("SetStatus@StepE", "Error: " & ex.Message, False)
        End Try
    End Sub

    Sub isFailedStatus()
        SendMessage(ProgressBar1.Handle, 1040, 2, 0)
        cbCreateLNK.Visible = False
        cbSeeInformation.Visible = False
        cbSeeUseGuide.Visible = False
        cbSeeWhatsNew.Visible = False
        cbStartAssembly.Visible = False
        cbStartAssistant.Visible = False
        btnEnd.Text = "Cerrar"
        btnExit.Enabled = False
    End Sub
    Sub isSucceedStatus()
        cbCreateLNK.Visible = True
        cbSeeInformation.Visible = True
        cbSeeUseGuide.Visible = True
        cbSeeWhatsNew.Visible = UpdateMode
        cbStartAssembly.Visible = True
        cbStartAssistant.Visible = True
        btnEnd.Text = "Cerrar"
        btnExit.Enabled = False
    End Sub
End Class