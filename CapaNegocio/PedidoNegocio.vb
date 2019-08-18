Imports CapaDatos
Imports CapaEntidad

Public Class PedidoNegocio
    Private pedidoDatos As PedidoDatos

    Public Sub New()
        pedidoDatos = New PedidoDatos
    End Sub

    Public Function getLista() As ArrayList
        Return pedidoDatos.getListaMesas
    End Function

    Public Function getListaPedidos() As ArrayList
        Return pedidoDatos.geListaPedidos()
    End Function
End Class
