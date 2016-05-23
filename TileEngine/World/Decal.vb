Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class Decal
    Public Enum Orientations
        Up
        Left
        Down
        Right
    End Enum

    Public Orientation As Orientations
    Public SpriteTexture As Texture2D
    Public Position As Vector2

    Dim srcRect As New Rectangle

    Public Sub New(theSpriteTexture As Texture2D, _orient As Orientations, _pos As Vector2)
        SpriteTexture = theSpriteTexture
        Orientation = _orient
        Position = _pos

        Select Case Orientation
            Case Orientations.Up
                srcRect = New Rectangle(0, 0, CInt(SpriteTexture.Width / 4), SpriteTexture.Height)
            Case Orientations.Left
                srcRect = New Rectangle(CInt(SpriteTexture.Width / 4), 0, CInt(SpriteTexture.Width / 4), SpriteTexture.Height)
            Case Orientations.Down
                srcRect = New Rectangle(CInt(SpriteTexture.Width / 4) * 2, 0, CInt(SpriteTexture.Width / 4), SpriteTexture.Height)
                MsgBox("dpown")
            Case Orientations.Right
                srcRect = New Rectangle(CInt(SpriteTexture.Width / 4) * 3, 0, CInt(SpriteTexture.Width / 4), SpriteTexture.Height)
        End Select
    End Sub

    Public Sub Draw(theSpriteBatch As SpriteBatch)
        theSpriteBatch.Draw(SpriteTexture, New Rectangle((Position * Block.BlockWidth).ToPoint, New Point(Block.BlockWidth, Block.BlockWidth * 2)), srcRect, Color.White)

    End Sub
End Class
