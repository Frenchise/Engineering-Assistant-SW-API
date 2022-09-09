<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cross_Product
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cross_Product))
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Force_k = New System.Windows.Forms.TextBox()
		Me.Force_j = New System.Windows.Forms.TextBox()
		Me.Force_i = New System.Windows.Forms.TextBox()
		Me.Distance_k = New System.Windows.Forms.TextBox()
		Me.Distance_j = New System.Windows.Forms.TextBox()
		Me.Distance_i = New System.Windows.Forms.TextBox()
		Me.j_Vector = New System.Windows.Forms.Label()
		Me.i_Vector = New System.Windows.Forms.Label()
		Me.k_Vector = New System.Windows.Forms.Label()
		Me.Force_Vector = New System.Windows.Forms.Label()
		Me.Distance_Vector = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Cross_Product_Result = New System.Windows.Forms.Label()
		Me.X_Result = New System.Windows.Forms.Label()
		Me.Y_Result = New System.Windows.Forms.Label()
		Me.Z_Result = New System.Windows.Forms.Label()
		Me.Resultant = New System.Windows.Forms.Label()
		Me.Clear_Button = New System.Windows.Forms.Button()
		Me.GroupBox1.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.Panel1)
		Me.GroupBox1.Controls.Add(Me.Force_Vector)
		Me.GroupBox1.Controls.Add(Me.Distance_Vector)
		Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(289, 142)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Cross Product"
		'
		'Panel1
		'
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Panel1.Controls.Add(Me.Force_k)
		Me.Panel1.Controls.Add(Me.Force_j)
		Me.Panel1.Controls.Add(Me.Force_i)
		Me.Panel1.Controls.Add(Me.Distance_k)
		Me.Panel1.Controls.Add(Me.Distance_j)
		Me.Panel1.Controls.Add(Me.Distance_i)
		Me.Panel1.Controls.Add(Me.j_Vector)
		Me.Panel1.Controls.Add(Me.i_Vector)
		Me.Panel1.Controls.Add(Me.k_Vector)
		Me.Panel1.Location = New System.Drawing.Point(64, 19)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(207, 106)
		Me.Panel1.TabIndex = 5
		'
		'Force_k
		'
		Me.Force_k.Location = New System.Drawing.Point(135, 75)
		Me.Force_k.Name = "Force_k"
		Me.Force_k.Size = New System.Drawing.Size(54, 20)
		Me.Force_k.TabIndex = 15
		Me.Force_k.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Force_j
		'
		Me.Force_j.Location = New System.Drawing.Point(75, 75)
		Me.Force_j.Name = "Force_j"
		Me.Force_j.Size = New System.Drawing.Size(54, 20)
		Me.Force_j.TabIndex = 14
		Me.Force_j.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Force_i
		'
		Me.Force_i.Location = New System.Drawing.Point(15, 75)
		Me.Force_i.Name = "Force_i"
		Me.Force_i.Size = New System.Drawing.Size(54, 20)
		Me.Force_i.TabIndex = 13
		Me.Force_i.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Distance_k
		'
		Me.Distance_k.Location = New System.Drawing.Point(135, 33)
		Me.Distance_k.Name = "Distance_k"
		Me.Distance_k.Size = New System.Drawing.Size(54, 20)
		Me.Distance_k.TabIndex = 12
		Me.Distance_k.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Distance_j
		'
		Me.Distance_j.Location = New System.Drawing.Point(75, 33)
		Me.Distance_j.Name = "Distance_j"
		Me.Distance_j.Size = New System.Drawing.Size(54, 20)
		Me.Distance_j.TabIndex = 11
		Me.Distance_j.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Distance_i
		'
		Me.Distance_i.Location = New System.Drawing.Point(15, 33)
		Me.Distance_i.Name = "Distance_i"
		Me.Distance_i.Size = New System.Drawing.Size(54, 20)
		Me.Distance_i.TabIndex = 10
		Me.Distance_i.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'j_Vector
		'
		Me.j_Vector.AutoSize = True
		Me.j_Vector.Location = New System.Drawing.Point(95, 7)
		Me.j_Vector.Name = "j_Vector"
		Me.j_Vector.Size = New System.Drawing.Size(9, 13)
		Me.j_Vector.TabIndex = 2
		Me.j_Vector.Text = "j"
		'
		'i_Vector
		'
		Me.i_Vector.AutoSize = True
		Me.i_Vector.Location = New System.Drawing.Point(26, 7)
		Me.i_Vector.Name = "i_Vector"
		Me.i_Vector.Size = New System.Drawing.Size(9, 13)
		Me.i_Vector.TabIndex = 1
		Me.i_Vector.Text = "i"
		'
		'k_Vector
		'
		Me.k_Vector.AutoSize = True
		Me.k_Vector.Location = New System.Drawing.Point(163, 7)
		Me.k_Vector.Name = "k_Vector"
		Me.k_Vector.Size = New System.Drawing.Size(13, 13)
		Me.k_Vector.TabIndex = 3
		Me.k_Vector.Text = "k"
		'
		'Force_Vector
		'
		Me.Force_Vector.Location = New System.Drawing.Point(10, 95)
		Me.Force_Vector.Name = "Force_Vector"
		Me.Force_Vector.Size = New System.Drawing.Size(52, 30)
		Me.Force_Vector.TabIndex = 4
		Me.Force_Vector.Text = "Force Vector"
		'
		'Distance_Vector
		'
		Me.Distance_Vector.Location = New System.Drawing.Point(6, 53)
		Me.Distance_Vector.Name = "Distance_Vector"
		Me.Distance_Vector.Size = New System.Drawing.Size(52, 30)
		Me.Distance_Vector.TabIndex = 1
		Me.Distance_Vector.Text = "Distance Vector"
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(177, 210)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(89, 23)
		Me.Button1.TabIndex = 1
		Me.Button1.Text = "Cross Product"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'Cross_Product_Result
		'
		Me.Cross_Product_Result.AutoSize = True
		Me.Cross_Product_Result.Location = New System.Drawing.Point(18, 174)
		Me.Cross_Product_Result.Margin = New System.Windows.Forms.Padding(3)
		Me.Cross_Product_Result.Name = "Cross_Product_Result"
		Me.Cross_Product_Result.Size = New System.Drawing.Size(86, 13)
		Me.Cross_Product_Result.TabIndex = 2
		Me.Cross_Product_Result.Text = "Resultant Vector"
		'
		'X_Result
		'
		Me.X_Result.AutoSize = True
		Me.X_Result.Location = New System.Drawing.Point(18, 193)
		Me.X_Result.Margin = New System.Windows.Forms.Padding(3)
		Me.X_Result.Name = "X_Result"
		Me.X_Result.Size = New System.Drawing.Size(47, 13)
		Me.X_Result.TabIndex = 3
		Me.X_Result.Text = "X Result"
		'
		'Y_Result
		'
		Me.Y_Result.AutoSize = True
		Me.Y_Result.Location = New System.Drawing.Point(18, 212)
		Me.Y_Result.Margin = New System.Windows.Forms.Padding(3)
		Me.Y_Result.Name = "Y_Result"
		Me.Y_Result.Size = New System.Drawing.Size(47, 13)
		Me.Y_Result.TabIndex = 4
		Me.Y_Result.Text = "Y Result"
		'
		'Z_Result
		'
		Me.Z_Result.AutoSize = True
		Me.Z_Result.Location = New System.Drawing.Point(18, 231)
		Me.Z_Result.Margin = New System.Windows.Forms.Padding(3)
		Me.Z_Result.Name = "Z_Result"
		Me.Z_Result.Size = New System.Drawing.Size(47, 13)
		Me.Z_Result.TabIndex = 5
		Me.Z_Result.Text = "Z Result"
		'
		'Resultant
		'
		Me.Resultant.AutoSize = True
		Me.Resultant.Location = New System.Drawing.Point(18, 251)
		Me.Resultant.Margin = New System.Windows.Forms.Padding(3)
		Me.Resultant.Name = "Resultant"
		Me.Resultant.Size = New System.Drawing.Size(52, 13)
		Me.Resultant.TabIndex = 6
		Me.Resultant.Text = "Resultant"
		'
		'Clear_Button
		'
		Me.Clear_Button.Location = New System.Drawing.Point(178, 181)
		Me.Clear_Button.Name = "Clear_Button"
		Me.Clear_Button.Size = New System.Drawing.Size(88, 23)
		Me.Clear_Button.TabIndex = 7
		Me.Clear_Button.Text = "Clear"
		Me.Clear_Button.UseVisualStyleBackColor = True
		'
		'Cross_Product
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Window
		Me.ClientSize = New System.Drawing.Size(390, 293)
		Me.Controls.Add(Me.Clear_Button)
		Me.Controls.Add(Me.Resultant)
		Me.Controls.Add(Me.Z_Result)
		Me.Controls.Add(Me.Y_Result)
		Me.Controls.Add(Me.X_Result)
		Me.Controls.Add(Me.Cross_Product_Result)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.GroupBox1)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "Cross_Product"
		Me.Text = "Cross Product"
		Me.GroupBox1.ResumeLayout(False)
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Force_k As TextBox
    Friend WithEvents Force_j As TextBox
    Friend WithEvents Force_i As TextBox
    Friend WithEvents Distance_k As TextBox
    Friend WithEvents Distance_j As TextBox
    Friend WithEvents Distance_i As TextBox
    Friend WithEvents j_Vector As Label
    Friend WithEvents i_Vector As Label
    Friend WithEvents k_Vector As Label
    Friend WithEvents Force_Vector As Label
    Friend WithEvents Distance_Vector As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Cross_Product_Result As Label
    Friend WithEvents X_Result As Label
    Friend WithEvents Y_Result As Label
    Friend WithEvents Z_Result As Label
    Friend WithEvents Resultant As Label
	Friend WithEvents Clear_Button As Button
End Class
