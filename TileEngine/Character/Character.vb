Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class Character
    Public rect As New Rectangle(0, 0, 10, 10)
    Public PositionZ As Integer = 0 'Z Position (Height) of the player in Blocks
    Public SpriteTexture As Texture2D
    Public alive As Boolean = True
    Public Type As CharacterTypes

    Public Enum CharacterTypes
        Player
        Enemy
    End Enum

    Public Sub New()

    End Sub

    Public Sub LoadTexture(texture As Texture2D)
        SpriteTexture = texture
    End Sub

    Public Sub Draw(theSpriteBatch As SpriteBatch)

        If alive Then
            DrawRectangle.Draw(theSpriteBatch, rect, Color.Green) ' Draw Bounding Box
            theSpriteBatch.Draw(SpriteTexture, New Rectangle(rect.X, rect.Y - SpriteTexture.Height + rect.Height, SpriteTexture.Width, SpriteTexture.Height), Color.White)
            rect.Width = SpriteTexture.Width - 6
        End If
    End Sub

    Public Function MoveUp() As Boolean

        For Each Block In Blocks
            If Block.BoundingBox.Intersects(New Rectangle(rect.X, rect.Y - 1, rect.Width, rect.Height)) AndAlso Block.Solid = True Then
                Return False
            End If
        Next

        rect.Y -= 1
        Return True
    End Function

    Public Function MoveLeft() As Boolean
        For Each Block In Blocks
            If Block.Position.Z = PositionZ AndAlso Block.BoundingBox.Intersects(New Rectangle(rect.X - 1, rect.Y, rect.Width, rect.Height)) AndAlso Block.Solid = True Then
                Return False
            End If
        Next


        rect.X -= 1
        Return True
    End Function

    Public Function MoveDown() As Boolean
        For Each Block In Blocks
            If Block.TopIsWalkable = True AndAlso Block.Position.Z = PositionZ AndAlso Block.BoundingBox.Intersects(New Rectangle(rect.X, rect.Y + 1, rect.Width, rect.Height)) AndAlso Block.Solid = True Then
                Return False
            End If
        Next


        rect.Y += 1
        Return True
    End Function

    Public Function MoveRight() As Boolean
        For Each Block In Blocks
            If Block.Position.Z = PositionZ AndAlso Block.BoundingBox.Intersects(New Rectangle(rect.X + 1, rect.Y, rect.Width, rect.Height)) AndAlso Block.Solid = True Then
                Return False
            End If
        Next

        rect.X += 1
        Return True
    End Function

    Public Sub ShootProjectile(target As Vector2, speed As Single, projType As Projectile.ProjectileTypes)
        Dim _direc As Vector2
        _direc.X = target.X - rect.X
        _direc.Y = target.Y - rect.Y
        _direc = (_direc / CSng(Math.Sqrt(_direc.X ^ 2 + _direc.Y ^ 2))) * speed

        If _direc.X.ToString <> "n. def." Then
            ScreenMainGame.Projectiles.Add(New Projectile With {.Direction = _direc, .Position = rect.Location.ToVector2, .ProjectileType = projType})
        End If
    End Sub
End Class
