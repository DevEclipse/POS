Imports System.Data.OleDb
Imports System.Linq
Public Class SaleItem

    'Shared Fields
    Public Shared Database As Database = New Database("SalesItems")
    Public Shared List As List(Of SaleItem) = New List(Of SaleItem)

    'Fields
    Public Id As Integer
    Public ItemBarcode As Integer
    Public SalesId As Integer
    Public Quantity As Integer

    'Reference
    Public Item As Item

    'Functions


    Public Shared Sub Load()
        List.Clear()
        For Each SaleItem As DataRow In Database.Table.Rows
            Create(SaleItem("Id"),
                   SaleItem("ItemBarcode"),
                   SaleItem("SalesId"),
                   SaleItem("Quantity"),
                            False)
        Next
    End Sub

    Public Shared Function Find(ByVal barCode As Integer)
        Return List.SingleOrDefault(Function(SalesItem As SaleItem) SalesItem.ItemBarcode = barCode)
    End Function

    Public Shared Function Create(ByVal salesItemId As Integer,
                             ByVal barCode As Integer,
                             ByVal transactionId As Integer,
                             ByVal quantity As Integer,
                             Optional ByVal includeTable As Boolean = True)
        Dim temp As SaleItem = New SaleItem With {
                    .Id = salesItemId,
                    .ItemBarcode = barCode,
                    .SalesId = transactionId,
                    .Quantity = quantity,
                    .Item = Item.Find(barCode)
                    }

        List.Add(temp)
        If (includeTable) Then
            Database.Table.Rows.Add(temp.Id, temp.ItemBarcode, temp.SalesId, temp.Quantity)
            Database.Update()
        End If
        Return temp
    End Function

End Class

