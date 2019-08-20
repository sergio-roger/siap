<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_buscar_cliente
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txt_buscar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv_clientes = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.txt_buscar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(546, 95)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(437, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 70)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'txt_buscar
        '
        Me.txt_buscar.Location = New System.Drawing.Point(146, 40)
        Me.txt_buscar.Name = "txt_buscar"
        Me.txt_buscar.Size = New System.Drawing.Size(182, 20)
        Me.txt_buscar.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Buscar por cédula"
        '
        'dgv_clientes
        '
        Me.dgv_clientes.AllowUserToAddRows = False
        Me.dgv_clientes.AllowUserToDeleteRows = False
        Me.dgv_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_clientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column4, Me.Column2, Me.Column3, Me.Column5, Me.Column6, Me.Column7})
        Me.dgv_clientes.Location = New System.Drawing.Point(17, 136)
        Me.dgv_clientes.Name = "dgv_clientes"
        Me.dgv_clientes.ReadOnly = True
        Me.dgv_clientes.Size = New System.Drawing.Size(546, 191)
        Me.dgv_clientes.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "Id"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Cedula"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Nombre"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Apellido"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Dieccion"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Telefono"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Correo"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'frm_buscar_cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 346)
        Me.Controls.Add(Me.dgv_clientes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frm_buscar_cliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_buscar_cliente"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txt_buscar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgv_clientes As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
End Class
