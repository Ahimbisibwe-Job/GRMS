Public Class MainMenu
    Private Sub Main_menu_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowUsername.Text = Login.Usernam.Text
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub





    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        NewVendor.Show()
        Me.Hide()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        NewPayee.Show()
        Me.Hide()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub PictureBox5_Click_1(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub MakeInvoice_Click(sender As Object, e As EventArgs) Handles MakeInvoice.Click
        NewInvoice.Show()
        Me.Hide()
    End Sub



End Class