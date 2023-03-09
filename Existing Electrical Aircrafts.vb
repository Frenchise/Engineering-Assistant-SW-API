Imports System.IO
Imports System.Runtime.InteropServices

Public Class Existing_Electrical_Aircrafts


	Dim Nat_Folder As String
    Dim PDF_dir As String
    Dim PDF_Analysis As String
    Dim dir_Manufacturer As String
    Dim dir_Aircraft As String
    Dim Aircraft_Serial As String
	Dim Electrical_PDF As String

	Dim PDF_Selected As Boolean = False
	Dim Item_Count As Integer
	Dim Air As Airplane

	Dim First_Space As String
	Dim Second_Space As String
	Dim Third_Space As String

	Dim Radio_Sort_Method As String = "Chrono"
	Dim OG_LIST As New List(Of String)

	Structure Airplane
		Public Manufacturer As String
		Public Type As String
		Public Serial As String
		Public Struct_Drawing As String
		Public Struct_Drawing_Name As String
		Public Elect_Drawing As String
		Public struct_FileName As String
	End Structure

	Private Sub Form_Resize() Handles Me.ResizeEnd ' Me.Activated,
		Functions.Form_resize(Me)
	End Sub

	Private Sub Aircraft_Frames_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Open_Native_Folder.Visible = False
		Open_PDF.Visible = False
		Chrono_Sort.Visible = False
		DWG_Sort.Visible = False
		Search_PDF_Names_Input.Visible = False
		PDF_Names_Label.Visible = False
		Form_Resize()

		AddHandler Chrono_Sort.CheckedChanged, New EventHandler(AddressOf Sort_CheckedChanged)
		'AddHandler DWG_Sort.CheckedChanged, New EventHandler(AddressOf Sort_CheckedChanged)
		AddHandler DWG_Num_Options.SelectedIndexChanged, New EventHandler(AddressOf Sort_CheckedChanged)


		Aircraft_Type_Label.Visible = False
		Aircraft_Type.Visible = False
		Existing_Electrical_PDFs.Visible = False
		Opt_DWG_NUM.Visible = False
		DWG_Num_Options.Visible = False

		If Directory.Exists(Network_Locations.Aircraft_Data_Dir) Then

			Directory_Exist.Text = "Aircraft Data Directory Exists"


			Aircraft_Type.Items.Clear()
			Aircraft_Type.Text = ""

			Dim folder = String.Empty
			Dim Folder_name = String.Empty

			For Each folder In System.IO.Directory.GetDirectories(Network_Locations.Aircraft_Data_Dir)

				Folder_name = System.IO.Path.GetFileNameWithoutExtension(folder)

				Manufacturer.Items.Add(Folder_name)

			Next

		Else

			Functions.Error_Form(, "Aircraft Data Directory Does not Exist",,,, False, Me)

			Directory_Exist.Text = "Aircraft Data Directory Does not Exist"

		End If

	End Sub

	Private Sub Manufacturer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Manufacturer.SelectedIndexChanged

		Open_Native_Folder.Visible = False
		Open_PDF.Visible = False
		Aircraft_Type_Label.Visible = True
		Aircraft_Type.Visible = True
		Existing_Electrical_PDFs.Visible = False
		PDF_Amount.Visible = False
		PDF_Selected = False

		Aircraft_Type.Items.Clear()
		Aircraft_Type.Text = ""

		Air.Manufacturer = Manufacturer.Text

		dir_Manufacturer = Network_Locations.Aircraft_Data_Dir + "\" + Manufacturer.Text

		If Directory.Exists(dir_Manufacturer) Then

			Dim folder = String.Empty
			Dim Folder_name = String.Empty

			For Each folder In System.IO.Directory.GetDirectories(dir_Manufacturer)

				Folder_name = System.IO.Path.GetFileNameWithoutExtension(folder)
				Aircraft_Type.Items.Add(Folder_name)

			Next

		End If

	End Sub

	Private Sub Aircraft_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Aircraft_Type.SelectedIndexChanged

		Existing_Electrical_PDFs.Visible = True
		PDF_Amount.Visible = True
		PDF_Amount.Text = ""
		PDF_Selected = False

		Opt_DWG_NUM.Visible = True
		DWG_Num_Options.SelectedIndex = 0
		DWG_Num_Options.Visible = True

		OG_LIST.Clear()
		Existing_Electrical_PDFs.Items.Clear()
		Existing_Electrical_PDFs.Text = ""

		Air.Type = Aircraft_Type.Text

		dir_Aircraft = dir_Manufacturer + "\" + Aircraft_Type.Text

		If Directory.Exists(dir_Aircraft) Then

			Dim file = String.Empty
			Dim File_name = String.Empty
			Dim Folder_name = String.Empty
			Dim Folder = String.Empty
			Dim Electrical_Folder = String.Empty
			Dim Contour_Folder = String.Empty

			For Each Folder In System.IO.Directory.GetDirectories(dir_Aircraft)


				For Each Electrical_Folder In System.IO.Directory.GetDirectories(Folder, "ELECTRICAL") 'Some folders are named ElectricalS

					Folder_name = System.IO.Path.GetFileNameWithoutExtension(Folder)

					For Each file In System.IO.Directory.GetFiles(Electrical_Folder, "*.pdf")

						File_name = System.IO.Path.GetFileNameWithoutExtension(file)
						Existing_Electrical_PDFs.Items.Add(File_name & " - " & Folder_name)
						Item_Count = Existing_Electrical_PDFs.Items.Count

					Next

				Next
