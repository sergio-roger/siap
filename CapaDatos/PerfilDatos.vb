Imports CapaEntidad

Public Class PerfilDatos

    Public Function getListaPerfil() As List(Of Perfil)
        getListaPerfil = Nothing

        Try
            Dim str_cadenaSql As String
            Dim lista As New List(Of Perfil)

            str_cadenaSql = "select * from seg_Perfil where per_estado = 'A'"

            '1 conectar a la BD
            If Conectar() = False Then
                Exit Function
            End If

            '2 hacer la tarea dentro de la BD
            dr = ExecuteReader(str_cadenaSql)

            If dr.HasRows Then
                While dr.Read
                    Dim perfil As New Perfil()

                    perfil.Id = dr("per_id")
                    perfil.Nombre = dr("per_nombre")
                    perfil.Descripcion = dr("per_descripcion")
                    perfil.Estado = dr("per_estado")

                    lista.Add(perfil)
                End While
                Return lista
            End If

        Catch ex As Exception
            getListaPerfil = Nothing
        End Try
    End Function

    Public Function eliminar(perfil As Perfil) As Boolean
        Try
            eliminar = False

            If (Conectar() = False) Then
                Exit Function
            End If

            cmd = New SqlClient.SqlCommand("sp_eliminarRegistro", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@id", perfil.Id)
            cmd.Parameters.AddWithValue("@tabla", "perfiles")

            cmd.ExecuteNonQuery()

            eliminar = True
        Catch ex As Exception
            eliminar = False
        End Try
    End Function

    Public Function procesarDatos(perfil As Perfil) As Boolean
        Try
            procesarDatos = False

            If (Conectar() = False) Then
                Exit Function
            End If

            cmd = New SqlClient.SqlCommand("sp_inserta_actualiza_perfil", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@per_id", perfil.Id)
            cmd.Parameters.AddWithValue("@per_nombre", perfil.Nombre)
            cmd.Parameters.AddWithValue("@per_descipcion", perfil.Descripcion)
            cmd.Parameters.AddWithValue("@per_estado", perfil.Estado)

            cmd.ExecuteNonQuery()
            procesarDatos = True
        Catch ex As Exception
            procesarDatos = False
        Finally
            Desconectar()
        End Try
    End Function
End Class
