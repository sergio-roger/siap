Public Class AuditoriaIngreso
    Private _id As Integer
    Private _id_usuario As Integer
    Private _id_perfil As Integer
    Private _id_factura As Integer
    Private _detalle As String
    Private _dinero As Double
    Private _fecha As Date
    Private _hora As Date
    Private _usuario As String
    Private _perfil As String

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

    Public Property Id_perfil As Integer
        Get
            Return _id_perfil
        End Get
        Set(value As Integer)
            _id_perfil = value
        End Set
    End Property

    Public Property Id_factura As Integer
        Get
            Return _id_factura
        End Get
        Set(value As Integer)
            _id_factura = value
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

    Public Property Detalle As String
        Get
            Return _detalle
        End Get
        Set(value As String)
            _detalle = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _usuario
        End Get
        Set(value As String)
            _usuario = value
        End Set
    End Property

    Public Property Perfil As String
        Get
            Return _perfil
        End Get
        Set(value As String)
            _perfil = value
        End Set
    End Property

    Public Property Dinero As Double
        Get
            Return _dinero
        End Get
        Set(value As Double)
            _dinero = value
        End Set
    End Property
End Class
