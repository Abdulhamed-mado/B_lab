Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class Form16
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim com As New SqlCommand("SELECT * FROM profit ", cn1)
        Dim da As New SqlDataAdapter(com)
        Dim dt As New DataTable
        da.Fill(dt)
        With ReportViewer1.LocalReport
            .DataSources.Clear()
            .ReportPath = "Report8.rdlc"
            .DataSources.Add(New ReportDataSource("DataSet1", dt))
        End With
        Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim thisDate As Date
        thisDate = Today.Date
        Dim d As Integer
        Dim m As Integer
        Dim y As Integer
        d = thisDate.Day
        m = thisDate.Month
        y = thisDate.Year
        Dim s As String = m & "-" & d & "-" & y

        Dim com As New SqlCommand("SELECT * FROM profit where cast(tdate as date)= '" + s + "'  ", cn1)
        Dim da As New SqlDataAdapter(com)
        Dim dt As New DataTable
        da.Fill(dt)
        With ReportViewer1.LocalReport
            .DataSources.Clear()
            .ReportPath = "Report8.rdlc"
            .DataSources.Add(New ReportDataSource("DataSet1", dt))
        End With
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim com As New SqlCommand("select* from profit where month(tdate)= month(getdate())  ", cn1)
        Dim da As New SqlDataAdapter(com)
        Dim dt As New DataTable
        da.Fill(dt)
        With ReportViewer1.LocalReport
            .DataSources.Clear()
            .ReportPath = "Report8.rdlc"
            .DataSources.Add(New ReportDataSource("DataSet1", dt))
        End With
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim com As New SqlCommand("select* from profit where year(tdate)= year(getdate()) ", cn1)
        Dim da As New SqlDataAdapter(com)
        Dim dt As New DataTable
        da.Fill(dt)
        With ReportViewer1.LocalReport
            .DataSources.Clear()
            .ReportPath = "Report8.rdlc"
            .DataSources.Add(New ReportDataSource("DataSet1", dt))
        End With
        Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim d As Integer
        Dim m As Integer
        Dim y As Integer
        d = DateTimePicker2.Value.Day
        m = DateTimePicker2.Value.Month
        y = DateTimePicker2.Value.Year
        Dim s As String = m & "-" & d & "-" & y

        Dim com As New SqlCommand("SELECT * FROM profit where cast(tdate as date)= '" + s + "'", cn1)
        Dim da As New SqlDataAdapter(com)
        Dim dt As New DataTable
        da.Fill(dt)
        With ReportViewer1.LocalReport
            .DataSources.Clear()
            .ReportPath = "Report8.rdlc"
            .DataSources.Add(New ReportDataSource("DataSet1", dt))
        End With
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Form16_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim com As New SqlCommand("SELECT * FROM profit ", cn1)
        Dim da As New SqlDataAdapter(com)
        Dim dt As New DataTable
        da.Fill(dt)
        With ReportViewer1.LocalReport
            .DataSources.Clear()
            .ReportPath = "Report8.rdlc"
            .DataSources.Add(New ReportDataSource("DataSet1", dt))
        End With
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class