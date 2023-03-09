Imports System.IO
Imports SwConst
Imports SldWorks
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Runtime.Remoting.Metadata.W3cXsd2001
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Engineering_Assistant.Functions
Imports Engineering_Assistant.SWFunctions

Public Class Start_Window

#Region "Class Vars and Paths"

	Dim swApp As SldWorks.SldWorks
	Dim swDraw As DrawingDoc
	Dim SWSheet As Sheet
	Dim swDoc As ModelDoc2

	Dim Cur_Version = Application.ProductVersion '.Substring(0, 9)
	Dim Prog_Version As String
	Dim new_Version As String
	Dim Initial_Open As Boolean = False
	Dim Loaded As Boolean = False

	ReadOnly Cur_User As String = Network_Locations.Current_User
	ReadOnly Status_num() As String = {"Solidworks is running", "More Than One Solidworks Is Running", "SolidWorks Is Not running",
		"Program is up to date", "Program is ahead of Version", "No Update file found"}

	Dim x_pos As Double = 0.0
	Dim y_pos As Double = 0.0
	Dim z_pos As Double = 0.0
	Dim OriginalSize_X As Integer = 700
	Dim OriginalSize_Y As Integer = 700
	Dim NewSize_X As Integer = 0
	Dim NewSize_Y As Integer = 0
	Dim ModminSize_X As Integer = 400
	Dim ModminSize_Y As Integer = 150
	Dim ModminSize_X_SW As Integer = 321


#End Region

#Region "Form functions, Load, Sizing, Closing, Positioning"

	Private Sub Form_Resize() Handles Me.ResizeEnd
		Functions.Form_resize(Me)
	End Sub

	Private Sub Starting_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

		If e.CloseReason = 3 Then

			Dim Out_text As String = System.Environment.UserName
			Out_text = Out_text & " logged out at " & DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")

			Dim User_Log As System.IO.StreamWriter = System.IO.File.AppendText(Cur_User)

			User_Log.WriteLine(Out_text)
			User_Log.Close()

			SWFunctions.Remove_SW()
			GC.Collect()
			GC.WaitForPendingFinalizers()

		End If
		e.Cancel = False
	End Sub

	Public Sub Start_Window_Load() Handles MyBase.Load

		HelpToolStripMenuItem.Visible = False
		UpdateToolStripMenuItem.Visible = False
		Save_As_DWG.Visible = False
		Save_As_STL.Visible = False
		Hide_Origin.Visible = False
		Model_Properties.Visible = False
		NOTE_UPDATING.Visible = False
		Load_Analysis_2.Visible = False
		AutoCad_Interface.Visible = False

		If System.IO.Directory.Exists(Network_Locations.SW_Path_Dir) Then

			Cad_Interfaces.Visible = True
			SolidWorks_Interface.Visible = True

			If SolidWorks_Interface.Checked = True Then
				Sheet_Metal_Group.Visible = True
				Solidworks_Functions_Group.Visible = True
				Solidworks_Modeling_Group.Visible = True
				AutoCad_Interface.Visible = False
				NewSize_X = OriginalSize_X
				Me.MinimumSize = New System.Drawing.Size(OriginalSize_X, OriginalSize_Y)
				Me.Width = NewSize_X
			Else
				Sheet_Metal_Group.Visible = False
				Solidworks_Functions_Group.Visible = False
				Solidworks_Modeling_Group.Visible = False
				AutoCad_Interface.Visible = False
				NewSize_X = OriginalSize_X - ModminSize_X
				Me.MinimumSize = New System.Drawing.Size(NewSize_X, Me.Height)
				Me.Width = NewSize_X
			End If

			ToolTip1.SetToolTip(SolidWorks_Interface, "Starts/Stops SolidWorks API")

		Else

			Cad_Interfaces.Visible = False
			SolidWorks_Interface.Visible = False
			Sheet_Metal_Group.Visible = False
			Solidworks_Functions_Group.Visible = False
			Solidworks_Modeling_Group.Visible = False
			AutoCad_Interface.Visible = False

			NewSize_X = OriginalSize_X - ModminSize_X
			NewSize_Y = OriginalSize_Y - ModminSize_Y
			Me.MinimumSize = New System.Drawing.Size(NewSize_X, NewSize_Y)
			Me.Width = NewSize_X
			Me.Height = NewSize_Y

		End If

		Dim StartProcess As New System.Diagnostics.Process()

		AlwaysOnTopToolStripMenuItem.Checked = False

		For Each Fm In Application.OpenForms
			If (Fm.name = Me.Name) And Initial_Open = False Then

				Initial_Open = True
				If System.IO.File.Exists(Cur_User) Then

					Dim Current_text As String = System.Environment.UserName
					Current_text = Current_text & " logged in at " & DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")
					Dim User_Log As System.IO.StreamWriter = System.IO.File.AppendText(Cur_User)
					User_Log.WriteLine(Current_text)
					User_Log.Close()

				End If
			End If
		Next

		If System.IO.File.Exists(Network_Locations.Program_Version_File) Then
			Dim reader As New System.IO.StreamReader(Network_Locations.Program_Version_File)
			Prog_Version = reader.ReadLine()
			reader.Close()

			If Cur_Version < Prog_Version Then
				UpdateToolStripMenuItem_Click() 'Update
			ElseIf Cur_Version = Prog_Version Then
				Status_Label.Text = Status_num(3) '"Program is up to date"
			ElseIf Cur_Version > Prog_Version Then
				Status_Label.Text = Status_num(4) '"Program is ahead of Version"
			End If
		Else
			Status_Label.Text = Status_num(5) '"No Update file found"
		End If
	End Sub

	Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
		Me.Close()
	End Sub

	Public Sub AlwaysOnTopToolStripMenuItem_Click() Handles AlwaysOnTopToolStripMenuItem.Click

		If AlwaysOnTopToolStripMenuItem.Checked = True Then
			TopMost = True
			Opacity = 0.8
		Else
			TopMost = False
			Opacity = 1
		End If

	End Sub

	Private Sub SolidWorks_Interface_CheckedChanged(sender As Object, e As EventArgs) Handles SolidWorks_Interface.CheckedChanged
		If SolidWorks_Interface.Checked = True Then

			NewSize_X = OriginalSize_X
			Me.MinimumSize = New System.Drawing.Size(OriginalSize_X, OriginalSize_Y)
			Me.Width = NewSize_X
			SWFunctions.Connect_SW()
			Sheet_Metal_Group.Visible = True
			Solidworks_Functions_Group.Visible = True
			Solidworks_Modeling_Group.Visible = True
			'Me.MinimumSize = OriginalSize_X - 321
		End If

		If SolidWorks_Interface.Checked = False Then
			If System.IO.Directory.Exists(Network_Locations.SW_Path_Dir) Then

				Cad_Interfaces.Visible = True
				SolidWorks_Interface.Visible = True
				Sheet_Metal_Group.Visible = False
				Solidworks_Functions_Group.Visible = False
				Solidworks_Modeling_Group.Visible = False
				AutoCad_Interface.Visible = False
				SWFunctions.Remove_SW()

				ToolTip1.SetToolTip(SolidWorks_Interface, "Starts/Stops SolidWorks API")

				NewSize_X = OriginalSize_X - ModminSize_X
				Me.MinimumSize = New System.Drawing.Size(NewSize_X, Me.Height)
				Me.Width = NewSize_X

				'Else
				'	
				'	Sheet_Metal_Group.Visible = False
				'	Solidworks_Functions_Group.Visible = False
				'	Solidworks_Modeling_Group.Visible = False

				'	NewSize_X = OriginalSize_X - ModminSize_X
				'	NewSize_Y = OriginalSize_Y - ModminSize_Y
				'	Me.MinimumSize = New System.Drawing.Size(NewSize_X, NewSize_Y)
				'	Me.Width = NewSize_X
				'	Me.Height = NewSize_Y
			End If
		End If
	End Sub

	Private Sub AutoCad_Interface_CheckedChanged(sender As Object, e As EventArgs) Handles AutoCad_Interface.CheckedChanged

	End Sub

