Imports System.Data.SqlClient

Public Class DBClass
    Dim strConn As String = "Data Source=.\SQLEXPRESS;Initial Catalog=ShopSampleDB; persist security info=True;user id=sa;password=password;"

    Public Function ConnectDB() As SqlConnection
        Dim Conn As SqlConnection

        Conn = New SqlConnection()

        With Conn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        Return Conn
    End Function

End Class
