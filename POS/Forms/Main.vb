Imports System.Linq
Public Class Main

    Dim itemPicture As Integer


    Dim saleNew As Sale


    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        itemPicture = "0"
        'ItemScreen.Image = ItemImage.Images(itemPicture)
        'TODO: This line of code loads data into the 'DbDataSet1.Items' table. You can move, or remove it, as needed.
        ItemsView.DataSource = Item.Database.Table
        saleNew = Sale.Create(1, 2, 10, 10, 10, 10, 10, "New", False)
        SalesView.DataSource = SaleItem.Database.Table
    End Sub




    Private Sub ButtonBuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuy.Click

        If ItemsView.SelectedRows.Count < 1 Then Return
        Dim rowItem As DataGridViewRow = ItemsView.SelectedRows(0)
            Dim barCode As Integer = rowItem.Cells("Barcode").Value
            Dim productName As String = rowItem.Cells("Name").Value
            Dim price As Double = rowItem.Cells("Price").Value
            TextBC.Text = barCode.ToString()
            TextPN.Text = productName
            TextPP.Text = price.ToString()

        SaleItem.Create(SaleItem.List.Count, barCode, saleNew.Id, Integer.Parse(TextNOP.Text))

        Dim sale As Sale = sale.Find(1)

        LabelTOTAL.Text = sale.SaleItems.Sum(Function(saleItem As SaleItem) saleItem.Item.Price * saleItem.Quantity).ToString()
    End Sub

    Private Sub ChangeAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeAccountToolStripMenuItem.Click
        Form1.Show()


    End Sub

    Private Sub ExitProgramToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitProgramToolStripMenuItem.Click
        If MsgBox("Are you sure?", MsgBoxStyle.YesNo, "Exit??") = vbYes Then
            End
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
    End Sub

    Private Sub AddItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemToolStripMenuItem.Click
        Inventory.Show()
    End Sub

    Private Sub TextSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextSearch.TextChanged
        Item.Database.Table.DefaultView.RowFilter = "Name LIKE '%" + TextSearch.Text + "%'"

    End Sub


    Private Sub NotepadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotepadToolStripMenuItem.Click

    End Sub

    Private Sub AddUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddUserToolStripMenuItem.Click
        UserMaintenance.Show()
    End Sub

    Private Sub ItemsView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ItemsView.CellContentClick

    End Sub
End Class