Imports System.IO
Imports System.Runtime.InteropServices

Public Class Aircraft_Frames

    Dim dir = "T:\Engineering\Non-Site Specific\PARTS\LIBRARY\Aircraft Frame Station"
    Dim PDF_dir As String
    Dim dir_Manufacturer As String
    Dim dir_Aircraft As String
    Dim Dir_Exist As Boolean
    Dim PDF_Selected As Boolean = False

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
        Aircraft_PDF_Label.Visible = False
        Aircraft_PDF.Visible = False

		If Dir_Exist Then

			Directory_Exist.Text = "Frame Station Directory Exists"

			Aircraft_Type.Items.Clear()
			Aircraft_Type.Text = ""
			Aircraft_PDF.Items.Clear()
			Aircraft_PDF.Text = ""

			Dim folder = String.Empty
			Dim Folder_name = String.Empty

			For Each folder In System.IO.Directory.GetDirectories(dir)

				Folder_name = System.IO.Path.GetFileNameWithoutExtension(folder)
				Manufacturer.Items.Add(Folder_name)

			Next

		Else

			Functions.Error_Form("Error", "Frame Station Directory Does not Exist",,,, False, Me)
			Directory_Exist.Text = "Frame Station Directory Does not Exist"

		End If

    End Sub

    Private Sub Manufacturer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Manufacturer.SelectedIndexChanged

        Aircraft_Type_Label.Visible = True
        Aircraft_Type.Visible = True
        Aircraft_PDF_Label.Visible = False
        Aircraft_PDF.Visible = False
        PDF_Selected = False

        Aircraft_Type.Items.Clear()
        Aircraft_Type.Text = ""
        Aircraft_PDF.Items.Clear()
        Aircraft_PDF.Text = ""

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

        'MsgBox("hello")

    End Sub

    Private Sub Aircraft_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Aircraft_Type.SelectedIndexChanged

        Aircraft_PDF_Label.Visible = True
        Aircraft_PDF.Visible = True
        PDF_Selected = False

        Aircraft_PDF.Items.Clear()
        Aircraft_PDF.Text = ""

        'MsgBox(Aircraft_Type.Text)
        dir_Aircraft = dir_Manufacturer + "\" + Aircraft_Type.Text
        'MsgBox(Dir)
        Dir_Exist = Directory.Exists(dir_Aircraft)
        If Dir_Exist Then

            Dim file = String.Empty
            Dim File_name = String.Empty

            For Each file In System.IO.Directory.GetFiles(dir_Aircraft, "*.pdf")

                File_name = System.IO.Path.GetFileNameWithoutExtension(file)
                Aircraft_PDF.Items.Add(File_name)

            Next

        End If

    End Sub

    Private Sub Aircraft_PDF_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Aircraft_PDF.SelectedIndexChanged
        'MsgBox("true")
        PDF_Selected = True
    End Sub

    Private Sub Open_PDF_Click(sender As Object, e As EventArgs) Handles Open_PDF.Click

        PDF_dir = dir_Aircraft + "\" + Aircraft_PDF.Text + ".pdf"

        If PDF_Selected = True Then
            Process.Start(PDF_dir)
        Else
			Functions.Error_Form("F.S. PDF Viewer", "No PDF Selected",,,, False, Me)
		End If

        'Aircraft_Frames_Load()
    End Sub

    Private Sub Aircraft_Frames_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class