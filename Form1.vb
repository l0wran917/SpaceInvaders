Public Class Form1



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

        ''' <summary>
        ''' Constructeur
        ''' </summary>
        ''' <param name="pos">Position du joeuur</param>
        ''' <param name="tailleJoueur">Taille du joueur</param>
        ''' <remarks></remarks>
        Sub New(ByVal pos As Point) ' Constructeur
            position = pos
            vitesse = 50

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
        ''' 
        ''' </summary>
        ''' <param name="deplacement"></param>
        ''' <remarks></remarks>
        Sub deplacement(ByVal deplacement As Integer)
            position.X += vitesse * deplacement
            img.Location = position
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

    Dim joueur As New Vaisseau(New Point(50, 250)) ' Créer un joueur
    Dim pnlJeu As New Panel()   ' Créer panel de jeu

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
