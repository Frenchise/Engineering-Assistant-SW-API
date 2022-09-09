<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Existing_Aircrafts_Stringers
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
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Manufacturer = New System.Windows.Forms.ComboBox()
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.Directory_Exist = New System.Windows.Forms.ToolStripStatusLabel()
		Me.Aircraft_Type = New System.Windows.Forms.ComboBox()
		Me.Aircraft_Type_Label = New System.Windows.Forms.Label()
		Me.Open_PDF = New System.Windows.Forms.Button()
		Me.Default_Spacing = New System.Windows.Forms.Label()
		Me.Existing_Structural_PDFs = New System.Windows.Forms.ListBox()
		Me.PDF_Amount = New System.Windows.Forms.Label()
		Me.Open_Native_Folder = New System.Windows.Forms.Button()
		Me.StatusStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(21, 45)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(103, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Select Manufacturer"
		'
		'Manufacturer
		'
		Me.Manufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Manufacturer.FormattingEnabled = True
		Me.Manufacturer.Location = New System.Drawing.Point(130, 42)
		Me.Manufacturer.Name = "Manufacturer"
		Me.Manufacturer.Size = New System.Drawing.Size(450, 21)
		Me.Manufacturer.TabIndex = 1
		'
		'StatusStrip1
		'
		Me.StatusStrip1.BackColor = System.Drawing.Color.White
		Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Directory_Exist})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 421)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(598, 22)
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
		'Aircraft_Type
		'
		Me.Aircraft_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Aircraft_Type.FormattingEnabled = True
		Me.Aircraft_Type.Location = New System.Drawing.Point(130, 69)
		Me.Aircraft_Type.Name = "Aircraft_Type"
		Me.Aircraft_Type.Size = New System.Drawing.Size(450, 21)
		Me.Aircraft_Type.TabIndex = 4
		'
		'Aircraft_Type_Label
		'
		Me.Aircraft_Type_Label.AutoSize = True
		Me.Aircraft_Type_Label.Location = New System.Drawing.Point(57, 72)
		Me.Aircraft_Type_Label.Name = "Aircraft_Type_Label"
		Me.Aircraft_Type_Label.Size = New System.Drawing.Size(67, 13)
		Me.Aircraft_Type_Label.TabIndex = 3
		Me.Aircraft_Type_Label.Text = "Aircraft Type"
		'
		'Open_PDF
		'
		Me.Open_PDF.Location = New System.Drawing.Point(230, 392)
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
		Me.Default_Spacing.Size = New System.Drawing.Size(228, 16)
		Me.Default_Spacing.TabIndex = 10
		Me.Default_Spacing.Text = "View An Aircraft's Stringer PDFs"
		'
		'Existing_Structural_PDFs
		'
		Me.Existing_Structural_PDFs.FormattingEnabled = True
		Me.Existing_Structural_PDFs.Location = New System.Drawing.Point(130, 96)
		Me.Existing_Structural_PDFs.Name = "Existing_Structural_PDFs"
		Me.Existing_Structural_PDFs.Size = New System.Drawing.Size(450, 290)
		Me.Existing_Structural_PDFs.TabIndex = 11
		'
		'PDF_Amount
		'
		Me.PDF_Amount.Location = New System.Drawing.Point(12, 96)
		Me.PDF_Amount.Name = "PDF_Amount"
		Me.PDF_Amount.Size = New System.Drawing.Size(112, 26)
		Me.PDF_Amount.TabIndex = 12
		Me.PDF_Amount.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Open_Native_Folder
		'
		Me.Open_Native_Folder.Location = New System.Drawing.Point(355, 392)
		Me.Open_Native_Folder.Name = "Open_Native_Folder"
		Me.Open_Native_Folder.Size = New System.Drawing.Size(75, 23)
		Me.Open_Native_Folder.TabIndex = 13
		Me.Open_Native_Folder.Text = "Open Native Folder"
		Me.Open_Native_Folder.UseVisualStyleBackColor = True
		'
		'Existing_Aircrafts_Stringers
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Window
		Me.ClientSize = New System.Drawing.Size(598, 443)
		Me.Controls.Add(Me.Open_Native_Folder)
		Me.Controls.Add(Me.PDF_Amount)
		Me.Controls.Add(Me.Existing_Structural_PDFs)
		Me.Controls.Add(Me.Default_Spacing)
		Me.Controls.Add(Me.Open_PDF)
		Me.Controls.Add(Me.Aircraft_Type)
		Me.Controls.Add(Me.Aircraft_Type_Label)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Controls.Add(Me.Manufacturer)
		Me.Controls.Add(Me.Label1)
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(614, 482)
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(614, 482)
		Me.Name = "Existing_Aircrafts_Stringers"
		Me.ShowIcon = False
		Me.Text = "Aircraft Structural Drawings"
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
    Friend WithEvents Manufacturer As ComboBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Directory_Exist As ToolStripStatusLabel
    Friend WithEvents Aircraft_Type As ComboBox
    Friend WithEvents Aircraft_Type_Label As Label
    Friend WithEvents Open_PDF As Button
    Friend WithEvents Default_Spacing As Label
    Friend WithEvents Existing_Structural_PDFs As ListBox
    Friend WithEvents PDF_Amount As Label
    Friend WithEvents Open_Native_Folder As Button
End Class
