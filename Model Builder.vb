Imports SwConst
Imports SwCommands
Imports SldWorks

Public Class Model_Builder

	Dim swApp As SldWorks.SldWorks
	Dim swDoc As ModelDoc2
	Dim fileerror As Integer
    Dim filewarning As Integer
    Dim config As Configuration
    Dim CusProperties As CustomPropertyManager
    Dim Extrusion_Number = String.Empty
    Dim Open_Config As Boolean
    Dim Change_Config = String.Empty
    Dim Filename = String.Empty
    Dim File_Extension As String = ".SLDPRT"
    Dim Generic_Error As New Error_Message
    Dim SuppressFeat As Boolean
    Dim SuppressFeat2 As Boolean
	Dim swModelDocExt As ModelDocExtension
	Dim Extrusion_Num As Integer

	Dim PropertyNames() As String = {"LENGTH", "MOUNTING_HOLE_SIZE", "RACK_HOLE_SIZE", "MOUNTING_LINEAR_ED", "MOUNTING_ED", "RACK_LINEAR_ED", "RACK_ED",
			"MOUNTING_HOLES", "RACK_HOLES", "HEIGHT", "THK", "L_LIP", "U_LIP"}

	Dim PropertyDescription = New String() {"Extrusion length", "Size of the 1st set of holes", "Size of the 2nd set of holes",
			"Long edge distance for 1st set of holes", "Short edge distance for 1st set of holes",
			"Long edge distance for 2nd set of holes", "Short edge distance for 2nd set of holes",
			"Number of 1st set of holes", "Number of 2nd set of holes", "Extrusion Height", "Thickness", "Lower Lip Length", "Upper Lip Length"}

	Dim GussetNames() As String = {"LENGTH", "HEIGHT", "THK", "BEND RADIUS", "SIDE LIP", "BOTTOM LIP", "RELIEF HEIGHT", "RELIEF WIDTH", "RELIEF RADIUS",
			"ANGLE CUT WIDTH", "ANGLE CUT HEIGHT", "RIVET NUMBERS", "RIVET WIDTH"}

	Dim GussetDescription() As String = {"Gusset length", "Gusset total height", "Thickness", "Inside bend radius", "Side lip length", "Bottom lip length",
			"Relief height", "Relief width", "Relief radius", "Angle cut width", "Angle cut height from bottom", "Number of rivets", "Rivet distance from side lip"}

	Dim U_PropertyNames() As String = {"LENGTH", "WIDTH", "HEIGHT", "THK", "INSIDE RADIUS", "LIP1_HOLE_SIZE", "LIP1_LINEAR_ED", "LIP1_ED", "LIP1_HOLES",
			"LIP2_HOLE_SIZE", "LIP2_LINEAR_ED", "LIP2_ED", "LIP2_HOLES"}

	Dim U_Description() As String = {"Channel Length", "Channel Width", "Channel Height", "Thickness", "Inside Radius", "Lip 1 Hole Size", "Lip 1 Linear Edge Distance",
			"Lip 1 Edge Distance", "Lip 1 Holes", "Lip 2 Hole Size", "Lip 2 Linear Edge Distance", "Lip 2 Edge Distance", "Lip 2 Holes"}

	Private Sub Form_Resize() Handles Me.ResizeEnd
		Functions.Form_resize(Me)
	End Sub

	Private Sub Property_Update_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Form_Resize()

		ToolStripStatusLabel1.Text = "Fields that are left blank will not be updated."
		Extrusion_Input.BackColor = System.Drawing.SystemColors.Window
		Extrusion_Input.ForeColor = System.Drawing.SystemColors.WindowText
		Extrusion_Input.ReadOnly = False
		Extrusion_Load.Visible = True

		Model_Image.Visible = False

		Label1.Visible = False
		Label2.Visible = False
		Label3.Visible = False
		Label4.Visible = False
		Label5.Visible = False
		Label6.Visible = False
		Label7.Visible = False
		Label8.Visible = False
		Label9.Visible = False
		Label10.Visible = False
		Label12.Visible = False
		Label11.Visible = False
		Label13.Visible = False

		Gusset_Mirror_Check.Visible = False

		Label1_Input.Visible = False
		Label2_Input.Visible = False
		Label3_Input.Visible = False
		Label4_Input.Visible = False
		Label5_Input.Visible = False
		Label6_Input.Visible = False
		Label7_Input.Visible = False
		Label8_Input.Visible = False
		Label9_Input.Visible = False
		Label10_Input.Visible = False
		Label12_Input.Visible = False
		Label11_Input.Visible = False
		Label13_Input.Visible = False

		'Clears previous input text
		Label1_Input.Text = ""
		Label2_Input.Text = ""
		Label3_Input.Text = ""
		Label4_Input.Text = ""
		Label5_Input.Text = ""
		Label6_Input.Text = ""
		Label7_Input.Text = ""
		Label8_Input.Text = ""
		Label9_Input.Text = ""
		Label10_Input.Text = ""
		Label12_Input.Text = ""
		Label11_Input.Text = ""
		Label13_Input.Text = ""

		If Functions.Calling_Fun = "Custom L" Or Functions.Calling_Fun = "Custom Z" Or Functions.Calling_Fun = "Gusset" Or Functions.Calling_Fun = "U Channel" Then
			'Extrusion_Num = 1
			Extrusion_Input.Text = "N/A"
			Extrusion_Load.PerformClick()
		End If

	End Sub

	Private Sub Extrusion_input_Keydown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Extrusion_Input.KeyDown
		If (e.KeyCode = Keys.Enter) Then
			Extrusion_Load_Click(sender, e)
		End If
	End Sub

	Private Sub Accept_Button_Click(sender As Object, e As EventArgs) Handles Accept_Button.Click

		Dim Error_Bool As Boolean = False

		If SWFunctions.swApp.ActiveDoc Is Nothing Then
			Functions.Error_Form(,,,,,, Me)

		Else

			Dim InputNum As Decimal

			'if it is not Gussets result is true and check other conditions
			'if it is Gussets result is false and do Gusset stuff
			If Functions.Calling_Fun <> "Gusset" Then

				'if it is U Channel result is true
				'if not U Channel result is false and do L and Z Angle stuff
				If Functions.Calling_Fun = "U Channel" Then

					swDoc = swApp.ActiveDoc
					CusProperties = swDoc.Extension.CustomPropertyManager("")

					If Label1_Input.Text <> "" Then

						InputNum = Functions.Text_Validate(Label1_Input, "Decimal", Me, Label1.Text)
						If InputNum = 0 Then
							Exit Sub
						Else
							CusProperties.Set2(U_PropertyNames(0), InputNum)
						End If

					End If

					If Label2_Input.Text <> "" Then

						InputNum = Functions.Text_Validate(Label2_Input, "Decimal", Me, Label2.Text)
						If InputNum = 0 Then
							Exit Sub
						Else
							CusProperties.Set2(U_PropertyNames(1), InputNum)
						End If

					End If

					If Label3_Input.Text <> "" Then

						InputNum = Functions.Text_Validate(Label3_Input, "Decimal", Me, Label3.Text)
						If InputNum = 0 Then
							Exit Sub
						Else
							CusProperties.Set2(U_PropertyNames(2), InputNum)
						End If

					End If

					If Label4_Input.Text <> "" Then

						InputNum = Functions.Text_Validate(Label4_Input, "Decimal", Me, Label4.Text)
						If InputNum = 0 Then
							Exit Sub
						Else
							CusProperties.Set2(U_PropertyNames(3), InputNum)
						End If

					End If

					If Label5_Input.Text <> "" Then

						InputNum = Functions.Text_Validate(Label5_Input, "Decimal", Me, Label5.Text)
						If InputNum = 0 Then
							Exit Sub
						Else
							CusProperties.Set2(U_PropertyNames(4), InputNum)
						End If

					End If

					If Label6_Input.Text <> "" Then

						InputNum = Functions.Text_Validate(Label6_Input, "Decimal", Me, Label6.Text)
						If InputNum = 0 Then
							Exit Sub
						Else
							CusProperties.Set2(U_PropertyNames(5), InputNum)
						End If

					End If

					If Label7_Input.Text <> "" Then

						InputNum = Functions.Text_Validate(Label7_Input, "Decimal", Me, Label7.Text)
						If InputNum = 0 Then
							Exit Sub
						Else
							CusProperties.Set2(U_PropertyNames(6), InputNum)
						End If

					End If

					If Label8_Input.Text <> "" Then

						InputNum = Functions.Text_Validate(Label8_Input, "Decimal", Me, Label8.Text)
						If InputNum = 0 Then
							Exit Sub
						Else
							CusProperties.Set2(U_PropertyNames(7), InputNum)
						End If

					End If

					If Label9_Input.Text <> "" Then

						InputNum = Functions.Text_Validate(Label9_Input, "Decimal", Me, Label9.Text)
						If InputNum = 0 Then
							Exit Sub
						Else
							CusProperties.Set2(U_PropertyNames(8), InputNum)
						End If

					End If

					If Label10_Input.Text <> "" Then

						InputNum = Functions.Text_Validate(Label10_Input, "Decimal", Me, Label10.Text)
						If InputNum = 0 Then
							Exit Sub
						Else
							CusProperties.Set2(U_PropertyNames(9), InputNum)
						End If

					End If

					If Label11_Input.Text <> "" Then

						InputNum = Functions.Text_Validate(Label11_Input, "Decimal", Me, Label11.Text)
						If InputNum = 0 Then
							Exit Sub
						Else
							CusProperties.Set2(U_PropertyNames(10), InputNum)
						End If

					End If

					If Label12_Input.Text <> "" Then

						InputNum = Functions.Text_Validate(Label12_Input, "Decimal", Me, Label12.Text)
						If InputNum = 0 Then
							Exit Sub
						Else
							CusProperties.Set2(U_PropertyNames(11), InputNum)
						End If

					End If

					If Label13_Input.Text <> "" Then

						InputNum = Functions.Text_Validate(Label13_Input, "Decimal", Me, Label13.Text)
						If InputNum = 0 Then
							Exit Sub
						Else
							CusProperties.Set2(U_PropertyNames(12), InputNum)
						End If

						'If Decimal.TryParse(Label13_Input.Text, InputNum) Then
						'	CusProperties.Set2(U_PropertyNames(12), InputNum)
						'Else
						'	Error_Bool = True
						'	Label1_Input.BackColor = Color.Gray
						'	Label1_Input.ForeColor = Color.White

						'End If

					End If

					swDoc.ForceRebuild3(True)
					swDoc.ShowNamedView2("*Isometric", 7)
					swDoc.ViewZoomtofit2()
					Functions.Status = True

					Me.Close()
					Exit Sub

					'If it isn't U Channel do normal L and Z Angle stuff
				Else

					Dim EnteredValue = String.Empty

					swDoc = swApp.ActiveDoc
					config = swDoc.GetActiveConfiguration

					'Allows access to the custom property manager
					CusProperties = swDoc.Extension.CustomPropertyManager("")

					If Label1_Input.Text <> "" Then
						If Decimal.TryParse(Label1_Input.Text, InputNum) Then
							CusProperties.Set2(PropertyNames(0), InputNum)
						Else
							Error_Bool = True
							Label1_Input.BackColor = Color.Gray
							Label1_Input.ForeColor = Color.White

						End If

					End If

					If Label2_Input.Text <> "" Then
						If Decimal.TryParse(Label2_Input.Text, InputNum) Then
							CusProperties.Set2(PropertyNames(1), InputNum)
						Else
							Error_Bool = True
							Label2_Input.BackColor = Color.Gray
							Label2_Input.ForeColor = Color.White

						End If
						'InputNum = Decimal.Parse(Label2_Input.Text)

					End If

					If Label3_Input.Text <> "" Then
						If Decimal.TryParse(Label3_Input.Text, InputNum) Then
							CusProperties.Set2(PropertyNames(2), InputNum)
						Else
							Error_Bool = True
							Label3_Input.BackColor = Color.Gray
							Label3_Input.ForeColor = Color.White

						End If
						'InputNum = Decimal.Parse(Label3_Input.Text)

					End If

					If Label4_Input.Text <> "" Then
						If Decimal.TryParse(Label4_Input.Text, InputNum) Then
							CusProperties.Set2(PropertyNames(3), InputNum)
						Else
							Error_Bool = True
							Label4_Input.BackColor = Color.Gray
							Label4_Input.ForeColor = Color.White

						End If
						'InputNum = Decimal.Parse(Label4_Input.Text)

					End If

					If Label5_Input.Text <> "" Then
						If Decimal.TryParse(Label5_Input.Text, InputNum) Then
							CusProperties.Set2(PropertyNames(4), InputNum)
						Else
							Error_Bool = True
							Label5_Input.BackColor = Color.Gray
							Label5_Input.ForeColor = Color.White

						End If
						'InputNum = Decimal.Parse(Label5_Input.Text)

					End If

					If Label6_Input.Text <> "" Then
						If Decimal.TryParse(Label6_Input.Text, InputNum) Then
							CusProperties.Set2(PropertyNames(5), InputNum)
						Else
							Error_Bool = True
							Label6_Input.BackColor = Color.Gray
							Label6_Input.ForeColor = Color.White

						End If
						'InputNum = Decimal.Parse(Label6_Input.Text)

					End If

					If Label7_Input.Text <> "" Then
						If Decimal.TryParse(Label7_Input.Text, InputNum) Then
							CusProperties.Set2(PropertyNames(6), InputNum)
						Else
							Error_Bool = True
							Label7_Input.BackColor = Color.Gray
							Label7_Input.ForeColor = Color.White

						End If
						'InputNum = Decimal.Parse(Label7_Input.Text)

					End If

					If Label8_Input.Text <> "" Then
						If Integer.TryParse(Label8_Input.Text, InputNum) Then
							If Label8_Input.Text > 1 Then
								'Suppress single hole feature, unsuppress multiple holes feature
								SuppressFeat = swDoc.Extension.SelectByID2("MOUNTING HOLES", "BODYFEATURE", 0, 0, 0, False, 0, Nothing, 0)
								SuppressFeat = swDoc.EditUnsuppress2

								SuppressFeat2 = swDoc.Extension.SelectByID2("SINGLE MOUNTING HOLE", "BODYFEATURE", 0, 0, 0, False, 0, Nothing, 0)
								SuppressFeat2 = swDoc.EditSuppress2

								CusProperties.Set2(PropertyNames(7), Label8_Input.Text)
							Else
								'Suppress multiple holes feature, suppress single hole feature
								SuppressFeat = swDoc.Extension.SelectByID2("MOUNTING HOLES", "BODYFEATURE", 0, 0, 0, False, 0, Nothing, 0)
								SuppressFeat = swDoc.EditSuppress2

								SuppressFeat2 = swDoc.Extension.SelectByID2("SINGLE MOUNTING HOLE", "BODYFEATURE", 0, 0, 0, False, 0, Nothing, 0)
								SuppressFeat2 = swDoc.EditUnsuppress2

								CusProperties.Set2(PropertyNames(7), Label8_Input.Text)
							End If
						Else
							Error_Bool = True
							Label8_Input.BackColor = Color.Gray
							Label8_Input.ForeColor = Color.White

						End If

					End If

					If Label9_Input.Text <> "" Then
						If Integer.TryParse(Label9_Input.Text, InputNum) Then
							If Label9_Input.Text > 1 Then
								'Suppress single hole feature, unsuppress multiple holes feature
								SuppressFeat = swDoc.Extension.SelectByID2("RACK MOUNTING HOLES", "BODYFEATURE", 0, 0, 0, False, 0, Nothing, 0)
								SuppressFeat = swDoc.EditUnsuppress2

								SuppressFeat2 = swDoc.Extension.SelectByID2("SINGLE RACK MOUNTING HOLE", "BODYFEATURE", 0, 0, 0, False, 0, Nothing, 0)
								SuppressFeat2 = swDoc.EditSuppress2

								CusProperties.Set2(PropertyNames(8), Label9_Input.Text)
							Else
								'Suppress multiple holes feature, suppress single hole feature
								SuppressFeat = swDoc.Extension.SelectByID2("RACK MOUNTING HOLES", "BODYFEATURE", 0, 0, 0, False, 0, Nothing, 0)
								SuppressFeat = swDoc.EditSuppress2

								SuppressFeat2 = swDoc.Extension.SelectByID2("SINGLE RACK MOUNTING HOLE", "BODYFEATURE", 0, 0, 0, False, 0, Nothing, 0)
								SuppressFeat2 = swDoc.EditUnsuppress2

								CusProperties.Set2(PropertyNames(8), Label9_Input.Text)
							End If
						Else
							Error_Bool = True
							Label9_Input.BackColor = Color.Gray
							Label9_Input.ForeColor = Color.White

						End If

					End If

					If Label10_Input.Text <> "" Then
						If Decimal.TryParse(Label10_Input.Text, InputNum) Then
							CusProperties.Set2(PropertyNames(9), InputNum)
						Else
							Error_Bool = True
							Label10_Input.BackColor = Color.Gray
							Label10_Input.ForeColor = Color.White

						End If
						'InputNum = Decimal.Parse(Label10_Input.Text)

					End If

					If Label11_Input.Text <> "" Then
						If Decimal.TryParse(Label11_Input.Text, InputNum) Then
							CusProperties.Set2(PropertyNames(10), InputNum)
						Else
							Error_Bool = True
							Label11_Input.BackColor = Color.Gray
							Label11_Input.ForeColor = Color.White

						End If
						'InputNum = Decimal.Parse(Label11_Input.Text)

					End If

					If Label12_Input.Text <> "" Then
						If Decimal.TryParse(Label12_Input.Text, InputNum) Then
							CusProperties.Set2(PropertyNames(11), InputNum)
						Else
							Error_Bool = True
							Label12_Input.BackColor = Color.Gray
							Label12_Input.ForeColor = Color.White

						End If
						'InputNum = Decimal.Parse(Label12_Input.Text)

					End If

					If Label13_Input.Text <> "" Then
						If Decimal.TryParse(Label13_Input.Text, InputNum) Then
							CusProperties.Set2(PropertyNames(12), InputNum)
						Else
							Error_Bool = True
							Label13_Input.BackColor = Color.Gray
							Label13_Input.ForeColor = Color.White

						End If
						'InputNum = Decimal.Parse(Label13_Input.Text)

					End If

					If Error_Bool = True Then
						Dim Calling_Function As String = Functions.Calling_Fun
						If Calling_Function = "10133" Or Calling_Function = "10134" Then
							Calling_Function = "L Angle-" + Calling_Function
						ElseIf Calling_Function = "Custom L" Then

							Calling_Function = "Custom L Angle"
						End If

						If Calling_Function = "10138" Or Calling_Function = "10139" Then
							Calling_Function = "z Angle-" + Calling_Function
						ElseIf Calling_Function = "Custom Z" Then
							Calling_Function = "Custom Z Angle"
						End If
						Functions.Error_Form(Calling_Function + " Default Values", "Using default values on" + System.Environment.NewLine + "the greyed text fields",,,,, Me)
					End If

					swDoc.ForceRebuild3(True)
					swDoc.ShowNamedView2("*Isometric", 7)
					swDoc.ViewZoomtofit2()
					Functions.Status = True

				End If


			Else

				'Do Gusset stuff here

				Dim Default_Width As Decimal
				Dim Default_Height As Decimal
				Dim Default_Radius As Decimal
				Dim Default_THK As Decimal
				Dim Default_Bend_R As Decimal
				Dim Relief_Width As Decimal
				Dim Relief_Height As Decimal
				Dim Relief_Radius As Decimal
				Dim Lip_Length As Decimal

				Dim Error_String As String = String.Empty
				Dim Error_String2 As String = String.Empty

				swDoc = swApp.ActiveDoc
				config = swDoc.GetActiveConfiguration

				'Allows access to the custom property manager
				CusProperties = swDoc.Extension.CustomPropertyManager("")

				If Label1_Input.Text <> "" Then
					If Decimal.TryParse(Label1_Input.Text, InputNum) Then
						CusProperties.Set2(GussetNames(0), InputNum)
						Lip_Length = InputNum
					Else


					End If
					'InputNum = Decimal.Parse(Label1_Input.Text)

				End If

				If Label2_Input.Text <> "" Then
					If Decimal.TryParse(Label2_Input.Text, InputNum) Then
						CusProperties.Set2(GussetNames(1), InputNum)

					Else
						Error_Bool = True
						Label2_Input.BackColor = Color.Gray
						Label2_Input.ForeColor = Color.White

					End If
					'InputNum = Decimal.Parse(Label2_Input.Text)

				End If

				If Label3_Input.Text <> "" Then
					If Decimal.TryParse(Label3_Input.Text, InputNum) Then
						Default_THK = InputNum
						CusProperties.Set2(GussetNames(2), InputNum)
					Else
						Error_Bool = True
						Label3_Input.BackColor = Color.Gray
						Label3_Input.ForeColor = Color.White

					End If
					'InputNum = Decimal.Parse(Label3_Input.Text)

				End If

				If Label4_Input.Text <> "" Then
					If Decimal.TryParse(Label4_Input.Text, InputNum) Then
						Default_Bend_R = InputNum
						CusProperties.Set2(GussetNames(3), InputNum)
					Else
						Error_Bool = True
						Label4_Input.BackColor = Color.Gray
						Label4_Input.ForeColor = Color.White

					End If
					'InputNum = Decimal.Parse(Label4_Input.Text)

				End If

				If Label5_Input.Text <> "" Then
					If Decimal.TryParse(Label5_Input.Text, InputNum) Then
						CusProperties.Set2(GussetNames(4), InputNum)

					Else
						Error_Bool = True
						Label5_Input.BackColor = Color.Gray
						Label5_Input.ForeColor = Color.White

					End If
					'InputNum = Decimal.Parse(Label5_Input.Text)

				End If

				If Label6_Input.Text <> "" Then
					If Decimal.TryParse(Label6_Input.Text, InputNum) Then
						CusProperties.Set2(GussetNames(5), InputNum)

					Else
						Error_Bool = True
						Label6_Input.BackColor = Color.Gray
						Label6_Input.ForeColor = Color.White

					End If
					'InputNum = Decimal.Parse(Label6_Input.Text)

				End If

				'Relief Radius
				Default_THK = CusProperties.Get(GussetNames(2))
				Default_Bend_R = CusProperties.Get(GussetNames(3))

				Default_Height = Default_THK + Default_Bend_R
				Default_Width = Default_Height
				Default_Radius = Default_Height - 0.05

				'Relief Height
				If Label7_Input.Text <> "" Then
					If Decimal.TryParse(Label7_Input.Text, InputNum) Then
						Relief_Height = InputNum
						If Relief_Height > Default_Height Then
							CusProperties.Set2(GussetNames(6), Relief_Height)
						Else
							Functions.Error_Form("Invalid Input", "Relief Height would result in errors",, "Using default values",,, Me)
							CusProperties.Set2(GussetNames(6), Default_Height)
						End If
					Else
						Error_Bool = True
						Label7_Input.BackColor = Color.Gray
						Label7_Input.ForeColor = Color.White

					End If
					'InputNum = Decimal.Parse(Label7_Input.Text)

				End If

				'Relief Width
				If Label8_Input.Text <> "" Then
					If Decimal.TryParse(Label8_Input.Text, InputNum) Then
						Relief_Width = InputNum
						If Relief_Width > Default_Width Then
							CusProperties.Set2(GussetNames(7), Relief_Width)
						Else
							Functions.Error_Form("Invalid Input", "Relief Width would result in errors",, "Using default values",,, Me)
							CusProperties.Set2(GussetNames(7), Default_Width)
						End If
					Else
						Error_Bool = True
						Label8_Input.BackColor = Color.Gray
						Label8_Input.ForeColor = Color.White

					End If
					'InputNum = Decimal.Parse(Label8_Input.Text)

				End If
				'Relief Radius
				If Label9_Input.Text <> "" Then
					If Decimal.TryParse(Label9_Input.Text, InputNum) Then
						Relief_Radius = InputNum
						If Relief_Radius < Default_Radius Then
							CusProperties.Set2(GussetNames(8), Relief_Radius)
						Else
							Functions.Error_Form("Invalid Input", "Relief Radius would result in errors",, "Using default values",,, Me)
							CusProperties.Set2(GussetNames(8), Default_Radius)
						End If
					Else
						Error_Bool = True
						Label9_Input.BackColor = Color.Gray
						Label9_Input.ForeColor = Color.White

					End If
					'InputNum = Decimal.Parse(Label9_Input.Text)

				End If

				If Label10_Input.Text <> "" Then
					If Decimal.TryParse(Label10_Input.Text, InputNum) Then
						CusProperties.Set2(GussetNames(9), InputNum)

					Else
						Error_Bool = True
						Label10_Input.BackColor = Color.Gray
						Label10_Input.ForeColor = Color.White

					End If
					'InputNum = Decimal.Parse(Label10_Input.Text)

				End If

				If Label11_Input.Text <> "" Then
					If Decimal.TryParse(Label11_Input.Text, InputNum) Then
						CusProperties.Set2(GussetNames(10), InputNum)

					Else
						Error_Bool = True
						Label11_Input.BackColor = Color.Gray
						Label11_Input.ForeColor = Color.White

					End If
					'InputNum = Decimal.Parse(Label11_Input.Text)

				End If

				If Label12_Input.Text <> "" Then
					If Decimal.TryParse(Label12_Input.Text, InputNum) Then
						CusProperties.Set2(GussetNames(11), InputNum)

					Else
						Error_Bool = True
						Label12_Input.BackColor = Color.Gray
						Label12_Input.ForeColor = Color.White

					End If
					'InputNum = Decimal.Parse(Label12_Input.Text)

				End If

				If Label13_Input.Text <> "" Then
					If Decimal.TryParse(Label13_Input.Text, InputNum) Then
						CusProperties.Set2(GussetNames(12), InputNum)

					Else
						Error_Bool = True
						Label13_Input.BackColor = Color.Gray
						Label13_Input.ForeColor = Color.White

					End If
					'InputNum = Decimal.Parse(Label13_Input.Text)

				End If

				If Error_Bool = True Then
					Functions.Error_Form("Gusset Default Values", "Using default values on" + System.Environment.NewLine + "the greyed text fields",,,,, Me)
				End If


				If Gusset_Mirror_Check.CheckState = CheckState.Checked Then
					Open_Config = swDoc.ShowConfiguration2("Mirrored")
					swDoc = swApp.ActiveDoc
				Else
					Open_Config = swDoc.ShowConfiguration2("Default")
				End If

				swDoc.ForceRebuild3(True)
				swDoc.ShowNamedView2("OppoIso", -1)
				swDoc.ViewZoomtofit2()
				Functions.Status = True

				'Dim CurrentModelViewArray As Object
				'CurrentModelViewArray = swDoc.GetModelViewNames

				'For i = 0 To swDoc.GetModelViewCount - 1

				'	Debug.Print(CurrentModelViewArray(i).ToString)          'Lists all of the views / custom views

				'Next

			End If

			Me.Close()

		End If

	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Me.Close()
	End Sub

	Private Sub Extrusion_Load_Click(sender As Object, e As EventArgs) Handles Extrusion_Load.Click

		swApp = CreateObject("SldWorks.Application")

		Extrusion_Input.ReadOnly = True
		Extrusion_Input.BackColor = Color.Gray
		Extrusion_Input.ForeColor = Color.White
		Extrusion_Load.Visible = False

		Extrusion_Num = Functions.Input_Validate(Extrusion_Input.Text, "Integer")
		'Extrusion_Num = Functions.Text_Validate(Extrusion_Input, "Integer", Me, "Extrusion input")

		Label1_Input.Focus()

		'Open File and Configuration
		If Extrusion_Input.Text = "N/A" Then

			'Gussets
			If Functions.Calling_Fun = "Gusset" Then
				'Functions.Error_Form("Not Yet", "No " & Functions.Calling_Fun & " program logic yet",,,,, Me)
				'Close()
				MsgBox("2")

				swDoc = swApp.OpenDoc6("T:\Engineering\Non-Site Specific\PARTS\LIBRARY\GUSSET\GUSSET BASE MODEL.SLDPRT", 1, 0, "", fileerror, filewarning)
				swDoc = swApp.ActiveDoc
				config = swDoc.GetActiveConfiguration
				Open_Config = swDoc.ShowConfiguration2("Default")

				Model_Image.Visible = True
				Model_Image.Image = My.Resources.Gusset
				Width = Width + Model_Image.Width
				Form_Resize()

				Gusset_Mirror_Check.Visible = True

				Label1.Text = GussetDescription(0)
				Label2.Text = GussetDescription(1)
				Label3.Text = GussetDescription(2)
				Label4.Text = GussetDescription(3)
				Label5.Text = GussetDescription(4)
				Label6.Text = GussetDescription(5)
				Label7.Text = GussetDescription(6)
				Label8.Text = GussetDescription(7)
				Label9.Text = GussetDescription(8)
				Label10.Text = GussetDescription(9)
				Label11.Text = GussetDescription(10)
				Label12.Text = GussetDescription(11)
				Label13.Text = GussetDescription(12)

				Label1.Visible = True
				Label2.Visible = True
				Label3.Visible = True
				Label4.Visible = True
				Label5.Visible = True
				Label6.Visible = True
				Label7.Visible = True
				Label8.Visible = True
				Label9.Visible = True
				Label10.Visible = True
				Label11.Visible = True
				Label12.Visible = True
				Label13.Visible = True

				Label1_Input.Visible = True
				Label2_Input.Visible = True
				Label3_Input.Visible = True
				Label4_Input.Visible = True
				Label5_Input.Visible = True
				Label6_Input.Visible = True
				Label7_Input.Visible = True
				Label8_Input.Visible = True
				Label9_Input.Visible = True
				Label10_Input.Visible = True
				Label11_Input.Visible = True
				Label12_Input.Visible = True
				Label13_Input.Visible = True



				Exit Sub

			End If

			If Functions.Calling_Fun = "U Channel" Then

				swDoc = swApp.OpenDoc6("T:\Engineering\Non-Site Specific\PARTS\LIBRARY\U CHANNELS\AND10137 EXTRUSION.SLDPRT", 1, 0, "", fileerror, filewarning)
				swDoc = swApp.ActiveDoc

				Model_Image.Visible = True
				Model_Image.Image = My.Resources.U_Channel
				Width = Width + Model_Image.Width
				Form_Resize()

				Label1.Text = U_Description(0)
				Label2.Text = U_Description(1)
				Label3.Text = U_Description(2)
				Label4.Text = U_Description(3)
				Label5.Text = U_Description(4)
				Label6.Text = U_Description(5)
				Label7.Text = U_Description(6)
				Label8.Text = U_Description(7)
				Label9.Text = U_Description(8)
				Label10.Text = U_Description(9)
				Label11.Text = U_Description(10)
				Label12.Text = U_Description(11)
				Label13.Text = U_Description(12)

				Label1.Visible = True
				Label2.Visible = True
				Label3.Visible = True
				Label4.Visible = True
				Label5.Visible = True
				Label6.Visible = True
				Label7.Visible = True
				Label8.Visible = True
				Label9.Visible = True
				Label10.Visible = True
				Label11.Visible = True
				Label12.Visible = True
				Label13.Visible = True

				Label1_Input.Visible = True
				Label2_Input.Visible = True
				Label3_Input.Visible = True
				Label4_Input.Visible = True
				Label5_Input.Visible = True
				Label6_Input.Visible = True
				Label7_Input.Visible = True
				Label8_Input.Visible = True
				Label9_Input.Visible = True
				Label10_Input.Visible = True
				Label11_Input.Visible = True
				Label12_Input.Visible = True
				Label13_Input.Visible = True

			End If

			If Functions.Calling_Fun <> "Gusset" Then 'Or Functions.Calling_Fun <> "U Channel" Then

				If Functions.Calling_Fun <> "U Channel" Then

					Label1.Text = PropertyDescription(0)
					Label2.Text = PropertyDescription(1)
					Label3.Text = PropertyDescription(2)
					Label4.Text = PropertyDescription(3)
					Label5.Text = PropertyDescription(4)
					Label6.Text = PropertyDescription(5)
					Label7.Text = PropertyDescription(6)
					Label8.Text = PropertyDescription(7)
					Label9.Text = PropertyDescription(8)

					Label1.Visible = True
					Label2.Visible = True
					Label3.Visible = True
					Label4.Visible = True
					Label5.Visible = True
					Label6.Visible = True
					Label7.Visible = True
					Label8.Visible = True
					Label9.Visible = True

					Label1_Input.Visible = True
					Label2_Input.Visible = True
					Label3_Input.Visible = True
					Label4_Input.Visible = True
					Label5_Input.Visible = True
					Label6_Input.Visible = True
					Label7_Input.Visible = True
					Label8_Input.Visible = True
					Label9_Input.Visible = True
				End If

			End If

			If Functions.Calling_Fun = "Custom L" Then

				Model_Image.Visible = True
				Model_Image.Image = My.Resources.Custom_L_Angle
				Width = Width + Model_Image.Width
				Form_Resize()


				swDoc = swApp.OpenDoc6("T:\Engineering\Non-Site Specific\PARTS\LIBRARY\L ANGLES\Custom\L-Angle.SLDPRT", 1, 0, "", fileerror, filewarning)
				swDoc = swApp.ActiveDoc

				Label10.Text = PropertyDescription(9)
				Label11.Text = PropertyDescription(10)
				Label12.Text = PropertyDescription(11)

				Label10.Visible = True
				Label12.Visible = True
				Label11.Visible = True

				Label10_Input.Visible = True
				Label11_Input.Visible = True
				Label12_Input.Visible = True
			End If

			If Functions.Calling_Fun = "Custom Z" Then

				Model_Image.Visible = True
				Model_Image.Image = My.Resources.Custom_Z_Angle
				Width = Width + Model_Image.Width
				Form_Resize()

				swDoc = swApp.OpenDoc6("T:\Engineering\Non-Site Specific\PARTS\LIBRARY\ZEE ANGLES\Custom\Z-Angle.SLDPRT", 1, 0, "", fileerror, filewarning)
				swDoc = swApp.ActiveDoc

				Label10.Text = PropertyDescription(9)
				Label11.Text = PropertyDescription(10)
				Label12.Text = PropertyDescription(11)
				Label13.Text = PropertyDescription(12)

				Label10.Visible = True
				Label12.Visible = True
				Label11.Visible = True
				Label13.Visible = True

				Label10_Input.Visible = True
				Label11_Input.Visible = True
				Label12_Input.Visible = True
				Label13_Input.Visible = True
			End If

		ElseIf Extrusion_Num = 0 Then

			Functions.Error_Form("Invalid Input", "Please enter a valid extrusion number",,,,, Me)
			Property_Update_Load(sender, e)

		Else

			'L Angles
			If Functions.Calling_Fun = "10133" Or Functions.Calling_Fun = "10134" Or Functions.Calling_Fun = "Custom L" Then
				Model_Image.Visible = True
				Model_Image.Image = My.Resources.Custom_L_Angle
				Width = Width + Model_Image.Width
				Form_Resize()

				If Functions.Calling_Fun = "10133" Then

					swDoc = swApp.OpenDoc6("T:\Engineering\Non-Site Specific\PARTS\LIBRARY\L ANGLES\EQUAL LEGS\AND10133 BASE L #0401-1604.SLDPRT", 1, 0, "", fileerror, filewarning)
					swDoc = swApp.ActiveDoc
					config = swDoc.GetActiveConfiguration
					Open_Config = swDoc.ShowConfiguration2(Extrusion_Num)

				ElseIf Functions.Calling_Fun = "10134" Then

					swDoc = swApp.OpenDoc6("T:\Engineering\Non-Site Specific\PARTS\LIBRARY\L ANGLES\UNEQUAL LEGS\AND10134 BASE L #0501-1604.SLDPRT", 1, 0, "", fileerror, filewarning)
					swDoc = swApp.ActiveDoc
					config = swDoc.GetActiveConfiguration
					Open_Config = swDoc.ShowConfiguration2(Extrusion_Num)

				End If

				Label1.Text = PropertyDescription(0)
				Label2.Text = PropertyDescription(1)
				Label3.Text = PropertyDescription(2)
				Label4.Text = PropertyDescription(3)
				Label5.Text = PropertyDescription(4)
				Label6.Text = PropertyDescription(5)
				Label7.Text = PropertyDescription(6)
				Label8.Text = PropertyDescription(7)
				Label9.Text = PropertyDescription(8)

				Label1.Visible = True
				Label2.Visible = True
				Label3.Visible = True
				Label4.Visible = True
				Label5.Visible = True
				Label6.Visible = True
				Label7.Visible = True
				Label8.Visible = True
				Label9.Visible = True

				Label1_Input.Visible = True
				Label2_Input.Visible = True
				Label3_Input.Visible = True
				Label4_Input.Visible = True
				Label5_Input.Visible = True
				Label6_Input.Visible = True
				Label7_Input.Visible = True
				Label8_Input.Visible = True
				Label9_Input.Visible = True

				Functions.Status = True
				Exit Sub

			End If

			'Z Angles
			If Functions.Calling_Fun = "10138" Or Functions.Calling_Fun = "10139" Or Functions.Calling_Fun = "Custom Z" Then
				Model_Image.Visible = True
				Model_Image.Image = My.Resources.Custom_Z_Angle
				Width = Width + Model_Image.Width
				Form_Resize()

				If Functions.Calling_Fun = "10138" Then

					swDoc = swApp.OpenDoc6("T:\Engineering\Non-Site Specific\PARTS\LIBRARY\ZEE ANGLES\EQUAL LIPS\AND10138 BASE ZEE #0401-2405.SLDPRT", 1, 0, "", fileerror, filewarning)
					swDoc = swApp.ActiveDoc
					config = swDoc.GetActiveConfiguration
					Open_Config = swDoc.ShowConfiguration2(Extrusion_Num)

				ElseIf Functions.Calling_Fun = "10139" Then

					swDoc = swApp.OpenDoc6("T:\Engineering\Non-Site Specific\PARTS\LIBRARY\ZEE ANGLES\UNEQUAL LIPS\AND10139 BASE ZEE #0401-3003.SLDPRT", 1, 0, "", fileerror, filewarning)
					swDoc = swApp.ActiveDoc
					config = swDoc.GetActiveConfiguration
					Open_Config = swDoc.ShowConfiguration2(Extrusion_Num)

				End If

				Label1.Text = PropertyDescription(0)
				Label2.Text = PropertyDescription(1)
				Label3.Text = PropertyDescription(2)
				Label4.Text = PropertyDescription(3)
				Label5.Text = PropertyDescription(4)
				Label6.Text = PropertyDescription(5)
				Label7.Text = PropertyDescription(6)
				Label8.Text = PropertyDescription(7)
				Label9.Text = PropertyDescription(8)

				Label1.Visible = True
				Label2.Visible = True
				Label3.Visible = True
				Label4.Visible = True
				Label5.Visible = True
				Label6.Visible = True
				Label7.Visible = True
				Label8.Visible = True
				Label9.Visible = True

				Label1_Input.Visible = True
				Label2_Input.Visible = True
				Label3_Input.Visible = True
				Label4_Input.Visible = True
				Label5_Input.Visible = True
				Label6_Input.Visible = True
				Label7_Input.Visible = True
				Label8_Input.Visible = True
				Label9_Input.Visible = True

				Functions.Status = True
				Exit Sub


			End If

		End If

	End Sub

	'Redundant functionality below as the inputs are text values
	'Private Sub Label1_Input_TextChanged(sender As Object, e As EventArgs) Handles Label1_Input.Validating
	'	If Label1_Input.Text <> "" Then
	'		Functions.Text_Validate(Label1_Input, "Integer", Me, "Fastener input")
	'	End If
	'End Sub

End Class