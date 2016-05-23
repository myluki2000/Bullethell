Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Input

Public Class PlayerChar
    Inherits Character

    Dim _counterShootCooldown As Double = 0
    Public ShootCooldown As Integer = 100

    Public Sub Update(gameTime As GameTime)
        If alive Then
            _counterShootCooldown -= gameTime.ElapsedGameTime.TotalMilliseconds

            If Keyboard.GetState.IsKeyDown(Keys.W) Then
                MoveInDirection(New Vector2(0, -1), 1)
            End If

            If Keyboard.GetState.IsKeyDown(Keys.A) Then
                MoveInDirection(New Vector2(-1, 0), 1)
            End If

            If Keyboard.GetState.IsKeyDown(Keys.S) Then
                MoveInDirection(New Vector2(0, 1), 1)
            End If

            If Keyboard.GetState.IsKeyDown(Keys.D) Then
                MoveInDirection(New Vector2(1, 0), 1)
            End If

            If Mouse.GetState.LeftButton = ButtonState.Pressed AndAlso _counterShootCooldown <= 0 Then
                ShootProjectile(Mouse.GetState.Position.ToVector2, 3, Projectile.ProjectileTypes.Player)
                _counterShootCooldown = ShootCooldown
            End If
        End If
    End Sub
End Class
