<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_ventas_platos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.date_fecha_hasta = New System.Windows.Forms.DateTimePicker()
        Me.date_fecha_desde = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_tipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ptc_logo = New System.Windows.Forms.PictureBox()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ptc_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CrystalReportViewer1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 191)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(776, 301)
        Me.GroupBox2.TabIndex = 8
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ptc_logo)
        Me.GroupBox1.Controls.Add(Me.date_fecha_hasta)
        Me.GroupBox1.Controls.Add(Me.date_fecha_desde)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo_tipo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 73)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 112)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'date_fecha_hasta
        '
        Me.date_fecha_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_fecha_hasta.Location = New System.Drawing.Point(482, 49)
        Me.date_fecha_hasta.Name = "date_fecha_hasta"
        Me.date_fecha_hasta.Size = New System.Drawing.Size(103, 20)
        Me.date_fecha_hasta.TabIndex = 5
        '
        'date_fecha_desde
        '
        Me.date_fecha_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_fecha_desde.Location = New System.Drawing.Point(307, 50)
        Me.date_fecha_desde.Name = "date_fecha_desde"
        Me.date_fecha_desde.Size = New System.Drawing.Size(103, 20)
        Me.date_fecha_desde.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(434, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Hasta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(250, 56)
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
        Me.cbo_tipo.Location = New System.Drawing.Point(42, 53)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(182, 21)
        Me.cbo_tipo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tipo"
        '
        'ptc_logo
        '
        Me.ptc_logo.Location = New System.Drawing.Point(631, 12)
        Me.ptc_logo.Name = "ptc_logo"
        Me.ptc_logo.Size = New System.Drawing.Size(133, 92)
        Me.ptc_logo.TabIndex = 10
        Me.ptc_logo.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.Location = New System.Drawing.Point(146, 12)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(111, 51)
        Me.btn_salir.TabIndex = 13
        Me.btn_salir.Text = "X"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Location = New System.Drawing.Point(16, 12)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(111, 51)
        Me.btn_imprimir.TabIndex = 12
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(355, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 25)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "REPORTES"
        '
        'frm_ventas_platos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 473)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.btn_imprimir)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frm_ventas_platos"
        Me.Text = "frm_ventas_platos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ptc_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents date_fecha_hasta As DateTimePicker
    Friend WithEvents date_fecha_desde As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbo_tipo As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ptc_logo As PictureBox
    Friend WithEvents btn_salir As Button
    Friend WithEvents btn_imprimir As Button
    Friend WithEvents Label5 As Label
End Class
