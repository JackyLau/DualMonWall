<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmMain
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmMain))
        Me.btCancel = New System.Windows.Forms.Button()
        Me.btFlip = New System.Windows.Forms.Button()
        Me.btTurnTL = New System.Windows.Forms.Button()
        Me.tbWidthTopLeft = New System.Windows.Forms.TextBox()
        Me.tbHeightTopLeft = New System.Windows.Forms.TextBox()
        Me.tbWidthBottomRight = New System.Windows.Forms.TextBox()
        Me.tbHeightBottomRight = New System.Windows.Forms.TextBox()
        Me.btTurnBR = New System.Windows.Forms.Button()
        Me.btGo = New System.Windows.Forms.Button()
        Me.sfKeepPic = New System.Windows.Forms.SaveFileDialog()
        Me.cbAutoName = New System.Windows.Forms.CheckBox()
        Me.lblSaved = New System.Windows.Forms.Label()
        Me.pbRight = New System.Windows.Forms.PictureBox()
        Me.pbBottom = New System.Windows.Forms.PictureBox()
        Me.pbLeft = New System.Windows.Forms.PictureBox()
        Me.pbTop = New System.Windows.Forms.PictureBox()
        Me.pCenter = New System.Windows.Forms.Panel()
        CType(Me.pbRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pCenter.SuspendLayout()
        Me.SuspendLayout()
        '
        'btCancel
        '
        Me.btCancel.Location = New System.Drawing.Point(3, 55)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(37, 33)
        Me.btCancel.TabIndex = 4
        Me.btCancel.TabStop = False
        Me.btCancel.Text = "X"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'btFlip
        '
        Me.btFlip.Location = New System.Drawing.Point(47, 55)
        Me.btFlip.Name = "btFlip"
        Me.btFlip.Size = New System.Drawing.Size(36, 33)
        Me.btFlip.TabIndex = 5
        Me.btFlip.TabStop = False
        Me.btFlip.Text = "Flip"
        Me.btFlip.UseVisualStyleBackColor = True
        '
        'btTurnTL
        '
        Me.btTurnTL.Location = New System.Drawing.Point(3, 4)
        Me.btTurnTL.Name = "btTurnTL"
        Me.btTurnTL.Size = New System.Drawing.Size(37, 29)
        Me.btTurnTL.TabIndex = 6
        Me.btTurnTL.TabStop = False
        Me.btTurnTL.Text = "Turn"
        Me.btTurnTL.UseVisualStyleBackColor = True
        '
        'tbWidthTopLeft
        '
        Me.tbWidthTopLeft.Location = New System.Drawing.Point(46, 7)
        Me.tbWidthTopLeft.Name = "tbWidthTopLeft"
        Me.tbWidthTopLeft.Size = New System.Drawing.Size(37, 22)
        Me.tbWidthTopLeft.TabIndex = 7
        Me.tbWidthTopLeft.TabStop = False
        '
        'tbHeightTopLeft
        '
        Me.tbHeightTopLeft.Location = New System.Drawing.Point(89, 7)
        Me.tbHeightTopLeft.Name = "tbHeightTopLeft"
        Me.tbHeightTopLeft.Size = New System.Drawing.Size(37, 22)
        Me.tbHeightTopLeft.TabIndex = 8
        Me.tbHeightTopLeft.TabStop = False
        '
        'tbWidthBottomRight
        '
        Me.tbWidthBottomRight.Location = New System.Drawing.Point(130, 102)
        Me.tbWidthBottomRight.Name = "tbWidthBottomRight"
        Me.tbWidthBottomRight.Size = New System.Drawing.Size(37, 22)
        Me.tbWidthBottomRight.TabIndex = 9
        Me.tbWidthBottomRight.TabStop = False
        '
        'tbHeightBottomRight
        '
        Me.tbHeightBottomRight.Location = New System.Drawing.Point(173, 102)
        Me.tbHeightBottomRight.Name = "tbHeightBottomRight"
        Me.tbHeightBottomRight.Size = New System.Drawing.Size(37, 22)
        Me.tbHeightBottomRight.TabIndex = 10
        Me.tbHeightBottomRight.TabStop = False
        '
        'btTurnBR
        '
        Me.btTurnBR.Location = New System.Drawing.Point(216, 99)
        Me.btTurnBR.Name = "btTurnBR"
        Me.btTurnBR.Size = New System.Drawing.Size(37, 29)
        Me.btTurnBR.TabIndex = 11
        Me.btTurnBR.TabStop = False
        Me.btTurnBR.Text = "Turn"
        Me.btTurnBR.UseVisualStyleBackColor = True
        '
        'btGo
        '
        Me.btGo.Location = New System.Drawing.Point(175, 55)
        Me.btGo.Name = "btGo"
        Me.btGo.Size = New System.Drawing.Size(61, 32)
        Me.btGo.TabIndex = 12
        Me.btGo.Text = "GO"
        Me.btGo.UseVisualStyleBackColor = True
        '
        'sfKeepPic
        '
        Me.sfKeepPic.DefaultExt = "JPG"
        Me.sfKeepPic.Filter = ".JPG|"
        '
        'cbAutoName
        '
        Me.cbAutoName.AutoSize = True
        Me.cbAutoName.Location = New System.Drawing.Point(89, 63)
        Me.cbAutoName.Name = "cbAutoName"
        Me.cbAutoName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbAutoName.Size = New System.Drawing.Size(77, 16)
        Me.cbAutoName.TabIndex = 14
        Me.cbAutoName.TabStop = False
        Me.cbAutoName.Text = "Auto Name"
        Me.cbAutoName.UseVisualStyleBackColor = True
        '
        'lblSaved
        '
        Me.lblSaved.BackColor = System.Drawing.Color.Silver
        Me.lblSaved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSaved.Font = New System.Drawing.Font("新細明體", 48.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSaved.ForeColor = System.Drawing.Color.Blue
        Me.lblSaved.Location = New System.Drawing.Point(2, 2)
        Me.lblSaved.Name = "lblSaved"
        Me.lblSaved.Size = New System.Drawing.Size(252, 128)
        Me.lblSaved.TabIndex = 20
        Me.lblSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSaved.Visible = False
        '
        'pbRight
        '
        Me.pbRight.BackgroundImage = Global.DualMonWallRoot.My.Resources.Resources.DragDropPicHere
        Me.pbRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbRight.Location = New System.Drawing.Point(521, 204)
        Me.pbRight.Name = "pbRight"
        Me.pbRight.Size = New System.Drawing.Size(250, 250)
        Me.pbRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbRight.TabIndex = 3
        Me.pbRight.TabStop = False
        '
        'pbBottom
        '
        Me.pbBottom.BackgroundImage = Global.DualMonWallRoot.My.Resources.Resources.DragDropPicHere
        Me.pbBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbBottom.Location = New System.Drawing.Point(265, 398)
        Me.pbBottom.Name = "pbBottom"
        Me.pbBottom.Size = New System.Drawing.Size(250, 250)
        Me.pbBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbBottom.TabIndex = 1
        Me.pbBottom.TabStop = False
        '
        'pbLeft
        '
        Me.pbLeft.BackgroundImage = Global.DualMonWallRoot.My.Resources.Resources.DragDropPicHere
        Me.pbLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbLeft.Location = New System.Drawing.Point(9, 204)
        Me.pbLeft.Name = "pbLeft"
        Me.pbLeft.Size = New System.Drawing.Size(250, 250)
        Me.pbLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLeft.TabIndex = 0
        Me.pbLeft.TabStop = False
        '
        'pbTop
        '
        Me.pbTop.BackgroundImage = Global.DualMonWallRoot.My.Resources.Resources.DragDropPicHere
        Me.pbTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbTop.Location = New System.Drawing.Point(265, 10)
        Me.pbTop.Name = "pbTop"
        Me.pbTop.Size = New System.Drawing.Size(250, 250)
        Me.pbTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbTop.TabIndex = 2
        Me.pbTop.TabStop = False
        '
        'pCenter
        '
        Me.pCenter.BackColor = System.Drawing.Color.Gray
        Me.pCenter.Controls.Add(Me.cbAutoName)
        Me.pCenter.Controls.Add(Me.btGo)
        Me.pCenter.Controls.Add(Me.btTurnBR)
        Me.pCenter.Controls.Add(Me.tbHeightBottomRight)
        Me.pCenter.Controls.Add(Me.tbWidthBottomRight)
        Me.pCenter.Controls.Add(Me.tbHeightTopLeft)
        Me.pCenter.Controls.Add(Me.tbWidthTopLeft)
        Me.pCenter.Controls.Add(Me.btTurnTL)
        Me.pCenter.Controls.Add(Me.btFlip)
        Me.pCenter.Controls.Add(Me.btCancel)
        Me.pCenter.Controls.Add(Me.lblSaved)
        Me.pCenter.Location = New System.Drawing.Point(262, 263)
        Me.pCenter.Name = "pCenter"
        Me.pCenter.Size = New System.Drawing.Size(256, 132)
        Me.pCenter.TabIndex = 22
        '
        'fmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(780, 656)
        Me.Controls.Add(Me.pCenter)
        Me.Controls.Add(Me.pbRight)
        Me.Controls.Add(Me.pbBottom)
        Me.Controls.Add(Me.pbLeft)
        Me.Controls.Add(Me.pbTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fmMain"
        Me.Text = "Dual Monitor Wall Paper"
        CType(Me.pbRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBottom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pCenter.ResumeLayout(False)
        Me.pCenter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbLeft As System.Windows.Forms.PictureBox
    Friend WithEvents pbBottom As System.Windows.Forms.PictureBox
    Friend WithEvents pbTop As System.Windows.Forms.PictureBox
    Friend WithEvents pbRight As System.Windows.Forms.PictureBox
    Friend WithEvents btCancel As System.Windows.Forms.Button
    Friend WithEvents btFlip As System.Windows.Forms.Button
    Friend WithEvents btTurnTL As System.Windows.Forms.Button
    Friend WithEvents tbWidthTopLeft As System.Windows.Forms.TextBox
    Friend WithEvents tbHeightTopLeft As System.Windows.Forms.TextBox
    Friend WithEvents tbWidthBottomRight As System.Windows.Forms.TextBox
    Friend WithEvents tbHeightBottomRight As System.Windows.Forms.TextBox
    Friend WithEvents btTurnBR As System.Windows.Forms.Button
    Friend WithEvents btGo As System.Windows.Forms.Button
    Friend WithEvents sfKeepPic As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cbAutoName As System.Windows.Forms.CheckBox
    Friend WithEvents lblSaved As System.Windows.Forms.Label
    Friend WithEvents pCenter As System.Windows.Forms.Panel

End Class
