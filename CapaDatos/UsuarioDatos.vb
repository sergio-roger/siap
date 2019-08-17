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

    Public Function getUsuario(cedula As String) As Usuario
        Try
            Dim usuario As New Usuario
            If (Conectar() = False) Then
                Exit Function
            End If

            Dim str_cadenaSql As String
            str_cadenaSql = "select *,
(select p.per_nombre from seg_Perfil p where p.per_id = s.per_Id) as perfil
from seg_Usuarios s where usu_estado = 'A' and usu_cedula = '" & cedula & "'"

            '2 hacer la tarea dentro de la BD
            dr = ExecuteReader(str_cadenaSql)

            If dr.HasRows Then
                While dr.Read
                    usuario.Id = dr("usu_id")
                    usuario.Cedula = dr("usu_cedula")
                    usuario.Nombres = dr("usu_nombres")
                    usuario.Apellidos = dr("usu_apellidos")
                    usuario.Id_perfil = dr("per_Id")
                    usuario.Perfil = dr("perfil")
                    usuario.Direccion = dr("usu_direccion")
                    usuario.Telefono = dr("usu_telefono")
                    usuario.Email = dr("usu_email")
                    usuario.Usuario = dr("usu_usuario")
                    usuario.Clave = dr("usu_clave")
                    'Hacer uso de las conversiones
                    usuario.Foto = IIf(dr("usu_foto") Is DBNull.Value, Nothing, dr("usu_foto"))
                    usuario.Estado = dr("usu_estado")
                End While
            Else
                usuario = Nothing
            End If
            Return usuario

        Catch ex As Exception
            getUsuario = Nothing
        Finally
            dr.Close()
            Desconectar()
        End Try
    End Function

    Public Function getUsuarios(buscar As String, opcion As String) As List(Of Usuario)
        getUsuarios = Nothing
        Try
            Dim lista As New List(Of Usuario)
            If Conectar() = False Then
                Exit Function
            End If

            dr = ExecuteReader("sp_busquedaUsuarios", buscar, opcion)

            If dr.HasRows Then
                While dr.Read
                    Dim usuario As New Usuario
                    usuario.Id = dr("usu_id")
                    usuario.Cedula = dr("usu_cedula")
                    usuario.Nombres = dr("usu_nombres")
                    usuario.Apellidos = dr("usu_apellidos")
                    usuario.Id_perfil = dr("per_Id")
                    usuario.Perfil = dr("perfil")
                    usuario.Direccion = dr("usu_direccion")
                    usuario.Telefono = dr("usu_telefono")
                    usuario.Email = dr("usu_email")
                    usuario.Usuario = dr("usu_usuario")
                    usuario.Clave = dr("usu_clave")
                    'Hacer uso de las conversiones
                    usuario.Foto = IIf(dr("usu_foto") Is DBNull.Value, Nothing, dr("usu_foto"))
                    usuario.Estado = dr("usu_estado")

                    lista.Add(usuario)
                End While
                Return lista
            End If
        Catch ex As Exception
            getUsuarios = Nothing
            MsgBox(ex.Message)
        Finally
            dr.Close()
            Desconectar()
        End Try
    End Function

    Public Function getListaPerfiles() As ArrayList
        Dim sql = "select per_id, per_nombre from seg_Perfil where per_estado='A' order by 2"
        Dim lista As New ArrayList()

        lista = CargarComboDesdeSql(sql)
        Return lista
    End Function
End Class
