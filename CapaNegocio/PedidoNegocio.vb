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

    Public Function numero() As Integer
        Return pedidoDatos.numero()
    End Function

    Public Function getPlatos() As List(Of Plato)
        Dim platoDatos As New PlatoDatos

        Return platoDatos.getplatos("", "codigo")
    End Function

    Public Function getCombos() As List(Of Combo)
        Dim comboDatos As New ComboDatos
        Return comboDatos.getCombos()
    End Function
End Class
