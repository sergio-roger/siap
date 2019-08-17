Imports CapaEntidad
Imports CapaNegocio

Public Class frm_usuario
    Dim usuarioNegocio As New UsuarioNegocio
    Dim usuario As New Usuario

    Private Sub frm_usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (cargarCombo() = False) Then
            MsgBox("No se pudo carga los roles", MsgBoxStyle.Critical, "Usuarios")
        End If

        chk_validar.Checked = True
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
            pb_foto.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory() & "img\user_default.jpg")
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

    Function validarDatos() As Boolean
        Try
            validarDatos = False
            Dim lista As New List(Of Usuario)

            If (txt_cedula.Text = String.Empty) Then
                MsgBox("Ingrese una cedula ", MsgBoxStyle.Information, "Cedula")
                txt_cedula.Focus()
                Exit Function
            End If

            If chk_validar.Checked = True Then
                If fun_validacedula(txt_cedula.Text) = False Then
                    MsgBox("Número de cédula incorrecto", MsgBoxStyle.Exclamation)
                    Exit Function
                End If
            End If
            If txt_nombres.Text = String.Empty Then
                MsgBox("Ingrese el nombre del usuario", MsgBoxStyle.Exclamation)
                txt_nombres.Focus()
                Exit Function
            End If
            If txt_apellidos.Text = String.Empty Then
                MsgBox("Ingrese el apellido del usuario", MsgBoxStyle.Exclamation)
                txt_apellidos.Focus()
                Exit Function
            End If
            If txt_usuario.Text = String.Empty Then
                MsgBox("Ingrese el nombre del usuario", MsgBoxStyle.Exclamation)
                txt_usuario.Focus()
                Exit Function
            End If

            If txt_clave.Text = String.Empty Then
                MsgBox("Ingrese la clave del usuario", MsgBoxStyle.Critical, "Error en la clave")
                txt_clave.Focus()
                Exit Function
            End If

            If (usuario.Id = 0) Then
                lista = usuarioNegocio.getUsuarios(txt_usuario.Text, "usuario")

                If (lista IsNot Nothing) Then
                    For Each item In lista
                        If (item.Usuario = txt_usuario.Text) Then
                            MsgBox("El usuario ya esta registrado !", MsgBoxStyle.Exclamation, "Usuario")
                            Exit For
                        End If
                    Next
                    Exit Function
                End If
            End If

            If txt_clave.Text = String.Empty Then
                MsgBox("Ingrese el nombre la clave", MsgBoxStyle.Exclamation)
                txt_clave.Focus()
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
            validarDatos = True
        Catch ex As Exception
            MsgBox(ex.Message)
            validarDatos = False
        End Try

    End Function

    Private Sub Limpiar()
        txt_cedula.Text = ""
        txt_nombres.Text = ""
        txt_apellidos.Text = ""
        txt_direccion.Text = ""
        txt_telefono.Text = ""
        txt_correo.Text = ""
        txt_usuario.Text = ""
        txt_clave.Text = ""
        txt_cedula.Focus()
        usuario.Id = 0
        auxUsuario.Id = 0
        chk_validar.Checked = True
        pb_foto.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory() & "img\user_default.jpg")

    End Sub

    Private Function crearUsuario() As Usuario
        Dim nuevo As New Usuario

        nuevo.Id = IIf(usuario.Id = 0, 0, usuario.Id)
        nuevo.Id_perfil = Integer.Parse(cbo_perfil.SelectedValue.ToString)
        nuevo.Cedula = txt_cedula.Text
        nuevo.Nombres = txt_nombres.Text
        nuevo.Apellidos = txt_apellidos.Text
        nuevo.Direccion = txt_direccion.Text
        nuevo.Telefono = txt_telefono.Text
        nuevo.Email = txt_correo.Text
        nuevo.Usuario = txt_usuario.Text
        nuevo.Clave = txt_clave.Text
        nuevo.Foto = ImageToByteArray(pb_foto.Image)
        nuevo.Fecha = date_fecha.Value.ToShortDateString
        MsgBox(nuevo.Fecha)
        nuevo.Estado = "A"

        Return nuevo
    End Function

    Private Function grabar() As Boolean

        Try
            grabar = False
            usuario = crearUsuario()
            grabar = usuarioNegocio.grabar(usuario)

        Catch ex As Exception
            grabar = False
            MsgBox(ex.Message)
        Finally
            'Desconectar()
        End Try
    End Function

    Private Function eliminar(usuario) As Boolean
        Try
            eliminar = False
            eliminar = usuarioNegocio.eliminar(usuario)
        Catch ex As Exception
            eliminar = False
        End Try
    End Function

    Private Sub btn_buscausuario_Click(sender As Object, e As EventArgs) Handles btn_buscausuario.Click
        Try
            Dim frmBuscar As New frm_buscar_usuario
            auxUsuario.Id = 0
            frmBuscar.ShowDialog()
            usuario = auxUsuario
            cargarUsuarioTexbox(usuario)
            'auxUsuario.Id = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_cedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cedula.KeyPress
        Try
            If (Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9) Then

                'Validar cedula

                If (recuperaUsuario(txt_cedula.Text) = False) Then
                    MsgBox("El usuario no existe", MsgBoxStyle.Information)
                    Limpiar()
                    txt_cedula.Focus()
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_grabar_Click(sender As Object, e As EventArgs) Handles btn_grabar.Click
        Try
            If (validarDatos() = False) Then
                Exit Sub
            End If

            'txt_clave_Leave(Me, New KeyPressEventArgs(ChrW(Keys.End)))

            'Proceso para grabar
            If (grabar()) Then
                If (usuario.Id = 0) Then
                    MsgBox("Datos registrados correctamente", MsgBoxStyle.Information, "Usuario")
                Else
                    MsgBox("Datos actualizados correctamente", MsgBoxStyle.Information, "Usuario")
                End If
            Else
                MsgBox("Hubo un error al insertar el registro", MsgBoxStyle.Critical, "Usuario")
            End If

            Limpiar()
            'clave_encri = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_cargar_Click(sender As Object, e As EventArgs) Handles btn_cargar.Click
        Try
            Dim archivo As New OpenFileDialog

            archivo.Filter = "Archivo JPG|*.jpg"

            If (archivo.ShowDialog = DialogResult.OK) Then
                pb_foto.Image = Image.FromFile(archivo.FileName)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        Limpiar()
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Try
            If (txt_cedula.Text = String.Empty) Then
                MsgBox("Digite una cedula para eliminar un usuario", MsgBoxStyle.Information, "Cedula")
                Exit Sub
            End If

            If (PreguntaRespuesta("Desea eliminar a " & txt_nombres.Text & " ? ", "Confirmar") = MsgBoxResult.Yes) Then

                If (eliminar(usuario) = False) Then
                    MsgBox("Hubo un error al eliminar al usuario !", MsgBoxStyle.Critical, "Usuario")
                Else
                    MsgBox("Usuario eliminado :v ", MsgBoxStyle.Information, "Usuario")
                    Limpiar()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class