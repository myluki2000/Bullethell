Imports System.Collections.Generic
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class ScreenEditor

    Private Shared EditorBlocks As New List(Of Block)
    Shared WithEvents btnPlay As New Button With {.rect = New Rectangle(0, 0, 60, 30), .text = "Play"}
    Shared WithEvents btnSave As New Button With {.rect = New Rectangle(70, 0, 60, 30), .text = "Save"}
    Shared WithEvents btnBlock1 As New Button With {.rect = New Rectangle(142, 2, 26, 26), .text = "", .ClickEffect = Button.ClickEffects.BlueBorder, .ToggleButton = True,
        .BackgroundTexture = }

    Public Shared Sub Draw(theSpriteBatch As SpriteBatch)
        If Mouse.GetState.LeftButton = ButtonState.Pressed Then
            EditorBlocks.Add(New Block(New Vector3(CSng(Math.Floor(Mouse.GetState.Position.X / Block.BlockWidth)), CSng(Math.Floor(Mouse.GetState.Position.Y / Block.BlockWidth)), 0)))
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
            DrawRectangle.Draw(theSpriteBatch, New Rectangle(CInt(_block.Position.X) * Block.BlockWidth, CInt(_block.Position.Y) * Block.BlockWidth, 30, 30), Color.Red)

        Next


        btnPlay.Draw(theSpriteBatch)
        btnSave.Draw(theSpriteBatch)
        btnBlock1.Draw(theSpriteBatch)

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



        SelectedScreen = Screens.MainGame
    End Sub

    Shared Sub btnSave_Clicked() Handles btnSave.Clicked

    End Sub
End Class
