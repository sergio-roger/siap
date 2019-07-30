Public Class frm_principal
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbl_hora.Text = Date.Now.ToShortTimeString()
    End Sub

    Private Sub frm_principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            'lbl_usuario.Text = g_str_nombres
            'CargarMenus(g_perfil_id)
            'lbl_perfil.Text = Obtener_perfil(g_perfil_id)
            'lbl_usuario.Text = g_str_nombres
            lbl_fecha.Text = DateTime.Now.ToShortDateString()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class