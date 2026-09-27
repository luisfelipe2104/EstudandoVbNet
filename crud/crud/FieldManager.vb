Imports System.Drawing
Imports System.Windows.Forms

Public Enum TipoCampo
    Texto
    CheckBox
End Enum

Public Class CampoGrid

    Public Property Propriedade As String
    Public Property Cabecalho As String
    Public Property Largura As Integer = 100
    Public Property Visivel As Boolean = True
    Public Property Formato As String = ""
    Public Property Alinhamento As DataGridViewContentAlignment = DataGridViewContentAlignment.NotSet
    Public Property AutoSizeMode As DataGridViewAutoSizeColumnMode = DataGridViewAutoSizeColumnMode.None
    Public Property Tipo As TipoCampo = TipoCampo.Texto
    Public Property SomenteLeitura As Boolean = True

End Class

Public Class FieldManager

    Private ReadOnly _campos As New List(Of CampoGrid)

    Public ReadOnly Property Campos As IReadOnlyList(Of CampoGrid)
        Get
            Return _campos
        End Get
    End Property

    Public Function Adicionar(propriedade As String,
                              cabecalho As String,
                              Optional largura As Integer = 100,
                              Optional visivel As Boolean = True,
                              Optional formato As String = "",
                              Optional alinhamento As DataGridViewContentAlignment = DataGridViewContentAlignment.NotSet,
                              Optional autoSizeMode As DataGridViewAutoSizeColumnMode = DataGridViewAutoSizeColumnMode.None,
                              Optional tipo As TipoCampo = TipoCampo.Texto,
                              Optional somenteLeitura As Boolean = True) As FieldManager

        _campos.Add(New CampoGrid With {
            .Propriedade = propriedade,
            .Cabecalho = cabecalho,
            .Largura = largura,
            .Visivel = visivel,
            .Formato = formato,
            .Alinhamento = alinhamento,
            .AutoSizeMode = autoSizeMode,
            .Tipo = tipo,
            .SomenteLeitura = somenteLeitura
        })

        Return Me
    End Function

    Public Sub Aplicar(grid As DataGridView)
        CriarColunas(grid)
        FormatarGrid(grid)
    End Sub

    Private Sub CriarColunas(grid As DataGridView)
        grid.AutoGenerateColumns = False
        grid.Columns.Clear()

        For Each campo As CampoGrid In _campos
            Dim coluna As DataGridViewColumn

            If campo.Tipo = TipoCampo.CheckBox Then
                coluna = New DataGridViewCheckBoxColumn()
            Else
                coluna = New DataGridViewTextBoxColumn()
            End If

            coluna.Name = campo.Propriedade
            coluna.DataPropertyName = campo.Propriedade
            coluna.HeaderText = campo.Cabecalho
            coluna.Width = campo.Largura
            coluna.Visible = campo.Visivel
            coluna.AutoSizeMode = campo.AutoSizeMode
            coluna.SortMode = DataGridViewColumnSortMode.Automatic
            coluna.ReadOnly = campo.SomenteLeitura

            If Not String.IsNullOrEmpty(campo.Formato) Then
                coluna.DefaultCellStyle.Format = campo.Formato
            End If

            If campo.Alinhamento <> DataGridViewContentAlignment.NotSet Then
                coluna.DefaultCellStyle.Alignment = campo.Alinhamento
                coluna.HeaderCell.Style.Alignment = campo.Alinhamento
            End If

            grid.Columns.Add(coluna)
        Next
    End Sub

    Public Sub FormatarGrid(grid As DataGridView)
        grid.BorderStyle = BorderStyle.Fixed3D
        grid.BackgroundColor = Color.White
        grid.GridColor = Color.Gainsboro
        grid.RowHeadersVisible = False
        grid.EnableHeadersVisualStyles = False

        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48)
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 48)
        grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White
        grid.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grid.ColumnHeadersHeight = 32

        grid.RowTemplate.Height = 26
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215)
        grid.DefaultCellStyle.SelectionForeColor = Color.White
        grid.DefaultCellStyle.Font = New Font("Segoe UI", 9.0F)

        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        grid.MultiSelect = False
        grid.AllowUserToAddRows = False
        grid.AllowUserToDeleteRows = False
        grid.AllowUserToResizeRows = False
        grid.ReadOnly = False
    End Sub

End Class
