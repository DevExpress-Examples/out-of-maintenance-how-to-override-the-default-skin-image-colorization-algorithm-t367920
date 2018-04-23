Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins


Namespace CustomColorizerTest
    Partial Public Class MainForm
        Inherits RibbonForm

        Public Sub New()
            InitializeComponent()
            InitSkinGallery()

        End Sub
        Private Sub InitSkinGallery()
            SkinHelper.InitSkinGallery(rgbiSkins, True)
        End Sub

    End Class
End Namespace