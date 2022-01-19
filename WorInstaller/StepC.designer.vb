<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StepC
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StepC))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PIC_IMG_Icon = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblAssemblyInfo = New System.Windows.Forms.Label()
        Me.cbAllUserCanUse = New System.Windows.Forms.CheckBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Timer_StartDownload = New System.Windows.Forms.Timer(Me.components)
        Me.PIC_IMG_Estandarte = New System.Windows.Forms.PictureBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PIC_IMG_Icon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PIC_IMG_Estandarte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.lblAssemblyInfo)
        Me.Panel1.Controls.Add(Me.cbAllUserCanUse)
        Me.Panel1.Controls.Add(Me.btnNext)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Location = New System.Drawing.Point(118, 414)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(520, 97)
        Me.Panel1.TabIndex = 11
        '
        'lblAssemblyInfo
        '
        Me.lblAssemblyInfo.Location = New System.Drawing.Point(114, 13)
        Me.lblAssemblyInfo.Name = "lblAssemblyInfo"
        Me.lblAssemblyInfo.Size = New System.Drawing.Size(226, 37)
        Me.lblAssemblyInfo.TabIndex = 16
        Me.lblAssemblyInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbAllUserCanUse
        '
        Me.cbAllUserCanUse.Checked = True
        Me.cbAllUserCanUse.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAllUserCanUse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbAllUserCanUse.Enabled = False
        Me.cbAllUserCanUse.Location = New System.Drawing.Point(114, 53)
        Me.cbAllUserCanUse.Name = "cbAllUserCanUse"
        Me.cbAllUserCanUse.Size = New System.Drawing.Size(226, 17)
        Me.cbAllUserCanUse.TabIndex = 1
        Me.cbAllUserCanUse.Text = "Instalación para todos los usuarios"
        Me.cbAllUserCanUse.UseVisualStyleBackColor = True
        Me.cbAllUserCanUse.Visible = False
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(346, 48)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(163, 25)
        Me.btnNext.TabIndex = 0
        Me.btnNext.Text = "Instalar >"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 79)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(514, 15)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 5
        Me.ProgressBar1.Value = 40
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
        'Timer_StartDownload
        '
        Me.Timer_StartDownload.Interval = 1500
        '
        'PIC_IMG_Estandarte
        '
        Me.PIC_IMG_Estandarte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PIC_IMG_Estandarte.Image = Global.Wor_Installer.My.Resources.Resources.Estandarte
        Me.PIC_IMG_Estandarte.Location = New System.Drawing.Point(1, 118)
        Me.PIC_IMG_Estandarte.Name = "PIC_IMG_Estandarte"
        Me.PIC_IMG_Estandarte.Size = New System.Drawing.Size(115, 393)
        Me.PIC_IMG_Estandarte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PIC_IMG_Estandarte.TabIndex = 13
        Me.PIC_IMG_Estandarte.TabStop = False
        '
        'WebBrowser1
        '
        Me.WebBrowser1.AllowWebBrowserDrop = False
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.Location = New System.Drawing.Point(118, 109)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.Size = New System.Drawing.Size(520, 302)
        Me.WebBrowser1.TabIndex = 2
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False
        '
        'StepC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 512)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.PIC_IMG_Estandarte)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.PIC_IMG_Icon)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(655, 551)
        Me.Name = "StepC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Assembly Information | WorInstaller"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PIC_IMG_Icon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PIC_IMG_Estandarte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PIC_IMG_Icon As PictureBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnNext As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents btnExit As Button
    Friend WithEvents Timer_StartDownload As Timer
    Friend WithEvents cbAllUserCanUse As CheckBox
    Friend WithEvents lblAssemblyInfo As Label
    Friend WithEvents PIC_IMG_Estandarte As PictureBox
    Friend WithEvents WebBrowser1 As WebBrowser
End Class
