Imports System.Data.SqlClient

Module Module1
    'Dim s1 As String = "Server=" & My.Computer.Name & ";Initial Catalog=Karate;Integrated Security=True"
    Dim s1 As String = "Server=DESKTOP-EDI2GIR;Database=EBA;Trusted_Connection=True;"
    Public cn1 As New SqlConnection(s1)
    Public z As String
    Public px As Integer = -1
    Public ucost As Integer

End Module
