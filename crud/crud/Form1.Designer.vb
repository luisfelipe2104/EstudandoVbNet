<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblNome = New Label()
        txtNome = New TextBox()
        lblSigla = New Label()
        txtSigla = New TextBox()
        chkAtivo = New CheckBox()
        btnSalvar = New Button()
        btnExcluir = New Button()
        btnLimpar = New Button()
        dgvBanqueiros = New DataGridView()
        CType(dgvBanqueiros, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblNome
        ' 
        lblNome.AutoSize = True
        lblNome.Location = New Point(20, 23)
        lblNome.Name = "lblNome"
        lblNome.Size = New Size(43, 15)
        lblNome.TabIndex = 0
        lblNome.Text = "Nome:"
        ' 
        ' txtNome
        ' 
        txtNome.Location = New Point(70, 20)
        txtNome.Name = "txtNome"
        txtNome.Size = New Size(250, 23)
        txtNome.TabIndex = 1
        ' 
        ' lblSigla
        ' 
        lblSigla.AutoSize = True
        lblSigla.Location = New Point(340, 23)
        lblSigla.Name = "lblSigla"
        lblSigla.Size = New Size(35, 15)
        lblSigla.TabIndex = 2
        lblSigla.Text = "Sigla:"
        ' 
        ' txtSigla
        ' 
        txtSigla.Location = New Point(382, 20)
        txtSigla.Name = "txtSigla"
        txtSigla.Size = New Size(120, 23)
        txtSigla.TabIndex = 3
        ' 
        ' chkAtivo
        ' 
        chkAtivo.AutoSize = True
        chkAtivo.Checked = True
        chkAtivo.CheckState = CheckState.Checked
        chkAtivo.Location = New Point(530, 22)
        chkAtivo.Name = "chkAtivo"
        chkAtivo.Size = New Size(54, 19)
        chkAtivo.TabIndex = 4
        chkAtivo.Text = "Ativo"
        chkAtivo.UseVisualStyleBackColor = True
        ' 
        ' btnSalvar
        ' 
        btnSalvar.Location = New Point(70, 55)
        btnSalvar.Name = "btnSalvar"
        btnSalvar.Size = New Size(110, 30)
        btnSalvar.TabIndex = 5
        btnSalvar.Text = "Salvar"
        btnSalvar.UseVisualStyleBackColor = True
        ' 
        ' btnExcluir
        ' 
        btnExcluir.Location = New Point(190, 55)
        btnExcluir.Name = "btnExcluir"
        btnExcluir.Size = New Size(110, 30)
        btnExcluir.TabIndex = 6
        btnExcluir.Text = "Excluir"
        btnExcluir.UseVisualStyleBackColor = True
        ' 
        ' btnLimpar
        ' 
        btnLimpar.Location = New Point(310, 55)
        btnLimpar.Name = "btnLimpar"
        btnLimpar.Size = New Size(110, 30)
        btnLimpar.TabIndex = 7
        btnLimpar.Text = "Novo / Limpar"
        btnLimpar.UseVisualStyleBackColor = True
        ' 
        ' dgvBanqueiros
        ' 
        dgvBanqueiros.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvBanqueiros.Location = New Point(20, 100)
        dgvBanqueiros.Name = "dgvBanqueiros"
        dgvBanqueiros.Size = New Size(760, 350)
        dgvBanqueiros.TabIndex = 8
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 480)
        Controls.Add(dgvBanqueiros)
        Controls.Add(btnLimpar)
        Controls.Add(btnExcluir)
        Controls.Add(btnSalvar)
        Controls.Add(chkAtivo)
        Controls.Add(txtSigla)
        Controls.Add(lblSigla)
        Controls.Add(txtNome)
        Controls.Add(lblNome)
        MinimumSize = New Size(600, 400)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Cadastro de Banqueiros"
        CType(dgvBanqueiros, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblNome As System.Windows.Forms.Label
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents lblSigla As System.Windows.Forms.Label
    Friend WithEvents txtSigla As System.Windows.Forms.TextBox
    Friend WithEvents chkAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents btnExcluir As System.Windows.Forms.Button
    Friend WithEvents btnLimpar As System.Windows.Forms.Button
    Friend WithEvents dgvBanqueiros As System.Windows.Forms.DataGridView

End Class
