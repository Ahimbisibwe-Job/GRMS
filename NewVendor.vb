Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient

Public Class NewVendor
    Dim gender As String
    Dim cmd As New MySqlCommand
    Dim Rd As MySqlDataReader
    Dim Dt As New DataTable
    Dim DtA As New MySqlDataAdapter
    Dim con As New MySqlConnection("Server=localhost;Port=3305;Database=grms;User ID=root; Password=leahjoblee@11")
    Private Sub updateTable()
        Dim bsource As New BindingSource
        Try
            con.Open()
            Dim query As String
            query = "select * from grms.marketvendor"
            cmd = New MySqlCommand(query, con)
            DtA.SelectCommand = cmd
            Dt.Clear()
            DtA.Fill(Dt)
            bsource.DataSource = Dt
            DataGridView2.DataSource = bsource
            DtA.Update(Dt)
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
        End Try
    End Sub
    Private Sub AddVendor_Click(sender As Object, e As EventArgs) Handles AddVendor.Click
        If ninNo.Text = "" Or fullName.Text = "" Or dateOfbirth.Text = "" Or gender = "" Or contact.Text = "" Or email.Text = "" Or address.Text = "" Or nextOfKin.Text = "" Or maritalStatus.Text = "" Then
            MessageBox.Show("Missing fields")
        Else
            Try
                con.Open()
                Dim query = "insert into grms.marketvendor (ninNo, fullName, dateOfBirth, gender, telephone, emailAddress, physicalAddress, nextOfKin, maritalStatus) values
                  ('" & ninNo.Text & "','" & fullName.Text & "','" & dateOfbirth.Text & "','" & contact.Text & "','" & email.Text & "','" & address.Text & "','" & nextOfKin.Text & "','" & maritalStatus.Text & "')"
                Dim cmd As New MySqlCommand(query, con)
                Rd = cmd.ExecuteReader
                MessageBox.Show("Vendor created")
                con.Close()
                DataGridView2.DataSource = Dt
                ninNo.Text = ""
                fullName.Text = ""
                dateOfbirth.Text = ""
                gender = ""
                contact.Text = ""
                email.Text = ""
                address.Text = ""
                nextOfKin.Text = ""
                maritalStatus.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        updateTable()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowUsername.Text = MainMenu.ShowUsername.Text
        updateTable()

    End Sub

    Private Sub Male_CheckedChanged(sender As Object, e As EventArgs) Handles Male.CheckedChanged
        gender = "Male"
    End Sub

    Private Sub Femalebtn_CheckedChanged(sender As Object, e As EventArgs) Handles Femalebtn.CheckedChanged
        gender = "Female"
    End Sub

    Private Sub Updatebtn_Click(sender As Object, e As EventArgs) Handles Updatebtn.Click
        Try
            con.Open()
            Dim query = "update grms.marketvendor set ninNo='" & ninNo.Text & "', fullName='" & fullName.Text & "', dateOfBirth='" & dateOfbirth.Text & "', gender='" & gender & "', telephone='" & contact.Text & "', emailAddress='" & email.Text & "', physicalAddress='" & address.Text & "', nextOfKin='" & nextOfKin.Text & "', maritalStatus='" & maritalStatus.Text & "'
              where ninNo='" & ninNo.Text & "'"
            Dim cmd As New MySqlCommand(query, con)
            Rd = cmd.ExecuteReader
            MessageBox.Show("Vendor updated")
            con.Close()


            ninNo.Text = ""
            fullName.Text = ""
            dateOfbirth.Text = ""
            gender = ""
            contact.Text = ""
            email.Text = ""
            address.Text = ""
            nextOfKin.Text = ""
            maritalStatus.Text = ""
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
            query = "Delete from grms.marketvendor where ninNo='" & ninNo.Text & "'"
            cmd = New MySqlCommand(query, con)
            Rd = cmd.ExecuteReader


            MessageBox.Show("Vendor deleted")
            con.Close()
            ninNo.Text = ""
            fullName.Text = ""
            dateOfbirth.Text = ""
            gender = ""
            contact.Text = ""
            email.Text = ""
            address.Text = ""
            nextOfKin.Text = ""
            maritalStatus.Text = ""
        Catch ex As Exception

        End Try
        updateTable()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView2.Rows(e.RowIndex)
            ninNo.Text = row.Cells("ninNo").Value.ToString
            fullName.Text = row.Cells("fullName").Value.ToString
            dateOfbirth.Text = row.Cells("dateOfBirth").Value.ToString
            gender = row.Cells("gender").Value.ToString
            contact.Text = row.Cells("telephone").Value.ToString
            email.Text = row.Cells("emailAddress").Value.ToString
            address.Text = row.Cells("physicalAddress").Value.ToString
            nextOfKin.Text = row.Cells("nextOfKin").Value.ToString
            maritalStatus.Text = row.Cells("maritalStatus").Value.ToString
        End If

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        MainMenu.Show()
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Me.Hide()
        MainMenu.Show()
    End Sub


    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Hide()
        Login.Show()
    End Sub

End Class