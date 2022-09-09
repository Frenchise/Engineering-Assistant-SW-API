Imports System.Math

Public Class Cross_Product

	Private Sub Form_Resize() Handles Me.ResizeEnd
		Functions.Form_resize(Me)
	End Sub

	Private Sub Cross_Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Form_Resize()
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim i As Decimal
        Dim j As Decimal
		Dim k As Decimal
		Dim Dis_i As Decimal
        Dim Dis_j As Decimal
        Dim Dis_k As Decimal
        Dim F_i As Decimal
        Dim F_j As Decimal
        Dim F_k As Decimal
        Dim Result As Decimal
        Dim Val_F_i As String = Nothing
        Dim Val_F_j As String = Nothing
        Dim Val_F_k As String = Nothing

        Dim Bool_F_i As Boolean
        Dim Bool_F_j As Boolean
		Dim Bool_F_k As Boolean
		Dim ER_Input As Boolean = False

        Dim ER_String() As String = {Nothing, Nothing, Nothing}
        Dim ER_Message As String = Nothing

        X_Result.Text = "X Result"
        Y_Result.Text = "Y Result"
        Z_Result.Text = "Z Result"
		Resultant.Text = "Resultant"

		If Distance_i.Text = "" Then
            Distance_i.Text = 0
        End If
		If Decimal.TryParse(Distance_i.Text, Dis_i) Then

		Else
			ER_String(0) = Distance_Vector.Text & " " & i_Vector.Text
            Dis_i = 0
            ER_Input = True

        End If

		If Distance_j.Text = "" Then
            Distance_j.Text = 0
        End If
		If Decimal.TryParse(Distance_j.Text, Dis_j) Then

		Else
			ER_String(1) = Distance_Vector.Text & " " & j_Vector.Text
            Dis_j = 0
            ER_Input = True

        End If

		If Distance_k.Text = "" Then
            Distance_k.Text = 0
        End If
		If Decimal.TryParse(Distance_k.Text, Dis_k) Then

		Else
			ER_String(2) = Distance_Vector.Text & " " & k_Vector.Text
            Dis_k = 0
            ER_Input = True

        End If

		If Force_i.Text = "" Then
			Force_i.Text = 0
		End If
		If Decimal.TryParse(Force_i.Text, F_i) Then

		Else
			F_i = 1
			Val_F_i = Force_i.Text
			Bool_F_i = True

		End If

		If Force_j.Text = "" Then
            Force_j.Text = 0
        End If
		If Decimal.TryParse(Force_j.Text, F_j) Then

		Else
			F_j = 1
			Val_F_j = Force_j.Text
			Bool_F_j = True

		End If

		If Force_k.Text = "" Then
            Force_k.Text = 0
        End If
		If Decimal.TryParse(Force_k.Text, F_k) Then

		Else
			F_k = 1
			Val_F_k = Force_k.Text
			Bool_F_k = True

		End If

		If ER_Input = False Then

            i = (Dis_j * F_k) - (Dis_k * F_j)

            j = -((Dis_i * F_k) - (Dis_k * F_i))

            k = (Dis_i * F_j) - (Dis_j * F_i)

			'This logic is messed up
			If Bool_F_i = True Or Bool_F_j = True Or Bool_F_k = True Then

				'If Bool_F_k = True Then
				If F_i = 1 And F_j = 1 And F_k = 1 Then

					X_Result.Text = "( " & Dis_j & Val_F_k & " )" & " - ( " & Dis_k & Val_F_j & " )"
					Y_Result.Text = "-(( " & Dis_i & Val_F_k & " )" & " - ( " & Dis_k & Val_F_i & " ))"
					Z_Result.Text = "( " & Dis_i & Val_F_j & " )" & " - ( " & Dis_j & Val_F_i & " )"

				ElseIf F_i = 1 And F_j = 1 Then

					X_Result.Text = "( " & (Dis_j * F_k) & " ) - ( " & Dis_k & Val_F_j & " )"
					Y_Result.Text = "-(( " & (Dis_i * F_k) & " ) - ( " & Dis_k & Val_F_i & " ))"
					Z_Result.Text = "( " & Dis_i & Val_F_j & " ) - ( " & Dis_j & Val_F_i & " )"

				ElseIf F_i = 1 And F_k = 1 Then

					X_Result.Text = "( " & Dis_j & Val_F_k & " ) - ( " & (Dis_k * F_j) & " )"
					Y_Result.Text = "-(( " & Dis_i & Val_F_k & " ) - ( " & Dis_k & Val_F_i & " ))"
					Z_Result.Text = "( " & (Dis_i * F_j) & " ) - ( " & Dis_j & Val_F_i & " )"

				ElseIf F_j = 1 And F_k = 1 Then

					X_Result.Text = "( " & Dis_j & Val_F_k & " ) - ( " & Dis_k & Val_F_j & " )"
					Y_Result.Text = "-(( " & Dis_i & Val_F_k & " ) - ( " & (Dis_k * F_i) & " ))"
					Z_Result.Text = "( " & Dis_i & Val_F_j & " ) - ( " & (Dis_j * F_i) & " )"

				ElseIf F_i = 1 Then

					X_Result.Text = (Dis_j * F_k) - (Dis_k * F_j)
					Y_Result.Text = "-(( " & (Dis_i * F_k) & " ) - ( " & Dis_k & Val_F_i & "))"
					Z_Result.Text = "( " & (Dis_j * F_k) & " ) - ( " & Dis_j & Val_F_i & ")"

				ElseIf F_j = 1 Then

					X_Result.Text = (Dis_j * F_k) & "- ( " & Dis_k & Val_F_j & ")"
					Y_Result.Text = -((Dis_i * F_k) - (Dis_k * F_i))
					Z_Result.Text = "(" & Dis_i & Val_F_j & " ) - ( " & (Dis_j * F_i) & " )"

				ElseIf F_k = 1 Then

					X_Result.Text = "( " & Dis_j & Val_F_k & " )" & " - ( " & Dis_k * F_j & " )"
					Y_Result.Text = "-(( " & Dis_i & Val_F_k & " ) - ( " & Dis_k * F_i & " ))"
					Z_Result.Text = (Dis_i * F_j) - (Dis_j * F_i)

				End If

			Else
				X_Result.Text = i & " " & Val_F_j
                Y_Result.Text = j & " " & Val_F_i
                Z_Result.Text = k & " " & Val_F_k

				'Cross_Product_Result.Text = Cross_Product_Result.Text & ": " & i & Val_F_j & "i " & j & Val_F_i & "j " & k & Val_F_k & "k"

				Result = Sqrt((i ^ 2) + (j ^ 2) + (k ^ 2))
                Result = System.Decimal.Round(Result, 3, MidpointRounding.AwayFromZero)
                Resultant.Text = Resultant.Text & ": " & Result
            End If

			X_Result.Text = "i : " & X_Result.Text
			Y_Result.Text = "j : " & Y_Result.Text
			Z_Result.Text = "k : " & Z_Result.Text

		Else

            If ER_String(0) IsNot Nothing Then
                ER_Message = ER_String(0) & " "
            End If
            If ER_String(1) IsNot Nothing Then
				ER_Message = ER_Message & ", " & ER_String(1)
			End If
            If ER_String(2) IsNot Nothing Then
				ER_Message = ER_Message & ", " & ER_String(2)
			End If

			Functions.Status = False
			Functions.Error_Form("Cross Product Error", "Following Inputs Are Not Numbers", , ER_Message,, False, Me)

		End If
		Functions.Status = True
	End Sub

	Private Sub Clear_Button_Click(sender As Object, e As EventArgs) Handles Clear_Button.Click
		Distance_i.Text = ""
		Distance_j.Text = ""
		Distance_k.Text = ""

		Force_i.Text = ""
		Force_j.Text = ""
		Force_k.Text = ""

	End Sub
End Class