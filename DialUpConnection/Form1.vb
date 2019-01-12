' WWW.30sharp.com
Imports System.Net
Public Class Form1
    Dim webreq As HttpWebRequest
    Dim webresp As HttpWebResponse

    'Funtion returns true or false base on the HttpStatusCode
    Function CheckConnection(ByVal url As String) As Boolean
        Dim strurl As String = url
        Dim bConnected As Boolean = False
        Try
            webreq = WebRequest.Create(strurl)
            webresp = webreq.GetResponse
            If webresp.StatusCode = HttpStatusCode.OK Then
                bConnected = True
            Else
                bConnected = False
            End If
            Return bConnected
        Catch ex As Exception
            bConnected = False
            Return bConnected
        Finally
            webresp = Nothing
        End Try
    End Function
    Private Sub btnConnect_Click(ByVal sender As System.Object, _
     ByVal e As System.EventArgs) Handles btnConnect.Click
        Dim lNg As Integer
        Dim urlString As String = TextBox1.Text
        Dim isConnected As Boolean = CheckConnection(urlString)
        If isConnected Then
            System.Diagnostics.Process.Start("iexplore", urlString)
        Else
            Dim ans As String = MsgBox("Do you want to connect?", _
            MsgBoxStyle.YesNo, "No Connected")

            If ans = vbYes Then
                lNg = Shell("rundll32.exe shell32.dll,Control_RunDLL ncpa.cpl,,0")
            Else
                MsgBox("Sorry canot connect you chose no...")
            End If
        End If
    End Sub
End Class
