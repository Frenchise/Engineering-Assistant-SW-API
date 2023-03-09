Public Class Radius_Finder

	Private Sub Form_Resize() Handles Me.ResizeEnd
		Functions.Form_resize(Me)
	End Sub

	Private Sub Radius_Finder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Form_Resize()
		Height_Radius_Input.Text = ""
		Width_Radius_Input.Text = ""
		Radius_Image_Box.Image = My.Resources.Radius_Finder
		Form_Resize()

	End Sub

	Private Sub Find_Radius_Click(sender As Object, e As EventArgs) Handles Find_Radius.Click
		Dim Radius_Height As Decimal
		Dim Radius_Width As Decimal
		Dim Radius As Decimal
		Dim Height_Check As Boolean = False
		Dim Width_Check As Boolean = False
		Radius_Output_Label.Text = "Radius"

		Try

			Radius_Height = Height_Radius_Input.Text
			Radius_Width = Width_Radius_Input.Text

			Radius = (Radius_Height / 2) + ((Radius_Width ^ 2) / (8 * Radius_Height))
			Radius = System.Decimal.Round(Radius, 3, MidpointRounding.AwayFromZero)
			If Radius > 0 Then
				Radius_Output_Label.Text = Radius_Output_Label.Text & ":   " & Radius.ToString
				Functions.Status = True
				'Me.Close()
			Else
				Functions.Error_Form("Error", "Something went wrong", , "Please try again",,, Me)
			End If

		Catch ex As InvalidCastException

			Functions.Error_Form("Null Value", "All inputs must be numerical",,,,, Me)

		End Try

	End Sub

	Private Sub Clear_Entries_Click(sender As Object, e As EventArgs) Handles Clear_Entries.Click
		Height_Radius_Input.Text = ""
		Width_Radius_Input.Text = ""
		Radius_Output_Label.Text = "Radius"
	End Sub

	Private Sub Height_Radius_Input_TextChanged(sender As Object, e As EventArgs) Handles Height_Radius_Input.Validating
		If Height_Radius_Input.Text <> "" Then
			Functions.Text_Validate(Height_Radius_Input, "Decimal", Me, "Height input")
		End If
	End Sub

	Private Sub Width_Radius_Input_TextChanged(sender As Object, e As EventArgs) Handles Width_Radius_Input.Validating
		If Width_Radius_Input.Text <> "" Then
			Functions.Text_Validate(Width_Radius_Input, "Decimal", Me, "Radius input")
		End If
	End Sub

End Class