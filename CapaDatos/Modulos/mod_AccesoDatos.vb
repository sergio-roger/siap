Imports System.Data.SqlClient
Imports CapaEntidad

Module mod_AccesoDatos
    Public str_cadenaconexion As String

    Public cnn As SqlConnection
    Public cmd As SqlCommand
    Public cmd2 As SqlCommand
    Public dr As SqlDataReader
    Public g_str_formatoFecha As String

    Public Function Conectar() As Boolean
        Try
            Conectar = False
            cnn = New SqlConnection
            cnn.ConnectionString = str_cadenaconexion
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()
                Conectar = True

            End If
        Catch ex As Exception
            Conectar = False

        End Try
    End Function

    Public Function Desconectar() As Boolean
        Try
            Desconectar = False
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
                Desconectar = True

            End If
        Catch ex As Exception
            Desconectar = False
        End Try
    End Function

    Public Function ExecuteReader(ByVal str_consulta As String) As SqlDataReader
        Try
            cmd = New SqlCommand
            cmd.CommandText = str_consulta
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn
            Return cmd.ExecuteReader

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ExecuteNonQUery(ByVal cadena As String) As Boolean
        Try
            'insert/update/delete
            cmd = New SqlCommand
            cmd.CommandText = cadena
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function ExecuteReader(ByVal cadenasql As String, ByVal ParamArray parametro() As String) As SqlDataReader
        Try
            Dim i As Integer
            cmd = New SqlCommand
            cmd.CommandText = cadenasql
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            'cargar los parámetros
            SqlCommandBuilder.DeriveParameters(cmd) 'trae los parámetros
            For i = 1 To parametro.Length
                CType(cmd.Parameters(i), SqlParameter).Value = parametro(i - 1)
            Next
            Return cmd.ExecuteReader()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function ExecuteNonQuery(ByVal procedimiento As String, ByVal ParamArray parametro() As String) As Boolean
        Dim i As Integer
        Try
            'graba o actualiza
            cmd = New SqlCommand
            cmd.CommandText = procedimiento
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            'cargar los parametros
            SqlCommandBuilder.DeriveParameters(cmd) 'trae los parametros
            For i = 1 To parametro.Length
                CType(cmd.Parameters(i), SqlParameter).Value = parametro(i - 1)
            Next
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function iniciarTransaccion() As Boolean
        Try
            iniciarTransaccion = False
            Dim cadenasql As String
            cadenasql = "BEGIN TRAN miproceso"
            If ExecuteNonQUery(cadenasql) = True Then
                iniciarTransaccion = True
            Else
                MsgBox("No se Pudo Iniciar la Transaccion")
                iniciarTransaccion = False
            End If
        Catch ex As Exception
            iniciarTransaccion = False
        End Try
    End Function

    Public Function commit() As Boolean
        Try
            commit = False
            Dim cadenasql As String
            cadenasql = "COMMIT TRAN miproceso"

            If ExecuteNonQUery(cadenasql) = True Then
                commit = True
            End If
        Catch ex As Exception
            commit = False
        End Try
    End Function

    Public Function rolbak() As Boolean
        Try
            rolbak = False
            Dim cadenasql As String
            cadenasql = "ROLLBACK TRAN miproceso"
            If ExecuteNonQUery(cadenasql) = True Then
                rolbak = True
            End If
        Catch ex As Exception
            rolbak = False
        End Try
    End Function

    Public Function CargarComboDesdeSql(ByVal LaSQL As String) As ArrayList
        Dim Lista As New ArrayList
        CargarComboDesdeSql = Nothing

        Try
            If (Conectar() = False) Then
                Exit Function
            End If

            dr = ExecuteReader(LaSQL)

            If (dr.HasRows) Then
                While dr.Read
                    Lista.Add(New ElementoCombo(dr.GetValue(0).ToString, dr.GetValue(1).ToString))
                End While
            End If

            Return Lista

        Catch ex As Exception
            CargarComboDesdeSql = Nothing
            'MessageBox.Show(ex.Message, "Metodo CargarComboDesdeSql", MessageBoxButtons.OK)
        Finally
            dr.Close()
            Desconectar()
        End Try

    End Function
End Module
