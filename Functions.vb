Public Class Functions

	Public Shared Status As Boolean = False
	Public Shared Calling_Fun As String

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
		Dim Output_Dec As Decimal
		'Dim Output_Txt As String

		If Valid_Input = "Integer" Then
			If Integer.TryParse(Txt.Text, Output_Int) Then
				Return Output_Int
			End If
		End If

		If Valid_Input = "Decimal" Then
			If Decimal.TryParse(Txt.Text, Output_Dec) Then
				Return Output_Dec
			End If
		End If

		'Redundant statement
		'If Valid_Input = "String" Then
		'	Output_Txt = Txt.Text
		'	Return Output_Txt
		'End If

		Error_Form("Incorrect input", Txt_Desc & " is not a number",, "Clearing text input",,, CurrentControl)
		Txt.Clear()
		Txt.Focus()

		'If Input_Validate(Txt.Text, Valid_Input) = 0 Then
		'	Error_Form("Incorrect input", "Box weight is not a number",, "Clearing text input",,, CurrentControl)
		'	Txt.Clear()
		'	Txt.Focus()
		'End If

		Return 0

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

	'Public Shared Function Write_to_Excel()


	'End Function

End Class
