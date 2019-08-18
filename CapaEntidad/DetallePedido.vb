Public Class DetallePedido
    Private _id As Integer
    Private _id_Pedido As Integer
    Private _id_tipoComida As Integer
    Private _id_Comida As Integer
    Private _nombre As String
    Private _cantidad As Integer
    Private _precioUnitario As Double
    Private _descuento As Boolean
    Private _porcentaje As Integer
    Private _subtotal As Double
    Private _total As Double
    Private _estado As String

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Id_Pedido As Integer
        Get
            Return _id_Pedido
        End Get
        Set(value As Integer)
            _id_Pedido = value
        End Set
    End Property

    Public Property Id_tipoComida As Integer
        Get
            Return _id_tipoComida
        End Get
        Set(value As Integer)
            _id_tipoComida = value
        End Set
    End Property

    Public Property Id_Comida As Integer
        Get
            Return _id_Comida
        End Get
        Set(value As Integer)
            _id_Comida = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Cantidad As Integer
        Get
            Return _cantidad
        End Get
        Set(value As Integer)
            _cantidad = value
        End Set
    End Property

    Public Property PrecioUnitario As Double
        Get
            Return _precioUnitario
        End Get
        Set(value As Double)
            _precioUnitario = value
        End Set
    End Property

    Public Property Descuento As Boolean
        Get
            Return _descuento
        End Get
        Set(value As Boolean)
            _descuento = value
        End Set
    End Property

    Public Property Porcentaje As Integer
        Get
            Return _porcentaje
        End Get
        Set(value As Integer)
            _porcentaje = value
        End Set
    End Property

    Public Property Subtotal As Double
        Get
            Return _subtotal
        End Get
        Set(value As Double)
            _subtotal = value
        End Set
    End Property

    Public Property Total As Double
        Get
            Return _total
        End Get
        Set(value As Double)
            _total = value
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
