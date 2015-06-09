Public Class Form1

    Dim tmrJeu As Timer
    Dim joueur As Vaisseau
    Dim aliens As GestionAliens

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrJeu = New Timer()
        joueur = New Vaisseau()
        aliens = New GestionAliens(2, 5)

        tmrJeu.Interval = 30
        tmrJeu.Start()
        AddHandler tmrJeu.Tick, AddressOf event_Tick ' Association fct reflexe au tick

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
        joueur.deplacerMissile()
        aliens.collision(joueur.getMissile())

    End Sub

End Class
