Public Class Load_Analysis

	Dim Original_VD As String
	Dim Original_SA As String
	Dim Original_ForceD As String
	Dim Original_FN As String
	Dim Original_FastenerD As String

	Private Sub Form_Resize() Handles Me.ResizeEnd
		Functions.Form_resize(Me)
	End Sub

	Private Sub Load_Analysis_Load() Handles MyBase.Load
		Form_Resize()

		Dim LoadToolTip As New ToolTip()

		'LoadToolTip.ToolTipIcon = ToolTipIcon.Info
		LoadToolTip.IsBalloon = False
		LoadToolTip.ShowAlways = True

#Region "Antenna Fastener Tensine ToolTips"
		LoadToolTip.SetToolTip(Dive_Speed, "Usually VD or max speed an aircraft can achieve.")
		LoadToolTip.SetToolTip(SA_Antenna, "Surface Area of antenna, rounded up.")
		LoadToolTip.SetToolTip(Force_Distance, "Distance from CG or max antenna height to mounting face.")
		LoadToolTip.SetToolTip(Fasteners_Per_Side, "Total fasteners divided by 2.")
		LoadToolTip.SetToolTip(Fastener_Distance, "Fastener distance across the antenna blade.")
#End Region


#Region "Feed-Thru Fastener Number ToolTips"
		LoadToolTip.SetToolTip(Doubler_Tensile_Strength, "Doubler material tensile strenght")
		LoadToolTip.SetToolTip(Skin_Thickness, "Thickness of the existing skin/floor.")
		LoadToolTip.SetToolTip(Skin_Bearing, "Bearing strength of skin, many need to ask for this info.")
		LoadToolTip.SetToolTip(FeedThru_Diameter_Label, "Diameter of Feed-Thru hole.")
		LoadToolTip.SetToolTip(Fastener_Diameter_Label, "Diameter of fastener used.")
		LoadToolTip.SetToolTip(Fastener_Tension_Label, "Tension spec of fastener.")
