Imports SwConst
'Imports SwCommandsSHEET_Template
Imports SldWorks
Imports System.IO

Public Class New_Drawing

	Dim swApp As SldWorks.SldWorks
	Dim swDraw As DrawingDoc
	Dim swDoc As ModelDoc2
	Dim CurDoc As ModelDoc2
	Dim swSheet As Sheet
	Dim CusProperties As CustomPropertyManager
	Dim CusProperties_Part As CustomPropertyManager
	Dim CusProperties_Assy As CustomPropertyManager
	Dim swModelDocExt As ModelDocExtension
	Dim swModelDocExt_Part As ModelDocExtension
	Dim swModelDocExt_Assy As ModelDocExtension
	Dim Bool_Result As Boolean
	Dim PC_USER As String = System.Environment.UserName
	Dim FullPathName As String
	Dim swView As View
	Dim annotations As Object
	Dim User_Saved As Boolean = False
	Dim Add_Sheet_Count As Integer = 3
	Dim Sheet_Count As Integer = 0
	Dim Drawing_Name_Saved As String
	Dim Add_Bom As Boolean = False
	Dim Clicked As Boolean = False
	Dim Title_ As String

	Dim Aircraft_Num As String
	Dim Add_View_Page As Integer
	Dim Opened_Files_Names As New List(Of String)

	Dim Part_Count As Integer = 0
	Dim Assy_Count As Integer = 0
	Dim Same_Page As Boolean = False

	'Dim Instance_list As New List(Of String)()
	Dim InstanceID_Added As Boolean = False
	Dim Main_Assy_Name As String
	Dim swFiles As New List(Of SW_Opened_Files)()

	Structure SW_Opened_Files
		Public Parent As String
		Public Child As String
		Public Instance_ID As String


		Public Sub New(s1 As String, s2 As String, s3 As String)
			Parent = s1
			Child = s2
			Instance_ID = s3

		End Sub
	End Structure


	Private Sub Form_Resize() Handles Me.ResizeEnd
		Functions.Form_resize(Me)
	End Sub

	Public Sub New_Drawing_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Reload.Click

		Dim PC_USER As String = System.Environment.UserName
		Dim Start_Char As String


		SWFunctions.swAssy_Docs.Clear()
		SWFunctions.swPart_Docs.Clear()
		SWFunctions.swDwg_Docs.Clear()

		Title_ = Me.Text
		Me.Height = 250

		Form_Resize()

		Opened_ASSY.Visible = False
		Opened_ASSY.Items.Clear()
		Opened_Part.Visible = False
		Opened_Part.Items.Clear()

		Same_Parts_Page_Checkbox.Checked = False
		Same_Assy_Page_Checkbox.Checked = False
		Same_Parts_Page_Checkbox.Visible = False
		Same_Assy_Page_Checkbox.Visible = False

		Notes_Groups.Visible = True
		Add_BOM_Hardware.Visible = True
		File_Rename_Checkbox.Visible = True
		Instructions_Label.Visible = False

		Clicked = False
		Title.Enabled = True
		AC_Serial.Enabled = True
		Request.Enabled = True
		Drawing_Num.Enabled = True

		For Each Folder In System.IO.Directory.GetDirectories(Network_Locations.ALN_ENG_DIR)

			'Dim file = String.Empty
			Dim File_name As String = System.IO.Path.GetFileNameWithoutExtension(Folder)
			Start_Char = File_name.Substring(0, 4)

			If Start_Char = "BOMB" Or Start_Char = "CESS" Or Start_Char = "CANA" Or
				Start_Char = "EMBR" Or Start_Char = "FALC" Or Start_Char = "GULF" Or
				Start_Char = "HAWK" Or Start_Char = "ISRA" Or Start_Char = "LEAR" Or
				Start_Char = "PIAG" Or Start_Char = "PILA" Or Start_Char = "TEXT" Then

				Dim AC_Doc_Name As String = File_name.Substring(0, (File_name.LastIndexOf("-")))

				AC_Serial.Items.Add(System.IO.Path.GetFileNameWithoutExtension(AC_Doc_Name))
			Else

			End If

		Next

	End Sub

