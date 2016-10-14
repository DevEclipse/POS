Imports System.Data.OleDb

Public Class Database

    'Global Connection Fields
    Public Shared Connection As OleDbConnection = New OleDbConnection
    Public Shared Provider As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = "
    Public Shared Path As String = "\Database\db.accdb"

    'Fields
    Public Builder As OleDbCommandBuilder
    Public Adapter As OleDbDataAdapter
    Public Table As DataTable

    Public Sub New(ByVal tableName As String)
        Table = New DataTable(tableName)
        Load()
    End Sub

    Public Sub Load()
        Adapter = New OleDbDataAdapter("SELECT * FROM [" + Table.TableName + "]", Connection)
        Builder = New OleDbCommandBuilder(Adapter)
        Adapter.Fill(Table)
    End Sub

    Public Shared Sub Connect(Optional ByVal tempPath As String = "")
        If Connection.State = ConnectionState.Open Then
            Connection.Close()
        End If
        If (Not tempPath = "") Then
            Path = tempPath
        End If
        Connection.ConnectionString = Provider + Application.StartupPath + Path
        Connection.Open()
    End Sub

    Public Sub Update()
        Adapter.Update(Table)
    End Sub

End Class
