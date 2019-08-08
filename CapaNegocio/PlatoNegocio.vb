Imports CapaEntidad
Imports CapaDatos

Public Class PlatoNegocio
    Dim platoDatos As PlatoDatos
    Public Sub New()
        platoDatos = New PlatoDatos()

    End Sub
    Public Function crearPlato(plato As Plato) As Boolean
        Return platoDatos.ProcesarPlato(plato)
    End Function

    Public Function actualizarPlato(plato As Plato) As Boolean
        Return platoDatos.ProcesarPlato(plato)
    End Function

    Public Function getListaModalidad() As ArrayList
        '  Return platoDatos.getListaModalidad()
        Return platoDatos.getListaModalidad2()

    End Function
End Class
