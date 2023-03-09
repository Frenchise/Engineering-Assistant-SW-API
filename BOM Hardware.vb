Imports SwConst
Imports SwCommands
Imports SldWorks

Public Class BOM_Hardware

	Dim swApp As SldWorks.SldWorks
	Dim swDraw As DrawingDoc
	Dim SWSheet As Sheet
	Dim swDoc As ModelDoc2


	Structure Hardware
		Public Hardware_Type As String
		Public Quanity As String
		Public Hardware_Name As String
	End Structure

	Structure ASSY
		Public Assy_Description As String
		Public Assy_Name As String

		Public Sub New(s1 As String, s2 As String)
			Assy_Description = s1
			Assy_Name = s2

		End Sub

	End Structure

	Structure PART
		Public Part_Description As String
		Public Part_Name As String

		Public Sub New(s1 As String, s2 As String)
			Part_Description = s1
			Part_Name = s2

		End Sub
	End Structure

	Structure TB_visible_Checked
		Public Visible_Count As String
		Public Checked As Boolean
	End Structure

	Private Sub Form_Resize() Handles Me.ResizeEnd
		Functions.Form_resize(Me)
	End Sub

	Private Sub BOM_Hardware_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Form_Resize()

		For Each pn As Panel In Me.Controls.OfType(Of Panel)
			For Each PnV As Panel In pn.Controls.OfType(Of Panel)

				For Each cb As CheckBox In PnV.Controls.OfType(Of CheckBox)
					cb.Checked = False
				Next

				For Each tb As TextBox In PnV.Controls.OfType(Of TextBox)
					'cb.Checked = False
					tb.Visible = False
					tb.Text = ""

					For Each lb As Label In PnV.Controls.OfType(Of Label)
						If lb.Tag = "Amount" Then
							lb.Visible = False
						End If

					Next
				Next
			Next

			For Each cb As CheckBox In pn.Controls.OfType(Of CheckBox)
				cb.Checked = False
			Next

			For Each tb As TextBox In pn.Controls.OfType(Of TextBox)
				'cb.Checked = False
				tb.Visible = False
				tb.Text = ""

				For Each lb As Label In pn.Controls.OfType(Of Label)
					If lb.Tag = "Amount" Then
						lb.Visible = False
					End If

				Next
			Next
		Next

	End Sub

	'Hides Text Boxes in Panel One if not checked
	Private Sub MS35206_04_40_CheckedChanged(sender As Object, e As EventArgs) Handles MS35206_04_40.CheckedChanged

		If MS35206_04_40.Checked = True Then
			TextBox1.Visible = True
		Else
			TextBox1.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub MS35206_06_32_CheckedChanged(sender As Object, e As EventArgs) Handles MS35206_06_32.CheckedChanged

		If MS35206_06_32.Checked = True Then
			TextBox2.Visible = True
		Else
			TextBox2.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub MS27039_08_32_CheckedChanged(sender As Object, e As EventArgs) Handles MS27039_08_32.CheckedChanged

		If MS27039_08_32.Checked = True Then
			TextBox3.Visible = True
		Else
			TextBox3.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub MS27039_10_32_CheckedChanged(sender As Object, e As EventArgs) Handles MS27039_10_32.CheckedChanged

		If MS27039_10_32.Checked = True Then
			TextBox4.Visible = True
		Else
			TextBox4.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub MS27039_1_4_28_CheckedChanged(sender As Object, e As EventArgs) Handles MS27039_1_4_28.CheckedChanged

		If MS27039_1_4_28.Checked = True Then
			TextBox5.Visible = True
		Else
			TextBox5.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub MS24693_04_40_CheckedChanged(sender As Object, e As EventArgs) Handles MS24693_04_40.CheckedChanged

		If MS24693_04_40.Checked = True Then
			TextBox6.Visible = True
		Else
			TextBox6.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub MS24693_06_32_CheckedChanged(sender As Object, e As EventArgs) Handles MS24693_06_32.CheckedChanged

		If MS24693_06_32.Checked = True Then
			TextBox7.Visible = True
		Else
			TextBox7.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub MS24694_08_32_CheckedChanged(sender As Object, e As EventArgs) Handles MS24694_08_32.CheckedChanged

		If MS24694_08_32.Checked = True Then
			TextBox8.Visible = True
		Else
			TextBox8.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub MS24694_10_32_CheckedChanged(sender As Object, e As EventArgs) Handles MS24694_10_32.CheckedChanged

		If MS24694_10_32.Checked = True Then
			TextBox9.Visible = True

		Else
			TextBox9.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub MS24694_1_4_28_CheckedChanged(sender As Object, e As EventArgs) Handles MS24694_1_4_28.CheckedChanged

		If MS24694_1_4_28.Checked = True Then
			TextBox10.Visible = True
		Else
			TextBox10.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub NAS1149FN416P_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1149FN416P.CheckedChanged

		If NAS1149FN416P.Checked = True Then
			TextBox11.Visible = True
		Else
			TextBox11.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub NAS1149FN616P_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1149FN616P.CheckedChanged

		If NAS1149FN616P.Checked = True Then
			TextBox12.Visible = True
		Else
			TextBox12.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub NAS1149FN832P_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1149FN832P.CheckedChanged

		If NAS1149FN832P.Checked = True Then
			TextBox13.Visible = True
		Else
			TextBox13.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub NAS1149FO332P_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1149FO332P.CheckedChanged

		If NAS1149FO332P.Checked = True Then
			TextBox14.Visible = True
		Else
			TextBox14.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub NAS1149FO463P_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1149FO436P.CheckedChanged

		If NAS1149FO436P.Checked = True Then
			TextBox15.Visible = True
		Else
			TextBox15.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub NAS1169_6_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1169_6.CheckedChanged

		If NAS1169_6.Checked = True Then
			TextBox16.Visible = True
		Else
			TextBox16.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub NAS1169_8_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1169_8.CheckedChanged

		If NAS1169_8.Checked = True Then
			TextBox17.Visible = True
		Else
			TextBox17.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub NAS1169_10_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1169_10.CheckedChanged

		If NAS1169_10.Checked = True Then
			TextBox18.Visible = True
		Else
			TextBox18.Visible = False
		End If
		Label_Visible()

	End Sub

	Private Sub NAS1169_416_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1169_416.CheckedChanged

		If NAS1169_416.Checked = True Then
			TextBox19.Visible = True
		Else
			TextBox19.Visible = False
		End If
		Label_Visible()

	End Sub

	' Shows or hides the amount label for each panel

	Private Sub Label_Visible()

		If Panel1.Controls.OfType(Of CheckBox)().Any(Function(cb) cb.Checked) Then
			Amount_Label.Visible = True
		Else
			Amount_Label.Visible = False
		End If

		If Panel2.Controls.OfType(Of CheckBox)().Any(Function(cb) cb.Checked) Then
			Amount_Label2.Visible = True
		Else
			Amount_Label2.Visible = False
		End If

		If Panel3.Controls.OfType(Of CheckBox)().Any(Function(cb) cb.Checked) Then
			Amount_Label3.Visible = True
		Else
			Amount_Label3.Visible = False
		End If

		If Panel4.Controls.OfType(Of CheckBox)().Any(Function(cb) cb.Checked) Then
			Amount_Label4.Visible = True
		Else
			Amount_Label4.Visible = False
		End If

		If Panel5.Controls.OfType(Of CheckBox)().Any(Function(cb) cb.Checked) Then
			Amount_Label5.Visible = True
		Else
			Amount_Label5.Visible = False
		End If

		If Panel6.Controls.OfType(Of CheckBox)().Any(Function(cb) cb.Checked) Or Panel6_1.Controls.OfType(Of CheckBox)().Any(Function(cb) cb.Checked) Or Panel6_2.Controls.OfType(Of CheckBox)().Any(Function(cb) cb.Checked) Then
			Amount_Label6.Visible = True
		Else
			Amount_Label6.Visible = False
		End If

		If Panel7.Controls.OfType(Of CheckBox)().Any(Function(cb) cb.Checked) Then
			Amount_Label7.Visible = True
		Else
			Amount_Label7.Visible = False
		End If

		'If Panel6_1.Controls.OfType(Of CheckBox)().Any(Function(cb) cb.Checked) Then
		'    Amount_Label6.Visible = True
		'Else
		'    Amount_Label6.Visible = False
		'End If

		'If Panel6_2.Controls.OfType(Of CheckBox)().Any(Function(cb) cb.Checked) Then
		'    Amount_Label6.Visible = True
		'Else
		'    Amount_Label6.Visible = False
		'End If

	End Sub


	'
	'
	' Does all the magic Here
	'
	'
	'
	'


	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Add_BOM.Click

		Dim swModel As ModelDoc2
		Dim swDrawing As DrawingDoc
		Dim status As Boolean
		Dim swTableAnnotation As TableAnnotation
		Dim swGeneralTableFeature As GeneralTableFeature
		Dim swSelectionMgr As SelectionMgr
		Dim swModelDocExt As ModelDocExtension
		Dim swFeature As Feature
		Dim nbrTableAnnotations As Integer
		Dim tableAnnotations() As Object
		Dim i As Integer
		Dim j As Integer
		Dim Part_NO_column As Integer
		Dim Part_NO_Rows As Integer
		Dim File_Name_Part = String.Empty
		Dim Rows_max As Integer
		Dim Columns_max As Integer
		Dim z As Integer
		Dim First_EmptyRow As Integer
		Dim Next_File_Name_Part As String
		Dim Third_File_Name_Part As String
		Dim Second_Hit As Boolean
		Dim Hardware_amounts As Integer = 0
		Dim tb_Index As Integer = 0
		Dim tb_visible As Integer = 0
		Dim tb_count As Integer = 0
		Dim tb_checked As Boolean = False
		Dim Last_Count As Integer = 0
		Dim Add_More_Rows As Boolean = False
		Dim more_rows As Integer
		Dim ASSY_Add As Boolean = False
		Dim PART_Add As Boolean = False

		swModel = swApp.ActiveDoc
		swDrawing = swModel

		If swModel Is Nothing Then

			Functions.Error_Form("Error", "No document is loaded.",,,, False, Me)
			Functions.Status = False

		Else

			If swModel.GetType <> CInt(3) Then

				Functions.Error_Form("Error", "This is not a drawing file",,,, False, Me)
				Functions.Status = False

			Else

				swModelDocExt = swModel.Extension
				z = 1

				While status = False   'traverses through drawing for general table feature 
					If Not status = swModelDocExt.SelectByID2("PART LIST TABLE", "GENERALTABLEFEAT", 0, 0, 0, False, 0, Nothing, 0) Then
						Exit While
					End If

					'As SW doesn't recycle feature number this adds instances to table features
					status = swModelDocExt.SelectByID2("General Table" & z, "GENERALTABLEFEAT", 0, 0, 0, False, 0, Nothing, 0)

					If status = True Then
						swSelectionMgr = swModel.SelectionManager
						swGeneralTableFeature = swSelectionMgr.GetSelectedObject6(1, -1)
						nbrTableAnnotations = swGeneralTableFeature.GetTableAnnotationCount
						tableAnnotations = swGeneralTableFeature.GetTableAnnotations
						swTableAnnotation = tableAnnotations(0)
						Columns_max = swTableAnnotation.ColumnCount()
						If Columns_max > 4 Then
							Exit While
						End If
						swModel.ClearSelection2(True)
						status = False
					End If



					'If Not status = swModelDocExt.SelectByID2("Bill of Materials", "BOM", 0, 0, 0, False, 0, Nothing, 0) Then
					'Exit While
					'End If
					'status = swModelDocExt.SelectByID2("Bill of Materials" & z, "BOM", 0, 0, 0, False, 0, Nothing, 0)

					z += 1 'Number of attempts to traverse drawing for table feature names
					If z = 10 Then
						MsgBox("Verify there is a Part List General Table")
						Me.Close()
						Exit Sub

						Exit While
					End If
				End While

				swSelectionMgr = swModel.SelectionManager
				swGeneralTableFeature = swSelectionMgr.GetSelectedObject6(1, -1)
				swFeature = swGeneralTableFeature.GetFeature
				swFeature.Name = "PART LIST TABLE" 'Renames Table feature for future instances
				nbrTableAnnotations = swGeneralTableFeature.GetTableAnnotationCount
				tableAnnotations = swGeneralTableFeature.GetTableAnnotations
				swTableAnnotation = tableAnnotations(0)
				Rows_max = swTableAnnotation.RowCount()
				Columns_max = swTableAnnotation.ColumnCount()

				'swTableAnnotation.InsertRow.
				Second_Hit = False
				j = 1

				'Max row is at the bottom and we walk up the BOM
				For i = Rows_max - 1 To 0 Step -1 '(nbrTableAnnotations - 1)  

					Part_NO_Rows = i 'Rows_max - j 'integar start at rowcount -1 and move up to number of assemblies a space and number of parts
					Part_NO_column = Columns_max - 4 'integar starts at right side of table while Columns_max -4 moves to the left 3 to get into the part no. column
					j = j + 1
					File_Name_Part = swTableAnnotation.Text2(Part_NO_Rows, Part_NO_column, 0)
					Next_File_Name_Part = swTableAnnotation.Text2(Part_NO_Rows - 1, Part_NO_column, 0)
					Third_File_Name_Part = swTableAnnotation.Text2(Part_NO_Rows - 2, Part_NO_column, 0)

					If File_Name_Part = "" Then

						If Next_File_Name_Part = "" And Second_Hit = False Then

							If Third_File_Name_Part = "" Then
								Second_Hit = True
								First_EmptyRow = Part_NO_Rows - 1
								If First_EmptyRow = -1 Then
									First_EmptyRow = 0
								End If

							End If


						End If
						'Else
						'	First_EmptyRow = -1
					End If
				Next

				'Builds Array Size for Fasteners and gets checkbox text
				For Each pn As Panel In Me.Controls.OfType(Of Panel)

					For Each PnV As Panel In pn.Controls.OfType(Of Panel)
						For Each cb As CheckBox In PnV.Controls.OfType(Of CheckBox)
							If cb.Checked Then
								Hardware_amounts += 1
							End If
						Next
					Next

					For Each cb As CheckBox In pn.Controls.OfType(Of CheckBox)
						If cb.Checked Then
							Hardware_amounts += 1
						End If
					Next

				Next

				Dim count As Integer = Hardware_amounts - 1
				Dim H(count) As Hardware

				Hardware_amounts = 0

				For Each pn As Panel In Me.Controls.OfType(Of Panel).OrderBy(Function(x) x.Name)

					For Each cb As CheckBox In pn.Controls.OfType(Of CheckBox).OrderBy(Function(x) x.Bottom)
						If cb.Checked = True Then

							Hardware_amounts += 1
							count = Hardware_amounts - 1

							For Each tb As TextBox In pn.Controls.OfType(Of TextBox).OrderBy(Function(x) x.Bottom)

								If tb.Visible = True Then

									H(count).Hardware_Type = pn.Tag
									H(count).Hardware_Name = cb.Text
									If tb.Tag = cb.Name Then
										H(count).Quanity = tb.Text
									End If
								End If
							Next
						End If
					Next

					For Each PnV As Panel In pn.Controls.OfType(Of Panel).OrderBy(Function(x) x.Top)

						For Each cb As CheckBox In PnV.Controls.OfType(Of CheckBox).OrderBy(Function(x) x.Bottom)
							If cb.Checked = True Then

								Hardware_amounts += 1
								count = Hardware_amounts - 1

								For Each tb As TextBox In PnV.Controls.OfType(Of TextBox).OrderBy(Function(x) x.Bottom)

									If tb.Visible = True Then

										H(count).Hardware_Type = PnV.Tag
										H(count).Hardware_Name = cb.Text
										If tb.Tag = cb.Name Then
											H(count).Quanity = tb.Text
										End If
									End If
								Next
							End If
						Next

					Next

				Next
				'Dim swParts As New List(Of PART)()
				'Dim swAssys As New List(Of ASSY)()

				'Dim swComp As Component2
				'Dim swConfMgr As ConfigurationManager
				'Dim swConf As Configuration

				'swConfMgr = swDoc.ConfigurationManager
				'swConf = swConfMgr.ActiveConfiguration
				'swComp = swConf.GetRootComponent3(True)

				'SWFunctions.Add_Docs(swComp, 1)


				'For z = 0 To SWFunctions.swAssy_Docs.Count - 1
				'	If SWFunctions.swAssy_Docs(z).Part_Number <> "" Or SWFunctions.swAssy_Docs(z).Part_Number <> "-XX" Then
				'		count += 1
				'		ASSY_Add = True
				'		swAssys.Add(New ASSY(SWFunctions.swAssy_Docs(z).Description, SWFunctions.swAssy_Docs(z).Name))
				'		Debug.Print(SWFunctions.swAssy_Docs(z).Name & " ---- " & SWFunctions.swAssy_Docs(z).Description)
				'	End If
				'Next

				'For x = 0 To SWFunctions.swPart_Docs.Count - 1
				'	If SWFunctions.swPart_Docs(z).Part_Number <> "" Or SWFunctions.swAssy_Docs(z).Part_Number <> "-XX" Then
				'		count += 1
				'		PART_Add = True
				'		swParts.Add(New PART(SWFunctions.swPart_Docs(z).Description, SWFunctions.swPart_Docs(z).Name))
				'		Debug.Print(SWFunctions.swPart_Docs(z).Name & " ---- " & SWFunctions.swPart_Docs(z).Description)

				'	End If
				'Next


				'Inserts data into Array of Struct type.

				If First_EmptyRow < count Then

					If First_EmptyRow = 0 Then
						more_rows = Hardware_amounts + 1
						'First_EmptyRow += 1
					Else
						more_rows = Hardware_amounts - First_EmptyRow ' - 1
						'First_EmptyRow = 0
					End If
					'Functions.Error_Form("Not Enough Rows", "Adding " & more_rows & " more rows to top of BOM",,,,, Me)
					'MsgBox("Adding " & more_rows & " more rows to top of parts list table")
					Add_More_Rows = True
				End If

				Dim l As Integer = 0

				For k = First_EmptyRow To 0 Step -1 'Rows_max  'ideally needs to be array size of hardware instead of Rows_max

					If Add_More_Rows = True Then
						For m = 1 To more_rows
							swTableAnnotation.InsertRow(1, 0)
						Next
						If File_Name_Part <> "" Then
							swTableAnnotation.InsertRow(1, 0)
						End If

						Add_More_Rows = False
						First_EmptyRow += more_rows - 1
						k = First_EmptyRow
					End If

					'If ASSY_Add = True Then
					'	swTableAnnotation.Text(First_EmptyRow - l, Columns_max - 4) = swAssys(l).Assy_Name
					'	swTableAnnotation.Text(First_EmptyRow - l, Columns_max - 3) = swAssys(l).Assy_Description
					'End If

					'If ASSY_Add = True Then
					'	swTableAnnotation.Text(First_EmptyRow - l, Columns_max - 4) = swParts(l).Part_Name
					'	swTableAnnotation.Text(First_EmptyRow - l, Columns_max - 3) = swParts(l).Part_Description
					'End If

					If l < Hardware_amounts Then
						swTableAnnotation.Text(First_EmptyRow - l, Columns_max - 4) = H(l).Hardware_Name
						swTableAnnotation.Text(First_EmptyRow - l, Columns_max - 3) = H(l).Hardware_Type
						swTableAnnotation.Text(First_EmptyRow - l, Columns_max - 5) = H(l).Quanity
						l += 1
					Else

						Exit For
					End If
				Next

				If First_EmptyRow < count Then
					'Dim more_rows As Integer
					If First_EmptyRow = 0 Then
						more_rows = Hardware_amounts + 1
					Else
						more_rows = Hardware_amounts - First_EmptyRow - 1
					End If

					'MsgBox("add " & more_rows & " more rows to top of parts list table")
				Else
					Me.Close()
					Functions.Status = True
				End If

			End If
		End If

	End Sub

	'
	'
	' Does all the magic Here
	'
	'
	'
	'

	Private Sub NAS1832_06_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1832_06.CheckedChanged
		If NAS1832_06.Checked = True Then
			TextBox20.Visible = True
		Else
			TextBox20.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1832_08_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1832_08.CheckedChanged
		If NAS1832_08.Checked = True Then
			TextBox21.Visible = True
		Else
			TextBox21.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1832_3_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1832_3.CheckedChanged
		If NAS1832_3.Checked = True Then
			TextBox22.Visible = True
		Else
			TextBox22.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1832_4_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1832_4.CheckedChanged
		If NAS1832_4.Checked = True Then
			TextBox23.Visible = True
		Else
			TextBox23.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1833_06_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1833_06.CheckedChanged
		If NAS1833_06.Checked = True Then
			TextBox24.Visible = True
		Else
			TextBox24.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1833_08_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1833_08.CheckedChanged
		If NAS1833_08.Checked = True Then
			TextBox25.Visible = True
		Else
			TextBox25.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1833_3_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1833_3.CheckedChanged
		If NAS1833_3.Checked = True Then
			TextBox26.Visible = True
		Else
			TextBox26.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1833_4_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1833_4.CheckedChanged
		If NAS1833_4.Checked = True Then
			TextBox27.Visible = True
		Else
			TextBox27.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1834_06_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1834_06.CheckedChanged
		If NAS1834_06.Checked = True Then
			TextBox28.Visible = True
		Else
			TextBox28.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1834_08_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1834_08.CheckedChanged
		If NAS1834_08.Checked = True Then
			TextBox29.Visible = True
		Else
			TextBox29.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1834_3_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1834_3.CheckedChanged
		If NAS1834_3.Checked = True Then
			TextBox30.Visible = True
		Else
			TextBox30.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1834_4_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1834_4.CheckedChanged
		If NAS1834_4.Checked = True Then
			TextBox31.Visible = True
		Else
			TextBox31.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1834K_06_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1834K_06.CheckedChanged
		If NAS1834K_06.Checked = True Then
			TextBox32.Visible = True
		Else
			TextBox32.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1834K_08_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1834K_08.CheckedChanged
		If NAS1834K_08.Checked = True Then
			TextBox33.Visible = True
		Else
			TextBox33.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1834K_3_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1834K_3.CheckedChanged
		If NAS1834K_3.Checked = True Then
			TextBox34.Visible = True
		Else
			TextBox34.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1834K_4_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1834K_4.CheckedChanged
		If NAS1834K_4.Checked = True Then
			TextBox35.Visible = True
		Else
			TextBox35.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1835_08_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1835_08.CheckedChanged
		If NAS1835_08.Checked = True Then
			TextBox36.Visible = True
		Else
			TextBox36.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1835_3_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1835_3.CheckedChanged
		If NAS1835_3.Checked = True Then
			TextBox37.Visible = True
		Else
			TextBox37.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1835_4_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1835_4.CheckedChanged
		If NAS1835_4.Checked = True Then
			TextBox38.Visible = True
		Else
			TextBox38.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1836_06_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1836_06.CheckedChanged
		If NAS1836_06.Checked = True Then
			TextBox39.Visible = True
		Else
			TextBox39.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1836_08_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1836_08.CheckedChanged
		If NAS1836_08.Checked = True Then
			TextBox40.Visible = True
		Else
			TextBox40.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1836_3_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1836_3.CheckedChanged
		If NAS1836_3.Checked = True Then
			TextBox41.Visible = True
		Else
			TextBox41.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub NAS1836_4_CheckedChanged(sender As Object, e As EventArgs) Handles NAS1836_4.CheckedChanged
		If NAS1836_4.Checked = True Then
			TextBox42.Visible = True
		Else
			TextBox42.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21059L04_CheckedChanged(sender As Object, e As EventArgs) Handles MS21059L04.CheckedChanged
		If MS21059L04.Checked = True Then
			TextBox43.Visible = True
		Else
			TextBox43.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21059L06_CheckedChanged(sender As Object, e As EventArgs) Handles MS21059L06.CheckedChanged
		If MS21059L06.Checked = True Then
			TextBox44.Visible = True
		Else
			TextBox44.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21059L08_CheckedChanged(sender As Object, e As EventArgs) Handles MS21059L08.CheckedChanged
		If MS21059L08.Checked = True Then
			TextBox45.Visible = True
		Else
			TextBox45.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21059L3_CheckedChanged(sender As Object, e As EventArgs) Handles MS21059L3.CheckedChanged
		If MS21059L3.Checked = True Then
			TextBox46.Visible = True
		Else
			TextBox46.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21059L4_CheckedChanged(sender As Object, e As EventArgs) Handles MS21059L4.CheckedChanged
		If MS21059L4.Checked = True Then
			TextBox47.Visible = True
		Else
			TextBox47.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21075L04_CheckedChanged(sender As Object, e As EventArgs) Handles MS21075L04.CheckedChanged
		If MS21075L04.Checked = True Then
			TextBox48.Visible = True
		Else
			TextBox48.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21075L06_CheckedChanged(sender As Object, e As EventArgs) Handles MS21075L06.CheckedChanged
		If MS21075L06.Checked = True Then
			TextBox49.Visible = True
		Else
			TextBox49.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21075L08_CheckedChanged(sender As Object, e As EventArgs) Handles MS21075L08.CheckedChanged
		If MS21075L08.Checked = True Then
			TextBox50.Visible = True
		Else
			TextBox50.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21075L3_CheckedChanged(sender As Object, e As EventArgs) Handles MS21075L3.CheckedChanged
		If MS21075L3.Checked = True Then
			TextBox51.Visible = True
		Else
			TextBox51.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21075L4_CheckedChanged(sender As Object, e As EventArgs) Handles MS21075L4.CheckedChanged
		If MS21075L4.Checked = True Then
			TextBox52.Visible = True
		Else
			TextBox52.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21061L04_CheckedChanged(sender As Object, e As EventArgs) Handles MS21061L04.CheckedChanged
		If MS21061L04.Checked = True Then
			TextBox53.Visible = True
		Else
			TextBox53.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21061L06_CheckedChanged(sender As Object, e As EventArgs) Handles MS21061L06.CheckedChanged
		If MS21061L06.Checked = True Then
			TextBox54.Visible = True
		Else
			TextBox54.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21061L08_CheckedChanged(sender As Object, e As EventArgs) Handles MS21061L08.CheckedChanged
		If MS21061L08.Checked = True Then
			TextBox55.Visible = True
		Else
			TextBox55.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21061L3_CheckedChanged(sender As Object, e As EventArgs) Handles MS21061L3.CheckedChanged
		If MS21061L3.Checked = True Then
			TextBox56.Visible = True
		Else
			TextBox56.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21061L4_CheckedChanged(sender As Object, e As EventArgs) Handles MS21061L4.CheckedChanged
		If MS21061L4.Checked = True Then
			TextBox57.Visible = True
		Else
			TextBox57.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21047L04_CheckedChanged(sender As Object, e As EventArgs) Handles MS21047L04.CheckedChanged
		If MS21047L04.Checked = True Then
			TextBox58.Visible = True
		Else
			TextBox58.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21047L06_CheckedChanged(sender As Object, e As EventArgs) Handles MS21047L06.CheckedChanged
		If MS21047L06.Checked = True Then
			TextBox59.Visible = True
		Else
			TextBox59.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21047L08_CheckedChanged(sender As Object, e As EventArgs) Handles MS21047L08.CheckedChanged
		If MS21047L08.Checked = True Then
			TextBox60.Visible = True
		Else
			TextBox60.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21047L3_CheckedChanged(sender As Object, e As EventArgs) Handles MS21047L3.CheckedChanged
		If MS21047L3.Checked = True Then
			TextBox61.Visible = True
		Else
			TextBox61.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21047L4_CheckedChanged(sender As Object, e As EventArgs) Handles MS21047L4.CheckedChanged
		If MS21047L4.Checked = True Then
			TextBox62.Visible = True
		Else
			TextBox62.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21071L04_CheckedChanged(sender As Object, e As EventArgs) Handles MS21071L04.CheckedChanged
		If MS21071L04.Checked = True Then
			TextBox63.Visible = True
		Else
			TextBox63.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21071L06_CheckedChanged(sender As Object, e As EventArgs) Handles MS21071L06.CheckedChanged
		If MS21071L06.Checked = True Then
			TextBox64.Visible = True
		Else
			TextBox64.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21071L08_CheckedChanged(sender As Object, e As EventArgs) Handles MS21071L08.CheckedChanged
		If MS21071L08.Checked = True Then
			TextBox65.Visible = True
		Else
			TextBox65.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21071L3_CheckedChanged(sender As Object, e As EventArgs) Handles MS21071L3.CheckedChanged
		If MS21071L3.Checked = True Then
			TextBox66.Visible = True
		Else
			TextBox66.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS21071L4_CheckedChanged(sender As Object, e As EventArgs) Handles MS21071L4.CheckedChanged
		If MS21071L4.Checked = True Then
			TextBox67.Visible = True
		Else
			TextBox67.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS20470AD2_CheckedChanged(sender As Object, e As EventArgs) Handles MS20470AD2.CheckedChanged
		If MS20470AD2.Checked = True Then
			TextBox68.Visible = True
		Else
			TextBox68.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS20470AD3_CheckedChanged(sender As Object, e As EventArgs) Handles MS20470AD3.CheckedChanged
		If MS20470AD3.Checked = True Then
			TextBox69.Visible = True
		Else
			TextBox69.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS20470AD4_CheckedChanged(sender As Object, e As EventArgs) Handles MS20470AD4.CheckedChanged
		If MS20470AD4.Checked = True Then
			TextBox70.Visible = True
		Else
			TextBox70.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS20470AD5_CheckedChanged(sender As Object, e As EventArgs) Handles MS20470AD5.CheckedChanged
		If MS20470AD5.Checked = True Then
			TextBox71.Visible = True
		Else
			TextBox71.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MS20470AD6_CheckedChanged(sender As Object, e As EventArgs) Handles MS20470AD6.CheckedChanged
		If MS20470AD6.Checked = True Then
			TextBox72.Visible = True
		Else
			TextBox72.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub ATR_525_A_B_CheckedChanged(sender As Object, e As EventArgs) Handles ATR_525_A_B.CheckedChanged
		If ATR_525_A_B.Checked = True Then
			TextBox73.Visible = True
			Amount_Label6.Visible = True
		Else
			TextBox73.Visible = False
			Amount_Label6.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub EA934_CheckedChanged(sender As Object, e As EventArgs) Handles EA934.CheckedChanged
		If EA934.Checked = True Then
			TextBox74.Visible = True
		Else
			TextBox74.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub PR_1440_CheckedChanged(sender As Object, e As EventArgs) Handles PR_1440.CheckedChanged
		If PR_1440.Checked = True Then
			TextBox76.Visible = True
		Else
			TextBox76.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub MAG_85_3_A_B_CheckedChanged(sender As Object, e As EventArgs) Handles MAG_85_3_A_B.CheckedChanged
		If MAG_85_3_A_B.Checked = True Then
			TextBox77.Visible = True
		Else
			TextBox77.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub ATR_1000_CheckedChanged(sender As Object, e As EventArgs) Handles ATR_1000.CheckedChanged
		If ATR_1000.Checked = True Then
			TextBox78.Visible = True
		Else
			TextBox78.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs)
		Dim i As Integer = 0
		For Each pn As Panel In Me.Controls.OfType(Of Panel)

			For Each cb As CheckBox In pn.Controls.OfType(Of CheckBox)
				cb.Checked = True

				For Each tb As TextBox In pn.Controls.OfType(Of TextBox)
					'tb.Visible = False
					tb.Text = i

				Next
				i += 1
			Next
		Next

	End Sub

	Private Sub PR_1422_1_2B_CheckedChanged(sender As Object, e As EventArgs) Handles PR_1422_1_2B.CheckedChanged
		If PR_1422_1_2B.Checked = True Then
			TextBox75.Visible = True
		Else
			TextBox75.Visible = False
		End If
		Label_Visible()
	End Sub

	Private Sub CTB8_CheckedChanged(sender As Object, e As EventArgs) Handles CTB8.CheckedChanged
		If CTB8.Checked = True Then
			TextBox79.Visible = True
		Else
			TextBox79.Visible = False
		End If
		Label_Visible()
	End Sub

End Class