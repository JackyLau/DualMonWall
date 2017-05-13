Public Class fmOutLine

    Private Sub fmOutLine_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Width = 1
        Me.Height = 1
    End Sub


    Private Sub fmOutLine_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        panOutLine.Width = Me.Width
        panOutLine.Height = Me.Height
    End Sub

End Class