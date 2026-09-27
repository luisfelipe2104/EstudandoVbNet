<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDetalheBanqueiro
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblNome = New Label()
        txtNome = New TextBox()
        lblSigla = New Label()
        txtSigla = New TextBox()
        lblSituacao = New Label()
        chkAtivo = New CheckBox()
        btnSalvar = New Button()
        SuspendLayout()
        ' 
        ' lblNome
        ' 
        lblNome.AutoSize = True
        lblNome.Location = New Point(20, 20)
        lblNome.Name = "lblNome"
        lblNome.Size = New Size(40, 15)
        lblNome.TabIndex = 0
        lblNome.Text = "Nome"
        ' 
        ' txtNome
        ' 
        txtNome.Location = New Point(20, 40)
        txtNome.Name = "txtNome"
        txtNome.ReadOnly = True
        txtNome.Size = New Size(340, 23)
        txtNome.TabIndex = 1
        txtNome.TabStop = False
        ' 
        ' lblSigla
        ' 
        lblSigla.AutoSize = True
        lblSigla.Location = New Point(20, 78)
        lblSigla.Name = "lblSigla"
        lblSigla.Size = New Size(34, 15)
        lblSigla.TabIndex = 2
        lblSigla.Text = "Sigla"
        ' 
        ' txtSigla
        ' 
        txtSigla.Location = New Point(20, 98)
        txtSigla.Name = "txtSigla"
        txtSigla.ReadOnly = True
        txtSigla.Size = New Size(150, 23)
        txtSigla.TabIndex = 3
        txtSigla.TabStop = False
        ' 
        ' lblSituacao
        ' 
        lblSituacao.AutoSize = True
        lblSituacao.Location = New Point(20, 140)
        lblSituacao.Name = "lblSituacao"
        lblSituacao.Size = New Size(52, 15)
        lblSituacao.TabIndex = 4
        lblSituacao.Text = "Situação"
        ' 
        ' chkAtivo
        ' 
        chkAtivo.AutoSize = True
        chkAtivo.Location = New Point(20, 160)
        chkAtivo.Name = "chkAtivo"
        chkAtivo.Size = New Size(55, 19)
        chkAtivo.TabIndex = 5
        chkAtivo.Text = "Ativo"
        chkAtivo.UseVisualStyleBackColor = True
        ' 
        ' btnSalvar
        ' 
        btnSalvar.Location = New Point(285, 202)
        btnSalvar.Name = "btnSalvar"
        btnSalvar.Size = New Size(75, 30)
        btnSalvar.TabIndex = 6
        btnSalvar.Text = "Salvar"
        btnSalvar.UseVisualStyleBackColor = True
        ' 
        ' FormDetalheBanqueiro
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(384, 251)
        Controls.Add(chkAtivo)
        Controls.Add(lblSituacao)
        Controls.Add(txtSigla)
        Controls.Add(lblSigla)
        Controls.Add(txtNome)
        Controls.Add(lblNome)
        Controls.Add(btnSalvar)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "FormDetalheBanqueiro"
        StartPosition = FormStartPosition.CenterParent
        Text = "Detalhe do Banqueiro"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblNome As Label
    Friend WithEvents txtNome As TextBox
    Friend WithEvents lblSigla As Label
    Friend WithEvents txtSigla As TextBox
    Friend WithEvents lblSituacao As Label
    Friend WithEvents chkAtivo As CheckBox
    Friend WithEvents btnSalvar As Button

End Class
