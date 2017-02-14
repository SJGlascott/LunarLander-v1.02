<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LanderClient
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LanderClient))
        Me.pbSurface = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblAngle = New System.Windows.Forms.Label()
        Me.lblVelX = New System.Windows.Forms.Label()
        Me.lblVelY = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLocX = New System.Windows.Forms.Label()
        Me.lblLocY = New System.Windows.Forms.Label()
        Me.lbl6 = New System.Windows.Forms.Label()
        Me.lblFuel = New System.Windows.Forms.Label()
        Me.lblLowFuel = New System.Windows.Forms.Label()
        Me.lblOutOfFuel = New System.Windows.Forms.Label()
        Me.picLander = New System.Windows.Forms.PictureBox()
        Me.timerRec = New System.Windows.Forms.Timer(Me.components)
        Me.landerPic2 = New System.Windows.Forms.PictureBox()
        Me.lblScoreValue = New System.Windows.Forms.Label()
        CType(Me.pbSurface, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLander, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.landerPic2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbSurface
        '
        Me.pbSurface.BackColor = System.Drawing.Color.Transparent
        Me.pbSurface.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbSurface.Location = New System.Drawing.Point(0, 0)
        Me.pbSurface.Name = "pbSurface"
        Me.pbSurface.Size = New System.Drawing.Size(1161, 633)
        Me.pbSurface.TabIndex = 0
        Me.pbSurface.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Angle"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(13, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Vel_X"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Vel_Y"
        '
        'lblAngle
        '
        Me.lblAngle.AutoSize = True
        Me.lblAngle.BackColor = System.Drawing.Color.Black
        Me.lblAngle.ForeColor = System.Drawing.Color.White
        Me.lblAngle.Location = New System.Drawing.Point(59, 13)
        Me.lblAngle.Name = "lblAngle"
        Me.lblAngle.Size = New System.Drawing.Size(39, 13)
        Me.lblAngle.TabIndex = 4
        Me.lblAngle.Text = "Label4"
        '
        'lblVelX
        '
        Me.lblVelX.AutoSize = True
        Me.lblVelX.BackColor = System.Drawing.Color.Black
        Me.lblVelX.ForeColor = System.Drawing.Color.White
        Me.lblVelX.Location = New System.Drawing.Point(59, 38)
        Me.lblVelX.Name = "lblVelX"
        Me.lblVelX.Size = New System.Drawing.Size(39, 13)
        Me.lblVelX.TabIndex = 5
        Me.lblVelX.Text = "Label4"
        '
        'lblVelY
        '
        Me.lblVelY.AutoSize = True
        Me.lblVelY.BackColor = System.Drawing.Color.Black
        Me.lblVelY.ForeColor = System.Drawing.Color.White
        Me.lblVelY.Location = New System.Drawing.Point(59, 63)
        Me.lblVelY.Name = "lblVelY"
        Me.lblVelY.Size = New System.Drawing.Size(39, 13)
        Me.lblVelY.TabIndex = 6
        Me.lblVelY.Text = "Label4"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Black
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(13, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Loc X"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(13, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Loc Y"
        '
        'lblLocX
        '
        Me.lblLocX.AutoSize = True
        Me.lblLocX.BackColor = System.Drawing.Color.Black
        Me.lblLocX.ForeColor = System.Drawing.Color.White
        Me.lblLocX.Location = New System.Drawing.Point(59, 84)
        Me.lblLocX.Name = "lblLocX"
        Me.lblLocX.Size = New System.Drawing.Size(39, 13)
        Me.lblLocX.TabIndex = 9
        Me.lblLocX.Text = "Label6"
        '
        'lblLocY
        '
        Me.lblLocY.AutoSize = True
        Me.lblLocY.BackColor = System.Drawing.Color.Black
        Me.lblLocY.ForeColor = System.Drawing.Color.White
        Me.lblLocY.Location = New System.Drawing.Point(59, 107)
        Me.lblLocY.Name = "lblLocY"
        Me.lblLocY.Size = New System.Drawing.Size(39, 13)
        Me.lblLocY.TabIndex = 10
        Me.lblLocY.Text = "Label6"
        '
        'lbl6
        '
        Me.lbl6.AutoSize = True
        Me.lbl6.BackColor = System.Drawing.Color.Black
        Me.lbl6.ForeColor = System.Drawing.Color.White
        Me.lbl6.Location = New System.Drawing.Point(13, 130)
        Me.lbl6.Name = "lbl6"
        Me.lbl6.Size = New System.Drawing.Size(27, 13)
        Me.lbl6.TabIndex = 11
        Me.lbl6.Text = "Fuel"
        '
        'lblFuel
        '
        Me.lblFuel.AutoSize = True
        Me.lblFuel.BackColor = System.Drawing.Color.Black
        Me.lblFuel.ForeColor = System.Drawing.Color.White
        Me.lblFuel.Location = New System.Drawing.Point(59, 130)
        Me.lblFuel.Name = "lblFuel"
        Me.lblFuel.Size = New System.Drawing.Size(39, 13)
        Me.lblFuel.TabIndex = 12
        Me.lblFuel.Text = "Label6"
        '
        'lblLowFuel
        '
        Me.lblLowFuel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblLowFuel.AutoSize = True
        Me.lblLowFuel.BackColor = System.Drawing.Color.Black
        Me.lblLowFuel.ForeColor = System.Drawing.Color.White
        Me.lblLowFuel.Location = New System.Drawing.Point(534, 310)
        Me.lblLowFuel.Name = "lblLowFuel"
        Me.lblLowFuel.Size = New System.Drawing.Size(93, 13)
        Me.lblLowFuel.TabIndex = 13
        Me.lblLowFuel.Text = "Warning Low Fuel"
        Me.lblLowFuel.Visible = False
        '
        'lblOutOfFuel
        '
        Me.lblOutOfFuel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblOutOfFuel.AutoSize = True
        Me.lblOutOfFuel.BackColor = System.Drawing.Color.Black
        Me.lblOutOfFuel.ForeColor = System.Drawing.Color.White
        Me.lblOutOfFuel.Location = New System.Drawing.Point(550, 310)
        Me.lblOutOfFuel.Name = "lblOutOfFuel"
        Me.lblOutOfFuel.Size = New System.Drawing.Size(61, 13)
        Me.lblOutOfFuel.TabIndex = 14
        Me.lblOutOfFuel.Text = "Out Of Fuel"
        Me.lblOutOfFuel.Visible = False
        '
        'picLander
        '
        Me.picLander.BackColor = System.Drawing.Color.Black
        Me.picLander.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picLander.Location = New System.Drawing.Point(153, 24)
        Me.picLander.Name = "picLander"
        Me.picLander.Size = New System.Drawing.Size(33, 27)
        Me.picLander.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLander.TabIndex = 15
        Me.picLander.TabStop = False
        '
        'timerRec
        '
        '
        'landerPic2
        '
        Me.landerPic2.BackColor = System.Drawing.Color.Black
        Me.landerPic2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.landerPic2.Image = CType(resources.GetObject("landerPic2.Image"), System.Drawing.Image)
        Me.landerPic2.Location = New System.Drawing.Point(114, 24)
        Me.landerPic2.Name = "landerPic2"
        Me.landerPic2.Size = New System.Drawing.Size(33, 27)
        Me.landerPic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.landerPic2.TabIndex = 16
        Me.landerPic2.TabStop = False
        '
        'lblScoreValue
        '
        Me.lblScoreValue.AutoSize = True
        Me.lblScoreValue.Location = New System.Drawing.Point(13, 147)
        Me.lblScoreValue.Name = "lblScoreValue"
        Me.lblScoreValue.Size = New System.Drawing.Size(38, 13)
        Me.lblScoreValue.TabIndex = 17
        Me.lblScoreValue.Text = "Score:"
        '
        'LanderClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1161, 633)
        Me.Controls.Add(Me.lblScoreValue)
        Me.Controls.Add(Me.landerPic2)
        Me.Controls.Add(Me.picLander)
        Me.Controls.Add(Me.lblOutOfFuel)
        Me.Controls.Add(Me.lblLowFuel)
        Me.Controls.Add(Me.lblFuel)
        Me.Controls.Add(Me.lbl6)
        Me.Controls.Add(Me.lblLocY)
        Me.Controls.Add(Me.lblLocX)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblVelY)
        Me.Controls.Add(Me.lblVelX)
        Me.Controls.Add(Me.lblAngle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbSurface)
        Me.Name = "LanderClient"
        Me.Text = "Lunar Lander"
        CType(Me.pbSurface, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLander, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.landerPic2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbSurface As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblAngle As System.Windows.Forms.Label
    Friend WithEvents lblVelX As System.Windows.Forms.Label
    Friend WithEvents lblVelY As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblLocX As System.Windows.Forms.Label
    Friend WithEvents lblLocY As System.Windows.Forms.Label
    Friend WithEvents lbl6 As System.Windows.Forms.Label
    Friend WithEvents lblFuel As System.Windows.Forms.Label
    Friend WithEvents lblLowFuel As System.Windows.Forms.Label
    Friend WithEvents lblOutOfFuel As System.Windows.Forms.Label
    Friend WithEvents picLander As System.Windows.Forms.PictureBox
    Friend WithEvents timerRec As System.Windows.Forms.Timer
    Friend WithEvents landerPic2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblScoreValue As System.Windows.Forms.Label

End Class
