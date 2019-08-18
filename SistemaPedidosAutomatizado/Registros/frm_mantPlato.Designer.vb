<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mantPlato
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmb_opcion = New System.Windows.Forms.ComboBox()
        Me.txt_buscar = New System.Windows.Forms.TextBox()
        Me.dgv_platos = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_modalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.imagen = New System.Windows.Forms.DataGridViewImageColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_platos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.GroupBox3.Size = New System.Drawing.Size(488, 61)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Buscar por Código"
        '
        'cmb_opcion
        '
        Me.cmb_opcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_opcion.FormattingEnabled = True
        Me.cmb_opcion.Items.AddRange(New Object() {"codigo", "plato"})
        Me.cmb_opcion.Location = New System.Drawing.Point(6, 21)
        Me.cmb_opcion.Name = "cmb_opcion"
        Me.cmb_opcion.Size = New System.Drawing.Size(186, 24)
        Me.cmb_opcion.TabIndex = 1
        '
        'txt_buscar
        '
        Me.txt_buscar.Location = New System.Drawing.Point(214, 23)
        Me.txt_buscar.Name = "txt_buscar"
        Me.txt_buscar.Size = New System.Drawing.Size(194, 22)
        Me.txt_buscar.TabIndex = 0
        '
        'dgv_platos
        '
        Me.dgv_platos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_platos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.codigo, Me.nombre, Me.id_modalidad, Me.Modalidad, Me.precio, Me.descripcion, Me.imagen, Me.estado})
        Me.dgv_platos.GridColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgv_platos.Location = New System.Drawing.Point(12, 82)
        Me.dgv_platos.Name = "dgv_platos"
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgv_platos.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_platos.Size = New System.Drawing.Size(488, 150)
        Me.dgv_platos.TabIndex = 21
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        '
        'codigo
        '
        Me.codigo.HeaderText = "codigo"
        Me.codigo.Name = "codigo"
        '
        'nombre
        '
        Me.nombre.HeaderText = "Plato"
        Me.nombre.Name = "nombre"
        '
        'id_modalidad
        '
        Me.id_modalidad.HeaderText = "id_modalidad"
        Me.id_modalidad.Name = "id_modalidad"
        '
        'Modalidad
        '
        Me.Modalidad.HeaderText = "Modalidad"
        Me.Modalidad.Name = "Modalidad"
        '
        'precio
        '
        Me.precio.HeaderText = "precio"
        Me.precio.Name = "precio"
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "descripcion"
        Me.descripcion.Name = "descripcion"
        '
        'imagen
        '
        Me.imagen.HeaderText = "imagen"
        Me.imagen.Name = "imagen"
        '
        'estado
        '
        Me.estado.HeaderText = "estado"
        Me.estado.Name = "estado"
        '
        'frm_mantPlato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(523, 244)
        Me.Controls.Add(Me.dgv_platos)
        Me.Controls.Add(Me.GroupBox3)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "frm_mantPlato"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_mantPlato"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgv_platos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmb_opcion As ComboBox
    Friend WithEvents txt_buscar As TextBox
    Friend WithEvents dgv_platos As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents codigo As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents id_modalidad As DataGridViewTextBoxColumn
    Friend WithEvents Modalidad As DataGridViewTextBoxColumn
    Friend WithEvents precio As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents imagen As DataGridViewImageColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
End Class
