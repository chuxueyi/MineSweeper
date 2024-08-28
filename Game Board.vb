

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

    Dim iDiscovered As Integer


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
            .Name = i,
            .Text = "",
            .Width = 30,
            .Height = 30,
            .Margin = New Padding(0),
            .Location = New Point(iX + (i Mod iC) * 30, iY + (i \ iC) * 30)})
        i += 1
        If i < iC * iR Then GoTo Board



        For Each ctrl In Me.Controls
            If TypeOf ctrl Is Button Then


                AddHandler DirectCast(ctrl, Button).Click, Sub(sender As Button, e As EventArgs)


                                                               Dim pvt = CInt(sender.Name)

                                                               Dim pvtHint = aiHint(pvt)

                                                               If pvtHint = -1 Then

                                                                   sender.Image = Image.FromFile(stPathExploded)

                                                                   DirectCast(Me.Controls.Item(0), PictureBox).Image = Image.FromFile(stPathNotHappy)

                                                                   MsgBox("Swept: " & iDiscovered * 100 \ Form1.iCount & "%")

                                                                   Exit Sub

                                                               End If

                                                               sender.Text = pvtHint

                                                               SweepSurrounding(pvt)


                                                               If iDiscovered = Form1.iCount Then DirectCast(Me.Controls.Item(0), PictureBox).Image = Image.FromFile(stPathFeelingGood)



                                                           End Sub



            End If


        Next


        AddHandler Me.Controls.Item(0).Click, Sub(sender As Object, e As EventArgs)

                                                  NewGame(False)

                                              End Sub


        NewGame(True)



    End Sub



    Private Sub SweepSurrounding(pvt As Integer)

        Dim srdgIdcs() = SurroundingIndices(pvt)

        Dim fogged = 0
        Dim discovered = 0
        Dim safe = 0

        Dim state(srdgIdcs.Count - 1) As String

        For index = 0 To srdgIdcs.Count - 1
            Dim srdgBtn As Button = Me.Controls.Item(srdgIdcs(index) + 1)
            If srdgBtn.Text = "" And srdgBtn.Image Is Nothing Then
                fogged += 1
                state(index) = "fogged"
            End If
            If srdgBtn.Image IsNot Nothing Then
                discovered += 1
                state(index) = "discovered"
            End If
            If srdgBtn.Text <> "" Then
                safe += 1
                state(index) = "safe"
            End If
        Next


        If fogged + discovered + safe <> srdgIdcs.Count Then MsgBox("something wrong")


        'now compare
        Dim pvtHint = aiHint(pvt)

        If discovered > pvtHint Then MsgBox("something wrong 1")

        If discovered = pvtHint Then
            If fogged = 0 Then Exit Sub
            If fogged > 0 Then
                For index = 0 To srdgIdcs.Count - 1
                    If state(index) = "fogged" Then Me.Controls.Item(srdgIdcs(index) + 1).Text = aiHint(srdgIdcs(index))
                Next
            End If
        End If

        If discovered < pvtHint Then
            If discovered + fogged > pvtHint Then
                Exit Sub    'still can work
            End If
            If discovered + fogged = pvtHint Then
                For index = 0 To srdgIdcs.Count - 1
                    If state(index) = "fogged" Then Me.Controls.Item(srdgIdcs(index) + 1).Text = aiHint(srdgIdcs(index))
                Next
            End If
            If discovered + fogged < pvtHint Then MsgBox("something wrong 2")
        End If


        For Each si In srdgIdcs
            If Me.Controls.Item(si).Text <> "" Then SweepSurrounding(si)
        Next


    End Sub


    Private Sub NewGame(isInit As Boolean)


        If Not isInit Then


            For Each hint In aiHint
                hint = 0                      'clear the hints
            Next


            iDiscovered = 0


            For index = 1 To iCR
                Me.Controls.Item(index).Text = ""
                DirectCast(Me.Controls.Item(index), Button).Image = Nothing
            Next


            DirectCast(Me.Controls.Item(0), PictureBox).Image = Image.FromFile(stPathSmiley)


        End If


        For count = 1 To Form1.iCount
Random:     Dim t = Int(iCR * Rnd())               'place mines randomly
            If aiHint(t) = -1 Then GoTo Random
            aiHint(t) = -1
        Next


        For index = 0 To iCR - 1
            If aiHint(index) = 0 Then       'for every not mine block
                Dim count = 0
                Dim srdg() = SurroundingIndices(index)
                For Each srdgIndex In srdg
                    If aiHint(srdgIndex) = -1 Then count += 1
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