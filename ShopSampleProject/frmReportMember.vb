Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmReportMember
    Dim DB As DBClass = New DBClass
    Dim Conn As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim action As String
    Dim sql As String
    Dim rs As Integer

    Private Sub frmReportMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conn = DB.ConnectDB()

        Dim dtt As New DataTable()

        sql = "SELECT * FROM tb_member"

        com = New SqlCommand(sql, Conn)
        Dim da = New SqlDataAdapter(com)
        da.Fill(dtt)
        rptViewer.SetDisplayMode(DisplayMode.PrintLayout)
        rptViewer.LocalReport.DataSources.Clear()
        Dim rpts As New ReportDataSource("DataSetMember", dtt)
        rptViewer.LocalReport.DataSources.Add(rpts)
        rptViewer.RefreshReport()

    End Sub
End Class