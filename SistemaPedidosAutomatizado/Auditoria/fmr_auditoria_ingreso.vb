Imports CapaEntidad
Imports CapaNegocio

Public Class fmr_auditoria_ingreso
    Private auditoria As New AuditoriaIngresoNegocio

    Private Function cargarDatos() As Boolean
        Try
            cargarDatos = False
            Dim lista As New List(Of AuditoriaIngreso)

            lista = auditoria.getDatos()

            If (lista.Count > 0) Then
                dgv_datos.Rows.Clear()

                For Each item In lista
                    dgv_datos.Rows.Add(item.Id, item.Detalle, item.Usuario, item.Perfil, item.Id_factura, item.Dinero, item.Fecha.ToShortDateString, item.Hora.ToShortTimeString)
                Next
                cargarDatos = True
            Else
                cargarDatos = False
            End If
        Catch ex As Exception
            cargarDatos = False
        End Try
    End Function

    Private Sub fmr_auditoria_ingreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If (cargarDatos() = False) Then
                mensaje("Error", "No se ha cargado los datos", "danger")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class