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

    Public Function getCombos() As List(Of Combo)
        getCombos = Nothing
        Try
            Dim lista As New List(Of Combo)
            If (Conectar() = False) Then
                Exit Function
            End If

            Dim cadenasql As String = "select com_id, com_descripcion, com_precio,com_descuento, com_porcentaje, com_codigo from combo where com_estado = 'A' order by 2"

            dr = ExecuteReader(cadenasql)

            If (dr.HasRows) Then
                While (dr.Read)
                    Dim a As New Combo
                    a.Id = dr("com_id")
                    a.Descripcion = dr("com_descripcion")
                    a.Precio = dr("com_precio")
                    a.Descuento = dr("com_descuento")
                    a.Porcentaje = dr("com_porcentaje")
                    a.Codigo = dr("com_codigo")
                    lista.Add(a)
                End While
                Return lista
            End If
        Catch ex As Exception
            getCombos = Nothing
        Finally
            dr.Close()
            Desconectar()
        End Try
    End Function

    Public Function eliminar(combo As Combo) As Boolean

        Try
            eliminar = False

            If (Conectar() = False) Then
                Exit Function
            End If

            cmd = New SqlClient.SqlCommand("sp_eliminarRegistro", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@id", combo.Id)
            cmd.Parameters.AddWithValue("@tabla", "combo")

            cmd.ExecuteNonQuery()

            eliminar = True
        Catch ex As Exception
            eliminar = False
        End Try
    End Function

    Public Function getCombo(codigo As String) As Combo

        getCombo = Nothing
        Try
            Dim combo As New Combo
            If (Conectar() = False) Then
                Exit Function
            End If

            Dim str_cadenaSql As String
            str_cadenaSql = "select *,
(select m.mod_id from Modalidad m where m.mod_id= p.id_modalidad) as modalidad
From combo p Where com_estado ='A' and com_codigo like '" & codigo & "'"
            'select *,
            '(select m.mod_id from Modalidad m where m.mod_id= p.id_modalidad ) as modalidad
            ' From combo p Where com_estado ='A' and com_codigo like @buscar+'%'
            '2 hacer la tarea dentro de la BD
            dr = ExecuteReader(str_cadenaSql)

            If dr.HasRows Then
                While dr.Read
                    combo.Id = dr("com_id")
                    combo.Codigo = dr("com_codigo")
                    combo.Descripcion = dr("com_descripcion")
                    combo.Bebida = dr("com_bebida")
                    combo.Elemento1 = dr("com_elemento1")
                    combo.Elemento2 = dr("com_elemento2")
                    combo.Elemento3 = dr("com_elemento3")
                    combo.Precio = dr("com_precio")
                    combo.Descuento = dr("com_descuento")
                    combo.Porcentaje = dr("com_porcentaje")
                    combo.Estado = dr("com_estado")
                    combo.Foto = IIf(dr("com_imagen") Is DBNull.Value, Nothing, dr("com_imagen"))
                    'combo.Estado =

                    'Usuario.Id_perfil = dr("per_Id")
                    'Usuario.Perfil = dr("perfil")
                    'usuario.Direccion = dr("usu_direccion")
                    'usuario.Telefono = dr("usu_telefono")
                    'usuario.Email = dr("usu_email")
                    'usuario.Usuario = dr("usu_usuario")
                    'usuario.Clave = dr("usu_clave")
                    ''Hacer uso de las conversiones
                    'usuario.Foto = IIf(dr("usu_foto") Is DBNull.Value, Nothing, dr("usu_foto"))
                    'usuario.Estado = dr("usu_estado")
                End While
            Else
                combo = Nothing
            End If
            Return combo

        Catch ex As Exception
            getCombo = Nothing
        Finally
            dr.Close()
            Desconectar()
        End Try



    End Function

    Public Function getCombos(buscar As String, opcion As String) As List(Of Combo)
        getCombos = Nothing
        Try
            Dim lista As New List(Of Combo)
            If Conectar() = False Then
                Exit Function
            End If

            dr = ExecuteReader("sp_busquedaCombos", buscar, opcion)

            If dr.HasRows Then
                While dr.Read
                    Dim combo As New Combo
                    combo.Id = dr("com_id")
                    combo.Codigo = dr("com_codigo")
                    combo.Descripcion = dr("com_descripcion")
                    combo.Elemento1 = dr("com_elemento1")
                    combo.Elemento2 = dr("com_elemento2")
                    combo.Elemento3 = dr("com_elemento3")
                    combo.Id_modalidad = dr("id_modalidad")
                    combo.Modalidad = dr("modalidad")
                    combo.Bebida = dr("com_bebida")
                    combo.Precio = dr("com_precio")
                    combo.Descuento = dr("com_descuento")
                    combo.Porcentaje = dr("com_porcentaje")
                    combo.Estado = dr("com_estado")
                    combo.Foto = IIf(dr("com_imagen") Is DBNull.Value, Nothing, dr("com_imagen"))
                    lista.Add(combo)
                End While
                Return lista
            End If
        Catch ex As Exception
            getCombos = Nothing
            MsgBox(ex.Message)
        Finally
            dr.Close()
            Desconectar()
        End Try




    End Function
End Class
