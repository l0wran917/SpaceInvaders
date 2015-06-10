Public Class Missile
    Inherits PictureBox

    Dim vitesse As Integer = 15
    Dim tireur As Vaisseau

    Sub New(ByVal tireur As Vaisseau)
        Image = Image.FromFile("../../img/missile.png")
        Size = Image.Size

        Location = tireur.Location

        Me.tireur = tireur
    End Sub

    Sub deplacer()
        If (Location.Y > 0) Then
            Location = New Point(Location.X, Location.Y - vitesse)
        Else
            tireur.supprimerMissile(False)
        End If

        BringToFront() ' Affiche les missiles au 1er plan
    End Sub

End Class
