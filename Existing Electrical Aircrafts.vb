Imports System.IO
Imports System.Runtime.InteropServices

Public Class Existing_Electrical_Aircrafts

    Dim dir = "T:\Engineering\Non-Site Specific\AIRCRAFT DATA"
    Dim PDF_dir As String
    Dim dir_Manufacturer As String
    Dim dir_Aircraft As String
    Dim Aircraft_Serial As String
    Dim Structure_PDF As String
    Dim Dir_Exist As Boolean
    Dim PDF_Selected As Boolean = False
    Dim Item_Count As Integer

    Dim OG_LIST As New List(Of String)
    'Dim Directories As String

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

        Dir_Exist = Directory.Exists(dir)
        Aircraft_Type_Label.Visible = False
        Aircraft_Type.Visible = False
        Existing_Electrical_PDFs.Visible = False

        If Dir_Exist Then

            Directory_Exist.Text = "Aircraft Data Directory Exists"

            Aircraft_Type.Items.Clear()
            Aircraft_Type.Text = ""

            Dim folder = String.Empty
            Dim Folder_name = String.Empty

            For Each folder In System.IO.Directory.GetDirectories(dir)

                Folder_name = System.IO.Path.GetFileNameWithoutExtension(folder)
                Manufacturer.Items.Add(Folder_name)

            Next

        Else

			Functions.Error_Form(, "Aircraft Data Directory Does not Exist",,,, False, Me)

			Directory_Exist.Text = "Aircraft Data Directory Does not Exist"
            Dim Errorfrm As New Error_Message
            ''use the following to pass an error message to the Error Message Form
            'Errorfrm.PassedText = "Frame Station Directory Does not Exist"
            'Errorfrm.StartPosition = FormStartPosition.CenterParent
            'Errorfrm.ShowDialog()

        End If

    End Sub

    Private Sub Manufacturer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Manufacturer.SelectedIndexChanged

        Aircraft_Type_Label.Visible = True
        Aircraft_Type.Visible = True
        Existing_Electrical_PDFs.Visible = False
        PDF_Amount.Visible = False
        PDF_Selected = False

        Aircraft_Type.Items.Clear()
        Aircraft_Type.Text = ""

        dir_Manufacturer = dir + "\" + Manufacturer.Text

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

        Existing_Electrical_PDFs.Visible = True
        PDF_Amount.Visible = True
        PDF_Amount.Text = ""
        PDF_Selected = False

        Existing_Electrical_PDFs.Items.Clear()
        Existing_Electrical_PDFs.Text = ""

        dir_Aircraft = dir_Manufacturer + "\" + Aircraft_Type.Text

        Dir_Exist = Directory.Exists(dir_Aircraft)
        If Dir_Exist Then

            Dim file = String.Empty
            Dim File_name = String.Empty
            Dim Folder_name = String.Empty
            Dim Folder = String.Empty
            Dim Structural_Folder = String.Empty

			For Each Folder In System.IO.Directory.GetDirectories(dir_Aircraft)

				For Each Structural_Folder In System.IO.Directory.GetDirectories(Folder, "ELECTRICAL")

					Folder_name = System.IO.Path.GetFileNameWithoutExtension(Folder)

					For Each file In System.IO.Directory.GetFiles(Structural_Folder, "*.pdf")

						File_name = System.IO.Path.GetFileNameWithoutExtension(file)
						Existing_Electrical_PDFs.Items.Add(File_name & " - " & Folder_name)
						Item_Count = Existing_Electrical_PDFs.Items.Count

					Next

				Next

			Next

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
		End If

	End Sub

	Private Sub Existing_Structural_PDFs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Existing_Electrical_PDFs.SelectedIndexChanged

		If Item_Count = 0 Then

			PDF_Selected = False
		Else

			Dim Team As String = Existing_Electrical_PDFs.Text

			Dim tm As String() = Team.Split(New String() {" - "}, StringSplitOptions.None)

            Aircraft_Serial = tm(1)
            Structure_PDF = tm(0)

            PDF_Selected = True

		End If

	End Sub

	Private Sub Existing_Structral_PDFs_DoubleClick(sender As Object, e As EventArgs) Handles Existing_Electrical_PDFs.DoubleClick
		Open_PDF_Click(sender, e)
	End Sub

	Private Sub Open_PDF_Click(sender As Object, e As EventArgs) Handles Open_PDF.Click

		PDF_dir = dir_Aircraft + "\" + Aircraft_Serial + "\ELECTRICAL\" + Structure_PDF + ".pdf"

        If PDF_Selected = True And System.IO.File.Exists(PDF_dir) Then
            Process.Start(PDF_dir)
        Else
            Functions.Error_Form("F.S. PDF Viewer", "No PDF Selected",,,, False, Me)
		End If

    End Sub

End Class