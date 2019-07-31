Imports CapaEntidad

Public Class MesaDatos

    Public Function procesarMesa(mesa As Mesa) As Boolean
        'Esta funcion va a crear y actualizar las mesas

        Try
            procesarMesa = False

            If (Conectar() = False) Then
                Exit Function
            End If

            cmd = New SqlClient.SqlCommand("sp_CrearActualizarMesa", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@id", mesa.Id)
            cmd.Parameters.AddWithValue("@nombre", mesa.Nombre)
            cmd.Parameters.AddWithValue("@cantidad", mesa.Cantidad)
            cmd.Parameters.AddWithValue("@estado", mesa.Estado)
            cmd.ExecuteNonQuery()
            procesarMesa = True

        Catch ex As Exception
            procesarMesa = False
        Finally
            Desconectar()
        End Try
    End Function

    Public Function eliminar(mesa As Mesa) As Boolean
        Try
            eliminar = False

            If (Conectar() = False) Then
                Exit Function
            End If

            If (mesa.Id > 0) Then
                cmd = New SqlClient.SqlCommand("sp_eliminarRegistro", cnn)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@id", mesa.Id)
                cmd.Parameters.AddWithValue("@tabla", "mesas")

                cmd.ExecuteNonQuery()
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            eliminar = False
        Finally
            Desconectar()
        End Try
    End Function

    Public Function getListaMesas() As List(Of Mesa)
        getListaMesas = Nothing

        Try
            Dim lista As New List(Of Mesa)

            If (Conectar() = False) Then
                Exit Function
            End If

            dr = ExecuteReader("sp_ListarMesas")

            If dr.HasRows Then
                While dr.Read
                    Dim mesa As New Mesa()

                    mesa.Id = dr("mesa_id")
                    mesa.Nombre = dr("mesa_nombre")
                    mesa.Cantidad = dr("mesa_cantidadA")
                    mesa.Estado = dr("mesa_estado")

                    lista.Add(mesa)
                End While
                Return lista
            End If

        Catch ex As Exception
            getListaMesas = Nothing
        Finally
            dr.Close()
            Desconectar()
        End Try
    End Function
End Class
