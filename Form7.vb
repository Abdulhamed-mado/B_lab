Imports System.Data.SqlClient

Public Class Form7
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim d As Integer
        Dim m As Integer
        Dim y As Integer
        d = DateTimePicker2.Value.Day
        m = DateTimePicker2.Value.Month
        y = DateTimePicker2.Value.Year
        Dim s As String = m & "-" & d & "-" & y

        Dim xx As Double = 1
        If txt9.Text <> "" Then xx = txt9.Text


        Dim cost As Double = ucost * xx
        Dim ccost As String = cost



        Try
            '        Dim str As String = "Server=DESKTOP-BRR1N2I;Database=karate;Trusted_Connection=True;
            '"


            '        Dim myconn As New SqlConnection(str)
            Dim coma As New SqlCommand("SELECT * FROM cp WHERE  ID='" + txt3.Text + "'", cn1)

            If cn1.State = ConnectionState.Open Then cn1.Close()
            cn1.Open()
            Dim myreder As SqlDataReader = coma.ExecuteReader()
            myreder.Read()

            txt4.Text = myreder("pname")



            cn1.Close()


        Catch ex As Exception

        End Try

        Dim comm As New SqlCommand("insert into docpat(did,docname,pid,pname,sdate,note,id,qun,tcost) values('" + txt1.Text + "' ,  '" + txt2.Text + "',  '" + txt3.Text + "',  '" + txt4.Text + "' ,'" + s + "', '" + txt6.Text + "', '" + txt8.Text + "', '" + txt9.Text + "', '" + ccost + "' )", cn1)

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


        Dim saddress As String = "000"
        saddress = saddress + txt8.Text
        Dim minusprofit = cost * -1
        Dim pps As String = minusprofit
        Dim ps As String = "مستحقات الفني"

        Dim com As New SqlCommand("insert into profit values('" + saddress + "' , '" + ps + "' , '" + pps + "', '" + s + "', '" + txt6.Text + "', '" + txt9.Text + "' )", cn1)

        Try
            If cn1.State = ConnectionState.Open Then cn1.Close()

            cn1.Open()
            com.ExecuteNonQuery()
            cn1.Close()

            txt1.Text = ""
            txt2.Text = ""
            txt3.Text = ""
            txt4.Text = ""
            txt6.Text = ""
            txt8.Text = ""
            txt9.Text = ""




        Catch ex As Exception

            cn1.Close()
        End Try







        FillDG()
    End Sub
    Sub FillDG()
        DataGridView1.Rows.Clear()
        Dim s As String = "SELECT * FROM docpat where pID<>0 order by pid"
        Dim da As New SqlDataAdapter(s, cn1)
        Dim ds As New DataSet(s)
        da.Fill(ds, s)
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                DataGridView1.Rows.Add(New String() {ds.Tables(0).Rows(i).Item("id"), ds.Tables(0).Rows(i).Item("did"), ds.Tables(0).Rows(i).Item("docname"), ds.Tables(0).Rows(i).Item("pid"), ds.Tables(0).Rows(i).Item("pname"), ds.Tables(0).Rows(i).Item("qun"), ds.Tables(0).Rows(i).Item("tcost"), ds.Tables(0).Rows(i).Item("sdate"), ds.Tables(0).Rows(i).Item("note")})
                'DataGridView1.Sort(DataGridView1.Columns("Id"), System.ComponentModel.ListSortDirection.Descending)
            Next

        End If
    End Sub
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Try
            Dim s As String
            s = DataGridView1.SelectedCells.Item(0).Value.ToString
            '        Dim str As String = "Server=DESKTOP-BRR1N2I;Database=karate;Trusted_Connection=True;
            '"


            '        Dim myconn As New SqlConnection(str)
            Dim com As New SqlCommand("SELECT * FROM docpat WHERE  ID='" + s + "'", cn1)

            If cn1.State = ConnectionState.Open Then cn1.Close()
            cn1.Open()
            Dim myreder As SqlDataReader = com.ExecuteReader()
            myreder.Read()

            txt3.Text = myreder("pid")
            txt4.Text = myreder("pname")
            txt1.Text = myreder("did")
            txt2.Text = myreder("docname")
            txt6.Text = myreder("note")
            txt8.Text = myreder("id")
            txt9.Text = myreder("qun")

            DateTimePicker2.Value = myreder("sdate")

            cn1.Close()

        Catch ex As Exception
            MsgBox("الرجاء التأكد نقر المزدوج على خانة رقم العيادة", MsgBoxStyle.Exclamation, "خطأ")

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim coma As New SqlCommand("SELECT * FROM cp WHERE  ID='" + txt3.Text + "'", cn1)

            If cn1.State = ConnectionState.Open Then cn1.Close()
            cn1.Open()
            Dim myreder As SqlDataReader = coma.ExecuteReader()
            myreder.Read()

            txt4.Text = myreder("pname")



            cn1.Close()


        Catch ex As Exception

        End Try

        Dim d As Integer
        Dim m As Integer
        Dim y As Integer
        d = DateTimePicker2.Value.Day
        m = DateTimePicker2.Value.Month
        y = DateTimePicker2.Value.Year

        Dim s As String = m & "-" & d & "-" & y
        Dim xx As Double = 1
        If txt9.Text <> "" Then xx = txt9.Text


        Dim cost As Double = ucost * xx
        Dim ccost As String = cost

        Dim up As String = "UPDATE docpat set "
        up = up + "pname ='" + txt4.Text + "'"
        up = up + ",did ='" + txt1.Text + "'"
        up = up + ",docname ='" + txt2.Text + "'"
        up = up + ",sdate ='" + s + "'"
        up = up + ",note ='" + txt6.Text + "'"
        up = up + ",tcost ='" + ccost + "'"
        up = up + ",qun ='" + txt9.Text + "'"


        up = up + "WHERE id = '" + txt8.Text + "' "


        'Dim myconn As New SqlConnection(str)
        Dim com As New SqlCommand(up, cn1)

        Try
            If cn1.State = ConnectionState.Open Then cn1.Close()

            cn1.Open()
            com.ExecuteNonQuery()
            cn1.Close()





        Catch ex As Exception
            MsgBox("الرجاء التأكد من البيانات", MsgBoxStyle.Exclamation, "خطأ")
            MsgBox(ex.ToString)
            Exit Sub

        End Try

        Dim saddress As String = "000"
        saddress = saddress + txt8.Text
        Dim minusprofit = cost * -1
        Dim pps As String = minusprofit
        Dim ps As String = "مستحقات الفني"

        Dim upp As String = "UPDATE profit set "
        upp = upp + "pname ='" + ps + "'"
        upp = upp + ",cost ='" + pps + "'"
        upp = upp + ",tdate ='" + s + "'"
        upp = upp + ",note ='" + txt6.Text + "'"
        upp = upp + ",qun ='" + txt9.Text + "'"


        upp = upp + "WHERE id = '" + saddress + "' "

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
            txt6.Text = ""
            txt8.Text = ""
            txt9.Text = ""




            MsgBox("تم تعديل البيانات")

        Catch ex As Exception
            MsgBox("الرجاء التأكد من البيانات", MsgBoxStyle.Exclamation, "خطأ")
            MsgBox(ex.ToString)

        End Try


        userf()


        FillDG()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim result As DialogResult = MsgBox("هل تريد حذف الحكم", MsgBoxStyle.YesNo, "تأكيد")
        If result = DialogResult.Yes Then
            Dim str As String = "Server=LAPTOP-TVMSOSNS\MADONAFO2001;Database=EBA;Trusted_Connection=True;
