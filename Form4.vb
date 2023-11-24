Imports System.Data.SqlClient

Public Class Form4
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim d As Integer
        Dim m As Integer
        Dim y As Integer
        d = DateTimePicker2.Value.Day
        m = DateTimePicker2.Value.Month
        y = DateTimePicker2.Value.Year
        Dim s As String = m & "-" & d & "-" & y
        Dim x As Double = 0
        If txt4.Text <> "" Then x = txt4.Text

        Dim xx As Double = 1
        If TextBox1.Text <> "" Then xx = TextBox1.Text


        Dim cost As Double = x * xx
        Dim ccost As String = cost
        Dim comm As New SqlCommand("insert into closs values('" + txt1.Text + "' , '" + txt3.Text + "' , '" + s + "', '" + ccost + "', '" + TextBox2.Text + "', '" + TextBox1.Text + "' )", cn1)

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


        Dim saddress As String = "00"
        saddress = saddress + txt1.Text
        Dim minusprofit = cost * -1
        Dim pps As String = minusprofit



        Dim com As New SqlCommand("insert into profit values('" + saddress + "' , '" + txt3.Text + "' , '" + pps + "', '" + s + "', '" + TextBox2.Text + "', '" + TextBox1.Text + "' )", cn1)

        Try
            If cn1.State = ConnectionState.Open Then cn1.Close()

            cn1.Open()
            com.ExecuteNonQuery()
            cn1.Close()
            txt1.Text = ""
            txt3.Text = ""
            txt4.Text = ""
            TextBox2.Text = ""
            TextBox1.Text = ""


        Catch ex As Exception
            MsgBox("الرجاء التأكد من  البيانات")
            MsgBox(ex.Message)

            cn1.Close()
        End Try




        FillDG()
    End Sub
    Sub FillDG()
        DataGridView1.Rows.Clear()
        Dim s As String = "SELECT * FROM closs where ID<>0 order by id"
        Dim da As New SqlDataAdapter(s, cn1)
        Dim ds As New DataSet(s)
        da.Fill(ds, s)
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                DataGridView1.Rows.Add(New String() {ds.Tables(0).Rows(i).Item("ID"), ds.Tables(0).Rows(i).Item("cname"), ds.Tables(0).Rows(i).Item("ccost"), ds.Tables(0).Rows(i).Item("cdate")})
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
        Dim x As Double = 0

        If txt4.Text <> "" Then x = txt4.Text

        Dim xx As Double = 1
        If TextBox1.Text <> "" Then xx = TextBox1.Text
        Dim cost As Double = x * xx
        Dim ccost As String = cost

        Dim s As String = m & "-" & d & "-" & y


        Dim up As String = "UPDATE closs set "
        up = up + "cname ='" + txt3.Text + "'"
        up = up + ",ccost ='" + ccost + "'"
        up = up + ",cdate ='" + s + "'"
        up = up + ",qun ='" + TextBox1.Text + "'"
        up = up + ",note ='" + TextBox2.Text + "'"
        up = up + "WHERE ID = '" + txt1.Text + "' "


        'Dim myconn As New SqlConnection(str)
        Dim com As New SqlCommand(up, cn1)

        Try
            If cn1.State = ConnectionState.Open Then cn1.Close()

            cn1.Open()
            com.ExecuteNonQuery()
            cn1.Close()




        Catch ex As Exception
            MsgBox("الرجاء التأكد من البيانات", MsgBoxStyle.Exclamation, "خطأ")

            Exit Sub

        End Try

        Dim saddress As String = "00"
        saddress = saddress + txt1.Text
        Dim minusprofit = cost * -1
        Dim pps As String = minusprofit




        Dim upp As String = "UPDATE profit set "
        upp = upp + "pname ='" + txt3.Text + "'"
        upp = upp + ",cost ='" + pps + "'"
        upp = upp + ",tdate ='" + s + "'"
        upp = upp + ",note ='" + TextBox2.Text + "'"
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
            txt3.Text = ""
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
            Dim com As New SqlCommand("delete FROM closs WHERE  id='" + txt1.Text + "'", cn1)
            Try
                If cn1.State = ConnectionState.Open Then cn1.Close()

                cn1.Open()

                com.ExecuteNonQuery()
                cn1.Close()


            Catch ex As Exception
                MsgBox(" الرجاء التأكد من حذف جميع سجلات الخاصة بهذا العنصر بهذا العنصر ", MsgBoxStyle.Exclamation, "خطأ")

                Exit Sub

            End Try


            Dim saddress As String = "00"
            saddress = saddress + txt1.Text
            Dim comm As New SqlCommand("delete FROM profit WHERE  id='" + saddress + "'", cn1)
            Try
                If cn1.State = ConnectionState.Open Then cn1.Close()

                cn1.Open()

                comm.ExecuteNonQuery()
                cn1.Close()

                txt1.Text = ""
                txt3.Text = ""
                txt4.Text = ""


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

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Try
            Dim s As String = ""
            s = DataGridView1.SelectedCells.Item(0).Value.ToString
            '        Dim str As String = "Server=DESKTOP-BRR1N2I;Database=karate;Trusted_Connection=True;
            '"


            '        Dim myconn As New SqlConnection(str)
            Dim com As New SqlCommand("SELECT * FROM closs WHERE  ID='" + s + "'", cn1)

            If cn1.State = ConnectionState.Open Then cn1.Close()
            cn1.Open()
            Dim myreder As SqlDataReader = com.ExecuteReader()
            myreder.Read()

            txt1.Text = myreder("ID")

            txt3.Text = myreder("cname")
            txt4.Text = myreder("ccost")
            DateTimePicker2.Value = myreder("cdate")
            TextBox1.Text = myreder("qun")
            cn1.Close()

        Catch ex As Exception
            MsgBox("الرجاء التأكد نقر المزدوج على خانة رقم العيادة", MsgBoxStyle.Exclamation, "خطأ")

        End Try
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDG()

    End Sub

    Private Sub txt4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt4.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridView1.Rows.Clear()
        Dim s As String = "SELECT * FROM closs where ID='" + TextBox1.Text + "' order by id"
        Dim da As New SqlDataAdapter(s, cn1)
        Dim ds As New DataSet(s)
        da.Fill(ds, s)
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                DataGridView1.Rows.Add(New String() {ds.Tables(0).Rows(i).Item("ID"), ds.Tables(0).Rows(i).Item("cname"), ds.Tables(0).Rows(i).Item("ccost"), ds.Tables(0).Rows(i).Item("cdate")})
                'DataGridView1.Sort(DataGridView1.Columns("Id"), System.ComponentModel.ListSortDirection.Descending)
            Next

        End If
        TextBox1.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FillDG()

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class