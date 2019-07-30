Imports System.Data.SqlClient
Imports CapaEntidad

Public Class DatosConexion
    Public dr As SqlDataReader

    'Constructor
    Public Sub New(ByVal cadena As String, ByVal formatoFecha As String)
        str_cadenaconexion = cadena
        g_str_formatoFecha = formatoFecha

    End Sub

    Public Sub New()
    End Sub

    Public Function VerificarConexion() As Boolean
        VerificarConexion = Conectar()
    End Function

    Public Function getMenuPrincipal(id_Perfil As Integer) As List(Of Menu)
        Try
            getMenuPrincipal = Nothing
            Dim lista As New List(Of Menu)
            Dim cadenasql As String = ""

            cadenasql = cadenasql & "select m.* from seg_menu m "
            cadenasql = cadenasql & "where men_estado = 'A'  and men_Id in "
            cadenasql = cadenasql & "(select men_Id from seg_accesos "
            cadenasql = cadenasql & " where per_id=" & id_Perfil & " and acc_estado='A')"

            If Conectar() = False Then
                Exit Function
            End If
            dr = ExecuteReader(cadenasql)

            If dr.HasRows Then
                While dr.Read
                    Dim objRegistro As New Menu
                    With objRegistro
                        .Men_Id = IIf(dr("men_ID") Is DBNull.Value, 0, dr("men_ID"))
                        .Men_Id_MenuPadre = IIf(dr("men_Id_MenuPadre") Is DBNull.Value, 0, dr("men_Id_MenuPadre"))
                        .Men_Descripcion = IIf(dr("men_Descripcion") Is DBNull.Value, "", dr("men_Descripcion"))
                        .Men_Posicion = IIf(dr("men_Posicion") Is DBNull.Value, 0, dr("men_Posicion"))
                        .Men_ForAsociado = IIf(dr("men_ForAsociado") Is DBNull.Value, 0, dr("men_ForAsociado"))
                        .Men_nombreFrm = IIf(dr("men_nombreFrm") Is DBNull.Value, "", dr("men_nombreFrm"))
                        .Men_estado = IIf(dr("men_estado") Is DBNull.Value, "", dr("men_estado"))
                    End With
                    lista.Add(objRegistro)
                End While
            End If
            Return lista
        Catch ex As Exception
            MsgBox(ex.Message)
            getMenuPrincipal = Nothing
        Finally
            dr.Close()
            Desconectar()
        End Try
    End Function

End Class
