<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmAutoFileName
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmAutoFileName))
        Me.tbDir = New System.Windows.Forms.TextBox()
        Me.mtxStart = New System.Windows.Forms.MaskedTextBox()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.udDigi = New System.Windows.Forms.NumericUpDown()
        Me.lblUnderLine = New System.Windows.Forms.Label()
        Me.txtLeader = New System.Windows.Forms.TextBox()
        Me.lblDir = New System.Windows.Forms.Label()
        Me.btDir = New System.Windows.Forms.Button()
        Me.btOK = New System.Windows.Forms.Button()
        Me.fbDir = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.udDigi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbDir
        '
        Me.tbDir.Enabled = False
        Me.tbDir.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tbDir.Location = New System.Drawing.Point(23, 21)
        Me.tbDir.Name = "tbDir"
        Me.tbDir.ReadOnly = True
        Me.tbDir.Size = New System.Drawing.Size(203, 23)
        Me.tbDir.TabIndex = 0
        Me.tbDir.TabStop = False
        '
        'mtxStart
        '
        Me.mtxStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.mtxStart.Location = New System.Drawing.Point(343, 56)
        Me.mtxStart.Mask = "000"
        Me.mtxStart.Name = "mtxStart"
        Me.mtxStart.Size = New System.Drawing.Size(54, 22)
        Me.mtxStart.TabIndex = 13
        Me.mtxStart.TabStop = False
        Me.mtxStart.Text = "001"
        Me.mtxStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStart.Location = New System.Drawing.Point(246, 62)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(95, 12)
        Me.lblStart.TabIndex = 12
        Me.lblStart.Text = "Start Count From >"
        '
        'udDigi
        '
        Me.udDigi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.udDigi.Location = New System.Drawing.Point(365, 21)
        Me.udDigi.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.udDigi.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udDigi.Name = "udDigi"
        Me.udDigi.Size = New System.Drawing.Size(32, 22)
        Me.udDigi.TabIndex = 10
        Me.udDigi.TabStop = False
        Me.udDigi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udDigi.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'lblUnderLine
        '
        Me.lblUnderLine.AutoSize = True
        Me.lblUnderLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lblUnderLine.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUnderLine.Location = New System.Drawing.Point(344, 21)
        Me.lblUnderLine.Name = "lblUnderLine"
        Me.lblUnderLine.Size = New System.Drawing.Size(20, 24)
        Me.lblUnderLine.TabIndex = 11
        Me.lblUnderLine.Text = "_"
        '
        'txtLeader
        '
        Me.txtLeader.Font = New System.Drawing.Font("新細明體", 9.75!)
        Me.txtLeader.Location = New System.Drawing.Point(248, 21)
        Me.txtLeader.MaxLength = 16
        Me.txtLeader.Name = "txtLeader"
        Me.txtLeader.Size = New System.Drawing.Size(93, 23)
        Me.txtLeader.TabIndex = 9
        Me.txtLeader.TabStop = False
        '
        'lblDir
        '
        Me.lblDir.AutoSize = True
        Me.lblDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lblDir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDir.Location = New System.Drawing.Point(232, 21)
        Me.lblDir.Name = "lblDir"
        Me.lblDir.Size = New System.Drawing.Size(15, 24)
        Me.lblDir.TabIndex = 14
        Me.lblDir.Text = "\"
        '
        'btDir
        '
        Me.btDir.Location = New System.Drawing.Point(23, 53)
        Me.btDir.Name = "btDir"
        Me.btDir.Size = New System.Drawing.Size(109, 25)
        Me.btDir.TabIndex = 15
        Me.btDir.TabStop = False
        Me.btDir.Text = "Select Directory"
        Me.btDir.UseVisualStyleBackColor = True
        '
        'btOK
        '
        Me.btOK.Location = New System.Drawing.Point(138, 53)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(88, 25)
        Me.btOK.TabIndex = 16
        Me.btOK.Text = "OK"
        Me.btOK.UseVisualStyleBackColor = True
        '
        'fmAutoFileName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 91)
        Me.Controls.Add(Me.btOK)
        Me.Controls.Add(Me.btDir)
        Me.Controls.Add(Me.lblDir)
        Me.Controls.Add(Me.mtxStart)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.udDigi)
        Me.Controls.Add(Me.lblUnderLine)
        Me.Controls.Add(Me.txtLeader)
        Me.Controls.Add(Me.tbDir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fmAutoFileName"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dual Monitor Wall Paper ...... Auto File Name"
        CType(Me.udDigi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbDir As System.Windows.Forms.TextBox
    Friend WithEvents mtxStart As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents udDigi As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblUnderLine As System.Windows.Forms.Label
    Friend WithEvents txtLeader As System.Windows.Forms.TextBox
    Friend WithEvents lblDir As System.Windows.Forms.Label
    Friend WithEvents btDir As System.Windows.Forms.Button
    Friend WithEvents btOK As System.Windows.Forms.Button
    Friend WithEvents fbDir As System.Windows.Forms.FolderBrowserDialog
End Class
