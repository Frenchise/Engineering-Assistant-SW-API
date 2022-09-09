<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Contour_Plate
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
        Me.FWD_Left = New System.Windows.Forms.RadioButton()
        Me.FWD_Right = New System.Windows.Forms.RadioButton()
        Me.FWD_Direction = New System.Windows.Forms.GroupBox()
        Me.Run_Contours = New System.Windows.Forms.Button()
        Me.Lateral_Angle = New System.Windows.Forms.GroupBox()
        Me.Angle_Right_Input = New System.Windows.Forms.TextBox()
        Me.Angle_Left_Input = New System.Windows.Forms.TextBox()
        Me.Angle_Right = New System.Windows.Forms.Label()
        Me.Angle_Left = New System.Windows.Forms.Label()
        Me.Lateral_Right_Angle = New System.Windows.Forms.RadioButton()
        Me.Lateral_Left_Angle = New System.Windows.Forms.RadioButton()
        Me.No_Lateral_Angle = New System.Windows.Forms.RadioButton()
        Me.Pitch_Angle = New System.Windows.Forms.GroupBox()
        Me.No_Pitch_Angle = New System.Windows.Forms.RadioButton()
        Me.Angle_Up = New System.Windows.Forms.Label()
        Me.Angle_Down = New System.Windows.Forms.Label()
        Me.Angle_Up_Input = New System.Windows.Forms.TextBox()
        Me.Angle_Down_Input = New System.Windows.Forms.TextBox()
        Me.Pitch_Up = New System.Windows.Forms.RadioButton()
        Me.Pitch_Down = New System.Windows.Forms.RadioButton()
        Me.Radii = New System.Windows.Forms.GroupBox()
        Me.Aft_Radius_Label = New System.Windows.Forms.Label()
        Me.FWD_Radius_Label = New System.Windows.Forms.Label()
        Me.AFT_Radius = New System.Windows.Forms.TextBox()
        Me.FWD_Radius = New System.Windows.Forms.TextBox()
        Me.Belly_Radii = New System.Windows.Forms.RadioButton()
        Me.Belly_Flat = New System.Windows.Forms.RadioButton()
        Me.Library_Feat = New System.Windows.Forms.GroupBox()
        Me.Feature_List = New System.Windows.Forms.ListBox()
        Me.Belly_Spline = New System.Windows.Forms.RadioButton()
        Me.FWD_Direction.SuspendLayout()
        Me.Lateral_Angle.SuspendLayout()
        Me.Pitch_Angle.SuspendLayout()
        Me.Radii.SuspendLayout()
        Me.Library_Feat.SuspendLayout()
        Me.SuspendLayout()
        '
        'FWD_Left
        '
        Me.FWD_Left.AutoSize = True
        Me.FWD_Left.Location = New System.Drawing.Point(6, 19)
        Me.FWD_Left.Name = "FWD_Left"
        Me.FWD_Left.Size = New System.Drawing.Size(71, 17)
        Me.FWD_Left.TabIndex = 10
        Me.FWD_Left.TabStop = True
        Me.FWD_Left.Text = "FWD Left"
        Me.FWD_Left.UseVisualStyleBackColor = True
        '
        'FWD_Right
        '
        Me.FWD_Right.AutoSize = True
        Me.FWD_Right.Location = New System.Drawing.Point(6, 42)
        Me.FWD_Right.Name = "FWD_Right"
        Me.FWD_Right.Size = New System.Drawing.Size(78, 17)
        Me.FWD_Right.TabIndex = 11
        Me.FWD_Right.TabStop = True
        Me.FWD_Right.Text = "FWD Right"
        Me.FWD_Right.UseVisualStyleBackColor = True
        '
        'FWD_Direction
        '
        Me.FWD_Direction.Controls.Add(Me.FWD_Left)
        Me.FWD_Direction.Controls.Add(Me.FWD_Right)
        Me.FWD_Direction.Location = New System.Drawing.Point(211, 146)
        Me.FWD_Direction.Name = "FWD_Direction"
        Me.FWD_Direction.Size = New System.Drawing.Size(107, 71)
        Me.FWD_Direction.TabIndex = 1
        Me.FWD_Direction.TabStop = False
        Me.FWD_Direction.Text = "Forward Direction"
        '
        'Run_Contours
        '
        Me.Run_Contours.Location = New System.Drawing.Point(324, 175)
        Me.Run_Contours.Name = "Run_Contours"
        Me.Run_Contours.Size = New System.Drawing.Size(103, 23)
        Me.Run_Contours.TabIndex = 100
        Me.Run_Contours.Text = "Do The Things"
        Me.Run_Contours.UseVisualStyleBackColor = True
        '
        'Lateral_Angle
        '
        Me.Lateral_Angle.Controls.Add(Me.Angle_Right_Input)
        Me.Lateral_Angle.Controls.Add(Me.Angle_Left_Input)
        Me.Lateral_Angle.Controls.Add(Me.Angle_Right)
        Me.Lateral_Angle.Controls.Add(Me.Angle_Left)
        Me.Lateral_Angle.Controls.Add(Me.Lateral_Right_Angle)
        Me.Lateral_Angle.Controls.Add(Me.Lateral_Left_Angle)
        Me.Lateral_Angle.Controls.Add(Me.No_Lateral_Angle)
        Me.Lateral_Angle.Location = New System.Drawing.Point(12, 117)
        Me.Lateral_Angle.Name = "Lateral_Angle"
        Me.Lateral_Angle.Size = New System.Drawing.Size(193, 91)
        Me.Lateral_Angle.TabIndex = 2
        Me.Lateral_Angle.TabStop = False
        Me.Lateral_Angle.Text = "Lateral Angle"
        '
        'Angle_Right_Input
        '
        Me.Angle_Right_Input.Location = New System.Drawing.Point(60, 64)
        Me.Angle_Right_Input.Name = "Angle_Right_Input"
        Me.Angle_Right_Input.Size = New System.Drawing.Size(37, 20)
        Me.Angle_Right_Input.TabIndex = 26
        '
        'Angle_Left_Input
        '
        Me.Angle_Left_Input.Location = New System.Drawing.Point(60, 38)
        Me.Angle_Left_Input.Name = "Angle_Left_Input"
        Me.Angle_Left_Input.Size = New System.Drawing.Size(37, 20)
        Me.Angle_Left_Input.TabIndex = 25
        '
        'Angle_Right
        '
        Me.Angle_Right.AutoSize = True
        Me.Angle_Right.Location = New System.Drawing.Point(103, 67)
        Me.Angle_Right.Name = "Angle_Right"
        Me.Angle_Right.Size = New System.Drawing.Size(47, 13)
        Me.Angle_Right.TabIndex = 24
        Me.Angle_Right.Text = "Degrees"
        '
        'Angle_Left
        '
        Me.Angle_Left.AutoSize = True
        Me.Angle_Left.Location = New System.Drawing.Point(103, 41)
        Me.Angle_Left.Name = "Angle_Left"
        Me.Angle_Left.Size = New System.Drawing.Size(47, 13)
        Me.Angle_Left.TabIndex = 23
        Me.Angle_Left.Text = "Degrees"
        '
        'Lateral_Right_Angle
        '
        Me.Lateral_Right_Angle.AutoSize = True
        Me.Lateral_Right_Angle.Location = New System.Drawing.Point(6, 65)
        Me.Lateral_Right_Angle.Name = "Lateral_Right_Angle"
        Me.Lateral_Right_Angle.Size = New System.Drawing.Size(50, 17)
        Me.Lateral_Right_Angle.TabIndex = 22
        Me.Lateral_Right_Angle.TabStop = True
        Me.Lateral_Right_Angle.Text = "Right"
        Me.Lateral_Right_Angle.UseVisualStyleBackColor = True
        '
        'Lateral_Left_Angle
        '
        Me.Lateral_Left_Angle.AutoSize = True
        Me.Lateral_Left_Angle.Location = New System.Drawing.Point(6, 42)
        Me.Lateral_Left_Angle.Name = "Lateral_Left_Angle"
        Me.Lateral_Left_Angle.Size = New System.Drawing.Size(43, 17)
        Me.Lateral_Left_Angle.TabIndex = 21
        Me.Lateral_Left_Angle.TabStop = True
        Me.Lateral_Left_Angle.Text = "Left"
        Me.Lateral_Left_Angle.UseVisualStyleBackColor = True
        '
        'No_Lateral_Angle
        '
        Me.No_Lateral_Angle.AutoSize = True
        Me.No_Lateral_Angle.Location = New System.Drawing.Point(6, 19)
        Me.No_Lateral_Angle.Name = "No_Lateral_Angle"
        Me.No_Lateral_Angle.Size = New System.Drawing.Size(51, 17)
        Me.No_Lateral_Angle.TabIndex = 20
        Me.No_Lateral_Angle.TabStop = True
        Me.No_Lateral_Angle.Text = "None"
        Me.No_Lateral_Angle.UseVisualStyleBackColor = True
        '
        'Pitch_Angle
        '
        Me.Pitch_Angle.Controls.Add(Me.No_Pitch_Angle)
        Me.Pitch_Angle.Controls.Add(Me.Angle_Up)
        Me.Pitch_Angle.Controls.Add(Me.Angle_Down)
        Me.Pitch_Angle.Controls.Add(Me.Angle_Up_Input)
        Me.Pitch_Angle.Controls.Add(Me.Angle_Down_Input)
        Me.Pitch_Angle.Controls.Add(Me.Pitch_Up)
        Me.Pitch_Angle.Controls.Add(Me.Pitch_Down)
        Me.Pitch_Angle.Location = New System.Drawing.Point(12, 12)
        Me.Pitch_Angle.Name = "Pitch_Angle"
        Me.Pitch_Angle.Size = New System.Drawing.Size(193, 99)
        Me.Pitch_Angle.TabIndex = 3
        Me.Pitch_Angle.TabStop = False
        Me.Pitch_Angle.Text = "Pitch Angle"
        '
        'No_Pitch_Angle
        '
        Me.No_Pitch_Angle.AutoSize = True
        Me.No_Pitch_Angle.Location = New System.Drawing.Point(6, 19)
        Me.No_Pitch_Angle.Name = "No_Pitch_Angle"
        Me.No_Pitch_Angle.Size = New System.Drawing.Size(51, 17)
        Me.No_Pitch_Angle.TabIndex = 30
        Me.No_Pitch_Angle.TabStop = True
        Me.No_Pitch_Angle.Text = "None"
        Me.No_Pitch_Angle.UseVisualStyleBackColor = True
        '
        'Angle_Up
        '
        Me.Angle_Up.AutoSize = True
        Me.Angle_Up.Location = New System.Drawing.Point(135, 71)
        Me.Angle_Up.Name = "Angle_Up"
        Me.Angle_Up.Size = New System.Drawing.Size(47, 13)
        Me.Angle_Up.TabIndex = 5
        Me.Angle_Up.Text = "Degrees"
        '
        'Angle_Down
        '
        Me.Angle_Down.AutoSize = True
        Me.Angle_Down.Location = New System.Drawing.Point(135, 44)
        Me.Angle_Down.Name = "Angle_Down"
        Me.Angle_Down.Size = New System.Drawing.Size(47, 13)
        Me.Angle_Down.TabIndex = 4
        Me.Angle_Down.Text = "Degrees"
        '
        'Angle_Up_Input
        '
        Me.Angle_Up_Input.Location = New System.Drawing.Point(92, 67)
        Me.Angle_Up_Input.Name = "Angle_Up_Input"
        Me.Angle_Up_Input.Size = New System.Drawing.Size(37, 20)
        Me.Angle_Up_Input.TabIndex = 3
        Me.Angle_Up_Input.TabStop = False
        '
        'Angle_Down_Input
        '
        Me.Angle_Down_Input.Location = New System.Drawing.Point(92, 41)
        Me.Angle_Down_Input.Name = "Angle_Down_Input"
        Me.Angle_Down_Input.Size = New System.Drawing.Size(37, 20)
        Me.Angle_Down_Input.TabIndex = 2
        Me.Angle_Down_Input.TabStop = False
        '
        'Pitch_Up
        '
        Me.Pitch_Up.AutoSize = True
        Me.Pitch_Up.Location = New System.Drawing.Point(6, 66)
        Me.Pitch_Up.Name = "Pitch_Up"
        Me.Pitch_Up.Size = New System.Drawing.Size(66, 17)
        Me.Pitch_Up.TabIndex = 32
        Me.Pitch_Up.TabStop = True
        Me.Pitch_Up.Text = "Pitch Up"
        Me.Pitch_Up.UseVisualStyleBackColor = True
        '
        'Pitch_Down
        '
        Me.Pitch_Down.AutoSize = True
        Me.Pitch_Down.Location = New System.Drawing.Point(6, 42)
        Me.Pitch_Down.Name = "Pitch_Down"
        Me.Pitch_Down.Size = New System.Drawing.Size(80, 17)
        Me.Pitch_Down.TabIndex = 31
        Me.Pitch_Down.TabStop = True
        Me.Pitch_Down.Text = "Pitch Down"
        Me.Pitch_Down.UseVisualStyleBackColor = True
        '
        'Radii
        '
        Me.Radii.Controls.Add(Me.Belly_Spline)
        Me.Radii.Controls.Add(Me.Aft_Radius_Label)
        Me.Radii.Controls.Add(Me.FWD_Radius_Label)
        Me.Radii.Controls.Add(Me.AFT_Radius)
        Me.Radii.Controls.Add(Me.FWD_Radius)
        Me.Radii.Controls.Add(Me.Belly_Radii)
        Me.Radii.Controls.Add(Me.Belly_Flat)
        Me.Radii.Location = New System.Drawing.Point(12, 214)
        Me.Radii.Name = "Radii"
        Me.Radii.Size = New System.Drawing.Size(193, 97)
        Me.Radii.TabIndex = 101
        Me.Radii.TabStop = False
        Me.Radii.Text = "Panel Radii"
        '
        'Aft_Radius_Label
        '
        Me.Aft_Radius_Label.AutoSize = True
        Me.Aft_Radius_Label.Location = New System.Drawing.Point(103, 70)
        Me.Aft_Radius_Label.Name = "Aft_Radius_Label"
        Me.Aft_Radius_Label.Size = New System.Drawing.Size(63, 13)
        Me.Aft_Radius_Label.TabIndex = 5
        Me.Aft_Radius_Label.Text = "AFT Radius"
        '
        'FWD_Radius_Label
        '
        Me.FWD_Radius_Label.AutoSize = True
        Me.FWD_Radius_Label.Location = New System.Drawing.Point(103, 44)
        Me.FWD_Radius_Label.Name = "FWD_Radius_Label"
        Me.FWD_Radius_Label.Size = New System.Drawing.Size(68, 13)
        Me.FWD_Radius_Label.TabIndex = 4
        Me.FWD_Radius_Label.Text = "FWD Radius"
        '
        'AFT_Radius
        '
        Me.AFT_Radius.Location = New System.Drawing.Point(61, 67)
        Me.AFT_Radius.Name = "AFT_Radius"
        Me.AFT_Radius.Size = New System.Drawing.Size(36, 20)
        Me.AFT_Radius.TabIndex = 3
        '
        'FWD_Radius
        '
        Me.FWD_Radius.Location = New System.Drawing.Point(61, 41)
        Me.FWD_Radius.Name = "FWD_Radius"
        Me.FWD_Radius.Size = New System.Drawing.Size(36, 20)
        Me.FWD_Radius.TabIndex = 2
        '
        'Belly_Radii
        '
        Me.Belly_Radii.AutoSize = True
        Me.Belly_Radii.Location = New System.Drawing.Point(6, 42)
        Me.Belly_Radii.Name = "Belly_Radii"
        Me.Belly_Radii.Size = New System.Drawing.Size(49, 17)
        Me.Belly_Radii.TabIndex = 1
        Me.Belly_Radii.TabStop = True
        Me.Belly_Radii.Text = "Radii"
        Me.Belly_Radii.UseVisualStyleBackColor = True
        '
        'Belly_Flat
        '
        Me.Belly_Flat.AutoSize = True
        Me.Belly_Flat.Location = New System.Drawing.Point(6, 19)
        Me.Belly_Flat.Name = "Belly_Flat"
        Me.Belly_Flat.Size = New System.Drawing.Size(42, 17)
        Me.Belly_Flat.TabIndex = 0
        Me.Belly_Flat.TabStop = True
        Me.Belly_Flat.Text = "Flat"
        Me.Belly_Flat.UseVisualStyleBackColor = True
        '
        'Library_Feat
        '
        Me.Library_Feat.Controls.Add(Me.Feature_List)
        Me.Library_Feat.Location = New System.Drawing.Point(211, 12)
        Me.Library_Feat.Name = "Library_Feat"
        Me.Library_Feat.Size = New System.Drawing.Size(216, 128)
        Me.Library_Feat.TabIndex = 103
        Me.Library_Feat.TabStop = False
        Me.Library_Feat.Text = "Availabe Library Feature"
        '
        'Feature_List
        '
        Me.Feature_List.FormattingEnabled = True
        Me.Feature_List.Location = New System.Drawing.Point(6, 19)
        Me.Feature_List.Name = "Feature_List"
        Me.Feature_List.Size = New System.Drawing.Size(205, 95)
        Me.Feature_List.TabIndex = 103
        '
        'Belly_Spline
        '
        Me.Belly_Spline.AutoSize = True
        Me.Belly_Spline.Location = New System.Drawing.Point(6, 65)
        Me.Belly_Spline.Name = "Belly_Spline"
        Me.Belly_Spline.Size = New System.Drawing.Size(54, 17)
        Me.Belly_Spline.TabIndex = 6
        Me.Belly_Spline.TabStop = True
        Me.Belly_Spline.Text = "Spline"
        Me.Belly_Spline.UseVisualStyleBackColor = True
        '
        'Contour_Plate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(449, 319)
        Me.Controls.Add(Me.Library_Feat)
        Me.Controls.Add(Me.Radii)
        Me.Controls.Add(Me.Lateral_Angle)
        Me.Controls.Add(Me.Pitch_Angle)
        Me.Controls.Add(Me.Run_Contours)
        Me.Controls.Add(Me.FWD_Direction)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Contour_Plate"
        Me.ShowIcon = False
        Me.Text = "Contour Plate"
        Me.FWD_Direction.ResumeLayout(False)
        Me.FWD_Direction.PerformLayout()
        Me.Lateral_Angle.ResumeLayout(False)
        Me.Lateral_Angle.PerformLayout()
        Me.Pitch_Angle.ResumeLayout(False)
        Me.Pitch_Angle.PerformLayout()
        Me.Radii.ResumeLayout(False)
        Me.Radii.PerformLayout()
        Me.Library_Feat.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FWD_Left As RadioButton
    Friend WithEvents FWD_Right As RadioButton
    Friend WithEvents FWD_Direction As GroupBox
    Friend WithEvents Run_Contours As Button
    Friend WithEvents Lateral_Angle As GroupBox
    Friend WithEvents Lateral_Right_Angle As RadioButton
    Friend WithEvents Lateral_Left_Angle As RadioButton
    Friend WithEvents No_Lateral_Angle As RadioButton
    Friend WithEvents Pitch_Angle As GroupBox
    Friend WithEvents Angle_Up As Label
    Friend WithEvents Angle_Down As Label
    Friend WithEvents Angle_Up_Input As TextBox
    Friend WithEvents Angle_Down_Input As TextBox
    Friend WithEvents Pitch_Up As RadioButton
    Friend WithEvents Pitch_Down As RadioButton
    Friend WithEvents No_Pitch_Angle As RadioButton
    Friend WithEvents Angle_Right_Input As TextBox
    Friend WithEvents Angle_Left_Input As TextBox
    Friend WithEvents Angle_Right As Label
    Friend WithEvents Angle_Left As Label
    Friend WithEvents Radii As GroupBox
    Friend WithEvents Belly_Radii As RadioButton
    Friend WithEvents Belly_Flat As RadioButton
    Friend WithEvents Aft_Radius_Label As Label
    Friend WithEvents FWD_Radius_Label As Label
    Friend WithEvents AFT_Radius As TextBox
    Friend WithEvents FWD_Radius As TextBox
    Friend WithEvents Library_Feat As GroupBox
    Friend WithEvents Feature_List As ListBox
    Friend WithEvents Belly_Spline As RadioButton
End Class
