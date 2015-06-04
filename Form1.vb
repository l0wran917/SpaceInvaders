Public Class Form1

#Region "Classes"

    ''' <summary>
    ''' Classe representant le vaisseau du joueur
    ''' </summary>
    ''' <remarks></remarks>
    Class Joueur
        Private position As New Point() ' Position du joueur
        Private taille As New Size()    ' Taille du joueur

        Private img As New PictureBox() ' Img du joueur

        Private scrore As Integer       ' Score du joueur

        Sub New(ByVal pos As Point, ByVal tailleJoueur As Size) ' Constructeur
            position = pos
            taille = tailleJoueur

            img.Image = Image.FromFile("../../img/vaisseau.png")
        End Sub

        Function getPictureBox()        ' Retourne pictureBox
            img.Location = position
            Return img
        End Function

    End Class

#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim joueur As New Joueur(New Point(50, 50), New Size(68, 49))

        Me.Controls.Add(joueur.getPictureBox())
    End Sub


End Class
