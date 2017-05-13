Public Class fmMain

    Const OffsetX As Integer = 8  ' 視窗左面之邊緣大小
    Const OffsetY As Integer = 30  ' 視窗上面之邊緣大小
    Const l_ResetBox As Boolean = False  ' 設定當有照片拉入時, 是否要重置 "照片選擇匡" (副視窗) 為看不見 .... True = 要重置, False = 保留

    Public MyMajor As String = ""  ' 版本號 (主)
    Public MyRevision As String = ""  ' 版本號 (副)

    Public vNameCount As Integer  ' 自動檔稱的後段數字 (供自動檔名用 .... 例: 001)

    Dim vBoxDrawing As Boolean  ' 照片之 "照片選擇內匡 (副視窗)" 正在繪畫中 (未完成一個框)
    Dim l_MouseOK As Boolean  ' 是否可以在 MouseMove, MouseUp 讀取(計算)滑鼠之位置旗號

    Dim vStart As Point  ' 第一下按下滑鼠時的位置
    Dim vTopS As Point  ' 記錄照片選擇匡最後停留的左上位置 (相對於主視窗位置), 用作移動整個主視窗時, 一併移動副視窗 (照片選擇匡) .... 上圖
    Dim vBottomS As Point  ' 同上 .... 下圖
    Dim vLeftS As Point  ' 同上 .... 左圖
    Dim vRightS As Point  ' 同上 .... 右圖

    Dim fmMoving As Form  ' 正在改變大小中的視窗 (共用變數)
    Dim fmTop As Form  ' 照片選擇匡視窗實體 ... 上圖
    Dim fmBottom As Form  ' 同上 .... 下圖
    Dim fmLeft As Form  ' 同上 .... 左圖
    Dim fmRight As Form  ' 同上 .... 右圖

    Dim vTopLeftRatioXY As Single  ' 文字匡內之 "顯示器 (Monitor)" 長寬比 (用作限定照片選擇匡之 "寬長比") .... 上圖/左圖
    Dim vBottomRightRatioXY As Single  ' 同上 .... 下圖/右圖

    Dim bmTemp As Bitmap  ' 暫存圖檔, 用於製作輸出完成圖


    Private Sub fmMain_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        ' 視窗不在作用時, 把 "照片選擇匡" (副視窗) 隱藏, 因為 "副視窗", 是透明及在最上層, 若顯示, 整個 Windows 會有無謂的方匡出現
        fmTop.Visible = False
        fmBottom.Visible = False
        fmLeft.Visible = False
        fmRight.Visible = False
    End Sub


    Private Sub fmMain_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ' 視窗再作用時, 把 "照片選擇匡" (副視窗) 再重新顯示
        fmTop.Visible = True  ' 最下面仍有相同的一句 (Fix VB Bug)
        fmBottom.Visible = True
        fmLeft.Visible = True
        fmRight.Visible = True
        fmTop.Visible = True  ' 因為第一行有可能不會執行 !
    End Sub


    Private Sub fmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' 只容許同時開啟唯一一個程式 (不可多次同時執行同一程式)
        If UBound(Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName)) > 0 Then Application.Exit()

        ' 處理標題之版本號顯示
        Try
            MyMajor = My.Application.Deployment.CurrentVersion.Major
            MyRevision = My.Application.Deployment.CurrentVersion.Revision
        Catch ex As System.Deployment.Application.InvalidDeploymentException
            MyMajor = My.Application.Info.Version.Major
            MyRevision = My.Application.Info.Version.Revision
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.Text = Me.Text & "  -  Version: " & MyMajor & "." & MyRevision

        ' 複製及顯示 "照片選擇匡" (副視窗) .... 隱藏在主視窗的最左上角 (只看到一小點)
        fmTop = New fmOutLine
        fmBottom = New fmOutLine
        fmLeft = New fmOutLine
        fmRight = New fmOutLine

        fmTop.Show()
        fmBottom.Show()
        fmLeft.Show()
        fmRight.Show()

        ' 令照片匡可以拉入照片
        pbTop.AllowDrop = True
        pbBottom.AllowDrop = True
        pbLeft.AllowDrop = True
        pbRight.AllowDrop = True

        l_MouseOK = False

        ' 設定文字
        lblSaved.Text = "Saved"
        lblSaved.Visible = False
        lblSaved.BringToFront()

        ' 取得兩個顯示器 (Monitor) 之大小值
        tbWidthTopLeft.Text = Screen.PrimaryScreen.Bounds.Width
        tbHeightTopLeft.Text = Screen.PrimaryScreen.Bounds.Height
        Try
            tbWidthBottomRight.Text = Screen.AllScreens(1).Bounds.Width
            tbHeightBottomRight.Text = Screen.AllScreens(1).Bounds.Height
        Catch ex As System.IndexOutOfRangeException
            Exit Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub p_ResetBox(vBox As Char)
        ' 重置 "照片選擇匡" (副視窗) 於左上角 (達至看不到) .... VBox = 要重置的 "照片選擇匡" (副視窗)
        Select Case vBox
            Case "T"
                fmTop.Top = Me.Top
                fmTop.Left = Me.Left
                fmTop.Width = 1
                fmTop.Height = 1
                vTopS.X = 0
                vTopS.Y = 0
            Case "B"
                fmBottom.Top = Me.Top
                fmBottom.Left = Me.Left
                fmBottom.Width = 1
                fmBottom.Height = 1
                vBottomS.X = 0
                vBottomS.Y = 0
            Case "L"
                fmLeft.Top = Me.Top
                fmLeft.Left = Me.Left
                fmLeft.Width = 1
                fmLeft.Height = 1
                vLeftS.X = 0
                vLeftS.Y = 0
            Case "R"
                fmRight.Top = Me.Top
                fmRight.Left = Me.Left
                fmRight.Width = 1
                fmRight.Height = 1
                vRightS.X = 0
                vRightS.Y = 0
        End Select
    End Sub


    Private Sub pbAllPB_DragEnter(sender As Object, e As DragEventArgs) Handles pbTop.DragEnter, pbRight.DragEnter, pbLeft.DragEnter, pbBottom.DragEnter
        ' 當有檔案拉入, 顯示出可拉入的 ICON, 確定是檔案 (不是其他物件), 確定只有一個檔案, 確定不是資料匣, 確定是 JPG 檔
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim vfilename() As String = e.Data.GetData(DataFormats.FileDrop)
            If (vfilename.Length = 1) AndAlso (FileIO.FileSystem.DirectoryExists(vfilename(0)) = False) AndAlso (UCase(FileIO.FileSystem.GetFileInfo(vfilename(0)).Extension) = ".JPG") Then e.Effect = DragDropEffects.Copy
        End If
    End Sub


    Private Sub pbAllPB_DragDrop(sender As Object, e As DragEventArgs) Handles pbTop.DragDrop, pbRight.DragDrop, pbLeft.DragDrop, pbBottom.DragDrop
        ' 有檔案拉入照片匡, 顯示拉入的照片

        Dim vFileName() As String  ' 拉入的檔案名 (照片存放位置)

        ' 把焦點重新設定在主視窗 (令繪 "照片選擇匡" (副視窗) 比較暢順)
        Me.Focus()

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            vFileName = e.Data.GetData(DataFormats.FileDrop)

            ' 確定是檔案 (不是其他物件), 確定只有一個檔案, 確定不是資料匣, 確定是 JPG 檔
            If (vFileName.Length = 1) AndAlso (FileIO.FileSystem.DirectoryExists(vFileName(0)) = False) AndAlso (UCase(FileIO.FileSystem.GetFileInfo(vFileName(0)).Extension) = ".JPG") Then

                ' 若已有舊照片, 先釋放資源
                If sender.image IsNot Nothing Then sender.Image.Dispose()

                sender.Image = Image.FromFile(vFileName(0))

                Select Case sender.name
                    Case "pbTop"
                        ' 利用另一邊 "圖片匡" 是可有圖片存在, 來判斷主視窗是否在顯示四個圖片匡 (上,下,左,右), 若是, 處理以下工作
                        If pbBottom.Image Is Nothing Then
                            ' 關閉不相關的兩個 (例如, 拉入在上圖片匡, 關閉左右圖片匡)
                            pbLeft.Visible = False
                            pbRight.Visible = False
                            Call p_ResetBox("L")
                            Call p_ResetBox("R")

                            ' 把主視窗縮小, 只顯示使用中的兩個 (令桌面空間增大)
                            Me.Left = Me.Left + pbLeft.Width
                            pCenter.Left = pCenter.Left - pbLeft.Width
                            pbTop.Left = pbTop.Left - pbLeft.Width
                            pbBottom.Left = pbTop.Left
                            Me.Width = Me.Width - pbLeft.Width - pbLeft.Width
                        End If
                        If l_ResetBox Then
                            ' 重置 (隱藏) "照片選擇匡" (副視窗) 
                            Call p_ResetBox("T")
                        Else
                            ' 暫存現時的 "照片選擇匡" (副視窗) 到 "fmMoving 視窗變數"
                            fmMoving = fmTop
                        End If
                    Case "pbBottom"
                        If pbTop.Image Is Nothing Then
                            pbLeft.Visible = False
                            pbRight.Visible = False
                            Call p_ResetBox("L")
                            Call p_ResetBox("R")

                            Me.Left = Me.Left + pbLeft.Width - 10
                            pCenter.Left = pCenter.Left - pbLeft.Width
                            pbTop.Left = pbTop.Left - pbLeft.Width
                            pbBottom.Left = pbTop.Left
                            Me.Width = Me.Width - pbLeft.Width - pbLeft.Width
                        End If
                        If l_ResetBox Then
                            Call p_ResetBox("B")
                        Else
                            fmMoving = fmBottom
                        End If
                    Case "pbLeft"
                        If pbRight.Image Is Nothing Then
                            pbTop.Visible = False
                            pbBottom.Visible = False
                            Call p_ResetBox("T")
                            Call p_ResetBox("B")

                            Me.Top = Me.Top + pbLeft.Top - 10
                            pCenter.Top = pbTop.Top + pCenter.Top - pbLeft.Top
                            pbLeft.Top = pbTop.Top
                            pbRight.Top = pbLeft.Top
                            Me.Height = Me.Height - pbTop.Height - pCenter.Height
                        End If
                        If l_ResetBox Then
                            Call p_ResetBox("L")
                        Else
                            fmMoving = fmLeft
                        End If
                    Case "pbRight"
                        If pbLeft.Image Is Nothing Then
                            pbTop.Visible = False
                            pbBottom.Visible = False
                            Call p_ResetBox("T")
                            Call p_ResetBox("B")

                            Me.Top = Me.Top + pbLeft.Top
                            pCenter.Top = pbTop.Top + pCenter.Top - pbLeft.Top
                            pbLeft.Top = pbTop.Top
                            pbRight.Top = pbLeft.Top
                            Me.Height = Me.Height - pbTop.Height - pCenter.Height
                        End If
                        If l_ResetBox Then
                            Call p_ResetBox("R")
                        Else
                            fmMoving = fmRight
                        End If
                End Select
                ' 若視窗是顯示中, 把 "照片選擇匡" (副視窗) 納入照片內 (令它不出界)
                If (l_ResetBox = False) AndAlso (fmMoving.Width > 2) AndAlso (fmMoving.Height > 2) Then Call p_FitInPic(sender)
            End If
        End If
    End Sub


    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        ' 刪除所有已拉入的照片, 重新開始

        Dim n_Temp As Integer  ' 計算照片匡在主視窗顯示位置用

        ' 把主視窗呎吋重新改大為顯示全部, 整理照片匡的正確顯示位置
        If pbLeft.Visible = False Then
            Me.Width = Me.Width + pbLeft.Width + pbLeft.Width
            pCenter.Left = pCenter.Left + pbLeft.Width
            pbTop.Left = pbTop.Left + pbLeft.Width
            pbBottom.Left = pbTop.Left
            Me.Left = Me.Left - pbTop.Width
        ElseIf pbTop.Visible = False Then
            Me.Height = Me.Height + pbTop.Height + pCenter.Height
            n_Temp = pCenter.Top - pbTop.Top
            pCenter.Top = pbTop.Top + pbTop.Height + 3
            pbLeft.Top = pCenter.Top - n_Temp
            pbRight.Top = pbLeft.Top
            Me.Top = Me.Top - pbLeft.Top + 10
        End If

        ' 釋放資源
        If pbTop.Image IsNot Nothing Then pbTop.Image.Dispose()
        If pbBottom.Image IsNot Nothing Then pbBottom.Image.Dispose()
        If pbLeft.Image IsNot Nothing Then pbLeft.Image.Dispose()
        If pbRight.Image IsNot Nothing Then pbRight.Image.Dispose()

        ' 刪除照片
        pbTop.Image = Nothing
        pbBottom.Image = Nothing
        pbLeft.Image = Nothing
        pbRight.Image = Nothing

        ' 重新再顯示所有照片匡
        pbTop.Visible = True
        pbBottom.Visible = True
        pbLeft.Visible = True
        pbRight.Visible = True

        ' 把所有 "照片選擇匡" (副視窗) 隱藏
        Call p_ResetBox("T")
        Call p_ResetBox("B")
        Call p_ResetBox("L")
        Call p_ResetBox("R")
    End Sub


    Private Sub btFlip_Click(sender As Object, e As EventArgs) Handles btFlip.Click
        ' 對調已拉入的兩張照片 ...... 因為照片已對調, 所以重置 "照片選擇匡" (副視窗) 
        Dim p_Temp As Image
        If (pbTop.Visible = True) And (pbLeft.Visible = False) Then
            p_Temp = pbTop.Image
            pbTop.Image = pbBottom.Image
            pbBottom.Image = p_Temp
            Call p_ResetBox("T")
            Call p_ResetBox("B")
        ElseIf (pbLeft.Visible = True) And (pbTop.Visible = False) Then
            p_Temp = pbLeft.Image
            pbLeft.Image = pbRight.Image
            pbRight.Image = p_Temp
            Call p_ResetBox("L")
            Call p_ResetBox("R")
        End If
    End Sub


    Private Sub btTurnTL_Click(sender As Object, e As EventArgs) Handles btTurnTL.Click
        ' 轉動照片順時針 90 度, 及重新整理 "照片選擇匡" (副視窗) .... 照片匡 .. 上/左
        If (pbTop.Visible = True) And (pbLeft.Visible = False) And (pbTop.Image IsNot Nothing) Then
            Call p_Rotate90(pbTop)
            fmMoving = fmTop
            If (fmMoving.Width > 2) And (fmMoving.Height > 2) Then Call p_FitInPic(pbTop)
        ElseIf (pbLeft.Visible = True) And (pbTop.Visible = False) And (pbLeft.Image IsNot Nothing) Then
            Call p_Rotate90(pbLeft)
            fmMoving = fmLeft
            If (fmMoving.Width > 2) And (fmMoving.Height > 2) Then Call p_FitInPic(pbLeft)
        End If
    End Sub


    Private Sub btTurnBR_Click(sender As Object, e As EventArgs) Handles btTurnBR.Click
        ' 轉動照片順時針 90 度, 及重新整理 "照片選擇匡" (副視窗) .... 照片匡 .. 下/右 
        If (pbBottom.Visible = True) And (pbRight.Visible = False) And (pbBottom.Image IsNot Nothing) Then
            Call p_Rotate90(pbBottom)
            fmMoving = fmBottom
            If (fmMoving.Width > 2) And (fmMoving.Height > 2) Then Call p_FitInPic(pbBottom)
        ElseIf (pbRight.Visible = True) And (pbBottom.Visible = False) And (pbRight.Image IsNot Nothing) Then
            Call p_Rotate90(pbRight)
            fmMoving = fmRight
            If (fmMoving.Width > 2) And (fmMoving.Height > 2) Then Call p_FitInPic(pbRight)
        End If
    End Sub


    Private Sub p_Rotate90(vPic As PictureBox)
        ' 轉動照片順時針 90 度 ..... vPic = 照片匡名字 (例: pbTop)
        Dim b_Temp As Drawing.Bitmap
        b_Temp = vPic.Image
        b_Temp.RotateFlip(RotateFlipType.Rotate90FlipNone)
        vPic.Image = b_Temp
    End Sub


    Private Sub pbALL_MouseDown(sender As Object, e As MouseEventArgs) Handles pbTop.MouseDown, pbRight.MouseDown, pbLeft.MouseDown, pbBottom.MouseDown
        ' 剛在照片匡內按下滑鼠,處理 "照片選擇匡" (副視窗) 

        ' 確定已有照片顯示在按下滑鼠之照片匡
        If (sender.image IsNot Nothing) And (e.Button = MouseButtons.Left) Then
            ' 設定暫存之 "照片選擇匡" (副視窗) 變數 fmMoving, 以作後續的處理
            Select Case sender.name
                Case "pbTop"
                    fmMoving = fmTop
                Case "pbBottom"
                    fmMoving = fmBottom
                Case "pbLeft"
                    fmMoving = fmLeft
                Case "pbRight"
                    fmMoving = fmRight
            End Select

            ' 若未曾在這照片匡劃過 "照片選擇匡" (副視窗), 或現時滑鼠所點之處是離開  "照片選擇匡" (副視窗), 重新設定 "照片選擇匡" (副視窗)之大小為最小
            If ((Me.Top + sender.Top + e.Y + OffsetY) < fmMoving.Top) Or ((Me.Left + sender.Left + e.X + OffsetX) < fmMoving.Left) Or (e.X > (fmMoving.Left + fmMoving.Width - Me.Left - sender.Left - OffsetX)) Or (e.Y > (fmMoving.Top + fmMoving.Height - Me.Top - sender.Top - OffsetY)) Then
                fmMoving.Left = (Me.Left + sender.Left + e.X + OffsetX)
                fmMoving.Top = (Me.Top + sender.Top + e.Y + OffsetY)
                fmMoving.Width = 1
                fmMoving.Height = 1
                vBoxDrawing = True
            End If

            ' 記著開始之滑鼠位置
            vStart = e.Location

            ' 設定續下的滑鼠動作可行
            l_MouseOK = True
        Else
            l_MouseOK = False
        End If
    End Sub


    Private Sub pbALL_MouseMove(sender As Object, e As MouseEventArgs) Handles pbTop.MouseMove, pbRight.MouseMove, pbLeft.MouseMove, pbBottom.MouseMove
        ' 滑鼠移動, 開始劃 "照片選擇匡" (副視窗) 
        If (l_MouseOK) And (e.Button = Windows.Forms.MouseButtons.Left) Then
            Dim vBoxRatioXY As Single  ' "照片選擇匡" (副視窗) 之長寬比

            If (vBoxDrawing) Then
                ' 正在開始繪畫 "照片選擇匡" (副視窗), 滑鼠動作現時為 ●改變● "照片選擇匡" (副視窗) 大小
                ' 設定現時計算之 "照片選擇匡" (副視窗) 之 "長寬比" 為 上/左 顯示器, 或 下/右 顯示器 (Monitor)
                If (sender.name = "pbTop") Or (sender.name = "pbLeft") Then vBoxRatioXY = vTopLeftRatioXY Else vBoxRatioXY = vBottomRightRatioXY
                If vBoxRatioXY = 0 Then
                    ' 未有設定長寬比, 自由繪畫
                    fmMoving.Width = (e.X - vStart.X)
                    fmMoving.Height = (e.Y - vStart.Y)
                ElseIf (e.X - vStart.X) < (e.Y - vStart.Y) Then
                    ' 硬定長寬比
                    fmMoving.Width = (e.X - vStart.X)
                    fmMoving.Height = fmMoving.Width / vBoxRatioXY
                Else
                    ' 硬定長寬比
                    fmMoving.Height = (e.Y - vStart.Y)
                    fmMoving.Width = fmMoving.Height * vBoxRatioXY
                End If
            ElseIf (vBoxDrawing = False) And (e.X < sender.Width) And (e.Y < sender.Height) Then
                ' "照片選擇匡" (副視窗) 是已完成的, 滑鼠動作現時為 ●移動● "照片選擇匡" (副視窗)
                If (fmMoving.Left + fmMoving.Width + e.X - vStart.X) < (Me.Left + sender.Left + sender.Width + OffsetX) Then fmMoving.Left = (fmMoving.Left + e.X - vStart.X) ' 移動左右
                If (fmMoving.Top + fmMoving.Height + e.Y - vStart.Y) < (Me.Top + sender.Top + sender.Height + OffsetY) Then fmMoving.Top = (fmMoving.Top + e.Y - vStart.Y) ' 移動上下
                ' 若 "照片選擇匡" (副視窗) 超出 "照片匡" 範圍, 把它抖正
                If fmMoving.Left < (Me.Left + sender.Left + OffsetX) Then fmMoving.Left = (Me.Left + sender.Left + OffsetX)
                If fmMoving.Top < (Me.Top + sender.Top + OffsetY) Then fmMoving.Top = (Me.Top + sender.Top + OffsetY)
                vStart = e.Location
            End If
        End If

    End Sub


    Private Sub pbALL_MouseUp(sender As Object, e As MouseEventArgs) Handles pbTop.MouseUp, pbRight.MouseUp, pbLeft.MouseUp, pbBottom.MouseUp
        ' 滑鼠離開, 顯示 "照片選擇匡" (副視窗), 及處理大小
        If (l_MouseOK) And (e.Button = Windows.Forms.MouseButtons.Left) Then

            Dim vBoxRatioXY As Single  ' "照片選擇匡" (副視窗) 之長寬比
            Dim X As Integer  ' 現時主視窗及副視窗之 X 軸 (橫) 相對數 
            Dim Y As Integer  ' 現時主視窗及副視窗之 Y 軸 (直) 相對數

            If vBoxDrawing Then
                ' 正在完成改變 "照片選擇匡" (副視窗) 大小, 若 "照片選擇匡" (副視窗) 是繪畫超出 "照片匡" 範圍
                ' 設定現時計算之 "照片選擇匡" (副視窗) 之 "長寬比" 為 上/左 顯示器, 或 下/右 顯示器 (Monitor)
                If (sender.name = "pbTop") Or (sender.name = "pbLeft") Then vBoxRatioXY = vTopLeftRatioXY Else vBoxRatioXY = vBottomRightRatioXY

                ' 寬度超出, 把寬度拉回
                If (fmMoving.Left + fmMoving.Width) > (Me.Left + sender.left + sender.width + OffsetX - 1) Then
                    fmMoving.Width = (Me.Left + sender.left + sender.width - fmMoving.Left + OffsetY - 1)
                    fmMoving.Height = fmMoving.Width / vBoxRatioXY
                End If

                ' 長度超出, 把長度拉回
                If (fmMoving.Top + fmMoving.Height) > (Me.Top + sender.top + sender.height + 29) Then
                    fmMoving.Height = (Me.Top + sender.top + sender.height - fmMoving.Top + 29)
                    fmMoving.Width = fmMoving.Height * vBoxRatioXY
                End If
            End If

            ' 測試是否已超出照片範圍, 把 "照片選擇匡" (副視窗) 放入回照片內
            Call p_FitInPic(sender)

            ' 儲存現時之 "照片選擇匡" (副視窗) 與主視窗的相對位置於變數中
            X = fmMoving.Left - Me.Left
            Y = fmMoving.Top - Me.Top

            Select Case sender.name
                Case "pbTop"
                    vTopS.X = X
                    vTopS.Y = Y
                Case "pbBottom"
                    vBottomS.X = X
                    vBottomS.Y = Y
                Case "pbLeft"
                    vLeftS.X = X
                    vLeftS.Y = Y
                Case "pbRight"
                    vRightS.X = X
                    vRightS.Y = Y
            End Select

            vBoxDrawing = False
        End If
        l_MouseOK = False
    End Sub


    Private Sub p_FitInPic(vPicBox As PictureBox)
        ' 測試是否已超出照片範圍, 把 "照片選擇匡" (副視窗) 放入回照片內 ..... vPicBox = 照片匡名字 (例: pbTop)
        Dim vRateTemp As Single  ' 計算中之比例 TEMP

        Dim vBoxRatioXY As Single  ' "照片選擇匡" (副視窗) 之長寬比

        Dim vOffsetX As Integer  ' 整個視窗之邊緣 X 軸, 計算用 TEMP 
        Dim vOffsetY As Integer  ' 整個視窗之邊緣 Y 軸, 計算用 TEMP

        Dim X As Integer  ' 左
        Dim Y As Integer  ' 上
        Dim W As Integer  ' 寬度
        Dim H As Integer  ' 高度

        ' 設定現時計算之 "照片選擇匡" (副視窗) 之 "長寬比" 為 上/左 顯示器, 或 下/右 顯示器 (Monitor)
        If (vPicBox.Name = "pbTop") Or (vPicBox.Name = "pbLeft") Then vBoxRatioXY = vTopLeftRatioXY Else vBoxRatioXY = vBottomRightRatioXY
        vOffsetX = Me.Left + vPicBox.Left + OffsetX
        vOffsetY = Me.Top + vPicBox.Top + OffsetY

        ' 計算照片與照片匡之比例
        vRateTemp = f_Zoom(vPicBox.Image, vPicBox.Width, vPicBox.Height)
        ' 計算照片在照片匡內所佔之位置
        X = (vPicBox.Width - (vPicBox.Image.Width * vRateTemp)) / 2
        Y = (vPicBOx.Height - (vPicBOx.Image.Height * vRateTemp)) / 2
        W = vPicBOx.Image.Width * vRateTemp
        H = vPicBOx.Image.Height * vRateTemp

        ' "照片選擇匡" (副視窗) 比照片寬, 把 "照片選擇匡" (副視窗) 縮到照片寬度一樣大小
        If fmMoving.Width > W Then
            fmMoving.Width = W - 1
            fmMoving.Height = (fmMoving.Width / vBoxRatioXY) - 1
        End If
        ' "照片選擇匡" (副視窗) 比照片高, 把 "照片選擇匡" (副視窗) 縮到照片高度一樣大小
        If fmMoving.Height > H Then
            fmMoving.Height = H - 1
            fmMoving.Width = (fmMoving.Height * vBoxRatioXY) - 1
        End If

        ' "照片選擇匡" (副視窗) 之右邊超出 照片右邊緣, 把 "照片選擇匡" (副視窗) 的左邊緣再向左推
        If (fmMoving.Left + fmMoving.Width - vOffsetX) > (X + W) Then fmMoving.Left = (fmMoving.Left - ((fmMoving.Left + fmMoving.Width) - (X + W))) + vOffsetX - 1
        ' "照片選擇匡" (副視窗) 之底邊超出 照片下邊緣, 把 "照片選擇匡" (副視窗) 的上邊緣再向上推
        If (fmMoving.Top + fmMoving.Height - vOffsetY) > (Y + H) Then fmMoving.Top = (fmMoving.Top - ((fmMoving.Top + fmMoving.Height) - (Y + H))) + vOffsetY - 1

        ' "照片選擇匡" (副視窗) 之左邊超出 照片左邊緣, 把 "照片選擇匡" (副視窗) 的左邊緣與照片的左邊緣對齊
        If (fmMoving.Left - vOffsetX) < X Then fmMoving.Left = (X + vOffsetX)
        ' "照片選擇匡" (副視窗) 之上邊超出 照片上邊緣, 把 "照片選擇匡" (副視窗) 的上邊緣與照片的上邊緣對齊
        If (fmMoving.Top - vOffsetY) < Y Then fmMoving.Top = (Y + vOffsetY)

    End Sub


    Private Sub fmMain_Move(sender As Object, e As EventArgs) Handles Me.Move
        ' 當主視窗移動時, 把所有 "照片選擇匡" (副視窗) 一起移動
        If lblSaved.Text <> "" Then
            fmTop.Left = (Me.Left + vTopS.X)
            fmTop.Top = (Me.Top + vTopS.Y)
            fmBottom.Left = (Me.Left + vBottomS.X)
            fmBottom.Top = (Me.Top + vBottomS.Y)
            fmLeft.Left = (Me.Left + vLeftS.X)
            fmLeft.Top = (Me.Top + vLeftS.Y)
            fmRight.Left = (Me.Left + vRightS.X)
            fmRight.Top = (Me.Top + vRightS.Y)
        End If
    End Sub


    Private Sub tbTextBoxALL_TextChanged(sender As Object, e As EventArgs) Handles tbHeightBottomRight.TextChanged, tbWidthTopLeft.TextChanged, tbWidthBottomRight.TextChanged, tbHeightTopLeft.TextChanged
        ' 不容許輸入之數值太大
        If Val(sender.text) > 3840 Then
            sender.text = 3840
        ElseIf Val(sender.text) = 0 Then
            sender.text = ""
        End If
        ' 計算顯示器 (Monitor) 的長寬比例
        If Val(tbHeightTopLeft.Text) <> 0 Then vTopLeftRatioXY = Val(tbWidthTopLeft.Text) / Val(tbHeightTopLeft.Text)
        If Val(tbHeightBottomRight.Text) <> 0 Then vBottomRightRatioXY = Val(tbWidthBottomRight.Text) / Val(tbHeightBottomRight.Text)
    End Sub


    Private Sub p_CropPic(vPic As PictureBox, vBox As Form, vWidth As Integer, vHeight As Integer)
        ' 根據 "照片選擇匡" (副視窗) 的大小來裁剪照片, 儲存於 bmTemp 內 (圖像變數) ..... 
        ' vPic = 照片匡名字 (例: pbTop) ..... vBox = "照片選擇匡" (副視窗) ..... vWidth = 顯視器的寬度 ..... vHeight =  = 顯視器的高度 (Monitor)

        Dim vRateTemp As Single  ' 計算中之比例 TEMP

        Dim X As Integer  ' 裁剪後之位置 (左)
        Dim Y As Integer  ' 裁剪後之位置 (上)
        Dim W As Integer  ' 裁剪後之位置 (寬度)
        Dim H As Integer  ' 裁剪後之位置 (高度)

        ' "照片選擇匡" (副視窗) 的呎吋大於 10 Pixel 才處理
        If (vBox.Width > 10) And (vBox.Height > 10) Then
            ' 計算照片與 "照片選擇匡" (副視窗) 之比例
            vRateTemp = f_Zoom(vPic.Image, vPic.Width, vPic.Height)
            ' 儲存已裁剪的照片原像素大小
            X = (vBox.Left - Me.Left - vPic.Left - OffsetX - ((vPic.Width - (vPic.Image.Width * vRateTemp)) / 2)) / vRateTemp
            Y = (vBox.Top - Me.Top - vPic.Top - OffsetY - ((vPic.Height - (vPic.Image.Height * vRateTemp)) / 2)) / vRateTemp
            W = vBox.Width / vRateTemp
            H = vBox.Height / vRateTemp
        Else
            ' 未有 "照片選擇匡" (副視窗)
            ' 計算顯示器 (Monitor) 之比例
            If (vPic.Name = "pbTop") Or (vPic.Name = "pbLeft") Then vRateTemp = (Val(tbWidthTopLeft.Text) / Val(tbHeightTopLeft.Text)) Else vRateTemp = (Val(tbWidthBottomRight.Text) / Val(tbHeightBottomRight.Text))
            ' 把照片裁剪到照片的中央, 而亦符合顯示器 (Monitor) 比例, 及儲存已裁剪的照片原像素大小
            If (vPic.Image.Width / vRateTemp) < vPic.Image.Height Then
                X = 0
                Y = (vPic.Image.Height - (vPic.Image.Width / vRateTemp)) / 2
                W = vPic.Image.Width
                H = vPic.Image.Width / vRateTemp
            Else
                X = (vPic.Image.Width - (vPic.Image.Height * vRateTemp)) / 2
                Y = 0
                W = vPic.Image.Height * vRateTemp
                H = vPic.Image.Height
            End If


        End If

        ' 裁剪照片, 儲存於 bmTemp 圖像變數內
        ' 設定輸出照片之實際大小 (像素)
        Dim vCrop As New Rectangle(0, 0, vWidth, vHeight)
        ' 設定輸出圖片之大小
        bmTemp = New Bitmap(vWidth, vHeight)
        Dim ghTemp As Graphics = Graphics.FromImage(bmTemp)

        ' 設定為高品質圖型處理
        ghTemp.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        ghTemp.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        ghTemp.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

        ghTemp.DrawImage(vPic.Image, vCrop, X, Y, W, H, GraphicsUnit.Pixel)
        ghTemp.Dispose()
    End Sub



    Private Sub btGo_Click(sender As Object, e As EventArgs) Handles btGo.Click
        ' 按下儲存按鈕, 開始整理及儲存成一個完整之照片檔案
        Dim bmTL As Bitmap = Nothing  ' 儲存著 上/左 邊已裁剪好及已縮放好比例的照片
        Dim bmBR As Bitmap = Nothing  ' 儲存著 下/右 邊已裁剪好及已縮放好比例的照片
        Dim imgTemp As Image  ' 圖片暫存檔 (用作合併照片時)
        Dim vFullPage As Point  ' 整頁面大小 (長寬)
        Dim vFirstPart As Point  ' 第一張照片之起始位置座標 (左上角)
        Dim vSecondPart As Point  ' 第二張照片之起始位置座標 (左上角)

        ' 要同時有兩個顯示器 (Monitor) 之呎吋才繼續
        If (Val(tbWidthTopLeft.Text) <> 0) And (Val(tbHeightTopLeft.Text) <> 0) And (Val(tbWidthBottomRight.Text) <> 0) And (Val(tbHeightBottomRight.Text) <> 0) Then
            ' 計算完成品之呎吋
            If (pbTop.Visible) And (pbLeft.Visible = False) Then
                ' 計算上下圖, 寬型 (上下排列的雙顯示組 Dual Mon)
                If Val(tbWidthTopLeft.Text) >= Val(tbWidthBottomRight.Text) Then
                    vFullPage.X = Val(tbWidthTopLeft.Text)
                Else
                    vFullPage.X = Val(tbWidthBottomRight.Text)
                End If
                vFullPage.Y = Val(tbHeightTopLeft.Text) + Val(tbHeightBottomRight.Text)
            ElseIf (pbLeft.Visible) And (pbTop.Visible = False) Then
                ' 計算左右圖, 高型 (左右排列的雙顯示組 Dual Mon)
                vFullPage.X = Val(tbWidthTopLeft.Text) + Val(tbWidthBottomRight.Text)
                If Val(tbHeightTopLeft.Text) >= Val(tbHeightBottomRight.Text) Then
                    vFullPage.Y = Val(tbHeightTopLeft.Text)
                Else
                    vFullPage.Y = Val(tbHeightBottomRight.Text)
                End If
            End If

            ' 要同時有兩張照片存在才繼續
            If ((pbTop.Visible) And (pbLeft.Visible = False)) AndAlso (pbTop.Image IsNot Nothing) AndAlso (pbBottom.Image IsNot Nothing) Then
                ' 計算上下圖, 寬型 (上下排列的雙顯示組 Dual Mon)
                ' 到副程式計算及儲存第一張照片
                Call p_CropPic(pbTop, fmTop, Val(tbWidthTopLeft.Text), Val(tbHeightTopLeft.Text))
                bmTL = bmTemp
                ' 若兩個顯示器大小不同, 把照片位置改變為排列在中央
                If Val(tbWidthTopLeft.Text) < Val(tbWidthBottomRight.Text) Then
                    vFirstPart = New Point(((Val(tbWidthBottomRight.Text) - Val(tbWidthTopLeft.Text)) / 2), 0)
                Else
                    vFirstPart = New Point(0, 0)
                End If
                ' 到副程式計算及儲存第二張照片
                Call p_CropPic(pbBottom, fmBottom, Val(tbWidthBottomRight.Text), Val(tbHeightBottomRight.Text))
                bmBR = bmTemp
                ' 若兩個顯示器大小不同, 把照片位置改變為排列在中央
                If Val(tbWidthTopLeft.Text) > Val(tbWidthBottomRight.Text) Then
                    vSecondPart = New Point(((Val(tbWidthTopLeft.Text) - Val(tbWidthBottomRight.Text)) / 2), Val(tbHeightTopLeft.Text))
                Else
                    vSecondPart = New Point(0, Val(tbHeightTopLeft.Text))
                End If
            ElseIf ((pbLeft.Visible) And (pbTop.Visible = False)) AndAlso (pbLeft.Image IsNot Nothing) AndAlso (pbRight.Image IsNot Nothing) Then
                ' 計算左右圖, 高型 (左右排列的雙顯示組 Dual Mon)
                ' 到副程式計算及儲存第一張照片
                Call p_CropPic(pbLeft, fmLeft, Val(tbWidthTopLeft.Text), Val(tbHeightTopLeft.Text))
                bmTL = bmTemp
                ' 若兩個顯示器大小不同, 把照片位置改變為排列在中央
                If Val(tbHeightTopLeft.Text) < Val(tbHeightBottomRight.Text) Then
                    vFirstPart = New Point(0, ((Val(tbHeightBottomRight.Text) - Val(tbHeightTopLeft.Text)) / 2))
                Else
                    vFirstPart = New Point(0, 0)
                End If
                ' 到副程式計算及儲存第二張照片
                Call p_CropPic(pbRight, fmRight, Val(tbWidthBottomRight.Text), Val(tbHeightBottomRight.Text))
                bmBR = bmTemp
                ' 若兩個顯示器大小不同, 把照片位置改變為排列在中央
                If Val(tbHeightTopLeft.Text) > Val(tbHeightBottomRight.Text) Then
                    vSecondPart = New Point(tbWidthTopLeft.Text, ((Val(tbHeightTopLeft.Text) - Val(tbHeightBottomRight.Text)) / 2))
                Else
                    vSecondPart = New Point(tbWidthTopLeft.Text, 0)
                End If
            End If

            ' 若已有兩張裁剪好的圖片, 製作成一整張圖
            If bmTL IsNot Nothing And bmBR IsNot Nothing Then

                ' 設定輸出圖片之大小 (合併後之實際大小)
                bmTemp = New Bitmap(vFullPage.X, vFullPage.Y)

                Dim ghTemp As Graphics = Graphics.FromImage(bmTemp)

                ' 設定為高品質圖型處理
                ghTemp.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                ghTemp.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                ghTemp.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

                ' 寫入第一張()
                imgTemp = bmTL
                ghTemp.DrawImage(imgTemp, vFirstPart)

                ' 合併第二張()
                imgTemp = bmBR
                ghTemp.DrawImage(imgTemp, vSecondPart)

                ' 儲存檔案
                If cbAutoName.Checked Then
                    ' 自動名稱
                    Dim l_Save As Boolean = False

                    ' 若有同名, 先問是否取代原來檔案
                    If FileIO.FileSystem.FileExists(fmAutoFileName.tbDir.Text & "\" & fmAutoFileName.txtLeader.Text & "_" & Microsoft.VisualBasic.Format(Val(vNameCount), StrDup(CInt(fmAutoFileName.udDigi.Value), "0")) & ".JPG") Then
                        l_Save = (MessageBox.Show(fmAutoFileName.txtLeader.Text & "_" & Microsoft.VisualBasic.Format(Val(vNameCount), StrDup(CInt(fmAutoFileName.udDigi.Value), "0")) & ".JPG" & "  Already Exist !" & vbCrLf & "Do Your Want to replace it ?", "Confirm Replace", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes)
                    Else
                        l_Save = True
                    End If

                    If l_Save Then
                        bmTemp.Save(fmAutoFileName.tbDir.Text & "\" & fmAutoFileName.txtLeader.Text & "_" & Microsoft.VisualBasic.Format(Val(vNameCount), StrDup(CInt(fmAutoFileName.udDigi.Value), "0")) & ".JPG", System.Drawing.Imaging.ImageFormat.Jpeg)
                        vNameCount += 1  ' 檔案數字加一
                        SaveSetting("Ranseco", "DualMonWall", "NameCount", vNameCount)  ' 記憶已增加的檔案數字
                        ' 顯示已儲存好的訊息
                        lblSaved.Visible = True
                        ' 停留兩秒
                        Dim i As Integer
                        For i = 1 To (2000 / 300)
                            System.Threading.Thread.Sleep(300)
                            Application.DoEvents()
                        Next
                        lblSaved.Visible = False
                    End If
                Else
                    ' 獨立單一檔案儲存
                    sfKeepPic.InitialDirectory = GetSetting("Ranseco", "DualMonWall", "MyDir", My.Computer.FileSystem.SpecialDirectories.MyPictures)
                    ' 顯示選擇檔案名稱及資料匣位置                        
                    If sfKeepPic.ShowDialog() <> vbCancel Then
                        bmTemp.Save(sfKeepPic.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                        ' 記憶資料匣位置
                        sfKeepPic.InitialDirectory = FileIO.FileSystem.GetParentPath(sfKeepPic.FileName)
                        SaveSetting("Ranseco", "DualMonWall", "MyDir", sfKeepPic.InitialDirectory)
                        ' 顯示已儲存好的訊息
                        lblSaved.Visible = True
                        ' 停留三秒
                        Dim i As Integer
                        For i = 1 To (3000 / 300)
                            System.Threading.Thread.Sleep(300)
                            Application.DoEvents()
                        Next
                        lblSaved.Visible = False
                    End If
                End If

                ' 釋放資源
                ghTemp.Dispose()
                imgTemp.Dispose()
                bmTemp.Dispose()
                bmTL.Dispose()
                bmBR.Dispose()
            End If
        End If
    End Sub


    Private Function f_Zoom(MyPic As Image, n_ResoWidth As Integer, n_ResoHeight As Integer) As Single
        ' 變更瀏覽器內圖片之大小以適應 ..... MyPic = 輸入圖片 ..... n_ResoWidth = 輸出寬度 .....  n_ResoHeight = 輸出高度 ..... f_Zoom 輸出為計算後之比例

        Dim MyNewImage As System.Drawing.Size  ' 照片大小
        Dim n_CalTemp As Double  ' 比例
        Dim MyHeight As Integer  ' 計算高度暫存用

        MyNewImage = MyPic.Size

        ' 設定 n_CalTemp 為 1 是因為當高度及寬度都小於輸出大小時的計算用
        n_CalTemp = 1

        If ((MyNewImage.Width < n_ResoWidth) And (MyNewImage.Height < n_ResoHeight)) Or (MyNewImage.Width > n_ResoWidth) Then
            ' 當寬度及高度都小於輸出的大小時, 放大照片 
            ' 當寬度大於輸出的大小時, 計算寬度
            n_CalTemp = n_ResoWidth / MyNewImage.Width
        End If

        MyHeight = MyNewImage.Height * n_CalTemp

        ' 當未曾計算過寬度 或 計算寬度後之高度大於輸出的大小時, 才計算高度
        If MyHeight > n_ResoHeight Then n_CalTemp = n_ResoHeight / MyNewImage.Height

        ' 把比例化成整數百份比 (可以 Remark 此行, 以輸出比例數)
        '        n_CalTemp = Int(n_CalTemp * 100)

        ' 回傳計算完之比例
        Return n_CalTemp
    End Function


    Private Sub cbAutoName_CheckedChanged(sender As Object, e As EventArgs) Handles cbAutoName.CheckedChanged
        ' 按下自動設定檔案名稱, 顯示設定儲存檔案名及資料匣之視窗
        If cbAutoName.Checked Then fmAutoFileName.ShowDialog()
    End Sub

End Class
