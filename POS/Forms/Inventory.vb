
Public Class Inventory

    Private Sub Inventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbDataSet1.Items' table. You can move, or remove it, as needed.
        InventoryView.DataSource = Item.Database.Table
    End Sub

  
    
   

    Private Function myimg() As Object
        Throw New NotImplementedException
    End Function


    Private Sub btnGenerate_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        TextBarcode.Text = TxtBarcode.Text
    End Sub

    Private Sub ButtonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click
        If TextBarcode.Text.Trim = "" And textName.Text.Trim = "" And textPRICE.Text.Trim = "" And TextQUAN.Text.Trim = "" And TextDES.Text = "" Then
            MsgBox("Input Item Details", MsgBoxStyle.Critical, "Item Details")
            Exit Sub
        End If
        If TextBarcode.Text.Trim = "" Then
            MsgBox("Generate Barcode", MsgBoxStyle.Critical, "Barcode")
            TextBarcode.Focus()
            Exit Sub
        ElseIf TextBarcode.Text.Contains(".") Or TextBarcode.Text.Contains("-") Then
            MsgBox("Invalid Characters: (-),(.)", MsgBoxStyle.Critical, "Invalid")
            TextBarcode.Focus()
            Exit Sub
        End If
        If textPRICE.Text.Trim = "" Then
            MsgBox("Product Price Missing", MsgBoxStyle.Critical, "Product Price")
            textPRICE.Focus()
            Exit Sub
        ElseIf Not IsNumeric(textPRICE.Text) Then
            MsgBox("Use Number Only", MsgBoxStyle.Critical, "Invalid Character")
            textPRICE.Focus()
            Exit Sub
            If TextQUAN.Text.Trim = "" Then
                MsgBox("Product Quantity Missing", MsgBoxStyle.Critical, "Product Quantity")
                TextQUAN.Focus()
                Exit Sub
            ElseIf Not IsNumeric(textPRICE.Text) Then
                MsgBox("Use Number Only", MsgBoxStyle.Critical, "Invalid Character")
                TextQUAN.Focus()
                Exit Sub
                If TextDES.Text.Trim = "" Then
                    MsgBox("Product Description Missing", MsgBoxStyle.Critical, "Product Descripition")
                    TextDES.Focus()
                    Exit Sub

                End If
            End If
        End If
        Item.Create(TextBarcode.Text, textName.Text, textPRICE.Text, TextQUAN.Text, TextDES.Text, True)
        MsgBox("Item Added", MsgBoxStyle.Information, "Add Item")






    End Sub

    Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
        If InventoryView.SelectedRows.Count < 1 Then Return

        For Each tempItem As DataGridViewRow In InventoryView.SelectedRows
            InventoryView.Rows.Remove(tempItem)
        Next
        Item.Database.Update()
    End Sub

    Private Sub TextSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextSearch.TextChanged
        Item.Database.Table.DefaultView.RowFilter = "Name LIKE '%" + TextSearch.Text + "%'"
    End Sub

    Private Sub TxtBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBarcode.TextChanged
        If TxtBarcode.Text.Contains("[A-Z-az]") Then
            MessageBox.Show("Use number only")
        End If
    End Sub
End Class