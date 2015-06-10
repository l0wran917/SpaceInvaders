﻿Public Class Vaisseau
    Inherits PictureBox

    Dim vitesse As Integer = 20
    Public missile As Missile

    Dim score As Integer = 0

    Sub New()
        Image = Image.FromFile("../../img/vaisseau.png")
        Size = Image.Size

        Location = New Point(10, Form1.pnlJeu.Height - Image.Height - 55) ' 15 px du bord inferieur de la fenetre
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

    Sub supprimerMissile(ByVal ennemiTue As Boolean)
        If (ennemiTue) Then
            score += 10
        End If

        Form1.pnlJeu.Controls.Remove(missile)
        missile = Nothing
    End Sub

    Function getScore()
        Return "Score : " + score.ToString()
    End Function

    Function getZoneJeu()
        Dim zoneJoueur As New Rectangle()
        zoneJoueur.X = 0
        zoneJoueur.Y = Me.Location.Y
        zoneJoueur.Width = Form1.pnlJeu.Width
        zoneJoueur.Height = Form1.pnlJeu.Width - (Form1.pnlJeu.Height - Me.Location.Y)

        Return zoneJoueur

    End Function

End Class
