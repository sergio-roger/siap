<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Combos
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
        Me.cryCombo = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'cryCombo
        '
        Me.cryCombo.ActiveViewIndex = -1
        Me.cryCombo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cryCombo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cryCombo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cryCombo.Location = New System.Drawing.Point(0, 0)
        Me.cryCombo.Name = "cryCombo"
        Me.cryCombo.Size = New System.Drawing.Size(800, 450)
        Me.cryCombo.TabIndex = 0
        Me.cryCombo.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Combos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cryCombo)
        Me.Name = "Combos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Combos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cryCombo As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
