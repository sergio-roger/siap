Imports CapaEntidad
Imports CapaNegocio

Public Class frm_plato
    Dim platoNegocio As New PlatoNegocio
    Dim plato As New Plato
    Dim titulo As String = "Plato"
    Private Sub frm_plato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarCombo()
            plato.Id = 0
            pb_foto.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory() & "img\image_defualt.jpg")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function cargarCombo() As Boolean
        Try
            cargarCombo = False
            Dim lista As New ArrayList()

            lista = platoNegocio.getListaModalidad

            With cmb_modalidad
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
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function creaplato() As Plato
        Dim nuevo As New Plato()

        nuevo.Id = IIf(plato.Id = 0, 0, plato.Id)
        nuevo.Mod_id = cmb_modalidad.SelectedValue.ToString
        nuevo.Codigo = txt_codigo.Text
        nuevo.Nombre = txt_nombre.Text
        nuevo.Precio = txt_precio.Text
        nuevo.Descripcion = txt_descripcion.Text
        nuevo.Imagen = ImageToByteArray(pb_foto.Image)
        nuevo.Fecha = date_fecha.Value.ToShortDateString
        nuevo.Estado = "A"

        Return nuevo
    End Function

    Private Function grabar() As Boolean
        Try
            grabar = False
            plato = creaplato()
            grabar = platoNegocio.grabar(plato)
        Catch ex As Exception
            grabar = False
            MsgBox(ex.Message)
        End Try

    End Function
    Sub limpiar()
        txt_codigo.Text = ""
        txt_nombre.Text = ""
        txt_descripcion.Text = ""
        txt_precio.Text = ""
        pb_foto.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory() & "img\image_defualt.jpg")
        auxPlato.Id = 0
        plato.Id = 0
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        limpiar()

    End Sub

    Private Sub btn_grabar_Click(sender As Object, e As EventArgs) Handles btn_grabar.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            If grabar() Then
                If (plato.Id = 0) Then
                    mensaje(titulo, "Registro grabado con éxito", "info")
                Else
                    mensaje(titulo, "Registro se actualizó", "info")
                End If
            Else
                MsgBox("Algo falló al registrar los datos")
                Exit Sub
            End If
            limpiar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function Validar() As Boolean
        Try
            Validar = False

            If (txt_descripcion.Text = "" Or txt_descripcion.Text.Length = 0 Or txt_descripcion Is Nothing) Then
                MsgBox("¡Ingrese una descripcion!", MsgBoxStyle.Information, "plato")
                txt_descripcion.Focus()

                Exit Function
            End If

            If (txt_nombre.Text = "" Or txt_nombre.Text.Length = 0 Or txt_nombre Is Nothing) Then
                MsgBox("¡Ingrese el nombre!", MsgBoxStyle.Information, "plato")
                txt_nombre.Focus()
                Exit Function
            End If

            If (txt_precio.MaskFull) Then
            Else
                mensaje(titulo, "Formato de precio ejemplo: 04,75 ", "alert")
                txt_precio.Focus()
                Exit Function
            End If

            Validar = True
        Catch ex As Exception
            Validar = False
        End Try
    End Function

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Try
            If (txt_codigo.Text = String.Empty) Then
                MsgBox("Digite una codigo para eliminar el plato", MsgBoxStyle.Information, "Codigo")
                Exit Sub
            End If

            If (PreguntaRespuesta("Desea eliminar a " & txt_descripcion.Text & " ? ", "Confirmar") = MsgBoxResult.Yes) Then

                If (eliminar(plato) = False) Then
                    MsgBox("Hubo un error al eliminar el plato !", MsgBoxStyle.Critical, "Plato")
                Else
                    MsgBox("Plato eliminado :v ", MsgBoxStyle.Information, "Plato")
                    limpiar()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function eliminar(plato) As Boolean
        Try
            eliminar = False
            eliminar = platoNegocio.eliminar(plato)
        Catch ex As Exception
            eliminar = False
        End Try
    End Function

    Private Sub btn_buscaPlato_Click(sender As Object, e As EventArgs) Handles btn_buscaPlato.Click

        Try
            Dim frmBuscar As New frm_mantPlato
            auxUsuario.Id = 0
            frmBuscar.ShowDialog()
            plato = auxPlato
            cargarPlatoTexbox(plato)
            'auxUsuario.Id = 0
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub cargarPlatoTexbox(plato As Plato)

        txt_codigo.Text = plato.Codigo
        txt_descripcion.Text = plato.Descripcion
        txt_nombre.Text = plato.Nombre
        txt_precio.Text = Agregar_cero(plato.Precio.ToString())
        cmb_modalidad.SelectedValue = plato.Mod_id.ToString

        If (plato.Imagen Is Nothing) Then
            pb_foto.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory() & "img\image_defualt.jpg")
        Else
            pb_foto.Image = ByteArrayToImage(plato.Imagen)
        End If
    End Sub
    Private Function recuperaPlato(codigo As String) As Boolean
        Try
            recuperaPlato = False

            plato = platoNegocio.getPlato(codigo)
            cargarPlatoTexbox(plato)

            recuperaPlato = True
        Catch ex As Exception
            recuperaPlato = False
        End Try
    End Function

    Private Sub btn_imagen_Click(sender As Object, e As EventArgs) Handles btn_imagen.Click
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

    Private Sub txt_codigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_codigo.KeyPress
        Try
            If (Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9) Then

                If (recuperaPlato(txt_codigo.Text) = False) Then
                    MsgBox("El codigo no existe", MsgBoxStyle.Information)
                    limpiar()
                    txt_codigo.Focus()
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
End Class