Imports CapaEntidad

Public Class FacturaDatos

    Public Function grabar(factura As Factura) As Boolean
        Try
            grabar = False

            If (Conectar() = False) Then
                Exit Function
            End If

            cmd = New SqlClient.SqlCommand("sp_inserta_factura", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@id", factura.Id)
            cmd.Parameters.AddWithValue("@usu_id", factura.Id_usuario)
            cmd.Parameters.AddWithValue("@cli_id", factura.Id_cliente)
            cmd.Parameters.AddWithValue("@ped_id", factura.Id_pedido)
            cmd.Parameters.AddWithValue("@fac_total", factura.Total)
            cmd.Parameters.AddWithValue("@fac_fecha", factura.Fecha.ToShortDateString)
            cmd.Parameters.AddWithValue("@fac_hora", factura.Fecha.ToShortTimeString)
            cmd.Parameters.AddWithValue("@fac_subtotal", factura.Subtotal)
            cmd.Parameters.AddWithValue("@fac_descuento", factura.Descuento)
            cmd.Parameters.AddWithValue("@fac_estado", factura.Estado)

            cmd.ExecuteNonQuery()
            grabar = True
        Catch ex As Exception
            grabar = False
        End Try
    End Function
End Class
