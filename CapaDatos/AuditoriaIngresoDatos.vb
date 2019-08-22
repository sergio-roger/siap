Imports CapaEntidad

Public Class AuditoriaIngresoDatos

    Public Function getDatos() As List(Of AuditoriaIngreso)
        getDatos = Nothing

        Try
            If (Conectar() = False) Then
                Exit Function
            End If
            Dim lista As New List(Of AuditoriaIngreso)
            dr = ExecuteReader("sp_listar_Audioria_Ingresos")

            If dr.HasRows Then
                While dr.Read
                    Dim audi As New AuditoriaIngreso

                    audi.Id = dr("aud_id")
                    audi.Detalle = dr("aud_detalle")
                    audi.Usuario = dr("usuario")
                    audi.Perfil = dr("perfil")
                    audi.Id_factura = dr("fac_id")
                    audi.Dinero = dr("aud_dinero")
                    audi.Fecha = dr("fecha")
                    audi.Hora = CDate(dr("hora").ToString)

                    lista.Add(audi)
                End While
                Return lista
            End If

        Catch ex As Exception
            getDatos = Nothing
        Finally
            dr.Close()
        End Try
    End Function

    Public Function guardar(objeto As AuditoriaIngreso) As Boolean
        Try
            guardar = False

            If (Conectar() = False) Then
                Exit Function
            End If

            cmd = New SqlClient.SqlCommand("sp_insertar_auditoria_ingresos", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@aud_detalle", objeto.Detalle)
            cmd.Parameters.AddWithValue("@usu_id", objeto.Id_usuario)
            cmd.Parameters.AddWithValue("@usu_fecha", objeto.Fecha.ToShortDateString)
            cmd.Parameters.AddWithValue("@usu_hora", objeto.Hora.ToShortTimeString)
            cmd.Parameters.AddWithValue("@fac_id", objeto.Id_factura)
            cmd.Parameters.AddWithValue("@aud_dinero", objeto.Dinero)
            cmd.Parameters.AddWithValue("@per_id", objeto.Id_perfil)

            cmd.ExecuteNonQuery()
            guardar = True
        Catch ex As Exception
            guardar = False
        End Try
    End Function
End Class
