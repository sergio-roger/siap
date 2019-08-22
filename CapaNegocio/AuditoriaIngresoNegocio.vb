Imports CapaEntidad
Imports CapaDatos

Public Class AuditoriaIngresoNegocio
    Public auditoria As New AuditoriaIngresoDatos

    Public Function getDatos() As List(Of AuditoriaIngreso)
        Return auditoria.getDatos()
    End Function

    Public Function guardar(objeto As AuditoriaIngreso) As Boolean
        Return auditoria.guardar(objeto)
    End Function
End Class
