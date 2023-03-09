Imports System.IO
Imports System.Runtime.InteropServices

Public Class Material_Data

	'"\\192.168.0.32\Shared Folders\Engineering\Non-Site Specific\PARTS\LIBRARY\Structural Docs"
	Dim PDF_dir As String
	Dim dir_Manufacturer As String
	Dim dir_Aircraft As String
	Dim Dir_Exist As Boolean
	Dim PDF_Selected As Boolean = False
	Dim SubDir_Folder As String
	Dim SubSubDir_Folder As String
	Dim SubSubSubDir_Folder As String

	Private Sub Form1_resizeEnd() Handles Me.Activated, Me.ResizeEnd

		Dim ScreenArea As Rectangle = Screen.GetWorkingArea(Me.Location)
		Dim FormArea As Rectangle = Me.DesktopBounds

		If Me.WindowState = FormWindowState.Normal AndAlso Not ScreenArea.Contains(FormArea) Then
			If FormArea.Top < ScreenArea.Top Then Me.Top = 0
			If FormArea.Left < ScreenArea.Left Then Me.Left = Me.Left - (FormArea.Left - ScreenArea.Left)
			If FormArea.Right > ScreenArea.Right Then Me.Left = Me.Left - (FormArea.Right - ScreenArea.Right)
			If FormArea.Bottom > ScreenArea.Bottom Then Me.Top = Me.Top - (FormArea.Bottom - ScreenArea.Bottom)
		End If

	End Sub

	Private Sub Aircraft_Frames_Load() Handles MyBase.Load
		Form1_resizeEnd()

		Open_PDF.Visible = False


		Dir_Exist = Directory.Exists(Network_Locations.Structural_Docs_Dir)

		Directory_Display_ListView.Scrollable = True
		Directory_Display_ListView.HeaderStyle = ColumnHeaderStyle.None
		Directory_Display_ListView.Columns.Add("")
		Directory_Display_ListView.Columns(0).Width = 780


		If Dir_Exist Then

			Directory_Exist.Text = "Structural Ref Directory Exists"

			Dim folder = String.Empty
			Dim Folder_name = String.Empty

			For Each folder In System.IO.Directory.GetDirectories(Network_Locations.Structural_Docs_Dir)

				Folder_name = System.IO.Path.GetFileNameWithoutExtension(folder)

			Next

		Else

			Functions.Error_Form("Error", "Frame Station Directory Does not Exist",,,, False, Me)
			Directory_Exist.Text = "Frame Station Directory Does not Exist"

		End If

		Dim Struct_Folders = Directory.GetDirectories(Network_Locations.Structural_Docs_Dir)

		For i = 0 To Struct_Folders.Count - 1

			If Struct_Folders(i) IsNot Nothing Then
				Dim Leading_Folder As New DirectoryInfo(Struct_Folders(i))
				Directory_Display_ListBox.Items.Add(Leading_Folder.Name)
				Directory_Display_ListView.Items.Add(Leading_Folder.Name).Tag = Leading_Folder
			End If

			Dim Sub_Folder = Directory.GetDirectories(Struct_Folders(i))

			For Each file In Directory.GetFiles(Struct_Folders(i))
				Dim PDF_Name = Path.GetFileNameWithoutExtension(file)
				Directory_Display_ListBox.Items.Add("   -----   -----   " + PDF_Name)
				Directory_Display_ListView.Items.Add("   -----   -----   " + PDF_Name).Tag = Struct_Folders(i) + "\" + PDF_Name

			Next

			For j = 0 To Sub_Folder.Count - 1
				If Sub_Folder(j) IsNot Nothing Then
					Dim Leading_Sub_Folder As New DirectoryInfo(Sub_Folder(j))
					Directory_Display_ListBox.Items.Add("   -----   " + Leading_Sub_Folder.Name)
					Directory_Display_ListView.Items.Add("   -----   " + Leading_Sub_Folder.Name).Tag = Leading_Sub_Folder '.Name
				End If

				Dim SubSub_Folder = Directory.GetDirectories(Sub_Folder(j))

				For Each file In Directory.GetFiles(Sub_Folder(j))
					Dim PDF_Name = Path.GetFileNameWithoutExtension(file)
					Directory_Display_ListBox.Items.Add("   -----   -----   -----   " + PDF_Name)
					Directory_Display_ListView.Items.Add("   -----   -----   -----   " + PDF_Name).Tag = Sub_Folder(j) + "\" + PDF_Name

				Next

				For k = 0 To SubSub_Folder.Count - 1

					If SubSub_Folder(k) IsNot Nothing Then
						Dim Leading_SubSub_Folder As New DirectoryInfo(SubSub_Folder(k))
						Directory_Display_ListBox.Items.Add("   -----   -----   " + Leading_SubSub_Folder.Name)
						Directory_Display_ListView.Items.Add("   -----   -----   " + Leading_SubSub_Folder.Name).Tag = Leading_SubSub_Folder '.Name
					End If

					Dim SubSubSub_Folder = Directory.GetDirectories(SubSub_Folder(k))

					For Each file In Directory.GetFiles(SubSub_Folder(k))
						Dim PDF_Name = Path.GetFileNameWithoutExtension(file)
						Directory_Display_ListBox.Items.Add("   -----   -----   -----   -----   " + PDF_Name)
						Directory_Display_ListView.Items.Add("   -----   -----   -----   -----   " + PDF_Name).Tag = SubSub_Folder(k) + "\" + PDF_Name

					Next

					For m = 0 To SubSubSub_Folder.Count - 1

						If SubSubSub_Folder(m) IsNot Nothing Then
							Dim Leading_SubSubSub_Folder As New DirectoryInfo(SubSubSub_Folder(m))
							Directory_Display_ListBox.Items.Add("   -----   -----   -----   " + Leading_SubSubSub_Folder.Name)
						End If

						For Each file In Directory.GetFiles(SubSubSub_Folder(m))
							Dim PDF_Name = Path.GetFileNameWithoutExtension(file)
							Directory_Display_ListBox.Items.Add("   -----   -----   -----   -----   -----   " + PDF_Name)
							Directory_Display_ListView.Items.Add("   -----   -----   -----   -----   -----   " + PDF_Name).Tag = SubSubSub_Folder(m) + "\" + PDF_Name

						Next
					Next
				Next
			Next

		Next

	End Sub

	Private Sub Open_PDF_Click(sender As Object, e As EventArgs) Handles Open_PDF.Click, Directory_Display_ListView.DoubleClick

		Dim File_dir = Directory_Display_ListView.SelectedItems(0).Tag.ToString
		PDF_dir = File_dir + ".pdf"
		Dim PNG_dir = File_dir + ".png"
		Dim jpg_dir = File_dir + ".jpg"
		Dim jpeg_dir = File_dir + ".jpeg"
		Dim Excel_Dir1 = File_dir + ".xlsx"
		Dim Excel_Dir2 = File_dir + ".xls"
		'MsgBox(PDF_dir)

		Select Case True
			Case File.Exists(PDF_dir)
				Process.Start(PDF_dir)
			Case File.Exists(PNG_dir)
				Process.Start(PNG_dir)
			Case File.Exists(jpg_dir)
				Process.Start(jpg_dir)
			Case File.Exists(jpeg_dir)
				Process.Start(jpeg_dir)
			Case File.Exists(Excel_Dir1)
				Process.Start(Excel_Dir1)
			Case File.Exists(Excel_Dir2)
				Process.Start(Excel_Dir2)
			Case Else
				Functions.Error_Form("F.S. PDF Viewer", "No File Selected",,,, False, Me)

		End Select


		'If System.IO.File.Exists(PDF_dir) Then
		'	Process.Start(PDF_dir)
		'ElseIf System.IO.File.Exists(PNG_dir) Then
		'	Process.Start(PNG_dir)
		'ElseIf System.IO.File.Exists(jpg_dir) Then
		'	Process.Start(jpg_dir)
		'ElseIf System.IO.File.Exists(jpeg_dir) Then
		'	Process.Start(jpeg_dir)
		'ElseIf System.IO.File.Exists(Excel_Dir1) Then
		'	Process.Start(Excel_Dir1)
		'ElseIf System.IO.File.Exists(Excel_Dir2) Then
		'	Process.Start(Excel_Dir2)
		'Else
		'	Functions.Error_Form("F.S. PDF Viewer", "No File Selected",,,, False, Me)

		'End If

		'If System.IO.File.Exists(PDF_dir) = True Then
		'	Process.Start(PDF_dir)
		'Else
		'	Functions.Error_Form("F.S. PDF Viewer", "No PDF Selected",,,, False, Me)
		'End If
	End Sub

	Private Sub Directory_Display_ListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Directory_Display_ListView.ItemSelectionChanged

		Dim Folder_File As String
		Folder_File = Directory_Display_ListView.FocusedItem.Tag.ToString
		'MsgBox(Folder_File)

		PDF_dir = Folder_File + ".pdf"
		Dim PNG_dir = Folder_File + ".png"
		Dim jpg_dir = Folder_File + ".jpg"
		Dim jpeg_dir = Folder_File + ".jpeg"
		Dim Excel_Dir1 = Folder_File + ".xlsx"
		Dim Excel_Dir2 = Folder_File + ".xls"


		Select Case True
			Case File.Exists(PDF_dir)
				Open_PDF.Visible = True
				Directory_Exist.Text = PDF_dir
			Case File.Exists(PNG_dir)
				Open_PDF.Visible = True
				Directory_Exist.Text = PNG_dir
			Case File.Exists(jpg_dir)
				Open_PDF.Visible = True
				Directory_Exist.Text = jpg_dir
			Case File.Exists(jpeg_dir)
				Open_PDF.Visible = True
				Directory_Exist.Text = jpeg_dir
			Case File.Exists(Excel_Dir1)
				Open_PDF.Visible = True
				Directory_Exist.Text = Excel_Dir1
			Case File.Exists(Excel_Dir2)
				Open_PDF.Visible = True
				Directory_Exist.Text = Excel_Dir2
			Case Else
				Open_PDF.Visible = False
				Directory_Exist.Text = Folder_File ' Directory_Display_ListView.FocusedItem.ToString
				'Functions.Error_Form("No file selected", "Item selected is not a file to open")

		End Select

		'Directory_Exist.Text = Folder_File

		'If System.IO.Directory.Exists(Folder_File) Then
		'	MsgBox("Folder")
		'ElseIf File.Exists(Folder_File) Then
		'	Process.Start(Folder_File)
		'	MsgBox("File")

		'End If

	End Sub
End Class