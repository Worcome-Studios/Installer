<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StepA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StepA))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblBody = New System.Windows.Forms.Label()
        Me.PIC_IMG_Icon = New System.Windows.Forms.PictureBox()
        Me.PIC_IMG_Banner = New System.Windows.Forms.PictureBox()
        Me.PIC_IMG_Estandarte = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.PIC_IMG_Icon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PIC_IMG_Banner, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PIC_IMG_Estandarte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.lblBody.Size = New System.Drawing.Size(500, 300)
        Me.lblBody.TabIndex = 4
        Me.lblBody.Text = "Wor: AppName Installer" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "El instalador recopilara datos para estadisticas, los d" &
    "atos son anonimos y no lo identifican como individuo."
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
        'PIC_IMG_Banner
        '
        Me.PIC_IMG_Banner.Image = Global.Wor_Installer.My.Resources.Resources.Banner
        Me.PIC_IMG_Banner.Location = New System.Drawing.Point(118, 1)
        Me.PIC_IMG_Banner.Name = "PIC_IMG_Banner"
        Me.PIC_IMG_Banner.Size = New System.Drawing.Size(520, 65)
        Me.PIC_IMG_Banner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PIC_IMG_Banner.TabIndex = 0
        Me.PIC_IMG_Banner.TabStop = False
        '
        'PIC_IMG_Estandarte
        '
        Me.PIC_IMG_Estandarte.Image = Global.Wor_Installer.My.Resources.Resources.Estandarte
        Me.PIC_IMG_Estandarte.Location = New System.Drawing.Point(1, 118)
        Me.PIC_IMG_Estandarte.Name = "PIC_IMG_Estandarte"
        Me.PIC_IMG_Estandarte.Size = New System.Drawing.Size(115, 393)
        Me.PIC_IMG_Estandarte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PIC_IMG_Estandarte.TabIndex = 1
        Me.PIC_IMG_Estandarte.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnNext)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Location = New System.Drawing.Point(118, 414)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(520, 97)
        Me.Panel1.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(114, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(292, 70)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Forma de instalación"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(70, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(216, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "(Instala la versión contenida en el instalador)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(164, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "(Instala la última versión)"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Enabled = False
        Me.RadioButton2.Location = New System.Drawing.Point(6, 42)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(55, 17)
        Me.RadioButton2.TabIndex = 2
        Me.RadioButton2.Text = "Offline"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 19)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(134, 17)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Online (Recomendado)"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(412, 48)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(97, 25)
        Me.btnNext.TabIndex = 0
        Me.btnNext.Text = "Siguiente >"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 79)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(514, 15)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 5
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(3, 48)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(105, 25)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "< Salir"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(122, 462)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(505, 25)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Algo a salido mal"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StepA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 512)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblBody)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.PIC_IMG_Icon)
        Me.Controls.Add(Me.PIC_IMG_Banner)
        Me.Controls.Add(Me.PIC_IMG_Estandarte)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "StepA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Introduction | Wor Installer"
        CType(Me.PIC_IMG_Icon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PIC_IMG_Banner, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PIC_IMG_Estandarte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PIC_IMG_Banner As PictureBox
    Friend WithEvents PIC_IMG_Estandarte As PictureBox
    Friend WithEvents PIC_IMG_Icon As PictureBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblBody As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnNext As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents btnExit As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label5 As Label
End Class
