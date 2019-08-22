Imports CapaEntidad
Imports CapaNegocio

Public Class frm_eliminar_pedidos

    Private pedidosOrdenados As Integer = 1
    Private pedido As New Pedido
    Private pedidoNegocio As New PedidoNegocio
    Private titulo As String = "ELiminar Pedido"
    Private existePedido As Boolean
    Private idPedido As Integer

    Private Sub llenarTablaPedido(objeto As Pedido)

        objeto.Detalles = New List(Of DetallePedido)
        objeto.Detalles = pedidoNegocio.getListaDetallePedidos(objeto.Id)
        dgv_pedido.Rows.Clear()

        For Each item In objeto.Detalles

            dgv_pedido.Rows.Add(item.Id, item.Id_Pedido, item.Id_tipoComida, item.Id_Comida, item.Nombre, item.Cantidad, item.PrecioUnitario, item.Descuento, item.Porcentaje, item.Subtotal, item.Total, item.Estado)
        Next

    End Sub

    Private Sub recuperarPedido(numero As String)
        Dim buscar As New Pedido
        Try
            ' recuperarPedido = False
            buscar = pedidoNegocio.getPedidoxNumero(numero, pedidosOrdenados)
            pedido = buscar

            If (buscar Is Nothing) Then
                'dgv_pedido.Rows.Clear()
                existePedido = False
                '    recuperarPedido = False
            Else
                existePedido = True
                '   recuperarPedido = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function eliminarPedido() As Boolean
        Try
            eliminarPedido = False

            If (existePedido) Then
                pedido.Id = idPedido
                eliminarPedido = pedidoNegocio.eliminar(pedido)
                auxPedido.Id = 0
                idPedido = 0
                txt_num_ped.Text = 0
            Else
                eliminarPedido = False
            End If
        Catch ex As Exception
            eliminarPedido = True
        End Try
    End Function

    Private Sub frm_eliminar_pedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Try
            Dim frm As New frm_buscar_pedido
            frm.estadoPedido = pedidosOrdenados   'Pedidos servidos
            frm.ShowDialog()
            pedido = auxPedido
            idPedido = auxPedido.Id

            If (pedido.Id > 0) Then
                existePedido = True
                txt_num_ped.Text = pedido.Id
                llenarTablaPedido(auxPedido)
            Else
                dgv_pedido.Rows.Clear()
                existePedido = False
            End If

            auxPedido.Id = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_num_ped.KeyPress
        Try
            If (Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9) Then

                recuperarPedido(txt_num_ped.Text)

                If (existePedido) Then
                    llenarTablaPedido(pedido)
                    idPedido = pedido.Id
                Else
                    dgv_pedido.Rows.Clear()
                    txt_num_ped.Text = ""
                    txt_num_ped.Focus()
                    mensaje(titulo, "El número de pedido no existe", "danger")
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Try
            If (txt_num_ped.Text = String.Empty) Then
                mensaje(titulo, "Digite un codigo para eliminar el Pedido", "info")
                Exit Sub
            End If

            If (PreguntaRespuesta("Desea eliminar el Pedido " & txt_num_ped.Text & " ? ", "Confirmar") = MsgBoxResult.No) Then
                Exit Sub
            End If

            If (eliminarPedido() = False) Then
                mensaje(titulo, "Hubo un error al eliminar el Pedido", "danger")
            Else
                dgv_pedido.Rows.Clear()
                txt_num_ped.Text = ""
                mensaje(titulo, "Pedido eliminado :(", "info")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class