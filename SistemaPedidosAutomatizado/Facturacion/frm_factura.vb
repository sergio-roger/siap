Imports CapaEntidad
Imports CapaNegocio

Public Class frm_factura
    Private pedidoNegocio As New PedidoNegocio
    Private pedido As New Pedido
    Private titulo As String = "Factura"
    Private descuento, subtotal, total As Double

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Try
            Dim frm As New frm_buscar_pedido
            frm.ShowDialog()
            pedido = auxPedido
            'mensaje(titulo, pedido.Id, "info")
            'Cargar detalle pedidos
            pedido.Detalles = New List(Of DetallePedido)
            pedido.Detalles = pedidoNegocio.getListaDetallePedidos(pedido.Id)
            dgv_pedido.Rows.Clear()
            descuento = 0
            subtotal = 0
            total = 0

            For Each item In pedido.Detalles
                descuento += item.PrecioUnitario * item.Porcentaje / 100
                subtotal += item.PrecioUnitario * item.Cantidad
                total += item.Subtotal * item.Cantidad
                dgv_pedido.Rows.Add(item.Id, item.Id_Pedido, item.Id_tipoComida, item.Id_Comida, item.Nombre, item.Cantidad, item.PrecioUnitario, item.Descuento, item.Porcentaje, item.Subtotal, item.Total, item.Estado)
            Next

            txt_descuento.Text = descuento
            txt_subtotal.Text = subtotal
            txt_total.Text = total
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txt_usuario.Text = usuarioSeccion.Nombres
        Catch ex As Exception

        End Try
    End Sub
End Class