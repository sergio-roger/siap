Imports CapaEntidad
Imports CapaDatos

Public Class PerfilNegocio

    Private perfilDatos As PerfilDatos

    Public Sub New()
        perfilDatos = New PerfilDatos()
    End Sub

    Public Function getListaPerfil() As List(Of Perfil)
        Return perfilDatos.getListaPerfil()
    End Function

    Public Function guardar(perfil As Perfil) As Boolean
        Return perfilDatos.procesarDatos(perfil)
    End Function

    Public Function Eliminar(perfil As Perfil) As Boolean
        Return perfilDatos.eliminar(perfil)
    End Function
End Class
