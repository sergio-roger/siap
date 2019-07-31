Imports CapaEntidad
Imports CapaNegocio

Public Class frm_mesa
    Private mesaNegocio As New MesaNegocio()
    Private mesa As New Mesa

    Private Function crearMesa() As Mesa
        Dim mesa As New Mesa()

        mesa.Nombre = txt_descripcion.Text
        mesa.Cantidad = txt_asientos.Text
        mesa.Estado = "A"

        Return mesa
    End Function

    Private Function Validar() As Boolean

        Try
            Validar = False

            If (txt_asientos.Text = "" Or txt_asientos.Text.Length = 0 Or txt_asientos Is Nothing) Then
                MsgBox("Ingrese cantidad de asientos !", MsgBoxStyle.Information, "Mesas")
                txt_asientos.Focus()
                Exit Function
            End If

            If (txt_descripcion.Text = "" Or txt_descripcion.Text.Length = 0 Or txt_descripcion Is Nothing) Then
                MsgBox("Ingrese una descripción !", MsgBoxStyle.Information, "Mesas")
                txt_descripcion.Focus()
                Exit Function
            End If

            Validar = True
        Catch ex As Exception
            Validar = False
        End Try

    End Function

    Private Sub Limpiar()
        txt_id.Text = ""
        txt_asientos.Text = ""
        txt_descripcion.Text = ""
        mesa.Id = 0
        txt_asientos.Focus()
    End Sub

    Private Function grabar() As Boolean
        Try
            grabar = False
            mesa = crearMesa()

            If (mesa.Id = 0) Then
                'Aki va a insertar
                If (mesaNegocio.crearMesa(mesa) = False) Then
                    MsgBox("No se pudo crear la mesa", MsgBoxStyle.Critical, "Mesa")
                Else
                    MsgBox("Mesa guardada", MsgBoxStyle.Information, "Mesa")
                End If
            Else
                'Aki va a actualiar
                If (mesaNegocio.actualizarMesa(mesa) = False) Then
                    MsgBox("No se pudo actualizar la mesa !", MsgBoxStyle.Exclamation, "Mesa")
                Else
                    MsgBox("Registro actualizado !", MsgBoxStyle.Information, "Mesa")
                End If
            End If

            Limpiar()
            grabar = True
        Catch ex As Exception
            grabar = False
        End Try
    End Function

    Private Sub cargarMesas()
        Dim lista As New List(Of Mesa)

        lista = mesaNegocio.getListaMesas()
        dgv_mesas.Rows.Clear()

        If (lista IsNot Nothing) Then
            For Each item In lista
                dgv_mesas.Rows.Add(item.Id, item.Cantidad, item.Nombre, item.Estado)
            Next
        End If
    End Sub

    Private Function eliminar() As Boolean
        Try
            eliminar = False
            'Cargar el objeto mesa en los txt
            If (mesa.Id > 0) Then
                txt_asientos.Text = mesa.Cantidad
                txt_descripcion.Text = mesa.Nombre
            End If

            'Pregunta si realmente desea eliminar
            If (PreguntaRespuesta("Desea eliminar a " & txt_descripcion.Text & " ? ", "Confirmar") = MsgBoxResult.Yes) Then

                eliminar = mesaNegocio.eliminar(mesa)
                Limpiar()
            End If

        Catch ex As Exception
            eliminar = False
        End Try
    End Function

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        Limpiar()
    End Sub

    Private Sub btn_grabar_Click(sender As Object, e As EventArgs) Handles btn_grabar.Click
        Try
            If (Validar() = False) Then
                Exit Sub
            End If

            If (grabar() = False) Then
                Exit Sub
            End If

            cargarMesas()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Try
            If (Validar() = False) Then
                Exit Sub
            End If

            If (eliminar() = False) Then
                Exit Sub
            Else
                Limpiar()
                MsgBox("Mesa eliminada !", MsgBoxStyle.Information, "Mesa")
            End If

            cargarMesas()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_mesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mesa.Id = 0

            cargarMesas()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_mesas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_mesas.CellDoubleClick
        'Cargar el objeto mesa
        Try
            If e.RowIndex > -1 Then
                'Limpiar()
                mesa.Id = dgv_mesas.Rows(e.RowIndex).Cells(0).Value
                mesa.Cantidad = dgv_mesas.Rows(e.RowIndex).Cells(1).Value
                mesa.Nombre = dgv_mesas.Rows(e.RowIndex).Cells(2).Value
                mesa.Estado = dgv_mesas.Rows(e.RowIndex).Cells(3).Value

                txt_id.Text = mesa.Id
                txt_asientos.Text = mesa.Cantidad
                txt_descripcion.Text = mesa.Nombre
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class