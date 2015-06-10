Public Class Vaisseau
    Inherits PictureBox

    Dim vitesse As Integer = 20 ' Vitesse de deplacement
    Public missile As Missile ' Declare une reference vers 1 missile

    Dim score As Integer = 0 ' Score actuel

    Dim missileRestant As Integer = 0 ' Nb Missiles restant

    ''' <summary>
    ''' Constructeur (Charge img + position)
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
        Image = Image.FromFile("../../img/vaisseau.png")
        Size = Image.Size

        Location = New Point(10, Form1.pnlJeu.Height - Image.Height - 55) ' 15 px du bord inferieur de la fenetre

        If (Form1.chxIllimite.Checked) Then
            missileRestant = -1
        Else
            missileRestant = Form1.txtNbMissile.Text
        End If
    End Sub

    ''' <summary>
    ''' Deplace le vaisseau sur l'axe X en fonction de la direction (en fonction de la touche pressée)
    ''' </summary>
    ''' <param name="direction">Direction deplacement (Droite : 1 / Gauche : -1)</param>
    ''' <remarks></remarks>
    Sub deplacer(ByVal direction As Integer)
        Dim pos = Location
        Dim deplacement As Integer = vitesse * direction

        If ((pos.X + deplacement < 0) Or (pos.X + deplacement + Width > Form1.pnlJeu.Width)) Then
            deplacement = 0
        End If

        Location = New Point(Location.X + deplacement, Location.Y)
    End Sub

    ''' <summary>
    ''' Genere un missile (Après appui sur touche)
    ''' </summary>
    ''' <remarks></remarks>
    Sub tirer()
        If (missileRestant > 0) Then
            If (missile Is Nothing) Then
                Dim missile As New Missile(Me)
                Me.missile = missile
                Form1.pnlJeu.Controls.Add(missile)
                missileRestant -= 1
            End If
        End If
    End Sub

    ''' <summary>
    ''' Fait avancer le missile s'il existe
    ''' </summary>
    ''' <remarks></remarks>
    Sub deplacerMissile()
        If (Not missile Is Nothing) Then
            missile.deplacer()
        End If
    End Sub

    ''' <summary>
    ''' Supprime le missile du panel de jeu s'il existe
    ''' </summary>
    ''' <param name="ennemiTue">Si le missile a été un ennemi ou non (augmentation du score)</param>
    ''' <remarks></remarks>
    Sub supprimerMissile(ByVal ennemiTue As Boolean)
        If (ennemiTue) Then
            score += 10
        End If

        Form1.pnlJeu.Controls.Remove(missile)
        missile = Nothing
    End Sub

    ''' <summary>
    ''' Retourne sour forme de string le score à afficher
    ''' </summary>
    ''' <returns>Chaine de caracter de la forme => Score : x</returns>
    ''' <remarks></remarks>
    Function getScore()
        Return "Score : " + score.ToString()
    End Function


    ''' <summary>
    ''' Retourne la zone en bas de l'ecran où le joueur se deplace
    ''' </summary>
    ''' <returns>Rectangle de la zone de deplacement du joueur</returns>
    ''' <remarks></remarks>
    Function getZoneJeu()
        Dim zoneJoueur As New Rectangle()
        zoneJoueur.X = 0
        zoneJoueur.Y = Me.Location.Y
        zoneJoueur.Width = Form1.pnlJeu.Width
        zoneJoueur.Height = Form1.pnlJeu.Width - (Form1.pnlJeu.Height - Me.Location.Y)

        Return zoneJoueur
    End Function

    ''' <summary>
    ''' Retourne le nombre de missiles restant
    ''' </summary>
    ''' <returns>String de la forme => Missiles restants : x</returns>
    ''' <remarks></remarks>
    Function getMissilesRestant() As String
        If (missileRestant < 0) Then
            Return "Missiles restants : Illimité"
        Else
            Return "Missiles restants : " + missileRestant.ToString
        End If
    End Function

End Class
