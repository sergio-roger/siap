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

    Public Function getEstadoPedidos() As ArrayList
        Return pedidoDatos.getEstadoPedidos()
    End Function

    Public Function numero() As Integer
        Return pedidoDatos.numero()
    End Function

    Public Function getListaDetallePedidos(id As Integer) As List(Of DetallePedido)
        Return pedidoDatos.getListaDetallePedidos(id)
    End Function

    Public Function getPlatos() As List(Of Plato)
        Dim platoDatos As New PlatoDatos

        Return platoDatos.getplatos("", "codigo")
    End Function

    Public Function getCombos() As List(Of Combo)
        Dim comboDatos As New ComboDatos
        Return comboDatos.getCombos()
    End Function

    Public Function calcularDescuento(detalleComida As DetallePedido) As DetallePedido
        If (detalleComida.Descuento = True) Then
            Dim descuento As Double
            descuento = (detalleComida.PrecioUnitario * detalleComida.Porcentaje) / 100
            detalleComida.Subtotal = detalleComida.PrecioUnitario - descuento
        Else
            detalleComida.Subtotal = detalleComida.PrecioUnitario
        End If
        Return detalleComida
    End Function

    Public Function getPedidosVista(estado As Integer) As List(Of Pedido)
        Return pedidoDatos.getPedidosVista(estado)
    End Function

    Public Function getPedidos() As List(Of Pedido)
        Return pedidoDatos.getPedidos()
    End Function

    Public Function grabar(pedido As Pedido, estadoMesa As String) As Boolean
        Return pedidoDatos.procederDetalle(pedido, estadoMesa)
    End Function

    Public Function actualizarPedido(id As Integer, opcion As Integer) As Boolean
        Return pedidoDatos.actualizarPedido(id, opcion)
    End Function

    Public Function getDetallePedido(id As Integer) As ArrayList
        Return pedidoDatos.getDetallePedido(id)
    End Function
End Class
