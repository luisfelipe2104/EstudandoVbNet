Imports Microsoft.Data.SqlClient

Public Class Form1

    Private _idSelecionado As Integer = 0
    Private _carregando As Boolean = False
    Private ReadOnly _campos As New FieldManager()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarGrid()
        CarregarBanqueiros()
    End Sub

    Private Sub ConfigurarGrid()
        _campos _
            .Adicionar("Id", "Id", visivel:=False) _
            .Adicionar("Nome", "Nome", autoSizeMode:=DataGridViewAutoSizeColumnMode.Fill) _
            .Adicionar("Sigla", "Sigla", largura:=150) _
            .Adicionar("Ativo", "Ativo", largura:=80,
                       alinhamento:=DataGridViewContentAlignment.MiddleCenter,
                       tipo:=TipoCampo.CheckBox,
                       somenteLeitura:=False)

        _campos.Aplicar(dgvBanqueiros)
    End Sub

    Private Sub CarregarBanqueiros()
        Try
            Using conn As SqlConnection = ObterConexao()
                conn.Open()
                Using cmd As New SqlCommand("SELECT Id, Nome, Sigla, Ativo FROM dbo.Banqueiro ORDER BY Nome", conn)
                    Using da As New SqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)

                        _carregando = True
                        dgvBanqueiros.DataSource = dt
                        _carregando = False
                    End Using
                End Using
            End Using

            LimparCampos()
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar banqueiros: " & ex.Message, "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If String.IsNullOrWhiteSpace(txtNome.Text) Then
            MessageBox.Show("Informe o nome do banqueiro.", "Atenção",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNome.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtSigla.Text) Then
            MessageBox.Show("Informe a sigla do banqueiro.", "Atenção",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSigla.Focus()
            Return
        End If

        Try
            Using conn As SqlConnection = ObterConexao()
                conn.Open()
                Dim sql As String

                Dim ativo As Boolean = chkAtivo.Checked
                If _idSelecionado <> 0 Then
                    sql = "UPDATE dbo.Banqueiro SET Nome = @Nome, Sigla = @Sigla, Ativo = @Ativo WHERE Id = @Id"
                    If dgvBanqueiros.CurrentRow IsNot Nothing Then
                        ativo = Convert.ToBoolean(dgvBanqueiros.CurrentRow.Cells("Ativo").Value)
                    End If
                Else
                    sql = "INSERT INTO dbo.Banqueiro (Nome, Sigla, Ativo) VALUES (@Nome, @Sigla, @Ativo)"
                End If

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Nome", txtNome.Text.Trim())
                    cmd.Parameters.AddWithValue("@Sigla", txtSigla.Text.Trim())
                    cmd.Parameters.AddWithValue("@Ativo", ativo)

                    If _idSelecionado <> 0 Then
                        cmd.Parameters.AddWithValue("@Id", _idSelecionado)
                    End If

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            CarregarBanqueiros()
        Catch ex As Exception
            MessageBox.Show("Erro ao salvar banqueiro: " & ex.Message, "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If _idSelecionado = 0 Then
            MessageBox.Show("Selecione um banqueiro na lista para excluir.", "Atenção",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim resposta As DialogResult = MessageBox.Show("Deseja realmente excluir o banqueiro selecionado?",
                                                       "Confirmação", MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question)
        If resposta <> DialogResult.Yes Then Return

        Try
            Using conn As SqlConnection = ObterConexao()
                conn.Open()
                Using cmd As New SqlCommand("DELETE FROM dbo.Banqueiro WHERE Id = @Id", conn)
                    cmd.Parameters.AddWithValue("@Id", _idSelecionado)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            CarregarBanqueiros()
        Catch ex As Exception
            MessageBox.Show("Erro ao excluir banqueiro: " & ex.Message, "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        LimparCampos()
    End Sub

    Private Sub dgvBanqueiros_SelectionChanged(sender As Object, e As EventArgs) Handles dgvBanqueiros.SelectionChanged
        If _carregando Then Return
        If dgvBanqueiros.CurrentRow Is Nothing Then Return

        Dim linha As DataGridViewRow = dgvBanqueiros.CurrentRow
        If linha.Cells("Id").Value Is Nothing OrElse linha.Cells("Id").Value Is DBNull.Value Then Return

        _idSelecionado = Convert.ToInt32(linha.Cells("Id").Value)
        txtNome.Text = Convert.ToString(linha.Cells("Nome").Value)
        txtSigla.Text = Convert.ToString(linha.Cells("Sigla").Value)
        chkAtivo.Checked = Convert.ToBoolean(linha.Cells("Ativo").Value)
    End Sub

    Private Sub dgvBanqueiros_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvBanqueiros.CurrentCellDirtyStateChanged
        If dgvBanqueiros.IsCurrentCellDirty Then
            dgvBanqueiros.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvBanqueiros_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBanqueiros.CellValueChanged
        If _carregando Then Return
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        If dgvBanqueiros.Columns(e.ColumnIndex).Name <> "Ativo" Then Return

        Dim linha As DataGridViewRow = dgvBanqueiros.Rows(e.RowIndex)
        If linha.Cells("Id").Value Is Nothing OrElse linha.Cells("Id").Value Is DBNull.Value Then Return

        Dim id As Integer = Convert.ToInt32(linha.Cells("Id").Value)
        Dim ativo As Boolean = Convert.ToBoolean(linha.Cells("Ativo").Value)

        AtualizarAtivo(id, ativo)
    End Sub

    Private Sub AtualizarAtivo(id As Integer, ativo As Boolean)
        Try
            Using conn As SqlConnection = ObterConexao()
                conn.Open()
                Using cmd As New SqlCommand("UPDATE dbo.Banqueiro SET Ativo = @Ativo WHERE Id = @Id", conn)
                    cmd.Parameters.AddWithValue("@Ativo", ativo)
                    cmd.Parameters.AddWithValue("@Id", id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            If id = _idSelecionado Then
                chkAtivo.Checked = ativo
            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao atualizar o status do banqueiro: " & ex.Message, "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            CarregarBanqueiros()
        End Try
    End Sub

    Private Sub LimparCampos()
        _carregando = True
        _idSelecionado = 0
        txtNome.Clear()
        txtSigla.Clear()
        chkAtivo.Checked = True
        dgvBanqueiros.ClearSelection()
        _carregando = False
        txtNome.Focus()
    End Sub

End Class
