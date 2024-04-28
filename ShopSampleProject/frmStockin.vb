Imports System.Data.SqlClient

Public Class frmStockin

    Dim DB As DBClass = New DBClass
    Dim Conn As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim dt As DataTable
    Dim action As String
    Dim sql As String
    Dim rs As Integer
    Dim total As Double = 0.0

    Private Sub ClearAllData()
        cboVendor_id.SelectedIndex = 0
        lblVendor_name.Text = ""
        lblVendor_tel.Text = ""

        cboPro_id.SelectedIndex = 0
        txtPro_perprice.Text = 0
        txtInvdetail_count.Text = 0
        lblnvdetail_sum.Text = "0.00"

        lblInvoice_total.Text = "0.00"
    End Sub

    Private Sub ClearSelectPro()

        txtPro_perprice.Value = 0
        txtInvdetail_count.Value = 0

        lblnvdetail_sum.Text = "0.00"
        btnAddProduct.Enabled = False

        txtInvdetail_count.Enabled = False
        txtPro_perprice.Enabled = False
    End Sub

    Private Sub CalculateProSum()
        Dim sum As Double = txtPro_perprice.Value * txtInvdetail_count.Value
        lblnvdetail_sum.Text = sum
    End Sub

    Private Sub FormatTotal()
        lblInvoice_total.Text = Format(total, "#,###.00")
    End Sub

    Private Sub frmStockin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Conn = DB.ConnectDB()

        Dim sql As String = "SELECT * FROM tb_vendor"

        com = New SqlCommand

        With com
            .CommandType = CommandType.Text
            .CommandText = sql
            .Connection = Conn
            dr = .ExecuteReader()

            If dr.HasRows Then
                dt = New DataTable()
                dt.Load(dr)

                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "เลือกคู่ค้า"
                dt.Rows.InsertAt(row, 0)

                With cboVendor_id
                    .DisplayMember = "vendor_name"
                    .ValueMember = "vendor_id"
                    .DataSource = dt
                End With

            End If
        End With

        dr.Close()

        sql = "SELECT * FROM tb_product"

        com = New SqlCommand

        With com
            .CommandType = CommandType.Text
            .CommandText = sql
            .Connection = Conn
            dr = .ExecuteReader()

            If dr.HasRows Then
                dt = New DataTable()
                dt.Load(dr)

                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "เลือกสินค้า"
                dt.Rows.InsertAt(row, 0)

                With cboPro_id
                    .DisplayMember = "pro_name"
                    .ValueMember = "pro_id"
                    .DataSource = dt
                End With

            End If
        End With

        dr.Close()

        ClearAllData()

    End Sub

    Private Sub cboVendor_id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVendor_id.SelectedIndexChanged

        If cboVendor_id.SelectedValue <> 0 Then
            Dim sql As String = "SELECT * FROM tb_vendor WHERE vendor_id = " & cboVendor_id.SelectedValue

            com = New SqlCommand

            With com
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = Conn
                dr = .ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    lblVendor_name.Text = dr("vendor_name").ToString
                    lblVendor_tel.Text = dr("vendor_tel").ToString
                End If
            End With

            dr.Close()

        Else
            lblVendor_name.Text = ""
            lblVendor_tel.Text = ""
        End If

    End Sub

    Private Sub cboPro_id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPro_id.SelectedIndexChanged

        If cboPro_id.SelectedValue <> 0 Then
            ClearSelectPro()
            txtPro_perprice.Enabled = True
            txtInvdetail_count.Enabled = True
            btnAddProduct.Enabled = True
        Else
            ClearSelectPro()
        End If

    End Sub

    Private Sub txtPro_perprice_ValueChanged(sender As Object, e As EventArgs) Handles txtPro_perprice.ValueChanged
        CalculateProSum()
    End Sub

    Private Sub txtInvdetail_count_ValueChanged(sender As Object, e As EventArgs) Handles txtInvdetail_count.ValueChanged
        CalculateProSum()
    End Sub

    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        If txtPro_perprice.Value = 0 Or txtInvdetail_count.Value = 0 Then
            MessageBox.Show("กรุณาเพิ่มราคา และจำนวน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPro_perprice.Focus()
            Exit Sub
        End If

        Dim i As Integer = 0
        Dim lvp As ListViewItem
        Dim pro_id As String

        For i = 0 To listDetail.Items.Count - 1
            pro_id = listDetail.Items(i).SubItems(0).Text
            If cboPro_id.SelectedValue = pro_id Then
                MessageBox.Show("คุณเลือกรายการซ้ำกัน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Next

        Dim anyData() As String

        anyData = New String() {cboPro_id.SelectedValue, cboPro_id.Text, txtPro_perprice.Value, txtInvdetail_count.Value, lblnvdetail_sum.Text}

        lvp = New ListViewItem(anyData)
        listDetail.Items.Add(lvp)

        total += lblnvdetail_sum.Text
        FormatTotal()

        cboPro_id.SelectedIndex = 0
        ClearSelectPro()
    End Sub


    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If listDetail.FocusedItem.SubItems(0).Text <> "" Then

            If MessageBox.Show("ต้องนำรายการออกใช่หรือไม่ ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                total -= listDetail.FocusedItem.SubItems(4).Text
                FormatTotal()

                listDetail.Items.RemoveAt(listDetail.FocusedItem.Index)
            End If

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearAllData()
        ClearSelectPro()
        cboPro_id.SelectedIndex = 0
        listDetail.Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cboVendor_id.SelectedValue = 0 Or total = 0 Then
            MessageBox.Show("กรุณาเลือกคู่ค้า และรายการ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim _cultureEnInfo As New Globalization.CultureInfo("en-US") 'th-TH
        Dim dateEng As DateTime = Convert.ToDateTime(txtInvoice_date.Value, _cultureEnInfo)
        'dateEng.ToString("MM/dd/yyyy 00:00:00", _cultureEnInfo)


        sql = "INSERT INTO tb_invoice (vendor_id, invoice_number, invoice_date, invoice_count, invoice_total) 
               VALUES 
               (
                 '" & cboVendor_id.SelectedValue & "',
                 '" & txtInvoice_number.Text & "',
                 '" & dateEng.ToString("MM/dd/yyyy 00:00:00", _cultureEnInfo) & "',
                 '" & listDetail.Items.Count & "',
                 '" & total & "'
               ); SELECT SCOPE_IDENTITY();"
        com = New SqlCommand

        With com
            .CommandType = CommandType.Text
            .CommandText = sql
            .Connection = Conn
            rs = .ExecuteScalar()
        End With

        If rs > 0 Then
            Dim lastInsertID As Integer = rs

            For i = 0 To listDetail.Items.Count - 1
                sql = "INSERT INTO tb_invoice_detail (invoice_id, pro_id, invdetail_count, invdetail_sum) "
                sql = sql & "VALUES ("
                sql = sql & "'" & lastInsertID & "', "
                sql = sql & "'" & listDetail.Items(i).SubItems(0).Text & "', "
                sql = sql & "'" & listDetail.Items(i).SubItems(3).Text & "', "
                sql = sql & "'" & listDetail.Items(i).SubItems(4).Text & "' "
                sql = sql & ")"

                com = New SqlCommand

                With com
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = Conn
                    .ExecuteNonQuery()
                End With

                sql = "UPDATE tb_product SET "
                sql = sql & "pro_stock = pro_stock + " & listDetail.Items(i).SubItems(3).Text & " "
                sql = sql & "WHERE "
                sql = sql & "pro_id = " & listDetail.Items(i).SubItems(0).Text

                com = New SqlCommand

                With com
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = Conn
                    .ExecuteNonQuery()
                End With
            Next

            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dr.Close()

            ClearAllData()
            ClearSelectPro()
            cboPro_id.SelectedIndex = 0
            listDetail.Clear()
        Else
            MessageBox.Show("เกิดข้อผิดพลาดไม่สามารถบันทึกข้อมูลได้ !!!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

End Class