Imports System.Data.SqlClient
Imports CapaEntidad

Public Class DatosConexion
    Public dr As SqlDataReader

    'Constructor
    Public Sub New(ByVal cadena As String, ByVal formatoFecha As String)
        str_cadenaconexion = cadena
        g_str_formatoFecha = formatoFecha

    End Sub

    Public Function VerificarConexion() As Boolean
        VerificarConexion = Conectar()
    End Function
End Class