#Region "Use if more than one ELECTRICAL folder naming style"
				'For Each Electrical_Folder In System.IO.Directory.GetDirectories(Folder, "Electrical") 'Some folders are named Electrical

				'	Folder_name = System.IO.Path.GetFileNameWithoutExtension(Folder)

				'	For Each file In System.IO.Directory.GetFiles(Electrical_Folder, "*.pdf")

				'		File_name = System.IO.Path.GetFileNameWithoutExtension(file)
				'		Existing_Electrical_PDFs.Items.Add(File_name & " - " & Folder_name)
				'		Item_Count = Existing_Electrical_PDFs.Items.Count

				'	Next

				'Next
#End Region

			Next

			If Folder = "" Then
				'For Each Contour_Folder In System.IO.Directory.GetDirectories(Folder, "ElectricalS")

				Folder_name = System.IO.Path.GetFileNameWithoutExtension(dir_Aircraft)

				For Each file In System.IO.Directory.GetFiles(dir_Aircraft, "*.pdf")

					File_name = System.IO.Path.GetFileNameWithoutExtension(file)
					Existing_Electrical_PDFs.Items.Add(File_name & " - " & Folder_name)
					Item_Count = Existing_Electrical_PDFs.Items.Count

				Next
				'Next
			End If

			For Each LI In Existing_Electrical_PDFs.Items
				OG_LIST.Add(LI.ToString())
			Next
			Functions.SortListBox(Existing_Electrical_PDFs, OG_LIST)
			'Functions.SortListBox(Existing_Electrical_PDFs)




			If Item_Count = 0 Then
				Directory_Exist.Text = "No Electrical PDFs to Display"
				Existing_Electrical_PDFs.Items.Add("No Electrical PDFs to Display")
			End If

			PDF_Amount.Text = "Number of PDFs - " & Item_Count.ToString()

			Chrono_Sort.Visible = True
			DWG_Sort.Visible = True
			Search_PDF_Names_Input.Visible = True
			PDF_Names_Label.Visible = True

		End If

	End Sub

	Private Sub Existing_Electrical_PDFs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Existing_Electrical_PDFs.SelectedIndexChanged

		Open_Native_Folder.Visible = False
		Open_PDF.Visible = False

		Dim File_name As String
		Dim CharsToTrim As Char() = {"(", ")"}
		Dim CharBool As Boolean = False

		If Item_Count = 0 Then

			PDF_Selected = False
		Else

			Dim Team As String = Existing_Electrical_PDFs.Text

			'Dim PDF_Text As String = Team

			'CharBool = Functions.CheckforAlphaChar(Team)
			'If CharBool = True Then
			'	MsgBox("pdf is from 2020+")
			'Else
			'	MsgBox("More filtering required to determine pdf generation")
			'End If


			If Team <> "" Then


				Dim tm As String() = Team.Split(New String() {" - "}, StringSplitOptions.None)

				Aircraft_Serial = tm(1)

				Air.Serial = tm(1)

				Air.struct_FileName = tm(0)
				Electrical_PDF = tm(0)

				File_name = tm(0)
				Dim Fname As String() = tm(0).Split(" ", 3, StringSplitOptions.None)
				Dim Fname2 As String() = tm(0).Split(" ", 3, StringSplitOptions.None)

				Air.Struct_Drawing_Name = Fname(1).Trim(CharsToTrim)

				Air.Struct_Drawing = Fname(0)

				First_Space = Fname(0)
				Second_Space = Fname(1)
				Third_Space = Fname(2)

				PDF_Selected = True
				Open_PDF.Visible = True

				'if native file location exists 
				'Open_Native_Folder.visible =true
				Dim folder = String.Empty
				Dim Folder_name = String.Empty

				'Bellow method works but is slow. Easier to not have

				'Dim Partial_Fold_Name = "*" & Air.Struct_Drawing & "*"
				'Dim DirInfo As DirectoryInfo = New DirectoryInfo(Native_Dir & "\CURRENT GENERATION DOCUMENTS")
				'Dim dInfoSearchFolder As DirectoryInfo = DirInfo.GetDirectories(Partial_Fold_Name, SearchOption.AllDirectories).FirstOrDefault

				'If IsNothing(dInfoSearchFolder) Then
				'	Functions.Error_Form("No folder found")
				'Else
				'	Nat_Folder = dInfoSearchFolder.FullName
				'	If Directory.Exists(Nat_Folder) Then
				'		Open_Native_Folder.Visible = True
				'	End If

				'End If



				For Each folder In System.IO.Directory.GetDirectories(Network_Locations.Native_Documents_Dir & "\CURRENT GENERATION DOCUMENTS")
					Nat_Folder = folder & "\" & Air.struct_FileName
					If Directory.Exists(Nat_Folder) Then
						Open_Native_Folder.Visible = True
						Exit For
					End If

				Next



				If Open_Native_Folder.Visible = False Then
					For Each folder In System.IO.Directory.GetDirectories(Network_Locations.Native_Documents_Dir & "\SECOND GENERATION DOCUMENTS")
						Nat_Folder = folder & "\" & Air.Struct_Drawing
						If Directory.Exists(Nat_Folder) Then
							Open_Native_Folder.Visible = True
							Exit For
						End If

					Next
				End If

				If Open_Native_Folder.Visible = False Then
					For Each folder In System.IO.Directory.GetDirectories(Network_Locations.Native_Documents_Dir & "\FIRST GENERATION DOCUMENTS")
						Nat_Folder = folder & "\" & Air.Struct_Drawing
						If Directory.Exists(Nat_Folder) Then
							Open_Native_Folder.Visible = True
							Exit For
						End If

					Next
				End If


			End If
		End If

	End Sub

	'Opens PDFs
	Private Sub Existing_Structral_PDFs_DoubleClick(sender As Object, e As EventArgs) Handles Existing_Electrical_PDFs.DoubleClick
		Open_PDF_Click(sender, e)
	End Sub

	Private Sub Open_PDF_Click(sender As Object, e As EventArgs) Handles Open_PDF.Click

		PDF_dir = Network_Locations.Aircraft_Data_Dir & "\" & Air.Manufacturer & "\" & Air.Type & "\" & Air.Serial & "\ElectricalS\" & Air.struct_FileName + ".pdf"
		PDF_Analysis = Network_Locations.Aircraft_Data_Dir & "\" & Air.Manufacturer & "\" & Air.Type & "\" & Air.struct_FileName + ".pdf"

		'PDF_dir = dir_Aircraft + "\" + Aircraft_Serial + "\ElectricalS\" + Electrical_PDF + ".pdf"

		If PDF_Selected = True Then
			If File.Exists(PDF_dir) Then
				Process.Start(PDF_dir)
			Else
				Process.Start(PDF_Analysis)
			End If

		Else
			Functions.Error_Form("F.S. PDF Viewer", "No PDF Selected",,,, False, Me)
		End If

	End Sub

	'Private Sub Aircraft_Frames_Load(sender As Object, e As EventArgs) Handles MyBase.Load
	'	Open_Native_Folder.Visible = False
	'	Open_PDF.Visible = False
	'End Sub

	Private Sub Open_Native_Folder_Click(sender As Object, e As EventArgs) Handles Open_Native_Folder.Click

		If PDF_Selected = True Then
			If Directory.Exists(Nat_Folder) Then
				Process.Start(Nat_Folder)

			End If

		Else
			Functions.Error_Form("F.S. PDF Viewer", "No PDF Selected",,,, False, Me)
		End If

	End Sub

	Private Sub Sort_CheckedChanged(sender As Object, e As EventArgs)

		'MsgBox("test run times")



		If Chrono_Sort.Checked = True AndAlso DWG_Num_Options.SelectedIndex <> 0 OrElse DWG_Sort.Checked = True AndAlso DWG_Num_Options.SelectedIndex <> 0 Then
			Radio_Sort_Method = "DWG"
			Functions.SortListBox(Existing_Electrical_PDFs, OG_LIST, Radio_Sort_Method, DWG_Num_Options.SelectedItem)

		ElseIf DWG_Sort.Checked = True AndAlso DWG_Num_Options.SelectedIndex = 0 Then
			Radio_Sort_Method = "DWG"
			Functions.SortListBox(Existing_Electrical_PDFs, OG_LIST, Radio_Sort_Method)

		ElseIf Chrono_Sort.Checked = True Then
			Radio_Sort_Method = "Chrono"
			DWG_Num_Options.SelectedIndex = 0
			Functions.SortListBox(Existing_Electrical_PDFs, OG_LIST, Radio_Sort_Method)
		End If

		'If Chrono_Sort.Checked = True Then
		'	Radio_Sort_Method = "Chrono"
		'	DWG_Num_Options.SelectedIndex = 0
		'	Functions.SortListBox(Existing_Electrical_PDFs, OG_LIST, Radio_Sort_Method)
		'End If

		'If DWG_Sort.Checked = True Then
		'	Radio_Sort_Method = "DWG"
		'	Functions.SortListBox(Existing_Electrical_PDFs, OG_LIST, Radio_Sort_Method, DWG_Num_Options.SelectedItem)
		'End If


	End Sub

	Private Sub Label2_Click(sender As Object, e As EventArgs) Handles PDF_Names_Label.Click

	End Sub

	Private Sub Clear_Button_Click(sender As Object, e As EventArgs) Handles Clear_Button.Click
		Search_PDF_Names_Input.Text = ""
		Existing_Electrical_PDFs.Items.Clear()
		For i = 0 To OG_LIST.Count - 1
			Existing_Electrical_PDFs.Items.Add(OG_LIST(i))
		Next
	End Sub

	Private Sub Search_Button_Click(sender As Object, e As EventArgs) Handles Search_Button.Click
		Dim i As Integer

		Existing_Electrical_PDFs.Items.Clear()

		For i = 0 To OG_LIST.Count - 1
			If OG_LIST(i).ToUpper.Contains(Search_PDF_Names_Input.Text.ToUpper) Then
				Existing_Electrical_PDFs.Items.Add(OG_LIST(i))
			End If
		Next
	End Sub

	Private Sub Search_Keydown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Search_PDF_Names_Input.KeyDown
		If (e.KeyCode = Keys.Enter) Then
			Search_Button_Click(sender, e)
		End If
	End Sub

