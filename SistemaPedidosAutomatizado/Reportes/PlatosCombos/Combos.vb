Public Class Combos

    Public fecha_inicio As String
    Public fecha_fin As String

    Private Sub Combos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rpt As New rpt_combos

        Dim formato As String = "yyyy/MM/dd"

        'MsgBox(Format(fecha_inicio, formato))

        rpt.SetParameterValue("@fecha_ini", CDate(fecha_inicio).ToShortDateString)
        rpt.SetParameterValue("@fecha_fin", CDate(fecha_fin).ToShortDateString)

        cryCombo.ReportSource = rpt
    End Sub
End Class