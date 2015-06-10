Public Class GestionAliens

    Dim aliens As New List(Of Alien)

    Dim nbColonne As Integer
    Dim nbLigne As Integer

    Dim tailleZoneEnnemi As Size
    Dim direction As Integer = 1

    Dim vitesse As New Point(8, 15)

    Dim posGroupe As Point

    Dim perdu As Boolean = False

    Sub New(ByVal nbLigne As Integer, ByVal nbColonne As Integer)
        initAliens(nbLigne, nbColonne)
    End Sub

    Sub initAliens(ByVal nbLigne As Integer, ByVal nbColonne As Integer)

        Me.nbLigne = nbLigne
        Me.nbColonne = nbColonne

        Dim pos As New Point(15, 40)
        posGroupe = pos

        Dim alienRef As New Alien(pos)
        Dim tailleAlien As New Size()

        tailleAlien = alienRef.Size

        Dim espaceEntreAliens As New Size(30, 10)
        tailleZoneEnnemi = New Size(0, 0)

        tailleZoneEnnemi.Width = (tailleAlien.Width * nbColonne) + (espaceEntreAliens.Width * (nbColonne - 1))
        tailleZoneEnnemi.Height = (tailleAlien.Height * nbLigne) + (espaceEntreAliens.Height * (nbLigne - 1))


        Form1.pnlJeu.Controls.Remove(alienRef) ' Supprime l'alien de reference du panel
        For i As Integer = 1 To nbLigne
            For e As Integer = 1 To nbColonne
                Dim alien As New Alien(pos)
                aliens.Add(alien)

                pos.X += tailleAlien.Width + espaceEntreAliens.Width
            Next
            pos.X = 15
            pos.Y += tailleAlien.Height + espaceEntreAliens.Height
        Next

    End Sub

    Sub collision(ByRef joueur As Vaisseau)

        Dim missile As Missile = joueur.missile

        For Each alien In aliens
            If (Not missile Is Nothing) Then
                If alien.Bounds.IntersectsWith(missile.Bounds) Then

                    joueur.supprimerMissile(True) ' Supprime le missile

                    Form1.pnlJeu.Controls.Remove(alien) ' Supprime l'alien
                    aliens.Remove(alien)

                    Exit For
                End If
            End If

            perdu = (alien.Bounds.IntersectsWith(joueur.getZoneJeu()))
        Next


    End Sub

    Sub deplacer()

        Dim deplacement As New Point(0, 0)

        If (posGroupe.X + tailleZoneEnnemi.Width > Form1.pnlJeu.Width) Or (posGroupe.X < 0) Then
            direction *= -1
            deplacement.Y += vitesse.Y
        End If

        For Each alien As Alien In aliens

            deplacement.X = vitesse.X * direction

            alien.Location += deplacement
        Next

        posGroupe += deplacement
    End Sub

    Function getNbAliens()
        Return aliens.Count
    End Function

    Function getPerdu()
        Return perdu
    End Function

    Sub supprimerAliens()
        For Each alien As Alien In aliens
            Form1.pnlJeu.Controls.Remove(alien)
        Next
    End Sub


End Class
