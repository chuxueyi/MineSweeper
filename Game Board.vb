Public Class frmGame

    'gaming
    Dim stPathSmiley = "C:\Users\Administrator\source\repos\MineSweeper\Resources\smiley1.ico"
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

    'every surrounding-buttons-indices for every button
    Dim aprSrdg(iCR - 1) As (Integer, Integer())

    'swept area
    Dim abSwept(iCR - 1) As Boolean


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

                                                                   abSwept(pvt) = True

                                                                   FastSweep(pvt)

                                                                   MarkMines()

                                                                   CheckWinning()

                                                                   AutoSweep()

                                                               End If


                                                           End Sub

            End If

        Next


        NewGame()


    End Sub

    Private Sub AutoSweep()
        'Throw New NotImplementedException()
    End Sub

    Private Sub CheckWinning()
        Dim count = 0
        For index = 1 To iCR
            If Me.Controls.Item(index).text = "*" Then
                count += 1
                If count = Form1.iMines Then
                    MsgBox("win")
                    Me.Close()
                End If
            End If
        Next
    End Sub

    Private Sub FastSweep(pvt As Integer)
        If aiHint(pvt) = 0 Then
            For Each pp In aprSrdg(pvt).Item2
                If Not abSwept(pp) Then
                    Me.Controls.Item(pp + 1).Text = aiHint(pp)
                    abSwept(pp) = True
                    FastSweep(pp)
                End If
            Next
        End If
    End Sub

    Private Sub NewGame()

        For Each h In aiHint : h = 0 : Next

        For Each s In abSwept : s = False : Next

        For index = 1 To iCR
            Me.Controls.Item(index).Text = ""
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

    Private Sub MarkMines()

        For index = 0 To iCR - 1
            If abSwept(index) Then
                Dim ii() = aprSrdg(index).Item2
                Dim count = 0
                For Each eii In ii
                    If Not abSwept(eii) Then count += 1
                Next
                If aiHint(index) = count Then
                    For Each eii In ii
                        If Not abSwept(eii) Then
                            Me.Controls.Item(eii + 1).Text = "*"   'swept is still false
                        End If
                    Next
                End If
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