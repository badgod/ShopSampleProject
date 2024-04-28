Imports System.Data.SqlClient

Public Class frmMember

    Dim DB As DBClass = New DBClass
    Dim Conn As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim action As String
    Dim sql As String
    Dim rs As Integer

    Private Sub ClearAllData()
        txtMem_id.Text = ""
        txtMem_name.Text = ""
        txtMem_address.Text = ""
        txtMem_tel.Text = ""

        txtMem_name.Enabled = False
        txtMem_address.Enabled = False
        txtMem_tel.Enabled = False

        btnSave.Enabled = False
        btnCancel.Enabled = False
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False

        dgvData.Enabled = True
    End Sub

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
    Private Sub frmMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conn = DB.ConnectDB()

        ClearAllData()
        ShowData()
        FormatDataGridView()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        action = "add"

        dgvData.Enabled = False

        txtMem_id.Text = ""
        txtMem_name.Text = ""
        txtMem_address.Text = ""
        txtMem_tel.Text = ""


        txtMem_name.Enabled = True
        txtMem_address.Enabled = True
        txtMem_tel.Enabled = True

        btnSave.Enabled = True
        btnCancel.Enabled = True

        txtMem_name.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearAllData()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtMem_name.Text.Trim() = "" Or txtMem_address.Text.Trim() = "" Or txtMem_tel.Text.Trim() = "" Then
            MessageBox.Show("กรอกข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMem_name.Focus()
            Exit Sub
        End If

        If action = "add" Then
            sql = "INSERT INTO tb_member (mem_name, mem_address, mem_tel) 
                   VALUES 
                   ('" & txtMem_name.Text.Trim() & "', 
                   '" & txtMem_address.Text.Trim() & "',
                   '" & txtMem_tel.Text.Trim() & "') "

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

                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)

                dr.Close()
            Else
                MessageBox.Show("เกิดข้อผิดพลาดไม่สามารถบันทึกข้อมูลได้ !!!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        If action = "edit" Then
            sql = "UPDATE tb_member SET 
                    mem_name = '" & txtMem_name.Text.Trim() & "', 
                    mem_address = '" & txtMem_address.Text.Trim() & "', 
                    mem_tel = '" & txtMem_tel.Text.Trim() & "' 
                    WHERE 
                    mem_id = '" & txtMem_id.Text & "'"

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
            txtMem_id.Text = .Rows.Item(e.RowIndex).Cells(0).Value.ToString()
            txtMem_name.Text = .Rows.Item(e.RowIndex).Cells(1).Value.ToString()
            txtMem_address.Text = .Rows.Item(e.RowIndex).Cells(2).Value.ToString()
            txtMem_tel.Text = .Rows.Item(e.RowIndex).Cells(3).Value.ToString()

            btnEdit.Enabled = True
            btnDelete.Enabled = True
        End With
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        txtMem_name.Enabled = True
        txtMem_address.Enabled = True
        txtMem_tel.Enabled = True
        btnSave.Enabled = True
        btnCancel.Enabled = True

        txtMem_name.Focus()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่ ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            sql = "DELETE FROM tb_producttype WHERE protype_id = '" & txtMem_id.Text & "'"

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