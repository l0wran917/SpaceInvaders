Public Class Form1

    Dim tmrJeu As Timer
    Dim joueur As Vaisseau
    Dim aliens As GestionAliens

    Dim lblScore As Label

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrJeu = New Timer()
        joueur = New Vaisseau()
        aliens = New GestionAliens(5, 6)

        tmrJeu.Interval = 30
        tmrJeu.Start()
        AddHandler tmrJeu.Tick, AddressOf event_Tick ' Association fct reflexe au tick

        lblScore = New Label()
        lblScore.Text = "Score :"
        lblScore.Font = New Font("Arial", 22)
        lblScore.AutoSize = True
        lblScore.Location = New Point(pnlJeu.Width - lblScore.Width - 70, 5)
        pnlJeu.Controls.Add(lblScore)

        pnlJeu.Controls.Add(joueur)
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

    End Sub

End Class
