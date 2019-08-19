Imports CapaEntidad
Imports CapaNegocio

Public Class frm_buscar_pedido

    Private pedidoNegocio As New PedidoNegocio
    Private pedido As New Pedido
    Private titulo As String = "Factura"

    Private Function cargarPedidos(estado As Integer) As Boolean
        Try
            cargarPedidos = False
            Dim lista As New List(Of Pedido)

            lista = pedidoNegocio.getPedidosVista(3)

            If (lista IsNot Nothing) Then
                For Each item In lista
                    dgv_pedidos.Rows.Add(item.Id, item.Mesa, item.EstadoPedido, item.Estado, item.Id_mesa)
                Next
            End If
            cargarPedidos = True
        Catch ex As Exception
            cargarPedidos = False
        End Try
    End Function

    Private Sub frm_buscar_pedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            If (cargarPedidos(3) = False) Then
                mensaje(titulo, "Hubo un error al cagar los pedidos", "danger")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_pedidos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_pedidos.CellDoubleClick
        Try
            If e.RowIndex > -1 Then
                auxPedido.Id = dgv_pedidos.Rows(e.RowIndex).Cells(0).Value
                pedido.Mesa = dgv_pedidos.Rows(e.RowIndex).Cells(1).Value
                pedido.EstadoPedido = dgv_pedidos.Rows(e.RowIndex).Cells(2).Value
                pedido.Estado = dgv_pedidos.Rows(e.RowIndex).Cells(3).Value
                pedido.Id_mesa = dgv_pedidos.Rows(e.RowIndex).Cells(4).Value
                Me.Close()
            End If
        Catch ex As exception

        End Try
    End Sub
End Class