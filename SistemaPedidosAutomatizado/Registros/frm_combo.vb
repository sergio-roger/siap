Imports CapaEntidad
Imports CapaNegocio

Public Class frm_combo

    Private combo As New Combo
    Private comboNegocio As New ComboNegocio
    Private titulo As String = "Combos"

    Private Function cargarCombo() As Boolean
        Try
            cargarCombo = False
            Dim lista As New ArrayList()

            lista = comboNegocio.getModalidades()

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
        End Try
    End Function

    Private Function validarDatos() As Boolean
        Try
            validarDatos = False

            If (txt_codigo.Text = String.Empty) Then
                MsgBox("Ingres un codigo !", MsgBoxStyle.Information, titulo)
                Exit Function
            End If

            If (txt_contenido1.Text = String.Empty) Then
                MsgBox("Ingrese contenido 1", MsgBoxStyle.Information, titulo)
                Exit Function
            End If

            If (txt_contenido2.Text = String.Empty) Then
                MsgBox("Ingrese contenido 2", MsgBoxStyle.Information, titulo)
                Exit Function
            End If

            If (txt_bebida.Text = String.Empty) Then
                MsgBox("Ingrese una bebida", MsgBoxStyle.Information, titulo)
                Exit Function
            End If

            If (txt_precio.MaskFull) Then
            Else
                mensaje(titulo, "Formato de precio ejemplo: 04,75 ", "alert")
                txt_precio.Focus()
                Exit Function
            End If
            validarDatos = True
        Catch ex As Exception
            validarDatos = False
        End Try
    End Function



    Private Sub Limpiar()
        txt_codigo.Text = ""
        txt_contenido1.Text = ""
        txt_contenido2.Text = ""
        txt_contenido3.Text = ""
        txt_bebida.Text = ""
        txt_precio.Text = ""
        txt_porcentaje.Text = ""
        txt_descripcion.Text = ""
        chk_descuento.Checked = False
        txt_porcentaje.ReadOnly = False
        combo.Id = 0
        auxCombo.Id = 0

        pb_foto.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory() & "img\image_defualt.jpg")
        panel_descuento.BackColor = Color.White
        lbl_porcentaje.BackColor = Color.White
        lbl_porcentaje.ForeColor = Color.Black
        txt_codigo.Focus()
    End Sub

    Private Sub Cahnge_desc()
        If (chk_descuento.Checked = True) Then
            panel_descuento.BackColor = Color.Black
            lbl_porcentaje.BackColor = Color.Black
            lbl_porcentaje.ForeColor = Color.White
            txt_porcentaje.ReadOnly = False
            txt_porcentaje.Focus()
        Else
            panel_descuento.BackColor = Color.White
            lbl_porcentaje.BackColor = Color.White
            lbl_porcentaje.ForeColor = Color.Black
            txt_porcentaje.ReadOnly = True
        End If
    End Sub

    Private Function crearCombo() As Combo
        Dim nuevo As New Combo

        nuevo.Id = IIf(combo.Id = 0, 0, combo.Id)
        nuevo.Id_modalidad = Integer.Parse(cmb_modalidad.SelectedValue.ToString)
        nuevo.Descripcion = txt_descripcion.Text
        nuevo.Elemento1 = txt_contenido1.Text
        nuevo.Elemento2 = txt_contenido2.Text
        nuevo.Elemento3 = txt_contenido3.Text
        nuevo.Bebida = txt_bebida.Text
        nuevo.Precio = txt_precio.Text
        nuevo.Foto = ImageToByteArray(pb_foto.Image)
        nuevo.Descuento = IIf(chk_descuento.Checked = True, True, False)

        If (chk_descuento.Checked = False) Then
            nuevo.Porcentaje = 0
        Else
            nuevo.Porcentaje = Integer.Parse(txt_porcentaje.Text)
        End If

        nuevo.Codigo = txt_codigo.Text
        nuevo.Fecha = date_fecha.Value.ToShortDateString
        nuevo.Estado = "A"

        Return nuevo
    End Function

    Private Function grabar() As Boolean
        Try
            grabar = False
            combo = crearCombo()
            grabar = comboNegocio.grabar(combo)

        Catch ex As Exception
            grabar = False
            'MsgBox(ex.Message)
        End Try
    End Function

    Private Sub frm_combo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pb_foto.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory() & "img\image_defualt.jpg")
        combo.Id = 0

        If (cargarCombo() = False) Then
            MsgBox("No se pudo carga los roles", MsgBoxStyle.Critical, titulo)
        End If
    End Sub

    Private Sub chk_descuento_CheckedChanged(sender As Object, e As EventArgs) Handles chk_descuento.CheckedChanged
        Cahnge_desc()
    End Sub

    Private Sub btn_buscaPCombo_Click(sender As Object, e As EventArgs) Handles btn_buscaPCombo.Click
        Try
            Dim frm As New frm_mantCombo
            frm.ShowDialog()
            combo = auxCombo
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_grabar_Click(sender As Object, e As EventArgs) Handles btn_grabar.Click
        Try
            If (validarDatos() = False) Then
                Exit Sub
            End If

            'Proceso para grabar
            If (grabar()) Then
                If (combo.Id = 0) Then
                    mensaje(titulo, "Datos registrados correctamente", "info")
                Else
                    mensaje(titulo, "Datos actualizados correctamente", "info")
                End If
            Else
                MsgBox("Hubo un error al insertar el registro", MsgBoxStyle.Critical, titulo)
            End If
            Limpiar()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        Limpiar()
    End Sub
End Class