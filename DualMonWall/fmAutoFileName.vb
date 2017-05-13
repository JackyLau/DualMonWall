Public Class fmAutoFileName

    Dim l_OK As Boolean

    Private Sub udDigi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles udDigi.ValueChanged
        ' 新檔名加數之數字長度改變, 更改輸入數字之 "長度限制" (Mask), 及把數字起始初設為 1
        Dim s_Temp As String  ' 檔案名數字字串

        s_Temp = CStr(Val(mtxStart.Text))

        mtxStart.Mask = StrDup(CInt(udDigi.Value), "0")

        If CInt(udDigi.Value) > Len(s_Temp) Then
            mtxStart.Text = StrDup((CInt(udDigi.Value) - Len(s_Temp)), "0")
        Else
            mtxStart.Text = ""
        End If

        mtxStart.Text = mtxStart.Text & s_Temp
    End Sub


    Private Sub btDir_Click(sender As Object, e As EventArgs) Handles btDir.Click
        ' 顯示選擇資料匣位置, 及記憶所選                        
        If fbDir.ShowDialog() <> vbCancel Then
            tbDir.Text = fbDir.SelectedPath
            SaveSetting("Ranseco", "DualMonWall", "FileDir", tbDir.Text)
        End If
    End Sub


    Private Sub fmAutoFileName_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' 若不是按 OK 離開, 把自動選項設定為未選
        If l_OK = False Then fmMain.cbAutoName.Checked = False
    End Sub


    Private Sub fmAutoFileName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 取得原來之設定
        txtLeader.Text = GetSetting("Ranseco", "DualMonWall", "FileLeader", "MyWP")
        mtxStart.Text = Microsoft.VisualBasic.Format(Val(GetSetting("Ranseco", "DualMonWall", "NameCount", 1)), "000")
        fmMain.vNameCount = Val(mtxStart.Text)
        fbDir.SelectedPath = GetSetting("Ranseco", "DualMonWall", "FileDir", My.Computer.FileSystem.SpecialDirectories.MyPictures)
        tbDir.Text = fbDir.SelectedPath
        l_OK = False
    End Sub


    Private Sub txtLeader_Leave(sender As Object, e As EventArgs) Handles txtLeader.Leave
        ' 記憶檔案名頭段
        txtLeader.Text = Trim(txtLeader.Text)
        SaveSetting("Ranseco", "DualMonWall", "FileLeader", txtLeader.Text)
    End Sub


    Private Sub mtxStart_Leave(sender As Object, e As EventArgs) Handles mtxStart.Leave
        ' 處理字串顯示型態
        mtxStart.Text = Microsoft.VisualBasic.Format(Val(mtxStart.Text), StrDup(CInt(udDigi.Value), "0"))
        fmMain.vNameCount = Val(mtxStart.Text)
    End Sub


    Private Sub btOK_Click(sender As Object, e As EventArgs) Handles btOK.Click
        ' 按 OK 離開, 設為 OK
        l_OK = True
        Me.Close()
        ' DeleteSetting("Ranseco", "DualMonWall")  ' 測試用, 正式使用要 Remark 此行
    End Sub

End Class