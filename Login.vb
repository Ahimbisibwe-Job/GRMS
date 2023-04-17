Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.EntityFrameworkCore.Storage
Imports MySql.Data.MySqlClient

Public Class Login
    Dim con As MySqlConnection
    Dim cmd As MySqlCommand
    Dim rdr As MySqlDataReader
    Dim DtA As MySqlDataAdapter

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Loginbtn.Click
        If (Usernam.Text = "") Then
            MessageBox.Show("Enter the Username")
            Usernam.Focus()
            Exit Sub
        End If
        If (Password.Text = "") Then
            MessageBox.Show("Enter the Password")
            Exit Sub
        End If
        If (Usertype.Text = "") Then
            MessageBox.Show("Select user type")
            Exit Sub
        End If
        Try
            Dim con As New MySqlConnection("Server=localhost;Port=3305;Database=grms;User ID=root;Password=leahjoblee@11")
            con.Open()
            cmd = New MySqlCommand("Select * from grms.user where usernam=@usernam and password=@password", con)
            Dim usernameparam As New MySqlParameter("@usernam", Me.Usernam.Text)
            Dim passwordparam As New MySqlParameter("@password", Me.Password.Text)
            cmd.Parameters.Add(usernameparam)
            cmd.Parameters.Add(passwordparam)
            Dim read As MySqlDataReader = cmd.ExecuteReader

            If read.HasRows Then
                read.Read()
                If read("usertype") = "Admin" Then
                    Create_User.Show()
                    Usernam.Clear()
                    Password.Clear()
                    Usertype.Focus()
                    Me.Hide()
                ElseIf read("usertype") = "User" Then
                    MainMenu.Show()
                    Usernam.Clear()
                    Password.Clear()
                    Usertype.Focus()
                    Me.Hide()
                ElseIf read("usertype") = "Market Leader" Then
                    MarketLeaderMenu.Show()
                    Usernam.Clear()
                    Password.Clear()
                    Usertype.Focus()
                    Me.Hide()
                Else
                    MessageBox.Show("Enter Valid username and password")
                    Usernam.Text = ""
                    Password.Text = ""
                End If
            Else
                MessageBox.Show("Enter Valid username and password")
                Usernam.Text = ""
                Password.Text = ""
                Usernam.Clear()
                Password.Clear()
                Usertype.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
