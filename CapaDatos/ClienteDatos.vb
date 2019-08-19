Imports CapaEntidad

Public Class ClienteDatos

    Public Function procesarDatos(cliente As Cliente) As Boolean
        Try
            procesarDatos = False

            If (Conectar() = False) Then
                Exit Function
            End If

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
        End Try
    End Function
End Class
