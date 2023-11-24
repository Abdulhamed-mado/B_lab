Imports System.Data.SqlClient

Public Class Form5
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim sa As String = ComboBox2.Text

        Dim comm As New SqlCommand("insert into clogin values('" + txt1.Text + "',  '" + txt3.Text + "' ,  '" + txt2.Text + "', '" + sa + "',  '" + txt4.Text + "')", cn1)

        Try
            If cn1.State = ConnectionState.Open Then cn1.Close()

            cn1.Open()
            comm.ExecuteNonQuery()
            cn1.Close()

            txt1.Text = ""
            txt2.Text = ""
            txt3.Text = ""

            txt4.Text = ""

            MsgBox("تم ادخال البيانات")
        Catch ex As Exception
            MsgBox("الرجاء التأكد من  البيانات")

            cn1.Close()
        End Try







        FillDG()
    End Sub

    Sub FillDG()
        DataGridView1.Rows.Clear()
        Dim s As String = "SELECT * FROM clogin "
        Dim da As New SqlDataAdapter(s, cn1)
        Dim ds As New DataSet(s)
        da.Fill(ds, s)
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                DataGridView1.Rows.Add(New String() {ds.Tables(0).Rows(i).Item("id"), ds.Tables(0).Rows(i).Item("username"), ds.Tables(0).Rows(i).Item("cpassword"), ds.Tables(0).Rows(i).Item("ctype"), ds.Tables(0).Rows(i).Item("cost")})
                'DataGridView1.Sort(DataGridView1.Columns("Id"), System.ComponentModel.ListSortDirection.Descending)
            Next

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sa As String = ComboBox2.Text
        If txt4.Text = "" Then
            txt4.Text = "0"
        End If

        Dim up As String = "UPDATE clogin set "
        up = up + "cpassword ='" + txt2.Text + "'"
        up = up + ",username ='" + txt3.Text + "'"
        up = up + ",cost ='" + txt4.Text + "'"

        up = up + ",ctype ='" + sa + "'"
        up = up + "WHERE id = '" + txt1.Text + "' "


        'Dim myconn As New SqlConnection(str)
        Dim com As New SqlCommand(up, cn1)

        Try
            If cn1.State = ConnectionState.Open Then cn1.Close()

            cn1.Open()
            com.ExecuteNonQuery()
            cn1.Close()

            txt1.Text = ""
            txt3.Text = ""
            txt2.Text = ""
            txt4.Text = ""


            MsgBox("تم تعديل البيانات")
        Catch ex As Exception
            MsgBox("الرجاء التأكد من البيانات", MsgBoxStyle.Exclamation, "خطأ")

        End Try


        FillDG()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim result As DialogResult = MsgBox("هل تريد حذف الحكم", MsgBoxStyle.YesNo, "تأكيد")
        If result = DialogResult.Yes Then
            Dim str As String = "Server=LAPTOP-TVMSOSNS\MADONAFO2001;Database=EBA;Trusted_Connection=True;
"



            Dim myconn As New SqlConnection(str)
            Dim com As New SqlCommand("delete FROM clogin WHERE id ='" + txt1.Text + "'", cn1)
            Try
                If cn1.State = ConnectionState.Open Then cn1.Close()

                cn1.Open()

                com.ExecuteNonQuery()
                cn1.Close()

                txt1.Text = ""
                txt3.Text = ""
                txt2.Text = ""
                txt4.Text = ""

                MsgBox("تم حذف البيانات")
            Catch ex As Exception
                MsgBox(" الرجاء التأكد من حذف جميع سجلات الخاصة بهذا العنصر بهذا العنصر ", MsgBoxStyle.Exclamation, "خطأ")

            End Try

        End If
        FillDG()
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Try
            Dim s As String
            s = DataGridView1.SelectedCells.Item(0).Value.ToString
            '        Dim str As String = "Server=DESKTOP-BRR1N2I;Database=karate;Trusted_Connection=True;
            '"


            '        Dim myconn As New SqlConnection(str)
            Dim com As New SqlCommand("SELECT * FROM clogin WHERE  ID='" + s + "'", cn1)

            If cn1.State = ConnectionState.Open Then cn1.Close()
            cn1.Open()
            Dim myreder As SqlDataReader = com.ExecuteReader()
            myreder.Read()

            txt1.Text = myreder("ID")
            txt3.Text = myreder("username")
            txt2.Text = myreder("cpassword")
            txt4.Text = myreder("cost")

            ComboBox2.Text = myreder("ctype")

            cn1.Close()

        Catch ex As Exception
            MsgBox("الرجاء التأكد نقر المزدوج على خانة رقم العيادة", MsgBoxStyle.Exclamation, "خطأ")

        End Try
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDG()
    End Sub

    Private Sub txt1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt1.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridView1.Rows.Clear()
        Dim s As String = "SELECT * FROM clogin where ID='" + TextBox3.Text + "' order by id"
        Dim da As New SqlDataAdapter(s, cn1)
        Dim ds As New DataSet(s)
        da.Fill(ds, s)
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                DataGridView1.Rows.Add(New String() {ds.Tables(0).Rows(i).Item("id"), ds.Tables(0).Rows(i).Item("username"), ds.Tables(0).Rows(i).Item("cpassword"), ds.Tables(0).Rows(i).Item("ctype"), ds.Tables(0).Rows(i).Item("cost")})
                'DataGridView1.Sort(DataGridView1.Columns("Id"), System.ComponentModel.ListSortDirection.Descending)
            Next

        End If
        TextBox3.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FillDG()

    End Sub

    Private Sub txt4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt4.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub
End Class