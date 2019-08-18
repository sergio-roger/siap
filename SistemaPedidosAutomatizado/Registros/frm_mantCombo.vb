Imports CapaEntidad
Imports CapaNegocio
Public Class frm_mantCombo
    Dim combonegocio As New ComboNegocio
    Private titulo As String = "Mantenimiento Combo"
    Private Sub frm_mantCombo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmb_opcion.SelectedValue = "Codigo"
            ' cmb_opcion.ValueMember = "apellidos"

            If buscarCombos("", "codigo") = False Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Function buscarCombos(buscar As String, opcion As String) As Boolean
        Try
            buscarCombos = False
            Dim lista As New List(Of Combo)

            lista = ComboNegocio.getCombos(buscar, opcion)
            dgv_combos.Rows.Clear()

            If (lista IsNot Nothing) Then
                For Each item In lista
                    If (item.Foto Is Nothing) Then
                        dgv_combos.Rows.Add(item.Id, item.Codigo, item.Descripcion, item.Elemento1, item.Elemento2, item.Elemento3, item.Id_modalidad, item.Modalidad, item.Bebida, item.Precio, item.Descuento, item.Porcentaje, item.Estado, Nothing)
                    Else
                        Dim img = ByteArrayToImage(item.Foto)
                        dgv_combos.Rows.Add(item.Id, item.Codigo, item.Descripcion, item.Elemento1, item.Elemento2, item.Elemento3, item.Id_modalidad, item.Modalidad, item.Bebida, item.Precio, item.Descuento, item.Porcentaje, item.Estado, img)

                    End If
                Next
            End If
        Catch ex As Exception
            buscarCombos = False
            'MsgBox(ex.Message)
        End Try
    End Function

    Private Sub txt_buscar_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar.TextChanged
        Try
            'cmb_opcion.SelectedValue = "apellidos"
            If (cmb_opcion.SelectedItem Is Nothing) Then
                mensaje(titulo, "Elija una opcion", "info")
                txt_buscar.Text = ""
                Exit Sub
            End If

            If buscarCombos(txt_buscar.Text, cmb_opcion.SelectedItem) = False Then
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgv_combos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_combos.CellContentClick

    End Sub

    Private Sub dgv_combos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_combos.CellDoubleClick
        Try
            If e.RowIndex > -1 Then
                'g_str_cedula = dgv_usuarios.Rows(e.RowIndex).Cells(0).Value
                auxCombo.Id = dgv_combos.Rows(e.RowIndex).Cells(0).Value
                auxCombo.Codigo = dgv_combos.Rows(e.RowIndex).Cells(1).Value()
                auxCombo.Descripcion = dgv_combos.Rows(e.RowIndex).Cells(2).Value()
                auxCombo.Elemento1 = dgv_combos.Rows(e.RowIndex).Cells(3).Value()
                auxCombo.Elemento2 = dgv_combos.Rows(e.RowIndex).Cells(4).Value()
                auxCombo.Elemento3 = dgv_combos.Rows(e.RowIndex).Cells(5).Value()
                auxCombo.Id_modalidad = dgv_combos.Rows(e.RowIndex).Cells(6).Value()
                auxCombo.Bebida = dgv_combos.Rows(e.RowIndex).Cells(8).Value()
                auxCombo.Precio = Double.Parse(dgv_combos.Rows(e.RowIndex).Cells(9).Value())

                If (dgv_combos.Rows(e.RowIndex).Cells(10).Value() = False) Then
                    auxCombo.Descuento = False
                Else
                    auxCombo.Descuento = True
                End If

                auxCombo.Porcentaje = Double.Parse(dgv_combos.Rows(e.RowIndex).Cells(11).Value())
                auxCombo.Estado = dgv_combos.Rows(e.RowIndex).Cells(12).Value()

                If (dgv_combos.Rows(e.RowIndex).Cells(13).Value() Is Nothing) Then
                    auxCombo.Foto = Nothing
                Else
                    Dim img As Byte()
                    img = ImageToByteArray(dgv_combos.Rows(e.RowIndex).Cells(13).Value())
                    auxCombo.Foto = img
                End If

                End If
                Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class