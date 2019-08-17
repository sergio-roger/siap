Imports CapaDatos
Imports CapaEntidad

Public Class ComboNegocio
    Private comboDatos As ComboDatos

    Public Sub New()
        comboDatos = New ComboDatos
    End Sub

    Public Function getModalidades() As ArrayList
        Return comboDatos.getModalidades()
    End Function

    Public Function grabar(combo As Combo) As Boolean
        Return comboDatos.procesarDatos(combo)
    End Function
End Class
