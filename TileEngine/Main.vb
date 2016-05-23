#Region "Using Statements"
Imports System.Collections.Generic
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Content
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input
Imports Microsoft.Xna.Framework.Storage
#End Region

''' <summary>
''' This is the main type for your game
''' </summary>
Public Class Main
    Inherits Game

    Private spriteBatch As SpriteBatch


    Public Sub New()
        MyBase.New()
        graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Content"
    End Sub

    ''' <summary>
    ''' Allows the game to perform any initialization it needs to before starting to run.
    ''' This is where it can query for any required services and load any non-graphic
    ''' related content.  Calling base.Initialize will enumerate through any components
    ''' and initialize them as well.
    ''' </summary>
    Protected Overrides Sub Initialize()
        ' TODO: Add your initialization logic here
        'Dim rm As New Room




        shadowTarget = New RenderTarget2D(GraphicsDevice, GraphicsDevice.PresentationParameters.BackBufferWidth, GraphicsDevice.PresentationParameters.BackBufferHeight)

        IsMouseVisible = True

        Player.rect.Location = New Point(70, 180)
        Enemy1.rect.Location = New Point(300, 180)
        Player.Type = Character.CharacterTypes.Player
        Enemy1.Type = Character.CharacterTypes.Enemy
        Characters.Add(Player)
        Characters.Add(Enemy1)

        MyBase.Initialize()
    End Sub

    ''' <summary>
    ''' LoadContent will be called once per game and is the place to load
    ''' all of your content.
    ''' </summary>
    Protected Overrides Sub LoadContent()

        Textures.LoadTextures(Content)

        spriteBatch = New SpriteBatch(GraphicsDevice)

        Block.BlockWidth = 50
        Tile.TileWidth = 50



        Room.GenerateRoom()
        Decals.Add(New Decal(Textures.doorWood, Decal.Orientations.Left, New Vector2(2, 0)))
    End Sub

    ''' <summary>
    ''' UnloadContent will be called once per game and is the place to unload
    ''' all content.
    ''' </summary>
    Protected Overrides Sub UnloadContent()
        ' TODO: Unload any non ContentManager content here
    End Sub

    ''' <summary>
    ''' Allows the game to run logic such as updating the world,
    ''' checking for collisions, gathering input, and playing audio.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
    Protected Overrides Sub Update(gameTime As GameTime)
        If GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed OrElse Keyboard.GetState().IsKeyDown(Keys.Escape) Then
            End
        End If

        Select Case SelectedScreen
            Case Screens.Editor
                ScreenEditor.Update(gameTime)
            Case Screens.MainGame
                ScreenMainGame.Update(gameTime)
        End Select

        Sleep(5)
        MyBase.Update(gameTime)
    End Sub

    ''' <summary>
    ''' This is called when the game should draw itself.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
    Protected Overrides Sub Draw(gameTime As GameTime)

        graphics.GraphicsDevice.SetRenderTarget(Nothing)
        GraphicsDevice.Clear(Color.CornflowerBlue)

        Select Case SelectedScreen
            Case Screens.MainGame
                ScreenMainGame.Draw(spriteBatch, gameTime)

            Case Screens.Editor
                ScreenEditor.Draw(spriteBatch)
        End Select
        MyBase.Draw(gameTime)
    End Sub
End Class
