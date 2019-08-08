Imports CapaEntidad
Imports CapaNegocio

Public Class frm_plato
    Dim platoNegocio As New PlatoNegocio
    Dim plato As New Plato
    Private Sub frm_plato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargar_combo_modalidad()
            plato.Id = 0
            pb_foto.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory() & "img\image_defualt.jpg")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function creaplato() As Plato
        Dim plato As New Plato()
        plato.Codigo = txt_codigo.Text
        plato.Nombre = txt_nombre.Text
        plato.Precio = txt_precio.Text
        plato.Descripcion = txt_descripcion.Text

        plato.Estado = "A"
        Return plato
    End Function
    Private Function grabar() As Boolean
        Try
            grabar = False

            plato = creaplato()

            If (plato.Id = 0) Then
                'aqui va a insertar

                If (platoNegocio.crearPlato(plato) = False) Then
                    MsgBox("No se pudo crear el plato", MsgBoxStyle.Critical, "Mesa")
                Else
                    MsgBox("plato registrado", MsgBoxStyle.Information, "Mesa")
                End If

            Else
                'aqui actualiza
                If (platoNegocio.actualizarPlato(plato) = False) Then
                    MsgBox("No se pudo actualizar el plato", MsgBoxStyle.Exclamation, "Mesa")
                Else
                    MsgBox("Plato Actualizado", MsgBoxStyle.Information, "Mesa")
                End If
            End If

            limpiar()
            grabar = True
        Catch ex As Exception
            grabar = False
        End Try
    End Function
    Sub limpiar()
        txt_nombre.Text = ""
        txt_descripcion.Text = ""
        txt_precio.Text = ""
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click

    End Sub

    Private Sub btn_grabar_Click(sender As Object, e As EventArgs) Handles btn_grabar.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If
            If grabar() = False Then
                Exit Sub
            End If



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
            If (txt_precio.Text = "" Or txt_precio.Text.Length = 0 Or txt_precio Is Nothing) Then
                MsgBox("¡Ingrese un precio !", MsgBoxStyle.Information, "plato")
                txt_precio.Focus()
                Exit Function
            End If
            Validar = True
        Catch ex As Exception
            Validar = False
        End Try


    End Function
    Function cargar_combo_modalidad() As Boolean
        Try
            cargar_combo_modalidad = False
            Dim lista As New ArrayList()

            lista = platoNegocio.getListaModalidad()

            With cmb_modalidad
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .DataSource = lista
                .ValueMember = "Codigo"
                .DisplayMember = "Texto"
            End With
            cargar_combo_modalidad = True

        Catch ex As Exception
            cargar_combo_modalidad = False
            'MsgBox(ex.Message)
        End Try
    End Function
End Class