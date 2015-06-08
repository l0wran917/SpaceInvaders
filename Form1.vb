Public Class Form1

    Dim joueur As New Vaisseau(New Point(50, 650)) ' Créer un joueur
    Dim whiteBrush As New SolidBrush(Color.White)

    Dim nbLignes As Integer = 3
    Dim nbColonnes As Integer = 5

    Dim vitesseDeplacementAliens = 10
    Dim distanceDescenteAliens = 15

    Dim directionAliens = 1

    Dim nbAliensVivant = 0

    ''' <summary>
    ''' Classe representant le vaisseau du joueur
    ''' </summary>
    ''' <remarks></remarks>

#Region "Procedure evenementielle"

    ''' <summary>
    ''' Procedure appellé lors de l'appui sur une touche
    ''' </summary>
    ''' <param name="sender">Objet declancheur de l'event</param>
    ''' <param name="e">Touche appuyé</param>
    ''' <remarks></remarks>
    Public Sub event_keyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Right Then
            joueur.deplacement(1)
        ElseIf e.KeyCode = Keys.Left Then
            joueur.deplacement(-1)
        ElseIf e.KeyCode = Keys.Space Then
            joueur.tirer()
        End If

    End Sub


#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrJeu.Interval = 30
        tmrJeu.Enabled = True

        pnlJeu.Size = New Size(Me.Width, Me.Height)
        pnlJeu.BackColor = Color.Cyan
        pnlJeu.Controls.Add(joueur.getPictureBox())

        initEnnemis()

        Me.Controls.Add(pnlJeu)
    End Sub

    ''' <summary>
    ''' Initialise le FlowLayoutPanel
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initEnnemis()
        Dim i As Integer = 0
        Dim e As Integer = 0

        Dim imgAlien = New PictureBox()
        imgAlien.Image = Image.FromFile("../../img/alien.png")

        Me.FlowPnlAliens.Width = (imgAlien.Width + 10) * nbColonnes
        Me.FlowPnlAliens.Height = (imgAlien.Height + 5) * nbLignes

        For i = 0 To nbColonnes
            For e = 0 To nbLignes
                Me.FlowPnlAliens.Controls.Add(New Alien())
                nbAliensVivant += 1
            Next
        Next


    End Sub

    ''' <summary>
    ''' Rafraichissement de la position des aliens à chaque tick
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub deplacerAliens()
        Dim posAliens = FlowPnlAliens.Location

        If (posAliens.X + vitesseDeplacementAliens + FlowPnlAliens.Size.Width > Me.Width) Then
            posAliens.Y += distanceDescenteAliens
            directionAliens *= -1
        ElseIf (posAliens.X + vitesseDeplacementAliens < 0) Then
            posAliens.Y += distanceDescenteAliens
            directionAliens *= -1
        End If

        posAliens.X += directionAliens * vitesseDeplacementAliens

        FlowPnlAliens.Location = posAliens

    End Sub

    Private Sub testCollision()
        Dim i As Integer

        For e = 0 To joueur.getMissiles().Count - 1
            For i = 0 To FlowPnlAliens.Controls.Count - 1
                Dim missileTmp = joueur.getMissiles.Item(e)
                Dim alienTmp = FlowPnlAliens.Controls.Item(i)

                Dim posAlien = alienTmp.Location + FlowPnlAliens.Location
                Dim posMissile = New Point(missileTmp.getRectangle().X, missileTmp.getRectangle().Y)

                If (posMissile.Y > posAlien.Y And posMissile.Y < posAlien.Y + alienTmp.Size.Height) And
                    (posMissile.X > posAlien.X And posMissile.X + missileTmp.getRectangle().Width < posAlien.X + alienTmp.Size.Width) Then

                    CType(alienTmp, Alien).Image = Image.FromFile("../../img/alien2.png")

                End If
            Next
        Next

        Console.WriteLine(FlowPnlAliens.Controls.Item(0).Location + FlowPnlAliens.Location)
    End Sub

    ''' <summary>
    ''' Timer du jeu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tmrJeuTick(sender As Object, e As EventArgs) Handles tmrJeu.Tick

        deplacerAliens()

        For Each missile As Missile In joueur.getMissiles
            missile.deplacer()
        Next

        pnlJeu.Refresh()

        testCollision()
    End Sub

End Class
