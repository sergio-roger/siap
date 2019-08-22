Imports CapaEntidad
Imports CapaDatos

Public Class AuditoriaIngresoNegocio
    Public auditoria As New AuditoriaIngresoDatos

    Public Function getDatos() As List(Of AuditoriaIngreso)
        Return auditoria.getDatos()
    End Function
End Class
