Imports CapaEntidad
Imports CapaNegocio

Public Class frm_servir_pedido
    Private titulo As String = "Estado Pedidos"
    Private pedidoNegocio As New PedidoNegocio
    Private pedido As New Pedido

    Private Function consultarEstadoPedidos() As Boolean
        Try
            consultarEstadoPedidos = False
            Dim lista As New List(Of Pedido)

            lista = pedidoNegocio.getPedidosVista("2")
            dgv_pedidos.Rows.Clear()

            For Each item In lista
                dgv_pedidos.Rows.Add(item.Id, item.Mesa, item.EstadoPedido, item.Estado)
            Next
            consultarEstadoPedidos = True
        Catch ex As Exception
            consultarEstadoPedidos = False
        End Try
    End Function

    Private Sub frm_servir_pedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (consultarEstadoPedidos() = False) Then
            'mensaje(titulo, "No se pudo cargar los pedidos", "danger")
        End If
    End Sub

    Private Sub dgv_pedidos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_pedidos.CellDoubleClick
        Try
            If e.RowIndex > -1 Then
                pedido.Id = dgv_pedidos.Rows(e.RowIndex).Cells(0).Value
                pedido.Mesa = dgv_pedidos.Rows(e.RowIndex).Cells(1).Value
                pedido.EstadoPedido = dgv_pedidos.Rows(e.RowIndex).Cells(2).Value
                pedido.Estado = dgv_pedidos.Rows(e.RowIndex).Cells(3).Value
                pedido.Observacion = dgv_pedidos.Rows(e.RowIndex).Cells(4).Value
                pedido.Id_mesa = dgv_pedidos.Rows(e.RowIndex).Cells(5).Value
                pedido.Id_estadoPedido = dgv_pedidos.Rows(e.RowIndex).Cells(6).Value

                txt_id.Text = pedido.Id
                txt_mesa.Text = pedido.Mesa

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function actualizarPedido() As Boolean
        Try
            actualizarPedido = False
            actualizarPedido = pedidoNegocio.actualizarPedido(pedido.Id, "3")

        Catch ex As Exception
            actualizarPedido = False
        End Try
    End Function

    Private Function cargarPedidos() As Boolean
        Try
            cargarPedidos = False
            Dim lista As New List(Of Pedido)
            lista = pedidoNegocio.getPedidos()
            dgv_pedidos.Rows.Clear()

            If (lista IsNot Nothing) Then
                For Each item In lista
                    dgv_pedidos.Rows.Add(item.Id, item.Mesa, item.EstadoPedido, item.Estado, item.Observacion, item.Id_mesa, item.Id_estadoPedido)
                Next
            End If

            cargarPedidos = True
        Catch ex As Exception
            cargarPedidos = False
        End Try
    End Function

    Private Sub btn_servir_Click(sender As Object, e As EventArgs) Handles btn_servir.Click
        Try
            If (pedido.Id <> 0) Then
                If (actualizarPedido() = False) Then
                    mensaje("Hups", "Algo salió mal al actualizar el pedido ", "alert")
                Else
                    txt_id.Text = ""
                    txt_mesa.Text = ""
                    mensaje("Exito", "El pedido ha sido servido", "info")

                    If (consultarEstadoPedidos() = False) Then
                        'mensaje(titulo, "No se pudo cargar los pedidos", "danger")
                    End If
                    pedido.Id = 0
                End If
            Else
                mensaje("Lista de Pedidos", "Seleccione un pedido para atender", "info")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class