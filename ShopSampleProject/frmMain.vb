Public Class frmMain

    Dim frm As Form

    Private Sub จดการประเภทสนคาToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles จดการประเภทสนคาToolStripMenuItem.Click

        frm = New frmProductType
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub จดการสนคาToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles จดการสนคาToolStripMenuItem.Click

        frm = New frmProduct
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub จดการขอมลคคาToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles จดการขอมลคคาToolStripMenuItem.Click

        frm = New frmVendor
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub จดการขอมลลกคาToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles จดการขอมลลกคาToolStripMenuItem.Click

        frm = New frmMember
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsbProduct.Click

        frm = New frmProduct
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub ออกจากระบบToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ออกจากระบบToolStripMenuItem.Click

        If MessageBox.Show("ต้องการออกจากระบบใช่หรือไม่ ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Application.Exit()

        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        If MessageBox.Show("ต้องการออกจากระบบใช่หรือไม่ ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Application.Exit()

        End If

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles tsbStockin.Click

        frm = New frmStockinList
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If SharedVar.usertype = "2" Then
            tsbProduct.Enabled = False
            tsbStockin.Enabled = False
            tsadmin.Enabled = False
        End If

        tssFullname.Text = "ผู้ใช้ : " & SharedVar.fullname
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        frm = New frmEx
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class