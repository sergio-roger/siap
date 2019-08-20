Imports CapaEntidad
Imports CapaDatos

Public Class FacturaNegocio
    Private factuaDatos As FacturaDatos

    Public Sub New()
        factuaDatos = New FacturaDatos
    End Sub

    Public Function grabar(factura As Factura) As Boolean
        Return factuaDatos.grabar(factura)
    End Function

End Class
