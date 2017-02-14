' Project: Lunar Lander
' Jukebox version 1.0.0.0
' Description:
'   This module handles playing music. The music resource must be defined within this module.
' Author: Originally created by Donielle Perfetti. Modified into a module by Joshua Church.
' Date: April 30, 2016
' IDE: Visual Studio 2015

Module Jukebox
    Dim musicOn As Boolean = False  ' Flag indicating whether music is currently playing.

    Public Sub toggleMusic()
        ' When called the music is toggled on or off.
        If musicOn = True Then
            My.Computer.Audio.Stop()
            musicOn = False
        ElseIf musicOn = False Then
            ' Plays the audio file represented by the resource
            My.Computer.Audio.Play(My.Resources.MoonMachine__Version_2_, AudioPlayMode.BackgroundLoop)
            musicOn = True
        End If
    End Sub

    Public Function isPlaying() As Boolean
        Return musicOn
    End Function
End Module