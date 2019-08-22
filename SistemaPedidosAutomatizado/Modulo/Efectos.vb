Module Efectos

    Public Sub entradaDevanecer(ByRef formulario As Form)
        Dim efecto As Double

        For efecto = 0.0 To 1.0 Step 0.1
            formulario.Opacity = efecto
            formulario.Refresh()
            Threading.Thread.Sleep(100)
        Next
    End Sub

    Public Sub salidaDevanecer(ByRef formulario As Form)
        Dim efecto As Double

        For efecto = 1.1 To 0.0 Step 0.1
            formulario.Opacity = efecto
            formulario.Refresh()
            Threading.Thread.Sleep(100)
        Next
    End Sub

    Public Sub entradaDevanecer()
        Dim efecto As Double

        For efecto = 0.0 To 1.1 Step 0.1
            frm_login.Opacity = efecto
            frm_login.Refresh()
            Threading.Thread.Sleep(100)
        Next
    End Sub

    Public Sub salidaDevanecer()
        Dim efecto As Double

        For efecto = 1.1 To 0.0 Step 0.1
            frm_login.Opacity = efecto
            frm_login.Refresh()
            Threading.Thread.Sleep(100)
        Next
    End Sub
End Module
