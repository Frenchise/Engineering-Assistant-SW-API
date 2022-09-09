Imports System.Runtime.InteropServices
Imports SwConst
Imports SwCommands
Imports SldWorks

Public Class Lib_Feat_Add

    Dim LibRefs() As DispatchWrapper
    Dim Dir As String = "T:\Engineering\Non-Site Specific\PARTS\LIBRARY\Footprint Hole Features"



	Private Sub Form_Resize() Handles Me.ResizeEnd
		Functions.Form_resize(Me)
	End Sub

	Private Sub Lib_Feat_Add_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Form_Resize()

		Dim file = String.Empty
		Dim File_name = String.Empty

		Functions.Check_Directory(Dir, ComboBox1)

	End Sub

	Private Sub Add_Lib_To_Part_Click(sender As Object, e As EventArgs) Handles Add_Lib_To_Part.Click

        Dim Select_ID As New Error_Message
		Dim swApp As SldWorks.SldWorks
		Dim swDoc As ModelDoc2
        Dim Part As PartDoc
		Dim Generic_Error As New Error_Message

		swApp = CreateObject("SldWorks.Application")
		swDoc = swApp.ActiveDoc



		'--------------------------'

		Dim swSelMgr As SelectionMgr
        Dim swFeatMgr As FeatureManager
        Dim swLibFeat As LibraryFeatureData
        'Dim swModelDocExtension As ModelDocExtension

        Dim INtoM As Double
        Dim RadtoDegree As Double
        Dim Vertical As Double
        Dim Horizontal As Double
        Dim Angle As Double

        Dim selcount As Integer
        'Dim RefCount As Integer
        Dim j As Integer
        Dim k As Integer

        Dim selectedObjects() As Object
        Dim Refs As Object = Nothing
        Dim RefTypes As Object = Nothing
        Dim RefInsert As Object = Nothing

        Dim boolstatus As Boolean

        Dim FeatName As Feature
        Dim swSubFeat As Feature
        Dim swSubSubFeat As Feature
        Dim swFeat As Feature

        Dim Sketch_Name As String
        Dim Name As String
        Dim Vertical_Sketch_Name As String
        Dim Horizontal_Sketch_Name As String
        Dim Rotatioin_Sketch_Name As String

        Dim SketchFeature As String = "ProfileFeature"
        Dim LibFeature As String = "LibraryFeature"
        Dim HoleWiz As String = "HoleWzd"



        '--------------------------'


        INtoM = (1 / 25.4) * 1000
		RadtoDegree = Math.PI / 180

		If swDoc Is Nothing Then

			Functions.Error_Form("Error", "No document is loaded.",,,, False, Me)
			Functions.Status = False

		Else

			If swDoc.GetType <> 1 Then

				Functions.Error_Form("Error", "This is not a part file",,,, False, Me)
				Functions.Status = False

			Else

				Part = swApp.ActiveDoc

				swFeatMgr = swDoc.FeatureManager
				swLibFeat = swFeatMgr.CreateDefinition(SwConst.swFeatureNameID_e.swFmLibraryFeature)

				Dir = Dir + "\" + ComboBox1.Text + ".sldlfp"
				boolstatus = swLibFeat.Initialize(Dir)

				'RefCount = swLibFeat.GetReferencesCount
				'Refs = swLibFeat.GetReferences2(swLibFeatureData_e.swLibFeatureData_FeatureRespect, RefTypes)
				swLibFeat.ConfigurationName = "Default"

				'swModelDocExtension = swDoc.Extension
				swSelMgr = swDoc.SelectionManager

				'selects selection 1 which is the insert face/plane
				Select_ID.PassedText = "Select Insert Face"
				Select_ID.FormName = "Library Insert Selection"
				Select_ID.StartPosition = FormStartPosition.CenterParent
				Select_ID.ShowDialog()
				Me.Show()

				swFeat = swFeatMgr.CreateFeature(swLibFeat)
				swLibFeat = Nothing
				swLibFeat = swFeat.GetDefinition()
				boolstatus = swLibFeat.AccessSelections(swDoc, Nothing)

				'select both edges
				Select_ID.PassedText = "CTRL Select Both Edges"
				Select_ID.TextLine2 = "First Selected Edge Dictates Vertical"
				Select_ID.TextLine3 = "Second Edge Is To The Right Of The First Edge"
				Select_ID.FormName = "Library Insert Selection"
				Select_ID.StartPosition = FormStartPosition.CenterParent
				Select_ID.ShowDialog()
				Me.Show()

				selcount = swSelMgr.GetSelectedObjectCount2(-1)

				ReDim selectedObjects(selcount)

				For k = 0 To (selcount - 1)
					selectedObjects(k) = swSelMgr.GetSelectedObject6(k + 1, -1)
				Next

				ReDim Preserve selectedObjects(selcount - 1)

				LibRefs = ObjectArrayToDispatchWrapperArray(selectedObjects)

				swLibFeat.SetReferences(LibRefs)

				boolstatus = swFeat.ModifyDefinition(swLibFeat, swDoc, Nothing)

				swDoc.ClearSelection()

				Sketch_Name = ComboBox1.Text

				j = 0
				Name = Sketch_Name
				FeatName = swDoc.FirstFeature()

				While Not FeatName Is Nothing
					If LibFeature = FeatName.GetTypeName2() Then

						swSubFeat = FeatName.GetFirstSubFeature()

						While Not swSubFeat Is Nothing
							If HoleWiz = swSubFeat.GetTypeName2() Then

								swSubSubFeat = swSubFeat.GetFirstSubFeature()

								While Not swSubSubFeat Is Nothing
									If Name = swSubSubFeat.Name Then

										j += 1
										Name = Sketch_Name + j.ToString()

									End If
									swSubSubFeat = swSubSubFeat.GetNextSubFeature()

								End While

							End If
							swSubFeat = swSubFeat.GetNextSubFeature()

						End While

					End If
					FeatName = FeatName.GetNextFeature()

				End While

				j -= 1

				If j <> 0 Then
					Sketch_Name = Sketch_Name + j.ToString()
				End If


				If Vertical_Dimension.Text <> "" Then

					If Double.TryParse(Vertical_Dimension.Text, Vertical) Then

						Vertical = Vertical / INtoM
						Vertical_Sketch_Name = "Vertical Direction@" + Sketch_Name
						swDoc.Parameter(Vertical_Sketch_Name).systemValue = Vertical

					Else
						MsgBox("Parse Failed, Enter a Number Next Time")

					End If

				End If

				If Horizontal_Dimension.Text <> "" Then

					If Double.TryParse(Horizontal_Dimension.Text, Horizontal) Then

						Horizontal = Horizontal / INtoM
						Horizontal_Sketch_Name = "Horizontal Direction@" + Sketch_Name
						swDoc.Parameter(Horizontal_Sketch_Name).systemValue = Horizontal

					Else
						MsgBox("Parse Failed, Enter a Number Next Time")

					End If

				End If

				If Rotation_Angle.Text <> "" Then

					If Double.TryParse(Rotation_Angle.Text, Angle) Then

						Angle = (Angle + 90) * RadtoDegree
						Rotatioin_Sketch_Name = "Rotation@" + Sketch_Name
						swDoc.Parameter(Rotatioin_Sketch_Name).systemValue = Angle

					Else
						MsgBox("Parse Failed, Enter a Number Next Time")

					End If

				End If

				swDoc.ForceRebuild3(True)
				Functions.Status = True
			End If
		End If
		Me.Close()
	End Sub



    Function ObjectArrayToDispatchWrapperArray(ByVal Objects As Object()) As DispatchWrapper()
        Dim ArraySize As Integer
        ArraySize = Objects.GetUpperBound(0)
        Dim d(ArraySize) As DispatchWrapper
        Dim ArrayIndex As Integer
        For ArrayIndex = 0 To ArraySize
            d(ArrayIndex) = New DispatchWrapper(Objects(ArrayIndex))
        Next
        Return d
    End Function


End Class


