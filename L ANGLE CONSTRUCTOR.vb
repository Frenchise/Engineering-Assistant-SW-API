Imports SwConst
Imports SwCommands
Imports SldWorks
Imports System.Drawing
Imports System



Public Class L_ANGLE_CONSTRUCTOR

	Dim swApp As SldWorks.SldWorks
	'Dim swApp As SldWorks.SldWorks = Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application"))
	Dim swDoc As ModelDoc2
    Dim CusProperties As CustomPropertyManager
    Dim config As Configuration

    'Creates array of strings of property names
    Dim PropertyNames = New String() {"LENGTH", "MOUNTING_HOLE_SIZE", "RACK_HOLE_SIZE", "MOUNTING_LINEAR_ED", "MOUNTING_ED", "RACK_LINEAR_ED", "RACK_ED",
            "MOUNTING_HOLES", "RACK_HOLES"}

    Dim PropertyDescription = New String() {"Enter the extrusion length.", "Enter the size of the first set of holes.", "Enter the size of the second set of holes.",
            "Enter the edge distance from the short edge to the first set of holes.", "Enter the edge distance along the long edge to the first set of holes.",
            "Enter the edge distance from the short edge to the second set of holes.", "Enter the edge distance along the long edge to the second set of holes.",
            "How many holes are in the first set of holes?", "How many holes are in the second set of holes?"}



    Private Sub L_ANGLE_CONSTRUCTOR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PictureBox1.Width = Me.Width
        PictureBox1.Height = (Me.Height / 2)

        'Dim PropUpdate As Integer
        swDoc = swApp.ActiveDoc
        config = swDoc.GetActiveConfiguration

        'Allows access to the custom property manager
        CusProperties = swDoc.Extension.CustomPropertyManager("")


        Show_Description.DataBindings.Add("Text", PropertyDescription, "")
        Label1.DataBindings.Add("Text", PropertyNames, "")

        DataBindings.ToString()


        'PropUpdate = CusProperties.Set2(PropertyNames(i), ValueInput.Text)


    End Sub

    Private Sub AcceptValue_Click(sender As Object, e As EventArgs) Handles AcceptValue.Click

        Dim PropUpdate As Integer
        Dim input As String
        Dim PropName As String
        'Dim ADD_HOLES As Integer


        'swDoc = swApp.ActiveDoc
        'config = swDoc.GetActiveConfiguration

        ''Allows access to the custom property manager
        'CusProperties = swDoc.Extension.CustomPropertyManager("")

        'Prompts user for data to fill the array
        'ADD_HOLES = Interaction.MsgBox("Do You Want To Add Hole Locations?", MessageBoxButtons.YesNo)

        'If ADD_HOLES = DialogResult.Yes Then

        'Loops to fill Array and applies array to custom property manager
        'For i As Integer = 0 To 8
        input = ValueInput.Text

        BindingContext.Item(PropertyDescription).Position += 1

        BindingContext.Item(PropertyNames).Position += 1
        PropName = DataBindings.ToString(PropertyNames)

        'Show_Description.DataBindings.Add("Text", PropertyDescription, "")
        'Show_Description.Text = PropertyDescription(i)
        'EnteredValue = InputBox(PropertyDescription(i), "Numerical Property Input")
        PropUpdate = CusProperties.Set2(PropName, input)
        ValueInput.Clear()

        'Next

        'Exits sub function
        'ElseIf ADD_HOLES = DialogResult.Cancel Then
        'Me.Close()
        'End If

        'swDoc.ForceRebuild3(True)
        'swDoc.ShowNamedView2("*Isometric", 7)
        'swDoc.ViewZoomtofit2()

    End Sub

    Private Sub L_ANGLE_CONSTRUCTOR_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        PictureBox1.Width = Me.Width
        PictureBox1.Height = (Me.Height / 2)

    End Sub

End Class

