Public Class Modalidad
    Private _id As Integer
    Private _descripcion As String
    Private _estado As String
    Private _horaInicio As Date
    Private _horaFin As Date

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

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property HoraInicio As Date
        Get
            Return _horaInicio
        End Get
        Set(value As Date)
            _horaInicio = value
        End Set
    End Property

    Public Property HoraFin As Date
        Get
            Return _horaFin
        End Get
        Set(value As Date)
            _horaFin = value
        End Set
    End Property
End Class
