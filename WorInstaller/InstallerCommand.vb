Public Class InstallerCommand
    Dim commandQueue As New ArrayList

    Private Sub InstallerCommand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddSugesedCommands()
    End Sub

    Sub StartUp()
        Try
            RichTextBox1.SelectionColor = Color.White
            RichTextBox1.AppendText(My.Application.Info.AssemblyName & " [Versión " & My.Application.Info.Version.ToString & " (" & Application.ProductVersion & ")" & "]")
            RichTextBox1.AppendText(vbCrLf & "(c) " & My.Application.Info.CompanyName & ". All rights reserved.")
            RichTextBox1.SelectionColor = Color.LimeGreen
        Catch ex As Exception
            Console.WriteLine("[StartUp@InstallerCommand]Error: " & ex.Message)
        End Try
    End Sub
    Sub AddToCommandLog(ByVal from As String, ByVal message As String, Optional ByVal flag As SByte = 0)
        Try
            Dim flagColor As Color
            Dim flagContent As String = " "
            Select Case flag
                Case 0
                    flagColor = Color.LimeGreen
                Case 1
                    flagColor = Color.Red
                    flagContent = " !!! "
                Case 2
                    flagColor = Color.Blue
                    flagContent = " --- "
                Case 3
                    flagColor = Color.Yellow
                    flagContent = " <> "
                Case 4
                    flagColor = Color.DarkGray
                    flagContent = " OK "
                Case 5
                    flagColor = Color.White
            End Select
            RichTextBox1.SelectionColor = flagColor
            RichTextBox1.AppendText(vbCrLf & "[" & from & "]" & flagContent & message)
            RichTextBox1.SelectionColor = Color.LimeGreen
            RichTextBox1.ScrollToCaret()
        Catch ex As Exception
            Console.WriteLine("[AddToInstallerLog@InstallerCommand]Error: " & ex.Message)
        End Try
    End Sub

    Sub AddSugesedCommands()
        Try
            Dim suggestCommands As New AutoCompleteStringCollection
            suggestCommands.Add("/Installer.Start()")
            suggestCommands.Add("/Assistant.Show()")
            suggestCommands.Add("/Installer.Package.Get()")
            suggestCommands.Add("/Installer.Package.Set=")
            suggestCommands.Add("-S")
            suggestCommands.Add("-F")
            suggestCommands.Add("-FORCEDOWNGRADE")
            suggestCommands.Add("/UNINSTALL")
            ComboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
            ComboBox1.AutoCompleteCustomSource = suggestCommands
        Catch ex As Exception
            Console.WriteLine("[AddSugesedCommands@InstallerCommand]Error: " & ex.Message)
        End Try
    End Sub

    Sub ProcessCommand(ByVal command As String)
        Try
            AddToInstallerLog("ProcessCommand@InstallerCommand", command, True, 5)
            Dim parametro As String = command
            If parametro.ToLower Like "*/installer.start()*" Then
                StartPreInstallProcess()
            ElseIf parametro.ToLower Like "*/assistant.show()*" Then
                StartAssistant()
            ElseIf parametro.ToLower Like "*/installer.package.get()*" Then
                AddToInstallerLog("Response", "Actual Installer Package is Assembly=" & AssemblyName & " Version=" & AssemblyVersion, False, 2)
            ElseIf parametro.ToLower Like "*/installer.package.set=*" Then
                Dim Args As String = parametro.Remove(0, parametro.LastIndexOf("=") + 1)
                Dim Pars As String() = Args.Split(",")
                Debugger.SetAssemblyInfo(Pars(0).Trim(), Pars(1).Trim())
            ElseIf parametro.ToLower Like "*-s*" Then
                isSilenced = True
                AddToInstallerLog("Response", "Silence mode: " & isSilenced, False, 2)
            ElseIf parametro.ToLower Like "*-f*" Then
                isForced = True
                AddToInstallerLog("Response", "Forced mode: " & isForced, False, 2)
            ElseIf parametro.ToLower Like "*-forcedowngrade*" Then
                CanDowngrade = True
                AddToInstallerLog("Response", "AllowDowngrade: " & CanDowngrade, False, 2)
            ElseIf parametro.ToLower Like "*/uninstall*" Then
                InstallMode = False
                UninstallMode = True
                UpdateMode = False
                AssistantMode = True
                AddToInstallerLog("Response", "Uninstall mode: " & UninstallMode &
                            vbCrLf & "  InstallMode: " & InstallMode &
                            vbCrLf & "  UpdateMode: " & UpdateMode &
                            vbCrLf & "  AssistantMode: " & AssistantMode, False, 2)
            End If
        Catch ex As Exception
            AddToInstallerLog("ProcessCommand", "Error: " & ex.Message, True, 1)
            Console.WriteLine("[StartUp@InstallerCommand]Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendToQueue(ComboBox1.Text)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked Then 'AutoCommit ACTIVADO
            SendToQueue(ComboBox1.Text)
        Else 'AutoCommit DESACTIVADO
            For i As Integer = 0 To commandQueue.Count - 1
                Label1.Text = "Processing: " & commandQueue(i)
                ProcessCommand(commandQueue(i))
            Next
            commandQueue.Clear()
            Label1.Text = Nothing
        End If
    End Sub

    Sub SendToQueue(ByVal content As String)
        Try
            If ComboBox1.Text <> Nothing Then
                Label1.Text = "Sended: " & content
                If CheckBox1.Checked Then 'AutoCommit ACTIVADO
                    'Envia el comando
                    ProcessCommand(content)
                Else 'AutoCommit DESACTIVADO
                    'Guarda el comando
                    AddToInstallerLog("Queue", "Command: " & content, False, 5)
                    ComboBox1.Items.Add(content)
                    commandQueue.Add(content)
                End If
            End If
        Catch ex As Exception
            AddToInstallerLog("SendToQueue", "Error: " & ex.Message, True, 1)
            Console.WriteLine("[SendToQueue@InstallerCommand]Error: " & ex.Message)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then 'AutoCommit ACTIVADO
            Button1.Text = "Send"
        Else 'AutoCommit DESACTIVADO
            Button1.Text = "Commit"
        End If
    End Sub

    Private Sub InstallerCommand_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End 'END_PROGRAM
    End Sub
End Class