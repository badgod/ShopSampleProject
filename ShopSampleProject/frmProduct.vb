Imports System.Data.SqlClient
Imports System.IO

Public Class frmProduct

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
        txtPro_id.Text = ""
        txtPro_name.Text = ""
        txtPro_detail.Text = ""
        txtPro_price.Text = ""
        txtPro_stock.Text = ""
        txtPro_image.Text = ""
        pbPro_image.ImageLocation = ""

        txtPro_name.Enabled = False
        txtPro_detail.Enabled = False
        txtPro_price.Enabled = False
        txtPro_stock.Enabled = False

        cboProtype_id.Enabled = False

        btnBrowse.Enabled = False
        btnSave.Enabled = False
        btnCancel.Enabled = False
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False

        dgvData.Enabled = True
    End Sub

    Private Sub ShowData()
        Dim sql As String = "SELECT 
                                tb_product.pro_id, 
                                tb_product.pro_name, 
                                tb_product.pro_price, 
                                tb_product.pro_stock,
                                tb_producttype.protype_name 
                            FROM 
                                tb_product, tb_producttype WHERE tb_product.protype_id = tb_producttype.protype_id"

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
                .Columns(1).HeaderText = "ชื่อสินค้า"
                .Columns(2).HeaderText = "ราคา"
                .Columns(3).HeaderText = "สินค้าคงเหลือ"
                .Columns(4).HeaderText = "ประเภท"

                .Columns(0).Width = 50
                .Columns(1).Width = 100
                .Columns(2).Width = 100
                .Columns(3).Width = 100
                .Columns(4).Width = 100

            End If
        End With
    End Sub

    Private Sub frmProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conn = DB.ConnectDB()

        ClearAllData()
        ShowData()
        FormatDataGridView()

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

                With cboProtype_id
                    .DisplayMember = "protype_name"
                    .ValueMember = "protype_id"
                    .DataSource = dt
                End With

            End If
        End With

        dr.Close()

        OpenFileProduct.Filter = "Image Files|*.jpg;*.png;*.gif;"
        OpenFileProduct.Title = "Select Image"

        Dim dir As New DirectoryInfo(My.Application.Info.DirectoryPath & "\productimage\")
        dir.Create()

        pbPro_image.SizeMode = PictureBoxSizeMode.Zoom

    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If (OpenFileProduct.ShowDialog = DialogResult.OK) Then
            Dim filepath As String
            filepath = OpenFileProduct.FileName
            txtPro_image.Text = filepath

            pbPro_image.ImageLocation = filepath
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        action = "add"

        dgvData.Enabled = False

        txtPro_id.Text = ""
        txtPro_name.Text = ""
        txtPro_detail.Text = ""
        txtPro_price.Text = "0"
        txtPro_stock.Text = "0"
        txtPro_image.Text = ""

        cboProtype_id.Enabled = True
        cboProtype_id.SelectedIndex = 0

        txtPro_name.Enabled = True
        txtPro_detail.Enabled = True
        txtPro_price.Enabled = True
        txtPro_stock.Enabled = True

        btnBrowse.Enabled = True
        btnSave.Enabled = True
        btnCancel.Enabled = True

        txtPro_name.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtPro_name.Text.Trim() = "" Or
            txtPro_detail.Text.Trim() = "" Or
            txtPro_image.Text = "" Then
            MessageBox.Show("กรอกข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPro_name.Focus()
            Exit Sub
        End If

        Dim FileToCopy As String = txtPro_image.Text
        Dim path As String = txtPro_image.Text

        Dim fif As New FileInfo(path)
        'Dim NewCopy As String = My.Application.Info.DirectoryPath & "\productimage\" & txtPro_name.Text & fif.Extension

        'If File.Exists(FileToCopy) Then
        'File.Copy(FileToCopy, NewCopy, True)
        'End If

        If action = "add" Then
            sql = "INSERT INTO tb_product 
                   (protype_id, 
                    pro_name, 
                    pro_detail, 
                    pro_price, 
                    pro_stock) 
                   VALUES 
                   ('" & cboProtype_id.SelectedValue & "', 
                   '" & txtPro_name.Text.Trim() & "',
                   '" & txtPro_detail.Text.Trim() & "',
                   '" & txtPro_price.Text.Trim() & "',
                   '" & txtPro_stock.Text.Trim() & "'); SELECT SCOPE_IDENTITY();"

            com = New SqlCommand

            With com
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = Conn
                rs = .ExecuteScalar()
            End With

            If rs > 0 Then
                Dim lastInsertID As Integer = rs
                Dim NewCopy As String = My.Application.Info.DirectoryPath & "\productimage\" & lastInsertID & fif.Extension

                If File.Exists(FileToCopy) Then
                    File.Copy(FileToCopy, NewCopy, True)
                End If

                sql = "UPDATE tb_product SET pro_image = '" & lastInsertID & fif.Extension & "' WHERE pro_id = '" & lastInsertID & "'"
                com = New SqlCommand

                With com
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = Conn
                    .ExecuteNonQuery()
                End With

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
            sql = "UPDATE tb_product SET 
                    protype_id = '" & cboProtype_id.SelectedValue & "', 
                    pro_name = '" & txtPro_name.Text.Trim() & "',
                    pro_detail = '" & txtPro_detail.Text.Trim() & "',
                    pro_price = '" & txtPro_price.Text.Trim() & "',
                    pro_stock = '" & txtPro_stock.Text.Trim() & "' "

            If txtPro_image.Text <> "" Then
                Dim NewCopy As String = My.Application.Info.DirectoryPath & "\productimage\" & txtPro_id.Text & fif.Extension

                If File.Exists(FileToCopy) Then
                    File.Copy(FileToCopy, NewCopy, True)
                End If

                sql = sql & ", pro_image = '" & txtPro_id.Text & fif.Extension & "' "
            End If

            sql = sql & "WHERE pro_id = '" & txtPro_id.Text.Trim() & "'"

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

        Dim pro_id As String = dgvData.Rows(e.RowIndex).Cells(0).Value.ToString()

        sql = "SELECT * FROM tb_product WHERE pro_id = " & pro_id

        com = New SqlCommand

        With com
            .CommandType = CommandType.Text
            .CommandText = sql
            .Connection = Conn
            dr = .ExecuteReader()

            If dr.HasRows Then
                dr.Read()
                txtPro_id.Text = dr("pro_id").ToString
                cboProtype_id.SelectedValue = dr("protype_id").ToString
                txtPro_name.Text = dr("pro_name").ToString
                txtPro_detail.Text = dr("pro_detail").ToString
                txtPro_price.Value = dr("pro_price").ToString
                txtPro_stock.Value = dr("pro_stock").ToString
                pbPro_image.ImageLocation = My.Application.Info.DirectoryPath & "\productimage\" & dr("pro_image").ToString
                old_pro_image = dr("pro_image").ToString
            End If
        End With

        dr.Close()

        btnEdit.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        action = "edit"

        txtPro_name.Enabled = True
        txtPro_detail.Enabled = True
        txtPro_price.Enabled = True
        txtPro_stock.Enabled = True

        btnBrowse.Enabled = True
        btnSave.Enabled = True
        btnCancel.Enabled = True

        txtPro_name.Focus()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่ ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            sql = "DELETE FROM tb_product WHERE pro_id = '" & txtPro_id.Text & "'"

            com = New SqlCommand

            With com
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = Conn
                rs = .ExecuteNonQuery()
            End With

            If rs > 0 Then
                Dim OldImage As String = old_pro_image

                If File.Exists(OldImage) = True Then
                    File.Delete(OldImage)
                End If

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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If txtSearch.Text.Trim() <> "" Then
            Dim sql As String = "SELECT tb_product.pro_price, 
                                    tb_product.pro_stock,
                                    tb_producttype.protype_name 
                                 FROM 
                                    tb_product, tb_producttype 
                                 WHERE 
                                    tb_product.protype_id = tb_producttype.protype_id AND 
                                    tb_product.pro_name LIKE '%" & txtSearch.Text.Trim() & "%' 
                                    OR tb_producttype.protype_name LIKE '%" & txtSearch.Text.Trim() & "%'"

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

        Else
            ShowData()

        End If

        FormatDataGridView()
    End Sub

    Private Sub btbClear_Click(sender As Object, e As EventArgs) Handles btbClear.Click
        txtPro_image.Text = ""
    End Sub
End Class