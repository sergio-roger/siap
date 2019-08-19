Imports CapaEntidad
Imports CapaNegocio

Public Class frm_factura
    Private pedidoNegocio As New PedidoNegocio
    Private clienteNegocio As New ClienteNegocio

    Private pedido As New Pedido
    Private titulo As String = "Factura"
    Private descuento, subtotal, total As Double
    Private cliente As New Cliente
    Private factura As New Factura

    Public Function cargarCliente(objeto As Cliente) As Boolean
        Try
            cargarCliente = False
            txt_cedula.Text = objeto.Cedula
            txt_nombres.Text = objeto.Nombre
            txt_apellidos.Text = objeto.Apellido
            txt_direccion.Text = objeto.Direccion
            txt_Telefono.Text = objeto.Telefono
            txt_correo.Text = objeto.Correo

            cargarCliente = True
        Catch ex As Exception
            cargarCliente = False
        End Try
    End Function

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bn_buscar_cliente.Click
        Try
            Dim frm As New frm_buscar_cliente
            frm.ShowDialog()
            cliente = auxCliente

            If (cargarCliente(cliente) = False) Then
                mensaje(titulo, "No se ha poiddido cargar Clientes", "danger")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function validarCliente() As Boolean
        Try
            validarCliente = False

            If (txt_cedula.Text = String.Empty) Then
                mensaje(titulo, "Ingrese una cedula", "info")
                Exit Function
            End If

            If chk_activar.Checked = True Then
                If fun_validacedula(txt_cedula.Text) = False Then
                    MsgBox("Número de cédula incorrecto", MsgBoxStyle.Exclamation)
                    Exit Function
                End If
            End If

            If (txt_nombres.Text = String.Empty) Then
                mensaje(titulo, "Ingrese nombres del cliente", "info")
                Exit Function
            End If

            If (txt_apellidos.Text = String.Empty) Then
                mensaje(titulo, "Ingrese apellidos", "info")
                Exit Function
            End If

            If txt_correo.Text <> String.Empty Then
                If validar_Mail(LCase(txt_correo.Text)) = False Then
                    MessageBox.Show("Dirección de correo electronico no valida,el correo debe tener el formato: nombre@dominio.com, " &
                    " por favor seleccione un correo valido", "Validación de     correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_correo.Focus()
                    Exit Function
                End If
            End If

            validarCliente = False
        Catch ex As Exception
            validarCliente = True
        End Try
    End Function

    Private Function cearCliente() As Cliente
        Dim nuevo As New Cliente

        nuevo.Cedula = txt_cedula.Text
        nuevo.Nombre = txt_nombres.Text
        nuevo.Apellido = txt_apellidos.Text
        nuevo.Direccion = txt_direccion.Text
        nuevo.Telefono = txt_Telefono.Text
        nuevo.Correo = txt_correo.Text

        Return nuevo
    End Function

    Private Function grabar() As Boolean
        Try
            grabar = False

            '  grabar = grabar.
        Catch ex As Exception
            grabar = False
        End Try
    End Function

    Private Function grabarCliente() As Boolean
        Try
            grabarCliente = False

            grabarCliente = clienteNegocio.grabar(cliente)
        Catch ex As Exception
            grabarCliente = False
        End Try
    End Function

    Private Sub btn_grabar_Click(sender As Object, e As EventArgs) Handles btn_grabar.Click
        Try
            If (validarCliente() = False) Then
                Exit Sub
            End If

            factura = cearFactura()
            If (grabar() = False) Then
                mensaje(titulo, "No se ha grabado", "danger")
            End If

            cliente = cearCliente()
            If (grabarCliente() = False) Then
                mensaje(titulo, "No se ha grabado el cliente", "danger")
            End If
        Catch ex As Exception

        End Try
    End Sub

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
            cliente.Id = 0
            chk_activar.Checked = True
        Catch ex As Exception

        End Try
    End Sub
End Class