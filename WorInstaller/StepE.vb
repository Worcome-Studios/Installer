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
        If isSilenced Then
            Me.Hide()
            Finalizing()
            EndingProccess()
        End If
    End Sub
    Private Sub StepE_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If UserClose Then
            SecureCloseAll()
        End If
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        Finalizing()
        EndingProccess()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Sub EndingProccess()
        Try
            If ReinstallMode = False Then
                If UpdateMode = False Then
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
                    Me.Close()
                Else
                    Me.Close()
                End If
            Else
                Me.Close()
            End If
            Me.Close()
        Catch ex As Exception
            AddToInstallerLog("EndingProccess@StepE", "Error: " & ex.Message, False)
        End Try
    End Sub

    Sub Finalizing()
        Try
            If cbCreateLNK.Visible = True Then
                If cbCreateLNK.Checked = True Then
                    If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & AssemblyPackageName & ".lnk") Then
                        My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & AssemblyPackageName & ".lnk")
                    End If
                    'CREACION DEL ACCESO DIRECTO PARA DESKTOP
                    Dim WSHShell As Object = CreateObject("WScript.Shell")
                    Dim Shortcut As Object
                    Shortcut = WSHShell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & AssemblyPackageName & ".lnk")
                    Shortcut.IconLocation = InstallFolder & "\" & AssemblyName & ".exe" & ",0"
                    Shortcut.TargetPath = InstallFolder & "\" & AssemblyName & ".exe"
                    Shortcut.WindowStyle = 1
                    If AppLanguage = 1 Then
                        Shortcut.Description = "Iniciar " & AssemblyPackageName
                    Else
                        Shortcut.Description = "Start " & AssemblyPackageName
                    End If
                    Shortcut.Save()
                End If
            End If
            If Not isSilenced Then
                If cbSeeWhatsNew.Visible = True Then
                    If cbSeeWhatsNew.Checked = True Then
                        Process.Start(ServerSwitch.DIR_AppHelper & "/AboutApps/" & AssemblyName & ".html#WhatsNew")
                    End If
                End If

                If cbSeeUseGuide.Visible = True Then
                    If cbSeeUseGuide.Checked = True Then
                        Process.Start(ServerSwitch.DIR_AppHelper & "/" & AssemblyName & ".html")
                    End If
                End If

                If cbSeeInformation.Visible = True Then
                    If cbSeeInformation.Checked = True Then
                        Process.Start(ServerSwitch.DIR_AppHelper & "/AboutApps/" & AssemblyName & ".html")
                    End If
                End If

                If cbStartAssembly.Visible = True Then
                    If cbStartAssembly.Checked = True Then
                        Process.Start(InstallFolder & "\" & AssemblyName & ".exe")
                    End If
                End If

                If cbStartAssistant.Visible = True Then
                    If cbStartAssistant.Checked = True Then
                        Process.Start(InstallFolder & "\uninstall.exe", ArgCommandLine)
                    End If
                End If
            End If
        Catch ex As Exception
            AddToInstallerLog("Finalizing@StepE", "Error: " & ex.Message, False)
        End Try
    End Sub

    Sub SetStatus(ByVal message As String, ByVal type As SByte)
        Try
            If type = 0 Then '0 = Cancelado/Detenido/Interrumpido
                isFailedStatus()
            ElseIf type = 1 Then '1 = Exitoso
                isSucceedStatus()
            End If
            lblBody.Text = message
            AddToInstallerLog("StepE", "Estado de proceso. " & type & ", " & message, False)
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
        CorrectProcess = True
        cbCreateLNK.Visible = True
        cbSeeInformation.Visible = True
        cbSeeUseGuide.Visible = True
        cbSeeWhatsNew.Visible = UpdateMode
        cbStartAssembly.Visible = True
        cbStartAssistant.Visible = InstallMode
        btnEnd.Text = "Cerrar"
        btnExit.Enabled = False
    End Sub
End Class