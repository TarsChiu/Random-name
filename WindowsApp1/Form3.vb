Imports System.IO
Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Text = waha
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If F = 0 Then
            Dim Writer As StreamWriter = New StreamWriter(Application.StartupPath + "\GH\" + CStr(train) + ".txt")
            Writer.Write(CStr(RichTextBox1.Text))
            Writer.Close()
            Me.Close()
        Else
            Dim Writer As StreamWriter = New StreamWriter(Application.StartupPath + "\G0\" + "CT.txt")
            Writer.Write(CStr(RichTextBox1.Text))
            Writer.Close()
            Me.Close()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class