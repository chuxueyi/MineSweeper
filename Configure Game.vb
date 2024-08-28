

Public Class frmConfig

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click


        If txtCol.Text <> "" And txtRow.Text <> "" Then
            Form1.iCol = txtCol.Text
            Form1.iRow = txtRow.Text
        End If


        If txtRow.Text <> "" And txtCol.Text = "" Then
            Form1.iRow = txtRow.Text
            Form1.mnEasy.Checked = True
        End If


        If txtRow.Text = "" And txtCol.Text <> "" Then
            Form1.iCol = txtCol.Text
            Form1.mnEasy.Checked = True
        End If


        If txtRow.Text = "" And txtCol.Text = "" Then
            Form1.mnEasy.Checked = True
            Form1.mnCfgSize.Checked = False
        End If


        If txtNum.Text <> "" Then Form1.iCount = txtNum.Text


        If txtNum.Text = "" Then
            Form1.mnNumSggsted.Checked = True
            Form1.mnCfgNum.Checked = False
            Form1.iCount = Form1.iCol * Form1.iRow \ 3
        End If


        Me.Close()


        Form1.TopMost = True
        Form1.Show()


    End Sub


End Class