Imports System.Data.SqlClient

Public Class UserModel
    Const CONNECTION_STRING As String = "Data Source=PHANVANHIEP\SQLEXPRESS;Initial Catalog=TraningNIC;Integrated Security=SSPI;"
    Public Shared Function LoadData() As DataSet
        Dim conn = New SqlConnection(CONNECTION_STRING)

        conn.Open()

        Dim cmd = "Select * from DEMO_ADO"
        Dim dataAdapter = New SqlDataAdapter(cmd, conn)

        Dim dtSet = New DataSet()

        dataAdapter.Fill(dtSet, "DEMO_ADO")

        conn.Close()

        Return dtSet
    End Function
End Class
