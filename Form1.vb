Public Class Form1


    Public iCol As Integer

    Public iRow As Integer

    Public iMines As Integer


    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click


        iCol = txtCol.Text

        iRow = txtRow.Text

        iMines = txtNum.Text


        frmGame.TopMost = True

        frmGame.Show()


    End Sub

End Class
