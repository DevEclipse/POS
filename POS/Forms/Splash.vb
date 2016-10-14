Public Class Splash

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sp.Click

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        ProgressBar1.Increment(50)
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = 100
        If ProgressBar1.Value = 1 Then
            Sp.Text = "Initializing..."
        ElseIf ProgressBar1.Value = 20 Then
            Sp.Refresh()
            Sp.Text = "Loading"
        ElseIf ProgressBar1.Value = 40 Then
            Sp.Refresh()
            Sp.Text = "Loading..."
        ElseIf ProgressBar1.Value = 45 Then
            Sp.Refresh()
            Sp.Text = "Loading.."
        ElseIf ProgressBar1.Value = 50 Then
            Sp.Refresh()
            Sp.Text = "Loading...."

        ElseIf ProgressBar1.Value = 60 Then
            Sp.Refresh()
            Sp.Text = "Loading.."
        ElseIf ProgressBar1.Value = 70 Then
            Sp.Refresh()
            Sp.Text = "Loading...."
        ElseIf ProgressBar1.Value = 75 Then
            Sp.Refresh()
            Sp.Text = "Loading.."
        ElseIf ProgressBar1.Value = 80 Then
            Sp.Refresh()
            Sp.Text = "Starting System"
        ElseIf ProgressBar1.Value = 85 Then
            Sp.Refresh()
            Sp.Text = "Opening Window"
        ElseIf ProgressBar1.Value = 100 Then
            Me.Hide()








        End If

    End Sub

    Private Sub Splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sp.BackColor = Color.Transparent
        Database.Connect()
        User.Load()
        Item.Load()
        Sale.Load()
        SaleItem.Load()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If ProgressBar1.Value = 100 Then
            Main.Show()
            Main.Enabled = False
            Login.Show()
        End If

    End Sub
End Class