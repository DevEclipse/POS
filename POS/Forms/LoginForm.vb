Public Class LoginForm
    Private Sub btn_LoginClick(sender As Object, e As EventArgs) Handles btn_Login.Click
        Dim tempUser As Account = Account.Find(tb_Username.Text)

        If tempUser Is Nothing Then
            MessageBox.Show("Username doesn't exist")
        ElseIf tempUser.Password = tb_Password.Text Then
            MessageBox.Show("Username exist")
        End If

    End Sub
End Class