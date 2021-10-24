Public Class Asistente
    Public UserClose As Boolean = True

    Private Sub Asistente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Asistente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If UserClose Then
            End 'END_PROGRAM
        End If
    End Sub
End Class