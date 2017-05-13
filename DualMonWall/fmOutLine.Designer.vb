<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmOutLine
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmOutLine))
        Me.panOutLine = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'panOutLine
        '
        Me.panOutLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panOutLine.Location = New System.Drawing.Point(0, 0)
        Me.panOutLine.Name = "panOutLine"
        Me.panOutLine.Size = New System.Drawing.Size(100, 100)
        Me.panOutLine.TabIndex = 0
        '
        'fmOutLine
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(100, 100)
        Me.ControlBox = False
        Me.Controls.Add(Me.panOutLine)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fmOutLine"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "fmOutLine"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.White
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panOutLine As System.Windows.Forms.Panel
End Class
