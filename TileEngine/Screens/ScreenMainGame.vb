Imports System.Collections.Generic
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class ScreenMainGame

    Public Shared Projectiles As New List(Of Projectile)
    Public Shared DrawShadows As Boolean = True
    Public Shared PathTexArray As Color(,)

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

        Enemy1.Draw(theSpriteBatch)


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
        Enemy1.Update(gameTime)
        Player.Update(gameTime)

        Try
            For Each proj In Projectiles
                proj.Update(gameTime)

                'If proj.landed = True Then
                '    Projectiles.Remove(proj)
                'End If
            Next
        Catch ex As InvalidOperationException

        End Try
    End Sub

    Shared tex As Texture2D
    Public Shared Sub DrawPathfinding()
        Dim theSpriteBatch As New SpriteBatch(graphics.GraphicsDevice)

        Dim renderTargetPath As New RenderTarget2D(graphics.GraphicsDevice,
            graphics.PreferredBackBufferWidth,
            graphics.PreferredBackBufferHeight)

        graphics.GraphicsDevice.SetRenderTarget(renderTargetPath)
        graphics.GraphicsDevice.Clear(Color.Gray)

        theSpriteBatch.Begin()
        For Each block In Blocks
            DrawRectangle.Draw(theSpriteBatch, block.BoundingBox, Color.Black)
        Next
        theSpriteBatch.End()

        graphics.GraphicsDevice.SetRenderTarget(Nothing)

        PathTexArray = TextureTo2DArray(renderTargetPath)
        tex = renderTargetPath
    End Sub


    Shared Function TextureTo2DArray(texture As Texture2D) As Color(,)
        Dim colors1D As Color() = New Color(texture.Width * texture.Height - 1) {}
        texture.GetData(colors1D)


        Dim colors2D As Color(,) = New Color(texture.Width - 1, texture.Height - 1) {}
        For x As Integer = 0 To texture.Width - 1
            For y As Integer = 0 To texture.Height - 1
                colors2D(x, y) = colors1D(x + y * texture.Width)
            Next
        Next

        Return colors2D
    End Function
End Class
