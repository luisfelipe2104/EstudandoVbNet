Imports Microsoft.Data.SqlClient

Module Conexao

    Public Const ConnectionString As String =
        "Server=localhost\MSSQLSERVER01;Database=MeuBanco;Integrated Security=True;TrustServerCertificate=True;"

    Public Function ObterConexao() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function

End Module
