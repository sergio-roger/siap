Imports CapaEntidad
Imports CapaNegocio

Public Class frm_modalidad_aux
    Private modalidad As New Modalidad()
    Private modalidadNegocio As New ModalidadNegocio()

    Private Function CargarModalidad() As Boolean
        Try
            Dim lista As List(Of Modalidad)
            modalidad.Id = 0
            CargarModalidad = False
            lista = modalidadNegocio.getListaModalidad()
            dgv_modalidad.Rows.Clear()

            For Each item In lista
                dgv_modalidad.Rows.Add(item.Id, item.Descripcion, item.HoraInicio.ToShortTimeString, item.HoraFin.ToShortTimeString, item.Estado)
            Next
            CargarModalidad = True

        Catch ex As Exception
            CargarModalidad = False
        End Try
    End Function

    Private Function ValidarDatos() As Boolean
        Try
            ValidarDatos = False

            If (txt_descripcion.Text = "") Then
                MsgBox("Ingrese una modalidad", MsgBoxStyle.Information, "Modalidad")
                txt_descripcion.Focus()
                Exit Function
            End If

            If (date_hora_empieza.Value.ToShortTimeString.Equals("0:00")) Then
                MsgBox("Ingrese hora de inicio diferente a 0:00")
                Exit Function
            End If

            ValidarDatos = True
        Catch ex As Exception
            ValidarDatos = False
            MsgBox(ex.Message)
        End Try
    End Function

    Public Sub Limpiar()
        'modalidad.Id = 0
        txt_descripcion.Text = ""
        date_hora_empieza.Value = Date.Parse("00:00")
        date_hora_termina.Value = Date.Parse("00:00")
        txt_descripcion.Focus()
    End Sub

    Private Function crearModalidad() As Modalidad
        Dim nuevo As New Modalidad()

        If (modalidad.Id <> 0) Then
            nuevo.Id = modalidad.Id
        End If
        nuevo.Descripcion = txt_descripcion.Text
        nuevo.HoraInicio = date_hora_empieza.Value
        nuevo.HoraFin = date_hora_termina.Value
        nuevo.Estado = "A"

        Return nuevo
    End Function

    Private Function Grabar() As Boolean
        Try

            Grabar = False
            Dim nuevo As Modalidad = crearModalidad()
            Grabar = modalidadNegocio.guardar(nuevo)

            Grabar = True

        Catch ex As Exception
            Grabar = False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub btn_grabar_Click(sender As Object, e As EventArgs) Handles btn_grabar.Click
        Try
            If (ValidarDatos() = False) Then
                Exit Sub
            End If

            'Proceso para grabar
            If (Grabar()) Then

                If (modalidad.Id = 0) Then
                    MsgBox("Modalidad registrados correctamente", MsgBoxStyle.Information, "Modalidad")
                Else
                    MsgBox("Modalidad actualizada", MsgBoxStyle.Information, "Actualizado")
                End If
                Limpiar()

                If (CargarModalidad() = False) Then
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frm_modalidad_aux_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CargarModalidad() = False Then
            MsgBox("No se pudo cargar")
        End If
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        Limpiar()
    End Sub

    Private Sub dgv_modalidad_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_modalidad.CellDoubleClick
        Try
            Dim aux As New Modalidad()

            If e.RowIndex > -1 Then
                modalidad.Id = dgv_modalidad.Rows(e.RowIndex).Cells(0).Value
                modalidad.Descripcion = dgv_modalidad.Rows(e.RowIndex).Cells(1).Value
                'modalidad.HoraInicio = dgv_modalidad.Rows(e.RowIndex).Cells(2).Value
                Dim hora_empieza As String = String.Format(dgv_modalidad.Rows(e.RowIndex).Cells(2).Value.ToString, "HH:mm:ss")
                Dim hora_termina As String = String.Format(dgv_modalidad.Rows(e.RowIndex).Cells(3).Value.ToString, "HH:mm:ss")
                modalidad.Estado = dgv_modalidad.Rows(e.RowIndex).Cells(4).Value

                date_hora_empieza.Value = Date.Parse(hora_empieza)
                date_hora_termina.Value = Date.Parse(hora_termina)

                'MsgBox("ID: " & modalidad.Id)
                txt_descripcion.Text = modalidad.Descripcion
                date_hora_empieza.Value = modalidad.HoraFin.ToShortTimeString
                date_hora_termina.Value = modalidad.HoraFin.ToShortTimeString
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Try
            If (modalidad.Id = 0) Then
                MsgBox("Elija una modalidad de la tabla para eliminar")
                Exit Sub
            End If

            If (modalidadNegocio.Eliminar(modalidad) = True) Then
                If CargarModalidad() = False Then
                    MsgBox("No se pudo cargar")
                End If

                MsgBox("Modalidad Eliminada", MsgBoxStyle.Information, "Modalidad")
            Else
                MsgBox("Hubo un error al eliminar", MsgBoxStyle.Critical, "Modalidad")
            End If
            Limpiar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_modalidad_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_modalidad.CellContentClick

    End Sub
End Class