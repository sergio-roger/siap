Imports CapaEntidad

Public Class ComboDatos

    Public Function getModalidades() As ArrayList
        Dim sql = "select mod_id,mod_descripcion from Modalidad where mod_estado = 'A' order by 2"
        Dim lista As New ArrayList()

        lista = CargarComboDesdeSql(sql)
        Return lista
    End Function

    Public Function procesarDatos(combo As Combo) As Boolean
        Try
            procesarDatos = False

            If (Conectar() = False) Then
                Exit Function
            End If

            cmd = New SqlClient.SqlCommand("sp_inserta_actualiza_combos", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@id", combo.Id)
            cmd.Parameters.AddWithValue("@id_modalidad", combo.Id_modalidad)
            cmd.Parameters.AddWithValue("@com_codigo", combo.Codigo)
            cmd.Parameters.AddWithValue("@com_descripcion", combo.Descripcion)
            cmd.Parameters.AddWithValue("@com_elemento1", combo.Elemento1)
            cmd.Parameters.AddWithValue("@com_elemento2", combo.Elemento2)
            cmd.Parameters.AddWithValue("@com_elemento3", combo.Elemento3)
            cmd.Parameters.AddWithValue("@com_bebida", combo.Bebida)
            cmd.Parameters.AddWithValue("@com_precio", combo.Precio)
            cmd.Parameters.AddWithValue("@com_estado", combo.Estado)
            cmd.Parameters.AddWithValue("@com_imagen", combo.Foto)
            cmd.Parameters.AddWithValue("@com_descuento", combo.Descuento)
            cmd.Parameters.AddWithValue("@com_porcentaje", combo.Porcentaje)
            cmd.Parameters.AddWithValue("@fecha", combo.Fecha)
            cmd.ExecuteNonQuery()

            procesarDatos = True
        Catch ex As Exception
            procesarDatos = False
        End Try
    End Function
End Class
