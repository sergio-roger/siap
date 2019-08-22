<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Platos
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
        Me.cryPlatos = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'cryPlatos
        '
        Me.cryPlatos.ActiveViewIndex = -1
        Me.cryPlatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cryPlatos.Cursor = System.Windows.Forms.Cursors.Default
        Me.cryPlatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cryPlatos.Location = New System.Drawing.Point(0, 0)
        Me.cryPlatos.Name = "cryPlatos"
        Me.cryPlatos.Size = New System.Drawing.Size(701, 446)
        Me.cryPlatos.TabIndex = 0
        Me.cryPlatos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Platos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 446)
        Me.Controls.Add(Me.cryPlatos)
        Me.Name = "Platos"
        Me.Text = "Platos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cryPlatos As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
