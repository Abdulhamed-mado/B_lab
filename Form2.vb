Imports System.Data.SqlClient

Public Class Form2


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim com As New SqlCommand("insert into clinic values('" + TextBox3.Text + "' , '" + TextBox5.Text + "' )", cn1)

        Try
            If cn1.State = ConnectionState.Open Then cn1.Close()

            cn1.Open()
            com.ExecuteNonQuery()
            cn1.Close()

            TextBox3.Text = ""
            TextBox5.Text = ""
            MsgBox("تم ادخال البيانات")
        Catch ex As Exception
            MsgBox("الرجاء التأكد من  البيانات")
            cn1.Close()
        End Try







        FillDG()
    End Sub
    Sub FillDG()
        DataGridView1.Rows.Clear()
        Dim s As String = "SELECT * FROM clinic where ID<>0 order by id"
        Dim da As New SqlDataAdapter(s, cn1)
        Dim ds As New DataSet(s)
        da.Fill(ds, s)
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                DataGridView1.Rows.Add(New String() {ds.Tables(0).Rows(i).Item("ID"), ds.Tables(0).Rows(i).Item("Ename")})
                'DataGridView1.Sort(DataGridView1.Columns("Id"), System.ComponentModel.ListSortDirection.Descending)
            Next

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim up As String = "UPDATE clinic set "
        up = up + "Ename ='" + TextBox5.Text + "'"
        up = up + "WHERE ID = '" + TextBox3.Text + "' "


        'Dim myconn As New SqlConnection(str)
        Dim com As New SqlCommand(up, cn1)

        Try
            If cn1.State = ConnectionState.Open Then cn1.Close()

            cn1.Open()
            com.ExecuteNonQuery()
            cn1.Close()

            TextBox3.Text = ""
            TextBox5.Text = ""

            MsgBox("تم تعديل البيانات")
        Catch ex As Exception
            MsgBox("الرجاء التأكد من البيانات", MsgBoxStyle.Exclamation, "خطأ")

        End Try


        FillDG()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim result As DialogResult = MsgBox("هل تريد حذف الحكم", MsgBoxStyle.YesNo, "تأكيد")
        If result = DialogResult.Yes Then
            Dim str As String = "Server=LAPTOP-TVMSOSNS\MADONAFO2001;Database=EBA;Trusted_Connection=True;
"



            Dim myconn As New SqlConnection(str)
            Dim com As New SqlCommand("delete FROM clinic WHERE  id='" + TextBox3.Text + "'", cn1)
            Try
                If cn1.State = ConnectionState.Open Then cn1.Close()

                cn1.Open()

                com.ExecuteNonQuery()
                cn1.Close()

                TextBox3.Text = ""
                TextBox5.Text = ""
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
            Dim com As New SqlCommand("SELECT * FROM clinic WHERE  ID='" + s + "'", cn1)

            If cn1.State = ConnectionState.Open Then cn1.Close()
            cn1.Open()
            Dim myreder As SqlDataReader = com.ExecuteReader()
            myreder.Read()

            TextBox3.Text = myreder("ID")

            TextBox5.Text = myreder("Ename")
            cn1.Close()

        Catch ex As Exception
            MsgBox("الرجاء التأكد نقر المزدوج على خانة رقم العيادة", MsgBoxStyle.Exclamation, "خطأ")

        End Try
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDG()

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DataGridView1.Rows.Clear()
        Dim s As String = "SELECT * FROM clinic where ID='" + TextBox1.Text + "' order by id"
        Dim da As New SqlDataAdapter(s, cn1)
        Dim ds As New DataSet(s)
        da.Fill(ds, s)
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                DataGridView1.Rows.Add(New String() {ds.Tables(0).Rows(i).Item("ID"), ds.Tables(0).Rows(i).Item("Ename")})
                'DataGridView1.Sort(DataGridView1.Columns("Id"), System.ComponentModel.ListSortDirection.Descending)
            Next

        End If
        TextBox1.Text = ""

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FillDG()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class