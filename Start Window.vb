Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports SwConst
Imports SwCommands
Imports SldWorks
Imports VB = Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql



Public Class Start_Window

	Dim NewButton As Boolean = False
	Dim OldButton As Boolean = False

	Dim swApp As SldWorks.SldWorks
	Dim swDraw As DrawingDoc
	Dim SWSheet As Sheet
	Dim swDoc As ModelDoc2

	Dim Cur_Version = Application.ProductVersion '.Substring(0, 9)
	Dim Prog_Version As String
	Dim Initial_Open As Boolean = False
	Dim Loaded As Boolean = False

	Dim new_Version As String
	Dim Version As String

	Dim Cur_User As String = "T:\Engineering\Non-Site Specific\PARTS\SW Macros\Model Creator\Resources\Current Users.txt"
	Dim Status_num() As String = {"Solidworks is running", "More Than One Solidworks Is Running", "SolidWorks Is Not running", "Program is up to date", "Program is ahead of Version", "No Update file found"}
	Dim SW_Path As String = "C:\Program Files\SOLIDWORKS Corp"

	Public Const SW_HIDE As Integer = 0
	Public Const SW_SHOWNORMAL As Integer = 1
	Public Const SW_SHOWMINIMIZED As Integer = 2
	Public Const SW_SHOWMAXIMIZED As Integer = 3
	Public Const SW_SHOWNOACTIVATE As Integer = 4
	Public Const SW_SHOW As Integer = 5

	Public conn As SqlConnection

	Dim x_pos As Double = 0.0
	Dim y_pos As Double = 0.0
	Dim z_pos As Double = 0.0

	Dim OriginalSize_X As Integer = 700
	Dim OriginalSize_Y As Integer = 725

	Dim NewSize_X As Integer = 0
	Dim NewSize_Y As Integer = 0

	'Begining Functions
	Private Sub Form_Resize() Handles Me.ResizeEnd
		Functions.Form_resize(Me)
	End Sub

	Private Sub Starting_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
		'Dim SWProcess() As Process
		'Dim count As Integer

		conn = New SqlConnection("")

		'Label1.Text = 

		If e.CloseReason = 3 Then

			Dim Out_text As String = System.Environment.UserName
			Out_text = Out_text & " logged out at " & DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")

			Dim User_Log As System.IO.StreamWriter = System.IO.File.AppendText(Cur_User)

			User_Log.WriteLine(Out_text)
			User_Log.Close()

			SWFunctions.Remove_SW()

			'SWProcess = Process.GetProcessesByName("SLDWORKS")
			'count = swApp.GetDocumentCount

			'If swApp.Visible = False And count = 0 Then
			'	swApp.Visible = True
			'	swApp.ExitApp()

			'End If
			'MsgBox(SWProcess.Count)
			'For i = 0 To SWProcess.Count - 1
			'	System.Runtime.InteropServices.Marshal.ReleaseComObject(swApp)
			'	System.Runtime.InteropServices.Marshal.FinalReleaseComObject(swApp)
			'Next

			'System.Runtime.InteropServices.Marshal.ReleaseComObject(swApp)
			'System.Runtime.InteropServices.Marshal.FinalReleaseComObject(swApp)

			'swApp = Nothing
			GC.Collect()
			GC.WaitForPendingFinalizers()

		End If
		e.Cancel = False
	End Sub

	Public Sub Start_Window_Load() Handles MyBase.Load
		'TODO: This line of code loads data into the 'AND_ExtrusionsDataSet.AND10139' table. You can move, or remove it, as needed.

		HelpToolStripMenuItem.Visible = False
		UpdateToolStripMenuItem.Visible = False


		TEST.Visible = False
		Save_As_DWG.Visible = False
		Save_As_STL.Visible = False
		'Note_Naming.Visible = False
		'Aircraft_Stringers.Visible = False
		Load_Analysis_2.Visible = False
		'Export_To_Excel.Visible = False

		If System.IO.Directory.Exists(SW_Path) Then
			SolidWorks_Interface.Visible = True
		Else
			SolidWorks_Interface.Visible = False
		End If

		'Dim SWProcess() As Process
		'Dim i As Integer
		Dim StartProcess As New System.Diagnostics.Process()
		'Dim Doc_Type As String

		AlwaysOnTopToolStripMenuItem.Checked = False

		'NewSize_X = OriginalSize_X - 321
		'Me.MinimumSize = New System.Drawing.Size(NewSize_X, Me.Height)
		'Me.Width = NewSize_X
		'MsgBox(Me.Width)



		ToolTip1.SetToolTip(SolidWorks_Interface, "Starts/Stops SolidWorks API")



		If Loaded = False Then
			Extra_Info.Text = ""
			SW_Doc.Text = ""

			NewSize_X = OriginalSize_X - 321
			Me.MinimumSize = New System.Drawing.Size(NewSize_X, Me.Height)
			Me.Width = NewSize_X

			SolidWorks_Interface.Checked = False

			Sheet_Metal_Group.Visible = False
			Solidworks_Functions_Group.Visible = False
			Solidworks_Modeling_Group.Visible = False
			AutoCad_Interface.Visible = False

			Loaded = True
		End If

		'Displays text whether SolidWorks is running or not
		'SWProcess = Process.GetProcessesByName("SLDWORKS")
		'If SWProcess.Count > 0 Then

		'	Status_Label.Text = Status_num(0) '"Solidworks Is Running"
		'	AlwaysOnTopToolStripMenuItem.Checked = True

		'	swApp = CreateObject("SldWorks.Application")
		'	swDoc = swApp.ActiveDoc()

		'	If swDoc IsNot Nothing Then

		'		Select Case swDoc.GetType
		'			Case CInt(0)
		'				Doc_Type = "Nothing"
		'			Case CInt(3)
		'				Doc_Type = "A Drawing"
		'			Case CInt(2)
		'				Doc_Type = "An Assembly"
		'			Case CInt(1)
		'				Doc_Type = "A Part"
		'			Case Else
		'				Doc_Type = "No Doc Loaded"
		'		End Select

		'	Else

		'		Doc_Type = "No Doc Loaded"

		'	End If
		'	SW_Doc.Text = "SolidWorks Loaded Document Is: " + Doc_Type

		'	If SWProcess.Count > 1 Then

		'		Process.Start("C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS (2)\swShellFileLauncher.exe")
		'		Functions.Error_Form("Too Many Solidworks' Running", " Solidworks are running", SWProcess.Count,,, False,)
		'		Status_Label.Text = Status_num(1) '"More Than One Solidworks Is Running"

		'		For j = 0 To SWProcess.Count - 1
		'			swApp.Visible = Visible
		'		Next

		'		For i = 0 To SWProcess.Count - 2
		'			System.Runtime.InteropServices.Marshal.ReleaseComObject(swApp)
		'			System.Runtime.InteropServices.Marshal.FinalReleaseComObject(swApp)
		'			SWProcess(i).CloseMainWindow()

		'			If SWProcess(i).HasExited = False Then
		'				SWProcess(i + 1).CloseMainWindow()
		'			End If
		'		Next

		'		AlwaysOnTopToolStripMenuItem.Checked = False

		'	End If

		'Else
		'	Status_Label.Text = Status_num(2) '"SolidWorks Is Not running" ', please be patient while SolidWorks opens."
		'	Process.Start("C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS (2)\swShellFileLauncher.exe")
		'	'Process.Start("C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\swShellFileLauncher.exe")
		'	Start_Window_Load()
		'End If

		AlwaysOnTopToolStripMenuItem_Click()

		'Add user to Current User.txt file
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

		'swApp.Visible = True
		'swApp.FrameState = 1

		'Update program here
		'Dim FileName As String = "" 'for testing purposes
		Dim FileName As String = "T:\Engineering\Non-Site Specific\PARTS\SW Macros\Model Creator\Version2.txt"


		If System.IO.File.Exists(FileName) Then
			Dim reader As New System.IO.StreamReader(FileName)
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
			Opacity = 0.9
		Else
			TopMost = False
			Opacity = 1
		End If

	End Sub



	''' <summary>
	''' Program Information
	''' </summary>
	Private Sub UpdateToolStripMenuItem_Click() Handles UpdateToolStripMenuItem.Click
		'MsgBox("Program needs updating")
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Version_Compare As Boolean

		new_Version = Cur_Version + " To " + Prog_Version

		Dim StartUpdate As New System.Diagnostics.Process()
		Version_Compare = Equals(Cur_Version, Prog_Version)


		If Version_Compare = False Then

			Functions.Error_Form("Program Update", "You are about to Update the Program",, new_Version,, False)

			AlwaysOnTopToolStripMenuItem.Checked = False
			AlwaysOnTopToolStripMenuItem_Click()

			Try
				StartUpdate = Process.Start("T:\Engineering\Non-Site Specific\PARTS\SW Macros\Model Creator\Engineering Assistant Installer.msi")

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

	Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
		Functions.Error_Form("Nothing ATM", "Not working yet",,,,, Me)
	End Sub

	Private Sub VersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VersionToolStripMenuItem.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		Functions.Error_Form("Program Version", Cur_Version, "Version: ",,,,)
	End Sub



	''' <summary>
	''' Builds L Angles, Z Angles, and Gussets
	''' </summary>
	Private Sub L_Angle_10133_Click(sender As Object, e As EventArgs) Handles L_Angle_10133.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Equal Leg L Angle Builder"
		Extra_Info.Text = ""
		Functions.Status = False

		SWFunctions.Connect_SW()

		Functions.Calling_Fun = "10133"
		Functions.Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Equal Leg L Angle has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()

		End If

		'SWFunctions.Remove_SW()

	End Sub

	Private Sub L_Angle_10134_Click(sender As Object, e As EventArgs) Handles L_Angle_10134.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Unequal Leg L Angle Builder"
		Extra_Info.Text = ""
		Functions.Status = False

		SWFunctions.Connect_SW()

		Functions.Calling_Fun = "10134"
		Functions.Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Unequal Leg L Angle has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()

		End If

		'SWFunctions.Remove_SW()

	End Sub

	Private Sub L_Angle_Custom_Click(sender As Object, e As EventArgs) Handles L_Angle_Custom.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Custom Leg L Angle Builder"
		Extra_Info.Text = ""
		Functions.Status = False

		SWFunctions.Connect_SW()

		Functions.Calling_Fun = "Custom L"
		Functions.Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Custom Leg L Angle has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()

		End If

		'SWFunctions.Remove_SW()

	End Sub

	Private Sub Z_Angle_10138_Click(sender As Object, e As EventArgs) Handles Z_Angle_10138.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Equal Leg L Angle Builder"
		Extra_Info.Text = ""
		Functions.Status = False

		SWFunctions.Connect_SW()

		Functions.Calling_Fun = "10138"
		Functions.Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Equal Leg L Angle has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()

		End If

		'SWFunctions.Remove_SW()

	End Sub

	Private Sub Z_Angle_10139_Click(sender As Object, e As EventArgs) Handles Z_Angle_10139.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Unequal Leg L Angle Builder"
		Extra_Info.Text = ""
		Functions.Status = False

		SWFunctions.Connect_SW()

		Functions.Calling_Fun = "10139"
		Functions.Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Unequal Leg L Angle has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()

		End If

		'SWFunctions.Remove_SW()

	End Sub

	Private Sub Z_Angle_Custom_Click(sender As Object, e As EventArgs) Handles Z_Angle_Custom.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Custom Leg L Angle Builder"
		Extra_Info.Text = ""
		Functions.Status = False

		SWFunctions.Connect_SW()

		Functions.Calling_Fun = "Custom Z"
		Functions.Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Custom Leg L Angle has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)
		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()

		End If

		'SWFunctions.Remove_SW()

	End Sub

	Private Sub Gusset_Custom_Click(sender As Object, e As EventArgs) Handles Gusset_Custom.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "Gusset Builder"
		Extra_Info.Text = ""
		Functions.Status = False

		SWFunctions.Connect_SW()

		Functions.Calling_Fun = "Gusset"
		Functions.Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "Gusset has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)

		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()

		End If

		'SWFunctions.Remove_SW()

	End Sub

	Private Sub U_Channel_Click(sender As Object, e As EventArgs) Handles U_Channel.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SW_Doc.Text = "U Channel Builder"
		Extra_Info.Text = ""
		Functions.Status = False

		SWFunctions.Connect_SW()

		Functions.Calling_Fun = "U Channel"
		Functions.Open_New_Form(Of Model_Builder)()

		If Functions.Status = True Then
			Extra_Info.Text = "U Channel has been created."
			Start_Window_Load()
			Save_As_New_Click(sender, e)

		Else
			Extra_Info.Text = "Operation failed."
			Start_Window_Load()

		End If

		'SWFunctions.Remove_SW()

	End Sub



	''' <summary>
	''' Viewing PDFs on the Network
	''' 
	''' </summary>
	Private Sub Frame_Station_Click(sender As Object, e As EventArgs) Handles Frame_Station.Click, ViewFrameStations.Click
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



	''' <summary>
	''' Solidwork Functions
	''' </summary>
	Private Sub New_Drawing_Click(sender As Object, e As EventArgs) Handles New_Drawing.Click, NewDrawingToolStripMenuItem.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		Functions.Status = False

		Debug.Print(TimeString)

		SWFunctions.Connect_SW()

		Dim count As Integer
		Dim index As Integer
		Dim Open_Docs As Object
		Dim FullPathName = String.Empty
		'Dim Errors As Integer
		'Dim Load As Boolean

		Dim UnsavedFiles As Integer = 0
		Dim OpenedDWG As Integer = 0
		Dim OpenedDWG_Name = String.Empty

		'swApp = CreateObject("SldWorks.Application")
		'Dim swDoc2 As ModelDoc2
		swDoc = SWFunctions.swApp.ActiveDoc
		count = SWFunctions.swApp.GetDocumentCount
		Open_Docs = SWFunctions.swApp.GetDocuments

		'MsgBox(Me.ToString)
		If count = 0 Then
			Functions.Error_Form("No Documents", "There are no documents loaded",,,, False,)
		Else

			For index = LBound(Open_Docs) To UBound(Open_Docs)
				swDoc = Open_Docs(index)
				FullPathName = swDoc.GetPathName()
				If FullPathName = "" Then
					'Functions.Error_Form("Unsaved File", "A file has not been saved.", "", "Please save all unsaved files.",, False,)
					Functions.Status = False
					UnsavedFiles += 1
					'Exit For
				Else
					Name = SWFunctions.SW_FileName(FullPathName)

					If swDoc.GetType = 3 Then

						'Functions.Error_Form("Drawing Already Loaded", "A drawing file is already loaded.", "", "Please close existing drawing files",, False,)
						Functions.Status = False
						OpenedDWG += 1

						If OpenedDWG = 1 Then
							OpenedDWG_Name = Name + ".SLDDRW"
						End If
						'Exit For
					Else

						Functions.Status = True

					End If

				End If

			Next

		End If

		If UnsavedFiles >= 1 And OpenedDWG >= 1 Then
			Functions.Error_Form("Unsaved Files and Opened Drawing", "You have " & UnsavedFiles &
								 " unsaved files opened",, "You have " & OpenedDWG & " opened drawings",, False,)
		ElseIf UnsavedFiles = 0 And OpenedDWG >= 1 Then
			Functions.Error_Form("Opened Drawing", "You have " & OpenedDWG & " opened drawings",,,, False,)

		ElseIf UnsavedFiles >= 1 And OpenedDWG >= 0 Then
			Functions.Error_Form("Unsaved Files", "You have " & UnsavedFiles & " unsaved files opened",,,, False,)

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
			'swDoc2 = SWFunctions.swApp.ActivateDoc3(OpenedDWG_Name, 1, 1, Errors)

			'swDoc = swApp.ActiveDoc
			Start_Window_Load()

		End If

		Debug.Print(TimeString & " --> " & SWFunctions.swAssy_Docs.Count & " - Assy, " & SWFunctions.swPart_Docs.Count & " - Part")
		'SWFunctions.Remove_SW()

	End Sub

	Private Sub Sheet_Rename_Click(sender As Object, e As EventArgs) Handles Sheet_Rename.Click, SheetRenameToolStripMenuItem.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean

		SWFunctions.Connect_SW()

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

		'SWFunctions.Remove_SW()

	End Sub

	Private Sub Add_Hardware_Click(sender As Object, e As EventArgs) Handles Add_Hardware.Click, OpenNewToolStripMenuItem.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SWFunctions.Connect_SW()

		SW_Doc.Text = "Add Hardware to BOM"
		Extra_Info.Text = ""
		Functions.Status = False

		swDoc = SWFunctions.swApp.ActiveDoc
		If swDoc.GetPathName() = "" Then
			Functions.Error_Form("File Is Not Saved", "Please save the file and try again")

		Else
			If swDoc.GetType = swDocumentTypes_e.swDocDRAWING Then
				Functions.Open_New_Form(Of BOM_Hardware)()
			Else
				Functions.Error_Form("Document Is Not A Drawing", "Opened document is not a drawing")
			End If
			Functions.Error_Form("Document Is Not Saved", "Please save and try agian")
		End If



		If Functions.Status = True Then
			Extra_Info.Text = "BOM Hardware has been added."
			Start_Window_Load()
		Else
			Extra_Info.Text = "BOM operation failed."
			Start_Window_Load()

		End If

		'SWFunctions.Remove_SW()

	End Sub

	Private Sub PDF_Drawing_Click(sender As Object, e As EventArgs) Handles PDF_Drawing.Click, PDFDrawing.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean

		SWFunctions.Connect_SW()

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

		'SWFunctions.Remove_SW()

	End Sub

	Private Sub Pack_N_Go_Click(sender As Object, e As EventArgs) Handles Pack_N_Go.Click, Pack_And_Go.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean

		SWFunctions.Connect_SW()

		SW_Doc.Text = "Pack And Go In Effect"
		Extra_Info.Text = ""
		'Status = SWFunctions.PackandGo2()
		Status = SWFunctions.IR_Pack_N_Go()

		If Status = True Then
			Extra_Info.Text = "Pack And Go has Completed."
			Start_Window_Load()
		Else
			Extra_Info.Text = "Pack And Go has Failed."
			Start_Window_Load()

		End If

		'SWFunctions.Remove_SW()

	End Sub

	Private Sub Remove_Config_Click(sender As Object, e As EventArgs) Handles Remove_Config.Click, RemoveConfigsToolStripMenuItem.Click

	End Sub

	Private Sub Save_As_STL_Click(sender As Object, e As EventArgs) Handles Save_As_STL.Click, SaveAsSTL.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean

		SWFunctions.Connect_SW()

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

		'SWFunctions.Remove_SW()

	End Sub

	Private Sub Save_As_New_Click(sender As Object, e As EventArgs) Handles SaveAsNew.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean

		SWFunctions.Connect_SW()

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

		'SWFunctions.Remove_SW()

	End Sub

	Private Sub Panel_Modeling_Click(sender As Object, e As EventArgs) Handles Panel_Modeling.Click

	End Sub

	Private Sub Contour_Plate_Modeling_Click(sender As Object, e As EventArgs) Handles Contour_Plate_Modeling.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SWFunctions.Connect_SW()

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

		'SWFunctions.Remove_SW()

	End Sub

	Private Sub Model_Properties_Click(sender As Object, e As EventArgs) Handles Model_Properties.Click

	End Sub

	Private Sub Library_Feature_Click(sender As Object, e As EventArgs) Handles Library_Feature.Click, LibraryFeatureToolStripMenuItem.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		SWFunctions.Connect_SW()

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

		'SWFunctions.Remove_SW()

	End Sub



	''' <summary>
	''' Various Math Functions
	''' </summary>
	Private Sub Cross_Product_Click(sender As Object, e As EventArgs) Handles Cross_Product.Click, CrossProductToolStripMenuItem.Click
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

		If Functions.Status = True Then
			Extra_Info.Text = "Load Analysis Complete"
			Start_Window_Load()
		Else
			Extra_Info.Text = "Operation Failed."
			Start_Window_Load()

		End If
	End Sub

	Private Sub DataBaseHereToolStripMenuItem_Click(sender As Object, e As EventArgs)
		'Dim conn As New SqlConnection
		'conn.Open()
		'Dim comm As New SqlCommand("Select", conn
		'	Dim reader As
	End Sub

	Private Sub DataTest_Click(sender As Object, e As EventArgs) Handles Note_Naming.Click

		Dim swDrawing As DrawingDoc
		Dim swDoc2 As ModelDoc2
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

		swApp = CreateObject("SldWorks.Application")
		swDoc = swApp.ActiveDoc

		If swDoc.GetType = swDocumentTypes_e.swDocDRAWING Then


			swDrawing = swApp.ActiveDoc

			'fileName = "C:\Users\mfrench\Engineering Stuff\Note Naming Dwg.SLDDRW"
			'swDrawing = swApp.OpenDoc6(fileName, 3, 0, "", errors, warnings)

			'Get drawing views and names of annotations in
			'each drawing view

			swDoc2 = swApp.ActiveDoc
			swExtension = swDoc2.Extension

			Status = swExtension.LoadDraftingStandard("T:\Engineering\East Alton\ENGINEERING PROCEDURES\Structural Drawing Standards\SolidWorks Standard Jul-30-2021.sldstd")

			If Status = False Then
				MsgBox("Standards didn't load")
			End If

			Sheetnumbers = swDrawing.GetSheetCount - 1
			sheetnames = swDrawing.GetSheetNames



			For i = 0 To (Sheetnumbers)
				swDrawing.ActivateSheet(sheetnames(i))
				If i = 0 Then
					swDrawing.SetupSheet6(sheetnames(i), 12, 12, 1, 1, False, "T:\Engineering\East Alton\ENGINEERING PROCEDURES\Structural Drawing Standards\2021 Cover Sheet.slddrt", 0.4318, 0.2794, "Default", True, 0, 0, 0, 0, 0, 0)
				Else
					swDrawing.SetupSheet6(sheetnames(i), 12, 12, 1, 1, False, "T:\Engineering\East Alton\ENGINEERING PROCEDURES\Structural Drawing Standards\2021 Additional Sheet.slddrt", 0.4318, 0.2794, "Default", True, 0, 0, 0, 0, 0, 0)
				End If
				swSheet = swDrawing.GetCurrentSheet
				'swSheet.SetName("Renaming" & i)
			Next

			swDrawing.ActivateSheet(sheetnames(0))

			Status = swExtension.SetUserPreferenceToggle(swUserPreferenceToggle_e.swDetailingShowPeriodWithBorders, swUserPreferenceOption_e.swDetailingNoOptionSpecified, False)



			If Status = False Then
				Functions.Error_Form("Annotation period border setting", "Setting is checked",, "Please uncheck setting")

			End If



			'Update Sheet formats
			'Get Sheet numbers
			'for sheet 0 to sheet end
			'update notes on sheet

			'swDrawing.SheetNext()


			For i = 0 To (Sheetnumbers)
				swDrView = swDrawing.GetFirstView
				While Not swDrView Is Nothing
					Debug.Print("Name of drawing view: " & swDrView.GetName2)
					annArray = swDrView.GetAnnotations
					If Not annArray Is Nothing Then
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

		'Dim swLayer As Layer



		swApp = CreateObject("SldWorks.Application")
		swDoc = swApp.ActiveDoc

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
					'If swSubFeat.GetTypeName = "" Then

					'End If
				End While

				swFeature = swFeature.GetNextFeature

			End While

			If Insert_WeightTable = True Then
				Sheetnumbers = swDoc.GetSheetCount - 1
				sheetnames = swDoc.GetSheetNames
				swDoc.ActivateSheet(sheetnames(0))
				swTableAnnotation = swDoc.InsertTableAnnotation2(False, 0.6 / 39.37, 2 / 39.37, 4, "T:\Engineering\East Alton\ENGINEERING PROCEDURES\Structural Drawing Standards\Weight Table.sldtbt", 8, 4)

			End If

			If Insert_BOMTable = True Then
				Sheetnumbers = swDoc.GetSheetCount - 1
				sheetnames = swDoc.GetSheetNames
				swDoc.ActivateSheet(sheetnames(0))
				swTableAnnotation = swDoc.InsertTableAnnotation2(False, 16.348 / 39.37, 2.004 / 39.37, 4, "T:\Engineering\East Alton\ENGINEERING PROCEDURES\Structural Drawing Standards\BOM file name linked.sldtbt", 29, 13)
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



	End Sub



	Private Sub Test_Click(sender As Object, e As EventArgs) Handles Export_To_Excel.Click
		Dim swDoc As ModelDoc2
		Dim swComp As Component2
		Dim swConfMgr As ConfigurationManager
		Dim swConf As Configuration
		Dim Path As String
		Dim filename As String
		Dim Opened_Files_Count As Integer

		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()

		swApp = CreateObject("SldWorks.Application")
		swDoc = swApp.ActiveDoc

		Opened_Files_Count = swApp.GetDocumentCount
		If Opened_Files_Count >= 1 Then


			If swDoc.GetPathName <> "" Then

				Path = System.IO.Path.GetDirectoryName(swDoc.GetPathName)
				filename = SWFunctions.SW_FileName(swDoc.GetPathName)

				If swDoc.GetType = swDocumentTypes_e.swDocASSEMBLY Or swDoc.GetType = swDocumentTypes_e.swDocDRAWING Then

					SWFunctions.swAssy_Docs.Clear()
					SWFunctions.swPart_Docs.Clear()
					SWFunctions.swDwg_Docs.Clear()

					swConfMgr = swDoc.ConfigurationManager
					swConf = swConfMgr.ActiveConfiguration
					swComp = swConf.GetRootComponent3(True)

					Debug.Print(TimeString)
					SWFunctions.Add_Docs2(swComp, 1)
					SWFunctions.Out_Put()

					'SWFunctions.Docs_To_Excel(Path, SWFunctions.swAssy_Docs(SWFunctions.swAssy_Docs.Count - 1).Nomenclature) 'filename)
					SWFunctions.Docs_To_Excel(Path, SWFunctions.swAssy_Docs(0).Nomenclature) 'filename)
					Debug.Print(TimeString & " --> " & SWFunctions.swAssy_Docs.Count + SWFunctions.swPart_Docs.Count)


				End If

				If swDoc.GetType <> swDocumentTypes_e.swDocPART Then

				End If
			Else
				Functions.Error_Form("Document is not saved", "Please save file and try again")
			End If
		Else
			Functions.Error_Form("No Document Loaded", "No SolidWorks document is open")
		End If
	End Sub

	Private Sub SolidWorks_Interface_CheckedChanged(sender As Object, e As EventArgs) Handles SolidWorks_Interface.CheckedChanged
		If SolidWorks_Interface.Checked = True Then
			NewSize_X = OriginalSize_X
			Me.MinimumSize = New System.Drawing.Size(NewSize_X, Me.Height)
			Me.Width = NewSize_X
			SWFunctions.Connect_SW()
			Sheet_Metal_Group.Visible = True
			Solidworks_Functions_Group.Visible = True
			Solidworks_Modeling_Group.Visible = True


			'Me.MinimumSize = OriginalSize_X - 321
		End If
		If SolidWorks_Interface.Checked = False Then

			SWFunctions.Remove_SW()
			Sheet_Metal_Group.Visible = False
			Solidworks_Functions_Group.Visible = False
			Solidworks_Modeling_Group.Visible = False

			NewSize_X = OriginalSize_X - 321
			Me.MinimumSize = New System.Drawing.Size(NewSize_X, Me.Height)
			Me.Width = NewSize_X



		End If
	End Sub

	Private Sub AutoCad_Interface_CheckedChanged(sender As Object, e As EventArgs) Handles AutoCad_Interface.CheckedChanged

	End Sub

	Private Sub Load_Analysis_2_Click(sender As Object, e As EventArgs) Handles Load_Analysis_2.Click

		''This is to test some logic

		'Dim status As Boolean = False
		'Dim buttoncount As Integer = 0

		'While (True)
		'	If buttoncount = 5 Then
		'		buttoncount = 0
		'	End If


		'	Debug.Print(NewButton & " ---- " & OldButton)

		'	If NewButton <> OldButton Then
		'		'Button was pushed


		'		If buttoncount = 1 Then
		'			Debug.Print("1")
		'		End If
		'		If buttoncount = 2 Then
		'			Debug.Print("2")
		'		End If
		'		If buttoncount = 3 Then
		'			Debug.Print("3")
		'		End If
		'		If buttoncount = 4 Then
		'			Debug.Print("4")
		'		End If
		'		If buttoncount = 5 Then
		'			Debug.Print("5")
		'		End If

		'		buttoncount += 1

		'	End If

		'	OldButton = NewButton

		'End While

	End Sub

	Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

		If e.KeyCode = Keys.K Then
			NewButton = True
		Else
			NewButton = False
		End If

	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Test_Button.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean

		SWFunctions.Connect_SW()

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

		''Dim swDoc As ModelDoc2
		''Dim swComp As Component2
		''Dim swConfMgr As ConfigurationManager
		''Dim swConf As Configuration

		''Dim Path As String
		''Dim filename As String
		''Dim Opened_Files_Count As Integer

		''AlwaysOnTopToolStripMenuItem.Checked = False
		''AlwaysOnTopToolStripMenuItem_Click()

		''swApp = CreateObject("SldWorks.Application")
		''swDoc = swApp.ActiveDoc
		''Opened_Files_Count = swApp.GetDocumentCount
		''Path = System.IO.Path.GetDirectoryName(swDoc.GetPathName)
		''filename = SWFunctions.SW_FileName(swDoc.GetPathName)

		''If swDoc.GetType = swDocumentTypes_e.swDocDRAWING Then
		''	SWFunctions.Add_RevInfo()
		''End If

		'If swDoc.GetType <> swDocumentTypes_e.swDocDRAWING Then

		'	SWFunctions.Rename_Files = True
		'	SWFunctions.swAssy_Docs.Clear()
		'	SWFunctions.swPart_Docs.Clear()
		'	SWFunctions.swDwg_Docs.Clear()

		'	swConfMgr = swDoc.ConfigurationManager
		'	swConf = swConfMgr.ActiveConfiguration
		'	swComp = swConf.GetRootComponent3(True)

		'	Debug.Print(TimeString)
		'	SWFunctions.Add_Docs2(swComp, 1)

		'	SWFunctions.Rename_Files_with_PN()
		'	SWFunctions.Out_Put()
		'	'SWFunctions.Docs_To_Excel(Path, SWFunctions.swAssy_Docs(SWFunctions.swAssy_Docs.Count - 1).Nomenclature)

		'	Debug.Print(TimeString & " --> " & SWFunctions.swAssy_Docs.Count + SWFunctions.swPart_Docs.Count)


		'End If

		'If swDoc.GetType <> swDocumentTypes_e.swDocPART Then

		'End If




		'AlwaysOnTopToolStripMenuItem.Checked = False
		'AlwaysOnTopToolStripMenuItem_Click()

		'Functions.Status = False


		'SWFunctions.Connect_SW()

		'Dim count As Integer
		'Dim index As Integer
		'Dim Open_Docs As Object
		'Dim FullPathName = String.Empty
		''Dim Errors As Integer
		''Dim Load As Boolean

		'Dim UnsavedFiles As Integer = 0
		'Dim OpenedDWG As Integer = 0
		'Dim OpenedDWG_Name = String.Empty

		''swApp = CreateObject("SldWorks.Application")
		''Dim swDoc2 As ModelDoc2
		'swDoc = SWFunctions.swApp.ActiveDoc
		'count = SWFunctions.swApp.GetDocumentCount
		'Open_Docs = SWFunctions.swApp.GetDocuments

		''MsgBox(Me.ToString)
		'If count = 0 Then
		'	Functions.Error_Form("No Documents", "There are no documents loaded",,,, False,)
		'Else

		'	For index = LBound(Open_Docs) To UBound(Open_Docs)
		'		swDoc = Open_Docs(index)
		'		FullPathName = swDoc.GetPathName()
		'		If FullPathName = "" Then
		'			'Functions.Error_Form("Unsaved File", "A file has not been saved.", "", "Please save all unsaved files.",, False,)
		'			Functions.Status = False
		'			UnsavedFiles += 1
		'			'Exit For
		'		Else
		'			Name = SWFunctions.SW_FileName(FullPathName)

		'			If swDoc.GetType = 3 Then

		'				'Functions.Error_Form("Drawing Already Loaded", "A drawing file is already loaded.", "", "Please close existing drawing files",, False,)
		'				Functions.Status = False
		'				OpenedDWG += 1

		'				If OpenedDWG = 1 Then
		'					OpenedDWG_Name = Name + ".SLDDRW"
		'				End If
		'				'Exit For
		'			Else

		'				Functions.Status = True

		'			End If

		'		End If

		'	Next

		'End If

		'If UnsavedFiles >= 1 And OpenedDWG >= 1 Then
		'	Functions.Error_Form("Unsaved Files and Opened Drawing", "You have " & UnsavedFiles &
		'						 " unsaved files opened",, "You have " & OpenedDWG & " opened drawings",, False,)
		'ElseIf UnsavedFiles = 0 And OpenedDWG >= 1 Then
		'	Functions.Error_Form("Opened Drawing", "You have " & OpenedDWG & " opened drawings",,,, False,)

		'ElseIf UnsavedFiles >= 1 And OpenedDWG >= 0 Then
		'	Functions.Error_Form("Unsaved Files", "You have " & UnsavedFiles & " unsaved files opened",,,, False,)

		'End If


		'If Functions.Status = True Then

		'	SWFunctions.Rename_Files = True
		'	SW_Doc.Text = "A New Drawing has Opened"
		'	Extra_Info.Text = ""
		'	Functions.Open_New_Form(Of New_Drawing)()

		'End If

		'If Functions.Status = True Then
		'	Extra_Info.Text = "Drawing has been created."
		'	If SWFunctions.Add_BOM = True Then
		'		Add_Hardware.PerformClick()
		'	End If
		'	Start_Window_Load()
		'Else
		'	Extra_Info.Text = "Drawing operation failed."
		'	'swDoc2 = SWFunctions.swApp.ActivateDoc3(OpenedDWG_Name, 1, 1, Errors)

		'	'swDoc = swApp.ActiveDoc
		'	Start_Window_Load()

		'End If

		''SWFunctions.Remove_SW()
	End Sub

	Private Sub Aircraft_Stringer_Charts(sender As Object, e As EventArgs) Handles Aircraft_Stringers.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		SW_Doc.Text = "View Existing Aircraft Stringers"
		Functions.Open_New_Form(Of Existing_Aircrafts_Stringers)()
		Start_Window_Load()
	End Sub

	Private Sub Start_Window_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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


		SWFunctions.Connect_SW()
		swDoc = SWFunctions.swApp.ActiveDoc

		'swDoc = swApp.ActiveDoc
		FullPathName = swDoc.GetPathName()

		If FullPathName = "" Then
			Functions.Error_Form("File not saved", "Save file and retry.")
		Else

			swModelDocExt = swDoc.Extension
			CusProperties = swModelDocExt.CustomPropertyManager("")

			Select Case PC_USER
				Case "mfrench"
					PC_USER = "M. FRENCH"
				Case "scisler"
					PC_USER = "S. CISLER"
				Case "ehaycraft"
					PC_USER = "E. Haycraft"
				Case "jfox"
					PC_USER = "J. FOX"
				Case "nbrown"
					PC_USER = "N. BROWN"
				Case "lsova"
					PC_USER = "L. SOVA"
				Case "KArthurs"
					PC_USER = "K. ARTHURS"
				Case "acrowe"
					PC_USER = "A. CROWE"
				Case "dcarter"
					PC_USER = "D. CARTER"
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





	End Sub

	Private Sub Save_As_DWG_Click(sender As Object, e As EventArgs) Handles Save_As_DWG.Click
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean

		SWFunctions.Connect_SW()

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

		'SWFunctions.Remove_SW()
	End Sub

	Private Sub Save_As_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Save_As_Type.SelectedIndexChanged
		AlwaysOnTopToolStripMenuItem.Checked = False
		AlwaysOnTopToolStripMenuItem_Click()
		Dim Status As Boolean
		Dim Filetype As String

		SWFunctions.Connect_SW()

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
End Class
