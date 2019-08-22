Imports CapaEntidad
Imports CapaDatos

Public Class FacturaNegocio
    Private facturaDatos As FacturaDatos

    Public Sub New()
        facturaDatos = New FacturaDatos
    End Sub

    Public Function grabar(factura As Factura) As Boolean
        Return facturaDatos.grabar(factura)
    End Function

    Public Function getUltimaFactura() As Integer
        Return facturaDatos.getUltimaFactura()
    End Function
End Class
