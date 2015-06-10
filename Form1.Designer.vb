<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.lblNbMissile = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chxIllimite = New System.Windows.Forms.CheckBox()
        Me.txtNbMissile = New System.Windows.Forms.TextBox()
        Me.cmbDifficulte = New System.Windows.Forms.ComboBox()
        Me.btnQuitter = New System.Windows.Forms.Button()
        Me.btnJouer = New System.Windows.Forms.Button()
        Me.pnlMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMenu
        '
        Me.pnlMenu.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlMenu.Controls.Add(Me.lblNbMissile)
        Me.pnlMenu.Controls.Add(Me.Label1)
        Me.pnlMenu.Controls.Add(Me.chxIllimite)
        Me.pnlMenu.Controls.Add(Me.txtNbMissile)
        Me.pnlMenu.Controls.Add(Me.cmbDifficulte)
        Me.pnlMenu.Controls.Add(Me.btnQuitter)
        Me.pnlMenu.Controls.Add(Me.btnJouer)
        Me.pnlMenu.Location = New System.Drawing.Point(0, 0)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(362, 254)
        Me.pnlMenu.TabIndex = 0
        '
        'lblNbMissile
        '
        Me.lblNbMissile.AutoSize = True
        Me.lblNbMissile.Location = New System.Drawing.Point(42, 59)
        Me.lblNbMissile.Name = "lblNbMissile"
        Me.lblNbMissile.Size = New System.Drawing.Size(88, 13)
        Me.lblNbMissile.TabIndex = 6
        Me.lblNbMissile.Text = "Nombre missiles :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Difficulté : "
        '
        'chxIllimite
        '
        Me.chxIllimite.AutoSize = True
        Me.chxIllimite.Location = New System.Drawing.Point(257, 58)
        Me.chxIllimite.Name = "chxIllimite"
        Me.chxIllimite.Size = New System.Drawing.Size(53, 17)
        Me.chxIllimite.TabIndex = 4
        Me.chxIllimite.Text = "illimité"
        Me.chxIllimite.UseVisualStyleBackColor = True
        '
        'txtNbMissile
        '
        Me.txtNbMissile.Location = New System.Drawing.Point(136, 56)
        Me.txtNbMissile.Name = "txtNbMissile"
        Me.txtNbMissile.Size = New System.Drawing.Size(115, 20)
        Me.txtNbMissile.TabIndex = 3
        '
        'cmbDifficulte
        '
        Me.cmbDifficulte.FormattingEnabled = True
        Me.cmbDifficulte.Items.AddRange(New Object() {"Tutoriel", "Facile", "Normal", "Difficile", "Impossible"})
        Me.cmbDifficulte.Location = New System.Drawing.Point(115, 29)
        Me.cmbDifficulte.Name = "cmbDifficulte"
        Me.cmbDifficulte.Size = New System.Drawing.Size(195, 21)
        Me.cmbDifficulte.TabIndex = 2
        '
        'btnQuitter
        '
        Me.btnQuitter.Location = New System.Drawing.Point(45, 186)
        Me.btnQuitter.Name = "btnQuitter"
        Me.btnQuitter.Size = New System.Drawing.Size(265, 46)
        Me.btnQuitter.TabIndex = 1
        Me.btnQuitter.Text = "Quitter"
        Me.btnQuitter.UseVisualStyleBackColor = True
        '
        'btnJouer
        '
        Me.btnJouer.Location = New System.Drawing.Point(45, 102)
        Me.btnJouer.Name = "btnJouer"
        Me.btnJouer.Size = New System.Drawing.Size(265, 46)
        Me.btnJouer.TabIndex = 0
        Me.btnJouer.Text = "Jouer"
        Me.btnJouer.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 253)
        Me.Controls.Add(Me.pnlMenu)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlMenu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents btnJouer As System.Windows.Forms.Button
    Friend WithEvents btnQuitter As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chxIllimite As System.Windows.Forms.CheckBox
    Friend WithEvents txtNbMissile As System.Windows.Forms.TextBox
    Friend WithEvents cmbDifficulte As System.Windows.Forms.ComboBox
    Friend WithEvents lblNbMissile As System.Windows.Forms.Label

End Class
