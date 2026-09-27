Imports Microsoft.Data.SqlClient

Public Class FormDetalheBanqueiro

    Private ReadOnly _id As Integer
    Private ReadOnly _nome As String
    Private ReadOnly _sigla As String
    Private ReadOnly _ativo As Boolean

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(id As Integer, nome As String, sigla As String, ativo As Boolean)
        InitializeComponent()
        _id = id
        _nome = nome
        _sigla = sigla
        _ativo = ativo
    End Sub

    Private Sub FormDetalheBanqueiro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNome.Text = _nome
        txtSigla.Text = _sigla
        chkAtivo.Checked = _ativo
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Using conn As SqlConnection = ObterConexao()
                conn.Open()
                Dim sql = "UPDATE dbo.Banqueiro SET Ativo = @Ativo WHERE Id = @Id"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Ativo", chkAtivo.Checked)
                    cmd.Parameters.AddWithValue("@Id", _id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Status do banqueiro atualizado.", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            DialogResult = DialogResult.OK
            Close()
        Catch ex As Exception
            MessageBox.Show("Erro ao atualizar banqueiro: " & ex.Message, "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
