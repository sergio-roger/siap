Imports CapaEntidad
Imports CapaNegocio

Public Class frm_lista_pedido
    Private titulo As String = "Lista Pedidos"
    Private pedidoNegocio As New PedidoNegocio
    Private pedido As New Pedido

    Private Function cargaComboEstados() As Boolean
        Try
            cargaComboEstados = False
            Dim lista As New ArrayList
            lista = pedidoNegocio.getEstadoPedidos()

            With cmb_estado
                .DropDownStyle = ComboBoxStyle.DropDownList
                '.AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .DataSource = lista
                .ValueMember = "Codigo"
                .DisplayMember = "Texto"
            End With

            cargaComboEstados = True
        Catch ex As Exception
            cargaComboEstados = False
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

    Private Sub frm_lista_pedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pedido.Id = 0

        If (cargaComboEstados() = False) Then
            mensaje(titulo, "No se pudo cargar estados", "danger")
        End If

        'Cargar los pedidos
        If (cargarPedidos() = False) Then
            mensaje(titulo, "No se pudo cargar los pedidos", "danger")
        End If
    End Sub

    Private Sub btn_despachar_Click(sender As Object, e As EventArgs) Handles btn_despachar.Click
        Try

            If (Pedido.Id <> 0) Then
                'If (ActualizarPedido(id_pedido, cmb_estado.SelectedValue) = False) Then
                '    mensaje("Hups", "Algo salió mal al actualizar el pedido ", "alert")
                'Else
                '    mensaje("Exito", "El pedido ha sido despachado", "info")
                '    VolverCargarPedidos()
                'End If
            Else
                mensaje("Lista de Pedidos", "Seleccione un pedido para atender", "info")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

                txt_codigo.Text = pedido.Id
                Dim lista As New ArrayList
                lista = pedidoNegocio.getDetallePedido(pedido.Id)
                list_detalle_pedido.Items.Clear()

                For Each item In lista
                    list_detalle_pedido.Items.Add(item)
                Next

                'Ejecutar el procedimiento almacenado
                'If (ObtenerDetallePedido(id_pedido) = False) Then
                '    mensaje("Hups", "Algo salio mal al cargar los detales ", "danger")
                'End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class