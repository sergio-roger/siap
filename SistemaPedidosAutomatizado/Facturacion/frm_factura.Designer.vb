<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_factura
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.date_hora = New System.Windows.Forms.DateTimePicker()
        Me.date_fecha = New System.Windows.Forms.DateTimePicker()
        Me.txt_usuario = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_correo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_Telefono = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_direccion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_apellidos = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_nombres = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_cedula = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgv_pedido = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.hjj = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.txt_descuento = New System.Windows.Forms.TextBox()
        Me.btn_borrar = New System.Windows.Forms.Button()
        Me.col_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_id_ped = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_id_tc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_id_comida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_porcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_subtotal = New System.Windows.Forms.TextBox()
        Me.bn_buscar_cliente = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_grabar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chk_activar = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv_pedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(502, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Factura"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_activar)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.date_hora)
        Me.GroupBox1.Controls.Add(Me.date_fecha)
        Me.GroupBox1.Controls.Add(Me.txt_usuario)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(807, 130)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Tomato
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Location = New System.Drawing.Point(722, 45)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(79, 71)
        Me.Button2.TabIndex = 60
        Me.Button2.Text = "Imprimir"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.Tomato
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscar.Location = New System.Drawing.Point(627, 45)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(79, 71)
        Me.btn_buscar.TabIndex = 59
        Me.btn_buscar.Text = "buscar"
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(321, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Hora"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(321, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(321, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Usuario"
        '
        'date_hora
        '
        Me.date_hora.Enabled = False
        Me.date_hora.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.date_hora.Location = New System.Drawing.Point(395, 89)
        Me.date_hora.Name = "date_hora"
        Me.date_hora.Size = New System.Drawing.Size(188, 20)
        Me.date_hora.TabIndex = 6
        '
        'date_fecha
        '
        Me.date_fecha.Enabled = False
        Me.date_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_fecha.Location = New System.Drawing.Point(395, 58)
        Me.date_fecha.Name = "date_fecha"
        Me.date_fecha.Size = New System.Drawing.Size(188, 20)
        Me.date_fecha.TabIndex = 5
        '
        'txt_usuario
        '
        Me.txt_usuario.Location = New System.Drawing.Point(395, 25)
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.ReadOnly = True
        Me.txt_usuario.Size = New System.Drawing.Size(188, 20)
        Me.txt_usuario.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(171, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "098976568"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(167, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Ecuador, Santa Elena"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(167, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Empresa SIAP S.A"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bn_buscar_cliente)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txt_correo)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txt_Telefono)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txt_direccion)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txt_apellidos)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txt_nombres)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txt_cedula)
        Me.GroupBox2.Location = New System.Drawing.Point(25, 213)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(278, 233)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 193)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 13)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Correo"
        '
        'txt_correo
        '
        Me.txt_correo.Location = New System.Drawing.Point(84, 193)
        Me.txt_correo.Name = "txt_correo"
        Me.txt_correo.Size = New System.Drawing.Size(178, 20)
        Me.txt_correo.TabIndex = 20
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 159)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Telefono"
        '
        'txt_Telefono
        '
        Me.txt_Telefono.Location = New System.Drawing.Point(84, 159)
        Me.txt_Telefono.Name = "txt_Telefono"
        Me.txt_Telefono.Size = New System.Drawing.Size(178, 20)
        Me.txt_Telefono.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 126)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Dirección"
        '
        'txt_direccion
        '
        Me.txt_direccion.Location = New System.Drawing.Point(84, 126)
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.Size = New System.Drawing.Size(182, 20)
        Me.txt_direccion.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Apellidos"
        '
        'txt_apellidos
        '
        Me.txt_apellidos.Location = New System.Drawing.Point(84, 94)
        Me.txt_apellidos.Name = "txt_apellidos"
        Me.txt_apellidos.Size = New System.Drawing.Size(182, 20)
        Me.txt_apellidos.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Nombres"
        '
        'txt_nombres
        '
        Me.txt_nombres.Location = New System.Drawing.Point(84, 64)
        Me.txt_nombres.Name = "txt_nombres"
        Me.txt_nombres.Size = New System.Drawing.Size(182, 20)
        Me.txt_nombres.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Cédula"
        '
        'txt_cedula
        '
        Me.txt_cedula.Location = New System.Drawing.Point(84, 34)
        Me.txt_cedula.Name = "txt_cedula"
        Me.txt_cedula.Size = New System.Drawing.Size(104, 20)
        Me.txt_cedula.TabIndex = 10
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgv_pedido)
        Me.GroupBox3.Location = New System.Drawing.Point(321, 213)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(511, 233)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pedido"
        '
        'dgv_pedido
        '
        Me.dgv_pedido.AllowUserToAddRows = False
        Me.dgv_pedido.BackgroundColor = System.Drawing.SystemColors.Highlight
        Me.dgv_pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pedido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_id, Me.col_id_ped, Me.col_id_tc, Me.col_id_comida, Me.col_nombre, Me.col_cantidad, Me.col_precio, Me.col_descuento, Me.col_porcentaje, Me.col_subtotal, Me.col_total, Me.col_estado})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Cornsilk
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_pedido.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_pedido.GridColor = System.Drawing.Color.White
        Me.dgv_pedido.Location = New System.Drawing.Point(15, 19)
        Me.dgv_pedido.Name = "dgv_pedido"
        Me.dgv_pedido.ReadOnly = True
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgv_pedido.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_pedido.Size = New System.Drawing.Size(490, 194)
        Me.dgv_pedido.TabIndex = 67
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_subtotal)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.hjj)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.txt_total)
        Me.GroupBox4.Controls.Add(Me.txt_descuento)
        Me.GroupBox4.Location = New System.Drawing.Point(321, 458)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(511, 84)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        '
        'hjj
        '
        Me.hjj.AutoSize = True
        Me.hjj.Location = New System.Drawing.Point(364, 22)
        Me.hjj.Name = "hjj"
        Me.hjj.Size = New System.Drawing.Size(31, 13)
        Me.hjj.TabIndex = 63
        Me.hjj.Text = "Total"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(185, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 62
        Me.Label15.Text = "Descuento"
        '
        'txt_total
        '
        Me.txt_total.Location = New System.Drawing.Point(367, 48)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(138, 20)
        Me.txt_total.TabIndex = 2
        '
        'txt_descuento
        '
        Me.txt_descuento.Location = New System.Drawing.Point(188, 48)
        Me.txt_descuento.Name = "txt_descuento"
        Me.txt_descuento.ReadOnly = True
        Me.txt_descuento.Size = New System.Drawing.Size(138, 20)
        Me.txt_descuento.TabIndex = 1
        '
        'btn_borrar
        '
        Me.btn_borrar.BackColor = System.Drawing.Color.Tomato
        Me.btn_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_borrar.Location = New System.Drawing.Point(143, 11)
        Me.btn_borrar.Name = "btn_borrar"
        Me.btn_borrar.Size = New System.Drawing.Size(50, 51)
        Me.btn_borrar.TabIndex = 56
        Me.btn_borrar.Text = "X"
        Me.btn_borrar.UseVisualStyleBackColor = False
        '
        'col_id
        '
        Me.col_id.HeaderText = "Id"
        Me.col_id.Name = "col_id"
        Me.col_id.ReadOnly = True
        Me.col_id.Visible = False
        Me.col_id.Width = 50
        '
        'col_id_ped
        '
        Me.col_id_ped.HeaderText = "Id Ped"
        Me.col_id_ped.Name = "col_id_ped"
        Me.col_id_ped.ReadOnly = True
        Me.col_id_ped.Visible = False
        Me.col_id_ped.Width = 50
        '
        'col_id_tc
        '
        Me.col_id_tc.HeaderText = "Id  Tc"
        Me.col_id_tc.Name = "col_id_tc"
        Me.col_id_tc.ReadOnly = True
        Me.col_id_tc.Visible = False
        Me.col_id_tc.Width = 50
        '
        'col_id_comida
        '
        Me.col_id_comida.HeaderText = "Id Comida"
        Me.col_id_comida.Name = "col_id_comida"
        Me.col_id_comida.ReadOnly = True
        Me.col_id_comida.Visible = False
        Me.col_id_comida.Width = 50
        '
        'col_nombre
        '
        Me.col_nombre.HeaderText = "Nombre"
        Me.col_nombre.Name = "col_nombre"
        Me.col_nombre.ReadOnly = True
        '
        'col_cantidad
        '
        Me.col_cantidad.HeaderText = "Cantidad"
        Me.col_cantidad.Name = "col_cantidad"
        Me.col_cantidad.ReadOnly = True
        '
        'col_precio
        '
        Me.col_precio.HeaderText = "Precio U"
        Me.col_precio.Name = "col_precio"
        Me.col_precio.ReadOnly = True
        '
        'col_descuento
        '
        Me.col_descuento.HeaderText = "Descuento"
        Me.col_descuento.Name = "col_descuento"
        Me.col_descuento.ReadOnly = True
        '
        'col_porcentaje
        '
        Me.col_porcentaje.HeaderText = "Porcentaje"
        Me.col_porcentaje.Name = "col_porcentaje"
        Me.col_porcentaje.ReadOnly = True
        '
        'col_subtotal
        '
        Me.col_subtotal.HeaderText = "Subtotal"
        Me.col_subtotal.Name = "col_subtotal"
        Me.col_subtotal.ReadOnly = True
        '
        'col_total
        '
        Me.col_total.HeaderText = "Total"
        Me.col_total.Name = "col_total"
        Me.col_total.ReadOnly = True
        '
        'col_estado
        '
        Me.col_estado.HeaderText = "Estado"
        Me.col_estado.Name = "col_estado"
        Me.col_estado.ReadOnly = True
        Me.col_estado.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(25, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "Subtotal"
        '
        'txt_subtotal
        '
        Me.txt_subtotal.Location = New System.Drawing.Point(28, 48)
        Me.txt_subtotal.Name = "txt_subtotal"
        Me.txt_subtotal.ReadOnly = True
        Me.txt_subtotal.Size = New System.Drawing.Size(138, 20)
        Me.txt_subtotal.TabIndex = 65
        '
        'bn_buscar_cliente
        '
        Me.bn_buscar_cliente.BackColor = System.Drawing.Color.Tomato
        Me.bn_buscar_cliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bn_buscar_cliente.Location = New System.Drawing.Point(207, 19)
        Me.bn_buscar_cliente.Name = "bn_buscar_cliente"
        Me.bn_buscar_cliente.Size = New System.Drawing.Size(59, 39)
        Me.bn_buscar_cliente.TabIndex = 61
        Me.bn_buscar_cliente.Text = "buscar"
        Me.bn_buscar_cliente.UseVisualStyleBackColor = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.DodgerBlue
        Me.btn_nuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_nuevo.Image = Global.SistemaPedidosAutomatizado.My.Resources.Resources.boton_nuevo_n
        Me.btn_nuevo.Location = New System.Drawing.Point(31, 9)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(50, 53)
        Me.btn_nuevo.TabIndex = 58
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'btn_grabar
        '
        Me.btn_grabar.BackColor = System.Drawing.Color.LimeGreen
        Me.btn_grabar.Image = Global.SistemaPedidosAutomatizado.My.Resources.Resources.boton_guardar_n
        Me.btn_grabar.Location = New System.Drawing.Point(87, 10)
        Me.btn_grabar.Name = "btn_grabar"
        Me.btn_grabar.Size = New System.Drawing.Size(50, 53)
        Me.btn_grabar.TabIndex = 57
        Me.btn_grabar.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(20, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(121, 97)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'chk_activar
        '
        Me.chk_activar.AutoSize = True
        Me.chk_activar.Location = New System.Drawing.Point(627, 19)
        Me.chk_activar.Name = "chk_activar"
        Me.chk_activar.Size = New System.Drawing.Size(81, 17)
        Me.chk_activar.TabIndex = 61
        Me.chk_activar.Text = "CheckBox1"
        Me.chk_activar.UseVisualStyleBackColor = True
        '
        'frm_factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 553)
        Me.Controls.Add(Me.btn_nuevo)
        Me.Controls.Add(Me.btn_borrar)
        Me.Controls.Add(Me.btn_grabar)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_factura"
        Me.Text = "frm_factura"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgv_pedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents date_hora As DateTimePicker
    Friend WithEvents date_fecha As DateTimePicker
    Friend WithEvents txt_usuario As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txt_correo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txt_Telefono As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txt_direccion As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txt_apellidos As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_nombres As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_cedula As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dgv_pedido As DataGridView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btn_nuevo As Button
    Friend WithEvents btn_borrar As Button
    Friend WithEvents btn_grabar As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btn_buscar As Button
    Friend WithEvents hjj As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txt_total As TextBox
    Friend WithEvents txt_descuento As TextBox
    Friend WithEvents col_id As DataGridViewTextBoxColumn
    Friend WithEvents col_id_ped As DataGridViewTextBoxColumn
    Friend WithEvents col_id_tc As DataGridViewTextBoxColumn
    Friend WithEvents col_id_comida As DataGridViewTextBoxColumn
    Friend WithEvents col_nombre As DataGridViewTextBoxColumn
    Friend WithEvents col_cantidad As DataGridViewTextBoxColumn
    Friend WithEvents col_precio As DataGridViewTextBoxColumn
    Friend WithEvents col_descuento As DataGridViewTextBoxColumn
    Friend WithEvents col_porcentaje As DataGridViewTextBoxColumn
    Friend WithEvents col_subtotal As DataGridViewTextBoxColumn
    Friend WithEvents col_total As DataGridViewTextBoxColumn
    Friend WithEvents col_estado As DataGridViewTextBoxColumn
    Friend WithEvents txt_subtotal As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents bn_buscar_cliente As Button
    Friend WithEvents chk_activar As CheckBox
End Class
