Imports System.IO
Public Class Form2
    Public nod
    Dim CClosing
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CClosing = 0
        Me.ActiveControl = Button2
        ListBox1.Items.Clear()
        Dim PathS As New System.IO.DirectoryInfo(Application.StartupPath + "\GH\")
        Dim NameS As System.IO.FileInfo
        For Each NameS In PathS.GetFiles
            Dim FileName = System.IO.Path.GetFileNameWithoutExtension(NameS.Name)
            ListBox1.Items.Add(FileName)
        Next
        ComboBox1.Items.Clear()
        Dim PathS2 As New System.IO.DirectoryInfo(Application.StartupPath + "\GH\")
        Dim NameS2 As System.IO.FileInfo
        For Each NameS2 In PathS2.GetFiles
            Dim FileName = System.IO.Path.GetFileNameWithoutExtension(NameS2.Name)
            ComboBox1.Items.Add(FileName)
        Next
        Dim reader As StreamReader = New StreamReader(Application.StartupPath + "\Data\Setting.ini")
        TextBox1.Text = reader.ReadLine()
        TextBox2.Text = reader.ReadLine()
        reader.Close()
        Dim reader4 As StreamReader = New StreamReader(Application.StartupPath + "\Data\Connection.ini")
        ComboBox1.Text = reader4.ReadLine()
        reader4.Close()
    End Sub
    Function LoadComboBox()
        ComboBox1.Items.Clear()
        Dim PathS2 As New System.IO.DirectoryInfo(Application.StartupPath + "\GH\")
        Dim NameS2 As System.IO.FileInfo
        For Each NameS2 In PathS2.GetFiles
            Dim FileName = System.IO.Path.GetFileNameWithoutExtension(NameS2.Name)
            ComboBox1.Items.Add(FileName)
        Next
        Return “OK”
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "文本文档(*.txt)|*.txt"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Results = TextBox1.Text
        Gather = TextBox2.Text
        Dim Writer As StreamWriter = New StreamWriter(Application.StartupPath + "\Data\Setting.ini")
        Writer.WriteLine(Results, 1)
        Writer.WriteLine(Gather, 2)
        Writer.Close()
        Dim Writer1 As StreamWriter = New StreamWriter(Application.StartupPath + "\Data\Connection.ini")
        Writer1.WriteLine(ComboBox1.SelectedItem)
        Writer1.Close()
        Dim PathS As New System.IO.DirectoryInfo(Application.StartupPath + "\GH\")
        Dim NameS As System.IO.FileInfo
        Form1.ComboBox1.Items.Clear()
        For Each NameS In PathS.GetFiles
            Dim FileName = System.IO.Path.GetFileNameWithoutExtension(NameS.Name)
            Form1.ComboBox1.Items.Add(FileName)
        Next
        Form1.ComboBox1.Text = Me.ComboBox1.Text
        CClosing = 1
        Me.Close()
    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim filepath2 As String = OpenFileDialog1.FileName
        Dim reader As StreamReader = New StreamReader(OpenFileDialog1.FileName)
        Student = reader.ReadToEnd()
        reader.Close()
    End Sub
    Private Sub OpenFileDialog2_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk
        Dim stu
        Dim filepath2 As String = OpenFileDialog2.FileName
        Dim reader As StreamReader = New StreamReader(OpenFileDialog2.FileName)
        stu = reader.ReadToEnd()
        reader.Close()
        Dim Writer As StreamWriter = New StreamWriter(Application.StartupPath + "\GH\" + CStr(ListBox1.SelectedItem) + ".txt")
        Writer.Write(stu)
        Writer.Close()
    End Sub
    Private Sub 导入ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 导入ToolStripMenuItem.Click
        OpenFileDialog2.Filter = "文本文档(*.txt)|*.txt"
        OpenFileDialog2.FilterIndex = 1
        OpenFileDialog2.ShowDialog()
    End Sub
    Private Sub 编写ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 编写ToolStripMenuItem.Click
        If CStr(ListBox1.SelectedItem) = "" Then
            MsgBox("请选择集合……", vbInformation, "Error")
        Else
            train = CStr(ListBox1.SelectedItem)
            Dim reader As StreamReader = New StreamReader(Application.StartupPath + "\GH\" + CStr(ListBox1.SelectedItem) + ".txt")
            waha = reader.ReadToEnd()
            reader.Close()
            Form3.Show()
        End If
    End Sub
    Private Sub 新建ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新建ToolStripMenuItem.Click
        Dim reader As StreamReader = New StreamReader(Application.StartupPath + "\Data\Number.ini")
        nod = reader.ReadToEnd()
        reader.Close()
        nod = nod + 1
        ListBox1.Items.Add(nod)
        IO.File.CreateText(Application.StartupPath + "\GH\" + CStr(nod) + ".txt").Dispose()
        Dim Writer2 As StreamWriter = New StreamWriter(Application.StartupPath + "\Data\Number.ini")
        Writer2.Write(CStr(nod))
        Writer2.Close()
        LoadComboBox()
    End Sub
    Private Sub 删除ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 删除ToolStripMenuItem.Click
        Dim del As String
        Dim reader As StreamReader = New StreamReader(Application.StartupPath + "\Data\Number.ini")
        nod = reader.ReadLine()
        reader.Close()
        nod = nod - 1
        If ListBox1.SelectedIndex = -1 Then
            MsgBox("请选择要删除的项目！"， vbInformation, "未选中的项目")
        Else
            del = ListBox1.SelectedItem
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            IO.File.Delete(Application.StartupPath + "\GH\" + del + ".txt")
            Dim Writer As StreamWriter = New StreamWriter(Application.StartupPath + "\Data\Number.ini")
            Writer.Write(CStr(nod))
            Writer.Close()
        End If
        LoadComboBox()
    End Sub
    Private Sub 重命名ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 重命名ToolStripMenuItem.Click
        Dim MYname As String
        Dim Old As String
        Old = ListBox1.SelectedItem.ToString
        MYname = InputBox("请输入新的名称", "输入",)
        If MYname = "" = False Then
            IO.File.Move(Application.StartupPath + "\GH\" + CStr(Old) + ".txt", Application.StartupPath + "\GH\" + CStr(MYname) + ".txt")
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            ListBox1.Items.Add(MYname)
        End If
        LoadComboBox()
    End Sub
    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim a
        If CClosing = 0 Then
            a = MsgBox("是否保存更改？", vbYesNo, "更改提示")
            If a = vbYes Then
                Results = TextBox1.Text
                Gather = TextBox2.Text
                Dim Writer As StreamWriter = New StreamWriter(Application.StartupPath + "\Data\Setting.ini")
                Writer.WriteLine(Results, 1)
                Writer.WriteLine(Gather, 2)
                Writer.Close()
                Dim Writer1 As StreamWriter = New StreamWriter(Application.StartupPath + "\Data\Connection.ini")
                Writer1.WriteLine(ComboBox1.SelectedItem)
                Writer1.Close()
                Dim PathS As New System.IO.DirectoryInfo(Application.StartupPath + "\GH\")
                Dim NameS As System.IO.FileInfo
                Form1.ComboBox1.Items.Clear()
                For Each NameS In PathS.GetFiles
                    Dim FileName = System.IO.Path.GetFileNameWithoutExtension(NameS.Name)
                    Form1.ComboBox1.Items.Add(FileName)
                Next
                Form1.ComboBox1.Text = Me.ComboBox1.Text
            End If
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim reader As StreamReader = New StreamReader(Application.StartupPath + "\Data\Number.ini")
        nod = reader.ReadToEnd()
        reader.Close()
        nod = nod + 1
        ListBox1.Items.Add(nod)
        IO.File.CreateText(Application.StartupPath + "\GH\" + CStr(nod) + ".txt").Dispose()
        Dim Writer2 As StreamWriter = New StreamWriter(Application.StartupPath + "\Data\Number.ini")
        Writer2.Write(CStr(nod))
        Writer2.Close()
        LoadComboBox()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim del As String
        Dim reader As StreamReader = New StreamReader(Application.StartupPath + "\Data\Number.ini")
        nod = reader.ReadLine()
        reader.Close()
        nod = nod - 1
        If ListBox1.SelectedIndex = -1 Then
            MsgBox("请选择要删除的项目！"， vbInformation, "未选中的项目")
        Else
            del = ListBox1.SelectedItem
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            IO.File.Delete(Application.StartupPath + "\GH\" + del + ".txt")
            Dim Writer As StreamWriter = New StreamWriter(Application.StartupPath + "\Data\Number.ini")
            Writer.Write(CStr(nod))
            Writer.Close()
        End If
        LoadComboBox()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenFileDialog2.Filter = "文本文档(*.txt)|*.txt"
        OpenFileDialog2.FilterIndex = 1
        OpenFileDialog2.ShowDialog()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If CStr(ListBox1.SelectedItem) = "" Then
            MsgBox("请选择集合", vbInformation, "Error")
        Else
            train = CStr(ListBox1.SelectedItem)
            Dim reader As StreamReader = New StreamReader(Application.StartupPath + "\GH\" + CStr(ListBox1.SelectedItem) + ".txt")
            waha = reader.ReadToEnd()
            reader.Close()
            Form3.Show()
        End If
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim MYname As String
        Dim Old As String
        Old = ListBox1.SelectedItem.ToString
        MYname = InputBox("请输入新的名称", "输入",)
        If MYname = "" = False Then
            IO.File.Move(Application.StartupPath + "\GH\" + CStr(Old) + ".txt", Application.StartupPath + "\GH\" + CStr(MYname) + ".txt")
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            ListBox1.Items.Add(MYname)
        End If
        LoadComboBox()
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim MyMonth As Integer = Format(Now, "MM")
        Dim MyDay As Integer = Format(Now, "dd")
        Dim Password
        Password = InputBox("请输入今天的密钥", "作弊")
        If Password = "" Then
        Else
            If Password = Math.Round((MyMonth + MyDay) * 365 / 7, 2) Then
                F = 1
                If Me.ComboBox1.Text = "" Then
                    MsgBox("请选取默认抽取集合", 16, "作弊")
                Else
                    Dim reader As StreamReader = New StreamReader(Application.StartupPath + "\GH\" + Me.ComboBox1.Text + ".txt")
                    waha = reader.ReadToEnd()
                    reader.Close()
                    Form3.Show()
                End If
            Else
                MsgBox("密钥错误")
            End If
        End If
    End Sub
End Class
