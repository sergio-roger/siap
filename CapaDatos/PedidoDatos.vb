Imports CapaDatos
Imports CapaEntidad

Public Class PedidoDatos
    Private auxpedido As New Pedido

    Public Function getListaMesas() As ArrayList
        Dim sql = "select mesa_id,mesa_nombre from mesa where mesa_estado='A' or mesa_estado='D' order by 2"
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

    Public Function getEstadoPedidos() As ArrayList
        Dim sql = "select ep_id, ep_descripcion from Estados_Pedidos where ep_estado='A' order by 2"
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

    Public Function grabar(pedido As Pedido) As Boolean

        Try
            grabar = False

            If (Conectar() = False) Then
                Exit Function
            End If

            'Grabando el pedido
            cmd = New SqlClient.SqlCommand("sp_inserta_Pedido", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", pedido.Id)
            cmd.Parameters.AddWithValue("@per_estado", pedido.Estado)
            cmd.Parameters.AddWithValue("@mesa_id", pedido.Id_mesa)
            cmd.Parameters.AddWithValue("@usu_id", pedido.Id_usuario)
            cmd.Parameters.AddWithValue("@ep_id", pedido.Id_estadoPedido)
            cmd.Parameters.AddWithValue("@per_observacion", pedido.Observacion)

            cmd.ExecuteNonQuery()
            grabar = True

        Catch ex As Exception
            grabar = False
        Finally
            'Desconectar()
        End Try
    End Function

    Public Function getDetallePedido(id As Integer) As ArrayList
        Try
            Dim lista As New ArrayList

            If (Conectar() = False) Then
                Exit Function
            End If

            dr = ExecuteReader("sp_obtener_detalle_Pedido", id)

            If dr.HasRows Then
                While dr.Read
                    Dim coleccion() As String = dr("items").Split(",")

                    For i = 0 To coleccion.Length - 1

                        If (coleccion(i) <> "") Then
                            lista.Add("* " & coleccion(i))
                        End If
                    Next
                End While
                Return lista
            End If

        Catch ex As Exception
            getDetallePedido = Nothing
        End Try
    End Function

    Public Function getPedidos() As List(Of Pedido)
        Try
            Dim lista As New List(Of Pedido)
            If (Conectar() = False) Then
                Exit Function
            End If

            Dim cadenasql As String = "select *,
(select m.mesa_nombre from Mesa m where m.mesa_id =p.mesa_id) as m_mesa, 
(select ep.ep_descripcion from Estados_Pedidos ep where p.ep_id = ep.ep_id) as ped_estado
from pedidos p order by per_id asc"

            dr = ExecuteReader(cadenasql)

            If (dr.HasRows) Then
                While (dr.Read)
                    Dim p As New Pedido

                    p.Id = dr("per_id")
                    p.Mesa = dr("m_mesa")
                    p.EstadoPedido = dr("ped_estado")
                    p.Estado = dr("per_estado")
                    p.Observacion = dr("per_observacion")
                    p.Id_mesa = dr("mesa_id")
                    p.Id_estadoPedido = dr("ep_id")
                    lista.Add(p)
                End While
                Return lista
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function procederDetalle(pedido As Pedido, estadoMesa As String) As Boolean

        Try
            procederDetalle = False
            'auxpedido = pedido

            'Grabar cabecera pedido
            If (grabar(pedido) = False) Then
                Exit Function
            End If

            'If (Conectar() = False) Then
            '    Exit Function
            'End If

            'Grabar los detalles del pedido
            For Each item In pedido.Detalles
                If (grabarDetalle(item) = False) Then
                    Exit Function
                End If
            Next

            'Actulizar el estado de las mesas
            If (actualizaEstadoMesa(pedido.Id_mesa, estadoMesa) = False) Then
                Exit Function
            End If

            procederDetalle = True
        Catch ex As Exception
            procederDetalle = False
        End Try
    End Function

    Public Function grabarDetalle(detalle As DetallePedido) As Boolean
        Try
            grabarDetalle = False

            'Grabando el pedido
            cmd = New SqlClient.SqlCommand("sp_insertar_detalles", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@id", detalle.Id)
            cmd.Parameters.AddWithValue("@tc_id", detalle.Id_tipoComida)
            cmd.Parameters.AddWithValue("@per_id", detalle.Id_Pedido)
            cmd.Parameters.AddWithValue("@ep_estado", detalle.Estado)
            cmd.Parameters.AddWithValue("@detp_cantidad", detalle.Cantidad)
            cmd.Parameters.AddWithValue("@detp_precioUnitario", detalle.PrecioUnitario)
            cmd.Parameters.AddWithValue("@detp_descuento", detalle.Descuento)
            cmd.Parameters.AddWithValue("@detp_porcentaje", detalle.Porcentaje)
            cmd.Parameters.AddWithValue("@detp_subtotal", detalle.Subtotal)
            cmd.Parameters.AddWithValue("@detp_total", detalle.Total)
            cmd.Parameters.AddWithValue("@id_comida", detalle.Id_Comida)
            cmd.Parameters.AddWithValue("@detp_nombre", detalle.Nombre)

            cmd.ExecuteNonQuery()

            grabarDetalle = True
        Catch ex As Exception
            grabarDetalle = False
        End Try
    End Function

    Public Function actualizaEstadoMesa(id As Integer, estadoMesa As String) As Boolean

        Try
            actualizaEstadoMesa = False

            cmd = New SqlClient.SqlCommand("sp_actualiza_estado_mesa", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@id", id)
            cmd.Parameters.AddWithValue("@estado", estadoMesa)
            cmd.ExecuteNonQuery()

            actualizaEstadoMesa = True
        Catch ex As Exception
            actualizaEstadoMesa = False
        End Try
    End Function
End Class
