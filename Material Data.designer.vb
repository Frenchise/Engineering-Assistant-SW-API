<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Material_Data
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
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.Directory_Exist = New System.Windows.Forms.ToolStripStatusLabel()
		Me.Open_PDF = New System.Windows.Forms.Button()
		Me.Default_Spacing = New System.Windows.Forms.Label()
		Me.Directory_Display_ListBox = New System.Windows.Forms.ListBox()
		Me.Material_Data_PDFs = New System.Windows.Forms.FolderBrowserDialog()
		Me.Directory_Display_ListView = New System.Windows.Forms.ListView()
		Me.StatusStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'StatusStrip1
		'
		Me.StatusStrip1.BackColor = System.Drawing.Color.White
		Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Directory_Exist})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 535)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(925, 22)
		Me.StatusStrip1.SizingGrip = False
		Me.StatusStrip1.TabIndex = 2
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'Directory_Exist
		'
		Me.Directory_Exist.Name = "Directory_Exist"
		Me.Directory_Exist.Size = New System.Drawing.Size(119, 17)
		Me.Directory_Exist.Text = "ToolStripStatusLabel1"
		'
		'Open_PDF
		'
		Me.Open_PDF.Location = New System.Drawing.Point(33, 101)
		Me.Open_PDF.Name = "Open_PDF"
		Me.Open_PDF.Size = New System.Drawing.Size(75, 23)
		Me.Open_PDF.TabIndex = 7
		Me.Open_PDF.Text = "Open PDF"
		Me.Open_PDF.UseVisualStyleBackColor = True
		'
		'Default_Spacing
		'
		Me.Default_Spacing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Default_Spacing.AutoSize = True
		Me.Default_Spacing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Default_Spacing.Location = New System.Drawing.Point(141, 9)
		Me.Default_Spacing.Name = "Default_Spacing"
		Me.Default_Spacing.Size = New System.Drawing.Size(152, 16)
		Me.Default_Spacing.TabIndex = 10
		Me.Default_Spacing.Text = "View Structural PDFs"
		'
		'Directory_Display_ListBox
		'
		Me.Directory_Display_ListBox.FormattingEnabled = True
		Me.Directory_Display_ListBox.Location = New System.Drawing.Point(641, 42)
		Me.Directory_Display_ListBox.Name = "Directory_Display_ListBox"
		Me.Directory_Display_ListBox.Size = New System.Drawing.Size(473, 394)
		Me.Directory_Display_ListBox.TabIndex = 11
		Me.Directory_Display_ListBox.Visible = False
		'
		'Material_Data_PDFs
		'
		Me.Material_Data_PDFs.SelectedPath = "T:\Engineering\Non-Site Specific\PARTS\LIBRARY\Structural Docs"
		Me.Material_Data_PDFs.ShowNewFolderButton = False
		'
		'Directory_Display_ListView
		'
		Me.Directory_Display_ListView.HideSelection = False
		Me.Directory_Display_ListView.LabelWrap = False
		Me.Directory_Display_ListView.Location = New System.Drawing.Point(127, 42)
		Me.Directory_Display_ListView.Name = "Directory_Display_ListView"
		Me.Directory_Display_ListView.Size = New System.Drawing.Size(784, 463)
		Me.Directory_Display_ListView.TabIndex = 12
		Me.Directory_Display_ListView.UseCompatibleStateImageBehavior = False
		Me.Directory_Display_ListView.View = System.Windows.Forms.View.Details
		'
		'Material_Data
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Window
		Me.ClientSize = New System.Drawing.Size(925, 557)
		Me.Controls.Add(Me.Directory_Display_ListView)
		Me.Controls.Add(Me.Directory_Display_ListBox)
		Me.Controls.Add(Me.Default_Spacing)
		Me.Controls.Add(Me.Open_PDF)
		Me.Controls.Add(Me.StatusStrip1)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(560, 300)
		Me.Name = "Material_Data"
		Me.ShowIcon = False
		Me.Text = "Material Data PDFs"
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents StatusStrip1 As StatusStrip
	Friend WithEvents Directory_Exist As ToolStripStatusLabel
	Friend WithEvents Open_PDF As Button
	Friend WithEvents Default_Spacing As Label
	Friend WithEvents Directory_Display_ListBox As ListBox
	Friend WithEvents Material_Data_PDFs As FolderBrowserDialog
	Friend WithEvents Directory_Display_ListView As ListView
End Class
