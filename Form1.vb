Public Class Form1

    Private tmrJeu As Timer
    Dim joueur As Vaisseau
    Dim aliens As GestionAliens

    Public pnlJeu As New Panel()

    Dim lblScore As Label

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub event_Clavier(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.Left) Then
            joueur.deplacer(-1)
        ElseIf (e.KeyCode = Keys.Right) Then
            joueur.deplacer(1)
        ElseIf (e.KeyCode = Keys.Space) Then
            joueur.tirer()
        End If

    End Sub

    Private Sub event_Tick(ByVal sender As Object, ByVal e As EventArgs)
        aliens.deplacer()
        joueur.deplacerMissile()
        aliens.collision(joueur)
        lblScore.Text = joueur.getScore()

        finJeu()

    End Sub

    Private Sub finJeu()
        If (aliens.getNbAliens() = 0) Then
            afficherMenu()
            MsgBox("Gagné !")
        End If

        If (aliens.getPerdu()) Then
            afficherMenu()
            MsgBox("Perdu")
        End If

    End Sub

    Private Sub afficherMenu()
        tmrJeu.Stop()
        Me.Controls.Remove(pnlJeu)
        Me.Controls.Add(pnlMenu)
        btnJouer.Enabled = True
        btnQuitter.Enabled = True
        Me.Size = New Size(378, 231)
    End Sub

    Private Sub lancementPartie()
        Me.Size = New Size(600, 500)
        pnlJeu.Size = Me.Size
        pnlJeu.Location = New Point(0, 0)

        tmrJeu = New Timer()
        joueur = New Vaisseau()
        aliens = New GestionAliens(4, 6)

        lblScore = New Label()
        lblScore.Text = "Score :"
        lblScore.Font = New Font("Arial", 22)
        lblScore.AutoSize = True
        lblScore.Location = New Point(pnlJeu.Width - lblScore.Width - 80, 5)
        pnlJeu.Controls.Add(lblScore)

        pnlJeu.Controls.Add(joueur)
        tmrJeu.Interval = 30
        AddHandler tmrJeu.Tick, AddressOf event_Tick ' Association fct reflexe au tick

        btnJouer.Enabled = False
        btnQuitter.Enabled = False

        Me.Controls.Remove(pnlMenu)
        Me.Controls.Add(pnlJeu)
        tmrJeu.Start()
    End Sub


    Private Sub btnJouer_Click(sender As Object, e As EventArgs) Handles btnJouer.Click
        lancementPartie()
    End Sub

    Private Sub btnQuitter_Click(sender As Object, e As EventArgs) Handles btnQuitter.Click
        Me.Dispose()
    End Sub
End Class
