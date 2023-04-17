Public Class MarketLeaderMenu
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub MarketLeaderMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowUsername.Text = Login.Usernam.Text
    End Sub


    Private Sub Debtors_Click(sender As Object, e As EventArgs) Handles Debtors.Click
        Me.Hide()
        PayrollReport.Show()
    End Sub

    Private Sub GroundAvailable_Click(sender As Object, e As EventArgs) Handles GroundAvailable.Click
        Dim groundsAvailable As New GroundsAvailable
        Me.Hide()
        groundsAvailable.Show()
    End Sub

    Private Sub PaymentsMade_Click(sender As Object, e As EventArgs) Handles PaymentsMade.Click
        Dim paymentsMade As New PaymentsMade
        Me.Hide()
        paymentsMade.Show()
    End Sub

    Private Sub FullPayment_Click(sender As Object, e As EventArgs) Handles FullPayment.Click
        Dim fullPaymentForm As New FullPayment
        Me.Hide()
        fullPaymentForm.Show()


    End Sub

End Class