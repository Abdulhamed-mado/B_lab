Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class Form13
    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim com As New SqlCommand("SELECT * FROM clinic where ID<>0 order by id ", cn1)
        Dim da As New SqlDataAdapter(com)
        Dim dt As New DataTable
        da.Fill(dt)
        With ReportViewer1.LocalReport
            .DataSources.Clear()
            .ReportPath = "Report1.rdlc"
            .DataSources.Add(New ReportDataSource("DataSet1", dt))
        End With

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class