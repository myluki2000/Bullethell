Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class Button

    Public rect As Rectangle
    Public Event Clicked()
    Public text As String = "Button"
    Public BackgroundColor As Color = Color.Gray
    Public BackgroundTexture As Texture2D
    Public ClickEffect As ClickEffects = ClickEffects.None
    Public ToggleButton As Boolean = False
    Public Checked As Boolean = False

    Public Enum ClickEffects
        None
        BlueBorder
    End Enum

    Dim lastMouseLBState As ButtonState

    Public Sub Draw(theSpriteBatch As SpriteBatch)
        ' Click detection

        If rect.Contains(Mouse.GetState.Position) AndAlso Mouse.GetState.LeftButton = ButtonState.Released AndAlso lastMouseLBState = ButtonState.Pressed Then
            If ToggleButton = False Then
                Select Case ClickEffect
                    Case ClickEffects.BlueBorder
                        DrawRectangle.Draw(theSpriteBatch, New Rectangle(rect.X - 2, rect.Y - 2, rect.Width + 4, rect.Height + 4), Color.LightBlue)
                End Select
            Else
                If Checked Then
                    Checked = False
                Else
                    Checked = True
                End If
            End If
            RaiseEvent Clicked()
        End If

        If ToggleButton = True AndAlso Checked = True Then
            DrawRectangle.Draw(theSpriteBatch, New Rectangle(rect.X - 2, rect.Y - 2, rect.Width + 4, rect.Height + 4), Color.LightBlue)
        End If


        ' Draw Background
        If BackgroundTexture Is Nothing Then
            DrawRectangle.Draw(theSpriteBatch, rect, BackgroundColor)
        Else
            theSpriteBatch.Draw(BackgroundTexture, rect, Color.White)
        End If
        ' Draw Button label
        theSpriteBatch.DrawString(FontKoot, text, New Vector2(CSng(rect.X + rect.Width / 2 - FontKoot.MeasureString(text).X / 2), CSng(rect.Y + rect.Height / 2 - FontKoot.MeasureString(text).Y / 2)), Color.Black)

        lastMouseLBState = Mouse.GetState.LeftButton
    End Sub
End Class
