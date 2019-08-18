Imports CapaEntidad

Public Class PlatoDatos
    Public Function procesarDatos(plato As Plato) As Boolean
        Try
            procesarDatos = False

            If (Conectar() = False) Then
                Exit Function
            End If
            cmd = New SqlClient.SqlCommand("sp_insertar_actualizar_plato", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", plato.Id)
            cmd.Parameters.AddWithValue("@pla_nombre", plato.Nombre)
            cmd.Parameters.AddWithValue("@mod_id", plato.Mod_id)
            cmd.Parameters.AddWithValue("@pla_precio", plato.Precio)
            cmd.Parameters.AddWithValue("@pla_estado", plato.Estado)
            cmd.Parameters.AddWithValue("@pla_descripcion", plato.Descripcion)
            cmd.Parameters.AddWithValue("@pla_imagen", plato.Imagen)
            cmd.Parameters.AddWithValue("@pla_codigo", plato.Codigo)
            cmd.Parameters.AddWithValue("@pla_fecha", plato.Fecha.ToShortDateString)

            cmd.ExecuteNonQuery()
            procesarDatos = True

        Catch ex As Exception
            procesarDatos = False
        Finally
            dr.Close()
            Desconectar()
        End Try
    End Function

    Public Function getPlato(codigo As String) As Plato
        getPlato = Nothing
        Try
            Dim plato As New Plato
            If (Conectar() = False) Then
                Exit Function
            End If

            Dim str_cadenaSql As String
            str_cadenaSql = "select *,
		(select m.mod_id from Modalidad m where m.mod_id= p.mod_id ) as modalidad
		 from plato p where pla_estado='A' and pla_codigo like '" & codigo & "'"


            '"select *,
            ' (select p.per_nombre from seg_Perfil p where p.per_id = s.per_Id) as perfil
            ' from seg_Usuarios s where usu_estado = 'A' and usu_cedula = '" & codigo & "'" ' arreglar la sentencia para la base de datos

            '2 hacer la tarea dentro de la BD
            dr = ExecuteReader(str_cadenaSql)

            If dr.HasRows Then
                While dr.Read
                    plato.Id = dr("pla_id")
                    plato.Nombre = dr("pla_nombre")
                    plato.Mod_id = dr("mod_id")
                    plato.Precio = dr("pla_precio")
                    plato.Descripcion = dr("pla_descripcion")
                    plato.Imagen = IIf(dr("pla_imagen") Is DBNull.Value, Nothing, dr("pla_imagen")) 'revisar en la base de datos 
                    plato.Estado = dr("pla_estado")

                End While
            Else
                plato = Nothing
            End If
            Return plato

        Catch ex As Exception
            getPlato = Nothing
        Finally
            dr.Close()
            Desconectar()
        End Try
    End Function

    Public Shared Function getplatos(buscar As String, opcion As String) As List(Of Plato)
        getplatos = Nothing
        Try
            Dim lista As New List(Of Plato)
            If Conectar() = False Then
                Exit Function
            End If

            dr = ExecuteReader("sp_busquedaPlatos", buscar, opcion)

            If dr.HasRows Then
                While dr.Read
                    Dim plato As New Plato
                    plato.Id = dr("pla_id")
                    plato.Nombre = dr("pla_nombre")
                    plato.Mod_id = dr("mod_id")
                    plato.Modalidad = dr("modalidad")
                    plato.Precio = dr("pla_precio")
                    plato.Estado = dr("pla_estado")
                    plato.Descripcion = dr("pla_descripcion")
                    plato.Imagen = IIf(dr("pla_imagen") Is DBNull.Value, Nothing, dr("pla_imagen"))
                    plato.Codigo = dr("pla_codigo")
                    lista.Add(plato)
                End While
                Return lista
            End If
        Catch ex As Exception
            getplatos = Nothing
            MsgBox(ex.Message)
        Finally
            dr.Close()
            Desconectar()
        End Try

    End Function

    Public Function eliminar(plato As Plato) As Boolean
        Try
            eliminar = False

            If (Conectar() = False) Then
                Exit Function
            End If

            cmd = New SqlClient.SqlCommand("sp_eliminarRegistro", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@id", plato.Id)
            cmd.Parameters.AddWithValue("@tabla", "platos")

            cmd.ExecuteNonQuery()

            eliminar = True
        Catch ex As Exception
            eliminar = False
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
