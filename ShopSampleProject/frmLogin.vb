Imports System.Data.SqlClient

Public Class frmLogin

    Dim DB As DBClass = New DBClass
    Dim Conn As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim action As String
    Dim sql As String
    Dim rs As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conn = DB.ConnectDB()

        If txtUser_username.Text.Trim() = "" Or txtUser_password.Text.Trim() = "" Then
            MessageBox.Show("กรอกข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUser_username.Focus()
            Exit Sub
        End If


        sql = "SELECT * FROM tb_user WHERE user_username = '" + txtUser_username.Text.Trim() + "' AND user_password = '" + txtUser_password.Text.Trim() + "'"

        com = New SqlCommand

        With com
            .CommandType = CommandType.Text
            .CommandText = sql
            .Connection = Conn
            dr = .ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                SharedVar.user_id = dr("user_id").ToString()
                SharedVar.username = dr("user_username").ToString()
                SharedVar.fullname = dr("user_fullname").ToString()
                SharedVar.usertype = dr("user_type").ToString()

                dr.Close()

                frmMain.Show()
                Me.Hide()
            Else
                MessageBox.Show("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUser_username.Text = ""
                txtUser_password.Text = ""
                txtUser_username.Focus()
                Exit Sub
            End If
        End With



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("ต้องการออกจากระบบใช่หรือไม่ ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Application.Exit()

        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class