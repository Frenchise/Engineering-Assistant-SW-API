<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Lib_Feat_Add
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
		Me.ComboBox1 = New System.Windows.Forms.ComboBox()
		Me.Add_Lib_To_Part = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Vertical_Dimension = New System.Windows.Forms.TextBox()
		Me.Horizontal_Dimension = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Rotation_Angle = New System.Windows.Forms.TextBox()
		Me.Default_Spacing = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'ComboBox1
		'
		Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.ComboBox1.FormattingEnabled = True
		Me.ComboBox1.Location = New System.Drawing.Point(121, 48)
		Me.ComboBox1.Name = "ComboBox1"
		Me.ComboBox1.Size = New System.Drawing.Size(405, 21)
		Me.ComboBox1.TabIndex = 0
		'
		'Add_Lib_To_Part
		'
		Me.Add_Lib_To_Part.Location = New System.Drawing.Point(289, 109)
		Me.Add_Lib_To_Part.Name = "Add_Lib_To_Part"
		Me.Add_Lib_To_Part.Size = New System.Drawing.Size(75, 23)
		Me.Add_Lib_To_Part.TabIndex = 4
		Me.Add_Lib_To_Part.Text = "Add"
		Me.Add_Lib_To_Part.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(11, 51)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(104, 13)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "Hole Pattern To Add"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(21, 83)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(94, 13)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "Vertical Dimension"
		'
		'Vertical_Dimension
		'
		Me.Vertical_Dimension.Location = New System.Drawing.Point(121, 80)
		Me.Vertical_Dimension.Margin = New System.Windows.Forms.Padding(3, 8, 3, 3)
		Me.Vertical_Dimension.Name = "Vertical_Dimension"
		Me.Vertical_Dimension.Size = New System.Drawing.Size(100, 20)
		Me.Vertical_Dimension.TabIndex = 1
		'
		'Horizontal_Dimension
		'
		Me.Horizontal_Dimension.Location = New System.Drawing.Point(121, 111)
		Me.Horizontal_Dimension.Margin = New System.Windows.Forms.Padding(3, 8, 3, 3)
		Me.Horizontal_Dimension.Name = "Horizontal_Dimension"
		Me.Horizontal_Dimension.Size = New System.Drawing.Size(100, 20)
		Me.Horizontal_Dimension.TabIndex = 2
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(9, 114)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(106, 13)
		Me.Label3.TabIndex = 5
		Me.Label3.Text = "Horizontal Dimension"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(16, 145)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(99, 13)
		Me.Label4.TabIndex = 7
		Me.Label4.Text = "Rotation Dimension"
		'
		'Rotation_Angle
		'
		Me.Rotation_Angle.Location = New System.Drawing.Point(121, 142)
		Me.Rotation_Angle.Margin = New System.Windows.Forms.Padding(3, 8, 3, 3)
		Me.Rotation_Angle.Name = "Rotation_Angle"
		Me.Rotation_Angle.Size = New System.Drawing.Size(100, 20)
		Me.Rotation_Angle.TabIndex = 3
		'
		'Default_Spacing
		'
		Me.Default_Spacing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Default_Spacing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Default_Spacing.Location = New System.Drawing.Point(83, 9)
		Me.Default_Spacing.Name = "Default_Spacing"
		Me.Default_Spacing.Size = New System.Drawing.Size(386, 17)
		Me.Default_Spacing.TabIndex = 9
		Me.Default_Spacing.Text = "Leave Dimension boxes empty to use default spacing"
		'
		'Lib_Feat_Add
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Window
		Me.ClientSize = New System.Drawing.Size(555, 284)
		Me.Controls.Add(Me.Default_Spacing)
		Me.Controls.Add(Me.Rotation_Angle)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Horizontal_Dimension)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Vertical_Dimension)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.Add_Lib_To_Part)
		Me.Controls.Add(Me.ComboBox1)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "Lib_Feat_Add"
		Me.ShowIcon = False
		Me.Text = "Add Feature To Part"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Add_Lib_To_Part As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Vertical_Dimension As TextBox
    Friend WithEvents Horizontal_Dimension As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Rotation_Angle As TextBox
    Friend WithEvents Default_Spacing As Label
End Class
