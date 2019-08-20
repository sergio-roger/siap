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

    Public Function getClientes(texto As String) As List(Of Cliente)
        Return clientedatos.getClients(texto)
    End Function

    Public Function getCliente(cedula As String) As Cliente
        Return clientedatos.getCliente(cedula)
    End Function

End Class
