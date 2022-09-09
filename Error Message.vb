Public Class Error_Message
    Private _passedText As String
    Private _passedValue As String
    Private _textLine2 As String
    Private _textLine3 As String
    Private _formName As String
    Dim Combine As String

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowIcon = True
        Me.Text = "Error Message"

        If _passedText = Nothing Then
            Message_Text.Text = "No Model is Loaded"
        Else
            If _passedValue = Nothing Then
                Message_Text.Text = PassedText
            Else

                Combine = PassedValue & PassedText
                Message_Text.Text = Combine
            End If

        End If

        If _textLine2 = Nothing Then
            Text_Line_2.Text = ""
        Else
            Text_Line_2.Text = TextLine2
        End If

        If _textLine3 = Nothing Then
            Text_Line_3.Text = ""
        Else
            Text_Line_3.Text = TextLine3
        End If

        If _formName <> Nothing Then
            Me.Text = FormName
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Okay.Click
        Me.Close()
    End Sub

    Public Property [PassedText]() As String
        Get
            Return _passedText
        End Get
        Set(ByVal Value As String)
            _passedText = Value
        End Set
    End Property

    Public Property [PassedValue]() As String
        Get
            Return _passedValue
        End Get
        Set(ByVal Value As String)
            _passedValue = Value
        End Set
    End Property

    Public Property TextLine2() As String
        Get
            Return _textLine2
        End Get
        Set(ByVal Value As String)
            _textLine2 = Value
        End Set
    End Property

    Public Property TextLine3() As String
        Get
            Return _textLine3
        End Get
        Set(ByVal Value As String)
            _textLine3 = Value
        End Set
    End Property

    Public Property [FormName]() As String
        Get
            Return _formName
        End Get
        Set(value As String)
            _formName = value
        End Set
    End Property


End Class