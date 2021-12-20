<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StepE
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StepE))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PIC_IMG_Icon = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblBody = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbStartAssistant = New System.Windows.Forms.CheckBox()
        Me.cbSeeInformation = New System.Windows.Forms.CheckBox()
        Me.cbSeeWhatsNew = New System.Windows.Forms.CheckBox()
        Me.cbSeeUseGuide = New System.Windows.Forms.CheckBox()
        Me.cbCreateLNK = New System.Windows.Forms.CheckBox()
        Me.cbStartAssembly = New System.Windows.Forms.CheckBox()
        Me.btnEnd = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.PIC_IMG_Estandarte = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PIC_IMG_Icon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PIC_IMG_Estandarte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Wor_Installer.My.Resources.Resources.Banner
        Me.PictureBox1.Location = New System.Drawing.Point(118, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(520, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PIC_IMG_Icon
        '
        Me.PIC_IMG_Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PIC_IMG_Icon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PIC_IMG_Icon.ErrorImage = Global.Wor_Installer.My.Resources.Resources.LogoWorInstaller
        Me.PIC_IMG_Icon.Image = Global.Wor_Installer.My.Resources.Resources.LogoWorInstaller
        Me.PIC_IMG_Icon.InitialImage = Global.Wor_Installer.My.Resources.Resources.LogoWorInstaller
        Me.PIC_IMG_Icon.Location = New System.Drawing.Point(1, 1)
        Me.PIC_IMG_Icon.Name = "PIC_IMG_Icon"
        Me.PIC_IMG_Icon.Size = New System.Drawing.Size(115, 115)
        Me.PIC_IMG_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PIC_IMG_Icon.TabIndex = 2
        Me.PIC_IMG_Icon.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(122, 69)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(505, 37)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "Wor: AppName Installer"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBody
        '
        Me.lblBody.Location = New System.Drawing.Point(127, 111)
        Me.lblBody.Name = "lblBody"
        Me.lblBody.Size = New System.Drawing.Size(500, 268)
        Me.lblBody.TabIndex = 4
        Me.lblBody.Text = "Finalizado" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "La instalacion finalizo correctamente" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "o" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "La instalacion fue interr" &
    "umpida"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cbStartAssistant)
        Me.Panel1.Controls.Add(Me.cbSeeInformation)
        Me.Panel1.Controls.Add(Me.cbSeeWhatsNew)
        Me.Panel1.Controls.Add(Me.cbSeeUseGuide)
        Me.Panel1.Controls.Add(Me.cbCreateLNK)
        Me.Panel1.Controls.Add(Me.cbStartAssembly)
        Me.Panel1.Controls.Add(Me.btnEnd)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Location = New System.Drawing.Point(118, 382)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(520, 129)
        Me.Panel1.TabIndex = 12
        '
        'cbStartAssistant
        '
        Me.cbStartAssistant.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cbStartAssistant.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbStartAssistant.Location = New System.Drawing.Point(198, 44)
        Me.cbStartAssistant.Name = "cbStartAssistant"
        Me.cbStartAssistant.Size = New System.Drawing.Size(125, 30)
        Me.cbStartAssistant.TabIndex = 5
        Me.cbStartAssistant.Text = "Iniciar Asistente"
        Me.cbStartAssistant.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cbStartAssistant.UseVisualStyleBackColor = True
        Me.cbStartAssistant.Visible = False
        '
        'cbSeeInformation
        '
        Me.cbSeeInformation.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cbSeeInformation.Checked = True
        Me.cbSeeInformation.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSeeInformation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbSeeInformation.Location = New System.Drawing.Point(359, 44)
        Me.cbSeeInformation.Name = "cbSeeInformation"
        Me.cbSeeInformation.Size = New System.Drawing.Size(155, 30)
        Me.cbSeeInformation.TabIndex = 6
        Me.cbSeeInformation.Text = "Ver Informacion"
        Me.cbSeeInformation.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cbSeeInformation.UseVisualStyleBackColor = True
        Me.cbSeeInformation.Visible = False
        '
        'cbSeeWhatsNew
        '
        Me.cbSeeWhatsNew.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cbSeeWhatsNew.Checked = True
        Me.cbSeeWhatsNew.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSeeWhatsNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbSeeWhatsNew.Location = New System.Drawing.Point(3, 44)
        Me.cbSeeWhatsNew.Name = "cbSeeWhatsNew"
        Me.cbSeeWhatsNew.Size = New System.Drawing.Size(158, 30)
        Me.cbSeeWhatsNew.TabIndex = 4
        Me.cbSeeWhatsNew.Text = "Ver el historial de cambios"
        Me.cbSeeWhatsNew.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cbSeeWhatsNew.UseVisualStyleBackColor = True
        Me.cbSeeWhatsNew.Visible = False
        '
        'cbSeeUseGuide
        '
        Me.cbSeeUseGuide.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cbSeeUseGuide.Checked = True
        Me.cbSeeUseGuide.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSeeUseGuide.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbSeeUseGuide.Location = New System.Drawing.Point(198, 8)
        Me.cbSeeUseGuide.Name = "cbSeeUseGuide"
        Me.cbSeeUseGuide.Size = New System.Drawing.Size(125, 30)
        Me.cbSeeUseGuide.TabIndex = 2
        Me.cbSeeUseGuide.Text = "Ver guia de uso"
        Me.cbSeeUseGuide.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cbSeeUseGuide.UseVisualStyleBackColor = True
        Me.cbSeeUseGuide.Visible = False
        '
        'cbCreateLNK
        '
        Me.cbCreateLNK.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cbCreateLNK.Checked = True
        Me.cbCreateLNK.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbCreateLNK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbCreateLNK.Location = New System.Drawing.Point(3, 8)
        Me.cbCreateLNK.Name = "cbCreateLNK"
        Me.cbCreateLNK.Size = New System.Drawing.Size(158, 30)
        Me.cbCreateLNK.TabIndex = 1
        Me.cbCreateLNK.Text = "Crear acceso directo"
        Me.cbCreateLNK.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cbCreateLNK.UseVisualStyleBackColor = True
        Me.cbCreateLNK.Visible = False
        '
        'cbStartAssembly
        '
        Me.cbStartAssembly.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cbStartAssembly.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbStartAssembly.Location = New System.Drawing.Point(359, 8)
        Me.cbStartAssembly.Name = "cbStartAssembly"
        Me.cbStartAssembly.Size = New System.Drawing.Size(158, 30)
        Me.cbStartAssembly.TabIndex = 3
        Me.cbStartAssembly.Text = "Iniciar <AppName>"
        Me.cbStartAssembly.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cbStartAssembly.UseVisualStyleBackColor = True
        Me.cbStartAssembly.Visible = False
        '
        'btnEnd
        '
        Me.btnEnd.Location = New System.Drawing.Point(359, 80)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(150, 25)
        Me.btnEnd.TabIndex = 0
        Me.btnEnd.Text = "Cerrar"
        Me.btnEnd.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 111)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(514, 15)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 5
        Me.ProgressBar1.Value = 100
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(3, 80)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(105, 25)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Cancelar"
        Me.btnExit.UseVisualStyleBackColor = True
        Me.btnExit.Visible = False
        '
        'PIC_IMG_Estandarte
        '
        Me.PIC_IMG_Estandarte.Image = Global.Wor_Installer.My.Resources.Resources.Estandarte
        Me.PIC_IMG_Estandarte.Location = New System.Drawing.Point(1, 118)
        Me.PIC_IMG_Estandarte.Name = "PIC_IMG_Estandarte"
        Me.PIC_IMG_Estandarte.Size = New System.Drawing.Size(115, 393)
        Me.PIC_IMG_Estandarte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PIC_IMG_Estandarte.TabIndex = 13
        Me.PIC_IMG_Estandarte.TabStop = False
        '
        'StepE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 512)
        Me.Controls.Add(Me.PIC_IMG_Estandarte)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblBody)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.PIC_IMG_Icon)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "StepE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conclusion | WorInstaller"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PIC_IMG_Icon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PIC_IMG_Estandarte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PIC_IMG_Icon As PictureBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblBody As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnEnd As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents btnExit As Button
    Friend WithEvents cbStartAssembly As CheckBox
    Friend WithEvents cbCreateLNK As CheckBox
    Friend WithEvents cbSeeUseGuide As CheckBox
    Friend WithEvents cbSeeWhatsNew As CheckBox
    Friend WithEvents PIC_IMG_Estandarte As PictureBox
    Friend WithEvents cbSeeInformation As CheckBox
    Friend WithEvents cbStartAssistant As CheckBox
End Class
