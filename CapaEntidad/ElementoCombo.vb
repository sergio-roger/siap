Public Class ElementoCombo
    Private CodigoElemento As String
    Private TextoElemento As String

    Public Sub New(ByVal NuevoCodigo As String, ByVal NuevoTexto As String)
        CodigoElemento = NuevoCodigo
        TextoElemento = NuevoTexto
    End Sub

    Public ReadOnly Property Codigo() As String
        Get
            Return CodigoElemento
        End Get
    End Property

    Public ReadOnly Property Texto() As String
        Get
            Return TextoElemento
        End Get
    End Property
End Class