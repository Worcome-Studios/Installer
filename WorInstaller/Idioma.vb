Public Class Idioma
    Public Class Forms

        Public Class Main
            Public Class OnLoad
                Shared Sub ESP()
                    StepA.GroupBox1.Text = "Forma de instalación"
                    StepA.RadioButton1.Text = "Online (Recomendado)"
                    StepA.Label3.Text = "(Instala la última versión)"
                    StepA.Label4.Text = "(Instala la versión contenida en el instalador)"
                    StepA.btnNext.Text = "Siguiente >"
                    StepA.btnExit.Text = "< Salir"
                End Sub

                Shared Sub ENG()
                    StepA.GroupBox1.Text = "Installation way"
                    StepA.RadioButton1.Text = "Online (Recommended)"
                    StepA.Label3.Text = "(Install the latest version)"
                    StepA.Label4.Text = "(Install the version contained in the installer)"
                    StepA.btnNext.Text = "Next >"
                    StepA.btnExit.Text = "< Exit"
                End Sub

                Shared Sub AfterLoad()
                    StepA.Text = AssemblyName & " - Installer | Wor Installer"
                    StepA.lblTitle.Text = AssemblyPackageName & " - Installer"
                    If AppLanguage = 1 Then
                        StepA.lblBody.Text = "Seleccione el método de instalación: Online para una instalación actualizada u Offline para una instalación dependiendo del paquete de instalación contenida en el Instalador." &
                            vbCrLf & vbCrLf & "Recomendamos no dar clic en 'Siguiente >' como un si no hubiese mañana. Lea la información que le entregamos en las distintas etapas."
                    Else
                        StepA.lblBody.Text = "Select the installation method: Online for an updated installation or Offline for an installation depending on the installation package contained in the StepD." &
                            vbCrLf & vbCrLf & "We recommend not clicking 'Next>' as if there were no tomorrow. Read the information that we give you in the different stages."
                    End If
                End Sub
            End Class
        End Class

        Public Class Dos
            Public Class OnLoad
                Shared Sub ESP()
                    StepB.btnNext.Text = "Siguiente >"
                    StepB.btnExit.Text = "< Salir"
                    StepB.rbAccept.Text = "Acepto"
                    StepB.rbDontAccept.Text = "No acepto"
                End Sub

                Shared Sub ENG()
                    StepB.btnNext.Text = "Next >"
                    StepB.btnExit.Text = "< Exit"
                    StepB.rbAccept.Text = "I agree"
                    StepB.rbDontAccept.Text = "Not agree"
                End Sub

                Shared Sub AfterLoad()
                    If AppLanguage = 1 Then
                        If ReinstallMode = False Then
                            StepB.Text = AssemblyName & " - Installer | Acuerdo con el Usuario @ Wor Installer"
                        Else
                            StepB.Text = AssemblyName & " - Reinstaller | Acuerdo con el Usuario @ Wor Installer"
                        End If
                    Else
                        If ReinstallMode = False Then
                            StepB.Text = AssemblyName & " - Installer | Acuerdo con el Usuario @ Wor Installer"
                        Else
                            StepB.Text = AssemblyName & " - Reinstaller | Acuerdo con el Usuario @ Wor Installer"
                        End If
                    End If
                    If ReinstallMode = False Then
                        StepB.lblTitle.Text = AssemblyPackageName & " - Installer"
                    Else
                        StepB.lblTitle.Text = AssemblyPackageName & " - Reinstaller"
                    End If
                End Sub
            End Class
        End Class

        Public Class Tres
            Public Class OnLoad
                Shared Sub ESP()
                    StepC.btnNext.Text = "Instalar >"
                    StepC.btnExit.Text = "< Salir"
                    StepC.cbAllUserCanUse.Text = "Instalación para todos los usuarios"
                End Sub

                Shared Sub ENG()
                    StepC.btnNext.Text = "Install >"
                    StepC.btnExit.Text = "< Exit"
                    StepC.cbAllUserCanUse.Text = "Install for all users"
                End Sub

                Shared Sub AfterLoad()
                    If AppLanguage = 1 Then
                        StepC.Text = AssemblyName & " " & AssemblyVersion & " - Installer | Información sobre Componentes @ Wor Installer"
                    Else
                        StepC.Text = AssemblyName & " " & AssemblyVersion & " - Installer | Component Information @ Wor Installer"
                    End If
                    StepC.lblTitle.Text = AssemblyPackageName & " - Installer"
                End Sub
            End Class
        End Class

        Public Class Cuatro
            Public Class OnLoad
                Shared Sub ESP()
                    StepD.btnNext.Text = "Espere..."
                    StepD.btnExit.Text = "Cancelar"
                End Sub

                Shared Sub ENG()
                    StepD.btnNext.Text = "Waiting..."
                    StepD.btnExit.Text = "Cancel"
                End Sub

                Shared Sub AfterLoad()
                    If ReinstallMode = False Then
                        If UpdateMode = False Then
                            StepD.Text = AssemblyName & " " & AssemblyVersion & " - Installer"
                            StepD.lblTitle.Text = AssemblyPackageName & " - Installer"
                        Else
                            StepD.Text = AssemblyName & " " & AssemblyVersion & " - Updater"
                            StepD.lblTitle.Text = AssemblyPackageName & " - Updater"
                        End If
                    Else
                        StepD.Text = AssemblyName & " " & AssemblyVersion & " - Reinstaller"
                        StepD.lblTitle.Text = AssemblyPackageName & " - Reinstaller"
                    End If
                    If AppLanguage = 1 Then
                        If ReinstallMode = False Then
                            If UpdateMode = False Then
                                StepD.lblBody.Text = "Descarga e Instalación en curso" &
                                    vbCrLf & "El instalador descargará e instalará el programa." &
                                    vbCrLf & "Puede seguir utilizando su Equipo con normalidad."
                            Else
                                StepD.lblBody.Text = "Descarga y Actualización en curso" &
                                    vbCrLf & "El instalador descargará y actualizará el programa." &
                                    vbCrLf & "Puede seguir utilizando su Equipo con normalidad."
                            End If
                        Else
                            StepD.lblBody.Text = "Reinstalación en curso" &
                                vbCrLf & "No desconecte el equipo ni lo apague durante la instalación." &
                                vbCrLf & "Mantenga el equipo conectado a un punto de acceso a Internet." &
                                vbCrLf & "Todos los componentes serán Reinstalados."
                        End If
                    Else
                        If ReinstallMode = False Then
                            If UpdateMode = False Then
                                StepD.lblBody.Text = "Installation in progress" &
                                    vbCrLf & "You can continue using your PC normally."
                            Else
                                StepD.lblBody.Text = "Update in progress" &
                                    vbCrLf & "You can continue using your PC normally."
                            End If
                        Else
                            StepD.lblBody.Text = "Reinstallation in progress" &
                                vbCrLf & "Do not disconnect the PC or turn it off during installation." &
                                vbCrLf & "Keep the computer connected to an Internet access point." &
                                vbCrLf & "All components will be Reinstalled."
                        End If
                    End If
                    If AppLanguage = 1 Then
                        StepD.btnNext.Text = "Descargando..."
                    Else
                        StepD.btnNext.Text = "Downloading..."
                    End If
                End Sub
            End Class
        End Class

        Public Class Cinco
            Public Class OnLoad
                Shared Sub ESP()
                    StepE.btnEnd.Text = "Finalizar"
                    StepE.btnExit.Text = "Cancelar"
                    StepE.cbStartAssembly.Text = "Iniciar Wor: " & AssemblyPackageName & " al finalizar."
                    StepE.cbCreateLNK.Text = "Crear acceso directo"
                    StepE.cbSeeUseGuide.Text = "Ver la guía de uso."
                    StepE.cbSeeWhatsNew.Text = "Ver el historial de cambios."
                    StepE.cbSeeInformation.Text = "Ver informacion"
                    StepE.cbStartAssistant.Text = "Iniciar Asistente"
                End Sub

                Shared Sub ENG()
                    StepE.btnEnd.Text = "Finalize"
                    StepE.btnExit.Text = "Cancel"
                    StepE.cbStartAssembly.Text = "Start Wor: " & AssemblyPackageName & " when finished."
                    StepE.cbCreateLNK.Text = "Create Shortcut"
                    StepE.cbSeeUseGuide.Text = "See the usage guide."
                    StepE.cbSeeWhatsNew.Text = "View the changelog."
                    StepE.cbSeeInformation.Text = "See Information"
                    StepE.cbStartAssistant.Text = "Start Assistant"
                End Sub

                Shared Sub AfterLoad()
                    StepE.Text = AssemblyName & " " & AssemblyVersion
                    StepE.lblTitle.Text = AssemblyPackageName
                End Sub
            End Class
        End Class

        Public Class Assistant
            Public Class OnLoad
                Shared Sub ESP()
                    Asistente.btnExit.Text = "< Salir"
                    Asistente.lblBody.Text = "Asistente de post-instalación" & vbCrLf & vbCrLf & "   Elija una opción"
                    Asistente.lblReinstall.Text = "Una reinstalación completa, el instalador no limpiara datos del usuario"
                    Asistente.lblUninstall.Text = "Elimina el programa de tu ordenador"
                    Asistente.lblReset.Text = "Restauracion de fabrica, elimina todos sus archivos vinculados" & vbCrLf & "Eliminara bases de datos, datos del usuario, etc"
                    Asistente.lblSearchUpdates.Text = "Busca actualizaciones disponibles en el servidor"
                    Asistente.lblUpdate.Text = "Actualizar el programa a su versión más reciente"
                    Asistente.btnReinstall.Text = "Reinstalar"
                    Asistente.btnUninstall.Text = "Desinstalar"
                    Asistente.btnReset.Text = "Resetear"
                    Asistente.btnSearchUpdates.Text = "Buscar actualizaciones"
                    Asistente.btnUpdate.Text = "Actualizar"
                    Asistente.llblAbout.Text = "Ver About"
                    Asistente.llblUseGuide.Text = "Ver Guía de uso"
                End Sub

                Shared Sub ENG()
                    Asistente.btnExit.Text = "< Exit"
                    Asistente.lblBody.Text = "Post-installation wizard" & vbCrLf & vbCrLf & "    Choose an option"
                    Asistente.lblReinstall.Text = "Reinstall the program and delete all its linked files" & vbCrLf & "Delete databases, user data, etc."
                    Asistente.lblUninstall.Text = "Delete the program from your computer"
                    Asistente.lblReset.Text = "A complete reinstall, the installer will not wipe user data"
                    Asistente.lblSearchUpdates.Text = "Check for available updates on the server"
                    Asistente.lblUpdate.Text = "Update the program to its latest version"
                    Asistente.btnReinstall.Text = "Reinstall"
                    Asistente.btnUninstall.Text = "Uninstall"
                    Asistente.btnReset.Text = "Reset"
                    Asistente.btnSearchUpdates.Text = "Search for updates"
                    Asistente.btnUpdate.Text = "Update"
                    Asistente.llblAbout.Text = "See About"
                    Asistente.llblUseGuide.Text = "See Usage guide"
                End Sub

                Shared Sub AfterLoad()
                    If AppLanguage = 1 Then
                        Asistente.lblTitle.Text = AssemblyPackageName & " - Asistente"
                    Else
                        Asistente.lblTitle.Text = AssemblyPackageName & " - Assistant"
                    End If
                End Sub
            End Class
        End Class
    End Class
End Class