<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class L_ANGLE_CONSTRUCTOR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(L_ANGLE_CONSTRUCTOR))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Show_Description = New System.Windows.Forms.Label()
        Me.ValueInput = New System.Windows.Forms.TextBox()
        Me.AcceptValue = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 121)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(284, 141)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Show_Description
        '
        Me.Show_Description.AutoSize = True
        Me.Show_Description.Location = New System.Drawing.Point(12, 9)
        Me.Show_Description.Name = "Show_Description"
        Me.Show_Description.Size = New System.Drawing.Size(39, 13)
        Me.Show_Description.TabIndex = 1
        Me.Show_Description.Text = "Label1"
        '
        'ValueInput
        '
        Me.ValueInput.Location = New System.Drawing.Point(108, 30)
        Me.ValueInput.Name = "ValueInput"
        Me.ValueInput.Size = New System.Drawing.Size(100, 20)
        Me.ValueInput.TabIndex = 2
        '
        'AcceptValue
        '
        Me.AcceptValue.Location = New System.Drawing.Point(108, 65)
        Me.AcceptValue.Name = "AcceptValue"
        Me.AcceptValue.Size = New System.Drawing.Size(75, 23)
        Me.AcceptValue.TabIndex = 3
        Me.AcceptValue.Text = "Button1"
        Me.AcceptValue.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Label1"
        '
        'L_ANGLE_CONSTRUCTOR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AcceptValue)
        Me.Controls.Add(Me.ValueInput)
        Me.Controls.Add(Me.Show_Description)
        Me.Controls.Add(Me.PictureBox1)
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "L_ANGLE_CONSTRUCTOR"
        Me.Text = "L Angle Constructor"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Show_Description As Label
    Friend WithEvents ValueInput As TextBox
    Friend WithEvents AcceptValue As Button
    Friend WithEvents Label1 As Label
End Class
