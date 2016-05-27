Imports Microsoft.Xna.Framework

Public Class Room
    Public Position As Vector2

    Public Shared Sub GenerateRoom()
        Blocks.Clear()
        Tiles.Clear()

        For iX As Integer = 0 To CInt(graphics.PreferredBackBufferWidth / Block.BlockWidth - 1)
            For iY As Integer = 1 To CInt(graphics.PreferredBackBufferHeight / Block.BlockWidth - 1)
                Tiles.Add(New Tile(New Vector2(iX, iY), Textures.brokenStone))
            Next
        Next

        For iX As Integer = 0 To CInt(graphics.PreferredBackBufferWidth / Block.BlockWidth - 1)
            Blocks.Add(New Block(New Vector3(iX, 0, 0), True))
            Blocks.Add(New Block(New Vector3(iX, CSng(graphics.PreferredBackBufferHeight / Block.BlockWidth) - 1, 0), True))
        Next

        For iY As Integer = 1 To CInt(graphics.PreferredBackBufferHeight / Block.BlockWidth - 1)
            Blocks.Add(New Block(New Vector3(0, iY, 0), True))
            Blocks.Add(New Block(New Vector3(CSng(graphics.PreferredBackBufferWidth / Block.BlockWidth) - 1, iY, 0), True))
        Next


        Decals.Add(New Decal(Textures.doorWood, Decal.Orientations.Down, New Vector2(CInt((graphics.PreferredBackBufferWidth / Block.BlockWidth - 1) / 2), 0)))
        Decals.Add(New Decal(Textures.doorWood, Decal.Orientations.Up, New Vector2(CInt((graphics.PreferredBackBufferWidth / Block.BlockWidth - 1) / 2),
                                                                                   CInt(graphics.PreferredBackBufferHeight / Block.BlockWidth - 1))))


        ScreenMainGame.DrawShadows = True
        ScreenMainGame.DrawPathfinding()
        SelectedScreen = Screens.MainGame
    End Sub
End Class
