Public Class frmSale

    Public mem_id As Integer
    Public mem__name As String
    Public mem_tel As String

    Private Sub frmSale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMem_id.Text = mem_id
        lblMem_name.Text = mem__name
        lblMem_tel.Text = mem_tel


    End Sub
End Class