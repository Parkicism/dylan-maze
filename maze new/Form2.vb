Public Class Form2
    Dim userLeft As Boolean = False
    Dim userRight As Boolean = False
    Dim userUp As Boolean = False
    Dim userDown As Boolean = False

    Dim speedUp As Boolean = False
    Dim speedDown As Boolean = False
    Dim speed As Integer = 3

    Dim gameOver As Boolean = False

    Dim programExit As Boolean = True

    Dim score As Integer = 250

    Dim Life As Integer = 5

    Dim listOfBlocks As New List(Of PictureBox)
    Dim listOfWalls As New List(Of PictureBox)
   



    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Up Then
            userUp = True
        End If

        If e.KeyCode = Keys.Down Then
            userDown = True
        End If

        If e.KeyCode = Keys.Left Then
            userLeft = True
        End If

        If e.KeyCode = Keys.Right Then
            userRight = True
        End If

        If e.KeyCode = Keys.W Then
            speedUp = True
        End If

        If e.KeyCode = Keys.S Then
            speedDown = True
        End If
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Up Then
            userUp = False
        End If

        If e.KeyCode = Keys.Down Then
            userDown = False
        End If

        If e.KeyCode = Keys.Left Then
            userLeft = False
        End If

        If e.KeyCode = Keys.Right Then
            userRight = False
        End If

        If e.KeyCode = Keys.W Then
            speedUp = False
        End If

        If e.KeyCode = Keys.S Then
            speedDown = False
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '=========================================================================================================
        'game over when score reachs 0
        If score = 0 Then
            Timer1.Stop()
            Timer2.Stop()
            MessageBox.Show("So BAD")
            Me.Close()
            programExit = False
            Form1.Show()
        End If
        '==========================================================================================================
        'speed CAP
        If speed <= 0 Then 'sets the speed cap of 1 so it won't go negative or 0
            speed = 1
        End If

        If speed >= 6 Then 'sets the speed cap to 10, so it won't go crazy fast 
            speed = 6
        End If

        'speed
        lblSpeed.Text = "Speed: " & speed

        '==========================================================================================================
        'code for the movement of pbUser
        If userLeft = True Then
            pbUser.Left = pbUser.Left - speed
        End If

        If userRight = True Then
            pbUser.Left = pbUser.Left + speed
        End If

        If userUp = True Then
            pbUser.Top = pbUser.Top - speed
        End If

        If userDown = True Then
            pbUser.Top = pbUser.Top + speed
        End If

        '==========================================================================================================
        'code to change the speed of User movement
        If speedUp = True Then
            speed = speed + 1
        End If

        If speedDown = True Then
            speed = speed - 1
        End If

        '==========================================================================================================
        'detects collision with all the pbWalls and pbBlocks, then resets the user to the starting point if the collision occured.

        'pbBlocks
        For x As Integer = 0 To listOfBlocks.Count - 1

            If pbUser.Bounds.IntersectsWith(listOfBlocks(x).Bounds) Then
                pbUser.Left = 10
                pbUser.Top = 405
                Life -= 1
            End If

        Next

        'pbWalls
        For x As Integer = 0 To 3
            If pbUser.Bounds.IntersectsWith(listOfWalls(x).Bounds) Then
                pbUser.Left = 10
                pbUser.Top = 405
                Life -= 1
            End If
        Next

        '=============================================================================================================
        'simple life code
        If Life = 4 Then
            pbLife1.Hide()
        End If

        If Life = 3 Then
            pbLife2.Hide()
        End If

        If Life = 2 Then
            pbLife3.Hide()
        End If

        If Life = 1 Then
            pbLife4.Hide()
        End If

        If Life = 0 Then
            pbLife5.Hide()
            Timer1.Stop()
            Timer2.Stop()
            MessageBox.Show("So BAD")
            programExit = False
            Me.Close()
            Form1.Show()
        End If

        '=============================================================================================================

        'lblFinish
        If pbUser.Bounds.IntersectsWith(lblFinish.Bounds) Then
            Timer1.Stop()
            MessageBox.Show("You beat one level, congrats! Now for the next level.")
            programExit = False
            Me.Close()
            Form3.Show()
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        score -= 1
        lblScore.Text = "Score: " & score

    End Sub

    Private Sub Form2_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        If programExit = True Then
            Form1.Close()
        End If

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'pbWall
        For Each c As Control In Me.Controls
            If TypeOf c Is PictureBox Then
                If Strings.InStr(c.Name, "pbWall") Then
                    listOfWalls.Add(c)
                End If
            End If
        Next

        'pbBlock
        For Each c As Control In Me.Controls
            If TypeOf c Is PictureBox Then
                If Strings.InStr(c.Name, "pbBlock") Then
                    listOfBlocks.Add(c)
                End If
            End If
        Next

        

    End Sub

End Class