#End Region

		Box_Forces_IMG.Visible = True
		Box_Forces_IMG.Image = My.Resources.Box_Resulting_Forces

		G1_Force.Visible = False
		G2_Force.Visible = False
		G3_Force.Visible = False
		Safety_Factor_Label.Visible = False


		If Vd_Aircraft_Input.Text = "" Then
		Else
			Vd_Aircraft_Input.Text = Original_VD
		End If

		If SA_Antenna_Input.Text = "" Then
		Else
			SA_Antenna_Input.Text = Original_SA
		End If

		If Force_Distance_Input.Text = "" Then
		Else
			Force_Distance_Input.Text = Original_ForceD
		End If

		If Antenna_Fastener_Num_Input.Text = "" Then
		Else
			Antenna_Fastener_Num_Input.Text = Original_FN
		End If

		If Fastener_Dist_Input.Text = "" Then
		Else
			Fastener_Dist_Input.Text = Original_FastenerD
		End If

	End Sub

	Private Sub Antenna_Forces_Button_Click(sender As Object, e As EventArgs) Handles Antenna_Forces_Button.Click
		Dim VD_Aircraft As Double
		Dim SA_Aircraft As Double
		Dim Fastener_num As Integer
		Dim Fastener_Dis As Decimal
		Dim Force_Dis As Decimal
		Dim Force As Decimal
		Side_Load_Force_Output.Text = "Fastener Force"

		Try

			VD_Aircraft = Vd_Aircraft_Input.Text
			SA_Aircraft = SA_Antenna_Input.Text
			Force_Dis = Force_Distance_Input.Text
			Fastener_num = Antenna_Fastener_Num_Input.Text
			Fastener_Dis = Fastener_Dist_Input.Text

			Force = SA_Aircraft * (0.00256 * (VD_Aircraft ^ 2)) * 1.2
			Force = System.Decimal.Round(Force, 2, MidpointRounding.AwayFromZero)

			Force = (Force * Force_Dis) / (Fastener_num * Fastener_Dis)
			Force = System.Decimal.Round(Force, 2, MidpointRounding.AwayFromZero)

			Side_Load_Force_Output.Text = Force.ToString() & " lbs"

		Catch ex As InvalidCastException

			Functions.Error_Form("Null Value", "All inputs must be numerical",,,,, Me)

		End Try

	End Sub

	Private Sub Feed_Thru_Button_Click(sender As Object, e As EventArgs) Handles Feed_Thru_Button.Click
		Dim Doubler_Tensile As Decimal
		Dim Skin_Mat_Thick As Decimal
		Dim Skin_Bear_Strength As Decimal
		Dim Hole_Diam As Decimal
		Dim Fastener_Diam As Decimal
		Dim Fastener_Tensile_Spec As Decimal
		Dim Bearing_Strength As Decimal
		Dim Fastener_Strength As Decimal
		Dim Force As Decimal
		Fast_Num_Output.Text = "Fastener Number"

		Try

			Doubler_Tensile = Doubler_Tensile_Input.Text
			Skin_Mat_Thick = Skin_Thick_Input.Text
			Skin_Bear_Strength = Skin_Bearing_Strength.Text
			Hole_Diam = Hole_Diameter_Input.Text
			Fastener_Diam = Fastener_Diameter.Text
			Fastener_Tensile_Spec = Fastener_Tension_Spec_Input.Text

			Bearing_Strength = Fastener_Diam * Skin_Mat_Thick * Skin_Bear_Strength
			If Bearing_Strength < Fastener_Tensile_Spec Then
				Fastener_Strength = Bearing_Strength
			Else
				Fastener_Strength = Fastener_Tensile_Spec
			End If

			Force = (Doubler_Tensile * Skin_Mat_Thick * Hole_Diam) / Fastener_Strength
			Force = Math.Ceiling(Force)

			Fast_Num_Output.BackColor = Color.LightGreen
			Fast_Num_Output.Text = Force.ToString() & " per side"

			'Load_Analysis_Load()
		Catch ex As InvalidCastException

			Functions.Error_Form("Null Value", "All inputs must be numerical",,,,, Me)

		End Try

	End Sub

	Private Sub Resultant_Forces_Button_Click(sender As Object, e As EventArgs) Handles Resultant_Forces_Button.Click

		Dim Fast_Num As Integer
		Dim Grav1 As Integer
		Dim Grav2 As Integer
		Dim Grav3 As Integer

		Dim Force1 As Decimal
		Dim Force2 As Decimal
		Dim Force3 As Decimal
		Dim Box_Weight As Decimal
		Dim Safety_Factor As Decimal = 1.2

		Dim Input_Error As Boolean = False

		Box_Weight = Functions.Input_Validate(Box_Weight_Input.Text, "Decimal")
		Fast_Num = Functions.Input_Validate(Box_Fastener_Num_Input.Text, "Integer")

		If Grav1_Load.SelectedIndex <> -1 Then
			Select Case Grav1_Load.SelectedItem.ToString
				Case "16G"
					Grav1 = 12
				Case "12G"
					Grav1 = 12
				Case "9G"
					Grav1 = 9
				Case "6G"
					Grav1 = 6
				Case "3G"
					Grav1 = 3
				Case Else
					Input_Error = True
			End Select
		Else
			Input_Error = True
		End If

		If Grav2_Load.SelectedIndex <> -1 Then
			Select Case Grav2_Load.SelectedItem.ToString
				Case "16G"
					Grav1 = 12
				Case "12G"
					Grav2 = 12
				Case "9G"
					Grav2 = 9
				Case "6G"
					Grav2 = 6
				Case "3G"
					Grav2 = 3
				Case Else
					Input_Error = True
			End Select
		Else
			Input_Error = True
		End If

		If Grav3_Load.SelectedIndex <> -1 Then
			Select Case Grav3_Load.SelectedItem.ToString
				Case "16G"
					Grav1 = 12
				Case "12G"
					Grav3 = 12
				Case "9G"
					Grav3 = 9
				Case "6G"
					Grav3 = 6
				Case "3G"
					Grav3 = 3
				Case Else
					Input_Error = True
			End Select
		Else
			Input_Error = True
		End If

		If Box_Weight = 0 Then

			Input_Error = True

		End If

		If Fast_Num = 0 Then

			Input_Error = True

		End If

		If Input_Error = False Then

			Force1 = (Box_Weight * Grav1 * Safety_Factor) / Fast_Num
			Force1 = System.Decimal.Round(Force1, 2, MidpointRounding.AwayFromZero)

			Force2 = (Box_Weight * Grav2 * Safety_Factor) / Fast_Num
			Force2 = System.Decimal.Round(Force2, 2, MidpointRounding.AwayFromZero)

			Force3 = (Box_Weight * Grav3 * Safety_Factor) / Fast_Num
			Force3 = System.Decimal.Round(Force3, 2, MidpointRounding.AwayFromZero)

			G1_Force.Visible = True
			G2_Force.Visible = True
			G3_Force.Visible = True
			Safety_Factor_Label.Visible = True

			Safety_Factor_Label.Text = "Safety Factor: " & Safety_Factor
			G1_Force.Text = Force1 & " lbs/Fastener"
			G2_Force.Text = Force2 & " lbs/Fastener"
			G3_Force.Text = Force3 & " lbs/Fastener"

			Functions.Status = True

		Else
			Functions.Error_Form("Input Error", "Enter values into all fields",,,,, Me)
			Functions.Status = False
		End If

	End Sub

