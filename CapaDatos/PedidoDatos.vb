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

    Public Function procederDetalle(pedido As Pedido) As Boolean

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
            If (actualizaEstadoMesa(pedido.Id_mesa) = False) Then
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

    Public Function actualizaEstadoMesa(id As Integer) As Boolean

        Try
            actualizaEstadoMesa = False

            cmd = New SqlClient.SqlCommand("sp_insertar_detalles", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@id", id)
            cmd.ExecuteNonQuery()

            actualizaEstadoMesa = True
        Catch ex As Exception
            actualizaEstadoMesa = False
        End Try
    End Function
End Class
