﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStockin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblVendor_tel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblVendor_name = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboVendor_id = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.listDetail = New System.Windows.Forms.ListView()
        Me.pro_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pro_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pro_perprice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.invdetail_count = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.invdetail_sum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblnvdetail_sum = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtInvdetail_count = New System.Windows.Forms.NumericUpDown()
        Me.txtPro_perprice = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboPro_id = New System.Windows.Forms.ComboBox()
        Me.lblInvoice_total = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtInvoice_date = New System.Windows.Forms.DateTimePicker()
        Me.txtInvoice_number = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtInvdetail_count, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPro_perprice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "รับเข้าสินค้า"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblVendor_tel)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblVendor_name)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboVendor_id)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 116)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "คู่ค้า"
        '
        'lblVendor_tel
        '
        Me.lblVendor_tel.AutoSize = True
        Me.lblVendor_tel.Location = New System.Drawing.Point(62, 84)
        Me.lblVendor_tel.Name = "lblVendor_tel"
        Me.lblVendor_tel.Size = New System.Drawing.Size(57, 13)
        Me.lblVendor_tel.TabIndex = 5
        Me.lblVendor_tel.Text = "vendor_tel"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "เบอร์โทร"
        '
        'lblVendor_name
        '
        Me.lblVendor_name.AutoSize = True
        Me.lblVendor_name.Location = New System.Drawing.Point(62, 58)
        Me.lblVendor_name.Name = "lblVendor_name"
        Me.lblVendor_name.Size = New System.Drawing.Size(72, 13)
        Me.lblVendor_name.TabIndex = 3
        Me.lblVendor_name.Text = "vendor_name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "ชื่อ"
        '
        'cboVendor_id
        '
        Me.cboVendor_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendor_id.FormattingEnabled = True
        Me.cboVendor_id.Location = New System.Drawing.Point(62, 22)
        Me.cboVendor_id.Name = "cboVendor_id"
        Me.cboVendor_id.Size = New System.Drawing.Size(187, 21)
        Me.cboVendor_id.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "เลือกคู่ค้า"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnRemove)
        Me.GroupBox2.Controls.Add(Me.listDetail)
        Me.GroupBox2.Controls.Add(Me.btnAddProduct)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lblnvdetail_sum)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtInvdetail_count)
        Me.GroupBox2.Controls.Add(Me.txtPro_perprice)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cboPro_id)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 154)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(612, 273)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "สินค้ารับเข้า"
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(562, 244)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(39, 23)
        Me.btnRemove.TabIndex = 11
        Me.btnRemove.Text = "ลบ"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'listDetail
        '
        Me.listDetail.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.pro_id, Me.pro_name, Me.pro_perprice, Me.invdetail_count, Me.invdetail_sum})
        Me.listDetail.FullRowSelect = True
        Me.listDetail.GridLines = True
        Me.listDetail.HideSelection = False
        Me.listDetail.Location = New System.Drawing.Point(9, 65)
        Me.listDetail.Name = "listDetail"
        Me.listDetail.Size = New System.Drawing.Size(592, 173)
        Me.listDetail.TabIndex = 10
        Me.listDetail.UseCompatibleStateImageBehavior = False
        Me.listDetail.View = System.Windows.Forms.View.Details
        '
        'pro_id
        '
        Me.pro_id.Text = "รหัส"
        '
        'pro_name
        '
        Me.pro_name.Text = "ชื่อ"
        Me.pro_name.Width = 200
        '
        'pro_perprice
        '
        Me.pro_perprice.Text = "ราคาต่อหน่วย"
        Me.pro_perprice.Width = 100
        '
        'invdetail_count
        '
        Me.invdetail_count.Text = "จำนวน"
        Me.invdetail_count.Width = 100
        '
        'invdetail_sum
        '
        Me.invdetail_sum.Text = "ราคา"
        Me.invdetail_sum.Width = 100
        '
        'btnAddProduct
        '
        Me.btnAddProduct.Location = New System.Drawing.Point(550, 36)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(51, 23)
        Me.btnAddProduct.TabIndex = 9
        Me.btnAddProduct.Text = "เพิ่ม"
        Me.btnAddProduct.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(311, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "จำนวน"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(184, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "ราคาต่อหน่วย"
        '
        'lblnvdetail_sum
        '
        Me.lblnvdetail_sum.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblnvdetail_sum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblnvdetail_sum.ForeColor = System.Drawing.Color.White
        Me.lblnvdetail_sum.Location = New System.Drawing.Point(440, 38)
        Me.lblnvdetail_sum.Name = "lblnvdetail_sum"
        Me.lblnvdetail_sum.Size = New System.Drawing.Size(104, 21)
        Me.lblnvdetail_sum.TabIndex = 6
        Me.lblnvdetail_sum.Text = "00.00"
        Me.lblnvdetail_sum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(439, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "ราคารวม"
        '
        'txtInvdetail_count
        '
        Me.txtInvdetail_count.Location = New System.Drawing.Point(314, 38)
        Me.txtInvdetail_count.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtInvdetail_count.Name = "txtInvdetail_count"
        Me.txtInvdetail_count.Size = New System.Drawing.Size(120, 20)
        Me.txtInvdetail_count.TabIndex = 5
        '
        'txtPro_perprice
        '
        Me.txtPro_perprice.DecimalPlaces = 2
        Me.txtPro_perprice.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.txtPro_perprice.Location = New System.Drawing.Point(187, 39)
        Me.txtPro_perprice.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtPro_perprice.Name = "txtPro_perprice"
        Me.txtPro_perprice.Size = New System.Drawing.Size(120, 20)
        Me.txtPro_perprice.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "สินค้า"
        '
        'cboPro_id
        '
        Me.cboPro_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPro_id.FormattingEnabled = True
        Me.cboPro_id.Location = New System.Drawing.Point(9, 38)
        Me.cboPro_id.Name = "cboPro_id"
        Me.cboPro_id.Size = New System.Drawing.Size(172, 21)
        Me.cboPro_id.TabIndex = 2
        '
        'lblInvoice_total
        '
        Me.lblInvoice_total.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblInvoice_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvoice_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblInvoice_total.ForeColor = System.Drawing.Color.White
        Me.lblInvoice_total.Location = New System.Drawing.Point(634, 162)
        Me.lblInvoice_total.Name = "lblInvoice_total"
        Me.lblInvoice_total.Size = New System.Drawing.Size(154, 76)
        Me.lblInvoice_total.TabIndex = 7
        Me.lblInvoice_total.Text = "00.00"
        Me.lblInvoice_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(634, 255)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(154, 46)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "บันทึก"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(634, 307)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(154, 45)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "ยกเลิก"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtInvoice_date)
        Me.GroupBox3.Controls.Add(Me.txtInvoice_number)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(286, 32)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(342, 116)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "รายละเอียดใบรับสินต้า"
        '
        'txtInvoice_date
        '
        Me.txtInvoice_date.Location = New System.Drawing.Point(55, 49)
        Me.txtInvoice_date.Name = "txtInvoice_date"
        Me.txtInvoice_date.Size = New System.Drawing.Size(219, 20)
        Me.txtInvoice_date.TabIndex = 8
        '
        'txtInvoice_number
        '
        Me.txtInvoice_number.Location = New System.Drawing.Point(55, 22)
        Me.txtInvoice_number.Name = "txtInvoice_number"
        Me.txtInvoice_number.Size = New System.Drawing.Size(219, 20)
        Me.txtInvoice_number.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "วันที่"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "เลขที่"
        '
        'frmStockin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblInvoice_total)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmStockin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "รับเข้าสินค้า"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtInvdetail_count, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPro_perprice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblVendor_tel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblVendor_name As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboVendor_id As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboPro_id As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblnvdetail_sum As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtInvdetail_count As NumericUpDown
    Friend WithEvents txtPro_perprice As NumericUpDown
    Friend WithEvents listDetail As ListView
    Friend WithEvents pro_id As ColumnHeader
    Friend WithEvents pro_name As ColumnHeader
    Friend WithEvents pro_perprice As ColumnHeader
    Friend WithEvents invdetail_count As ColumnHeader
    Friend WithEvents invdetail_sum As ColumnHeader
    Friend WithEvents btnAddProduct As Button
    Friend WithEvents lblInvoice_total As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtInvoice_date As DateTimePicker
    Friend WithEvents txtInvoice_number As TextBox
End Class
