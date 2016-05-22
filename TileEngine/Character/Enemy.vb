Imports Microsoft.Xna.Framework

Public Class Enemy
    Inherits Character

    Dim countdown As Double
    Public Sub Update(gameTime As GameTime)
        If alive AndAlso Player.alive Then
#Region "Shoot at player"
            If countdown <= 0 Then
                ShootProjectile(Player.rect.Location.ToVector2, 3, Projectile.ProjectileTypes.Enemy)

                countdown = 800
            End If

            countdown -= gameTime.ElapsedGameTime.TotalMilliseconds
#End Region

#Region "Walk towards player"
            MoveInDirection(Player.rect.Location.ToVector2 - rect.Location.ToVector2, 1)

#End Region


        End If
    End Sub
End Class
