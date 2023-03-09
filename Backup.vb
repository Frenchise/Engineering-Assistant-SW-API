Public Class Backup

    Public Struct_Manufacturers As New List(Of String)
    Public Elect_Manufacturers As New List(Of String)
    ReadOnly MFG_List As String() = {"BEECHCRAFT", "BOMBARDIER", "CESSNA", "EMBRAER", "FALCON", "GULFSTREAM", "HAWKER", "LEARJEFT"}
    Dim Title_ As String

    Private Sub Form_Resize() Handles Me.ResizeEnd
        Functions.Form_resize(Me)
    End Sub

    Function Initialize_Form()

#Region "Struct checkboxes"
        Struct_ACTypes.Checked = False

        BEECHCRAFT_Struct.Checked = False
        BOMBARDIER_Struct.Checked = False
        CESSNA_Struct.Checked = False
        EMBRAER_Struct.Checked = False
        FALCON_Struct.Checked = False
        GULFSTREAM_Struct.Checked = False
        HAWKER_Struct.Checked = False
        LEARJET_Struct.Checked = False
#End Region

#Region "Elect checkboxes"
        Elect_ACTypes.Checked = False

        BEECHCRAFT_Elect.Checked = False
        BOMBARDIER_Elect.Checked = False
        CESSNA_Elect.Checked = False
        EMBRAER_Elect.Checked = False
        FALCON_Elect.Checked = False
        GULFSTREAM_Elect.Checked = False
        HAWKER_Elect.Checked = False
        LEARJET_Elect.Checked = False
#End Region

        Return True
    End Function

    Private Sub Backup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Title_ = Me.Text

        Form_Resize()
        Initialize_Form()
        Functions.Status = False

    End Sub

#Region "Structural items"

    Private Sub Struct_ACTypes_CheckedChanged(sender As Object, e As EventArgs) Handles Struct_ACTypes.CheckedChanged

        Functions.Error_Form("Lengthy Process", "Checking all A/C types can take over an hour",,,,, Me)

        If Struct_ACTypes.Checked = True Then
            Struct_Manufacturers.Clear()
            BEECHCRAFT_Struct.Checked = True
            BOMBARDIER_Struct.Checked = True
            CESSNA_Struct.Checked = True
            EMBRAER_Struct.Checked = True
            FALCON_Struct.Checked = True
            GULFSTREAM_Struct.Checked = True
            HAWKER_Struct.Checked = True
            LEARJET_Struct.Checked = True

            'For Each mfg In MFG_List
            '    'MsgBox(mfg)
            '    Struct_Manufacturers.Add(mfg)
            '    For i = 0 To Struct_Manufacturers.Count - 1
            '        Debug.Print(Struct_Manufacturers(i))
            '    Next

            'Next
        End If

        If Struct_ACTypes.Checked = False Then
            BEECHCRAFT_Struct.Checked = False
            BOMBARDIER_Struct.Checked = False
            CESSNA_Struct.Checked = False
            EMBRAER_Struct.Checked = False
            FALCON_Struct.Checked = False
            GULFSTREAM_Struct.Checked = False
            HAWKER_Struct.Checked = False
            LEARJET_Struct.Checked = False
            Struct_Manufacturers.Clear()
        End If



    End Sub

    Private Sub BEECHCRAFT_Struct_CheckedChanged(sender As Object, e As EventArgs) Handles BEECHCRAFT_Struct.CheckedChanged
        If BEECHCRAFT_Struct.Checked = True Then
            Struct_Manufacturers.Add("BEECHCRAFT")
        End If

        If BEECHCRAFT_Struct.Checked = False Then
            Struct_Manufacturers.Remove("BEECHCRAFT")
        End If
    End Sub

    Private Sub BOMBARDIER_Struct_CheckedChanged(sender As Object, e As EventArgs) Handles BOMBARDIER_Struct.CheckedChanged
        If BOMBARDIER_Struct.Checked = True Then
            Struct_Manufacturers.Add("BOMBARDIER")
        End If

        If BOMBARDIER_Struct.Checked = False Then
            Struct_Manufacturers.Remove("BOMBARDIER")
        End If
    End Sub

    Private Sub CESSNA_Struct_CheckedChanged(sender As Object, e As EventArgs) Handles CESSNA_Struct.CheckedChanged
        If CESSNA_Struct.Checked = True Then
            Struct_Manufacturers.Add("CESSNA")
        End If

        If CESSNA_Struct.Checked = False Then
            Struct_Manufacturers.Remove("CESSNA")
        End If
    End Sub

    Private Sub EMBRAER_Struct_CheckedChanged(sender As Object, e As EventArgs) Handles EMBRAER_Struct.CheckedChanged
        If EMBRAER_Struct.Checked = True Then
            Struct_Manufacturers.Add("EMBRAER")
        End If

        If EMBRAER_Struct.Checked = False Then
            Struct_Manufacturers.Remove("EMBRAER")
        End If
    End Sub

    Private Sub FALCON_Struct_CheckedChanged(sender As Object, e As EventArgs) Handles FALCON_Struct.CheckedChanged
        If FALCON_Struct.Checked = True Then
            Struct_Manufacturers.Add("FALCON")
        End If

        If FALCON_Struct.Checked = False Then
            Struct_Manufacturers.Remove("FALCON")
        End If
    End Sub

    Private Sub GULFSTREAM_Struct_CheckedChanged(sender As Object, e As EventArgs) Handles GULFSTREAM_Struct.CheckedChanged
        If GULFSTREAM_Struct.Checked = True Then
            Struct_Manufacturers.Add("GULFSTREAM")
        End If

        If GULFSTREAM_Struct.Checked = False Then
            Struct_Manufacturers.Remove("GULFSTREAM")
        End If
    End Sub

    Private Sub HAWKER_Struct_CheckedChanged(sender As Object, e As EventArgs) Handles HAWKER_Struct.CheckedChanged
        If HAWKER_Struct.Checked = True Then
            Struct_Manufacturers.Add("HAWKER")
        End If

        If HAWKER_Struct.Checked = False Then
            Struct_Manufacturers.Remove("HAWKER")
        End If
    End Sub

    Private Sub LEARJET_Struct_CheckedChanged(sender As Object, e As EventArgs) Handles LEARJET_Struct.CheckedChanged
        If LEARJET_Struct.Checked = True Then
            Struct_Manufacturers.Add("LEARJET")
        End If

        If LEARJET_Struct.Checked = False Then
            Struct_Manufacturers.Remove("LEARJET")
        End If
    End Sub

