Imports System.Data.SqlClient

Public Class Form8


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        'Form1.Show()
        'TextBox1.Text = ""
        'TextBox2.Text = ""
        'Me.Hide()

        Try

            Dim com As New SqlCommand("SELECT * FROM clogin WHERE  username='" + TextBox1.Text + "' and cpassword='" + TextBox2.Text + "'", cn1)
            If cn1.State = ConnectionState.Open Then cn1.Close()
            cn1.Open()
            Dim myreder As SqlDataReader = com.ExecuteReader()
            myreder.Read()

            px = myreder("id")
            ucost = myreder("cost")

            z = myreder("ctype")

            cn1.Close()

            If z = "ادمن" Then
                Form1.Show()
                TextBox1.Text = ""
                TextBox2.Text = ""
                Me.Hide()
            Else
                Form9.Show()
                TextBox1.Text = ""
                TextBox2.Text = ""
                Me.Hide()


            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("الرجاء التأكد من البيانات", MsgBoxStyle.Exclamation, "خطأ")
        End Try
    End Sub
End Class