Public Class GestionAliens

    Dim aliens As New List(Of Alien)

    Sub New(ByVal nbLigne As Integer, ByVal nbColonne As Integer)
        initAliens(nbLigne, nbColonne)
    End Sub

    Sub initAliens(ByVal nbLigne As Integer, ByVal nbColonne As Integer)

        Dim pos As New Point(15, 15)

        Dim alienRef As New Alien(pos)
        Dim tailleAlien As New Size()
        tailleAlien = alienRef.Size

        For i As Integer = 0 To nbLigne
            For e As Integer = 0 To nbColonne
                Dim alien As New Alien(pos)
                aliens.Add(alien)

                pos.X += tailleAlien.Width + 30
            Next
            pos.X = 15
            pos.Y += tailleAlien.Height + 10
        Next

    End Sub

    Sub collision(ByVal missile As Missile)
        If (Not missile Is Nothing) Then

        End If
    End Sub

End Class
