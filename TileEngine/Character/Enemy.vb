Imports Microsoft.Xna.Framework

Public Class Enemy
    Inherits Character

    Dim countdown As Double
    Public Sub Update(gameTime As GameTime)
        If alive Then
            If countdown <= 0 Then
                ShootProjectile(Player.rect.Location.ToVector2, 3, Projectile.ProjectileTypes.Enemy)

                countdown = 500
            End If

            countdown -= gameTime.ElapsedGameTime.TotalMilliseconds
        End If
    End Sub
End Class
