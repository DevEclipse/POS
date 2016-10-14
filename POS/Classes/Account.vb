Imports System.Data.OleDb
Public Class Account

    'Shared Fields
    Public Shared Database As Database = New Database("Accounts")
    Public Shared List As List(Of Account) = New List(Of Account)
    'Fields

    Public Id As Integer
    Public Username As String
    Public Password As String
    Public Name As String

    Public Sales As List(Of Sale)
    'Functions

    Public Shared Sub Load()
        List.Clear()
        For Each Account As DataRow In Database.Table.Rows
            Create(Account("Id"),
                   Account("Username"),
                   Account("Password"),
                   Account("Name"),
                   False)
        Next
    End Sub

    Public Shared Function Find(ByVal name As String)
        Return List.SingleOrDefault(Function(Account As Account) Account.Name = name)
    End Function

    Public Shared Function Create(
                            ByVal id As Integer,
                            ByVal username As String,
                            ByVal password As String,
                            ByVal name As String,
                            Optional ByVal includeTable As Boolean = True)

        Dim temp As Account = New Account With {
                    .Id = id,
                    .Username = username,
                    .Password = password,
                    .Name = name,
                    }

        List.Add(temp)
        If (includeTable) Then
            Database.Table.Rows.Add(List.Count, temp.Username, temp.Password, temp.Name)
            Database.Update()
        End If
        Return temp
    End Function

End Class
