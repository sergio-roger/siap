Imports CapaEntidad
Imports CapaDatos

Public Class ClienteNegocio

    Private clientedatos As ClienteDatos

    Public Sub New()
        clientedatos = New ClienteDatos
    End Sub

    Public Function grabar(cliente As Cliente) As Boolean
        Return clientedatos.procesarDatos(cliente)
    End Function
End Class
