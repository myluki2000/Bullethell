Imports System.Collections.Generic
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class ScreenMainGame

    Public Shared Projectiles As New List(Of Projectile)
    Public Shared DrawShadows As Boolean = True

    Public Shared Sub Draw(theSpriteBatch As SpriteBatch, theGameTime As GameTime)
        theSpriteBatch.Begin(Nothing, BlendState.AlphaBlend, SamplerState.LinearWrap, Nothing, Nothing, Nothing, Nothing)
        ' Draw default floor tile
        theSpriteBatch.Draw(Textures.grass, New Vector2(0, 0), New Rectangle(0, 0, 100000, 50000), Color.White)
        theSpriteBatch.End()

        theSpriteBatch.Begin(Nothing, BlendState.AlphaBlend, Nothing, Nothing, Nothing, Nothing, Nothing)
        ' Draw floor tiles
        For Each Tile In Tiles
            Tile.Draw(theSpriteBatch)
        Next


        ' Draw render target with shadows
        theSpriteBatch.Draw(shadowTarget, New Vector2(0, 0), Color.Black * 0.3F)


        ' Draw blocks behind player
        For Each Block In Blocks
            If Block.Position.Z < Player.PositionZ OrElse Block.rect.Y + Block.BlockWidth <= Player.rect.Y Then
                Block.Draw(theSpriteBatch)
            End If
        Next



        For Each Block In Blocks
            If Block.Position.Z = Player.PositionZ - 1 Then
                DrawRectangle.Draw(theSpriteBatch, New Rectangle(Block.rect.X, Block.rect.Y - Block.BlockWidth, Block.rect.Width, Block.rect.Height), Color.Red)
            End If
        Next




        ' Draw player
        Player.Draw(theSpriteBatch)



        ' Draw Projectiles
        For Each proj In Projectiles
            proj.Draw(theSpriteBatch)
        Next



        ' Draw blocks in front of player
        For Each Block In Blocks
            If Not Block.Position.Z < Player.PositionZ AndAlso Block.rect.Y + Block.BlockWidth > Player.rect.Y Then
                Block.Draw(theSpriteBatch)
            End If
        Next


        theSpriteBatch.End()

        If DrawShadows Then
            ' Draw shadows which will be saved to a render target
            graphics.GraphicsDevice.SetRenderTarget(shadowTarget)
            graphics.GraphicsDevice.Clear(Color.Transparent)
            theSpriteBatch.Begin()
            For Each Block In Blocks
                Block.DrawShadow(theSpriteBatch)
            Next
            theSpriteBatch.End()

            DrawShadows = False
        End If
    End Sub

    Public Shared Sub Update(gameTime As GameTime)
        Try
            For Each proj In Projectiles
                proj.Update(gameTime)

                If proj.landed = True Then
                    Projectiles.Remove(proj)
                End If
            Next
        Catch ex As InvalidOperationException

        End Try
    End Sub
End Class
