Imports System.Data.OleDb
Imports System.Linq
Public Class Item

    'Shared Fields
    Public Shared Database As Database = New Database("Items")
    Public Shared List As List(Of Item) = New List(Of Item)

    'Fields
    Public Barcode As Integer
    Public Price As Double
    Public Name As String
    Public Quantity As Integer
    Public Description As String

    'Reference

    Public SaleItems As List(Of SaleItem)
    'Functions

    Public Shared Sub Load()
        List.Clear()
        For Each Item As DataRow In Database.Table.Rows
            Create(Item("Barcode"),
                   Item("Name"),
                   Item("Price"),
                   Item("Quantity"),
                   Item("Description"),
                   False)
        Next
    End Sub

    Public Shared Function Find(ByVal barCode As Integer)
        Return List.SingleOrDefault(Function(Item As Item) Item.Barcode = barCode)
    End Function

    Public Shared Function Create(ByVal barCode As Integer,
                                 ByVal name As String,
                                 ByVal price As Double,
                                 ByVal quantity As Integer,
                                 ByVal description As String,
                                 Optional ByVal includeTable As Boolean = True)
        Dim temp As Item = New Item With {
                    .Barcode = barCode,
                    .Price = price,
                    .Name = name,
                    .Quantity = quantity,
                    .Description = description,
                    .SaleItems = SaleItem.List.Where(Function(saleItem As SaleItem) saleItem.ItemBarcode = barCode).ToList()
                    }

        List.Add(temp)
        If (includeTable) Then
            Database.Table.Rows.Add(temp.Barcode, temp.Name, temp.Price, temp.Quantity, temp.Description)
            Database.Update()
        End If
        Return temp
    End Function


End Class

