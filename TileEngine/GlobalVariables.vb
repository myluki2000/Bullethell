Imports System.Collections.Generic
Imports Microsoft.Xna.Framework

Module GlobalVariables
#Region "Colors"
    Public ColorDarkerGray As New Microsoft.Xna.Framework.Color(90, 90, 90)
    Public ColorDarkererGray As New Microsoft.Xna.Framework.Color(70, 70, 70)
#End Region

    Public shadowTarget As Graphics.RenderTarget2D
    Public graphics As GraphicsDeviceManager


    Public Rooms As New List(Of Room)

    Public Blocks As New List(Of Block) ' Blocks
    Public Tiles As New List(Of Tile)
    Public Decals As New List(Of Decal)

    Public Characters As New List(Of Character)

    Public Player As New PlayerChar
    Public Enemy1 As New Enemy

    Public FontKoot As Graphics.SpriteFont

    Public ShadowTexture As Graphics.Texture2D
    Public SelectedScreen As Screens
    Public Enum Screens
        MainMenu
        MainGame
        Editor
    End Enum

    Public Function ToRad(degrees As Single) As Single
        Return CSng(degrees * Math.PI / 180)
    End Function

    Public Function AddRects(rect1 As Rectangle, rect2 As Rectangle) As Rectangle
        Return New Rectangle(rect1.X + rect2.X, rect1.Y + rect2.Y, rect1.Width + rect2.Width, rect1.Height + rect2.Height)
    End Function

    Public Function RectIncludes(rect1 As Rectangle, rect2 As Rectangle) As Boolean
        If rect1.Left <= rect2.Left AndAlso rect1.Top <= rect2.Top AndAlso rect1.Right >= rect2.Right AndAlso rect1.Bottom >= rect2.Bottom Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function RectIntersects(rect1 As Rectangle, rect2 As Rectangle) As Boolean
        If rect1.Intersects(rect2) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub Sleep(ByRef iMilliSeconds As Integer)
        Dim i As Integer, iHalfSeconds As Integer = CInt(iMilliSeconds / 500)
        For i = 1 To iHalfSeconds
            Threading.Thread.Sleep(500)
        Next i
    End Sub
End Module