"



            Dim myconn As New SqlConnection(str)

            Dim com As New SqlCommand("delete FROM docpat WHERE  id='" + txt8.Text + "'", cn1)
            Try
                If cn1.State = ConnectionState.Open Then cn1.Close()

                cn1.Open()

                com.ExecuteNonQuery()
                cn1.Close()


            Catch ex As Exception
                MsgBox(" الرجاء التأكد من حذف جميع سجلات الخاصة بهذا العنصر بهذا العنصر ", MsgBoxStyle.Exclamation, "خطأ")
                Exit Sub
            End Try

        End If

        Dim saddress As String = "000"
        saddress = saddress + txt8.Text
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
            txt6.Text = ""
            txt8.Text = ""
            txt9.Text = ""

            MsgBox("تم حذف البيانات")
        Catch ex As Exception
            MsgBox(" الرجاء التأكد من حذف جميع سجلات الخاصة بهذا العنصر بهذا العنصر ", MsgBoxStyle.Exclamation, "خطأ")

        End Try
        userf()
        FillDG()
    End Sub
    Sub userf()
        Dim lID As String = px
        Try
            Dim ca As New SqlCommand("SELECT * FROM clogin WHERE  ID='" + lID + "'", cn1)

            If cn1.State = ConnectionState.Open Then cn1.Close()
            cn1.Open()
            Dim myreder As SqlDataReader = ca.ExecuteReader()
            myreder.Read()

            txt2.Text = myreder("username")
            txt1.Text = lID
            cn1.Close()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userf()
        FillDG()
    End Sub

    Private Sub txt1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt1.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt5_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt8.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridView1.Rows.Clear()
        Dim s As String = "SELECT * FROM docpat where ID='" + TextBox3.Text + "' order by id"
        Dim da As New SqlDataAdapter(s, cn1)
        Dim ds As New DataSet(s)
        da.Fill(ds, s)
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                DataGridView1.Rows.Add(New String() {ds.Tables(0).Rows(i).Item("id"), ds.Tables(0).Rows(i).Item("did"), ds.Tables(0).Rows(i).Item("docname"), ds.Tables(0).Rows(i).Item("pid"), ds.Tables(0).Rows(i).Item("pname"), ds.Tables(0).Rows(i).Item("qun"), ds.Tables(0).Rows(i).Item("tcost"), ds.Tables(0).Rows(i).Item("sdate"), ds.Tables(0).Rows(i).Item("note")})
                'DataGridView1.Sort(DataGridView1.Columns("Id"), System.ComponentModel.ListSortDirection.Descending)
            Next

        End If
        TextBox3.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FillDG()

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class