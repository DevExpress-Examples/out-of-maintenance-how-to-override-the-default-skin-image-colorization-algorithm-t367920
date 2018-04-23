Imports System.Collections.Generic
Imports System.Drawing
Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports DevExpress.Utils.Colors
Imports System.Linq

Namespace CustomColorizerTest.CustomColorizers
    Public Class MainThemeColorizer
        Inherits SkinImageColorizer

        Private ReadOnly MainThemeColorsBySkinName As Dictionary(Of String, Color)
        Private ReadOnly HueMaskColorsByThemeColor As Dictionary(Of Color, Color)

        Public Sub New()
            Me.MainThemeColorsBySkinName = New Dictionary(Of String, Color)()
            Me.HueMaskColorsByThemeColor = New Dictionary(Of Color, Color)()
            Me.AddDefaultMainThemeColors()
        End Sub

        Private ReadOnly Property MainThemeColor() As Color
            Get
                Return If(Me.MainThemeColorsBySkinName.ContainsKey(UserLookAndFeel.Default.SkinName), Me.MainThemeColorsBySkinName(UserLookAndFeel.Default.SkinName), Color.Empty)
            End Get
        End Property

        Protected Overrides Function ConvertColorByHueCore(ByVal color As Color, ByVal maskColor As Color) As Color
            If Me.IsMainThemeColor(color) Then
                Return maskColor
            End If
            Return MyBase.ConvertColorByHueCore(color, Me.GetHueMaskColor(maskColor))
        End Function

        Private Function IsMainThemeColor(ByVal color As Color) As Boolean
            Return Me.MainThemeColor = color
        End Function

        Private Shared Function PrepareHueMaskColor(ByVal themeColor As Color) As Color
            Dim hsb As HueSatBright = HueSatBright.FromColor(themeColor)
            hsb.Brightness = 1.0
            hsb.Saturation = 1.0
            Return hsb.AsRGB
        End Function

        Private Function GetHueMaskColor(ByVal themeColor As Color) As Color
            Dim result As Color = Color.Empty
            If Me.HueMaskColorsByThemeColor.TryGetValue(themeColor, result) Then
                Return result
            End If
            result = MainThemeColorizer.PrepareHueMaskColor(themeColor)
            Me.HueMaskColorsByThemeColor.Add(themeColor, result)
            Return result
        End Function

        Private Sub AddDefaultMainThemeColors()
            Me.SetSkinMainThemeColor("Office 2016 Colorful", Color.FromArgb(1, 115, 199))
            Me.SetSkinMainThemeColor("Office 2013", Color.FromArgb(0, 114, 198))
            Me.SetSkinMainThemeColor("Office 2013 Light Gray", Color.FromArgb(25, 71, 138))
            Me.SetSkinMainThemeColor("Office 2010 Blue", Color.FromArgb(207, 221, 238))
            Me.SetSkinMainThemeColor("Visual Studio 2013 Blue", Color.FromArgb(41, 57, 85))
            Me.SetSkinMainThemeColor("Visual Studio 2013 Dark", Color.FromArgb(0, 122, 204))
            Me.SetSkinMainThemeColor("Visual Studio 2013 Light", Color.FromArgb(0, 122, 204))
            Me.SetSkinMainThemeColor("VS2010", Color.FromArgb(43, 59, 88))
            Me.SetSkinMainThemeColor("High Contrast", Color.FromArgb(128, 0, 128))
            Me.SetSkinMainThemeColor("Office 2007 Green", Color.FromArgb(222, 239, 229))
            Me.SetSkinMainThemeColor("Office 2007 Pink", Color.FromArgb(219, 187, 196))
            Me.SetSkinMainThemeColor("McSkin", Color.FromArgb(209, 215, 226))
            Me.SetSkinMainThemeColor("Blueprint", Color.FromArgb(86, 119, 174))
        End Sub

        Private Sub SetSkinMainThemeColor(ByVal skinName As String, ByVal mainThemeColor As Color)
            Me.MainThemeColorsBySkinName(skinName) = mainThemeColor
        End Sub
    End Class
End Namespace
