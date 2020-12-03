Imports System.IO
Public Class Form1
    Dim Name1
    Dim I
    Dim R As String
    Dim T = 0
    Dim CTT
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Dir(Application.StartupPath + "\Data\", vbDirectory) = "" Then
            MkDir(Application.StartupPath + "\Data\")
            MkDir(Application.StartupPath + "\GH\")
            MkDir(Application.StartupPath + "\G0\")
            IO.File.CreateText(Application.StartupPath + "\Data\Setting.ini").Dispose()
            IO.File.CreateText(Application.StartupPath + "\Data\Connection.ini").Dispose()
            IO.File.CreateText(Application.StartupPath + "\Data\Number.ini").Dispose()
            IO.File.CreateText(Application.StartupPath + "\G0\" + "CT.txt").Dispose()
            Dim Writer As StreamWriter = New StreamWriter(Application.StartupPath + "\Data\Setting.ini")
            Writer.WriteLine("抽取结果为：", 1)
            Writer.WriteLine("抽取集合：", 2)
            Writer.Close()
            Dim Writer1 As StreamWriter = New StreamWriter(Application.StartupPath + "\Data\Number.ini")
            Writer1.WriteLine("0")
            Writer1.Close()
        End If
        Dim reader As StreamReader = New StreamReader(Application.StartupPath + "\Data\Setting.ini")
        Label1.Text = reader.ReadLine()
        Label2.Text = reader.ReadLine()
        reader.Close()
        Dim PathS As New System.IO.DirectoryInfo(Application.StartupPath + "\GH\")
        Dim NameS As System.IO.FileInfo
        For Each NameS In PathS.GetFiles
            Dim FileName = System.IO.Path.GetFileNameWithoutExtension(NameS.Name)
            ComboBox1.Items.Add(FileName)
        Next
        Dim reader4 As StreamReader = New StreamReader(Application.StartupPath + "\Data\Connection.ini")
        ComboBox1.Text = reader4.ReadLine()
        reader4.Close()
        Dim need
        need = ComboBox1.Text
        Dim reader1 As StreamReader = New StreamReader(Application.StartupPath + "\Data\Setting.ini")
        Results = reader1.ReadLine()
        reader1.Close()
        If need <> "" Then
            If F = 0 Then
                Dim reader5 As StreamReader = New StreamReader(Application.StartupPath + "\GH\" + CStr(need) + ".txt")
                Student = reader5.ReadToEnd()
                reader5.Close()
            Else
                Dim reader6 As StreamReader = New StreamReader(Application.StartupPath + "\G0\" + "CT.txt")
                CTT = reader6.ReadToEnd()
                reader6.Close()
            End If
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        NumericUpDown1.Text = NumericUpDown1.Text - 1
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        NumericUpDown1.Text = NumericUpDown1.Text + 1
    End Sub
    Private Sub 开始抽取ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 开始抽取ToolStripMenuItem.Click
        If ComboBox1.Text = "" Then
            MsgBox("请选择集合", vbOKOnly, "提示")
        Else
            ' Timer1.Enabled = True
            'F = F + 1
            ' Button1.Text = “停止抽取”
            'If F = 2 Then
            'Timer1.Enabled = False
            'F = 0
            'Button1.Text = “开始抽取”
            ' End If
            If F = 0 Then
                Do
                    Name1 = Split(Student, " ", -1, 1)
                    Randomize()
                    I = Int(((UBound(Name1) + 1) * Rnd()) + 0)
                    R = R & " " & Name1(I)
                    T = T + 1
                Loop Until T = NumericUpDown1.Text
                T = 0
                Label1.Text = Results & R
            Else
                Do
                    Name1 = Split(CTT, " ", -1, 1)
                    Randomize()
                    I = Int(((UBound(Name1) + 1) * Rnd()) + 0)
                    R = R & " " & Name1(I)
                    T = T + 1
                Loop Until T = NumericUpDown1.Text
                T = 0
                Label1.Text = Results & R
            End If
        End If
            R = ""
    End Sub

    Private Sub 设置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 设置ToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim need
        need = ComboBox1.Text
        Dim reader1 As StreamReader = New StreamReader(Application.StartupPath + "\Data\Setting.ini")
        Results = reader1.ReadLine()
        reader1.Close()
        If F = 0 Then
            Dim reader5 As StreamReader = New StreamReader(Application.StartupPath + "\GH\" + CStr(need) + ".txt")
            Student = reader5.ReadToEnd()
            reader5.Close()
        Else
            Dim reader6 As StreamReader = New StreamReader(Application.StartupPath + "\G0\" + "CT.txt")
            CTT = reader6.ReadToEnd()
            reader6.Close()
        End If
    End Sub
End Class




