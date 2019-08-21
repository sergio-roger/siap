Imports CapaEntidad
Imports CapaNegocio

Public Class frm_pedido
    Private pedido As New Pedido
    Private pedidoNegocio As New PedidoNegocio
    Private platoNegocio As New PlatoNegocio
    Private comboNegocio As New ComboNegocio

    Private usuario As Usuario
    Private detalleComida As New DetallePedido

    Private titulo As String
    Private expandir As Boolean = False
    Private subtotal_col As Integer = 8 + 1
    Private cantidad_col As Integer = 4 + 1
    Private precio_col As Integer = 5 + 1
    Private descuento_col As Integer = 6 + 1
    Private porcentaje_col As Integer = 7 + 1
    Private total_col As Integer = 9 + 1

    Private Sub CargarCombos()
        Try
            If (cargarComboMesas() = False) Then
                mensaje(titulo, "Hubo un error al cargar las mesas", "danger")
            End If

            If (cargarComboEstados() = False) Then
                mensaje(titulo, "Hubo un error al cargar el Estado de los Pedidos", "danger")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function cargarComboMesas() As Boolean
        Try
            cargarComboMesas = False
            Dim lista As New ArrayList()

            lista = pedidoNegocio.getLista()

            With cmb_mesa
                .DropDownStyle = ComboBoxStyle.DropDownList
                '.AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .DataSource = lista
                .ValueMember = "Codigo"
                .DisplayMember = "Texto"
            End With
            cargarComboMesas = True
        Catch ex As Exception
            cargarComboMesas = False
        End Try
    End Function

    Private Function cargarComboEstados() As Boolean
        Try
            cargarComboEstados = False
            cmb_estado.Items.Add("Ordenado")
            cmb_estado.Text = "Ordenado"

            cargarComboEstados = True
        Catch ex As Exception
            cargarComboEstados = False
        End Try
    End Function

    Private Function obtenerNPedido() As Integer
        Return pedidoNegocio.numero()
    End Function

    Private Function llenarTablaPlatos() As Boolean
        Try
            llenarTablaPlatos = False
            Dim lista As New List(Of Plato)

            lista = pedidoNegocio.getPlatos()
            dgv_productos.Rows.Clear()

            If (lista.Count > 0) Then
                For Each item In lista
                    dgv_productos.Rows.Add(item.Id, item.Nombre, item.Precio, item.Codigo, False, 0)
                Next
            End If
            llenarTablaPlatos = True
        Catch ex As Exception
            llenarTablaPlatos = True
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function llenarTablaCombo() As Boolean
        Try
            llenarTablaCombo = False
            Dim lista As New List(Of Combo)

            lista = pedidoNegocio.getCombos()
            dgv_productos.Rows.Clear()

            If (lista.Count > 0) Then
                For Each item In lista
                    dgv_productos.Rows.Add(item.Id, item.Descripcion, item.Precio, item.Codigo, item.Descuento, item.Porcentaje)
                Next
            End If

            llenarTablaCombo = True
        Catch ex As Exception
            llenarTablaCombo = False
        End Try
    End Function

    Private Sub CargarTabla()
        Try
            If (rdb_plato.Checked = True) Then
                If (llenarTablaPlatos() = False) Then
                    mensaje(titulo, "No se cargo los platos", "danger")
                    Exit Sub
                End If

            ElseIf (rdb_combo.Checked = True) Then
                If (llenarTablaCombo() = False) Then
                    mensaje(titulo, "No se cargo los combos", "danger")
                    Exit Sub
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Function buscarPlatos(buscar As String, opcion As String) As Boolean
        Try
            buscarPlatos = False
            Dim lista As New List(Of Plato)

            lista = PlatoNegocio.getPlatos(buscar, opcion)
            dgv_productos.Rows.Clear()

            If (lista IsNot Nothing) Then
                For Each item In lista
                    dgv_productos.Rows.Add(item.Id, item.Nombre, item.Precio, item.Codigo, False, 0)
                Next
            End If
        Catch ex As Exception
            buscarPlatos = False
            'MsgBox(ex.Message)
        End Try
    End Function

    Function buscarCombos(buscar As String, opcion As String) As Boolean
        Try
            buscarCombos = False
            Dim lista As New List(Of Combo)

            lista = comboNegocio.getCombos(buscar, opcion)
            dgv_productos.Rows.Clear()

            If (lista IsNot Nothing) Then
                For Each item In lista
                    dgv_productos.Rows.Add(item.Id, item.Descripcion, item.Precio, item.Codigo, item.Descuento, item.Porcentaje)
                Next
            End If
        Catch ex As Exception
            buscarCombos = False
            'MsgBox(ex.Message)
        End Try
    End Function

    Private Sub LimpiarOrden()
        txt_codigo.Text = ""
        txt_descripcion.Text = ""
        txt_cantidad.Text = ""
        txt_precio.Text = ""
        rdb_plato.Checked = True
        txt_codigo.Focus()
    End Sub

    Private Sub AgregarTabla(objeto As DetallePedido)
        dgv_pedido.Rows.Add(0, objeto.Id_Pedido, objeto.Id_tipoComida, objeto.Id_Comida, objeto.Nombre, objeto.Cantidad, objeto.PrecioUnitario, objeto.Descuento, objeto.Porcentaje, objeto.Subtotal, objeto.Total, "A")
    End Sub

    Private Function Validar() As Boolean
        Validar = False

        If (dgv_pedido.RowCount < 1) Then
            mensaje("Pedido", "Ingrese al menos un plato o un combo", "info")
            txt_codigo.Focus()
            Exit Function
        End If

        Validar = True
    End Function

    Private Sub Limpiar()
        txt_codigo.Text = ""
        rdb_plato.Checked = True
        rdb_combo.Checked = False
        txt_descripcion.Text = ""
        txt_cantidad.Text = ""
        txt_precio.Text = ""
        dgv_pedido.Rows.Clear()
        txt_codigo_pedido.Focus()
    End Sub

    Private Sub frm_pedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Width = 484
            usuario = usuarioSeccion
            txt_usuario.Text = usuario.Nombres
            rdb_combo.Checked = False
            rdb_plato.Checked = True
            CargarCombos()
            CargarTabla()
            txt_codigo_pedido.Text = obtenerNPedido()
            txt_codigo_pedido.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function crearPedido() As Pedido
        Dim nuevo As New Pedido

        nuevo.Id = Integer.Parse(txt_codigo_pedido.Text)
        nuevo.Estado = "A"
        nuevo.Id_mesa = cmb_mesa.SelectedValue.ToString
        nuevo.Id_usuario = usuario.Id
        nuevo.Id_estadoPedido = 1
        nuevo.Observacion = txt_descripcion.Text
        nuevo.Fecha = date_fecha.Value.ToShortDateString

        Return nuevo
    End Function

    Private Function crearListaDetalles() As List(Of DetallePedido)
        Dim i As Integer = 1
        crearListaDetalles = Nothing
        Try
            Dim lista As New List(Of DetallePedido)
            For Each Fila In dgv_pedido.Rows.Cast(Of DataGridViewRow)()
                Dim dp As New DetallePedido

                dp.Id = Fila.Cells("col_id").Value.ToString()
                dp.Id_Pedido = Fila.Cells("col_id_ped").Value.ToString()
                dp.Id_tipoComida = Fila.Cells("col_id_tc").Value.ToString
                dp.Id_Comida = Fila.Cells("col_id_comida").Value.ToString
                dp.Nombre = Fila.Cells("col_nombre").Value.ToString
                dp.Cantidad = Integer.Parse(Fila.Cells("col_cantidad").Value.ToString)
                dp.PrecioUnitario = Fila.Cells("col_precio").Value.ToString
                dp.Descuento = Fila.Cells("col_descuento").Value.ToString
                dp.Porcentaje = Integer.Parse(Fila.Cells("col_porcentaje").Value.ToString)
                dp.Subtotal = Fila.Cells("col_subtotal").Value.ToString
                dp.Total = Fila.Cells("col_total").Value.ToString
                dp.Estado = Fila.Cells("col_estado").Value.ToString
                dp.Fecha = date_fecha.Value.ToShortDateString

                lista.Add(dp)
                'Relizar insercciones en la tabla Detalle-Pedido
                'If (GrabarDetallePedido(pedido_id) = False) Then
                'End If
                i = i + 1
            Next
            Return lista
        Catch ex As Exception
            crearListaDetalles = Nothing
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function GrabarPedido() As Boolean
        Try
            GrabarPedido = False
            Dim listadetalles As New List(Of DetallePedido)

            pedido = crearPedido()
            listadetalles = crearListaDetalles()
            pedido.Detalles = listadetalles

            GrabarPedido = pedidoNegocio.grabar(pedido, "m-ocupado")

        Catch ex As Exception
            GrabarPedido = False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub btn_buscar_p_Click(sender As Object, e As EventArgs)
        If rdb_combo.Checked = True Then
            Dim frm As New frm_mantCombo
            frm.ShowDialog()
        End If
    End Sub

    Private Sub rdb_combo_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_combo.CheckedChanged
        If (rdb_combo.Checked = True) Then
            If (llenarTablaCombo() = False) Then
                mensaje(titulo, "No se pudo cargar", "danger")
            End If
        End If
    End Sub

    Private Sub rdb_plato_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_plato.CheckedChanged
        If (rdb_plato.Checked = True) Then
            If (llenarTablaPlatos() = False) Then
                mensaje(titulo, "No se pudo cargar platos", "danger")
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar.TextChanged
        If (rdb_plato.Checked = True) Then
            'Buscar en platos
            If buscarPlatos(txt_buscar.Text, "plato") = False Then
            End If
        End If

        If (rdb_combo.Checked = True) Then
            'Buscar en Combos
            If buscarCombos(txt_buscar.Text, "descripcion") = False Then
            End If
        End If
    End Sub

    Private Sub btn_expandir_Click(sender As Object, e As EventArgs) Handles btn_expandir.Click
        If (expandir = False) Then
            Do Until Me.Width = 766
                Me.Width += 2
            Loop
            expandir = True
            btn_expandir.Text = "<<"
        ElseIf (expandir = True) Then

            Do Until Me.Width = 484
                Me.Width -= 2
            Loop
            btn_expandir.Text = ">>"
            expandir = False
        End If
    End Sub

    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Try
            If (txt_codigo.Text = "") Then
                mensaje("Pedido", "Ingrese un codigo", "danger")
                txt_codigo.Focus()
                Exit Sub
            End If
            If (txt_cantidad.Text = "") Then
                mensaje("Pedido", "Ingrese una cantidad", "alert")
                txt_cantidad.Focus()
                Exit Sub
            End If

            If (txt_cantidad.Text <> "" And Val(txt_cantidad.Text) > 0) Then
                'dgv_pedido.Rows.Add(False, txt_id_aux.Text, id_comida, txt_descripcion.Text, tipo, txt_cantidad.Text, txt_precio.Text,
                'txt_descuento.Text, txt_porcentaje.Text)
                detalleComida = pedidoNegocio.calcularDescuento(detalleComida)
                detalleComida.Cantidad = Integer.Parse(txt_cantidad.Text)
                detalleComida.Total = detalleComida.Subtotal * detalleComida.Cantidad
                AgregarTabla(detalleComida)
                LimpiarOrden()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgv_productos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_productos.CellDoubleClick
        Try
            If e.RowIndex > -1 Then
                detalleComida.Id = 0
                detalleComida.Id_Pedido = Integer.Parse(txt_codigo_pedido.Text)

                If (rdb_plato.Checked = True) Then
                    detalleComida.Id_tipoComida = 1
                ElseIf (rdb_combo.Checked = True) Then
                    detalleComida.Id_tipoComida = 2
                End If

                detalleComida.Id_Comida = dgv_productos.Rows(e.RowIndex).Cells(0).Value
                detalleComida.Nombre = dgv_productos.Rows(e.RowIndex).Cells(1).Value
                'detalleComida.Cantidad = Integer.Parse(txt_cantidad.Text)
                detalleComida.PrecioUnitario = dgv_productos.Rows(e.RowIndex).Cells(2).Value
                detalleComida.Descuento = dgv_productos.Rows(e.RowIndex).Cells(4).Value
                detalleComida.Porcentaje = Integer.Parse(dgv_productos.Rows(e.RowIndex).Cells(5).Value)

                'Presentar en los textbox
                txt_codigo.Text = dgv_productos.Rows(e.RowIndex).Cells(3).Value
                txt_precio.Text = Agregar_cero(detalleComida.PrecioUnitario)
                txt_descripcion.Text = detalleComida.Nombre
                txt_cantidad.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad.KeyPress
        Try
            If (Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9) Then

                btn_agregar_Click(Me, New KeyPressEventArgs(ChrW(Keys.Enter)))
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_grabar_Click(sender As Object, e As EventArgs) Handles btn_grabar.Click
        Try
            If (Validar() = False) Then
                Exit Sub
            End If

            If (PreguntaRespuesta("Realmente desea Grabar ? ", "Confirmar Transacción") = MsgBoxResult.Yes) Then
                'MsgBox("Procediendo a guardar la factura", MsgBoxStyle.Information, "Registrar datos")

                If (GrabarPedido() = False) Then
                    MsgBox("Hubo un error al guardar el Pedido", MsgBoxStyle.Critical, "Error")
                Else
                    Limpiar()
                    If (cargarComboMesas() = False) Then
                        mensaje(titulo, "Hubo un error al cargar las mesas", "danger")
                    End If
                    txt_codigo_pedido.Text = obtenerNPedido()
                    MsgBox("Pedido guardado correctamente", MsgBoxStyle.Information, "Exito al Guardar")
                End If
            Else
                MsgBox("No se registrara los datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgv_pedido_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_pedido.KeyDown
        Dim li_index As Integer

        If e.KeyCode = Keys.Delete Then

            e.Handled = True

            li_index = CType(sender, DataGridView).CurrentRow.Index
            dgv_pedido.Rows.RemoveAt(li_index)
        End If
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        Limpiar()
    End Sub
End Class