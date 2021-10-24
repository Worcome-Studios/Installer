<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StepB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StepB))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PIC_IMG_Icon = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.rbAccept = New System.Windows.Forms.RadioButton()
        Me.rbDontAccept = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rtbEULA = New System.Windows.Forms.RichTextBox()
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
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 79)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(514, 15)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 5
        Me.ProgressBar1.Value = 20
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(359, 48)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(150, 25)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Siguiente >"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(3, 48)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(105, 25)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "< Salir"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'rbAccept
        '
        Me.rbAccept.AutoSize = True
        Me.rbAccept.Enabled = False
        Me.rbAccept.Location = New System.Drawing.Point(359, 25)
        Me.rbAccept.Name = "rbAccept"
        Me.rbAccept.Size = New System.Drawing.Size(59, 17)
        Me.rbAccept.TabIndex = 1
        Me.rbAccept.Text = "Acepto"
        Me.rbAccept.UseVisualStyleBackColor = True
        '
        'rbDontAccept
        '
        Me.rbDontAccept.AutoSize = True
        Me.rbDontAccept.Checked = True
        Me.rbDontAccept.Location = New System.Drawing.Point(434, 25)
        Me.rbDontAccept.Name = "rbDontAccept"
        Me.rbDontAccept.Size = New System.Drawing.Size(75, 17)
        Me.rbDontAccept.TabIndex = 0
        Me.rbDontAccept.TabStop = True
        Me.rbDontAccept.Text = "No acepto"
        Me.rbDontAccept.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnNext)
        Me.Panel1.Controls.Add(Me.rbDontAccept)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.rbAccept)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Location = New System.Drawing.Point(118, 414)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(520, 97)
        Me.Panel1.TabIndex = 10
        '
        'rtbEULA
        '
        Me.rtbEULA.BackColor = System.Drawing.SystemColors.Control
        Me.rtbEULA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbEULA.Cursor = System.Windows.Forms.Cursors.Default
        Me.rtbEULA.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbEULA.Location = New System.Drawing.Point(127, 111)
        Me.rtbEULA.Name = "rtbEULA"
        Me.rtbEULA.ReadOnly = True
        Me.rtbEULA.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtbEULA.Size = New System.Drawing.Size(500, 297)
        Me.rtbEULA.TabIndex = 11
        Me.rtbEULA.Text = ""
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
        'StepB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 512)
        Me.Controls.Add(Me.PIC_IMG_Estandarte)
        Me.Controls.Add(Me.rtbEULA)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PIC_IMG_Icon)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "StepB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Wor Installer"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PIC_IMG_Icon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PIC_IMG_Estandarte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PIC_IMG_Icon As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents btnNext As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents rbAccept As RadioButton
    Friend WithEvents rbDontAccept As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rtbEULA As RichTextBox
    Friend WithEvents PIC_IMG_Estandarte As PictureBox
End Class
