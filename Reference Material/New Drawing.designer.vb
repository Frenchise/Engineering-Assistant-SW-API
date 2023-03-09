<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class New_Drawing
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(New_Drawing))
		Me.Title_L = New System.Windows.Forms.Label()
		Me.Title = New System.Windows.Forms.TextBox()
		Me.AC_SN = New System.Windows.Forms.Label()
		Me.Request = New System.Windows.Forms.TextBox()
		Me.Request_By = New System.Windows.Forms.Label()
		Me.Generate_Drawing = New System.Windows.Forms.Button()
		Me.Opened_ASSY = New System.Windows.Forms.ListBox()
		Me.Opened_Part = New System.Windows.Forms.ListBox()
		Me.Reload = New System.Windows.Forms.Button()
		Me.Notes_Groups = New System.Windows.Forms.GroupBox()
		Me.Avionics_Instl_CheckBox = New System.Windows.Forms.CheckBox()
		Me.Nutplate_Instl_CheckBox = New System.Windows.Forms.CheckBox()
		Me.Insert_Instl_CheckBox = New System.Windows.Forms.CheckBox()
		Me.STD_Notes_CheckBox = New System.Windows.Forms.CheckBox()
		Me.Instructions_Label = New System.Windows.Forms.RichTextBox()
		Me.Add_BOM_Hardware = New System.Windows.Forms.CheckBox()
		Me.Drawing_Num = New System.Windows.Forms.TextBox()
		Me.Drawing_Num_Label = New System.Windows.Forms.Label()
		Me.AC_Serial = New System.Windows.Forms.ComboBox()
		Me.Same_Parts_Page_Checkbox = New System.Windows.Forms.CheckBox()
		Me.Same_Assy_Page_Checkbox = New System.Windows.Forms.CheckBox()
		Me.Add_All = New System.Windows.Forms.Button()
		Me.File_Rename_Checkbox = New System.Windows.Forms.CheckBox()
		Me.Notes_Groups.SuspendLayout()
		Me.SuspendLayout()
		'
		'Title_L
		'
		Me.Title_L.AutoSize = True
		Me.Title_L.Location = New System.Drawing.Point(72, 26)
		Me.Title_L.Name = "Title_L"
		Me.Title_L.Size = New System.Drawing.Size(27, 13)
		Me.Title_L.TabIndex = 0
		Me.Title_L.Text = "Title"
		'
		'Title
		'
		Me.Title.Location = New System.Drawing.Point(104, 23)
		Me.Title.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
		Me.Title.Name = "Title"
		Me.Title.Size = New System.Drawing.Size(268, 20)
		Me.Title.TabIndex = 1
		Me.Title.Text = "Optional"
		'
		'AC_SN
		'
		Me.AC_SN.AutoSize = True
		Me.AC_SN.Location = New System.Drawing.Point(27, 56)
		Me.AC_SN.Name = "AC_SN"
		Me.AC_SN.Size = New System.Drawing.Size(72, 13)
		Me.AC_SN.TabIndex = 3
		Me.AC_SN.Text = "Aircraft + S/N"
		'
		'Request
		'
		Me.Request.Location = New System.Drawing.Point(104, 84)
		Me.Request.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
		Me.Request.Name = "Request"
		Me.Request.Size = New System.Drawing.Size(268, 20)
		Me.Request.TabIndex = 3
		Me.Request.Text = "Optional"
		'
		'Request_By
		'
		Me.Request_By.AutoSize = True
		Me.Request_By.Location = New System.Drawing.Point(25, 88)
		Me.Request_By.Name = "Request_By"
		Me.Request_By.Size = New System.Drawing.Size(74, 13)
		Me.Request_By.TabIndex = 5
		Me.Request_By.Text = "Requested By"
		'
		'Generate_Drawing
		'
		Me.Generate_Drawing.Location = New System.Drawing.Point(95, 152)
		Me.Generate_Drawing.Margin = New System.Windows.Forms.Padding(15, 3, 15, 3)
		Me.Generate_Drawing.Name = "Generate_Drawing"
		Me.Generate_Drawing.Size = New System.Drawing.Size(60, 23)
		Me.Generate_Drawing.TabIndex = 6
		Me.Generate_Drawing.Text = "Generate"
		Me.Generate_Drawing.UseVisualStyleBackColor = True
		'
		'Opened_ASSY
		'
		Me.Opened_ASSY.FormattingEnabled = True
		Me.Opened_ASSY.Location = New System.Drawing.Point(274, 209)
		Me.Opened_ASSY.Margin = New System.Windows.Forms.Padding(15, 3, 15, 3)
		Me.Opened_ASSY.Name = "Opened_ASSY"
		Me.Opened_ASSY.Size = New System.Drawing.Size(214, 95)
		Me.Opened_ASSY.TabIndex = 9
		Me.Opened_ASSY.TabStop = False
		'
		'Opened_Part
		'
		Me.Opened_Part.FormattingEnabled = True
		Me.Opened_Part.Location = New System.Drawing.Point(30, 209)
		Me.Opened_Part.Margin = New System.Windows.Forms.Padding(15, 3, 15, 3)
		Me.Opened_Part.Name = "Opened_Part"
		Me.Opened_Part.Size = New System.Drawing.Size(214, 95)
		Me.Opened_Part.TabIndex = 10
		Me.Opened_Part.TabStop = False
		'
		'Reload
		'
		Me.Reload.Location = New System.Drawing.Point(30, 152)
		Me.Reload.Name = "Reload"
		Me.Reload.Size = New System.Drawing.Size(57, 23)
		Me.Reload.TabIndex = 5
		Me.Reload.Text = "Reload"
		Me.Reload.UseVisualStyleBackColor = True
		'
		'Notes_Groups
		'
		Me.Notes_Groups.Controls.Add(Me.Avionics_Instl_CheckBox)
		Me.Notes_Groups.Controls.Add(Me.Nutplate_Instl_CheckBox)
		Me.Notes_Groups.Controls.Add(Me.Insert_Instl_CheckBox)
		Me.Notes_Groups.Controls.Add(Me.STD_Notes_CheckBox)
		Me.Notes_Groups.Location = New System.Drawing.Point(396, 12)
		Me.Notes_Groups.Name = "Notes_Groups"
		Me.Notes_Groups.Size = New System.Drawing.Size(118, 126)
		Me.Notes_Groups.TabIndex = 12
		Me.Notes_Groups.TabStop = False
		Me.Notes_Groups.Text = "Notes"
		'
		'Avionics_Instl_CheckBox
		'
		Me.Avionics_Instl_CheckBox.AutoSize = True
		Me.Avionics_Instl_CheckBox.Location = New System.Drawing.Point(6, 95)
		Me.Avionics_Instl_CheckBox.Name = "Avionics_Instl_CheckBox"
		Me.Avionics_Instl_CheckBox.Size = New System.Drawing.Size(88, 17)
		Me.Avionics_Instl_CheckBox.TabIndex = 3
		Me.Avionics_Instl_CheckBox.Text = "Avionics Instl"
		Me.Avionics_Instl_CheckBox.UseVisualStyleBackColor = True
		'
		'Nutplate_Instl_CheckBox
		'
		Me.Nutplate_Instl_CheckBox.AutoSize = True
		Me.Nutplate_Instl_CheckBox.Location = New System.Drawing.Point(6, 72)
		Me.Nutplate_Instl_CheckBox.Name = "Nutplate_Instl_CheckBox"
		Me.Nutplate_Instl_CheckBox.Size = New System.Drawing.Size(88, 17)
		Me.Nutplate_Instl_CheckBox.TabIndex = 2
		Me.Nutplate_Instl_CheckBox.Text = "Nutplate Instl"
		Me.Nutplate_Instl_CheckBox.UseVisualStyleBackColor = True
		'
		'Insert_Instl_CheckBox
		'
		Me.Insert_Instl_CheckBox.AutoSize = True
		Me.Insert_Instl_CheckBox.Location = New System.Drawing.Point(7, 49)
		Me.Insert_Instl_CheckBox.Name = "Insert_Instl_CheckBox"
		Me.Insert_Instl_CheckBox.Size = New System.Drawing.Size(74, 17)
		Me.Insert_Instl_CheckBox.TabIndex = 1
		Me.Insert_Instl_CheckBox.Text = "Insert Intsl"
		Me.Insert_Instl_CheckBox.UseVisualStyleBackColor = True
		'
		'STD_Notes_CheckBox
		'
		Me.STD_Notes_CheckBox.AutoSize = True
		Me.STD_Notes_CheckBox.Location = New System.Drawing.Point(7, 26)
		Me.STD_Notes_CheckBox.Name = "STD_Notes_CheckBox"
		Me.STD_Notes_CheckBox.Size = New System.Drawing.Size(100, 17)
		Me.STD_Notes_CheckBox.TabIndex = 0
		Me.STD_Notes_CheckBox.Text = "Standard Notes"
		Me.STD_Notes_CheckBox.UseVisualStyleBackColor = True
		'
		'Instructions_Label
		'
		Me.Instructions_Label.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Instructions_Label.Location = New System.Drawing.Point(387, 30)
		Me.Instructions_Label.Name = "Instructions_Label"
		Me.Instructions_Label.Size = New System.Drawing.Size(135, 96)
		Me.Instructions_Label.TabIndex = 101
		Me.Instructions_Label.TabStop = False
		Me.Instructions_Label.Text = ""
		'
		'Add_BOM_Hardware
		'
		Me.Add_BOM_Hardware.AutoSize = True
		Me.Add_BOM_Hardware.Location = New System.Drawing.Point(238, 156)
		Me.Add_BOM_Hardware.Name = "Add_BOM_Hardware"
		Me.Add_BOM_Hardware.Size = New System.Drawing.Size(121, 17)
		Me.Add_BOM_Hardware.TabIndex = 8
		Me.Add_BOM_Hardware.TabStop = False
		Me.Add_BOM_Hardware.Text = "Add BOM Hardware"
		Me.Add_BOM_Hardware.UseVisualStyleBackColor = True
		'
		'Drawing_Num
		'
		Me.Drawing_Num.Location = New System.Drawing.Point(104, 114)
		Me.Drawing_Num.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
		Me.Drawing_Num.Name = "Drawing_Num"
		Me.Drawing_Num.Size = New System.Drawing.Size(268, 20)
		Me.Drawing_Num.TabIndex = 4
		Me.Drawing_Num.Text = "Optional"
		'
		'Drawing_Num_Label
		'
		Me.Drawing_Num_Label.AutoSize = True
		Me.Drawing_Num_Label.Location = New System.Drawing.Point(13, 117)
		Me.Drawing_Num_Label.Name = "Drawing_Num_Label"
		Me.Drawing_Num_Label.Size = New System.Drawing.Size(86, 13)
		Me.Drawing_Num_Label.TabIndex = 15
		Me.Drawing_Num_Label.Text = "Drawing Number"
		'
		'AC_Serial
		'
		Me.AC_Serial.FormattingEnabled = True
		Me.AC_Serial.Location = New System.Drawing.Point(104, 53)
		Me.AC_Serial.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
		Me.AC_Serial.Name = "AC_Serial"
		Me.AC_Serial.Size = New System.Drawing.Size(268, 21)
		Me.AC_Serial.TabIndex = 2
		Me.AC_Serial.Text = "Optional - Type your own"
		'
		'Same_Parts_Page_Checkbox
		'
		Me.Same_Parts_Page_Checkbox.AutoSize = True
		Me.Same_Parts_Page_Checkbox.Location = New System.Drawing.Point(75, 186)
		Me.Same_Parts_Page_Checkbox.Name = "Same_Parts_Page_Checkbox"
		Me.Same_Parts_Page_Checkbox.Size = New System.Drawing.Size(119, 17)
		Me.Same_Parts_Page_Checkbox.TabIndex = 102
		Me.Same_Parts_Page_Checkbox.TabStop = False
		Me.Same_Parts_Page_Checkbox.Text = "Add To Same Page"
		Me.Same_Parts_Page_Checkbox.UseVisualStyleBackColor = True
		'
		'Same_Assy_Page_Checkbox
		'
		Me.Same_Assy_Page_Checkbox.AutoSize = True
		Me.Same_Assy_Page_Checkbox.Location = New System.Drawing.Point(321, 186)
		Me.Same_Assy_Page_Checkbox.Name = "Same_Assy_Page_Checkbox"
		Me.Same_Assy_Page_Checkbox.Size = New System.Drawing.Size(119, 17)
		Me.Same_Assy_Page_Checkbox.TabIndex = 103
		Me.Same_Assy_Page_Checkbox.TabStop = False
		Me.Same_Assy_Page_Checkbox.Text = "Add To Same Page"
		Me.Same_Assy_Page_Checkbox.UseVisualStyleBackColor = True
		'
		'Add_All
		'
		Me.Add_All.Location = New System.Drawing.Point(160, 152)
		Me.Add_All.Margin = New System.Windows.Forms.Padding(15, 3, 15, 3)
		Me.Add_All.Name = "Add_All"
		Me.Add_All.Size = New System.Drawing.Size(60, 23)
		Me.Add_All.TabIndex = 7
		Me.Add_All.Text = "Add All"
		Me.Add_All.UseVisualStyleBackColor = True
		'
		'File_Rename_Checkbox
		'
		Me.File_Rename_Checkbox.AutoSize = True
		Me.File_Rename_Checkbox.Location = New System.Drawing.Point(365, 156)
		Me.File_Rename_Checkbox.Name = "File_Rename_Checkbox"
		Me.File_Rename_Checkbox.Size = New System.Drawing.Size(90, 17)
		Me.File_Rename_Checkbox.TabIndex = 104
		Me.File_Rename_Checkbox.TabStop = False
		Me.File_Rename_Checkbox.Text = "Rename Files"
		Me.File_Rename_Checkbox.UseVisualStyleBackColor = True
		'
		'New_Drawing
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Window
		Me.ClientSize = New System.Drawing.Size(534, 326)
		Me.Controls.Add(Me.File_Rename_Checkbox)
		Me.Controls.Add(Me.Add_All)
		Me.Controls.Add(Me.Same_Assy_Page_Checkbox)
		Me.Controls.Add(Me.Same_Parts_Page_Checkbox)
		Me.Controls.Add(Me.Instructions_Label)
		Me.Controls.Add(Me.AC_Serial)
		Me.Controls.Add(Me.Drawing_Num)
		Me.Controls.Add(Me.Drawing_Num_Label)
		Me.Controls.Add(Me.Add_BOM_Hardware)
		Me.Controls.Add(Me.Notes_Groups)
		Me.Controls.Add(Me.Reload)
		Me.Controls.Add(Me.Opened_Part)
		Me.Controls.Add(Me.Opened_ASSY)
		Me.Controls.Add(Me.Generate_Drawing)
		Me.Controls.Add(Me.Request)
		Me.Controls.Add(Me.Request_By)
		Me.Controls.Add(Me.AC_SN)
		Me.Controls.Add(Me.Title)
		Me.Controls.Add(Me.Title_L)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "New_Drawing"
		Me.Text = "A New Drawing Appeared"
		Me.Notes_Groups.ResumeLayout(False)
		Me.Notes_Groups.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Title_L As Label
	Friend WithEvents Title As TextBox
	Friend WithEvents AC_SN As Label
	Friend WithEvents Request As TextBox
	Friend WithEvents Request_By As Label
	Friend WithEvents Generate_Drawing As Button
	Friend WithEvents Opened_ASSY As ListBox
	Friend WithEvents Opened_Part As ListBox
	Friend WithEvents Reload As Button
	Friend WithEvents Notes_Groups As GroupBox
	Friend WithEvents Avionics_Instl_CheckBox As CheckBox
	Friend WithEvents Nutplate_Instl_CheckBox As CheckBox
	Friend WithEvents Insert_Instl_CheckBox As CheckBox
	Friend WithEvents STD_Notes_CheckBox As CheckBox
	Friend WithEvents Add_BOM_Hardware As CheckBox
	Friend WithEvents Drawing_Num As TextBox
	Friend WithEvents Drawing_Num_Label As Label
	Friend WithEvents AC_Serial As ComboBox
	Friend WithEvents Instructions_Label As RichTextBox
	Friend WithEvents Same_Parts_Page_Checkbox As CheckBox
	Friend WithEvents Same_Assy_Page_Checkbox As CheckBox
	Friend WithEvents Add_All As Button
	Friend WithEvents File_Rename_Checkbox As CheckBox
End Class