#Region "Non used functions"

	'Sub TraverseComponent(ByVal swComp As Component2, ByVal nLevel As Integer)

	'Dim vChildComp As Object
	'Dim swChildComp As Component2
	'Dim swParent As Component2
	'Dim Parent As String ' = "N/A"
	'Dim Instance_Text As String = "N/A"
	'Dim Temp_Parent As String = "N/A"
	'Dim Temp_Instance As String = "N/A"
	'Dim sPadStr As String = ""
	'Dim i As Integer
	'Dim ChartoTrim As Char() = {"-"}
	'Dim Status As Boolean = False
	'Dim Add_To_Struct As Boolean = False
	'Dim swPart As ModelDoc2
	'Dim swPart3 As ModelDoc2
	'Dim errorval As Integer
	'Dim ValOut = String.Empty
	'Dim Dash_XX = String.Empty
	'Dim wasResolved As Boolean
	'Dim linkToProp As Boolean
	'Dim Dash_Name = String.Empty
	'Dim Temp_Name = String.Empty

	'Dim Count As Integer = swFiles.Count
	'If nLevel = 1 Then
	'	swFiles.Clear()
	'End If

	'For i = 0 To nLevel - 1
	'	sPadStr = sPadStr + "  "
	'Next i
	'vChildComp = swComp.GetChildren
	'For i = 0 To UBound(vChildComp)
	'	swChildComp = vChildComp(i)
	'	If swChildComp.IsSuppressed() = False Then

	'		swParent = swChildComp.GetParent
	'		Add_To_Struct = False
	'		If swParent Is Nothing Then

	'			swPart = swChildComp.GetModelDoc2
	'			Parent = swChildComp.Name2
	'			If Parent.Substring(0, Parent.IndexOf("-")) <> "" Then
	'				Parent = Parent.Substring(0, Parent.IndexOf("-"))
	'			End If

	'			swPart3 = swApp.ActivateDoc3(Parent, 0, 1, errorval)
	'			swModelDocExt_Part = swPart3.Extension
	'			CusProperties_Part = swModelDocExt_Part.CustomPropertyManager("")
	'			Dash_Name = CusProperties_Part.Get6("PART NUMBER", True, ValOut, Dash_XX, wasResolved, linkToProp)

	'			If Dash_Name = 2 Then
	'				If Dash_XX <> "" And Dash_XX <> "-XX" Then

	'					Temp_Name = Dash_XX.Substring(0, 1)

	'					If Temp_Name = "-" Then
	'						Add_To_Struct = True
	'					End If
	'				End If

	'			End If
	'			swApp.CloseDoc(Parent)

	'		Else
	'			swPart = swParent.GetModelDoc2
	'			Parent = swParent.Name2.Substring(0, swParent.Name2.IndexOf("-"))
	'			Instance_Text = swChildComp.Name2

	'			If Instance_Text.IndexOf("/") > 0 Then

	'				Instance_Text = Instance_Text.Remove(0, Instance_Text.IndexOf("/") + 1)
	'				Temp_Parent = Instance_Text.Substring(0, Instance_Text.LastIndexOf("-"))


	'				If Instance_Text.LastIndexOf("-") <> -1 Then
	'					Temp_Parent = Instance_Text.Substring(0, Instance_Text.LastIndexOf("-"))
	'					If Temp_Parent.IndexOf("/") > 0 Then
	'						Temp_Parent = Temp_Parent.Remove(0, Temp_Parent.IndexOf("/") + 1)
	'					End If
	'				End If

	'				Instance_Text = Instance_Text.Remove(0, Instance_Text.IndexOf("/") + 1)
	'				If Temp_Parent = Parent Then
	'					Temp_Parent = "N/A"
	'				End If
	'			End If

	'			swPart3 = swApp.ActivateDoc3(Temp_Parent, 0, 1, errorval)
	'			swModelDocExt_Part = swPart3.Extension
	'			CusProperties_Part = swModelDocExt_Part.CustomPropertyManager("")
	'			Dash_Name = CusProperties_Part.Get6("PART NUMBER", True, ValOut, Dash_XX, wasResolved, linkToProp)

	'			If Dash_Name = 2 Then
	'				If Dash_XX <> "" And Dash_XX <> "-XX" Then

	'					Temp_Name = Dash_XX.Substring(0, 1)

	'					If Temp_Name = "-" Then
	'						Add_To_Struct = True
	'					End If
	'				End If

	'			End If
	'			swApp.CloseDoc(Temp_Parent)

	'		End If

	'		If Add_To_Struct = True Then


	'			If swFiles.Count = 0 Then
	'				swFiles.Add(New SW_Opened_Files(Parent, Instance_Text, swChildComp.GetSelectByIDString()))
	'			Else
	'				Status = False
	'				Dim j As Integer = 0
	'				While j < swFiles.Count

	'					If swFiles(j).Parent = Parent Then

	'						For k = 0 To swFiles.Count - 1
	'							If swFiles(k).Child = Temp_Parent Then
	'								Status = True
	'								Exit While
	'							ElseIf swFiles(k).Child = Instance_Text Then
	'								Status = True
	'								Exit While
	'							ElseIf swFiles(k).Parent = Temp_Parent Then
	'								Status = True
	'								Exit While
	'							ElseIf swFiles(k).Parent = Instance_Text Then
	'								Status = True
	'								Exit While
	'							End If
	'						Next
	'					End If
	'					j += 1

	'					If j = swFiles.Count Then
	'						Status = False
	'						Exit While
	'					End If
	'				End While

	'				If Status = False And Add_To_Struct = True Then

	'					If Temp_Parent = "N/A" Then
	'						swFiles.Add(New SW_Opened_Files(Parent, Instance_Text, swChildComp.GetSelectByIDString()))
	'					Else
	'						swFiles.Add(New SW_Opened_Files(Parent, Temp_Parent, swChildComp.GetSelectByIDString()))
	'					End If
	'				End If
	'			End If

	'		End If

	'	End If

	'	TraverseComponent(swChildComp, nLevel + 1)
	'Next i
	'End Sub

