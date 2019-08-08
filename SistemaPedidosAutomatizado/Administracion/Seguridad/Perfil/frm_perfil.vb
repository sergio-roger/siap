Imports CapaEntidad
Imports CapaNegocio

Public Class frm_perfil
    Private perfil As New Perfil()
    Private perfilNegocio As New PerfilNegocio()

    Private Function CargarPerfiles() As Boolean
        Try
            Dim lista As List(Of Perfil)
            perfil.Id = 0
            CargarPerfiles = False
            lista = perfilNegocio.getListaPerfil()
            dgv_datos.Rows.Clear()

            For Each item In lista
                dgv_datos.Rows.Add(item.Id, item.Nombre, item.Descripcion, item.Estado)
            Next
            CargarPerfiles = True

        Catch ex As Exception
            CargarPerfiles = False
        End Try
    End Function

    Private Sub Limpiar()

        txt_buscar.Text = ""
        txt_descripcion.Text = ""
        txt_buscar.Focus()
        perfil.Id = 0
    End Sub

    Private Function ValidarDatos() As Boolean
        Try
            ValidarDatos = False

            If (txt_buscar.Text = "") Then
                MsgBox("Ingrese un nombre de perfil", MsgBoxStyle.Information, "Perfil")
                txt_buscar.Focus()
                Exit Function
            End If

            If (txt_descripcion.Text = "") Then
                MsgBox("Ingrese una descripcion ", MsgBoxStyle.Information, "Descripcion")
                txt_descripcion.Focus()
                Exit Function
            End If

            'If (ExistePerfil(txt_buscar.Text)) Then
            'Dim cond1 As String = "per_nombre = '" & txt_buscar.Text & "' "
            'Dim cond2 As String = "per_estado = 'A' "

            'If (ExisteDato("seg_Perfil", cond1, cond2, "per_nombre", txt_buscar.Text) And id_perfil = 0) Then
            '    MsgBox("El perfil ya se encuentra registrado", MsgBoxStyle.Exclamation, "Perfil")
            '    Limpiar()
            '    Exit Function
            'End If

            ValidarDatos = True
        Catch ex As Exception
            ValidarDatos = False
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function crearPerfil() As Perfil
        Dim nuevo As New Perfil()

        If (perfil.Id <> 0) Then
            nuevo.Id = perfil.Id
        End If

        nuevo.Nombre = StrConv(txt_buscar.Text, VbStrConv.Lowercase)
        nuevo.Descripcion = txt_descripcion.Text
        nuevo.Estado = "A"

        Return nuevo
    End Function

    Private Function Grabar() As Boolean
        Try

            Grabar = False
            Dim nuevo As Perfil = crearPerfil()

            Grabar = perfilNegocio.guardar(nuevo)
            'cmd = New SqlClient.SqlCommand("sp_inserta_actualiza_perfil", cnn)
            'cmd.CommandType = CommandType.StoredProcedure

            'cmd.Parameters.AddWithValue("@per_id", id_perfil)
            'cmd.Parameters.AddWithValue("@per_nombre", nombre)
            'cmd.Parameters.AddWithValue("@per_descipcion", txt_descripcion.Text)
            'cmd.Parameters.AddWithValue("@per_estado", "A")

            'cmd.ExecuteNonQuery()
            Grabar = True

        Catch ex As Exception
            Grabar = False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub frm_perfil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CargarPerfiles() = False Then
            MsgBox("No se pudo cargar")
        End If
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click

    End Sub

    Private Sub btn_grabar_Click(sender As Object, e As EventArgs) Handles btn_grabar.Click
        Try
            If (ValidarDatos() = False) Then
                Exit Sub
            End If

            'Proceso para grabar
            If (Grabar()) Then

                If (perfil.Id = 0) Then
                    MsgBox("Perfil registrados correctamente", MsgBoxStyle.Information, "Registrado")
                Else
                    MsgBox("Perfil actualizado", MsgBoxStyle.Information, "Actualizado")
                End If
                Limpiar()

                If (CargarPerfiles() = False) Then
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgv_datos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_datos.CellContentClick

    End Sub

    Private Sub dgv_datos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_datos.CellDoubleClick
        Try

            If e.RowIndex > -1 Then
                perfil.Id = dgv_datos.Rows(e.RowIndex).Cells(0).Value
                perfil.Nombre = dgv_datos.Rows(e.RowIndex).Cells(1).Value
                perfil.Descripcion = dgv_datos.Rows(e.RowIndex).Cells(2).Value
                perfil.Estado = dgv_datos.Rows(e.RowIndex).Cells(3).Value

                txt_buscar.Text = perfil.Nombre
                txt_descripcion.Text = perfil.Descripcion
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Try
            If (perfil.Id = 0) Then
                MsgBox("Elija un perfil de la tabla para eliminar")
                Exit Sub
            End If

            If (perfilNegocio.Eliminar(perfil) = True) Then
                If CargarPerfiles() = False Then
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
End Class