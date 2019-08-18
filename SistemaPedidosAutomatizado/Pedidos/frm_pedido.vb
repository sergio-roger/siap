Imports CapaEntidad
Imports CapaNegocio

Public Class frm_pedido
    Private pedido As New Pedido
    Private pedidoNegocio As New PedidoNegocio
    Private usuario As Usuario
    Private titulo As String

    Private Sub CargarCombos()
        Try
            If (cargarComboMesas() = False) Then
                mensaje(titulo, "Hubo un error al cargar las mesas", "danger")
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
            Dim lista As New ArrayList()

            lista = pedidoNegocio.getListaPedidos()

            With cmb_mesa
                .DropDownStyle = ComboBoxStyle.DropDownList
                '.AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .DataSource = lista
                .ValueMember = "Codigo"
                .DisplayMember = "Texto"
            End With
            cargarComboEstados = True
        Catch ex As Exception
            cargarComboEstados = False
        End Try
    End Function

    Private Sub frm_pedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            usuario = usuarioSeccion
            txt_usuario.Text = usuario.Nombres

            CargarCombos()
            'numero_pedido = Obtener_N_Pedido()
            'txt_codigo_pedido.Text = numero_pedido.ToString()
            rdb_combo.Checked = False
            rdb_plato.Checked = True
            txt_codigo_pedido.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class