Imports CapaEntidad

Public Class PlatoDatos
    Public Function ProcesarPlato(plato As Plato) As Boolean
        Try
            ProcesarPlato = False

            If (Conectar() = False) Then
                Exit Function
            End If
            cmd = New SqlClient.SqlCommand("sp_CrearActualizarPlato", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@id", plato.Id)
            cmd.Parameters.AddWithValue("@nombre", plato.Nombre)
            cmd.Parameters.AddWithValue("@precio", plato.Precio)
            cmd.Parameters.AddWithValue("@estado", plato.Estado)
            cmd.Parameters.AddWithValue("@id_mod", plato.Mod_id)

            cmd.ExecuteNonQuery()
            ProcesarPlato = True

        Catch ex As Exception
            ProcesarPlato = False
        Finally
            dr.Close()
            Desconectar()
        End Try
    End Function

    Public Function getListaModalidad2() As ArrayList
        Dim sql = "select mod_id , mod_descripcion from Modalidad where mod_estado = 'A' order by 2"
        Dim lista As New ArrayList()

        lista = CargarComboDesdeSql(sql)
        Return lista
    End Function

    Public Function getListaModalidad() As ArrayList
        Dim sql = "select mod_id , mod_descripcion from Modalidad where mod_estado = 'A' order by 2"
        Dim lista As New ArrayList()

        lista = CargarComboDesdeSql(sql)
        Return lista
    End Function
End Class
