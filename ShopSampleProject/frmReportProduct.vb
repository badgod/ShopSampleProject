Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmReportProduct
    Dim DB As DBClass = New DBClass
    Dim Conn As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim action As String
    Dim sql As String
    Dim rs As Integer

    Private Sub frmReportProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conn = DB.ConnectDB()

        Dim sql As String = "SELECT * FROM tb_producttype"

        com = New SqlCommand

        With com
            .CommandType = CommandType.Text
            .CommandText = sql
            .Connection = Conn
            dr = .ExecuteReader()

            If dr.HasRows Then
                dt = New DataTable()
                dt.Load(dr)

                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "ทุกประเภท"
                dt.Rows.InsertAt(row, 0)

                With cboProtype_id
                    .DisplayMember = "protype_name"
                    .ValueMember = "protype_id"
                    .DataSource = dt
                End With

            End If
        End With

        dr.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conn = DB.ConnectDB()

        Dim dtt As New DataTable()
        Dim imgpath As String = My.Application.Info.DirectoryPath & "\productimage\"

        If cboProtype_id.SelectedValue = 0 Then
            sql = "SELECT tb_product.*, tb_producttype.protype_name FROM tb_product INNER JOIN tb_producttype ON tb_product.protype_id = tb_producttype.protype_id"
        Else
            sql = "SELECT tb_product.*, tb_producttype.protype_name FROM tb_product INNER JOIN tb_producttype ON tb_product.protype_id = tb_producttype.protype_id AND tb_product.protype_id = " & cboProtype_id.SelectedValue
        End If

        com = New SqlCommand(sql, Conn)
        Dim da = New SqlDataAdapter(com)
        da.Fill(dtt)
        rptReport.SetDisplayMode(DisplayMode.PrintLayout)
        rptReport.LocalReport.DataSources.Clear()
        Dim rpts As New ReportDataSource("DataSetProduct", dtt)
        rptReport.LocalReport.DataSources.Add(rpts)
        rptReport.LocalReport.SetParameters(New ReportParameter("p_protype_name", cboProtype_id.Text))
        rptReport.RefreshReport()

    End Sub
End Class