#End Region


	Private Sub Generate_Drawing_Click(sender As Object, e As EventArgs) Handles Generate_Drawing.Click

		Dim count As Integer
		'Dim index As Integer
		Dim Open_Docs As Object

		If Clicked = False Then

			Me.BackColor = SystemColors.InactiveCaption
			Me.Text = Title_ + " - Loading"

			If AC_Serial.SelectedItem <> Nothing Then

				Aircraft_Num = AC_Serial.SelectedItem
				Aircraft_Num = Aircraft_Num.Substring(Aircraft_Num.IndexOf(" ") + 1, (Aircraft_Num.Length) - (Aircraft_Num.IndexOf(" ") + 1))
			Else
				Aircraft_Num = AC_Serial.Text
			End If

			Notes_Groups.Visible = False
			Add_BOM_Hardware.Visible = False
			File_Rename_Checkbox.Visible = False

			Title.Enabled = False
			AC_Serial.Enabled = False
			Request.Enabled = False
			Drawing_Num.Enabled = False

			swApp = SWFunctions.swApp
			swDoc = swApp.ActiveDoc

			count = swApp.GetDocumentCount
			Open_Docs = swApp.GetDocuments

			If count = 0 Then
				Functions.Error_Form("No Documents", "There are no documents loaded",,,, False, Me)
			Else

				Dim swRootComp As Component2
				Dim swConfMgr As ConfigurationManager
				Dim swConf As Configuration

				swConfMgr = swDoc.ConfigurationManager
				swConf = swConfMgr.ActiveConfiguration
				swRootComp = swConf.GetRootComponent3(True) 'Top level Assy
				Main_Assy_Name = swRootComp.Name2

				If swDoc.GetType = swDocumentTypes_e.swDocASSEMBLY Then
					'SWFunctions.Rename_Files = True
					SWFunctions.Add_Docs2(swRootComp, 1)
					If SWFunctions.Rename_Files = True Then
						SWFunctions.Rename_Files_with_PN()
					End If

					SWFunctions.Out_Put("Ascending")
					'TraverseComponent(swRootComp, 1) original
					'SWFunctions.Add_Docs(swRootComp, 1)
					InstanceID_Added = True
					'For z = 0 To swFiles.Count - 1
					'	Debug.Print(swFiles(z).Parent & ", " & swFiles(z).Child & ", " & swFiles(z).Instance_ID)
					'Next
				End If

				'For index = LBound(Open_Docs) To UBound(Open_Docs)

				'	Dim swPart As PartDoc
				'	Dim swAssy As AssemblyDoc

				'	swDoc = Open_Docs(index)



				'	FullPathName = swDoc.GetPathName()
				'	If FullPathName = "" Then

				'	Else
				'		Name = SWFunctions.SW_FileName(FullPathName)

				'		If swDoc.GetType = 2 Then 'Assembly file

				'			Dim ValOut = String.Empty
				'			Dim Dash_XX = String.Empty
				'			Dim wasResolved As Boolean
				'			Dim linkToProp As Boolean
				'			Dim Dash_Name = String.Empty
				'			Dim Temp_Name = String.Empty

				'			swAssy = Open_Docs(index)


				'			swModelDocExt_Assy = swAssy.Extension
				'			CusProperties_Assy = swModelDocExt_Assy.CustomPropertyManager("")
				'			Dash_Name = CusProperties_Assy.Get6("PART NUMBER", True, ValOut, Dash_XX, wasResolved, linkToProp)

				'			If Dash_Name = 2 Then
				'				If Dash_XX <> "" And Dash_XX <> "-XX" Then


				'					Temp_Name = Dash_XX.Substring(0, 1)
				'					If Temp_Name = "-" Then
				'						'Opened_ASSY.Items.Add(Name)
				'						Opened_ASSY.Items.Add(Dash_XX & " " & Name)
				'						Opened_Files_Names.Add(Name)
				'					End If
				'				End If

				'				'Opened_Part.Items.Add(Dash_XX & "-" & Name)
				'			End If

				'			'If InstanceID_Added = False Then
				'			'	'Stole from API site
				'			'	Dim swModel As ModelDoc2
				'			'	Dim swConfMgr As ConfigurationManager
				'			'	Dim swConf As Configuration
				'			'	Dim swRootComp As Component2

				'			'	swModel = swApp.ActiveDoc
				'			'	swConfMgr = swModel.ConfigurationManager
				'			'	swConf = swConfMgr.ActiveConfiguration
				'			'	swRootComp = swConf.GetRootComponent3(True) 'Top level Assy
				'			'	Main_Assy_Name = swRootComp.Name2
				'			'	If swModel.GetType = swDocumentTypes_e.swDocASSEMBLY Then
				'			'		TraverseComponent(swRootComp, 1)
				'			'		InstanceID_Added = True
				'			'	End If
				'			'End If

				'			'Opened_ASSY.Items.Add(Name)
				'			'Don't sore the Assemblies so the TOP LEVEL ASSY will be on top
				'			Functions.SortListBox(Opened_ASSY, 0)

				'		ElseIf swDoc.GetType = 1 Then 'Part file

				'			Dim ValOut = String.Empty
				'			Dim Dash_XX = String.Empty
				'			Dim wasResolved As Boolean
				'			Dim linkToProp As Boolean
				'			Dim Dash_Name = String.Empty
				'			Dim Temp_Name = String.Empty

				'			swPart = Open_Docs(index)

				'			swModelDocExt_Part = swPart.Extension
				'			CusProperties_Part = swModelDocExt_Part.CustomPropertyManager("")
				'			Dash_Name = CusProperties_Part.Get6("PART NUMBER", True, ValOut, Dash_XX, wasResolved, linkToProp)

				'			'MsgBox(Name & " 1")
				'			'MsgBox(ValOut & " 2")
				'			'MsgBox(wasResolved & " 3")
				'			'MsgBox(linkToProp & " 4")
				'			'MsgBox(Dash_Name & " 5")
				'			'MsgBox(Dash_XX & " 6")



				'			If Dash_Name = 2 Then
				'				If Dash_XX <> "" And Dash_XX <> "-XX" Then


				'					Temp_Name = Dash_XX.Substring(0, 1)
				'					If Temp_Name = "-" Then
				'						Opened_Part.Items.Add(Dash_XX & " " & Name)
				'						Opened_Files_Names.Add(Name)
				'						'Opened_Part.Items.Add(Name)
				'					End If
				'				End If

				'				'Opened_Part.Items.Add(Dash_XX & "-" & Name)
				'			End If

				'			'Else
				'			'	Opened_Part.Items.Add(Name)
				'			'End If

				'			'Opened_Part.Items.Add(Name)
				'			Functions.SortListBox(Opened_Part, 0)

				'		End If
				'	End If
				'Next

				''For i = 0 To swFiles.Count - 1
				''	Debug.Print(swFiles(i).Parent & System.Environment.NewLine & "- , " & swFiles(i).Child & " , " & swFiles(i).Instance_ID)
				''Next

				'Opened_ASSY.Visible = True

				'Opened_Part.Visible = True

				'Me.Height = Height + 115

			End If

			Me.BackColor = SystemColors.Window
			Me.Text = Title_

			Instructions_Label.Visible = True
			Instructions_Label.Clear()
			Instructions_Label.SelectedText = "Start by adding the ASSY:" & System.Environment.NewLine
			Instructions_Label.SelectionBullet = True
			Instructions_Label.SelectedText = "Double click the ASSY" & System.Environment.NewLine
			Instructions_Label.SelectedText = "Save the Doc" & System.Environment.NewLine
			Instructions_Label.SelectedText = "Double click the Parts"
			Instructions_Label.SelectionBullet = False

			Clicked = True

		End If

	End Sub

	Private Sub Opened_ASSY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Opened_ASSY.DoubleClick

		Dim count As Integer
		Dim index As Integer
		Dim Open_Docs As Object
		Dim Sheet_name As String
		Dim Sheet_Num As String
		Dim Last_Sheet As String
		Dim swSheetNames As Object
		Dim Same_Page As Boolean = False
		Dim Boundary_Box_Size As Double() = {0.0, 0.0, 0.0, 0.0}
		Dim Scale_Factor As Double
		Dim Prop_Name As String

		Dim i As Integer
		Dim status As Boolean
		Dim View_Count As Integer


		Dim sw_View As View
		Dim swAssy As AssemblyDoc

		Dim View_Name = String.Empty
		Dim First_View_Name = String.Empty
		Dim ValOut = String.Empty
		Dim ResolvedValOut = String.Empty
		Dim wasResolved As Boolean
		Dim linkToProp As Boolean

		Dim File_Name As String

		'Dim File_Name As String = Opened_ASSY.Text
		If Assy_Count = 0 Then
			File_Name = SWFunctions.swAssy_Docs(Assy_Count).Comp
		Else
			File_Name = SWFunctions.swAssy_Docs(Assy_Count).subcomp
		End If


		Drawing_Name_Saved = swDoc.GetPathName()

		Prop_Name = File_Name.Substring(0, 1)
		'MsgBox(Prop_Name)

		If Prop_Name = "-" Then
			File_Name = File_Name.Substring(File_Name.IndexOf(" ") + 1)
		End If

		swApp.ActivateDoc(File_Name)
		'If InstanceID_Added = False Then
		'Stole from API site
		Dim swModel As ModelDoc2
		Dim swConfMgr As ConfigurationManager
		Dim swConf As Configuration
		Dim swRootComp As Component2

		swModel = swApp.ActiveDoc
		swConfMgr = swModel.ConfigurationManager
		swConf = swConfMgr.ActiveConfiguration
		swRootComp = swConf.GetRootComponent3(True) 'Top level Assy
		Main_Assy_Name = swRootComp.Name2
		If User_Saved = False Then

			'''''Moved this section to Generate Drawing.click

			'If swModel.GetType = swDocumentTypes_e.swDocASSEMBLY Then
			'	SWFunctions.Rename_Files = True
			'   SWFunctions.Add_Docs2(swRootComp, 1)
			'	SWFunctions.Rename_Files_with_PN()
			'	SWFunctions.Out_Put()
			'	'TraverseComponent(swRootComp, 1) original
			'	'SWFunctions.Add_Docs(swRootComp, 1)
			'	InstanceID_Added = True
			'	'For z = 0 To swFiles.Count - 1
			'	'	Debug.Print(swFiles(z).Parent & ", " & swFiles(z).Child & ", " & swFiles(z).Instance_ID)
			'	'Next
			'End If
		End If
		'End If

		'For i = 0 To swFiles.Count - 1
		'	Debug.Print(swFiles(i).Parent & System.Environment.NewLine & "- , " & swFiles(i).Child & " , " & swFiles(i).Instance_ID)
		'Next




		Functions.Status = True



		swAssy = swApp.ActiveDoc

		swModelDocExt_Assy = swAssy.Extension
		CusProperties_Assy = swModelDocExt_Assy.CustomPropertyManager("")
		View_Name = CusProperties_Assy.Get6("NOTE INFO", True, ValOut, ResolvedValOut, wasResolved, linkToProp)

		'Update Drawing Number on Assembly File
		Draw_Num_Update()

		FullPathName = swDoc.GetPathName()

		'Checks if drawing document has been saved previously
		If User_Saved = False Then

			Open_New_Draw()

		Else

			Same_Assy_Page_Checkbox.Visible = True

			If Same_Assy_Page_Checkbox.Checked = True Then
				Same_Page = True
				Add_View_Page += 1
			Else
				Same_Page = False
				Add_View_Page = 0
			End If

			count = swApp.GetDocumentCount
			Open_Docs = swApp.GetDocuments

			For index = LBound(Open_Docs) To UBound(Open_Docs)
				swDoc = Open_Docs(index)
				FullPathName = swDoc.GetPathName()
				Name = SWFunctions.SW_FileName(FullPathName)

				If swDoc.GetType = 3 Then
					Name = SWFunctions.SW_FileName(FullPathName)
					swApp.ActivateDoc(Name)

				End If
			Next

		End If

		Add_Sheet_Count = swDraw.GetSheetCount
		swSheet = swDraw.GetCurrentSheet

		swSheetNames = swDraw.GetSheetNames
		Last_Sheet = swSheetNames(UBound(swSheetNames))

		If Same_Page = False Then

			If swSheet.GetName = Last_Sheet Then

				Add_Sheet_Count += 1
				Sheet_Num = Add_Sheet_Count.ToString
				Sheet_name = "Sheet" + Sheet_Num
				swDraw.NewSheet3(Sheet_name, 12, 12, 1, 1, False, Network_Locations.SW_AddSheet_Temp, 0, 0, "")
				swDraw.ActivateSheet(Sheet_name)

			Else
				swDraw.SheetNext()
			End If

		End If

		sw_View = swDraw.GetFirstView
		First_View_Name = sw_View.Name

		If ResolvedValOut <> "" Then

			Bool_Result = swDraw.Create3rdAngleViews2(File_Name)

			sw_View = sw_View.GetNextView
			If Same_Page = True Then

				View_Count = Add_View_Page * 3
				For i = 0 To View_Count - 1 '2
					sw_View = sw_View.GetNextView
				Next
				Dim View_Position As Double() = {0.4318, 0.1143}
				sw_View.Position = View_Position
			End If
			sw_View.SetName2(ResolvedValOut)
			Boundary_Box_Size = sw_View.GetOutline()

		Else
			Bool_Result = swDraw.Create3rdAngleViews2(File_Name)
		End If

		Dim sw_view1 As View = Nothing
		Dim sw_view2 As View = Nothing
		Dim sw_view3 As View = Nothing

		If Same_Page = False Then

			swDraw.ActivateView(ResolvedValOut)
			'Error gets thrown when the view name has been used already
			'can be on the same sheet or a different sheet
			'logic to check all views and names and rename the view if it's already used on a different sheet
			sw_view1 = swDraw.ActiveDrawingView
		End If
		If sw_view1 Is Nothing Then
			sw_view1 = swDraw.GetFirstView
			sw_view1 = sw_view1.GetNextView
			If Same_Page = True Then
				For j = 0 To View_Count - 1
					sw_view1 = sw_view1.GetNextView
				Next

			End If
		End If

		sw_view2 = sw_view1.GetNextView()
		If sw_view1.Name = ResolvedValOut Then
			sw_view2.SetName2(ResolvedValOut & " - TOP")
		End If

		sw_view3 = sw_view2.GetNextView()
		If sw_view1.Name = ResolvedValOut Then
			sw_view3.SetName2(ResolvedValOut & " - RIGHT")
		End If

		Scale_Factor = SWFunctions.View_Scale(sw_view1.GetOutline(), sw_view2.GetOutline(), sw_view3.GetOutline())

		sw_View.ScaleRatio() = {1, Scale_Factor}

		status = swDraw.ActivateView(ResolvedValOut)
		annotations = swDraw.InsertModelAnnotations3(0, 64, True, False, False, True)

		Dim Open_Doc_Names As New List(Of String)()

		For i = 0 To Opened_ASSY.Items.Count - 1
			Open_Doc_Names.Add(Opened_ASSY.Items(i))
		Next
		For j = 0 To Opened_Part.Items.Count - 1
			Open_Doc_Names.Add(Opened_Part.Items(j))
		Next

		If Same_Page = False And User_Saved = False Then
			SWFunctions.Add_NoteInfo2(swDoc, ResolvedValOut, File_Name, SWFunctions.swAssy_Docs, SWFunctions.swPart_Docs, Add_BOM_Hardware.Checked)
			'SWFunctions.Add_NoteInfo2(swDoc, ResolvedValOut, File_Name, swFiles, Add_BOM_Hardware.Checked)
		End If
		''''''''''''''''
		'MsgBox(Add_BOM_Hardware.Checked)
		If User_Saved = False Then

			SWFunctions.Save_Doc()

		End If

		Drawing_Name_Saved = swDoc.GetPathName()

		Dim Second_Warning As Integer = 1

		While Drawing_Name_Saved = "" And Second_Warning < 2

			User_Saved = False
			Functions.Error_Form("Save The File", "Please Save The Drawing File",,,, False, Start_Window)
			'''''''''''''''''''''''''''''''
			'SWFunctions.Save_Doc()
			Drawing_Name_Saved = swDoc.GetPathName()
			Second_Warning += 1

		End While

		If Drawing_Name_Saved <> "" Then
			User_Saved = True

		End If

		swDoc.ForceRebuild3(True)

		swApp.CloseDoc(File_Name)
		Same_Assy_Page_Checkbox.Checked = False

		Assy_Count += 1

	End Sub

	Private Sub Opened_Part_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Opened_Part.DoubleClick

		Dim count As Integer
		Dim index As Integer
		Dim Open_Docs As Object
		Dim Sheet_Name As String
		Dim Sheet_Num As String
		Dim Last_Sheet As String
		Dim swSheetNames As Object

		Dim Boundary_Box_Size As Double() = {0.0, 0.0, 0.0, 0.0}
		Dim Scale_Factor As Double
		Dim File_Extension As String
		Dim Prop_Name As String

		Dim sw_View As View
		Dim swPart As PartDoc
		'Dim swDoc As ModelDoc2
		'Dim swExtension As ModelDocExtension

		Dim View_Name = String.Empty
		Dim View_Count As Integer

		Dim ValOut = String.Empty
		Dim ResolvedValOut = String.Empty
		Dim wasResolved As Boolean
		Dim linkToProp As Boolean


		'Dim Status As Boolean

		'Dim File_Name As String = Opened_Part.Text
		Dim File_Name As String = SWFunctions.swPart_Docs(Part_Count).subcomp

		Drawing_Name_Saved = swDoc.GetPathName()

		Prop_Name = File_Name.Substring(0, 1)
		'MsgBox(Prop_Name)

		'If Prop_Name = "-" Then
		'	File_Name = File_Name.Substring(File_Name.IndexOf(" ") + 1)
		'End If




		'File_Name = File_Name.Remove(0, File_Name.LastIndexOf(" ") + 1)
		'MsgBox(File_Name)

		swApp.ActivateDoc(File_Name)

		swPart = swApp.ActiveDoc

		swModelDocExt_Part = swPart.Extension
		CusProperties_Part = swModelDocExt_Part.CustomPropertyManager("")
		View_Name = CusProperties_Part.Get6("NOTE INFO", True, ValOut, ResolvedValOut, wasResolved, linkToProp)

		Draw_Num_Update()

		FullPathName = swDoc.GetPathName()

		File_Extension = SWFunctions.SW_Extension(FullPathName)

		If Drawing_Name_Saved <> "" Then
			If File_Extension = ".SLDDRW" Then
				User_Saved = True
			ElseIf File_Extension <> ".SLDDRW" Then
				User_Saved = False
				Functions.Error_Form("Drawing not saved", "Please save the Part before continuing.",,,, False, Me)
				Exit Sub
			End If

		Else
			User_Saved = False
		End If

		If User_Saved = False Then
			Functions.Error_Form("Drawing not saved", "Please save the drawing before continuing.",,,, False, Me)
		Else

			'Open_New_Draw()

			Same_Parts_Page_Checkbox.Visible = True

			If Same_Page = True Then
				Add_View_Page += 1
			Else
				Add_View_Page = 0
			End If

			'If Same_Parts_Page_Checkbox.Checked = True Then
			'	Same_Page = True
			'	Add_View_Page += 1
			'Else
			'	Same_Page = False
			'	Add_View_Page = 0
			'End If

			count = swApp.GetDocumentCount
			Open_Docs = swApp.GetDocuments

			For index = LBound(Open_Docs) To UBound(Open_Docs)
				swDoc = Open_Docs(index)
				FullPathName = swDoc.GetPathName()
				Name = SWFunctions.SW_FileName(FullPathName)

				If swDoc.GetType = 3 Then
					Name = SWFunctions.SW_FileName(FullPathName)
					swApp.ActivateDoc(Name)

				End If
			Next

			'Call function to input drawing number into current file

			swDraw = swDoc

			swSheet = swDraw.GetCurrentSheet

			swSheetNames = swDraw.GetSheetNames
			Last_Sheet = swSheetNames(UBound(swSheetNames))

			If Same_Page = False Then

				If swSheet.GetName = Last_Sheet Then

					Add_Sheet_Count += 1
					Sheet_Num = Add_Sheet_Count.ToString
					Sheet_Name = "Sheet" + Sheet_Num
					swDraw.NewSheet3(Sheet_Name, 12, 12, 1, 1, False, Network_Locations.SW_AddSheet_Temp, 0, 0, "")
					swDraw.ActivateSheet(Sheet_Name)

				Else
					swDraw.SheetNext()

				End If

			End If


			sw_View = swDraw.GetFirstView

			If ResolvedValOut <> "" Then

				Bool_Result = swDraw.Create3rdAngleViews2(File_Name)

				sw_View = swDraw.GetFirstView
				sw_View = sw_View.GetNextView
				If Same_Page = True Then

					Dim SS As Object
					Dim VV As Object
					Dim SheetCount As Integer
					Dim Views As Integer

					SS = swDraw.GetViews
					For SheetCount = LBound(SS) To UBound(SS)

						VV = SS(SheetCount)

						For Views = LBound(VV) To UBound(VV)

						Next

					Next

					'View_Count = swDraw.GetViewCount - swDraw.GetSheetCount
					View_Count = Add_View_Page * 3
					'MsgBox(View_Count)
					For i = 0 To View_Count - 1
						sw_View = sw_View.GetNextView
					Next
					Dim View_Position As Double() = {0.4318, 0.1143}
					sw_View.Position = View_Position
				End If
				sw_View.SetName2(ResolvedValOut)
				Boundary_Box_Size = sw_View.GetOutline()

			Else
				Bool_Result = swDraw.Create3rdAngleViews2(File_Name)
			End If

			Dim sw_view1 As View = Nothing
			Dim sw_view2 As View = Nothing
			Dim sw_view3 As View = Nothing

			If Same_Page = False Then

				swDraw.ActivateView(ResolvedValOut)
				'Error gets thrown when the view name has been used already
				'can be on the same sheet or a different sheet
				'logic to check all views and names and rename the view if it's already used on a different sheet
				sw_view1 = swDraw.ActiveDrawingView
			End If
			If sw_view1 Is Nothing Then
				sw_view1 = swDraw.GetFirstView
				sw_view1 = sw_view1.GetNextView
				If Same_Page = True Then
					For j = 0 To View_Count - 1
						sw_view1 = sw_view1.GetNextView
					Next

				End If
			End If

			sw_view2 = sw_view1.GetNextView()
			If sw_view1.Name = ResolvedValOut Then
				sw_view2.SetName2(ResolvedValOut & " - TOP")
			End If

			sw_view3 = sw_view2.GetNextView()
			If sw_view1.Name = ResolvedValOut Then
				sw_view3.SetName2(ResolvedValOut & " - RIGHT")
			End If

			Scale_Factor = SWFunctions.View_Scale(sw_view1.GetOutline(), sw_view2.GetOutline(), sw_view3.GetOutline())

			sw_view1.ScaleRatio() = {1, Scale_Factor}

			annotations = swDraw.InsertModelAnnotations3(0, 32768, True, True, False, True) 'Inserts dimensions marked for drawing
			annotations = swDraw.InsertModelAnnotations3(0, 1048576, True, True, False, True) 'Inserts Hole Callout

			swDoc.ForceRebuild3(True)

			Part_Count += 1

		End If

		swApp.CloseDoc(File_Name)
		Same_Page = Not (Same_Page)
		'Same_Parts_Page_Checkbox.Checked = False

	End Sub

	Private Sub Add_BOM_Hardware_CheckedChanged(sender As Object, e As EventArgs) Handles Add_BOM_Hardware.CheckedChanged
		If Add_BOM_Hardware.Checked = True Then
			SWFunctions.Add_BOM = True
		ElseIf Add_BOM_Hardware.Checked = False Then
			SWFunctions.Add_BOM = False
		End If
	End Sub

	Private Sub Draw_Num_Update()
		If Drawing_Num.Text <> "Optional" Then

			CurDoc = swApp.ActiveDoc
			CusProperties = CurDoc.Extension.CustomPropertyManager("")
			CusProperties.Set2("DRAWING NUMBER", Drawing_Num.Text)

		End If
	End Sub

	Private Sub Open_New_Draw()

		Dim FolderName As String
		Dim swTitle As String
		Dim AC_Num As String
		Dim Drawings_Major As String
		Dim Folder_Check As String
		Dim Minor_Check As String
		Dim Structural As String
		Dim Note_Style As String = Nothing
		Dim Bool As Boolean

		Dim swAnnotation As Annotation
		Dim swNote As Note
		Dim swView As View
		Dim swLayerMgr As LayerMgr
		Dim Sheet1_Notes As Object

		swDoc = swApp.NewDocument(Network_Locations.SW_Draw_Temp, 0, 0, 0)
		swDraw = swDoc
		swModelDocExt = swDoc.Extension
		CusProperties = swModelDocExt.CustomPropertyManager("")

		FolderName = FullPathName.Remove(FullPathName.LastIndexOf("\"))
		Structural = Directory.GetParent(FolderName).FullName
		Drawings_Major = Directory.GetParent(Structural).FullName
		AC_Num = Directory.GetParent(Drawings_Major).FullName

		Folder_Check = Drawings_Major.Remove(0, Drawings_Major.LastIndexOf("\") + 1)
		Minor_Check = Structural.Remove(0, Structural.LastIndexOf("\") + 1)

		If Minor_Check = "(3) Drawings Minor" Then
			AC_Num = Directory.GetParent(Structural).FullName
		End If

		If Folder_Check = "(2) Drawings Major" Or Minor_Check = "(3) Drawings Minor" Then

			AC_Num = AC_Num.Remove(0, AC_Num.LastIndexOf("\") + 1)
			AC_Num = AC_Num.Remove(AC_Num.LastIndexOf("-"))
			AC_Serial.Text = AC_Num

			swTitle = FolderName.Remove(0, FolderName.LastIndexOf("\") + 1)
			Dim FN As String() = swTitle.Split(New String() {"("}, StringSplitOptions.None)
			swTitle = FN(1).Remove(FN(1).LastIndexOf(")"))
			Title.Text = swTitle

			CusProperties.Set2("TITLE", swTitle.ToUpper)
			CusProperties.Set2("AIRCRAFT & S/N", AC_Num.ToUpper)

		Else

			If Title.Text.ToString = "" Then
				Title.Text = "N/A"
				Title.Enabled = False
			Else
				CusProperties.Set2("TITLE", Title.Text.ToString.ToUpper)
				Title.Enabled = False
			End If

			If Aircraft_Num = "" Or Aircraft_Num = "Optional - Type your own" Or Aircraft_Num = "N/A" Then
				AC_Serial.Text = "N/A"
				AC_Serial.Enabled = False
			Else
				CusProperties.Set2("AIRCRAFT & S/N", Aircraft_Num.ToUpper)
				AC_Serial.Enabled = False
			End If

		End If

		If Request.Text.ToString = "" Then
			Request.Text = "N/A"
		Else
			CusProperties.Set2("RELEASED TO", Request.Text.ToString.ToUpper)
			CusProperties.Set2("REQUESTED BY", Request.Text.ToString.ToUpper)

		End If

		Select Case PC_USER
			Case ""
				PC_USER = ""
			
			Case Else
				PC_USER = ""
				Functions.Error_Form("User Name Error", "User Name not defined",, "Manually input Drawnby name",, False, Me)

		End Select

		CusProperties.Set2("DATE", DateTime.Now.ToString("MMM/dd/yyyy").ToUpper)
		CusProperties.Set2("DRAWN BY", PC_USER)
		CusProperties.Set2("CURRENT REV", "$PRP:""REV 1""")
		CusProperties.Set2("REV DESCRIPTION", "PRELIMINARY RELEASE")

		'Adding Notes to Sheet 1
		swDraw.ActivateSheet("Sheet1")
		If STD_Notes_CheckBox.Checked = True And Insert_Instl_CheckBox.Checked = True And Nutplate_Instl_CheckBox.Checked = True And Avionics_Instl_CheckBox.Checked = True Then

			Note_Style = "STD, Nutplate, Insert, Avionics"

		ElseIf STD_Notes_CheckBox.Checked = True And Insert_Instl_CheckBox.Checked = True And Nutplate_Instl_CheckBox.Checked = True Then

			Note_Style = "STD, Nutplate, Insert"

		ElseIf STD_Notes_CheckBox.Checked = True And Insert_Instl_CheckBox.Checked = True And Avionics_Instl_CheckBox.Checked = True Then

			Note_Style = "STD, Insert, Avionics"

		ElseIf STD_Notes_CheckBox.Checked = True And Nutplate_Instl_CheckBox.Checked = True And Avionics_Instl_CheckBox.Checked = True Then

			Note_Style = "STD, Nutplate, Avionics"

		ElseIf STD_Notes_CheckBox.Checked = True And Nutplate_Instl_CheckBox.Checked = True Then

			Note_Style = "STD, Nutplate"

		ElseIf STD_Notes_CheckBox.Checked = True And Insert_Instl_CheckBox.Checked = True Then

			Note_Style = "STD, Insert"

		ElseIf STD_Notes_CheckBox.Checked = True And Avionics_Instl_CheckBox.Checked = True Then

			Note_Style = "STD, Avionics"

		ElseIf STD_Notes_CheckBox.Checked = True Then

			Note_Style = "STD Note"

		End If

		swLayerMgr = swDoc.GetLayerManager

		If Note_Style IsNot Nothing Then

			swView = swDraw.GetFirstView
			Sheet1_Notes = swView.GetNotes


			For i = 0 To UBound(Sheet1_Notes)

				swNote = Sheet1_Notes(i)
				If swNote.GetName = "Drawing-Notes" Then



					'swNote.Visible = True

					swAnnotation = swNote.GetAnnotation

					swAnnotation.SetPosition2(1.15 / 39.3701, 9.75 / 39.3701, 0)
					swAnnotation.SetStyleName(Note_Style)
					swAnnotation.Visible = swAnnotationVisibilityState_e.swAnnotationVisible
					swAnnotation.Layer = "NOTES"


				End If

			Next

		End If
		Bool = swLayerMgr.SetCurrentLayer("-Per Standard-")
	End Sub

	Private Sub Add_All_Click(sender As Object, e As EventArgs) Handles Add_All.Click

		'Dim swModel As ModelDoc2
		'Dim swConfMgr As ConfigurationManager
		'Dim swConf As Configuration
		'Dim swRootComp As Component2

		'swModel = swApp.ActiveDoc
		'swConfMgr = swModel.ConfigurationManager
		'swConf = swConfMgr.ActiveConfiguration
		'swRootComp = swConf.GetRootComponent3(True) 'Top level Assy
		'Main_Assy_Name = swRootComp.Name2

		Generate_Drawing.PerformClick()

		For i = 0 To SWFunctions.swAssy_Docs.Count - 1 'Opened_ASSY.Items.Count - 1
			'Opened_ASSY.SetSelected(i, True)
			Opened_ASSY_SelectedIndexChanged(sender, e)
			'SWFunctions.Add_Docs(swRootComp, 1)

		Next

		For j = 0 To SWFunctions.swPart_Docs.Count - 1 'Opened_Part.Items.Count - 1

			'Opened_Part.SetSelected(j, True)
			Opened_Part_SelectedIndexChanged(sender, e)
		Next

		Functions.Error_Form("Done", "All Assemblies and Part files have been added",,,, False,)
		SWFunctions.Out_Put("Ascending")
		Me.Close()


	End Sub

	Private Sub File_Rename_Checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles File_Rename_Checkbox.CheckedChanged
		If File_Rename_Checkbox.Checked = True Then
			SWFunctions.Rename_Files = True
		ElseIf File_Rename_Checkbox.Checked = False Then
			SWFunctions.Rename_Files = False
		End If
	End Sub
End Class