#End Region

#Region "Electrical items"

    Private Sub Elect_ACTypes_CheckedChanged(sender As Object, e As EventArgs) Handles Elect_ACTypes.CheckedChanged

        Functions.Error_Form("Lengthy Process", "Checking all A/C types can take over an hour",,,,, Me)

        If Elect_ACTypes.Checked = True Then
            BEECHCRAFT_Elect.Checked = True
            BOMBARDIER_Elect.Checked = True
            CESSNA_Elect.Checked = True
            EMBRAER_Elect.Checked = True
            FALCON_Elect.Checked = True
            GULFSTREAM_Elect.Checked = True
            HAWKER_Elect.Checked = True
            LEARJET_Elect.Checked = True

            'For Each mfg In MFG_List
            '    'MsgBox(mfg)
            '    Elect_Manufacturers.Add(mfg)
            '    For i = 0 To Elect_Manufacturers.Count - 1
            '        Debug.Print(Elect_Manufacturers(i))
            '    Next

            'Next
        End If

        If Elect_ACTypes.Checked = False Then
            BEECHCRAFT_Elect.Checked = False
            BOMBARDIER_Elect.Checked = False
            CESSNA_Elect.Checked = False
            EMBRAER_Elect.Checked = False
            FALCON_Elect.Checked = False
            GULFSTREAM_Elect.Checked = False
            HAWKER_Elect.Checked = False
            LEARJET_Elect.Checked = False
            Elect_Manufacturers.Clear()
        End If

    End Sub

    Private Sub BEECHCRAFT_Elect_CheckedChanged(sender As Object, e As EventArgs) Handles BEECHCRAFT_Elect.CheckedChanged
        If BEECHCRAFT_Elect.Checked = True Then
            Elect_Manufacturers.Add("BEECHCRAFT")
        End If

        If BEECHCRAFT_Elect.Checked = False Then
            Elect_Manufacturers.Remove("BEECHCRAFT")
        End If
    End Sub

    Private Sub BOMBARDIER_Elect_CheckedChanged(sender As Object, e As EventArgs) Handles BOMBARDIER_Elect.CheckedChanged
        If BOMBARDIER_Elect.Checked = True Then
            Elect_Manufacturers.Add("BOMBARDIER")
        End If

        If BOMBARDIER_Elect.Checked = False Then
            Elect_Manufacturers.Remove("BOMBARDIER")
        End If
    End Sub

    Private Sub CESSNA_Elect_CheckedChanged(sender As Object, e As EventArgs) Handles CESSNA_Elect.CheckedChanged
        If CESSNA_Elect.Checked = True Then
            Elect_Manufacturers.Add("CESSNA")
        End If

        If CESSNA_Elect.Checked = False Then
            Elect_Manufacturers.Remove("CESSNA")
        End If
    End Sub

    Private Sub EMBRAER_Elect_CheckedChanged(sender As Object, e As EventArgs) Handles EMBRAER_Elect.CheckedChanged
        If EMBRAER_Elect.Checked = True Then
            Elect_Manufacturers.Add("EMBRAER")
        End If

        If EMBRAER_Elect.Checked = False Then
            Elect_Manufacturers.Remove("EMBRAER")
        End If
    End Sub

    Private Sub FALCON_Elect_CheckedChanged(sender As Object, e As EventArgs) Handles FALCON_Elect.CheckedChanged
        If FALCON_Elect.Checked = True Then
            Elect_Manufacturers.Add("FALCON")
        End If

        If FALCON_Elect.Checked = False Then
            Elect_Manufacturers.Remove("FALCON")
        End If
    End Sub

    Private Sub GULFSTREAM_Elect_CheckedChanged(sender As Object, e As EventArgs) Handles GULFSTREAM_Elect.CheckedChanged
        If GULFSTREAM_Elect.Checked = True Then
            Elect_Manufacturers.Add("GULFSTREAM")
        End If

        If GULFSTREAM_Elect.Checked = False Then
            Elect_Manufacturers.Remove("GULFSTREAM")
        End If
    End Sub

    Private Sub HAWKER_Elect_CheckedChanged(sender As Object, e As EventArgs) Handles HAWKER_Elect.CheckedChanged
        If HAWKER_Elect.Checked = True Then
            Elect_Manufacturers.Add("HAWKER")
        End If

        If HAWKER_Elect.Checked = False Then
            Elect_Manufacturers.Remove("HAWKER")
        End If
    End Sub

    Private Sub LEARJET_Elect_CheckedChanged(sender As Object, e As EventArgs) Handles LEARJET_Elect.CheckedChanged
        If LEARJET_Elect.Checked = True Then
            Elect_Manufacturers.Add("LEARJET")
        End If

        If LEARJET_Elect.Checked = False Then
            Elect_Manufacturers.Remove("LEARJET")
        End If
    End Sub

    Private Sub Clear_Chckbox_Click(sender As Object, e As EventArgs) Handles Clear_Chckbox.Click
        Initialize_Form()
    End Sub

