Imports System.Data.SqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim DB As DBClass = New DBClass

        Dim Conn As SqlConnection = DB.ConnectDB
        Dim dr As SqlDataReader
        Dim dt As DataTable
        Dim com As SqlCommand

        MsgBox(Conn.State)

        Dim sql As String = "SELECT * FROM tb_user"

        com = New SqlCommand

        With com
            .CommandType = CommandType.Text
            .CommandText = sql
            .Connection = Conn
            dr = .ExecuteReader()

            If dr.HasRows Then
                dt = New DataTable()
                dt.Load(dr)
                DataGridView1.DataSource = dt
            Else
                MessageBox.Show("ไม่พบข้อมูล", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End With

        dr.Close()

    End Sub
End Class