#End Region


#Region "Form Updating and Help"
	Private Sub UpdateToolStripMenuItem_Click() Handles UpdateToolStripMenuItem.Click

		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		new_Version = Cur_Version + " To " + Prog_Version

		Dim Version_Compare = Equals(Cur_Version, Prog_Version)

		If Version_Compare = False Then

			Functions.Error_Form("Program Update", "You are about to Update the Program",, new_Version,, False)

			Try
				Dim StartUpdate = Process.Start(Network_Locations.Update_Start_file)

				End
				Me.Close()
			Catch ex As Exception
				SW_Doc.Text = "Update declined by user"
				End
			End Try

		Else
			Functions.Error_Form("Program Update", "Program is the latest version",, Cur_Version)

		End If
	End Sub

	Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click, Help.Click
		'Functions.Error_Form("Nothing ATM", "Not working yet",,,,, Me)
		Process.Start(Network_Locations.ProgramHelp_Dir)
	End Sub

	Private Sub VersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VersionToolStripMenuItem.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		Functions.Error_Form("Program Version", Cur_Version, "Version: ",,,,)
	End Sub

#End Region


#Region "Sheet metal, L angle, Z angles, Gussets, and misc extrusions"
	Private Sub L_Angle_10133_Click(sender As Object, e As EventArgs) Handles L_Angle_10133.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Equal Leg L Angle Builder"
		Extra_Info.Text = ""
		Functions.Status = False
		Calling_Fun = "10133"
		Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Equal Leg L Angle has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()
		End If
	End Sub

	Private Sub L_Angle_10134_Click(sender As Object, e As EventArgs) Handles L_Angle_10134.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Unequal Leg L Angle Builder"
		Extra_Info.Text = ""
		Functions.Status = False
		Calling_Fun = "10134"
		Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Unequal Leg L Angle has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()
		End If
	End Sub

	Private Sub L_Angle_Custom_Click(sender As Object, e As EventArgs) Handles L_Angle_Custom.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Custom Leg L Angle Builder"
		Extra_Info.Text = ""
		Functions.Status = False
		Calling_Fun = "Custom L"
		Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Custom Leg L Angle has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()
		End If
	End Sub

	Private Sub Z_Angle_10138_Click(sender As Object, e As EventArgs) Handles Z_Angle_10138.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Equal Leg L Angle Builder"
		Extra_Info.Text = ""
		Functions.Status = False
		Calling_Fun = "10138"
		Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Equal Leg L Angle has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()
		End If
	End Sub

	Private Sub Z_Angle_10139_Click(sender As Object, e As EventArgs) Handles Z_Angle_10139.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Unequal Leg L Angle Builder"
		Extra_Info.Text = ""
		Functions.Status = False
		Calling_Fun = "10139"
		Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Unequal Leg L Angle has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()
		End If
	End Sub

	Private Sub Z_Angle_Custom_Click(sender As Object, e As EventArgs) Handles Z_Angle_Custom.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Custom Leg L Angle Builder"
		Extra_Info.Text = ""
		Functions.Status = False
		Calling_Fun = "Custom Z"
		Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Custom Leg L Angle has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()
		End If
	End Sub

	Private Sub Gusset_Custom_Click(sender As Object, e As EventArgs) Handles Gusset_Custom.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Gusset Builder"
		Extra_Info.Text = ""
		Functions.Status = False
		Calling_Fun = "Gusset"
		Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Gusset has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()
		End If
	End Sub

	Private Sub U_Channel_Click(sender As Object, e As EventArgs) Handles U_Channel.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "U Channel Builder"
		Extra_Info.Text = ""
		Functions.Status = False
		Calling_Fun = "U Channel"
		Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "U Channel has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()
		End If
	End Sub

