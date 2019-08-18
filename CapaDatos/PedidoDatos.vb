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

    Public Function numero() As Integer
        numero = 0
        Try
            If (Conectar() = False) Then
                Exit Function
            End If

            Dim cadenaslq As String = "select count(*) as numero from Pedidos"

            dr = ExecuteReader(cadenaslq)

            If (dr.HasRows) Then
                While (dr.Read)
                    numero = Integer.Parse(dr("numero")) + 1
                End While
            End If
        Catch ex As Exception
            numero = 0
        End Try
    End Function
End Class
