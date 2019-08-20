Imports CapaEntidad

Public Class ClienteDatos

    Public Function procesarDatos(cliente As Cliente) As Boolean
        Try
            procesarDatos = False

            If (Conectar() = False) Then
                Exit Function
            End If
            '[sp_inserta_actualiza_cliente]

            cmd = New SqlClient.SqlCommand("sp_inserta_actualiza_cliente", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@id", cliente.Id)
            cmd.Parameters.AddWithValue("@cli_nombre", cliente.Nombre)
            cmd.Parameters.AddWithValue("@cli_apellido", cliente.Apellido)
            cmd.Parameters.AddWithValue("@cli_cedula", cliente.Cedula)
            cmd.Parameters.AddWithValue("@cli_direccion", cliente.Direccion)
            cmd.Parameters.AddWithValue("@cli_telefono", cliente.Telefono)
            cmd.Parameters.AddWithValue("@cli_correo", cliente.Correo)

            cmd.ExecuteNonQuery()

            procesarDatos = True
        Catch ex As Exception
            procesarDatos = False
        Finally
            dr.Close()
        End Try
    End Function

    Public Function getClients(texto As String) As List(Of Cliente)
        Try
            getClients = Nothing

            If Conectar() = False Then
                Exit Function
            End If
            Dim lista As New List(Of Cliente)
            dr = ExecuteReader("sp_listar_clientes", texto)

            If dr.HasRows Then
                While dr.Read
                    Dim cliente As New Cliente

                    cliente.Id = dr("cli_id")
                    cliente.Nombre = dr("cli_nombre")
                    cliente.Apellido = dr("cli_apellido")
                    cliente.Cedula = dr("cli_cedula")
                    cliente.Direccion = dr("cli_direccion")
                    cliente.Telefono = dr("cli_telefono")
                    cliente.Correo = dr("cli_correo")
                    lista.Add(cliente)
                End While
                Return lista
            End If
        Catch ex As Exception
            dr.Close()
            getClients = Nothing
        End Try
    End Function

    Public Function getCliente(cedula As String) As Cliente
        getCliente = Nothing
        Try
            Dim c As New Cliente
            If (Conectar() = False) Then
                Exit Function
            End If

            Dim sql As String = "select *  from Cliente c  where c.cli_cedula='" & cedula & "'  order by c.cli_id desc"
            dr = ExecuteReader(sql)

            If (dr.HasRows) Then
                While (dr.Read)
                    c.Id = dr("cli_id")
                    c.Cedula = dr("cli_cedula")
                    c.Nombre = dr("cli_nombre")
                    c.Apellido = dr("cli_apellido")
                    c.Direccion = dr("cli_direccion")
                    c.Telefono = dr("cli_telefono")
                    c.Correo = dr("cli_correo")
                End While
                Return c
            Else
                Return Nothing
            End If

        Catch ex As Exception
            getCliente = Nothing

        End Try
    End Function
End Class
