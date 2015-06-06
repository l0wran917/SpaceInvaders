Public Class Form1


    Public joueur As New Vaisseau(New Point(50, 650)) ' Créer un joueur
    Private whiteBrush As New SolidBrush(Color.White)

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
            missiles.Add(New Missile(New Point(position.X + 31, position.Y)))
        End Sub

        Public Function getMissiles()
            Return missiles
        End Function


    End Class

    Class Missile
        Private position As New Point() ' Position du missile
        Private taille As New Size()    ' Taille du missile

        Private vitesse As Integer  ' Vitesse deplacement missile

        Sub New(ByVal pos As Point)
            Me.taille = New Size(5, 15)
            Me.position = pos - New Size(0, taille.Height)
            vitesse = 7
        End Sub


        ''' <summary>
        ''' Fait avancer le missile vers les ennemis
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub deplacer()
            position.Y -= vitesse
        End Sub

        ''' <summary>
        ''' Retourne le rectangle formé par le missile pour l'affichage
        ''' </summary>
        ''' <returns>Rectangle formé par le missile</returns>
        ''' <remarks></remarks>
        Public Function getRectangle()
            Return New Rectangle(position.X, position.Y, taille.Width, taille.Height)
        End Function
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

    Public Sub event_paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pnlJeu.Paint
        Dim g As Graphics = e.Graphics

        ' AntiAliasing
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        ' On affiche chaque missile
        For Each missile As Missile In joueur.getMissiles
            g.FillRectangle(whiteBrush, missile.getRectangle())
        Next

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

        For Each missile As Missile In joueur.getMissiles
            missile.deplacer()
        Next

        Console.WriteLine(Me.Size)

        pnlJeu.Refresh()
    End Sub

End Class
