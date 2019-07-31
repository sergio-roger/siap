Module Helper
    Public Function PreguntaRespuesta(mensaje As String, titulo As String) As MsgBoxResult

        Dim respuesta As MsgBoxResult = Nothing
        Dim style As MsgBoxStyle

        Try
            style = MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo
            respuesta = MsgBox(mensaje, style, titulo)

            Return respuesta
        Catch ex As Exception
            respuesta = MsgBoxResult.No
            Return respuesta
        End Try
    End Function


End Module
