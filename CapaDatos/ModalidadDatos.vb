Imports CapaEntidad

Public Class ModalidadDatos
    Public Function getListaModalidad() As List(Of Modalidad)
        getListaModalidad = Nothing

        Try
            Dim str_cadenaSql As String
            Dim lista As New List(Of Modalidad)

            str_cadenaSql = "select * from Modalidad where mod_estado = 'A'"

            '1 conectar a la BD
            If Conectar() = False Then
                Exit Function
            End If

            '2 hacer la tarea dentro de la BD
            dr = ExecuteReader(str_cadenaSql)

            If dr.HasRows Then
                While dr.Read
                    Dim modalidad As New Modalidad()

                    modalidad.Id = dr("mod_id")
                    modalidad.Descripcion = dr("mod_descripcion")
                    modalidad.Estado = dr("mod_estado")
                    Dim hora_empieza As String = String.Format(dr("mod_hora_empieza").ToString, "HH:mm:ss")
                    Dim hora_termina As String = String.Format(dr("mod_hora_termina").ToString, "HH:mm:ss")

                    modalidad.HoraInicio = Date.Parse(hora_empieza)
                    modalidad.HoraFin = Date.Parse(hora_termina)
                    lista.Add(modalidad)
                End While
                Return lista
            End If

        Catch ex As Exception
            getListaModalidad = Nothing
        End Try
    End Function

    Public Function eliminar(modalidad As Modalidad) As Boolean
        Try
            eliminar = False

            If (Conectar() = False) Then
                Exit Function
            End If

            cmd = New SqlClient.SqlCommand("sp_eliminarRegistro", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@id", modalidad.Id)
            cmd.Parameters.AddWithValue("@tabla", "modalidades")

            cmd.ExecuteNonQuery()

            eliminar = True
        Catch ex As Exception
            eliminar = False
        End Try
    End Function

    Public Function guardar(nuevo As Modalidad) As Boolean
        Try
            guardar = False

            If (Conectar() = False) Then
                Exit Function
            End If

            cmd = New SqlClient.SqlCommand("sp_insertar_modalidad", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@mod_id", nuevo.Id)
            cmd.Parameters.AddWithValue("@mod_descripcion", nuevo.Descripcion)
            cmd.Parameters.AddWithValue("@mod_hora_empieza", nuevo.HoraInicio.ToShortTimeString)
            cmd.Parameters.AddWithValue("@mod_hora_termina", nuevo.HoraFin.ToShortTimeString)
            cmd.Parameters.AddWithValue("@mod_estado", nuevo.Estado)

            cmd.ExecuteNonQuery()

            guardar = True
        Catch ex As Exception
            guardar = False
        End Try
    End Function
End Class
