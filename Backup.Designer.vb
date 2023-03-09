<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Backup
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Backup))
		Me.Structural_Group_Box = New System.Windows.Forms.GroupBox()
		Me.EMBRAER_Struct = New System.Windows.Forms.CheckBox()
		Me.LEARJET_Struct = New System.Windows.Forms.CheckBox()
		Me.HAWKER_Struct = New System.Windows.Forms.CheckBox()
		Me.GULFSTREAM_Struct = New System.Windows.Forms.CheckBox()
		Me.FALCON_Struct = New System.Windows.Forms.CheckBox()
		Me.CESSNA_Struct = New System.Windows.Forms.CheckBox()
		Me.BOMBARDIER_Struct = New System.Windows.Forms.CheckBox()
		Me.BEECHCRAFT_Struct = New System.Windows.Forms.CheckBox()
		Me.Struct_ACTypes = New System.Windows.Forms.CheckBox()
		Me.Electrical_Group_box = New System.Windows.Forms.GroupBox()
		Me.EMBRAER_Elect = New System.Windows.Forms.CheckBox()
		Me.LEARJET_Elect = New System.Windows.Forms.CheckBox()
		Me.HAWKER_Elect = New System.Windows.Forms.CheckBox()
		Me.GULFSTREAM_Elect = New System.Windows.Forms.CheckBox()
		Me.FALCON_Elect = New System.Windows.Forms.CheckBox()
		Me.CESSNA_Elect = New System.Windows.Forms.CheckBox()
		Me.BOMBARDIER_Elect = New System.Windows.Forms.CheckBox()
		Me.BEECHCRAFT_Elect = New System.Windows.Forms.CheckBox()
		Me.Elect_ACTypes = New System.Windows.Forms.CheckBox()
		Me.Update_Excel_Backups = New System.Windows.Forms.Button()
		Me.Clear_Chckbox = New System.Windows.Forms.Button()
		Me.Structural_Group_Box.SuspendLayout()
		Me.Electrical_Group_box.SuspendLayout()
		Me.SuspendLayout()
		'
		'Structural_Group_Box
		'
		Me.Structural_Group_Box.Controls.Add(Me.EMBRAER_Struct)
		Me.Structural_Group_Box.Controls.Add(Me.LEARJET_Struct)
		Me.Structural_Group_Box.Controls.Add(Me.HAWKER_Struct)
		Me.Structural_Group_Box.Controls.Add(Me.GULFSTREAM_Struct)
		Me.Structural_Group_Box.Controls.Add(Me.FALCON_Struct)
		Me.Structural_Group_Box.Controls.Add(Me.CESSNA_Struct)
		Me.Structural_Group_Box.Controls.Add(Me.BOMBARDIER_Struct)
		Me.Structural_Group_Box.Controls.Add(Me.BEECHCRAFT_Struct)
		Me.Structural_Group_Box.Controls.Add(Me.Struct_ACTypes)
		Me.Structural_Group_Box.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Structural_Group_Box.Location = New System.Drawing.Point(24, 24)
		Me.Structural_Group_Box.Margin = New System.Windows.Forms.Padding(15)
		Me.Structural_Group_Box.Name = "Structural_Group_Box"
		Me.Structural_Group_Box.Size = New System.Drawing.Size(200, 255)
		Me.Structural_Group_Box.TabIndex = 0
		Me.Structural_Group_Box.TabStop = False
		Me.Structural_Group_Box.Text = "STRUCT"
		'
		'EMBRAER_Struct
		'
		Me.EMBRAER_Struct.AutoSize = True
		Me.EMBRAER_Struct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.EMBRAER_Struct.Location = New System.Drawing.Point(23, 130)
		Me.EMBRAER_Struct.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
		Me.EMBRAER_Struct.Name = "EMBRAER_Struct"
		Me.EMBRAER_Struct.Size = New System.Drawing.Size(79, 17)
		Me.EMBRAER_Struct.TabIndex = 8
		Me.EMBRAER_Struct.Text = "EMBRAER"
		Me.EMBRAER_Struct.UseVisualStyleBackColor = True
		'
		'LEARJET_Struct
		'
		Me.LEARJET_Struct.AutoSize = True
		Me.LEARJET_Struct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.LEARJET_Struct.Location = New System.Drawing.Point(23, 222)
		Me.LEARJET_Struct.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
		Me.LEARJET_Struct.Name = "LEARJET_Struct"
		Me.LEARJET_Struct.Size = New System.Drawing.Size(73, 17)
		Me.LEARJET_Struct.TabIndex = 4
		Me.LEARJET_Struct.Text = "LEARJET"
		Me.LEARJET_Struct.UseVisualStyleBackColor = True
		'
		'HAWKER_Struct
		'
		Me.HAWKER_Struct.AutoSize = True
		Me.HAWKER_Struct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.HAWKER_Struct.Location = New System.Drawing.Point(23, 199)
		Me.HAWKER_Struct.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
		Me.HAWKER_Struct.Name = "HAWKER_Struct"
		Me.HAWKER_Struct.Size = New System.Drawing.Size(74, 17)
		Me.HAWKER_Struct.TabIndex = 6
		Me.HAWKER_Struct.Text = "HAWKER"
		Me.HAWKER_Struct.UseVisualStyleBackColor = True
		'
		'GULFSTREAM_Struct
		'
		Me.GULFSTREAM_Struct.AutoSize = True
		Me.GULFSTREAM_Struct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.GULFSTREAM_Struct.Location = New System.Drawing.Point(23, 176)
		Me.GULFSTREAM_Struct.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
		Me.GULFSTREAM_Struct.Name = "GULFSTREAM_Struct"
		Me.GULFSTREAM_Struct.Size = New System.Drawing.Size(99, 17)
		Me.GULFSTREAM_Struct.TabIndex = 5
		Me.GULFSTREAM_Struct.Text = "GULFSTREAM"
		Me.GULFSTREAM_Struct.UseVisualStyleBackColor = True
		'
		'FALCON_Struct
		'
		Me.FALCON_Struct.AutoSize = True
		Me.FALCON_Struct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.FALCON_Struct.Location = New System.Drawing.Point(23, 153)
		Me.FALCON_Struct.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
		Me.FALCON_Struct.Name = "FALCON_Struct"
		Me.FALCON_Struct.Size = New System.Drawing.Size(68, 17)
		Me.FALCON_Struct.TabIndex = 7
		Me.FALCON_Struct.Text = "FALCON"
		Me.FALCON_Struct.UseVisualStyleBackColor = True
		'
		'CESSNA_Struct
		'
		Me.CESSNA_Struct.AutoSize = True
		Me.CESSNA_Struct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.CESSNA_Struct.Location = New System.Drawing.Point(23, 107)
		Me.CESSNA_Struct.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
		Me.CESSNA_Struct.Name = "CESSNA_Struct"
		Me.CESSNA_Struct.Size = New System.Drawing.Size(69, 17)
		Me.CESSNA_Struct.TabIndex = 3
		Me.CESSNA_Struct.Text = "CESSNA"
		Me.CESSNA_Struct.UseVisualStyleBackColor = True
		'
		'BOMBARDIER_Struct
		'
		Me.BOMBARDIER_Struct.AutoSize = True
		Me.BOMBARDIER_Struct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.BOMBARDIER_Struct.Location = New System.Drawing.Point(23, 84)
		Me.BOMBARDIER_Struct.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
		Me.BOMBARDIER_Struct.Name = "BOMBARDIER_Struct"
		Me.BOMBARDIER_Struct.Size = New System.Drawing.Size(98, 17)
		Me.BOMBARDIER_Struct.TabIndex = 2
		Me.BOMBARDIER_Struct.Text = "BOMBARDIER"
		Me.BOMBARDIER_Struct.UseVisualStyleBackColor = True
		'
		'BEECHCRAFT_Struct
		'
		Me.BEECHCRAFT_Struct.AutoSize = True
		Me.BEECHCRAFT_Struct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.BEECHCRAFT_Struct.Location = New System.Drawing.Point(23, 61)
		Me.BEECHCRAFT_Struct.Margin = New System.Windows.Forms.Padding(20, 8, 3, 3)
		Me.BEECHCRAFT_Struct.Name = "BEECHCRAFT_Struct"
		Me.BEECHCRAFT_Struct.Size = New System.Drawing.Size(97, 17)
		Me.BEECHCRAFT_Struct.TabIndex = 1
		Me.BEECHCRAFT_Struct.Text = "BEECHCRAFT"
		Me.BEECHCRAFT_Struct.UseVisualStyleBackColor = True
		'
		'Struct_ACTypes
		'
		Me.Struct_ACTypes.AutoSize = True
		Me.Struct_ACTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Struct_ACTypes.Location = New System.Drawing.Point(6, 28)
		Me.Struct_ACTypes.Name = "Struct_ACTypes"
		Me.Struct_ACTypes.Size = New System.Drawing.Size(191, 22)
		Me.Struct_ACTypes.TabIndex = 0
		Me.Struct_ACTypes.Text = "ALL A/C TPYES BELOW"
		Me.Struct_ACTypes.UseVisualStyleBackColor = True
		'
		'Electrical_Group_box
		'
		Me.Electrical_Group_box.Controls.Add(Me.EMBRAER_Elect)
		Me.Electrical_Group_box.Controls.Add(Me.LEARJET_Elect)
		Me.Electrical_Group_box.Controls.Add(Me.HAWKER_Elect)
		Me.Electrical_Group_box.Controls.Add(Me.GULFSTREAM_Elect)
		Me.Electrical_Group_box.Controls.Add(Me.FALCON_Elect)
		Me.Electrical_Group_box.Controls.Add(Me.CESSNA_Elect)
		Me.Electrical_Group_box.Controls.Add(Me.BOMBARDIER_Elect)
		Me.Electrical_Group_box.Controls.Add(Me.BEECHCRAFT_Elect)
		Me.Electrical_Group_box.Controls.Add(Me.Elect_ACTypes)
		Me.Electrical_Group_box.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Electrical_Group_box.Location = New System.Drawing.Point(254, 24)
		Me.Electrical_Group_box.Margin = New System.Windows.Forms.Padding(15)
		Me.Electrical_Group_box.Name = "Electrical_Group_box"
		Me.Electrical_Group_box.Size = New System.Drawing.Size(200, 255)
		Me.Electrical_Group_box.TabIndex = 1
		Me.Electrical_Group_box.TabStop = False
		Me.Electrical_Group_box.Text = "ELECT"
		'
		'EMBRAER_Elect
		'
		Me.EMBRAER_Elect.AutoSize = True
		Me.EMBRAER_Elect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.EMBRAER_Elect.Location = New System.Drawing.Point(23, 130)
		Me.EMBRAER_Elect.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
		Me.EMBRAER_Elect.Name = "EMBRAER_Elect"
		Me.EMBRAER_Elect.Size = New System.Drawing.Size(79, 17)
		Me.EMBRAER_Elect.TabIndex = 8
		Me.EMBRAER_Elect.Text = "EMBRAER"
		Me.EMBRAER_Elect.UseVisualStyleBackColor = True
		'
		'LEARJET_Elect
		'
		Me.LEARJET_Elect.AutoSize = True
		Me.LEARJET_Elect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.LEARJET_Elect.Location = New System.Drawing.Point(23, 222)
		Me.LEARJET_Elect.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
		Me.LEARJET_Elect.Name = "LEARJET_Elect"
		Me.LEARJET_Elect.Size = New System.Drawing.Size(73, 17)
		Me.LEARJET_Elect.TabIndex = 4
		Me.LEARJET_Elect.Text = "LEARJET"
		Me.LEARJET_Elect.UseVisualStyleBackColor = True
		'
		'HAWKER_Elect
		'
		Me.HAWKER_Elect.AutoSize = True
		Me.HAWKER_Elect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.HAWKER_Elect.Location = New System.Drawing.Point(23, 199)
		Me.HAWKER_Elect.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
		Me.HAWKER_Elect.Name = "HAWKER_Elect"
		Me.HAWKER_Elect.Size = New System.Drawing.Size(74, 17)
		Me.HAWKER_Elect.TabIndex = 6
		Me.HAWKER_Elect.Text = "HAWKER"
		Me.HAWKER_Elect.UseVisualStyleBackColor = True
		'
		'GULFSTREAM_Elect
		'
		Me.GULFSTREAM_Elect.AutoSize = True
		Me.GULFSTREAM_Elect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.GULFSTREAM_Elect.Location = New System.Drawing.Point(23, 176)
		Me.GULFSTREAM_Elect.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
		Me.GULFSTREAM_Elect.Name = "GULFSTREAM_Elect"
		Me.GULFSTREAM_Elect.Size = New System.Drawing.Size(99, 17)
		Me.GULFSTREAM_Elect.TabIndex = 5
		Me.GULFSTREAM_Elect.Text = "GULFSTREAM"
		Me.GULFSTREAM_Elect.UseVisualStyleBackColor = True
		'
		'FALCON_Elect
		'
		Me.FALCON_Elect.AutoSize = True
		Me.FALCON_Elect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.FALCON_Elect.Location = New System.Drawing.Point(23, 153)
		Me.FALCON_Elect.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
		Me.FALCON_Elect.Name = "FALCON_Elect"
		Me.FALCON_Elect.Size = New System.Drawing.Size(68, 17)
		Me.FALCON_Elect.TabIndex = 7
		Me.FALCON_Elect.Text = "FALCON"
		Me.FALCON_Elect.UseVisualStyleBackColor = True
		'
		'CESSNA_Elect
		'
		Me.CESSNA_Elect.AutoSize = True
		Me.CESSNA_Elect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.CESSNA_Elect.Location = New System.Drawing.Point(23, 107)
		Me.CESSNA_Elect.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
		Me.CESSNA_Elect.Name = "CESSNA_Elect"
		Me.CESSNA_Elect.Size = New System.Drawing.Size(69, 17)
		Me.CESSNA_Elect.TabIndex = 3
		Me.CESSNA_Elect.Text = "CESSNA"
		Me.CESSNA_Elect.UseVisualStyleBackColor = True
		'
		'BOMBARDIER_Elect
		'
		Me.BOMBARDIER_Elect.AutoSize = True
		Me.BOMBARDIER_Elect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.BOMBARDIER_Elect.Location = New System.Drawing.Point(23, 84)
		Me.BOMBARDIER_Elect.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
		Me.BOMBARDIER_Elect.Name = "BOMBARDIER_Elect"
		Me.BOMBARDIER_Elect.Size = New System.Drawing.Size(98, 17)
		Me.BOMBARDIER_Elect.TabIndex = 2
		Me.BOMBARDIER_Elect.Text = "BOMBARDIER"
		Me.BOMBARDIER_Elect.UseVisualStyleBackColor = True
		'
		'BEECHCRAFT_Elect
		'
		Me.BEECHCRAFT_Elect.AutoSize = True
		Me.BEECHCRAFT_Elect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.BEECHCRAFT_Elect.Location = New System.Drawing.Point(23, 61)
		Me.BEECHCRAFT_Elect.Margin = New System.Windows.Forms.Padding(20, 8, 3, 3)
		Me.BEECHCRAFT_Elect.Name = "BEECHCRAFT_Elect"
		Me.BEECHCRAFT_Elect.Size = New System.Drawing.Size(97, 17)
		Me.BEECHCRAFT_Elect.TabIndex = 1
		Me.BEECHCRAFT_Elect.Text = "BEECHCRAFT"
		Me.BEECHCRAFT_Elect.UseVisualStyleBackColor = True
		'
		'Elect_ACTypes
		'
		Me.Elect_ACTypes.AutoSize = True
		Me.Elect_ACTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Elect_ACTypes.Location = New System.Drawing.Point(6, 28)
		Me.Elect_ACTypes.Name = "Elect_ACTypes"
		Me.Elect_ACTypes.Size = New System.Drawing.Size(191, 22)
		Me.Elect_ACTypes.TabIndex = 0
		Me.Elect_ACTypes.Text = "ALL A/C TPYES BELOW"
		Me.Elect_ACTypes.UseVisualStyleBackColor = True
		'
		'Update_Excel_Backups
		'
		Me.Update_Excel_Backups.Location = New System.Drawing.Point(162, 297)
		Me.Update_Excel_Backups.Name = "Update_Excel_Backups"
		Me.Update_Excel_Backups.Size = New System.Drawing.Size(150, 23)
		Me.Update_Excel_Backups.TabIndex = 2
		Me.Update_Excel_Backups.Text = "Do the updates"
		Me.Update_Excel_Backups.UseVisualStyleBackColor = True
		'
		'Clear_Chckbox
		'
		Me.Clear_Chckbox.Location = New System.Drawing.Point(318, 297)
		Me.Clear_Chckbox.Name = "Clear_Chckbox"
		Me.Clear_Chckbox.Size = New System.Drawing.Size(75, 23)
		Me.Clear_Chckbox.TabIndex = 3
		Me.Clear_Chckbox.Text = "Clear"
		Me.Clear_Chckbox.UseVisualStyleBackColor = True
		'
		'Backup
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Window
		Me.ClientSize = New System.Drawing.Size(479, 340)
		Me.Controls.Add(Me.Clear_Chckbox)
		Me.Controls.Add(Me.Update_Excel_Backups)
		Me.Controls.Add(Me.Electrical_Group_box)
		Me.Controls.Add(Me.Structural_Group_Box)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "Backup"
		Me.Text = "Engineering - Native and PDF files to Excel"
		Me.Structural_Group_Box.ResumeLayout(False)
		Me.Structural_Group_Box.PerformLayout()
		Me.Electrical_Group_box.ResumeLayout(False)
		Me.Electrical_Group_box.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents Structural_Group_Box As GroupBox
	Friend WithEvents EMBRAER_Struct As CheckBox
	Friend WithEvents LEARJET_Struct As CheckBox
	Friend WithEvents HAWKER_Struct As CheckBox
	Friend WithEvents GULFSTREAM_Struct As CheckBox
	Friend WithEvents FALCON_Struct As CheckBox
	Friend WithEvents CESSNA_Struct As CheckBox
	Friend WithEvents BOMBARDIER_Struct As CheckBox
	Friend WithEvents BEECHCRAFT_Struct As CheckBox
	Friend WithEvents Struct_ACTypes As CheckBox
	Friend WithEvents Electrical_Group_box As GroupBox
	Friend WithEvents EMBRAER_Elect As CheckBox
	Friend WithEvents LEARJET_Elect As CheckBox
	Friend WithEvents HAWKER_Elect As CheckBox
	Friend WithEvents GULFSTREAM_Elect As CheckBox
	Friend WithEvents FALCON_Elect As CheckBox
	Friend WithEvents CESSNA_Elect As CheckBox
	Friend WithEvents BOMBARDIER_Elect As CheckBox
	Friend WithEvents BEECHCRAFT_Elect As CheckBox
	Friend WithEvents Elect_ACTypes As CheckBox
	Friend WithEvents Update_Excel_Backups As Button
	Friend WithEvents Clear_Chckbox As Button
End Class
