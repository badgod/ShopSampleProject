<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportProduct
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboProtype_id = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rptReport = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ประเภทสินค้า"
        '
        'cboProtype_id
        '
        Me.cboProtype_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProtype_id.FormattingEnabled = True
        Me.cboProtype_id.Items.AddRange(New Object() {"ประเภท  1", "ประเภท  2"})
        Me.cboProtype_id.Location = New System.Drawing.Point(89, 10)
        Me.cboProtype_id.Name = "cboProtype_id"
        Me.cboProtype_id.Size = New System.Drawing.Size(161, 21)
        Me.cboProtype_id.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(256, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "แสดงผล"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rptReport
        '
        Me.rptReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rptReport.LocalReport.ReportEmbeddedResource = "ShopSampleProject.rptProduct.rdlc"
        Me.rptReport.Location = New System.Drawing.Point(12, 46)
        Me.rptReport.Name = "rptReport"
        Me.rptReport.ServerReport.BearerToken = Nothing
        Me.rptReport.Size = New System.Drawing.Size(776, 392)
        Me.rptReport.TabIndex = 4
        '
        'frmReportProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.rptReport)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cboProtype_id)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmReportProduct"
        Me.Text = "frmReportProduct"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cboProtype_id As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents rptReport As Microsoft.Reporting.WinForms.ReportViewer
End Class
