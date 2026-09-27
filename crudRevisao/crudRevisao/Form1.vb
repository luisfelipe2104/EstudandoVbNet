Imports Microsoft.Data.SqlClient

Public Class Form1

    Private ReadOnly _campos As New FieldManager()

    Private Sub ConfigureGrid()
        _campos _
            .Adicionar("Id", "Id", visivel:=False) _
            .Adicionar("Nome", "Nome", autoSizeMode:=DataGridViewAutoSizeColumnMode.Fill) _
            .Adicionar("Sigla", "Sigla", largura:=150) _
            .Adicionar("Ativo", "Ativo", largura:=80, alinhamento:=DataGridViewContentAlignment.MiddleCenter, tipo:=TipoCampo.CheckBox)
        _campos.Aplicar(GridBanqueiro)
    End Sub

    Private Sub ListarBanqueiros()
        Try
            Using conn As SqlConnection = ObterConexao()
                conn.Open()
                Using cmd As New SqlCommand("p_BaqueiroAtivo_Sel", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Nome", If(String.IsNullOrWhiteSpace(inp_nome.Text), "", inp_nome.Text.Trim()))
                    Using da As New SqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        GridBanqueiro.DataSource = dt
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao listar banqueiros: " & ex.Message, "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigureGrid()
        ListarBanqueiros()
    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        ListarBanqueiros()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ListarBanqueiros()
    End Sub

    Private Sub btnSelecionar_Click(sender As Object, e As EventArgs) Handles btnSelecionar.Click
        If GridBanqueiro.CurrentRow Is Nothing Then
            MessageBox.Show("Selecione um banqueiro.", "Atenção",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim id As Integer = Convert.ToInt32(GridBanqueiro.CurrentRow.Cells("Id").Value)
        Dim nome As String = Convert.ToString(GridBanqueiro.CurrentRow.Cells("Nome").Value)
        Dim sigla As String = Convert.ToString(GridBanqueiro.CurrentRow.Cells("Sigla").Value)
        Dim ativo As Boolean = Convert.ToBoolean(GridBanqueiro.CurrentRow.Cells("Ativo").Value)

        Using detalhe As New FormDetalheBanqueiro(id, nome, sigla, ativo)
            If detalhe.ShowDialog(Me) = DialogResult.OK Then
                ListarBanqueiros()
            End If
        End Using
    End Sub
End Class
