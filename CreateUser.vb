Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.SqlServer
Imports MySql.Data.MySqlClient
Public Class Create_User
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
            query = "select *from grms.user"
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
    Private Sub Createbtn_Click(sender As Object, e As EventArgs) Handles Createbtn.Click
        If Userid.Text = "" Or Fullname.Text = "" Or Email.Text = "" Or Password.Text = "" Or Location.Text = "" Or Usertype.Text = "" Or Usernam.Text = "" Then
            MessageBox.Show("Missing fields")
        Else
            Try
                con.Open()
                Dim query = "insert into grms.user (userid, fullName, email, password, location, usertype, usernam) values
                  ('" & Userid.Text & "','" & Fullname.Text & "','" & Email.Text & "','" & Password.Text & "','" & Location.Text & "','" & Usertype.Text & "','" & Usernam.Text & "')"
                Dim cmd As New MySqlCommand(query, con)
                Rd = cmd.ExecuteReader
                MessageBox.Show("User created")
                con.Close()
                DataGridView1.DataSource = Dt
                Userid.Text = ""
                Fullname.Text = ""
                Email.Text = ""
                Password.Text = ""
                Location.Text = ""
                Usertype.Text = ""
                Usernam.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        updateTable()
    End Sub

    Private Sub Create_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateTable()
        ShowUsername.Text = Login.Usernam.Text
    End Sub

    Private Sub Updatebtn_Click(sender As Object, e As EventArgs) Handles Updatebtn.Click
        Try
            con.Open()
            Dim query As String
            query = "update grms.user set UserId='" & Userid.Text & "', Fullname='" & Fullname.Text & "', Email='" & Email.Text & "', Password='" & Password.Text & "', Location='" & Location.Text & "', Usertype='" & Usertype.Text & "',Usernam='" & Usernam.Text & "'
               where UserId='" & Userid.Text & "'"
            cmd = New MySqlCommand(query, con)
            Rd = cmd.ExecuteReader

            MessageBox.Show("data has been Updated")
            con.Close()
            Userid.Text = ""
            Fullname.Text = ""
            Email.Text = ""
            Password.Text = ""
            Location.Text = ""
            Usertype.Text = ""
            Usernam.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
        End Try
        updateTable()
    End Sub

    Private Sub Deletebtn_Click(sender As Object, e As EventArgs) Handles Deletebtn.Click
        Try
            con.Open()
            Dim query As String
            query = "Delete from grms.user where UserId='" & Userid.Text & "'"
            cmd = New MySqlCommand(query, con)
            Rd = cmd.ExecuteReader

            MessageBox.Show("data has been deleted")
            con.Close()
            Userid.Text = ""
            Fullname.Text = ""
            Email.Text = ""
            Password.Text = ""
            Location.Text = ""
            Usertype.Text = ""
            Usernam.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
        End Try
        updateTable()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            Userid.Text = row.Cells("userid").Value.ToString
            Fullname.Text = row.Cells("fullname").Value.ToString
            Email.Text = row.Cells("email").Value.ToString
            Password.Text = row.Cells("password").Value.ToString
            Location.Text = row.Cells("location").Value.ToString
            Usertype.Text = row.Cells("usertype").Value.ToString
            Usernam.Text = row.Cells("usernam").Value.ToString
        End If
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub ShowUsername_Click(sender As Object, e As EventArgs) Handles ShowUsername.Click

    End Sub


End Class
