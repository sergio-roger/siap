<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mantCombo
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
        Me.dgv_usuarios = New System.Windows.Forms.DataGridView()
        Me.col_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_modalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_contenido1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_bebida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_porcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmb_opcion = New System.Windows.Forms.ComboBox()
        Me.txt_buscar = New System.Windows.Forms.TextBox()
        CType(Me.dgv_usuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_usuarios
        '
        Me.dgv_usuarios.AllowUserToAddRows = False
        Me.dgv_usuarios.BackgroundColor = System.Drawing.SystemColors.Highlight
        Me.dgv_usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_usuarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_id, Me.col_codigo, Me.col_modalidad, Me.col_contenido1, Me.col_bebida, Me.col_precio, Me.col_desc, Me.col_porcentaje, Me.col_estado})
        Me.dgv_usuarios.Location = New System.Drawing.Point(12, 93)
        Me.dgv_usuarios.Name = "dgv_usuarios"
        Me.dgv_usuarios.ReadOnly = True
        Me.dgv_usuarios.Size = New System.Drawing.Size(607, 131)
        Me.dgv_usuarios.TabIndex = 21
        '
        'col_id
        '
        Me.col_id.HeaderText = "ID"
        Me.col_id.Name = "col_id"
        Me.col_id.ReadOnly = True
        '
        'col_codigo
        '
        Me.col_codigo.HeaderText = "Codigo"
        Me.col_codigo.Name = "col_codigo"
        Me.col_codigo.ReadOnly = True
        '
        'col_modalidad
        '
        Me.col_modalidad.HeaderText = "Modalidad"
        Me.col_modalidad.Name = "col_modalidad"
        Me.col_modalidad.ReadOnly = True
        Me.col_modalidad.Width = 120
        '
        'col_contenido1
        '
        Me.col_contenido1.HeaderText = "Contenido1"
        Me.col_contenido1.Name = "col_contenido1"
        Me.col_contenido1.ReadOnly = True
        Me.col_contenido1.Width = 180
        '
        'col_bebida
        '
        Me.col_bebida.HeaderText = "Bebida"
        Me.col_bebida.Name = "col_bebida"
        Me.col_bebida.ReadOnly = True
        '
        'col_precio
        '
        Me.col_precio.HeaderText = "Precio"
        Me.col_precio.Name = "col_precio"
        Me.col_precio.ReadOnly = True
        '
        'col_desc
        '
        Me.col_desc.HeaderText = "Descuento"
        Me.col_desc.Name = "col_desc"
        Me.col_desc.ReadOnly = True
        '
        'col_porcentaje
        '
        Me.col_porcentaje.HeaderText = "Porcentaje"
        Me.col_porcentaje.Name = "col_porcentaje"
        Me.col_porcentaje.ReadOnly = True
        '
        'col_estado
        '
        Me.col_estado.HeaderText = "Estado"
        Me.col_estado.Name = "col_estado"
        Me.col_estado.ReadOnly = True
        Me.col_estado.Width = 70
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.cmb_opcion)
        Me.GroupBox3.Controls.Add(Me.txt_buscar)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.Highlight
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(607, 61)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Buscar por Código"
        '
        'cmb_opcion
        '
        Me.cmb_opcion.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.cmb_opcion.FormattingEnabled = True
        Me.cmb_opcion.Items.AddRange(New Object() {"Código", "Contenido 1"})
        Me.cmb_opcion.Location = New System.Drawing.Point(6, 21)
        Me.cmb_opcion.Name = "cmb_opcion"
        Me.cmb_opcion.Size = New System.Drawing.Size(186, 24)
        Me.cmb_opcion.TabIndex = 1
        Me.cmb_opcion.Text = "Código"
        '
        'txt_buscar
        '
        Me.txt_buscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_buscar.Location = New System.Drawing.Point(213, 21)
        Me.txt_buscar.Name = "txt_buscar"
        Me.txt_buscar.Size = New System.Drawing.Size(194, 22)
        Me.txt_buscar.TabIndex = 0
        '
        'frm_mantCombo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(634, 242)
        Me.Controls.Add(Me.dgv_usuarios)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "frm_mantCombo"
        Me.Text = "frm_mantCombo"
        CType(Me.dgv_usuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_usuarios As DataGridView
    Friend WithEvents col_id As DataGridViewTextBoxColumn
    Friend WithEvents col_codigo As DataGridViewTextBoxColumn
    Friend WithEvents col_modalidad As DataGridViewTextBoxColumn
    Friend WithEvents col_contenido1 As DataGridViewTextBoxColumn
    Friend WithEvents col_bebida As DataGridViewTextBoxColumn
    Friend WithEvents col_precio As DataGridViewTextBoxColumn
    Friend WithEvents col_desc As DataGridViewTextBoxColumn
    Friend WithEvents col_porcentaje As DataGridViewTextBoxColumn
    Friend WithEvents col_estado As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmb_opcion As ComboBox
    Friend WithEvents txt_buscar As TextBox
End Class
