Imports CapaEntidad
Imports CapaDatos

Public Class UsuarioNegocio

    Private usuarioDatos As UsuarioDatos

    Public Sub New()
        usuarioDatos = New UsuarioDatos()
    End Sub

    Public Function VerificarUsuario(usuario As String, clave As String) As List(Of Usuario)
        Try
            VerificarUsuario = usuarioDatos.VerificarUsuario(usuario, clave)

        Catch ex As Exception
            MsgBox(ex.Message)
            VerificarUsuario = Nothing
        End Try
    End Function

    Public Function getListaPerfiles() As ArrayList
        Return usuarioDatos.getListaPerfiles()
    End Function

    Public Function getUsuarios(buscar As String, opcion As String) As List(Of Usuario)
        Return usuarioDatos.getUsuarios(buscar, opcion)
    End Function

    Public Function getUsuario(cedula As String) As Usuario
        Return usuarioDatos.getUsuario(cedula)
    End Function

    Public Function grabar(usuario As Usuario) As Boolean
        Return usuarioDatos.procesarDatos(usuario)
    End Function

    Public Function eliminar(usuario As Usuario) As Boolean
        Return usuarioDatos.eliminar(usuario)
    End Function
End Class
