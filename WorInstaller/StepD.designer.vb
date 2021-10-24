<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StepD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StepD))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PIC_IMG_Icon = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnRetry = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Timer_StartDownload = New System.Windows.Forms.Timer(Me.components)
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.PIC_IMG_Estandarte = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PIC_IMG_Icon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PIC_IMG_Estandarte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
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
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(122, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(505, 37)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Wor: AppName Installer"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(127, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(500, 75)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Instalacion en curso" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "No desconecte el equipo ni lo apage durante la instalacio" &
    "n." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Puede seguir utilizando su Equipo con normalidad."
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnRetry)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.btnNext)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Location = New System.Drawing.Point(118, 414)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(520, 97)
        Me.Panel1.TabIndex = 12
        '
        'btnRetry
        '
        Me.btnRetry.Enabled = False
        Me.btnRetry.Location = New System.Drawing.Point(178, 42)
        Me.btnRetry.Name = "btnRetry"
        Me.btnRetry.Size = New System.Drawing.Size(111, 31)
        Me.btnRetry.TabIndex = 2
        Me.btnRetry.Text = "Retry"
        Me.btnRetry.UseVisualStyleBackColor = True
        Me.btnRetry.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(114, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(239, 28)
        Me.Label4.TabIndex = 15
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(359, 48)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(150, 25)
        Me.btnNext.TabIndex = 0
        Me.btnNext.Text = "Espere..."
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 79)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(514, 15)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 5
        Me.ProgressBar1.Value = 60
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(3, 48)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(105, 25)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Cancelar"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.LightGray
        Me.RichTextBox1.Location = New System.Drawing.Point(129, 189)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(497, 219)
        Me.RichTextBox1.TabIndex = 13
        Me.RichTextBox1.Text = ""
        '
        'Timer_StartDownload
        '
        Me.Timer_StartDownload.Enabled = True
        Me.Timer_StartDownload.Interval = 1500
        '
        'WebBrowser1
        '
        Me.WebBrowser1.AllowWebBrowserDrop = False
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.Location = New System.Drawing.Point(3, -75)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.Size = New System.Drawing.Size(511, 369)
        Me.WebBrowser1.TabIndex = 1
        Me.WebBrowser1.TabStop = False
        Me.WebBrowser1.Url = New System.Uri("", System.UriKind.Relative)
        Me.WebBrowser1.Visible = False
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False
        '
        'PIC_IMG_Estandarte
        '
        Me.PIC_IMG_Estandarte.Image = Global.Wor_Installer.My.Resources.Resources.Estandarte
        Me.PIC_IMG_Estandarte.Location = New System.Drawing.Point(1, 118)
        Me.PIC_IMG_Estandarte.Name = "PIC_IMG_Estandarte"
        Me.PIC_IMG_Estandarte.Size = New System.Drawing.Size(115, 393)
        Me.PIC_IMG_Estandarte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PIC_IMG_Estandarte.TabIndex = 15
        Me.PIC_IMG_Estandarte.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.WebBrowser1)
        Me.Panel2.Location = New System.Drawing.Point(118, 189)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(517, 219)
        Me.Panel2.TabIndex = 16
        '
        'StepD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(639, 512)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PIC_IMG_Estandarte)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PIC_IMG_Icon)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "StepD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wor Installer"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PIC_IMG_Icon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PIC_IMG_Estandarte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PIC_IMG_Icon As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnNext As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents btnExit As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Timer_StartDownload As Timer
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents Label4 As Label
    Friend WithEvents PIC_IMG_Estandarte As PictureBox
    Friend WithEvents btnRetry As Button
    Friend WithEvents Panel2 As Panel
End Class
