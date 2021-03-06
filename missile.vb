﻿Public Class Missile
    Inherits PictureBox

    Dim vitesse As Integer = 15 ' Vitesse de deplacement
    Dim tireur As Vaisseau ' Reference vers le vaisseau qui lance le missile

    ''' <summary>
    ''' Constructeur (charge img + position)
    ''' </summary>
    ''' <param name="tireur"></param>
    ''' <remarks></remarks>
    Sub New(ByVal tireur As Vaisseau)
        Image = Image.FromFile("../../img/missile.png")
        Size = Image.Size

        Location = tireur.Location

        Me.tireur = tireur
    End Sub

    ''' <summary>
    ''' Deplace le missile en Y en fonction de sa vitesse
    ''' </summary>
    ''' <remarks></remarks>
    Sub deplacer()
        If (Location.Y > 0) Then
            Location = New Point(Location.X, Location.Y - vitesse)
        Else
            tireur.supprimerMissile(False)
        End If

        BringToFront() ' Affiche les missiles au 1er plan
    End Sub

End Class
