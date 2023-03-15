Public Class Form1
    Private Sub btnSpeed_Click(sender As Object, e As EventArgs) Handles btnSpeed.Click
        Dim strSpeed As String
        Dim decSpeed As Decimal
        Dim decSum As Decimal
        Dim decAverage As Decimal = 0D

        Dim intEntry As Integer = 1
        Dim intMaxEntry As Integer = 10

        Dim strIBoxMsg As String = "Please enter your home internet speed in Mbps, user #"
        Dim strIBoxTitle As String = "Internet Speed"
        Dim strValError As String = "That doesn't look like a number! Please try again."
        Dim strNumError As String = "Wow, you have negative speed? Our service is better than we thought!" & vbCrLf & "Just kidding. Try again, user #"


        strSpeed = InputBox(strIBoxMsg & intEntry, strIBoxTitle)

        Do Until intEntry > intMaxEntry Or strSpeed = ""
            strIBoxMsg = strIBoxMsg
            If IsNumeric(strSpeed) Then
                decSpeed = Convert.ToDecimal(strSpeed)

                If decSpeed > 0 Then
                    lstSpeed.Items.Add(decSpeed)
                    decSum += decSpeed
                    intEntry += 1
                    strIBoxMsg = strIBoxMsg
                Else
                    strIBoxMsg = strNumError
                End If
            Else
                strIBoxMsg = strValError
            End If

            If intEntry <= intMaxEntry Then
                strSpeed = InputBox(strIBoxMsg & intEntry, strIBoxTitle)
            End If
        Loop

        If intEntry > 1 Then
            decAverage = decSum / (intEntry - 1)
            lblSpeed.Text = "Average Internet Speed: " + decAverage.ToString + " Mbps"
        Else
            lblSpeed.Text = "No speeds entered!"
        End If



        lstSpeed.Visible = True
        lblSpeed.Visible = True
        btnSpeed.Enabled = False
        btnClear.Enabled = True
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lblSpeed.Visible = False
        lstSpeed.Items.Clear()
        lstSpeed.Visible = False
        btnSpeed.Enabled = True
        btnClear.Enabled = False

    End Sub
End Class
