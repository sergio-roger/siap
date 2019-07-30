Public Class Menu
    Private _id As Integer
    Private _id_padre As Integer
    Private _descripcion As String
    Private _posicion As Integer
    Private _formAsociado As Boolean
    Private _nombreForm As String
    Private _estado As String

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Id_padre As Integer
        Get
            Return _id_padre
        End Get
        Set(value As Integer)
            _id_padre = value
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

    Public Property Posicion As Integer
        Get
            Return _posicion
        End Get
        Set(value As Integer)
            _posicion = value
        End Set
    End Property

    Public Property FormAsociado As Boolean
        Get
            Return _formAsociado
        End Get
        Set(value As Boolean)
            _formAsociado = value
        End Set
    End Property

    Public Property NombreForm As String
        Get
            Return _nombreForm
        End Get
        Set(value As String)
            _nombreForm = value
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
