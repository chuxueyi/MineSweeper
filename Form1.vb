Public Class Form1
    Public iCol As Integer
    Public iRow As Integer
    Public iCount As Integer
    Public iSteps As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'load default settings
        iCol = 10
        iRow = 10
        mnEasy.Checked = True
        iCount = (iCol * iRow) \ 3
        mnNumSggsted.Checked = True
        iSteps = 100
        mnAISggsted.Checked = True
    End Sub
    Private Sub mnEasy_Click(sender As Object, e As EventArgs) Handles mnEasy.Click
        iCol = 10
        iRow = 10
        sender.Checked = True
        mnNotEasy.Checked = False
        mnCfgSize.Checked = False
    End Sub

    Private Sub mnNotEasy_Click(sender As Object, e As EventArgs) Handles mnNotEasy.Click
        iCol = 20
        iRow = 20
        sender.Checked = True
        mnEasy.Checked = False
        mnCfgSize.Checked = False
    End Sub

    Private Sub mnCfgSize_Click(sender As Object, e As EventArgs) Handles mnCfgSize.Click
        sender.Checked = True
        mnEasy.Checked = False
        mnNotEasy.Checked = False
        frmConfig.TopMost = True
        frmConfig.Show()
    End Sub

    Private Sub mnNumSggsted_Click(sender As Object, e As EventArgs) Handles mnNumSggsted.Click
        'suppose it's 50%
        iCount = (iCol * iRow) \ 2
        sender.Checked = True
        mnCfgNum.Checked = False
    End Sub
    Private Sub mmnCfgNum_Click(sender As Object, e As EventArgs) Handles mnCfgNum.Click
        sender.checked = True
        mnNumSggsted.Checked = False
        frmConfig.TopMost = True
        frmConfig.Show()
    End Sub
    Private Sub mnAISggsted_Click(sender As Object, e As EventArgs) Handles mnAISggsted.Click
        'suppose it's roughly 100
        iSteps = 100
        sender.checked = True
        mnCfgSteps.Checked = False
    End Sub
    Private Sub mnCfgSteps_Click(sender As Object, e As EventArgs) Handles mnCfgSteps.Click
        sender.Checked = True
        mnAISggsted.Checked = False
        frmConfig.TopMost = True
        frmConfig.Show()
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        frmGame.TopMost = True
        frmGame.Show()
    End Sub
End Class
