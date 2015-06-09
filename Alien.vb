Public Class Alien
    Inherits PictureBox

    Sub New(ByVal pos As Point)
        Image = Image.FromFile("../../img/alien.png")
        Size = Image.Size

        Location = pos

        Form1.pnlJeu.Controls.Add(Me)
    End Sub

End Class
