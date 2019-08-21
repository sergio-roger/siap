Imports CapaEntidad
Imports CapaNegocio

Public Class frm_factura
    Private pedidoNegocio As New PedidoNegocio
    Private clienteNegocio As New ClienteNegocio
    Private facturaNegocio As New FacturaNegocio

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

            validarCliente = True
        Catch ex As Exception
            validarCliente = False
        End Try
    End Function

    Private Function validarFactura() As Boolean
        Try
            validarFactura = False

            If (dgv_pedido.RowCount < 1) Then
                mensaje(titulo, "Ingrese la orden del pedido a facturar", "alerts")
                btn_buscar.Focus()
                Exit Function
            End If
            validarFactura = True
        Catch ex As Exception
            validarFactura = False
        End Try
    End Function

    Private Function cearFactura() As Factura
        Dim nuevo As New Factura

        nuevo.Id = IIf(factura.Id = 0, 0, factura.Id)
        nuevo.Id_usuario = usuarioSeccion.Id
        nuevo.Id_cliente = cliente.Id
        nuevo.Id_pedido = pedido.Id
        nuevo.Total = total
        nuevo.Subtotal = subtotal
        nuevo.Descuento = descuento
        nuevo.Fecha = date_fecha.Value.ToShortDateString
        nuevo.Hora = date_hora.Value.ToShortTimeString
        nuevo.Estado = "A"

        Return nuevo
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

            grabar = facturaNegocio.grabar(factura)
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

    Private Sub Limpiar()
        cliente.Id = 0
        factura.Id = 0
        pedido.Id = 0
        dgv_pedido.Rows.Clear()
        txt_cedula.Text = ""
        txt_apellidos.Text = ""
        txt_nombres.Text = ""
        txt_direccion.Text = ""
        txt_Telefono.Text = ""
        txt_cedula.Text = ""
        txt_total.Text = ""
        txt_subtotal.Text = ""
        txt_descuento.Text = ""
        txt_correo.Text = ""
    End Sub

    Private Function recuperarCliente(cedula As String) As Boolean
        Try
            recuperarCliente = False
            cliente = clienteNegocio.getCliente(cedula)

            If (cliente IsNot Nothing) Then
                txt_cedula.Text = cliente.Cedula
                txt_nombres.Text = cliente.Nombre
                txt_apellidos.Text = cliente.Apellido
                txt_direccion.Text = cliente.Direccion
                txt_Telefono.Text = cliente.Telefono
                txt_correo.Text = cliente.Correo
            End If

            recuperarCliente = True
        Catch ex As Exception
            recuperarCliente = False
        End Try
    End Function

    Private Sub btn_grabar_Click(sender As Object, e As EventArgs) Handles btn_grabar.Click
        Try
            If (validarCliente() = False) Then
                Exit Sub
            End If

            If (validarFactura() = False) Then
                Exit Sub
            End If

            Dim c As Cliente = clienteNegocio.getCliente(cliente.Cedula)

            If (c Is Nothing) Then
                cliente.Id = 0
            Else
                cliente.Id = c.Id
            End If

            cliente = cearCliente()

            If (grabarCliente() = False) Then
                mensaje(titulo, "No se ha grabado el cliente", "danger")
                Exit Sub
            End If

            factura = cearFactura()
            If (cliente.Id = 0) Then
                c = clienteNegocio.getCliente(cliente.Cedula)
            End If
            factura.Id_cliente = c.Id

            If (grabar() = False) Then
                mensaje(titulo, "No se ha grabado", "danger")
                Exit Sub
            Else
                'Actualizar el estado del pedido
                If (actualizarPedido(4) = False) Then
                    mensaje(titulo, "Hubo un error al actualizar los datos", "danger")
                    Exit Sub
                End If

                'Actualizar el estado de la mesa 
                If (actualizarEstadoMesa("m-facturada") = False) Then
                    mensaje(titulo, "Hubo un error al actualizar mesa", "danger")
                    Exit Sub
                End If

                '
                'Aki va auditoria 
                '
                mensaje(titulo, "Factura registrado con exito !", "info")
                Limpiar()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function actualizarPedido(estado As Integer) As Boolean
        Try
            actualizarPedido = False
            actualizarPedido = pedidoNegocio.actualizarPedido(pedido.Id, estado)

        Catch ex As Exception
            actualizarPedido = False
        End Try
    End Function

    Private Function actualizarEstadoMesa(estado As String) As Boolean
        Dim mesaNegocio As New MesaNegocio
        Return mesaNegocio.actualizarEstadoMesa(pedido.Id_mesa, estado)
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Try
            Dim frm As New frm_buscar_pedido
            frm.ShowDialog()
            pedido = auxPedido

            llenarTablaPedido(auxPedido)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenarTablaPedido(objeto As Pedido)

        objeto.Detalles = New List(Of DetallePedido)
        objeto.Detalles = pedidoNegocio.getListaDetallePedidos(objeto.Id)
        dgv_pedido.Rows.Clear()
        descuento = 0
        subtotal = 0
        total = 0

        For Each item In objeto.Detalles
            descuento += item.PrecioUnitario * item.Porcentaje / 100
            subtotal += item.PrecioUnitario * item.Cantidad
            total += item.Subtotal * item.Cantidad
            dgv_pedido.Rows.Add(item.Id, item.Id_Pedido, item.Id_tipoComida, item.Id_Comida, item.Nombre, item.Cantidad, item.PrecioUnitario, item.Descuento, item.Porcentaje, item.Subtotal, item.Total, item.Estado)
        Next

        txt_descuento.Text = descuento
        txt_subtotal.Text = subtotal
        txt_total.Text = total
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        Limpiar()
    End Sub

    Private Sub frm_factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txt_usuario.Text = usuarioSeccion.Nombres
            cliente.Id = 0
            factura.Id = 0
            chk_activar.Checked = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_cedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cedula.KeyPress
        Try
            If (Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9) Then

                If (recuperarCliente(txt_cedula.Text) = False) Then
                    txt_nombres.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txt_num_ped_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_num_ped.KeyPress
        Try
            If (Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9) Then

                recuperarPedido(txt_num_ped.Text)
                txt_nombres.Focus()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub recuperarPedido(numero As String)
        Dim buscar As New Pedido

        buscar = pedidoNegocio.getPedidoxNumero(numero)
        pedido = buscar

        If (buscar Is Nothing) Then
            txt_num_ped.Text = ""
            mensaje(titulo, "El número de pedido no se encuentra disponible", "alert")
            txt_num_ped.Focus()
        Else
            llenarTablaPedido(buscar)
        End If
    End Sub

End Class