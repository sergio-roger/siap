Public Class frm_ventas_reporte

    Private Sub btn_platos_Click(sender As Object, e As EventArgs) Handles btn_platos.Click
        Dim frm As New Platos
        frm.fecha_inicio = fecha_ini.Value
        frm.fecha_fin = fecha_fin.Value

        frm.ShowDialog()
    End Sub

    Private Sub btn_combos_Click(sender As Object, e As EventArgs) Handles btn_combos.Click
        Dim frm As New Combos
        frm.fecha_inicio = fecha_ini.Value
        frm.fecha_fin = fecha_fin.Value

        frm.ShowDialog()
    End Sub
End Class