<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_principal
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lbl_hora = New System.Windows.Forms.ToolStripLabel()
        Me.lbl_fecha = New System.Windows.Forms.ToolStripLabel()
        Me.lbl_usuario_estado = New System.Windows.Forms.ToolStripLabel()
        Me.MenuPpal = New System.Windows.Forms.MenuStrip()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_usuario = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_perfil = New System.Windows.Forms.Label()
        Me.pb_foto = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pb_foto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbl_hora, Me.lbl_fecha, Me.lbl_usuario_estado})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 502)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(1311, 25)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "barra_info"
        '
        'lbl_hora
        '
        Me.lbl_hora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_hora.Name = "lbl_hora"
        Me.lbl_hora.Size = New System.Drawing.Size(38, 22)
        Me.lbl_hora.Text = "Hora"
        '
        'lbl_fecha
        '
        Me.lbl_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(80, 22)
        Me.lbl_fecha.Text = "aki va fecha"
        '
        'lbl_usuario_estado
        '
        Me.lbl_usuario_estado.Name = "lbl_usuario_estado"
        Me.lbl_usuario_estado.Size = New System.Drawing.Size(88, 22)
        Me.lbl_usuario_estado.Text = "ToolStripLabel1"
        '
        'MenuPpal
        '
        Me.MenuPpal.Location = New System.Drawing.Point(0, 0)
        Me.MenuPpal.Name = "MenuPpal"
        Me.MenuPpal.Size = New System.Drawing.Size(1311, 24)
        Me.MenuPpal.TabIndex = 14
        Me.MenuPpal.Text = "MenuStrip1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lbl_usuario)
        Me.Panel2.Location = New System.Drawing.Point(12, 79)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(184, 35)
        Me.Panel2.TabIndex = 17
        '
        'lbl_usuario
        '
        Me.lbl_usuario.AutoSize = True
        Me.lbl_usuario.BackColor = System.Drawing.Color.Transparent
        Me.lbl_usuario.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_usuario.ForeColor = System.Drawing.Color.White
        Me.lbl_usuario.Location = New System.Drawing.Point(10, 10)
        Me.lbl_usuario.Name = "lbl_usuario"
        Me.lbl_usuario.Size = New System.Drawing.Size(94, 15)
        Me.lbl_usuario.TabIndex = 7
        Me.lbl_usuario.Text = "Pepe el Grillo"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.lbl_perfil)
        Me.Panel1.Location = New System.Drawing.Point(12, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(184, 33)
        Me.Panel1.TabIndex = 16
        '
        'lbl_perfil
        '
        Me.lbl_perfil.AutoSize = True
        Me.lbl_perfil.BackColor = System.Drawing.Color.Transparent
        Me.lbl_perfil.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_perfil.ForeColor = System.Drawing.Color.White
        Me.lbl_perfil.Location = New System.Drawing.Point(3, 5)
        Me.lbl_perfil.Name = "lbl_perfil"
        Me.lbl_perfil.Size = New System.Drawing.Size(169, 21)
        Me.lbl_perfil.TabIndex = 5
        Me.lbl_perfil.Text = "Gerente Comercial"
        '
        'pb_foto
        '
        Me.pb_foto.Location = New System.Drawing.Point(1197, 40)
        Me.pb_foto.Name = "pb_foto"
        Me.pb_foto.Size = New System.Drawing.Size(106, 92)
        Me.pb_foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_foto.TabIndex = 18
        Me.pb_foto.TabStop = False
        '
        'frm_principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1311, 527)
        Me.Controls.Add(Me.pb_foto)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuPpal)
        Me.IsMdiContainer = True
        Me.Name = "frm_principal"
        Me.Text = "frm_principal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pb_foto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents lbl_hora As ToolStripLabel
    Friend WithEvents lbl_fecha As ToolStripLabel
    Friend WithEvents MenuPpal As MenuStrip
    Friend WithEvents pb_foto As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lbl_usuario As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbl_perfil As Label
    Friend WithEvents lbl_usuario_estado As ToolStripLabel
End Class
