Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.SqlServer
Imports MySql.Data.MySqlClient
Public Class FullPayment
    Dim cmd As New MySqlCommand
    Dim Rd As MySqlDataReader
    Dim Dt As New DataTable
    Dim DtA As New MySqlDataAdapter
    Dim con As New MySqlConnection("Server=localhost;Port=3305;Database=grms;User ID=root;Password=leahjoblee@11")
    Private bsource As Object

    Private Sub updateTable()
        Dim bsource As New BindingSource
        Try
            con.Open()
            Dim query As String
            query = "select * from grms.payment where amount = 2000000"
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

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateTable()
        ShowUsername.Text = MarketLeaderMenu.ShowUsername.Text
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        Me.Hide()
        MarketLeaderMenu.Show()
    End Sub

    'Private Sub searchbtn_Click(sender As Object, e As EventArgs)

    ' Dim searchValue As String = search.Text
    'Dim query As String = "SELECT * FROM grms.payment WHERE invoiceNo LIKE '%" & searchValue & "%' OR amount LIKE '%" & searchValue & "%' OR date LIKE '%" & searchValue & "%' OR paymentType LIKE '%" & searchValue & "%' OR stallNo LIKE '%" & searchValue & "%' Or fullName LIKE '%" & searchValue & "%'Or gender LIKE '%" & searchValue & "%' Or contact LIKE '%" & searchValue & "%' Or email LIKE '%" & searchValue & "%' Or location LIKE '%" & searchValue & "%'"
    ' cmd = New MySqlCommand(query, con)
    ' DtA.SelectCommand = cmd
    ' Dt.Clear()
    ' DtA.Fill(Dt)

    ' Initialize bsource as a new BindingSource object
    ' bsource = New BindingSource
    ' bsource.DataSource = Dt
    ' DataGridView1.DataSource = bsource
    'DtA.Update(Dt)





    'End Sub


End Class