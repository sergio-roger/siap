Imports CapaEntidad

Public Class UsuarioDatos

    Public Function VerificarUsuario(usuario As String, clave As String) As List(Of Usuario)
        VerificarUsuario = Nothing
        Dim listaUsuarios As New List(Of Usuario)

        Try
            Dim str_cadenaSql As String = ""

            str_cadenaSql = "select usu_nombres,usu_apellidos,per_id,usu_id from seg_usuarios where usu_usuario='" & usuario & "' and usu_clave='" & clave & "'"
            '1 conectar a la BD

            If Conectar() = False Then
                Exit Function
            End If

            '2 hacer la tarea dentro de la BD
            dr = ExecuteReader(str_cadenaSql)

            If dr.HasRows Then
                While dr.Read
                    Dim objUsuario As New Usuario

                    objUsuario.Id = dr("usu_id")
                    objUsuario.Id_perfil = dr("per_id")
                    objUsuario.Nombres = dr("usu_nombres") & " " & dr("usu_apellidos")

                    'cargar a la lista
                    listaUsuarios.Add(objUsuario)
                End While
            End If
            Return listaUsuarios
        Catch ex As Exception
            VerificarUsuario = Nothing
            MsgBox(ex.Message)
        Finally
            dr.Close()
            '3 desconectar la BD
            Desconectar()
        End Try
    End Function
End Class
