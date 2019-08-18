Imports CapaEntidad
Imports CapaDatos

Public Class PlatoNegocio
    Dim platoDatos As PlatoDatos

    Public Sub New()
        platoDatos = New PlatoDatos()

    End Sub
    Public Function grabar(plato As Plato) As Boolean
        Return platoDatos.procesarDatos(plato)
    End Function

    Public Function getListaModalidad() As ArrayList
        '  Return platoDatos.getListaModalidad()
        Return platoDatos.getListaModalidad2()
    End Function

    Public Function getPlatos(buscar As String, opcion As String) As List(Of Plato)
        Return platoDatos.getplatos(buscar, opcion)
    End Function

    Public Function eliminar(plato As Plato) As Boolean
        Return platoDatos.eliminar(plato)
    End Function

    Public Function getPlato(codigo As String) As Plato
        Return platoDatos.getPlato(codigo)
    End Function
End Class
