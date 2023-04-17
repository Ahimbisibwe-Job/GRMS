Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.SqlServer
Imports MySql.Data.MySqlClient
Public Class GroundsAvailable
    Dim cmd As New MySqlCommand
    Dim Rd As MySqlDataReader
    Dim Dt As New DataTable
    Dim DtA As New MySqlDataAdapter
    Dim con As New MySqlConnection("Server=localhost;Port=3305;Database=grms;User ID=root;Password=leahjoblee@11")
    Private Sub updateTable()
        Dim bsource As New BindingSource
        Try
            con.Open()
            Dim query As String
            query = "select *from grms.stall"
            cmd = New MySqlCommand(query, con)
            DtA.SelectCommand = cmd
            Dt.Clear()
            DtA.Fill(Dt)
            bsource.DataSource = Dt
            DataGridView1.DataSource = bsource
            DtA.Update(Dt)
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
        End Try
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label39_Click(sender As Object, e As EventArgs) Handles Label39.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroundsAvailableReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowUsername.Text = MarketLeaderMenu.ShowUsername.Text
        updateTable()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Me.Hide()
        MarketLeaderMenu.Show()
    End Sub
End Class