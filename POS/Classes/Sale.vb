Imports System.Data.OleDb
Imports System.Linq
Public Class Sale

    'Shared Fields
    Public Shared Database As Database = New Database("Sales")
    Public Shared List As List(Of Sale) = New List(Of Sale)

    'Fields
    Public Id As Integer
    Public EmployeeId As Integer
    Public Amount As Double
    Public Total As Double
    Public Change As Double
    Public Discount As Double
    Public Tax As Double
    Public Status As String

    'Reference
    Public SaleItems As List(Of SaleItem)
    'Functions

    Public Shared Sub Load()
        List.Clear()
        For Each Sale As DataRow In Database.Table.Rows
            Create(Sale("Id"),
                   Sale("EmployeeId"),
                   Sale("Amount"),
                   Sale("Total"),
                   Sale("Change"),
                   Sale("Discount"),
                   Sale("Tax"),
                   Sale("Status"),
                   False)
        Next
    End Sub

    Public Shared Function Find(ByVal saleId As Integer)
        Return List.SingleOrDefault(Function(sale As Sale) sale.Id = saleId)
    End Function

    Public Shared Function Create(
                            ByVal id As Integer,
                            ByVal empId As Integer,
                            ByVal amount As Double,
                            ByVal total As Double,
                            ByVal change As Double,
                            ByVal discount As Double,
                            ByVal tax As Double,
                            ByVal status As String,
                            Optional ByVal includeTable As Boolean = True)

        Dim temp As Sale = New Sale With {
                    .Id = id,
                    .EmployeeId = empId,
                    .Amount = amount,
                    .Total = total,
                    .Change = change,
                    .Discount = discount,
                    .Tax = tax,
                    .Status = status,
                    .SaleItems = SaleItem.List.Where(Function(saleItem As SaleItem) saleItem.SalesId = id).ToList()
                    }

        List.Add(temp)
        If (includeTable) Then
            Database.Table.Rows.Add(temp.Id, temp.EmployeeId, temp.Amount, temp.Total, temp.Change, temp.Discount, temp.Tax, temp.Status)
            Database.Update()
        End If

        Return temp
    End Function


End Class

