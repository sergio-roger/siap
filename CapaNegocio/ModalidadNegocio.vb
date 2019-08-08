Imports CapaEntidad
Imports CapaDatos

Public Class ModalidadNegocio

    Private modalidadDatos As ModalidadDatos

    Public Sub New()
        modalidadDatos = New ModalidadDatos()
    End Sub

    Public Function getListaModalidad() As List(Of Modalidad)
        Return modalidadDatos.getListaModalidad()
    End Function

    Public Function guardar(nuevo As Modalidad) As Boolean
        Return modalidadDatos.guardar(nuevo)
    End Function

    Public Function Eliminar(modalidad As Modalidad) As Boolean
        Return modalidadDatos.eliminar(modalidad)
    End Function
End Class
