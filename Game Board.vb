Public Class frmGame

    Dim stPathSmiley = "C:\Users\Administrator\source\repos\MineSweeper\Resources\smiley1.ico"
    Dim stPathFeelingGood = "C:\Users\Administrator\source\repos\MineSweeper\Resources\smiley.ico"
    Dim stPathNotHappy = "C:\Users\Administrator\source\repos\MineSweeper\Resources\smiley3.ico"
    Dim stPathExploded = "C:\Users\Administrator\source\repos\MineSweeper\Resources\mine4.ico"
    Dim stPathDiscovered = "C:\Users\Administrator\source\repos\MineSweeper\Resources\mine2.ico"


    Dim iC = Form1.iCol
    Dim iR = Form1.iRow
    Dim iCR = iC * iR


    Dim aiHint(iCR) As Integer


    Dim iDscvrdToTal As Integer


    Private Sub frmGame_Load() Handles MyBase.Load


        Me.Controls.Add(New PictureBox With {
            .Image = Image.FromFile(stPathSmiley),
            .Width = iC * 30 \ 6,
            .Height = iC * 30 \ 6,
            .SizeMode = PictureBoxSizeMode.StretchImage,
            .BorderStyle = BorderStyle.None,
            .Location = New Point((iC * 30 - iC * 30 \ 6) / 2, iC)})



        Dim iX = 0
        Dim iY = iC * 30 \ 6 + 2 * iC

        Dim i = 0
Board:  Me.Controls.Add(New Button With {
            .Text = "",
            .Width = 30,
            .Height = 30,
            .Margin = New Padding(0),
            .Location = New Point(iX + (i Mod iC) * 30, iY + (i \ iC) * 30)})
        i += 1
        If i < iC * iR Then GoTo Board


        Me.Controls.SetChildIndex(Me.Controls.Item(0), iCR + 1)
        For index = 1 To iCR
            Me.Controls.SetChildIndex(Me.Controls.Item(i), i - 1)
        Next
        Me.Controls.SetChildIndex(Me.Controls.Item(0), iCR)


        For Each ctrl In Me.Controls

            If TypeOf ctrl Is Button Then
                AddHandler DirectCast(ctrl, Button).Click, Sub(sender As Button, e As EventArgs)


                                                               Dim pvt As Integer = Me.Controls.GetChildIndex(ctrl)


                                                               If aiHint(pvt) = -1 Then

                                                                   sender.Image = Image.FromFile(stPathExploded)
                                                                   DirectCast(Me.Controls.Item(0), PictureBox).Image = Image.FromFile(stPathNotHappy)
                                                                   'MsgBox("Game End! Swept: " & iDscvrdToTal * 100 \ Form1.iMines & "%")
                                                                   Exit Sub

                                                               End If


                                                               If aiHint(pvt) <> -1 Then

                                                                   sender.Text = aiHint(pvt)
                                                                   SweepSurrounding(pvt)

                                                               End If


                                                           End Sub

            End If

        Next


        AddHandler Me.Controls.Item(0).Click, AddressOf NewGame


        NewGame()


    End Sub



    Private Sub SweepSurrounding(pvt As Integer)


        Dim srdgIdcs() = SurroundingIndices(pvt)
        Dim sCount = srdgIdcs.Count
        Dim state(sCount - 1) As String

        Dim fogged = 0
        Dim discovered = 0
        Dim safe = 0

        For index = 0 To sCount - 1
            Dim si = srdgIdcs(index)
            Dim stt = state(si)
            Dim sBtn As Button = Me.Controls.Item(si + 1)

            If sBtn.Text = "" And sBtn.Image Is Nothing Then
                fogged += 1
                stt = "fogged"
            End If
            If sBtn.Image IsNot Nothing Then     'image or text
                discovered += 1
                stt = "discovered"
            End If
            If sBtn.Text <> "" Then
                safe += 1
                stt = "safe"
            End If

        Next


        Dim pvtHint = aiHint(pvt)


        If discovered = pvtHint Then

            If fogged = 0 Then Exit Sub      'recursion exit

            If fogged > 0 Then
                For index = 0 To sCount - 1
                    If state(index) = "fogged" Then Me.Controls.Item(srdgIdcs(index) + 1).Text = aiHint(srdgIdcs(index))
                Next
                Exit Sub           'recursion exit
            End If

        End If


        If discovered < pvtHint Then

            If discovered + fogged > pvtHint Then
                Exit Sub    'still can work
            End If

            If discovered + fogged = pvtHint Then
                For index = 0 To sCount - 1
                    If state(index) = "fogged" Then DirectCast(Me.Controls.Item(srdgIdcs(index) + 1), Button).Image = Image.FromFile(stPathDiscovered)
                Next
                iDscvrdToTal += 1
                If iDscvrdToTal = Form1.iMines Then DirectCast(Me.Controls.Item(0), PictureBox).Image = Image.FromFile(stPathFeelingGood)
                Exit Sub    'recursion exit
            End If

        End If


        For Each si In srdgIdcs
            If Me.Controls.Item(si + 1).Text <> "" Then SweepSurrounding(si)
        Next


    End Sub

    Private Sub NewGame()


        For Each hint In aiHint
            hint = 0
        Next


        iDscvrdToTal = 0


        For index = 1 To iCR
            Me.Controls.Item(index).Text = ""
            DirectCast(Me.Controls.Item(index), Button).Image = Nothing
        Next


        DirectCast(Me.Controls.Item(0), PictureBox).Image = Image.FromFile(stPathSmiley)


        For count = 1 To Form1.iMines
Random:     Dim t = Int(iCR * Rnd())
            If aiHint(t) = -1 Then GoTo Random
            aiHint(t) = -1
        Next



        For index = 0 To iCR - 1

            If aiHint(index) = 0 Then

                Dim count = 0

                Dim srdgIndices() = SurroundingIndices(index)
                For Each si In srdgIndices
                    If aiHint(si) = -1 Then count += 1
                Next

                aiHint(index) = count       'update hint

            End If

        Next



    End Sub



    Private Function SurroundingIndices(i As Integer) As Integer()

        Dim srdgIdcs() As Integer = {}

        If i - 1 >= 0 And i - 1 < iCR And i Mod iC <> 0 Then srdgIdcs.Append(i - 1)
        If i + 1 >= 0 And i + 1 < iCR And i Mod iC <> iC - 1 Then srdgIdcs.Append(i + 1)
        If i - iC >= 0 And i - iC < iCR And i \ iC <> 0 Then srdgIdcs.Append(i - iC)
        If i + iC >= 0 And i + iC < iCR And i \ iC <> iR - 1 Then srdgIdcs.Append(i + iC)
        If i - iC - 1 >= 0 And i - iC - 1 < iCR And i Mod iC <> 0 And i \ iC <> 0 Then srdgIdcs.Append(i - iC - 1)
        If i + iC - 1 >= 0 And i + iC - 1 < iCR And i Mod iC <> 0 And i \ iC <> iR - 1 Then srdgIdcs.Append(i + iC - 1)
        If i - iC + 1 >= 0 And i - iC + 1 < iCR And i Mod iC <> iC - 1 And i \ iC <> 0 Then srdgIdcs.Append(i - iC + 1)
        If i + iC + 1 >= 0 And i + iC + 1 < iCR And i Mod iC <> iC - 1 And i \ iC <> iR - 1 Then srdgIdcs.Append(i + iC + 1)

        Return srdgIdcs

    End Function



End Class