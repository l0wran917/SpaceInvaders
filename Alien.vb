Public Class Alien
    Inherits PictureBox

    ''' <summary>
    ''' Constructeur (Charge img + position)
    ''' </summary>
    ''' <param name="pos">Position de l'alien</param>
    ''' <remarks></remarks>
    Sub New(ByVal pos As Point)
        Image = Image.FromFile("../../img/alien.png")
        Size = Image.Size

        Location = pos

        Form1.pnlJeu.Controls.Add(Me)
    End Sub

End Class
