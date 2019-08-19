Public Class Factura
 |   Private _id As Integer
    Private _id_usuario As Integer
    Private _id_cliente As Integer
    Private _id_pedido As Integer
    Private _fecha As Date
    Private _hora As Date
    Private _subtotal As Double
    Private _descuento As Double
    Private _total As Double

    Public Property Id_usuario As Integer
        Get
            Return _id_usuario
        End Get
        Set(value As Integer)
            _id_usuario = value
        End Set
    End Property

    Public Property Id_cliente As Integer
        Get
            Return _id_cliente
        End Get
        Set(value As Integer)
            _id_cliente = value
        End Set
    End Property

    Public Property Id_pedido As Integer
        Get
            Return _id_pedido
        End Get
        Set(value As Integer)
            _id_pedido = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _fecha
        End Get
        Set(value As Date)
            _fecha = value
        End Set
    End Property

    Public Property Hora As Date
        Get
            Return _hora
        End Get
        Set(value As Date)
            _hora = value
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

    Public Property Descuento As Double
        Get
            Return _descuento
        End Get
        Set(value As Double)
            _descuento = value
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
End Class
