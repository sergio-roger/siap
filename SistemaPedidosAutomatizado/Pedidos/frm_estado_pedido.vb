Imports CapaEntidad
Imports CapaNegocio

Public Class frm_estado_pedido
    Private titulo As String = "Estado Pedidos"
    Private pedidoNegocio As New PedidoNegocio
    Private pedido As New Pedido

    Private Function cargaComboEstados() As Boolean
        Try
            cargaComboEstados = False
            Dim lista As New ArrayList
            lista = PedidoNegocio.getEstadoPedidos()

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

    Private Function consultarEstadoPedidos() As Boolean
        Try
            consultarEstadoPedidos = False
            Dim lista As New List(Of Pedido)

            lista = pedidoNegocio.getPedidosVista(cmb_estado.SelectedValue.ToString)
            dgv_pedidos.Rows.Clear()

            For Each item In lista
                dgv_pedidos.Rows.Add(item.Id, item.Mesa, item.EstadoPedido, item.Estado)
            Next
            consultarEstadoPedidos = True
        Catch ex As Exception
            consultarEstadoPedidos = False
        End Try
    End Function

    Private Sub frm_estado_pedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If (cargaComboEstados() = False) Then
            'mensaje(titulo, "No se pudo cargar estados", "danger")
        End If

        If (consultarEstadoPedidos() = False) Then
            'mensaje(titulo, "No se pudo cargar los pedidos", "danger")
        End If
    End Sub

    Private Sub cmb_estado_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmb_estado.SelectedValueChanged


    End Sub

    Private Sub cmb_estado_TextChanged(sender As Object, e As EventArgs) Handles cmb_estado.TextChanged

    End Sub

    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        If (consultarEstadoPedidos() = False) Then
            ' mensaje(titulo, "No se pudo cargar los pedidos", "danger")
        End If
    End Sub

    Private Sub dgv_pedidos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_pedidos.CellContentClick

    End Sub
End Class