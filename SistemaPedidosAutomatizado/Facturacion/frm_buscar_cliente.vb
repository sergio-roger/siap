Imports CapaEntidad
Imports CapaNegocio

Public Class frm_buscar_cliente

    Private clienteNegocio As New ClienteNegocio

    Private Function cargarCliente(texto As String) As Boolean
        Try
            cargarCliente = False
            Dim lista As New List(Of Cliente)

            lista = clienteNegocio.getClientes(texto)
            dgv_clientes.Rows.Clear()

            If (lista IsNot Nothing) Then
                For Each item In lista
                    dgv_clientes.Rows.Add(item.Id, item.Cedula, item.Nombre, item.Apellido, item.Direccion, item.Telefono, item.Correo)
                Next
            End If

            cargarCliente = True
        Catch ex As Exception
            cargarCliente = False
        End Try
    End Function

    Private Sub frm_buscar_cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If (cargarCliente("") = False) Then
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar.TextChanged
        Try
            If (cargarCliente(txt_buscar.Text) = False) Then
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_clientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_clientes.CellDoubleClick
        Try
            If e.RowIndex > -1 Then
                auxCliente.Id = dgv_clientes.Rows(e.RowIndex).Cells(0).Value
                auxCliente.Cedula = dgv_clientes.Rows(e.RowIndex).Cells(1).Value
                auxCliente.Nombre = dgv_clientes.Rows(e.RowIndex).Cells(2).Value
                auxCliente.Apellido = dgv_clientes.Rows(e.RowIndex).Cells(3).Value
                auxCliente.Direccion = dgv_clientes.Rows(e.RowIndex).Cells(4).Value
                auxCliente.Telefono = dgv_clientes.Rows(e.RowIndex).Cells(5).Value
                auxCliente.Correo = dgv_clientes.Rows(e.RowIndex).Cells(6).Value

                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class