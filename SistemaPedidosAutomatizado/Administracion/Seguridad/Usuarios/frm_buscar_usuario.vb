Imports CapaEntidad
Imports CapaNegocio

Public Class frm_buscar_usuario
    Dim usuarioNegocio As New UsuarioNegocio

    Function buscarUsuario(buscar As String, opcion As String) As Boolean
        Try
            buscarUsuario = False
            Dim lista As New List(Of Usuario)

            lista = usuarioNegocio.getUsuarios(buscar, opcion)
            dgv_usuarios.Rows.Clear()

            If (lista IsNot Nothing) Then
                For Each item In lista
                    If (item.Foto Is Nothing) Then
                        dgv_usuarios.Rows.Add(item.Id, item.Cedula, item.Apellidos, item.Nombres, item.Id_perfil, item.Direccion, item.Telefono, item.Email, item.Usuario, item.Clave, Nothing, item.Perfil, item.Estado)
                    Else
                        Dim img = ByteArrayToImage(item.Foto)
                        dgv_usuarios.Rows.Add(item.Id, item.Cedula, item.Apellidos, item.Nombres, item.Id_perfil, item.Direccion, item.Telefono, item.Email, item.Usuario, item.Clave, img, item.Perfil, item.Estado)
                    End If
                Next
            End If
        Catch ex As Exception
            buscarUsuario = False
            'MsgBox(ex.Message)
        End Try
    End Function

    Private Sub frm_buscar_usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmb_opcion.SelectedValue = "apellidos"

            If buscarUsuario("", "apellidos") = False Then
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txt_buscar_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar.TextChanged
        Try
            'cmb_opcion.SelectedValue = "apellidos"

            If buscarUsuario(txt_buscar.Text, cmb_opcion.SelectedItem) = False Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgv_usuarios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_usuarios.CellDoubleClick
        Try
            If e.RowIndex > -1 Then
                'g_str_cedula = dgv_usuarios.Rows(e.RowIndex).Cells(0).Value
                auxUsuario.Id = dgv_usuarios.Rows(e.RowIndex).Cells(0).Value
                auxUsuario.Cedula = dgv_usuarios.Rows(e.RowIndex).Cells(1).Value()
                auxUsuario.Apellidos = dgv_usuarios.Rows(e.RowIndex).Cells(2).Value()
                auxUsuario.Nombres = dgv_usuarios.Rows(e.RowIndex).Cells(3).Value()
                auxUsuario.Id_perfil = dgv_usuarios.Rows(e.RowIndex).Cells(4).Value()
                auxUsuario.Direccion = dgv_usuarios.Rows(e.RowIndex).Cells(5).Value()
                auxUsuario.Telefono = dgv_usuarios.Rows(e.RowIndex).Cells(6).Value()
                auxUsuario.Email = dgv_usuarios.Rows(e.RowIndex).Cells(7).Value()
                auxUsuario.Usuario = dgv_usuarios.Rows(e.RowIndex).Cells(8).Value()
                auxUsuario.Clave = dgv_usuarios.Rows(e.RowIndex).Cells(9).Value()

                If (dgv_usuarios.Rows(e.RowIndex).Cells(10).Value() Is Nothing) Then
                    auxUsuario.Foto = Nothing
                Else
                    Dim img As Byte()
                    img = ImageToByteArray(dgv_usuarios.Rows(e.RowIndex).Cells(10).Value())
                    auxUsuario.Foto = img
                End If

                auxUsuario.Perfil = dgv_usuarios.Rows(e.RowIndex).Cells(11).Value()
                auxUsuario.Estado = dgv_usuarios.Rows(e.RowIndex).Cells(12).Value()

                Me.Close()
                End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class