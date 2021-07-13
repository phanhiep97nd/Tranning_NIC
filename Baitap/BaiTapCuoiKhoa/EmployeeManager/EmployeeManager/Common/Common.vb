Imports System.Security.Cryptography

Public Class Common
    Public Shared Function EncryptPass(input As String) As String
        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
             hasher.ComputeHash(Encoding.UTF8.GetBytes(input))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using
    End Function

    Public Shared Function GetErrorMessageEdit(input As List(Of String)) As String
        Dim message As New StringBuilder
        For Each item In input
            message.Append("<div class='alert alert-danger' role='alert'><strong>Error!</strong> " & item & "</div>")
        Next
        Return message.ToString
    End Function
End Class
