Public Class StepE 'Conclusion / EndScreen / FIVE
    Public UserClose As Boolean = True

    Private Sub StepE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If AppImageLocation IsNot Nothing Then
            PIC_IMG_Icon.ImageLocation = AppImageLocation
        End If
    End Sub
    Private Sub StepE_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If UserClose Then
            End 'END_PROGRAM
        End If
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
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