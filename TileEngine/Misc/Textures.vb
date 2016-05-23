Imports Microsoft.Xna.Framework

Public Class Textures
    Public Shared grass As Graphics.Texture2D
    Public Shared brokenStone As Graphics.Texture2D
    Public Shared wood As Graphics.Texture2D

    Public Shared doorWood As Graphics.Texture2D


    Public Shared Bullet As Graphics.Texture2D

    Public Shared Sub LoadTextures(theContent As Content.ContentManager)
#Region "Tiles and Blocks"
        grass = theContent.Load(Of Graphics.Texture2D)("Textures/World/BlockTile/grass")
        brokenStone = theContent.Load(Of Graphics.Texture2D)("Textures/World/BlockTile/stone_broken")
        wood = theContent.Load(Of Graphics.Texture2D)("Textures/World/BlockTile/wood")
        Bullet = theContent.Load(Of Graphics.Texture2D)("Textures/Misc/bullet")
#End Region

#Region "Decals"
        doorWood = theContent.Load(Of Graphics.Texture2D)("Textures/World/Decals/door_wood")

#End Region


        FontKoot = theContent.Load(Of Graphics.SpriteFont)("Fonts/Koot")

        Player.SpriteTexture = theContent.Load(Of Graphics.Texture2D)("Textures/Characters/character")
        Enemy1.SpriteTexture = theContent.Load(Of Graphics.Texture2D)("Textures/Characters/blaeh")

        ShadowTexture = theContent.Load(Of Graphics.Texture2D)("Textures/Misc/shadow")
    End Sub
End Class