#Region "Original Electrical Code"
	' Private Sub Aircraft_Frames_Load() Handles MyBase.Load
	'     Open_Native_Folder.Visible = False
	'     Open_PDF.Visible = False
	'     Chrono_Sort.Visible = False
	'     DWG_Sort.Visible = False
	'     Search_PDF_Names_Input.Visible = False
	'     PDF_Names_Label.Visible = False
	'     Form_Resize()

	'     AddHandler Chrono_Sort.CheckedChanged, New EventHandler(AddressOf Sort_CheckedChanged)
	'     AddHandler DWG_Num_Options.SelectedIndexChanged, New EventHandler(AddressOf Sort_CheckedChanged)

	'     Dir_Exist = Directory.Exists(dir)
	'     Aircraft_Type_Label.Visible = False
	'     Aircraft_Type.Visible = False
	'     Existing_Electrical_PDFs.Visible = False

	'     If Dir_Exist Then

	'         Directory_Exist.Text = "Aircraft Data Directory Exists"

	'         Aircraft_Type.Items.Clear()
	'         Aircraft_Type.Text = ""

	'         Dim folder = String.Empty
	'         Dim Folder_name = String.Empty

	'         For Each folder In System.IO.Directory.GetDirectories(dir)

	'             Folder_name = System.IO.Path.GetFileNameWithoutExtension(folder)
	'             Manufacturer.Items.Add(Folder_name)

	'         Next

	'     Else

	'Functions.Error_Form(, "Aircraft Data Directory Does not Exist",,,, False, Me)

	'Directory_Exist.Text = "Aircraft Data Directory Does not Exist"
	'         Dim Errorfrm As New Error_Message
	'         ''use the following to pass an error message to the Error Message Form
	'         'Errorfrm.PassedText = "Frame Station Directory Does not Exist"
	'         'Errorfrm.StartPosition = FormStartPosition.CenterParent
	'         'Errorfrm.ShowDialog()

	'     End If

	' End Sub

	' Private Sub Manufacturer_SelectedIndexChanged(sender As Object, e As EventArgs)

	'     Aircraft_Type_Label.Visible = True
	'     Aircraft_Type.Visible = True
	'     Existing_Electrical_PDFs.Visible = False
	'     PDF_Amount.Visible = False
	'     PDF_Selected = False

	'     Aircraft_Type.Items.Clear()
	'     Aircraft_Type.Text = ""

	'     dir_Manufacturer = dir + "\" + Manufacturer.Text

	'     Dir_Exist = Directory.Exists(dir_Manufacturer)
	'     If Dir_Exist Then

	'         Dim folder = String.Empty
	'         Dim Folder_name = String.Empty

	'         For Each folder In System.IO.Directory.GetDirectories(dir_Manufacturer)

	'             Folder_name = System.IO.Path.GetFileNameWithoutExtension(folder)
	'             Aircraft_Type.Items.Add(Folder_name)

	'         Next

	'     End If

	' End Sub


	' Private Sub Aircraft_Type_SelectedIndexChanged(sender As Object, e As EventArgs)

	'     Existing_Electrical_PDFs.Visible = True
	'     PDF_Amount.Visible = True
	'     PDF_Amount.Text = ""
	'     PDF_Selected = False

	'     Existing_Electrical_PDFs.Items.Clear()
	'     Existing_Electrical_PDFs.Text = ""

	'     dir_Aircraft = dir_Manufacturer + "\" + Aircraft_Type.Text

	'     Dir_Exist = Directory.Exists(dir_Aircraft)
	'     If Dir_Exist Then

	'         Dim file = String.Empty
	'         Dim File_name = String.Empty
	'         Dim Folder_name = String.Empty
	'         Dim Folder = String.Empty
	'         Dim Electrical_Folder = String.Empty

	'         For Each Folder In System.IO.Directory.GetDirectories(dir_Aircraft)

	'             For Each Electrical_Folder In System.IO.Directory.GetDirectories(Folder, "ELECTRICAL")

	'                 Folder_name = System.IO.Path.GetFileNameWithoutExtension(Folder)

	'                 For Each file In System.IO.Directory.GetFiles(Electrical_Folder, "*.pdf")

	'                     File_name = System.IO.Path.GetFileNameWithoutExtension(file)
	'                     Existing_Electrical_PDFs.Items.Add(File_name & " - " & Folder_name)
	'                     Item_Count = Existing_Electrical_PDFs.Items.Count

	'                 Next

	'             Next

	'         Next

	'         For Each LI In Existing_Electrical_PDFs.Items
	'             OG_LIST.Add(LI.ToString())
	'         Next
	'         Functions.SortListBox(Existing_Electrical_PDFs, OG_LIST)
	'         'Functions.SortListBox(Existing_Electrical_PDFs)

	'         If Item_Count = 0 Then
	'             Directory_Exist.Text = "No Electrical PDFs to Display"
	'             Existing_Electrical_PDFs.Items.Add("No Electrical PDFs to Display")
	'         End If
	'         PDF_Amount.Text = "Number of PDFs - " & Item_Count.ToString()
	'     End If

	' End Sub

	' Private Sub Existing_Electrical_PDFs_SelectedIndexChanged(sender As Object, e As EventArgs)

	'     If Item_Count = 0 Then

	'         PDF_Selected = False
	'     Else

	'         Dim Team As String = Existing_Electrical_PDFs.Text

	'         Dim tm As String() = Team.Split(New String() {" - "}, StringSplitOptions.None)

	'         Aircraft_Serial = tm(1)
	'         Electrical_PDF = tm(0)

	'         PDF_Selected = True

	'     End If

	' End Sub

	' Private Sub Existing_Structral_PDFs_DoubleClick(sender As Object, e As EventArgs)
	'     Open_PDF_Click(sender, e)
	' End Sub

	' Private Sub Open_PDF_Click(sender As Object, e As EventArgs)

	'     PDF_dir = dir_Aircraft + "\" + Aircraft_Serial + "\ELECTRICAL\" + Electrical_PDF + ".pdf"

	'     If PDF_Selected = True And System.IO.File.Exists(PDF_dir) Then
	'         Process.Start(PDF_dir)
	'     Else
	'         Functions.Error_Form("F.S. PDF Viewer", "No PDF Selected",,,, False, Me)
	'     End If

	' End Sub

#End Region

End Class