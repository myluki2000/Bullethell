Imports System.Collections.Generic
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class ScreenEditor

    Private Shared EditorBlocks As New List(Of Block)
    Shared WithEvents btnPlay As New Button With {.rect = New Rectangle(0, 0, 60, 30), .text = "Play"}
    Shared WithEvents btnSave As New Button With {.rect = New Rectangle(70, 0, 60, 30), .text = "Save"}
    Shared WithEvents btnBlock1 As New Button With {.rect = New Rectangle(142, 2, 26, 26), .text = "", .ClickEffect = Button.ClickEffects.BlueBorder, .ToggleButton = True}
    Shared WithEvents btnBlock2 As New Button With {.rect = New Rectangle(172, 2, 26, 26), .text = "", .ClickEffect = Button.ClickEffects.BlueBorder, .ToggleButton = True,
        .BackgroundTexture = Textures.brokenStone}
    Shared WithEvents btnBlock3 As New Button With {.rect = New Rectangle(202, 2, 26, 26), .text = "", .ClickEffect = Button.ClickEffects.BlueBorder, .ToggleButton = True,
        .BackgroundTexture = Textures.wood}

    Shared sprBatch As SpriteBatch

    Public Shared Sub Draw(theSpriteBatch As SpriteBatch)
        sprBatch = theSpriteBatch

        If Mouse.GetState.LeftButton = ButtonState.Pressed Then
            If btnBlock1.Checked Then
                EditorBlocks.Add(New Block(New Vector3(CSng(Math.Floor(Mouse.GetState.Position.X / Block.BlockWidth)), CSng(Math.Floor(Mouse.GetState.Position.Y / Block.BlockWidth)), 0)))

            ElseIf btnBlock2.Checked Then
                EditorBlocks.Add(New Block(New Vector3(CSng(Math.Floor(Mouse.GetState.Position.X / Block.BlockWidth)), CSng(Math.Floor(Mouse.GetState.Position.Y / Block.BlockWidth)), 0), True, Textures.brokenStone, True))

            ElseIf btnBlock3.Checked Then
                EditorBlocks.Add(New Block(New Vector3(CSng(Math.Floor(Mouse.GetState.Position.X / Block.BlockWidth)), CSng(Math.Floor(Mouse.GetState.Position.Y / Block.BlockWidth)), 0), True, Textures.wood, True))
            End If
        End If
        If Mouse.GetState.RightButton = ButtonState.Pressed Then
            For Each _block In EditorBlocks
                If _block.Position = New Vector3(CSng(Math.Floor(Mouse.GetState.Position.X / Block.BlockWidth)), CSng(Math.Floor(Mouse.GetState.Position.Y / Block.BlockWidth)), 0) Then
                    EditorBlocks.Remove(_block)
                    Exit For
                End If
            Next
        End If


        theSpriteBatch.Begin()
        For Each _block In EditorBlocks
            If _block.SpriteTexture Is Nothing Then
                DrawRectangle.Draw(theSpriteBatch, New Rectangle(CInt(_block.Position.X) * Block.BlockWidth, CInt(_block.Position.Y) * Block.BlockWidth, Block.BlockWidth, Block.BlockWidth), Color.Gray)
            Else
                theSpriteBatch.Draw(_block.SpriteTexture, New Rectangle(CInt(_block.Position.X) * Block.BlockWidth, CInt(_block.Position.Y) * Block.BlockWidth, Block.BlockWidth, Block.BlockWidth), New Rectangle(0, 0, _block.SpriteTexture.Width, CInt(_block.SpriteTexture.Height / 2)), Color.White)
            End If
        Next


        btnPlay.Draw(theSpriteBatch)
        btnSave.Draw(theSpriteBatch)
        btnBlock1.Draw(theSpriteBatch)
        btnBlock2.Draw(theSpriteBatch)
        btnBlock3.Draw(theSpriteBatch)

        theSpriteBatch.End()
    End Sub

    Public Shared Sub Update(gameTime As GameTime)
    End Sub

    Shared Sub btnPlay_Clicked() Handles btnPlay.Clicked
        Blocks.Clear()
        For i As Integer = 0 To 200
            For Each _block In EditorBlocks
                If _block.Position.Y = i Then
                    Blocks.Add(_block)
                End If
            Next
        Next


        ScreenMainGame.DrawShadows = True
        SelectedScreen = Screens.MainGame
    End Sub

    Shared Sub btnSave_Clicked() Handles btnSave.Clicked

    End Sub

    Shared Sub btnBlock1_Clicked() Handles btnBlock1.Clicked
        btnBlock2.Checked = False
        btnBlock3.Checked = False
    End Sub

    Shared Sub btnBlock2_Clicked() Handles btnBlock2.Clicked
        btnBlock1.Checked = False
        btnBlock3.Checked = False
    End Sub

    Shared Sub btnBlock3_Clicked() Handles btnBlock3.Clicked
        btnBlock1.Checked = False
        btnBlock2.Checked = False
    End Sub
End Class
