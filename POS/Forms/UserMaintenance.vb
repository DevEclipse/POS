Public Class UserMaintenance

    Private Sub UserMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UserView.DataSource = User.Database.Table
    End Sub

    Private Sub ButtonADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonADD.Click
        
        If TextUsername.Text = "" Then
            MsgBox("Username Needed", MsgBoxStyle.Information, "Account Information")
        ElseIf TextPassword.Text = "" Then
            MsgBox("Password Needed", MsgBoxStyle.Information, "Account Information")
            TextPassword.Focus()
        ElseIf TextFirstname.Text = "" Then
            MsgBox("Firsname Needed", MsgBoxStyle.Information, "Account Information")
            TextFirstname.Focus()
        ElseIf TextSurname.Text = "" Then
            MsgBox("Surname Needed", MsgBoxStyle.Information, "Account Information")
            TextSurname.Focus()
        ElseIf ComboQuestion.Text = "" Then
            MsgBox("Choose Your Security Question", MsgBoxStyle.Information, "Account Information")
            ComboQuestion.Focus()
        ElseIf ComboUsertype.Text = "" Then
            MsgBox("Choose Your User Type", MsgBoxStyle.Information, "Account Information")
            ComboUsertype.Focus()
        ElseIf TextAnswer.Text = "" Then
            MsgBox("Security Question answer is needed", MsgBoxStyle.Information, "Account Information")
            TextAnswer.Focus()
        Else
            User.Create(User.Database.Table.Rows.Count, TextUsername.Text, TextPassword.Text, TextAnswer.Text, TextFirstname.Text, TextSurname.Text, ComboUsertype.Text, True)
            MsgBox("Account Added", MsgBoxStyle.Information, "Account")
        End If
    End Sub
End Class