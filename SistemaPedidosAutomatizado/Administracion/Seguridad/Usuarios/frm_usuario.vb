Imports CapaEntidad
Imports CapaNegocio

Public Class frm_usuario
    Dim usuarioNegocio As New UsuarioNegocio
    Dim usuario As New Usuario

    Private Sub frm_usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (cargarCombo() = False) Then
            MsgBox("No se pudo carga los roles", MsgBoxStyle.Critical, "Usuarios")
        End If

        pb_foto.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory() & "img\user_default.jpg")
    End Sub

    Private Sub cargarUsuarioTexbox(user As Usuario)
        txt_cedula.Text = user.Cedula
        cbo_perfil.Text = user.Perfil
        cbo_perfil.SelectedValue = user.Id_perfil.ToString
        txt_nombres.Text = user.Nombres
        txt_apellidos.Text = user.Apellidos
        txt_direccion.Text = user.Direccion
        txt_telefono.Text = user.Telefono
        txt_correo.Text = user.Email
        txt_usuario.Text = user.Usuario
        txt_clave.Text = user.Clave

        'foto
        'Dim mi_foto As Byte()
        'mi_foto = ImageToByteArray(pb_foto.Image)
        If (user.Foto Is Nothing) Then
        Else
            pb_foto.Image = ByteArrayToImage(user.Foto)
        End If
    End Sub

    Private Function recuperaUsuario(cedula As String) As Boolean
        Try
            recuperaUsuario = False

            usuario = usuarioNegocio.getUsuario(cedula)
            cargarUsuarioTexbox(usuario)

            recuperaUsuario = True
        Catch ex As Exception
            recuperaUsuario = False
        End Try
    End Function

    Private Function cargarCombo() As Boolean
        Try
            cargarCombo = False
            Dim lista As New ArrayList()

            lista = usuarioNegocio.getListaPerfiles()

            With cbo_perfil
                .DropDownStyle = ComboBoxStyle.DropDownList
                '.AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .DataSource = lista
                .ValueMember = "Codigo"
                .DisplayMember = "Texto"
            End With
            cargarCombo = True
        Catch ex As Exception
            cargarCombo = False
        End Try
    End Function

    Private Sub btn_buscausuario_Click(sender As Object, e As EventArgs) Handles btn_buscausuario.Click
        Try
            Dim frmBuscar As New frm_buscar_usuario
            auxUsuario.Id = 0
            frmBuscar.ShowDialog()
            usuario = auxUsuario
            auxUsuario.Id = 0
            cargarUsuarioTexbox(usuario)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_cedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cedula.KeyPress
        Try
            If (Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9) Then

                'Validar cedula

                If (recuperaUsuario(txt_cedula.Text) = False) Then
                    'MsgBox("El usuario no existe", MsgBoxStyle.Information)
                    'Limpiar()
                    'txt_cedula.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class