Imports System.IO
Imports Engineering_Assistant.SWFunctions

Public Class Functions

	Public Shared Status As Boolean = False
	Public Shared Calling_Fun As String
	Public Shared Document_Directory As New List(Of Struct_Docs)

	Class Struct_Docs
		Public PDF_Name As String
		Public Manufacturer As String
		Public Aircraft_Type As String
		Public Serial_Number As String
		Public Drawing_Num As String
		Public Title As String
		Public PDF_Path As String
		Public Native_Path As String

		Public Sub New(s1 As String, s2 As String, s3 As String, s4 As String, s5 As String, s6 As String, s7 As String, s8 As String)
			PDF_Name = s1
			Manufacturer = s2
			Aircraft_Type = s3
			Serial_Number = s4
			Drawing_Num = s5
			Title = s6
			PDF_Path = s7
			Native_Path = s8

		End Sub

	End Class

	Public Shared Function Error_Form(Optional ByVal FmName As String = "Error",
								  Optional ByVal FmText As String = "",
								  Optional ByVal FmValue As String = "",
								  Optional ByVal FmText2 As String = "",
								  Optional ByVal FmText3 As String = "",
								  Optional ByVal BaseLoad As Boolean = False,
								  Optional ByVal CurrentControl As Control = Nothing)
		Dim left As Integer
		Dim width As Integer
		Dim top As Integer
		Dim height As Integer
		Dim parent As Control = Nothing
		Dim PopUpForm As New Error_Message



		Start_Window.AlwaysOnTopToolStripMenuItem.Checked = False
		Start_Window.AlwaysOnTopToolStripMenuItem_Click()

		PopUpForm.FormName = FmName
		PopUpForm.PassedText = FmText
		PopUpForm.PassedValue = FmValue
		PopUpForm.TextLine2 = FmText2
		PopUpForm.TextLine3 = FmText3



		If CurrentControl Is Nothing Then

			'Centers the popup to the center of the parent calling form

			PopUpForm.StartPosition = FormStartPosition.CenterParent

		ElseIf CurrentControl Is Start_Window Then
			'The Following code centers the popup to the center of the screen where the mouse is located at

			Dim Screen_W As Integer
			Dim Screen_H As Integer
			Dim ScreenArea As Rectangle = Screen.GetWorkingArea(Cursor.Position)

			PopUpForm.TopMost = True
			Screen_W = ScreenArea.Size.Width
			Screen_H = ScreenArea.Size.Height

			PopUpForm.StartPosition = FormStartPosition.Manual
			PopUpForm.Location = New Point(((Screen_W / 2) - (PopUpForm.Width / 2)), ((Screen_H / 2) - (PopUpForm.Height / 2)))
		Else


			parent = CurrentControl
			PopUpForm.Owner = parent

			PopUpForm.StartPosition = FormStartPosition.Manual

			left = CurrentControl.Left
			width = (CurrentControl.Width / 2) - (PopUpForm.Width / 2)
			top = CurrentControl.Top
			height = (CurrentControl.Height / 2) - (PopUpForm.Height / 2)

			PopUpForm.Location = New Point(left + width, top + height)

		End If

		PopUpForm.ShowDialog()

		If BaseLoad = True Then

			Start_Window.Start_Window_Load()

		End If

		Return True

	End Function

	Public Shared Function Open_New_Form(Of T As {Form, New})()

		Dim instance As Form = Nothing
		instance = New T()

		instance.StartPosition = FormStartPosition.Manual
		instance.Location = New Point(Start_Window.Right, Start_Window.Top)


		instance.ShowDialog()

		Return True

	End Function

	Public Shared Function Check_Directory(Directory As String, List As ComboBox)

		Dim file = String.Empty
		Dim File_name = String.Empty
		Dim Start_Char As Char

		For Each file In System.IO.Directory.GetFiles(Directory, "*.sldlfp")

			File_name = System.IO.Path.GetFileName(file)
			Start_Char = File_name.Substring(0, 1)

			If Start_Char <> "~" Then

				List.Items.Add(System.IO.Path.GetFileNameWithoutExtension(file))
			Else

			End If

		Next

		Return List
	End Function

	Public Shared Function Directory_List(Directory As String, List As ListBox)

		Dim file = String.Empty
		Dim File_name = String.Empty
		Dim Start_Char As Char

		For Each file In System.IO.Directory.GetFiles(Directory, "*.sldlfp")

			File_name = System.IO.Path.GetFileName(file)
			Start_Char = File_name.Substring(0, 1)

			If Start_Char <> "~" Then

				List.Items.Add(System.IO.Path.GetFileNameWithoutExtension(file))
			Else

			End If

		Next

		Return List
	End Function

	Public Shared Function SortList(ByVal listbox As List(Of String), Optional ByVal Direction As Integer = 1)
		Dim TempList As New List(Of String)
		Dim i As Integer
		Dim Item_Count As Integer
		For Each LI In listbox
			TempList.Add(LI.ToString())

		Next

		If Direction = 0 Then

			TempList.Sort()
			Item_Count = listbox.Count
			listbox.Clear()

			For i = 0 To Item_Count - 1

				listbox.Add(TempList(i))

			Next
		Else

			TempList.Sort()
			TempList.Reverse()
			Item_Count = listbox.Count
			listbox.Clear()

			For i = 0 To Item_Count - 1

				listbox.Add(TempList(i))

			Next
		End If

		Return listbox


	End Function

	Public Shared Sub SortListBox(ByVal listbox As ListBox, ByVal OGLIST As List(Of String), Optional ByVal Direction As String = "Chrono", Optional ByVal DWG_Type_Filer As String = "ALL")

		Dim TempList As New List(Of String)
		Dim i As Integer
		Dim Item_Count As Integer
		Dim ordered As IOrderedEnumerable(Of String)

		TempList = OGLIST
		'For Each LI In listbox.Items
		'	TempList.Add(LI.ToString())

		'Next

		If Direction = "DWG" Then
			listbox.Items.Clear()

			ordered = TempList.OrderByDescending(Function(x) GetDWG_Num_Type(x)) 'was TempList

			For i = 0 To ordered.Count - 1
				If DWG_Type_Filer <> "ALL" Then
					If GetDWG_Num_Type(ordered(i)) = DWG_Type_Filer Then
						listbox.Items.Add(ordered(i))
					End If
				ElseIf DWG_Type_Filer = "ALL" Then
					listbox.Items.Add(ordered(i))
				End If

			Next





			'Else
			'	listbox.Items.Clear()
			'	ordered = TempList.OrderByDescending(Function(x) GetDWG_Num_Type(x))

			'	For i = 0 To ordered.Count - 1
			'		listbox.Items.Add(ordered(i))
			'	Next
			'End If

			'listbox.Items.Clear()
			'ordered = TempList.OrderByDescending(Function(x) GetDWG_Num_Type(x)) '.

			'For i = 0 To ordered.Count - 1

			'	Debug.Print(GetDWG_Num_Type(ordered(i)))

			'	listbox.Items.Add(ordered(i))
			'Next

			'ThenBy(Function(x) x.Substring(4, 5)).ThenBy(Function(x) x.Substring(5, 6)).
			'ThenBy(Function(x) x.Substring(0, 1)).ThenBy(Function(x) x.Substring(1, 2)).
			'ThenBy(Function(x) x.Substring(2, 3)).ThenBy(Function(x) x.Substring(6, 7))



		ElseIf Direction = "Chrono" Then

			TempList.Sort()
			TempList.Reverse()
			Item_Count = TempList.Count
			listbox.Items.Clear()

			For i = 0 To Item_Count - 1

				If DWG_Type_Filer <> "ALL" Then
					If GetDWG_Num_Type(TempList(i)) = DWG_Type_Filer Then
						listbox.Items.Add(TempList(i))
					End If
				ElseIf DWG_Type_Filer = "ALL" Then
					listbox.Items.Add(TempList(i))
				End If

				'listbox.Items.Add(TempList(i))

			Next
		End If



	End Sub

	Public Shared Function Form_resize(Optional ByVal CurrentControl As Form = Nothing)

		Dim parent As Form = Nothing
		parent = CurrentControl

		Dim ScreenArea As Rectangle = Screen.GetWorkingArea(parent.Location)
		Dim FormArea As Rectangle = parent.DesktopBounds

		If parent.WindowState = FormWindowState.Normal AndAlso Not ScreenArea.Contains(FormArea) Then
			If FormArea.Top < ScreenArea.Top Then parent.Top = 0
			If FormArea.Left < ScreenArea.Left Then parent.Left = parent.Left - (FormArea.Left - ScreenArea.Left)
			If FormArea.Right > ScreenArea.Right Then parent.Left = parent.Left - (FormArea.Right - ScreenArea.Right)
			If FormArea.Bottom > ScreenArea.Bottom Then parent.Top = parent.Top - (FormArea.Bottom - ScreenArea.Bottom)
		End If

		Return True

	End Function

	Public Shared Function Input_Validate(Input As String, Valid_Input As String)

		Dim Output_Int As Integer
		Dim Output_Dec As Decimal

		If Valid_Input = "Integer" Then

			If Integer.TryParse(Input, Output_Int) Then

				Return Output_Int
			Else
				Return 0
			End If
		End If

		If Valid_Input = "Decimal" Then

			If Decimal.TryParse(Input, Output_Dec) Then

				Return Output_Dec
			Else
				Return 0
			End If
		End If

		Return 0
	End Function

	Public Shared Function Text_Validate(Sender As Object, Valid_Input As String, CurrentControl As Control, Txt_Desc As String)

		Dim Txt As TextBox = DirectCast(Sender, TextBox)
		Dim Output_Int As Integer
		Dim IntString As String = "Integer"
		Dim Output_Dec As Decimal
		Dim DecString As String = "Decimal"
		Dim Output_Dub As Double
		Dim DubString As String = "Double"
		Dim Output_Char As Char
		Dim CharString As String = "Char"
		'Dim Output_Txt As String

		If Valid_Input = IntString Then
			If Integer.TryParse(Txt.Text, Output_Int) Then
				Return IntString
			ElseIf Txt_Desc <> "Force input" Then
				Error_Form("Incorrect input", Txt_Desc & " is not a correct value for this input",, "Clearing text input",,, CurrentControl)
				Txt.Clear()
				Txt.Focus()
			End If
		End If

		If Valid_Input = DecString Then
			If Decimal.TryParse(Txt.Text, Output_Dec) Then
				Return DecString
			ElseIf Txt_Desc <> "Force input" Then
				Error_Form("Incorrect input", Txt_Desc & " is not a correct value for this input",, "Clearing text input",,, CurrentControl)
				Txt.Clear()
				Txt.Focus()
			End If
		End If

		If Valid_Input = DubString Then
			If Double.TryParse(Txt.Text, Output_Dub) Then
				Return DubString
			ElseIf Txt_Desc <> "Force input" Then
				Error_Form("Incorrect input", Txt_Desc & " is not a correct value for this input",, "Clearing text input",,, CurrentControl)
				Txt.Clear()
				Txt.Focus()
			End If
		End If

		If Valid_Input = CharString Then
			If Char.TryParse(Txt.Text, Output_Char) Then
				Return CharString
			ElseIf Txt_Desc <> "Force input" Then
				Error_Form("Incorrect input", Txt_Desc & " is not a character",, "Clearing text input",,, CurrentControl)
				Txt.Clear()
				Txt.Focus()
			End If
		End If

		'Redundant statement
		'If Valid_Input = "String" Then
		'	Output_Txt = Txt.Text
		'	Return Output_Txt
		'End If




		'If Input_Validate(Txt.Text, Valid_Input) = 0 Then
		'	Error_Form("Incorrect input", "Box weight is not a number",, "Clearing text input",,, CurrentControl)
		'	Txt.Clear()
		'	Txt.Focus()
		'End If

		Return "False"

	End Function

	Shared Function FolderName(path As String)
		Dim FileName As String = path

		FileName = FileName.Remove(0, FileName.LastIndexOf("\") + 1)
		FileName = FileName.Remove(FileName.LastIndexOf("."))

		Return FileName
	End Function

	Shared Function GetDWG_Num_Type(ByVal PDF_String As String)
		Dim DWG_Num_Type = String.Empty

		If CheckforAlphaChar(PDF_String, 6) = True Then
			DWG_Num_Type = PDF_String.Substring(3, 3)
		ElseIf CheckforAlphaChar(PDF_String, 5) = True Then
			DWG_Num_Type = PDF_String.Substring(2, 3)
		ElseIf CheckforSym(PDF_String, 2) = True Then
			DWG_Num_Type = PDF_String.Substring(3, 3)
		Else
			DWG_Num_Type = PDF_String.Substring(4, 3)
		End If
		'DWG_Num_Type = "339"

		Return DWG_Num_Type
	End Function

	Shared Function CheckforAlphaChar(ByVal StringtoCheck As String, Optional ByVal CharPosition As Integer = 0)



		If Char.IsLetter(StringtoCheck.Chars(CharPosition)) Then
			Return True
		Else
			Return False
		End If

	End Function

	Shared Function CheckforSym(ByVal StringtoCheck As String, Optional ByVal CharPosition As Integer = 0)



		If Char.IsSymbol(StringtoCheck.Chars(CharPosition)) Then
			Return True
		Else
			Return False
		End If

	End Function

	Shared Function PDFGen_Current(ByVal StringtoCheck As String, Optional ByVal CharPosition As Integer = 0)



		Return True
	End Function

	Shared Function GetStructPDFs(ByVal Dir_Path As String, ByVal Folder_name As String) As (AC_Type As String, Manufacturer As String,
		Serial_Num As String, Dir_Path As String, Native_Path As String, Dwg_Num As String, Title As String)

		Dim AC_Type As String = ""
		Dim Manufacturer As String = ""
		Dim Serial_Num As String = ""
		Dim Native_Path As String = ""
		Dim Dwg_Num As String = ""
		Dim Title As String
		Dim CharsToTrim As Char() = {"(", ")", " "}

		Title = System.IO.Path.GetFileNameWithoutExtension(Dir_Path)

		Dim tm As String() = Title.Split(New String() {" - "}, StringSplitOptions.None)

		Dim Fname As String() = tm(0).Split("(", 2, StringSplitOptions.None)

		Try
			If Fname.Length = 1 Then
				Title = Fname(0).Trim(CharsToTrim)
			Else
				Dwg_Num = Fname(0).Trim(CharsToTrim)
			End If

			If Fname.Length = 2 Then
				Title = Fname(1).Trim(CharsToTrim)
			End If
			If Fname.Length = 3 Then
				Debug.Print("Larger Array")
			End If



		Catch ex As Exception
			Error_Form("Broken", Dir_Path, , ex.Message)
		End Try


		Return (AC_Type, Manufacturer, Serial_Num, Dir_Path, Native_Path, Dwg_Num, Title)
	End Function

	Public Shared Function MFG_Backup_Combine_StructElect(ByVal Struct_list As List(Of String), ByVal Elect_list As List(Of String))

		For Each mfg In Struct_list
			MFGtoBackup(mfg, "STRUCTURES")
		Next
		For Each mfg In Elect_list
			MFGtoBackup(mfg, "ELECTRICAL")
		Next

		Return True
	End Function

	Public Shared Sub Add_To_Doc_List(ByVal StructPath As String, ByVal Native_Dir As String)

		For Each mfg_dir In Directory.GetFiles(StructPath, "*.pdf")

#Region "Var Declaratioins"


			Dim Manufacturer_excel As String
			Dim AC_Type_excel As String
			Dim Dwg_Num_excel As String
			Dim Dwg_Num_excel_NoRev As String = ""
			Dim Serial_Num_excel As String
			Dim Title_excel As String
			Dim Title_OG As String
			Dim PDF_Name As String
			Dim PDF_Name_Extension As String
			Dim Native_Folder_excel As String = "Can't Locate Native File Path"
			Dim Native_Folder As String
			Dim Native_File As String
			Dim Native_File_Long As String
			Dim Native_File_OG As String
			Dim Native_File_OG_NoRev As String
			Dim CharsToTrim As Char() = {"(", ")", " "}
			Dim FirstGenFolderLength As Integer
			Dim FirstGenFolderNum As String = ""
			Dim FirstGenDWGNum As String = ""
			Dim SecondGenFolderNum As String = ""

#End Region
			PDF_Name = System.IO.Path.GetFileNameWithoutExtension(mfg_dir)

			Dim Path_to_Data As String() = mfg_dir.Split("\")
			Dim length As Integer = Path_to_Data.Length - 1
			PDF_Name_Extension = Path_to_Data(length)
			Serial_Num_excel = Path_to_Data(length - 2)
			AC_Type_excel = Path_to_Data(length - 3)
			Manufacturer_excel = Path_to_Data(length - 4)

			'Dim tm As String() = PDF_Name.Split(New String() {" - "}, StringSplitOptions.None)
			Dim Fname As String()
			If PDF_Name.Contains("(") Then

				Fname = PDF_Name.Split("(", 2, StringSplitOptions.None)
				Dwg_Num_excel = Fname(0).Trim(CharsToTrim)
				If Dwg_Num_excel.Contains(" ") Then
					Dwg_Num_excel = Dwg_Num_excel.Substring(0, Dwg_Num_excel.IndexOf(" "))

				End If
				If Not IsNumeric(Dwg_Num_excel.Substring(Dwg_Num_excel.Length - 1, 1)) Then
					Dwg_Num_excel_NoRev = Dwg_Num_excel.Substring(0, Dwg_Num_excel.Length - 1)
				End If
				'Title_OG = Fname(1)
				Title_excel = Fname(1).Trim(CharsToTrim)
				Title_OG = "(" & Title_excel & ")"

			ElseIf PDF_Name.Contains(" ") Then

				Dwg_Num_excel = PDF_Name.Substring(0, PDF_Name.IndexOf(" "))
				Title_excel = PDF_Name.Trim(CharsToTrim)
				Title_OG = "(" & Title_excel & ")"
			Else
				Dwg_Num_excel = "N/A"
				Title_excel = PDF_Name.Trim(CharsToTrim)
				Title_OG = "(" & Title_excel & ")"
			End If

			'Try
			Dim CurrentGenStatus As Boolean = False
			Dim FirstGenStatus As Boolean = False
			Dim SecondGenStatus As Boolean = False
			Dim CurrentYear As String = "20"
			If PDF_Name.Length > 8 Then


				Dim CurrentGen As String = PDF_Name.Substring(7, 1)
				Dim CurrentGen2 As String = PDF_Name.Substring(8, 1)
				Dim CurrentGen3 As String = PDF_Name.Substring(6, 1)
				Dim FirstGen As String = PDF_Name.Substring(2, 1)
				Dim FirstGen2 As String = PDF_Name.Substring(3, 1)
				If CurrentGen = "-" Then

					If Not IsNumeric(PDF_Name.Substring(6, 1)) Then
						CurrentGenStatus = True
						If IsNumeric(PDF_Name.Substring(1, 2)) Then
							CurrentYear += PDF_Name.Substring(1, 2)
						End If

					ElseIf IsNumeric(PDF_Name.Substring(0, 2)) Then
						SecondGenStatus = True
						SecondGenFolderNum = PDF_Name.Substring(0, 2)
					End If

				ElseIf CurrentGen2 = "-" Then

					'MsgBox(PDF_Name.Substring(7, 1).ToCharArray())
					If Not IsNumeric(PDF_Name.Substring(7, 1)) Then
						CurrentGenStatus = True
						If IsNumeric(PDF_Name.Substring(0, 2)) Then
							CurrentYear += PDF_Name.Substring(0, 2)
						End If

					ElseIf IsNumeric(PDF_Name.Substring(0, 2)) Then
						SecondGenStatus = True
						SecondGenFolderNum = PDF_Name.Substring(0, 2)
					End If

				ElseIf CurrentGen3 = "-" Then

					'MsgBox(PDF_Name.Substring(7, 1).ToCharArray())
					If Not IsNumeric(PDF_Name.Substring(6, 1)) Then
						CurrentGenStatus = True
						If IsNumeric(PDF_Name.Substring(0, 2)) Then
							CurrentYear += PDF_Name.Substring(0, 2)
						End If

					ElseIf IsNumeric(PDF_Name.Substring(0, 2)) Then
						SecondGenStatus = True
						SecondGenFolderNum = PDF_Name.Substring(0, 2)
					End If

				ElseIf FirstGen = "-" Then

					If IsNumeric(PDF_Name.Substring(0, 2)) Then
						FirstGenStatus = True
						FirstGenFolderLength = 2
						FirstGenFolderNum = PDF_Name.Substring(0, FirstGenFolderLength)
						FirstGenDWGNum = PDF_Name.Substring(FirstGenFolderLength + 1, 3)
					End If

				ElseIf FirstGen2 = "-" Then

					If IsNumeric(PDF_Name.Substring(0, 3)) Then
						FirstGenStatus = True
						FirstGenFolderLength = 3
						FirstGenFolderNum = PDF_Name.Substring(0, FirstGenFolderLength)
						FirstGenDWGNum = PDF_Name.Substring(FirstGenFolderLength + 1, 3)
					ElseIf IsNumeric(PDF_Name.Substring(0, 2)) Then
						FirstGenStatus = True
						FirstGenFolderLength = 2
						FirstGenFolderNum = PDF_Name.Substring(0, FirstGenFolderLength)
						FirstGenDWGNum = PDF_Name.Substring(FirstGenFolderLength + 1, 3)
					End If

				End If

			End If

			If CurrentGenStatus = True Then

				Dim CurPath = IO.Path.Combine(Native_Dir, "CURRENT GENERATION DOCUMENTS", CurrentYear)
				If Directory.Exists(CurPath) Then

					Native_Folder = IO.Path.Combine(CurPath, PDF_Name)
					Native_File = IO.Path.Combine(CurPath, Dwg_Num_excel)
					Native_File_Long = IO.Path.Combine(CurPath, PDF_Name)
					Native_File_OG = IO.Path.Combine(CurPath, Dwg_Num_excel & " " & Title_OG)
					Native_File_OG_NoRev = IO.Path.Combine(CurPath, Dwg_Num_excel_NoRev & " " & Title_OG)
					If Directory.Exists(Native_Folder) Then
						Native_Folder_excel = Native_Folder

					ElseIf Directory.Exists(Native_File) Then
						Native_Folder_excel = Native_File

					ElseIf File.Exists(Native_File + ".dwg") Then
						Native_Folder_excel = Native_File + ".dwg"

					ElseIf File.Exists(Native_File + ".doc") Then
						Native_Folder_excel = Native_File + ".doc"

					ElseIf File.Exists(Native_File + ".docx") Then
						Native_Folder_excel = Native_File + ".docx"

					ElseIf File.Exists(Native_File_Long + ".dwg") Then
						Native_Folder_excel = Native_File_Long + ".dwg"

					ElseIf Directory.Exists(Native_File_OG) Then
						Native_Folder_excel = Native_File_OG

					ElseIf File.Exists(Native_File_OG + ".dwg") Then
						Native_Folder_excel = Native_File_OG + ".dwg"

					ElseIf File.Exists(Native_File_OG + ".doc") Then
						Native_Folder_excel = Native_File_OG + ".doc"

					ElseIf File.Exists(Native_File_OG + ".docx") Then
						Native_Folder_excel = Native_File_OG + ".docx"

					ElseIf Directory.Exists(Native_File_OG_NoRev) Then
						Native_Folder_excel = Native_File_OG_NoRev

					ElseIf File.Exists(Native_File_OG_NoRev + ".dwg") Then
						Native_Folder_excel = Native_File_OG_NoRev + ".dwg"

					ElseIf File.Exists(Native_File_OG_NoRev + ".doc") Then
						Native_Folder_excel = Native_File_OG_NoRev + ".doc"

					ElseIf File.Exists(Native_File_OG_NoRev + ".docx") Then
						Native_Folder_excel = Native_File_OG_NoRev + ".docx"

					Else
						Dim FoundFolder As Boolean = False
						For Each subfolder In System.IO.Directory.GetDirectories(CurPath)
							If subfolder.Contains(Dwg_Num_excel) Then
								Native_Folder_excel = subfolder
								FoundFolder = True
								Exit For
							End If
						Next
						If FoundFolder = False Then
							For Each filename As String In Directory.GetFiles(CurPath, "*.dwg")
								If filename.ToLower().Contains(Dwg_Num_excel.ToLower) Then
									Native_Folder_excel = filename
									FoundFolder = True
									Exit For
								End If

							Next
						End If
						If FoundFolder = False Then
							For Each filename As String In Directory.GetFiles(CurPath, "*.doc")
								If filename.ToLower().Contains(Dwg_Num_excel.ToLower) Then
									Native_Folder_excel = filename
									FoundFolder = True
									Exit For
								End If

							Next
						End If
						If FoundFolder = False Then
							For Each filename As String In Directory.GetFiles(CurPath, "*.docx")
								If filename.ToLower().Contains(Dwg_Num_excel.ToLower) Then
									Native_Folder_excel = filename
									FoundFolder = True
									Exit For
								End If
							Next
						End If
					End If
				End If
			End If

			If Native_Folder_excel = "Can't Locate Native File Path" Then

				If FirstGenStatus = True Then
					Dim FirstPath = IO.Path.Combine(Native_Dir, "FIRST GENERATION DOCUMENTS", FirstGenFolderNum, FirstGenDWGNum)

					If Directory.Exists(FirstPath) Then

						Native_Folder = FirstPath & "\" & PDF_Name
						Native_File = FirstPath & "\" & Dwg_Num_excel
						Native_File_Long = FirstPath & "\" & PDF_Name

						If Directory.Exists(Native_Folder) Then
							Native_Folder_excel = Native_Folder

						ElseIf File.Exists(Native_File + ".dwg") Then
							Native_Folder_excel = Native_File + ".dwg"

						ElseIf File.Exists(Native_File_Long + ".dwg") Then
							Native_Folder_excel = Native_File_Long + ".dwg"

						ElseIf File.Exists(Native_File + ".doc") Then
							Native_Folder_excel = Native_File + ".doc"

						ElseIf File.Exists(Native_File + ".docx") Then
							Native_Folder_excel = Native_File + ".docx"

						ElseIf File.Exists(Native_File_Long + ".doc") Then
							Native_Folder_excel = Native_File_Long + ".doc"

						ElseIf File.Exists(Native_File_Long + ".docx") Then
							Native_Folder_excel = Native_File_Long + ".docx"

						End If
					End If
				End If
			End If

			If Native_Folder_excel = "Can't Locate Native File Path" Then

				If SecondGenStatus = True Then

					If Directory.Exists(Native_Dir & "\SECOND GENERATION DOCUMENTS\" & SecondGenFolderNum) Then

						Dim secGenFolder = IO.Path.Combine(Native_Dir, "SECOND GENERATION DOCUMENTS", SecondGenFolderNum, Dwg_Num_excel)

						If File.Exists(secGenFolder & ".dwg") Then 'Native_File + ".dwg") OrElse File.Exists(Native_File_Long + ".dwg") Then
							Native_Folder_excel = secGenFolder & ".dwg"

						ElseIf File.Exists(secGenFolder & ".doc") Then
							Native_Folder_excel = secGenFolder & ".doc"

						ElseIf File.Exists(secGenFolder & ".docx") Then
							Native_Folder_excel = secGenFolder & ".docx"

						ElseIf Directory.Exists(Native_Dir & "\SECOND GENERATION DOCUMENTS\" & SecondGenFolderNum & "\" & Dwg_Num_excel) Then
							Native_Folder_excel = secGenFolder

						Else
							For Each folder In System.IO.Directory.GetDirectories(Native_Dir & "\SECOND GENERATION DOCUMENTS\" & SecondGenFolderNum)
								Native_Folder = folder & "\" & PDF_Name
								Native_File = folder & "\" & Dwg_Num_excel
								Native_File_Long = folder & "\" & PDF_Name
								If Directory.Exists(Native_Folder) Then

									Native_Folder_excel = Native_Folder
									Exit For
								ElseIf File.Exists(Native_File + ".dwg") Then

									Native_Folder_excel = Native_File + ".dwg"
									Exit For
								ElseIf File.Exists(Native_File_Long + ".dwg") Then

									Native_Folder_excel = Native_File_Long + ".dwg"
									Exit For
								ElseIf File.Exists(Native_File + ".doc") Then

									Native_Folder_excel = Native_File + ".doc"
									Exit For
								ElseIf File.Exists(Native_File + ".docx") Then

									Native_Folder_excel = Native_File + ".docx"
									Exit For
								ElseIf File.Exists(Native_File_Long + ".doc") Then

									Native_Folder_excel = Native_File_Long + ".doc"
									Exit For
								ElseIf File.Exists(Native_File_Long + ".docx") Then

									Native_Folder_excel = Native_File_Long + ".docx"
									Exit For
								End If
							Next
						End If
					End If
				End If
			End If

			Functions.Document_Directory.Add(New Struct_Docs(PDF_Name, Manufacturer_excel, AC_Type_excel, Serial_Num_excel, Dwg_Num_excel, Title_excel,
																  mfg_dir, Native_Folder_excel))
		Next

	End Sub

	Public Shared Function MFGtoBackup(ByVal mfg As String, ByVal eng_department As String) 'Public Shared Function

		Dim mfg_dir = IO.Path.Combine(Network_Locations.Aircraft_Data_Dir, mfg)
		Dim Native_Dir = Network_Locations.Native_Documents_Dir
		Dim AC_Type As String
		Dim AC_Serial_Num As String
		Dim StructPath As String

		For Each AC_Type In System.IO.Directory.GetDirectories(mfg_dir)
			For Each AC_Serial_Num In System.IO.Directory.GetDirectories(AC_Type)
				If Directory.Exists(AC_Serial_Num + "\" + eng_department) Then
					StructPath = AC_Serial_Num + "\" + eng_department
					Add_To_Doc_List(StructPath, Native_Dir)

				ElseIf Directory.Exists(AC_Serial_Num + "\STRUCTURAL") Then
					StructPath = AC_Serial_Num + "\STRUCTURAL"
					Add_To_Doc_List(StructPath, Native_Dir)
				End If
			Next
		Next

		If Functions.Document_Directory.Count > 0 Then

			For i = 0 To Functions.Document_Directory.Count - 1
				Debug.Print(Functions.Document_Directory(i).PDF_Name &
									" - " & Functions.Document_Directory(i).PDF_Name &
									" - " & Functions.Document_Directory(i).Manufacturer &
									" - " & Functions.Document_Directory(i).Aircraft_Type &
									" - " & Functions.Document_Directory(i).Serial_Number &
									" - " & Functions.Document_Directory(i).Drawing_Num &
									" - " & Functions.Document_Directory(i).Title &
									" - " & Functions.Document_Directory(i).PDF_Path &
									" - " & Functions.Document_Directory(i).Native_Path)
			Next

			Functions.Write_To_Excel_Arrays(eng_department)

		End If
		Functions.Document_Directory.Clear()

		Return True
	End Function

	Public Shared Function Write_To_Excel_Arrays(ByVal eng_department As String)
		Dim xlApp As Microsoft.Office.Interop.Excel.Application
		Dim workbook As Microsoft.Office.Interop.Excel.Workbook
		Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet
		Dim Range As Microsoft.Office.Interop.Excel.Range
		Dim Col_Start = 2
		Dim Row_Start = 5
		Dim Doc_Count As Integer = 0
		Dim Path As String = Network_Locations.Excel_Database_Path
		Dim To_Excel(Document_Directory.Count - 1, 7) As String

		If eng_department = "STRUCTURES" Then
			eng_department = "STRUCTURAL"
		ElseIf eng_department = "ELECTRICAL" Then

		End If

		Dim Ex_File As String = Document_Directory(0).Manufacturer + " - " + eng_department + " DATA LIST.xlsm"
		Dim Ex_Path As String = IO.Path.Combine(Path, Ex_File)
		Dim TimeNow As DateTime = DateTime.Now
		Dim format As String = "MMM-dd-yyyy"

		For i = 0 To Document_Directory.Count - 1
			To_Excel(Doc_Count, 0) = Document_Directory(i).PDF_Name
			To_Excel(Doc_Count, 1) = Document_Directory(i).Manufacturer
			To_Excel(Doc_Count, 2) = Document_Directory(i).Aircraft_Type
			To_Excel(Doc_Count, 3) = Document_Directory(i).Serial_Number
			To_Excel(Doc_Count, 4) = Document_Directory(i).Drawing_Num
			To_Excel(Doc_Count, 5) = Document_Directory(i).Title
			To_Excel(Doc_Count, 6) = Document_Directory(i).PDF_Path
			To_Excel(Doc_Count, 7) = Document_Directory(i).Native_Path
			Doc_Count += 1
		Next

		xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
		workbook = xlApp.Workbooks.Open(Ex_Path)
		xlApp.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
		xlApp.Visible = False
		worksheet = workbook.Sheets(1)

		With worksheet
			Range = .Range(.Cells(Row_Start, Col_Start), .Cells(UBound(To_Excel, 1) - LBound(To_Excel, 1) + Row_Start,
															   UBound(To_Excel, 2) - LBound(To_Excel, 2) + Col_Start))
		End With

		Range.Value = To_Excel

		Path += TimeNow.ToString(format)

		If Not System.IO.Directory.Exists(Path) Then
			System.IO.Directory.CreateDirectory(Path)
		End If

		Path += "\" + Document_Directory(0).Manufacturer + " - " + eng_department + " DATA LIST.xlsm"

		xlApp.DisplayAlerts = False
		workbook.SaveAs(Path)
		xlApp.Quit()

		Return True
	End Function

	Public Shared Function Write_To_Excel_Elec()
		Dim xlApp As Microsoft.Office.Interop.Excel.Application
		Dim workbook As Microsoft.Office.Interop.Excel.Workbook
		Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet
		Dim Range As Microsoft.Office.Interop.Excel.Range
		Dim Col_Start = 2
		Dim Row_Start = 5
		Dim Doc_Count As Integer = 0

		Dim To_Excel(Document_Directory.Count - 1, 7) As String

		For i = 0 To Document_Directory.Count - 1

			To_Excel(Doc_Count, 0) = Document_Directory(i).PDF_Name
			To_Excel(Doc_Count, 1) = Document_Directory(i).Manufacturer
			To_Excel(Doc_Count, 2) = Document_Directory(i).Aircraft_Type
			To_Excel(Doc_Count, 3) = Document_Directory(i).Serial_Number
			To_Excel(Doc_Count, 4) = Document_Directory(i).Drawing_Num
			To_Excel(Doc_Count, 5) = Document_Directory(i).Title
			To_Excel(Doc_Count, 6) = Document_Directory(i).PDF_Path
			To_Excel(Doc_Count, 7) = Document_Directory(i).Native_Path

			Doc_Count += 1
		Next

		xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass

		workbook = xlApp.Workbooks.Open(Network_Locations.Excel_Database_Path + "Electrical\" +
										Document_Directory(0).Manufacturer + " - ELECTRICAL DATA LIST.xlsm")

		xlApp.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
		xlApp.Visible = False

		worksheet = workbook.Sheets(1)

		With worksheet
			Range = .Range(.Cells(Row_Start, Col_Start), .Cells(UBound(To_Excel, 1) - LBound(To_Excel, 1) + Row_Start,
															   UBound(To_Excel, 2) - LBound(To_Excel, 2) + Col_Start))
		End With
		Range.Value = To_Excel

		xlApp.DisplayAlerts = False
		workbook.Save()
		xlApp.Quit()

		Return True
	End Function

End Class