#End Region


#Region "PDF and existing files"
	Private Sub Frame_Station_Click(sender As Object, e As EventArgs) Handles ViewFrameStations.Click, Frame_Station.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		SW_Doc.Text = "Aircraft Frame Station PDF"
		Functions.Open_New_Form(Of Aircraft_Frames)()
		Start_Window_Load()
	End Sub

	Private Sub Structural_Drawings_Click(sender As Object, e As EventArgs) Handles Structural_Drawings.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		SW_Doc.Text = "View Existing Structural PDFs"
		Functions.Open_New_Form(Of Existing_Aircrafts)()
		Start_Window_Load()
	End Sub

	Private Sub Electrical_Drawings_Click(sender As Object, e As EventArgs) Handles Electrical_Drawings.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		SW_Doc.Text = "View Existing Electrical PDFs"
		Functions.Open_New_Form(Of Existing_Electrical_Aircrafts)()
		Start_Window_Load()
	End Sub

	Private Sub Aircraft_Stringer_Charts(sender As Object, e As EventArgs) Handles Aircraft_Stringers.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		SW_Doc.Text = "View Existing Aircraft Stringers"
		Functions.Open_New_Form(Of Existing_Aircrafts_Stringers)()
		Start_Window_Load()
	End Sub

#End Region


#Region "Saving"

	Private Sub Save_As_New_Click(sender As Object, e As EventArgs) Handles SaveAsNew.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean

		SW_Doc.Text = "Save as new Doc"
		Extra_Info.Text = ""
		Status = SWFunctions.Save_As()

		If Status = True Then
			Extra_Info.Text = "File has been saved."
			Start_Window_Load()
		Else
			Extra_Info.Text = "File did not save."
			Start_Window_Load()
		End If
	End Sub

#End Region


