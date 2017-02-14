Public Class MainMenu

    Private Sub btnServer_Click(sender As Object, e As EventArgs) Handles btnServer.Click
        LanderServer.Show()

    End Sub

    Private Sub btnClient_Click(sender As Object, e As EventArgs) Handles btnClient.Click
        LanderClient.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SinglePlayer.Show()
    End Sub

    Private Sub btnMusic_Click(sender As Object, e As EventArgs) Handles btnMusic.Click
        ' Toggles the music on or off when a button is pressed.
        Jukebox.toggleMusic()
        If Jukebox.isPlaying() Then
            btnMusic.Text = "Stop Music"
        Else
            btnMusic.Text = "Start Music"
        End If
    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Jukebox.toggleMusic()
    End Sub
End Class