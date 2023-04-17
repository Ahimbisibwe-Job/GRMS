Imports System.Data.Entity
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.SqlServer
Imports MySql.Data.MySqlClient
Public Class NewPayee
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
            query = "select *from grms.payment"
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
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Close()
        Login.Show()
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Me.Hide()
        MainMenu.Show()
    End Sub

    Private Sub NewPayee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            con.Open()
            Dim query As String
            query = "select * from grms.marketvendor"
            cmd = New MySqlCommand(query, con)
            Rd = cmd.ExecuteReader

            While Rd.Read
                Dim Name = Rd.GetString("fullName")
                fullName.Items.Add(Name)
            End While
            con.Close()
            fullName.Text = ""
            gender.Text = ""
            telephone.Text = ""
            emailAddress.Text = ""
            PhysicalAddress.Text = ""
            invoiceNo.Text = ""
            amount.Text = ""
            DateTimePicker1.Text = ""
            paymentType.Text = ""
            stallNo.Text = """"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        updateTable()
        ShowUsername.Text = MainMenu.ShowUsername.Text
    End Sub


    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        MainMenu.Show()
    End Sub

    Private Sub Savebtn_Click(sender As Object, e As EventArgs) Handles Savebtn.Click
        If amount.Text = "" Or DateTimePicker1.Text = "" Or paymentType.Text = "" Or stallNo.Text = "" Then
            MessageBox.Show("Missing fields")
        Else
            Try
                con.Open()
                Dim query = "insert into grms.payment (fullName, gender, contact, email, location,invoiceNo,amount,date,paymentType,stallNo) values
                  ('" & fullName.Text & "','" & gender.Text & "','" & telephone.Text & "','" & emailAddress.Text & "','" & PhysicalAddress.Text & "','" & invoiceNo.Text & "','" & amount.Text & "','" & DateTimePicker1.Text & "'
                    ,'" & paymentType.Text & "','" & stallNo.Text & "')"
                Dim cmd As New MySqlCommand(query, con)
                Rd = cmd.ExecuteReader
                MessageBox.Show("Vendor cleared")
                con.Close()
                DataGridView1.DataSource = Dt
                fullName.Text = ""
                gender.Text = ""
                telephone.Text = ""
                emailAddress.Text = ""
                PhysicalAddress.Text = ""
                invoiceNo.Text = ""
                amount.Text = ""
                DateTimePicker1.Text = ""
                paymentType.Text = ""
                stallNo.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        updateTable()
    End Sub

    Private Sub Updatebtn_Click(sender As Object, e As EventArgs) Handles Updatebtn.Click
        Try
            con.Open()
            Dim query = "update grms.payment set fullName='" & fullName.Text & "', gender='" & gender.Text & "', contact='" & telephone.Text & "', email='" & emailAddress.Text & "', location='" & PhysicalAddress.Text & "',invoiceNo='" & invoiceNo.Text & "', amount='" & amount.Text & "',  Date='" & DateTimePicker1.Text & "', paymentType='" & paymentType.Text & "',stallNo='" & stallNo.Text & "'
              where invoiceNo='" & invoiceNo.Text & "'"
            Dim cmd As New MySqlCommand(query, con)
            Rd = cmd.ExecuteReader
            MessageBox.Show("Vendor updated")
            con.Close()
            DataGridView1.DataSource = Dt
            fullName.Text = ""
            gender.Text = ""
            telephone.Text = ""
            emailAddress.Text = ""
            PhysicalAddress.Text = ""
            invoiceNo.Text = ""
            amount.Text = ""
            DateTimePicker1.Text = ""
            paymentType.Text = ""
            stallNo.Text = ""
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
            query = "Delete from grms.payment where invoiceNo='" & invoiceNo.Text & "'"
            cmd = New MySqlCommand(query, con)
            Rd = cmd.ExecuteReader


            MessageBox.Show("Vendor deleted")
            con.Close()
            fullName.Text = ""
            gender.Text = ""
            telephone.Text = ""
            emailAddress.Text = ""
            PhysicalAddress.Text = ""
            invoiceNo.Text = ""
            amount.Text = ""
            DateTimePicker1.Text = ""
            paymentType.Text = ""
            stallNo.Text = """"
        Catch ex As Exception

        End Try
        updateTable()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            fullName.Text = row.Cells("fullName").Value.ToString
            gender.Text = row.Cells("gender").Value.ToString
            telephone.Text = row.Cells("contact").Value.ToString
            emailAddress.Text = row.Cells("email").Value.ToString
            PhysicalAddress.Text = row.Cells("location").Value.ToString
            invoiceNo.Text = row.Cells("invoiceNo").Value.ToString
            amount.Text = row.Cells("amount").Value.ToString
            DateTimePicker1.Text = row.Cells("date").Value.ToString
            paymentType.Text = row.Cells("paymentType").Value.ToString
            stallNo.Text = row.Cells("stallNo").Value.ToString
        End If
    End Sub

    Private Sub fullName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles fullName.SelectedIndexChanged
        Try
            con.Open()
            Dim query As String = "SELECT gender, telephone, emailAddress, PhysicalAddress FROM grms.marketvendor WHERE fullName = @Name"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Name", fullName.SelectedItem)
            Rd = cmd.ExecuteReader
            If Rd.Read Then
                gender.Text = Rd.GetString("gender")
                telephone.Text = Rd.GetString("telephone")
                emailAddress.Text = Rd.GetString("emailAddress")
                PhysicalAddress.Text = Rd.GetString("PhysicalAddress")
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)

    End Sub
End Class