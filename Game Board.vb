Public Class frmGame

    'icon-size image paths
    Dim stPathSmiley = "C:\Users\Administrator\source\repos\MineSweeper\Resources\smiley1.ico"
    Dim stPathFeelingGood = "C:\Users\Administrator\source\repos\MineSweeper\Resources\smiley.ico"
    Dim stPathNotHappy = "C:\Users\Administrator\source\repos\MineSweeper\Resources\smiley3.ico"
    Dim stPathExploded = "C:\Users\Administrator\source\repos\MineSweeper\Resources\mine4.ico"
    Dim stPathDiscovered = "C:\Users\Administrator\source\repos\MineSweeper\Resources\mine2.ico"

    'x axis / columns
    Dim iC = Form1.iCol
    'y axis / rows
    Dim iR = Form1.iRow
    'total button numbers
    Dim iCR = iC * iR

    'hidden answer board
    Dim aiHint(iCR - 1) As Integer     'last index in parenthesis

    'fogged, discovered, or safe
    Dim astState(iCR - 1) As String

    'every surrounding buttons' indices for every button
    Dim aprSrdg(iCR - 1) As (Integer, Integer())

    'number of mines discovered successfully
    Dim iDscvrdToTal As Integer

    'load the game board according to designated sizes
    Private Sub frmGame_Load() Handles MyBase.Load

        'add the start happy face picturebox
        Me.Controls.Add(New PictureBox With {
            .Image = Image.FromFile(stPathSmiley),
            .Width = 50,
            .Height = 50,
            .SizeMode = PictureBoxSizeMode.StretchImage,    'stretch the image so it's size is the same as the picbox
        .Location = New Point((iC * 30 - 50) / 2, 30)})    'center horizontally, down a bit vertically

        'start x of game board, 0
        'start y of game board, 50 + 2 * 30
        Dim sy = 110

        Dim i = 0
