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
        Me.components = New System.ComponentModel.Container()
        Me.tmrJeu = New System.Windows.Forms.Timer(Me.components)
        Me.pnlJeu = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'tmrJeu
        '
        '
        'pnlJeu
        '
        Me.pnlJeu.Location = New System.Drawing.Point(0, 0)
        Me.pnlJeu.Name = "pnlJeu"
        Me.pnlJeu.Size = New System.Drawing.Size(460, 354)
        Me.pnlJeu.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 721)
        Me.Controls.Add(Me.pnlJeu)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrJeu As System.Windows.Forms.Timer
    Friend WithEvents pnlJeu As System.Windows.Forms.Panel

End Class
