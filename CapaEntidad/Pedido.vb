Public Class Pedido
    Private _id As Integer
    Private _id_usuario As Integer
    Private _id_estadoPedido As Integer
    Private _id_mesa As Integer
    Private _estado As String
    Private _observacion As String

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Id_usuario As Integer
        Get
            Return _id_usuario
        End Get
        Set(value As Integer)
            _id_usuario = value
        End Set
    End Property

    Public Property Id_estadoPedido As Integer
        Get
            Return _id_estadoPedido
        End Get
        Set(value As Integer)
            _id_estadoPedido = value
        End Set
    End Property

    Public Property Id_mesa As Integer
        Get
            Return _id_mesa
        End Get
        Set(value As Integer)
            _id_mesa = value
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

    Public Property Observacion As String
        Get
            Return _observacion
        End Get
        Set(value As String)
            _observacion = value
        End Set
    End Property
End Class
