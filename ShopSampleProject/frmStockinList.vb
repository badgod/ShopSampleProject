Imports System.Data.SqlClient

Public Class frmStockinList

    Dim frm As Form
    Dim DB As DBClass = New DBClass
    Dim Conn As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim action As String
    Dim sql As String
    Dim rs As Integer

    Private Sub ShowData()
        Dim sql As String = "SELECT
                                tb_invoice.invoice_id, 
                                tb_vendor.vendor_name, 
                                tb_invoice.invoice_number, 
                                tb_invoice.invoice_date,
                                tb_invoice.invoice_count,
                                tb_invoice.invoice_total 
                            FROM 
                                tb_invoice, tb_vendor 
                            WHERE 
                                tb_invoice.vendor_id = tb_vendor.vendor_id"
        com = New SqlCommand

        With com
            .CommandType = CommandType.Text
            .CommandText = sql
            .Connection = Conn
            dr = .ExecuteReader()

            If dr.HasRows Then
                dt = New DataTable()
                dt.Load(dr)
                dgvData.DataSource = dt
            Else
                dgvData.DataSource = Nothing
            End If
        End With

        dr.Close()
    End Sub

    Private Sub FormatDataGridView()

        With dgvData
            If .RowCount > 0 Then
                .Columns(0).HeaderText = "รหัส"
                .Columns(1).HeaderText = "คู่ค้า"
                .Columns(2).HeaderText = "เลขที่"
                .Columns(3).HeaderText = "วันที่"
                .Columns(4).HeaderText = "จำนวน"
                .Columns(5).HeaderText = "รวม"


                .Columns(0).Width = 50
                .Columns(1).Width = 100
                .Columns(2).Width = 100
                .Columns(3).Width = 100
                .Columns(4).Width = 100
                .Columns(5).Width = 100

            End If
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frm = New frmStockin
        frm.Show()
    End Sub

    Private Sub frmStockinList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conn = DB.ConnectDB()

        ShowData()
        FormatDataGridView()

    End Sub
End Class