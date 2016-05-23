Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class Projectile
    Public Enum ProjectileTypes
        Player
        Enemy
    End Enum

    Public ProjectileType As ProjectileTypes
    Public Position As New Vector2(0, 0)
    Public Direction As New Vector2(1, 1)

    Public landed As Boolean = False

    Dim previousTime As Integer

    Dim TimeUntilDestroyed As Double = 5000

    Public Sub Update(gameTime As GameTime)


        TimeUntilDestroyed -= gameTime.ElapsedGameTime.TotalMilliseconds

        If TimeUntilDestroyed <= 0 AndAlso landed = False Then
            landed = True
            Direction = Vector2.Zero
        End If

        If gameTime.TotalGameTime.Milliseconds Mod 2 = 0 Then
            Try
                If ScreenMainGame.PathTexArray(CInt(Position.X), CInt(Position.Y)) = Color.Black Then
                    landed = True
                    Direction = Vector2.Zero
                    Return
                End If
            Catch ex As IndexOutOfRangeException
                ScreenMainGame.Projectiles.Remove(Me)
            End Try

            Position += Direction

            For Each _character In Characters
                If _character.Hitbox.Intersects(New Rectangle(CInt(Position.X), CInt(Position.Y), 10, 10)) Then
                    If _character.Type = Character.CharacterTypes.Player AndAlso ProjectileType = ProjectileTypes.Enemy Then
                        _character.alive = False
                    End If

                    If _character.Type = Character.CharacterTypes.Enemy AndAlso ProjectileType = ProjectileTypes.Player Then
                        _character.alive = False
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub Draw(theSpriteBatch As SpriteBatch)
        'DrawRectangle.Draw(theSpriteBatch, New Rectangle(CInt(Position.X), CInt(Position.Y), 10, 10), Color.Red)

        Dim rot As Single
        If Direction.X >= 0 Then
            rot = CSng(Math.Atan(Direction.Y / Direction.X)) + ToRad(90)
        Else
            rot = CSng(Math.Atan(Direction.Y / Direction.X)) + ToRad(-90)
        End If

        theSpriteBatch.Draw(Textures.Bullet, New Rectangle(CInt(Position.X), CInt(Position.Y), 10, 10), Nothing, Color.White, rot, New Vector2(5, 5), Nothing, 0)
    End Sub
End Class
