Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text.RegularExpressions

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

    Public Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Return Image.FromStream(ms)
    End Function

    Public Function ImageToByteArray(ByVal imageIn As Image) As Byte()
        Dim ms As New MemoryStream()
        imageIn.Save(ms, ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

End Module
