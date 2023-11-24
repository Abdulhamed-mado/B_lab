Imports System.Data.SqlClient

Public Class Form6
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txt1.Text <> "0" Then
            Dim d As Integer
            Dim m As Integer
            Dim y As Integer
            d = DateTimePicker2.Value.Day
            m = DateTimePicker2.Value.Month
            y = DateTimePicker2.Value.Year
            Dim s As String = m & "-" & d & "-" & y


            Try
                Dim ca As New SqlCommand("SELECT * FROM clinic WHERE  ID='" + txt8.Text + "'", cn1)

                If cn1.State = ConnectionState.Open Then cn1.Close()
                cn1.Open()
                Dim myreder As SqlDataReader = ca.ExecuteReader()
                myreder.Read()

                txt9.Text = myreder("Ename")


                cn1.Close()

            Catch ex As Exception

            End Try
            Dim comm As New SqlCommand("insert into cp values('" + txt1.Text + "' ,  '" + txt3.Text + "', '" + s + "', '" + txt2.Text + "' , '" + txt5.Text + "', '" + txt4.Text + "', '" + txt7.Text + "', '" + txt6.Text + "', '" + txt8.Text + "', '" + txt9.Text + "' )", cn1)

            Try
                If cn1.State = ConnectionState.Open Then cn1.Close()

                cn1.Open()
                comm.ExecuteNonQuery()
                cn1.Close()

                txt1.Text = ""
                txt2.Text = ""
                txt3.Text = ""
                txt4.Text = ""
                txt5.Text = ""
                txt6.Text = ""
                txt7.Text = ""
                txt8.Text = ""
                txt9.Text = ""

                MsgBox("تم ادخال البيانات")
            Catch ex As Exception
                MsgBox("الرجاء التأكد من  البيانات")
                cn1.Close()
            End Try

            FillDG()

        Else
            MsgBox("الرجاء التأكد من  البيانات")
        End If

    End Sub

    Sub FillDG()
        DataGridView1.Rows.Clear()
        Dim s As String = "SELECT * FROM cp where ID<>0 order by id"
        Dim da As New SqlDataAdapter(s, cn1)
        Dim ds As New DataSet(s)
        da.Fill(ds, s)
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                DataGridView1.Rows.Add(New String() {ds.Tables(0).Rows(i).Item("ID"), ds.Tables(0).Rows(i).Item("pname"), ds.Tables(0).Rows(i).Item("cid"), ds.Tables(0).Rows(i).Item("cname"), ds.Tables(0).Rows(i).Item("pdate"), ds.Tables(0).Rows(i).Item("ctype"), ds.Tables(0).Rows(i).Item("utl"), ds.Tables(0).Rows(i).Item("utr"), ds.Tables(0).Rows(i).Item("ltl"), ds.Tables(0).Rows(i).Item("ltr")})
                'DataGridView1.Sort(DataGridView1.Columns("Id"), System.ComponentModel.ListSortDirection.Descending)
            Next

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim d As Integer
        Dim m As Integer
        Dim y As Integer
        d = DateTimePicker2.Value.Day
        m = DateTimePicker2.Value.Month
        y = DateTimePicker2.Value.Year

        Dim s As String = m & "-" & d & "-" & y


        Dim up As String = "UPDATE cp set "
        up = up + "pname ='" + txt3.Text + "'"
        up = up + ",ctype ='" + txt2.Text + "'"
        up = up + ",utl ='" + txt5.Text + "'"
        up = up + ",pdate ='" + s + "'"
        up = up + ",utr ='" + txt4.Text + "'"
        up = up + ",ltl ='" + txt7.Text + "'"
        up = up + ",ltr ='" + txt6.Text + "'"
        up = up + ",cid ='" + txt8.Text + "'"
        up = up + ",cname ='" + txt9.Text + "'"

        up = up + "WHERE ID = '" + txt1.Text + "' "


        'Dim myconn As New SqlConnection(str)
        Dim com As New SqlCommand(up, cn1)

        Try
            If cn1.State = ConnectionState.Open Then cn1.Close()

            cn1.Open()
            com.ExecuteNonQuery()
            cn1.Close()
            txt1.Text = ""
            txt2.Text = ""
            txt3.Text = ""
            txt4.Text = ""
            txt5.Text = ""
            txt6.Text = ""
            txt7.Text = ""
            txt8.Text = ""
            txt9.Text = ""

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

            Dim d As Integer
            Dim m As Integer
            Dim y As Integer
            d = DateTimePicker2.Value.Day
            m = DateTimePicker2.Value.Month
            y = DateTimePicker2.Value.Year
            Dim s As String = m & "-" & d & "-" & y



            Dim comm As New SqlCommand("insert into deletedcp values('" + txt1.Text + "' ,  '" + txt3.Text + "', '" + s + "', '" + txt2.Text + "' , '" + txt5.Text + "', '" + txt4.Text + "', '" + txt7.Text + "', '" + txt6.Text + "', '" + txt8.Text + "', '" + txt9.Text + "' )", cn1)

            Try
                If cn1.State = ConnectionState.Open Then cn1.Close()

                cn1.Open()
                comm.ExecuteNonQuery()
                cn1.Close()


            Catch ex As Exception
                cn1.Close()
            End Try



            Dim myconn As New SqlConnection(str)
            Dim com As New SqlCommand("delete FROM cp WHERE  id='" + txt1.Text + "'", cn1)
            Try
                If cn1.State = ConnectionState.Open Then cn1.Close()

                cn1.Open()

                com.ExecuteNonQuery()
                cn1.Close()

                txt1.Text = ""
                txt2.Text = ""
                txt3.Text = ""
                txt4.Text = ""
                txt5.Text = ""
                txt6.Text = ""
                txt7.Text = ""
                txt8.Text = ""
                txt9.Text = ""

                MsgBox("تم حذف البيانات")
            Catch ex As Exception
                MsgBox(" الرجاء التأكد من حذف جميع سجلات الخاصة بهذا العنصر بهذا العنصر ", MsgBoxStyle.Exclamation, "خطأ")
                MsgBox(ex.ToString)
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
            Dim com As New SqlCommand("SELECT * FROM cp WHERE  ID='" + s + "'", cn1)

            If cn1.State = ConnectionState.Open Then cn1.Close()
            cn1.Open()
            Dim myreder As SqlDataReader = com.ExecuteReader()
            myreder.Read()

            txt1.Text = myreder("ID")
            txt2.Text = myreder("ctype")
            txt3.Text = myreder("pname")
            txt4.Text = myreder("utr")
            txt5.Text = myreder("utl")
            txt6.Text = myreder("ltr")
            txt7.Text = myreder("ltl")
            txt8.Text = myreder("cid")
            txt9.Text = myreder("cname")
            DateTimePicker2.Value = myreder("pdate")

            cn1.Close()

        Catch ex As Exception
            MsgBox("الرجاء التأكد نقر المزدوج على خانة رقم العيادة", MsgBoxStyle.Exclamation, "خطأ")

        End Try
    End Sub



    Private Sub txt1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt1.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub







    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDG()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridView1.Rows.Clear()
        If TextBox3.Text <> "0" Then
            Dim s As String = "SELECT * FROM cp where ID='" + TextBox3.Text + "' order by id"
            Dim da As New SqlDataAdapter(s, cn1)
            Dim ds As New DataSet(s)
            da.Fill(ds, s)
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    DataGridView1.Rows.Add(New String() {ds.Tables(0).Rows(i).Item("ID"), ds.Tables(0).Rows(i).Item("pname"), ds.Tables(0).Rows(i).Item("cid"), ds.Tables(0).Rows(i).Item("cname"), ds.Tables(0).Rows(i).Item("pdate"), ds.Tables(0).Rows(i).Item("ctype"), ds.Tables(0).Rows(i).Item("utl"), ds.Tables(0).Rows(i).Item("utr"), ds.Tables(0).Rows(i).Item("ltl"), ds.Tables(0).Rows(i).Item("ltr")})
                    'DataGridView1.Sort(DataGridView1.Columns("Id"), System.ComponentModel.ListSortDirection.Descending)
                Next

            End If
        Else
            Dim s As String = "SELECT * FROM deletedcp order by id"
            Dim da As New SqlDataAdapter(s, cn1)
            Dim ds As New DataSet(s)
            da.Fill(ds, s)
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    DataGridView1.Rows.Add(New String() {ds.Tables(0).Rows(i).Item("ID"), ds.Tables(0).Rows(i).Item("pname"), ds.Tables(0).Rows(i).Item("cid"), ds.Tables(0).Rows(i).Item("cname"), ds.Tables(0).Rows(i).Item("pdate"), ds.Tables(0).Rows(i).Item("ctype"), ds.Tables(0).Rows(i).Item("utl"), ds.Tables(0).Rows(i).Item("utr"), ds.Tables(0).Rows(i).Item("ltl"), ds.Tables(0).Rows(i).Item("ltr")})
                    'DataGridView1.Sort(DataGridView1.Columns("Id"), System.ComponentModel.ListSortDirection.Descending)
                Next

            End If


        End If

        TextBox3.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FillDG()

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub
End Class