#End Region

    Private Sub Update_Excel_Backups_Click(sender As Object, e As EventArgs) Handles Update_Excel_Backups.Click
        'For Each item In Struct_Manufacturers
        '    MsgBox("This Structural mfg - " & item & " will be updated")
        'Next

        'For Each item In Elect_Manufacturers
        '    MsgBox("This Electrical mfg - " & item & " will be updated")
        'Next
        Dim start_time As DateTime
        Dim end_time As DateTime
        Dim time_elapsed As TimeSpan

        start_time = Now
        Me.Cursor = Cursors.WaitCursor
        Me.BackColor = SystemColors.InactiveCaption
        Me.Text = "PDF --> Excel in works..."

        If Struct_Manufacturers.Count > 0 Or Elect_Manufacturers.Count > 0 Then
            Functions.MFG_Backup_Combine_StructElect(Struct_Manufacturers, Elect_Manufacturers)
        End If

        Initialize_Form()
        Me.BackColor = SystemColors.Window
        Me.Text = Title_
        end_time = Now
        time_elapsed = end_time.Subtract(start_time)
        Functions.Error_Form("PDF --> Excel is dont", "DONE",, "Time elapsed - " + time_elapsed.ToString,,, Me)
        Me.Cursor = Cursors.Default

    End Sub

End Class