#Region "SW Functions 1"

	Private Sub New_Drawing_Click(sender As Object, e As EventArgs) Handles NewDrawingToolStripMenuItem.Click, New_Drawing.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		Functions.Status = False

		Debug.Print(TimeString)

		Dim count As Integer
		Dim index As Integer
		Dim Open_Docs As Object
		Dim FullPathName = String.Empty
		'Dim Errors As Integer
		'Dim Load As Boolean

		Dim UnsavedFiles As Integer = 0
		Dim OpenedDWG As Integer = 0
		Dim OpenedDWG_Name = String.Empty

		swDoc = SWFunctions.swApp.ActiveDoc
		count = SWFunctions.swApp.GetDocumentCount
		Open_Docs = SWFunctions.swApp.GetDocuments

		'MsgBox(Me.ToString)
		If swDoc Is Nothing Then 'count = 0 Then
			Functions.Error_Form()
		Else

			For index = LBound(Open_Docs) To UBound(Open_Docs)
				swDoc = Open_Docs(index)
				FullPathName = swDoc.GetPathName()
				If FullPathName = "" Then
					Functions.Status = False
					UnsavedFiles += 1
				ElseIf swDoc.GetType = 3 Then
					Functions.Status = False
					OpenedDWG += 1
				Else
					Functions.Status = True
				End If
			Next

			If UnsavedFiles >= 1 And OpenedDWG >= 1 Then
				Functions.Error_Form("Unsaved Files and Opened Drawing", "You have " & UnsavedFiles &
						 " unsaved files opened",, "You have " & OpenedDWG & " opened drawings",, False)
			ElseIf UnsavedFiles = 0 And OpenedDWG = 1 Then
				Functions.Error_Form("Opened Drawing", "You have " & OpenedDWG & " opened drawing",,,, False)
			ElseIf UnsavedFiles = 0 And OpenedDWG >= 2 Then
				Functions.Error_Form("Opened Drawing", "You have " & OpenedDWG & " opened drawings",,,, False)
			ElseIf UnsavedFiles = 1 And OpenedDWG >= 0 Then
				Functions.Error_Form("Unsaved Files", "You have " & UnsavedFiles & " unsaved file opened",,,, False)
			ElseIf UnsavedFiles >= 2 And OpenedDWG >= 0 Then
				Functions.Error_Form("Unsaved Files", "You have " & UnsavedFiles & " unsaved files opened",,,, False)
			End If
			Debug.Print(TimeString & " --> " & SWFunctions.swAssy_Docs.Count & " - Assy, " & SWFunctions.swPart_Docs.Count & " - Part")
		End If

		If Functions.Status = True Then
			SW_Doc.Text = "A New Drawing has Opened"
			Extra_Info.Text = ""
			Functions.Open_New_Form(Of New_Drawing)()
		End If

		If Functions.Status = True Then
			Extra_Info.Text = "Drawing has been created."
			If SWFunctions.Add_BOM = True Then
				Add_Hardware.PerformClick()
			End If
			Start_Window_Load()
		Else
			Extra_Info.Text = "Drawing operation failed."
			Start_Window_Load()
		End If

	End Sub

	Private Sub Sheet_Rename_Click(sender As Object, e As EventArgs) Handles SheetRenameToolStripMenuItem.Click, Sheet_Rename.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean

		SW_Doc.Text = "Sheets are renaming."
		Extra_Info.Text = ""
		Status = SWFunctions.Sheet_Rename()

		If Status = True Then
			Extra_Info.Text = "Drawing Sheets have been renamed."
			Start_Window_Load()
		Else
			Extra_Info.Text = "Sheets did not get renamed."
			Start_Window_Load()
		End If

	End Sub

	Private Sub Add_Hardware_Click(sender As Object, e As EventArgs) Handles OpenNewToolStripMenuItem.Click, Add_Hardware.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		swDoc = SWFunctions.swApp.ActiveDoc

		SW_Doc.Text = "Add Hardware to BOM"
		Extra_Info.Text = ""
		Functions.Status = False

		If swDoc Is Nothing Then
			Functions.Error_Form()
		Else
			If swDoc.GetPathName() = "" Then
				Functions.Error_Form("File Is Not Saved", "Please save the file and try again")
			Else
				If swDoc.GetType = swDocumentTypes_e.swDocDRAWING Then
					Functions.Open_New_Form(Of BOM_Hardware)()
				Else
					Functions.Error_Form("Document Is Not A Drawing", "Opened document is not a drawing")
				End If
			End If
		End If

		If Functions.Status = True Then
			Extra_Info.Text = "BOM Hardware has been added."
			Start_Window_Load()
		Else
			Extra_Info.Text = "BOM operation failed."
			Start_Window_Load()
		End If
	End Sub

	Private Sub PDF_Drawing_Click(sender As Object, e As EventArgs) Handles PDFDrawing.Click, PDF_Drawing.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean

		SW_Doc.Text = "Creating Drawing a PDF."
		Extra_Info.Text = ""
		Status = SWFunctions.PDF()

		If Status = True Then
			Extra_Info.Text = "Drawing has been saved as a PDF."
			Start_Window_Load()
		Else
			Extra_Info.Text = "Drawing did not saved as a PDF."
			Start_Window_Load()
		End If
	End Sub

	Private Sub Pack_N_Go_Click(sender As Object, e As EventArgs) Handles Pack_N_Go.Click, Pack_And_Go.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean

		SW_Doc.Text = "Pack And Go In Effect"
		Extra_Info.Text = ""
		'Status = SWFunctions.PackandGo2()
		If SWFunctions.swApp.ActiveDoc() Is Nothing Then
			Functions.Error_Form()
			Status = False
		Else
			Status = SWFunctions.IR_Pack_N_Go()
		End If

		If Status = True Then
			Extra_Info.Text = "Pack And Go has Completed."
			Start_Window_Load()
		Else
			Extra_Info.Text = "Pack And Go has Failed."
			Start_Window_Load()
		End If
	End Sub

	Private Sub Save_As_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Save_As_Type.SelectedIndexChanged
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean
		Dim Filetype As String

		Filetype = Save_As_Type.SelectedItem

		SW_Doc.Text = "Save Part as " + Filetype
		Extra_Info.Text = ""
		Status = SWFunctions.Save_Step(Filetype)

		If Status = True Then
			Extra_Info.Text = "Part File has been saved as STEP."
			Start_Window_Load()
		Else
			Extra_Info.Text = "Part File did not save as STEP."
			Start_Window_Load()
		End If
	End Sub

	Private Sub TEST_Click_1(sender As Object, e As EventArgs) Handles Cust_Prop_Update.Click

		Dim FolderName As String
		Dim swTitle As String
		Dim swDWG_Num As String
		Dim AC_Num As String
		Dim Drawings_Major As String
		Dim Folder_Check As String
		Dim Minor_Check As String
		Dim Structural As String
		Dim FullPathName As String
		Dim desktop As String
		Dim Int As Integer

		Dim PC_USER As String = System.Environment.UserName

		Dim CusProperties As CustomPropertyManager
		Dim swModelDocExt As ModelDocExtension

		swDoc = SWFunctions.swApp.ActiveDoc

		If swDoc Is Nothing Then
			Functions.Error_Form()
		Else

			If swDoc.GetType = swDocumentTypes_e.swDocDRAWING Then

				'swDoc = swApp.ActiveDoc
				FullPathName = swDoc.GetPathName()

				If FullPathName = "" Then
					Functions.Error_Form("File not saved", "Save file and retry.")
				Else

					swModelDocExt = swDoc.Extension
					CusProperties = swModelDocExt.CustomPropertyManager("")

					Select Case PC_USER
						Case ""
							PC_USER = ""
						Case ""
							PC_USER = ""
						Case ""
							PC_USER = ""
						Case ""
							PC_USER = ""
						Case ""
							PC_USER = ""
						Case ""
							PC_USER = ""
						Case ""
							PC_USER = ""
						Case ""
							PC_USER = ""
						Case ""
							PC_USER = ""
						Case Else
							PC_USER = "UNKNOWN"
							Functions.Error_Form("User Name Error", "PC User Name doesn't match the list",, "Manually input Drawnby name",, False, Me)

					End Select

					Int = CusProperties.Set2("DATE", DateTime.Now.ToString("MMM/dd/yyyy").ToUpper)
					If Int <> 0 Then
						Functions.Error_Form("Error with DATE", "Date does not work with " + DateTime.Now.ToString("MMM/dd/yyyy").ToUpper,, "Please enter value manually.")
					End If

					Int = CusProperties.Set2("DRAWN BY", PC_USER)
					If Int <> 0 Then
						Functions.Error_Form("Error with DRAWN BY", "DRAWN BY does not work with PC USER name",, "Please enter value manually.")
					End If

					Int = CusProperties.Set2("CURRENT REV", "$PRP:""REV 1""")
					If Int <> 0 Then
						Functions.Error_Form("Error with CURRENT REV", "CURRENT REV value does not work ",, "Please enter value manually.")
					End If

					Int = CusProperties.Set2("REV 1 DESCRIPTION", "PRELIMINARY RELEASE")
					If Int <> 0 Then
						Functions.Error_Form("Error with REV 1 DESCRIPTION", "REV 1 DESCRIPTION does not work",, "Please enter value manually.")
					End If

					FolderName = FullPathName.Remove(FullPathName.LastIndexOf("\"))
					desktop = FolderName.Remove(0, FolderName.LastIndexOf("\") + 1)
					If desktop <> "Desktop" Then
						Structural = Directory.GetParent(FolderName).FullName
						Drawings_Major = Directory.GetParent(Structural).FullName
						AC_Num = Directory.GetParent(Drawings_Major).FullName

						Folder_Check = Drawings_Major.Remove(0, Drawings_Major.LastIndexOf("\") + 1)
						Minor_Check = Structural.Remove(0, Structural.LastIndexOf("\") + 1)

						If Minor_Check = "(3) Drawings Minor" Then
							AC_Num = Directory.GetParent(Structural).FullName
						End If

						If Folder_Check = "(2) Drawings Major" Or Folder_Check = "(3) Drawings Minor" Or Minor_Check = "(3) Drawings Minor" Then

							AC_Num = AC_Num.Remove(0, AC_Num.LastIndexOf("\") + 1)
							AC_Num = AC_Num.Remove(AC_Num.LastIndexOf("-"))
							AC_Num = AC_Num.Substring(AC_Num.IndexOf(" "))

							swTitle = FolderName.Remove(0, FolderName.LastIndexOf("\") + 1)
							Dim FN As String() = swTitle.Split(New String() {"("}, StringSplitOptions.None)
							swDWG_Num = FN(0)
							swTitle = FN(1).Remove(FN(1).LastIndexOf(")"))

							Int = CusProperties.Set2("DWG NUM", swDWG_Num.ToUpper)
							If Int <> 0 Then
								Functions.Error_Form("Error with DWG NUM", "DWG NUM does not work with " + swDWG_Num.ToUpper,, "Please enter value manually.")
							End If

							Int = CusProperties.Set2("TITLE", swTitle.ToUpper)
							If Int <> 0 Then
								Functions.Error_Form("Error with Title", "Title does not work with " + swTitle.ToUpper,, "Please enter value manually.")
							End If
							Int = CusProperties.Set2("AIRCRAFT & S/N", AC_Num.ToUpper)
							If Int <> 0 Then
								Functions.Error_Form("Error with Title", "Title does not work with " + swTitle.ToUpper,, "Please enter value manually.")
							End If
						Else
							Functions.Error_Form("N/A Folder", "File not saved in appropriate folder",, "Some values will not be updated")
						End If
					Else
						Functions.Error_Form("N/A Folder", "File is saved on Desktop",, "Some values will not be updated")
					End If

					'Adding Notes to Sheet 1
					swDoc.ActivateSheet("Sheet1")
					swDoc.ForceRebuild3(True)
				End If
			Else
				Functions.Error_Form("Not a Drawing", "File is not a drawing.")
			End If
		End If
	End Sub

	Private Sub Remove_Config_Click(sender As Object, e As EventArgs) Handles RemoveConfigsToolStripMenuItem.Click, Hide_Origin.Click

	End Sub
#End Region


#Region "SW Functions 2"

	Private Sub Contour_Plate_Modeling_Click(sender As Object, e As EventArgs) Handles Contour_Plate_Modeling.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Create a Contour Plate"
		Extra_Info.Text = ""
		Functions.Status = False
		Functions.Open_New_Form(Of Contour_Plate)()

		If Functions.Status = True Then
			Extra_Info.Text = "Contour Plate has been created."
			Start_Window_Load()
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()
		End If
	End Sub

	Private Sub Library_Feature_Click(sender As Object, e As EventArgs) Handles LibraryFeatureToolStripMenuItem.Click, Library_Feature.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Insert Library Feature"
		Extra_Info.Text = ""
		Functions.Status = False
		Functions.Open_New_Form(Of Lib_Feat_Add)()

		If Functions.Status = True Then
			Extra_Info.Text = "Library Feature Added."
			Start_Window_Load()
		Else
			Extra_Info.Text = "Operation Failed."
			Start_Window_Load()
		End If
	End Sub

	Private Sub Model_Properties_Click(sender As Object, e As EventArgs) Handles Model_Properties.Click

	End Sub

	Private Sub Panel_Modeling_Click(sender As Object, e As EventArgs) Handles NOTE_UPDATING.Click

	End Sub

	Private Sub BOM_Weight_Tables_Click(sender As Object, e As EventArgs) Handles BOM_Weight_Tables.Click

		Dim swDoc As ModelDoc2
		Dim swGeneralTableFeature As GeneralTableFeature
		Dim swTableAnnotation As TableAnnotation
		Dim swFeature As Feature
		Dim swSubFeat As Feature
		Dim swLayerMgr As LayerMgr

		Dim Insert_WeightTable As Boolean = True
		Dim Insert_BOMTable As Boolean = True
		Dim Columns_max As Integer
		Dim nbrTableAnnotations As Integer
		Dim tableAnnotations() As Object
		Dim sheetnames() As String
		Dim Sheetnumbers As Integer
		Dim Bool As Integer

		swDoc = SWFunctions.swApp.ActiveDoc

		If swDoc Is Nothing Then
			Functions.Error_Form()
		Else
			If swDoc.GetType = swDocumentTypes_e.swDocDRAWING Then
				swFeature = swDoc.FirstFeature


				swLayerMgr = swDoc.GetLayerManager
				Bool = swLayerMgr.SetCurrentLayer("BOMS")

				While swFeature IsNot Nothing

					Debug.Print(swFeature.Name + "  ---  " + swFeature.GetTypeName)

					swSubFeat = swFeature.GetFirstSubFeature

					While swSubFeat IsNot Nothing

						Debug.Print(swSubFeat.Name + "  --- --- ---  " + swSubFeat.GetTypeName)

						If swSubFeat.GetTypeName = "GeneralTableFeature" Then

							swGeneralTableFeature = swSubFeat.GetSpecificFeature2
							nbrTableAnnotations = swGeneralTableFeature.GetTableAnnotationCount
							tableAnnotations = swGeneralTableFeature.GetTableAnnotations
							swTableAnnotation = tableAnnotations(0)
							Columns_max = swTableAnnotation.ColumnCount()
							If Columns_max = 4 Then

								swSubFeat.Name = "WEIGHT TABLE"
								Insert_WeightTable = False
							ElseIf Columns_max > 4 Then

								swSubFeat.Name = "PART LIST TABLE"
								Insert_BOMTable = False
							Else
							End If
						End If

						swSubFeat = swSubFeat.GetNextSubFeature
					End While

					swFeature = swFeature.GetNextFeature
				End While

				If Insert_WeightTable = True Then
					Sheetnumbers = swDoc.GetSheetCount - 1
					sheetnames = swDoc.GetSheetNames
					swDoc.ActivateSheet(sheetnames(0))
					swTableAnnotation = swDoc.InsertTableAnnotation2(False, 0.6 / 39.37, 2 / 39.37, 4, Network_Locations.WeightTable_Path, 8, 4)

				End If

				If Insert_BOMTable = True Then
					Sheetnumbers = swDoc.GetSheetCount - 1
					sheetnames = swDoc.GetSheetNames
					swDoc.ActivateSheet(sheetnames(0))
					swTableAnnotation = swDoc.InsertTableAnnotation2(False, 16.348 / 39.37, 2.004 / 39.37, 4, Network_Locations.BOMTable_Path, 29, 13)
				End If

				If Insert_WeightTable = True Or Insert_BOMTable = True Then
					swFeature = swDoc.FirstFeature

					While swFeature IsNot Nothing
						swSubFeat = swFeature.GetFirstSubFeature

						While swSubFeat IsNot Nothing
							If swSubFeat.GetTypeName = "GeneralTableFeature" Then

								swGeneralTableFeature = swSubFeat.GetSpecificFeature2
								nbrTableAnnotations = swGeneralTableFeature.GetTableAnnotationCount
								tableAnnotations = swGeneralTableFeature.GetTableAnnotations
								swTableAnnotation = tableAnnotations(0)
								Columns_max = swTableAnnotation.ColumnCount()

								If Columns_max = 4 Then
									swSubFeat.Name = "WEIGHT TABLE"
								ElseIf Columns_max > 4 Then
									swSubFeat.Name = "PART LIST TABLE"
								End If
							End If

							swSubFeat = swSubFeat.GetNextSubFeature
						End While

						swFeature = swFeature.GetNextFeature
					End While
				End If

				Bool = swLayerMgr.SetCurrentLayer("-Per Standard-")
			Else
				Functions.Error_Form("No Drawing Activated", "Document is not a drawing doc")
			End If
		End If
	End Sub

	Private Sub Test_Click(sender As Object, e As EventArgs) Handles Export_To_Excel.Click

		Dim swComp As Component2
		Dim swConfMgr As ConfigurationManager
		Dim swConf As Configuration
		Dim Path As String
		Dim filename As String
		Dim Opened_Files_Count As Integer
		Dim TopAssy As String

		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		swDoc = SWFunctions.swApp.ActiveDoc

		If swDoc Is Nothing Then
			Functions.Error_Form()
		Else
			If swDoc.GetType = swDocumentTypes_e.swDocASSEMBLY Then

				Opened_Files_Count = SWFunctions.swApp.GetDocumentCount
				If Opened_Files_Count >= 1 Then

					If swDoc.GetPathName <> "" Then

						Path = System.IO.Path.GetDirectoryName(swDoc.GetPathName)
						filename = SWFunctions.SW_FileName(swDoc.GetPathName)

						If swDoc.GetType = swDocumentTypes_e.swDocASSEMBLY Or swDoc.GetType = swDocumentTypes_e.swDocDRAWING Then

							SWFunctions.swAssy_Docs.Clear()
							SWFunctions.swPart_Docs.Clear()
							SWFunctions.swDwg_Docs.Clear()
							SWFunctions.swHardware_Docs.Clear()

							swConfMgr = swDoc.ConfigurationManager
							swConf = swConfMgr.ActiveConfiguration
							swComp = swConf.GetRootComponent3(True)

							Dim starttime = TimeString
							Debug.Print(TimeString)
							SWFunctions.Add_Docs2(swComp, 1)
							SWFunctions.Out_Put("Descending")

							If SWFunctions.swAssy_Docs.Count > 0 Then
								TopAssy = SWFunctions.swAssy_Docs(SWFunctions.swAssy_Docs.Count - 1).Nomenclature
								SWFunctions.Docs_To_Excel(Path, TopAssy)
							Else
								Functions.Error_Form("Assy/Parts incompatible", "Assy/Part files missing specific custom properties.")
							End If

							'SWFunctions.Docs_To_Excel(Path, SWFunctions.swAssy_Docs(SWFunctions.swAssy_Docs.Count - 1).Nomenclature) 'filename)
							'SWFunctions.Docs_To_Excel(Path, SWFunctions.swAssy_Docs(0).Nomenclature) 'filename)
							'filename)
							Debug.Print(TimeString & " --> " & starttime & " #" & SWFunctions.swAssy_Docs.Count + SWFunctions.swPart_Docs.Count)
						ElseIf swDoc.GetType <> swDocumentTypes_e.swDocPART Then
							Functions.Error_Form("Wrong File Type", "Active doc is not an Assy")
						End If

					Else
						Functions.Error_Form("Document is not saved", "Please save file and try again")
					End If
				Else
					Functions.Error_Form("No Document Loaded", "No SolidWorks document is open")
				End If
			Else
				Functions.Error_Form("Not an Assembly,", "This is not an Assembly File.")
			End If
		End If
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Pack_N_Go_Assy.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean

		SW_Doc.Text = "Pack And Go In Effect"
		Extra_Info.Text = ""
		Status = SWFunctions.PackandGoAssy()

		If Status = True Then
			Extra_Info.Text = "Pack And Go has Completed."
			Start_Window_Load()
		Else
			Extra_Info.Text = "Pack And Go has Failed."
			Start_Window_Load()
		End If
	End Sub

	Private Sub DataTest_Click(sender As Object, e As EventArgs) Handles Note_Naming.Click

		Dim swDrawing As DrawingDoc
		Dim swDoc2 As ModelDoc2
		Dim swDoc As ModelDoc2
		Dim swSheet As Sheet
		Dim swDrView As View
		Dim swExtension As ModelDocExtension
		Dim annArray() As Object
		Dim obj As Object
		Dim currAnn As Annotation
		'Dim fileName As String
		'Dim errors As Integer
		'Dim warnings As Integer
		Dim Status As Boolean

		'Dim vAttEntTypeArr As Object

		Dim sheetnames() As String
		Dim Sheetnumbers As Integer

		swDoc = SWFunctions.swApp.ActiveDoc

		If swDoc Is Nothing Then
			Functions.Error_Form()
		Else
			If swDoc.GetType = swDocumentTypes_e.swDocDRAWING Then

				swDrawing = swDoc
				swDoc2 = swDoc
				swExtension = swDoc2.Extension

				Status = swExtension.LoadDraftingStandardALN_Std_Draw()

				If Status = False Then
					MsgBox("Standards didn't load")
				End If

				Sheetnumbers = swDrawing.GetSheetCount - 1
				sheetnames = swDrawing.GetSheetNames

				For i = 0 To (Sheetnumbers)
					swDrawing.ActivateSheet(sheetnames(i))
					If i = 0 Then
						swDrawing.SetupSheet6(sheetnames(i), 12, 12, 1, 1, False, Network_Locations.SW_CoverSheet_Temp, 0.4318, 0.2794, "Default", True, 0, 0, 0, 0, 0, 0)
					Else
						swDrawing.SetupSheet6(sheetnames(i), 12, 12, 1, 1, False, Network_Locations.SW_AddSheet_Temp, 0.4318, 0.2794, "Default", True, 0, 0, 0, 0, 0, 0)
					End If
					swSheet = swDrawing.GetCurrentSheet
					'swSheet.SetName("Renaming" & i)
				Next

				swDrawing.ActivateSheet(sheetnames(0))

				Status = swExtension.SetUserPreferenceToggle(swUserPreferenceToggle_e.swDetailingShowPeriodWithBorders, swUserPreferenceOption_e.swDetailingNoOptionSpecified, False)

				If Status = False Then
					Functions.Error_Form("Annotation period border setting", "Setting is checked",, "Please uncheck setting")

				End If

				For i = 0 To (Sheetnumbers)
					swDrView = swDrawing.GetFirstView
					While swDrView IsNot Nothing
						Debug.Print("Name of drawing view: " & swDrView.GetName2)
						annArray = swDrView.GetAnnotations
						If annArray IsNot Nothing Then
							For Each obj In annArray
								currAnn = obj
								Debug.Print("  Name of annotation: " & currAnn.GetName)
								currAnn.Select3(True, Nothing)

								'currAnn.lea

								'vAttEntTypeArr = currAnn.GetAttachedEntityTypes
								'If vAttEntTypeArr.ToString = "142" Then
								'	MsgBox("Table")
								'End If

								'currAnn.SetName(InputBox("Note Name", "Name this note"))

								Dim NameArray() As String = Split(currAnn.GetName)
								If NameArray(0) = "Sheet" Then
									'do nothing
								Else
									MsgBox("Note not named please name it")
									'currAnn.SetName(InputBox("Note Name", "Name this note"))
									currAnn.SetTextFormat(0, True, Nothing)
								End If
								'Debug.Print(" NEW --- Name of annotation: " & currAnn.GetName)
							Next obj
						End If
						swDrView = swDrView.GetNextView
					End While
					swDrawing.ClearSelection2(True)
					If i < Sheetnumbers Then
						swDrawing.ActivateSheet(sheetnames(i + 1))
					End If
				Next
				'First drawing view is the sheet, so get next drawing view
				'swDrView = swDrView.GetNextView
				swDrawing.ActivateSheet(sheetnames(0))
			Else
				Functions.Error_Form("Document is Not a Drawing", "Current document is not a drawing file")
			End If
		End If
	End Sub

#End Region


#Region "Math, Radius, Excel, and Load Functions"

	Private Sub Backup_Click(sender As Object, e As EventArgs) Handles Backup.Click

		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		If System.Environment.UserName = "Us1" Or System.Environment.UserName = "Us2" Then

			Process.Start("T:\Engineering\Non-Site Specific\APPROVED DOCUMENTS\EXCEL DATABASE")

			SW_Doc.Text = "PDF to Excel Backup"
			Extra_Info.Text = ""
			Functions.Status = False
			Functions.Open_New_Form(Of Backup)()

			If Functions.Status = True Then
				Extra_Info.Text = "Backup was completed"
				Start_Window_Load()
			Else
				Extra_Info.Text = "Operation failed."
				Start_Window_Load()
			End If
		Else
			Process.Start(Network_Locations.Excel_Database_Path)
		End If
	End Sub

	Private Sub Cross_Product_Click(sender As Object, e As EventArgs) Handles CrossProductToolStripMenuItem.Click, Cross_Product.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Cross product"
		Extra_Info.Text = ""
		Functions.Status = False
		Functions.Open_New_Form(Of Cross_Product)()

		If Functions.Status = True Then
			Extra_Info.Text = "Completed Cross Product."
			Start_Window_Load()
		Else
			Extra_Info.Text = "Operation Failed."
			Start_Window_Load()
		End If
	End Sub

	Private Sub Fastener_Data_Click(sender As Object, e As EventArgs) Handles Fastener_Data.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		SW_Doc.Text = "View Material PDFs"
		Functions.Open_New_Form(Of Material_Data)()
		Start_Window_Load()
	End Sub

	Private Sub Radius_Finder_Button_Click(sender As Object, e As EventArgs) Handles Radius_Finder_Button.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Find that Radius"
		Extra_Info.Text = ""
		Functions.Status = False
		Functions.Open_New_Form(Of Radius_Finder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Radius Returned."
			Start_Window_Load()
		Else
			Extra_Info.Text = "Operation Failed."
			Start_Window_Load()
		End If
	End Sub

	Private Sub Load_Analysis_Button_Click(sender As Object, e As EventArgs) Handles Load_Analysis_Button.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Analysing Load Data"
		Extra_Info.Text = ""
		Functions.Status = False
		Functions.Open_New_Form(Of Load_Analysis)()

		Extra_Info.Text = "Load Analysis Complete"
		Start_Window_Load()

	End Sub


#End Region


#Region "Unused or moved functions"
	Private Sub Save_As_STL_Click(sender As Object, e As EventArgs) Handles SaveAsSTL.Click, Save_As_STL.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean

		SW_Doc.Text = "Save Part as STL"
		Extra_Info.Text = ""
		Status = SWFunctions.Save_Step(".STL")

		If Status = True Then
			Extra_Info.Text = "Part File has been saved as STEP."
			Start_Window_Load()
		Else
			Extra_Info.Text = "Part File did not save as STEP."
			Start_Window_Load()
		End If
	End Sub

	Private Sub Save_As_DWG_Click(sender As Object, e As EventArgs) Handles Save_As_DWG.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean

		SW_Doc.Text = "Save Part as STL"
		Extra_Info.Text = ""
		Status = SWFunctions.Save_Step(".DWG")

		If Status = True Then
			Extra_Info.Text = "Part File has been saved as STEP."
			Start_Window_Load()
		Else
			Extra_Info.Text = "Part File did not save as STEP."
			Start_Window_Load()
		End If
	End Sub


#End Region


End Class
