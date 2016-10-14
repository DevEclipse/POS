Public Class Form1
    Dim attemp As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = Color.DarkCyan

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Me.Close()
    End Sub

    Private Sub ButtonChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonChange.Click

        Dim warning As String = "warning" & vbNewLine & vbNewLine + _
  "If Attemps var = 3" & vbNewLine & vbNewLine + _
  "System will lock for 10 Seconds."
        If (textusername.Text = "") And (textpassword.Text = "") Then
            attemp = attemp + 1
            MsgBox("Please input Username and Password" & vbNewLine & vbNewLine + _
                   warning, MsgBoxStyle.Exclamation, "Sorry Sir" & _
                    "Number of Attemps =" & attemp)
            Exit Sub
        ElseIf (textusername.Text = "") Then
            attemp = attemp + 1
            MsgBox("Please input Username" & vbNewLine & vbNewLine + _
                   warning, MsgBoxStyle.Exclamation, "Sorry Sir" & _
                    "Number of Attemps =" & attemp)
            Exit Sub
        ElseIf (textpassword.Text = "") Then
            attemp = attemp + 1
            MsgBox("Please input Password" & vbNewLine & vbNewLine + _
                   warning, MsgBoxStyle.Exclamation, "Sorry Sir" & _
                    "Number of Attemps =" & attemp)
            Exit Sub
        End If
        Dim tempUser As User = User.Find(textusername.Text)


        If tempUser Is Nothing Then
            attemp = attemp + 1
            MsgBox("Invalid Username", MsgBoxStyle.Critical, "Please try again!")
            Exit Sub

        Else

            If tempUser Is Nothing Or tempUser.Password = textpassword.Text Then
                MsgBox("Login Successful", MsgBoxStyle.Information, "Login")
                Main.Enabled = True
                Me.Close()

                Splash.Timer2.Enabled = False
                textusername.Text = ""
                textpassword.Text = ""
                attemp = 0
                Main.LabelFN.Text = tempUser.Name
                Main.LabelSN.Text = tempUser.Surname
                Main.LabelPosition.Text = tempUser.Position
                If Main.LabelPosition.Text = "Admin" Then
                    Main.LabelName.Text = "Admin's Name:"
                End If
                If tempUser.Position = "Admin" Then
                    MsgBox("Welcome Admin", MsgBoxStyle.Information, "Authorized Login")
                    Main.InventoryTool.Enabled = True
                    Main.UsersTool.Enabled = True
                    Main.SalesTool.Enabled = True
                    Main.BackupTool.Enabled = True
                ElseIf tempUser.Position = "Employee" Then
                    Main.InventoryTool.Enabled = False
                    Main.UsersTool.Enabled = False
                    Main.SalesTool.Enabled = False
                    Main.BackupTool.Enabled = False



                End If
            End If
        End If

    End Sub
End Class