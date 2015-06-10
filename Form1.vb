Public Class Form1

    Private tmrJeu As Timer ' Timer qui envoi un tick pour boucle du jeu
    Dim joueur As Vaisseau ' Vaisseau du joueur
    Dim aliens As GestionAliens ' Objet qui contient tous les aliens

    Public pnlJeu As New Panel() ' Panel qui contient tous les aliens et le joueur

    Dim lblScore As Label
    Dim lblMissileRestant As Label

#Region "Fonctions evenementielles"

    ''' <summary>
    ''' Gestion controles du joueur (deplacement + tirer)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub event_Clavier(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.Left) Then
            joueur.deplacer(-1) ' Deplacement vers la gauche 
        ElseIf (e.KeyCode = Keys.Right) Then
            joueur.deplacer(1) ' Deplacement vers la droite
        ElseIf (e.KeyCode = Keys.Space) Then
            joueur.tirer() ' Lancement du missile
        End If

    End Sub

    ''' <summary>
    ''' Reflexe du timer (boucle du jeu)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub event_Tick(ByVal sender As Object, ByVal e As EventArgs)
        ' Deplacement aliens + missile
        aliens.deplacer()
        joueur.deplacerMissile()

        ' Test si missile touche alien et si alien touche zone joueur
        aliens.collision(joueur)

        ' Actualise les scores
        lblScore.Text = joueur.getScore()

        'Actualise les missiles restants
        lblMissileRestant.Text = joueur.getMissilesRestant()

        ' Test si la partie est terminée
        finJeu()

    End Sub

    ''' <summary>
    ''' Fonction lancement de la partie (clic sur btn jouer)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lancementPartie(ByVal sender As Object, ByVal e As EventArgs) Handles btnJouer.Click
        ' Verifie que les reglages sont précisé
        If (cmbDifficulte.SelectedIndex = -1) Then
            MsgBox("Veuillez choisir une difficulté")
        ElseIf (Not chxIllimite.Checked And txtNbMissile.Text.Length = 0) Then
            MsgBox("Nombre de missiles incorrect")
        Else
            ' Redimensionne la fenetre
            ' Met à la bonne position le panel de jeu
            Me.Size = New Size(600, 500)
            pnlJeu.Size = Me.Size
            pnlJeu.Location = New Point(0, 0)

            ' Declare le timer, le joueur et les aliens
            tmrJeu = New Timer()
            joueur = New Vaisseau()
            aliens = New GestionAliens()

            ' Initialisation du label pour le score
            lblScore = New Label()
            lblScore.Text = "Score :"
            lblScore.Font = New Font("Arial", 16)
            lblScore.AutoSize = True
            lblScore.Location = New Point(pnlJeu.Width - lblScore.Width - 80, 5)

            ' Declare le label nb Missile
            lblMissileRestant = New Label()
            lblMissileRestant.Text = "Missile Restant : "
            lblMissileRestant.Font = New Font("Arial", 16)
            lblMissileRestant.AutoSize = True
            lblMissileRestant.Location = New Point(0, 5)

            ' Config du timer + activation
            tmrJeu.Interval = 30
            AddHandler tmrJeu.Tick, AddressOf event_Tick ' Association fct reflexe au tick

            ' Desactivation btns du menu (Sinon ils gardent le focus)
            For Each element As Object In pnlMenu.Controls
                element.Enabled = False
            Next

            ' Supprime le menu
            Me.Controls.Remove(pnlMenu)

            ' Affiche le panel de jeu
            pnlJeu.Controls.Add(lblScore)
            pnlJeu.Controls.Add(lblMissileRestant)
            pnlJeu.Controls.Add(joueur)
            Me.Controls.Add(pnlJeu)

            ' Lance le timer
            tmrJeu.Start()
        End If
    End Sub

    ''' <summary>
    ''' Fermeture du programme
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnQuitter_Click(sender As Object, e As EventArgs) Handles btnQuitter.Click
        Me.Dispose()
    End Sub

#End Region

    ''' <summary>
    ''' Test si le joueur a gagné ou perdu
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Sub finJeu()
        ' Si il n'y a plus d'aliens
        If (aliens.getNbAliens() = 0) Then
            afficherMenu()
            MsgBox("Gagné !")
        End If

        ' Si les aliens touchent la zone du joueur
        If (aliens.getPerdu()) Then
            afficherMenu()
            MsgBox("Perdu")
        End If

    End Sub

    ''' <summary>
    ''' Masque le panel et affiche le menu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub afficherMenu()
        tmrJeu.Stop()

        ' Réactive les boutons du menu
        For Each element As Object In pnlMenu.Controls
            element.Enabled = True
        Next

        'Redimensionne la fenetre
        Me.Size = New Size(378, 292)

        'Supprime les elements de jeu
        Me.Controls.Remove(pnlJeu)
        pnlJeu.Controls.Remove(joueur)
        pnlJeu.Controls.Remove(lblScore)
        aliens.supprimerAliens()

        ' Si le missile existe, on le supprime
        If (Not joueur.missile Is Nothing) Then
            pnlJeu.Controls.Remove(joueur.missile)
        End If

        ' Affiche menu
        Me.Controls.Add(pnlMenu)
    End Sub


    Private Sub txtNbMissile_TextChanged(sender As Object, e As EventArgs) Handles txtNbMissile.TextChanged
        If (Not IsNumeric(CType(sender, TextBox).Text)) Then
            CType(sender, TextBox).Text = ""
        End If
    End Sub
End Class
