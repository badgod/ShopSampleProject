Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmMember2
    Dim DB As DBClass = New DBClass
    Dim Conn As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim action As String
    Dim sql As String
    Dim rs As Integer

    Private Sub frmMember2_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conn = DB.ConnectDB()

        Dim dtt As New DataTable()

        sql = "SELECT * FROM tb_member WHERE mem_id = " & TextBox1.Text

        com = New SqlCommand(Sql, Conn)
        Dim da = New SqlDataAdapter(com)
        da.Fill(dtt)
        rptReport.SetDisplayMode(DisplayMode.PrintLayout)
        rptReport.LocalReport.DataSources.Clear()
        Dim rpts As New ReportDataSource("DataSetMember", dtt)
        rptReport.LocalReport.DataSources.Add(rpts)
        rptReport.RefreshReport()
    End Sub
End Class