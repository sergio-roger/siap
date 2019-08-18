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

    Private Sub Multiplicar()
        Try
            If (dgv_pedido.RowCount > 0) Then

                For fila = 0 To dgv_pedido.RowCount - 1
                    'dgv_pedido.Rows(fila).Cells(subototal_p).Value = (dgv.Rows(fila).Cells(cant_p).Value) * (dgv_pedido.Rows(fila).Cells(precio_p).Value)
                    'Calcular el Iva'
                    If (dgv_pedido.Rows(fila).Cells(descuento_col).Value = True) Then  'Aplica descuento
                        Dim axu_desc As Double
                        axu_desc = (dgv_pedido.Rows(fila).Cells(precio_col).Value * dgv_pedido.Rows(fila).Cells(porcentaje_col).Value) / 100
                        dgv_pedido.Rows(fila).Cells(subtotal_col).Value = (dgv_pedido.Rows(fila).Cells(precio_col).Value - axu_desc)
                    Else
                        dgv_pedido.Rows(fila).Cells(subtotal_col).Value = dgv_pedido.Rows(fila).Cells(precio_col).Value
                    End If

                    dgv_pedido.Rows(fila).Cells(total_col).Value = dgv_pedido.Rows(fila).Cells(subtotal_col).Value * dgv_pedido.Rows(fila).Cells(cantidad_col).Value
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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
End Class