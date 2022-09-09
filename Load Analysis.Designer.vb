<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Load_Analysis
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Load_Analysis))
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Box_Weight_Input = New System.Windows.Forms.TextBox()
		Me.Vd_Aircraft_Input = New System.Windows.Forms.TextBox()
		Me.Dive_Speed = New System.Windows.Forms.Label()
		Me.Grav1_Load = New System.Windows.Forms.ComboBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Grav2_Load = New System.Windows.Forms.ComboBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Grav3_Load = New System.Windows.Forms.ComboBox()
		Me.SA_Antenna_Input = New System.Windows.Forms.TextBox()
		Me.SA_Antenna = New System.Windows.Forms.Label()
		Me.Side_Load_Force_Output = New System.Windows.Forms.Label()
		Me.Antenna_Forces_Group = New System.Windows.Forms.GroupBox()
		Me.Fastener_Dist_Input = New System.Windows.Forms.TextBox()
		Me.Force_Distance_Input = New System.Windows.Forms.TextBox()
		Me.Fastener_Distance = New System.Windows.Forms.Label()
		Me.Force_Distance = New System.Windows.Forms.Label()
		Me.Antenna_Forces_Button = New System.Windows.Forms.Button()
		Me.Antenna_Fastener_Num_Input = New System.Windows.Forms.TextBox()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Fasteners_Per_Side = New System.Windows.Forms.Label()
		Me.Box_Force_Input = New System.Windows.Forms.GroupBox()
		Me.Safety_Factor_Label = New System.Windows.Forms.Label()
		Me.G3_Force = New System.Windows.Forms.Label()
		Me.G2_Force = New System.Windows.Forms.Label()
		Me.G1_Force = New System.Windows.Forms.Label()
		Me.Gravity_Note_Label = New System.Windows.Forms.Label()
		Me.Box_Fastener_Num_Input = New System.Windows.Forms.TextBox()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.Resultant_Forces_Button = New System.Windows.Forms.Button()
		Me.Feed_Thru_Group = New System.Windows.Forms.GroupBox()
		Me.Clear_Inputs = New System.Windows.Forms.Button()
		Me.Skin_Bearing_Strength = New System.Windows.Forms.TextBox()
		Me.Skin_Bearing = New System.Windows.Forms.Label()
		Me.Fastener_Diameter = New System.Windows.Forms.TextBox()
		Me.Fastener_Diameter_Label = New System.Windows.Forms.Label()
		Me.Feed_Thru_Button = New System.Windows.Forms.Button()
		Me.Fast_Num_Output = New System.Windows.Forms.Label()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.Fastener_Tension_Spec_Input = New System.Windows.Forms.TextBox()
		Me.Hole_Diameter_Input = New System.Windows.Forms.TextBox()
		Me.Skin_Thick_Input = New System.Windows.Forms.TextBox()
		Me.Doubler_Tensile_Input = New System.Windows.Forms.TextBox()
		Me.Doubler_Tensile_Strength = New System.Windows.Forms.Label()
		Me.Fastener_Tension_Label = New System.Windows.Forms.Label()
		Me.FeedThru_Diameter_Label = New System.Windows.Forms.Label()
		Me.Skin_Thickness = New System.Windows.Forms.Label()
		Me.Box_Forces_IMG = New System.Windows.Forms.PictureBox()
		Me.Antenna_Forces_Group.SuspendLayout()
		Me.Box_Force_Input.SuspendLayout()
		Me.Feed_Thru_Group.SuspendLayout()
		CType(Me.Box_Forces_IMG, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(45, 23)
		Me.Label1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(105, 16)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Box Weight (lbs)"
		'
		'Box_Weight_Input
		'
		Me.Box_Weight_Input.Location = New System.Drawing.Point(159, 20)
		Me.Box_Weight_Input.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
		Me.Box_Weight_Input.Name = "Box_Weight_Input"
		Me.Box_Weight_Input.Size = New System.Drawing.Size(76, 22)
		Me.Box_Weight_Input.TabIndex = 7
		'
		'Vd_Aircraft_Input
		'
		Me.Vd_Aircraft_Input.Location = New System.Drawing.Point(237, 23)
		Me.Vd_Aircraft_Input.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
		Me.Vd_Aircraft_Input.Name = "Vd_Aircraft_Input"
		Me.Vd_Aircraft_Input.Size = New System.Drawing.Size(96, 22)
		Me.Vd_Aircraft_Input.TabIndex = 1
		'
		'Dive_Speed
		'
		Me.Dive_Speed.AutoSize = True
		Me.Dive_Speed.Location = New System.Drawing.Point(40, 26)
		Me.Dive_Speed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Dive_Speed.Name = "Dive_Speed"
		Me.Dive_Speed.Size = New System.Drawing.Size(190, 16)
		Me.Dive_Speed.TabIndex = 2
		Me.Dive_Speed.Text = "Dive Speed (MPH) TCD Sheet"
		'
		'Grav1_Load
		'
		Me.Grav1_Load.FormattingEnabled = True
		Me.Grav1_Load.Items.AddRange(New Object() {"16G", "12G", "9G", "6G", "3G"})
		Me.Grav1_Load.Location = New System.Drawing.Point(159, 101)
		Me.Grav1_Load.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
		Me.Grav1_Load.Name = "Grav1_Load"
		Me.Grav1_Load.Size = New System.Drawing.Size(76, 24)
		Me.Grav1_Load.TabIndex = 9
		Me.Grav1_Load.Text = "Select"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(6, 104)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(144, 16)
		Me.Label3.TabIndex = 5
		Me.Label3.Text = "Gravity Direction 1 (G1)"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(6, 136)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(144, 16)
		Me.Label4.TabIndex = 7
		Me.Label4.Text = "Gravity Direction 2 (G2)"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Grav2_Load
		'
		Me.Grav2_Load.FormattingEnabled = True
		Me.Grav2_Load.Items.AddRange(New Object() {"16G", "12G", "9G", "6G", "3G"})
		Me.Grav2_Load.Location = New System.Drawing.Point(159, 133)
		Me.Grav2_Load.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
		Me.Grav2_Load.Name = "Grav2_Load"
		Me.Grav2_Load.Size = New System.Drawing.Size(76, 24)
		Me.Grav2_Load.TabIndex = 10
		Me.Grav2_Load.Text = "Select"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(6, 168)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(144, 16)
		Me.Label5.TabIndex = 9
		Me.Label5.Text = "Gravity Direction 3 (G3)"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Grav3_Load
		'
		Me.Grav3_Load.FormattingEnabled = True
		Me.Grav3_Load.Items.AddRange(New Object() {"16G", "12G", "9G", "6G", "3G"})
		Me.Grav3_Load.Location = New System.Drawing.Point(159, 165)
		Me.Grav3_Load.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
		Me.Grav3_Load.Name = "Grav3_Load"
		Me.Grav3_Load.Size = New System.Drawing.Size(76, 24)
		Me.Grav3_Load.TabIndex = 11
		Me.Grav3_Load.Text = "Select"
		'
		'SA_Antenna_Input
		'
		Me.SA_Antenna_Input.Location = New System.Drawing.Point(237, 53)
		Me.SA_Antenna_Input.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
		Me.SA_Antenna_Input.Name = "SA_Antenna_Input"
		Me.SA_Antenna_Input.Size = New System.Drawing.Size(96, 22)
		Me.SA_Antenna_Input.TabIndex = 2
		'
		'SA_Antenna
		'
		Me.SA_Antenna.AutoSize = True
		Me.SA_Antenna.Location = New System.Drawing.Point(47, 56)
		Me.SA_Antenna.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.SA_Antenna.Name = "SA_Antenna"
		Me.SA_Antenna.Size = New System.Drawing.Size(183, 16)
		Me.SA_Antenna.TabIndex = 10
		Me.SA_Antenna.Text = "Surface Area of Antenna (ft^2)"
		'
		'Side_Load_Force_Output
		'
		Me.Side_Load_Force_Output.AutoSize = True
		Me.Side_Load_Force_Output.Location = New System.Drawing.Point(234, 177)
		Me.Side_Load_Force_Output.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
		Me.Side_Load_Force_Output.Name = "Side_Load_Force_Output"
		Me.Side_Load_Force_Output.Size = New System.Drawing.Size(99, 16)
		Me.Side_Load_Force_Output.TabIndex = 98
		Me.Side_Load_Force_Output.Text = "Fastener Force"
		'
		'Antenna_Forces_Group
		'
		Me.Antenna_Forces_Group.Controls.Add(Me.Fastener_Dist_Input)
		Me.Antenna_Forces_Group.Controls.Add(Me.Force_Distance_Input)
		Me.Antenna_Forces_Group.Controls.Add(Me.Fastener_Distance)
		Me.Antenna_Forces_Group.Controls.Add(Me.Force_Distance)
		Me.Antenna_Forces_Group.Controls.Add(Me.Antenna_Forces_Button)
		Me.Antenna_Forces_Group.Controls.Add(Me.Antenna_Fastener_Num_Input)
		Me.Antenna_Forces_Group.Controls.Add(Me.Label9)
		Me.Antenna_Forces_Group.Controls.Add(Me.Fasteners_Per_Side)
		Me.Antenna_Forces_Group.Controls.Add(Me.Vd_Aircraft_Input)
		Me.Antenna_Forces_Group.Controls.Add(Me.Side_Load_Force_Output)
		Me.Antenna_Forces_Group.Controls.Add(Me.Dive_Speed)
		Me.Antenna_Forces_Group.Controls.Add(Me.SA_Antenna_Input)
		Me.Antenna_Forces_Group.Controls.Add(Me.SA_Antenna)
		Me.Antenna_Forces_Group.Location = New System.Drawing.Point(12, 38)
		Me.Antenna_Forces_Group.Name = "Antenna_Forces_Group"
		Me.Antenna_Forces_Group.Size = New System.Drawing.Size(360, 262)
		Me.Antenna_Forces_Group.TabIndex = 100
		Me.Antenna_Forces_Group.TabStop = False
		Me.Antenna_Forces_Group.Text = "Antenna Forces"
		'
		'Fastener_Dist_Input
		'
		Me.Fastener_Dist_Input.Location = New System.Drawing.Point(237, 145)
		Me.Fastener_Dist_Input.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
		Me.Fastener_Dist_Input.Name = "Fastener_Dist_Input"
		Me.Fastener_Dist_Input.Size = New System.Drawing.Size(96, 22)
		Me.Fastener_Dist_Input.TabIndex = 5
		'
		'Force_Distance_Input
		'
		Me.Force_Distance_Input.Location = New System.Drawing.Point(237, 83)
		Me.Force_Distance_Input.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
		Me.Force_Distance_Input.Name = "Force_Distance_Input"
		Me.Force_Distance_Input.Size = New System.Drawing.Size(96, 22)
		Me.Force_Distance_Input.TabIndex = 3
		'
		'Fastener_Distance
		'
		Me.Fastener_Distance.AutoSize = True
		Me.Fastener_Distance.Location = New System.Drawing.Point(7, 148)
		Me.Fastener_Distance.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Fastener_Distance.Name = "Fastener_Distance"
		Me.Fastener_Distance.Size = New System.Drawing.Size(223, 16)
		Me.Fastener_Distance.TabIndex = 18
		Me.Fastener_Distance.Text = "Distance Betwen Fastener Sides (in)"
		'
		'Force_Distance
		'
		Me.Force_Distance.AutoSize = True
		Me.Force_Distance.Location = New System.Drawing.Point(13, 86)
		Me.Force_Distance.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Force_Distance.Name = "Force_Distance"
		Me.Force_Distance.Size = New System.Drawing.Size(217, 16)
		Me.Force_Distance.TabIndex = 20
		Me.Force_Distance.Text = "Force Distance From Fasteners (in)"
		'
		'Antenna_Forces_Button
		'
		Me.Antenna_Forces_Button.Location = New System.Drawing.Point(111, 201)
		Me.Antenna_Forces_Button.Name = "Antenna_Forces_Button"
		Me.Antenna_Forces_Button.Size = New System.Drawing.Size(222, 23)
		Me.Antenna_Forces_Button.TabIndex = 6
		Me.Antenna_Forces_Button.Text = "Check Fastener Tension Force"
		Me.Antenna_Forces_Button.UseVisualStyleBackColor = True
		'
		'Antenna_Fastener_Num_Input
		'
		Me.Antenna_Fastener_Num_Input.Location = New System.Drawing.Point(237, 115)
		Me.Antenna_Fastener_Num_Input.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
		Me.Antenna_Fastener_Num_Input.Name = "Antenna_Fastener_Num_Input"
		Me.Antenna_Fastener_Num_Input.Size = New System.Drawing.Size(96, 22)
		Me.Antenna_Fastener_Num_Input.TabIndex = 4
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(15, 177)
		Me.Label9.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(215, 16)
		Me.Label9.TabIndex = 19
		Me.Label9.Text = "Result Tension Force per Fastener"
		'
		'Fasteners_Per_Side
		'
		Me.Fasteners_Per_Side.AutoSize = True
		Me.Fasteners_Per_Side.Location = New System.Drawing.Point(83, 118)
		Me.Fasteners_Per_Side.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Fasteners_Per_Side.Name = "Fasteners_Per_Side"
		Me.Fasteners_Per_Side.Size = New System.Drawing.Size(147, 16)
		Me.Fasteners_Per_Side.TabIndex = 16
		Me.Fasteners_Per_Side.Text = "# of Fasteners Per Side"
		'
		'Box_Force_Input
		'
		Me.Box_Force_Input.Controls.Add(Me.Safety_Factor_Label)
		Me.Box_Force_Input.Controls.Add(Me.G3_Force)
		Me.Box_Force_Input.Controls.Add(Me.G2_Force)
		Me.Box_Force_Input.Controls.Add(Me.G1_Force)
		Me.Box_Force_Input.Controls.Add(Me.Gravity_Note_Label)
		Me.Box_Force_Input.Controls.Add(Me.Box_Fastener_Num_Input)
		Me.Box_Force_Input.Controls.Add(Me.Label16)
		Me.Box_Force_Input.Controls.Add(Me.Resultant_Forces_Button)
		Me.Box_Force_Input.Controls.Add(Me.Box_Weight_Input)
		Me.Box_Force_Input.Controls.Add(Me.Label1)
		Me.Box_Force_Input.Controls.Add(Me.Label5)
		Me.Box_Force_Input.Controls.Add(Me.Grav1_Load)
		Me.Box_Force_Input.Controls.Add(Me.Grav3_Load)
		Me.Box_Force_Input.Controls.Add(Me.Label3)
		Me.Box_Force_Input.Controls.Add(Me.Label4)
		Me.Box_Force_Input.Controls.Add(Me.Grav2_Load)
		Me.Box_Force_Input.Location = New System.Drawing.Point(12, 301)
		Me.Box_Force_Input.Margin = New System.Windows.Forms.Padding(3, 15, 3, 3)
		Me.Box_Force_Input.Name = "Box_Force_Input"
		Me.Box_Force_Input.Size = New System.Drawing.Size(360, 241)
		Me.Box_Force_Input.TabIndex = 101
		Me.Box_Force_Input.TabStop = False
		Me.Box_Force_Input.Text = "Box Forces"
		'
		'Safety_Factor_Label
		'
		Me.Safety_Factor_Label.AutoSize = True
		Me.Safety_Factor_Label.Location = New System.Drawing.Point(241, 53)
		Me.Safety_Factor_Label.Name = "Safety_Factor_Label"
		Me.Safety_Factor_Label.Size = New System.Drawing.Size(56, 16)
		Me.Safety_Factor_Label.TabIndex = 17
		Me.Safety_Factor_Label.Text = "Label17"
		'
		'G3_Force
		'
		Me.G3_Force.AutoSize = True
		Me.G3_Force.Location = New System.Drawing.Point(241, 168)
		Me.G3_Force.Name = "G3_Force"
		Me.G3_Force.Size = New System.Drawing.Size(56, 16)
		Me.G3_Force.TabIndex = 16
		Me.G3_Force.Text = "Label19"
		'
		'G2_Force
		'
		Me.G2_Force.AutoSize = True
		Me.G2_Force.Location = New System.Drawing.Point(241, 136)
		Me.G2_Force.Name = "G2_Force"
		Me.G2_Force.Size = New System.Drawing.Size(56, 16)
		Me.G2_Force.TabIndex = 15
		Me.G2_Force.Text = "Label18"
		'
		'G1_Force
		'
		Me.G1_Force.AutoSize = True
		Me.G1_Force.Location = New System.Drawing.Point(241, 104)
		Me.G1_Force.Name = "G1_Force"
		Me.G1_Force.Size = New System.Drawing.Size(56, 16)
		Me.G1_Force.TabIndex = 14
		Me.G1_Force.Text = "Label17"
		'
		'Gravity_Note_Label
		'
		Me.Gravity_Note_Label.AutoSize = True
		Me.Gravity_Note_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Gravity_Note_Label.Location = New System.Drawing.Point(7, 80)
		Me.Gravity_Note_Label.Margin = New System.Windows.Forms.Padding(4, 5, 4, 0)
		Me.Gravity_Note_Label.Name = "Gravity_Note_Label"
		Me.Gravity_Note_Label.Size = New System.Drawing.Size(278, 16)
		Me.Gravity_Note_Label.TabIndex = 13
		Me.Gravity_Note_Label.Text = "Allign Gravity with Plane FWD Direction"
		Me.Gravity_Note_Label.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Box_Fastener_Num_Input
		'
		Me.Box_Fastener_Num_Input.Location = New System.Drawing.Point(159, 50)
		Me.Box_Fastener_Num_Input.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
		Me.Box_Fastener_Num_Input.Name = "Box_Fastener_Num_Input"
		Me.Box_Fastener_Num_Input.Size = New System.Drawing.Size(76, 22)
		Me.Box_Fastener_Num_Input.TabIndex = 8
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.Location = New System.Drawing.Point(17, 53)
		Me.Label16.Margin = New System.Windows.Forms.Padding(4, 5, 4, 0)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(133, 16)
		Me.Label16.TabIndex = 11
		Me.Label16.Text = "Number of Fasteners"
		Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Resultant_Forces_Button
		'
		Me.Resultant_Forces_Button.Location = New System.Drawing.Point(35, 195)
		Me.Resultant_Forces_Button.Name = "Resultant_Forces_Button"
		Me.Resultant_Forces_Button.Size = New System.Drawing.Size(200, 23)
		Me.Resultant_Forces_Button.TabIndex = 12
		Me.Resultant_Forces_Button.Text = "Resultant Forces per Fastener"
		Me.Resultant_Forces_Button.UseVisualStyleBackColor = True
		'
		'Feed_Thru_Group
		'
		Me.Feed_Thru_Group.Controls.Add(Me.Clear_Inputs)
		Me.Feed_Thru_Group.Controls.Add(Me.Skin_Bearing_Strength)
		Me.Feed_Thru_Group.Controls.Add(Me.Skin_Bearing)
		Me.Feed_Thru_Group.Controls.Add(Me.Fastener_Diameter)
		Me.Feed_Thru_Group.Controls.Add(Me.Fastener_Diameter_Label)
		Me.Feed_Thru_Group.Controls.Add(Me.Feed_Thru_Button)
		Me.Feed_Thru_Group.Controls.Add(Me.Fast_Num_Output)
		Me.Feed_Thru_Group.Controls.Add(Me.Label15)
		Me.Feed_Thru_Group.Controls.Add(Me.Fastener_Tension_Spec_Input)
		Me.Feed_Thru_Group.Controls.Add(Me.Hole_Diameter_Input)
		Me.Feed_Thru_Group.Controls.Add(Me.Skin_Thick_Input)
		Me.Feed_Thru_Group.Controls.Add(Me.Doubler_Tensile_Input)
		Me.Feed_Thru_Group.Controls.Add(Me.Doubler_Tensile_Strength)
		Me.Feed_Thru_Group.Controls.Add(Me.Fastener_Tension_Label)
		Me.Feed_Thru_Group.Controls.Add(Me.FeedThru_Diameter_Label)
		Me.Feed_Thru_Group.Controls.Add(Me.Skin_Thickness)
		Me.Feed_Thru_Group.Location = New System.Drawing.Point(390, 38)
		Me.Feed_Thru_Group.Margin = New System.Windows.Forms.Padding(15)
		Me.Feed_Thru_Group.Name = "Feed_Thru_Group"
		Me.Feed_Thru_Group.Size = New System.Drawing.Size(360, 262)
		Me.Feed_Thru_Group.TabIndex = 102
		Me.Feed_Thru_Group.TabStop = False
		Me.Feed_Thru_Group.Text = "Feed Thru Fastener Calculations"
		'
		'Clear_Inputs
		'
		Me.Clear_Inputs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Clear_Inputs.ForeColor = System.Drawing.Color.Red
		Me.Clear_Inputs.Location = New System.Drawing.Point(297, 226)
		Me.Clear_Inputs.Name = "Clear_Inputs"
		Me.Clear_Inputs.Size = New System.Drawing.Size(48, 23)
		Me.Clear_Inputs.TabIndex = 100
		Me.Clear_Inputs.Text = "Clear"
		Me.Clear_Inputs.UseVisualStyleBackColor = True
		'
		'Skin_Bearing_Strength
		'
		Me.Skin_Bearing_Strength.Location = New System.Drawing.Point(204, 83)
		Me.Skin_Bearing_Strength.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
		Me.Skin_Bearing_Strength.Name = "Skin_Bearing_Strength"
		Me.Skin_Bearing_Strength.Size = New System.Drawing.Size(76, 22)
		Me.Skin_Bearing_Strength.TabIndex = 15
		'
		'Skin_Bearing
		'
		Me.Skin_Bearing.AutoSize = True
		Me.Skin_Bearing.Location = New System.Drawing.Point(26, 86)
		Me.Skin_Bearing.Name = "Skin_Bearing"
		Me.Skin_Bearing.Size = New System.Drawing.Size(168, 16)
		Me.Skin_Bearing.TabIndex = 21
		Me.Skin_Bearing.Text = "Skin Bearing Strength (PSI)"
		'
		'Fastener_Diameter
		'
		Me.Fastener_Diameter.Location = New System.Drawing.Point(204, 142)
		Me.Fastener_Diameter.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
		Me.Fastener_Diameter.Name = "Fastener_Diameter"
		Me.Fastener_Diameter.Size = New System.Drawing.Size(76, 22)
		Me.Fastener_Diameter.TabIndex = 17
		'
		'Fastener_Diameter_Label
		'
		Me.Fastener_Diameter_Label.AutoSize = True
		Me.Fastener_Diameter_Label.Location = New System.Drawing.Point(57, 145)
		Me.Fastener_Diameter_Label.Name = "Fastener_Diameter_Label"
		Me.Fastener_Diameter_Label.Size = New System.Drawing.Size(140, 16)
		Me.Fastener_Diameter_Label.TabIndex = 19
		Me.Fastener_Diameter_Label.Text = "Fastener Diameter (in)"
		'
		'Feed_Thru_Button
		'
		Me.Feed_Thru_Button.ForeColor = System.Drawing.Color.Green
		Me.Feed_Thru_Button.Location = New System.Drawing.Point(103, 226)
		Me.Feed_Thru_Button.Name = "Feed_Thru_Button"
		Me.Feed_Thru_Button.Size = New System.Drawing.Size(177, 23)
		Me.Feed_Thru_Button.TabIndex = 19
		Me.Feed_Thru_Button.Text = "Check Fastener Numbers"
		Me.Feed_Thru_Button.UseVisualStyleBackColor = True
		'
		'Fast_Num_Output
		'
		Me.Fast_Num_Output.AutoSize = True
		Me.Fast_Num_Output.Location = New System.Drawing.Point(203, 202)
		Me.Fast_Num_Output.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
		Me.Fast_Num_Output.Name = "Fast_Num_Output"
		Me.Fast_Num_Output.Size = New System.Drawing.Size(112, 16)
		Me.Fast_Num_Output.TabIndex = 99
		Me.Fast_Num_Output.Text = "Fastener Number"
		'
		'Label15
		'
		Me.Label15.AutoSize = True
		Me.Label15.Location = New System.Drawing.Point(6, 202)
		Me.Label15.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(191, 16)
		Me.Label15.TabIndex = 15
		Me.Label15.Text = "Min Fastener Number Per Side"
		'
		'Fastener_Tension_Spec_Input
		'
		Me.Fastener_Tension_Spec_Input.Location = New System.Drawing.Point(204, 172)
		Me.Fastener_Tension_Spec_Input.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
		Me.Fastener_Tension_Spec_Input.Name = "Fastener_Tension_Spec_Input"
		Me.Fastener_Tension_Spec_Input.Size = New System.Drawing.Size(76, 22)
		Me.Fastener_Tension_Spec_Input.TabIndex = 18
		'
		'Hole_Diameter_Input
		'
		Me.Hole_Diameter_Input.Location = New System.Drawing.Point(204, 112)
		Me.Hole_Diameter_Input.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
		Me.Hole_Diameter_Input.Name = "Hole_Diameter_Input"
		Me.Hole_Diameter_Input.Size = New System.Drawing.Size(76, 22)
		Me.Hole_Diameter_Input.TabIndex = 16
		'
		'Skin_Thick_Input
		'
		Me.Skin_Thick_Input.Location = New System.Drawing.Point(204, 53)
		Me.Skin_Thick_Input.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
		Me.Skin_Thick_Input.Name = "Skin_Thick_Input"
		Me.Skin_Thick_Input.Size = New System.Drawing.Size(76, 22)
		Me.Skin_Thick_Input.TabIndex = 14
		'
		'Doubler_Tensile_Input
		'
		Me.Doubler_Tensile_Input.Location = New System.Drawing.Point(204, 23)
		Me.Doubler_Tensile_Input.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
		Me.Doubler_Tensile_Input.Name = "Doubler_Tensile_Input"
		Me.Doubler_Tensile_Input.Size = New System.Drawing.Size(76, 22)
		Me.Doubler_Tensile_Input.TabIndex = 13
		'
		'Doubler_Tensile_Strength
		'
		Me.Doubler_Tensile_Strength.AutoSize = True
		Me.Doubler_Tensile_Strength.Location = New System.Drawing.Point(9, 26)
		Me.Doubler_Tensile_Strength.Margin = New System.Windows.Forms.Padding(4, 5, 4, 0)
		Me.Doubler_Tensile_Strength.Name = "Doubler_Tensile_Strength"
		Me.Doubler_Tensile_Strength.Size = New System.Drawing.Size(188, 16)
		Me.Doubler_Tensile_Strength.TabIndex = 0
		Me.Doubler_Tensile_Strength.Text = "Doubler Tensile Strenght (PSI)"
		'
		'Fastener_Tension_Label
		'
		Me.Fastener_Tension_Label.AutoSize = True
		Me.Fastener_Tension_Label.Location = New System.Drawing.Point(17, 175)
		Me.Fastener_Tension_Label.Name = "Fastener_Tension_Label"
		Me.Fastener_Tension_Label.Size = New System.Drawing.Size(180, 16)
		Me.Fastener_Tension_Label.TabIndex = 9
		Me.Fastener_Tension_Label.Text = "Fastener Tension Spec (PSI)"
		'
		'FeedThru_Diameter_Label
		'
		Me.FeedThru_Diameter_Label.AutoSize = True
		Me.FeedThru_Diameter_Label.Location = New System.Drawing.Point(81, 115)
		Me.FeedThru_Diameter_Label.Name = "FeedThru_Diameter_Label"
		Me.FeedThru_Diameter_Label.Size = New System.Drawing.Size(116, 16)
		Me.FeedThru_Diameter_Label.TabIndex = 5
		Me.FeedThru_Diameter_Label.Text = "Hole Diameter (in)"
		'
		'Skin_Thickness
		'
		Me.Skin_Thickness.AutoSize = True
		Me.Skin_Thickness.Location = New System.Drawing.Point(26, 56)
		Me.Skin_Thickness.Name = "Skin_Thickness"
		Me.Skin_Thickness.Size = New System.Drawing.Size(171, 16)
		Me.Skin_Thickness.TabIndex = 7
		Me.Skin_Thickness.Text = "Skin Material Thickness (in)"
		'
		'Box_Forces_IMG
		'
		Me.Box_Forces_IMG.Location = New System.Drawing.Point(390, 309)
		Me.Box_Forces_IMG.Name = "Box_Forces_IMG"
		Me.Box_Forces_IMG.Size = New System.Drawing.Size(360, 233)
		Me.Box_Forces_IMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.Box_Forces_IMG.TabIndex = 31
		Me.Box_Forces_IMG.TabStop = False
		'
		'Load_Analysis
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Window
		Me.ClientSize = New System.Drawing.Size(782, 554)
		Me.Controls.Add(Me.Box_Forces_IMG)
		Me.Controls.Add(Me.Feed_Thru_Group)
		Me.Controls.Add(Me.Box_Force_Input)
		Me.Controls.Add(Me.Antenna_Forces_Group)
		Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Margin = New System.Windows.Forms.Padding(4)
		Me.Name = "Load_Analysis"
		Me.Text = "Load Analysis"
		Me.Antenna_Forces_Group.ResumeLayout(False)
		Me.Antenna_Forces_Group.PerformLayout()
		Me.Box_Force_Input.ResumeLayout(False)
		Me.Box_Force_Input.PerformLayout()
		Me.Feed_Thru_Group.ResumeLayout(False)
		Me.Feed_Thru_Group.PerformLayout()
		CType(Me.Box_Forces_IMG, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents Box_Weight_Input As TextBox
	Friend WithEvents Vd_Aircraft_Input As TextBox
	Friend WithEvents Dive_Speed As Label
	Friend WithEvents Grav1_Load As ComboBox
	Friend WithEvents Label3 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents Grav2_Load As ComboBox
	Friend WithEvents Label5 As Label
	Friend WithEvents Grav3_Load As ComboBox
	Friend WithEvents SA_Antenna_Input As TextBox
	Friend WithEvents SA_Antenna As Label
	Friend WithEvents Side_Load_Force_Output As Label
	Friend WithEvents Antenna_Forces_Group As GroupBox
	Friend WithEvents Label9 As Label
	Friend WithEvents Fastener_Dist_Input As TextBox
	Friend WithEvents Fastener_Distance As Label
	Friend WithEvents Antenna_Fastener_Num_Input As TextBox
	Friend WithEvents Fasteners_Per_Side As Label
	Friend WithEvents Box_Force_Input As GroupBox
	Friend WithEvents Antenna_Forces_Button As Button
	Friend WithEvents Force_Distance_Input As TextBox
	Friend WithEvents Force_Distance As Label
	Friend WithEvents Feed_Thru_Group As GroupBox
	Friend WithEvents Doubler_Tensile_Input As TextBox
	Friend WithEvents Doubler_Tensile_Strength As Label
	Friend WithEvents Fastener_Tension_Label As Label
	Friend WithEvents FeedThru_Diameter_Label As Label
	Friend WithEvents Skin_Thickness As Label
	Friend WithEvents Fast_Num_Output As Label
	Friend WithEvents Label15 As Label
	Friend WithEvents Fastener_Tension_Spec_Input As TextBox
	Friend WithEvents Hole_Diameter_Input As TextBox
	Friend WithEvents Skin_Thick_Input As TextBox
	Friend WithEvents Feed_Thru_Button As Button
	Friend WithEvents Resultant_Forces_Button As Button
	Friend WithEvents Box_Fastener_Num_Input As TextBox
	Friend WithEvents Label16 As Label
	Friend WithEvents Box_Forces_IMG As PictureBox
	Friend WithEvents Gravity_Note_Label As Label
	Friend WithEvents G3_Force As Label
	Friend WithEvents G2_Force As Label
	Friend WithEvents G1_Force As Label
	Friend WithEvents Safety_Factor_Label As Label
	Friend WithEvents Fastener_Diameter As TextBox
	Friend WithEvents Fastener_Diameter_Label As Label
	Friend WithEvents Skin_Bearing_Strength As TextBox
	Friend WithEvents Skin_Bearing As Label
	Friend WithEvents Clear_Inputs As Button
End Class
