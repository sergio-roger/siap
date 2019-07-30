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
End Class
