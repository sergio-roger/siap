Imports CapaEntidad

Public Class Combo
    Private _id As Integer
    Private _id_modalidad As Integer
    Private _codigo As String
    Private _descripcion As String
    Private _elemento1 As String
    Private _elemento2 As String
    Private _elemento3 As String
    Private _bebida As String
    Private _precio As Double
    Private _foto As Byte()
    Private _descuento As Boolean
    Private _porcentaje As Integer
    Private _fecha As Date
    Private _modalidad As String
    Private _estado As String

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property

    Public Shared Function getDatoCombos() As List(Of Combo)
        Throw New NotImplementedException()
    End Function

    Public Property Elemento1 As String
        Get
            Return _elemento1
        End Get
        Set(value As String)
            _elemento1 = value
        End Set
    End Property

    Public Property Elemento2 As String
        Get
            Return _elemento2
        End Get
        Set(value As String)
            _elemento2 = value
        End Set
    End Property

    Public Property Elemento3 As String
        Get
            Return _elemento3
        End Get
        Set(value As String)
            _elemento3 = value
        End Set
    End Property

    Public Property Bebida As String
        Get
            Return _bebida
        End Get
        Set(value As String)
            _bebida = value
        End Set
    End Property

    Public Property Precio As Double
        Get
            Return _precio
        End Get
        Set(value As Double)
            _precio = value
        End Set
    End Property

    Public Property Foto As Byte()
        Get
            Return _foto
        End Get
        Set(value As Byte())
            _foto = value
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

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property Codigo As String
        Get
            Return _codigo
        End Get
        Set(value As String)
            _codigo = value
        End Set
    End Property

    Public Property Id_modalidad As Integer
        Get
            Return _id_modalidad
        End Get
        Set(value As Integer)
            _id_modalidad = value
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

    Public Property Modalidad As String
        Get
            Return _modalidad
        End Get
        Set(value As String)
            _modalidad = value
        End Set
    End Property
End Class
