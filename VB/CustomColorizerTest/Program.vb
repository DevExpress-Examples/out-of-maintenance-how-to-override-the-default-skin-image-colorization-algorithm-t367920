Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports CustomColorizerTest.CustomColorizers
Imports DevExpress.LookAndFeel
Imports DevExpress.Skins

Namespace CustomColorizerTest
    Friend NotInheritable Class Program

        Private Sub New()
        End Sub

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)

            DevExpress.Skins.SkinManager.EnableFormSkins()
            DevExpress.UserSkins.BonusSkins.Register()
            UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful")
            UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(135, 35, 0)
            SkinImageColorizer.Default = New MainThemeColorizer()
            AddHandler UserLookAndFeel.Default.StyleChanged, AddressOf Program.OnStyleChanged
            Application.Run(New MainForm())
        End Sub

        Private Shared Sub OnStyleChanged(ByVal sender As Object, ByVal e As EventArgs)
            Select Case UserLookAndFeel.Default.SkinName
                Case "Office 2016 Colorful"
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(135, 35, 0)
                Case "Office 2013"
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(216, 52, 60)
                Case "Office 2013 Light Gray"
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(21, 181, 131)
                Case "Office 2010 Blue"
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(247, 192, 36)
                Case "Visual Studio 2013 Blue"
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(166, 164, 93)
                Case "Visual Studio 2013 Dark"
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(101, 87, 104)
                Case "Visual Studio 2013 Light"
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(99, 210, 103)
                Case "VS2010"
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(195, 92, 12)
                Case "High Contrast"
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(239, 120, 141)
                Case "Office 2007 Pink"
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(166, 221, 147)
                Case "McSkin"
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(130, 60, 125)
                Case "Blueprint"
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(108, 203, 194)
                Case Else
                    UserLookAndFeel.Default.SkinMaskColor = Color.Empty
            End Select
        End Sub
    End Class
End Namespace