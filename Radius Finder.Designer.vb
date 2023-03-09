<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Radius_Finder
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Radius_Finder))
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Radius_Image_Box = New System.Windows.Forms.PictureBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Height_Radius_Input = New System.Windows.Forms.TextBox()
		Me.Width_Radius_Input = New System.Windows.Forms.TextBox()
		Me.Radius_Output_Label = New System.Windows.Forms.Label()
		Me.Find_Radius = New System.Windows.Forms.Button()
		Me.Clear_Entries = New System.Windows.Forms.Button()
		CType(Me.Radius_Image_Box, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(219, 27)
		Me.Label1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(46, 16)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Height"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Radius_Image_Box
		'
		Me.Radius_Image_Box.Location = New System.Drawing.Point(12, 126)
		Me.Radius_Image_Box.Name = "Radius_Image_Box"
		Me.Radius_Image_Box.Size = New System.Drawing.Size(736, 312)
		Me.Radius_Image_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.Radius_Image_Box.TabIndex = 1
		Me.Radius_Image_Box.TabStop = False
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(224, 53)
		Me.Label2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(41, 16)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Width"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Height_Radius_Input
		'
		Me.Height_Radius_Input.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Height_Radius_Input.Location = New System.Drawing.Point(272, 24)
		Me.Height_Radius_Input.Name = "Height_Radius_Input"
		Me.Height_Radius_Input.Size = New System.Drawing.Size(100, 22)
		Me.Height_Radius_Input.TabIndex = 3
		'
		'Width_Radius_Input
		'
		Me.Width_Radius_Input.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Width_Radius_Input.Location = New System.Drawing.Point(272, 50)
		Me.Width_Radius_Input.Name = "Width_Radius_Input"
		Me.Width_Radius_Input.Size = New System.Drawing.Size(100, 22)
		Me.Width_Radius_Input.TabIndex = 4
		'
		'Radius_Output_Label
		'
		Me.Radius_Output_Label.AutoSize = True
		Me.Radius_Output_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Radius_Output_Label.Location = New System.Drawing.Point(215, 79)
		Me.Radius_Output_Label.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
		Me.Radius_Output_Label.Name = "Radius_Output_Label"
		Me.Radius_Output_Label.Size = New System.Drawing.Size(50, 16)
		Me.Radius_Output_Label.TabIndex = 5
		Me.Radius_Output_Label.Text = "Radius"
		Me.Radius_Output_Label.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Find_Radius
		'
		Me.Find_Radius.Location = New System.Drawing.Point(423, 23)
		Me.Find_Radius.Name = "Find_Radius"
		Me.Find_Radius.Size = New System.Drawing.Size(124, 23)
		Me.Find_Radius.TabIndex = 6
		Me.Find_Radius.Text = "Find That Radius"
		Me.Find_Radius.UseVisualStyleBackColor = True
		'
		'Clear_Entries
		'
		Me.Clear_Entries.Location = New System.Drawing.Point(423, 72)
		Me.Clear_Entries.Name = "Clear_Entries"
		Me.Clear_Entries.Size = New System.Drawing.Size(124, 23)
		Me.Clear_Entries.TabIndex = 7
		Me.Clear_Entries.Text = "Clear Entries"
		Me.Clear_Entries.UseVisualStyleBackColor = True
		'
		'Radius_Finder
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Window
		Me.ClientSize = New System.Drawing.Size(784, 450)
		Me.Controls.Add(Me.Clear_Entries)
		Me.Controls.Add(Me.Find_Radius)
		Me.Controls.Add(Me.Radius_Output_Label)
		Me.Controls.Add(Me.Width_Radius_Input)
		Me.Controls.Add(Me.Height_Radius_Input)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Radius_Image_Box)
		Me.Controls.Add(Me.Label1)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "Radius_Finder"
		Me.Text = "Radius Finder"
		CType(Me.Radius_Image_Box, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents Radius_Image_Box As PictureBox
	Friend WithEvents Label2 As Label
	Friend WithEvents Height_Radius_Input As TextBox
	Friend WithEvents Width_Radius_Input As TextBox
	Friend WithEvents Radius_Output_Label As Label
	Friend WithEvents Find_Radius As Button
	Friend WithEvents Clear_Entries As Button
End Class
