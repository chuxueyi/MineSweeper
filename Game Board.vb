Public Class frmGame

    'gaming
    Dim stPathSmiley = "C:\Users\Administrator\source\repos\MineSweeper\Resources\smiley1.ico"
    'winning
    Dim stPathFeelingGood = "C:\Users\Administrator\source\repos\MineSweeper\Resources\smiley.ico"
    'losing
    Dim stPathNotHappy = "C:\Users\Administrator\source\repos\MineSweeper\Resources\smiley3.ico"
    Dim stPathExploded = "C:\Users\Administrator\source\repos\MineSweeper\Resources\mine4.ico"

    'x axis / columns
    Dim iC = Form1.iCol
    'y axis / rows
    Dim iR = Form1.iRow
    'total button numbers
    Dim iCR = iC * iR

    'hidden answer board
    Dim aiHint(iCR - 1) As Integer     'last index in parenthesis

    'mine probability from player's point of view
    Dim aiProb(iCR - 1) As Integer

    'every surrounding-buttons-indices for every button
    Dim aprSrdg(iCR - 1) As (Integer, Integer())

    '
    'winning
    '


    'load the game board according to designated sizes
    Private Sub frmGame_Load() Handles MyBase.Load

        'add the start happy face picturebox
        Me.Controls.Add(New PictureBox With {
            .Image = Image.FromFile(stPathSmiley),
            .Width = 50,
            .Height = 50,
            .SizeMode = PictureBoxSizeMode.StretchImage,    'stretch the image so it's size is the same as the picbox
        .Location = New Point((iC * 50 - 50) / 2, 25)})    'center horizontally, down a bit vertically


        Dim i = 0
Board:  Me.Controls.Add(New Button With {
            .Name = CStr(i),     'index in me.controls needs plus 1
            .Text = "",
            .Image = Nothing,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Width = 50,
            .Height = 50,
            .Margin = New Padding(0),
            .Location = New Point((i Mod iC) * 50, 100 + (i \ iC) * 50)})
        i += 1
        If i < iCR Then GoTo Board


        For Each ctrl In Me.Controls

            If TypeOf ctrl Is Button Then
                AddHandler DirectCast(ctrl, Button).Click, Sub(sender As Button, e As EventArgs)


                                                               Dim pvt As Integer = sender.Name

                                                               If aiHint(pvt) = -1 Then
                                                                   sender.Text = ""
                                                                   sender.Image = Image.FromFile(stPathExploded)
                                                                   DirectCast(Me.Controls.Item(0), PictureBox).Image = Image.FromFile(stPathNotHappy)

                                                               End If


                                                               If aiHint(pvt) <> -1 Then

                                                                   sender.Text = aiHint(pvt)
                                                                   aiProb(pvt) = 0

                                                                   UpdateProb(pvt)

                                                               End If


                                                           End Sub

            End If

        Next


        AddHandler Me.Controls.Item(0).Click, AddressOf NewGame


        NewGame()


    End Sub

    Private Sub NewGame()

        aiHint.Initialize()


        For index = 1 To iCR
            aiProb(index - 1) = 100
            Me.Controls.Item(index).Text = aiProb(index - 1) & "%"
            Me.Controls.Item(index).Image = Nothing
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

    Private Sub UpdateProb(startIndex As Integer)

        If aiHint(startIndex) = 0 Then
            For Each si In aprSrdg(startIndex).Item2
                Me.Controls.Item(si + 1).Text = aiHint(si)
                aiProb(si) = 0
            Next
        End If
        If aiHint(startIndex) <> 0 Then
            Dim count = 0
            For Each si As Integer In aprSrdg(startIndex).Item2
                If aiProb(si) <> 0 Then count += 1
            Next
            If count <> 0 Then
                For Each si As Integer In aprSrdg(startIndex).Item2
                    If aiProb(si) <> 0 Then
                        aiProb(si) = aiHint(startIndex) * 100 \ count
                        Me.Controls.Item(si).Text = aiProb(si) & "%"
                    End If

                Next
            End If

        End If


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