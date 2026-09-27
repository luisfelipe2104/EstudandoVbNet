Imports Microsoft.Data.SqlClient

Public Class Form1

    Private ReadOnly _campos As New FieldManager()
    Private _carregando As Boolean = False
    Private _IdSelecionado As Integer
    Private _isAtivo As Boolean

    Private Sub ConfigureGrid()
        _campos _
            .Adicionar("Id", "Id", visivel:=False) _
            .Adicionar("Nome", "Nome", autoSizeMode:=DataGridViewAutoSizeColumnMode.Fill) _
            .Adicionar("Sigla", "Sigla", largura:=150) _
            .Adicionar("Ativo", "Ativo", largura:=80, alinhamento:=DataGridViewContentAlignment.MiddleCenter, tipo:=TipoCampo.CheckBox, somenteLeitura:=False)
        _campos.Aplicar(GridBanqueiro)
    End Sub

    Private Sub ListarBanqueiros()
        Try
            Using conn As SqlConnection = ObterConexao()
                conn.Open()
                Dim sql = "p_BaqueiroAtivo_Sel"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    Dim nome As String = If(String.IsNullOrWhiteSpace(inp_nome.Text), "", inp_nome.Text)
                    cmd.Parameters.AddWithValue("@Nome", nome)
                    Using da As New SqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        _carregando = True
                        GridBanqueiro.DataSource = dt
                        _carregando = False
                    End Using
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigureGrid()
        ListarBanqueiros()
    End Sub

    Private Sub GridBanqueiro_SelectionChanged(sender As Object, e As EventArgs) Handles GridBanqueiro.SelectionChanged
        If _carregando Then Return
        If GridBanqueiro.CurrentRow Is Nothing Then Return

        Dim linha As DataGridViewRow = GridBanqueiro.CurrentRow

        _IdSelecionado = Convert.ToInt32(linha.Cells("Id").Value)
        _isAtivo = Convert.ToBoolean(linha.Cells("Ativo").Value)
    End Sub

    Private Sub GridBanqueiro_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles GridBanqueiro.CurrentCellDirtyStateChanged
        If GridBanqueiro.IsCurrentCellDirty Then
            GridBanqueiro.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        GridBanqueiro.EndEdit()

        If GridBanqueiro.CurrentRow Is Nothing Then
            MessageBox.Show("Selecione um banqueiro para atualizar.", "Atenção",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim id As Integer = Convert.ToInt32(GridBanqueiro.CurrentRow.Cells("Id").Value)
        Dim ativo As Boolean = Convert.ToBoolean(GridBanqueiro.CurrentRow.Cells("Ativo").Value)

        Using conn As SqlConnection = ObterConexao()
            conn.Open()
            Dim sql = "UPDATE dbo.Banqueiro SET Ativo = @Ativo WHERE Id = @Id"

            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Ativo", ativo)
                cmd.Parameters.AddWithValue("@Id", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
        MessageBox.Show("Status do banqueiro atualizado.", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

        ListarBanqueiros()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ListarBanqueiros()
    End Sub
End Class
