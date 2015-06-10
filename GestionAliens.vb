Public Class GestionAliens

    Dim aliens As New List(Of Alien) ' Liste d'alien

    Dim nbColonne As Integer ' nb Alien sur une colone
    Dim nbLigne As Integer ' nb alien sur une ligne

    Dim direction As Integer = 1 ' Direction du deplacement (Droite / Gauche)

    Dim vitesse As Point ' Vitesse deplacement en X et Y

    Dim posGroupe As Point ' Position de la zone qui contient tous les aliens
    Dim tailleZoneEnnemi As Size ' Taille de la zone qui contient tous les aliens

    Dim perdu As Boolean = False ' Si le joueur à perdu

    ''' <summary>
    ''' Constructeur
    ''' </summary>
    ''' <param name="nbLigne">Nb ligne d'alien</param>
    ''' <param name="nbColonne">Nb alien par ligne</param>
    ''' <remarks></remarks>
    Sub New()
        initAliens()
    End Sub

    ''' <summary>
    ''' Genere les aliens
    ''' </summary>
    ''' <param name="nbLigne">Nb ligne d'alien</param>
    ''' <param name="nbColonne">Nb alien par ligne</param>
    ''' <remarks></remarks>
    Sub initAliens()

        Console.WriteLine(Form1.cmbDifficulte.SelectedIndex)
        If (Form1.cmbDifficulte.SelectedIndex = 0) Then ' Tuto
            Me.vitesse = New Point(0, 0)
            Me.nbLigne = 3
            Me.nbColonne = 9
        ElseIf (Form1.cmbDifficulte.SelectedIndex = 1) Then ' Facile
            Me.vitesse = New Point(5, 8)
            Me.nbLigne = 3
            Me.nbColonne = 5
        ElseIf (Form1.cmbDifficulte.SelectedIndex = 2) Then ' Normal
            Me.vitesse = New Point(8, 15)
            Me.nbLigne = 4
            Me.nbColonne = 5
        ElseIf (Form1.cmbDifficulte.SelectedIndex = 3) Then ' Difficile
            Me.vitesse = New Point(10, 15)
            Me.nbLigne = 4
            Me.nbColonne = 7
        ElseIf (Form1.cmbDifficulte.SelectedIndex = 4) Then ' Impossible
            Me.vitesse = New Point(20, 20)
            Me.nbLigne = 6
            Me.nbColonne = 8
        End If

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


    ''' <summary>
    ''' Test collision entre missile et aliens et entre aliens et zone joueur
    ''' </summary>
    ''' <param name="joueur">joueur pour recuperer la zone du joueur</param>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Deplace tous les aliens en fonction de la direction + changement de direction sur touche un bord
    ''' </summary>
    ''' <remarks></remarks>
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


    ''' <summary>
    ''' Retourne le nombre d'aliens restant
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function getNbAliens()
        Return aliens.Count
    End Function

    ''' <summary>
    ''' Retourne si le joueur a perdu ou non
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function getPerdu()
        Return perdu
    End Function

    ''' <summary>
    ''' Supprime tous les aliens du panel de jeu
    ''' </summary>
    ''' <remarks></remarks>
    Sub supprimerAliens()
        For Each alien As Alien In aliens
            Form1.pnlJeu.Controls.Remove(alien)
        Next
    End Sub


End Class
