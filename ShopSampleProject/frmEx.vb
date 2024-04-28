Imports System.Data.SqlClient

Public Class frmEx

    Dim DB As DBClass = New DBClass
    Dim Conn As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim action As String
    Dim sql As String
    Dim rs As Integer
    Dim old_pro_image As String

    Private Sub ClearAllData()
        txtEx_id.Text = ""
        txtEx_datetime.Value = Now()
        txtEx_value.Text = ""

        cboExtype_id.Enabled = False

        btnSave.Enabled = False
        btnCancel.Enabled = False
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False

        dgvData.Enabled = True
    End Sub

    Private Sub ShowData()
        Dim sql As String

        sql = "SELECT 
                tb_ex.ex_id, tb_ex.ex_datetime, tb_extype.extype_name,tb_ex.ex_value, tb_user.user_fullname 
               FROM 
                tb_ex, tb_extype, tb_user 
               WHERE 
                tb_ex.extype_id = tb_extype.extype_id AND 
                tb_ex.user_id = tb_user.user_id"

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
                .Columns(1).HeaderText = "วันที่"
                .Columns(2).HeaderText = "ประเภทรายจ่าย"
                .Columns(3).HeaderText = "รายจ่าย"
                .Columns(4).HeaderText = "ผู้บันทึก"

                .Columns(0).Width = 50
                .Columns(1).Width = 100
                .Columns(2).Width = 100
                .Columns(3).Width = 100
                .Columns(4).Width = 100

            End If
        End With
    End Sub
    Private Sub frmEx_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conn = DB.ConnectDB()

        Dim sql As String = "SELECT * FROM tb_extype"

        com = New SqlCommand

        With com
            .CommandType = CommandType.Text
            .CommandText = sql
            .Connection = Conn
            dr = .ExecuteReader()

            If dr.HasRows Then
                dt = New DataTable()
                dt.Load(dr)

                With cboExtype_id
                    .DisplayMember = "extype_name"
                    .ValueMember = "extype_id"
                    .DataSource = dt
                End With

            End If
        End With

        dr.Close()

        ClearAllData()
        ShowData()
        FormatDataGridView()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        action = "add"

        dgvData.Enabled = False

        txtEx_id.Text = ""
        cboExtype_id.SelectedIndex = 0
        txtEx_datetime.Value = Now()
        cboExtype_id.Enabled = True

        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If txtEx_value.Value <= 0 Then
            MessageBox.Show("กรอกข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If action = "add" Then
            sql = "INSERT INTO tb_ex (ex_datetime, extype_id, ex_value, user_id) VALUES (@ex_datetime, @extype_id, @ex_value, @user_id)"

            With com
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = Conn
                .Parameters.Clear()
                .Parameters.Add("@ex_datetime", SqlDbType.DateTime).Value = txtEx_datetime.Value
                .Parameters.Add("@extype_id", SqlDbType.Int).Value = cboExtype_id.SelectedValue
                .Parameters.Add("@ex_value", SqlDbType.Decimal).Value = txtEx_value.Value
                .Parameters.Add("@user_id", SqlDbType.Int).Value = SharedVar.user_id
                rs = .ExecuteNonQuery()
            End With

            If rs > 0 Then
                ShowData()
                FormatDataGridView()
                ClearAllData()

                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)

                dr.Close()
            Else
                MessageBox.Show("เกิดข้อผิดพลาดไม่สามารถบันทึกข้อมูลได้ !!!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub
End Class