Public Class Form1


    Public joueur As New Vaisseau(New Point(50, 250)) ' Créer un joueur
    Public pnlJeu As New Panel()   ' Créer panel de jeu

#Region "Classes"

    ''' <summary>
    ''' Classe representant le vaisseau du joueur
    ''' </summary>
    ''' <remarks></remarks>
    Class Vaisseau
        Private position As New Point() ' Position du joueur
        Private taille As New Size()    ' Taille du joueur

        Private img As New PictureBox() ' Img du joueur

        Private scrore As Integer       ' Score du joueur

        Private vitesse As Integer      ' Vitesse de deplacement du joueur

        Private missiles As New List(Of Missile)

        ''' <summary>
        ''' Constructeur
        ''' </summary>
        ''' <param name="pos">Position du joeuur</param>
        ''' <param name="tailleJoueur">Taille du joueur</param>
        ''' <remarks></remarks>
        Sub New(ByVal pos As Point) ' Constructeur
            position = pos
            vitesse = 20

            img.Image = Image.FromFile("../../img/vaisseau.png")
            taille = img.Size

        End Sub

        ''' <summary>
        ''' Getter pour obtenir la pictureBox au bon endroit
        ''' </summary>
        ''' <returns>Image du joueur</returns>
        ''' <remarks></remarks>
        Function getPictureBox()        ' Retourne pictureBox
            img.Location = position
            Return img
        End Function

        ''' <summary>
        ''' Change la position du joueur en fct de sa vitesse et direction
        ''' </summary>
        ''' <param name="deplacement">Direction du deplacement (-1 | 1)</param>
        ''' <remarks></remarks>
        Sub deplacement(ByVal deplacement As Integer)
            position.X += vitesse * deplacement
            img.Location = position
        End Sub

        ''' <summary>
        ''' Declenche le lancement d'un missile 
        ''' </summary>
        ''' <remarks></remarks>
        Sub tirer()
            missiles.Add(New Missile(New Point(position.X + (taille.Width / 2), position.Y - taille.Height)))
        End Sub

    End Class

    Class Missile
        Private position As New Point() ' Position du missile
        Private taille As New Size()    ' Taille du missile

        Private vitesse As Integer  ' Vitesse deplacement missile

        Private img As New PictureBox()   ' Image du missile

        Sub New(ByVal pos As Point)
            Me.img.Image = Image.FromFile("../../img/missile.png")
            Me.position = pos
            Me.taille = img.Size
            img.Location = position
            Form1.pnlJeu.Controls.Add(img)
            Console.WriteLine(position)
        End Sub
    End Class

#End Region

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


        Me.Controls.Add(pnlJeu)
    End Sub


    Private Sub tmrJeuTick(sender As Object, e As EventArgs) Handles tmrJeu.Tick
        pnlJeu.Refresh()
    End Sub
End Class
