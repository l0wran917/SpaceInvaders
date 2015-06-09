Public Class Vaisseau
    Inherits PictureBox

    Dim vitesse As Integer = 20
    Dim missile As Missile

    Sub New()
        Image = Image.FromFile("../../img/vaisseau.png")
        Size = Image.Size

        Location = New Point(10, Form1.pnlJeu.Height - Image.Height - 15) ' 15 px du bord inferieur de la fenetre
    End Sub

    Sub deplacer(ByVal direction As Integer)
        Dim pos = Location
        Dim deplacement As Integer = vitesse * direction

        If ((pos.X + deplacement < 0) Or (pos.X + deplacement + Width > Form1.pnlJeu.Width)) Then
            deplacement = 0
        End If

        Location = New Point(Location.X + deplacement, Location.Y)
    End Sub

    Sub tirer()
        If (missile Is Nothing) Then
            Dim missile As New Missile(Me)
            Me.missile = missile
            Form1.pnlJeu.Controls.Add(missile)

        End If
    End Sub

    Sub deplacerMissile()
        If (Not missile Is Nothing) Then
            missile.deplacer()
        End If
    End Sub

    Sub supprimerMissile()
        Form1.pnlJeu.Controls.Remove(missile)
        missile = Nothing
    End Sub

    Function getMissile()
        Return missile
    End Function

End Class
