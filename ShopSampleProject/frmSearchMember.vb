Imports System.Data.SqlClient

Public Class frmSearchMember

    Dim DB As DBClass = New DBClass
    Dim Conn As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim action As String
    Dim sql As String
    Dim rs As Integer
    Dim mem_id As Integer
    Dim mem_name As String
    Dim mem_tel As String

    Private Sub ShowData()
        Dim sql As String = "SELECT * FROM tb_member"

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
                .Columns(1).HeaderText = "ชื่อลูกค้า"
                .Columns(2).HeaderText = "ที่อยู่"
                .Columns(3).HeaderText = "เบอร์โทร"


                .Columns(0).Width = 50
                .Columns(1).Width = 100
                .Columns(1).Width = 100
                .Columns(1).Width = 100
            End If
        End With
    End Sub
    Private Sub frmSearchMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conn = DB.ConnectDB()

        ShowData()
        FormatDataGridView()
    End Sub

    Private Sub dgvData_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseUp
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        With dgvData
            mem_id = .Rows.Item(e.RowIndex).Cells(0).Value.ToString()
            mem_name = .Rows.Item(e.RowIndex).Cells(1).Value.ToString()
            mem_tel = .Rows.Item(e.RowIndex).Cells(3).Value.ToString()

            lblMem_name.Text = mem_name

        End With
    End Sub

    Private Sub btnMember_Click(sender As Object, e As EventArgs) Handles btnMember.Click
        frmMember.ShowDialog()
        ShowData()
        FormatDataGridView()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        frmSale.mem_id = mem_id
        frmSale.mem__name = mem_name
        frmSale.mem_tel = mem_tel
        frmSale.Show()
        Me.Hide()



    End Sub
End Class