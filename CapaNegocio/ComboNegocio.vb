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

    Public Function getCombos(buscar As String, opcion As String) As List(Of Combo)
        Return comboDatos.getCombos(buscar, opcion)
    End Function

    Public Function getCombo(codigo As String) As Combo

        Return comboDatos.getCombo(codigo)

    End Function

    Public Function eliminar(combo As Object) As Boolean
        Return comboDatos.eliminar(combo)
    End Function
End Class
