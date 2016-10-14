Imports System.Data.OleDb
Public Class SQ

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ComboQuestion.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonConfirm.Click
        Dim tempUser As User = User.Find(UserSearch.Text)

        If tempUser.Answer = TextAnwer.Text Then
            MsgBox("Your Answer is correct", MsgBoxStyle.Information, "Correct")
            Label3.Visible = True
            TextPassword.Visible = True
            TextPassword.Text = tempUser.Password
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        Dim tempUser As User = User.Find(UserSearch.Text)

        If Not tempUser Is Nothing Then
            MsgBox("Account Found", MsgBoxStyle.Information, "Found")
            Firstname.Text = tempUser.Name

            Surname.Text = tempUser.Surname

            ComboQuestion.Enabled = True
            TextAnwer.Enabled = True
            ComboQuestion.Enabled = True
            TextAnwer.Enabled = True
            ButtonConfirm.Enabled = True
        Else
            MsgBox("Account Not Found", MsgBoxStyle.Critical, "No Account")
        End If

    End Sub

  

    Private Sub LabelClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelClose.Click
        Me.Hide()
    End Sub
End Class