<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ventas_reporte
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.fecha_ini = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_combos = New System.Windows.Forms.Button()
        Me.btn_platos = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(234, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Generador de Repotes"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.fecha_fin)
        Me.GroupBox1.Controls.Add(Me.fecha_ini)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(68, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(439, 98)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'fecha_fin
        '
        Me.fecha_fin.CustomFormat = "yyy/MM/dd"
        Me.fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fecha_fin.Location = New System.Drawing.Point(233, 56)
        Me.fecha_fin.Name = "fecha_fin"
        Me.fecha_fin.Size = New System.Drawing.Size(166, 20)
        Me.fecha_fin.TabIndex = 3
        '
        'fecha_ini
        '
        Me.fecha_ini.CustomFormat = "yyy/MM/dd"
        Me.fecha_ini.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fecha_ini.Location = New System.Drawing.Point(27, 56)
        Me.fecha_ini.Name = "fecha_ini"
        Me.fecha_ini.Size = New System.Drawing.Size(166, 20)
        Me.fecha_ini.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(230, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Hasta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Desde"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_combos)
        Me.GroupBox2.Controls.Add(Me.btn_platos)
        Me.GroupBox2.Location = New System.Drawing.Point(68, 225)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(449, 136)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'btn_combos
        '
        Me.btn_combos.Location = New System.Drawing.Point(233, 27)
        Me.btn_combos.Name = "btn_combos"
        Me.btn_combos.Size = New System.Drawing.Size(166, 92)
        Me.btn_combos.TabIndex = 1
        Me.btn_combos.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Reportes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Combos"
        Me.btn_combos.UseVisualStyleBackColor = True
        '
        'btn_platos
        '
        Me.btn_platos.Location = New System.Drawing.Point(27, 26)
        Me.btn_platos.Name = "btn_platos"
        Me.btn_platos.Size = New System.Drawing.Size(166, 92)
        Me.btn_platos.TabIndex = 0
        Me.btn_platos.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Reportes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Platos"
        Me.btn_platos.UseVisualStyleBackColor = True
        '
        'frm_ventas_reporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 396)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_ventas_reporte"
        Me.Text = "frm_ventas_reporte"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents fecha_fin As DateTimePicker
    Friend WithEvents fecha_ini As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btn_combos As Button
    Friend WithEvents btn_platos As Button
End Class
