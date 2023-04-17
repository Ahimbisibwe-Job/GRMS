Imports Org.BouncyCastle.Crypto.Tls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Imports System.Net.NetworkInformation

Public Class NewInvoice
    Dim cmd As New MySqlCommand
    Dim Rd As MySqlDataReader
    Dim Dt As New DataTable
    Dim DtA As New MySqlDataAdapter
    Dim con As New MySqlConnection("Server=localhost;Port=3305;Database=grms;User ID=root;Password=leahjoblee@11")
    Private Sub loadTeller()
        Dim bsource As New BindingSource
        Try
            con.Open()
            Dim query As String
            query = "select userId,fullName from grms.user where usernam='" & ShowUsername.Text & "'"
            cmd = New MySqlCommand(query, con)
            Rd = cmd.ExecuteReader
            If Rd.Read Then
                userId.Text = Rd.GetString("userId")
                fullName.Text = Rd.GetString("fullName")
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
        End Try
    End Sub
    Private Sub Label7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowUsername.Text = MainMenu.ShowUsername.Text
        loadTeller()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Back.Click
        Me.Hide()
        MainMenu.Show()
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.Hide()
        MainMenu.Show()
    End Sub

    Private Sub ShowUsername_Click(sender As Object, e As EventArgs) Handles ShowUsername.Click

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Vname.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                con.Open()
                Dim query As String = "SELECT fullName,stallNo,contact,email,date,amount FROM grms.payment WHERE invoiceNo ='" & TextBox2.Text & "'"
                cmd = New MySqlCommand(query, con)
                'cmd.Parameters.AddWithValue("@Name", fullName.SelectedItem)
                Rd = cmd.ExecuteReader
                If Rd.Read Then
                    issuedDate.Text = Rd.GetString("date")
                    Vname.Text = Rd.GetString("fullName")
                    stallNo.Text = Rd.GetString("stallNo")
                    contact.Text = Rd.GetString("contact")
                    email.Text = Rd.GetString("email")
                    amount.Text = Rd.GetString("amount")
                End If
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
End Class