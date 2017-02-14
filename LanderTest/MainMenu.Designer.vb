<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
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
        Me.btnServer = New System.Windows.Forms.Button()
        Me.btnClient = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnMusic = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnServer
        '
        Me.btnServer.Location = New System.Drawing.Point(61, 132)
        Me.btnServer.Name = "btnServer"
        Me.btnServer.Size = New System.Drawing.Size(75, 23)
        Me.btnServer.TabIndex = 0
        Me.btnServer.Text = "Server"
        Me.btnServer.UseVisualStyleBackColor = True
        '
        'btnClient
        '
        Me.btnClient.Location = New System.Drawing.Point(142, 132)
        Me.btnClient.Name = "btnClient"
        Me.btnClient.Size = New System.Drawing.Size(75, 23)
        Me.btnClient.TabIndex = 1
        Me.btnClient.Text = "Client"
        Me.btnClient.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(85, 79)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Single Player"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(108, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Single Player:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(108, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Multiplayer:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(225, 31)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "LUNAR LANDER"
        '
        'btnMusic
        '
        Me.btnMusic.Location = New System.Drawing.Point(85, 155)
        Me.btnMusic.Name = "btnMusic"
        Me.btnMusic.Size = New System.Drawing.Size(110, 23)
        Me.btnMusic.TabIndex = 6
        Me.btnMusic.Text = "Stop Music"
        Me.btnMusic.UseVisualStyleBackColor = True
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 190)
        Me.Controls.Add(Me.btnMusic)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnClient)
        Me.Controls.Add(Me.btnServer)
        Me.Name = "MainMenu"
        Me.Text = "MainMenu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnServer As System.Windows.Forms.Button
    Friend WithEvents btnClient As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnMusic As System.Windows.Forms.Button
End Class
