<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_movimiento
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
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ptc_logo = New System.Windows.Forms.PictureBox()
        Me.date_fecha_hasta = New System.Windows.Forms.DateTimePicker()
        Me.date_fecha_desde = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.rdb_compra = New System.Windows.Forms.RadioButton()
        Me.rdb_venta = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ptc_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_salir
        '
        Me.btn_salir.Location = New System.Drawing.Point(142, 8)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(111, 51)
        Me.btn_salir.TabIndex = 14
        Me.btn_salir.Text = "X"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CrystalReportViewer1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 195)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(776, 301)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(3, 16)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(770, 282)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(351, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 25)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "REPORTES"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ptc_logo)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.date_fecha_hasta)
        Me.GroupBox1.Controls.Add(Me.date_fecha_desde)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo_tipo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 125)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'ptc_logo
        '
        Me.ptc_logo.Location = New System.Drawing.Point(616, 19)
        Me.ptc_logo.Name = "ptc_logo"
        Me.ptc_logo.Size = New System.Drawing.Size(133, 92)
        Me.ptc_logo.TabIndex = 9
        Me.ptc_logo.TabStop = False
        '
        'date_fecha_hasta
        '
        Me.date_fecha_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_fecha_hasta.Location = New System.Drawing.Point(376, 77)
        Me.date_fecha_hasta.Name = "date_fecha_hasta"
        Me.date_fecha_hasta.Size = New System.Drawing.Size(103, 20)
        Me.date_fecha_hasta.TabIndex = 5
        '
        'date_fecha_desde
        '
        Me.date_fecha_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_fecha_desde.Location = New System.Drawing.Point(376, 34)
        Me.date_fecha_desde.Name = "date_fecha_desde"
        Me.date_fecha_desde.Size = New System.Drawing.Size(103, 20)
        Me.date_fecha_desde.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(319, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Hasta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(316, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Desde"
        '
        'cbo_tipo
        '
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"Platos", "Combos", "Ambos"})
        Me.cbo_tipo.Location = New System.Drawing.Point(89, 31)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(182, 21)
        Me.cbo_tipo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tipo"
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Location = New System.Drawing.Point(15, 8)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(111, 51)
        Me.btn_imprimir.TabIndex = 15
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'rdb_compra
        '
        Me.rdb_compra.AutoSize = True
        Me.rdb_compra.Location = New System.Drawing.Point(6, 10)
        Me.rdb_compra.Name = "rdb_compra"
        Me.rdb_compra.Size = New System.Drawing.Size(66, 17)
        Me.rdb_compra.TabIndex = 0
        Me.rdb_compra.TabStop = True
        Me.rdb_compra.Text = "Compras"
        Me.rdb_compra.UseVisualStyleBackColor = True
        '
        'rdb_venta
        '
        Me.rdb_venta.AutoSize = True
        Me.rdb_venta.Location = New System.Drawing.Point(159, 11)
        Me.rdb_venta.Name = "rdb_venta"
        Me.rdb_venta.Size = New System.Drawing.Size(58, 17)
        Me.rdb_venta.TabIndex = 1
        Me.rdb_venta.TabStop = True
        Me.rdb_venta.Text = "Ventas"
        Me.rdb_venta.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdb_venta)
        Me.GroupBox3.Controls.Add(Me.rdb_compra)
        Me.GroupBox3.Location = New System.Drawing.Point(28, 68)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(243, 34)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'frm_movimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 505)
        Me.Controls.Add(Me.btn_imprimir)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frm_movimiento"
        Me.Text = "frm_movimiento"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ptc_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_salir As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ptc_logo As PictureBox
    Friend WithEvents date_fecha_hasta As DateTimePicker
    Friend WithEvents date_fecha_desde As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbo_tipo As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btn_imprimir As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rdb_venta As RadioButton
    Friend WithEvents rdb_compra As RadioButton
End Class
