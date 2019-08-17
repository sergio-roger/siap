Imports CapaEntidad
Imports CapaNegocio

Public Class frm_login

    Private Function Leer_archivo_conexion() As Boolean
        Try
            Leer_archivo_conexion = False

            Dim g_str_servidor As String
            Dim g_str_bd As String
            Dim g_str_usuario_bd As String
            Dim g_str_clave_bd As String

            Dim directorio = System.AppDomain.CurrentDomain.BaseDirectory & "Datos-coneccion.txt" 'Obtengo donde se encuentra el .exe
            Dim obj_leer As New IO.StreamReader(directorio)
            Dim vector_txt As New ArrayList()
            Dim linea_txt As String = ""

            Do
                linea_txt = obj_leer.ReadLine

                If (Not linea_txt Is Nothing) Then
                    vector_txt.Add(linea_txt)
                End If
            Loop Until linea_txt Is Nothing

            obj_leer.Close()
            Dim cadena As String = ""

            For Each linea_txt In vector_txt
                cadena = cadena & linea_txt
            Next

            Dim partes = cadena.Split(":")
            g_str_servidor = partes(1)
            g_str_bd = partes(3)
            g_str_usuario_bd = partes(5)
            g_str_clave_bd = partes(7)
            g_str_formatoFechaBd = partes(9)

            If (g_str_usuario_bd = "") Then
                'Conectar sin 
                str_coneccion = "Data Source=" & g_str_servidor & ";Initial Catalog=" & g_str_bd & ";Integrated Security=true;"
            Else
                'Conectar con clave
                str_coneccion = "Data Source=" & g_str_servidor & ";Initial Catalog=" & g_str_bd & ";User ID=" & g_str_usuario_bd & ";password=" & g_str_clave_bd
            End If

            Leer_archivo_conexion = True

        Catch ex As Exception
            Leer_archivo_conexion = False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function VerificaConexion() As Boolean
        Try
            Dim conexion As New ConexionNegocio()
            VerificaConexion = conexion.VerificarConexion(str_coneccion, g_str_formatoFechaBd)
        Catch ex As Exception
            VerificaConexion = False
            MsgBox(ex.Message)
        End Try
    End Function

    Function Validar() As Boolean
        Try
            Validar = False

            If txt_usuario.Text = "" Then
                MsgBox("Ingrese el usuario")
                txt_usuario.Focus()
                Exit Function
            End If

            If txt_clave.Text = "" Then
                MsgBox("Ingrese la clave del usuario")
                txt_clave.Focus()
                Exit Function
            End If

            Validar = True
        Catch ex As Exception
            Validar = False
        End Try
    End Function

    Function VerificarUsuario(ByVal usuario As String, ByVal clave As String) As Boolean
        Try
            VerificarUsuario = False

            Dim listaAux As New List(Of Usuario)
            Dim usuarioNegocio As New UsuarioNegocio()
            Dim n, i As Integer

            listaAux = usuarioNegocio.VerificarUsuario(usuario, clave)
            usuarioSeccion = listaAux.Item(0)
            n = listaAux.Count - 1

            'If n >= 0 Then
            '    For i = 0 To n
            '        g_str_nombreUsuario = listaAux.Item(i).Nombres
            '        g_int_perfil = listaAux.Item(i).Id_perfil
            '        g_int_Id_usuario = listaAux.Item(i).Id
            '    Next
            'End If

            VerificarUsuario = True
        Catch ex As Exception
            VerificarUsuario = False
        End Try
    End Function

    Sub Limpiar()
        txt_usuario.Text = ""
        txt_clave.Text = ""
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Application.ExitThread()
    End Sub

    Private Sub btn_iniciar_Click(sender As Object, e As EventArgs) Handles btn_iniciar.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            If VerificarUsuario(txt_usuario.Text, txt_clave.Text) = True Then
                Dim frm As New frm_principal()
                Me.Hide()
                'frm.int_perfil = g_int_perfil
                frm.Show()
            Else
                MsgBox("Clave de Acceso incorrecta")
                Limpiar()
                txt_usuario.Focus()
            End If

            'Dim miobj As New cls_CE_AccesoAlSistema
            'miobj.Usu_id = txt_usuario.Text
            'miobj.Usu_nombres = txt_clave.Text

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frm_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txt_usuario.Focus()

            If (Leer_archivo_conexion() = False) Then
                MsgBox("Error al cargar parametros de conexion, comunique al proveedor")
                Me.Dispose()
                Exit Sub
            End If

            If VerificaConexion() = False Then
                MsgBox("Error al conectar..")
            Else
                'MsgBox("OK al conectar..")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txt_usuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_usuario.KeyPress
        Try
            If (Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9) Then
                txt_clave.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txt_clave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_clave.KeyPress
        Try
            If (Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9) Then
                btn_iniciar_Click(Me, New KeyPressEventArgs(ChrW(Keys.Enter)))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class