Imports System.Data.OleDb
Public Class User

    'Shared Fields
    Public Shared Database As Database = New Database("Users")
    Public Shared List As List(Of User) = New List(Of User)
    'Fields

    Public Id As Integer
    Public Username As String
    Public Password As String
    Public Answer As String
    Public Name As String
    Public Surname As String
    Public Position As String

    'Reference

    Public Sales As List(Of Sale)
    'Functions

    Public Shared Sub Load()
        List.Clear()
        For Each User As DataRow In Database.Table.Rows
            Create(User("Id"),
                   User("Username"),
                   User("Password"),
                   User("Answer"),
                   User("Name"),
                   User("Surname"),
                   User("Position"),
                   False)
        Next
    End Sub

    Public Shared Function Find(ByVal userName)
        Return List.SingleOrDefault(Function(user As User) user.Username = userName)
    End Function

    Public Shared Function Create(
                            ByVal id As Integer,
                            ByVal username As String,
                            ByVal password As String,
                            ByVal answer As String,
                            ByVal name As String,
                            ByVal surname As String,
                            ByVal position As String,
                            Optional ByVal includeTable As Boolean = True)

        Dim temp As User = New User With {
                    .Id = id,
                    .Username = username,
                    .Password = password,
                    .Answer = answer,
                    .Name = name,
                    .Surname = surname,
                    .Position = position,
                    .Sales = Sale.List.Where(Function(sale As Sale) sale.EmployeeId = id).ToList()
                    }

        List.Add(temp)
        If (includeTable) Then
            Database.Table.Rows.Add(100000, temp.Username, temp.Password, temp.Answer, temp.Name, temp.Surname, temp.Position)
            Database.Update()
        End If
        Return temp
    End Function

End Class
