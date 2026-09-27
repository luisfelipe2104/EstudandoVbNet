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
        GridBanqueiro = New DataGridView()
        btnSalvar = New Button()
        inp_nome = New TextBox()
        btnBuscar = New Button()
        CType(GridBanqueiro, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GridBanqueiro
        ' 
        GridBanqueiro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        GridBanqueiro.Location = New Point(12, 194)
        GridBanqueiro.Name = "GridBanqueiro"
        GridBanqueiro.Size = New Size(776, 244)
        GridBanqueiro.TabIndex = 0
        ' 
        ' btnSalvar
        ' 
        btnSalvar.Location = New Point(684, 152)
        btnSalvar.Name = "btnSalvar"
        btnSalvar.Size = New Size(75, 23)
        btnSalvar.TabIndex = 2
        btnSalvar.Text = "Salvar"
        btnSalvar.UseVisualStyleBackColor = True
        ' 
        ' inp_nome
        ' 
        inp_nome.Location = New Point(12, 152)
        inp_nome.Name = "inp_nome"
        inp_nome.Size = New Size(413, 23)
        inp_nome.TabIndex = 3
        ' 
        ' btnBuscar
        ' 
        btnBuscar.Location = New Point(431, 152)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(75, 23)
        btnBuscar.TabIndex = 4
        btnBuscar.Text = "Buscar"
        btnBuscar.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnBuscar)
        Controls.Add(inp_nome)
        Controls.Add(btnSalvar)
        Controls.Add(GridBanqueiro)
        Name = "Form1"
        Text = "Form1"
        CType(GridBanqueiro, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GridBanqueiro As DataGridView
    Friend WithEvents btnSalvar As Button
    Friend WithEvents inp_nome As TextBox
    Friend WithEvents btnBuscar As Button

End Class
