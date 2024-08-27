
Public Class frmGame


    Dim iC = Form1.iCol
    Dim iR = Form1.iRow
    Dim iCR = iC * iR


    Dim aiHint(iCR) As Integer
    Dim iClicked As Integer

    Dim abClicked() As Boolean


    Private Sub frmGame_Load() Handles MyBase.Load


        Me.Controls.Add(New PictureBox With {
            .Image = Image.FromFile("C:\Users\Administrator\source\repos\MineSweeper\Resources\smiley1.ico"),
            .Width = iC * 30 \ 6,
            .Height = iC * 30 \ 6,
            .SizeMode = PictureBoxSizeMode.StretchImage,
            .BorderStyle = BorderStyle.None,
            .Location = New Point((iC * 30 - iC * 30 \ 6) / 2, iC)})



        Dim iX = 0
        Dim iY = iC * 30 \ 6 + 2 * iC

        Dim i = 0
Board:  Me.Controls.Add(New Button With {
            .Name = "" & i,
            .Text = "",
            .Width = 30,
            .Height = 30,
            .Margin = New Padding(0),
            .Location = New Point(iX + (i Mod iC) * 30, iY + (i \ iC) * 30)})
        i += 1
        If i < iC * iR Then GoTo Board



        For Each eCtrl In Me.Controls
            If TypeOf eCtrl Is Button Then
                AddHandler DirectCast(eCtrl, Button).Click, Sub(sender As Button, e As MouseEventArgs)
                                                                If e.Button = MouseButtons.Left Then
                                                                    i = CInt(sender.Name)
                                                                    If aiHint(i) = -1 Then
                                                                        sender.Image = Image.FromFile("C:\Users\Administrator\source\repos\MineSweeper\Resources\mine4.ico")
                                                                        ShowAns(i)
                                                                        DirectCast(Me.Controls.Item(0), PictureBox).Image = Image.FromFile("C:\Users\Administrator\source\repos\MineSweeper\Resources\smiley3.ico")
                                                                    End If
                                                                    If aiHint(i) <> -1 Then
                                                                        sender.Text = "" & aiHint(i)
                                                                        abClicked(i) = True
                                                                        iClicked += 1
                                                                        If iClicked = iCR - Form1.iCount Then DirectCast(Me.Controls.Item(0), PictureBox).Image = Image.FromFile("C:\Users\Administrator\source\repos\MineSweeper\Resources\smiley.ico")
                                                                        ComputerPlay(Form1.iSteps)
                                                                    End If
                                                                End If


                                                                If e.Button = MouseButtons.Right Then
                                                                    sender.Image = Image.FromFile("C:\Users\Administrator\source\repos\MineSweeper\Resources\mine2.ico")
                                                                End If

                                                            End Sub
            End If
        Next


        AddHandler Me.Controls.Item(0).Click, Sub(sender As Object, e As EventArgs)
                                                  NewGame()
                                                  sender.Image = Image.FromFile("C:\Users\Administrator\source\repos\MineSweeper\Resources\smiley1.ico")
                                              End Sub


        NewGame()



    End Sub

    Private Sub ComputerPlay(iStp As Integer)
        Dim i = 0
Play:   PlayOneStep()
        i += 1
        If i < iStp Then GoTo Play
    End Sub


    Private Sub PlayOneStep()
        'search from 0
        '100 percent sure move
        'one move
        Dim i = 0
Pivot:  If abClicked(i) = True Then
            i += 1
            GoTo Pivot
        End If
        If abClicked(i) = False Then
            'if around eight has one revealed(clicked) as 1
            'then pass

            'if
            'then pass
            '...
        End If
        'Dim btnPvt As Button = Me.Controls.Item(i + 1)

    End Sub

    Private Sub ShowAns(ii As Integer)


        Dim i = 0
Mine:   If i <> ii And aiHint(i) = -1 Then
            Dim btnShowing As Button = Me.Controls.Item(i + 1)
            btnShowing.Image = Image.FromFile("C:\Users\Administrator\source\repos\MineSweeper\Resources\mine2.ico")
        End If
        i += 1
        If i < iCR Then GoTo Mine


    End Sub

    Private Sub NewGame()


        Dim i = 0
Clear:  aiHint(i) = 0
        i += 1
        If i < iCR Then GoTo Clear


        i = 0
Random: Dim iRdm = Int(iCR * Rnd())
        If aiHint(iRdm) = -1 Then GoTo Random
        If aiHint(iRdm) = 0 Then
            aiHint(iRdm) = -1
            i += 1
            If i < Form1.iCount Then GoTo Random
        End If


        i = 0
Hint:   If aiHint(i) = 0 Then
            Dim iHint = 0
            If i - 1 >= 0 And i - 1 < iCR And i Mod iC <> 0 Then If aiHint(i - 1) = -1 Then iHint += 1
            If i + 1 >= 0 And i + 1 < iCR And i Mod iC <> iC - 1 Then If aiHint(i + 1) = -1 Then iHint += 1
            If i - iC >= 0 And i - iC < iCR And i \ iC <> 0 Then If aiHint(i - iC) = -1 Then iHint += 1
            If i + iC >= 0 And i + iC < iCR And i \ iC <> iR - 1 Then If aiHint(i + iC) = -1 Then iHint += 1
            If i - iC - 1 >= 0 And i - iC - 1 < iCR And i Mod iC <> 0 And i \ iC <> 0 Then If aiHint(i - iC - 1) = -1 Then iHint += 1
            If i + iC - 1 >= 0 And i + iC - 1 < iCR And i Mod iC <> 0 And i \ iC <> iR - 1 Then If aiHint(i + iC - 1) = -1 Then iHint += 1
            If i - iC + 1 >= 0 And i - iC + 1 < iCR And i Mod iC <> iC - 1 And i \ iC <> 0 Then If aiHint(i - iC + 1) = -1 Then iHint += 1
            If i + iC + 1 >= 0 And i + iC + 1 < iCR And i Mod iC <> iC - 1 And i \ iC <> iR - 1 Then If aiHint(i + iC + 1) = -1 Then iHint += 1
            aiHint(i) = iHint
        End If
        i += 1
        If i < iCR Then GoTo Hint


        iClicked = 0


        i = 0
clear1: Me.Controls.Item(i + 1).Text = ""
        DirectCast(Me.Controls.Item(i + 1), Button).Image = Nothing
        i += 1
        If i < iCR Then GoTo clear1


        i = 0
Clear2: abClicked(i) = False
        i += 1
        If i < iCR Then GoTo Clear2


    End Sub


End Class