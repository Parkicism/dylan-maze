Public Class Form4

    Dim userLeft As Boolean = False
    Dim userRight As Boolean = False
    Dim userUp As Boolean = False
    Dim userDown As Boolean = False

    Dim speedUp As Boolean = False
    Dim speedDown As Boolean = False
    Dim speed As Integer = 3

    'pbBall0
    Dim ball As Point
    Dim X As Integer = 5
    Dim Y As Integer = 0
    Dim ballRX As Integer = 0
    Dim ballRY As Integer = 0
    Dim ballSpeed As Integer = 3

    'pbBall1
    Dim ball2 As Point
    Dim X2 As Integer = 109
    Dim Y2 As Integer = 393
    Dim ballRX2 As Integer = 0
    Dim ballRY2 As Integer = 2
    Dim ballSpeed2 As Integer = 3

    'pbBall2
    Dim ball3 As Point
    Dim X3 As Integer = 202
    Dim Y3 As Integer = 0
    Dim ballRX3 As Integer = 0
    Dim ballRY3 As Integer = 0
    Dim ballSpeed3 As Integer = 3

    'pbBall3
    Dim ball4 As Point
    Dim X4 As Integer = 313
    Dim Y4 As Integer = 393
    Dim ballRX4 As Integer = 0
    Dim ballRY4 As Integer = 2
    Dim ballSpeed4 As Integer = 3

    'pbBall4
    Dim ball5 As Point
    Dim X5 As Integer = 415
    Dim Y5 As Integer = 0
    Dim ballRX5 As Integer = 0
    Dim ballRY5 As Integer = 0
    Dim ballSpeed5 As Integer = 3

    Dim gameOver As Boolean = False

    Dim programExit As Boolean = True

    Dim score As Integer = 350

    Dim Life As Integer = 5


    Dim pbGates(11) As PictureBox

    Dim listOfBlocks As New List(Of PictureBox)
    Dim listOfWalls As New List(Of PictureBox)
    Dim listOfGates As New List(Of PictureBox)
    Dim listOfBall As New List(Of PictureBox)

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'pbObstacle
        For Each c As Control In Me.Controls
            If TypeOf c Is PictureBox Then
                If Strings.InStr(c.Name, "pbObstacle") Then
                    listOfGates.Add(c)
                End If
            End If
        Next

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

        'pbBall
        For Each c As Control In Me.Controls
            If TypeOf c Is PictureBox Then
                If Strings.InStr(c.Name, "pbBall") Then
                    listOfBall.Add(c)
                End If
            End If
        Next
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        'game over
        If score = 0 Then
            Timer1.Stop()
            Timer2.Stop()
            Timer3.Stop()
            MessageBox.Show("FASTER NEXT TIME")
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

        'speed
        lblSpeed.Text = "Speed: " & speed

        '==========================================================================================================
        'detects collision with all the pbWalls and pbBlocks, then resets the user to the starting point if the collision occured.
        'pbBlocks
        For x As Integer = 0 To listOfBlocks.Count - 1

            If pbUser.Bounds.IntersectsWith(listOfBlocks(x).Bounds) And pbSwitch.BackColor = Color.Green Then
                pbUser.Left = 10
                pbUser.Top = 405
                Life -= 1
                x = 5
                Y = 0
                ballRX = 0
                ballRY = 0
                ballSpeed = 3


                X2 = 109
                Y2 = 393
                ballRX2 = 0
                ballRY2 = 2
                ballSpeed2 = 3

                X3 = 202
                Y3 = 0
                ballRX3 = 0
                ballRY3 = 0
                ballSpeed3 = 3


                X4 = 313
                Y4 = 393
                ballRX4 = 0
                ballRY4 = 2
                ballSpeed4 = 3

                X5 = 415
                Y5 = 0
                ballRX5 = 0
                ballRY5 = 0
                ballSpeed5 = 3

                pbSwitch.BackColor = Color.Cyan
                pbDoor.BackColor = Color.Cyan
            ElseIf pbUser.Bounds.IntersectsWith(listOfBlocks(x).Bounds) Then
                pbUser.Left = 10
                pbUser.Top = 405
                Life -= 1
                x = 5
                Y = 0
                ballRX = 0
                ballRY = 0
                ballSpeed = 3


                X2 = 109
                Y2 = 393
                ballRX2 = 0
                ballRY2 = 2
                ballSpeed2 = 3

                X3 = 202
                Y3 = 0
                ballRX3 = 0
                ballRY3 = 0
                ballSpeed3 = 3


                X4 = 313
                Y4 = 393
                ballRX4 = 0
                ballRY4 = 2
                ballSpeed4 = 3

                X5 = 415
                Y5 = 0
                ballRX5 = 0
                ballRY5 = 0
                ballSpeed5 = 3

            End If

        Next

        'pbWalls
        For x As Integer = 0 To 3
            If pbUser.Bounds.IntersectsWith(listOfWalls(x).Bounds) Then
                pbUser.Left = 10
                pbUser.Top = 405
                Life -= 1
                x = 5
                Y = 0
                ballRX = 0
                ballRY = 0
                ballSpeed = 3


                X2 = 109
                Y2 = 393
                ballRX2 = 0
                ballRY2 = 2
                ballSpeed2 = 3

                X3 = 202
                Y3 = 0
                ballRX3 = 0
                ballRY3 = 0
                ballSpeed3 = 3


                X4 = 313
                Y4 = 393
                ballRX4 = 0
                ballRY4 = 2
                ballSpeed4 = 3

                X5 = 415
                Y5 = 0
                ballRX5 = 0
                ballRY5 = 0
                ballSpeed5 = 3

            End If
        Next

        'pbGates
        For x As Integer = 0 To 11
            If pbUser.Bounds.IntersectsWith(listOfGates(x).Bounds) And listOfGates(x).BackColor = Color.Red Then
                pbUser.Left = 10
                pbUser.Top = 405
                Life -= 1
                x = 5
                Y = 0
                ballRX = 0
                ballRY = 0
                ballSpeed = 3


                X2 = 109
                Y2 = 393
                ballRX2 = 0
                ballRY2 = 2
                ballSpeed2 = 3

                X3 = 202
                Y3 = 0
                ballRX3 = 0
                ballRY3 = 0
                ballSpeed3 = 3


                X4 = 313
                Y4 = 393
                ballRX4 = 0
                ballRY4 = 2
                ballSpeed4 = 3

                X5 = 415
                Y5 = 0
                ballRX5 = 0
                ballRY5 = 0
                ballSpeed5 = 3

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
            MessageBox.Show("You couldn't even beat this simple game...")
            programExit = False
            Me.Close()
            Form1.Show()
        End If

        '=============================================================================================================
        'lblFinish
        If pbUser.Bounds.IntersectsWith(lblFinish.Bounds) Then
            Timer1.Stop()
            MessageBox.Show("Easy Game Easy Life")
            Me.Close()
        End If


        '=============================================================================================================
        'pbSwitch

        If pbUser.Bounds.IntersectsWith(pbSwitch.Bounds) Then
            pbSwitch.BackColor = Color.Green
            pbDoor.BackColor = Color.Gainsboro
        End If

        If pbUser.Bounds.IntersectsWith(pbDoor.Bounds) And pbDoor.BackColor = Color.Cyan Then
            pbUser.Left = 10
            pbUser.Top = 405
            Life -= 1
            X = 5
            Y = 0
            ballRX = 0
            ballRY = 0
            ballSpeed = 3


            X2 = 109
            Y2 = 393
            ballRX2 = 0
            ballRY2 = 2
            ballSpeed2 = 3

            X3 = 202
            Y3 = 0
            ballRX3 = 0
            ballRY3 = 0
            ballSpeed3 = 3


            X4 = 313
            Y4 = 393
            ballRX4 = 0
            ballRY4 = 2
            ballSpeed4 = 3

            X5 = 415
            Y5 = 0
            ballRX5 = 0
            ballRY5 = 0
            ballSpeed5 = 3
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        score -= 1
        lblScore.Text = "Score: " & score

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick

        For x As Integer = 0 To 11
            If listOfGates(x).BackColor = Color.Red Then
                Timer3.Interval = 1500
                listOfGates(x).BackColor = Color.Gainsboro
                listOfGates(x).SendToBack()
            ElseIf listOfGates(x).BackColor = Color.Gainsboro Then
                Timer3.Interval = 1000
                listOfGates(x).BackColor = Color.Red
                listOfGates(x).BringToFront()
            End If
        Next

    End Sub

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick

        'pbball0
        X = X + ballRX  'increments the x and y value
        Y = Y + ballRY
        ball.X = X 'assigns the X value to the point X and assigns the Y value to the point Y
        ball.Y = Y
        pbBall0.Location = ball

        If ball.Y >= pbWall0.Top Then
            ballRY = ballSpeed * -1
        End If

        If ball.Y <= pbWall1.Bottom Then
            ballRY = ballSpeed
        End If

        'pbball1
        X2 = X2 + ballRX2  'increments the x and y value
        Y2 = Y2 + ballRY2
        ball2.X = X2 'assigns the X value to the point X and assigns the Y value to the point Y
        ball2.Y = Y2
        pbBall1.Location = ball2

        If ball2.Y >= pbWall0.Top Then
            ballRY2 = ballSpeed2 * -1
        End If

        If ball2.Y <= pbWall1.Bottom Then
            ballRY2 = ballSpeed2
        End If

        'pbball2
        X3 = X3 + ballRX3  'increments the x and y value
        Y3 = Y3 + ballRY3
        ball3.X = X3 'assigns the X value to the point X and assigns the Y value to the point Y
        ball3.Y = Y3
        pbBall2.Location = ball3

        If ball3.Y >= pbWall0.Top Then
            ballRY3 = ballSpeed3 * -1
        End If

        If ball3.Y <= pbWall1.Bottom Then
            ballRY3 = ballSpeed3
        End If

        'pbball3
        X4 = X4 + ballRX4  'increments the x and y value
        Y4 = Y4 + ballRY4
        ball4.X = X4 'assigns the X value to the point X and assigns the Y value to the point Y
        ball4.Y = Y4
        pbBall3.Location = ball4

        If ball4.Y >= pbWall0.Top Then
            ballRY4 = ballSpeed4 * -1
        End If

        If ball4.Y <= pbWall1.Bottom Then
            ballRY4 = ballSpeed4
        End If

        'pbball4
        X5 = X5 + ballRX5  'increments the x and y value
        Y5 = Y5 + ballRY5
        ball5.X = X5 'assigns the X value to the point X and assigns the Y value to the point Y
        ball5.Y = Y5
        pbBall4.Location = ball5

        If ball5.Y >= pbWall0.Top Then
            ballRY5 = ballSpeed5 * -1
        End If

        If ball5.Y <= pbWall1.Bottom Then
            ballRY5 = ballSpeed5
        End If

        For X As Integer = 0 To 4
            If pbUser.Bounds.IntersectsWith(listOfBall(X).Bounds) Then
                pbUser.Left = 10
                pbUser.Top = 405
                Life -= 1

                X = 5
                Y = 0
                ballRX = 0
                ballRY = 0
                ballSpeed = 3


                X2 = 109
                Y2 = 393
                ballRX2 = 0
                ballRY2 = 2
                ballSpeed2 = 3

                X3 = 202
                Y3 = 0
                ballRX3 = 0
                ballRY3 = 0
                ballSpeed3 = 3


                X4 = 313
                Y4 = 393
                ballRX4 = 0
                ballRY4 = 2
                ballSpeed4 = 3

                X5 = 415
                Y5 = 0
                ballRX5 = 0
                ballRY5 = 0
                ballSpeed5 = 3

            End If
        Next

    End Sub

    Private Sub Form4_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If programExit = True Then
            Form1.Close()
        End If
    End Sub

    Private Sub Form4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

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


    Private Sub Form4_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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
End Class