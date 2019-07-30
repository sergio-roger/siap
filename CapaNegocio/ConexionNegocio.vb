Imports CapaEntidad
Imports CapaDatos

Public Class ConexionNegocio

    Public Function VerificarConexion(cadenaConexion As String, formatoFecha As String) As Boolean
        Try
            Dim conexion As New DatosConexion(cadenaConexion, formatoFecha)

            VerificarConexion = conexion.VerificarConexion()

        Catch ex As Exception
            VerificarConexion = False
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function getMenuPrincipal(id_Perfil As Integer) As List(Of Menu)
        Dim datoConexion As New DatosConexion()
        getMenuPrincipal = datoConexion.getMenuPrincipal(id_Perfil)
    End Function
End Class
