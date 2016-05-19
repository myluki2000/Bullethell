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
    Public Sub Update(gameTime As GameTime)
        If gameTime.TotalGameTime.Milliseconds Mod 2 = 0 Then
            Dim rect As Rectangle
            rect.Location = (Position + Direction).ToPoint
            rect.Width = 10
            rect.Height = 10

            previousTime = CInt(gameTime.TotalGameTime.TotalMilliseconds)

            For Each block In Blocks
                If rect.Intersects(block.BoundingBox) Then
                    landed = True
                    Direction = Vector2.Zero
                    Return
                End If
            Next

            Position += Direction


        End If

    End Sub

    Public Sub Draw(theSpriteBatch As SpriteBatch)
        DrawRectangle.Draw(theSpriteBatch, New Rectangle(CInt(Position.X), CInt(Position.Y), 10, 10), Color.Red)
    End Sub
End Class
