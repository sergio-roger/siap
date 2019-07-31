Imports CapaEntidad
Imports CapaDatos

Public Class MesaNegocio
    Dim mesaDatos As MesaDatos

    Public Sub New()
        mesaDatos = New MesaDatos()
    End Sub

    Public Function crearMesa(mesa As Mesa) As Boolean
        Return mesaDatos.procesarMesa(mesa)
    End Function

    Public Function actualizarMesa(mesa As Mesa) As Boolean
        Return mesaDatos.procesarMesa(mesa)
    End Function

    Public Function getListaMesas() As List(Of Mesa)
        Return mesaDatos.getListaMesas()
    End Function

    Public Function eliminar(mesa As Mesa) As Boolean
        Return mesaDatos.eliminar(mesa)
    End Function
End Class
