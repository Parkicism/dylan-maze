Public Class Form1

    Dim userLeft As Boolean = False
    Dim userRight As Boolean = False
    Dim userUp As Boolean = False
    Dim userDown As Boolean = False

    Dim speed As Integer = 3
    Dim listOfBlocks As List(Of PictureBox)

    Dim userPlay As Boolean = False
    
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

    End Sub

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

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

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

        If pbUser.Bounds.IntersectsWith(lblPlay.Bounds) Then
            userPlay = True
        End If

    End Sub

    Private Sub lblPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPlay.Click
        Me.Hide()
        Form4.Show()
    End Sub
End Class
