Imports System.IO
Imports System.Runtime.InteropServices

Public Class Existing_Aircrafts_Stringers

	Dim Nat_Folder As String
	Dim PDF_dir As String
	Dim PDF_Analysis As String
	Dim dir_Manufacturer As String
    Dim dir_Aircraft As String
    Dim Aircraft_Serial As String
    Dim Structure_PDF As String
    Dim Dir_Exist As Boolean
    Dim PDF_Selected As Boolean = False
    Dim Item_Count As Integer
	Dim Air As Airplane

	Dim First_Space As String
	Dim Second_Space As String
	Dim Third_Space As String

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
	'Dim Directories As String

	Private Sub Form_Resize() Handles Me.ResizeEnd
		Functions.Form_resize(Me)
	End Sub

	Private Sub Aircraft_Frames_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Open_Native_Folder.Visible = False
		Open_PDF.Visible = False
		Form_Resize()

		Dir_Exist = Directory.Exists(Network_Locations.Stringer_Charts)
		Aircraft_Type_Label.Visible = False
		Aircraft_Type.Visible = False
		Existing_Structural_PDFs.Visible = False

		If Dir_Exist Then

			Directory_Exist.Text = "Aircraft Stringer Directory Exists"


			Aircraft_Type.Items.Clear()
			Aircraft_Type.Text = ""

			Dim folder = String.Empty
			Dim Folder_name = String.Empty

			For Each folder In System.IO.Directory.GetDirectories(Network_Locations.Stringer_Charts)

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
		Existing_Structural_PDFs.Visible = False
		PDF_Amount.Visible = False
		PDF_Selected = False

		Aircraft_Type.Items.Clear()
		Aircraft_Type.Text = ""

		Air.Manufacturer = Manufacturer.Text

		dir_Manufacturer = Network_Locations.Stringer_Charts + "\" + Manufacturer.Text

		Dir_Exist = Directory.Exists(dir_Manufacturer)
		If Dir_Exist Then

			Dim folder = String.Empty
			Dim Folder_name = String.Empty

			For Each folder In System.IO.Directory.GetDirectories(dir_Manufacturer)

				Folder_name = System.IO.Path.GetFileNameWithoutExtension(folder)
				Aircraft_Type.Items.Add(Folder_name)

			Next

		End If

	End Sub

	Private Sub Aircraft_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Aircraft_Type.SelectedIndexChanged

		Existing_Structural_PDFs.Visible = True
		PDF_Amount.Visible = True
		PDF_Amount.Text = ""
		PDF_Selected = False

		Existing_Structural_PDFs.Items.Clear()
		Existing_Structural_PDFs.Text = ""

		Air.Type = Aircraft_Type.Text

		dir_Aircraft = dir_Manufacturer + "\" + Aircraft_Type.Text

		Dir_Exist = Directory.Exists(dir_Aircraft)
		If Dir_Exist Then

			Dim file = String.Empty
			Dim File_name = String.Empty
			Dim Folder_name = String.Empty
			Dim Folder = String.Empty
			Dim Structural_Folder = String.Empty
			Dim Contour_Folder = String.Empty

			For Each Folder In System.IO.Directory.GetDirectories(dir_Aircraft)

				For Each Structural_Folder In System.IO.Directory.GetDirectories(Folder, "STRUCTURES")

					Folder_name = System.IO.Path.GetFileNameWithoutExtension(Folder)

					For Each file In System.IO.Directory.GetFiles(Structural_Folder, "*.pdf")

						File_name = System.IO.Path.GetFileNameWithoutExtension(file)
						Existing_Structural_PDFs.Items.Add(File_name & " - " & Folder_name)
						Item_Count = Existing_Structural_PDFs.Items.Count

					Next

				Next


			Next

			If Folder = "" Then
				'For Each Contour_Folder In System.IO.Directory.GetDirectories(Folder, "STRUCTURES")

				Folder_name = System.IO.Path.GetFileNameWithoutExtension(dir_Aircraft)

				For Each file In System.IO.Directory.GetFiles(dir_Aircraft, "*.pdf")

					File_name = System.IO.Path.GetFileNameWithoutExtension(file)
					Existing_Structural_PDFs.Items.Add(File_name) ' & " - " & Folder_name)
					Item_Count = Existing_Structural_PDFs.Items.Count

				Next
				'Next
			End If

			For Each LI In Existing_Structural_PDFs.Items
				OG_LIST.Add(LI.ToString())
			Next
			Functions.SortListBox(Existing_Structural_PDFs, OG_LIST)
			'Functions.SortListBox(Existing_Structural_PDFs)

			If Item_Count = 0 Then
				Directory_Exist.Text = "No Structural PDFs to Display"
				Existing_Structural_PDFs.Items.Add("No Structural PDFs to Display")
			End If

			PDF_Amount.Text = "Number of PDFs - " & Item_Count.ToString()

		End If

	End Sub

	Private Sub Existing_Structural_PDFs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Existing_Structural_PDFs.SelectedIndexChanged

		Open_Native_Folder.Visible = False
		Open_PDF.Visible = False

		Dim CharsToTrim As Char() = {"(", ")"}

		If Item_Count = 0 Then

			PDF_Selected = False
		Else

			'Dim Team As String = Existing_Structural_PDFs.Text

			'Dim tm As String() = Team.Split(New String() {" - "}, StringSplitOptions.None)

			'Aircraft_Serial = tm(1)

			'Air.Serial = tm(1)

			'Air.struct_FileName = tm(0)

			Air.struct_FileName = Existing_Structural_PDFs.Text
			'Structure_PDF = tm(0)

			'File_name = tm(0)
			'Dim Fname As String() = tm(0).Split(" ", 3, StringSplitOptions.None)

			'Air.Struct_Drawing_Name = Fname(1).Trim(CharsToTrim)

			'Air.Struct_Drawing = Fname(0)

			'First_Space = Fname(0)
			'Second_Space = Fname(1)
			'Third_Space = Fname(2)

			PDF_Selected = True
			Open_PDF.Visible = True

			'if native file location exists 
			'Open_Native_Folder.visible =true
			Dim folder = String.Empty
			Dim Folder_name = String.Empty

			'For Each folder In System.IO.Directory.GetDirectories(Native_Dir & "\CURRENT GENERATION DOCUMENTS")
			'	Nat_Folder = folder & "\" & Air.struct_FileName
			'	If Directory.Exists(Nat_Folder) Then
			'		Open_Native_Folder.Visible = True
			'		Exit For
			'	End If

			'Next

			'If Open_Native_Folder.Visible = False Then
			'	For Each folder In System.IO.Directory.GetDirectories(Native_Dir & "\SECOND GENERATION DOCUMENTS")
			'		Nat_Folder = folder & "\" & Air.Struct_Drawing
			'		If Directory.Exists(Nat_Folder) Then
			'			Open_Native_Folder.Visible = True
			'			Exit For
			'		End If

			'	Next
			'End If
			'If Open_Native_Folder.Visible = False Then
			'	For Each folder In System.IO.Directory.GetDirectories(Native_Dir & "\FIRST GENERATION DOCUMENTS")
			'		Nat_Folder = folder & "\" & Air.Struct_Drawing
			'		If Directory.Exists(Nat_Folder) Then
			'			Open_Native_Folder.Visible = True
			'			Exit For
			'		End If

			'	Next
			'End If


		End If

	End Sub

	'Opens PDFs
	Private Sub Existing_Structral_PDFs_DoubleClick(sender As Object, e As EventArgs) Handles Existing_Structural_PDFs.DoubleClick
		Open_PDF_Click(sender, e)
	End Sub

	Private Sub Open_PDF_Click(sender As Object, e As EventArgs) Handles Open_PDF.Click

		PDF_dir = Network_Locations.Stringer_Charts & "\" & Air.Manufacturer & "\" & Air.Type & "\" & Air.Serial & "\STRUCTURES\" & Air.struct_FileName + ".pdf"
		PDF_Analysis = Network_Locations.Stringer_Charts & "\" & Air.Manufacturer & "\" & Air.Type & "\" & Air.struct_FileName + ".pdf"

		'PDF_dir = dir_Aircraft + "\" + Aircraft_Serial + "\STRUCTURES\" + Structure_PDF + ".pdf"

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


End Class