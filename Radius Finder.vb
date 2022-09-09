Public Class Radius_Finder

	Private Sub Form_Resize() Handles Me.ResizeEnd
		Functions.Form_resize(Me)
	End Sub

	Private Sub Radius_Finder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Form_Resize()
		Height_Radius_Input.Text = ""
		Width_Radius_Input.Text = ""
		Radius_Image_Box.Image = My.Resources.Radius_Finder
		'Me.Width = Radius_Image_Box.Width + Me.Width
		'Me.Height = Radius_Image_Box.Height + Me.Height
		Form_Resize()

	End Sub

	Private Sub Find_Radius_Click(sender As Object, e As EventArgs) Handles Find_Radius.Click
		Dim Radius_Height As Decimal
		Dim Radius_Width As Decimal
		Dim Radius As Decimal
		Dim Height_Check As Boolean = False
		Dim Width_Check As Boolean = False

		Radius_Output_Label.Text = "Radius"

		If Decimal.TryParse(Height_Radius_Input.Text, Radius_Height) Then
			Height_Check = True
		Else
			Functions.Error_Form("Input not valid", Height_Radius_Input.Text & " is not valid",,,,, Me)
		End If

		If Decimal.TryParse(Width_Radius_Input.Text, Radius_Width) Then
			Width_Check = True
		Else
			Functions.Error_Form("Input not valid", Width_Radius_Input.Text & " is not valid",,,,, Me)
		End If

		If Height_Check = True And Width_Check = True Then
			Radius = (Radius_Height / 2) + ((Radius_Width ^ 2) / (8 * Radius_Height))
			Radius = System.Decimal.Round(Radius, 3, MidpointRounding.AwayFromZero)
			If Radius > 0 Then
				Radius_Output_Label.Text = Radius_Output_Label.Text & ":   " & Radius.ToString
				Functions.Status = True
				'Me.Close()
			Else
				Functions.Error_Form("Error", "Something went wrong", , "Please try again",,, Me)
			End If
		End If

	End Sub

	Private Sub Clear_Entries_Click(sender As Object, e As EventArgs) Handles Clear_Entries.Click
		Height_Radius_Input.Text = ""
		Width_Radius_Input.Text = ""
		Radius_Output_Label.Text = "Radius"
	End Sub
End Class