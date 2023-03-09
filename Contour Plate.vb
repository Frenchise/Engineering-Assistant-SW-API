Imports System.IO
Imports System.Runtime.InteropServices
Imports SwConst
Imports SwCommands
Imports SldWorks

Public Class Contour_Plate

	Dim swApp As SldWorks.SldWorks
	Dim swDraw As DrawingDoc
    Dim swPart As PartDoc
	Dim SWSheet As Sheet
	Dim swDoc As ModelDoc2
    Dim swFeat As Feature

    Dim fileerror As Integer
    Dim filewarning As Integer
    Dim config As Configuration
    Dim CusProperties As CustomPropertyManager
    Dim swModelDocExt As ModelDocExtension
    Dim Prop_Result As Integer

    'Custom Property Names
    Dim swPitch_Angle As String = "PITCH ANGLE"
    Dim swLateral_Angle As String = "LATERAL ANGLE"
    Dim swFWD_Radius As String = "RADIUS1"
    Dim swAFT_Radius As String = "RADIUS2"
	Dim swRot_Angle As String = "ROTATION ANGLE"



	Dim Dir As String

    Dim LibRefs() As DispatchWrapper

    Structure Angles
        Public FWD As String
        Public Lateral As String
        Public Pitch As String
        Public Radius As String

    End Structure


    Private Sub Contour_Plate_Load() Handles MyBase.Load

		Form_Resize()
		Initialize_Form()
		Functions.Status = False

	End Sub

	Private Sub Form_Resize() Handles Me.ResizeEnd
		Functions.Form_resize(Me)
	End Sub

	Function Initialize_Form()

        No_Pitch_Angle.Checked = True
        No_Lateral_Angle.Checked = True
        Belly_Flat.Checked = True

        Angle_Down.Visible = False
        Angle_Down_Input.Visible = False
        Angle_Up_Input.Visible = False
        Angle_Up.Visible = False

        Angle_Right_Input.Visible = False
        Angle_Right.Visible = False
        Angle_Left_Input.Visible = False
        Angle_Left.Visible = False

        FWD_Radius.Visible = False
        FWD_Radius_Label.Visible = False
        AFT_Radius.Visible = False
        Aft_Radius_Label.Visible = False

        'Not visible till I figure the logic how to Spline the contours
        Belly_Spline.Visible = False

        Return True

    End Function


	Private Sub Run_Contours_Click(sender As Object, e As EventArgs) Handles Run_Contours.Click
        Dim status As Boolean
        Dim Lateral_Angle As Double
        Dim Pitch_Angle As Double
        Dim FWD_Radii As Double
        Dim AFT_Radii As Double
        Dim Rot_Angle As Double
		Dim Aircraft_Angles As Angles

        Aircraft_Angles.FWD = Nothing
        Aircraft_Angles.Lateral = Nothing
        Aircraft_Angles.Pitch = Nothing
        Aircraft_Angles.Radius = Nothing


        'FWD Directions
        If FWD_Right.Checked = True Then
            Aircraft_Angles.FWD = "Right"
        Else
            Aircraft_Angles.FWD = "Left"
        End If

        'Lateral Angle
        If No_Lateral_Angle.Checked = True Then
            Aircraft_Angles.Lateral = "No"
        ElseIf Lateral_Left_Angle.Checked = True Then
            Aircraft_Angles.Lateral = "Left"
        ElseIf Lateral_Right_Angle.Checked = True Then
            Aircraft_Angles.Lateral = "Right"
        End If

        'Pitch Angle
        If No_Pitch_Angle.Checked = True Then
            Aircraft_Angles.Pitch = "No"
        ElseIf Pitch_Up.Checked = True Then
            Aircraft_Angles.Pitch = "Up"
        ElseIf Pitch_Down.Checked = True Then
            Aircraft_Angles.Pitch = "Down"
        End If

        'Belly Shape
        If Belly_Flat.Checked = True Then
            Aircraft_Angles.Radius = "Flat"
            swDoc = swApp.OpenDoc6(Network_Locations.Flat_Contour_Plate_Temp, 1, 0, "", fileerror, filewarning)
            swApp.ActivateDoc("Contour Plate Template - Flat")
        End If

        If Belly_Radii.Checked = True Then
            Aircraft_Angles.Radius = "Radius"
            swDoc = swApp.OpenDoc6(Network_Locations.Radius_Contour_Plate_Temp, 1, 0, "", fileerror, filewarning)
            swApp.ActivateDoc("Contour Plate Template - Radius")
        End If

        If Belly_Spline.Checked = True Then
            Aircraft_Angles.Radius = "Spline"
            swDoc = swApp.OpenDoc6(Network_Locations.Spline_Contour_Plate_Temp, 1, 0, "", fileerror, filewarning)
            swApp.ActivateDoc("Contour Plate Template - Spline")
        End If



        swDoc = swApp.ActiveDoc
        swPart = swApp.ActiveDoc
        CusProperties = swDoc.Extension.CustomPropertyManager("")

        'FWD Direction
        If Aircraft_Angles.FWD = "Left" Then

            swFeat = swPart.FeatureByName("FWD LEFT")
            status = swFeat.SetSuppression2(SuppressionState:=1, Config_opt:=1, Config_names:=Nothing)

            swFeat = swPart.FeatureByName("FWD RIGHT")
            status = swFeat.SetSuppression2(SuppressionState:=0, Config_opt:=1, Config_names:=Nothing)

            Rot_Angle = 0
            Prop_Result = CusProperties.Set2(swRot_Angle, Rot_Angle)

        ElseIf Aircraft_Angles.FWD = "Right" Then

            swFeat = swPart.FeatureByName("FWD LEFT")
            status = swFeat.SetSuppression2(SuppressionState:=0, Config_opt:=1, Config_names:=Nothing)


            swFeat = swPart.FeatureByName("FWD RIGHT")
            status = swFeat.SetSuppression2(SuppressionState:=1, Config_opt:=1, Config_names:=Nothing)

            Rot_Angle = 180
            Prop_Result = CusProperties.Set2(swRot_Angle, Rot_Angle)

        End If


        'Pitch Angle
        If Aircraft_Angles.Pitch = "Up" Then

			If Double.TryParse(Angle_Up_Input.Text, Pitch_Angle) Then

				If Pitch_Angle = 0 Or Pitch_Angle = 360 Then

					Functions.Error_Form(Pitch_Angle.ToString() & " Is Equivalent to 0", "Select None for Pitch Angle",,,, False, Me)

				ElseIf Pitch_Angle > 360 Or Pitch_Angle < 0 Then

					Functions.Error_Form(Pitch_Angle.ToString() & " Is Not Correct", "Angle cannot be less than 0 or greater than 360",,,, False, Me)

				Else
					If Aircraft_Angles.FWD = "Left" Then

						Pitch_Angle = 360 - Pitch_Angle

					End If

					Prop_Result = CusProperties.Set2(swPitch_Angle, Pitch_Angle)
				End If

			Else

				Functions.Error_Form(Angle_Up_Input.Text & " Is Not Correct", Angle_Up_Input.Text & " is not valid, Enter a Valid FWD Radius Next Time",,,, False, Me)

				Exit Sub
            End If

        ElseIf Aircraft_Angles.Pitch = "Down" Then

			If Double.TryParse(Angle_Down_Input.Text, Pitch_Angle) Then

				If Pitch_Angle = 0 Or Pitch_Angle = 360 Then

					Functions.Error_Form(Pitch_Angle.ToString() & " Is Equivalent to 0", "Select None for Pitch Angle",,,, False, Me)

				ElseIf Pitch_Angle > 360 Or Pitch_Angle < 0 Then

					Functions.Error_Form(Pitch_Angle.ToString() & " Is Not Correct", "Angle cannot be less than 0 or greater than 360",,,, False, Me)

				Else
					If Aircraft_Angles.FWD = "Right" Then

						Pitch_Angle = 360 - Pitch_Angle

					End If

					Prop_Result = CusProperties.Set2(swPitch_Angle, Pitch_Angle)
				End If

			Else

				Functions.Error_Form(Angle_Down_Input.Text & " Is Not Correct", Angle_Down_Input.Text & " is not valid, Enter a Valid FWD Radius Next Time",,,, False, Me)

				Exit Sub
            End If

        ElseIf Aircraft_Angles.Pitch = "No" Then

            Pitch_Angle = 0
            Prop_Result = CusProperties.Set2(swPitch_Angle, Pitch_Angle)

        End If
        'End Pitch Angle


        'Lateral Angle'
        If Aircraft_Angles.Lateral = "Left" Then

			If Double.TryParse(Angle_Left_Input.Text, Lateral_Angle) Then

				If Lateral_Angle = 0 Or Lateral_Angle = 360 Then

					Functions.Error_Form(Lateral_Angle.ToString() & " Is Equivalent to 0", "Select None for Lateral Angle",,,, False, Me)

				ElseIf Lateral_Angle > 360 Or Lateral_Angle < 0 Then

					Functions.Error_Form(Lateral_Angle.ToString() & " Is Not Correct", "Angle cannot be less than 0 or greater than 360",,,, False, Me)

				Else
					If Aircraft_Angles.FWD = "Right" Then

						Lateral_Angle = 360 - Lateral_Angle

					End If

					Prop_Result = CusProperties.Set2(swLateral_Angle, Lateral_Angle)
				End If

			Else

				Functions.Error_Form(Angle_Left_Input.Text & " Is Not Correct", Angle_Left_Input.Text & " is not valid, Enter a Valid FWD Radius Next Time",,,, False, Me)

				Exit Sub
            End If

        ElseIf Aircraft_Angles.Lateral = "Right" Then

            If Double.TryParse(Angle_Right_Input.Text, Lateral_Angle) Then

                If Lateral_Angle = 0 Or Lateral_Angle = 360 Then

                    Dim Errorfrm As New Error_Message
                    Errorfrm.PassedText = "Select None for Lateral Angle"
                    Errorfrm.FormName = Lateral_Angle.ToString() & " Is Equivalent to 0"
                    Errorfrm.StartPosition = FormStartPosition.CenterParent
                    Errorfrm.ShowDialog()

                ElseIf Lateral_Angle > 360 Or Lateral_Angle < 0 Then

                    Dim Errorfrm As New Error_Message
                    Errorfrm.PassedText = "Angle cannot be less than 0 or greater than 360"
                    Errorfrm.FormName = Lateral_Angle.ToString() & " Is Not Correct"
                    Errorfrm.StartPosition = FormStartPosition.CenterParent
                    Errorfrm.ShowDialog()

                Else
                    If Aircraft_Angles.FWD = "Left" Then

                        Lateral_Angle = 360 - Lateral_Angle

                    End If

                    Prop_Result = CusProperties.Set2(swLateral_Angle, Lateral_Angle)
                End If

            Else
                Dim Errorfrm As New Error_Message
                Errorfrm.PassedText = Angle_Right_Input.Text & " is not valid, Enter a Valid FWD Radius Next Time"
                Errorfrm.FormName = Angle_Right_Input.Text & " Is Not Correct"
                Errorfrm.StartPosition = FormStartPosition.CenterParent
                Errorfrm.ShowDialog()
                Exit Sub
            End If

        ElseIf Aircraft_Angles.Lateral = "No" Then

            Lateral_Angle = 0
            Prop_Result = CusProperties.Set2(swLateral_Angle, Lateral_Angle)

        End If
        'End Lateral Angle

        'Belly Type
        'If Aircraft_Angles.Radius = False Then

        '    'unsupresses the flat profile
        '    swFeat = swPart.FeatureByName("FLAT/FLAT, PITCH DOWN, INBOARD")
        '    status = swFeat.SetSuppression2(SuppressionState:=1, Config_opt:=1, Config_names:=Nothing) 'unsupressed

        '    'supresses the Radius profile
        '    swFeat = swPart.FeatureByName("RADIUS/RADIUS, PITCH DOWN, LATERAL LEFT")
        '    status = swFeat.SetSuppression2(SuppressionState:=0, Config_opt:=1, Config_names:=Nothing) 'supressed
        '    swFeat = swPart.FeatureByName("Radius1")
        '    status = swFeat.SetSuppression2(SuppressionState:=0, Config_opt:=1, Config_names:=Nothing) 'supressed
        '    swFeat = swPart.FeatureByName("Radius2")
        '    status = swFeat.SetSuppression2(SuppressionState:=0, Config_opt:=1, Config_names:=Nothing) 'supressed
        '    swFeat = swPart.FeatureByName("Guide Sketch")
        '    status = swFeat.SetSuppression2(SuppressionState:=0, Config_opt:=1, Config_names:=Nothing) 'supressed

        'Else

        '    'supresses the flat profile
        '    swFeat = swPart.FeatureByName("FLAT/FLAT, PITCH DOWN, INBOARD")
        '    status = swFeat.SetSuppression2(SuppressionState:=0, Config_opt:=1, Config_names:=Nothing) 'supressed
        '    swFeat = swPart.FeatureByName("Flat Sketch")
        '    status = swFeat.SetSuppression2(SuppressionState:=0, Config_opt:=1, Config_names:=Nothing) 'supressed

        '    'unsupresses the Radius profile
        '    swFeat = swPart.FeatureByName("RADIUS/RADIUS, PITCH DOWN, LATERAL LEFT")
        '    status = swFeat.SetSuppression2(SuppressionState:=1, Config_opt:=1, Config_names:=Nothing) 'unsupressed

        'End If
        ''End Belly Type

        'Belly Radius
        If Aircraft_Angles.Radius = "Radius" Then

            If Double.TryParse(FWD_Radius.Text, FWD_Radii) Then

                If FWD_Radii > 0 Then

                    If Aircraft_Angles.FWD = "Left" Then

                        Prop_Result = CusProperties.Set2(swFWD_Radius, FWD_Radii)

                    Else

                        Prop_Result = CusProperties.Set2(swAFT_Radius, FWD_Radii)

                    End If
                Else
                    Dim Errorfrm As New Error_Message
                    Errorfrm.PassedText = FWD_Radii.ToString() & " Degrees is not valid, Enter a Valid FWD Radius Next Time"
                    Errorfrm.FormName = FWD_Radii.ToString() & " Is Not Correct"
                    Errorfrm.StartPosition = FormStartPosition.CenterParent
                    Errorfrm.ShowDialog()
                End If

            Else
                Dim Errorfrm As New Error_Message
                Errorfrm.PassedText = FWD_Radius.Text & " is not valid, Enter a Valid FWD Radius Next Time"
                Errorfrm.FormName = FWD_Radius.Text & " Is Not Correct"
                Errorfrm.StartPosition = FormStartPosition.CenterParent
                Errorfrm.ShowDialog()
                Exit Sub
            End If

            If Double.TryParse(AFT_Radius.Text, AFT_Radii) Then

                If AFT_Radii > 0 Then

                    If Aircraft_Angles.FWD = "Left" Then

                        Prop_Result = CusProperties.Set2(swAFT_Radius, AFT_Radii)

                    Else

                        Prop_Result = CusProperties.Set2(swFWD_Radius, AFT_Radii)

                    End If
                Else
                    Dim Errorfrm As New Error_Message
                    Errorfrm.PassedText = AFT_Radii.ToString() & " Degrees is not valid, Enter a Valid FWD Radius Next Time"
                    Errorfrm.FormName = AFT_Radii.ToString() & " Is Not Correct"
                    Errorfrm.StartPosition = FormStartPosition.CenterParent
                    Errorfrm.ShowDialog()
                End If

            Else
                Dim Errorfrm As New Error_Message
                Errorfrm.PassedText = AFT_Radius.Text & " is not valid, Enter a Valid FWD Radius Next Time"
                Errorfrm.FormName = AFT_Radius.Text & " Is Not Correct"
                Errorfrm.StartPosition = FormStartPosition.CenterParent
                Errorfrm.ShowDialog()
                Exit Sub
            End If

        ElseIf Aircraft_Angles.Radius = "Spline" Then
            MsgBox("Currently nothing, ran as radius")

        End If
        'End Belly Radius

        'MsgBox(Feature_List.SelectedIndex)
        If Feature_List.SelectedIndex >= 0 Then
            Add_Contour()
        End If


        swDoc.ForceRebuild3(True)
		Functions.Status = True
		Me.Close()

    End Sub

    Private Sub Pitch_Down_CheckedChanged(sender As Object, e As EventArgs) Handles Pitch_Down.CheckedChanged

        Angle_Down.Visible = True
        Angle_Down_Input.Visible = True

        Angle_Up_Input.Visible = False
        Angle_Up_Input.Clear()
        Angle_Up.Visible = False

    End Sub

    Private Sub Pitch_Up_CheckedChanged(sender As Object, e As EventArgs) Handles Pitch_Up.CheckedChanged

        Angle_Down.Visible = False
        Angle_Down_Input.Visible = False
        Angle_Down_Input.Clear()

        Angle_Up_Input.Visible = True
        Angle_Up.Visible = True

    End Sub

    Private Sub No_Pitch_Angle_CheckedChanged(sender As Object, e As EventArgs) Handles No_Pitch_Angle.CheckedChanged

        Angle_Down.Visible = False
        Angle_Down_Input.Visible = False
        Angle_Down_Input.Clear()

        Angle_Up_Input.Visible = False
        Angle_Up_Input.Clear()
        Angle_Up.Visible = False

    End Sub

    Private Sub No_Lateral_Angle_CheckedChanged(sender As Object, e As EventArgs) Handles No_Lateral_Angle.CheckedChanged

        Angle_Right_Input.Visible = False
        Angle_Right_Input.Clear()
        Angle_Right.Visible = False

        Angle_Left_Input.Visible = False
        Angle_Left_Input.Clear()
        Angle_Left.Visible = False

    End Sub

    Private Sub Lateral_Left_Angle_CheckedChanged(sender As Object, e As EventArgs) Handles Lateral_Left_Angle.CheckedChanged

        Angle_Right_Input.Visible = False
        Angle_Right_Input.Clear()
        Angle_Right.Visible = False

        Angle_Left_Input.Visible = True
        Angle_Left.Visible = True

    End Sub

    Private Sub Lateral_Right_Angle_CheckedChanged(sender As Object, e As EventArgs) Handles Lateral_Right_Angle.CheckedChanged

        Angle_Right_Input.Visible = True
        Angle_Right.Visible = True

        Angle_Left_Input.Visible = False
        Angle_Left_Input.Clear()
        Angle_Left.Visible = False

    End Sub

    Private Sub Belly_Flat_CheckedChanged(sender As Object, e As EventArgs) Handles Belly_Flat.CheckedChanged

        FWD_Radius.Visible = False
        FWD_Radius.Clear()
        FWD_Radius_Label.Visible = False
        AFT_Radius.Visible = False
        AFT_Radius.Clear()
        Aft_Radius_Label.Visible = False

        Feature_List.Items.Clear()

        Functions.Directory_List(Network_Locations.Flat_panel, Feature_List)


    End Sub

    Private Sub Belly_Radii_CheckedChanged(sender As Object, e As EventArgs) Handles Belly_Radii.CheckedChanged

        FWD_Radius.Visible = True
        FWD_Radius_Label.Visible = True
        AFT_Radius.Visible = True
        Aft_Radius_Label.Visible = True

        Feature_List.Items.Clear()

        Functions.Directory_List(Network_Locations.Radius_Panel, Feature_List)


    End Sub

    Private Sub Belly_Spline_CheckedChanged(sender As Object, e As EventArgs) Handles Belly_Spline.CheckedChanged

        FWD_Radius.Visible = False
        FWD_Radius.Clear()
        FWD_Radius_Label.Visible = False
        AFT_Radius.Visible = False
        AFT_Radius.Clear()
        Aft_Radius_Label.Visible = False

        Feature_List.Items.Clear()

        Functions.Directory_List(Network_Locations.Radius_Panel, Feature_List)

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

    Function Add_Contour()

        Dim Select_ID As New Error_Message

        Dim swSelMgr As SelectionMgr
        Dim swFeatMgr As FeatureManager
        Dim swLibFeat As LibraryFeatureData

        Dim boolstatus As Boolean

        Dim selcount As Integer
        Dim RefCount As Integer

        Dim selectedObjects() As Object
        Dim Refs As Object = Nothing
        Dim RefTypes As Object = Nothing

        swModelDocExt = swDoc.Extension
        swFeatMgr = swDoc.FeatureManager
		swLibFeat = swFeatMgr.CreateDefinition(SwConst.swFeatureNameID_e.swFmLibraryFeature)


		'Feature_List.SelectedItem.ToString()
		Dir = Dir + "\" + Feature_List.SelectedItem.ToString() + ".sldlfp"
        'Dir = Dir + "\" + Contour_Plate_Dir.Text + ".sldlfp"
        boolstatus = swLibFeat.Initialize(Dir)


        RefCount = swLibFeat.GetReferencesCount
		Refs = swLibFeat.GetReferences2(SwConst.swLibFeatureData_e.swLibFeatureData_FeatureRespect, RefTypes)

		swLibFeat.ConfigurationName = "Default"

        swSelMgr = swDoc.SelectionManager

        ''selects selection 1 which is the insert face/plane
        'Select_ID.PassedText = "Select Ground Plane"
        'Select_ID.FormName = "Library Insert Selection"
        'Select_ID.StartPosition = FormStartPosition.CenterParent
        'Select_ID.ShowDialog()
        'Me.Show()

        boolstatus = swModelDocExt.SelectByID2("GROUND PLANE", "PLANE", 0, 0, 0, False, 0, Nothing, 0)

        swFeat = swFeatMgr.CreateFeature(swLibFeat)
        swLibFeat = Nothing
        swLibFeat = swFeat.GetDefinition()
        boolstatus = swLibFeat.AccessSelections(swDoc, Nothing)

        ''select both edges
        'Select_ID.PassedText = "CTRL Select The Following"
        'Select_ID.TextLine2 = "ORIGIN, REF PLANE, and SKIN PLANE"
        ''Select_ID.TextLine3 = "Second Edge Is To The Right Of The First Edge"
        'Select_ID.FormName = "Library Insert Selection"
        'Select_ID.StartPosition = FormStartPosition.CenterParent
        'Select_ID.ShowDialog()
        'Me.Show()

        '        boolstatus = swModelDocExt.SelectByID2("Origin", "EXTSKETCHPOINT", 0, 0, 0, True, 0, Nothing, 0)
        boolstatus = swModelDocExt.SelectByID2("Point1@Origin", "EXTSKETCHPOINT", 0, 0, 0, True, 0, Nothing, 0)
        boolstatus = swModelDocExt.SelectByID2("REF PLANE", "PLANE", 0, 0, 0, True, 0, Nothing, 0)
        boolstatus = swModelDocExt.SelectByID2("SKIN PLANE", "PLANE", 0, 0, 0, True, 0, Nothing, 0)

        'boolstatus = swModelDocExt.SelectByID2("Origin", "PLANE", 0, 0, 0, True, 0, Nothing, 0)

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


        Return True
    End Function


End Class