#Region "Box Loads"
	Private Sub Box_Weight_Input_TextChanged(sender As Object, e As EventArgs) Handles Box_Weight_Input.Validating

		If Box_Weight_Input.Text <> "" Then
			Functions.Text_Validate(Box_Weight_Input, "Decimal", Me, "Box weight")
		End If

	End Sub

	Private Sub Box_Fastener_Num_Input_TextChanged(sender As Object, e As EventArgs) Handles Box_Fastener_Num_Input.Validating
		If Box_Fastener_Num_Input.Text <> "" Then
			Functions.Text_Validate(Box_Fastener_Num_Input, "Integer", Me, "Fastener input")
		End If

	End Sub

#End Region


#Region "Doubler Loads"
	Private Sub Doubler_Tensile_Input_TextChanged(sender As Object, e As EventArgs) Handles Doubler_Tensile_Input.Validating
		If Doubler_Tensile_Input.Text <> "" Then
			Functions.Text_Validate(Doubler_Tensile_Input, "Decimal", Me, "Doubler Tensile input")
		End If
	End Sub

	Private Sub Skin_Thick_Input_TextChanged(sender As Object, e As EventArgs) Handles Skin_Thick_Input.Validating
		If Skin_Thick_Input.Text <> "" Then
			Functions.Text_Validate(Skin_Thick_Input, "Decimal", Me, "Skin Thickness input")
		End If
	End Sub

	Private Sub Skin_Bearing_Strength_TextChanged(sender As Object, e As EventArgs) Handles Skin_Bearing_Strength.Validating
		If Skin_Bearing_Strength.Text <> "" Then
			Functions.Text_Validate(Skin_Bearing_Strength, "Decimal", Me, "Skin Bearing Strength input")
		End If
	End Sub

	Private Sub Hole_Diameter_Input_TextChanged(sender As Object, e As EventArgs) Handles Hole_Diameter_Input.Validating
		If Hole_Diameter_Input.Text <> "" Then
			Functions.Text_Validate(Hole_Diameter_Input, "Decimal", Me, "Hole Diameter input")
		End If
	End Sub

	Private Sub Fastener_Diameter_TextChanged(sender As Object, e As EventArgs) Handles Fastener_Diameter.Validating
		If Fastener_Diameter.Text <> "" Then
			Functions.Text_Validate(Fastener_Diameter, "Decimal", Me, "Fastener Diameter input")
		End If
	End Sub

	Private Sub Fastener_Tension_Spec_Input_TextChanged(sender As Object, e As EventArgs) Handles Fastener_Tension_Spec_Input.Validating
		If Fastener_Tension_Spec_Input.Text <> "" Then
			Functions.Text_Validate(Fastener_Tension_Spec_Input, "Decimal", Me, "Fastener Spec input")
		End If
	End Sub

	Private Sub Clear_Inputs_Click(sender As Object, e As EventArgs) Handles Clear_Inputs.Click
		For Each tb As Control In Feed_Thru_Group.Controls
			If tb.GetType Is GetType(TextBox) Then
				tb.Text = ""
				Fast_Num_Output.Text = "Fastener Number"
				Fast_Num_Output.BackColor = SystemColors.Window
			End If
		Next
	End Sub

#End Region


#Region "Antenna Loads"
	Private Sub Vd_Aircraft_Input_TextChanged(sender As Object, e As EventArgs) Handles Vd_Aircraft_Input.Validating
		If Vd_Aircraft_Input.Text <> "" Then
			Functions.Text_Validate(Vd_Aircraft_Input, "Double", Me, "Dive Speed input")
		End If
	End Sub

	Private Sub SA_Antenna_Input_TextChanged(sender As Object, e As EventArgs) Handles SA_Antenna_Input.Validating
		If SA_Antenna_Input.Text <> "" Then
			Functions.Text_Validate(SA_Antenna_Input, "Double", Me, "Antenna SA input")
		End If
	End Sub

	Private Sub Force_Distance_Input_TextChanged(sender As Object, e As EventArgs) Handles Force_Distance_Input.Validating
		If Force_Distance_Input.Text <> "" Then
			Functions.Text_Validate(Force_Distance_Input, "Decimal", Me, "Force Distance input")
		End If
	End Sub

	Private Sub Antenna_Fastener_Num_Input_TextChanged(sender As Object, e As EventArgs) Handles Antenna_Fastener_Num_Input.Validating
		If Antenna_Fastener_Num_Input.Text <> "" Then
			Functions.Text_Validate(Antenna_Fastener_Num_Input, "Integer", Me, "Fastener Num input")
		End If
	End Sub

	Private Sub Fastener_Dist_Input_TextChanged(sender As Object, e As EventArgs) Handles Fastener_Dist_Input.Validating
		If Fastener_Dist_Input.Text <> "" Then
			Functions.Text_Validate(Fastener_Dist_Input, "Decimal", Me, "Fastener Distance input")
		End If
	End Sub



#End Region


End Class