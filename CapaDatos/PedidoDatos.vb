Imports CapaDatos

Public Class PedidoDatos
    Public Function getListaMesas() As ArrayList
        Dim sql = "select mesa_id,mesa_nombre from mesa where mesa_estado='A' order by 2"
        Dim lista As New ArrayList()

        lista = CargarComboDesdeSql(sql)
        Return lista
    End Function

    Public Function geListaPedidos() As ArrayList
        Dim sql = "select ep_id,ep_descripcion from Estados_Pedidos where ep_estado='A' order by 2"
        Dim lista As New ArrayList()

        lista = CargarComboDesdeSql(sql)
        Return lista
    End Function

End Class