Board:  Me.Controls.Add(New Button With {
            .Name = CStr(i),     'index in me.controls needs plus 1
            .Text = "",
            .Image = Nothing,
            .Width = 30,
            .Height = 30,
            .Margin = New Padding(0),
            .Location = New Point((i Mod iC) * 30, sy + (i \ iC) * 30)})
        i += 1
        If i < iCR Then GoTo Board


        For Each ctrl In Me.Controls

            If TypeOf ctrl Is Button Then
                AddHandler DirectCast(ctrl, Button).Click, Sub(sender As Button, e As EventArgs)


                                                               Dim pvt As Integer = sender.Name

                                                               MsgBox(pvt)
                                                               If aiHint(pvt) = -1 Then

                                                                   sender.Image = Image.FromFile(stPathExploded)
                                                                   DirectCast(Me.Controls.Item(0), PictureBox).Image = Image.FromFile(stPathNotHappy)
                                                                   'MsgBox("Game End! Swept: " & iDscvrdToTal * 100 \ Form1.iMines & "%")
                                                                   Exit Sub

                                                               End If


                                                               If aiHint(pvt) <> -1 Then

                                                                   sender.Text = aiHint(pvt)
                                                                   astState(pvt) = "safe"
                                                                   SweepSurrounding(pvt)

                                                               End If


                                                           End Sub

            End If

        Next


        AddHandler Me.Controls.Item(0).Click, AddressOf NewGame


        NewGame()


    End Sub



    Private Sub SweepSurrounding(pvt As Integer)

        Dim pvtHint = aiHint(pvt)
        Dim srdgIdcs() = aprSrdg(pvt).Item2

        If pvtHint = 0 Then
            For Each si In srdgIdcs
                Me.Controls.Item(si + 1).Text = aiHint(si)
                astState(si) = "safe"
            Next
        End If

        If pvtHint = 8 Then
            For Each si In srdgIdcs
                DirectCast(Me.Controls.Item(si + 1), Button).Image = Image.FromFile(stPathDiscovered)
                astState(si) = "discovered"
            Next
        End If

        If pvtHint > 0 And pvtHint < 8 Then
            Dim fogged = 0
            Dim discovered = 0
            For Each si In srdgIdcs
                If astState(si) = "fogged" Then fogged += 1
                If astState(si) = "discovered" Then discovered += 1
            Next
            If discovered = pvtHint Then
                If fogged > 0 Then
                    For Each si In srdgIdcs
                        If astState(si) = "fogged" Then Me.Controls.Item(si + 1).Text = aiHint(si)
                        astState(si) = "safe"
                    Next
                End If
            End If
            If discovered < pvtHint Then
                If discovered + fogged > pvtHint Then Exit Sub   'recursion exit on needing people
                If discovered + fogged = pvtHint Then
                    For Each si In srdgIdcs
                        If astState(si) = "fogged" Then DirectCast(Me.Controls.Item(si + 1), Button).Image = Image.FromFile(stPathDiscovered)
                        astState(si) = "discovered"
                        iDscvrdToTal += 1
                        If iDscvrdToTal = Form1.iMines Then
                            DirectCast(Me.Controls.Item(0), PictureBox).Image = Image.FromFile(stPathFeelingGood)
                            Exit Sub    'recursion exit on winning
                        End If
                    Next
                End If
            End If
        End If

        'For Each si In srdgIdcs
        '    If astState(si) = "safe" Then SweepSurrounding(si)
        'Next


    End Sub

    Private Sub NewGame()

        For Each h In aiHint
            h = 0
        Next

        iDscvrdToTal = 0

        For index = 1 To iCR
            Me.Controls.Item(index).Text = ""
            Me.Controls.Item(index).Image = Nothing
            astState(index - 1) = "fogged"
            aprSrdg(index - 1) = (index - 1, SurroundingIndices(index - 1))
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

                For Each si In aprSrdg(index).Item2
                    If aiHint(si) = -1 Then count += 1
                Next

                aiHint(index) = count

            End If

        Next



    End Sub


    Private Function SurroundingIndices(i As Integer) As Integer()

        Dim srdg8(7) As Integer

        Dim srdgCount = 0

        If i - 1 >= 0 And i - 1 < iCR And i Mod iC <> 0 Then
            srdg8(srdgCount) = i - 1
            srdgCount += 1
        End If
        If i + 1 >= 0 And i + 1 < iCR And i Mod iC <> iC - 1 Then
            srdg8(srdgCount) = i + 1
            srdgCount += 1
        End If
        If i - iC >= 0 And i - iC < iCR And i \ iC <> 0 Then
            srdg8(srdgCount) = i - iC
            srdgCount += 1
        End If
        If i + iC >= 0 And i + iC < iCR And i \ iC <> iR - 1 Then
            srdg8(srdgCount) = i + iC
            srdgCount += 1
        End If
        If i - iC - 1 >= 0 And i - iC - 1 < iCR And i Mod iC <> 0 And i \ iC <> 0 Then
            srdg8(srdgCount) = i - iC - 1
            srdgCount += 1
        End If
        If i + iC - 1 >= 0 And i + iC - 1 < iCR And i Mod iC <> 0 And i \ iC <> iR - 1 Then
            srdg8(srdgCount) = i + iC - 1
            srdgCount += 1
        End If
        If i - iC + 1 >= 0 And i - iC + 1 < iCR And i Mod iC <> iC - 1 And i \ iC <> 0 Then
            srdg8(srdgCount) = i - iC + 1
            srdgCount += 1
        End If
        If i + iC + 1 >= 0 And i + iC + 1 < iCR And i Mod iC <> iC - 1 And i \ iC <> iR - 1 Then
            srdg8(srdgCount) = i + iC + 1
            srdgCount += 1
        End If

        Dim srdgIdcs(srdgCount - 1) As Integer
        For index = 0 To srdgCount - 1
            srdgIdcs(index) = srdg8(index)
        Next


        Return srdgIdcs

    End Function

    Private Sub Repeat(times As Integer, oneTime As Func(Of Object))
        For index = 1 To times
            oneTime()
        Next
    End Sub



End Class