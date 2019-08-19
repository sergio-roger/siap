Public Class EstadoPedido
    Private _id As Integer
    Private _decripcion As String
    Private _clave As String
    Private _estado As String

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Decripcion As String
        Get
            Return _decripcion
        End Get
        Set(value As String)
            _decripcion = value
        End Set
    End Property

    Public Property Clave As String
        Get
            Return _clave
        End Get
        Set(value As String)
            _clave = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property
End Class
