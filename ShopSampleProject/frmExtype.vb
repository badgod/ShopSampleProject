Imports System.Data.SqlClient

Public Class frmExtype

    Dim DB As DBClass = New DBClass
    Dim Conn As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim action As String
    Dim sql As String
    Dim rs As Integer

    Private Sub ClearAllData()
        txtExtype_id.Text = ""
        txtExtype_name.Text = ""

        txtExtype_name.Enabled = False

        btnSave.Enabled = False
        btnCancel.Enabled = False
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False

        dgvData.Enabled = True
    End Sub

    Private Sub ShowData()
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
                .Columns(1).HeaderText = "ชื่อประเภทสินค้า"

                .Columns(0).Width = 50
                .Columns(1).Width = 250
            End If
        End With
    End Sub
    Private Sub frmExtype_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conn = DB.ConnectDB()

        ClearAllData()
        ShowData()
        FormatDataGridView()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        action = "add"

        dgvData.Enabled = False

        txtExtype_id.Text = ""
        txtExtype_name.Text = ""

        txtExtype_name.Enabled = True
        btnSave.Enabled = True
        btnCancel.Enabled = True

        txtExtype_name.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearAllData()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtExtype_name.Text.Trim() = "" Then
            MessageBox.Show("กรอกข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtExtype_name.Focus()
            Exit Sub
        End If

        If action = "add" Then
            'sql = "INSERT INTO tb_extype (extype_name) VALUES ('" & txtExtype_name.Text.Trim() & "') "
            sql = "INSERT INTO tb_extype (extype_name) VALUES (@extype_name) "


            com = New SqlCommand

            With com
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = Conn
                .Parameters.Clear()
                .Parameters.Add("@extype_name", SqlDbType.NVarChar).Value = txtExtype_name.Text.Trim()
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

        If action = "edit" Then
            sql = "UPDATE tb_extype SET extype_name = @extype_name WHERE extype_id = @extype_id"

            com = New SqlCommand

            With com
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = Conn
                .Parameters.Clear()
                .Parameters.Add("@extype_name", SqlDbType.NVarChar).Value = txtExtype_name.Text.Trim()
                .Parameters.Add("@extype_id", SqlDbType.Int).Value = txtExtype_id.Text.Trim()
                rs = .ExecuteNonQuery()
            End With

            If rs > 0 Then
                ShowData()
                FormatDataGridView()
                ClearAllData()

                MessageBox.Show("แก้ไขข้อมูลเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)

                dr.Close()
            Else
                MessageBox.Show("เกิดข้อผิดพลาดไม่สามารถบันทึกข้อมูลได้ !!!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub dgvData_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseUp
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        With dgvData
            txtExtype_id.Text = .Rows.Item(e.RowIndex).Cells(0).Value.ToString()
            txtExtype_name.Text = .Rows.Item(e.RowIndex).Cells(1).Value.ToString()


            btnEdit.Enabled = True
            btnDelete.Enabled = True
        End With
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        action = "edit"

        txtExtype_name.Enabled = True
        btnSave.Enabled = True
        btnCancel.Enabled = True

        txtExtype_name.Focus()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่ ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            sql = "DELETE FROM tb_extype WHERE protype_id = '" & txtExtype_id.Text & "'"

            com = New SqlCommand

            With com
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = Conn
                rs = .ExecuteNonQuery()
            End With

            If rs > 0 Then
                ShowData()
                FormatDataGridView()
                ClearAllData()

                MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)

                dr.Close()
            Else
                MessageBox.Show("เกิดข้อผิดพลาดไม่สามารถลบข้อมูลได้ !!!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub
End Class