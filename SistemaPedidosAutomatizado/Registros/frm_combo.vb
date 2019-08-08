Public Class frm_combo

    Private Sub frm_combo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pb_foto.Image = Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory() & "img\image_defualt.jpg")
    End Sub
End Class