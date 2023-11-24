Imports System.Data.SqlClient

Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim coma As New SqlCommand("SELECT * FROM clinic WHERE  ID='" + txt1.Text + "'", cn1)

            If cn1.State = ConnectionState.Open Then cn1.Close()
            cn1.Open()
            Dim myreder As SqlDataReader = coma.ExecuteReader()
            myreder.Read()


            txt2.Text = myreder("Ename")
            cn1.Close()
        Catch ex As Exception
            MsgBox("لا توجد عيادة بهذا الرقم ")
            Exit Sub

        End Try

        Dim x As Double = 0
        If txt4.Text <> "" Then x = txt4.Text

        Dim xx As Double = 1
        If txt6.Text <> "" Then xx = txt6.Text


        Dim cost As Double = x * xx
        Dim ccost As String = cost


        Dim d As Integer
        Dim m As Integer
        Dim y As Integer
        d = DateTimePicker2.Value.Day
        m = DateTimePicker2.Value.Month
        y = DateTimePicker2.Value.Year
        Dim s As String = m & "-" & d & "-" & y

        Dim comm As New SqlCommand("insert into ctransaction values('" + txt3.Text + "' , '" + txt2.Text + "' , '" + txt1.Text + "', '" + txt4.Text + "', '" + s + "', '" + txt5.Text + "', '" + txt6.Text + "', '" + ccost + "', '" + txt7.Text + "' )", cn1)

        Try
            If cn1.State = ConnectionState.Open Then cn1.Close()

            cn1.Open()
            comm.ExecuteNonQuery()
            cn1.Close()



            MsgBox("تم ادخال البيانات")
        Catch ex As Exception
            MsgBox("الرجاء التأكد من  البيانات")
            cn1.Close()
            Exit Sub

        End Try


        Dim saddress As String = "0"
        saddress = saddress + txt3.Text

        Dim ps As String = "فاتورة عيادة:" + txt2.Text
        ps = ps + txt3.Text

        Dim pps As String = 1


        Dim com As New SqlCommand("insert into profit values('" + saddress + "' , '" + ps + "' , '" + ccost + "', '" + s + "', '" + txt5.Text + "', '" + pps + "' )", cn1)

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


        Catch ex As Exception
            MsgBox("الرجاء التأكد من  البيانات")
            MsgBox(ex.ToString)

            cn1.Close()

        End Try




        FillDG()


    End Sub






    Sub FillDG()
        DataGridView1.Rows.Clear()
        Dim s As String = "SELECT * FROM ctransaction where ID<>0 order by id"
        Dim da As New SqlDataAdapter(s, cn1)
        Dim ds As New DataSet(s)
        da.Fill(ds, s)
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                DataGridView1.Rows.Add(New String() {ds.Tables(0).Rows(i).Item("ID"), ds.Tables(0).Rows(i).Item("Ename"), ds.Tables(0).Rows(i).Item("cid"), ds.Tables(0).Rows(i).Item("pname"), ds.Tables(0).Rows(i).Item("amount"), ds.Tables(0).Rows(i).Item("qun"), ds.Tables(0).Rows(i).Item("tcost"), ds.Tables(0).Rows(i).Item("tdate"), ds.Tables(0).Rows(i).Item("note")})
                'DataGridView1.Sort(DataGridView1.Columns("Id"), System.ComponentModel.ListSortDirection.Descending)
            Next

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim x As Double = 0
        If txt4.Text <> "" Then x = txt4.Text

        Dim xx As Double = 1
        If txt6.Text <> "" Then xx = txt6.Text


        Dim cost As Double = x * xx
        Dim ccost As String = cost

        Try
            Dim coma As New SqlCommand("SELECT * FROM clinic WHERE  ID='" + txt1.Text + "'", cn1)

            If cn1.State = ConnectionState.Open Then cn1.Close()
            cn1.Open()
            Dim myreder As SqlDataReader = coma.ExecuteReader()
            myreder.Read()


            txt2.Text = myreder("Ename")
            cn1.Close()
        Catch ex As Exception
            MsgBox("لا توجد عيادة بهذا الرقم ")
            Exit Sub

        End Try
        Dim d As Integer
        Dim m As Integer
        Dim y As Integer
        d = DateTimePicker2.Value.Day
        m = DateTimePicker2.Value.Month
        y = DateTimePicker2.Value.Year

        Dim s As String = m & "-" & d & "-" & y


        Dim up As String = "UPDATE ctransaction set "
        up = up + "Ename ='" + txt2.Text + "'"
        up = up + ",cid ='" + txt1.Text + "'"
        up = up + ",amount ='" + txt4.Text + "'"
        up = up + ",qun ='" + txt6.Text + "'"
        up = up + ",tcost ='" + ccost + "'"

        up = up + ",tdate ='" + s + "'"
        up = up + ",note ='" + txt5.Text + "'"
        up = up + ",pname ='" + txt7.Text + "'"


        up = up + "WHERE ID = '" + txt3.Text + "' "


        'Dim myconn As New SqlConnection(str)
        Dim com As New SqlCommand(up, cn1)

        Try
            If cn1.State = ConnectionState.Open Then cn1.Close()

            cn1.Open()
            com.ExecuteNonQuery()
            cn1.Close()




        Catch ex As Exception
            cn1.Close()
            Exit Sub

        End Try

        Dim saddress As String = "0"
        saddress = saddress + txt3.Text

        Dim ps As String = "فاتورة عيادة:" + txt2.Text

        Dim pps As String = 1

        Dim upp As String = "UPDATE profit set "
        upp = upp + "pname ='" + ps + "'"
        upp = upp + ",cost ='" + ccost + "'"
        upp = upp + ",tdate ='" + s + "'"
        upp = upp + ",note ='" + txt5.Text + "'"
        upp = upp + ",qun ='" + pps + "'"


        upp = upp + "WHERE id = '" + saddress + "' "



        'Dim myconn As New SqlConnection(str)
        Dim comm As New SqlCommand(upp, cn1)

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
            Dim com As New SqlCommand("delete FROM ctransaction WHERE  id='" + txt3.Text + "'", cn1)
            Try
                If cn1.State = ConnectionState.Open Then cn1.Close()

                cn1.Open()

                com.ExecuteNonQuery()
                cn1.Close()


            Catch ex As Exception
                MsgBox(" الرجاء التأكد من حذف جميع سجلات الخاصة بهذا العنصر بهذا العنصر ", MsgBoxStyle.Exclamation, "خطأ")
                Exit Sub

            End Try

            Dim saddress As String = "0"
            saddress = saddress + txt3.Text


            Dim comm As New SqlCommand("delete FROM profit WHERE  id='" + saddress + "'", cn1)
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


                MsgBox("تم حذف البيانات")
            Catch ex As Exception
                MsgBox(" الرجاء التأكد من حذف جميع سجلات الخاصة بهذا العنصر بهذا العنصر ", MsgBoxStyle.Exclamation, "خطأ")

            End Try


        End If
        FillDG()

    End Sub

    Private Sub txt1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt1.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt3.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Try
            Dim s As String
            s = DataGridView1.SelectedCells.Item(0).Value.ToString
            '        Dim str As String = "Server=DESKTOP-BRR1N2I;Database=karate;Trusted_Connection=True;
            '"


            '        Dim myconn As New SqlConnection(str)
            Dim com As New SqlCommand("SELECT * FROM ctransaction WHERE  ID='" + s + "'", cn1)

            If cn1.State = ConnectionState.Open Then cn1.Close()
            cn1.Open()
            Dim myreder As SqlDataReader = com.ExecuteReader()
            myreder.Read()

            txt1.Text = myreder("cid")

            txt2.Text = myreder("Ename")
            txt3.Text = myreder("id")
            txt4.Text = myreder("amount")
            txt5.Text = myreder("note")
            txt6.Text = myreder("qun")

            DateTimePicker2.Value = myreder("tdate")

            cn1.Close()

        Catch ex As Exception
            MsgBox("الرجاء التأكد نقر المزدوج على خانة رقم العيادة", MsgBoxStyle.Exclamation, "خطأ")

        End Try
    End Sub

    Private Sub txt4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt4.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDG()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.Rows.Clear()
        Dim s As String = "SELECT * FROM ctransaction where ID='" + TextBox1.Text + "' order by id"
        Dim da As New SqlDataAdapter(s, cn1)
        Dim ds As New DataSet(s)
        da.Fill(ds, s)
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                DataGridView1.Rows.Add(New String() {ds.Tables(0).Rows(i).Item("ID"), ds.Tables(0).Rows(i).Item("Ename"), ds.Tables(0).Rows(i).Item("cid"), ds.Tables(0).Rows(i).Item("amount"), ds.Tables(0).Rows(i).Item("tdate"), ds.Tables(0).Rows(i).Item("note")})
                'DataGridView1.Sort(DataGridView1.Columns("Id"), System.ComponentModel.ListSortDirection.Descending)
            Next

        End If
        TextBox1.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FillDG()
    End Sub
End Class