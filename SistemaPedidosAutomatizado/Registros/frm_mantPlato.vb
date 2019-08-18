Imports CapaEntidad
Imports CapaNegocio

Public Class frm_mantPlato

    Private platoNegocio As New PlatoNegocio
    Private titulo As String = "Mantenimiento Plato"

    Private Sub frm_mantPlato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmb_opcion.SelectedValue = "codigo"
            ' cmb_opcion.ValueMember = "apellidos"

            If buscarPlatos("", "codigo") = False Then
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function buscarPlatos(buscar As String, opcion As String) As Boolean
        Try
            buscarPlatos = False
            Dim lista As New List(Of Plato)

            lista = platoNegocio.getPlatos(buscar, opcion)
            dgv_platos.Rows.Clear()

            If (lista IsNot Nothing) Then
                For Each item In lista
                    If (item.Imagen Is Nothing) Then
                        dgv_platos.Rows.Add(item.Id, item.Codigo, item.Nombre, item.Mod_id, item.Modalidad, item.Precio, item.Descripcion, Nothing, item.Estado)
                    Else
                        Dim img = ByteArrayToImage(item.Imagen)
                        dgv_platos.Rows.Add(item.Id, item.Codigo, item.Nombre, item.Mod_id, item.Modalidad, item.Precio, item.Descripcion, img, item.Estado)

                    End If
                Next
            End If
        Catch ex As Exception
            buscarPlatos = False
            'MsgBox(ex.Message)
        End Try
    End Function

    Private Sub txt_buscar_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar.TextChanged
        Try
            'cmb_opcion.SelectedValue = "apellidos"

            If (cmb_opcion.SelectedItem Is Nothing) Then
                mensaje(titulo, "Seleccione una opcion ", "info")
                txt_buscar.Text = ""
                Exit Sub
            End If

            If buscarPlatos(txt_buscar.Text, cmb_opcion.SelectedItem) = False Then
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgv_platos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_platos.CellDoubleClick
        Try
            If e.RowIndex > -1 Then
                'g_str_cedula = dgv_usuarios.Rows(e.RowIndex).Cells(0).Value
                auxPlato.Id = dgv_platos.Rows(e.RowIndex).Cells(0).Value
                auxPlato.Codigo = dgv_platos.Rows(e.RowIndex).Cells(1).Value()
                auxPlato.Nombre = dgv_platos.Rows(e.RowIndex).Cells(2).Value()
                auxPlato.Mod_id = Integer.Parse(dgv_platos.Rows(e.RowIndex).Cells(3).Value())
                auxPlato.Modalidad = dgv_platos.Rows(e.RowIndex).Cells(4).Value()
                auxPlato.Precio = Double.Parse(dgv_platos.Rows(e.RowIndex).Cells(5).Value())
                auxPlato.Descripcion = dgv_platos.Rows(e.RowIndex).Cells(6).Value()

                If (dgv_platos.Rows(e.RowIndex).Cells(7).Value() Is Nothing) Then
                    auxPlato.Imagen = Nothing
                Else
                    Dim img As Byte()
                    img = ImageToByteArray(dgv_platos.Rows(e.RowIndex).Cells(7).Value())
                    auxPlato.Imagen = img
                End If
                auxPlato.Estado = dgv_platos.Rows(e.RowIndex).Cells(8).Value()
            End If
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class