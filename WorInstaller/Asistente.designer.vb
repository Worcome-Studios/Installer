<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Asistente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Asistente))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PIC_IMG_Icon = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblBody = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblAssemblyInfo = New System.Windows.Forms.Label()
        Me.rtbLog = New System.Windows.Forms.RichTextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.llblAbout = New System.Windows.Forms.LinkLabel()
        Me.btnReinstall = New System.Windows.Forms.Button()
        Me.btnUninstall = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.lblReinstall = New System.Windows.Forms.Label()
        Me.lblUninstall = New System.Windows.Forms.Label()
        Me.lblReset = New System.Windows.Forms.Label()
        Me.btnSearchUpdates = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.picAppIcon = New System.Windows.Forms.PictureBox()
        Me.llblUseGuide = New System.Windows.Forms.LinkLabel()
        Me.lblSearchUpdates = New System.Windows.Forms.Label()
        Me.PIC_IMG_Estandarte = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PIC_IMG_Icon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.picAppIcon, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(377, 37)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "Wor: AppName Installer"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBody
        '
        Me.lblBody.Location = New System.Drawing.Point(127, 111)
        Me.lblBody.Name = "lblBody"
        Me.lblBody.Size = New System.Drawing.Size(372, 64)
        Me.lblBody.TabIndex = 4
        Me.lblBody.Text = "Asistente de instalacion" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Eliga una opcion"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.lblAssemblyInfo)
        Me.Panel1.Controls.Add(Me.rtbLog)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Location = New System.Drawing.Point(118, 398)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(520, 113)
        Me.Panel1.TabIndex = 11
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(3, 60)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(105, 25)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "< Salir"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblAssemblyInfo
        '
        Me.lblAssemblyInfo.Location = New System.Drawing.Point(3, 3)
        Me.lblAssemblyInfo.Name = "lblAssemblyInfo"
        Me.lblAssemblyInfo.Size = New System.Drawing.Size(240, 54)
        Me.lblAssemblyInfo.TabIndex = 22
        '
        'rtbLog
        '
        Me.rtbLog.BackColor = System.Drawing.SystemColors.Control
        Me.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbLog.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.rtbLog.Location = New System.Drawing.Point(249, 3)
        Me.rtbLog.Name = "rtbLog"
        Me.rtbLog.ReadOnly = True
        Me.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtbLog.Size = New System.Drawing.Size(264, 82)
        Me.rtbLog.TabIndex = 8
        Me.rtbLog.Text = ""
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 91)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(510, 15)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 5
        '
        'llblAbout
        '
        Me.llblAbout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.llblAbout.Location = New System.Drawing.Point(409, 295)
        Me.llblAbout.Name = "llblAbout"
        Me.llblAbout.Size = New System.Drawing.Size(108, 13)
        Me.llblAbout.TabIndex = 5
        Me.llblAbout.TabStop = True
        Me.llblAbout.Text = "Ver About"
        Me.llblAbout.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnReinstall
        '
        Me.btnReinstall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReinstall.Location = New System.Drawing.Point(17, 109)
        Me.btnReinstall.Name = "btnReinstall"
        Me.btnReinstall.Size = New System.Drawing.Size(88, 42)
        Me.btnReinstall.TabIndex = 3
        Me.btnReinstall.Text = "Reinstalar"
        Me.btnReinstall.UseVisualStyleBackColor = True
        '
        'btnUninstall
        '
        Me.btnUninstall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUninstall.Location = New System.Drawing.Point(17, 157)
        Me.btnUninstall.Name = "btnUninstall"
        Me.btnUninstall.Size = New System.Drawing.Size(88, 42)
        Me.btnUninstall.TabIndex = 2
        Me.btnUninstall.Text = "Desinstalar"
        Me.btnUninstall.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.Location = New System.Drawing.Point(17, 205)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(88, 42)
        Me.btnReset.TabIndex = 1
        Me.btnReset.Text = "Resetear"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'lblReinstall
        '
        Me.lblReinstall.Location = New System.Drawing.Point(111, 109)
        Me.lblReinstall.Name = "lblReinstall"
        Me.lblReinstall.Size = New System.Drawing.Size(393, 42)
        Me.lblReinstall.TabIndex = 17
        Me.lblReinstall.Text = "Una reinstalacion completa, el instalador no limpiara datos del usuario"
        Me.lblReinstall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUninstall
        '
        Me.lblUninstall.Location = New System.Drawing.Point(111, 157)
        Me.lblUninstall.Name = "lblUninstall"
        Me.lblUninstall.Size = New System.Drawing.Size(393, 42)
        Me.lblUninstall.TabIndex = 18
        Me.lblUninstall.Text = "Elimina el programa de tu ordenador como si jamas hubiese sido instalado"
        Me.lblUninstall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReset
        '
        Me.lblReset.Location = New System.Drawing.Point(111, 205)
        Me.lblReset.Name = "lblReset"
        Me.lblReset.Size = New System.Drawing.Size(393, 42)
        Me.lblReset.TabIndex = 19
        Me.lblReset.Text = "Restauracion de fabrica, elimina todos sus archivos vinculados" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Eliminara bases d" &
    "e datos, datos del usuario, etc"
        Me.lblReset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSearchUpdates
        '
        Me.btnSearchUpdates.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearchUpdates.Location = New System.Drawing.Point(17, 253)
        Me.btnSearchUpdates.Name = "btnSearchUpdates"
        Me.btnSearchUpdates.Size = New System.Drawing.Size(88, 42)
        Me.btnSearchUpdates.TabIndex = 0
        Me.btnSearchUpdates.Text = "Buscar actualizaciones"
        Me.btnSearchUpdates.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.picAppIcon)
        Me.Panel2.Controls.Add(Me.llblUseGuide)
        Me.Panel2.Controls.Add(Me.lblSearchUpdates)
        Me.Panel2.Controls.Add(Me.llblAbout)
        Me.Panel2.Controls.Add(Me.btnReinstall)
        Me.Panel2.Controls.Add(Me.btnSearchUpdates)
        Me.Panel2.Controls.Add(Me.lblReset)
        Me.Panel2.Controls.Add(Me.btnUninstall)
        Me.Panel2.Controls.Add(Me.lblUninstall)
        Me.Panel2.Controls.Add(Me.btnReset)
        Me.Panel2.Controls.Add(Me.lblReinstall)
        Me.Panel2.Location = New System.Drawing.Point(118, 69)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(520, 328)
        Me.Panel2.TabIndex = 0
        '
        'picAppIcon
        '
        Me.picAppIcon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picAppIcon.ErrorImage = Nothing
        Me.picAppIcon.InitialImage = Nothing
        Me.picAppIcon.Location = New System.Drawing.Point(472, 3)
        Me.picAppIcon.Name = "picAppIcon"
        Me.picAppIcon.Size = New System.Drawing.Size(45, 45)
        Me.picAppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picAppIcon.TabIndex = 13
        Me.picAppIcon.TabStop = False
        Me.picAppIcon.Visible = False
        '
        'llblUseGuide
        '
        Me.llblUseGuide.Cursor = System.Windows.Forms.Cursors.Hand
        Me.llblUseGuide.Location = New System.Drawing.Point(409, 313)
        Me.llblUseGuide.Name = "llblUseGuide"
        Me.llblUseGuide.Size = New System.Drawing.Size(108, 13)
        Me.llblUseGuide.TabIndex = 6
        Me.llblUseGuide.TabStop = True
        Me.llblUseGuide.Text = "Ver Guia de uso"
        Me.llblUseGuide.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSearchUpdates
        '
        Me.lblSearchUpdates.Location = New System.Drawing.Point(111, 253)
        Me.lblSearchUpdates.Name = "lblSearchUpdates"
        Me.lblSearchUpdates.Size = New System.Drawing.Size(393, 42)
        Me.lblSearchUpdates.TabIndex = 23
        Me.lblSearchUpdates.Text = "Busca actualizaciones disponibles en el Servidor"
        Me.lblSearchUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PIC_IMG_Estandarte
        '
        Me.PIC_IMG_Estandarte.Image = Global.Wor_Installer.My.Resources.Resources.Estandarte
        Me.PIC_IMG_Estandarte.Location = New System.Drawing.Point(1, 118)
        Me.PIC_IMG_Estandarte.Name = "PIC_IMG_Estandarte"
        Me.PIC_IMG_Estandarte.Size = New System.Drawing.Size(115, 393)
        Me.PIC_IMG_Estandarte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PIC_IMG_Estandarte.TabIndex = 12
        Me.PIC_IMG_Estandarte.TabStop = False
        '
        'Asistente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 512)
        Me.Controls.Add(Me.lblBody)
        Me.Controls.Add(Me.PIC_IMG_Estandarte)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.PIC_IMG_Icon)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Asistente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wor Installer"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PIC_IMG_Icon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.picAppIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PIC_IMG_Estandarte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PIC_IMG_Icon As PictureBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblBody As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnExit As Button
    Friend WithEvents btnReinstall As Button
    Friend WithEvents btnUninstall As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents lblReinstall As Label
    Friend WithEvents lblUninstall As Label
    Friend WithEvents lblReset As Label
    Friend WithEvents rtbLog As RichTextBox
    Friend WithEvents lblAssemblyInfo As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents llblAbout As LinkLabel
    Friend WithEvents btnSearchUpdates As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblSearchUpdates As Label
    Friend WithEvents llblUseGuide As LinkLabel
    Friend WithEvents PIC_IMG_Estandarte As PictureBox
    Friend WithEvents picAppIcon As PictureBox
End Class
